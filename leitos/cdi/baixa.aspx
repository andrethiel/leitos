<%@ Page Language="C#" AutoEventWireup="true" CodeFile="baixa.aspx.cs" Inherits="cdi_baixa" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Baixa de exames | Leitos Rocio</title>
    <link rel="icon" type="imagem/ico" href="../images/favicon.ico" />
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
                    </ul>
                    </div>
                </div>
                </nav>
            <div id="page-wrapper" class="gray-bg dashbard-1">
                <div class="banner">
		         <h1>BAIXA DE EXAMES</h1><br />
                    <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="Label13" runat="server" Visible="False"></asp:Label>
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="Setor de Pedido"></asp:Label>
                    <br />
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="textbox" Enabled="false"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label4" runat="server" Text="Nome do Paciente"></asp:Label>
                    <br />
                    <asp:TextBox ID="TextBox3" runat="server" CssClass="textbox" Enabled="false"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label12" runat="server" Text="Especialidade"></asp:Label>
                    <br />
                    <asp:TextBox ID="TextBox2" CssClass="textbox" runat="server" Enabled="false"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label15" runat="server"  Text="Procedimento"></asp:Label>
                    <br />
                    <asp:TextBox ID="TextBox4" CssClass="textbox" runat="server" Enabled="false"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label6" runat="server" Text="Box"></asp:Label>
                    <br />
                    <asp:TextBox ID="TextBox5" runat="server" CssClass="textbox" Enabled="false"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label16" runat="server" Text="Obs. Paciente"></asp:Label>
                    <br />
                    <asp:TextBox ID="TextBox6" runat="server" CssClass="textbox" TextMode="MultiLine" Enabled="false"></asp:TextBox>
                    <br />
                    <br />
                    <br />
                    <asp:Button ID="Button1" class="button" runat="server" Text="Baixar Exame" OnClick="Button1_Click"/>
                    <br />
                    <asp:Button ID="Button2" class="button" runat="server" Text="CANCELAR AGENDAMENTO" OnClick="Button2_Click"/>
                    </div>
           </div>
                </div>
        <script src="../principal/js/bootstrap.min.js"></script>
	<script src="../principal/js/scripts.js"></script>
        <script type="text/javascript">
    function ShowPopup(body) {
        $("#MyPopup .modal-body").html(body);
        $("#MyPopup").modal("show");
            }
</script>
        <div id="MyPopup" class="modal fade" role="dialog" data-backdrop="static">
    <div class="modal-dialog">
        <!-- Modal content-->
        <div class="modal-content">
            <div class="modal-header">
               <p style="font-size:15px; text-align:center; color:red" >Atenção</p>
                </div>
            <div class="modal-body">
                <p style="font-size:15px; text-align:center">
                    <asp:Label ID="Label9" runat="server"></asp:Label>
                </p>
                </div>
            <div class="modal-footer">
                <asp:Button ID="Button3" class="btn btn-secondary" runat="server" Text="Não" OnClick="Button3_Click" />
                <asp:Button ID="Button4" class="btn btn-primary" runat="server" Text="Sim" OnClick="Button4_Click" />
                </div>
            </div>
        </div>
            </div>
    </form>
</body>
</html>
