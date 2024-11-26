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
    public partial class DetalleReparacion : System.Web.UI.Page
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
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM DetallesReparacion"))
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

        protected void bAgregarDetalle_Click(object sender, EventArgs e)
        {
            ClsDetalleReparacion.ReparacionID = int.Parse(tCodigoReparacion.Text);
            ClsDetalleReparacion.Descripcion = tDescripcion.Text;
            ClsDetalleReparacion.FechaInicio = tFechaInicio.Text;
            ClsDetalleReparacion.FechaFin = tFechaFin.Text;
            if (DetallesReparacion.AgregarDetalles(ClsDetalleReparacion.ReparacionID, ClsDetalleReparacion.Descripcion, ClsDetalleReparacion.FechaInicio, ClsDetalleReparacion.FechaFin) > 0)
            {
                MostrarAlerta(this, "Detalle de la reparación ingresado");
                LlenarGrid();
            }
            else
            {
                MostrarAlerta(this, "Error al ingresar el detalle de la reparación");
            }
        }

        protected void bModificarDetalle_Click(object sender, EventArgs e)
        {
            ClsDetalleReparacion.DetalleID = int.Parse(tCodigoDetalle.Text);
            ClsDetalleReparacion.ReparacionID = int.Parse(tCodigoReparacion.Text);
            ClsDetalleReparacion.Descripcion = tDescripcion.Text;
            ClsDetalleReparacion.FechaInicio = tFechaInicio.Text;
            ClsDetalleReparacion.FechaFin = tFechaFin.Text;
            if (DetallesReparacion.ModificarDetalles(ClsDetalleReparacion.DetalleID, ClsDetalleReparacion.ReparacionID, ClsDetalleReparacion.Descripcion, ClsDetalleReparacion.FechaInicio, ClsDetalleReparacion.FechaFin) > 0)
            {
                MostrarAlerta(this, "Detalle de la reparación modificado");
                LlenarGrid();
            }
            else
            {
                MostrarAlerta(this, "Error al modificar el detalle de la reparación");
            }
        }

        protected void bBorrarDetalle_Click(object sender, EventArgs e)
        {
            ClsDetalleReparacion.DetalleID = int.Parse(tCodigoDetalle.Text);
            if (DetallesReparacion.BorrarDetalles(ClsDetalleReparacion.DetalleID) > 0)
            {
                MostrarAlerta(this, "Detalle de la reparación eliminado");
                LlenarGrid();
            }
            else
            {
                MostrarAlerta(this, "Error al eliminar el detalle de la reparación");
            }
        }
    }
}