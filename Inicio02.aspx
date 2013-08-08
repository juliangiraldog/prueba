<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Inicio02.aspx.cs" Inherits="Inicio02" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Página sin título</title>
    <link href="css/estilos.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
   <div class="cont_02">
    <div class="cont_02_01"></div>
    <div class="cont_02_02">
    
      <div class="cont_ingreso">
  <div class="txt_ingreso"><b>Ingresa tus datos y participa en nuestra actividad</b></div>
  <div class="field_box">
    <div class="field_txt">Tipo de identificación:</div>
    <div class="campos">
    <asp:DropDownList ID="dSeleccion" runat="server">
                   <asp:ListItem Value="">Seleccione</asp:ListItem>
                    <asp:ListItem Value="1">Cédula de ciudadanía</asp:ListItem>
                <asp:ListItem Value="2">Cédula de extranjería</asp:ListItem>
                    </asp:DropDownList>
    
    </div>
  </div>
  <div class="field_box">
    <div class="field_txt">Número:</div>
    <div class="campos"><asp:TextBox ID="TextBox1" runat="server" onkeypress="ValidaSoloNumeros()"></asp:TextBox></div>
  </div>
  <div class="field_box">
  <div class="btn_entrar">
  
  <asp:ImageButton ID="ImageButton1" runat="server" OnClick="ImageButton1_Click1" Width="65px" AlternateText="Ingresar" Height="33px" ImageUrl="img/entrar.png" />
  </div>
 
  <asp:Label ID="Label1" runat="server" ForeColor="Black"></asp:Label>
  </div>
  <div class="txt_ingreso"><b></b></div>
</div>
    
    </div>
    <div class="cont_02_03"></div>
  </div>
    </form>
</body>
</html>
