using API_DominioTatuajes.Agregados;
using API_DominioTatuajes.ObjetosDeValor;
using API_Infraestructura.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasTatuajes.PruebasInfraestructura
{
    
    public class MockRepositorioUsuario : IRepositorioUsuario
    {
        public static List<Usuario> ListaUsuarios { get; set; }
        public MockRepositorioUsuario()
        {
            ListaUsuarios = new();
            ListaUsuarios.Add(Usuario.CrearUsuarioCliente(Guid.Parse("00000000-0000-0000-0000-000000000001")
                                ,CorreoElectronico.Crear("tester@mail.com")
                                ,Password.Crear("Contraseña123")));
            ListaUsuarios.Add(Usuario.CrearUsuarioCliente(Guid.Parse("00000000-0000-0000-0000-000000000002")
                                , CorreoElectronico.Crear("tester1@mail.com")
                                , Password.Crear("Contaseña123")));
            ListaUsuarios.Add(Usuario.CrearUsuarioTatuador(Guid.Parse("00000000-0000-0000-0000-000000000003")
                                , CorreoElectronico.Crear("tester2@mail.com")
                                , Password.Crear("Contaseña123")));
            ListaUsuarios.Add(Usuario.CrearUsuarioTatuador(Guid.Parse("00000000-0000-0000-0000-000000000004")
                                , CorreoElectronico.Crear("tester3@mail.com")
                                , Password.Crear("Contaseña123")));
        }
        public void Agregar(Usuario agregado)
        {
            if (agregado == null) throw new ArgumentNullException("No se pueden agregar objetos nulos");
            ListaUsuarios.Add(agregado);
        }

        public void EliminarPorId(Guid id)
        {
            Usuario usuarioAEliminar = ListaUsuarios.FirstOrDefault(x => x.Id == id);
            if (usuarioAEliminar != null)
            {
                ListaUsuarios.Remove(usuarioAEliminar);
                return;
            }
            throw new ArgumentNullException("No se pueden eliminar valores nulos");
        }

        public Usuario GetUsuarioPorCorreo(string correo)
        {
            return ListaUsuarios.FirstOrDefault(x => x.UsuarioCorreo.Cadenavalida == correo);
        }

        public Usuario GetUsuarioCliente(Guid id)
        {
            return ListaUsuarios.FirstOrDefault(x => x.Id == id);
            
        }

        public IEnumerable<Usuario> GetUsuarios()
        {
            return ListaUsuarios;
        }

        public void Update(Usuario agregado)
        {
            if (agregado == null) throw new ArgumentNullException("No se puede utilizar valores nulos");
            Usuario usuarioAEliminar = ListaUsuarios.FirstOrDefault(x => x.Id == agregado.Id);
            if(usuarioAEliminar != null) ListaUsuarios.Remove(usuarioAEliminar);
            ListaUsuarios.Add(agregado);
        }
    }
}
