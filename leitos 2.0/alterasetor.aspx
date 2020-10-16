<%@ Page Language="C#" AutoEventWireup="true" CodeFile="alterasetor.aspx.cs" Inherits="alterasetor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="icon" type="imagem/ico" href="favicon.ico" />
    <link rel="icon" type="imagem/ico" href="favicon.ico" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="css/bootstrap.css" />
    <script src="https://kit.fontawesome.com/b8fb32cd64.js" crossorigin="anonymous"></script>
    <%--<link href="//fonts.googleapis.com/css?family=Raleway:100,100i,200,200i,300,300i,400,400i,500,500i,600,600i,700,700i,800,800i,900,900i" rel="stylesheet" />--%>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
    <script>
        function sucesso() {
            var div = document.getElementById('MyAlert').style.display = 'blodck';
        };
        function error() {
            var div = document.getElementById('MyAlert').style.display = 'block';
            document.getElementById('MyAlert').className = 'alert alert-danger';
        }
        function removeRequired() {
            document.getElementById('TextBox1').removeAttribute('required');
            document.getElementById('TextBox2').removeAttribute('required');
            document.getElementById('TextBox3').removeAttribute('required');
        }
        function voltar() {
            document.getElementById('DropDownList1').required = false;
            window.location.href = 'Default.aspx';
        }
    </script>
    <style>
        .botao {
            width: 100%;
            background: #4455a0;
            color: #fff;
            margin: 19px 0px 0px;
            font-size: 15px;
            font-weight: 400;
            border: none;
            padding: 12px 10px;
            letter-spacing: 1px;
            text-transform: uppercase;
            cursor: pointer;
            transition: 0.5s all;
            -webkit-transition: 0.5s all;
            border-radius: 8px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>
            <asp:Image ID="Image1" runat="server" Height="100px" ImageUrl="images/HOSP ROCIO_BRANCA.png" /></h1>
        <div class=" w3l-login-form">
            <h2>Altaração de usuario</h2>
            <div class=" w3l-form-group">
                <div id="MyAlert" class="alert alert-success" role="alert" style="display: none">
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
            </div>
            <div class=" w3l-form-group">
                <div class=" w3l-form-group">
                    <div style="color: white">Seu setor</div>
                    <div class="group">
                        <i class="fas fa-procedures"></i>
                        <asp:TextBox ID="TextBox1" CssClass="input" runat="server" Enabled="false"></asp:TextBox>
                    </div>
                </div>
                <div class=" w3l-form-group">
                    <div style="color: white">Novo setor</div>
                    <div class="group">
                        <i class="fas fa-procedures"></i>
                        <asp:DropDownList ID="DropDownList1" CssClass="input" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <asp:Button ID="Button1" CssClass="button" runat="server" Text="Alterar setor" OnClick="Button1_Click"/><br />
            <br />
            <asp:Button ID="Button2" CssClass="button" runat="server" Text="voltar" OnClientClick="voltar(); return false;" />
            <footer>
                <p class="copyright-agileinfo">2018 Hospital do Rocio | Design by I.T Information Technology</p>
            </footer>
        </div>
        <script>
            function voltar() {
                $('#DropDownList1').prop('required', false);
            window.location.href = 'alterausuario.aspx';
        }
        </script>
    </form>
</body>
</html>
