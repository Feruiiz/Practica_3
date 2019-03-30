<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CrearUsuario.aspx.cs" Inherits="CrearUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="./Estilos/estilo.css">
    <link rel="stylesheet" href="./Estilos/fontello.css"> 
    <title>Crear Usuario</title>
</head>
<body background="/imagenes/CrearUsuario.jpg">
    <form id="form3" runat="server">
        <h2>CREAR USUARIO</h2>
            <asp:TextBox class ="cajadeTexto" ID="nombre" runat="server" placeholder ="Nombre" required></asp:TextBox>
            <asp:TextBox class ="cajadeTexto" ID="nickname" runat="server" placeholder ="Nickname" required></asp:TextBox>
            <asp:TextBox class ="cajadeTexto" ID="correo" runat="server" placeholder ="Correo electronico" required TextMode="Email"></asp:TextBox>
            <asp:Label ID="Error" runat="server" Text="" cssclass="Error"></asp:Label> 
            
            <asp:TextBox class ="cajadeTexto" ID="pass1" runat="server" placeholder ="Ingrese una contraseña" required TextMode="Password"></asp:TextBox>
            <asp:TextBox class ="cajadeTexto" ID="pass2" runat="server" placeholder ="Confirmar contraseña" required TextMode="Password"></asp:TextBox>
            <asp:Label ID="Error1" runat="server" Text="" cssclass="Error"></asp:Label> 
         
            <!--<input type="button" value="Enviar" id="boton">-->
            <asp:Button class ="cajadeTexto" ID="boton" runat="server" Text="Agregar nuevo usuario" OnClick="boton_Click" />
            <a href="iniciarSesion.aspx"><font color="#fff"><span class="icon-left-open"></span>Volver al Login</a>
    </form>
</body>
</html>

