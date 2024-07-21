using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PZBot.Migrations
{
    /// <inheritdoc />
    public partial class Variables_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Channel",
                table: "ChannelCommands");

            migrationBuilder.AlterColumn<string>(
                name: "ChannelId",
                table: "Channels",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ChannelId",
                table: "ChannelCommands",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Channels_ChannelId",
                table: "Channels",
                column: "ChannelId");

            migrationBuilder.CreateTable(
                name: "CommandVariables",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChannelId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommandId = table.Column<int>(type: "int", nullable: false),
                    Group = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Parent = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommandVariables", x => x.id);
                    table.ForeignKey(
                        name: "FK_CommandVariables_ChannelCommands_CommandId",
                        column: x => x.CommandId,
                        principalTable: "ChannelCommands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChannelCommands_ChannelId",
                table: "ChannelCommands",
                column: "ChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_CommandVariables_CommandId",
                table: "CommandVariables",
                column: "CommandId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChannelCommands_Channels_ChannelId",
                table: "ChannelCommands",
                column: "ChannelId",
                principalTable: "Channels",
                principalColumn: "ChannelId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChannelCommands_Channels_ChannelId",
                table: "ChannelCommands");

            migrationBuilder.DropTable(
                name: "CommandVariables");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Channels_ChannelId",
                table: "Channels");

            migrationBuilder.DropIndex(
                name: "IX_ChannelCommands_ChannelId",
                table: "ChannelCommands");

            migrationBuilder.AlterColumn<string>(
                name: "ChannelId",
                table: "Channels",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "ChannelId",
                table: "ChannelCommands",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "Channel",
                table: "ChannelCommands",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
