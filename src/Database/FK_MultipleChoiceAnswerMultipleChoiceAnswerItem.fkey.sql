-- Creating foreign key on [MultipleChoiceAnswerID] in table 'MultipleChoiceAnswerItem'
-- Creating foreign key on [MultipleChoiceAnswerID] in table 'MultipleChoiceAnswerItem'
ALTER TABLE [dbo].[MultipleChoiceAnswerItem]
ADD CONSTRAINT [FK_MultipleChoiceAnswerMultipleChoiceAnswerItem]
    FOREIGN KEY ([MultipleChoiceAnswerID])
    REFERENCES [dbo].[Answer_MultipleChoiceAnswer]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;





