<%@ Page Language="C#" AutoEventWireup="true" CodeFile="agendados.aspx.cs" Inherits="Principal_principalCDI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="icon" type="imagem/ico" href="../images/favicon.ico" />
    <link href="../principal/css/StyleSheet.css" rel='stylesheet' type='text/css' />
        <meta http-equiv="refresh" content="30" />
    <script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
<link href="../principal/css/bootstrap.min.css" rel='stylesheet' type='text/css' />
<!-- Custom Theme files -->
<link href="../principal/css/style.css" rel='stylesheet' type='text/css' />
<link href="../principal/css/font-awesome.css" rel="stylesheet"> 
<script src="../principal/js/jquery.min.js"> </script>
<!-- Mainly scripts -->
<script src="../principal/js/jquery.metisMenu.js"></script>
<script src="../principal/js/jquery.slimscroll.min.js"></script>
<!-- Custom and plugin javascript -->
<link href="../principal/css/custom.css" rel="stylesheet">
<script src="../principal/js/custom.js"></script>
<script src="../principal/js/screenfull.js"></script>
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
    <script>
        
<script src="../principal/js/pie-chart.js"type="text/javascript"></script>
    <script src="../principal/js/skycons.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="wrapper">
        <nav class="navbar-default navbar-static-top" role="navigation">
             <div class="navbar-header">
               <h1><img src="../images/HOSP ROCIO.png" style="width:200px;margin-left:2px;margin-top:2px; margin-bottom:2px" /></h1>         
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
                        <asp:LinkButton ID="LinkButton1" class=" hvr-bounce-to-right" runat="server" OnClick="LinkButton1_Click"><i class="fa fa-desktop nav_icon"></i><span class="nav-label">Voltar</span></asp:LinkButton>
                    </li>
                </ul>
                    </div>
                </div>
                </nav>
            <div id="page-wrapper" class="gray-bg dashbard-1">
                <div class="banner">
		         <h1>&nbsp;EXAMES AGENDADOS NO DIA</h1><br />
                    <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label>
                        <h2>
                            Exames que estão sendo pedidos</h2>
                    <br />
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%" EmptyDataText="Ressonancia" GridLines="Horizontal" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt">
<AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                        <Columns>
                            <asp:TemplateField HeaderText="Nome do paciente">
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# string.Format("../cdi/baixa.aspx?atende={0}&&session="+Label1.Text+"&&tipo=2", HttpUtility.UrlEncode(Eval("id").ToString())) %>' Text='<%# Eval("nome_pac") %>'>HyperLink</asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="local" HeaderText="Setor" />
                            <asp:BoundField DataField="quarto" HeaderText="Box/Quarto" />
                            <asp:BoundField DataField="especial" HeaderText="Especialidade" />
                            <asp:BoundField DataField="procede" HeaderText="Procedimento" />
                            <asp:BoundField HeaderText="Pedido" DataField="nome_completo" />
                            <asp:TemplateField HeaderText="Data e Hora">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("data_pedido", "{0:d}") %>'></asp:Label>
                                    |
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("hora_pedido") %>'></asp:Label>
                                </ItemTemplate>
                                <ControlStyle ForeColor="Black" />
                                <ItemStyle ForeColor="Black" />
                            </asp:TemplateField>
                        </Columns>

<PagerStyle CssClass="pgr"></PagerStyle>
                    </asp:GridView>

                    <br />
                    <br />

                    <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="False" Width="100%" EmptyDataText="Angioressonâncias" GridLines="Horizontal" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt">
<AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                        <Columns>
                            <asp:TemplateField HeaderText="Nome do paciente">
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# string.Format("../cdi/baixa.aspx?atende={0}&&session="+Label1.Text+"&&tipo=2", HttpUtility.UrlEncode(Eval("id").ToString())) %>' Text='<%# Eval("nome_pac") %>'>HyperLink</asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="local" HeaderText="Setor" />
                            <asp:BoundField DataField="quarto" HeaderText="Box/Quarto" />
                            <asp:BoundField DataField="especial" HeaderText="Especialidade" />
                            <asp:BoundField DataField="procede" HeaderText="Procedimento" />
                            <asp:BoundField HeaderText="Pedido" DataField="nome_completo" />
                            <asp:TemplateField HeaderText="Data e Hora">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("data_pedido", "{0:d}") %>'></asp:Label>
                                    |
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("hora_pedido") %>'></asp:Label>
                                </ItemTemplate>
                                <ControlStyle ForeColor="Black" />
                                <ItemStyle ForeColor="Black" />
                            </asp:TemplateField>
                        </Columns>

<PagerStyle CssClass="pgr"></PagerStyle>
                    </asp:GridView>
                    <br />
                    <br />
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Width="100%" EmptyDataText="Tomografia" GridLines="Horizontal" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt">
<AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                        <Columns>
                            <asp:TemplateField HeaderText="Nome do paciente">
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# string.Format("../cdi/baixa.aspx?atende={0}&&session="+Label1.Text+"&&tipo=2", HttpUtility.UrlEncode(Eval("id").ToString())) %>' Text='<%# Eval("nome_pac") %>'>HyperLink</asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="local" HeaderText="Setor" />
                            <asp:BoundField DataField="quarto" HeaderText="Box/Quarto" />
                            <asp:BoundField DataField="especial" HeaderText="Especialidade" />
                            <asp:BoundField DataField="procede" HeaderText="Procedimento" />
                            <asp:BoundField HeaderText="Pedido" DataField="nome_completo" />
                            <asp:TemplateField HeaderText="Data e Hora">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("data_pedido", "{0:d}") %>'></asp:Label>
                                    |
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("hora_pedido") %>'></asp:Label>
                                </ItemTemplate>
                                <ControlStyle ForeColor="Black" />
                                <ItemStyle ForeColor="Black" />
                            </asp:TemplateField>
                        </Columns>

<PagerStyle CssClass="pgr"></PagerStyle>
                    </asp:GridView>
                    <br />
                    <br />
                    <asp:GridView ID="GridView7" runat="server" AutoGenerateColumns="False" Width="100%" EmptyDataText="Angiotomografias" GridLines="Horizontal" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt">
<AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                        <Columns>
                            <asp:TemplateField HeaderText="Nome do paciente">
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# string.Format("../cdi/baixa.aspx?atende={0}&&session="+Label1.Text+"&&tipo=2", HttpUtility.UrlEncode(Eval("id").ToString())) %>' Text='<%# Eval("nome_pac") %>'>HyperLink</asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="local" HeaderText="Setor" />
                            <asp:BoundField DataField="quarto" HeaderText="Box/Quarto" />
                            <asp:BoundField DataField="especial" HeaderText="Especialidade" />
                            <asp:BoundField DataField="procede" HeaderText="Procedimento" />
                            <asp:BoundField HeaderText="Pedido" DataField="nome_completo" />
                            <asp:TemplateField HeaderText="Data e Hora">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("data_pedido", "{0:d}") %>'></asp:Label>
                                    |
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("hora_pedido") %>'></asp:Label>
                                </ItemTemplate>
                                <ControlStyle ForeColor="Black" />
                                <ItemStyle ForeColor="Black" />
                            </asp:TemplateField>
                        </Columns>

<PagerStyle CssClass="pgr"></PagerStyle>
                    </asp:GridView>
                    <br />
                    <br />
                    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" Width="100%" EmptyDataText="Raio-X" GridLines="Horizontal" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt">
<AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                        <Columns>
                            <asp:TemplateField HeaderText="Nome do paciente">
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# string.Format("../cdi/baixa.aspx?atende={0}&&session="+Label1.Text+"&&tipo=2", HttpUtility.UrlEncode(Eval("id").ToString())) %>' Text='<%# Eval("nome_pac") %>'>HyperLink</asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="local" HeaderText="Setor" />
                            <asp:BoundField DataField="quarto" HeaderText="Box/Quarto" />
                            <asp:BoundField DataField="especial" HeaderText="Especialidade" />
                            <asp:BoundField DataField="procede" HeaderText="Procedimento" />
                            <asp:BoundField HeaderText="Pedido" DataField="nome_completo" />
                            <asp:TemplateField HeaderText="Data e Hora">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("data_pedido", "{0:d}") %>'></asp:Label>
                                    |
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("hora_pedido") %>'></asp:Label>
                                </ItemTemplate>
                                <ControlStyle ForeColor="Black" />
                                <ItemStyle ForeColor="Black" />
                            </asp:TemplateField>
                        </Columns>

<PagerStyle CssClass="pgr"></PagerStyle>
                    </asp:GridView>
                    <br />
                    <br />
                    <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" Width="100%" EmptyDataText="Ecografia" GridLines="Horizontal" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt">
<AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                        <Columns>
                            <asp:TemplateField HeaderText="Nome do paciente">
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# string.Format("../cdi/baixa.aspx?atende={0}&&session="+Label1.Text+"&&tipo=2", HttpUtility.UrlEncode(Eval("id").ToString())) %>' Text='<%# Eval("nome_pac") %>'>HyperLink</asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="local" HeaderText="Setor" />
                            <asp:BoundField DataField="quarto" HeaderText="Box/Quarto" />
                            <asp:BoundField DataField="especial" HeaderText="Especialidade" />
                            <asp:BoundField DataField="procede" HeaderText="Procedimento" />
                            <asp:BoundField HeaderText="Pedido" DataField="nome_completo" />
                            <asp:TemplateField HeaderText="Data e Hora">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("data_pedido", "{0:d}") %>'></asp:Label>
                                    |
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("hora_pedido") %>'></asp:Label>
                                </ItemTemplate>
                                <ControlStyle ForeColor="Black" />
                                <ItemStyle ForeColor="Black" />
                            </asp:TemplateField>
                        </Columns>

<PagerStyle CssClass="pgr"></PagerStyle>
                    </asp:GridView>
                    <br />
                    <br />
                    <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" Width="100%" EmptyDataText="Biópsias" GridLines="Horizontal" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt">
<AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                        <Columns>
                            <asp:TemplateField HeaderText="Nome do paciente">
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# string.Format("../cdi/baixa.aspx?atende={0}&&session="+Label1.Text+"&&tipo=2", HttpUtility.UrlEncode(Eval("id").ToString())) %>' Text='<%# Eval("nome_pac") %>'>HyperLink</asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="local" HeaderText="Setor" />
                            <asp:BoundField DataField="quarto" HeaderText="Box/Quarto" />
                            <asp:BoundField DataField="especial" HeaderText="Especialidade" />
                            <asp:BoundField DataField="procede" HeaderText="Procedimento" />
                            <asp:BoundField HeaderText="Pedido" DataField="nome_completo" />
                            <asp:TemplateField HeaderText="Data e Hora">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("data_pedido", "{0:d}") %>'></asp:Label>
                                    |
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("hora_pedido") %>'></asp:Label>
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
	<script src="../principal/js/scripts.js"></script>
        <script src="../principal/js/bootstrap.min.js"></script>
                    
    </form>
</body>
</html>
