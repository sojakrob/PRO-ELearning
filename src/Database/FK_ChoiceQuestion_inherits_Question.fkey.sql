-- Creating foreign key on [ID] in table 'Question_ChoiceQuestion'
ALTER TABLE [dbo].[Question_ChoiceQuestion]
ADD CONSTRAINT [FK_ChoiceQuestion_inherits_Question]
    FOREIGN KEY ([ID])
    REFERENCES [dbo].[Question]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;


