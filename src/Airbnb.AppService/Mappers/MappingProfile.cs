using Airbnb.AppService.Responses.Listings;
using Airbnb.Core.Entities;
using AutoMapper;

namespace Airbnb.AppService.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Listing, CreateListingResponse>();
    }
}