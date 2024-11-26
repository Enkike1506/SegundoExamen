<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reparacion.aspx.cs" Inherits="SegundoExamen.Vistas.Reparacion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>REAPARACIONES DE LOS EQUIPOS</h2>
            <br />
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
            <br />

            Código:
            <asp:TextBox ID="tCodigoReparacion" Type="number" runat="server"></asp:TextBox>
            <br />

            Código del equipo:
            <asp:TextBox ID="tCodigoEquipo" Type="number" runat="server"></asp:TextBox>
            <br />

            Fecha de la solicitud:
            <asp:TextBox ID="tFechaSolicitud" Type="Date" runat="server"></asp:TextBox>
            <br />

            Estado:
            <asp:TextBox ID="tEstado" runat="server"></asp:TextBox>
            <br />

            <asp:Button ID="bAgregarReparacion" runat="server" Text="Agregar" OnClick="bAgregarReparacion_Click" />
            <asp:Button ID="bModificarReparacion" runat="server" Text="Modificar" OnClick="bModificarReparacion_Click" />
            <asp:Button ID="bBorrarReparacion" runat="server" Text="Borrar" OnClick="bBorrarReparacion_Click" />
        </div>
    </form>
</body>
</html>
