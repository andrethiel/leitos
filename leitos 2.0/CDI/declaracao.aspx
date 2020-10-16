<%@ Page Language="C#" AutoEventWireup="true" CodeFile="declaracao.aspx.cs" MasterPageFile="~/CDI/MasterPage.master" Inherits="CDI_declaracao" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    <link rel="icon" type="imagem/ico" href="favicon.ico" />
    <link href="../css/bootstrap.css" rel='stylesheet' type='text/css' />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/js-cookie@beta/dist/js.cookie.min.js"></script>
    <script src="../Script/jquery.maskedinput.min.js" type="text/javascript"></script>

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

    </script>
    <style>
        .botao {
            width: 100%;
            background: #4455a0;
            color: #fff;
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
                    <h1>DECLARAÇÃO</h1>
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
                <div class="col-sm-3" style="margin-top: 1%">
                    <asp:TextBox ID="TextBox1" CssClass="form-control ng-pristine ng-untouched ng-valid ng-empty" runat="server" AutoPostBack="true" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
                </div>
                <div class="col-sm-3" style="margin-top: 1%">
                    <asp:TextBox ID="TextBox2" CssClass="form-control ng-pristine ng-untouched ng-valid ng-empty" runat="server"></asp:TextBox>
                </div>
                 <div class="col-sm-3" style="margin-top: 1%">
                    <asp:TextBox ID="TextBox3" CssClass="form-control ng-pristine ng-untouched ng-valid ng-empty" runat="server"></asp:TextBox>
                </div>
                 <div class="col-sm-3" style="margin-top: 1%">
                    <asp:TextBox ID="TextBox4" CssClass="form-control ng-pristine ng-untouched ng-valid ng-empty" runat="server"></asp:TextBox>
                </div>
                <div class="col-sm-3" style="margin-top: 1%">
                    <asp:TextBox ID="TextBox5" CssClass="form-control ng-pristine ng-untouched ng-valid ng-empty" runat="server"></asp:TextBox>
                </div>
                <div class="col-sm-3" style="margin-top: 1%">
                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control ng-pristine ng-untouched ng-valid ng-empty" onchange="verifica_declaracao()">
                        <asp:ListItem Value="">Declaração para quem ?</asp:ListItem>
                        <asp:ListItem>Paciente</asp:ListItem>
                        <asp:ListItem>Acompanhante</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-sm-3" style="margin-top: 1%">
                    <asp:TextBox ID="TextBox6" CssClass="form-control ng-pristine ng-untouched ng-valid ng-empty" style="display: none" runat="server"></asp:TextBox>
                </div>
                <div class="col-sm-3" style="margin-top: 1%">
                    <asp:TextBox ID="TextBox7" CssClass="form-control ng-pristine ng-untouched ng-valid ng-empty" style="display: none" runat="server"></asp:TextBox>
                </div>
                <div class="col-sm-12" style="margin-top: 1%">
                    <asp:Button ID="Button1" CssClass="botao" runat="server" Text="Imprimir" OnClick="Button1_Click"/>
                </div>
            </div>
        </div>
    </div>
    <script>
        jQuery(function ($) {
            $("#Content_TextBox3").mask("999.999.999-99");
            $("#Content_TextBox7").mask("999.999.999-99");
            $("#Content_TextBox4").mask("99:99");
            $("#Content_TextBox5").mask("99:99");
        });
        document.getElementById('Content_TextBox1').placeholder = 'N° Atendimento'
        document.getElementById('Content_TextBox2').placeholder = 'Nome do paciente'
        document.getElementById('Content_TextBox3').placeholder = 'CPF do paciente'
        document.getElementById('Content_TextBox4').placeholder = 'Hora chagada'
        document.getElementById('Content_TextBox5').placeholder = 'Hora saida'
        document.getElementById('Content_TextBox6').placeholder = 'Nome acompanhante'
        document.getElementById('Content_TextBox7').placeholder = 'CPF do Acompanhante'
        $('#Content_TextBox1').prop('required', true);
        $('#Content_TextBox2').prop('required', true);
        $('#Content_TextBox3').prop('required', true);
        $('#Content_TextBox4').prop('required', true);
         $('#Content_TextBox5').prop('required', true);
        $('#Content_DropDownList1').prop('required', true);

        function verifica_declaracao() {
            var declara = $('#Content_DropDownList1 :selected').text();

            if (declara != 'Paciente') {
                document.getElementById('Content_TextBox6').style.display = 'inline-block'
                document.getElementById('Content_TextBox7').style.display = 'inline-block'
                $('#Content_TextBox6').prop('required', true);
                $('#Content_TextBox7').prop('required', true);
            } else {
                document.getElementById('Content_TextBox6').style.display = 'none'
                document.getElementById('Content_TextBox7').style.display = 'none'
                $('#Content_TextBox6').prop('required', false);
                $('#Content_TextBox7').prop('required', false);
            }
        }
    </script>
</asp:Content>

