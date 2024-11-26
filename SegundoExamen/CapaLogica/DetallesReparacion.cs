using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace SegundoExamen.CapaLogica
{
    public class DetallesReparacion
    {
        public static int AgregarDetalles(int codigoReparacion, string descripcion, string fechaInicio, string fechaFin)
        {
            int retorno = 0;
            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("IngresarDetallesReparacion", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@reparacionId", codigoReparacion));
                    cmd.Parameters.Add(new SqlParameter("@descripcion", descripcion));
                    cmd.Parameters.Add(new SqlParameter("@fechaInicio", fechaInicio));
                    cmd.Parameters.Add(new SqlParameter("@fechaFin", fechaFin));

                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;
        }

        public static int ModificarDetalles(int codigo, int codigoReparacion, string descripcion, string fechaInicio, string fechaFin)
        {
            int retorno = 0;
            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ModificarDetallesReparacion", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@id", codigo));
                    cmd.Parameters.Add(new SqlParameter("@reparacionId", codigoReparacion));
                    cmd.Parameters.Add(new SqlParameter("@descripcion", descripcion));
                    cmd.Parameters.Add(new SqlParameter("@fechaInicio", fechaInicio));
                    cmd.Parameters.Add(new SqlParameter("@fechaFin", fechaFin));

                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;
        }

        public static int BorrarDetalles(int codigo)
        {
            int retorno = 0;
            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("BorrarDetallesReparacion", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@id", codigo));

                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;
        }
    }
}