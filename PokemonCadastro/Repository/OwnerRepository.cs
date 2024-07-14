using PokemonCadastro.Context;
using PokemonCadastro.Interfaces;
using PokemonCadastro.Model;

namespace PokemonCadastro.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly DataContext _context;

        public OwnerRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Owner> GetOwner() => _context.Owners.OrderBy(p => p.OwnerId).ToList();


        public List<Owner> GetOwnerCountry(string CountryName)
        {
            var OwnerCountry = _context.Owners.FirstOrDefault(fd => fd.Country.CountryName == CountryName);
            return OwnerCountry != null ? [OwnerCountry] : [];
        }
        public Owner GetOwnerGym(string GymName) => _context.Owners.Where(w => w.Gym == GymName)
                                                                   .FirstOrDefault();

        public List<Owner> GetOwnerId(int OwnerId)
        {
            var Owner = _context.Owners.FirstOrDefault(fd => fd.OwnerId == OwnerId);
            return Owner != null ? [Owner] : [];
        }

        public Owner GetOwnerName(string FirstName) => _context.Owners.Where(w => w.FirstName == FirstName).FirstOrDefault();

        public ICollection<Owner> GetOwnerOfAPokemon(int PokemonId) => [.._context.PokemonOwners
                                                        .Where(W => W.PokemonId == PokemonId)
                                                        .Select(s => s.Owners)];
        public ICollection<PokemonModel> GetPokemonByOwner(int OwnerId) => [.._context.PokemonOwners
                                                          .Where(w => w.OwnerId == OwnerId)
                                                          .Select(s => s.Pokemon)];
        public bool OwnerExists(int OwnerId) => _context.Owners.Any(w => w.OwnerId == OwnerId);

    }
}
