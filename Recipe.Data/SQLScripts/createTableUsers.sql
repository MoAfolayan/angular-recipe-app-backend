create table Users (
    Id int NOT NULL PRIMARY KEY IDENTITY(1,1),
    Auth0Id nvarchar(255) NOT NULL,
    Email nvarchar(255) NULL,
    FirstName nvarchar(50) NOT NULL,
    LastName nvarchar(50) NOT NULL,
    IsActive bit NOT NULL DEFAULT 1,
    CreatedDate datetime NOT NULL DEFAULT GETUTCDATE()
)