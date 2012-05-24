-- Creating primary key on [Forms_ID], [Groups_ID] in table 'FormGroup'
-- Creating primary key on [Forms_ID], [Groups_ID] in table 'FormGroup'
ALTER TABLE [dbo].[FormGroup]
ADD CONSTRAINT [PK_FormGroup]
    PRIMARY KEY NONCLUSTERED ([Forms_ID], [Groups_ID] ASC);





