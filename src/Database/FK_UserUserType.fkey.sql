-- Creating foreign key on [UserTypeID] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [FK_UserUserType]
    FOREIGN KEY ([UserTypeID])
    REFERENCES [dbo].[UserType]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;


