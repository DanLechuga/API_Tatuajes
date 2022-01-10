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
    class DTOCita {
        public Guid Cita_id { get; set; }
        public DateTime Cita_fechacreacion { get; set; }
        public DateTime Cita_fechamodificacion { get; set; }
        public DateTime Cita_fechatermino { get; set; }
        

    }
    public class RepositorioCita : IRepositorioCita
    {
        public IUnidadDeTrabajo UnidadDeTrabajo { get; }
        public RepositorioCita(IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.UnidadDeTrabajo = unidadDeTrabajo;
        }
        public void Agregar(Cita agregado)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cita> ConsultaCita(Usuario usuario)
        {
            List<Cita> ListaCitas = null;
            try
            {
                DynamicParameters parameters = new();
                parameters.Add("@idUsuario",usuario.Id,System.Data.DbType.Guid);
                CommandDefinition command = new("ConsultaDeCitas", parameters,commandTimeout: 0, commandType:System.Data.CommandType.StoredProcedure  );
                IEnumerable<DTOCita> ListaDTOS = UnidadDeTrabajo.SqlConnection.Query<DTOCita>(command);
                foreach (DTOCita item in ListaDTOS)
                {
                    ListaCitas.Add(Cita.Crear(item.Cita_id,item.Cita_fechacreacion,item.Cita_fechamodificacion,item.Cita_fechatermino));
                }
                return ListaCitas??new();
            
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

        public void Update(Cita agregado)
        {
            throw new NotImplementedException();
        }
    }
}
