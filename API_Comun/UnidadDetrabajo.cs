using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace API_Comun
{
    public class UnidadDetrabajo : IUnidadDeTrabajo
    {
        private bool isDisposed;
        private IntPtr nativeResource = Marshal.AllocHGlobal(100);

        public UnidadDetrabajo(string conexion)
        {
            this.SqlConnection = new SqlConnection(conexion);
            this.SqlCommand = new SqlCommand("", this.SqlConnection);

        }

        public SqlConnection SqlConnection { get; set; }
        public SqlTransaction SqlTransaction { get; set; }
        public SqlCommand SqlCommand { get; set; }
        protected virtual void Dispose(bool disposing)
        {
            if (isDisposed) return;

            if (disposing)
            {
                // free managed resources
                SqlConnection.Dispose();
            }

            // free native resources if there are any.
            if (nativeResource != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(nativeResource);
                nativeResource = IntPtr.Zero;
            }

            isDisposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void SaveChanges()
        {
            this.SqlTransaction = SqlConnection.BeginTransaction();
            this.SqlTransaction.Commit();
        }
    }

}
