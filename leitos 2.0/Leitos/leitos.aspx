<%@ Page Language="C#" AutoEventWireup="true" CodeFile="leitos.aspx.cs" MasterPageFile="~/Leitos/MasterPage.master" Inherits="Leitos_leitos" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    <link rel="icon" type="imagem/ico" href="favicon.ico" />
    <link href="../css/bootstrap.css" rel='stylesheet' type='text/css' />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>

    <script>
        if (document.cookie.indexOf("id") < 0) {
            window.location.href = '../Default.aspx';
        };
        function sucesso() {
            var div = document.getElementById('MyAlert').style.display = 'block';
        };
        function error() {
            var div = document.getElementById('MyAlert').style.display = 'block';
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
    </style>
    <div class="swichermainbx clearfix" style="margin-top: 80px">
        <div class="container">
            <div class="form-group row">
                <div class="title" style="margin-top: 5%">
                    <h1>GERENCIAMENTO DE LEITOS</h1>
                </div>
            </div>
            <div class="col-sm-10" style="margin-top: 1%">
                <div id="MyAlert" class="alert alert-success" role="alert" style="display: none">
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
            </div>
        </div>
        <div class="container">
            <div class="col-14" style="margin-top: 1%">
                <asp:Repeater ID="Repeater1" runat="server">
                    <HeaderTemplate>
                        <table class="table">
                            <thead>
                                <tr>
                                    <th>N° Atendimento</th>
                                    <th>Nome do Paciente</th>
                                    <th>Sexo</th>
                                    <th>UTI</th>
                                    <th>Box</th>
                                    <th>Pedido</th>
                                    <th>Diagnostico</th>
                                    <th>Especialidade</th>
                                    <th>Convenio</th>
                                    <th>Leito Liberado</th>
                                    <th>Hora da liberação</th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Label ID="Label9" runat="server" Text='<%#Eval("num_atendimento") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("nome_pac") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("sexo") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label6" runat="server" Text='<%#Eval("uti") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text='<%#Eval("box") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label7" runat="server" Text='<%#Eval("nome_completo") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label8" runat="server" Text='<%#Eval("diagnostico") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label10" runat="server" Text='<%#Eval("especial") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label11" runat="server" Text='<%#Eval("Convenio") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text='<%#Eval("leito") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label5" runat="server" Text='<%# Eval("hora_libera") %>'></asp:Label></td>
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
</asp:Content>
