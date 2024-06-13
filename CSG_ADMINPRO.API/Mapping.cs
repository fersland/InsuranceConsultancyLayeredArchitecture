using AutoMapper;
using CSG_ADMINPRO.APLICATION.DTOs;
using CSG_ADMINPRO.DOMAIN.DTO;
using CSG_ADMINPRO.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSG_ADMINPRO.API
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<ClienteDTO, Cliente>();
            CreateMap<UsuarioDTO, Usuario>();
            CreateMap<UsuarioPasswordDTO, Usuario>();
            CreateMap<CitaDTO, Cita>(); // Para el viewmodel
            CreateMap<CitaCreateDTO, Cita>();

        }
    }
}
