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
   public class PruebasDominioTatuador
    {
        [Fact]
        public void Tatuador_CrearTatuador_TatuadorConCorreoNulo()
        {

            CorreoElectronico fakeEmail = null;
            string fakenumero = "1234567890";
            Guid FakeIdTatuador = Guid.NewGuid();
            string fakeNombre = "tester";
            Assert.Throws<ArgumentNullException>(() => { Tatuador fakeTatuador = Tatuador.Crear(FakeIdTatuador,fakeNombre,fakeEmail,fakenumero); });
        } 
        [Fact]
        public void Tatuador_CrearTatuador_TatuadorConNumeroExcedentea12Caracteres()
        {
            string fakeCorreo = "tester@mail.com";
            CorreoElectronico fakeEmail = CorreoElectronico.Crear(fakeCorreo);
            Guid FakeIdTatuador = Guid.NewGuid();
            string fakeNombre = "tester";
            string fakenumero = "123456789101112";
            Assert.Throws<ArgumentOutOfRangeException>(() => { Tatuador fakeTatuador = Tatuador.Crear(FakeIdTatuador,fakeNombre,fakeEmail,fakenumero); });
        }
        [Fact]
        public void Tatuador_CrearTatuador_TatuadorConNumeroVacio()
        {
            string fakeCorreo = "tester@mail.com";
            CorreoElectronico fakeEmail = CorreoElectronico.Crear(fakeCorreo);
            Guid FakeIdTatuador = Guid.NewGuid();
            string fakeNombre = "tester";
            string fakenumero = "";
            Assert.Throws<ArgumentNullException>(() => { Tatuador fakeTatuador = Tatuador.Crear(FakeIdTatuador, fakeNombre, fakeEmail, fakenumero); });
        }
        [Fact]
        public void Tatuador_CrearTatuador_TatuadorConNumeroConEspacioEnBlanco()
        {
            string fakeCorreo = "tester@mail.com";
            CorreoElectronico fakeEmail = CorreoElectronico.Crear(fakeCorreo);
            Guid FakeIdTatuador = Guid.NewGuid();
            string fakeNombre = "tester";
            string fakenumero = " ";
            Assert.Throws<ArgumentNullException>(() => { Tatuador fakeTatuador = Tatuador.Crear(FakeIdTatuador, fakeNombre, fakeEmail, fakenumero); });
        }
        [Fact]
        public void Tatuador_CrearTatuador_UnNuevoTatuador()
        {
            string fakeCorreo = "tester@mail.com";
            CorreoElectronico fakeEmail = CorreoElectronico.Crear(fakeCorreo);
            Guid FakeIdTatuador = Guid.NewGuid();
            string fakeNombre = "tester";
            string fakenumero = "1234567891";
            Tatuador fakeTatuador = Tatuador.Crear(FakeIdTatuador, fakeNombre, fakeEmail, fakenumero);
            Assert.NotNull(fakeTatuador);
        }
    }
}
