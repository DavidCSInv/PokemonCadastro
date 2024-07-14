namespace PokemonCadastro.Model
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string ReviewTitle { get; set; }
        public string ReviewText { get; set; }
        public int Rating { get; set; }
        public PokemonModel Pokemons { get; set; }
        public Reviewer Reviewer { get; set; }
    }
}
