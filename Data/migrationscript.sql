CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

CREATE TABLE "SystemReports" (
    "Id" serial NOT NULL,
    "Name" text NULL,
    "ReportDate" timestamp without time zone NOT NULL,
    "CreatedDate" timestamp without time zone NOT NULL,
    "UpdatedDate" timestamp without time zone NOT NULL,
    "SystemName" integer NOT NULL,
    "SystemUpdate" text NULL,
    "PersonnelUpdates" text NULL,
    "CreativeIdeasAndEvaluations" text NULL,
    "BarriersOrChallenges" text NULL,
    "HowCanIHelpYou" text NULL,
    "PersonalGrowthAndDevelopment" text NULL,
    CONSTRAINT "PK_SystemReports" PRIMARY KEY ("Id")
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20190727120133_Initial', '2.2.6-servicing-10079');

ALTER TABLE "SystemReports" ADD "SystemReportStatus" integer NOT NULL DEFAULT 0;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20190905230943_SystemReportStatus', '2.2.6-servicing-10079');

ALTER TABLE "SystemReports" ADD "Active" boolean NOT NULL DEFAULT FALSE;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20190905231018_ActiveIndicator', '2.2.6-servicing-10079');

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20191012003215_SrictDateDataTypes', '2.2.6-servicing-10079');

CREATE TABLE "SystemStatus" (
    "Id" serial NOT NULL,
    "Status" text NULL,
    CONSTRAINT "PK_SystemStatus" PRIMARY KEY ("Id")
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20191012184428_SystemStatus', '2.2.6-servicing-10079');

ALTER TABLE "SystemReports" DROP COLUMN "SystemName";

ALTER TABLE "SystemReports" DROP COLUMN "SystemReportStatus";

ALTER TABLE "SystemStatus" ADD "SystemReportId" integer NULL;

CREATE TABLE "SystemName" (
    "Id" serial NOT NULL,
    "Name" text NULL,
    "SystemReportId" integer NULL,
    CONSTRAINT "PK_SystemName" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_SystemName_SystemReports_SystemReportId" FOREIGN KEY ("SystemReportId") REFERENCES "SystemReports" ("Id") ON DELETE RESTRICT
);

CREATE INDEX "IX_SystemStatus_SystemReportId" ON "SystemStatus" ("SystemReportId");

CREATE INDEX "IX_SystemName_SystemReportId" ON "SystemName" ("SystemReportId");

ALTER TABLE "SystemStatus" ADD CONSTRAINT "FK_SystemStatus_SystemReports_SystemReportId" FOREIGN KEY ("SystemReportId") REFERENCES "SystemReports" ("Id") ON DELETE RESTRICT;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20191013190003_SystemName', '2.2.6-servicing-10079');
