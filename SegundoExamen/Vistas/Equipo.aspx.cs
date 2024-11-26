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
    public partial class Equipo : System.Web.UI.Page
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
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM Equipos"))
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

        protected void bAgregarEquipo_Click(object sender, EventArgs e)
        {
            ClsEquipo.TipoEquipo = tTipoEquipo.Text;
            ClsEquipo.Modelo = tModelo.Text;
            ClsEquipo.UsuarioID = int.Parse(tCodigoUsuario.Text);
            if (Equipos.AgregarEquipos(ClsEquipo.TipoEquipo, ClsEquipo.Modelo, ClsEquipo.UsuarioID) > 0)
            {
                MostrarAlerta(this, "Equipo ingresado");
                LlenarGrid();
            }
            else
            {
                MostrarAlerta(this, "Error al ingresar el equipo");
            }
        }

        protected void bModificarEquipo_Click(object sender, EventArgs e)
        {
            ClsEquipo.EquipoID = int.Parse(tCodigoEquipo.Text);
            ClsEquipo.TipoEquipo = tTipoEquipo.Text;
            ClsEquipo.Modelo = tModelo.Text;
            ClsEquipo.UsuarioID = int.Parse(tCodigoUsuario.Text);
            if (Equipos.ModificarEquipos(ClsEquipo.EquipoID, ClsEquipo.TipoEquipo, ClsEquipo.Modelo, ClsEquipo.UsuarioID) > 0)
            {
                MostrarAlerta(this, "Equipo modificado");
                LlenarGrid();
            }
            else
            {
                MostrarAlerta(this, "Error al modificar el equipo");
            }
        }

        protected void bBorrarEquipo_Click(object sender, EventArgs e)
        {
            ClsEquipo.EquipoID = int.Parse(tCodigoEquipo.Text);
            if (Equipos.BorrarEquipos(ClsEquipo.EquipoID) > 0)
            {
                MostrarAlerta(this, "Equipo eliminado");
                LlenarGrid();
            }
            else
            {
                MostrarAlerta(this, "Error al eliminar el equipo");
            }
        }
    }
}