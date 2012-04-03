-- Creating foreign key on [TextBooks_ID] in table 'TextBookGroup'
ALTER TABLE [dbo].[TextBookGroup]
ADD CONSTRAINT [FK_TextBookGroup_TextBook]
    FOREIGN KEY ([TextBooks_ID])
    REFERENCES [dbo].[TextBook]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;


