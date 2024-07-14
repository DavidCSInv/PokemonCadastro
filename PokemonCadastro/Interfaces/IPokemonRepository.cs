using PokemonCadastro.Model;

namespace PokemonCadastro.Interfaces
{
    public interface IPokemonRepository
    {
        ICollection<PokemonModel> GetPokemon();
        List<PokemonModel> GetPokemonId(int id);
        PokemonModel GetPokemonName(string Pokemonname);
        decimal GetPokemonRating(int id);
        bool PokemonExists(int id);
    }
}
