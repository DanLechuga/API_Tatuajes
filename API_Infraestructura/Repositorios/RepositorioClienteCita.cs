using API_Comun;
using API_DominioTatuajes.Agregados;
using API_Infraestructura.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Infraestructura.Repositorios
{
    class DTOCitaCliente
    {
        public Guid ClienteCita_id { get; set; }
        public DateTime ClienteCita_Fecha { get; set; }
        public Guid ClienteCita_ClienteId { get; set; }
        public bool ClienteCita_Anticipo { get; set; }
        public double ClienteCita_MontoAnticipa { get; set; }
        public Guid ClienteCita_TatuadorId { get; set; }
    }
    public class RepositorioClienteCita : IRepositorioClienteCita
    {
        public IUnidadDeTrabajo UnidadDeTrabajo { get; set; }
        public RepositorioClienteCita(IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.UnidadDeTrabajo = unidadDeTrabajo;
        }
        public void Agregar(CitaCliente agregado)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CitaCliente> ConsultaCitaCliente(Usuario usuario)
        {
            List<CitaCliente> ListaCitasCliente = new();
            DynamicParameters parameters = new();
            parameters.Add("@idUsuario",usuario.Id,System.Data.DbType.Guid);
            CommandDefinition command = new("ConsultarCitaPorUsuario",parameters,commandTimeout: 0, commandType: System.Data.CommandType.StoredProcedure);
            IEnumerable<DTOCitaCliente> ListaDTOS = UnidadDeTrabajo.SqlConnection.Query<DTOCitaCliente>(command);
            foreach (var item in ListaDTOS)
            {
                ListaCitasCliente.Add(CitaCliente.Crear(item.ClienteCita_id,item.ClienteCita_id,item.ClienteCita_ClienteId,item.ClienteCita_Fecha,item.ClienteCita_Anticipo,item.ClienteCita_MontoAnticipa,item.ClienteCita_TatuadorId));
            }
            return ListaCitasCliente;
            
        }

        public void EliminarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(CitaCliente agregado)
        {
            throw new NotImplementedException();
        }
    }
}
