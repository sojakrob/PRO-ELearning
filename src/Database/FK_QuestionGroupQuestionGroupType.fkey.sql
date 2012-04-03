-- Creating foreign key on [QuestionGroupTypeID] in table 'QuestionGroup'
ALTER TABLE [dbo].[QuestionGroup]
ADD CONSTRAINT [FK_QuestionGroupQuestionGroupType]
    FOREIGN KEY ([QuestionGroupTypeID])
    REFERENCES [dbo].[QuestionGroupType]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;


