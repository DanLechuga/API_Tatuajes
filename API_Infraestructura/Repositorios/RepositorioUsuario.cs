using API_Comun;
using API_DominioTatuajes.Agregados;
using API_DominioTatuajes.ObjetosDeValor;
using API_Infraestructura.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Infraestructura.Repositorios
{
    class DTOUsuario
    {
        public Guid UsuarioId { get; set; }
        public string UsuarioCorreo { get; set; }
        public string UsuarioPassword { get; set; }
        public bool UsuarioEsCliente { get; set; }
        public bool UsuarioEsTatuador { get; set; }
        
    }
    public class RepositorioUsuario : IRepositorioUsuario
    {
        
        public IUnidadDeTrabajo UnidadDeTrabajo { get; }
        public RepositorioUsuario(IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.UnidadDeTrabajo = unidadDeTrabajo;
        }
        public void Agregar(Usuario agregado)
        {
            throw new NotImplementedException();
        }

        public void EliminarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Usuario GetUsuarioPorId(Guid id)
        {
            try
            {
                Usuario usuarioConsultado = null;
                DynamicParameters parameters = new();
                parameters.Add("@id",id,System.Data.DbType.Guid);
                CommandDefinition command = new("ConsultarUsuarioPorId",parameters,commandType: System.Data.CommandType.StoredProcedure, commandTimeout:0);
                DTOUsuario dTOUsuario = this.UnidadDeTrabajo.SqlConnection.QueryFirstOrDefault<DTOUsuario>(command);
                if (dTOUsuario == null) throw new ArgumentNullException("No se encontro usuario para el id ingresado");
                if (dTOUsuario.UsuarioEsCliente) usuarioConsultado = Usuario.CrearUsuarioCliente(dTOUsuario.UsuarioId, CorreoElectronico.Crear(dTOUsuario.UsuarioCorreo), Password.Crear(dTOUsuario.UsuarioPassword));
                if (dTOUsuario.UsuarioEsTatuador) usuarioConsultado = Usuario.CrearUsuarioTatuador(dTOUsuario.UsuarioId,CorreoElectronico.Crear(dTOUsuario.UsuarioCorreo),Password.Crear(dTOUsuario.UsuarioPassword));

                return usuarioConsultado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Usuario> GetUsuarios()
        {
            throw new NotImplementedException();
        }

        public void Update(Usuario agregado)
        {
            throw new NotImplementedException();
        }

        public Usuario GetUsuarioPorCorreo(string correo)
        {
            if (string.IsNullOrEmpty(correo)) throw new ArgumentNullException("No se puede utilizar valors vacios");
            try
            {
                Usuario usuarioConsultado = null;
                DynamicParameters parameters = new();
                parameters.Add("@correo", correo, System.Data.DbType.String);
                CommandDefinition command = new("ConsultarUsuarioPorCorreo", parameters, commandType: System.Data.CommandType.StoredProcedure, commandTimeout: 0);
                DTOUsuario dTOUsuario = this.UnidadDeTrabajo.SqlConnection.QueryFirstOrDefault<DTOUsuario>(command);
                if (dTOUsuario == null) throw new ArgumentNullException("No se encontro usuario para el correo ingresado");
                if (dTOUsuario.UsuarioEsCliente) usuarioConsultado = Usuario.CrearUsuarioCliente(dTOUsuario.UsuarioId, CorreoElectronico.Crear(dTOUsuario.UsuarioCorreo), Password.Crear(dTOUsuario.UsuarioPassword));
                if (dTOUsuario.UsuarioEsTatuador) usuarioConsultado = Usuario.CrearUsuarioTatuador(dTOUsuario.UsuarioId, CorreoElectronico.Crear(dTOUsuario.UsuarioCorreo), Password.Crear(dTOUsuario.UsuarioPassword));
                return usuarioConsultado;  
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
