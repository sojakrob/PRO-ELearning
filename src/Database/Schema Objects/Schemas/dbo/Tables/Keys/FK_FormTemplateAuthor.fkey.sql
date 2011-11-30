-- Creating foreign key on [AuthorID] in table 'Form'
ALTER TABLE [dbo].[Form]
ADD CONSTRAINT [FK_FormTemplateAuthor]
    FOREIGN KEY ([AuthorID])
    REFERENCES [dbo].[User]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;


