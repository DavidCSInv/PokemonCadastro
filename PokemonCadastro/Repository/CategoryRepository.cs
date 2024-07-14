using PokemonCadastro.Context;
using PokemonCadastro.Interfaces;
using PokemonCadastro.Model;

namespace PokemonCadastro.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;
        public CategoryRepository(DataContext context)
        {
            _context = context;
        }

        public bool CategoryExists(int CategoryId) => _context.Categories.Any(c => c.CategoryId == CategoryId);


        public ICollection<Category> GetCategories() => _context.Categories.OrderBy(o => o.CategoryId).ToList();

        public List<Category> GetCategoryId(int CategoryId) => _context.Categories
                                                               .Where(w => w.CategoryId == CategoryId)
                                                               .ToList();

        public Category GetCategoryName(string CategoryName) => _context.Categories
                                                                .Where(w => w.Name == CategoryName)
                                                                .FirstOrDefault();

        public ICollection<PokemonModel> GetPokemonCategory(int CategoryId) => _context.PokemonCategories
                                                                            .Where(w => w.CategoryId == CategoryId)
                                                                            .Select(s => s.Pokemon)
                                                                            .ToList();


    }
}
