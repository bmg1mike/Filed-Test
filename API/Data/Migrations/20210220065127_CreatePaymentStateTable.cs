using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class CreatePaymentStateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CardHolder",
                table: "Payments",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymentStateId",
                table: "Payments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PaymentState",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    State = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentState", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PaymentStateId",
                table: "Payments",
                column: "PaymentStateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_PaymentState_PaymentStateId",
                table: "Payments",
                column: "PaymentStateId",
                principalTable: "PaymentState",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_PaymentState_PaymentStateId",
                table: "Payments");

            migrationBuilder.DropTable(
                name: "PaymentState");

            migrationBuilder.DropIndex(
                name: "IX_Payments_PaymentStateId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "PaymentStateId",
                table: "Payments");

            migrationBuilder.AlterColumn<string>(
                name: "CardHolder",
                table: "Payments",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }
    }
}
