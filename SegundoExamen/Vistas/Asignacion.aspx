<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Asignacion.aspx.cs" Inherits="SegundoExamen.Vistas.Asignacion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>ASIGNACIONES</h2>
            <br />
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
            <br />

            Código:
            <asp:TextBox ID="tCodigoAsingnacion" Type="number" runat="server"></asp:TextBox>
            <br />

            Código de la reparación:
            <asp:TextBox ID="tCodigoReparacion" Type="number" runat="server"></asp:TextBox>
            <br />

            Código del técnico:
            <asp:TextBox ID="tCodigoTecnico" Type="number" runat="server"></asp:TextBox>
            <br />

            Código del técnico:
            <asp:TextBox ID="tFechaAsignacion" Type="date" runat="server"></asp:TextBox>
            <br />

            <asp:Button ID="bAgregarAsignacion" runat="server" Text="Agregar" OnClick="bAgregarAsignacion_Click" />
            <asp:Button ID="bModificarAsigncion" runat="server" Text="Modificar" OnClick="bModificarAsignacion_Click" />
            <asp:Button ID="bBorrarAsignacion" runat="server" Text="Borrar" OnClick="bBorrarAsignacion_Click" />
        </div>
    </form>
</body>
</html>
