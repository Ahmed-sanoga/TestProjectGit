using AutoMapper;
using SuperheroAPI.DTOs;
using SuperheroAPI.Entites;

namespace SuperheroAPI.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Entity ➜ DTO
            CreateMap<Superhero, SuperheroDto>();

            // DTO ➜ Entity
            CreateMap<CreateSuperheroDto, Superhero>();
        }
    }
}
