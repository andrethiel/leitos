<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pedidos.aspx.cs" Inherits="Leitos_Principal_Pedidouti_pedidos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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
<script src="../js/pie-chart.js"type="text/javascript"></script>
    <script src="../js/skycons.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="wrapper">
        <nav class="navbar-default navbar-static-top" role="navigation">
             <div class="navbar-header">
                 <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
               <h1><img src="../../images/HOSP ROCIO.png" style="width:200px;margin-left:2px;margin-top:2px; margin-bottom:2px" /></h1>         
			   </div>
            <div class=" border-bottom">
        	<div class="full-left">
            <div class="clearfix"></div>
           </div>
            <div class="drop-men" >
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
                        <a href="#" class=" hvr-bounce-to-right"><i class="fa fa-indent nav_icon"></i> <span class="nav-label">Leitos</span><span class="fa arrow"></span></a>
                        <ul class="nav nav-second-level">
                            <li><asp:LinkButton ID="LinkButton3" class=" hvr-bounce-to-right" runat="server" OnClick="LinkButton3_Click"><i class="fa fa-desktop nav_icon"></i><span class="nav-label">Pedido de Leito</span></asp:LinkButton></li>
                        </ul>
                    </li>
                    <li>
                        <a href="#" class=" hvr-bounce-to-right"><i class="fa fa-indent nav_icon"></i> <span class="nav-label">Exames</span><span class="fa arrow"></span></a>
                        <ul class="nav nav-second-level">
                            <li><asp:LinkButton ID="LinkButton2" class=" hvr-bounce-to-right" runat="server" OnClick="LinkButton2_Click"><i class="fa fa-desktop nav_icon"></i><span class="nav-label">Solicitar Exame</span></asp:LinkButton></li>
                        </ul>
                    </li>
                    <li>
                        <a href="#" class=" hvr-bounce-to-right"><i class="fa fa-indent nav_icon"></i> <span class="nav-label">Perfil</span><span class="fa arrow"></span></a>
                        <ul class="nav nav-second-level">
                            <li><asp:LinkButton ID="LinkButton5" class=" hvr-bounce-to-right" runat="server" OnClick="LinkButton5_Click"><i class="fa fa-desktop nav_icon"></i><span class="nav-label">Alterar meu perfil</span></asp:LinkButton></li>
                        </ul>
                    </li>
                    <li>
                        <asp:LinkButton ID="LinkButton4" class=" hvr-bounce-to-right" runat="server" OnClick="LinkButton4_Click1"><i class="fa fa-desktop nav_icon"></i><span class="nav-label">Sair</span></asp:LinkButton>
                    </li>
                    </ul>
                    </div>
                </div>
                </nav>
            <div id="page-wrapper" class="gray-bg dashbard-1">
                <div class="banner">
		         <h1>PEDIDO DE LEITOS</h1><br />
                    
                    <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label>
                        <h2>
                            Leitos que estão sendo pedidos
                        </h2>
                    <br />
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%" EmptyDataText="Sem registros" GridLines="Horizontal" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt">
                        <Columns>
                            <asp:BoundField DataField="Leito" HeaderText="Leito liberado" />
                            <asp:TemplateField HeaderText="Prontuario">
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# string.Format("alterar.aspx?atende={0}&&session="+Label1.Text+"&&tipo=1", HttpUtility.UrlEncode(Eval("num_atendimento").ToString())) %>' Text='<%# Eval("num_atendimento") %>'>HyperLink</asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="nome_pac" HeaderText="Nome do Paciente" />
                            <asp:BoundField DataField="box" HeaderText="Box" />
                            <asp:BoundField DataField="nome_completo" HeaderText="Pedido" />
                            <asp:TemplateField HeaderText="Data e hora da liberação">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("data_libera", "{0:d}") %>'></asp:Label>
                                    |
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("hora_libera") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>

                    </asp:GridView>
                    <br />
                    <br />
                    <br />
                    <h2>Exames Pedidos</h2>
                    <br />
                    <asp:GridView ID="GridView2" Width="100%" EmptyDataText="Sem registros" GridLines="Horizontal" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridView2_RowDataBound">
<AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>

                        <Columns>
                            <asp:BoundField DataField="status" HeaderText="Cancelado"/>
                            <asp:BoundField HeaderText="Status do exame" DataField="baixa" />
                            <asp:BoundField DataField="especial" HeaderText="Especialidade" />
                            <asp:BoundField DataField="procede" HeaderText="Procedimento" />
                            <asp:BoundField DataField="nome_pac" HeaderText="Nome do Paciente" />
                            <asp:BoundField DataField="quarto" HeaderText="Box" />
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
                    </div>
           </div>
                </div>
        <span id="tempo">--</span>
        <div id="link" style="display:none">
        <p><a href="https://ibogos.wordpress.com">Você já pode acessar meu blog clicando aqui!</a></p>
            </div>
        
	<script src="../js/scripts.js"></script>
	<!--//scrolling js-->
	<script src="../js/bootstrap.min.js"> </script>
        <!--
        <script type="text/javascript">
            function Popup(body) {
                if (!localStorage.getItem('OK')) {
                    $("#MyPopup .modal-body").html(body);
                    $("#MyPopup").modal("show");
                    
                }
            };
            function OK() {
                if (localStorage) {
                    if (!localStorage.getItem('OK')) {
                        localStorage.setItem('OK', true);
                    }
                }
            };
            function Fechar() {
                localStorage.clear();
            }
</script>
            -->

    </form>
</body>
</html>
