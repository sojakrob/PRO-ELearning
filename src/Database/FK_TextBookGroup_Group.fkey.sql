-- Creating foreign key on [Groups_ID] in table 'TextBookGroup'
-- Creating foreign key on [Groups_ID] in table 'TextBookGroup'
ALTER TABLE [dbo].[TextBookGroup]
ADD CONSTRAINT [FK_TextBookGroup_Group]
    FOREIGN KEY ([Groups_ID])
    REFERENCES [dbo].[Group]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;





