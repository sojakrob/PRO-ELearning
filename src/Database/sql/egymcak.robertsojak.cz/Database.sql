/*
Deployment script for rsojak_egymcak
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "rsojak_egymcak"
:setvar DefaultDataPath "C:\Program Files (x86)\Microsoft SQL Server\MSSQL.1\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files (x86)\Microsoft SQL Server\MSSQL.1\MSSQL\DATA\"

GO
:on error exit
GO
USE [master]
GO
IF (DB_ID(N'$(DatabaseName)') IS NOT NULL
    AND DATABASEPROPERTYEX(N'$(DatabaseName)','Status') <> N'ONLINE')
BEGIN
    RAISERROR(N'The state of the target database, %s, is not set to ONLINE. To deploy to this database, its state must be set to ONLINE.', 16, 127,N'$(DatabaseName)') WITH NOWAIT
    RETURN
END

GO
IF (DB_ID(N'$(DatabaseName)') IS NOT NULL) 
BEGIN
    ALTER DATABASE [$(DatabaseName)]
    SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [$(DatabaseName)];
END

GO
PRINT N'Creating $(DatabaseName)...'
GO
CREATE DATABASE [$(DatabaseName)]
    ON 
    PRIMARY(NAME = [rsojak_egymcak], FILENAME = N'$(DefaultDataPath)rsojak_egymcak.mdf')
    LOG ON (NAME = [rsojak_egymcak_log], FILENAME = N'$(DefaultLogPath)rsojak_egymcak_log.ldf') COLLATE SQL_Latin1_General_CP1_CI_AS
GO
USE [$(DatabaseName)]
GO
/*
 Pre-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be executed before the build script.	
 Use SQLCMD syntax to include a file in the pre-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the pre-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

GO
PRINT N'Creating [dbo].[Answer]...';


GO
CREATE TABLE [dbo].[Answer] (
    [ID]                               INT IDENTITY (1, 1) NOT NULL,
    [QuestionInstanceAnswer_Answer_ID] INT NOT NULL
);


GO
PRINT N'Creating PK_Answer...';


GO
ALTER TABLE [dbo].[Answer]
    ADD CONSTRAINT [PK_Answer] PRIMARY KEY CLUSTERED ([ID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[Answer].[IX_FK_QuestionInstanceAnswer]...';


GO
CREATE NONCLUSTERED INDEX [IX_FK_QuestionInstanceAnswer]
    ON [dbo].[Answer]([QuestionInstanceAnswer_Answer_ID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF, ONLINE = OFF, MAXDOP = 0);


GO
PRINT N'Creating [dbo].[Answer_ChoiceAnswer]...';


GO
CREATE TABLE [dbo].[Answer_ChoiceAnswer] (
    [ItemID] INT NOT NULL,
    [ID]     INT NOT NULL
);


GO
PRINT N'Creating PK_Answer_ChoiceAnswer...';


GO
ALTER TABLE [dbo].[Answer_ChoiceAnswer]
    ADD CONSTRAINT [PK_Answer_ChoiceAnswer] PRIMARY KEY CLUSTERED ([ID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[Answer_ChoiceAnswer].[IX_FK_ChoiceAnswerChoiceItem]...';


GO
CREATE NONCLUSTERED INDEX [IX_FK_ChoiceAnswerChoiceItem]
    ON [dbo].[Answer_ChoiceAnswer]([ItemID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF, ONLINE = OFF, MAXDOP = 0);


GO
PRINT N'Creating [dbo].[Answer_MultipleChoiceAnswer]...';


GO
CREATE TABLE [dbo].[Answer_MultipleChoiceAnswer] (
    [ID] INT NOT NULL
);


GO
PRINT N'Creating PK_Answer_MultipleChoiceAnswer...';


GO
ALTER TABLE [dbo].[Answer_MultipleChoiceAnswer]
    ADD CONSTRAINT [PK_Answer_MultipleChoiceAnswer] PRIMARY KEY CLUSTERED ([ID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[Answer_ScaleAnswer]...';


GO
CREATE TABLE [dbo].[Answer_ScaleAnswer] (
    [Value] INT NOT NULL,
    [ID]    INT NOT NULL
);


GO
PRINT N'Creating PK_Answer_ScaleAnswer...';


GO
ALTER TABLE [dbo].[Answer_ScaleAnswer]
    ADD CONSTRAINT [PK_Answer_ScaleAnswer] PRIMARY KEY CLUSTERED ([ID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[Answer_TextAnswer]...';


GO
CREATE TABLE [dbo].[Answer_TextAnswer] (
    [Text] NVARCHAR (MAX) NOT NULL,
    [ID]   INT            NOT NULL
);


GO
PRINT N'Creating PK_Answer_TextAnswer...';


GO
ALTER TABLE [dbo].[Answer_TextAnswer]
    ADD CONSTRAINT [PK_Answer_TextAnswer] PRIMARY KEY CLUSTERED ([ID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[Form]...';


GO
CREATE TABLE [dbo].[Form] (
    [ID]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (MAX) NOT NULL,
    [Text]        NVARCHAR (MAX) NULL,
    [TimeToFill]  INT            NULL,
    [Shuffle]     BIT            NOT NULL,
    [Created]     DATETIME       NOT NULL,
    [FormTypeID]  INT            NOT NULL,
    [AuthorID]    INT            NOT NULL,
    [FormStateID] INT            NOT NULL,
    [MaxFills]    INT            NULL
);


GO
PRINT N'Creating PK_Form...';


GO
ALTER TABLE [dbo].[Form]
    ADD CONSTRAINT [PK_Form] PRIMARY KEY CLUSTERED ([ID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[Form].[IX_FK_FormFormState]...';


GO
CREATE NONCLUSTERED INDEX [IX_FK_FormFormState]
    ON [dbo].[Form]([FormStateID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF, ONLINE = OFF, MAXDOP = 0);


GO
PRINT N'Creating [dbo].[Form].[IX_FK_FormTemplateAuthor]...';


GO
CREATE NONCLUSTERED INDEX [IX_FK_FormTemplateAuthor]
    ON [dbo].[Form]([AuthorID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF, ONLINE = OFF, MAXDOP = 0);


GO
PRINT N'Creating [dbo].[Form].[IX_FK_FormTemplateFormType]...';


GO
CREATE NONCLUSTERED INDEX [IX_FK_FormTemplateFormType]
    ON [dbo].[Form]([FormTypeID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF, ONLINE = OFF, MAXDOP = 0);


GO
PRINT N'Creating [dbo].[FormGroup]...';


GO
CREATE TABLE [dbo].[FormGroup] (
    [Forms_ID]  INT NOT NULL,
    [Groups_ID] INT NOT NULL
);


GO
PRINT N'Creating PK_FormGroup...';


GO
ALTER TABLE [dbo].[FormGroup]
    ADD CONSTRAINT [PK_FormGroup] PRIMARY KEY NONCLUSTERED ([Forms_ID] ASC, [Groups_ID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[FormGroup].[IX_FK_FormGroup_Group]...';


GO
CREATE NONCLUSTERED INDEX [IX_FK_FormGroup_Group]
    ON [dbo].[FormGroup]([Groups_ID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF, ONLINE = OFF, MAXDOP = 0);


GO
PRINT N'Creating [dbo].[FormInstance]...';


GO
CREATE TABLE [dbo].[FormInstance] (
    [ID]                                      INT      IDENTITY (1, 1) NOT NULL,
    [Created]                                 DATETIME NOT NULL,
    [Submited]                                DATETIME NOT NULL,
    [SolverID]                                INT      NOT NULL,
    [FormTemplateID]                          INT      NOT NULL,
    [EvaluationID]                            INT      NULL,
    [IsPreview]                               BIT      NOT NULL,
    [UserFillingFormInstance_FormInstance_ID] INT      NULL
);


GO
PRINT N'Creating PK_FormInstance...';


GO
ALTER TABLE [dbo].[FormInstance]
    ADD CONSTRAINT [PK_FormInstance] PRIMARY KEY CLUSTERED ([ID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[FormInstance].[IX_FK_FormInstanceFormTemplate]...';


GO
CREATE NONCLUSTERED INDEX [IX_FK_FormInstanceFormTemplate]
    ON [dbo].[FormInstance]([FormTemplateID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF, ONLINE = OFF, MAXDOP = 0);


GO
PRINT N'Creating [dbo].[FormInstance].[IX_FK_FormInstanceUser]...';


GO
CREATE NONCLUSTERED INDEX [IX_FK_FormInstanceUser]
    ON [dbo].[FormInstance]([SolverID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF, ONLINE = OFF, MAXDOP = 0);


GO
PRINT N'Creating [dbo].[FormInstance].[IX_FK_UserFillingFormInstance]...';


GO
CREATE NONCLUSTERED INDEX [IX_FK_UserFillingFormInstance]
    ON [dbo].[FormInstance]([UserFillingFormInstance_FormInstance_ID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF, ONLINE = OFF, MAXDOP = 0);


GO
PRINT N'Creating [dbo].[FormInstanceEvaluation]...';


GO
CREATE TABLE [dbo].[FormInstanceEvaluation] (
    [ID]              INT            IDENTITY (1, 1) NOT NULL,
    [Note]            NVARCHAR (MAX) NOT NULL,
    [MarkValueID]     INT            NULL,
    [FormInstance_ID] INT            NOT NULL
);


GO
PRINT N'Creating PK_FormInstanceEvaluation...';


GO
ALTER TABLE [dbo].[FormInstanceEvaluation]
    ADD CONSTRAINT [PK_FormInstanceEvaluation] PRIMARY KEY CLUSTERED ([ID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[FormInstanceEvaluation].[IX_FK_FormInstanceEvaluationMarkValue]...';


GO
CREATE NONCLUSTERED INDEX [IX_FK_FormInstanceEvaluationMarkValue]
    ON [dbo].[FormInstanceEvaluation]([MarkValueID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF, ONLINE = OFF, MAXDOP = 0);


GO
PRINT N'Creating [dbo].[FormInstanceEvaluation].[IX_FK_FormInstanceFormInstanceEvaluation]...';


GO
CREATE NONCLUSTERED INDEX [IX_FK_FormInstanceFormInstanceEvaluation]
    ON [dbo].[FormInstanceEvaluation]([FormInstance_ID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF, ONLINE = OFF, MAXDOP = 0);


GO
PRINT N'Creating [dbo].[FormState]...';


GO
CREATE TABLE [dbo].[FormState] (
    [ID]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NOT NULL
);


GO
PRINT N'Creating PK_FormState...';


GO
ALTER TABLE [dbo].[FormState]
    ADD CONSTRAINT [PK_FormState] PRIMARY KEY CLUSTERED ([ID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[FormType]...';


GO
CREATE TABLE [dbo].[FormType] (
    [ID]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NOT NULL
);


GO
PRINT N'Creating PK_FormType...';


GO
ALTER TABLE [dbo].[FormType]
    ADD CONSTRAINT [PK_FormType] PRIMARY KEY CLUSTERED ([ID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[Group]...';


GO
CREATE TABLE [dbo].[Group] (
    [ID]           INT            IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (MAX) NOT NULL,
    [SupervisorID] INT            NOT NULL
);


GO
PRINT N'Creating PK_Group...';


GO
ALTER TABLE [dbo].[Group]
    ADD CONSTRAINT [PK_Group] PRIMARY KEY CLUSTERED ([ID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[Group].[IX_FK_Supervisor]...';


GO
CREATE NONCLUSTERED INDEX [IX_FK_Supervisor]
    ON [dbo].[Group]([SupervisorID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF, ONLINE = OFF, MAXDOP = 0);


GO
PRINT N'Creating [dbo].[GroupMembers]...';


GO
CREATE TABLE [dbo].[GroupMembers] (
    [Groups_ID]  INT NOT NULL,
    [Members_ID] INT NOT NULL
);


GO
PRINT N'Creating PK_GroupMembers...';


GO
ALTER TABLE [dbo].[GroupMembers]
    ADD CONSTRAINT [PK_GroupMembers] PRIMARY KEY NONCLUSTERED ([Groups_ID] ASC, [Members_ID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[GroupMembers].[IX_FK_GroupMembers_User]...';


GO
CREATE NONCLUSTERED INDEX [IX_FK_GroupMembers_User]
    ON [dbo].[GroupMembers]([Members_ID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF, ONLINE = OFF, MAXDOP = 0);


GO
PRINT N'Creating [dbo].[ChoiceItem]...';


GO
CREATE TABLE [dbo].[ChoiceItem] (
    [ID]               INT            IDENTITY (1, 1) NOT NULL,
    [ChoiceQuestionID] INT            NOT NULL,
    [Text]             NVARCHAR (MAX) NOT NULL,
    [Index]            INT            NOT NULL,
    [IsCorrect]        BIT            NOT NULL,
    [Explanation]      NVARCHAR (MAX) NULL,
    [ImageUrl]         NVARCHAR (MAX) NULL
);


GO
PRINT N'Creating PK_ChoiceItem...';


GO
ALTER TABLE [dbo].[ChoiceItem]
    ADD CONSTRAINT [PK_ChoiceItem] PRIMARY KEY CLUSTERED ([ID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[ChoiceItem].[IX_FK_ChoiceQuestionChoiceItem]...';


GO
CREATE NONCLUSTERED INDEX [IX_FK_ChoiceQuestionChoiceItem]
    ON [dbo].[ChoiceItem]([ChoiceQuestionID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF, ONLINE = OFF, MAXDOP = 0);


GO
PRINT N'Creating [dbo].[MarkValue]...';


GO
CREATE TABLE [dbo].[MarkValue] (
    [ID]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NOT NULL
);


GO
PRINT N'Creating PK_MarkValue...';


GO
ALTER TABLE [dbo].[MarkValue]
    ADD CONSTRAINT [PK_MarkValue] PRIMARY KEY CLUSTERED ([ID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[MultipleChoiceAnswerItem]...';


GO
CREATE TABLE [dbo].[MultipleChoiceAnswerItem] (
    [ID]                     INT IDENTITY (1, 1) NOT NULL,
    [MultipleChoiceAnswerID] INT NOT NULL,
    [ChoiceItemID]           INT NOT NULL
);


GO
PRINT N'Creating PK_MultipleChoiceAnswerItem...';


GO
ALTER TABLE [dbo].[MultipleChoiceAnswerItem]
    ADD CONSTRAINT [PK_MultipleChoiceAnswerItem] PRIMARY KEY CLUSTERED ([ID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[MultipleChoiceAnswerItem].[IX_FK_MultipleChoiceAnswerItemChoiceItem]...';


GO
CREATE NONCLUSTERED INDEX [IX_FK_MultipleChoiceAnswerItemChoiceItem]
    ON [dbo].[MultipleChoiceAnswerItem]([ChoiceItemID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF, ONLINE = OFF, MAXDOP = 0);


GO
PRINT N'Creating [dbo].[MultipleChoiceAnswerItem].[IX_FK_MultipleChoiceAnswerMultipleChoiceAnswerItem]...';


GO
CREATE NONCLUSTERED INDEX [IX_FK_MultipleChoiceAnswerMultipleChoiceAnswerItem]
    ON [dbo].[MultipleChoiceAnswerItem]([MultipleChoiceAnswerID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF, ONLINE = OFF, MAXDOP = 0);


GO
PRINT N'Creating [dbo].[Question]...';


GO
CREATE TABLE [dbo].[Question] (
    [ID]              INT            IDENTITY (1, 1) NOT NULL,
    [Text]            NVARCHAR (MAX) NOT NULL,
    [HelpText]        NVARCHAR (MAX) NULL,
    [ImageUrl]        NVARCHAR (MAX) NULL,
    [Explanation]     NVARCHAR (MAX) NULL,
    [QuestionGroupID] INT            NOT NULL
);


GO
PRINT N'Creating PK_Question...';


GO
ALTER TABLE [dbo].[Question]
    ADD CONSTRAINT [PK_Question] PRIMARY KEY CLUSTERED ([ID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[Question].[IX_FK_QuestionGroupQuestion]...';


GO
CREATE NONCLUSTERED INDEX [IX_FK_QuestionGroupQuestion]
    ON [dbo].[Question]([QuestionGroupID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF, ONLINE = OFF, MAXDOP = 0);


GO
PRINT N'Creating [dbo].[Question_ChoiceQuestion]...';


GO
CREATE TABLE [dbo].[Question_ChoiceQuestion] (
    [Shuffle] BIT NOT NULL,
    [ID]      INT NOT NULL
);


GO
PRINT N'Creating PK_Question_ChoiceQuestion...';


GO
ALTER TABLE [dbo].[Question_ChoiceQuestion]
    ADD CONSTRAINT [PK_Question_ChoiceQuestion] PRIMARY KEY CLUSTERED ([ID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[Question_ScaleQuestion]...';


GO
CREATE TABLE [dbo].[Question_ScaleQuestion] (
    [MinValue]     INT            NOT NULL,
    [MinValueText] NVARCHAR (MAX) NOT NULL,
    [MaxValue]     INT            NOT NULL,
    [MaxValueText] NVARCHAR (MAX) NOT NULL,
    [Increment]    INT            NOT NULL,
    [ID]           INT            NOT NULL
);


GO
PRINT N'Creating PK_Question_ScaleQuestion...';


GO
ALTER TABLE [dbo].[Question_ScaleQuestion]
    ADD CONSTRAINT [PK_Question_ScaleQuestion] PRIMARY KEY CLUSTERED ([ID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[QuestionGroup]...';


GO
CREATE TABLE [dbo].[QuestionGroup] (
    [ID]                  INT IDENTITY (1, 1) NOT NULL,
    [Index]               INT NOT NULL,
    [IsRequired]          BIT NOT NULL,
    [QuestionGroupTypeID] INT NOT NULL,
    [FormTemplateID]      INT NOT NULL
);


GO
PRINT N'Creating PK_QuestionGroup...';


GO
ALTER TABLE [dbo].[QuestionGroup]
    ADD CONSTRAINT [PK_QuestionGroup] PRIMARY KEY CLUSTERED ([ID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[QuestionGroup].[IX_FK_QuestionGroupFormTemplate]...';


GO
CREATE NONCLUSTERED INDEX [IX_FK_QuestionGroupFormTemplate]
    ON [dbo].[QuestionGroup]([FormTemplateID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF, ONLINE = OFF, MAXDOP = 0);


GO
PRINT N'Creating [dbo].[QuestionGroup].[IX_FK_QuestionGroupQuestionGroupType]...';


GO
CREATE NONCLUSTERED INDEX [IX_FK_QuestionGroupQuestionGroupType]
    ON [dbo].[QuestionGroup]([QuestionGroupTypeID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF, ONLINE = OFF, MAXDOP = 0);


GO
PRINT N'Creating [dbo].[QuestionGroupType]...';


GO
CREATE TABLE [dbo].[QuestionGroupType] (
    [ID]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NOT NULL
);


GO
PRINT N'Creating PK_QuestionGroupType...';


GO
ALTER TABLE [dbo].[QuestionGroupType]
    ADD CONSTRAINT [PK_QuestionGroupType] PRIMARY KEY CLUSTERED ([ID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[QuestionInstance]...';


GO
CREATE TABLE [dbo].[QuestionInstance] (
    [ID]             INT IDENTITY (1, 1) NOT NULL,
    [Index]          INT NOT NULL,
    [QuestionID]     INT NOT NULL,
    [FormInstanceID] INT NOT NULL
);


GO
PRINT N'Creating PK_QuestionInstance...';


GO
ALTER TABLE [dbo].[QuestionInstance]
    ADD CONSTRAINT [PK_QuestionInstance] PRIMARY KEY CLUSTERED ([ID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[QuestionInstance].[IX_FK_FormInstanceQuestionInstance]...';


GO
CREATE NONCLUSTERED INDEX [IX_FK_FormInstanceQuestionInstance]
    ON [dbo].[QuestionInstance]([FormInstanceID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF, ONLINE = OFF, MAXDOP = 0);


GO
PRINT N'Creating [dbo].[QuestionInstance].[IX_FK_QuestionInstanceQuestionTemplate]...';


GO
CREATE NONCLUSTERED INDEX [IX_FK_QuestionInstanceQuestionTemplate]
    ON [dbo].[QuestionInstance]([QuestionID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF, ONLINE = OFF, MAXDOP = 0);


GO
PRINT N'Creating [dbo].[TextBook]...';


GO
CREATE TABLE [dbo].[TextBook] (
    [ID]              INT            IDENTITY (1, 1) NOT NULL,
    [Created]         DATETIME       NOT NULL,
    [Changed]         DATETIME       NOT NULL,
    [Title]           NVARCHAR (MAX) NOT NULL,
    [Text]            NVARCHAR (MAX) NOT NULL,
    [CreatedByID]     INT            NOT NULL,
    [ChangedByID]     INT            NOT NULL,
    [VisibleToOthers] BIT            NOT NULL,
    [Html]            NVARCHAR (MAX) NOT NULL
);


GO
PRINT N'Creating PK_TextBook...';


GO
ALTER TABLE [dbo].[TextBook]
    ADD CONSTRAINT [PK_TextBook] PRIMARY KEY CLUSTERED ([ID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[TextBook].[IX_FK_TextBookUserCreator]...';


GO
CREATE NONCLUSTERED INDEX [IX_FK_TextBookUserCreator]
    ON [dbo].[TextBook]([CreatedByID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF, ONLINE = OFF, MAXDOP = 0);


GO
PRINT N'Creating [dbo].[TextBook].[IX_FK_TextBookUserChanger]...';


GO
CREATE NONCLUSTERED INDEX [IX_FK_TextBookUserChanger]
    ON [dbo].[TextBook]([ChangedByID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF, ONLINE = OFF, MAXDOP = 0);


GO
PRINT N'Creating [dbo].[TextBookGroup]...';


GO
CREATE TABLE [dbo].[TextBookGroup] (
    [TextBooks_ID] INT NOT NULL,
    [Groups_ID]    INT NOT NULL
);


GO
PRINT N'Creating PK_TextBookGroup...';


GO
ALTER TABLE [dbo].[TextBookGroup]
    ADD CONSTRAINT [PK_TextBookGroup] PRIMARY KEY NONCLUSTERED ([TextBooks_ID] ASC, [Groups_ID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[TextBookGroup].[IX_FK_TextBookGroup_Group]...';


GO
CREATE NONCLUSTERED INDEX [IX_FK_TextBookGroup_Group]
    ON [dbo].[TextBookGroup]([Groups_ID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF, ONLINE = OFF, MAXDOP = 0);


GO
PRINT N'Creating [dbo].[User]...';


GO
CREATE TABLE [dbo].[User] (
    [ID]          INT            IDENTITY (1, 1) NOT NULL,
    [Email]       NVARCHAR (MAX) NOT NULL,
    [UserTypeID]  INT            NOT NULL,
    [Password]    CHAR (32)      NULL,
    [IsActive]    BIT            NOT NULL,
    [FillingForm] INT            NULL
);


GO
PRINT N'Creating PK_User...';


GO
ALTER TABLE [dbo].[User]
    ADD CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([ID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[User].[IX_FK_UserUserType]...';


GO
CREATE NONCLUSTERED INDEX [IX_FK_UserUserType]
    ON [dbo].[User]([UserTypeID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF, ONLINE = OFF, MAXDOP = 0);


GO
PRINT N'Creating [dbo].[UserType]...';


GO
CREATE TABLE [dbo].[UserType] (
    [ID]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NOT NULL
);


GO
PRINT N'Creating PK_UserType...';


GO
ALTER TABLE [dbo].[UserType]
    ADD CONSTRAINT [PK_UserType] PRIMARY KEY CLUSTERED ([ID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating FK_QuestionInstanceAnswer...';


GO
ALTER TABLE [dbo].[Answer] WITH NOCHECK
    ADD CONSTRAINT [FK_QuestionInstanceAnswer] FOREIGN KEY ([QuestionInstanceAnswer_Answer_ID]) REFERENCES [dbo].[QuestionInstance] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_ChoiceAnswer_inherits_Answer...';


GO
ALTER TABLE [dbo].[Answer_ChoiceAnswer] WITH NOCHECK
    ADD CONSTRAINT [FK_ChoiceAnswer_inherits_Answer] FOREIGN KEY ([ID]) REFERENCES [dbo].[Answer] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_ChoiceAnswerChoiceItem...';


GO
ALTER TABLE [dbo].[Answer_ChoiceAnswer] WITH NOCHECK
    ADD CONSTRAINT [FK_ChoiceAnswerChoiceItem] FOREIGN KEY ([ItemID]) REFERENCES [dbo].[ChoiceItem] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_MultipleChoiceAnswer_inherits_Answer...';


GO
ALTER TABLE [dbo].[Answer_MultipleChoiceAnswer] WITH NOCHECK
    ADD CONSTRAINT [FK_MultipleChoiceAnswer_inherits_Answer] FOREIGN KEY ([ID]) REFERENCES [dbo].[Answer] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_ScaleAnswer_inherits_Answer...';


GO
ALTER TABLE [dbo].[Answer_ScaleAnswer] WITH NOCHECK
    ADD CONSTRAINT [FK_ScaleAnswer_inherits_Answer] FOREIGN KEY ([ID]) REFERENCES [dbo].[Answer] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_TextAnswer_inherits_Answer...';


GO
ALTER TABLE [dbo].[Answer_TextAnswer] WITH NOCHECK
    ADD CONSTRAINT [FK_TextAnswer_inherits_Answer] FOREIGN KEY ([ID]) REFERENCES [dbo].[Answer] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_FormFormState...';


GO
ALTER TABLE [dbo].[Form] WITH NOCHECK
    ADD CONSTRAINT [FK_FormFormState] FOREIGN KEY ([FormStateID]) REFERENCES [dbo].[FormState] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_FormTemplateAuthor...';


GO
ALTER TABLE [dbo].[Form] WITH NOCHECK
    ADD CONSTRAINT [FK_FormTemplateAuthor] FOREIGN KEY ([AuthorID]) REFERENCES [dbo].[User] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_FormTemplateFormType...';


GO
ALTER TABLE [dbo].[Form] WITH NOCHECK
    ADD CONSTRAINT [FK_FormTemplateFormType] FOREIGN KEY ([FormTypeID]) REFERENCES [dbo].[FormType] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_FormGroup_Form...';


GO
ALTER TABLE [dbo].[FormGroup] WITH NOCHECK
    ADD CONSTRAINT [FK_FormGroup_Form] FOREIGN KEY ([Forms_ID]) REFERENCES [dbo].[Form] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_FormGroup_Group...';


GO
ALTER TABLE [dbo].[FormGroup] WITH NOCHECK
    ADD CONSTRAINT [FK_FormGroup_Group] FOREIGN KEY ([Groups_ID]) REFERENCES [dbo].[Group] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_FormInstanceFormTemplate...';


GO
ALTER TABLE [dbo].[FormInstance] WITH NOCHECK
    ADD CONSTRAINT [FK_FormInstanceFormTemplate] FOREIGN KEY ([FormTemplateID]) REFERENCES [dbo].[Form] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_FormInstanceUser...';


GO
ALTER TABLE [dbo].[FormInstance] WITH NOCHECK
    ADD CONSTRAINT [FK_FormInstanceUser] FOREIGN KEY ([SolverID]) REFERENCES [dbo].[User] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_UserFillingFormInstance...';


GO
ALTER TABLE [dbo].[FormInstance] WITH NOCHECK
    ADD CONSTRAINT [FK_UserFillingFormInstance] FOREIGN KEY ([UserFillingFormInstance_FormInstance_ID]) REFERENCES [dbo].[User] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_FormInstanceEvaluationMarkValue...';


GO
ALTER TABLE [dbo].[FormInstanceEvaluation] WITH NOCHECK
    ADD CONSTRAINT [FK_FormInstanceEvaluationMarkValue] FOREIGN KEY ([MarkValueID]) REFERENCES [dbo].[MarkValue] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_FormInstanceFormInstanceEvaluation...';


GO
ALTER TABLE [dbo].[FormInstanceEvaluation] WITH NOCHECK
    ADD CONSTRAINT [FK_FormInstanceFormInstanceEvaluation] FOREIGN KEY ([FormInstance_ID]) REFERENCES [dbo].[FormInstance] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Supervisor...';


GO
ALTER TABLE [dbo].[Group] WITH NOCHECK
    ADD CONSTRAINT [FK_Supervisor] FOREIGN KEY ([SupervisorID]) REFERENCES [dbo].[User] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_GroupMembers_Group...';


GO
ALTER TABLE [dbo].[GroupMembers] WITH NOCHECK
    ADD CONSTRAINT [FK_GroupMembers_Group] FOREIGN KEY ([Groups_ID]) REFERENCES [dbo].[Group] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_GroupMembers_User...';


GO
ALTER TABLE [dbo].[GroupMembers] WITH NOCHECK
    ADD CONSTRAINT [FK_GroupMembers_User] FOREIGN KEY ([Members_ID]) REFERENCES [dbo].[User] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_ChoiceQuestionChoiceItem...';


GO
ALTER TABLE [dbo].[ChoiceItem] WITH NOCHECK
    ADD CONSTRAINT [FK_ChoiceQuestionChoiceItem] FOREIGN KEY ([ChoiceQuestionID]) REFERENCES [dbo].[Question_ChoiceQuestion] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_MultipleChoiceAnswerItemChoiceItem...';


GO
ALTER TABLE [dbo].[MultipleChoiceAnswerItem] WITH NOCHECK
    ADD CONSTRAINT [FK_MultipleChoiceAnswerItemChoiceItem] FOREIGN KEY ([ChoiceItemID]) REFERENCES [dbo].[ChoiceItem] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_MultipleChoiceAnswerMultipleChoiceAnswerItem...';


GO
ALTER TABLE [dbo].[MultipleChoiceAnswerItem] WITH NOCHECK
    ADD CONSTRAINT [FK_MultipleChoiceAnswerMultipleChoiceAnswerItem] FOREIGN KEY ([MultipleChoiceAnswerID]) REFERENCES [dbo].[Answer_MultipleChoiceAnswer] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_QuestionGroupQuestion...';


GO
ALTER TABLE [dbo].[Question] WITH NOCHECK
    ADD CONSTRAINT [FK_QuestionGroupQuestion] FOREIGN KEY ([QuestionGroupID]) REFERENCES [dbo].[QuestionGroup] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_ChoiceQuestion_inherits_Question...';


GO
ALTER TABLE [dbo].[Question_ChoiceQuestion] WITH NOCHECK
    ADD CONSTRAINT [FK_ChoiceQuestion_inherits_Question] FOREIGN KEY ([ID]) REFERENCES [dbo].[Question] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_ScaleQuestion_inherits_Question...';


GO
ALTER TABLE [dbo].[Question_ScaleQuestion] WITH NOCHECK
    ADD CONSTRAINT [FK_ScaleQuestion_inherits_Question] FOREIGN KEY ([ID]) REFERENCES [dbo].[Question] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_QuestionGroupFormTemplate...';


GO
ALTER TABLE [dbo].[QuestionGroup] WITH NOCHECK
    ADD CONSTRAINT [FK_QuestionGroupFormTemplate] FOREIGN KEY ([FormTemplateID]) REFERENCES [dbo].[Form] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_QuestionGroupQuestionGroupType...';


GO
ALTER TABLE [dbo].[QuestionGroup] WITH NOCHECK
    ADD CONSTRAINT [FK_QuestionGroupQuestionGroupType] FOREIGN KEY ([QuestionGroupTypeID]) REFERENCES [dbo].[QuestionGroupType] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_FormInstanceQuestionInstance...';


GO
ALTER TABLE [dbo].[QuestionInstance] WITH NOCHECK
    ADD CONSTRAINT [FK_FormInstanceQuestionInstance] FOREIGN KEY ([FormInstanceID]) REFERENCES [dbo].[FormInstance] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_QuestionInstanceQuestionTemplate...';


GO
ALTER TABLE [dbo].[QuestionInstance] WITH NOCHECK
    ADD CONSTRAINT [FK_QuestionInstanceQuestionTemplate] FOREIGN KEY ([QuestionID]) REFERENCES [dbo].[Question] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_TextBookUserCreator...';


GO
ALTER TABLE [dbo].[TextBook] WITH NOCHECK
    ADD CONSTRAINT [FK_TextBookUserCreator] FOREIGN KEY ([CreatedByID]) REFERENCES [dbo].[User] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_TextBookUserChanger...';


GO
ALTER TABLE [dbo].[TextBook] WITH NOCHECK
    ADD CONSTRAINT [FK_TextBookUserChanger] FOREIGN KEY ([ChangedByID]) REFERENCES [dbo].[User] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_TextBookGroup_Group...';


GO
ALTER TABLE [dbo].[TextBookGroup] WITH NOCHECK
    ADD CONSTRAINT [FK_TextBookGroup_Group] FOREIGN KEY ([Groups_ID]) REFERENCES [dbo].[Group] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_TextBookGroup_TextBook...';


GO
ALTER TABLE [dbo].[TextBookGroup] WITH NOCHECK
    ADD CONSTRAINT [FK_TextBookGroup_TextBook] FOREIGN KEY ([TextBooks_ID]) REFERENCES [dbo].[TextBook] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_UserUserType...';


GO
ALTER TABLE [dbo].[User] WITH NOCHECK
    ADD CONSTRAINT [FK_UserUserType] FOREIGN KEY ([UserTypeID]) REFERENCES [dbo].[UserType] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
-- Refactoring step to update target server with deployed transaction logs
CREATE TABLE  [dbo].[__RefactorLog] (OperationKey UNIQUEIDENTIFIER NOT NULL PRIMARY KEY)
GO
sp_addextendedproperty N'microsoft_database_tools_support', N'refactoring log', N'schema', N'dbo', N'table', N'__RefactorLog'
GO

GO

-- Form Types
INSERT INTO [dbo].[FormType] ([Name]) VALUES ('Questionnaire')
INSERT INTO [dbo].[FormType] ([Name]) VALUES ('Exam')
INSERT INTO [dbo].[FormType] ([Name]) VALUES ('TrainingTest')
GO

-- Form States
INSERT INTO [dbo].[FormState] ([Name]) VALUES ('Inactive')
INSERT INTO [dbo].[FormState] ([Name]) VALUES ('Active')
INSERT INTO [dbo].[FormState] ([Name]) VALUES ('Archived')
GO

-- Mark Values
INSERT INTO [dbo].[MarkValue] ([Name]) VALUES ('A')
INSERT INTO [dbo].[MarkValue] ([Name]) VALUES ('B')
INSERT INTO [dbo].[MarkValue] ([Name]) VALUES ('C')
INSERT INTO [dbo].[MarkValue] ([Name]) VALUES ('D')
INSERT INTO [dbo].[MarkValue] ([Name]) VALUES ('E')
INSERT INTO [dbo].[MarkValue] ([Name]) VALUES ('F')
GO

-- QuestionGroup Types
INSERT INTO [dbo].[QuestionGroupType] ([Name]) VALUES ('InlineText')
INSERT INTO [dbo].[QuestionGroupType] ([Name]) VALUES ('MultilineText')
INSERT INTO [dbo].[QuestionGroupType] ([Name]) VALUES ('Choice')
INSERT INTO [dbo].[QuestionGroupType] ([Name]) VALUES ('MultipleChoice')
INSERT INTO [dbo].[QuestionGroupType] ([Name]) VALUES ('Scale')
GO

-- User Types
INSERT INTO [dbo].[UserType] ([Name]) VALUES ('Administrator')
INSERT INTO [dbo].[UserType] ([Name]) VALUES ('Lector')
INSERT INTO [dbo].[UserType] ([Name]) VALUES ('Student')
GO


-- Users
INSERT INTO [User]([Email], [UserTypeID], [Password], [IsActive]) 
	VALUES ('admin@admin.admin', 1, '2f23fa3579f3f75175793649115c1b25', 1)
INSERT INTO [User]([Email], [UserTypeID], [Password], [IsActive]) 
	VALUES ('lector@lector.lector', 2, '2f23fa3579f3f75175793649115c1b25', 1)
INSERT INTO [User]([Email], [UserTypeID], [Password], [IsActive]) 
	VALUES ('studentA@studentA.studentA', 3, '2f23fa3579f3f75175793649115c1b25', 1)
INSERT INTO [User]([Email], [UserTypeID], [Password], [IsActive]) 
	VALUES ('studentB@studentB.studentB', 3, '2f23fa3579f3f75175793649115c1b25', 1)
INSERT INTO [User]([Email], [UserTypeID], [Password], [IsActive]) 
	VALUES ('studentL@studentL.studentL', 3, '2f23fa3579f3f75175793649115c1b25', 1)
GO

-- Groups
INSERT INTO [Group]([Name], [SupervisorID])
	VALUES ('Group AAA', 1)
INSERT INTO [Group]([Name], [SupervisorID])
	VALUES ('Group LLL', 2)
GO


-- Users <--> Groups
INSERT INTO [GroupMembers]([Groups_ID], [Members_ID])
	VALUES (1, 3)
INSERT INTO [GroupMembers]([Groups_ID], [Members_ID])
	VALUES (1, 4)
INSERT INTO [GroupMembers]([Groups_ID], [Members_ID])
	VALUES (2, 5)

GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[Answer] WITH CHECK CHECK CONSTRAINT [FK_QuestionInstanceAnswer];

ALTER TABLE [dbo].[Answer_ChoiceAnswer] WITH CHECK CHECK CONSTRAINT [FK_ChoiceAnswer_inherits_Answer];

ALTER TABLE [dbo].[Answer_ChoiceAnswer] WITH CHECK CHECK CONSTRAINT [FK_ChoiceAnswerChoiceItem];

ALTER TABLE [dbo].[Answer_MultipleChoiceAnswer] WITH CHECK CHECK CONSTRAINT [FK_MultipleChoiceAnswer_inherits_Answer];

ALTER TABLE [dbo].[Answer_ScaleAnswer] WITH CHECK CHECK CONSTRAINT [FK_ScaleAnswer_inherits_Answer];

ALTER TABLE [dbo].[Answer_TextAnswer] WITH CHECK CHECK CONSTRAINT [FK_TextAnswer_inherits_Answer];

ALTER TABLE [dbo].[Form] WITH CHECK CHECK CONSTRAINT [FK_FormFormState];

ALTER TABLE [dbo].[Form] WITH CHECK CHECK CONSTRAINT [FK_FormTemplateAuthor];

ALTER TABLE [dbo].[Form] WITH CHECK CHECK CONSTRAINT [FK_FormTemplateFormType];

ALTER TABLE [dbo].[FormGroup] WITH CHECK CHECK CONSTRAINT [FK_FormGroup_Form];

ALTER TABLE [dbo].[FormGroup] WITH CHECK CHECK CONSTRAINT [FK_FormGroup_Group];

ALTER TABLE [dbo].[FormInstance] WITH CHECK CHECK CONSTRAINT [FK_FormInstanceFormTemplate];

ALTER TABLE [dbo].[FormInstance] WITH CHECK CHECK CONSTRAINT [FK_FormInstanceUser];

ALTER TABLE [dbo].[FormInstance] WITH CHECK CHECK CONSTRAINT [FK_UserFillingFormInstance];

ALTER TABLE [dbo].[FormInstanceEvaluation] WITH CHECK CHECK CONSTRAINT [FK_FormInstanceEvaluationMarkValue];

ALTER TABLE [dbo].[FormInstanceEvaluation] WITH CHECK CHECK CONSTRAINT [FK_FormInstanceFormInstanceEvaluation];

ALTER TABLE [dbo].[Group] WITH CHECK CHECK CONSTRAINT [FK_Supervisor];

ALTER TABLE [dbo].[GroupMembers] WITH CHECK CHECK CONSTRAINT [FK_GroupMembers_Group];

ALTER TABLE [dbo].[GroupMembers] WITH CHECK CHECK CONSTRAINT [FK_GroupMembers_User];

ALTER TABLE [dbo].[ChoiceItem] WITH CHECK CHECK CONSTRAINT [FK_ChoiceQuestionChoiceItem];

ALTER TABLE [dbo].[MultipleChoiceAnswerItem] WITH CHECK CHECK CONSTRAINT [FK_MultipleChoiceAnswerItemChoiceItem];

ALTER TABLE [dbo].[MultipleChoiceAnswerItem] WITH CHECK CHECK CONSTRAINT [FK_MultipleChoiceAnswerMultipleChoiceAnswerItem];

ALTER TABLE [dbo].[Question] WITH CHECK CHECK CONSTRAINT [FK_QuestionGroupQuestion];

ALTER TABLE [dbo].[Question_ChoiceQuestion] WITH CHECK CHECK CONSTRAINT [FK_ChoiceQuestion_inherits_Question];

ALTER TABLE [dbo].[Question_ScaleQuestion] WITH CHECK CHECK CONSTRAINT [FK_ScaleQuestion_inherits_Question];

ALTER TABLE [dbo].[QuestionGroup] WITH CHECK CHECK CONSTRAINT [FK_QuestionGroupFormTemplate];

ALTER TABLE [dbo].[QuestionGroup] WITH CHECK CHECK CONSTRAINT [FK_QuestionGroupQuestionGroupType];

ALTER TABLE [dbo].[QuestionInstance] WITH CHECK CHECK CONSTRAINT [FK_FormInstanceQuestionInstance];

ALTER TABLE [dbo].[QuestionInstance] WITH CHECK CHECK CONSTRAINT [FK_QuestionInstanceQuestionTemplate];

ALTER TABLE [dbo].[TextBook] WITH CHECK CHECK CONSTRAINT [FK_TextBookUserCreator];

ALTER TABLE [dbo].[TextBook] WITH CHECK CHECK CONSTRAINT [FK_TextBookUserChanger];

ALTER TABLE [dbo].[TextBookGroup] WITH CHECK CHECK CONSTRAINT [FK_TextBookGroup_Group];

ALTER TABLE [dbo].[TextBookGroup] WITH CHECK CHECK CONSTRAINT [FK_TextBookGroup_TextBook];

ALTER TABLE [dbo].[User] WITH CHECK CHECK CONSTRAINT [FK_UserUserType];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        DECLARE @VarDecimalSupported AS BIT;
        SELECT @VarDecimalSupported = 0;
        IF ((ServerProperty(N'EngineEdition') = 3)
            AND (((@@microsoftversion / power(2, 24) = 9)
                  AND (@@microsoftversion & 0xffff >= 3024))
                 OR ((@@microsoftversion / power(2, 24) = 10)
                     AND (@@microsoftversion & 0xffff >= 1600))))
            SELECT @VarDecimalSupported = 1;
        IF (@VarDecimalSupported > 0)
            BEGIN
                EXECUTE sp_db_vardecimal_storage_format N'$(DatabaseName)', 'ON';
            END
    END


GO
