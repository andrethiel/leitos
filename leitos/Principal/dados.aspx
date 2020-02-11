<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dados.aspx.cs" Inherits="dados" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="icon" type="imagem/ico" href="../images/favicon.ico" />
    <script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
<link href="css/bootstrap.min.css" rel='stylesheet' type='text/css' />
<!-- Custom Theme files -->
<link href="css/style.css" rel='stylesheet' type='text/css' />
    <link href="css/StyleSheet.css" rel='stylesheet' type='text/css' />
<link href="css/font-awesome.css" rel="stylesheet"> 
<script src="js/jquery.min.js"> </script>
<!-- Mainly scripts -->
<script src="js/jquery.metisMenu.js"></script>
<script src="js/jquery.slimscroll.min.js"></script>
<!-- Custom and plugin javascript -->
<link href="css/custom.css" rel="stylesheet">
<script src="js/custom.js"></script>
<script src="js/screenfull.js"></script>
    <link rel="Stylesheet" href="https://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.10/themes/redmond/jquery-ui.css" />
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
<script src="js/pie-chart.js"type="text/javascript"></script>
    <script src="js/skycons.js"></script>
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
                        <asp:LinkButton ID="LinkButton2" class=" hvr-bounce-to-right" runat="server" OnClick="LinkButton2_Click" ><i class="fa fa-desktop nav_icon"></i><span class="nav-label">Leitos</span></asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="LinkButton1" class=" hvr-bounce-to-right" runat="server" ><i class="fa fa-desktop nav_icon"></i><span class="nav-label">Sair</span></asp:LinkButton>
                    </li>
                </ul>
                    </div>
                </div>
                </nav>
            <div id="page-wrapper" class="gray-bg dashbard-1">
                <div class="banner">
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
		         <h1>BUSCAR LEITO / LEITOS DO DIA</h1><br />
                    <asp:Label ID="Label1" runat="server" Visible="false"></asp:Label>
                    <br />
                    <br />
                    <h2>Leitos UTI's do dia</h2>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt">
                <Columns>
                    <asp:TemplateField HeaderText="Prontuario">
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# string.Format("../Principal/alterar.aspx?atende={0}&&session="+Label1.Text+"&&tipo=1", HttpUtility.UrlEncode(Eval("num_atendimento").ToString())) %>' Text='<%# Eval("num_atendimento") %>'>HyperLink</asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                    <asp:BoundField DataField="nome_pac" HeaderText="Paciente" />
                    <asp:BoundField DataField="sexo" HeaderText="Sexo" />
                    <asp:BoundField DataField="uti" HeaderText="UTI" />
                    <asp:BoundField DataField="box" HeaderText="BOX" />
                    <asp:BoundField DataField="leito" HeaderText="Leito" />
                    <asp:BoundField DataField="hora_libera" HeaderText="Hora da liberação" />
                </Columns>
            </asp:GridView>
                    <br />
                    <br />
                    <h2>Transferencias do dia</h2>
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt">
                        <Columns>
                    <asp:TemplateField HeaderText="Prontuario">
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# string.Format("../Principal/alterar.aspx?atende={0}&&session="+Label1.Text+"&&tipo=2", HttpUtility.UrlEncode(Eval("num_atendimento").ToString())) %>' Text='<%# Eval("num_atendimento") %>'>HyperLink</asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                    <asp:BoundField DataField="nome_pac" HeaderText="Paciente" />
                    <asp:BoundField DataField="sexo" HeaderText="Sexo" />
                    <asp:BoundField DataField="leito" HeaderText="Leito" />
                    <asp:BoundField DataField="hora_libera" HeaderText="Hora da liberação" />
                </Columns>
                    </asp:GridView>
                    <br />
                    <br />
                    <h2>Cirurgico do dia</h2>

                    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt">
                        <Columns>
                    <asp:TemplateField HeaderText="Prontuario">
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# string.Format("../Principal/alterar.aspx?atende={0}&&session="+Label1.Text+"&&tipo=2", HttpUtility.UrlEncode(Eval("num_atendimento").ToString())) %>' Text='<%# Eval("num_atendimento") %>'>HyperLink</asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                    <asp:BoundField DataField="nome_pac" HeaderText="Paciente" />
                    <asp:BoundField DataField="sexo" HeaderText="Sexo" />
                    <asp:BoundField DataField="leito" HeaderText="Leito" />
                    <asp:BoundField DataField="hora_libera" HeaderText="Hora da liberação" />
                </Columns>
                    </asp:GridView>
                    </div>
                </div>
            </div>
        <script src="js/jquery-1.8.0.js"></script>
    <script src="js/jquery-ui.js"></script>
    <script>
        $("#TextBox1").datepicker();
    </script>
    </form>
</body>
</html>
