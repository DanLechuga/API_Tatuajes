using API_Comun;
using API_DominioTatuajes.Agregados;
using API_Infraestructura.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using API_DominioTatuajes.ObjetosDeValor;

namespace API_Infraestructura.Repositorios
{
     class DTOCliente
    {
        public Guid Cliente_id { get; set; }
        public string Cliente_nombre { get; set; }
        public string Cliente_correo { get; set; }
        public string Cliente_numeroTel { get; set; }
        public string Cliente_password { get; set; }
    }
    public class RepositorioCliente : IRepositorioCliente
    {
        public IUnidadDeTrabajo UnidadDeTrabajo { get; }
        public RepositorioCliente(IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.UnidadDeTrabajo = unidadDeTrabajo;
        }

        public IEnumerable<Cliente> GetClientes()
        {
            throw new NotImplementedException();
        }

        public Cliente GetClientePorId(Guid id)
        {
            Cliente cliente = null;
            try
            {
                DynamicParameters parameters = new();
                parameters.Add("@idCliente", id,System.Data.DbType.Guid);
                CommandDefinition command = new("ConsultaInformacionClientePorId", parameters,commandType:System.Data.CommandType.StoredProcedure,commandTimeout: 0);
                DTOCliente clienteConsultado = UnidadDeTrabajo.SqlConnection.QueryFirstOrDefault<DTOCliente>(command);
                if (clienteConsultado == null) throw new ArgumentNullException("No se encontro cliente para el id ingresado");
                cliente = Cliente.Crear(clienteConsultado.Cliente_id,clienteConsultado.Cliente_nombre,CorreoElectronico.Crear(clienteConsultado.Cliente_correo),Password.Crear(clienteConsultado.Cliente_password),clienteConsultado.Cliente_numeroTel);

            }
            catch (Exception)
            {

                throw;
            }
            return cliente;
        }

        public void Agregar(Cliente agregado)
        {
            throw new NotImplementedException();
        }

        public void Update(Cliente agregado)
        {
            throw new NotImplementedException();
        }

        public void EliminarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Cliente GetClintePorCorreo(string correoElectronico)
        {
            if (string.IsNullOrEmpty(correoElectronico)) throw new ArgumentNullException("No se puede utilizar valores vacios o nulos");
            try
            {
                Cliente clienteConsultado = null;
                DynamicParameters parameters = new();
                parameters.Add("@correo", correoElectronico, System.Data.DbType.String);
                CommandDefinition command = new("ConsultarClientePorCorreo", parameters, commandTimeout: 0, commandType: System.Data.CommandType.StoredProcedure);
                DTOCliente DtoCliente = UnidadDeTrabajo.SqlConnection.QueryFirstOrDefault<DTOCliente>(command);
                if (DtoCliente == null) throw new ArgumentNullException("No se encontro registro para correo ingresado");
                clienteConsultado = Cliente.Crear(DtoCliente.Cliente_id,DtoCliente.Cliente_nombre,CorreoElectronico.Crear(DtoCliente.Cliente_correo),Password.Crear(DtoCliente.Cliente_password),DtoCliente.Cliente_numeroTel);
                return clienteConsultado;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
