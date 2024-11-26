using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SegundoExamen.CapaLogica;
using SegundoExamen.CapaModelo;

namespace SegundoExamen.Vistas
{
    public partial class Reparacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LlenarGrid();
        }
        public static void MostrarAlerta(Page page, string message)
        {
            string script = $"<script type='text/javascript'>alert('{message}');</script>";
            ClientScriptManager cs = page.ClientScript;
            cs.RegisterStartupScript(page.GetType(), "AlertScript", script);
        }

        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM Reparaciones"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                        }
                    }
                }
            }
        }

        protected void bAgregarReparacion_Click(object sender, EventArgs e)
        {
            ClsReparacion.EquipoID = int.Parse(tCodigoEquipo.Text);
            ClsReparacion.FechaSolicitud = tFechaSolicitud.Text;
            ClsReparacion.Estado = tEstado.Text;
            if (Reparaciones.AgregarReparaciones(ClsReparacion.EquipoID, ClsReparacion.FechaSolicitud, ClsReparacion.Estado) > 0)
            {
                MostrarAlerta(this, "Reparación ingresada");
                LlenarGrid();
            }
            else
            {
                MostrarAlerta(this, "Error al ingresar la reparación");
            }
        }

        protected void bModificarReparacion_Click(object sender, EventArgs e)
        {
            ClsReparacion.ReparacionID = int.Parse(tCodigoReparacion.Text);
            ClsReparacion.EquipoID = int.Parse(tCodigoEquipo.Text);
            ClsReparacion.FechaSolicitud = tFechaSolicitud.Text;
            ClsReparacion.Estado = tEstado.Text;
            if (Reparaciones.ModificarReparaciones(ClsReparacion.ReparacionID, ClsReparacion.EquipoID, ClsReparacion.FechaSolicitud, ClsReparacion.Estado) > 0)
            {
                MostrarAlerta(this, "Reparación modificada");
                LlenarGrid();
            }
            else
            {
                MostrarAlerta(this, "Error al modificar la reparación");
            }
        }

        protected void bBorrarReparacion_Click(object sender, EventArgs e)
        {
            ClsReparacion.ReparacionID = int.Parse(tCodigoReparacion.Text);
            if (Reparaciones.BorrarReparacion(ClsReparacion.ReparacionID) > 0)
            {
                MostrarAlerta(this, "Reparación eliminada");
                LlenarGrid();
            }
            else
            {
                MostrarAlerta(this, "Error al eliminar la reparación");
            }
        }
    }
}