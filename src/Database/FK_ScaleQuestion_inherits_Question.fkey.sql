-- Creating foreign key on [ID] in table 'Question_ScaleQuestion'
-- Creating foreign key on [ID] in table 'Question_ScaleQuestion'
-- Creating foreign key on [ID] in table 'Question_ScaleQuestion'
-- Creating foreign key on [ID] in table 'Question_ScaleQuestion'
ALTER TABLE [dbo].[Question_ScaleQuestion]
ADD CONSTRAINT [FK_ScaleQuestion_inherits_Question]
    FOREIGN KEY ([ID])
    REFERENCES [dbo].[Question]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;











