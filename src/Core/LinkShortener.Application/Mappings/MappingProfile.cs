using AutoMapper;
using LinkShortener.Application.DTO;
using LinkShortener.Domain.Entities;

namespace LinkShortener.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Url, UrlResponseDto>();
    }
}