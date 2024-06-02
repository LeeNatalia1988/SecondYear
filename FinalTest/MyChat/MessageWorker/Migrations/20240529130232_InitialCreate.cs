using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MessageWorker.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MessageStatus",
                columns: table => new
                {
                    MessageStatusID = table.Column<int>(type: "integer", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageStatus", x => x.MessageStatusID);
                });

            migrationBuilder.CreateTable(
                name: "messages",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    text = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    from_user = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    to_user = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    StatusID = table.Column<int>(type: "integer", nullable: false),
                    MessageStatusID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("messages_pkey", x => x.id);
                    table.ForeignKey(
                        name: "FK_messages_MessageStatus_MessageStatusID",
                        column: x => x.MessageStatusID,
                        principalTable: "MessageStatus",
                        principalColumn: "MessageStatusID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MessageStatus",
                columns: new[] { "MessageStatusID", "Text" },
                values: new object[,]
                {
                    { 0, "Create" },
                    { 1, "Receive" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_messages_id",
                table: "messages",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_messages_MessageStatusID",
                table: "messages",
                column: "MessageStatusID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "messages");

            migrationBuilder.DropTable(
                name: "MessageStatus");
        }
    }
}
