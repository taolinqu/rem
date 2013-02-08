﻿CREATE TABLE [VisitModule].[HeartRate] (
    [HeartRateKey]              BIGINT             NOT NULL,
    [Version]                   INT                NOT NULL,
    [BeatsPerMinuteMeasure]     INT                NOT NULL,
    [EffectiveTimestamp]        DATETIMEOFFSET (7) NOT NULL,
    [CreatedTimestamp]          DATETIMEOFFSET (7) NOT NULL,
    [UpdatedTimestamp]          DATETIMEOFFSET (7) NOT NULL,
    [VitalSignKey]              BIGINT             NOT NULL,
    [CreatedBySystemAccountKey] BIGINT             NOT NULL,
    [UpdatedBySystemAccountKey] BIGINT             NOT NULL,
    PRIMARY KEY CLUSTERED ([HeartRateKey] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);












