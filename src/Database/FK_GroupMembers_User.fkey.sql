-- Creating foreign key on [Members_ID] in table 'GroupMembers'
-- Creating foreign key on [Members_ID] in table 'GroupMembers'
-- Creating foreign key on [Members_ID] in table 'GroupMembers'
-- Creating foreign key on [Members_ID] in table 'GroupMembers'
ALTER TABLE [dbo].[GroupMembers]
ADD CONSTRAINT [FK_GroupMembers_User]
    FOREIGN KEY ([Members_ID])
    REFERENCES [dbo].[User]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;











