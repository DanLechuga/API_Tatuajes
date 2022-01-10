using API_DominioTatuajes.Agregados;
using API_Infraestructura.Interfaces;
using System;
using System.Collections.Generic;

namespace PruebasTatuajes
{
    public class MockRepositorioCita : IRepositorioCita
    {
        public List<Cita> ListaCitas { get; set; }
        public MockRepositorioCita()
        {
            ListaCitas = new();
            ListaCitas.Add(Cita.Crear(Guid.Parse("00000000-0000-0000-0000-000000000001"),DateTime.Parse("23/02/2022"), DateTime.MinValue,DateTime.MinValue));
            ListaCitas.Add(Cita.Crear(Guid.Parse("00000000-0000-0000-0000-000000000002"), DateTime.Parse("15/05/2022"), DateTime.MinValue, DateTime.MinValue));
            ListaCitas.Add(Cita.Crear(Guid.Parse("00000000-0000-0000-0000-000000000003"), DateTime.Parse("06/05/2022"), DateTime.MinValue, DateTime.MinValue));
            ListaCitas.Add(Cita.Crear(Guid.Parse("00000000-0000-0000-0000-000000000004"), DateTime.Parse("09/09/2022"), DateTime.MinValue, DateTime.MinValue));

        }
        public IEnumerable<Cita> ConsultaCita(Usuario usuario)
        {
            return ListaCitas;
        }

        public void Agregar(Cita agregado)
        {
            throw new NotImplementedException();
        }

        public void Update(Cita agregado)
        {
            throw new NotImplementedException();
        }

        public void EliminarPorId(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}