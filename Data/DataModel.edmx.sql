
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 10/31/2011 20:22:47
-- Generated from EDMX file: d:\_mb\School\FEL\Predmety\A7B36PRO\ELearning\Data\DataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ELearning];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_QuestionGroupQuestion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Question] DROP CONSTRAINT [FK_QuestionGroupQuestion];
GO
IF OBJECT_ID(N'[dbo].[FK_QuestionGroupQuestionGroupType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[QuestionGroup] DROP CONSTRAINT [FK_QuestionGroupQuestionGroupType];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Question]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Question];
GO
IF OBJECT_ID(N'[dbo].[QuestionGroup]', 'U') IS NOT NULL
    DROP TABLE [dbo].[QuestionGroup];
GO
IF OBJECT_ID(N'[dbo].[QuestionGroupType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[QuestionGroupType];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Question'
CREATE TABLE [dbo].[Question] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Text] nvarchar(max)  NOT NULL,
    [HelpText] nvarchar(max)  NULL,
    [ImageUrl] nvarchar(max)  NULL,
    [Explanation] nvarchar(max)  NULL,
    [QuestionGroupID] int  NOT NULL
);
GO

-- Creating table 'QuestionGroup'
CREATE TABLE [dbo].[QuestionGroup] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Index] int  NOT NULL,
    [IsRequired] bit  NOT NULL,
    [QuestionGroupTypeID] int  NOT NULL,
    [FormTemplateID] int  NOT NULL
);
GO

-- Creating table 'QuestionGroupType'
CREATE TABLE [dbo].[QuestionGroupType] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'User'
CREATE TABLE [dbo].[User] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [UserTypeID] int  NOT NULL
);
GO

-- Creating table 'Group'
CREATE TABLE [dbo].[Group] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [SupervisorID] int  NOT NULL
);
GO

-- Creating table 'UserType'
CREATE TABLE [dbo].[UserType] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Form'
CREATE TABLE [dbo].[Form] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Text] nvarchar(max)  NOT NULL,
    [TimeToFill] datetime  NULL,
    [Shuffle] bit  NOT NULL,
    [Created] datetime  NOT NULL,
    [FormTypeID] int  NOT NULL,
    [AuthorID] int  NOT NULL
);
GO

-- Creating table 'FormType'
CREATE TABLE [dbo].[FormType] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'FormInstance'
CREATE TABLE [dbo].[FormInstance] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Created] datetime  NOT NULL,
    [Submited] datetime  NOT NULL,
    [SolverID] int  NOT NULL,
    [FormTemplateID] int  NOT NULL,
    [Evaluation_ID] int  NOT NULL
);
GO

-- Creating table 'QuestionInstance'
CREATE TABLE [dbo].[QuestionInstance] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Index] int  NOT NULL,
    [QuestionID] int  NOT NULL,
    [FormInstanceID] int  NOT NULL
);
GO

-- Creating table 'FormInstanceEvaluation'
CREATE TABLE [dbo].[FormInstanceEvaluation] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Mark] nvarchar(max)  NOT NULL,
    [Note] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Answer'
CREATE TABLE [dbo].[Answer] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [QuestionInstanceAnswer_Answer_ID] int  NOT NULL
);
GO

-- Creating table 'ChoiceItem'
CREATE TABLE [dbo].[ChoiceItem] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [ChoiceQuestionID] int  NOT NULL,
    [Text] nvarchar(max)  NOT NULL,
    [Index] int  NOT NULL,
    [IsCorrect] bit  NOT NULL,
    [Explanation] nvarchar(max)  NOT NULL,
    [ImageUrl] nvarchar(max)  NULL
);
GO

-- Creating table 'Question_ChoiceQuestion'
CREATE TABLE [dbo].[Question_ChoiceQuestion] (
    [Shuffle] nvarchar(max)  NOT NULL,
    [ID] int  NOT NULL
);
GO

-- Creating table 'Answer_TextAnswer'
CREATE TABLE [dbo].[Answer_TextAnswer] (
    [Text] nvarchar(max)  NOT NULL,
    [ID] int  NOT NULL
);
GO

-- Creating table 'Answer_ChoiceAnswer'
CREATE TABLE [dbo].[Answer_ChoiceAnswer] (
    [Index] int  NOT NULL,
    [ID] int  NOT NULL
);
GO

-- Creating table 'Answer_ScaleAnswer'
CREATE TABLE [dbo].[Answer_ScaleAnswer] (
    [Value] int  NOT NULL,
    [ID] int  NOT NULL
);
GO

-- Creating table 'Question_ScaleQuestion'
CREATE TABLE [dbo].[Question_ScaleQuestion] (
    [MinValue] int  NOT NULL,
    [MinValueText] nvarchar(max)  NOT NULL,
    [MaxValue] int  NOT NULL,
    [MaxValueText] nvarchar(max)  NOT NULL,
    [Increment] int  NOT NULL,
    [ID] int  NOT NULL
);
GO

-- Creating table 'GroupMembers'
CREATE TABLE [dbo].[GroupMembers] (
    [Groups_ID] int  NOT NULL,
    [Members_ID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'Question'
ALTER TABLE [dbo].[Question]
ADD CONSTRAINT [PK_Question]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'QuestionGroup'
ALTER TABLE [dbo].[QuestionGroup]
ADD CONSTRAINT [PK_QuestionGroup]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'QuestionGroupType'
ALTER TABLE [dbo].[QuestionGroupType]
ADD CONSTRAINT [PK_QuestionGroupType]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [PK_User]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Group'
ALTER TABLE [dbo].[Group]
ADD CONSTRAINT [PK_Group]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'UserType'
ALTER TABLE [dbo].[UserType]
ADD CONSTRAINT [PK_UserType]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Form'
ALTER TABLE [dbo].[Form]
ADD CONSTRAINT [PK_Form]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'FormType'
ALTER TABLE [dbo].[FormType]
ADD CONSTRAINT [PK_FormType]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'FormInstance'
ALTER TABLE [dbo].[FormInstance]
ADD CONSTRAINT [PK_FormInstance]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'QuestionInstance'
ALTER TABLE [dbo].[QuestionInstance]
ADD CONSTRAINT [PK_QuestionInstance]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'FormInstanceEvaluation'
ALTER TABLE [dbo].[FormInstanceEvaluation]
ADD CONSTRAINT [PK_FormInstanceEvaluation]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Answer'
ALTER TABLE [dbo].[Answer]
ADD CONSTRAINT [PK_Answer]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'ChoiceItem'
ALTER TABLE [dbo].[ChoiceItem]
ADD CONSTRAINT [PK_ChoiceItem]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Question_ChoiceQuestion'
ALTER TABLE [dbo].[Question_ChoiceQuestion]
ADD CONSTRAINT [PK_Question_ChoiceQuestion]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Answer_TextAnswer'
ALTER TABLE [dbo].[Answer_TextAnswer]
ADD CONSTRAINT [PK_Answer_TextAnswer]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Answer_ChoiceAnswer'
ALTER TABLE [dbo].[Answer_ChoiceAnswer]
ADD CONSTRAINT [PK_Answer_ChoiceAnswer]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Answer_ScaleAnswer'
ALTER TABLE [dbo].[Answer_ScaleAnswer]
ADD CONSTRAINT [PK_Answer_ScaleAnswer]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Question_ScaleQuestion'
ALTER TABLE [dbo].[Question_ScaleQuestion]
ADD CONSTRAINT [PK_Question_ScaleQuestion]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [Groups_ID], [Members_ID] in table 'GroupMembers'
ALTER TABLE [dbo].[GroupMembers]
ADD CONSTRAINT [PK_GroupMembers]
    PRIMARY KEY NONCLUSTERED ([Groups_ID], [Members_ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [QuestionGroupID] in table 'Question'
ALTER TABLE [dbo].[Question]
ADD CONSTRAINT [FK_QuestionGroupQuestion]
    FOREIGN KEY ([QuestionGroupID])
    REFERENCES [dbo].[QuestionGroup]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_QuestionGroupQuestion'
CREATE INDEX [IX_FK_QuestionGroupQuestion]
ON [dbo].[Question]
    ([QuestionGroupID]);
GO

-- Creating foreign key on [QuestionGroupTypeID] in table 'QuestionGroup'
ALTER TABLE [dbo].[QuestionGroup]
ADD CONSTRAINT [FK_QuestionGroupQuestionGroupType]
    FOREIGN KEY ([QuestionGroupTypeID])
    REFERENCES [dbo].[QuestionGroupType]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_QuestionGroupQuestionGroupType'
CREATE INDEX [IX_FK_QuestionGroupQuestionGroupType]
ON [dbo].[QuestionGroup]
    ([QuestionGroupTypeID]);
GO

-- Creating foreign key on [SupervisorID] in table 'Group'
ALTER TABLE [dbo].[Group]
ADD CONSTRAINT [FK_Supervisor]
    FOREIGN KEY ([SupervisorID])
    REFERENCES [dbo].[User]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Supervisor'
CREATE INDEX [IX_FK_Supervisor]
ON [dbo].[Group]
    ([SupervisorID]);
GO

-- Creating foreign key on [Groups_ID] in table 'GroupMembers'
ALTER TABLE [dbo].[GroupMembers]
ADD CONSTRAINT [FK_GroupMembers_Group]
    FOREIGN KEY ([Groups_ID])
    REFERENCES [dbo].[Group]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Members_ID] in table 'GroupMembers'
ALTER TABLE [dbo].[GroupMembers]
ADD CONSTRAINT [FK_GroupMembers_User]
    FOREIGN KEY ([Members_ID])
    REFERENCES [dbo].[User]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_GroupMembers_User'
CREATE INDEX [IX_FK_GroupMembers_User]
ON [dbo].[GroupMembers]
    ([Members_ID]);
GO

-- Creating foreign key on [UserTypeID] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [FK_UserUserType]
    FOREIGN KEY ([UserTypeID])
    REFERENCES [dbo].[UserType]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserUserType'
CREATE INDEX [IX_FK_UserUserType]
ON [dbo].[User]
    ([UserTypeID]);
GO

-- Creating foreign key on [FormTypeID] in table 'Form'
ALTER TABLE [dbo].[Form]
ADD CONSTRAINT [FK_FormTemplateFormType]
    FOREIGN KEY ([FormTypeID])
    REFERENCES [dbo].[FormType]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FormTemplateFormType'
CREATE INDEX [IX_FK_FormTemplateFormType]
ON [dbo].[Form]
    ([FormTypeID]);
GO

-- Creating foreign key on [AuthorID] in table 'Form'
ALTER TABLE [dbo].[Form]
ADD CONSTRAINT [FK_FormTemplateAuthor]
    FOREIGN KEY ([AuthorID])
    REFERENCES [dbo].[User]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FormTemplateAuthor'
CREATE INDEX [IX_FK_FormTemplateAuthor]
ON [dbo].[Form]
    ([AuthorID]);
GO

-- Creating foreign key on [FormTemplateID] in table 'QuestionGroup'
ALTER TABLE [dbo].[QuestionGroup]
ADD CONSTRAINT [FK_QuestionGroupFormTemplate]
    FOREIGN KEY ([FormTemplateID])
    REFERENCES [dbo].[Form]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_QuestionGroupFormTemplate'
CREATE INDEX [IX_FK_QuestionGroupFormTemplate]
ON [dbo].[QuestionGroup]
    ([FormTemplateID]);
GO

-- Creating foreign key on [SolverID] in table 'FormInstance'
ALTER TABLE [dbo].[FormInstance]
ADD CONSTRAINT [FK_FormInstanceUser]
    FOREIGN KEY ([SolverID])
    REFERENCES [dbo].[User]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FormInstanceUser'
CREATE INDEX [IX_FK_FormInstanceUser]
ON [dbo].[FormInstance]
    ([SolverID]);
GO

-- Creating foreign key on [FormTemplateID] in table 'FormInstance'
ALTER TABLE [dbo].[FormInstance]
ADD CONSTRAINT [FK_FormInstanceFormTemplate]
    FOREIGN KEY ([FormTemplateID])
    REFERENCES [dbo].[Form]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FormInstanceFormTemplate'
CREATE INDEX [IX_FK_FormInstanceFormTemplate]
ON [dbo].[FormInstance]
    ([FormTemplateID]);
GO

-- Creating foreign key on [QuestionID] in table 'QuestionInstance'
ALTER TABLE [dbo].[QuestionInstance]
ADD CONSTRAINT [FK_QuestionInstanceQuestionTemplate]
    FOREIGN KEY ([QuestionID])
    REFERENCES [dbo].[Question]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_QuestionInstanceQuestionTemplate'
CREATE INDEX [IX_FK_QuestionInstanceQuestionTemplate]
ON [dbo].[QuestionInstance]
    ([QuestionID]);
GO

-- Creating foreign key on [FormInstanceID] in table 'QuestionInstance'
ALTER TABLE [dbo].[QuestionInstance]
ADD CONSTRAINT [FK_FormInstanceQuestionInstance]
    FOREIGN KEY ([FormInstanceID])
    REFERENCES [dbo].[FormInstance]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FormInstanceQuestionInstance'
CREATE INDEX [IX_FK_FormInstanceQuestionInstance]
ON [dbo].[QuestionInstance]
    ([FormInstanceID]);
GO

-- Creating foreign key on [Evaluation_ID] in table 'FormInstance'
ALTER TABLE [dbo].[FormInstance]
ADD CONSTRAINT [FK_FormInstanceFormInstanceEvaluation]
    FOREIGN KEY ([Evaluation_ID])
    REFERENCES [dbo].[FormInstanceEvaluation]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FormInstanceFormInstanceEvaluation'
CREATE INDEX [IX_FK_FormInstanceFormInstanceEvaluation]
ON [dbo].[FormInstance]
    ([Evaluation_ID]);
GO

-- Creating foreign key on [QuestionInstanceAnswer_Answer_ID] in table 'Answer'
ALTER TABLE [dbo].[Answer]
ADD CONSTRAINT [FK_QuestionInstanceAnswer]
    FOREIGN KEY ([QuestionInstanceAnswer_Answer_ID])
    REFERENCES [dbo].[QuestionInstance]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_QuestionInstanceAnswer'
CREATE INDEX [IX_FK_QuestionInstanceAnswer]
ON [dbo].[Answer]
    ([QuestionInstanceAnswer_Answer_ID]);
GO

-- Creating foreign key on [ChoiceQuestionID] in table 'ChoiceItem'
ALTER TABLE [dbo].[ChoiceItem]
ADD CONSTRAINT [FK_ChoiceQuestionChoiceItem]
    FOREIGN KEY ([ChoiceQuestionID])
    REFERENCES [dbo].[Question_ChoiceQuestion]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ChoiceQuestionChoiceItem'
CREATE INDEX [IX_FK_ChoiceQuestionChoiceItem]
ON [dbo].[ChoiceItem]
    ([ChoiceQuestionID]);
GO

-- Creating foreign key on [ID] in table 'Question_ChoiceQuestion'
ALTER TABLE [dbo].[Question_ChoiceQuestion]
ADD CONSTRAINT [FK_ChoiceQuestion_inherits_Question]
    FOREIGN KEY ([ID])
    REFERENCES [dbo].[Question]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ID] in table 'Answer_TextAnswer'
ALTER TABLE [dbo].[Answer_TextAnswer]
ADD CONSTRAINT [FK_TextAnswer_inherits_Answer]
    FOREIGN KEY ([ID])
    REFERENCES [dbo].[Answer]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ID] in table 'Answer_ChoiceAnswer'
ALTER TABLE [dbo].[Answer_ChoiceAnswer]
ADD CONSTRAINT [FK_ChoiceAnswer_inherits_Answer]
    FOREIGN KEY ([ID])
    REFERENCES [dbo].[Answer]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ID] in table 'Answer_ScaleAnswer'
ALTER TABLE [dbo].[Answer_ScaleAnswer]
ADD CONSTRAINT [FK_ScaleAnswer_inherits_Answer]
    FOREIGN KEY ([ID])
    REFERENCES [dbo].[Answer]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ID] in table 'Question_ScaleQuestion'
ALTER TABLE [dbo].[Question_ScaleQuestion]
ADD CONSTRAINT [FK_ScaleQuestion_inherits_Question]
    FOREIGN KEY ([ID])
    REFERENCES [dbo].[Question]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------