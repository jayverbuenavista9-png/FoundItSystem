using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FoundItSystem
{
    internal static class Program
    {
        const string MASTER_CONN = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;";

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try   { EnsureDatabase(); }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not set up the database.\n\n" + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Application.Run(new LoginForm());
        }

        static void EnsureDatabase()
        {
            // 1. Create the DB if it doesn't exist yet
            using (var conn = new SqlConnection(MASTER_CONN))
            {
                conn.Open();
                var cmd = new SqlCommand(
                    "IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'FoundItDB') " +
                    "CREATE DATABASE FoundItDB", conn);
                cmd.ExecuteNonQuery();
            }

            // 2. Create tables if they don't exist
            using (var conn = new SqlConnection(AppConfig.Conn))
            {
                conn.Open();

                Run(conn, @"
                    IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Users' AND xtype='U')
                    CREATE TABLE Users (
                        Username NVARCHAR(50) PRIMARY KEY,
                        Password NVARCHAR(100) NOT NULL
                    )");

                Run(conn, @"
                    IF NOT EXISTS (SELECT * FROM sys.columns WHERE Name = 'Phone' AND Object_ID = OBJECT_ID('Users'))
                    BEGIN
                        ALTER TABLE Users ADD Phone NVARCHAR(20) NULL, Email NVARCHAR(100) NULL;
                    END");

                Run(conn, @"
                    IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Items' AND xtype='U')
                    CREATE TABLE Items (
                        ID          INT IDENTITY(1,1) PRIMARY KEY,
                        Name        NVARCHAR(100) NOT NULL,
                        Description NVARCHAR(MAX),
                        OwnerName   NVARCHAR(50),
                        Category    NVARCHAR(50),
                        Status      NVARCHAR(50),
                        Claimant    NVARCHAR(50) NULL,
                        IsDeleted   BIT DEFAULT 0,
                        ReportedAt  DATETIME DEFAULT GETDATE()
                    )");

                Run(conn, @"
                    IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Comments' AND xtype='U')
                    CREATE TABLE Comments (
                        ID        INT IDENTITY(1,1) PRIMARY KEY,
                        ItemID    INT FOREIGN KEY REFERENCES Items(ID),
                        Username  NVARCHAR(50),
                        Message   NVARCHAR(MAX),
                        CreatedAt DATETIME DEFAULT GETDATE()
                    )");

                Run(conn, @"
                    IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Notifications' AND xtype='U')
                    CREATE TABLE Notifications (
                        ID        INT IDENTITY(1,1) PRIMARY KEY,
                        Username  NVARCHAR(50),
                        Message   NVARCHAR(MAX),
                        IsRead    BIT DEFAULT 0,
                        CreatedAt DATETIME DEFAULT GETDATE()
                    )");

                // 3. Seed default admin account if table is empty
                var count = (int)new SqlCommand("SELECT COUNT(*) FROM Users", conn).ExecuteScalar();
                if (count == 0)
                    Run(conn, "INSERT INTO Users (Username, Password) VALUES ('admin', 'admin123')");
            }
        }

        static void Run(SqlConnection conn, string sql)
            => new SqlCommand(sql, conn).ExecuteNonQuery();
    }
}
