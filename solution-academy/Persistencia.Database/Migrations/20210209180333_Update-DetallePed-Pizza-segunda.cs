using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistencia.Database.Migrations
{
    public partial class UpdateDetallePedPizzasegunda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_DetallePedidos_PizzaId",
                table: "DetallePedidos",
                column: "PizzaId");

            migrationBuilder.AddForeignKey(
                name: "FK_DetallePedidos_Pizzas_PizzaId",
                table: "DetallePedidos",
                column: "PizzaId",
                principalTable: "Pizzas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetallePedidos_Pizzas_PizzaId",
                table: "DetallePedidos");

            migrationBuilder.DropIndex(
                name: "IX_DetallePedidos_PizzaId",
                table: "DetallePedidos");
        }
    }
}
