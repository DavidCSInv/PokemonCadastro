using PokemonCadastro.Model;

namespace PokemonCadastro.Interfaces
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountry();
        Country GetCountryId(int id);
        Country GetCountryName(string countryName);
        Country GetCountryByOwner(int ownerId);
        ICollection<Owner> GetOwnersByCountry(int CountryId);
        bool CountryExists(int CountryId);
    }
}
