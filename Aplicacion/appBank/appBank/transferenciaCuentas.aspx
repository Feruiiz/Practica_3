<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="transferenciaCuentas.aspx.cs" Inherits="appBank.transferenciaCuentas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="./Estilos/estilo.css">
    <link rel="stylesheet" href="./Estilos/fontello.css"> 
    <title>Transferencia</title>
</head>
<body background="./imagenes/AgregarSoftware.jpg">
    <header>
           <div class="contenedor">
                <h1 class="icon-spin3">BANK</h1>
                <input type="checkbox" id="menu-bar">
                <label class="icon-cog" id="md" for="menu-bar"></label>
                <asp:Label  class="nomusu" ID="nombre_usuario" runat="server"></asp:Label>
                <!--ahora agregaremos el menu-->
                <nav class="menu">
                <ul class="nav">
                    <li><a><span class="icon-left-open"></span>Ver Historial</a></li>
                    <li><a href="perfilUsuario.aspx">Perfil de Usuario</a></li>
                    <li><a href="solicitudPrestamo.aspx">Solicitud de prestamo</a></li>
                    <li><a href="inicio.aspx">ir a Inicio</a></li>
                    <li><a href="iniciarSesion.aspx">Salir del Sistema</a></li>
                  </ul>
                  </nav>
                <!--ahora agregaremos el menu-->
             </div>
     </header>


    </br>
    </br>
    </br>
    </br>

    <form id="form3" runat="server">
        <h2>TRANSFERENCIAS BANCARIAS</h2>
            <asp:Label CssClass="cajadeTexto" ID="saldoActual" runat="server" ForeColor="White"></asp:Label>
            <asp:DropDownList class ="cajadeTexto" ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                <asp:ListItem Value="0">Transferir monto a otra cuenta</asp:ListItem>
                <asp:ListItem Value="1">Deposito</asp:ListItem>
                <asp:ListItem Value="2">Retiro</asp:ListItem>
        </asp:DropDownList>
            <asp:TextBox class ="cajadeTexto" ID="cuenta1" runat="server" placeholder ="Cuenta propia numero:" required></asp:TextBox>
            <asp:TextBox class ="cajadeTexto" ID="cuenta2" runat="server" placeholder ="Cuenta destino con numero:" required></asp:TextBox>
            <asp:TextBox class ="cajadeTexto" ID="monto" runat="server" placeholder ="monto" required></asp:TextBox>
            
            <asp:Label ID="Error" runat="server" Text="" cssclass="Error"></asp:Label> 
         
            <!--<input type="button" value="Enviar" id="boton">-->
            <asp:Button class ="cajadeTexto" ID="boton" runat="server" Text="Realizar transferencia" OnClick="boton_Click" />
           
    </form>
</body>
</html>
