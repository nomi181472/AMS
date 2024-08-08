using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DA.Migrations
{
    /// <inheritdoc />
    public partial class ShiftWorkingProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeOnly>(
                name: "TimeOut",
                table: "Shifts",
                type: "time without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "TimeIn",
                table: "Shifts",
                type: "time without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "shiftWorkingProfiles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ShiftId = table.Column<string>(type: "text", nullable: true),
                    WorkingProfileId = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shiftWorkingProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_shiftWorkingProfiles_Shifts_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Shifts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_shiftWorkingProfiles_WorkingProfiles_WorkingProfileId",
                        column: x => x.WorkingProfileId,
                        principalTable: "WorkingProfiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_shiftWorkingProfiles_ShiftId",
                table: "shiftWorkingProfiles",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_shiftWorkingProfiles_WorkingProfileId",
                table: "shiftWorkingProfiles",
                column: "WorkingProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "shiftWorkingProfiles");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeOut",
                table: "Shifts",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(TimeOnly),
                oldType: "time without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeIn",
                table: "Shifts",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(TimeOnly),
                oldType: "time without time zone",
                oldNullable: true);
        }
    }
}
