﻿using AutoMapper;
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
            CreateMap<Patient,PatientDto>().ReverseMap();
        }
    }
}
