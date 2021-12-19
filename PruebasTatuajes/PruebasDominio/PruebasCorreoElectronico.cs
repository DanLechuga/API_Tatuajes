using API_DominioTatuajes.ObjetosDeValor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PruebasTatuajes.PruebasDominio
{
   public class PruebasCorreoElectronico
    {
        [Fact]
        public void CorreoElectronico_CrearCorreoElectronico_CorreoElectronicoVacio()
        {
            string FakeCorreoElectronico = "";
            Assert.Throws<ArgumentNullException>(() => { CorreoElectronico FakeCorreoE = CorreoElectronico.Crear(FakeCorreoElectronico); }); 
            
        }
        [Fact]
        public void CorreoElectronico_CrearCorreoElectronico_CorreoElectronicoSinArroba()
        {
            string FakeCorreoElectronico = "testermail.com";
            Assert.Throws<Exception>(() => { CorreoElectronico FakeCorreoE = CorreoElectronico.Crear(FakeCorreoElectronico); }); 
                       
        }
        [Fact]
        public void CorreoElectronico_CrearCorreoElectronico_CorreoElectronicoSinPunto()
        {
            string FakeCorreoElectronico = "tester@mailcom";
            Assert.Throws<Exception>(() => { CorreoElectronico FakeCorreoE = CorreoElectronico.Crear(FakeCorreoElectronico); });
        }
        [Fact]
        public void CorreoElectronico_CrearCorreoElectronico_CorreoElectronicoCompleto()
        {
            string FakeCorreoElectronico = "tester@mail.com";
            CorreoElectronico FakeCorreoE = CorreoElectronico.Crear(FakeCorreoElectronico);
            Assert.NotNull(FakeCorreoE);
            
        }
    }
}
