using AutoMapper;
using DataTransferObjects.Persons;
using Microsoft.VisualBasic;
using Persistance.Entities;

namespace Application.Persons.Mappings
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Person, PersonDto>();

            CreateMap<Person, PersonDropdownDto>()
                .ForMember(x => x.Id, opt => opt.MapFrom(o => o.Id))
                .ForMember(x => x.FullName, opt => opt.MapFrom(o => $"{o.FirstName} {o.LastName}"));

            CreateMap<PersonForCreateDto, Person>()
                .ForMember(x => x.Id, opts => opts.Ignore()) // pt a ignora campul la mapare
                .ForMember(x => x.FirstName, opts => opts.MapFrom(x => x.FirstName))
                .ForMember(x => x.LastName, opts => opts.MapFrom(x => x.LastName))
                .ForMember(x => x.Password, opts => opts.MapFrom(x => x.UserPassword))
                .ForMember(x => x.IsAdmin, opts => opts.MapFrom(x => false))
                .ForMember(x => x.Cereri, opts => opts.Ignore());
        }
    }
}
