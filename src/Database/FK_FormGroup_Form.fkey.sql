-- Creating foreign key on [Forms_ID] in table 'FormGroup'
-- Creating foreign key on [Forms_ID] in table 'FormGroup'
-- Creating foreign key on [Forms_ID] in table 'FormGroup'
ALTER TABLE [dbo].[FormGroup]
ADD CONSTRAINT [FK_FormGroup_Form]
    FOREIGN KEY ([Forms_ID])
    REFERENCES [dbo].[Form]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;








