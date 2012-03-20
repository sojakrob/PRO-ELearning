-- Creating foreign key on [Groups_ID] in table 'GroupMembers'
-- Creating foreign key on [Groups_ID] in table 'GroupMembers'
-- Creating foreign key on [Groups_ID] in table 'GroupMembers'
-- Creating foreign key on [Groups_ID] in table 'GroupMembers'
ALTER TABLE [dbo].[GroupMembers]
ADD CONSTRAINT [FK_GroupMembers_Group]
    FOREIGN KEY ([Groups_ID])
    REFERENCES [dbo].[Group]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;











