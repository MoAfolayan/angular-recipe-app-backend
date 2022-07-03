create table Recipe
(
    Id int NOT NULL PRIMARY KEY IDENTITY(1,1),
    Name nvarchar(255) NOT NULL,
    UserId int NOT NULL FOREIGN KEY REFERENCES [dbo].[User](Id),
    IsActive bit NOT NULL DEFAULT 1,
    CreatedDate datetime NOT NULL DEFAULT GETUTCDATE()
)