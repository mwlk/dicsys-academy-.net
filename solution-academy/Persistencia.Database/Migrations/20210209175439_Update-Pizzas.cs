using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistencia.Database.Migrations
{
    public partial class UpdatePizzas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IngredienteId",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "PizzaId",
                table: "Ingredientes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IngredienteId",
                table: "Pizzas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PizzaId",
                table: "Ingredientes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
