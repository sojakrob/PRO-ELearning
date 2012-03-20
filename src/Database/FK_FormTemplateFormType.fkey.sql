-- Creating foreign key on [FormTypeID] in table 'Form'
-- Creating foreign key on [FormTypeID] in table 'Form'
-- Creating foreign key on [FormTypeID] in table 'Form'
-- Creating foreign key on [FormTypeID] in table 'Form'
ALTER TABLE [dbo].[Form]
ADD CONSTRAINT [FK_FormTemplateFormType]
    FOREIGN KEY ([FormTypeID])
    REFERENCES [dbo].[FormType]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;











