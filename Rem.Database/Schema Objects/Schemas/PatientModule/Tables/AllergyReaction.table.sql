﻿CREATE TABLE [PatientModule].[AllergyReaction] (
    [AllergyReactionKey]        BIGINT             NOT NULL,
    [Version]                   INT                NOT NULL,
    [CreatedTimestamp]          DATETIMEOFFSET (7) NOT NULL,
    [UpdatedTimestamp]          DATETIMEOFFSET (7) NOT NULL,
    [AllergyKey]                BIGINT             NOT NULL,
    [ReactionLkpKey]            BIGINT             NOT NULL,
    [CreatedBySystemAccountKey] BIGINT             NOT NULL,
    [UpdatedBySystemAccountKey] BIGINT             NOT NULL,
    PRIMARY KEY CLUSTERED ([AllergyReactionKey] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);









