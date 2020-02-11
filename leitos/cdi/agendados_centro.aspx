<%@ Page Language="C#" AutoEventWireup="true" CodeFile="agendados_centro.aspx.cs" Inherits="cdi_agendados_centro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Exames Agendados Centro | Leitos Rocio</title>
    <link rel="icon" type="../imagem/ico" href="../images/favicon.ico" />
    <script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
<link href="../principal/css/bootstrap.min.css" rel='stylesheet' type='text/css' />
<!-- Custom Theme files -->
<link href="../principal/css/style.css" rel='stylesheet' type='text/css' />
    <link href="../principal/css/StyleSheet.css" rel='stylesheet' type='text/css' />
<link href="../principal/css/font-awesome.css" rel="stylesheet"> 
<script src="../principal/js/jquery.min.js"> </script>

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
		         <h1>GERENCIAMENTO DE EXAMES CENTRO</h1><br />
                    <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label>
                    <h4></h4>
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="Nome do Paciente"></asp:Label>
                    <br />
                    <asp:TextBox ID="TextBox1" CssClass="textbox" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label6" runat="server" Text="Data de agendamento"></asp:Label>
                    <br />
                    <asp:TextBox ID="TextBox2" CssClass="textbox" runat="server" AutoCompleteType="Disabled" TextMode="Date"></asp:TextBox>
                    <br /><br />
                    <asp:Button ID="Button1" class="button" runat="server" Text="Procurar" OnClick="Button1_Click" />
                    <br />
                    <br />
                     <br />
                     <br />
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="90%" GridLines="Horizontal" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"><AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                        <Columns>
                            <asp:TemplateField HeaderText="Nome do paciente">
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# string.Format("../cdi/centro.aspx?atende={0}&&session="+Label1.Text, HttpUtility.UrlEncode(Eval("id").ToString())) %>' Text='<%# Eval("nome_pac") %>'>HyperLink</asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="tel" HeaderText="Telefone" />
                            <asp:TemplateField HeaderText="Data e hora da baixa">
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("data_marcado","{0:d}") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="especial" HeaderText="Exame" />
                            <asp:BoundField DataField="obs" HeaderText="Obs" />
                            <asp:BoundField HeaderText="Agendado" DataField="nome_completo" />
                        </Columns><PagerStyle CssClass="pgr"></PagerStyle>
                    </asp:GridView>
                    <div style="text-align:right; width: 90%">
                        Quantidade de exames agendados: <asp:Label ID="Label3" runat="server"></asp:Label> Exames
                    </div>
                    </div>
                        </div>
                    </div>
                       
        <script src="../Principal/js/bootstrap.min.js"></script>
	<script src="../Principal/js/scripts.js"></script>
        <script type="text/javascript">
    function ShowPopup(body) {
        $("#MyPopup .modal-body").html(body);
        $("#MyPopup").modal("show");
            }
</script>
        <div id="MyPopup" class="modal fade" role="dialog">
    <div class="modal-dialog">
        <!-- Modal content-->
        <div class="modal-content">
            <div class="modal-header">
               <p style="font-size:15px; text-align:center; color:red" >Atenção</p>
                </div>
            <div class="modal-body">
                <p style="font-size:15px; text-align:center">
                    <asp:Label ID="Label11" runat="server"></asp:Label>
                </p>
                </div>
        </div>
        </div>
            </div>
    </form>
</body>
</html>
