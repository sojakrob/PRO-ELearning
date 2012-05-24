-- Creating foreign key on [MarkValueID] in table 'FormInstanceEvaluation'
-- Creating foreign key on [MarkValueID] in table 'FormInstanceEvaluation'
ALTER TABLE [dbo].[FormInstanceEvaluation]
ADD CONSTRAINT [FK_FormInstanceEvaluationMarkValue]
    FOREIGN KEY ([MarkValueID])
    REFERENCES [dbo].[MarkValue]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;





