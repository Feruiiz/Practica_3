<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Inicio.aspx.cs" Inherits="appBank_Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="./Estilos/estilo.css">
    <link rel="stylesheet" href="./Estilos/fontello.css"> 
    <title>Inicio</title>
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
                    <li><a><span class="icon-left-open"></span>Ver Historial</a></li>
                    <li><a href="perfilUsuario.aspx">Perfil de Usuario</a></li>
                    <li><a href="solicitudPrestamo.aspx">Solicitud de prestamo</a></li>
                    <li><a href="trasferenciaCuentas.aspx">Transferencias</a></li>
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
        <h2>Bienvenido</h2>
        <asp:Label  class="nomusu" ID="name_user" runat="server" ></asp:Label>
        </br>
        </br>
        <h2>Información Cuenta</h2>
        <asp:Label CssClass="cajadeTexto" ID="no_cuenta" runat="server" ForeColor="White" Text ="Numero de cuenta: "></asp:Label>
        </br>
        </br>
        <asp:Label CssClass="cajadeTexto" ID="saldoActual" runat="server" ForeColor="White" Text ="Saldo Actual: "></asp:Label>
        </br>
        </br>
        <asp:Label ID="Error" runat="server" Text="" cssclass="Error"></asp:Label> 
    </form>
</body>
</html>
