-- Creating foreign key on [ChangedByID] in table 'TextBook'
-- Creating foreign key on [ChangedByID] in table 'TextBook'
ALTER TABLE [dbo].[TextBook]
ADD CONSTRAINT [FK_TextBookUserChanger]
    FOREIGN KEY ([ChangedByID])
    REFERENCES [dbo].[User]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;





