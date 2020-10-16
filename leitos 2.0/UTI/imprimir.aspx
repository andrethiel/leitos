<%@ Page Language="C#" AutoEventWireup="true" CodeFile="imprimir.aspx.cs" MasterPageFile="~/UTI/MasterPage.master" Inherits="Postos_imprimir" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    link rel="icon" type="imagem/ico" href="favicon.ico" />
    <link href="../css/bootstrap.css" rel='stylesheet' type='text/css' />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/js-cookie@beta/dist/js.cookie.min.js"></script>

    <script>
        function error() {
            var div = document.getElementById('Alert').style.display = 'block';
            document.getElementById('Alert').className = 'alert alert-danger';

        };
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
                    <h1>IMPRESSÃO DE LAUDOS DE EXAMES DE IMAGEM</h1>
                </div>
            </div>
        </div>
        <div class="container">
            <div class="col-sm-12" style="margin-top: 1%">
                <div id="Alert" class="alert alert-success" role="alert" style="display: none">
                    <asp:Label ID="Label2" runat="server"></asp:Label>
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
            </div>
            <div class="form-group row">
                <div class="col-sm-12" style="margin-top: 1%">
                    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                        <HeaderTemplate>
                            <table class="table table-hover">
                                <thead>
                                    <tr>
                                        <th>Nome do Paciente</th>
                                        <th>Unidade</th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="LinkButton3" runat="server" CssClass="link" Text='<%#Eval("nm_paciente") %>' CommandArgument='<%#Eval("cd_pessoa_fisica") %>'></asp:LinkButton></td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("cd_unidade") %>'></asp:Label></td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </tbody>
                                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">

        
        function ShowDo(body) {
            $("#solciita .modal-body").html(body);
            $("#solciita").modal("show");
        }
        function ShowImprimi(body) {
            $("#reimprimi .modal-body").html(body);
            $("#reimprimi").modal("show");
            if ($("#reimprimi").hasClass('show')) {
                $('#Content_DropDownList1').prop('required', true);
            }
            
        }
    </script>
    <div id="solciita" class="modal" role="dialog" style="margin-top: 3%">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-body">

                    <div class="col-sm-12">
                        <div id="MyAlert" class="alert alert-danger" role="alert" style="display: none">
                            <asp:Label ID="Label3" runat="server"></asp:Label>
                        </div>
                        <asp:Repeater ID="Repeater2" runat="server" OnItemCommand="Repeater2_ItemCommand">
                            <HeaderTemplate>
                                <table class="table">
                                    <thead>
                                        <tr>
                                            <th>Exame</th>
                                            <th>Data do exame</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:LinkButton ID="LinkButton3" runat="server" Text='<%#Eval("ds_titulo_laudo") %>' CommandArgument='<%#Eval("nr_sequencia") %>'></asp:LinkButton></td>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text='<%#Eval("dt_exame") %>'></asp:Label></td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </tbody>
                                            </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>

                </div>
            </div>
        </div>
    </div>
    <div id="reimprimi" class="modal" role="dialog">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-body">

                        <div class="form-group row">
                            <p style="font-size: 20px">Exame impresso por: <asp:Label ID="Label1" runat="server"></asp:Label></p>

                            <div class="col-sm-12" style="margin-top: 3%">
                                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="">Motivo para reimpressão</asp:ListItem>
                                    <asp:ListItem>Entraga para o paciente</asp:ListItem>
                                    <asp:ListItem>Faltando exame prontuário</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-sm-12">
                                <asp:Button ID="Button1" CssClass="botao" runat="server" Text="Imprimir" OnClick="Button1_Click"/>
                            </div>
                        </div>
                    </div>
            </div>
        </div>
    </div>
    <script>
            
    </script>
</asp:Content>
