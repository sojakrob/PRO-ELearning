-- Creating foreign key on [ID] in table 'Answer_ChoiceAnswer'
-- Creating foreign key on [ID] in table 'Answer_ChoiceAnswer'
-- Creating foreign key on [ID] in table 'Answer_ChoiceAnswer'
ALTER TABLE [dbo].[Answer_ChoiceAnswer]
ADD CONSTRAINT [FK_ChoiceAnswer_inherits_Answer]
    FOREIGN KEY ([ID])
    REFERENCES [dbo].[Answer]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;








