-- Creating foreign key on [FormInstanceID] in table 'QuestionInstance'
-- Creating foreign key on [FormInstanceID] in table 'QuestionInstance'
-- Creating foreign key on [FormInstanceID] in table 'QuestionInstance'
-- Creating foreign key on [FormInstanceID] in table 'QuestionInstance'
ALTER TABLE [dbo].[QuestionInstance]
ADD CONSTRAINT [FK_FormInstanceQuestionInstance]
    FOREIGN KEY ([FormInstanceID])
    REFERENCES [dbo].[FormInstance]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;











