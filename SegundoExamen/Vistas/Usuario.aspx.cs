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
    public partial class Usuario : System.Web.UI.Page
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
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM Usuarios"))
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

        protected void bAgregarUsuario_Click(object sender, EventArgs e)
        {
            ClsUsuario.Nombre = tNombreUsuario.Text;
            ClsUsuario.CorreoElectronico = tCorreoElectronico.Text;
            ClsUsuario.Telefono = tTelefono.Text;
            if (Usuarios.AgregarUsuarios(ClsUsuario.Nombre, ClsUsuario.CorreoElectronico, ClsUsuario.Telefono) > 0)
            {
                MostrarAlerta(this, "Usuario ingresado");
                LlenarGrid();
            }
            else
            {
                MostrarAlerta(this, "Error al ingresar al usuario");
            }
        }

        protected void bModificarUsuario_Click(object sender, EventArgs e)
        {
            ClsUsuario.UsuarioID = int.Parse(tCodigoUsuario.Text);
            ClsUsuario.Nombre = tNombreUsuario.Text;
            ClsUsuario.CorreoElectronico = tCorreoElectronico.Text;
            ClsUsuario.Telefono = tTelefono.Text;
            if (Usuarios.ModificarUsuarios(ClsUsuario.UsuarioID, ClsUsuario.Nombre, ClsUsuario.CorreoElectronico, ClsUsuario.Telefono) > 0)
            {
                MostrarAlerta(this, "Usuario modificado");
                LlenarGrid();
            }
            else
            {
                MostrarAlerta(this, "Error al modificar al usuario");
            }
        }

        protected void bBorrarUsuario_Click(object sender, EventArgs e)
        {
            ClsUsuario.UsuarioID = int.Parse(tCodigoUsuario.Text);
            if (Usuarios.BorrarUsuarios(ClsUsuario.UsuarioID) > 0)
            {
                MostrarAlerta(this, "Usuario eliminado");
                LlenarGrid();
            }
            else
            {
                MostrarAlerta(this, "Error al eliminar al usuario");
            }
        }
    }
}