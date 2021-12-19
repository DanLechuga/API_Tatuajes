using API_DominioTatuajes.Agregados;
using API_DominioTatuajes.ObjetosDeValor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PruebasTatuajes.PruebasDominio
{
   public class PruebasDominioCliente
    {
        [Fact]
        public void Cliente_CrearCliente_ClienteConCorreoNulo()
        {
            Guid FakeidCliente = Guid.NewGuid();
            string FakenombreCliente = "tester1";
            CorreoElectronico FakeemailCliente = null;
            Password FakecontraseniaCliente = Password.Crear("MiContraseña");
            string FakenumeroTelCliente = "1234567890";

            Assert.Throws<ArgumentNullException>(() => { Cliente FakeCliente = Cliente.Crear(FakeidCliente,FakenombreCliente,FakeemailCliente,FakecontraseniaCliente,FakenumeroTelCliente); });
            
        }
        [Fact]
        public void Cliente_CrearCliente_ClienteConPasswordNulo()
        {
            Guid FakeidCliente = Guid.NewGuid();
            string FakenombreCliente = "tester1";
            CorreoElectronico FakeemailCliente = CorreoElectronico.Crear("tester@mail.com");
            Password FakecontraseniaCliente = null;
            string FakenumeroTelCliente = "1234567890";

            Assert.Throws<ArgumentNullException>(() => { Cliente FakeCliente = Cliente.Crear(FakeidCliente, FakenombreCliente, FakeemailCliente, FakecontraseniaCliente, FakenumeroTelCliente); });
        }
        [Fact]
        public void Cliente_CrearCliente_ClienteCompleto()
        {
            Guid FakeidCliente = Guid.NewGuid();
            string FakenombreCliente = "tester1";
            CorreoElectronico FakeemailCliente = CorreoElectronico.Crear("tester@mail.com");
            Password FakecontraseniaCliente = Password.Crear("MiContraseña");
            string FakenumeroTelCliente = "1234567890";

             Cliente FakeCliente = Cliente.Crear(FakeidCliente, FakenombreCliente, FakeemailCliente, FakecontraseniaCliente, FakenumeroTelCliente);
            Assert.NotNull(FakeCliente);
        }
    }
}
