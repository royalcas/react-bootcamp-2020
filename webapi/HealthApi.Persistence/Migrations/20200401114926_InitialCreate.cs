using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthApi.Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HealthRisks",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthRisks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medications",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PreventionActivityTopics",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Benefits = table.Column<string>(maxLength: 256, nullable: false),
                    Considerations = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreventionActivityTopics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tips",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tips", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 256, nullable: false),
                    LastName = table.Column<string>(maxLength: 256, nullable: false),
                    Email = table.Column<string>(maxLength: 256, nullable: false),
                    AvatarUrl = table.Column<string>(maxLength: 256, nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActivitySuggestionsByRisk",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    RiskId = table.Column<string>(nullable: false),
                    ActivityTopicId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivitySuggestionsByRisk", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivitySuggestionsByRisk_PreventionActivityTopics_ActivityTopicId",
                        column: x => x.ActivityTopicId,
                        principalTable: "PreventionActivityTopics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivitySuggestionsByRisk_HealthRisks_RiskId",
                        column: x => x.RiskId,
                        principalTable: "HealthRisks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalRecords",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Details = table.Column<string>(nullable: false),
                    Treatment = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalRecords_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserActivitySubscriptions",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    ActivityTopicId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserActivitySubscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserActivitySubscriptions_PreventionActivityTopics_ActivityTopicId",
                        column: x => x.ActivityTopicId,
                        principalTable: "PreventionActivityTopics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserActivitySubscriptions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserIdentifiedRisks",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    RiskId = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserIdentifiedRisks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserIdentifiedRisks_HealthRisks_RiskId",
                        column: x => x.RiskId,
                        principalTable: "HealthRisks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserIdentifiedRisks_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Quantity = table.Column<float>(nullable: false),
                    MedicationId = table.Column<string>(nullable: false),
                    MedicalRecordItemId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prescriptions_MedicalRecords_MedicalRecordItemId",
                        column: x => x.MedicalRecordItemId,
                        principalTable: "MedicalRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prescriptions_Medications_MedicationId",
                        column: x => x.MedicationId,
                        principalTable: "Medications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivitySuggestionsByRisk_ActivityTopicId",
                table: "ActivitySuggestionsByRisk",
                column: "ActivityTopicId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivitySuggestionsByRisk_RiskId",
                table: "ActivitySuggestionsByRisk",
                column: "RiskId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_UserId",
                table: "MedicalRecords",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_MedicalRecordItemId",
                table: "Prescriptions",
                column: "MedicalRecordItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_MedicationId",
                table: "Prescriptions",
                column: "MedicationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserActivitySubscriptions_ActivityTopicId",
                table: "UserActivitySubscriptions",
                column: "ActivityTopicId");

            migrationBuilder.CreateIndex(
                name: "IX_UserActivitySubscriptions_UserId",
                table: "UserActivitySubscriptions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserIdentifiedRisks_RiskId",
                table: "UserIdentifiedRisks",
                column: "RiskId");

            migrationBuilder.CreateIndex(
                name: "IX_UserIdentifiedRisks_UserId",
                table: "UserIdentifiedRisks",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivitySuggestionsByRisk");

            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropTable(
                name: "Tips");

            migrationBuilder.DropTable(
                name: "UserActivitySubscriptions");

            migrationBuilder.DropTable(
                name: "UserIdentifiedRisks");

            migrationBuilder.DropTable(
                name: "MedicalRecords");

            migrationBuilder.DropTable(
                name: "Medications");

            migrationBuilder.DropTable(
                name: "PreventionActivityTopics");

            migrationBuilder.DropTable(
                name: "HealthRisks");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
