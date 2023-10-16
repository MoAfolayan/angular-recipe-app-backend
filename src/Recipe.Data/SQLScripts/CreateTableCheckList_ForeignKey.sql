create table
    CheckList (
        Id int NOT NULL PRIMARY KEY IDENTITY (1, 1),
        RecipeId int NOT NULL FOREIGN KEY REFERENCES Recipe (Id),
        IsActive bit NOT NULL DEFAULT 1,
        CreatedDate datetime NOT NULL DEFAULT GETUTCDATE ()
    )