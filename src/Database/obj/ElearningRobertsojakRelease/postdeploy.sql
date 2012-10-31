
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
