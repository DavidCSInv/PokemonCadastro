using PokemonCadastro.Model;

namespace PokemonCadastro.Interfaces
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();
        List<Category> GetCategoryId(int CategoryId);
        ICollection<PokemonModel> GetPokemonCategory(int CategoryId);
        Category GetCategoryName(string CategoryName);
        bool CategoryExists(int CategoryId);
    }
}
