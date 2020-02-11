<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pedidos.aspx.cs" Inherits="Leitos_Principal_Pedidouti_pedidos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Pedido de Leitos | Leitos Rocio</title>
    <link rel="icon" type="imagem/ico" href="../../images/favicon.ico" />
    <link href="../css/StyleSheet.css" rel='stylesheet' type='text/css' />
    <meta http-equiv="refresh" content="30" />
    <script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
    <link href="../css/bootstrap.min.css" rel='stylesheet' type='text/css' />
    <!-- Custom Theme files -->
    <link href="../css/style.css" rel='stylesheet' type='text/css' />
    <link href="../css/font-awesome.css" rel="stylesheet">
    <script src="../js/jquery.min.js"> </script>
    <!-- Mainly scripts -->
    <script src="../js/jquery.metisMenu.js"></script>
    <script src="../js/jquery.slimscroll.min.js"></script>
    <!-- Custom and plugin javascript -->
    <link href="../css/custom.css" rel="stylesheet">
    <script src="../js/custom.js"></script>
    <script src="../js/screenfull.js"></script>
    <script>
        console.log('');
    </script>
    <script>
        $(function () {
            $('#supported').text('Supported/allowed: ' + !!screenfull.enabled);

            if (!screenfull.enabled) {
                return false;
            }
            $('#toggle').click(function () {
                screenfull.toggle($('#container')[0]);
            });
        });
    </script>
    <script type="text/javascript">
        function notificacao() {
            document.addEventListener('DOMContentLoaded', function () {
                if (!Notification) {
                    alert('Desktop notifications not available in your browser. Try Chromium.');
                    return;
                }
                if (Notification.permission !== "granted")
                    Notification.requestPermission();
                else {
                    var pres = document.getElementById('<%=TextBox3.ClientID %>').value;
                    var leito = document.getElementById('<%=TextBox4.ClientID %>').value;
                    var session = document.getElementById('<%=TextBox5.ClientID %>').value;
                    var notificacao = new Notification("Leito liberado", {
                        icon: '../../images/favicon.ico',
                        body: "Liberado para prescrição " + pres + " Leito " + leito,
                        requireINteraction: true,
                    });
                    notificacao.onclick = function () {
                        window.open("pedidos.aspx?session=" + session);
                    }
                }
            })
        }
    </script>
    <script src="../js/pie-chart.js" type="text/javascript"></script>
    <script src="../js/skycons.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="wrapper">
            <nav class="navbar-default navbar-static-top" role="navigation">
                <div class="navbar-header">
                    <h1>
                        <img src="../../images/HOSP ROCIO.png" style="width: 200px; margin-left: 2px; margin-top: 2px; margin-bottom: 2px" /></h1>
                </div>
                <div class=" border-bottom">
                    <div class="full-left">
                        <div class="clearfix"></div>
                    </div>
                    <div class="drop-men">
                        <ul class=" nav_1">
                        </ul>
                    </div>
                    <div class="clearfix"></div>
                    <div class="navbar-default sidebar" role="navigation">
                        <div class="sidebar-nav navbar-collapse">
                            <ul class="nav" id="side-menu">
                                <li>
                                    <asp:LinkButton ID="LinkButton1" class=" hvr-bounce-to-right" runat="server" OnClick="LinkButton1_Click"><i class="fa fa-desktop nav_icon"></i><span class="nav-label">Inicio</span></asp:LinkButton>
                                </li>
                                <li>
                                    <a href="#" class=" hvr-bounce-to-right"><i class="fa fa-indent nav_icon"></i><span class="nav-label">Leitos</span><span class="fa arrow"></span></a>
                                    <ul class="nav nav-second-level">
                                        <li>
                                            <asp:LinkButton ID="LinkButton3" class=" hvr-bounce-to-right" runat="server" OnClick="LinkButton3_Click"><i class="fa fa-desktop nav_icon"></i><span class="nav-label">Pedir Transferencia</span></asp:LinkButton></li>
                                    </ul>
                                </li>
                                <li>
                                    <a href="#" class=" hvr-bounce-to-right"><i class="fa fa-indent nav_icon"></i><span class="nav-label">Exames</span><span class="fa arrow"></span></a>
                                    <ul class="nav nav-second-level">
                                        <li>
                                            <asp:LinkButton ID="LinkButton2" class=" hvr-bounce-to-right" runat="server" OnClick="LinkButton2_Click"><i class="fa fa-desktop nav_icon"></i><span class="nav-label">Solicitar exames</span></asp:LinkButton></li>
                                    </ul>
                                </li>
                                <li>
                                    <a href="#" class=" hvr-bounce-to-right"><i class="fa fa-indent nav_icon"></i><span class="nav-label">Assistente Social</span><span class="fa arrow"></span></a>
                                    <ul class="nav nav-second-level">
                                        <li>
                                            <asp:LinkButton ID="LinkButton6" class=" hvr-bounce-to-right" runat="server" OnClick="LinkButton6_Click"><i class="fa fa-desktop nav_icon"></i><span class="nav-label">Pedir alta</span></asp:LinkButton></li>
                                    </ul>
                                </li>
                                <li>
                                    <a href="#" class=" hvr-bounce-to-right"><i class="fa fa-indent nav_icon"></i><span class="nav-label">Perfil</span><span class="fa arrow"></span></a>
                                    <ul class="nav nav-second-level">
                                        <li>
                                            <asp:LinkButton ID="LinkButton5" class=" hvr-bounce-to-right" runat="server" OnClick="LinkButton5_Click"><i class="fa fa-desktop nav_icon"></i><span class="nav-label">Alterar meu perfil</span></asp:LinkButton></li>
                                    </ul>
                                </li>
                                <li>
                                    <asp:LinkButton ID="LinkButton4" class=" hvr-bounce-to-right" runat="server" OnClick="LinkButton4_Click"><i class="fa fa-desktop nav_icon"></i><span class="nav-label">Sair</span></asp:LinkButton>
                                </li>
                            </ul>
                        </div>
                    </div>
            </nav>
            <div id="page-wrapper" class="gray-bg dashbard-1">
                <div class="banner">
                    <h1>PEDIDO DE LEITOS</h1>
                    <br />
                    <div style="display: none">
                        <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="Label7" runat="server"></asp:Label>
                        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                    </div>
                    <h2>Leitos que estão sendo pedidos
                            para transferência</h2>
                    <br />
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center" Width="100%" GridLines="Horizontal" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt">
                        <AlternatingRowStyle CssClass="alt" />
                        <Columns>
                            <asp:TemplateField HeaderText="Leito liberado">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Leito") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Leito") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Prescrição">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("num_atendimento") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("num_atendimento") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Nome do Paciente">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("nome_pac") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("nome_pac") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Quarto">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("quarto") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("quarto") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Diagnostico">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("diagnostico") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("diagnostico") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Convenio">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("convenio") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("convenio") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>

                        <PagerStyle CssClass="pgr" />

                    </asp:GridView>

                    <br />
                    <br />
                    <h2>Exames de imagem solicitados</h2>
                    <br />
                    <asp:GridView ID="GridView2" Width="100%" EmptyDataText="Sem registros" GridLines="Horizontal" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridView2_RowDataBound">
                        <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>

                        <Columns>
                            <asp:BoundField DataField="status" HeaderText="Cancelado">
                                <ItemStyle Font-Bold="True" ForeColor="White" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Status do exame" DataField="baixa" />
                            <asp:BoundField DataField="especial" HeaderText="Especialidade" />
                            <asp:BoundField DataField="procede" HeaderText="Procedimento" />
                            <asp:BoundField DataField="nome_pac" HeaderText="Nome do Paciente" />
                            <asp:BoundField DataField="quarto" HeaderText="Quarto-Leito" />
                            <asp:BoundField DataField="nome_completo" HeaderText="Pedido" />
                            <asp:BoundField DataField="usuario_libera" HeaderText="Quem agendou" />
                            <asp:TemplateField HeaderText="Data e Hora do agendamento">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("data_libera", "{0:d}") %>'></asp:Label>
                                    |
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("hora_libera") %>'></asp:Label>
                                </ItemTemplate>
                                <ControlStyle ForeColor="Black" />
                                <ItemStyle ForeColor="Black" />
                            </asp:TemplateField>
                        </Columns>

                        <PagerStyle CssClass="pgr"></PagerStyle>
                    </asp:GridView>
                    <br />
                    <br />

                    <asp:GridView ID="GridView3" Width="100%" EmptyDataText="Sem registros" GridLines="Horizontal" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridView2_RowDataBound">
                        <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>

                        <Columns>
                            <asp:BoundField HeaderText="Status do exame" DataField="status" />
                            <asp:BoundField DataField="especial" HeaderText="Especialidade" />
                            <asp:BoundField DataField="procede" HeaderText="Procedimento" />
                            <asp:BoundField DataField="nome_pac" HeaderText="Nome do Paciente" />
                            <asp:BoundField DataField="quarto" HeaderText="quarto" />
                            <asp:BoundField DataField="nome_completo" HeaderText="Pedido" />
                            <asp:TemplateField HeaderText="Data e Hora do cancelamento">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("data_cancela", "{0:d}") %>'></asp:Label>
                                    |
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("hora_cancela") %>'></asp:Label>
                                </ItemTemplate>
                                <ControlStyle ForeColor="Black" />
                                <ItemStyle ForeColor="Black" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="usuario_cancela" HeaderText="Cancelado por" />
                        </Columns>

                        <PagerStyle CssClass="pgr"></PagerStyle>
                    </asp:GridView>
                    <h2>Altas solicitadas ao serviço social</h2>
                    <asp:GridView ID="GridView4" Width="100%" EmptyDataText="Sem registros" GridLines="Horizontal" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridView4_RowDataBound">
                        <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>


                        <Columns>
                            <asp:BoundField DataField="num_atendimento" HeaderText="N° Atendimento" />
                            <asp:BoundField DataField="nome_pac" HeaderText="Nome do Paciente" />
                            <asp:BoundField DataField="leito" HeaderText="Leito" />
                            <asp:BoundField DataField="obs" HeaderText="Obs serviço social"/>
                        </Columns>
                        <PagerStyle CssClass="pgr"></PagerStyle>
                    </asp:GridView>
                </div>
            </div>
        </div>
        <span id="tempo">--</span>
        <div id="link" style="display: none">
            <p><a href="https://ibogos.wordpress.com">Você já pode acessar meu blog clicando aqui!</a></p>
        </div>
        <script>
            contador();
        </script>
        <script src="../js/scripts.js"></script>
        <!--//scrolling js-->
        <script src="../js/bootstrap.min.js"> </script>
    </form>
</body>
</html>
