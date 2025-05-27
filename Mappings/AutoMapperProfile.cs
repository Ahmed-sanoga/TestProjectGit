using AutoMapper;
using SuperheroAPI.DOTs;
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

            CreateMap<Card, CardDto>();
            CreateMap<CardDto, Card>();
        }
    }
}
