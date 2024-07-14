namespace PokemonCadastro.Model
{
    public class Reviewer
    {
        public int ReviewerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
