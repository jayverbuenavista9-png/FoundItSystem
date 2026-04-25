CREATE TABLE Users (
    Username NVARCHAR(50) PRIMARY KEY,
    Password NVARCHAR(100) NOT NULL
);

CREATE TABLE Items (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(MAX),
    OwnerName NVARCHAR(50),
    Category NVARCHAR(50),
    Status NVARCHAR(50),
    Claimant NVARCHAR(50) NULL,
    IsDeleted BIT DEFAULT 0,
    ReportedAt DATETIME DEFAULT GETDATE()
);

CREATE TABLE Comments (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    ItemID INT FOREIGN KEY REFERENCES Items(ID),
    Username NVARCHAR(50),
    Message NVARCHAR(MAX),
    CreatedAt DATETIME DEFAULT GETDATE()
);

CREATE TABLE Notifications (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50),
    Message NVARCHAR(MAX),
    IsRead BIT DEFAULT 0,
    CreatedAt DATETIME DEFAULT GETDATE()
);

-- Insert the default admin account
INSERT INTO Users (Username, Password) VALUES ('admin', 'admin123');