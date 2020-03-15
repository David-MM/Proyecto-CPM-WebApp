<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ventas.aspx.cs" Inherits="Menusito.Views.Requisicion.Ventas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="Panel1" runat="server">
                <asp:DropDownList ID="ClienteDrop" runat="server" Height="16px" Width="182px">
                </asp:DropDownList>
                <asp:DropDownList ID="ProductoDrop" runat="server" Height="20px" Width="217px">
                </asp:DropDownList>
                <asp:DropDownList ID="BodegaDrop" runat="server" Height="16px" Width="231px">
                </asp:DropDownList>
                <asp:TextBox ID="txtFechaVencimiento" runat="server" Height="22px" Width="181px"></asp:TextBox>
                <asp:TextBox ID="txtPrecio" runat="server" Height="22px" Width="181px"></asp:TextBox>
                <asp:TextBox ID="txtCantidad" runat="server" Height="22px" Width="181px"></asp:TextBox>
                <asp:TextBox ID="txtISV" runat="server" Height="22px" Width="181px"></asp:TextBox>
                <asp:Button ID="btnAgregar" runat="server" Text="+" />
                <br />
                <br />
            </asp:Panel>
        </div>
    </form>
</body>
</html>
