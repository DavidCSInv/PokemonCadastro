namespace PokemonCadastro.Model
{
    public class PokemonOwnerJoin
    {
        public int PokemonId { get; set; }
        public int OwnerId { get; set; }
        public PokemonModel Pokemon { get; set; }
        public Owner Owners { get; set; }
    }
}
