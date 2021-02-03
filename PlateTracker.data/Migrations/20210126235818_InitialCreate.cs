using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PlateTracker.data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeFirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    EmployeeLastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    BuddyPunchID = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false, defaultValueSql: "('SYSTEM')"),
                    DatetimeCreated = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeID);
                });

            migrationBuilder.CreateTable(
                name: "LineType",
                columns: table => new
                {
                    LineTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LineTypeName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    LineTypeDescription = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    DatetimeCreated = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    DatetimeUpdated = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false, defaultValueSql: "('SYSTEM')"),
                    UpdatedBy = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false, defaultValueSql: "('SYSTEM')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineType", x => x.LineTypeID);
                });

            migrationBuilder.CreateTable(
                name: "TankMeasurementType",
                columns: table => new
                {
                    TankMeasurementTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TankMeasurementTypeName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    TankMeasurementTypeDescription = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    DatetimeCreated = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    DatetimeUpdated = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false, defaultValueSql: "('SYSTEM')"),
                    UpdatedBy = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false, defaultValueSql: "('SYSTEM')"),
                    UOM = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TankMeasurementType", x => x.TankMeasurementTypeID);
                });

            migrationBuilder.CreateTable(
                name: "TankType",
                columns: table => new
                {
                    TankTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TankTypeName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    TankTypeDescription = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    LineTypeID = table.Column<int>(type: "int", nullable: false),
                    DatetimeCreated = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    DatetimeUpdated = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false, defaultValueSql: "('SYSTEM')"),
                    UpdatedBy = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false, defaultValueSql: "('SYSTEM')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TankType", x => x.TankTypeID);
                    table.ForeignKey(
                        name: "FK_TankType_LineType",
                        column: x => x.LineTypeID,
                        principalTable: "LineType",
                        principalColumn: "LineTypeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TankMeasurement",
                columns: table => new
                {
                    TankMeasurementID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TankMeasurementTypeID = table.Column<int>(type: "int", nullable: false),
                    TankTypeID = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Notes = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    TankMeasurementEmployeeID = table.Column<int>(type: "int", nullable: false),
                    TankMeasurementDatetime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    DatetimeCreated = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    DatetimeUpdated = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false, defaultValueSql: "('SYSTEM')"),
                    UpdatedBy = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false, defaultValueSql: "('SYSTEM')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TankMeasurement", x => x.TankMeasurementID);
                    table.ForeignKey(
                        name: "FK_TankMeasurement_Employee",
                        column: x => x.TankMeasurementEmployeeID,
                        principalTable: "Employee",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TankMeasurement_TankType",
                        column: x => x.TankTypeID,
                        principalTable: "TankType",
                        principalColumn: "TankTypeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TankMeasurement_TankMeasurementType",
                        column: x => x.TankMeasurementTypeID,
                        principalTable: "TankMeasurementType",
                        principalColumn: "TankMeasurementTypeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TankMeasurementNominal",
                columns: table => new
                {
                    TankMeasurementNominalID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TankTypeID = table.Column<int>(type: "int", nullable: false),
                    TankMeasurementTypeID = table.Column<int>(type: "int", nullable: false),
                    LowNominalValue = table.Column<int>(type: "int", nullable: false),
                    IdealNominalValue = table.Column<int>(type: "int", nullable: false),
                    HighNominalValue = table.Column<int>(type: "int", nullable: false),
                    MinimumTestingFrequencyDays = table.Column<int>(type: "int", nullable: false),
                    IdealTestingFrequencyDays = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false, defaultValueSql: "('SYSTEM')"),
                    DatetimeCreated = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdatedBy = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false, defaultValueSql: "('SYSTEM')"),
                    DatetimeUpdated = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TankMeasurementNominal", x => x.TankMeasurementNominalID);
                    table.ForeignKey(
                        name: "FK_TankMeasurementNominal_TankMeasurementNominal",
                        column: x => x.TankTypeID,
                        principalTable: "TankType",
                        principalColumn: "TankTypeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TankMeasurementNominal_TankMeasurementType",
                        column: x => x.TankMeasurementTypeID,
                        principalTable: "TankMeasurementType",
                        principalColumn: "TankMeasurementTypeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TankMeasurement_TankMeasurementEmployeeID",
                table: "TankMeasurement",
                column: "TankMeasurementEmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_TankMeasurement_TankTypeID",
                table: "TankMeasurement",
                column: "TankTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_TankMeasurement_TankMeasurementTypeID",
                table: "TankMeasurement",
                column: "TankMeasurementTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_TankMeasurementNominal_TankMeasurementTypeID",
                table: "TankMeasurementNominal",
                column: "TankMeasurementTypeID");

            migrationBuilder.CreateIndex(
                name: "uq_TankMeasurementNominal",
                table: "TankMeasurementNominal",
                columns: new[] { "TankTypeID", "TankMeasurementTypeID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TankType_LineTypeID",
                table: "TankType",
                column: "LineTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TankMeasurement");

            migrationBuilder.DropTable(
                name: "TankMeasurementNominal");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "TankType");

            migrationBuilder.DropTable(
                name: "TankMeasurementType");

            migrationBuilder.DropTable(
                name: "LineType");
        }
    }
}
