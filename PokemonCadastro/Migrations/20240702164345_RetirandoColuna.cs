using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonCadastro.Migrations
{
    /// <inheritdoc />
    public partial class RetirandoColuna : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PokemonOwners_PokemonOwners_PokemonOwnerJoinPokemonId_PokemonOwnerJoinOwnerId",
                table: "PokemonOwners");

            migrationBuilder.DropIndex(
                name: "IX_PokemonOwners_PokemonOwnerJoinPokemonId_PokemonOwnerJoinOwnerId",
                table: "PokemonOwners");

            migrationBuilder.DropColumn(
                name: "PokemonOwnerJoinOwnerId",
                table: "PokemonOwners");

            migrationBuilder.DropColumn(
                name: "PokemonOwnerJoinPokemonId",
                table: "PokemonOwners");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PokemonOwnerJoinOwnerId",
                table: "PokemonOwners",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PokemonOwnerJoinPokemonId",
                table: "PokemonOwners",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PokemonOwners_PokemonOwnerJoinPokemonId_PokemonOwnerJoinOwnerId",
                table: "PokemonOwners",
                columns: new[] { "PokemonOwnerJoinPokemonId", "PokemonOwnerJoinOwnerId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonOwners_PokemonOwners_PokemonOwnerJoinPokemonId_PokemonOwnerJoinOwnerId",
                table: "PokemonOwners",
                columns: new[] { "PokemonOwnerJoinPokemonId", "PokemonOwnerJoinOwnerId" },
                principalTable: "PokemonOwners",
                principalColumns: new[] { "PokemonId", "OwnerId" });
        }
    }
}
