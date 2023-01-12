using API_Aplicacion.DTOs;
using AutoMapper;
using API_Comun;
using API_DominioTatuajes.Agregados;

namespace API_Aplicacion.AutoMap
{
  
   public class DomainToDto : Profile   
    {
        
        public DomainToDto()
        {
            CreateMap<DTOCatalogoTatuajes, CatalogoDeTatuajes>().ReverseMap()
                .ForMember(dest => dest.IdTatuaje,a=>a.MapFrom(src => src.ID));
            CreateMap<DTODetalleTatuaje, DetalleDeTatuaje>().ReverseMap()
               .ForMember(dest => dest.IdTatuaje,a=>a.MapFrom(src => src.ID))
               .ForMember(dest => dest.PrecioTatuaje,a=>a.MapFrom(src => $"${src.PrecioTatuaje}"));
            CreateMap<DTODetalleTatuaje, TatuajeCita>().ReverseMap()
                .ForMember(dest => dest.IdTatuaje, a => a.MapFrom(src => src.TatuajeCita_IdCatalogo))
                .ForMember(dest => dest.NombreTatuajeCustom, a => a.MapFrom(src => src.TatuajeCita_NombreTatuajeCustom));
            CreateMap<DTODetalleTatuaje, DTODetalleTatuaje>().ReverseMap();
            CreateMap<DTOCitas, CitaCliente>().ReverseMap()
                .ForMember(dest => dest.IdUsuario,a=>a.MapFrom(src => src.IdCliente))
                .ForMember(dest => dest.FechaCreacion,a=>a.MapFrom(src =>src.FechaCitaRegistrada));
            CreateMap<DTOCitas, TatuajeCita>().ReverseMap()
                .ForMember(dest => dest.IdCatalogo, a => a.MapFrom(src => src.TatuajeCita_IdCatalogo))
                .ForMember(dest => dest.NombreTatuajeCustom, a => a.MapFrom(src => src.TatuajeCita_NombreTatuajeCustom));
            CreateMap<DTOSession, Session>().ReverseMap();
            CreateMap<DTOCreador, Creador>().ReverseMap()
                .ForMember(dest => dest.IdCreador,a=>a.MapFrom(src => src.Id))
                .ForMember(dest => dest.CorreoCreador,a=>a.MapFrom(src => src.CreadorCorreo))
                .ForMember(dest => dest.NombreCreador,a=>a.MapFrom(src => src.CreadorNombre))
                .ForMember(dest => dest.TelefonoCreador,a=>a.MapFrom(src => src.CreadorTelefono));
            CreateMap<DTOTatuador, Tatuador>().ReverseMap()
                .ForMember(dest => dest.idTatuador, a => a.MapFrom(src => src.Id))
                .ForMember(dest => dest.correoTauador, a => a.MapFrom(src => src.Tatuador_Correo))
                .ForMember(dest => dest.nombreTatuador, a => a.MapFrom(src => src.Tatuador_Nombre))
                .ForMember(dest => dest.numeroTalefonico, a => a.MapFrom(src => src.Tatuador_NumTel));
            CreateMap<DTOCitasTatuador, CitaCliente>().ReverseMap()
                .ForMember(dest => dest.EsConAnticipo, a => a.MapFrom(src => src.EsConAnticipo))
                .ForMember(dest => dest.CantidadDeposito, a => a.MapFrom(src => src.CantidadDeposito))
                .ForMember(dest => dest.FechaCreacion, a => a.MapFrom(src => src.FechaCitaRegistrada))
                .ForMember(dest => dest.IdCita, a => a.MapFrom(src => src.IdCita))
                .ForMember(dest => dest.IdCliente, a => a.MapFrom(src => src.IdCliente));
            CreateMap<DTOCitasTatuador, Cliente>().ReverseMap()
                .ForMember(dest => dest.NombreCliente, a => a.MapFrom(src => src.Cliente_nombre));
            CreateMap<DTOCitasTatuador, TatuajeCita>().ReverseMap()
                .ForMember(dest => dest.IdCatalogo,a=>a.MapFrom(src => src.TatuajeCita_IdCatalogo));
            CreateMap<DTOUsuario, Usuario>().ReverseMap()
                .ForMember(dest => dest.IdUsaurio, a => a.MapFrom(src => src.Id))
                .ForMember(dest => dest.EsCliente, a => a.MapFrom(src => src.UsuarioEsCliente))
                .ForMember(dest => dest.EsUsuarioValido, a => a.MapFrom(src => true))
                .ForMember(dest => dest.EsCreadorContenido, a => a.MapFrom(src => src.UsuarioEsCreadorContenido))
                .ForMember(dest => dest.EsTatuador, a => a.MapFrom(src => src.UsuarioEsTatuador))
                .ForPath(dest => dest.Username,a=>a.MapFrom(src => src.UsuarioCorreo.Cadenavalida))
                .ForPath(dest => dest.Password,a=>a.MapFrom(src => src.UsuarioPassword.ContraseniaValida));
            CreateMap<DTOCliente, Cliente>().ReverseMap()
                .ForMember(dest => dest.IdCliente,a=>a.MapFrom(src => src.Id))
                .ForMember(dest => dest.CorreoCliente,a=>a.MapFrom(src => src.Cliente_correo.Cadenavalida))
                .ForMember(dest => dest.NombreCliente,a=>a.MapFrom(src => src.Cliente_nombre))
                .ForMember(dest => dest.NumeroTelefonico,a=>a.MapFrom(src => src.Cliente_numeroTel))
                .ForMember(dest => dest.PasswordCliente,a=>a.MapFrom(src => src.Password.ContraseniaValida));
                



        }
    }
}
