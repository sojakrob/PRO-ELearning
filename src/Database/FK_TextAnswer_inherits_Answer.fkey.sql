-- Creating foreign key on [ID] in table 'Answer_TextAnswer'
-- Creating foreign key on [ID] in table 'Answer_TextAnswer'
-- Creating foreign key on [ID] in table 'Answer_TextAnswer'
-- Creating foreign key on [ID] in table 'Answer_TextAnswer'
ALTER TABLE [dbo].[Answer_TextAnswer]
ADD CONSTRAINT [FK_TextAnswer_inherits_Answer]
    FOREIGN KEY ([ID])
    REFERENCES [dbo].[Answer]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;











