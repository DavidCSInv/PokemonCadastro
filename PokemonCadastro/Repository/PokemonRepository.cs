using PokemonCadastro.Context;
using PokemonCadastro.Interfaces;
using PokemonCadastro.Model;

namespace PokemonCadastro.Repository
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly DataContext _context;
        public PokemonRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<PokemonModel> GetPokemon() => _context.Pokemons.OrderBy(p => p.PokemonId)
                                                                                .ToList();
        public List<PokemonModel> GetPokemonId(int PokemonId)
        {
            var Pokemon = _context.Pokemons.FirstOrDefault(p => p.PokemonId == PokemonId);
            return Pokemon != null ? [Pokemon] : [];
        }
        public PokemonModel GetPokemonName(string Pokemonname) => _context.Pokemons
                                                              .Where(p => p.PokemonName == Pokemonname)
                                                              .FirstOrDefault();

        public decimal GetPokemonRating(int PokemonId)
        {
            var review = _context.Reviews.Where(p => p.Pokemons.PokemonId == PokemonId);

            if (review.Count() <= 0)
                return 0;
            return Math.Round((decimal)review.Sum(p => p.Rating) / review.Count(), 2);
        }

        public bool PokemonExists(int PokemonId) => _context.Pokemons.Any(p => p.PokemonId == PokemonId);

    }
}
