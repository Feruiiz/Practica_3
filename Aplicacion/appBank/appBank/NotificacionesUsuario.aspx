<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NotificacionesUsuario.aspx.cs" Inherits="appBank.NotificacionesUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="./Estilos/estilo.css">
    <link rel="stylesheet" href="./Estilos/fontello.css"> 
    <title>Notificaciones</title>
</head>
<body>
    <header>
           <div class="contenedor">
                <h1 class="icon-spin3">BANK</h1>
                <input type="checkbox" id="menu-bar">
                <label class="icon-cog" id="md" for="menu-bar"></label>
                <asp:Label  class="nomusu" ID="nombre_usuario" runat="server"></asp:Label>
                <!--ahora agregaremos el menu-->
                <nav class="menu">
                <ul class="nav">
                    <li><a href="NotificacionesUsuario.aspx">Ver Notificaciones</a></li>
                    <li><a href="">Ver Historial</a></li>
                    <li><a href="perfilUsuario.aspx">Perfil de Usuario</a></li>
                    <li><a href="transferenciaCuentas.aspx">Transferencias Bancarias</a></li>
                    <li><a href="inicio.aspx">ir a Inicio</a></li>
                    <li><a href="iniciarSesion.aspx">Salir del Sistema</a></li>
                  </ul>
                  </nav>
                <!--ahora agregaremos el menu-->
             </div>
     </header>
     <form id="form3" runat="server">
         <asp:Button class ="cajadeTexto" ID="btn_aceptar" runat="server" Text="Marcar Como Leídas" OnClick="marcar_leidas" />
    </form>
</body>
</html>
