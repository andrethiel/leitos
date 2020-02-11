<%@ Page Language="C#" AutoEventWireup="true" CodeFile="redireciona.aspx.cs" Inherits="Leitos_Principal_redireciona" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Redirecionamento | Leitos Rocio</title>
    <link rel="icon" type="imagem/ico" href="../../images/favicon.ico" />
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <link href="../css/fontawesome-all.css" rel="stylesheet" />
    <link href="//fonts.googleapis.com/css?family=Raleway:100,100i,200,200i,300,300i,400,400i,500,500i,600,600i,700,700i,800,800i,900,900i"
        rel="stylesheet">
    <script type="text/javascript">
        window.history.forward();
        function noBack() {
            window.history.forward();
        }
    </script>
    <script type="text/javascript">setInterval ("window.location='?page=stats'", "300000");</script>
</head>
<body onload="noBack();" onpageshow="if (event.persisted) noBack();" onunload="">
    <form id="form1" runat="server">
       <h1><asp:Image ID="Image1" runat="server" Height="100px" ImageUrl="../images/HOSP ROCIO_BRANCA.png" /></h1>
    <div class=" w3l-login-form">
         <div class=" w3l-form-group">
                <h2>Seu tempo de sessão expirou</h2>
            </div>
            <asp:Button ID="Button1" CssClass="button" runat="server" Text="OK" OnClick="Button1_Click" />
        
    <footer>
        <p class="copyright-agileinfo">2018 Hospital do Rocio | Design by I.T Information Technology</p>
    </footer>
        </div>
    </form>
</body>
</html>
