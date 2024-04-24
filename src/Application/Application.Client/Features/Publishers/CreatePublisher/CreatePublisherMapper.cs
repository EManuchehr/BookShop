using AutoMapper;
using Domain.Entities;

namespace Application.Client.Features.Publishers.CreatePublisher;

public class CreatePublisherMapper : Profile
{
    public CreatePublisherMapper()
    {
        CreateMap<CreatePublisherRequest, Publisher>();

        CreateMap<Publisher, CreatePublisherResponse>();
    }
}