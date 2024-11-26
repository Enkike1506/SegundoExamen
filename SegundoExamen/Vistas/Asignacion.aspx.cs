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
    public partial class Asignacion : System.Web.UI.Page
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
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM Asignaciones"))
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

        protected void bAgregarAsignacion_Click(object sender, EventArgs e)
        {
            ClsAsignacion.RepracionID = int.Parse(tCodigoReparacion.Text);
            ClsAsignacion.TecnicoID = int.Parse(tCodigoTecnico.Text);
            ClsAsignacion.FechaAsignacion = tFechaAsignacion.Text;
            if (Asignaciones.AgregarAsignaciones(ClsAsignacion.RepracionID, ClsAsignacion.TecnicoID, ClsAsignacion.FechaAsignacion) > 0)
            {
                MostrarAlerta(this, "Asignación ingresada");
                LlenarGrid();
            }
            else
            {
                MostrarAlerta(this, "Error al ingresar la asignación");
            }
        }

        protected void bModificarAsignacion_Click(object sender, EventArgs e)
        {
            ClsAsignacion.AsignacionID = int.Parse(tCodigoAsingnacion.Text);
            ClsAsignacion.RepracionID = int.Parse(tCodigoReparacion.Text);
            ClsAsignacion.TecnicoID = int.Parse(tCodigoTecnico.Text);
            ClsAsignacion.FechaAsignacion = tFechaAsignacion.Text;
            if (Asignaciones.ModificarAsignaciones(ClsAsignacion.AsignacionID, ClsAsignacion.RepracionID, ClsAsignacion.TecnicoID, ClsAsignacion.FechaAsignacion) > 0)
            {
                MostrarAlerta(this, "Asignación modificada");
                LlenarGrid();
            }
            else
            {
                MostrarAlerta(this, "Error al modificar la asignación");
            }
        }

        protected void bBorrarAsignacion_Click(object sender, EventArgs e)
        {
            ClsAsignacion.AsignacionID = int.Parse(tCodigoAsingnacion.Text);
            if (Asignaciones.BorrarAsignaciones(ClsAsignacion.AsignacionID) > 0)
            {
                MostrarAlerta(this, "Asignación eliminada");
                LlenarGrid();
            }
            else
            {
                MostrarAlerta(this, "Error al eliminar la asignación");
            }
        }
    }
}