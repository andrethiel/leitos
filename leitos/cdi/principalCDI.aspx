<%@ Page Language="C#" AutoEventWireup="true" CodeFile="principalCDI.aspx.cs" Inherits="Principal_principalCDI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Gerenciamento de exames | leitos rocio</title>
    <link rel="icon" type="imagem/ico" href="../images/favicon.ico" />
    <link href="../principal/css/StyleSheet.css" rel='stylesheet' type='text/css' />
<link href="../principal/css/bootstrap.min.css" rel='stylesheet' type='text/css' />
<!-- Custom Theme files -->
<%--<link href="../principal/css/style.css" rel='stylesheet' type='text/css' />--%>
<link href="../principal/css/font-awesome.css" rel="stylesheet"> 
<script src="../principal/js/jquery.min.js"> </script>
<!-- Mainly scripts -->
<script src="../principal/js/jquery.metisMenu.js"></script>
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
                        <asp:LinkButton ID="LinkButton1" class=" hvr-bounce-to-right" runat="server" OnClick="LinkButton1_Click"><i class="fa fa-desktop nav_icon"></i><span class="nav-label">Exames agendados</span></asp:LinkButton>
                    </li>
                    <li>
                        <a href="#" class=" hvr-bounce-to-right"><i class="fa fa-indent nav_icon"></i> <span class="nav-label">Exames Centro</span><span class="fa arrow"></span></a>
                        <ul class="nav nav-second-level">
                            <li><asp:LinkButton ID="LinkButton4" class=" hvr-bounce-to-right" runat="server" OnClick="LinkButton4_Click"><i class="fa fa-desktop nav_icon"></i><span class="nav-label">Agendar exames centro</span></asp:LinkButton></li>
                        </ul>
                    </li>
                    <li>
                        <a href="#" class=" hvr-bounce-to-right"><i class="fa fa-indent nav_icon"></i> <span class="nav-label">Cadastro</span><span class="fa arrow"></span></a>
                        <ul class="nav nav-second-level">
                            <li><asp:LinkButton ID="LinkButton2" class=" hvr-bounce-to-right" runat="server" OnClick="LinkButton2_Click"><i class="fa fa-desktop nav_icon"></i><span class="nav-label">Cadastrar novo usuario</span></asp:LinkButton></li>
                        </ul>
                    </li>
                    <li>
                        <a href="#" class=" hvr-bounce-to-right"><i class="fa fa-indent nav_icon"></i> <span class="nav-label">Perfil</span><span class="fa arrow"></span></a>
                        <ul class="nav nav-second-level">
                            <li><asp:LinkButton ID="LinkButton5" class=" hvr-bounce-to-right" runat="server" OnClick="LinkButton5_Click"><i class="fa fa-desktop nav_icon"></i><span class="nav-label">Alterar meu perfil</span></asp:LinkButton></li>
                        </ul>
                    </li>
                    <li>
                        <asp:LinkButton ID="LinkButton3" class=" hvr-bounce-to-right" runat="server" OnClick="LinkButton3_Click"><i class="fa fa-desktop nav_icon"></i><span class="nav-label">Sair</span></asp:LinkButton>
                    </li>
                </ul>
                    </div>
                </div>
                </nav>
            <div id="topo">
            <div id="page-wrapper" class="gray-bg dashbard-1">
                <div class="banner">
		         <h1>GERENCIAMENTO DE EXAMES</h1><br />
                    <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label>
                    <table>
                        <tr>
                            <td >
                               <a href="#resso" class="dropdown-toggle dropdown-at"><img src="../images/resso.png" title="Ressonancia" height="32" /><asp:Label ID="Label2" CssClass="number" runat="server"></asp:Label></a>
                            </td>
                            <td style="padding-left:15px">
                                <a href="#tomo" class="dropdown-toggle dropdown-at"><img src="../images/tomo.png" title="Tomografia" height="32" /><asp:Label ID="Label4" CssClass="number" runat="server"></asp:Label></a>
                            </td>
                            <td style="padding-left:15px">
                                <a href="#angior" class="dropdown-toggle dropdown-at"><img src="../images/angio.png" title="Angiotomo e angioresso" height="32" /><asp:Label ID="Label6" CssClass="number" runat="server"></asp:Label></a>
                            </td>
                            <td style="padding-left:15px">
                                <a href="#raio" class="dropdown-toggle dropdown-at"><img src="../images/raio.png" title="Raio-x" height="32" /><asp:Label ID="Label7" CssClass="number" runat="server"></asp:Label></a>
                            </td>
                            <td style="padding-left:15px">
                                <a href="#eco" class="dropdown-toggle dropdown-at"><img src="../images/eco.png" title="Ecografia" height="32" /><asp:Label ID="Label8" CssClass="number" runat="server"></asp:Label></a>
                            </td>
                            <td style="padding-left:15px">
                                <a href="#mamo" class="dropdown-toggle dropdown-at"><img src="../images/mamo.png" title="Mamografia" height="32" /><asp:Label ID="Label9" CssClass="number" runat="server"></asp:Label></a>
                            </td>
                        </tr>
                    </table>
                        </div>
                     <br />
                    <br />
                    <br />
                <div class="banner">
                    <section id="resso">
                    <h4>Ressonância</h4>
                    <br />
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%" GridLines="Horizontal" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand">
<AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                        <Columns>
                            <asp:BoundField DataField="status" HeaderText="Cancelado" />
                            <asp:BoundField DataField="quarto" HeaderText="Box/Quarto" />
                            <asp:TemplateField HeaderText="Nome do paciente">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton6"  runat="server" Text='<%# Eval("nome_pac") %>' CommandName="Baixar" CommandArgument='<%#Eval("fornecedor") + "," +Eval("id") %>'></asp:LinkButton>
                                    <%--<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# string.Format("../cdi/baixa.aspx?atende={0}&&session="+Label1.Text, HttpUtility.UrlEncode(Eval("id").ToString())) %>' Text='<%# Eval("nome_pac") %>'>HyperLink</asp:HyperLink>--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="local" HeaderText="Setor" />
                       
                            <asp:BoundField DataField="especial" HeaderText="Especialidade" />
                            <asp:BoundField DataField="procede" HeaderText="Procedimento" />
                            <asp:BoundField DataField="obs" HeaderText="Obs. Paciente" />
                            <asp:BoundField HeaderText="Pedido" DataField="nome_completo" />
                            <asp:TemplateField HeaderText="Data e Hora do pedido">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("hora_pedido") %>'></asp:Label>
                                </ItemTemplate>
                                <ControlStyle ForeColor="Black" />
                                <ItemStyle ForeColor="Black" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="baixa" HeaderText="Status do Exame" />
                            <asp:BoundField DataField="usuario_libera" HeaderText="Baixa" />
                            
                            <asp:TemplateField HeaderText="Data e hora da baixa">
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("hora_libera") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns><PagerStyle CssClass="pgr"></PagerStyle>
                    </asp:GridView>
                        </section>
                <a href="#topo">Topo</a>
                    <br />
                <br />
                    <section id="tomo">
                    <h4>Tomografia</h4>
                    <br />
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Width="100%" GridLines="Horizontal" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" OnRowDataBound="GridView2_RowDataBound">
<AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                        <Columns>
                            <asp:BoundField DataField="status" HeaderText="Cancelado" />
                            <asp:TemplateField HeaderText="Nome do paciente">
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# string.Format("../cdi/baixa.aspx?atende={0}&&session="+Label1.Text, HttpUtility.UrlEncode(Eval("id").ToString())) %>' Text='<%# Eval("nome_pac") %>'>HyperLink</asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="quarto" HeaderText="Box/Quarto" />
                            <asp:BoundField DataField="local" HeaderText="Setor" />
                            
                            <asp:BoundField DataField="especial" HeaderText="Especialidade" />
                            <asp:BoundField DataField="procede" HeaderText="Procedimento" />
                            <asp:BoundField DataField="obs" HeaderText="Obs. Paciente" />
                            <asp:BoundField HeaderText="Pedido" DataField="nome_completo" />
                            <asp:TemplateField HeaderText="Data e Hora do pedido">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("hora_pedido") %>'></asp:Label>
                                </ItemTemplate>

                                <ControlStyle ForeColor="Black" />
                                <ItemStyle ForeColor="Black" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="baixa" HeaderText="Status do Exame" />
                            <asp:BoundField DataField="usuario_libera" HeaderText="Baixa" />
                            <asp:TemplateField HeaderText="Data e hora da baixa">
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("hora_libera") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>

<PagerStyle CssClass="pgr"></PagerStyle>
                    </asp:GridView>
                        </section>
                     <a href="#topo">Topo</a>
                    <br />
                <br />
                    <section id="raio">
                    <h4>Raio-X</h4>
                    <br />
                    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" Width="100%" GridLines="Horizontal" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" OnRowDataBound="GridView3_RowDataBound">
<AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                        <Columns>
                            <asp:BoundField DataField="status" HeaderText="Cancelado" />
                            <asp:TemplateField HeaderText="Nome do paciente">
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# string.Format("../cdi/baixa.aspx?atende={0}&&session="+Label1.Text, HttpUtility.UrlEncode(Eval("id").ToString())) %>' Text='<%# Eval("nome_pac") %>'>HyperLink</asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="quarto" HeaderText="Box/Quarto" />
                            <asp:BoundField DataField="local" HeaderText="Setor" />
                            
                            <asp:BoundField DataField="especial" HeaderText="Especialidade" />
                            <asp:BoundField DataField="procede" HeaderText="Procedimento" />
                            <asp:BoundField DataField="obs" HeaderText="Obs. Paciente" />
                            <asp:BoundField HeaderText="Pedido" DataField="nome_completo" />
                            <asp:TemplateField HeaderText="Data e Hora do pedido">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("hora_pedido") %>'></asp:Label>
                                </ItemTemplate>
                                <ControlStyle ForeColor="Black" />
                                <ItemStyle ForeColor="Black" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="baixa" HeaderText="Status do Exame" />
                            <asp:BoundField DataField="usuario_libera" HeaderText="Baixa" />
                            
                            <asp:TemplateField HeaderText="Data e hora da baixa">
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("hora_libera") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>

<PagerStyle CssClass="pgr"></PagerStyle>
                    </asp:GridView>
                    <br />
                        </section>
                <a href="#topo">Topo</a>
                    <br />
                <br />
                    <section id="eco">
                    <h4>Ecografia</h4>
                    <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" Width="100%" GridLines="Horizontal" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" OnRowDataBound="GridView4_RowDataBound">
<AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                        <Columns>
                            <asp:BoundField DataField="status" HeaderText="Cancelado" />
                            <asp:TemplateField HeaderText="Nome do paciente">
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# string.Format("../cdi/baixa.aspx?atende={0}&&session="+Label1.Text, HttpUtility.UrlEncode(Eval("id").ToString())) %>' Text='<%# Eval("nome_pac") %>'>HyperLink</asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="quarto" HeaderText="Box/Quarto" />
                            <asp:BoundField DataField="local" HeaderText="Setor" />
                            
                            <asp:BoundField DataField="especial" HeaderText="Especialidade" />
                            <asp:BoundField DataField="procede" HeaderText="Procedimento" />
                            <asp:BoundField DataField="obs" HeaderText="Obs. Paciente" />
                            <asp:BoundField HeaderText="Pedido" DataField="nome_completo" />
                            <asp:TemplateField HeaderText="Data e Hora do pedido">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("hora_pedido") %>'></asp:Label>
                                </ItemTemplate>
                                <ControlStyle ForeColor="Black" />
                                <ItemStyle ForeColor="Black" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="baixa" HeaderText="Status do Exame" />
                            <asp:BoundField DataField="usuario_libera" HeaderText="Baixa" />
                            <asp:TemplateField HeaderText="Data e hora da baixa">
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("hora_libera") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>

<PagerStyle CssClass="pgr"></PagerStyle>
                    </asp:GridView>
                    <br />
                        </section>
                <a href="#topo">Topo</a>
                    <br />
                <br />
                    <section id="angiot">
                    <h4>Angiotomografias</h4>
                    <br />
                    <asp:GridView ID="GridView7" runat="server" AutoGenerateColumns="False" Width="100%" GridLines="Horizontal" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" OnRowDataBound="GridView7_RowDataBound">
<AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                        <Columns>
                            <asp:BoundField DataField="status" HeaderText="Cancelado" />
                            <asp:TemplateField HeaderText="Nome do paciente">
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# string.Format("../cdi/baixa.aspx?atende={0}&&session="+Label1.Text, HttpUtility.UrlEncode(Eval("id").ToString())) %>' Text='<%# Eval("nome_pac") %>'>HyperLink</asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="quarto" HeaderText="Box/Quarto" />
                            <asp:BoundField DataField="local" HeaderText="Setor" />
                            
                            <asp:BoundField DataField="especial" HeaderText="Especialidade" />
                            <asp:BoundField DataField="procede" HeaderText="Procedimento" />
                            <asp:BoundField DataField="obs" HeaderText="Obs. Paciente" />
                            <asp:BoundField HeaderText="Pedido" DataField="nome_completo" />
                            <asp:TemplateField HeaderText="Data e Hora do pedido">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("hora_pedido") %>'></asp:Label>
                                </ItemTemplate>
                                <ControlStyle ForeColor="Black" />
                                <ItemStyle ForeColor="Black" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="baixa" HeaderText="Status do Exame" />
                            <asp:BoundField DataField="usuario_libera" HeaderText="Baixa" />
                            
                            <asp:TemplateField HeaderText="Data e hora da baixa">
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("hora_libera") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>

<PagerStyle CssClass="pgr"></PagerStyle>
                    </asp:GridView>
                        </section><a href="#topo">Topo</a>
                    <br />
                <br />
                    <section id="angior">
                    <h4>Angioressonâncias</h4>
                    <br />
                    <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="False" Width="100%" GridLines="Horizontal" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" OnRowDataBound="GridView6_RowDataBound">
<AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                        <Columns>
                            <asp:BoundField DataField="status" HeaderText="Cancelado" />
                            <asp:TemplateField HeaderText="Nome do paciente">
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# string.Format("../cdi/baixa.aspx?atende={0}&&session="+Label1.Text, HttpUtility.UrlEncode(Eval("id").ToString())) %>' Text='<%# Eval("nome_pac") %>'>HyperLink</asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="quarto" HeaderText="Box/Quarto" />
                            <asp:BoundField DataField="local" HeaderText="Setor" />
                            
                            <asp:BoundField DataField="especial" HeaderText="Especialidade" />
                            <asp:BoundField DataField="procede" HeaderText="Procedimento" />
                            <asp:BoundField DataField="obs" HeaderText="Obs. Paciente" />
                            <asp:BoundField HeaderText="Pedido" DataField="nome_completo" />
                            <asp:TemplateField HeaderText="Data e Hora do pedido">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("hora_pedido") %>'></asp:Label>
                                </ItemTemplate>
                                <ControlStyle ForeColor="Black" />
                                <ItemStyle ForeColor="Black" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="usuario_libera" HeaderText="Baixa" />
                            <asp:BoundField DataField="baixa" HeaderText="Status do Exame" />
                            <asp:TemplateField HeaderText="Data e hora da baixa">
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("hora_libera") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns><PagerStyle CssClass="pgr"></PagerStyle>
                    </asp:GridView>

                    <br />
                        </section>
                 <a href="#topo">Topo</a>
                    <br />
                <br />
                    
                    <section id="mamo">
                    <h4>MAMO</h4>
                    <br />
                    <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" Width="100%" GridLines="Horizontal" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" OnRowDataBound="GridView4_RowDataBound">
<AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                        <Columns>
                            <asp:BoundField DataField="status" HeaderText="Cancelado" />
                            <asp:TemplateField HeaderText="Nome do paciente">
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# string.Format("../cdi/baixa.aspx?atende={0}&&session="+Label1.Text, HttpUtility.UrlEncode(Eval("id").ToString())) %>' Text='<%# Eval("nome_pac") %>'>HyperLink</asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="quarto" HeaderText="Box/Quarto" />
                            <asp:BoundField DataField="local" HeaderText="Setor" />
                            
                            <asp:BoundField DataField="especial" HeaderText="Especialidade" />
                            <asp:BoundField DataField="procede" HeaderText="Procedimento" />
                            <asp:BoundField DataField="obs" HeaderText="Obs. Paciente" />
                            <asp:BoundField HeaderText="Pedido" DataField="nome_completo" />
                            <asp:TemplateField HeaderText="Data e Hora do pedido">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("hora_pedido") %>'></asp:Label>
                                </ItemTemplate>
                                <ControlStyle ForeColor="Black" />
                                <ItemStyle ForeColor="Black" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="baixa" HeaderText="Status do Exame" />
                            <asp:BoundField DataField="usuario_libera" HeaderText="Baixa" />
                            <asp:TemplateField HeaderText="Data e hora da baixa">
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("hora_libera") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>

<PagerStyle CssClass="pgr"></PagerStyle>
                    </asp:GridView>
                        </section>
                <a href="#topo">Topo</a>
                    <br /><br />
                    </div>
                </div>
            </div>
	<script src="../principal/js/scripts.js"></script>
        <script src="../principal/js/bootstrap.min.js"></script>
            <script type="text/javascript">
        function ShowPopup(body) {
            $("#MyPopup .modal-body").html(body);
            $("#MyPopup").modal("show");
        }
    </script>
            <div id="MyPopup" class="modal fade" role="dialog">
            <div class="modal-dialog modal-dialog-centered" role="document">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <p style="font-size: 20px; text-align: center;">Agendamento do Exame</p>
                    </div>
                    <div class="modal-body">
                        <div class="container">
                            <asp:Label ID="Label10" runat="server" Text="Label"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
    </form>
</body>
</html>
