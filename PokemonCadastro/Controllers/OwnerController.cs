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
    public class OwnerController : Controller
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly IPokemonRepository _pokeRepository;
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public OwnerController(IOwnerRepository ownerRepository, DataContext context, IMapper mapper, IPokemonRepository pokeRepository)
        {
            _ownerRepository = ownerRepository;
            _context = context;
            _mapper = mapper;
            _pokeRepository = pokeRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Owner>))]
        public IActionResult GetOwner()
        {
            var Owner = _mapper.Map<List<OwnerDto>>(_ownerRepository.GetOwner());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(Owner);
        }

        [HttpGet("{OwnerId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Owner>))]
        [ProducesResponseType(400)]
        public IActionResult GetOnwerId(int OwnerId)
        {
            if (!_ownerRepository.OwnerExists(OwnerId))
                return NotFound();

            var Owner = _mapper.Map<List<OwnerDto>>(_ownerRepository.GetOwnerId(OwnerId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(Owner);
        }

        //TODO Terminar de fazer por nome do dono
        [HttpGet("Name/{OwnerName}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Owner>))]
        [ProducesResponseType(400)]
        public IActionResult GetOwnerName(string OwnerName)
        {
            var Owner = _mapper.Map<OwnerDto>(_ownerRepository.GetOwnerName(OwnerName));

            if (Owner == null)
                return NotFound("Não existe este treinador");

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(Owner);
        }

        [HttpGet("OwnerofaPokemon/{PokemonId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Owner>))]
        [ProducesResponseType(400)]
        public IActionResult GetOwnerOfaPokemon(int PokemonId)
        {
            if (!_pokeRepository.PokemonExists(PokemonId))
                return NotFound("Pokemon não existente");

            if (!ModelState.IsValid)
                return BadRequest("Modelo de dados incorreto");
            var Owner = _mapper.Map<List<OwnerDto>>(_ownerRepository.GetOwnerOfAPokemon(PokemonId));
            return Ok(Owner);
        }

        [HttpGet("PokemonOfAOwner/{OwnerId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Owner>))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonByOwner(int OwnerId)
        {
            if (!_ownerRepository.OwnerExists(OwnerId))
                return NotFound("Treinador não existente");

            if (!ModelState.IsValid)
                return BadRequest("Modelo de dados incorreto");

            var Owner = _mapper.Map<List<PokemonDto>>(_ownerRepository.GetPokemonByOwner(OwnerId));

            return Ok(Owner);
        }
    }
}
