/*
Deployment script for ELearning
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "ELearning"
:setvar DefaultDataPath ""
:setvar DefaultLogPath ""

GO
USE [master]

GO
:on error exit
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
CREATE DATABASE [$(DatabaseName)] COLLATE SQL_Latin1_General_CP1_CI_AS
GO
EXECUTE sp_dbcmptlevel [$(DatabaseName)], 100;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                NUMERIC_ROUNDABORT OFF,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL,
                RECOVERY FULL,
                CURSOR_CLOSE_ON_COMMIT OFF,
                AUTO_CREATE_STATISTICS ON,
                AUTO_SHRINK OFF,
                AUTO_UPDATE_STATISTICS ON,
                RECURSIVE_TRIGGERS OFF 
            WITH ROLLBACK IMMEDIATE;
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CLOSE OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ALLOW_SNAPSHOT_ISOLATION OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET READ_COMMITTED_SNAPSHOT OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_UPDATE_STATISTICS_ASYNC OFF,
                PAGE_VERIFY NONE,
                DATE_CORRELATION_OPTIMIZATION OFF,
                DISABLE_BROKER,
                PARAMETERIZATION SIMPLE,
                SUPPLEMENTAL_LOGGING OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET TRUSTWORTHY OFF,
        DB_CHAINING OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET HONOR_BROKER_PRIORITY OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
USE [$(DatabaseName)]

GO
IF fulltextserviceproperty(N'IsFulltextInstalled') = 1
    EXECUTE sp_fulltext_database 'enable';


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
    [Index] INT NOT NULL,
    [ID]    INT NOT NULL
);


GO
PRINT N'Creating PK_Answer_ChoiceAnswer...';


GO
ALTER TABLE [dbo].[Answer_ChoiceAnswer]
    ADD CONSTRAINT [PK_Answer_ChoiceAnswer] PRIMARY KEY CLUSTERED ([ID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


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
PRINT N'Creating [dbo].[ChoiceItem]...';


GO
CREATE TABLE [dbo].[ChoiceItem] (
    [ID]               INT            IDENTITY (1, 1) NOT NULL,
    [ChoiceQuestionID] INT            NOT NULL,
    [Text]             NVARCHAR (MAX) NOT NULL,
    [Index]            INT            NOT NULL,
    [IsCorrect]        BIT            NOT NULL,
    [Explanation]      NVARCHAR (MAX) NOT NULL,
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
PRINT N'Creating [dbo].[Form]...';


GO
CREATE TABLE [dbo].[Form] (
    [ID]         INT            IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (MAX) NOT NULL,
    [Text]       NVARCHAR (MAX) NOT NULL,
    [TimeToFill] INT            NULL,
    [Shuffle]    BIT            NOT NULL,
    [Created]    DATETIME       NOT NULL,
    [FormTypeID] INT            NOT NULL,
    [AuthorID]   INT            NOT NULL
);


GO
PRINT N'Creating PK_Form...';


GO
ALTER TABLE [dbo].[Form]
    ADD CONSTRAINT [PK_Form] PRIMARY KEY CLUSTERED ([ID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


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
PRINT N'Creating [dbo].[FormInstance]...';


GO
CREATE TABLE [dbo].[FormInstance] (
    [ID]             INT      IDENTITY (1, 1) NOT NULL,
    [Created]        DATETIME NOT NULL,
    [Submited]       DATETIME NOT NULL,
    [SolverID]       INT      NOT NULL,
    [FormTemplateID] INT      NOT NULL,
    [Evaluation_ID]  INT      NOT NULL
);


GO
PRINT N'Creating PK_FormInstance...';


GO
ALTER TABLE [dbo].[FormInstance]
    ADD CONSTRAINT [PK_FormInstance] PRIMARY KEY CLUSTERED ([ID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[FormInstance].[IX_FK_FormInstanceFormInstanceEvaluation]...';


GO
CREATE NONCLUSTERED INDEX [IX_FK_FormInstanceFormInstanceEvaluation]
    ON [dbo].[FormInstance]([Evaluation_ID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF, ONLINE = OFF, MAXDOP = 0);


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
PRINT N'Creating [dbo].[FormInstanceEvaluation]...';


GO
CREATE TABLE [dbo].[FormInstanceEvaluation] (
    [ID]   INT            IDENTITY (1, 1) NOT NULL,
    [Mark] NVARCHAR (MAX) NOT NULL,
    [Note] NVARCHAR (MAX) NOT NULL
);


GO
PRINT N'Creating PK_FormInstanceEvaluation...';


GO
ALTER TABLE [dbo].[FormInstanceEvaluation]
    ADD CONSTRAINT [PK_FormInstanceEvaluation] PRIMARY KEY CLUSTERED ([ID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


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
    [Shuffle] NVARCHAR (MAX) NOT NULL,
    [ID]      INT            NOT NULL
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
PRINT N'Creating [dbo].[User]...';


GO
CREATE TABLE [dbo].[User] (
    [ID]         INT            IDENTITY (1, 1) NOT NULL,
    [Email]      NVARCHAR (MAX) NOT NULL,
    [UserTypeID] INT            NOT NULL,
    [Password]   CHAR (32)      NULL,
    [IsActive]   BIT            NOT NULL
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
PRINT N'Creating FK_ChoiceQuestionChoiceItem...';


GO
ALTER TABLE [dbo].[ChoiceItem] WITH NOCHECK
    ADD CONSTRAINT [FK_ChoiceQuestionChoiceItem] FOREIGN KEY ([ChoiceQuestionID]) REFERENCES [dbo].[Question_ChoiceQuestion] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;


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
PRINT N'Creating FK_FormInstanceFormInstanceEvaluation...';


GO
ALTER TABLE [dbo].[FormInstance] WITH NOCHECK
    ADD CONSTRAINT [FK_FormInstanceFormInstanceEvaluation] FOREIGN KEY ([Evaluation_ID]) REFERENCES [dbo].[FormInstanceEvaluation] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;


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

-- QuestionGroup Types
INSERT INTO [dbo].[QuestionGroupType] ([Name]) VALUES ('InlineText')
INSERT INTO [dbo].[QuestionGroupType] ([Name]) VALUES ('MultilineText')
INSERT INTO [dbo].[QuestionGroupType] ([Name]) VALUES ('Choice')
INSERT INTO [dbo].[QuestionGroupType] ([Name]) VALUES ('MultipleChoice')
INSERT INTO [dbo].[QuestionGroupType] ([Name]) VALUES ('Combo')
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
	VALUES ('student@student.student', 3, '2f23fa3579f3f75175793649115c1b25', 1)
GO

GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[Answer] WITH CHECK CHECK CONSTRAINT [FK_QuestionInstanceAnswer];

ALTER TABLE [dbo].[Answer_ChoiceAnswer] WITH CHECK CHECK CONSTRAINT [FK_ChoiceAnswer_inherits_Answer];

ALTER TABLE [dbo].[Answer_ScaleAnswer] WITH CHECK CHECK CONSTRAINT [FK_ScaleAnswer_inherits_Answer];

ALTER TABLE [dbo].[Answer_TextAnswer] WITH CHECK CHECK CONSTRAINT [FK_TextAnswer_inherits_Answer];

ALTER TABLE [dbo].[ChoiceItem] WITH CHECK CHECK CONSTRAINT [FK_ChoiceQuestionChoiceItem];

ALTER TABLE [dbo].[Form] WITH CHECK CHECK CONSTRAINT [FK_FormTemplateAuthor];

ALTER TABLE [dbo].[Form] WITH CHECK CHECK CONSTRAINT [FK_FormTemplateFormType];

ALTER TABLE [dbo].[FormInstance] WITH CHECK CHECK CONSTRAINT [FK_FormInstanceFormInstanceEvaluation];

ALTER TABLE [dbo].[FormInstance] WITH CHECK CHECK CONSTRAINT [FK_FormInstanceFormTemplate];

ALTER TABLE [dbo].[FormInstance] WITH CHECK CHECK CONSTRAINT [FK_FormInstanceUser];

ALTER TABLE [dbo].[Group] WITH CHECK CHECK CONSTRAINT [FK_Supervisor];

ALTER TABLE [dbo].[GroupMembers] WITH CHECK CHECK CONSTRAINT [FK_GroupMembers_Group];

ALTER TABLE [dbo].[GroupMembers] WITH CHECK CHECK CONSTRAINT [FK_GroupMembers_User];

ALTER TABLE [dbo].[Question] WITH CHECK CHECK CONSTRAINT [FK_QuestionGroupQuestion];

ALTER TABLE [dbo].[Question_ChoiceQuestion] WITH CHECK CHECK CONSTRAINT [FK_ChoiceQuestion_inherits_Question];

ALTER TABLE [dbo].[Question_ScaleQuestion] WITH CHECK CHECK CONSTRAINT [FK_ScaleQuestion_inherits_Question];

ALTER TABLE [dbo].[QuestionGroup] WITH CHECK CHECK CONSTRAINT [FK_QuestionGroupFormTemplate];

ALTER TABLE [dbo].[QuestionGroup] WITH CHECK CHECK CONSTRAINT [FK_QuestionGroupQuestionGroupType];

ALTER TABLE [dbo].[QuestionInstance] WITH CHECK CHECK CONSTRAINT [FK_FormInstanceQuestionInstance];

ALTER TABLE [dbo].[QuestionInstance] WITH CHECK CHECK CONSTRAINT [FK_QuestionInstanceQuestionTemplate];

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
ALTER DATABASE [$(DatabaseName)]
    SET MULTI_USER 
    WITH ROLLBACK IMMEDIATE;


GO
