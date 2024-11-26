<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tecnico.aspx.cs" Inherits="SegundoExamen.Vistas.Tecnico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>TÉCNICOS  REGISTRADOS</h2>
            <br />
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
            <br />

            Código:
            <asp:TextBox ID="tCodigoTecnico" Type="number" runat="server"></asp:TextBox>
            <br />

            Nombre:
            <asp:TextBox ID="tNombreTecnico" runat="server"></asp:TextBox>
            <br />

            Especialidad:
            <asp:TextBox ID="tEspecialidad" runat="server"></asp:TextBox>
            <br />

            <asp:Button ID="bAgregarTecnico" runat="server" Text="Agregar" OnClick="bAgregarTecnico_Click" />
            <asp:Button ID="bModificarTecnico" runat="server" Text="Modificar" OnClick="bModificarTecnico_Click" />
            <asp:Button ID="bBorrarTecnico" runat="server" Text="Borrar" OnClick="bBorrarTecnico_Click" />
        </div>
    </form>
</body>
</html>
