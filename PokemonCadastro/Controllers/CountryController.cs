using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonCadastro.Context;
using PokemonCadastro.Context.Dto;
using PokemonCadastro.Interfaces;
using PokemonCadastro.Model;

namespace PokemonCadastro.Controllers
{
    [Route("api[controller]")]
    [ApiController]
    public class CountryController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly ICountryRepository _countryRepository;
        private readonly IOwnerRepository _ownerRepository;
        private readonly IMapper _mapper;
        public CountryController(DataContext context, ICountryRepository countryRepository, IMapper mapper, IOwnerRepository owner)
        {
            _dataContext = context;
            _countryRepository = countryRepository;
            _mapper = mapper;
            _ownerRepository = owner;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Country>))]
        public IActionResult GetCountry()
        {
            var Country = _mapper.Map<List<CountryDto>>(_countryRepository.GetCountry());

            return Ok(Country);
        }

        [HttpGet("{CountryId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Country>))]
        [ProducesResponseType(400)]
        public IActionResult GetCountryId(int CountryId)
        {
            if (!_countryRepository.CountryExists(CountryId))
                return NotFound("Este país não existe");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var Country = _mapper.Map<CountryDto>(_countryRepository.GetCountryId(CountryId));

            return Ok(Country);
        }

        [HttpGet("CountryByOwner/{OwnerId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Country>))]
        [ProducesResponseType(400)]
        public IActionResult GetCountryByOwner(int OwnerId)
        {
            if (!_ownerRepository.OwnerExists(OwnerId))
                return NotFound("Este dono não existe");

            if (!ModelState.IsValid)
                return BadRequest("Erro no modelo de dados");

            var Owner = _mapper.Map<CountryDto>(_countryRepository.GetCountryByOwner(OwnerId));
            return Ok(Owner);
        }

        [HttpGet("OwnerByCountry/{CountryId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Country>))]
        [ProducesResponseType(400)]
        public IActionResult GetOwnerByCountry(int CountryId)
        {
            if (!_countryRepository.CountryExists(CountryId))
                return NotFound("Este pais não existe");

            if (!ModelState.IsValid)
                return BadRequest("Modelo de dados incorreto");

            var Country = _mapper.Map<List<OwnerDto>>(_countryRepository.GetOwnersByCountry(CountryId));

            return Ok(Country);
        }
    }
}
