<%@ Page Language="C#" AutoEventWireup="true" CodeFile="examecdi.aspx.cs" Inherits="Principal_Pedidouti_examecdi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Pedido de exame de imagem | Leitos Rocio</title>
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
                $("#TextBox5").keypress(verificaNumero);
            });
        </script>
<script src="../js/pie-chart.js" type="text/javascript"></script>
    <script src="../js/skycons.js"></script>
</head>
<body>
    <form id="formexames" runat="server">
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
            <div id="page-wrapper" class="gray-bg dashbard-1">
                <div class="banner">
		         <h1>PEDIDO DE EXAMES DE IMAGEM</h1><br />
                    <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="Label13" runat="server" Visible="False"></asp:Label>
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="Setor de Trabalho"></asp:Label>
                    <br />
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="textbox" Enabled="false"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label4" runat="server" Text="Nome do Paciente"></asp:Label>
                    <br />
                    <asp:TextBox ID="TextBox3" runat="server" CssClass="textbox" AutoCompleteType="Disabled"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label12" runat="server" Text="Especialidade"></asp:Label>
                    <br />
                    <asp:DropDownList ID="DropDownList4" CssClass="textbox" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged">
                        <asp:ListItem Value="">Escolha uma especialidade</asp:ListItem>                        
                    </asp:DropDownList>
                    <br />
                    <asp:Label ID="Label15" runat="server"  Text="Procedimento"></asp:Label>
                    <br />
                    <asp:DropDownList ID="DropDownList5" CssClass="textbox" runat="server">
                        <asp:ListItem Value="">Selecione um procedimento</asp:ListItem>
                        <asp:ListItem></asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged" Text="Emergencia" />
                    <br />
                    <asp:Label ID="Label6" runat="server" Text="Quarto"></asp:Label>
                    <br />
                    <asp:TextBox ID="TextBox5" runat="server" CssClass="textbox" AutoCompleteType="Disabled"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label17" runat="server" Text="Leito"></asp:Label>
                    <br />
                    <asp:DropDownList ID="DropDownList6" CssClass="textbox" runat="server">
                        <asp:ListItem Value="">Selecione um leito</asp:ListItem>
                        <asp:ListItem>A</asp:ListItem>
                        <asp:ListItem>B</asp:ListItem>
                        <asp:ListItem>C</asp:ListItem>
                        <asp:ListItem></asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <asp:Label ID="Label16" runat="server" Text="Obs. Paciente"></asp:Label>
                    <br />
                    <asp:TextBox ID="TextBox6" runat="server" CssClass="textbox" TextMode="MultiLine"></asp:TextBox>
                    <br />
                    <br />
                    <br />
                    <asp:Button ID="Button1" class="button" runat="server" Text="Solicitar Exame" OnClick="Button1_Click" />
                    </div>
           </div>
                </div>
	<script src="../js/scripts.js"></script>
	<!--//scrolling js-->
	<script src="../js/bootstrap.min.js"> </script>

        <script type="text/javascript">
            function Popup(body) {
                $("#MyPopup .modal-body").html(body);
                $("#MyPopup").modal("show");
            }
            function men(body) {
                $("#Mesage .modal-body").html(body);
                $("#Mesage").modal("show");
            }
            function hora(body) {
                $("#horario .modal-body").html(body);
                $("#horario").modal("show");
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
                    <asp:Label ID="Label5" runat="server"></asp:Label>
                </p>
                </div>
            <div class="modal-footer">
                <asp:Button ID="Button3" class="btn btn-secondary" runat="server" Text="Não" OnClick="Button3_Click" />
                <asp:Button ID="Button2" class="btn btn-primary" runat="server" Text="Sim" OnClick="Button2_Click" />
                </div>
            </div>
        </div>
            </div>


        <div id="Mesage" class="modal fade" role="dialog" >
            <div class="modal-dialog modal-dialog-centered" role="document">
        <!-- Modal content-->
        <div class="modal-content">
            <div class="modal-header">
               <p style="font-size:15px; text-align:center; color:red" >Atenção</p>
                </div>
            <div class="modal-body">
                <p style="font-size:15px; text-align:center">
                    <asp:Label ID="Label3" runat="server"></asp:Label></p>
                </div>
            </div>
        </div>
            </div>

        <div id="horario" class="modal fade" role="dialog" data-backdrop="static">
    <div class="modal-dialog">
        <!-- Modal content-->
        <div class="modal-content">
            <div class="modal-header">
               <p style="font-size:15px; text-align:center; color:red" >Atenção</p>
                </div>
            <div class="modal-body">
                <p style="font-size:15px; text-align:center">
                    <asp:Label ID="Label7" runat="server"></asp:Label>
                </p>
                </div>
            <div class="modal-footer">
                <asp:Button ID="Button5" class="btn btn-primary" runat="server" Text="OK" OnClick="Button5_Click" />
                </div>
            </div>
        </div>
            </div>
    </form>
</body>
</html>
