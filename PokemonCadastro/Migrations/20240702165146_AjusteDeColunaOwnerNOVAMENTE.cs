using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonCadastro.Migrations
{
    /// <inheritdoc />
    public partial class AjusteDeColunaOwnerNOVAMENTE : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PokemonOwners_Owners_OwnerId1",
                table: "PokemonOwners");

            migrationBuilder.RenameColumn(
                name: "OwnerId1",
                table: "PokemonOwners",
                newName: "OwnersOwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_PokemonOwners_OwnerId1",
                table: "PokemonOwners",
                newName: "IX_PokemonOwners_OwnersOwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonOwners_Owners_OwnersOwnerId",
                table: "PokemonOwners",
                column: "OwnersOwnerId",
                principalTable: "Owners",
                principalColumn: "OwnerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PokemonOwners_Owners_OwnersOwnerId",
                table: "PokemonOwners");

            migrationBuilder.RenameColumn(
                name: "OwnersOwnerId",
                table: "PokemonOwners",
                newName: "OwnerId1");

            migrationBuilder.RenameIndex(
                name: "IX_PokemonOwners_OwnersOwnerId",
                table: "PokemonOwners",
                newName: "IX_PokemonOwners_OwnerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonOwners_Owners_OwnerId1",
                table: "PokemonOwners",
                column: "OwnerId1",
                principalTable: "Owners",
                principalColumn: "OwnerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
