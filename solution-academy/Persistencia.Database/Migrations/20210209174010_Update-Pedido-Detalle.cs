using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistencia.Database.Migrations
{
    public partial class UpdatePedidoDetalle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetallePedidos_Pedidos_PedidoId",
                table: "DetallePedidos");

            migrationBuilder.DropColumn(
                name: "DetallePedidoId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "PizzaId",
                table: "DetallePedidos");

            migrationBuilder.AlterColumn<int>(
                name: "PedidoId",
                table: "DetallePedidos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DetallePedidos_Pedidos_PedidoId",
                table: "DetallePedidos",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetallePedidos_Pedidos_PedidoId",
                table: "DetallePedidos");

            migrationBuilder.AddColumn<int>(
                name: "DetallePedidoId",
                table: "Pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "PedidoId",
                table: "DetallePedidos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PizzaId",
                table: "DetallePedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_DetallePedidos_Pedidos_PedidoId",
                table: "DetallePedidos",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
