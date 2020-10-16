<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/UTI/MasterPage.master" CodeFile="Pedido.aspx.cs" Inherits="UTI_Pedido" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    <link rel="icon" type="imagem/ico" href="favicon.ico" />
    <link href="../css/bootstrap.css" rel='stylesheet' type='text/css' />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>

    <script>
        function sucesso() {
            var div = document.getElementById('MyAlert').style.display = 'block';
        };
        function error() {
            var div = document.getElementById('MyAlert').style.display = 'block';
            document.getElementById('MyAlert').className = 'alert alert-danger';
        };

        setTimeout(esconde, 3000);

        function esconde() {
            document.getElementById('MyAlert').style.display = 'none';
        };

        if (document.cookie.indexOf("id") < 0) {
            window.location.href = '../Default.aspx';
        };

        document.title = 'Pedido de Leitos | Leitos Rocio';

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

    <div class="swichermainbx clearfix" style="margin-left: 4%">
        <div class="container">
            <div class="form-group row">
                <div class="title" style="margin-top: 5%">
                    <h1>PEDIDO DE LEITOS</h1>
                </div>
            </div>
            <div id="MyAlert" class="alert alert-success" role="alert" style="display: none">
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
        </div>
        <div class="container">
            <div class="form-group row">
                <div class="col-sm-2" style="margin-top: 1%">
                    <asp:TextBox ID="TextBox2" CssClass="form-control ng-pristine ng-untouched ng-valid ng-empty" runat="server" AutoPostBack="true" OnTextChanged="TextBox2_TextChanged" OnClick=""></asp:TextBox>
                </div>
                <div class="col-sm-5" style="margin-top: 1%">
                    <asp:TextBox ID="TextBox3" CssClass="form-control ng-pristine ng-untouched ng-valid ng-empty" runat="server"></asp:TextBox>
                </div>
                <div class="col-sm-1" style="margin-top: 1%">
                    <asp:TextBox ID="TextBox4" CssClass="form-control ng-pristine ng-untouched ng-valid ng-empty" runat="server"></asp:TextBox>
                </div>
                <div class="col-sm-2" style="margin-top: 1%">
                    <asp:TextBox ID="TextBox5" CssClass="form-control ng-pristine ng-untouched ng-valid ng-empty" runat="server"></asp:TextBox>
                </div>
                <div class="col-sm-2" style="margin-top: 1%">
                    <asp:TextBox ID="TextBox6" CssClass="form-control ng-pristine ng-untouched ng-valid ng-empty" runat="server"></asp:TextBox>
                </div>
                <div class="col-sm-2" style="margin-top: 1%">
                    <asp:DropDownList ID="DropDownList1" CssClass="form-control ng-pristine ng-untouched ng-valid ng-empty" runat="server">
                        <asp:ListItem Value="">Especialidade</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-sm-5" style="margin-top: 1%">
                    <asp:TextBox ID="TextBox7" CssClass="form-control ng-pristine ng-untouched ng-valid ng-empty" runat="server"></asp:TextBox>
                </div>
                <div class="col-sm-5" style="margin-top: 1%">
                    <asp:TextBox ID="TextBox8" CssClass="form-control ng-pristine ng-untouched ng-valid ng-empty" runat="server"></asp:TextBox>
                </div>
                <div class="col-sm-12" style="margin-top: 1%">
                    <asp:Button ID="Button1" runat="server" Text="Salvar" CssClass="botao" OnClick="Button1_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
