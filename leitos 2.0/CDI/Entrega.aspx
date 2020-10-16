<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Entrega.aspx.cs" MasterPageFile="~/CDI/MasterPage.master" Inherits="CDI_Entrega" %>

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
                <div class="title" style="margin-top: 5%" id="topo">
                    <h1>GERENCIAMENTO DE EXAMES</h1>
                </div>
            </div>
             <div id="MyAlert" class="alert alert-success" role="alert" style="visibility: hidden">
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
            <div class="form-group row">
                <div class="col-sm-4">
                    <asp:TextBox ID="TextBox4" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="col-sm-4">
                    <asp:Button ID="Button1" runat="server" CssClass="botao" Text="Buscar" OnClick="Button1_Click" />
                </div>
                <div class="col-sm-12" style="margin-top: 1%">
                    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                        <HeaderTemplate>
                            <table class="table">
                                <thead>
                                    <tr>
                                        <th>Atendimento</th>
                                        <th>Prescrição</th>
                                        <th>Exame</th>
                                        <th>Impressão</th>
                                        <th>Data Impressão</th>
                                        <th>Data Reimpressão</th>
                                        <th>Motivo Reimpressão</th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                <asp:LinkButton ID="LinkButton3" runat="server" Text='<%#Eval("atendimento") %>' CommandArgument='<%#Eval("atendimento") + "," + Eval("prescricao") + "," + Eval("exame") + "," + Eval("sequencia")%>'></asp:LinkButton></td>
                                <td>
                                    <asp:Label ID="Label9" runat="server" Text='<%#Eval("prescricao") %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("exame") %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("nome_completo") %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label6" runat="server" Text='<%#Eval("data", "{0:d}") %>'></asp:Label>
                                    | 
                                        <asp:Label ID="Label13" runat="server" Text='<%# Eval("hora") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("data_reimpressao", "{0:d}") %>'></asp:Label>
                                    | 
                                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("hora_reimpressao") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label5" runat="server" Text='<%#Eval("motivo_reimpressao") %>'></asp:Label></td>

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
    <script>
        document.getElementById('Content_TextBox4').placeholder = "Digite o numero do atendimento ou prescrição";
        $('#Content_TextBox4').prop('required', true);
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
                <div class="modal-body">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="form-group col-sm-12">
                                <asp:Button ID="Button2" runat="server" CssClass="botao" Text="reimpressão" OnClick="Button2_Click"/>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
