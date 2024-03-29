﻿using API_Comun;
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
        public bool UsuarioEsCreadorContenido { get; set; }

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
            try
            {
                DynamicParameters parameters = new();
                parameters.Add("@idUsuario",agregado.Id,System.Data.DbType.Guid);
                parameters.Add("@Correo",agregado.UsuarioCorreo.Cadenavalida,System.Data.DbType.String);
                parameters.Add("@Password",agregado.UsuarioPassword.ContraseniaValida,System.Data.DbType.String);
                parameters.Add("@UsuarioCliente",agregado.UsuarioEsCliente,System.Data.DbType.Boolean);
                CommandDefinition command = new("CrearUsuarioCliente",parameters,commandTimeout: 0, commandType: System.Data.CommandType.StoredProcedure);
                if (UnidadDeTrabajo.SqlConnection.State == 0) UnidadDeTrabajo.SqlConnection.Open();
                UnidadDeTrabajo.SqlConnection.Execute(command);
                
                
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public void EliminarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Usuario GetUsuarioCliente(Guid id)
        {
            try
            {
                Usuario usuarioConsultado = null;
                DynamicParameters parameters = new();
                parameters.Add("@id",id,System.Data.DbType.Guid);
                CommandDefinition command = new("ConsultarUsuarioPorId", parameters,commandType: System.Data.CommandType.StoredProcedure, commandTimeout:0);
                DTOUsuario dTOUsuario = this.UnidadDeTrabajo.SqlConnection.QueryFirstOrDefault<DTOUsuario>(command);
                if (dTOUsuario == null) return null;
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
            if (string.IsNullOrEmpty(correo)) throw new Exception("No se puede utilizar valors vacios");
            try
            {
                Usuario usuarioConsultado = null;
                DynamicParameters parameters = new();
                parameters.Add("@correo", correo, System.Data.DbType.String);
                CommandDefinition command = new("ConsultarUsuarioPorCorreo", parameters, commandType: System.Data.CommandType.StoredProcedure, commandTimeout: 0);
                DTOUsuario dTOUsuario = this.UnidadDeTrabajo.SqlConnection.QueryFirstOrDefault<DTOUsuario>(command);
                if (dTOUsuario == null) return null;
                if (dTOUsuario.UsuarioEsCliente) usuarioConsultado = Usuario.CrearUsuarioCliente(dTOUsuario.UsuarioId, CorreoElectronico.Crear(dTOUsuario.UsuarioCorreo), Password.Crear(dTOUsuario.UsuarioPassword));
                if (dTOUsuario.UsuarioEsTatuador) usuarioConsultado = Usuario.CrearUsuarioTatuador(dTOUsuario.UsuarioId, CorreoElectronico.Crear(dTOUsuario.UsuarioCorreo), Password.Crear(dTOUsuario.UsuarioPassword));
                if (dTOUsuario.UsuarioEsCreadorContenido) usuarioConsultado = Usuario.CrearUsuarioCreadorContenido(dTOUsuario.UsuarioId, CorreoElectronico.Crear(dTOUsuario.UsuarioCorreo), Password.Crear(dTOUsuario.UsuarioPassword));
                return usuarioConsultado;  
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
