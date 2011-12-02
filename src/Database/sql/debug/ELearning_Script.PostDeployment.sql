
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
