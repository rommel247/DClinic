using AutoMapper;
using DClinic.Domain.Commands;
using DClinic.Domain.Dtos;
using DClinic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DClinic.Domain.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Patient, CreatePatientCommand>().ReverseMap();
            CreateMap<Patient, UpdatePatientCommand>().ReverseMap();
            CreateMap<Patient,PatientDto>().ReverseMap();
        }
    }
}
