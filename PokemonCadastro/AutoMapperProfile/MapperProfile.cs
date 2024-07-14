using AutoMapper;
using PokemonCadastro.Context.Dto;
using PokemonCadastro.Model;

namespace PokemonCadastro.AutoMapperProfile
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<PokemonModel, PokemonDto>()
                .ForMember(d => d.PokemonId, src => src.MapFrom(x => x.PokemonId));
        }
    }
}
