<%@ Page Language="C#" AutoEventWireup="true" CodeFile="registrar.aspx.cs" Inherits="registrar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>CADASTRO LOGIN | LEITOS ROCIO</title>
    <link rel="icon" type="imagem/ico" href="images/favicon.ico" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/fontawesome-all.css" rel="stylesheet" />
    <link href="//fonts.googleapis.com/css?family=Raleway:100,100i,200,200i,300,300i,400,400i,500,500i,600,600i,700,700i,800,800i,900,900i" rel="stylesheet" />
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <script src="Scripts/jquery-3.3.1.slim.min.js"></script>
<script src="Scripts/esm/popper.min.js"></script>
<script src="Scripts/bootstrap.min.js"></script>
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
        <asp:Label ID="Label1" runat="server" Visible="false"></asp:Label>
        <asp:Label ID="Label2" runat="server" Visible="false"></asp:Label>
        <h1><asp:Image ID="Image1" runat="server" Height="100px" ImageUrl="images/HOSP ROCIO_BRANCA.png" /></h1>
    <div class=" w3l-login-form">
        <h2>Criar usuario</h2>
         <div class=" w3l-form-group">
             <div id="MyPopup" class="alert alert-success" role="alert" style="visibility:hidden">
            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
    <span aria-hidden="true">&times;</span>
  </button>
</div>
             <div class=" w3l-form-group">
                <div class="group">
                    <i class="fas fa-bars"></i>
                    <asp:DropDownList ID="DropDownList1" CssClass="input" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
                        <asp:ListItem>Selecione um Setor</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
                <div class="group">
                    <i class="fas fa-user"></i>
                    <asp:TextBox ID="TextBox1" CssClass="input" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                </div>
            </div>
            <div class=" w3l-form-group">
                <div class="group">
                    <i class="fas fa-at"></i>
                    <asp:TextBox ID="TextBox2" CssClass="input" runat="server" AutoCompleteType="Disabled" TextMode="Email"></asp:TextBox>
                </div>
            </div>
        
        <div class=" w3l-form-group">
                <div class="group">
                    <i class="fas fa-lock"></i>
                    <asp:TextBox ID="TextBox3" CssClass="input" runat="server" TextMode="Password"></asp:TextBox>
                </div>
            </div>
        <div class=" w3l-form-group">
                <div class="group">
                    <i class="fas fa-lock"></i>
                    <asp:TextBox ID="TextBox4" runat="server" CssClass="input" TextMode="Password"></asp:TextBox>
                </div>
            </div>
            <asp:Button ID="Button1" CssClass="button" runat="server" Text="Registrar" OnClick="Button1_Click"/>
        <p class=" w3l-register-p"><a href="Default.aspx" class="register">Já sou registrado</a></p>
    <footer>
        <p class="copyright-agileinfo">2018 Hospital do Rocio | Design by I.T Information Technology</p>
    </footer>
        </div>
    </form>
</body>
</html>
