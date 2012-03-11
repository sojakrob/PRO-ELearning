-- Creating foreign key on [FormStateID] in table 'Form'
ALTER TABLE [dbo].[Form]
ADD CONSTRAINT [FK_FormFormState]
    FOREIGN KEY ([FormStateID])
    REFERENCES [dbo].[FormState]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;


