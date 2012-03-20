-- Creating foreign key on [SolverID] in table 'FormInstance'
-- Creating foreign key on [SolverID] in table 'FormInstance'
-- Creating foreign key on [SolverID] in table 'FormInstance'
-- Creating foreign key on [SolverID] in table 'FormInstance'
ALTER TABLE [dbo].[FormInstance]
ADD CONSTRAINT [FK_FormInstanceUser]
    FOREIGN KEY ([SolverID])
    REFERENCES [dbo].[User]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;











