-- Creating table 'ChoiceItem'
CREATE TABLE [dbo].[ChoiceItem] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [ChoiceQuestionID] int  NOT NULL,
    [Text] nvarchar(max)  NOT NULL,
    [Index] int  NOT NULL,
    [IsCorrect] bit  NOT NULL,
    [Explanation] nvarchar(max)  NULL,
    [ImageUrl] nvarchar(max)  NULL
);


