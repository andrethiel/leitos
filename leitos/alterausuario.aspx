<%@ Page Language="C#" AutoEventWireup="true" CodeFile="alterausuario.aspx.cs" Inherits="alterausuariop" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Alteração de usuario | Leitos Rocio</title>
    <link rel="icon" type="imagem/ico" href="images/favicon.ico" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/fontawesome-all.css" rel="stylesheet" />
    <link href="//fonts.googleapis.com/css?family=Raleway:100,100i,200,200i,300,300i,400,400i,500,500i,600,600i,700,700i,800,800i,900,900i"rel="stylesheet" />
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <script src="Scripts/jquery-3.3.1.slim.min.js"></script>
<script src="Scripts/esm/popper.min.js"></script>
<script src="Scripts/bootstrap.min.js"></script>
    
    <script>
        function sucesso() {
            var div = document.getElementById('MyPopup').style.display = 'block';
        };
        function error() {
            var div = document.getElementById('MyPopup').style.display = 'block';
            document.getElementById('MyPopup').className = 'alert alert-danger';
        }
    </script>
    <script type="text/javascript">
            function Popup(body) {
                if (!localStorage.getItem('OK')) {
                    $("#pop .modal-body").html(body);
                    $("#pop").modal("show");
                    
                }
            };
            function OK() {
                if (localStorage) {
                    if (!localStorage.getItem('OK')) {
                        localStorage.setItem('OK', true);
                    }
                }
            };
            function Fechar() {
                localStorage.clear();
            }
</script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" Visible="false"></asp:Label>
        <asp:Label ID="Label2" runat="server" Visible="false"></asp:Label>
        <h1><asp:Image ID="Image1" runat="server" Height="100px" ImageUrl="images/HOSP ROCIO_BRANCA.png" /></h1>
    <div class=" w3l-login-form">
        <h2>Altaração de usuario</h2>
        <div id="MyPopup" class="alert alert-success" role="alert" style="display:none">
            <p><asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
    <span aria-hidden="true">&times;</span>
  </button></p>
</div>
         <div class=" w3l-form-group">
             <div style="color:white">Nome completo</div>
                <div class="group">
                    <i class="fas fa-user"></i>
                    <asp:TextBox ID="TextBox1" CssClass="input" runat="server" AutoCompleteType="Disabled" Enabled="false"></asp:TextBox>
                    <asp:ImageButton ID="ImageButton1" runat="server" OnClick="ImageButton1_Click" ImageUrl="~/images/editar.ico" Height="20px"/>
                </div>
            </div>
            <div class=" w3l-form-group">
                <div style="color:white">E-mail</div>
                <div class="group">
                    <i class="fas fa-at"></i>
                    <asp:TextBox ID="TextBox2" CssClass="input" runat="server" AutoCompleteType="Disabled" Enabled="false"></asp:TextBox>
                    <asp:ImageButton ID="ImageButton2" runat="server" OnClick="ImageButton2_Click" ImageUrl="~/images/editar.ico" Height="20px" />
                </div>
            </div>
            <asp:Button ID="Button1" CssClass="button" runat="server" Text="Alterar meus dados" OnClick="Button1_Click"/><br /><br />
        <asp:Button ID="Button2" CssClass="button" runat="server" Text="Alterar minha senha" OnClick="Button2_Click"/><br /><br />
        <asp:Button ID="Button4" CssClass="button" runat="server" Text="Alterar meu Setor" OnClick="Button4_Click"/><br /><br />
        <asp:Button ID="Button3" CssClass="button" runat="server" Text="Voltar" OnClick="Button3_Click"/>

    <footer>
        <p class="copyright-agileinfo">2018 Hospital do Rocio | Design by I.T Information Technology</p>
    </footer>
        </div>

        <div id="pop" class="modal fade" role="dialog" >
    <div class="modal-dialog modal-lg">
        <!-- Modal content-->
        <div class="modal-content">
            <div class="modal-header">
               <p style="font-size:15px; text-align:center;">Atenção: Como alterar seu nome e email</p>
                </div>
            <div class="modal-body" style="text-align:center">
                <p style="font-size:15px; text-align:center">
                    <asp:Label ID="Label5" Text="Para mudar o usuario, clique no botão de editar e altere suas informçãoes.<br>Depois de alterado clique no botão salvar para terminar a edição dos dados.<br>E clique em alterar meus dados" runat="server"></asp:Label>
                </p>
                <img src="images/gif/usuario.gif" />
                </div>
            <div class="modal-footer">
                <asp:Button ID="Button5" class="btn btn-secondary" runat="server" Text="Sair" OnClick="Button5_Click" />
                <asp:Button ID="Button6" class="btn btn-primary" runat="server" Text="Ok, Entendi" OnClick="Button6_Click" />
                </div>
            </div>
        </div>
            </div>
    </form>
</body>
</html>
