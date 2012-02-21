-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [QuestionGroupID] in table 'Question'
-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [QuestionGroupID] in table 'Question'
ALTER TABLE [dbo].[Question]
ADD CONSTRAINT [FK_QuestionGroupQuestion]
    FOREIGN KEY ([QuestionGroupID])
    REFERENCES [dbo].[QuestionGroup]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;





