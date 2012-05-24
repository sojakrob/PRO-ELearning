-- Creating primary key on [TextBooks_ID], [Groups_ID] in table 'TextBookGroup'
-- Creating primary key on [TextBooks_ID], [Groups_ID] in table 'TextBookGroup'
ALTER TABLE [dbo].[TextBookGroup]
ADD CONSTRAINT [PK_TextBookGroup]
    PRIMARY KEY NONCLUSTERED ([TextBooks_ID], [Groups_ID] ASC);





