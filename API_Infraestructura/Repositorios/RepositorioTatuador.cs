using API_DominioTatuajes.Agregados;
using API_Infraestructura.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_Comun;
using Dapper;
using API_DominioTatuajes.ObjetosDeValor;

namespace API_Infraestructura.Repositorios
{
    class DTOTatuador
    {
        public Guid Tatuador_Id { get; set; }
        public string Tatuador_Nombre { get; set; }
        public string Tatuador_Correo { get; set; }
        public string Tatuador_NumTel { get; set; }
    }
    public class RepositorioTatuador : IRepositorioTatuador
    {
        public IUnidadDeTrabajo UnidadDeTrabajo { get; }
        public RepositorioTatuador(IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.UnidadDeTrabajo = unidadDeTrabajo;
        }
        public void Agregar(Tatuador agregado)
        {
            throw new NotImplementedException();
        }

        public Tatuador ConsultarPorId(Guid idTatuador)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tatuador> ConsultarTodosLosTatuadores()
        {
            List<Tatuador> ListaTatuadores = new();
            try
            {
                CommandDefinition command = new("ConsultarTodosTatuadores", commandTimeout: 0, commandType: System.Data.CommandType.StoredProcedure);
                IEnumerable<DTOTatuador> ListaDTOS = UnidadDeTrabajo.SqlConnection.Query<DTOTatuador>(command);
                if (!ListaDTOS.Any()) throw new ArgumentNullException("No se encontraron tatuadores registrados");
                foreach (var item in ListaDTOS)
                {
                    ListaTatuadores.Add(Tatuador.Crear(item.Tatuador_Id,item.Tatuador_Nombre,CorreoElectronico.Crear(item.Tatuador_Correo),item.Tatuador_NumTel));
                }
            }
            catch (Exception)
            {

                throw;
            }
            return ListaTatuadores;
        }

        public void EliminarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(Tatuador agregado)
        {
            throw new NotImplementedException();
        }
    }
}
