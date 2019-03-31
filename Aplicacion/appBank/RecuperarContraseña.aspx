<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RecuperarContraseña.aspx.cs" Inherits="RecuperarContraseña" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="./Estilos/estilo.css">
    <link rel="stylesheet" href="./Estilos/fontello.css"> 
    <title>Recuperar Contraseña</title>
</head>
<body background ="./imagenes/RecuperarContraseña.png">
    <form id="form1" runat="server">
        <h2>RECUPERAR CONTRASEÑA</h2>
            <p>
            <asp:TextBox class ="cajadeTexto" ID="correo" runat="server" placeholder ="Ingrese su correo electronico" required TextMode="Email"></asp:TextBox>
            <asp:TextBox class ="cajadeTexto" ID="pass1" runat="server" placeholder ="Ingrese nueva Contraseña" required TextMode="password" MaxLength="8"></asp:TextBox>
            <asp:TextBox class ="cajadeTexto" ID="pass2" runat="server" placeholder ="Confirmar contraseña" required TextMode="password" MaxLength="8"></asp:TextBox>
            <!--<input type="button" value="Enviar" id="boton">-->
            <asp:Button class ="cajadeTexto" ID="boton" runat="server" Text="Recuperar contraseña" OnClick="boton_Click" />
            <asp:Label ID="Error2" runat="server" Text="" cssclass="Error"></asp:Label>
                </br>
            <a href="iniciarSesion.aspx"><font color="#fff"><span class="icon-left-open"></span>Volver al Login</a>
    </form>
</body>
</html>
