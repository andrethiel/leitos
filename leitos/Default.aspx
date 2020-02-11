<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login | Leitos Rocio</title>
    <link rel="icon" type="imagem/ico" href="images/favicon.ico" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/fontawesome-all.css" rel="stylesheet" />
    <link href="//fonts.googleapis.com/css?family=Raleway:100,100i,200,200i,300,300i,400,400i,500,500i,600,600i,700,700i,800,800i,900,900i" rel="stylesheet" />
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <script src="Scripts/jquery-3.3.1.slim.min.js"></script>
<script src="Scripts/esm/popper.min.js"></script>
<script src="Scripts/bootstrap.min.js"></script>
<script>
        window.history.forward();
        function noback() {
            window.history.forward();
        }
    </script>
    <script>
        function sucesso() {
            var div = document.getElementById('MyPopup').style.visibility = 'visible';
        };
        function error() {
            var div = document.getElementById('MyPopup').style.visibility = 'visible';
            document.getElementById('MyPopup').className = 'alert alert-danger';
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
       <h1><asp:Image ID="Image1" runat="server" Height="100px" ImageUrl="images/HOSP ROCIO_BRANCA.png" /></h1>
    <div class=" w3l-login-form">
        <div id="MyPopup" class="alert alert-success" role="alert" style="visibility:hidden">
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
    <span aria-hidden="true">&times;</span>
  </button>
</div>
         <div class=" w3l-form-group">
                <div class="group">
                    <i class="fas fa-user"></i>
                    <asp:TextBox ID="TextBox1" CssClass="input" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                </div>
            </div>
            <div class=" w3l-form-group">
                <div class="group">
                    <i class="fas fa-unlock"></i>
                    <asp:TextBox ID="TextBox2" runat="server" CssClass="input" TextMode="Password" AutoCompleteType="Disabled"></asp:TextBox>
                    <asp:TextBox ID="TextBox3" runat="server" Visible="false"></asp:TextBox>
                </div>
            </div>
            <asp:Button ID="Button1" CssClass="button" runat="server" Text="Entrar" OnClick="Button1_Click" />
        <p class=" w3l-register-p"><a href="registrar.aspx" class="register">Registrar</a></p>
        <p class=" w3l-register-p"><a href="recupera.aspx" class="register">Esqueceu a senha ?</a></p>
        
    <footer>
        <p class="copyright-agileinfo">2018 Hospital do Rocio | Design by I.T Information Technology</p>
    </footer>
        </div>
    </form>
</body>
</html>
