namespace PokemonCadastro.Model
{
    public class PokemonCategoryJoin
    {
        public int PokemonId { get; set; }
        public int CategoryId { get; set; }
        public PokemonModel Pokemon { get; set; }
        public Category Category { get; set; }
    }
}
