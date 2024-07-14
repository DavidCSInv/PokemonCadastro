using AutoMapper;
using PokemonCadastro.Context.Dto;
using PokemonCadastro.Model;

namespace PokemonCadastro.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PokemonModel, PokemonDto>();
            CreateMap<Owner, OwnerDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Country, CountryDto>();

        }
    }
}
