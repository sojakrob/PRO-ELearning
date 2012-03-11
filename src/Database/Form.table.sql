-- Creating table 'Form'
CREATE TABLE [dbo].[Form] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Text] nvarchar(max)  NULL,
    [TimeToFill] int  NULL,
    [Shuffle] bit  NOT NULL,
    [Created] datetime  NOT NULL,
    [FormTypeID] int  NOT NULL,
    [AuthorID] int  NOT NULL,
    [FormStateID] int  NOT NULL
);


