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
            <asp:Label ID="Error3" runat="server" Text="Debe Contener al Menos 1 digito y no ser mayor a 12 caracteres" cssclass="label"></asp:Label> 
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"    
               ErrorMessage="Su NickName no debe ser mayor a 12 caracteres, y contener al menos 1 digitos"
               ControlToValidate="nickname"    
               ValidationExpression="^[a-zA-Z0-9'@&#.\s]{2,12}$" />
            <asp:TextBox class ="cajadeTexto" ID="correo" runat="server" placeholder ="Correo electronico" required TextMode="Email"></asp:TextBox>
            <asp:Label ID="Error" runat="server" Text="" cssclass="labels"></asp:Label> 
            
            <asp:TextBox ValidationExpression="^[a-zA-Z0-9'@&#.\s]{8}$" class ="cajadeTexto" ID="pass1" runat="server" placeholder ="Ingrese una contraseña de 8 caracteres exactos" required  TextMode="Password"></asp:TextBox>
            <asp:Label ID="Error1" runat="server" Text="" cssclass="Error"></asp:Label> 
            <asp:RegularExpressionValidator ID="RegExp1" runat="server"    
               ErrorMessage="Su contraseña debe contener al menos 8 caracteres"
               ControlToValidate="pass1"    
               ValidationExpression="^[a-zA-Z0-9'@&#.\s]{8}$" />
            <asp:TextBox ValidationExpression="^[a-zA-Z0-9'@&#.\s]{8}$" class ="cajadeTexto" ID="pass2" runat="server" placeholder ="Confirmar contraseña" required  TextMode="Password"></asp:TextBox>
            <asp:Label ID="Error2" runat="server" Text="" cssclass="Error"></asp:Label> 
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"    
               ErrorMessage="Su contraseña debe contener al menos 8 caracteres"
               ControlToValidate="pass2"    
               ValidationExpression="^[a-zA-Z0-9'@&#.\s]{8}$" /> 
           
            <!--<input type="button" value="Enviar" id="boton">-->
            <asp:Button class ="cajadeTexto" ID="boton" runat="server" Text="Agregar nuevo usuario" OnClick="boton_Click" />
            <a href="iniciarSesion.aspx"><font color="#fff"><span class="icon-left-open"></span>Volver al Login</a>
    </form>
</body>
</html>

