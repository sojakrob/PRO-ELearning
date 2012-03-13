-- Creating foreign key on [FormTemplateID] in table 'FormInstance'
-- Creating foreign key on [FormTemplateID] in table 'FormInstance'
-- Creating foreign key on [FormTemplateID] in table 'FormInstance'
ALTER TABLE [dbo].[FormInstance]
ADD CONSTRAINT [FK_FormInstanceFormTemplate]
    FOREIGN KEY ([FormTemplateID])
    REFERENCES [dbo].[Form]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;








