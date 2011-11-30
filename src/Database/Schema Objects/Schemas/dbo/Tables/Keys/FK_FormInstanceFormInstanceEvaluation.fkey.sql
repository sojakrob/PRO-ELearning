-- Creating foreign key on [Evaluation_ID] in table 'FormInstance'
ALTER TABLE [dbo].[FormInstance]
ADD CONSTRAINT [FK_FormInstanceFormInstanceEvaluation]
    FOREIGN KEY ([Evaluation_ID])
    REFERENCES [dbo].[FormInstanceEvaluation]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;


