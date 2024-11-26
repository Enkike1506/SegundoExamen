<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetalleReparacion.aspx.cs" Inherits="SegundoExamen.Vistas.DetalleReparacion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>DETALLES DE LAS REPARACIONES</h2>
            <br />
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
            <br />

            Código:
            <asp:TextBox ID="tCodigoDetalle" Type="number" runat="server"></asp:TextBox>
            <br />

            Código de la reparacion:
            <asp:TextBox ID="tCodigoReparacion" Type="number" runat="server"></asp:TextBox>
            <br />

            Descripción:
            <asp:TextBox ID="tDescripcion" runat="server"></asp:TextBox>
            <br />

            Fecha de inicio:
            <asp:TextBox ID="tFechaInicio" Type="Date" runat="server"></asp:TextBox>
            <br />

            Fecha de fin:
            <asp:TextBox ID="tFechaFin" Type="Date" runat="server"></asp:TextBox>
            <br />

            <asp:Button ID="bAgregarDetalle" runat="server" Text="Agregar" OnClick="bAgregarDetalle_Click" />
            <asp:Button ID="bModificarDetalle" runat="server" Text="Modificar" OnClick="bModificarDetalle_Click" />
            <asp:Button ID="bBorrarDetalle" runat="server" Text="Borrar" OnClick="bBorrarDetalle_Click" />
        </div>
    </form>
</body>
</html>
