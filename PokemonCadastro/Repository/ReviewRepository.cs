using AutoMapper;
using PokemonCadastro.Context;
using PokemonCadastro.Interfaces;
using PokemonCadastro.Model;

namespace PokemonCadastro.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        public ReviewRepository(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        public ICollection<Review> GetReviews() => _dataContext.Reviews.OrderBy(o => o.ReviewId).ToList();

        public ICollection<Review> GetReviewByRating(int Rating) => [.. _dataContext.Reviews
                                                                .Where(w => w.Rating ==Rating)];
        public ICollection<Review> GetReviewByReviwer(int ReviewerId) => [.. _dataContext.Reviews
                                                                .Where(w => w.Reviewer.ReviewerId == ReviewerId)];

        public Review GetReviewsId(int ReviewId) => _dataContext.Reviews
                                                     .Where(w => w.ReviewId == ReviewId)
                                                     .FirstOrDefault();
        public Review GetReviewTitle(string ReviewName) => _dataContext.Reviews
                                                           .Where(w => w.ReviewTitle == ReviewName)
                                                           .FirstOrDefault();
        public ICollection<Review> GetReviewByPokemon(int PokemonId) => [.._dataContext.Pokemons.Where(w => w.PokemonId == PokemonId)
            .SelectMany(s => s.Reviews)];
        public bool ReviewExists(int ReviewId) => _dataContext.Reviews.Any(a => a.ReviewId == ReviewId);
    }
}
