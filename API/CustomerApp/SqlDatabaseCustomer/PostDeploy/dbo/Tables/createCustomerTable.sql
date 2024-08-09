CREATE TABLE [dbo].[Customer] (
    [Id] INT NOT NULL,
    [Birthday] DATE NOT NULL,
    [FirstName] VARCHAR (70) NOT NULL,
    [LastName] VARCHAR (70) NOT NULL,
    CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED ([Id])
);