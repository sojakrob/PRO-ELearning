-- Creating foreign key on [ID] in table 'Answer_ScaleAnswer'
-- Creating foreign key on [ID] in table 'Answer_ScaleAnswer'
-- Creating foreign key on [ID] in table 'Answer_ScaleAnswer'
-- Creating foreign key on [ID] in table 'Answer_ScaleAnswer'
ALTER TABLE [dbo].[Answer_ScaleAnswer]
ADD CONSTRAINT [FK_ScaleAnswer_inherits_Answer]
    FOREIGN KEY ([ID])
    REFERENCES [dbo].[Answer]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;











