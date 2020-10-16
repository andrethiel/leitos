<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Leitos/MasterPage.master" CodeFile="Principal.aspx.cs" Inherits="Leitos_Principal" %>

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
            <div class="col-14" style="margin-top: 1%">
                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                    <HeaderTemplate>
                        <table class="table">
                            <thead>
                                <tr>
                                    <th colspan="12" style="font-size: 19px; text-align: center; background-color: orange">UTI Coronariana</th>
                                </tr>
                                <tr>
                                    <th>N° Atendimento</th>
                                    <th>Nome do Paciente</th>
                                    <th>Sexo</th>
                                    <th>UTI</th>
                                    <th>Box</th>
                                    <th>Pedido</th>
                                    <th>Diagnostico</th>
                                    <th>Data e Hora do Pedido</th>
                                    <th>Obs. Paciente</th>
                                    <th>Especialidade</th>
                                    <th>Convenio</th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:LinkButton ID="LinkButton3" runat="server" Text='<%#Eval("num_atendimento") %>' CommandArgument='<%#Eval("id")  + "," + Eval("num_atendimento")%>'></asp:LinkButton></td>
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
                                <asp:Label ID="Label4" runat="server" Text='<%#Eval("data_pedido", "{0:d}") %>'></asp:Label>
                                | 
                                <asp:Label ID="Label5" runat="server" Text='<%# Eval("hora_pedido") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label9" runat="server" Text='<%#Eval("obs") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label10" runat="server" Text='<%#Eval("especial") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label11" runat="server" Text='<%#Eval("Convenio") %>'></asp:Label></td>

                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody>
                                            </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
            <div class="col-14" style="margin-top: 1%">
                <asp:Repeater ID="Repeater2" runat="server" OnItemCommand="Repeater2_ItemCommand">
                    <HeaderTemplate>
                        <table class="table">
                            <thead>
                                <tr>
                                    <th colspan="12" style="font-size: 19px; text-align: center; background-color: cornflowerblue">UTI Azul</th>
                                </tr>
                                <tr>
                                    <th>N° Atendimento</th>
                                    <th>Nome do Paciente</th>
                                    <th>Sexo</th>
                                    <th>UTI</th>
                                    <th>Box</th>
                                    <th>Pedido</th>
                                    <th>Diagnostico</th>
                                    <th>Data e Hora do Pedido</th>
                                    <th>Obs. Paciente</th>
                                    <th>Especialidade</th>
                                    <th>Convenio</th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:LinkButton ID="LinkButton3" runat="server" Text='<%#Eval("num_atendimento") %>' CommandArgument='<%#Eval("id")  + "," + Eval("num_atendimento")%>'></asp:LinkButton></td>
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
                                <asp:Label ID="Label4" runat="server" Text='<%#Eval("data_pedido", "{0:d}") %>'></asp:Label>
                                | 
                                <asp:Label ID="Label5" runat="server" Text='<%# Eval("hora_pedido") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label9" runat="server" Text='<%#Eval("obs") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label10" runat="server" Text='<%#Eval("especial") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label11" runat="server" Text='<%#Eval("Convenio") %>'></asp:Label></td>

                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody>
                                            </table>
                    </FooterTemplate>
                </asp:Repeater>
                <div class="col-14" style="margin-top: 1%">
                    <asp:Repeater ID="Repeater3" runat="server" OnItemCommand="Repeater3_ItemCommand">
                        <HeaderTemplate>
                            <table class="table">
                                <thead>
                                    <tr>
                                        <th colspan="12" style="font-size: 19px; text-align: center; background-color: #c8a2c8">UTI Lilas</th>
                                    </tr>
                                    <tr>
                                        <th>N° Atendimento</th>
                                        <th>Nome do Paciente</th>
                                        <th>Sexo</th>
                                        <th>UTI</th>
                                        <th>Box</th>
                                        <th>Pedido</th>
                                        <th>Diagnostico</th>
                                        <th>Data e Hora do Pedido</th>
                                        <th>Obs. Paciente</th>
                                        <th>Especialidade</th>
                                        <th>Convenio</th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="LinkButton3" runat="server" Text='<%#Eval("num_atendimento") %>' CommandArgument='<%#Eval("id")  + "," + Eval("num_atendimento")%>'></asp:LinkButton></td>
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
                                    <asp:Label ID="Label4" runat="server" Text='<%#Eval("data_pedido", "{0:d}") %>'></asp:Label>
                                    | 
                                <asp:Label ID="Label5" runat="server" Text='<%# Eval("hora_pedido") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label9" runat="server" Text='<%#Eval("obs") %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label10" runat="server" Text='<%#Eval("especial") %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label11" runat="server" Text='<%#Eval("Convenio") %>'></asp:Label></td>

                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </tbody>
                                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
                <div class="col-14" style="margin-top: 1%">
                    <asp:Repeater ID="Repeater4" runat="server" OnItemCommand="Repeater4_ItemCommand">
                        <HeaderTemplate>
                            <table class="table">
                                <thead>
                                    <tr>
                                        <th colspan="12" style="font-size: 19px; text-align: center; background-color: lightgreen">UTI Verde</th>
                                    </tr>
                                    <tr>
                                        <th>N° Atendimento</th>
                                        <th>Nome do Paciente</th>
                                        <th>Sexo</th>
                                        <th>UTI</th>
                                        <th>Box</th>
                                        <th>Pedido</th>
                                        <th>Diagnostico</th>
                                        <th>Data e Hora do Pedido</th>
                                        <th>Obs. Paciente</th>
                                        <th>Especialidade</th>
                                        <th>Convenio</th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="LinkButton3" runat="server" Text='<%#Eval("num_atendimento") %>' CommandArgument='<%#Eval("id")  + "," + Eval("num_atendimento")%>'></asp:LinkButton></td>
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
                                    <asp:Label ID="Label4" runat="server" Text='<%#Eval("data_pedido", "{0:d}") %>'></asp:Label>
                                    | 
                                <asp:Label ID="Label5" runat="server" Text='<%# Eval("hora_pedido") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label9" runat="server" Text='<%#Eval("obs") %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label10" runat="server" Text='<%#Eval("especial") %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label11" runat="server" Text='<%#Eval("Convenio") %>'></asp:Label></td>

                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </tbody>
                                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div class="col-14" style="margin-top: 1%">
                <asp:Repeater ID="Repeater5" runat="server" OnItemCommand="Repeater5_ItemCommand">
                    <HeaderTemplate>
                        <table class="table">
                            <thead>
                                <tr>
                                    <th colspan="12" style="font-size: 19px; text-align: center; background-color: #a0d9d0">Centro Cirurgico</th>
                                </tr>
                                <tr>
                                    <th>N° Atendimento</th>
                                    <th>Nome do Paciente</th>
                                    <th>Sexo</th>
                                    <th>Local</th>
                                    <th>Pedido</th>
                                    <th>Data e Hora do Pedido</th>
                                    <th>Especialidade</th>
                                    <th>Convenio</th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:LinkButton ID="LinkButton3" runat="server" Text='<%#Eval("num_atendimento") %>' CommandArgument='<%#Eval("id")  + "," + Eval("num_atendimento")%>'></asp:LinkButton></td>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("nome_pac") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("sexo") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label6" runat="server" Text='<%#Eval("local") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label7" runat="server" Text='<%#Eval("nome_completo") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text='<%#Eval("data_pedido", "{0:d}") %>'></asp:Label>
                                | 
                                <asp:Label ID="Label5" runat="server" Text='<%# Eval("hora_pedido") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label10" runat="server" Text='<%#Eval("especial") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label12" runat="server" Text='<%#Eval("convenio") %>'></asp:Label></td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody>
                                            </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
            <div class="col-14" style="margin-top: 1%">
                <asp:Repeater ID="Repeater6" runat="server" OnItemCommand="Repeater6_ItemCommand">
                    <HeaderTemplate>
                        <table class="table">
                            <thead>
                                <tr>
                                    <th colspan="12" style="font-size: 19px; text-align: center; background-color: lightseagreen">Transferencias</th>
                                </tr>
                                <tr>
                                    <th>N° Atendimento</th>
                                    <th>Nome do Paciente</th>
                                    <th>Sexo</th>
                                    <th>Local</th>
                                    <th>Quarto - Leito</th>
                                    <th>Pedido</th>
                                    <th>Diagnostico</th>
                                    <th>Data e Hora do Pedido</th>
                                    <th>Motivo da transferencia</th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:LinkButton ID="LinkButton3" runat="server" Text='<%#Eval("num_atendimento") %>' CommandArgument='<%#Eval("id")  + "," + Eval("num_atendimento")%>'></asp:LinkButton></td>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("nome_pac") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("sexo") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label6" runat="server" Text='<%#Eval("local") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text='<%#Eval("quarto") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label7" runat="server" Text='<%#Eval("nome_completo") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label8" runat="server" Text='<%#Eval("diagnostico") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text='<%#Eval("data_pedido", "{0:d}") %>'></asp:Label>
                                | 
                                <asp:Label ID="Label5" runat="server" Text='<%# Eval("hora_pedido") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label11" runat="server" Text='<%#Eval("Motivo") %>'></asp:Label></td>

                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody>
                                            </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>

             <div class="col-14" style="margin-top: 1%">
                <asp:Repeater ID="Repeater7" runat="server">
                    <HeaderTemplate>
                        <table class="table">
                            <thead>
                                <tr>
                                    <th colspan="12" style="font-size: 19px; text-align: center; background-color: rgb(255, 0, 0)">Altas Canceladas</th>
                                </tr>
                                <tr>
                                    <th>Status</th>
                                    <th>N° Atendimento</th>
                                    <th>Nome do Paciente</th>
                                    <th>Local</th>
                                    <th>Quarto - Leito</th>
                                    <th>Data e Hora do Cancelamento</th>
                                    <th>Cancelado por</th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Label ID="Label13" runat="server" Text='<%#Eval("leito") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label14" runat="server" Text='<%#Eval("num_atendimento") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("nome_pac") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label18" runat="server" Text='<%#Eval("uti") %>'></asp:Label>
                                <%--<asp:Label ID="Label15" runat="server" Text='<%#String.Format("{0},{1}", Eval("uti"), Eval("local")) %>'></asp:Label>--%></td>
                            <td>
                                <asp:Label ID="Label16" runat="server" Text='<%#Eval("box") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text='<%#Eval("data_libera", "{0:d}") %>'></asp:Label>
                                | 
                                <asp:Label ID="Label5" runat="server" Text='<%# Eval("hora_libera") %>'></asp:Label>
                                <td>
                                <asp:Label ID="Label17" runat="server" Text='<%#Eval("nome_completo") %>'></asp:Label></td>
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
        <script type="text/javascript">
            function ShowDo(body) {
                $("#solciita .modal-body").html(body);
                $("#solciita").modal("show");
            }
            function fechar() {
                document.getElementById('MyAlert').style.display = 'none';
            }
            
        </script>
        <div id="solciita" class="modal" role="dialog">
            <div class="modal-dialog modal-dialog-centered" role="document">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <p style="font-size: 20px; text-align: center;">Leitos</p>
                    </div>
                    <div class="modal-body">
                        <div class="container">
                            <div class="form-group row">
                                <div class="col-sm-3" style="margin-top: 1%">
                                    <span>Posto</span>
                                    <asp:TextBox ID="TextBox1" CssClass="form-control ng-pristine ng-untouched ng-valid ng-empty" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-sm-4" style="margin-top: 1%">
                                    <span>Quarto</span>
                                    <asp:TextBox ID="TextBox2" CssClass="form-control ng-pristine ng-untouched ng-valid ng-empty" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-sm-3" style="margin-top: 1%">
                                    <span>Leito</span>
                                    <asp:TextBox ID="TextBox3" CssClass="form-control ng-pristine ng-untouched ng-valid ng-empty" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-sm-10" style="margin-top: 1%">
                                    <asp:Button ID="Button1" CssClass="botao" runat="server" Text="Confirmar Leito" OnClick="Button1_Click" />
                                </div>
                                <div class="col-sm-10" style="margin-top: 1%">
                                    <asp:Button ID="Button3" CssClass="botao" runat="server" Text="Confirmar Leito" OnClick="Button3_Click" />
                                </div>
                                <div class="col-sm-10" style="margin-top: 1%">
                                    <asp:Button ID="Button2" CssClass="botao" runat="server" Style="background: #f50000;" Text="Cancelar Pedido de leito" OnClick="Button2_Click" />
                                </div>
                                
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>