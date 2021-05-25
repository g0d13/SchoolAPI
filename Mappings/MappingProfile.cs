using System;
using System.Linq;
using AutoMapper;
using SchoolAPI.DataTransferObjects;
using SchoolAPI.Models;


namespace SchoolAPI.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Origin destiny
            CreateMap<Usuario, UsuarioDto>()
                .ForMember(opt => opt.Role,
                    m
                        => m.MapFrom(u => (int)u.RolId)).ReverseMap();

        }
    }
}