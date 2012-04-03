-- Creating table 'TextBook'
CREATE TABLE [dbo].[TextBook] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Created] datetime  NOT NULL,
    [Changed] datetime  NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Text] nvarchar(max)  NOT NULL,
    [CreatedByID] int  NOT NULL,
    [ChangedByID] int  NOT NULL,
    [VisibleToOthers] bit  NOT NULL,
    [Html] nvarchar(max)  NOT NULL
);


