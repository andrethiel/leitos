<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Principal.aspx.cs" MasterPageFile="~/CDI/MasterPage.master" Inherits="CDI_Principal" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">

    <link rel="icon" type="imagem/ico" href="favicon.ico" />
    <link href="../css/bootstrap.css" rel='stylesheet' type='text/css' />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>

    <script>
        if (document.cookie.indexOf("id") < 0) {
            window.location.href = '../Default.aspx';
        };
    </script>
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
            padding: 12px 10px;
            letter-spacing: 1px;
            text-transform: uppercase;
            cursor: pointer;
            transition: 0.5s all;
            -webkit-transition: 0.5s all;
            border-radius: 8px;
        }

        .number {
            display: inline-block;
            background-color: #EB0000;
            color: #fff;
            border-radius: 100px;
            width: 20px;
            height: 20px;
            font-size: 11px;
            line-height: 1.8em;
            text-align: center;
        }
    </style>

    <div class="swichermainbx clearfix" style="margin-top: 80px">
        <div class="container">
            <div class="form-group row">
                <div class="title" style="margin-top: 5%" id="topo">
                    <h1>GERENCIAMENTO DE EXAMES</h1>
                    <table style="margin-top: 10%; margin-bottom: 5%">
                        <tr>
                            <td>
                                <button id="resso" type="button" style="background-color: #fff; border: none">
                                    <img src="../images/resso.png" title="Ressonancia" height="42" />
                                    <asp:Label ID="Label2" CssClass="number" runat="server"></asp:Label>
                                </button>
                            </td>
                            <td style="padding-left: 15px">
                                <button id="tomo" type="button" style="background-color: #fff; border: none">
                                    <img src="../images/tomo.png" title="Tomografia" height="42" />
                                    <asp:Label ID="Label4" CssClass="number" runat="server"></asp:Label>
                                </button>
                            </td>
                            <td style="padding-left: 15px">
                                <button id="raio" type="button" style="background-color: #fff; border: none">
                                    <img src="../images/raio.png" title="Raio-x" height="42" />
                                    <asp:Label ID="Label7" CssClass="number" runat="server"></asp:Label>
                                </button>
                            </td>
                            <td style="padding-left: 15px">
                                <button id="eco" type="button" style="background-color: #fff; border: none">
                                    <img src="../images/eco.png" title="Ecografia" height="42" />
                                    <asp:Label ID="Label8" CssClass="number" runat="server"></asp:Label>
                                </button>
                            </td>
                            <td style="padding-left: 15px">
                                <button id="mamo" type="button" style="background-color: #fff; border: none">
                                    <img src="../images/mamo.png" title="Mamografia" height="42" />
                                    <asp:Label ID="Label9" CssClass="number" runat="server"></asp:Label>
                                </button>
                            </td>
                            <td style="padding-left: 15px">
                                <button id="angior" type="button" style="background-color: #fff; border: none">
                                    <img src="../images/angio.png" title="Angiotomo e angioresso" height="42" />
                                    <asp:Label ID="Label6" CssClass="number" runat="server"></asp:Label>
                                </button>
                            </td>
                        </tr>
                    </table>
                    <div id="MyAlert" class="alert alert-success" role="alert" style="visibility: hidden">
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                </div>
            </div>
        </div>
        <div class="container">
                <div class="form-group row">
                    <div class="col-sm-4">
                        <asp:TextBox ID="TextBox4" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-sm-3">
                        <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server">
                            <asp:ListItem Value="">Selecione uma das especialidades</asp:ListItem>
                            <asp:ListItem>Ressonância</asp:ListItem>
                            <asp:ListItem>Tomografia</asp:ListItem>
                            <asp:ListItem>Raio-X</asp:ListItem>
                            <asp:ListItem>Ecografia</asp:ListItem>
                            <asp:ListItem>Angioressonâncias</asp:ListItem>
                            <asp:ListItem>Angiotomografias</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-sm-2">
                        <asp:Button ID="Button3" CssClass="botao" runat="server" style="margin: 0px" Text="consultar exame" OnClick="Button3_Click" OnClientClick="valida()" />
                    </div>
                    <div class="col-sm-2">
                        <asp:Button ID="Button4" CssClass="botao" runat="server" style="margin: 0px" Text="limpar pesquisa" OnClick="Button4_Click" />
                    </div>
                    <div class="col-sm-12" style="margin-top: 1%">
                        <asp:Repeater ID="Repeater8" runat="server">
                            <HeaderTemplate>
                                <table class="table">
                                    <thead>
                                        <tr>
                                            <th>Nome do Paciente</th>
                                            <th>Box/Quarto</th>
                                            <th>Setor</th>
                                            <th>Especialidade</th>
                                            <th>Procedimento</th>
                                            <th>Obs. Paciente</th>
                                            <th>Pedido</th>
                                            <th>Hora do pedido</th>
                                            <th>Status do Exame</th>
                                            <th>Baixa</th>
                                            <th>Hora da baixa</th>
                                            <th>Cancelado</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>

                                    <td>
                                        <asp:Label ID="Label12" runat="server" Text='<%#Eval("nome_pac") %>'></asp:Label></td>
                                    <td>
                                        <asp:Label ID="Label9" runat="server" Text='<%#Eval("quarto") %>'></asp:Label></td>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("local") %>'></asp:Label></td>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text='<%#Eval("especial") %>'></asp:Label></td>
                                    <td>
                                        <asp:Label ID="Label6" runat="server" Text='<%#Eval("procede") %>'></asp:Label></td>
                                    <td>
                                        <asp:Label ID="Label10" runat="server" Text='<%#Eval("obs") %>'></asp:Label></td>
                                    <td>
                                        <asp:Label ID="Label11" runat="server" Text='<%#Eval("nome_completo") %>'></asp:Label></td>
                                    <td>
                                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("hora_pedido") %>'></asp:Label></td>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" Text='<%#Eval("baixa") %>'></asp:Label></td>
                                    <td>
                                        <asp:Label ID="Label7" runat="server" Text='<%#Eval("usuario_libera") %>'></asp:Label></td>
                                    <td>
                                        <asp:Label ID="Label8" runat="server" Text='<%# Eval("hora_libera", "{0:t}") %>'></asp:Label></td>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" Text='<%#Eval("status") %>'></asp:Label></td>
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
        <div id="div_resso" class="collapse" style="margin-left: 5%; margin-right: 5%">
            <div class="title" style="margin-top: 2%">
                <h4>Ressonância</h4>
            </div>

            <div class="col-sm-12" style="margin-top: 1%">
                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                    <HeaderTemplate>
                        <table class="table">
                            <thead>
                                <tr>
                                    <th>Nome do Paciente</th>
                                    <th>Box/Quarto</th>
                                    <th>Setor</th>
                                    <th>Especialidade</th>
                                    <th>Procedimento</th>
                                    <th>Obs. Paciente</th>
                                    <th>Pedido</th>
                                    <th>Hora do pedido</th>
                                    <th>Status do Exame</th>
                                    <th>Baixa</th>
                                    <th>Hora da baixa</th>
                                    <th>Cancelado</th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>

                            <td>
                                <asp:LinkButton ID="LinkButton3" runat="server" Text='<%#Eval("nome_pac") %>' CommandArgument='<%#Eval("id")+ "," + Eval("nome_pac")+ "," + Eval("quarto")+ "," + Eval("local")%>'></asp:LinkButton></td>
                            <td>
                                <asp:Label ID="Label9" runat="server" Text='<%#Eval("quarto") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("local") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("especial") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label6" runat="server" Text='<%#Eval("procede") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label10" runat="server" Text='<%#Eval("obs") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label11" runat="server" Text='<%#Eval("nome_completo") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label5" runat="server" Text='<%# Eval("hora_pedido") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text='<%#Eval("baixa") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label7" runat="server" Text='<%#Eval("usuario_libera") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label8" runat="server" Text='<%# Eval("hora_libera", "{0:t}") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text='<%#Eval("status") %>'></asp:Label></td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody>
                                            </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>

        <div id="div_tomo" class="collapse" style="margin-left: 5%; margin-right: 5%">
            <div class="title" style="margin-top: 2%">
                <h4>Tomografia</h4>
            </div>
            <div class="col-sm-12" style="padding: 1%">
                <asp:Repeater ID="Repeater2" runat="server" OnItemCommand="Repeater2_ItemCommand">
                    <HeaderTemplate>
                        <table class="table">
                            <thead>
                                <tr>
                                    <th>Nome do Paciente</th>
                                    <th>Box/Quarto</th>
                                    <th>Setor</th>
                                    <th>Especialidade</th>
                                    <th>Procedimento</th>
                                    <th>Obs. Paciente</th>
                                    <th>Pedido</th>
                                    <th>Hora do pedido</th>
                                    <th>Status do Exame</th>
                                    <th>Baixa</th>
                                    <th>Hora da baixa</th>
                                    <th>Cancelado</th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>

                            <td>
                                <asp:LinkButton ID="LinkButton3" runat="server" Text='<%#Eval("nome_pac") %>' CommandArgument='<%#Eval("id")+ "," + Eval("nome_pac")+ "," + Eval("quarto")+ "," + Eval("local")%>'></asp:LinkButton></td>
                            <td>
                                <asp:Label ID="Label9" runat="server" Text='<%#Eval("quarto") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("local") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("especial") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label6" runat="server" Text='<%#Eval("procede") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label10" runat="server" Text='<%#Eval("obs") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label11" runat="server" Text='<%#Eval("nome_completo") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label5" runat="server" Text='<%# Eval("hora_pedido") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text='<%#Eval("baixa") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label7" runat="server" Text='<%#Eval("usuario_libera") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label8" runat="server" Text='<%# Eval("hora_libera", "{0:t}") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text='<%#Eval("status") %>'></asp:Label></td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody>
                                            </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>

        <div id="div_raio" class="collapse" style="margin-left: 5%; margin-right: 5%">
            <div class="title" style="margin-top: 2%">
                <h4>Raio-X</h4>
            </div>
            <div class="col-sm-12" style="margin-top: 1%">
                <asp:Repeater ID="Repeater3" runat="server" OnItemCommand="Repeater3_ItemCommand">
                    <HeaderTemplate>
                        <table class="table">
                            <thead>
                                <tr>
                                    <th>Nome do Paciente</th>
                                    <th>Box/Quarto</th>
                                    <th>Setor</th>
                                    <th>Especialidade</th>
                                    <th>Procedimento</th>
                                    <th>Obs. Paciente</th>
                                    <th>Pedido</th>
                                    <th>Hora do pedido</th>
                                    <th>Status do Exame</th>
                                    <th>Baixa</th>
                                    <th>Hora da baixa</th>
                                    <th>Cancelado</th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:LinkButton ID="LinkButton3" runat="server" Text='<%#Eval("nome_pac") %>' CommandArgument='<%#Eval("id")+ "," + Eval("nome_pac")+ "," + Eval("quarto")+ "," + Eval("local")%>'></asp:LinkButton></td>
                            <td>
                                <asp:Label ID="Label9" runat="server" Text='<%#Eval("quarto") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("local") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("especial") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label6" runat="server" Text='<%#Eval("procede") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label10" runat="server" Text='<%#Eval("obs") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label11" runat="server" Text='<%#Eval("nome_completo") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label5" runat="server" Text='<%# Eval("hora_pedido") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text='<%#Eval("baixa") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label7" runat="server" Text='<%#Eval("usuario_libera") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label8" runat="server" Text='<%# Eval("hora_libera", "{0:t}") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text='<%#Eval("status") %>'></asp:Label></td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>

        <div id="div_eco" class="collapse" style="margin-left: 5%; margin-right: 5%">
            <div class="title" style="margin-top: 2%">
                <h4>Ecografia</h4>
            </div>
            <div class="col-sm-12" style="margin-top: 1%">
                <asp:Repeater ID="Repeater4" runat="server" OnItemCommand="Repeater4_ItemCommand">
                    <HeaderTemplate>
                        <table class="table">
                            <thead>
                                <tr>
                                    <th>Nome do Paciente</th>
                                    <th>Box/Quarto</th>
                                    <th>Setor</th>
                                    <th>Especialidade</th>
                                    <th>Procedimento</th>
                                    <th>Obs. Paciente</th>
                                    <th>Pedido</th>
                                    <th>Hora do pedido</th>
                                    <th>Status do Exame</th>
                                    <th>Baixa</th>
                                    <th>Hora da baixa</th>
                                    <th>Cancelado</th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>

                            <td>
                                <asp:LinkButton ID="LinkButton3" runat="server" Text='<%#Eval("nome_pac") %>' CommandArgument='<%#Eval("id")+ "," + Eval("nome_pac")+ "," + Eval("quarto")+ "," + Eval("local")%>'></asp:LinkButton></td>
                            <td>
                                <asp:Label ID="Label9" runat="server" Text='<%#Eval("quarto") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("local") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("especial") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label6" runat="server" Text='<%#Eval("procede") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label10" runat="server" Text='<%#Eval("obs") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label11" runat="server" Text='<%#Eval("nome_completo") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label5" runat="server" Text='<%# Eval("hora_pedido") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text='<%#Eval("baixa") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label7" runat="server" Text='<%#Eval("usuario_libera") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label8" runat="server" Text='<%# Eval("hora_libera", "{0:t}") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text='<%#Eval("status") %>'></asp:Label></td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody>
                                            </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>

        <div id="div_mamo" class="collapse" style="margin-left: 5%; margin-right: 5%">
            <div class="title" style="margin-top: 2%">
                <h4>Mamografia</h4>
            </div>
            <div class="col-sm-12" style="margin-top: 1%">
                <asp:Repeater ID="Repeater7" runat="server" OnItemCommand="Repeater7_ItemCommand">
                    <HeaderTemplate>
                        <table class="table">
                            <thead>
                                <tr>
                                    <th>Nome do Paciente</th>
                                    <th>Box/Quarto</th>
                                    <th>Setor</th>
                                    <th>Especialidade</th>
                                    <th>Procedimento</th>
                                    <th>Obs. Paciente</th>
                                    <th>Pedido</th>
                                    <th>Hora do pedido</th>
                                    <th>Status do Exame</th>
                                    <th>Baixa</th>
                                    <th>Hora da baixa</th>
                                    <th>Cancelado</th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>

                            <td>
                                <asp:LinkButton ID="LinkButton3" runat="server" Text='<%#Eval("nome_pac") %>' CommandArgument='<%#Eval("id")+ "," + Eval("nome_pac")+ "," + Eval("quarto")+ "," + Eval("local")%>'></asp:LinkButton></td>
                            <td>
                                <asp:Label ID="Label9" runat="server" Text='<%#Eval("quarto") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("local") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("especial") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label6" runat="server" Text='<%#Eval("procede") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label10" runat="server" Text='<%#Eval("obs") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label11" runat="server" Text='<%#Eval("nome_completo") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label5" runat="server" Text='<%# Eval("hora_pedido") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text='<%#Eval("baixa") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label7" runat="server" Text='<%#Eval("usuario_libera") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label8" runat="server" Text='<%# Eval("hora_libera", "{0:t}") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text='<%#Eval("status") %>'></asp:Label></td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody>
                                            </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
        <div id="div_angioresso" class="collapse" style="margin-left: 5%; margin-right: 5%">
            <div class="title" style="margin-top: 2%">
                <h4>Angioressonâncias</h4>
            </div>
            <div class="col-sm-12" style="margin-top: 1%">
                <asp:Repeater ID="Repeater6" runat="server" OnItemCommand="Repeater6_ItemCommand">
                    <HeaderTemplate>
                        <table class="table">
                            <thead>
                                <tr>
                                    <th>Nome do Paciente</th>
                                    <th>Box/Quarto</th>
                                    <th>Setor</th>
                                    <th>Especialidade</th>
                                    <th>Procedimento</th>
                                    <th>Obs. Paciente</th>
                                    <th>Pedido</th>
                                    <th>Hora do pedido</th>
                                    <th>Status do Exame</th>
                                    <th>Baixa</th>
                                    <th>Hora da baixa</th>
                                    <th>Cancelado</th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>

                            <td>
                                <asp:LinkButton ID="LinkButton3" runat="server" Text='<%#Eval("nome_pac") %>' CommandArgument='<%#Eval("id")+ "," + Eval("nome_pac")+ "," + Eval("quarto")+ "," + Eval("local")%>'></asp:LinkButton></td>
                            <td>
                                <asp:Label ID="Label9" runat="server" Text='<%#Eval("quarto") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("local") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("especial") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label6" runat="server" Text='<%#Eval("procede") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label10" runat="server" Text='<%#Eval("obs") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label11" runat="server" Text='<%#Eval("nome_completo") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label5" runat="server" Text='<%# Eval("hora_pedido") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text='<%#Eval("baixa") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label7" runat="server" Text='<%#Eval("usuario_libera") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label8" runat="server" Text='<%# Eval("hora_libera", "{0:t}") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text='<%#Eval("status") %>'></asp:Label></td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody>
                                            </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
        <div id="div_angiotomo" class="collapse" style="margin-left: 5%; margin-right: 5%">
            <div class="title" style="margin-top: 2%">
                <h4>Angiotomografias</h4>
            </div>
            <div class="col-sm-12" style="margin-top: 1%">
                <asp:Repeater ID="Repeater5" runat="server" OnItemCommand="Repeater5_ItemCommand">
                    <HeaderTemplate>
                        <table class="table">
                            <thead>
                                <tr>
                                    <th>Nome do Paciente</th>
                                    <th>Box/Quarto</th>
                                    <th>Setor</th>
                                    <th>Especialidade</th>
                                    <th>Procedimento</th>
                                    <th>Obs. Paciente</th>
                                    <th>Pedido</th>
                                    <th>Hora do pedido</th>
                                    <th>Status do Exame</th>
                                    <th>Baixa</th>
                                    <th>Hora da baixa</th>
                                    <th>Cancelado</th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>

                            <td>
                                <asp:LinkButton ID="LinkButton3" runat="server" Text='<%#Eval("nome_pac") %>' CommandArgument='<%#Eval("id")+ "," + Eval("nome_pac")+ "," + Eval("quarto")+ "," + Eval("local")%>'></asp:LinkButton></td>
                            <td>
                                <asp:Label ID="Label9" runat="server" Text='<%#Eval("quarto") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("local") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("especial") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label6" runat="server" Text='<%#Eval("procede") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label10" runat="server" Text='<%#Eval("obs") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label11" runat="server" Text='<%#Eval("nome_completo") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label5" runat="server" Text='<%# Eval("hora_pedido") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text='<%#Eval("baixa") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label7" runat="server" Text='<%#Eval("usuario_libera") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label8" runat="server" Text='<%# Eval("hora_libera", "{0:t}") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text='<%#Eval("status") %>'></asp:Label></td>
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
        $("#resso").click(function () {
            $("#div_resso").collapse('toggle');
        });
        $("#tomo").click(function () {
            $("#div_tomo").collapse('toggle');
        });
        $("#raio").click(function () {
            $("#div_raio").collapse('toggle');
        });
        $("#eco").click(function () {
            $("#div_eco").collapse('toggle');
        });
        $("#angior").click(function () {
            $("#div_angioresso").collapse('toggle');
            $("#div_angiotomo").collapse('toggle');
        });
        function esconde() {
            document.getElementById('MyAlert').style.display = 'none';
        }

        setTimeout(esconde, 4000);


        $("td").each(function () {
            if ($(this).find("span").text() == 'Exame Cancelado') {
                $(this).css({ "color": "#fff", "background-color": "rgb(255, 0, 0)" })
            }
        })

        function valida() {
            document.getElementById('Content_TextBox4').required = true
            document.getElementById('Content_DropDownList1').required = true
        }
        
    </script>
    <script>
        function ShowPopup(body) {
            $("#MyPopup .modal-body").html(body);
            $("#MyPopup").modal("show");
        }
    </script>
    <div id="MyPopup" class="modal fade" role="dialog">
        <div class="modal-dialog" style="margin-top: 7%;" role="document">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <p style="font-size: 20px; text-align: center;">Baixa de Exame</p>
                </div>
                <div class="modal-body">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="form-group col-sm-6">
                                <span style="font-weight: bold">Nome do Paciente</span>
                                <asp:TextBox ID="TextBox2" CssClass="form-control ng-pristine ng-untouched ng-valid ng-empty" runat="server" Enabled="false"></asp:TextBox>
                            </div>
                            <div class="form-group col-sm-2">
                                <span style="font-weight: bold">Box/Quarto</span>
                                <asp:TextBox ID="TextBox1" CssClass="form-control ng-pristine ng-untouched ng-valid ng-empty" runat="server" Enabled="false"></asp:TextBox>
                            </div>
                            <div class="form-group col-sm-4">
                                <span style="font-weight: bold">Setor</span>
                                <asp:TextBox ID="TextBox3" CssClass="form-control ng-pristine ng-untouched ng-valid ng-empty" runat="server" Enabled="false"></asp:TextBox>
                            </div>
                            <div class="form-group col-sm-6">
                                <asp:Button ID="Button1" runat="server" CssClass="botao" Text="Baixar exame" OnClick="Button1_Click" />
                            </div>
                            <div class="form-group col-sm-6">
                                <asp:Button ID="Button2" runat="server" CssClass="botao" Style="background: #f50000;" Text="Cancelar exame" OnClick="Button2_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
