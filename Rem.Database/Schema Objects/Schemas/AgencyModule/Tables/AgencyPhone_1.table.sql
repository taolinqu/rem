﻿CREATE TABLE [AgencyModule].[AgencyPhone] (
    [AgencyPhoneKey]            BIGINT             NOT NULL,
    [Version]                   INT                NOT NULL,
    [CreatedTimestamp]          DATETIMEOFFSET (7) NOT NULL,
    [UpdatedTimestamp]          DATETIMEOFFSET (7) NOT NULL,
    [AgencyAddressAndPhoneKey]  BIGINT             NOT NULL,
    [AgencyPhoneTypeLkpKey]     BIGINT             NOT NULL,
    [CreatedBySystemAccountKey] BIGINT             NOT NULL,
    [UpdatedBySystemAccountKey] BIGINT             NOT NULL,
    [PhoneNumber]               NVARCHAR (20)      NOT NULL,
    [PhoneExtensionNumber]      NVARCHAR (20)      NULL,
    PRIMARY KEY CLUSTERED ([AgencyPhoneKey] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);



