using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonCadastro.Context;
using PokemonCadastro.Interfaces;
using PokemonCadastro.Model;

namespace PokemonCadastro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : Controller
    {
        private readonly DataContext _context;
        private readonly IReviewRepository _reviewRepository;
        private readonly IPokemonRepository _pokeRepository;
        private readonly IMapper _mapper;
        public ReviewController(DataContext context, IReviewRepository reviewRepository, IPokemonRepository pokemonRepository, IMapper mapper)
        {
            _context = context;
            _reviewRepository = reviewRepository;
            _pokeRepository = pokemonRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Review>))]
        public IActionResult GetReviews()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var Review = _reviewRepository.GetReviews();

            return Ok(Review);
        }
    }
}
