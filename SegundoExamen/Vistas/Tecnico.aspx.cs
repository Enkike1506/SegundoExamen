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
    public partial class Tecnico : System.Web.UI.Page
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
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM Tecnicos"))
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

        protected void bAgregarTecnico_Click(object sender, EventArgs e)
        {
            ClsTecnico.Nombre = tNombreTecnico.Text;
            ClsTecnico.Especialidad = tEspecialidad.Text;
            if (Tecnicos.AgregarTecnicos(ClsTecnico.Nombre, ClsTecnico.Especialidad) > 0)
            {
                MostrarAlerta(this, "Técnico ingresado");
                LlenarGrid();
            }
            else
            {
                MostrarAlerta(this, "Error al ingresar el técnico");
            }
        }

        protected void bModificarTecnico_Click(object sender, EventArgs e)
        {
            ClsTecnico.TecnicoID = int.Parse(tCodigoTecnico.Text);
            ClsTecnico.Nombre = tNombreTecnico.Text;
            ClsTecnico.Especialidad = tEspecialidad.Text;
            if (Tecnicos.ModificarTecnicos(ClsTecnico.TecnicoID, ClsTecnico.Nombre, ClsTecnico.Especialidad) > 0)
            {
                MostrarAlerta(this, "Técnico modificado");
                LlenarGrid();
            }
            else
            {
                MostrarAlerta(this, "Error al modificar el técnico");
            }
        }

        protected void bBorrarTecnico_Click(object sender, EventArgs e)
        {
            ClsTecnico.TecnicoID = int.Parse(tCodigoTecnico.Text);
            if (Tecnicos.BorrarTecnicos(ClsTecnico.TecnicoID) > 0)
            {
                MostrarAlerta(this, "Técnico eliminado");
                LlenarGrid();
            }
            else
            {
                MostrarAlerta(this, "Error al eliminar el técnico");
            }
        }
    }
}