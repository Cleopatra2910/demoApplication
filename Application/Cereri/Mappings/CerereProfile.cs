using System;
using System.Collections.Generic;
using System.Text;
using Application.Enums;
using AutoMapper;
using DataTransferObjects.Cereri;
using Persistance.Entities;

namespace Application.Cereri.Mappings
{
    public class CerereProfile : Profile
    {
        public CerereProfile()
        {
            CreateMap<CreareCerereDto, Cerere>()
                .ForMember(x => x.Id, opts => opts.Ignore())
                .ForMember(x => x.Persoana, opts => opts.Ignore())
                .ForMember(x => x.StatusCerere, opts => opts.MapFrom(o => (int) StatusCerereEnum.New));

            CreateMap<EditareCerereDto, Cerere>()
                .ForMember(x => x.Id, opts => opts.Ignore())
                .ForMember(x => x.Persoana, opts => opts.Ignore())
                .ForMember(x => x.PersoanaId, opts => opts.Ignore())
                .ForMember(x => x.StatusCerere, opts => opts.Ignore());


            CreateMap<Cerere, CerereForGet>();

        }
    }
}
