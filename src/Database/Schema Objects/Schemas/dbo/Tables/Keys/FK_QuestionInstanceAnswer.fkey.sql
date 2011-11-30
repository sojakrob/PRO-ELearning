-- Creating foreign key on [QuestionInstanceAnswer_Answer_ID] in table 'Answer'
ALTER TABLE [dbo].[Answer]
ADD CONSTRAINT [FK_QuestionInstanceAnswer]
    FOREIGN KEY ([QuestionInstanceAnswer_Answer_ID])
    REFERENCES [dbo].[QuestionInstance]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;


