CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

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
VALUES ('20190727120133_Initial', '5.0.9');

COMMIT;

START TRANSACTION;

ALTER TABLE "SystemReports" ADD "SystemReportStatus" integer NOT NULL DEFAULT 0;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20190905230943_SystemReportStatus', '5.0.9');

COMMIT;

START TRANSACTION;

ALTER TABLE "SystemReports" ADD "Active" boolean NOT NULL DEFAULT FALSE;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20190905231018_ActiveIndicator', '5.0.9');

COMMIT;

START TRANSACTION;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20191012003215_SrictDateDataTypes', '5.0.9');

COMMIT;

START TRANSACTION;

CREATE TABLE "SystemStatus" (
    "Id" serial NOT NULL,
    "Status" text NULL,
    CONSTRAINT "PK_SystemStatus" PRIMARY KEY ("Id")
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20191012184428_SystemStatus', '5.0.9');

COMMIT;

START TRANSACTION;

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
VALUES ('20191013190003_SystemName', '5.0.9');

COMMIT;

START TRANSACTION;

ALTER TABLE "SystemName" DROP CONSTRAINT "FK_SystemName_SystemReports_SystemReportId";

ALTER TABLE "SystemStatus" DROP CONSTRAINT "FK_SystemStatus_SystemReports_SystemReportId";

DROP INDEX "IX_SystemStatus_SystemReportId";

DROP INDEX "IX_SystemName_SystemReportId";

ALTER TABLE "SystemStatus" DROP COLUMN "SystemReportId";

ALTER TABLE "SystemName" DROP COLUMN "SystemReportId";

ALTER TABLE "SystemReports" ADD "SystemNameId" integer NULL;

ALTER TABLE "SystemReports" ADD "SystemReportStatusId" integer NULL;

CREATE INDEX "IX_SystemReports_SystemNameId" ON "SystemReports" ("SystemNameId");

CREATE INDEX "IX_SystemReports_SystemReportStatusId" ON "SystemReports" ("SystemReportStatusId");

ALTER TABLE "SystemReports" ADD CONSTRAINT "FK_SystemReports_SystemName_SystemNameId" FOREIGN KEY ("SystemNameId") REFERENCES "SystemName" ("Id") ON DELETE RESTRICT;

ALTER TABLE "SystemReports" ADD CONSTRAINT "FK_SystemReports_SystemStatus_SystemReportStatusId" FOREIGN KEY ("SystemReportStatusId") REFERENCES "SystemStatus" ("Id") ON DELETE RESTRICT;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20191013202414_UpdatedSystemReportFK', '5.0.9');

COMMIT;

START TRANSACTION;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20191013203000_UpdatedStatusModelFK', '5.0.9');

COMMIT;

START TRANSACTION;

ALTER TABLE "SystemReports" DROP CONSTRAINT "FK_SystemReports_SystemName_SystemNameId";

ALTER TABLE "SystemReports" DROP CONSTRAINT "FK_SystemReports_SystemStatus_SystemReportStatusId";

ALTER TABLE "SystemReports" ALTER COLUMN "SystemReportStatusId" SET NOT NULL;

ALTER TABLE "SystemReports" ALTER COLUMN "SystemNameId" SET NOT NULL;

ALTER TABLE "SystemReports" ADD CONSTRAINT "FK_SystemReports_SystemName_SystemNameId" FOREIGN KEY ("SystemNameId") REFERENCES "SystemName" ("Id") ON DELETE CASCADE;

ALTER TABLE "SystemReports" ADD CONSTRAINT "FK_SystemReports_SystemStatus_SystemReportStatusId" FOREIGN KEY ("SystemReportStatusId") REFERENCES "SystemStatus" ("Id") ON DELETE CASCADE;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20191013204551_UpdatedSystemReportFKs', '5.0.9');

COMMIT;

START TRANSACTION;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20191109000620_IdGenerationSystemStatusSystemName', '5.0.9');

COMMIT;

START TRANSACTION;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20191111124501_AddedForeignKeys', '5.0.9');

COMMIT;

START TRANSACTION;

ALTER TABLE "SystemReports" DROP COLUMN "Name";

ALTER TABLE "SystemReports" ADD "ReportName" text NULL;

ALTER TABLE "SystemReports" ADD "ReporterName" text NULL;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20191130141410_ReporterName', '5.0.9');

COMMIT;

START TRANSACTION;

CREATE TABLE "Users" (
    id integer GENERATED BY DEFAULT AS IDENTITY,
    "firstName" text NULL,
    "lastName" text NULL,
    username text NULL,
    "passwordHash" bytea NULL,
    "passwordSalt" bytea NULL,
    CONSTRAINT "PK_Users" PRIMARY KEY (id)
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20200207232058_AuthenticationAPI', '5.0.9');

COMMIT;

START TRANSACTION;

ALTER TABLE "Users" ADD "emailAddress" text NULL;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20200208161641_userEmailAddress', '5.0.9');

COMMIT;

START TRANSACTION;

ALTER TABLE "SystemReports" DROP CONSTRAINT "FK_SystemReports_SystemStatus_SystemReportStatusId";

DROP TABLE "SystemStatus";

DROP TABLE "Users";

CREATE TABLE "SystemReportStatus" (
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    "Status" text NULL,
    CONSTRAINT "PK_SystemReportStatus" PRIMARY KEY ("Id")
);

ALTER TABLE "SystemReports" ADD CONSTRAINT "FK_SystemReports_SystemReportStatus_SystemReportStatusId" FOREIGN KEY ("SystemReportStatusId") REFERENCES "SystemReportStatus" ("Id") ON DELETE CASCADE;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20210814163343_ChangedSystemStatustoSystemReportStatus', '5.0.9');

COMMIT;