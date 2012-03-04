-- Creating foreign key on [UserFillingFormInstance_FormInstance_ID] in table 'FormInstance'
-- Creating foreign key on [UserFillingFormInstance_FormInstance_ID] in table 'FormInstance'
-- Creating foreign key on [UserFillingFormInstance_FormInstance_ID] in table 'FormInstance'
ALTER TABLE [dbo].[FormInstance]
ADD CONSTRAINT [FK_UserFillingFormInstance]
    FOREIGN KEY ([UserFillingFormInstance_FormInstance_ID])
    REFERENCES [dbo].[User]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;








