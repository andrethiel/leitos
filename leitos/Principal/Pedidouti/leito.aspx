<%@ Page Language="C#" AutoEventWireup="true" CodeFile="leito.aspx.cs" Inherits="Principal_leito" MaintainScrollPositionOnPostback="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Transferencia de leitos | Leitos Rocio</title>
    <link rel="icon" type="imagem/ico" href="../../images/favicon.ico" />
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
    <script>
            function verificaNumero(e) {
                if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                    return false;
                }
            }
             
            $(document).ready(function() {
                $("#TextBox2").keypress(verificaNumero);
                $("#TextBox5").keypress(verificaNumero);
            });
        </script>
<script src="../js/pie-chart.js" type="text/javascript"></script>
    <script src="../js/skycons.js"></script>
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
                        <asp:LinkButton ID="LinkButton1" class=" hvr-bounce-to-right" runat="server" OnClick="LinkButton1_Click"><i class="fa fa-desktop nav_icon"></i><span class="nav-label">Voltar</span></asp:LinkButton>
                    </li>
                    </ul>
                    </div>
                </div>
                </nav>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <div id="page-wrapper" class="gray-bg dashbard-1">
                <div class="banner">
		         <h1>PEDIDO DE LEITOS</h1><br />
                    <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label>
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="Setor de Trabalho"></asp:Label>
                    <br />
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="textbox" Enabled="false"></asp:TextBox><br />
                    <asp:Label ID="Label3" runat="server" Text="N° Prontuario"></asp:Label>
                    <br />
                    <asp:TextBox ID="TextBox2" runat="server" CssClass="textbox" AutoCompleteType="Disabled" OnTextChanged="TextBox2_TextChanged" AutoPostBack="true"></asp:TextBox><br />
                    <asp:Label ID="Label4" runat="server" Text="Nome do Paciente"></asp:Label>
                    <br />
                    <asp:TextBox ID="TextBox3" runat="server" CssClass="textbox" AutoCompleteType="Disabled" Enabled="false"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label9" runat="server" Text="Sexo"></asp:Label>
                    <br />
                    <asp:DropDownList ID="DropDownList1"  CssClass="textbox" runat="server" Enabled="false">
                        <asp:ListItem Value="">Escolha um sexo</asp:ListItem>
                        <asp:ListItem>Masculino</asp:ListItem>
                        <asp:ListItem>Feminino</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <asp:Label ID="Label5" runat="server" Text="Diagnostico"></asp:Label>
                    <br />
                    <asp:TextBox ID="TextBox4" runat="server" CssClass="textbox" AutoCompleteType="Disabled" ></asp:TextBox><br />
                    <asp:Label ID="Label6" runat="server" Text="Box"></asp:Label>
                    <br />
                    <asp:TextBox ID="TextBox5" runat="server" CssClass="textbox" AutoCompleteType="Disabled"></asp:TextBox>
                    <br />
                    <asp:CheckBox ID="CheckBox1" runat="server" Text="Isolamento" OnCheckedChanged="CheckBox1_CheckedChanged" AutoPostBack="True" />
                    <asp:Label ID="Label12" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="Label7" runat="server" Text="Obs. do paciente" ></asp:Label>
                    <br />
                    <asp:TextBox ID="TextBox6" runat="server" CssClass="textbox" TextMode="MultiLine" AutoCompleteType="Disabled"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label11" runat="server" Text="Especialidade"></asp:Label>
                    <br />
                    <asp:DropDownList ID="DropDownList3" runat="server" CssClass="textbox">
                        <asp:ListItem Value="">Escolha uma especialidade</asp:ListItem>
                        <asp:ListItem>Clinica</asp:ListItem>
                        <asp:ListItem>Gineco</asp:ListItem>
                        <asp:ListItem>Obstetricia</asp:ListItem>
                        <asp:ListItem>Neurologia</asp:ListItem>
                        <asp:ListItem>Vascular</asp:ListItem>
                        <asp:ListItem>Ortopedia</asp:ListItem>
                        <asp:ListItem>Geral</asp:ListItem>
                        <asp:ListItem>Hepatologia</asp:ListItem>
                        <asp:ListItem>Nefrologia/TX</asp:ListItem>
                        <asp:ListItem>Oncologia</asp:ListItem>
                        <asp:ListItem>Cardiologia</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <asp:Label ID="Label10" runat="server" Text="Convênio"></asp:Label>
                    <br />
                    <asp:DropDownList ID="DropDownList2" CssClass="textbox" runat="server" Enabled="false">
                        <asp:ListItem Value="">Escolha um Convênio</asp:ListItem>
                        <asp:ListItem>SUS</asp:ListItem>
                        <asp:ListItem>Particular</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <br />
                    <asp:Button ID="Button1" class="button" runat="server" Text="Salvar" OnClick="Button1_Click" />
                    </div>
           </div>
                </div>
	<script src="../js/scripts.js"></script>
	<!--//scrolling js-->
	<script src="../js/bootstrap.min.js"> </script>
        <div style="display:none">
            <asp:Label ID="Label8" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
