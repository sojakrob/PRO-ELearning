-- Creating foreign key on [ChoiceItemID] in table 'MultipleChoiceAnswerItem'
-- Creating foreign key on [ChoiceItemID] in table 'MultipleChoiceAnswerItem'
ALTER TABLE [dbo].[MultipleChoiceAnswerItem]
ADD CONSTRAINT [FK_MultipleChoiceAnswerItemChoiceItem]
    FOREIGN KEY ([ChoiceItemID])
    REFERENCES [dbo].[ChoiceItem]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;





