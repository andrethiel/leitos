<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Altas.aspx.cs" MasterPageFile="~/Leitos/MasterPage.master" Inherits="_Default" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">

    <link rel="icon" type="imagem/ico" href="favicon.ico" />
    <link href="../css/bootstrap.css" rel='stylesheet' type='text/css' />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>

    <script>
        function sucesso() {
            var div = document.getElementById('MyAlert').style.visibility = 'visible';
        };
        function error() {
            var div = document.getElementById('MyAlert').style.visibility = 'visible';
            document.getElementById('MyAlert').className = 'alert alert-danger';
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
            padding: 10px 10px;
            letter-spacing: 1px;
            text-transform: uppercase;
            cursor: pointer;
            transition: 0.5s all;
            -webkit-transition: 0.5s all;
            border-radius: 8px;
        }
    </style>

        <div class="swichermainbx clearfix" style="margin-top: 80px">
            <div class="container">
                <div class="form-group row">
                    <div class="title" style="margin-top: 5%">
                        <h1>Altas do Dia</h1>
                    </div>
                </div>
                <div id="MyAlert" class="alert alert-success" role="alert" style="visibility: hidden">
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="col-sm-12" style="margin-top: 1%">
                    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                        <HeaderTemplate>
                            <table class="table">
                                <thead>
                                    <tr>
                                        <th>Selecionar - N° atendimento</th>
                                        <th>Nome do Paciente</th>
                                        <th>Leito</th>
                                        <th>Cidade</th>
                                        <th>Contato</th>
                                        <th>Tipo da Alta</th>
                                        <th>Acompanhante</th>
                                        <th>Oxigênio</th>
                                        <th>Solicitante</th>
                                        <th>Status</th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="LinkButton3" runat="server" Text='<%#Eval("num_atendimento") %>' CommandArgument='<%#Eval("id")%>'></asp:LinkButton></td>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("nome_pac") %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("leito") %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("cidade") %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label6" runat="server" Text='<%#Eval("contato") %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text='<%#Eval("tipo_alta") %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label5" runat="server" Text='<%#Eval("acompanha") %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label7" runat="server" Text='<%#Eval("ox") %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label9" runat="server" Text='<%#Eval("nome_completo") %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label12" runat="server" Text='<%#Eval("status") %>'></asp:Label></td>

                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </tbody>
                                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
                <script type="text/javascript">
                    function ShowDo(body) {
                        $("#solciita .modal-body").html(body);
                        $("#solciita").modal("show");
                    }
                </script>
                <div id="solciita" class="modal fade" role="dialog">
                    <div class="modal-dialog modal-dialog-centered" role="document">
                        <!-- Modal content-->
                        <div class="modal-content">
                            <div class="modal-header">
                                <p style="font-size: 20px; text-align: center;">Cadastro Ligações</p>
                            </div>
                            <div class="modal-body">
                                    <div class="form-group row">
                                        <div class="col-lg-12" style="margin-top: 1%">
                                            <asp:TextBox ID="TextBox1" CssClass="form-control ng-pristine ng-untouched ng-valid ng-empty" TextMode="MultiLine" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <div class="col-lg-12" style="margin-top: 1%">
                                            <asp:Button ID="Button1" runat="server" Text="Inserir" CssClass="botao" OnClick="Button1_Click" />
                                        </div>
                                    </div>
                                </div>
                            <div class="modal-header">
                            </div>
                            <div class="modal-body">
                                    <div class="form-group row">
                                        <div class="col-sm-12" style="margin-top: 1%">
                                            <asp:Repeater ID="Repeater2" runat="server" OnItemCommand="Repeater1_ItemCommand">
                                                <HeaderTemplate>
                                                    <table class="table">
                                                        <thead>
                                                            <tr>
                                                                <th>Ligação</th>
                                                                <th>Usuario</th>
                                                                <th>Data e hora da ligação</th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label8" runat="server" Text='<%#Eval("mensagem") %>'></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("nome_completo") %>'></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="Label10" runat="server" Text='<%#Eval("data", "{0:d}") %>'></asp:Label>
                                                                -
                                                                <asp:Label ID="Label11" runat="server" Text='<%#Eval("hora") %>'></asp:Label></td>
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
                </div>
            </div>
    </asp:Content>