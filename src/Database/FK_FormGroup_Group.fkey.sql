-- Creating foreign key on [Groups_ID] in table 'FormGroup'
-- Creating foreign key on [Groups_ID] in table 'FormGroup'
-- Creating foreign key on [Groups_ID] in table 'FormGroup'
ALTER TABLE [dbo].[FormGroup]
ADD CONSTRAINT [FK_FormGroup_Group]
    FOREIGN KEY ([Groups_ID])
    REFERENCES [dbo].[Group]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;








