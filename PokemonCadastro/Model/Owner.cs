namespace PokemonCadastro.Model
{
    public class Owner
    {
        public int OwnerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gym { get; set; }
        public Country Country { get; set; }
        public List<PokemonOwnerJoin> PokemonOwner { get; set; }
    }
}
