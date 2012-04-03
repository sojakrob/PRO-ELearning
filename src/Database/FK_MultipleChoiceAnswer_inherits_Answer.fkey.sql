-- Creating foreign key on [ID] in table 'Answer_MultipleChoiceAnswer'
ALTER TABLE [dbo].[Answer_MultipleChoiceAnswer]
ADD CONSTRAINT [FK_MultipleChoiceAnswer_inherits_Answer]
    FOREIGN KEY ([ID])
    REFERENCES [dbo].[Answer]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;


