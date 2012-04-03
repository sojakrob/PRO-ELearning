-- Creating foreign key on [ItemID] in table 'Answer_ChoiceAnswer'
ALTER TABLE [dbo].[Answer_ChoiceAnswer]
ADD CONSTRAINT [FK_ChoiceAnswerChoiceItem]
    FOREIGN KEY ([ItemID])
    REFERENCES [dbo].[ChoiceItem]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;


