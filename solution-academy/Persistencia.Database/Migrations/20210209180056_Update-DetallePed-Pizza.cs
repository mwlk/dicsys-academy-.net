using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistencia.Database.Migrations
{
    public partial class UpdateDetallePedPizza : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_DetallePedidos_DetallePedidoId",
                table: "Pizzas");

            migrationBuilder.DropIndex(
                name: "IX_Pizzas_DetallePedidoId",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "DetallePedidoId",
                table: "Pizzas");

            migrationBuilder.AddColumn<int>(
                name: "PizzaId",
                table: "DetallePedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PizzaId",
                table: "DetallePedidos");

            migrationBuilder.AddColumn<int>(
                name: "DetallePedidoId",
                table: "Pizzas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_DetallePedidoId",
                table: "Pizzas",
                column: "DetallePedidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_DetallePedidos_DetallePedidoId",
                table: "Pizzas",
                column: "DetallePedidoId",
                principalTable: "DetallePedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
