
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 10/29/2011 18:43:46
-- Generated from EDMX file: D:\_mb\School\FEL\Predmety\A7B36PRO\ELearning\Data\DataModel.edmx
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
    ALTER TABLE [dbo].[QuestionSet] DROP CONSTRAINT [FK_QuestionGroupQuestion];
GO
IF OBJECT_ID(N'[dbo].[FK_QuestionGroupQuestionGroupType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[QuestionGroupSet] DROP CONSTRAINT [FK_QuestionGroupQuestionGroupType];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[QuestionSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[QuestionSet];
GO
IF OBJECT_ID(N'[dbo].[QuestionGroupSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[QuestionGroupSet];
GO
IF OBJECT_ID(N'[dbo].[QuestionGroupTypeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[QuestionGroupTypeSet];
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
    [QuestionGroupTypeID] int  NOT NULL
);
GO

-- Creating table 'QuestionGroupType'
CREATE TABLE [dbo].[QuestionGroupType] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
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

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------