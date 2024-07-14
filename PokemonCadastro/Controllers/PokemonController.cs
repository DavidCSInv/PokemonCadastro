using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonCadastro.Context;
using PokemonCadastro.Context.Dto;
using PokemonCadastro.Interfaces;
using PokemonCadastro.Model;

namespace PokemonCadastro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : Controller
    {
        private readonly IPokemonRepository _Pokemonrepository;
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;
        public PokemonController(IPokemonRepository pokemonRepository, DataContext context, IMapper mapper)
        {
            _Pokemonrepository = pokemonRepository;
            _dataContext = context;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PokemonModel>))]
        public IActionResult GetPokemonModels()
        {
            var Pokemons = _mapper.Map<List<PokemonDto>>(_Pokemonrepository.GetPokemon());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(Pokemons);
        }

        [HttpGet("{PokeId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PokemonModel>))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemon(int PokeId)
        {
            if (!_Pokemonrepository.PokemonExists(PokeId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var Pokemon = _mapper.Map<List<PokemonDto>>(_Pokemonrepository.GetPokemonId(PokeId));

            return Ok(Pokemon);
        }

        [HttpGet("{PokeId}/rating")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonRating(int PokeId)
        {
            if (!_Pokemonrepository.PokemonExists(PokeId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var rating = _Pokemonrepository.GetPokemonRating(PokeId);

            return Ok(rating);
        }
    }
}
