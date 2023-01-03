using API_Comun;
using API_DominioTatuajes.Agregados;
using API_Infraestructura.Interfaces;
using System;
using Dapper;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Infraestructura.Repositorios
{
    //			
    class DTOCreador
    {
        public Guid CreadorId { get; set; }
        public string CreadorNombre { get; set; }
        public string CreadorTelefono { get; set; }
        public string CreadorCorreo { get; set; }
    }
   public class RepositorioCreador: IRepositorioCreador
    {
        public IUnidadDeTrabajo UnidadDeTrabajo { get; set; }
        public RepositorioCreador(IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.UnidadDeTrabajo = unidadDeTrabajo;
        }

        public Creador ConsultarPorCorreo(string correoCreador)
        {
            DynamicParameters parameters = new();
            parameters.Add("@correoCreador",correoCreador,DbType.String);
            CommandDefinition command = new("ConsultarCreadorPorCorreo",parameters,commandType:CommandType.StoredProcedure);
            DTOCreador dTOCreador = UnidadDeTrabajo.SqlConnection.QueryFirstOrDefault<DTOCreador>(command);
            if (dTOCreador is null) return null;
            return Creador.Crear(dTOCreador.CreadorId, dTOCreador.CreadorNombre, dTOCreador.CreadorTelefono, dTOCreador.CreadorCorreo);
        }

        public Creador ConsultarPorId(Guid idCreador)
        {
            DynamicParameters parameters = new();
            parameters.Add("@idCreador", idCreador, DbType.Guid);
            CommandDefinition command = new("ConsultarCreadorPorId", parameters, commandType: CommandType.StoredProcedure);
            DTOCreador dTOCreador = UnidadDeTrabajo.SqlConnection.QueryFirstOrDefault<DTOCreador>(command);
            if (dTOCreador is null) return null;
            return Creador.Crear(dTOCreador.CreadorId, dTOCreador.CreadorNombre, dTOCreador.CreadorTelefono, dTOCreador.CreadorCorreo);
        }

        public void Agregar(Creador agregado)
        {
            throw new NotImplementedException();
        }

        public void Update(Creador agregado)
        {
            throw new NotImplementedException();
        }

        public void EliminarPorId(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
