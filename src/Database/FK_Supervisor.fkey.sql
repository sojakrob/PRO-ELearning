-- Creating foreign key on [SupervisorID] in table 'Group'
-- Creating foreign key on [SupervisorID] in table 'Group'
-- Creating foreign key on [SupervisorID] in table 'Group'
-- Creating foreign key on [SupervisorID] in table 'Group'
ALTER TABLE [dbo].[Group]
ADD CONSTRAINT [FK_Supervisor]
    FOREIGN KEY ([SupervisorID])
    REFERENCES [dbo].[User]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;











