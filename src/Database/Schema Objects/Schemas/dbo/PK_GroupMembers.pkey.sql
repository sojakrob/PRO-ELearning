-- Creating primary key on [Groups_ID], [Members_ID] in table 'GroupMembers'
-- Creating primary key on [Groups_ID], [Members_ID] in table 'GroupMembers'
ALTER TABLE [dbo].[GroupMembers]
ADD CONSTRAINT [PK_GroupMembers]
    PRIMARY KEY NONCLUSTERED ([Groups_ID], [Members_ID] ASC);





