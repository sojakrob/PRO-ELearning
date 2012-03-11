
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 11/19/2011 09:13:34
-- Generated from EDMX file: d:\_mb\School\FEL\Predmety\A7B36PRO\ELearning\src\Data\DataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [db8414991a6d244d96b85a9f91000af42b];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO
-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ChoiceAnswer_inherits_Answer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Answer_ChoiceAnswer] DROP CONSTRAINT [FK_ChoiceAnswer_inherits_Answer];
GO
IF OBJECT_ID(N'[dbo].[FK_ChoiceQuestion_inherits_Question]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Question_ChoiceQuestion] DROP CONSTRAINT [FK_ChoiceQuestion_inherits_Question];
GO
IF OBJECT_ID(N'[dbo].[FK_ChoiceQuestionChoiceItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChoiceItem] DROP CONSTRAINT [FK_ChoiceQuestionChoiceItem];
GO
IF OBJECT_ID(N'[dbo].[FK_FormInstanceFormInstanceEvaluation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormInstance] DROP CONSTRAINT [FK_FormInstanceFormInstanceEvaluation];
GO
IF OBJECT_ID(N'[dbo].[FK_FormInstanceFormTemplate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormInstance] DROP CONSTRAINT [FK_FormInstanceFormTemplate];
GO
IF OBJECT_ID(N'[dbo].[FK_FormInstanceQuestionInstance]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[QuestionInstance] DROP CONSTRAINT [FK_FormInstanceQuestionInstance];
GO
IF OBJECT_ID(N'[dbo].[FK_FormInstanceUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormInstance] DROP CONSTRAINT [FK_FormInstanceUser];
GO
IF OBJECT_ID(N'[dbo].[FK_FormTemplateAuthor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Form] DROP CONSTRAINT [FK_FormTemplateAuthor];
GO
IF OBJECT_ID(N'[dbo].[FK_FormTemplateFormType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Form] DROP CONSTRAINT [FK_FormTemplateFormType];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupMembers_Group]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GroupMembers] DROP CONSTRAINT [FK_GroupMembers_Group];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupMembers_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GroupMembers] DROP CONSTRAINT [FK_GroupMembers_User];
GO
IF OBJECT_ID(N'[dbo].[FK_QuestionGroupFormTemplate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[QuestionGroup] DROP CONSTRAINT [FK_QuestionGroupFormTemplate];
GO
IF OBJECT_ID(N'[dbo].[FK_QuestionGroupQuestion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Question] DROP CONSTRAINT [FK_QuestionGroupQuestion];
GO
IF OBJECT_ID(N'[dbo].[FK_QuestionGroupQuestionGroupType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[QuestionGroup] DROP CONSTRAINT [FK_QuestionGroupQuestionGroupType];
GO
IF OBJECT_ID(N'[dbo].[FK_QuestionInstanceAnswer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Answer] DROP CONSTRAINT [FK_QuestionInstanceAnswer];
GO
IF OBJECT_ID(N'[dbo].[FK_QuestionInstanceQuestionTemplate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[QuestionInstance] DROP CONSTRAINT [FK_QuestionInstanceQuestionTemplate];
GO
IF OBJECT_ID(N'[dbo].[FK_ScaleAnswer_inherits_Answer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Answer_ScaleAnswer] DROP CONSTRAINT [FK_ScaleAnswer_inherits_Answer];
GO
IF OBJECT_ID(N'[dbo].[FK_ScaleQuestion_inherits_Question]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Question_ScaleQuestion] DROP CONSTRAINT [FK_ScaleQuestion_inherits_Question];
GO
IF OBJECT_ID(N'[dbo].[FK_Supervisor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Group] DROP CONSTRAINT [FK_Supervisor];
GO
IF OBJECT_ID(N'[dbo].[FK_TextAnswer_inherits_Answer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Answer_TextAnswer] DROP CONSTRAINT [FK_TextAnswer_inherits_Answer];
GO
IF OBJECT_ID(N'[dbo].[FK_UserUserType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_UserUserType];
GO
-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Answer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Answer];
GO
IF OBJECT_ID(N'[dbo].[Answer_ChoiceAnswer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Answer_ChoiceAnswer];
GO
IF OBJECT_ID(N'[dbo].[Answer_ScaleAnswer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Answer_ScaleAnswer];
GO
IF OBJECT_ID(N'[dbo].[Answer_TextAnswer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Answer_TextAnswer];
GO
IF OBJECT_ID(N'[dbo].[ChoiceItem]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ChoiceItem];
GO
IF OBJECT_ID(N'[dbo].[Form]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Form];
GO
IF OBJECT_ID(N'[dbo].[FormInstance]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormInstance];
GO
IF OBJECT_ID(N'[dbo].[FormInstanceEvaluation]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormInstanceEvaluation];
GO
IF OBJECT_ID(N'[dbo].[FormType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormType];
GO
IF OBJECT_ID(N'[dbo].[Group]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Group];
GO
IF OBJECT_ID(N'[dbo].[GroupMembers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GroupMembers];
GO
IF OBJECT_ID(N'[dbo].[Question]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Question];
GO
IF OBJECT_ID(N'[dbo].[Question_ChoiceQuestion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Question_ChoiceQuestion];
GO
IF OBJECT_ID(N'[dbo].[Question_ScaleQuestion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Question_ScaleQuestion];
GO
IF OBJECT_ID(N'[dbo].[QuestionGroup]', 'U') IS NOT NULL
    DROP TABLE [dbo].[QuestionGroup];
GO
IF OBJECT_ID(N'[dbo].[QuestionGroupType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[QuestionGroupType];
GO
IF OBJECT_ID(N'[dbo].[QuestionInstance]', 'U') IS NOT NULL
    DROP TABLE [dbo].[QuestionInstance];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO
IF OBJECT_ID(N'[dbo].[UserType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserType];
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------

GO

-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 02/16/2012 18:24:31
-- Generated from EDMX file: D:\_mb\School\FEL\Predmety\A7B36PRO\ELearning\src\Data\DataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [db8414991a6d244d96b85a9f91000af42b];
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
IF OBJECT_ID(N'[dbo].[FK_Supervisor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Group] DROP CONSTRAINT [FK_Supervisor];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupMembers_Group]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GroupMembers] DROP CONSTRAINT [FK_GroupMembers_Group];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupMembers_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GroupMembers] DROP CONSTRAINT [FK_GroupMembers_User];
GO
IF OBJECT_ID(N'[dbo].[FK_UserUserType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_UserUserType];
GO
IF OBJECT_ID(N'[dbo].[FK_FormTemplateFormType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Form] DROP CONSTRAINT [FK_FormTemplateFormType];
GO
IF OBJECT_ID(N'[dbo].[FK_FormTemplateAuthor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Form] DROP CONSTRAINT [FK_FormTemplateAuthor];
GO
IF OBJECT_ID(N'[dbo].[FK_QuestionGroupFormTemplate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[QuestionGroup] DROP CONSTRAINT [FK_QuestionGroupFormTemplate];
GO
IF OBJECT_ID(N'[dbo].[FK_FormInstanceUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormInstance] DROP CONSTRAINT [FK_FormInstanceUser];
GO
IF OBJECT_ID(N'[dbo].[FK_FormInstanceFormTemplate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormInstance] DROP CONSTRAINT [FK_FormInstanceFormTemplate];
GO
IF OBJECT_ID(N'[dbo].[FK_QuestionInstanceQuestionTemplate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[QuestionInstance] DROP CONSTRAINT [FK_QuestionInstanceQuestionTemplate];
GO
IF OBJECT_ID(N'[dbo].[FK_FormInstanceQuestionInstance]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[QuestionInstance] DROP CONSTRAINT [FK_FormInstanceQuestionInstance];
GO
IF OBJECT_ID(N'[dbo].[FK_FormInstanceFormInstanceEvaluation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormInstanceEvaluation] DROP CONSTRAINT [FK_FormInstanceFormInstanceEvaluation];
GO
IF OBJECT_ID(N'[dbo].[FK_QuestionInstanceAnswer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Answer] DROP CONSTRAINT [FK_QuestionInstanceAnswer];
GO
IF OBJECT_ID(N'[dbo].[FK_ChoiceQuestionChoiceItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChoiceItem] DROP CONSTRAINT [FK_ChoiceQuestionChoiceItem];
GO
IF OBJECT_ID(N'[dbo].[FK_UserFillingFormInstance]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormInstance] DROP CONSTRAINT [FK_UserFillingFormInstance];
GO
IF OBJECT_ID(N'[dbo].[FK_ChoiceQuestion_inherits_Question]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Question_ChoiceQuestion] DROP CONSTRAINT [FK_ChoiceQuestion_inherits_Question];
GO
IF OBJECT_ID(N'[dbo].[FK_TextAnswer_inherits_Answer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Answer_TextAnswer] DROP CONSTRAINT [FK_TextAnswer_inherits_Answer];
GO
IF OBJECT_ID(N'[dbo].[FK_ChoiceAnswer_inherits_Answer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Answer_ChoiceAnswer] DROP CONSTRAINT [FK_ChoiceAnswer_inherits_Answer];
GO
IF OBJECT_ID(N'[dbo].[FK_ScaleAnswer_inherits_Answer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Answer_ScaleAnswer] DROP CONSTRAINT [FK_ScaleAnswer_inherits_Answer];
GO
IF OBJECT_ID(N'[dbo].[FK_ScaleQuestion_inherits_Question]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Question_ScaleQuestion] DROP CONSTRAINT [FK_ScaleQuestion_inherits_Question];
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
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO
IF OBJECT_ID(N'[dbo].[Group]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Group];
GO
IF OBJECT_ID(N'[dbo].[UserType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserType];
GO
IF OBJECT_ID(N'[dbo].[Form]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Form];
GO
IF OBJECT_ID(N'[dbo].[FormType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormType];
GO
IF OBJECT_ID(N'[dbo].[FormInstance]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormInstance];
GO
IF OBJECT_ID(N'[dbo].[QuestionInstance]', 'U') IS NOT NULL
    DROP TABLE [dbo].[QuestionInstance];
GO
IF OBJECT_ID(N'[dbo].[FormInstanceEvaluation]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormInstanceEvaluation];
GO
IF OBJECT_ID(N'[dbo].[Answer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Answer];
GO
IF OBJECT_ID(N'[dbo].[ChoiceItem]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ChoiceItem];
GO
IF OBJECT_ID(N'[dbo].[Question_ChoiceQuestion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Question_ChoiceQuestion];
GO
IF OBJECT_ID(N'[dbo].[Answer_TextAnswer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Answer_TextAnswer];
GO
IF OBJECT_ID(N'[dbo].[Answer_ChoiceAnswer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Answer_ChoiceAnswer];
GO
IF OBJECT_ID(N'[dbo].[Answer_ScaleAnswer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Answer_ScaleAnswer];
GO
IF OBJECT_ID(N'[dbo].[Question_ScaleQuestion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Question_ScaleQuestion];
GO
IF OBJECT_ID(N'[dbo].[GroupMembers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GroupMembers];
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------

GO

-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 02/16/2012 18:24:31
-- Generated from EDMX file: D:\_mb\School\FEL\Predmety\A7B36PRO\ELearning\src\Data\DataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [db8414991a6d244d96b85a9f91000af42b];
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
IF OBJECT_ID(N'[dbo].[FK_Supervisor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Group] DROP CONSTRAINT [FK_Supervisor];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupMembers_Group]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GroupMembers] DROP CONSTRAINT [FK_GroupMembers_Group];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupMembers_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GroupMembers] DROP CONSTRAINT [FK_GroupMembers_User];
GO
IF OBJECT_ID(N'[dbo].[FK_UserUserType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_UserUserType];
GO
IF OBJECT_ID(N'[dbo].[FK_FormTemplateFormType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Form] DROP CONSTRAINT [FK_FormTemplateFormType];
GO
IF OBJECT_ID(N'[dbo].[FK_FormTemplateAuthor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Form] DROP CONSTRAINT [FK_FormTemplateAuthor];
GO
IF OBJECT_ID(N'[dbo].[FK_QuestionGroupFormTemplate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[QuestionGroup] DROP CONSTRAINT [FK_QuestionGroupFormTemplate];
GO
IF OBJECT_ID(N'[dbo].[FK_FormInstanceUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormInstance] DROP CONSTRAINT [FK_FormInstanceUser];
GO
IF OBJECT_ID(N'[dbo].[FK_FormInstanceFormTemplate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormInstance] DROP CONSTRAINT [FK_FormInstanceFormTemplate];
GO
IF OBJECT_ID(N'[dbo].[FK_QuestionInstanceQuestionTemplate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[QuestionInstance] DROP CONSTRAINT [FK_QuestionInstanceQuestionTemplate];
GO
IF OBJECT_ID(N'[dbo].[FK_FormInstanceQuestionInstance]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[QuestionInstance] DROP CONSTRAINT [FK_FormInstanceQuestionInstance];
GO
IF OBJECT_ID(N'[dbo].[FK_FormInstanceFormInstanceEvaluation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormInstanceEvaluation] DROP CONSTRAINT [FK_FormInstanceFormInstanceEvaluation];
GO
IF OBJECT_ID(N'[dbo].[FK_QuestionInstanceAnswer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Answer] DROP CONSTRAINT [FK_QuestionInstanceAnswer];
GO
IF OBJECT_ID(N'[dbo].[FK_ChoiceQuestionChoiceItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChoiceItem] DROP CONSTRAINT [FK_ChoiceQuestionChoiceItem];
GO
IF OBJECT_ID(N'[dbo].[FK_UserFillingFormInstance]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormInstance] DROP CONSTRAINT [FK_UserFillingFormInstance];
GO
IF OBJECT_ID(N'[dbo].[FK_ChoiceQuestion_inherits_Question]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Question_ChoiceQuestion] DROP CONSTRAINT [FK_ChoiceQuestion_inherits_Question];
GO
IF OBJECT_ID(N'[dbo].[FK_TextAnswer_inherits_Answer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Answer_TextAnswer] DROP CONSTRAINT [FK_TextAnswer_inherits_Answer];
GO
IF OBJECT_ID(N'[dbo].[FK_ChoiceAnswer_inherits_Answer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Answer_ChoiceAnswer] DROP CONSTRAINT [FK_ChoiceAnswer_inherits_Answer];
GO
IF OBJECT_ID(N'[dbo].[FK_ScaleAnswer_inherits_Answer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Answer_ScaleAnswer] DROP CONSTRAINT [FK_ScaleAnswer_inherits_Answer];
GO
IF OBJECT_ID(N'[dbo].[FK_ScaleQuestion_inherits_Question]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Question_ScaleQuestion] DROP CONSTRAINT [FK_ScaleQuestion_inherits_Question];
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
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO
IF OBJECT_ID(N'[dbo].[Group]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Group];
GO
IF OBJECT_ID(N'[dbo].[UserType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserType];
GO
IF OBJECT_ID(N'[dbo].[Form]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Form];
GO
IF OBJECT_ID(N'[dbo].[FormType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormType];
GO
IF OBJECT_ID(N'[dbo].[FormInstance]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormInstance];
GO
IF OBJECT_ID(N'[dbo].[QuestionInstance]', 'U') IS NOT NULL
    DROP TABLE [dbo].[QuestionInstance];
GO
IF OBJECT_ID(N'[dbo].[FormInstanceEvaluation]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormInstanceEvaluation];
GO
IF OBJECT_ID(N'[dbo].[Answer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Answer];
GO
IF OBJECT_ID(N'[dbo].[ChoiceItem]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ChoiceItem];
GO
IF OBJECT_ID(N'[dbo].[Question_ChoiceQuestion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Question_ChoiceQuestion];
GO
IF OBJECT_ID(N'[dbo].[Answer_TextAnswer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Answer_TextAnswer];
GO
IF OBJECT_ID(N'[dbo].[Answer_ChoiceAnswer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Answer_ChoiceAnswer];
GO
IF OBJECT_ID(N'[dbo].[Answer_ScaleAnswer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Answer_ScaleAnswer];
GO
IF OBJECT_ID(N'[dbo].[Question_ScaleQuestion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Question_ScaleQuestion];
GO
IF OBJECT_ID(N'[dbo].[GroupMembers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GroupMembers];
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------

GO

-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 02/16/2012 18:24:31
-- Generated from EDMX file: D:\_mb\School\FEL\Predmety\A7B36PRO\ELearning\src\Data\DataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [db8414991a6d244d96b85a9f91000af42b];
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
IF OBJECT_ID(N'[dbo].[FK_Supervisor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Group] DROP CONSTRAINT [FK_Supervisor];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupMembers_Group]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GroupMembers] DROP CONSTRAINT [FK_GroupMembers_Group];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupMembers_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GroupMembers] DROP CONSTRAINT [FK_GroupMembers_User];
GO
IF OBJECT_ID(N'[dbo].[FK_UserUserType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_UserUserType];
GO
IF OBJECT_ID(N'[dbo].[FK_FormTemplateFormType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Form] DROP CONSTRAINT [FK_FormTemplateFormType];
GO
IF OBJECT_ID(N'[dbo].[FK_FormTemplateAuthor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Form] DROP CONSTRAINT [FK_FormTemplateAuthor];
GO
IF OBJECT_ID(N'[dbo].[FK_QuestionGroupFormTemplate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[QuestionGroup] DROP CONSTRAINT [FK_QuestionGroupFormTemplate];
GO
IF OBJECT_ID(N'[dbo].[FK_FormInstanceUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormInstance] DROP CONSTRAINT [FK_FormInstanceUser];
GO
IF OBJECT_ID(N'[dbo].[FK_FormInstanceFormTemplate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormInstance] DROP CONSTRAINT [FK_FormInstanceFormTemplate];
GO
IF OBJECT_ID(N'[dbo].[FK_QuestionInstanceQuestionTemplate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[QuestionInstance] DROP CONSTRAINT [FK_QuestionInstanceQuestionTemplate];
GO
IF OBJECT_ID(N'[dbo].[FK_FormInstanceQuestionInstance]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[QuestionInstance] DROP CONSTRAINT [FK_FormInstanceQuestionInstance];
GO
IF OBJECT_ID(N'[dbo].[FK_FormInstanceFormInstanceEvaluation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormInstanceEvaluation] DROP CONSTRAINT [FK_FormInstanceFormInstanceEvaluation];
GO
IF OBJECT_ID(N'[dbo].[FK_QuestionInstanceAnswer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Answer] DROP CONSTRAINT [FK_QuestionInstanceAnswer];
GO
IF OBJECT_ID(N'[dbo].[FK_ChoiceQuestionChoiceItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChoiceItem] DROP CONSTRAINT [FK_ChoiceQuestionChoiceItem];
GO
IF OBJECT_ID(N'[dbo].[FK_UserFillingFormInstance]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormInstance] DROP CONSTRAINT [FK_UserFillingFormInstance];
GO
IF OBJECT_ID(N'[dbo].[FK_ChoiceQuestion_inherits_Question]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Question_ChoiceQuestion] DROP CONSTRAINT [FK_ChoiceQuestion_inherits_Question];
GO
IF OBJECT_ID(N'[dbo].[FK_TextAnswer_inherits_Answer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Answer_TextAnswer] DROP CONSTRAINT [FK_TextAnswer_inherits_Answer];
GO
IF OBJECT_ID(N'[dbo].[FK_ChoiceAnswer_inherits_Answer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Answer_ChoiceAnswer] DROP CONSTRAINT [FK_ChoiceAnswer_inherits_Answer];
GO
IF OBJECT_ID(N'[dbo].[FK_ScaleAnswer_inherits_Answer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Answer_ScaleAnswer] DROP CONSTRAINT [FK_ScaleAnswer_inherits_Answer];
GO
IF OBJECT_ID(N'[dbo].[FK_ScaleQuestion_inherits_Question]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Question_ScaleQuestion] DROP CONSTRAINT [FK_ScaleQuestion_inherits_Question];
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
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO
IF OBJECT_ID(N'[dbo].[Group]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Group];
GO
IF OBJECT_ID(N'[dbo].[UserType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserType];
GO
IF OBJECT_ID(N'[dbo].[Form]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Form];
GO
IF OBJECT_ID(N'[dbo].[FormType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormType];
GO
IF OBJECT_ID(N'[dbo].[FormInstance]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormInstance];
GO
IF OBJECT_ID(N'[dbo].[QuestionInstance]', 'U') IS NOT NULL
    DROP TABLE [dbo].[QuestionInstance];
GO
IF OBJECT_ID(N'[dbo].[FormInstanceEvaluation]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormInstanceEvaluation];
GO
IF OBJECT_ID(N'[dbo].[Answer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Answer];
GO
IF OBJECT_ID(N'[dbo].[ChoiceItem]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ChoiceItem];
GO
IF OBJECT_ID(N'[dbo].[Question_ChoiceQuestion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Question_ChoiceQuestion];
GO
IF OBJECT_ID(N'[dbo].[Answer_TextAnswer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Answer_TextAnswer];
GO
IF OBJECT_ID(N'[dbo].[Answer_ChoiceAnswer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Answer_ChoiceAnswer];
GO
IF OBJECT_ID(N'[dbo].[Answer_ScaleAnswer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Answer_ScaleAnswer];
GO
IF OBJECT_ID(N'[dbo].[Question_ScaleQuestion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Question_ScaleQuestion];
GO
IF OBJECT_ID(N'[dbo].[GroupMembers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GroupMembers];
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------

GO

-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 02/21/2012 11:57:56
-- Generated from EDMX file: D:\_mb\School\FEL\Predmety\A7B36PRO\ELearning\src\Data\DataModel.edmx
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
IF OBJECT_ID(N'[dbo].[FK_Supervisor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Group] DROP CONSTRAINT [FK_Supervisor];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupMembers_Group]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GroupMembers] DROP CONSTRAINT [FK_GroupMembers_Group];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupMembers_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GroupMembers] DROP CONSTRAINT [FK_GroupMembers_User];
GO
IF OBJECT_ID(N'[dbo].[FK_UserUserType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_UserUserType];
GO
IF OBJECT_ID(N'[dbo].[FK_FormTemplateFormType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Form] DROP CONSTRAINT [FK_FormTemplateFormType];
GO
IF OBJECT_ID(N'[dbo].[FK_FormTemplateAuthor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Form] DROP CONSTRAINT [FK_FormTemplateAuthor];
GO
IF OBJECT_ID(N'[dbo].[FK_QuestionGroupFormTemplate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[QuestionGroup] DROP CONSTRAINT [FK_QuestionGroupFormTemplate];
GO
IF OBJECT_ID(N'[dbo].[FK_FormInstanceUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormInstance] DROP CONSTRAINT [FK_FormInstanceUser];
GO
IF OBJECT_ID(N'[dbo].[FK_FormInstanceFormTemplate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormInstance] DROP CONSTRAINT [FK_FormInstanceFormTemplate];
GO
IF OBJECT_ID(N'[dbo].[FK_QuestionInstanceQuestionTemplate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[QuestionInstance] DROP CONSTRAINT [FK_QuestionInstanceQuestionTemplate];
GO
IF OBJECT_ID(N'[dbo].[FK_FormInstanceQuestionInstance]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[QuestionInstance] DROP CONSTRAINT [FK_FormInstanceQuestionInstance];
GO
IF OBJECT_ID(N'[dbo].[FK_FormInstanceFormInstanceEvaluation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormInstanceEvaluation] DROP CONSTRAINT [FK_FormInstanceFormInstanceEvaluation];
GO
IF OBJECT_ID(N'[dbo].[FK_QuestionInstanceAnswer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Answer] DROP CONSTRAINT [FK_QuestionInstanceAnswer];
GO
IF OBJECT_ID(N'[dbo].[FK_ChoiceQuestionChoiceItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChoiceItem] DROP CONSTRAINT [FK_ChoiceQuestionChoiceItem];
GO
IF OBJECT_ID(N'[dbo].[FK_UserFillingFormInstance]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormInstance] DROP CONSTRAINT [FK_UserFillingFormInstance];
GO
IF OBJECT_ID(N'[dbo].[FK_ChoiceQuestion_inherits_Question]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Question_ChoiceQuestion] DROP CONSTRAINT [FK_ChoiceQuestion_inherits_Question];
GO
IF OBJECT_ID(N'[dbo].[FK_TextAnswer_inherits_Answer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Answer_TextAnswer] DROP CONSTRAINT [FK_TextAnswer_inherits_Answer];
GO
IF OBJECT_ID(N'[dbo].[FK_ChoiceAnswer_inherits_Answer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Answer_ChoiceAnswer] DROP CONSTRAINT [FK_ChoiceAnswer_inherits_Answer];
GO
IF OBJECT_ID(N'[dbo].[FK_ScaleAnswer_inherits_Answer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Answer_ScaleAnswer] DROP CONSTRAINT [FK_ScaleAnswer_inherits_Answer];
GO
IF OBJECT_ID(N'[dbo].[FK_ScaleQuestion_inherits_Question]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Question_ScaleQuestion] DROP CONSTRAINT [FK_ScaleQuestion_inherits_Question];
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
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO
IF OBJECT_ID(N'[dbo].[Group]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Group];
GO
IF OBJECT_ID(N'[dbo].[UserType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserType];
GO
IF OBJECT_ID(N'[dbo].[Form]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Form];
GO
IF OBJECT_ID(N'[dbo].[FormType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormType];
GO
IF OBJECT_ID(N'[dbo].[FormInstance]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormInstance];
GO
IF OBJECT_ID(N'[dbo].[QuestionInstance]', 'U') IS NOT NULL
    DROP TABLE [dbo].[QuestionInstance];
GO
IF OBJECT_ID(N'[dbo].[FormInstanceEvaluation]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormInstanceEvaluation];
GO
IF OBJECT_ID(N'[dbo].[Answer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Answer];
GO
IF OBJECT_ID(N'[dbo].[ChoiceItem]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ChoiceItem];
GO
IF OBJECT_ID(N'[dbo].[Question_ChoiceQuestion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Question_ChoiceQuestion];
GO
IF OBJECT_ID(N'[dbo].[Answer_TextAnswer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Answer_TextAnswer];
GO
IF OBJECT_ID(N'[dbo].[Answer_ChoiceAnswer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Answer_ChoiceAnswer];
GO
IF OBJECT_ID(N'[dbo].[Answer_ScaleAnswer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Answer_ScaleAnswer];
GO
IF OBJECT_ID(N'[dbo].[Question_ScaleQuestion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Question_ScaleQuestion];
GO
IF OBJECT_ID(N'[dbo].[GroupMembers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GroupMembers];
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------

GO

-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 03/04/2012 10:42:03
-- Generated from EDMX file: d:\_mb\School\FEL\Predmety\A7B36PRO\ELearning\src\Data\DataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [db8414991a6d244d96b85a9f91000af42b];
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
IF OBJECT_ID(N'[dbo].[FK_Supervisor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Group] DROP CONSTRAINT [FK_Supervisor];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupMembers_Group]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GroupMembers] DROP CONSTRAINT [FK_GroupMembers_Group];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupMembers_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GroupMembers] DROP CONSTRAINT [FK_GroupMembers_User];
GO
IF OBJECT_ID(N'[dbo].[FK_UserUserType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_UserUserType];
GO
IF OBJECT_ID(N'[dbo].[FK_FormTemplateFormType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Form] DROP CONSTRAINT [FK_FormTemplateFormType];
GO
IF OBJECT_ID(N'[dbo].[FK_FormTemplateAuthor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Form] DROP CONSTRAINT [FK_FormTemplateAuthor];
GO
IF OBJECT_ID(N'[dbo].[FK_QuestionGroupFormTemplate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[QuestionGroup] DROP CONSTRAINT [FK_QuestionGroupFormTemplate];
GO
IF OBJECT_ID(N'[dbo].[FK_FormInstanceUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormInstance] DROP CONSTRAINT [FK_FormInstanceUser];
GO
IF OBJECT_ID(N'[dbo].[FK_FormInstanceFormTemplate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormInstance] DROP CONSTRAINT [FK_FormInstanceFormTemplate];
GO
IF OBJECT_ID(N'[dbo].[FK_QuestionInstanceQuestionTemplate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[QuestionInstance] DROP CONSTRAINT [FK_QuestionInstanceQuestionTemplate];
GO
IF OBJECT_ID(N'[dbo].[FK_FormInstanceQuestionInstance]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[QuestionInstance] DROP CONSTRAINT [FK_FormInstanceQuestionInstance];
GO
IF OBJECT_ID(N'[dbo].[FK_FormInstanceFormInstanceEvaluation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormInstanceEvaluation] DROP CONSTRAINT [FK_FormInstanceFormInstanceEvaluation];
GO
IF OBJECT_ID(N'[dbo].[FK_QuestionInstanceAnswer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Answer] DROP CONSTRAINT [FK_QuestionInstanceAnswer];
GO
IF OBJECT_ID(N'[dbo].[FK_ChoiceQuestionChoiceItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChoiceItem] DROP CONSTRAINT [FK_ChoiceQuestionChoiceItem];
GO
IF OBJECT_ID(N'[dbo].[FK_UserFillingFormInstance]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormInstance] DROP CONSTRAINT [FK_UserFillingFormInstance];
GO
IF OBJECT_ID(N'[dbo].[FK_ChoiceQuestion_inherits_Question]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Question_ChoiceQuestion] DROP CONSTRAINT [FK_ChoiceQuestion_inherits_Question];
GO
IF OBJECT_ID(N'[dbo].[FK_TextAnswer_inherits_Answer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Answer_TextAnswer] DROP CONSTRAINT [FK_TextAnswer_inherits_Answer];
GO
IF OBJECT_ID(N'[dbo].[FK_ChoiceAnswer_inherits_Answer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Answer_ChoiceAnswer] DROP CONSTRAINT [FK_ChoiceAnswer_inherits_Answer];
GO
IF OBJECT_ID(N'[dbo].[FK_ScaleAnswer_inherits_Answer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Answer_ScaleAnswer] DROP CONSTRAINT [FK_ScaleAnswer_inherits_Answer];
GO
IF OBJECT_ID(N'[dbo].[FK_ScaleQuestion_inherits_Question]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Question_ScaleQuestion] DROP CONSTRAINT [FK_ScaleQuestion_inherits_Question];
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
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO
IF OBJECT_ID(N'[dbo].[Group]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Group];
GO
IF OBJECT_ID(N'[dbo].[UserType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserType];
GO
IF OBJECT_ID(N'[dbo].[Form]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Form];
GO
IF OBJECT_ID(N'[dbo].[FormType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormType];
GO
IF OBJECT_ID(N'[dbo].[FormInstance]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormInstance];
GO
IF OBJECT_ID(N'[dbo].[QuestionInstance]', 'U') IS NOT NULL
    DROP TABLE [dbo].[QuestionInstance];
GO
IF OBJECT_ID(N'[dbo].[FormInstanceEvaluation]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormInstanceEvaluation];
GO
IF OBJECT_ID(N'[dbo].[Answer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Answer];
GO
IF OBJECT_ID(N'[dbo].[ChoiceItem]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ChoiceItem];
GO
IF OBJECT_ID(N'[dbo].[Question_ChoiceQuestion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Question_ChoiceQuestion];
GO
IF OBJECT_ID(N'[dbo].[Answer_TextAnswer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Answer_TextAnswer];
GO
IF OBJECT_ID(N'[dbo].[Answer_ChoiceAnswer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Answer_ChoiceAnswer];
GO
IF OBJECT_ID(N'[dbo].[Answer_ScaleAnswer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Answer_ScaleAnswer];
GO
IF OBJECT_ID(N'[dbo].[Question_ScaleQuestion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Question_ScaleQuestion];
GO
IF OBJECT_ID(N'[dbo].[GroupMembers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GroupMembers];
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------

GO

-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 03/08/2012 17:37:49
-- Generated from EDMX file: D:\_mb\School\FEL\Predmety\A7B36PRO\ELearning\src\Data\DataModel.edmx
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
IF OBJECT_ID(N'[dbo].[FK_Supervisor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Group] DROP CONSTRAINT [FK_Supervisor];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupMembers_Group]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GroupMembers] DROP CONSTRAINT [FK_GroupMembers_Group];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupMembers_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GroupMembers] DROP CONSTRAINT [FK_GroupMembers_User];
GO
IF OBJECT_ID(N'[dbo].[FK_UserUserType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_UserUserType];
GO
IF OBJECT_ID(N'[dbo].[FK_FormTemplateFormType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Form] DROP CONSTRAINT [FK_FormTemplateFormType];
GO
IF OBJECT_ID(N'[dbo].[FK_FormTemplateAuthor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Form] DROP CONSTRAINT [FK_FormTemplateAuthor];
GO
IF OBJECT_ID(N'[dbo].[FK_QuestionGroupFormTemplate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[QuestionGroup] DROP CONSTRAINT [FK_QuestionGroupFormTemplate];
GO
IF OBJECT_ID(N'[dbo].[FK_FormInstanceUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormInstance] DROP CONSTRAINT [FK_FormInstanceUser];
GO
IF OBJECT_ID(N'[dbo].[FK_FormInstanceFormTemplate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormInstance] DROP CONSTRAINT [FK_FormInstanceFormTemplate];
GO
IF OBJECT_ID(N'[dbo].[FK_QuestionInstanceQuestionTemplate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[QuestionInstance] DROP CONSTRAINT [FK_QuestionInstanceQuestionTemplate];
GO
IF OBJECT_ID(N'[dbo].[FK_FormInstanceQuestionInstance]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[QuestionInstance] DROP CONSTRAINT [FK_FormInstanceQuestionInstance];
GO
IF OBJECT_ID(N'[dbo].[FK_FormInstanceFormInstanceEvaluation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormInstanceEvaluation] DROP CONSTRAINT [FK_FormInstanceFormInstanceEvaluation];
GO
IF OBJECT_ID(N'[dbo].[FK_QuestionInstanceAnswer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Answer] DROP CONSTRAINT [FK_QuestionInstanceAnswer];
GO
IF OBJECT_ID(N'[dbo].[FK_ChoiceQuestionChoiceItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChoiceItem] DROP CONSTRAINT [FK_ChoiceQuestionChoiceItem];
GO
IF OBJECT_ID(N'[dbo].[FK_UserFillingFormInstance]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormInstance] DROP CONSTRAINT [FK_UserFillingFormInstance];
GO
IF OBJECT_ID(N'[dbo].[FK_FormGroup_Form]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormGroup] DROP CONSTRAINT [FK_FormGroup_Form];
GO
IF OBJECT_ID(N'[dbo].[FK_FormGroup_Group]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormGroup] DROP CONSTRAINT [FK_FormGroup_Group];
GO
IF OBJECT_ID(N'[dbo].[FK_ChoiceQuestion_inherits_Question]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Question_ChoiceQuestion] DROP CONSTRAINT [FK_ChoiceQuestion_inherits_Question];
GO
IF OBJECT_ID(N'[dbo].[FK_TextAnswer_inherits_Answer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Answer_TextAnswer] DROP CONSTRAINT [FK_TextAnswer_inherits_Answer];
GO
IF OBJECT_ID(N'[dbo].[FK_ChoiceAnswer_inherits_Answer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Answer_ChoiceAnswer] DROP CONSTRAINT [FK_ChoiceAnswer_inherits_Answer];
GO
IF OBJECT_ID(N'[dbo].[FK_ScaleAnswer_inherits_Answer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Answer_ScaleAnswer] DROP CONSTRAINT [FK_ScaleAnswer_inherits_Answer];
GO
IF OBJECT_ID(N'[dbo].[FK_ScaleQuestion_inherits_Question]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Question_ScaleQuestion] DROP CONSTRAINT [FK_ScaleQuestion_inherits_Question];
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
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO
IF OBJECT_ID(N'[dbo].[Group]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Group];
GO
IF OBJECT_ID(N'[dbo].[UserType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserType];
GO
IF OBJECT_ID(N'[dbo].[Form]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Form];
GO
IF OBJECT_ID(N'[dbo].[FormType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormType];
GO
IF OBJECT_ID(N'[dbo].[FormInstance]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormInstance];
GO
IF OBJECT_ID(N'[dbo].[QuestionInstance]', 'U') IS NOT NULL
    DROP TABLE [dbo].[QuestionInstance];
GO
IF OBJECT_ID(N'[dbo].[FormInstanceEvaluation]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormInstanceEvaluation];
GO
IF OBJECT_ID(N'[dbo].[Answer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Answer];
GO
IF OBJECT_ID(N'[dbo].[ChoiceItem]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ChoiceItem];
GO
IF OBJECT_ID(N'[dbo].[Question_ChoiceQuestion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Question_ChoiceQuestion];
GO
IF OBJECT_ID(N'[dbo].[Answer_TextAnswer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Answer_TextAnswer];
GO
IF OBJECT_ID(N'[dbo].[Answer_ChoiceAnswer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Answer_ChoiceAnswer];
GO
IF OBJECT_ID(N'[dbo].[Answer_ScaleAnswer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Answer_ScaleAnswer];
GO
IF OBJECT_ID(N'[dbo].[Question_ScaleQuestion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Question_ScaleQuestion];
GO
IF OBJECT_ID(N'[dbo].[GroupMembers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GroupMembers];
GO
IF OBJECT_ID(N'[dbo].[FormGroup]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormGroup];
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------

GO

-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 03/10/2012 11:10:51
-- Generated from EDMX file: D:\_mb\School\FEL\Predmety\A7B36PRO\ELearning\src\Data\DataModel.edmx
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
IF OBJECT_ID(N'[dbo].[FK_Supervisor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Group] DROP CONSTRAINT [FK_Supervisor];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupMembers_Group]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GroupMembers] DROP CONSTRAINT [FK_GroupMembers_Group];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupMembers_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GroupMembers] DROP CONSTRAINT [FK_GroupMembers_User];
GO
IF OBJECT_ID(N'[dbo].[FK_UserUserType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_UserUserType];
GO
IF OBJECT_ID(N'[dbo].[FK_FormTemplateFormType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Form] DROP CONSTRAINT [FK_FormTemplateFormType];
GO
IF OBJECT_ID(N'[dbo].[FK_FormTemplateAuthor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Form] DROP CONSTRAINT [FK_FormTemplateAuthor];
GO
IF OBJECT_ID(N'[dbo].[FK_QuestionGroupFormTemplate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[QuestionGroup] DROP CONSTRAINT [FK_QuestionGroupFormTemplate];
GO
IF OBJECT_ID(N'[dbo].[FK_FormInstanceUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormInstance] DROP CONSTRAINT [FK_FormInstanceUser];
GO
IF OBJECT_ID(N'[dbo].[FK_FormInstanceFormTemplate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormInstance] DROP CONSTRAINT [FK_FormInstanceFormTemplate];
GO
IF OBJECT_ID(N'[dbo].[FK_QuestionInstanceQuestionTemplate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[QuestionInstance] DROP CONSTRAINT [FK_QuestionInstanceQuestionTemplate];
GO
IF OBJECT_ID(N'[dbo].[FK_FormInstanceQuestionInstance]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[QuestionInstance] DROP CONSTRAINT [FK_FormInstanceQuestionInstance];
GO
IF OBJECT_ID(N'[dbo].[FK_FormInstanceFormInstanceEvaluation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormInstanceEvaluation] DROP CONSTRAINT [FK_FormInstanceFormInstanceEvaluation];
GO
IF OBJECT_ID(N'[dbo].[FK_QuestionInstanceAnswer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Answer] DROP CONSTRAINT [FK_QuestionInstanceAnswer];
GO
IF OBJECT_ID(N'[dbo].[FK_ChoiceQuestionChoiceItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChoiceItem] DROP CONSTRAINT [FK_ChoiceQuestionChoiceItem];
GO
IF OBJECT_ID(N'[dbo].[FK_UserFillingFormInstance]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormInstance] DROP CONSTRAINT [FK_UserFillingFormInstance];
GO
IF OBJECT_ID(N'[dbo].[FK_FormGroup_Form]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormGroup] DROP CONSTRAINT [FK_FormGroup_Form];
GO
IF OBJECT_ID(N'[dbo].[FK_FormGroup_Group]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormGroup] DROP CONSTRAINT [FK_FormGroup_Group];
GO
IF OBJECT_ID(N'[dbo].[FK_FormFormState]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Form] DROP CONSTRAINT [FK_FormFormState];
GO
IF OBJECT_ID(N'[dbo].[FK_ChoiceQuestion_inherits_Question]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Question_ChoiceQuestion] DROP CONSTRAINT [FK_ChoiceQuestion_inherits_Question];
GO
IF OBJECT_ID(N'[dbo].[FK_TextAnswer_inherits_Answer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Answer_TextAnswer] DROP CONSTRAINT [FK_TextAnswer_inherits_Answer];
GO
IF OBJECT_ID(N'[dbo].[FK_ChoiceAnswer_inherits_Answer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Answer_ChoiceAnswer] DROP CONSTRAINT [FK_ChoiceAnswer_inherits_Answer];
GO
IF OBJECT_ID(N'[dbo].[FK_ScaleAnswer_inherits_Answer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Answer_ScaleAnswer] DROP CONSTRAINT [FK_ScaleAnswer_inherits_Answer];
GO
IF OBJECT_ID(N'[dbo].[FK_ScaleQuestion_inherits_Question]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Question_ScaleQuestion] DROP CONSTRAINT [FK_ScaleQuestion_inherits_Question];
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
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO
IF OBJECT_ID(N'[dbo].[Group]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Group];
GO
IF OBJECT_ID(N'[dbo].[UserType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserType];
GO
IF OBJECT_ID(N'[dbo].[Form]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Form];
GO
IF OBJECT_ID(N'[dbo].[FormType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormType];
GO
IF OBJECT_ID(N'[dbo].[FormInstance]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormInstance];
GO
IF OBJECT_ID(N'[dbo].[QuestionInstance]', 'U') IS NOT NULL
    DROP TABLE [dbo].[QuestionInstance];
GO
IF OBJECT_ID(N'[dbo].[FormInstanceEvaluation]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormInstanceEvaluation];
GO
IF OBJECT_ID(N'[dbo].[Answer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Answer];
GO
IF OBJECT_ID(N'[dbo].[ChoiceItem]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ChoiceItem];
GO
IF OBJECT_ID(N'[dbo].[FormState]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormState];
GO
IF OBJECT_ID(N'[dbo].[Question_ChoiceQuestion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Question_ChoiceQuestion];
GO
IF OBJECT_ID(N'[dbo].[Answer_TextAnswer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Answer_TextAnswer];
GO
IF OBJECT_ID(N'[dbo].[Answer_ChoiceAnswer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Answer_ChoiceAnswer];
GO
IF OBJECT_ID(N'[dbo].[Answer_ScaleAnswer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Answer_ScaleAnswer];
GO
IF OBJECT_ID(N'[dbo].[Question_ScaleQuestion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Question_ScaleQuestion];
GO
IF OBJECT_ID(N'[dbo].[GroupMembers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GroupMembers];
GO
IF OBJECT_ID(N'[dbo].[FormGroup]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormGroup];
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------

GO

-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 03/10/2012 11:19:59
-- Generated from EDMX file: D:\_mb\School\FEL\Predmety\A7B36PRO\ELearning\src\Data\DataModel.edmx
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
IF OBJECT_ID(N'[dbo].[FK_Supervisor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Group] DROP CONSTRAINT [FK_Supervisor];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupMembers_Group]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GroupMembers] DROP CONSTRAINT [FK_GroupMembers_Group];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupMembers_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GroupMembers] DROP CONSTRAINT [FK_GroupMembers_User];
GO
IF OBJECT_ID(N'[dbo].[FK_UserUserType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_UserUserType];
GO
IF OBJECT_ID(N'[dbo].[FK_FormTemplateFormType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Form] DROP CONSTRAINT [FK_FormTemplateFormType];
GO
IF OBJECT_ID(N'[dbo].[FK_FormTemplateAuthor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Form] DROP CONSTRAINT [FK_FormTemplateAuthor];
GO
IF OBJECT_ID(N'[dbo].[FK_QuestionGroupFormTemplate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[QuestionGroup] DROP CONSTRAINT [FK_QuestionGroupFormTemplate];
GO
IF OBJECT_ID(N'[dbo].[FK_FormInstanceUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormInstance] DROP CONSTRAINT [FK_FormInstanceUser];
GO
IF OBJECT_ID(N'[dbo].[FK_FormInstanceFormTemplate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormInstance] DROP CONSTRAINT [FK_FormInstanceFormTemplate];
GO
IF OBJECT_ID(N'[dbo].[FK_QuestionInstanceQuestionTemplate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[QuestionInstance] DROP CONSTRAINT [FK_QuestionInstanceQuestionTemplate];
GO
IF OBJECT_ID(N'[dbo].[FK_FormInstanceQuestionInstance]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[QuestionInstance] DROP CONSTRAINT [FK_FormInstanceQuestionInstance];
GO
IF OBJECT_ID(N'[dbo].[FK_FormInstanceFormInstanceEvaluation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormInstanceEvaluation] DROP CONSTRAINT [FK_FormInstanceFormInstanceEvaluation];
GO
IF OBJECT_ID(N'[dbo].[FK_QuestionInstanceAnswer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Answer] DROP CONSTRAINT [FK_QuestionInstanceAnswer];
GO
IF OBJECT_ID(N'[dbo].[FK_ChoiceQuestionChoiceItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChoiceItem] DROP CONSTRAINT [FK_ChoiceQuestionChoiceItem];
GO
IF OBJECT_ID(N'[dbo].[FK_UserFillingFormInstance]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormInstance] DROP CONSTRAINT [FK_UserFillingFormInstance];
GO
IF OBJECT_ID(N'[dbo].[FK_FormGroup_Form]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormGroup] DROP CONSTRAINT [FK_FormGroup_Form];
GO
IF OBJECT_ID(N'[dbo].[FK_FormGroup_Group]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormGroup] DROP CONSTRAINT [FK_FormGroup_Group];
GO
IF OBJECT_ID(N'[dbo].[FK_FormFormState]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Form] DROP CONSTRAINT [FK_FormFormState];
GO
IF OBJECT_ID(N'[dbo].[FK_FormInstanceEvaluationMarkValue]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MarkValue] DROP CONSTRAINT [FK_FormInstanceEvaluationMarkValue];
GO
IF OBJECT_ID(N'[dbo].[FK_ChoiceQuestion_inherits_Question]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Question_ChoiceQuestion] DROP CONSTRAINT [FK_ChoiceQuestion_inherits_Question];
GO
IF OBJECT_ID(N'[dbo].[FK_TextAnswer_inherits_Answer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Answer_TextAnswer] DROP CONSTRAINT [FK_TextAnswer_inherits_Answer];
GO
IF OBJECT_ID(N'[dbo].[FK_ChoiceAnswer_inherits_Answer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Answer_ChoiceAnswer] DROP CONSTRAINT [FK_ChoiceAnswer_inherits_Answer];
GO
IF OBJECT_ID(N'[dbo].[FK_ScaleAnswer_inherits_Answer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Answer_ScaleAnswer] DROP CONSTRAINT [FK_ScaleAnswer_inherits_Answer];
GO
IF OBJECT_ID(N'[dbo].[FK_ScaleQuestion_inherits_Question]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Question_ScaleQuestion] DROP CONSTRAINT [FK_ScaleQuestion_inherits_Question];
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
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO
IF OBJECT_ID(N'[dbo].[Group]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Group];
GO
IF OBJECT_ID(N'[dbo].[UserType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserType];
GO
IF OBJECT_ID(N'[dbo].[Form]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Form];
GO
IF OBJECT_ID(N'[dbo].[FormType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormType];
GO
IF OBJECT_ID(N'[dbo].[FormInstance]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormInstance];
GO
IF OBJECT_ID(N'[dbo].[QuestionInstance]', 'U') IS NOT NULL
    DROP TABLE [dbo].[QuestionInstance];
GO
IF OBJECT_ID(N'[dbo].[FormInstanceEvaluation]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormInstanceEvaluation];
GO
IF OBJECT_ID(N'[dbo].[Answer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Answer];
GO
IF OBJECT_ID(N'[dbo].[ChoiceItem]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ChoiceItem];
GO
IF OBJECT_ID(N'[dbo].[FormState]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormState];
GO
IF OBJECT_ID(N'[dbo].[MarkValue]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MarkValue];
GO
IF OBJECT_ID(N'[dbo].[Question_ChoiceQuestion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Question_ChoiceQuestion];
GO
IF OBJECT_ID(N'[dbo].[Answer_TextAnswer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Answer_TextAnswer];
GO
IF OBJECT_ID(N'[dbo].[Answer_ChoiceAnswer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Answer_ChoiceAnswer];
GO
IF OBJECT_ID(N'[dbo].[Answer_ScaleAnswer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Answer_ScaleAnswer];
GO
IF OBJECT_ID(N'[dbo].[Question_ScaleQuestion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Question_ScaleQuestion];
GO
IF OBJECT_ID(N'[dbo].[GroupMembers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GroupMembers];
GO
IF OBJECT_ID(N'[dbo].[FormGroup]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormGroup];
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------

GO

-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 03/10/2012 11:19:59
-- Generated from EDMX file: D:\_mb\School\FEL\Predmety\A7B36PRO\ELearning\src\Data\DataModel.edmx
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
IF OBJECT_ID(N'[dbo].[FK_Supervisor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Group] DROP CONSTRAINT [FK_Supervisor];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupMembers_Group]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GroupMembers] DROP CONSTRAINT [FK_GroupMembers_Group];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupMembers_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GroupMembers] DROP CONSTRAINT [FK_GroupMembers_User];
GO
IF OBJECT_ID(N'[dbo].[FK_UserUserType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_UserUserType];
GO
IF OBJECT_ID(N'[dbo].[FK_FormTemplateFormType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Form] DROP CONSTRAINT [FK_FormTemplateFormType];
GO
IF OBJECT_ID(N'[dbo].[FK_FormTemplateAuthor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Form] DROP CONSTRAINT [FK_FormTemplateAuthor];
GO
IF OBJECT_ID(N'[dbo].[FK_QuestionGroupFormTemplate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[QuestionGroup] DROP CONSTRAINT [FK_QuestionGroupFormTemplate];
GO
IF OBJECT_ID(N'[dbo].[FK_FormInstanceUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormInstance] DROP CONSTRAINT [FK_FormInstanceUser];
GO
IF OBJECT_ID(N'[dbo].[FK_FormInstanceFormTemplate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormInstance] DROP CONSTRAINT [FK_FormInstanceFormTemplate];
GO
IF OBJECT_ID(N'[dbo].[FK_QuestionInstanceQuestionTemplate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[QuestionInstance] DROP CONSTRAINT [FK_QuestionInstanceQuestionTemplate];
GO
IF OBJECT_ID(N'[dbo].[FK_FormInstanceQuestionInstance]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[QuestionInstance] DROP CONSTRAINT [FK_FormInstanceQuestionInstance];
GO
IF OBJECT_ID(N'[dbo].[FK_FormInstanceFormInstanceEvaluation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormInstanceEvaluation] DROP CONSTRAINT [FK_FormInstanceFormInstanceEvaluation];
GO
IF OBJECT_ID(N'[dbo].[FK_QuestionInstanceAnswer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Answer] DROP CONSTRAINT [FK_QuestionInstanceAnswer];
GO
IF OBJECT_ID(N'[dbo].[FK_ChoiceQuestionChoiceItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChoiceItem] DROP CONSTRAINT [FK_ChoiceQuestionChoiceItem];
GO
IF OBJECT_ID(N'[dbo].[FK_UserFillingFormInstance]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormInstance] DROP CONSTRAINT [FK_UserFillingFormInstance];
GO
IF OBJECT_ID(N'[dbo].[FK_FormGroup_Form]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormGroup] DROP CONSTRAINT [FK_FormGroup_Form];
GO
IF OBJECT_ID(N'[dbo].[FK_FormGroup_Group]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormGroup] DROP CONSTRAINT [FK_FormGroup_Group];
GO
IF OBJECT_ID(N'[dbo].[FK_FormFormState]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Form] DROP CONSTRAINT [FK_FormFormState];
GO
IF OBJECT_ID(N'[dbo].[FK_FormInstanceEvaluationMarkValue]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MarkValue] DROP CONSTRAINT [FK_FormInstanceEvaluationMarkValue];
GO
IF OBJECT_ID(N'[dbo].[FK_ChoiceQuestion_inherits_Question]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Question_ChoiceQuestion] DROP CONSTRAINT [FK_ChoiceQuestion_inherits_Question];
GO
IF OBJECT_ID(N'[dbo].[FK_TextAnswer_inherits_Answer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Answer_TextAnswer] DROP CONSTRAINT [FK_TextAnswer_inherits_Answer];
GO
IF OBJECT_ID(N'[dbo].[FK_ChoiceAnswer_inherits_Answer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Answer_ChoiceAnswer] DROP CONSTRAINT [FK_ChoiceAnswer_inherits_Answer];
GO
IF OBJECT_ID(N'[dbo].[FK_ScaleAnswer_inherits_Answer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Answer_ScaleAnswer] DROP CONSTRAINT [FK_ScaleAnswer_inherits_Answer];
GO
IF OBJECT_ID(N'[dbo].[FK_ScaleQuestion_inherits_Question]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Question_ScaleQuestion] DROP CONSTRAINT [FK_ScaleQuestion_inherits_Question];
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
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO
IF OBJECT_ID(N'[dbo].[Group]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Group];
GO
IF OBJECT_ID(N'[dbo].[UserType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserType];
GO
IF OBJECT_ID(N'[dbo].[Form]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Form];
GO
IF OBJECT_ID(N'[dbo].[FormType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormType];
GO
IF OBJECT_ID(N'[dbo].[FormInstance]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormInstance];
GO
IF OBJECT_ID(N'[dbo].[QuestionInstance]', 'U') IS NOT NULL
    DROP TABLE [dbo].[QuestionInstance];
GO
IF OBJECT_ID(N'[dbo].[FormInstanceEvaluation]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormInstanceEvaluation];
GO
IF OBJECT_ID(N'[dbo].[Answer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Answer];
GO
IF OBJECT_ID(N'[dbo].[ChoiceItem]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ChoiceItem];
GO
IF OBJECT_ID(N'[dbo].[FormState]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormState];
GO
IF OBJECT_ID(N'[dbo].[MarkValue]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MarkValue];
GO
IF OBJECT_ID(N'[dbo].[Question_ChoiceQuestion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Question_ChoiceQuestion];
GO
IF OBJECT_ID(N'[dbo].[Answer_TextAnswer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Answer_TextAnswer];
GO
IF OBJECT_ID(N'[dbo].[Answer_ChoiceAnswer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Answer_ChoiceAnswer];
GO
IF OBJECT_ID(N'[dbo].[Answer_ScaleAnswer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Answer_ScaleAnswer];
GO
IF OBJECT_ID(N'[dbo].[Question_ScaleQuestion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Question_ScaleQuestion];
GO
IF OBJECT_ID(N'[dbo].[GroupMembers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GroupMembers];
GO
IF OBJECT_ID(N'[dbo].[FormGroup]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormGroup];
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------

GO

-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 03/10/2012 11:19:59
-- Generated from EDMX file: D:\_mb\School\FEL\Predmety\A7B36PRO\ELearning\src\Data\DataModel.edmx
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
IF OBJECT_ID(N'[dbo].[FK_Supervisor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Group] DROP CONSTRAINT [FK_Supervisor];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupMembers_Group]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GroupMembers] DROP CONSTRAINT [FK_GroupMembers_Group];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupMembers_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GroupMembers] DROP CONSTRAINT [FK_GroupMembers_User];
GO
IF OBJECT_ID(N'[dbo].[FK_UserUserType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_UserUserType];
GO
IF OBJECT_ID(N'[dbo].[FK_FormTemplateFormType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Form] DROP CONSTRAINT [FK_FormTemplateFormType];
GO
IF OBJECT_ID(N'[dbo].[FK_FormTemplateAuthor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Form] DROP CONSTRAINT [FK_FormTemplateAuthor];
GO
IF OBJECT_ID(N'[dbo].[FK_QuestionGroupFormTemplate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[QuestionGroup] DROP CONSTRAINT [FK_QuestionGroupFormTemplate];
GO
IF OBJECT_ID(N'[dbo].[FK_FormInstanceUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormInstance] DROP CONSTRAINT [FK_FormInstanceUser];
GO
IF OBJECT_ID(N'[dbo].[FK_FormInstanceFormTemplate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormInstance] DROP CONSTRAINT [FK_FormInstanceFormTemplate];
GO
IF OBJECT_ID(N'[dbo].[FK_QuestionInstanceQuestionTemplate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[QuestionInstance] DROP CONSTRAINT [FK_QuestionInstanceQuestionTemplate];
GO
IF OBJECT_ID(N'[dbo].[FK_FormInstanceQuestionInstance]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[QuestionInstance] DROP CONSTRAINT [FK_FormInstanceQuestionInstance];
GO
IF OBJECT_ID(N'[dbo].[FK_FormInstanceFormInstanceEvaluation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormInstanceEvaluation] DROP CONSTRAINT [FK_FormInstanceFormInstanceEvaluation];
GO
IF OBJECT_ID(N'[dbo].[FK_QuestionInstanceAnswer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Answer] DROP CONSTRAINT [FK_QuestionInstanceAnswer];
GO
IF OBJECT_ID(N'[dbo].[FK_ChoiceQuestionChoiceItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChoiceItem] DROP CONSTRAINT [FK_ChoiceQuestionChoiceItem];
GO
IF OBJECT_ID(N'[dbo].[FK_UserFillingFormInstance]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormInstance] DROP CONSTRAINT [FK_UserFillingFormInstance];
GO
IF OBJECT_ID(N'[dbo].[FK_FormGroup_Form]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormGroup] DROP CONSTRAINT [FK_FormGroup_Form];
GO
IF OBJECT_ID(N'[dbo].[FK_FormGroup_Group]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormGroup] DROP CONSTRAINT [FK_FormGroup_Group];
GO
IF OBJECT_ID(N'[dbo].[FK_FormFormState]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Form] DROP CONSTRAINT [FK_FormFormState];
GO
IF OBJECT_ID(N'[dbo].[FK_FormInstanceEvaluationMarkValue]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MarkValue] DROP CONSTRAINT [FK_FormInstanceEvaluationMarkValue];
GO
IF OBJECT_ID(N'[dbo].[FK_ChoiceQuestion_inherits_Question]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Question_ChoiceQuestion] DROP CONSTRAINT [FK_ChoiceQuestion_inherits_Question];
GO
IF OBJECT_ID(N'[dbo].[FK_TextAnswer_inherits_Answer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Answer_TextAnswer] DROP CONSTRAINT [FK_TextAnswer_inherits_Answer];
GO
IF OBJECT_ID(N'[dbo].[FK_ChoiceAnswer_inherits_Answer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Answer_ChoiceAnswer] DROP CONSTRAINT [FK_ChoiceAnswer_inherits_Answer];
GO
IF OBJECT_ID(N'[dbo].[FK_ScaleAnswer_inherits_Answer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Answer_ScaleAnswer] DROP CONSTRAINT [FK_ScaleAnswer_inherits_Answer];
GO
IF OBJECT_ID(N'[dbo].[FK_ScaleQuestion_inherits_Question]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Question_ScaleQuestion] DROP CONSTRAINT [FK_ScaleQuestion_inherits_Question];
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
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO
IF OBJECT_ID(N'[dbo].[Group]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Group];
GO
IF OBJECT_ID(N'[dbo].[UserType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserType];
GO
IF OBJECT_ID(N'[dbo].[Form]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Form];
GO
IF OBJECT_ID(N'[dbo].[FormType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormType];
GO
IF OBJECT_ID(N'[dbo].[FormInstance]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormInstance];
GO
IF OBJECT_ID(N'[dbo].[QuestionInstance]', 'U') IS NOT NULL
    DROP TABLE [dbo].[QuestionInstance];
GO
IF OBJECT_ID(N'[dbo].[FormInstanceEvaluation]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormInstanceEvaluation];
GO
IF OBJECT_ID(N'[dbo].[Answer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Answer];
GO
IF OBJECT_ID(N'[dbo].[ChoiceItem]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ChoiceItem];
GO
IF OBJECT_ID(N'[dbo].[FormState]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormState];
GO
IF OBJECT_ID(N'[dbo].[MarkValue]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MarkValue];
GO
IF OBJECT_ID(N'[dbo].[Question_ChoiceQuestion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Question_ChoiceQuestion];
GO
IF OBJECT_ID(N'[dbo].[Answer_TextAnswer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Answer_TextAnswer];
GO
IF OBJECT_ID(N'[dbo].[Answer_ChoiceAnswer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Answer_ChoiceAnswer];
GO
IF OBJECT_ID(N'[dbo].[Answer_ScaleAnswer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Answer_ScaleAnswer];
GO
IF OBJECT_ID(N'[dbo].[Question_ScaleQuestion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Question_ScaleQuestion];
GO
IF OBJECT_ID(N'[dbo].[GroupMembers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GroupMembers];
GO
IF OBJECT_ID(N'[dbo].[FormGroup]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormGroup];
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------

GO

-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 03/11/2012 13:31:24
-- Generated from EDMX file: D:\_mb\School\FEL\Predmety\A7B36PRO\ELearning\src\Data\DataModel.edmx
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
IF OBJECT_ID(N'[dbo].[FK_Supervisor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Group] DROP CONSTRAINT [FK_Supervisor];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupMembers_Group]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GroupMembers] DROP CONSTRAINT [FK_GroupMembers_Group];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupMembers_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GroupMembers] DROP CONSTRAINT [FK_GroupMembers_User];
GO
IF OBJECT_ID(N'[dbo].[FK_UserUserType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_UserUserType];
GO
IF OBJECT_ID(N'[dbo].[FK_FormTemplateFormType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Form] DROP CONSTRAINT [FK_FormTemplateFormType];
GO
IF OBJECT_ID(N'[dbo].[FK_FormTemplateAuthor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Form] DROP CONSTRAINT [FK_FormTemplateAuthor];
GO
IF OBJECT_ID(N'[dbo].[FK_QuestionGroupFormTemplate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[QuestionGroup] DROP CONSTRAINT [FK_QuestionGroupFormTemplate];
GO
IF OBJECT_ID(N'[dbo].[FK_FormInstanceUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormInstance] DROP CONSTRAINT [FK_FormInstanceUser];
GO
IF OBJECT_ID(N'[dbo].[FK_FormInstanceFormTemplate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormInstance] DROP CONSTRAINT [FK_FormInstanceFormTemplate];
GO
IF OBJECT_ID(N'[dbo].[FK_QuestionInstanceQuestionTemplate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[QuestionInstance] DROP CONSTRAINT [FK_QuestionInstanceQuestionTemplate];
GO
IF OBJECT_ID(N'[dbo].[FK_FormInstanceQuestionInstance]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[QuestionInstance] DROP CONSTRAINT [FK_FormInstanceQuestionInstance];
GO
IF OBJECT_ID(N'[dbo].[FK_FormInstanceFormInstanceEvaluation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormInstanceEvaluation] DROP CONSTRAINT [FK_FormInstanceFormInstanceEvaluation];
GO
IF OBJECT_ID(N'[dbo].[FK_QuestionInstanceAnswer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Answer] DROP CONSTRAINT [FK_QuestionInstanceAnswer];
GO
IF OBJECT_ID(N'[dbo].[FK_ChoiceQuestionChoiceItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChoiceItem] DROP CONSTRAINT [FK_ChoiceQuestionChoiceItem];
GO
IF OBJECT_ID(N'[dbo].[FK_UserFillingFormInstance]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormInstance] DROP CONSTRAINT [FK_UserFillingFormInstance];
GO
IF OBJECT_ID(N'[dbo].[FK_FormGroup_Form]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormGroup] DROP CONSTRAINT [FK_FormGroup_Form];
GO
IF OBJECT_ID(N'[dbo].[FK_FormGroup_Group]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormGroup] DROP CONSTRAINT [FK_FormGroup_Group];
GO
IF OBJECT_ID(N'[dbo].[FK_FormFormState]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Form] DROP CONSTRAINT [FK_FormFormState];
GO
IF OBJECT_ID(N'[dbo].[FK_FormInstanceEvaluationMarkValue]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormInstanceEvaluation] DROP CONSTRAINT [FK_FormInstanceEvaluationMarkValue];
GO
IF OBJECT_ID(N'[dbo].[FK_ChoiceQuestion_inherits_Question]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Question_ChoiceQuestion] DROP CONSTRAINT [FK_ChoiceQuestion_inherits_Question];
GO
IF OBJECT_ID(N'[dbo].[FK_TextAnswer_inherits_Answer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Answer_TextAnswer] DROP CONSTRAINT [FK_TextAnswer_inherits_Answer];
GO
IF OBJECT_ID(N'[dbo].[FK_ChoiceAnswer_inherits_Answer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Answer_ChoiceAnswer] DROP CONSTRAINT [FK_ChoiceAnswer_inherits_Answer];
GO
IF OBJECT_ID(N'[dbo].[FK_ScaleAnswer_inherits_Answer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Answer_ScaleAnswer] DROP CONSTRAINT [FK_ScaleAnswer_inherits_Answer];
GO
IF OBJECT_ID(N'[dbo].[FK_ScaleQuestion_inherits_Question]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Question_ScaleQuestion] DROP CONSTRAINT [FK_ScaleQuestion_inherits_Question];
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
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO
IF OBJECT_ID(N'[dbo].[Group]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Group];
GO
IF OBJECT_ID(N'[dbo].[UserType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserType];
GO
IF OBJECT_ID(N'[dbo].[Form]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Form];
GO
IF OBJECT_ID(N'[dbo].[FormType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormType];
GO
IF OBJECT_ID(N'[dbo].[FormInstance]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormInstance];
GO
IF OBJECT_ID(N'[dbo].[QuestionInstance]', 'U') IS NOT NULL
    DROP TABLE [dbo].[QuestionInstance];
GO
IF OBJECT_ID(N'[dbo].[FormInstanceEvaluation]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormInstanceEvaluation];
GO
IF OBJECT_ID(N'[dbo].[Answer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Answer];
GO
IF OBJECT_ID(N'[dbo].[ChoiceItem]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ChoiceItem];
GO
IF OBJECT_ID(N'[dbo].[FormState]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormState];
GO
IF OBJECT_ID(N'[dbo].[MarkValue]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MarkValue];
GO
IF OBJECT_ID(N'[dbo].[Question_ChoiceQuestion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Question_ChoiceQuestion];
GO
IF OBJECT_ID(N'[dbo].[Answer_TextAnswer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Answer_TextAnswer];
GO
IF OBJECT_ID(N'[dbo].[Answer_ChoiceAnswer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Answer_ChoiceAnswer];
GO
IF OBJECT_ID(N'[dbo].[Answer_ScaleAnswer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Answer_ScaleAnswer];
GO
IF OBJECT_ID(N'[dbo].[Question_ScaleQuestion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Question_ScaleQuestion];
GO
IF OBJECT_ID(N'[dbo].[GroupMembers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GroupMembers];
GO
IF OBJECT_ID(N'[dbo].[FormGroup]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormGroup];
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------

GO

-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 03/11/2012 14:12:07
-- Generated from EDMX file: D:\_mb\School\FEL\Predmety\A7B36PRO\ELearning\src\Data\DataModel.edmx
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
IF OBJECT_ID(N'[dbo].[FK_Supervisor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Group] DROP CONSTRAINT [FK_Supervisor];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupMembers_Group]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GroupMembers] DROP CONSTRAINT [FK_GroupMembers_Group];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupMembers_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GroupMembers] DROP CONSTRAINT [FK_GroupMembers_User];
GO
IF OBJECT_ID(N'[dbo].[FK_UserUserType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_UserUserType];
GO
IF OBJECT_ID(N'[dbo].[FK_FormTemplateFormType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Form] DROP CONSTRAINT [FK_FormTemplateFormType];
GO
IF OBJECT_ID(N'[dbo].[FK_FormTemplateAuthor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Form] DROP CONSTRAINT [FK_FormTemplateAuthor];
GO
IF OBJECT_ID(N'[dbo].[FK_QuestionGroupFormTemplate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[QuestionGroup] DROP CONSTRAINT [FK_QuestionGroupFormTemplate];
GO
IF OBJECT_ID(N'[dbo].[FK_FormInstanceUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormInstance] DROP CONSTRAINT [FK_FormInstanceUser];
GO
IF OBJECT_ID(N'[dbo].[FK_FormInstanceFormTemplate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormInstance] DROP CONSTRAINT [FK_FormInstanceFormTemplate];
GO
IF OBJECT_ID(N'[dbo].[FK_QuestionInstanceQuestionTemplate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[QuestionInstance] DROP CONSTRAINT [FK_QuestionInstanceQuestionTemplate];
GO
IF OBJECT_ID(N'[dbo].[FK_FormInstanceQuestionInstance]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[QuestionInstance] DROP CONSTRAINT [FK_FormInstanceQuestionInstance];
GO
IF OBJECT_ID(N'[dbo].[FK_FormInstanceFormInstanceEvaluation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormInstanceEvaluation] DROP CONSTRAINT [FK_FormInstanceFormInstanceEvaluation];
GO
IF OBJECT_ID(N'[dbo].[FK_QuestionInstanceAnswer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Answer] DROP CONSTRAINT [FK_QuestionInstanceAnswer];
GO
IF OBJECT_ID(N'[dbo].[FK_ChoiceQuestionChoiceItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChoiceItem] DROP CONSTRAINT [FK_ChoiceQuestionChoiceItem];
GO
IF OBJECT_ID(N'[dbo].[FK_UserFillingFormInstance]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormInstance] DROP CONSTRAINT [FK_UserFillingFormInstance];
GO
IF OBJECT_ID(N'[dbo].[FK_FormGroup_Form]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormGroup] DROP CONSTRAINT [FK_FormGroup_Form];
GO
IF OBJECT_ID(N'[dbo].[FK_FormGroup_Group]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormGroup] DROP CONSTRAINT [FK_FormGroup_Group];
GO
IF OBJECT_ID(N'[dbo].[FK_FormFormState]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Form] DROP CONSTRAINT [FK_FormFormState];
GO
IF OBJECT_ID(N'[dbo].[FK_FormInstanceEvaluationMarkValue]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormInstanceEvaluation] DROP CONSTRAINT [FK_FormInstanceEvaluationMarkValue];
GO
IF OBJECT_ID(N'[dbo].[FK_MultipleChoiceAnswerChoiceAnswer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Answer_ChoiceAnswer] DROP CONSTRAINT [FK_MultipleChoiceAnswerChoiceAnswer];
GO
IF OBJECT_ID(N'[dbo].[FK_ChoiceQuestion_inherits_Question]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Question_ChoiceQuestion] DROP CONSTRAINT [FK_ChoiceQuestion_inherits_Question];
GO
IF OBJECT_ID(N'[dbo].[FK_MultipleChoiceAnswer_inherits_Answer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Answer_MultipleChoiceAnswer] DROP CONSTRAINT [FK_MultipleChoiceAnswer_inherits_Answer];
GO
IF OBJECT_ID(N'[dbo].[FK_ChoiceAnswer_inherits_Answer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Answer_ChoiceAnswer] DROP CONSTRAINT [FK_ChoiceAnswer_inherits_Answer];
GO
IF OBJECT_ID(N'[dbo].[FK_TextAnswer_inherits_Answer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Answer_TextAnswer] DROP CONSTRAINT [FK_TextAnswer_inherits_Answer];
GO
IF OBJECT_ID(N'[dbo].[FK_ScaleAnswer_inherits_Answer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Answer_ScaleAnswer] DROP CONSTRAINT [FK_ScaleAnswer_inherits_Answer];
GO
IF OBJECT_ID(N'[dbo].[FK_ScaleQuestion_inherits_Question]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Question_ScaleQuestion] DROP CONSTRAINT [FK_ScaleQuestion_inherits_Question];
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
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO
IF OBJECT_ID(N'[dbo].[Group]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Group];
GO
IF OBJECT_ID(N'[dbo].[UserType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserType];
GO
IF OBJECT_ID(N'[dbo].[Form]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Form];
GO
IF OBJECT_ID(N'[dbo].[FormType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormType];
GO
IF OBJECT_ID(N'[dbo].[FormInstance]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormInstance];
GO
IF OBJECT_ID(N'[dbo].[QuestionInstance]', 'U') IS NOT NULL
    DROP TABLE [dbo].[QuestionInstance];
GO
IF OBJECT_ID(N'[dbo].[FormInstanceEvaluation]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormInstanceEvaluation];
GO
IF OBJECT_ID(N'[dbo].[Answer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Answer];
GO
IF OBJECT_ID(N'[dbo].[ChoiceItem]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ChoiceItem];
GO
IF OBJECT_ID(N'[dbo].[FormState]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormState];
GO
IF OBJECT_ID(N'[dbo].[MarkValue]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MarkValue];
GO
IF OBJECT_ID(N'[dbo].[Question_ChoiceQuestion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Question_ChoiceQuestion];
GO
IF OBJECT_ID(N'[dbo].[Answer_MultipleChoiceAnswer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Answer_MultipleChoiceAnswer];
GO
IF OBJECT_ID(N'[dbo].[Answer_ChoiceAnswer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Answer_ChoiceAnswer];
GO
IF OBJECT_ID(N'[dbo].[Answer_TextAnswer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Answer_TextAnswer];
GO
IF OBJECT_ID(N'[dbo].[Answer_ScaleAnswer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Answer_ScaleAnswer];
GO
IF OBJECT_ID(N'[dbo].[Question_ScaleQuestion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Question_ScaleQuestion];
GO
IF OBJECT_ID(N'[dbo].[GroupMembers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GroupMembers];
GO
IF OBJECT_ID(N'[dbo].[FormGroup]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormGroup];
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------

GO
