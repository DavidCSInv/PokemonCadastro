using System.ComponentModel.DataAnnotations;

namespace PokemonCadastro.Model
{
    public class PokemonModel
    {
        [Key]
        public int PokemonId { get; set; }
        public string PokemonName { get; set; }
        public string PokemonDescription { get; set; }
        public DateTime BirthDate { get; set; }
        public List<Review> Reviews { get; set; } = [];
        public List<PokemonOwnerJoin> PokemonOwners { get; set; } = [];
        public List<PokemonCategoryJoin> PokemonCategories { get; set; } = [];
    }
}
