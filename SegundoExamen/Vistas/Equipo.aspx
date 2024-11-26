<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Equipo.aspx.cs" Inherits="SegundoExamen.Vistas.Equipo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>EQUIPOS DE LOS USUARIOS</h2>
            <br />
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
            <br />

            Código:
            <asp:TextBox ID="tCodigoEquipo" Type="number" runat="server"></asp:TextBox>
            <br />

            Tipo de equipo:
            <asp:TextBox ID="tTipoEquipo" runat="server"></asp:TextBox>
            <br />

            Modelo del equipo:
            <asp:TextBox ID="tModelo" runat="server"></asp:TextBox>
            <br />

            Código del usuario:
            <asp:TextBox ID="tCodigoUsuario" Type="number" runat="server"></asp:TextBox>
            <br />

            <asp:Button ID="bAgregarEquipo" runat="server" Text="Agregar" OnClick="bAgregarEquipo_Click" />
            <asp:Button ID="bModificarEquipo" runat="server" Text="Modificar" OnClick="bModificarEquipo_Click" />
            <asp:Button ID="bBorrarEquipo" runat="server" Text="Borrar" OnClick="bBorrarEquipo_Click" />
        </div>
    </form>
</body>
</html>
