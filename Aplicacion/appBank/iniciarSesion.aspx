﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="iniciarSesion.aspx.cs" Inherits="iniciarSesion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="./Estilos/estilo.css">
    <link rel="stylesheet" href="./Estilos/fontello.css">
    <title>Pagina de Inicio</title>
</head>
<body background ="/imagenes/inicio.jpg">
   <form id="form1" runat="server">
        <h2>INICIO DE SESION</h2>
            <asp:TextBox class ="cajadeTexto" ID="correoUsuario" runat="server" placeholder ="Correo electronico" required TextMode="Email"></asp:TextBox>
            <asp:TextBox class ="cajadeTexto" ID="contraseñaUsuario" runat="server" placeholder ="Contraseña" required TextMode="Password"></asp:TextBox>
            <a href="RecuperarContraseña.aspx"><font color="#fff">¿Olvidaste tu contraseña?</a><br/>
            &nbsp;<asp:Button class ="cajadeTexto" ID="boton" runat="server" Text="Ingresar" OnClick="boton_Click" Font-Strikeout="False" />
            <asp:Label ID="Error" runat="server" Text="" cssclass="Error"></asp:Label><!-- <br/>&nbsp;-->
            <a href="CrearUsuario.aspx"><font color="#fff" size ="3.5px">Crear cuenta >></a>
            
    </form>
</body>
</html>
