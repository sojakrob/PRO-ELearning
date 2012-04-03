-- Creating table 'FormInstance'
CREATE TABLE [dbo].[FormInstance] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Created] datetime  NOT NULL,
    [Submited] datetime  NOT NULL,
    [SolverID] int  NOT NULL,
    [FormTemplateID] int  NOT NULL,
    [EvaluationID] int  NULL,
    [IsPreview] bit  NOT NULL,
    [UserFillingFormInstance_FormInstance_ID] int  NULL
);


