create table CheckListItem (
    Id int NOT NULL PRIMARY KEY IDENTITY(1,1),
    CheckListId int NOT NULL FOREIGN KEY REFERENCES CheckList(Id),
    IngredientId int NOT NULL FOREIGN KEY REFERENCES Ingredient(Id),
    IsChecked bit NOT NULL DEFAULT 0,
    IsActive bit NOT NULL DEFAULT 1,
    CreatedDate datetime NOT NULL DEFAULT GETUTCDATE()
)