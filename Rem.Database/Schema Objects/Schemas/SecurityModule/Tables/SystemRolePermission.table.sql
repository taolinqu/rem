﻿CREATE TABLE [SecurityModule].[SystemRolePermission] (
    [SystemRolePermissionKey]   BIGINT             NOT NULL,
    [Version]                   INT                NOT NULL,
    [CreatedTimestamp]          DATETIMEOFFSET (7) NOT NULL,
    [UpdatedTimestamp]          DATETIMEOFFSET (7) NOT NULL,
    [SystemRoleKey]             BIGINT             NOT NULL,
    [SystemPermissionKey]       BIGINT             NOT NULL,
    [CreatedBySystemAccountKey] BIGINT             NOT NULL,
    [UpdatedBySystemAccountKey] BIGINT             NOT NULL,
    PRIMARY KEY CLUSTERED ([SystemRolePermissionKey] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);





