namespace PokemonCadastro.Model
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public List<PokemonCategoryJoin> PokemonCategories { get; set; } = [];
    }
}
