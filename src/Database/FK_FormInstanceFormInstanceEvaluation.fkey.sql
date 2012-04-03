-- Creating foreign key on [FormInstance_ID] in table 'FormInstanceEvaluation'
ALTER TABLE [dbo].[FormInstanceEvaluation]
ADD CONSTRAINT [FK_FormInstanceFormInstanceEvaluation]
    FOREIGN KEY ([FormInstance_ID])
    REFERENCES [dbo].[FormInstance]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;


