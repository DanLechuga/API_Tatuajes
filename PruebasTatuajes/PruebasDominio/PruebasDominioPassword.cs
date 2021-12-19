using API_DominioTatuajes.ObjetosDeValor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PruebasTatuajes.PruebasDominio
{
   public class PruebasDominioPassword
    {
        [Fact]
        public void Password_CrearPassword_PasswordVacio()
        {
            string FakeContrasenia = "";
            Assert.Throws<ArgumentNullException>(() => { Password fakePassword = Password.Crear(FakeContrasenia); });
            
        }
        [Fact]
        public void Password_CrearPassword_PasswordSinMayuscula()
        {
            string FakeContrasenia = "micontrasena123";
            Assert.Throws<Exception>(() => { Password fakePassword = Password.Crear(FakeContrasenia); });

        }
        [Fact]
        public void Password_CrearPassword_PasswordSinMinuscula()
        {
            string FakeContrasenia = "MICONTRASENA123";
            Assert.Throws<Exception>(() => { Password fakePassword = Password.Crear(FakeContrasenia); });

        }
        [Fact]
        public void Password_CrearPassword_PasswordCompleto()
        {
            string FakeContrasenia = "Micontrasena123";
            Password fakePassword = Password.Crear(FakeContrasenia);
            Assert.NotNull(fakePassword);

        }
        [Fact]
        public void Password_CrearPassword_PasswodExcede50Caracteres()
        {
            string FakePassword = "Mdsakjdhasjhdaskjgdalhldjhsagvldhjs5465494321654654av";

            Assert.Throws<ArgumentOutOfRangeException>(() => { Password fakeobjPassword = Password.Crear(FakePassword); }); 


        }
    } 
}
