<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Postos/MasterPage.master" CodeFile="Principal.aspx.cs" Inherits="UTI_Default" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    <asp:Timer ID="Timer1" OnTick="Timer1_Tick" Interval="30000" runat="server"></asp:Timer>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <link rel="icon" type="imagem/ico" href="favicon.ico" />
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

    <div class="swichermainbx clearfix" style="margin-top: 3%">
        <div class="container">
            <div class="form-group row">
                <div class="title" style="margin-top: 5%">
                    <h1>PEDIDO DE LEITOS</h1>
                    <h1>POSTO/UTI: <asp:Label ID="Label10" runat="server"></asp:Label></h1>
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
            <div class="col-sm-12" style="margin-top: 3%">
                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                    <HeaderTemplate>
                        <table class="table">
                            <thead>
                                <tr>
                                    <th>Leito Liberado</th>
                                    <th>N° Atendimento</th>
                                    <th>Nome do Paciente</th>
                                    <th>Quarto</th>
                                    <th>Convenio</th>
                                    <th>Data e Hora da liberação</th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text='<%#Eval("Leito") %>'></asp:Label></td>
                            <td>
                                <asp:LinkButton ID="LinkButton3" runat="server" Text='<%#Eval("num_atendimento")%>' CommandArgument='<%#Eval("id")%>'></asp:LinkButton></td>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("nome_pac") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("quarto") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label6" runat="server" Text='<%#Eval("convenio") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text='<%#Eval("data_libera", "{0:d}") %>'></asp:Label>
                                | 
                                <asp:Label ID="Label5" runat="server" Text='<%# Eval("hora_libera") %>'></asp:Label>
                            </td>

                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody>
                                            </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
        <div class="container">
            <div class="form-group row">
                <div id="exames" class="title" style="margin-top: 5%">
                    <h1>EXAMES PEDIDOS</h1>
                </div>
            </div>
        </div>
        <div class="container">
            <div class="form-group row">
                <div class="col-sm-12" style="margin-top: 1%">
                    <asp:Repeater ID="Repeater2" runat="server" OnItemCommand="Repeater2_ItemCommand">
                        <HeaderTemplate>
                            <table class="table">
                                <thead>
                                    <tr>
                                        <th>Cancelado</th>
                                        <th>Status do exame</th>
                                        <th>Especialidade</th>
                                        <th>Procedimento</th>
                                        <th>Nome do Paciente</th>
                                        <th>Quarto/Leito</th>
                                        <th>Pedido</th>
                                        <th>Agendado</th>
                                        <th>Data e Hora do agendamento</th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("status") %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label7" runat="server" Text='<%#Eval("baixa") %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label8" runat="server" Text='<%#Eval("especial") %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label9" runat="server" Text='<%#Eval("procede") %>'></asp:Label></td>
                                <td>
                                    <asp:LinkButton ID="LinkButton3" runat="server" Text='<%#Eval("nome_pac") %>' CommandArgument='<%#Eval("id")%>'></asp:LinkButton></td>
                                <td>
                                    <asp:Label ID="Label11" runat="server" Text='<%#Eval("quarto") %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label12" runat="server" Text='<%#Eval("nome_completo") %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label13" runat="server" Text='<%#Eval("usuario_libera") %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label14" runat="server" Text='<%#Eval("data_libera", "{0:d}") %>'></asp:Label>
                                    |
                                <asp:Label ID="Label15" runat="server" Text='<%# Eval("hora_libera") %>'></asp:Label>
                                </td>
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
        <div class="container">
            <div class="form-group row">
                <div id="social" class="title" style="margin-top: 5%">
                    <h1>ALTAS ASSISTENTE SOCIAL</h1>
                </div>
            </div>
        </div>
        <div class="container">
            <div class="form-group row">
                <div class="col-sm-12" style="margin-top: 1%">
                    <asp:Repeater ID="Repeater3" runat="server" OnItemCommand="Repeater3_ItemCommand">
                        <HeaderTemplate>
                            <table class="table">
                                <thead>
                                    <tr>
                                        <th>Status</th>
                                        <th>Nome do Paciente</th>
                                        <th>Quarto/Leito</th>
                                        <th>Data da solicitação</th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("status") %>'></asp:Label></td>
                                <td>
                                    <asp:LinkButton ID="LinkButton3" runat="server" Text='<%#Eval("nome_pac") %>' CommandArgument='<%#Eval("id")%>'></asp:LinkButton></td>
                                <td>
                                    <asp:Label ID="Label11" runat="server" Text='<%#Eval("leito") %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label14" runat="server" Text='<%#Eval("data_alta" , "{0:d}") %>'></asp:Label>
                                </td>

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
        <script>
            $("td").each(function () {
                if ($(this).find("span").text() == 'Alta Cancelada') {
                    $(this).css({"color": "#fff", "background-color": "rgb(255, 0, 0)" })
                }
            })
            $("td").each(function () {
                if ($(this).find("span").text() == 'Exame Cancelado') {
                    $(this).css({"color": "#fff", "background-color": "rgb(255, 0, 0)" })
                }
            })
        </script>
        <script>
            function ShowPopup(body) {
                $("#MyPopup .modal-body").html(body);
                $("#MyPopup").modal("show");
            }
        </script>
        <div id="MyPopup" class="modal" role="dialog">
            <div class="modal-dialog" style="margin-top: 7%;" role="document">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <p style="font-size: 20px; text-align: center;">Cancelar</p>
                    </div>
                    <div class="modal-body">
                        <div class="container-fluid">
                            <div class="row">
                                <div class="form-group col-sm-12">
                                    <asp:Button ID="Button1" runat="server" CssClass="botao" Style="background: #f50000;" Text="Cancelar pedido leito" OnClick="Button1_Click" />
                                    <asp:Button ID="Button2" runat="server" CssClass="botao" Style="background: #f50000;" Text="Cancelar Exame" OnClick="Button2_Click" />
                                    <asp:Button ID="Button3" runat="server" CssClass="botao" Style="background: #f50000;" Text="Cancelar Alta" OnClick="Button3_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
