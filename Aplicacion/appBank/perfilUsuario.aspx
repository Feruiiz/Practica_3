<%@ Page Language="C#" AutoEventWireup="true" CodeFile="perfilUsuario.aspx.cs" Inherits="appBank_perfilUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="./Estilos/estilo.css">
    <link rel="stylesheet" href="./Estilos/fontello.css"> 
    <title>Transferencia</title>
</head>
<body background="./imagenes/perfil.jpg">
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
                    <li><a href="transferenciaCuentas.aspx">Transferencias Bancarias</a></li>
                    <li><a href="solicitudPrestamo.aspx">Solicitud de prestamo</a></li>
                    <li><a href="inicio.aspx">ir a Inicio</a></li>
                    <li><a href="iniciarSesion.aspx">Salir del Sisteme</a></li>
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
        <h2>Perfil de Usuario</h2>
            
            <asp:TextBox class ="cajadeTexto" ID="nombre" runat="server" placeholder ="Nombre completo" required></asp:TextBox>
            <asp:TextBox class ="cajadeTexto" ID="nickname" runat="server" placeholder ="Nickname" required></asp:TextBox>
            <asp:TextBox class ="cajadeTexto" ID="correo" runat="server" placeholder ="Correo electronico" required></asp:TextBox>
            
            <asp:TextBox class ="cajadeTexto" ID="pass" runat="server" placeholder ="Ingrese su contraseña actual" required TextMode="Password"></asp:TextBox>
            <asp:Label ID="Error" runat="server" Text="" cssclass="Error"></asp:Label> 
         
            <!--<input type="button" value="Enviar" id="boton">-->
            <asp:Button class ="cajadeTexto" ID="boton" runat="server" Text="Guardar cambios" OnClick="boton_Click" />
           
    </form>
</body>
</html>
