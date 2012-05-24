-- Creating foreign key on [ChoiceQuestionID] in table 'ChoiceItem'
-- Creating foreign key on [ChoiceQuestionID] in table 'ChoiceItem'
ALTER TABLE [dbo].[ChoiceItem]
ADD CONSTRAINT [FK_ChoiceQuestionChoiceItem]
    FOREIGN KEY ([ChoiceQuestionID])
    REFERENCES [dbo].[Question_ChoiceQuestion]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;





