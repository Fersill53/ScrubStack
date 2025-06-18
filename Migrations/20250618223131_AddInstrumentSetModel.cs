using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScrubStack.Migrations
{
    /// <inheritdoc />
    public partial class AddInstrumentSetModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PreferenceCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SurgeonName = table.Column<string>(type: "TEXT", nullable: true),
                    ProcedureName = table.Column<string>(type: "TEXT", nullable: true),
                    Instruments = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreferenceCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InstrumentSets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SetName = table.Column<string>(type: "TEXT", nullable: false),
                    PreferenceCardId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstrumentSets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstrumentSets_PreferenceCards_PreferenceCardId",
                        column: x => x.PreferenceCardId,
                        principalTable: "PreferenceCards",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Instrument",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    InstrumentSetId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instrument", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instrument_InstrumentSets_InstrumentSetId",
                        column: x => x.InstrumentSetId,
                        principalTable: "InstrumentSets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Instrument_InstrumentSetId",
                table: "Instrument",
                column: "InstrumentSetId");

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentSets_PreferenceCardId",
                table: "InstrumentSets",
                column: "PreferenceCardId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Instrument");

            migrationBuilder.DropTable(
                name: "InstrumentSets");

            migrationBuilder.DropTable(
                name: "PreferenceCards");
        }
    }
}
