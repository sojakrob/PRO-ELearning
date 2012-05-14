/*
Deployment script for rsojak_elearning
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "rsojak_elearning"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\"

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

IF NOT EXISTS (SELECT 1 FROM [master].[dbo].[sysdatabases] WHERE [name] = N'$(DatabaseName)')
BEGIN
    RAISERROR(N'You cannot deploy this update script to target WIN-ICLDFVHRBHF. The database for which this script was built, rsojak_elearning, does not exist on this server.', 16, 127) WITH NOWAIT
    RETURN
END

GO

IF (@@servername != 'WIN-ICLDFVHRBHF')
BEGIN
    RAISERROR(N'The server name in the build script %s does not match the name of the target server %s. Verify whether your database project settings are correct and whether your build script is up to date.', 16, 127,N'WIN-ICLDFVHRBHF',@@servername) WITH NOWAIT
    RETURN
END

GO

IF CAST(DATABASEPROPERTY(N'$(DatabaseName)','IsReadOnly') as bit) = 1
BEGIN
    RAISERROR(N'You cannot deploy this update script because the database for which it was built, %s , is set to READ_ONLY.', 16, 127, N'$(DatabaseName)') WITH NOWAIT
    RETURN
END

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
