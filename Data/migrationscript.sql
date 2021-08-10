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
VALUES ('20190727120133_Initial', '3.0.0');

ALTER TABLE "SystemReports" ADD "SystemReportStatus" integer NOT NULL DEFAULT 0;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20190905230943_SystemReportStatus', '3.0.0');

ALTER TABLE "SystemReports" ADD "Active" boolean NOT NULL DEFAULT FALSE;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20190905231018_ActiveIndicator', '3.0.0');

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20191012003215_SrictDateDataTypes', '3.0.0');

CREATE TABLE "SystemStatus" (
    "Id" serial NOT NULL,
    "Status" text NULL,
    CONSTRAINT "PK_SystemStatus" PRIMARY KEY ("Id")
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20191012184428_SystemStatus', '3.0.0');

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
VALUES ('20191013190003_SystemName', '3.0.0');

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
VALUES ('20191013202414_UpdatedSystemReportFK', '3.0.0');

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20191013203000_UpdatedStatusModelFK', '3.0.0');

ALTER TABLE "SystemReports" DROP CONSTRAINT "FK_SystemReports_SystemName_SystemNameId";

ALTER TABLE "SystemReports" DROP CONSTRAINT "FK_SystemReports_SystemStatus_SystemReportStatusId";

ALTER TABLE "SystemReports" ALTER COLUMN "SystemReportStatusId" TYPE integer;
ALTER TABLE "SystemReports" ALTER COLUMN "SystemReportStatusId" SET NOT NULL;
ALTER TABLE "SystemReports" ALTER COLUMN "SystemReportStatusId" DROP DEFAULT;

ALTER TABLE "SystemReports" ALTER COLUMN "SystemNameId" TYPE integer;
ALTER TABLE "SystemReports" ALTER COLUMN "SystemNameId" SET NOT NULL;
ALTER TABLE "SystemReports" ALTER COLUMN "SystemNameId" DROP DEFAULT;

ALTER TABLE "SystemReports" ADD CONSTRAINT "FK_SystemReports_SystemName_SystemNameId" FOREIGN KEY ("SystemNameId") REFERENCES "SystemName" ("Id") ON DELETE CASCADE;

ALTER TABLE "SystemReports" ADD CONSTRAINT "FK_SystemReports_SystemStatus_SystemReportStatusId" FOREIGN KEY ("SystemReportStatusId") REFERENCES "SystemStatus" ("Id") ON DELETE CASCADE;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20191013204551_UpdatedSystemReportFKs', '3.0.0');

ALTER TABLE "SystemStatus" ALTER COLUMN "Id" TYPE integer;
ALTER TABLE "SystemStatus" ALTER COLUMN "Id" SET NOT NULL;
ALTER SEQUENCE "SystemStatus_Id_seq" RENAME TO "SystemStatus_Id_old_seq";
ALTER TABLE "SystemStatus" ALTER COLUMN "Id" DROP DEFAULT;
ALTER TABLE "SystemStatus" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY;
SELECT * FROM setval('"SystemStatus_Id_seq"', nextval('"SystemStatus_Id_old_seq"'), false);
DROP SEQUENCE "SystemStatus_Id_old_seq";

ALTER TABLE "SystemReports" ALTER COLUMN "Id" TYPE integer;
ALTER TABLE "SystemReports" ALTER COLUMN "Id" SET NOT NULL;
ALTER SEQUENCE "SystemReports_Id_seq" RENAME TO "SystemReports_Id_old_seq";
ALTER TABLE "SystemReports" ALTER COLUMN "Id" DROP DEFAULT;
ALTER TABLE "SystemReports" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY;
SELECT * FROM setval('"SystemReports_Id_seq"', nextval('"SystemReports_Id_old_seq"'), false);
DROP SEQUENCE "SystemReports_Id_old_seq";

ALTER TABLE "SystemName" ALTER COLUMN "Id" TYPE integer;
ALTER TABLE "SystemName" ALTER COLUMN "Id" SET NOT NULL;
ALTER SEQUENCE "SystemName_Id_seq" RENAME TO "SystemName_Id_old_seq";
ALTER TABLE "SystemName" ALTER COLUMN "Id" DROP DEFAULT;
ALTER TABLE "SystemName" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY;
SELECT * FROM setval('"SystemName_Id_seq"', nextval('"SystemName_Id_old_seq"'), false);
DROP SEQUENCE "SystemName_Id_old_seq";

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20191108234648_SystemReportIdGeneration', '3.0.0');

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20191109000620_IdGenerationSystemStatusSystemName', '3.0.0');

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20191111124501_AddedForeignKeys', '3.0.0');

ALTER TABLE "SystemReports" DROP COLUMN "Name";

ALTER TABLE "SystemReports" ADD "ReportName" text NULL;

ALTER TABLE "SystemReports" ADD "ReporterName" text NULL;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20191130141410_ReporterName', '3.0.0');