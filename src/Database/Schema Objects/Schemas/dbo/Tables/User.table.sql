-- Creating table 'User'
-- Creating table 'User'
CREATE TABLE [dbo].[User] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [UserTypeID] int  NOT NULL,
    [Password] char(32)  NULL,
    [IsActive] bit  NOT NULL,
    [FillingForm] int  NULL
);





