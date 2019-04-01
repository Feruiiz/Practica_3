<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Debitos.aspx.cs" Inherits="appBank.Debitos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="./Estilos/estilo.css">
    <link rel="stylesheet" href="./Estilos/fontello.css"> 
    <title>Transferencia</title>
</head>
<body background="./imagenes/AgregarProfesion.jpg">
    <header>
           <div class="contenedor">
                <h1 class="icon-spin3">BANK</h1>
                <input type="checkbox" id="menu-bar">
                <label class="icon-cog" id="md" for="menu-bar"></label>
                <asp:Label  class="nomusu" ID="nombre_usuario" runat="server"></asp:Label>
                <!--ahora agregaremos el menu-->
                <nav class="menu">
                <ul class="nav">
                    <li><a href ="aprobarCreditos.aspx">Aprobar creditos</a></li>
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
        <h2>DEBITOS BANCARIOS</h2>
            
            <asp:TextBox class ="cajadeTexto" ID="cuenta" runat="server" placeholder ="Ingrese el numero de cuenta" required></asp:TextBox>
            <asp:TextBox class ="cajadeTexto" ID="monto" runat="server" placeholder ="Ingrese el monto" required></asp:TextBox>
            <asp:TextBox class ="cajacomentario" ID="descripcion" runat="server" placeholder ="Escriba aqui la descripcion" required TextMode="MultiLine"></asp:TextBox>
            
            <asp:Label ID="Error" runat="server" Text="" cssclass="Error"></asp:Label> 
         
            <!--<input type="button" value="Enviar" id="boton">-->
            <asp:Button class ="cajadeTexto" ID="boton" runat="server" Text="Realizar transferencia" OnClick="boton_Click" />
           
    </form>
</body>
</html>