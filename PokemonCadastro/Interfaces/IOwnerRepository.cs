using PokemonCadastro.Model;

namespace PokemonCadastro.Interfaces
{
    public interface IOwnerRepository
    {
        ICollection<Owner> GetOwner();
        List<Owner> GetOwnerId(int id);
        List<Owner> GetOwnerCountry(string CountryName);
        Owner GetOwnerName(string OwnerName);
        Owner GetOwnerGym(string GymName);
        ICollection<Owner> GetOwnerOfAPokemon(int OwnerId);
        ICollection<PokemonModel> GetPokemonByOwner(int PokemonId);
        bool OwnerExists(int id);

    }
}
