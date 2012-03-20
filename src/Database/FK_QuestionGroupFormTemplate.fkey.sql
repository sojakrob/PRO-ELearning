-- Creating foreign key on [FormTemplateID] in table 'QuestionGroup'
-- Creating foreign key on [FormTemplateID] in table 'QuestionGroup'
-- Creating foreign key on [FormTemplateID] in table 'QuestionGroup'
-- Creating foreign key on [FormTemplateID] in table 'QuestionGroup'
ALTER TABLE [dbo].[QuestionGroup]
ADD CONSTRAINT [FK_QuestionGroupFormTemplate]
    FOREIGN KEY ([FormTemplateID])
    REFERENCES [dbo].[Form]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;











