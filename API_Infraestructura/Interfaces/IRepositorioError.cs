﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Infraestructura.Interfaces
{
   public interface IRepositorioError
    {
        void RegistrarError(string ExceptionMessage,string InnerException, string StackTrace);
    }
}
