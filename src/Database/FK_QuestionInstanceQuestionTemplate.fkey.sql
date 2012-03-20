-- Creating foreign key on [QuestionID] in table 'QuestionInstance'
-- Creating foreign key on [QuestionID] in table 'QuestionInstance'
-- Creating foreign key on [QuestionID] in table 'QuestionInstance'
-- Creating foreign key on [QuestionID] in table 'QuestionInstance'
ALTER TABLE [dbo].[QuestionInstance]
ADD CONSTRAINT [FK_QuestionInstanceQuestionTemplate]
    FOREIGN KEY ([QuestionID])
    REFERENCES [dbo].[Question]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;











