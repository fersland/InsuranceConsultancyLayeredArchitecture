using AutoMapper;
using CSG_ADMINPRO.APLICATION.DTOs;
using CSG_ADMINPRO.DOMAIN.DTO;
using CSG_ADMINPRO.DOMAIN.Entities;
using CSG_ADMINPRO.UI.Models.ViewModel;

namespace CSG_ADMINPRO.UI.Mapping
{
    public class MappingData : Profile
    {
        public MappingData()
        {
            CreateMap<AseguradoCreateViewModel, Asegurado>();
            CreateMap<UsuarioDTO, Usuario>();
            CreateMap<UsuarioPasswordDTO, Usuario>();
            CreateMap<CitaDTO, Cita>(); // Para el viewmodel
        }
    }
}
