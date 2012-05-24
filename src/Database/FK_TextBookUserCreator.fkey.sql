-- Creating foreign key on [CreatedByID] in table 'TextBook'
-- Creating foreign key on [CreatedByID] in table 'TextBook'
ALTER TABLE [dbo].[TextBook]
ADD CONSTRAINT [FK_TextBookUserCreator]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[User]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;





