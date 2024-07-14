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
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public CategoryController(DataContext context, IMapper mapper, ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            _dataContext = context;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
        public IActionResult GetCategory()
        {
            var Category = _mapper.Map<List<CategoryDto>>(_categoryRepository.GetCategories());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(Category);
        }

        [HttpGet("{CategoryId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
        [ProducesResponseType(400)]
        public IActionResult GetCategoriesId(int CategoryId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_categoryRepository.CategoryExists(CategoryId))
                return NotFound("Este ID não existe");

            var Category = _mapper.Map<List<CategoryDto>>(_categoryRepository.GetCategoryId(CategoryId));

            return Ok(Category);
        }
        [HttpGet("Pokemon/CategoryId")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonCategoryId(int CategoryId)
        {
            if (!_categoryRepository.CategoryExists(CategoryId))
                return NotFound("Não ha pokemon com esta categoria");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var PokeCatId = _mapper.Map<List<PokemonDto>>(_categoryRepository.GetPokemonCategory(CategoryId));
            return Ok(PokeCatId);
        }

    }
}
