﻿CREATE TABLE [TedsModule].[TedsAdmissionBatch] (
    [TedsAdmissionBatchKey]     BIGINT             NOT NULL,
    [Version]                   INT                NOT NULL,
    [SubmissionDocument]        VARBINARY (MAX)    NULL,
    [CreatedTimestamp]          DATETIMEOFFSET (7) NOT NULL,
    [UpdatedTimestamp]          DATETIMEOFFSET (7) NOT NULL,
    [TedsBatchKey]              BIGINT             NULL,
    [CreatedBySystemAccountKey] BIGINT             NOT NULL,
    [UpdatedBySystemAccountKey] BIGINT             NOT NULL,
    PRIMARY KEY CLUSTERED ([TedsAdmissionBatchKey] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);

