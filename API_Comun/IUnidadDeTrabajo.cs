using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Comun
{
   public interface IUnidadDeTrabajo: IDisposable
    {
        public SqlConnection SqlConnection { get; set; }
        public SqlTransaction SqlTransaction { get; set; }
        public SqlCommand SqlCommand { get; set; }
        void SaveChanges();
    }
}
