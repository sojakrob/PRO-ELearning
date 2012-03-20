-- Creating table 'QuestionGroup'
-- Creating table 'QuestionGroup'
-- Creating table 'QuestionGroup'
-- Creating table 'QuestionGroup'
CREATE TABLE [dbo].[QuestionGroup] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Index] int  NOT NULL,
    [IsRequired] bit  NOT NULL,
    [QuestionGroupTypeID] int  NOT NULL,
    [FormTemplateID] int  NOT NULL
);











