<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChateandoConExpertos01.aspx.cs" Inherits="ChateandoConExpertos01" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Página sin título</title>
    <link href="css/estilos.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
   <div class="cont_04">
    <div class="cont_04_01"></div>
    <div class="cont_04_02">
    
       <div class="cont_tks">
  <div class="tks_title"><b>Cuéntanos que quisieras saber de tu gato:</b>
   <asp:TextBox ID="txtDocumento" runat="server" Height="19px" Visible="False" Width="216px"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
       ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="(*)"></asp:RequiredFieldValidator><br />
  </div>
  <div class="tks_question">
    <asp:TextBox ID="TextBox1" runat="server" Height="166px" TextMode="MultiLine" Width="526px"></asp:TextBox>
    </div>
    <div class="tks_btn_enviar">
    
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="img/enviar.png" Height="33px" Width="65px" OnClick="ImageButton1_Click" />
    
    </div>
</div>
    
    </div>
    <div class="cont_04_03"></div>
  </div>
    </form>
</body>
</html>
