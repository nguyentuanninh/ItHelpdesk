using AutoMapper;
using ITHelpdesk.Application.DTOs.Authen;
using ITHelpdesk.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelpdesk.Application
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Employee, LoginResponseDto>().ReverseMap();
            CreateMap<Employee, RegisterRequestDto>().ReverseMap();
        }
    }
}
