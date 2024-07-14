using PokemonCadastro.Model;

namespace PokemonCadastro.Interfaces
{
    public interface IReviewRepository
    {
        ICollection<Review> GetReviews();
        Review GetReviewsId(int ReviewId);
        Review GetReviewTitle(string ReviewName);
        ICollection<Review> GetReviewByReviwer(int ReviewerId);
        ICollection<Review> GetReviewByRating(int Rating);
        ICollection<Review> GetReviewByPokemon(int PokemonId);
        bool ReviewExists(int ReviewId);
    }
}
