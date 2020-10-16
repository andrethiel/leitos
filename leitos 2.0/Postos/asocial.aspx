<%@ Page Language="C#" AutoEventWireup="true" CodeFile="asocial.aspx.cs" MasterPageFile="~/Postos/MasterPage.master" Inherits="Postos_asocial" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    <link href="../css/bootstrap.css" rel='stylesheet' type='text/css' />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/js-cookie@beta/dist/js.cookie.min.js"></script>


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

        document.title = 'Altas Assistente Social | Leitos Rocio';

        


        var local = Cookies.get('local')
        if (local == 'Centro Cirurgico') {
            alert('Não é possivel fazer marcação de exame')
            window.location.href = 'Principal.aspx';
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

    <div class="swichermainbx clearfix" style="margin-left: 4%">
        <div class="container">
            <div class="form-group row">
                <div class="title" style="margin-top: 5%">
                    <h1>PEDIDO ALTA ASSISTENTE SOCIAL</h1>
                </div>
            </div>
            <div class="col-sm-12" style="margin-top: 1%">
                <div id="MyAlert" class="alert alert-success" role="alert" style="display: none">
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
            </div>
        </div>
        <div class="container">
            <div class="form-group row">
                <div class="col-sm-2" style="margin-top: 1%">
                    <asp:TextBox ID="TextBox1" CssClass="form-control ng-pristine ng-untouched ng-valid ng-empty" runat="server" AutoPostBack="true" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
                </div>
                <div class="col-sm-6" style="margin-top: 1%">
                    <asp:TextBox ID="TextBox2" CssClass="form-control ng-pristine ng-untouched ng-valid ng-empty" runat="server"></asp:TextBox>
                </div>
                <div class="col-sm-2" style="margin-top: 1%">
                    <asp:TextBox ID="TextBox3" CssClass="form-control ng-pristine ng-untouched ng-valid ng-empty" runat="server"></asp:TextBox>
                </div>
                <div class="col-sm-2" style="margin-top: 1%">
                    <asp:TextBox ID="TextBox4" CssClass="form-control ng-pristine ng-untouched ng-valid ng-empty" runat="server"></asp:TextBox>
                </div>
                <div class="col-sm-3" style="margin-top: 1%">
                    <asp:DropDownList ID="DropDownList1" CssClass="form-control ng-pristine ng-untouched ng-valid ng-empty" runat="server">
                        <asp:ListItem Value="">Avisar alta para</asp:ListItem>
                        <asp:ListItem>Ambulância</asp:ListItem>
                        <asp:ListItem>Familia</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-sm-3" style="margin-top: 1%">
                    <asp:DropDownList ID="DropDownList2" CssClass="form-control ng-pristine ng-untouched ng-valid ng-empty" runat="server">
                        <asp:ListItem Value="">Acompanhante</asp:ListItem>
                        <asp:ListItem>Sim</asp:ListItem>
                        <asp:ListItem>Não</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-sm-3" style="margin-top: 1%">
                    <asp:DropDownList ID="DropDownList3" CssClass="form-control ng-pristine ng-untouched ng-valid ng-empty" runat="server">
                        <asp:ListItem Value="">Condições do Paciente</asp:ListItem>
                        <asp:ListItem>Sentado</asp:ListItem>
                        <asp:ListItem>Maca</asp:ListItem>
                    </asp:DropDownList>
                </div>
                 <div class="col-sm-3" id="outros" style="margin-top: 1%">
                     <asp:DropDownList ID="DropDownList4" CssClass="form-control ng-pristine ng-untouched ng-valid ng-empty" runat="server">
                        <asp:ListItem Value="">Covid-19</asp:ListItem>
                        <asp:ListItem>Sim</asp:ListItem>
                        <asp:ListItem>Não</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-sm-12" style="margin-top: 1%">
                    <asp:Button ID="Button1" runat="server" CssClass="botao" Text="Solicitar alta assistente social" OnClick="Button1_Click" />
                    </div>
            </div>
        </div>
    </div>
    <script>
        document.getElementById('Content_TextBox1').placeholder = 'N° atendimento';
        document.getElementById('Content_TextBox2').placeholder = 'Nome do Paciente'
        document.getElementById('Content_TextBox3').placeholder = 'Quarto-Leito'
        document.getElementById('Content_TextBox4').placeholder = 'Municipio'
        document.getElementById('Content_TextBox5').placeholder = 'Municipio'


        $('#Content_TextBox1').prop('required', true);
        $('#Content_TextBox2').prop('required', true);
        $('#Content_TextBox3').prop('required', true);
        $('#Content_TextBox4').prop('required', true);
        $('#Content_DropDownList1').prop('required', true);
        $('#Content_DropDownList2').prop('required', true);
        $('#Content_DropDownList3').prop('required', true);

        //function outros() {
        //    if ($('#Content_DropDownList3').val() == 'Outros') {
        //        document.getElementById('outros').style.display = 'block';
        //        $('#Content_TextBox5').prop('required', true);
        //    } else {
        //        document.getElementById('outros').style.display = 'none';
        //        $('#Content_TextBox5').prop('required', false);
        //    }
           
        //}
    </script>
</asp:Content>
