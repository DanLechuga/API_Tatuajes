

using API_Aplicacion.DTOs;
using API_Tatuajes.Modelos;
using AutoMapper;
using System;

namespace API_Tatuajes.AutoMap
{
    /// <summary>
    /// 
    /// </summary>
   public  class ModelToDto : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public ModelToDto()
        {
            CreateMap<DTOCitas, ModeloCrearCita>().ReverseMap()
                .ForMember(dest => dest.IdUsuario,a=>a.MapFrom(src => src.idUsuario))
                .ForMember(dest => dest.EsConAnticipo,a=>a.MapFrom(src => src.esAnticipo))
                .ForMember(dest => dest.CantidadDeposito, a => a.MapFrom(src => src.montoAnticipo))
                .ForMember(dest => dest.FechaCreacion, a => a.MapFrom(src => src.fechaCita))
                .ForMember(dest => dest.IdCita,a=>a.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.IdCatalogo,a=>a.MapFrom(src => src.listaDeTatuajes))
                .ForMember(dest => dest.NombreTatuajeCustom,a=>a.MapFrom(src => string.IsNullOrEmpty(src.nombreTatuajeCustom)? "":src.nombreTatuajeCustom));

            CreateMap<DTOCitas, ModeloActualizarCita>().ReverseMap()
                .ForMember(dest => dest.IdCita, a => a.MapFrom(src => src.idCita))
                .ForMember(dest => dest.FechaCreacion,a=>a.MapFrom(src => src.fechaActualizada));
            CreateMap<DTOSession, ModeloSession>().ReverseMap();
            CreateMap<DTOUsuario, ModeloCerrarSessionCliente>().ReverseMap()
                .ForMember(dest => dest.IdUsaurio,a=>a.MapFrom(src => src.idCliente));

            CreateMap<DTOTatuador, ModeloCerrarSessionTatuador>().ReverseMap()
                .ForMember(dest => dest.idTatuador, a => a.MapFrom(src => src.idTatuador));
            CreateMap<DTOCreador, ModeloCerrarSessionCreador>().ReverseMap()
                .ForMember(dest => dest.IdCreador, a => a.MapFrom(src => src.idCreador));
            CreateMap<DTOUsuario, ModeloUsuario>().ReverseMap().
                ForMember(dest => dest.Username,a=>a.MapFrom(src => src.Username))
                .ForMember(dest => dest.Password,a=>a.MapFrom(src => src.Password));
            CreateMap<DTORegistroDeCliente, ModeloRegistrarCliente>().ReverseMap()
                .ForMember(dest => dest.NombreCliente,a=>a.MapFrom(src => src.nombreDeCliente));

        }
    }
}
