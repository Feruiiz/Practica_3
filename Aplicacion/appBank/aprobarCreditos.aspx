<%@ Page Language="C#" AutoEventWireup="true" CodeFile="aprobarCreditos.aspx.cs" Inherits="appBank_aprobarCreditos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="./Estilos/estilo.css">
    <link rel="stylesheet" href="./Estilos/fontello.css"> 
    <title>Transferencia</title>
</head>
<body background="/imagenes/inicio2.jpg">
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

        <h2>Solicitud de Créditos</h2>

            
            <asp:DropDownList class ="cajadeTexto" ID="listaPrestamos" runat="server" AutoPostBack="True">
            </asp:DropDownList>
           <asp:Button class ="cajadeTexto" ID="btn_solicitud" runat="server" Text="Ver solicitud" OnClick="verSolicitud_click" />
            <asp:Label CssClass="cajadeTexto" ID="id_solicitud" runat="server" ForeColor="White" Text ="Solicitud No: "></asp:Label>            
        <asp:Label CssClass="cajadeTexto" ID="no_solicitud" runat="server" ForeColor="White" Text =""></asp:Label>            
            </br>
            </br>
            <asp:Label CssClass="cajadeTexto" ID="cliente" runat="server" ForeColor="White" Text ="Cliente: "></asp:Label>
            </br>
            </br>
            <asp:Label CssClass="cajadeTexto" ID="lbl_descrip" runat="server" ForeColor="White" Text ="Descripcion: "></asp:Label>
            <asp:TextBox class ="cajacomentario" ID="descripcion" runat="server" placeholder ="Descripcion..." TextMode="MultiLine"></asp:TextBox>
            </br>
            </br>
            <asp:Label CssClass="cajadeTexto" ID="monto" runat="server" ForeColor="White" Text ="Monto: "></asp:Label>
            </br>
            </br>
            <asp:Label ID="Error" runat="server" Text="" cssclass="Error"></asp:Label> 
         
            <!--<input type="button" value="Enviar" id="boton">-->
            <asp:Button class ="cajadeTexto" ID="btn_aceptar" runat="server" Text="Aceptar Crédito" OnClick="acept_credito_click" />
        <asp:Button class ="cajadeTexto" ID="btn_rechazar" runat="server" Text="Rechazar Crédito" OnClick="rech_credito_click" />
           
    </form>
</body>
</html>
