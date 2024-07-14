using AutoMapper;
using PokemonCadastro.Context;
using PokemonCadastro.Interfaces;
using PokemonCadastro.Model;

namespace PokemonCadastro.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DataContext _Context;
        private readonly IMapper _mapper;
        public CountryRepository(DataContext Context, IMapper mapper)
        {
            _Context = Context;
            _mapper = mapper;
        }
        public bool CountryExists(int CountryId) => _Context.Country.Any(a => a.CountryId == CountryId);

        public ICollection<Country> GetCountry() => _Context.Country.OrderBy(o => o.CountryId).ToList();
        public Country GetCountryId(int Countryid) => _Context.Country
                                                      .FirstOrDefault(o => o.CountryId == Countryid);

        public Country GetCountryByOwner(int ownerId) => _Context.Owners.Where(w => w.OwnerId == ownerId)
                                                                        .Select(s => s.Country)
                                                                        .FirstOrDefault();

        public Country GetCountryName(string countryName) => _Context.Country
                                                                    .Where(w => w.CountryName == countryName)
                                                                    .FirstOrDefault();

        public ICollection<Owner> GetOwnersByCountry(int CountryId) => _Context.Owners
                                                                    .Where(w => w.Country.CountryId == CountryId)
                                                                    .ToList();
    }
}
