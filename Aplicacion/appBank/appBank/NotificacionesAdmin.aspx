<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NotificacionesAdmin.aspx.cs" Inherits="appBank.Notificaciones" %>

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
                    <li><a href="Debitos.aspx">Realizar debitos</a></li>
                    <li><a href="aprobarCreditos.aspx">Aprobar Creditos</a></li>
                    <li><a href="reporteUsuarios.aspx">Ver usuarios</a></li>
                    <li><a href="reporteSolicitudes.aspx">Ver solicitudes</a></li>
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
