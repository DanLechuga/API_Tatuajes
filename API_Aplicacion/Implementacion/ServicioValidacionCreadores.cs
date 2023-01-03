﻿using API_Aplicacion.DTOs;
using API_Aplicacion.Interfaces;
using API_DominioTatuajes.Agregados;
using API_Infraestructura.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Aplicacion.Implementacion
{
    public class ServicioValidacionCreadores : IServicioValidacionCreadores
    {
        public IRepositorioCreador RepositorioCreador { get; set; }
        public ServicioValidacionCreadores(IRepositorioCreador repositorioCreador)
        {
            this.RepositorioCreador = repositorioCreador;
        }
        public DTOCreador ConsultarInfoCreador(DTOCreador dTOCreador)
        {
            if (dTOCreador is null) throw new Exception("No se puede usar valores nulos");
            Creador creador = null;
            if (!string.IsNullOrEmpty(dTOCreador.CorreoCreador))
                creador = RepositorioCreador.ConsultarPorCorreo(dTOCreador.CorreoCreador);

            if (Guid.Empty != dTOCreador.IdCreador)
                creador = RepositorioCreador.ConsultarPorId(dTOCreador.IdCreador);
            if(creador is null) throw new Exception($"No se pudo consultar informacion para el correo ingresado: {dTOCreador.CorreoCreador}");
            return new DTOCreador { CorreoCreador = creador.CreadorCorreo,IdCreador = creador.Id,NombreCreador = creador.CreadorNombre,TelefonoCreador = creador.CreadorTelefono};
        }
    }
}
