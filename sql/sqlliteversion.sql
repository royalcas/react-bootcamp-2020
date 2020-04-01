CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

CREATE TABLE "Medications" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_Medications" PRIMARY KEY,
    "Type" INTEGER NOT NULL,
    "Name" TEXT NOT NULL
);

CREATE TABLE "Users" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_Users" PRIMARY KEY,
    "FirstName" TEXT NOT NULL,
    "LastName" TEXT NOT NULL,
    "Email" TEXT NOT NULL,
    "AvatarUrl" TEXT NOT NULL,
    "BirthDate" TEXT NOT NULL,
    "Gender" INTEGER NOT NULL
);

CREATE TABLE "MedicalRecords" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_MedicalRecords" PRIMARY KEY,
    "Date" TEXT NOT NULL,
    "Details" TEXT NOT NULL,
    "Treatment" TEXT NOT NULL,
    "UserId" TEXT NOT NULL,
    CONSTRAINT "FK_MedicalRecords_Users_UserId" FOREIGN KEY ("UserId") REFERENCES "Users" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Prescriptions" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_Prescriptions" PRIMARY KEY,
    "Quantity" REAL NOT NULL,
    "MedicationId" TEXT NOT NULL,
    "MedicalRecordItemId" TEXT NOT NULL,
    CONSTRAINT "FK_Prescriptions_MedicalRecords_MedicalRecordItemId" FOREIGN KEY ("MedicalRecordItemId") REFERENCES "MedicalRecords" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_Prescriptions_Medications_MedicationId" FOREIGN KEY ("MedicationId") REFERENCES "Medications" ("Id") ON DELETE CASCADE
);

CREATE INDEX "IX_MedicalRecords_UserId" ON "MedicalRecords" ("UserId");

CREATE INDEX "IX_Prescriptions_MedicalRecordItemId" ON "Prescriptions" ("MedicalRecordItemId");

CREATE INDEX "IX_Prescriptions_MedicationId" ON "Prescriptions" ("MedicationId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20200328235649_BaseRelationshipModel', '3.1.3');

CREATE TABLE "HealthRisks" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_HealthRisks" PRIMARY KEY,
    "Name" TEXT NOT NULL
);

CREATE TABLE "PreventionActivityTopics" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_PreventionActivityTopics" PRIMARY KEY,
    "Name" TEXT NOT NULL,
    "Benefits" TEXT NOT NULL,
    "Considerations" TEXT NOT NULL
);

CREATE TABLE "Tips" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_Tips" PRIMARY KEY,
    "Title" TEXT NULL,
    "Description" TEXT NULL
);

CREATE TABLE "UserIdentifiedRisks" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_UserIdentifiedRisks" PRIMARY KEY,
    "RiskId" TEXT NULL,
    "UserId" TEXT NULL,
    CONSTRAINT "FK_UserIdentifiedRisks_HealthRisks_RiskId" FOREIGN KEY ("RiskId") REFERENCES "HealthRisks" ("Id") ON DELETE RESTRICT,
    CONSTRAINT "FK_UserIdentifiedRisks_Users_UserId" FOREIGN KEY ("UserId") REFERENCES "Users" ("Id") ON DELETE RESTRICT
);

CREATE TABLE "ActivitySuggestionsByRisk" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_ActivitySuggestionsByRisk" PRIMARY KEY,
    "RiskId" TEXT NOT NULL,
    "ActivityTopicId" TEXT NOT NULL,
    CONSTRAINT "FK_ActivitySuggestionsByRisk_PreventionActivityTopics_ActivityTopicId" FOREIGN KEY ("ActivityTopicId") REFERENCES "PreventionActivityTopics" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_ActivitySuggestionsByRisk_HealthRisks_RiskId" FOREIGN KEY ("RiskId") REFERENCES "HealthRisks" ("Id") ON DELETE CASCADE
);

CREATE TABLE "UserActivitySubscriptions" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_UserActivitySubscriptions" PRIMARY KEY,
    "UserId" TEXT NOT NULL,
    "ActivityTopicId" TEXT NOT NULL,
    CONSTRAINT "FK_UserActivitySubscriptions_PreventionActivityTopics_ActivityTopicId" FOREIGN KEY ("ActivityTopicId") REFERENCES "PreventionActivityTopics" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_UserActivitySubscriptions_Users_UserId" FOREIGN KEY ("UserId") REFERENCES "Users" ("Id") ON DELETE CASCADE
);

CREATE INDEX "IX_ActivitySuggestionsByRisk_ActivityTopicId" ON "ActivitySuggestionsByRisk" ("ActivityTopicId");

CREATE INDEX "IX_ActivitySuggestionsByRisk_RiskId" ON "ActivitySuggestionsByRisk" ("RiskId");

CREATE INDEX "IX_UserActivitySubscriptions_ActivityTopicId" ON "UserActivitySubscriptions" ("ActivityTopicId");

CREATE INDEX "IX_UserActivitySubscriptions_UserId" ON "UserActivitySubscriptions" ("UserId");

CREATE INDEX "IX_UserIdentifiedRisks_RiskId" ON "UserIdentifiedRisks" ("RiskId");

CREATE INDEX "IX_UserIdentifiedRisks_UserId" ON "UserIdentifiedRisks" ("UserId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20200401021952_AddSuggestionSchemas', '3.1.3');

