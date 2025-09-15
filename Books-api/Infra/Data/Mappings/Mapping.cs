using AutoMapper;
using Domain.Models.DTO;

namespace Infra.Data.Mappings;

public class Mapping : Profile
{
    public Mapping()
    {
        CreateMap(typeof(ResponseGenerico<>), typeof(ResponseGenerico<>));
    }
}