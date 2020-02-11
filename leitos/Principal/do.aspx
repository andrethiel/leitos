<%@ Page Language="C#" AutoEventWireup="true" CodeFile="do.aspx.cs" Inherits="Principal_do" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Localizar D.O - Leitos Rocio</title>
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
                        <asp:LinkButton ID="LinkButton2" class=" hvr-bounce-to-right" runat="server" OnClick="LinkButton2_Click"><i class="fa fa-desktop nav_icon"></i><span class="nav-label">Voltar</span></asp:LinkButton>
                    </li>
                </ul>
                    </div>
                </div>
                </nav>
            <div id="page-wrapper" class="gray-bg dashbard-1">
                <div class="banner">
		         <h1>DIGITALIZAÇÃO DE DOCUMENTOS</h1><br />

         <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label>

                     <asp:Label ID="Label6" runat="server" Visible="False"></asp:Label>

                     <asp:Label ID="Label7" runat="server" Visible="False"></asp:Label><br /><br />
                    <asp:Label ID="Label2" runat="server" Text="Nº do Prontuario"></asp:Label>
                    <br />
                    <asp:TextBox ID="TextBox1" CssClass="textbox" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label8" runat="server" Text="Nome do Paciente"></asp:Label>
                    <br />
                    <asp:TextBox ID="TextBox2" CssClass="textbox" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Button ID="Button1" class="button" runat="server" Text="Procurar" OnClick="Button1_Click"/>
                    <br />
                    <br /><br />
                    <br />
                     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="90%" GridLines="Horizontal" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"><AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
             <Columns>
                 <asp:TemplateField ItemStyle-HorizontalAlign = "Center" HeaderText="Arquivo" >
                     <ItemTemplate>
                         <asp:LinkButton ID="LinkButton1" Text="Ver arquivos do paciente" CommandArgument='<%# Eval("id_pac") %>' runat="server" OnClick="LinkButton1_Click"></asp:LinkButton>
            </ItemTemplate>
                     <HeaderStyle HorizontalAlign="Right" />
                     <ItemStyle HorizontalAlign="Center"></ItemStyle>
        </asp:TemplateField>
                 <asp:BoundField DataField="num_atendimento" HeaderText="Nº do atendimento"/>
                 <asp:BoundField DataField="nome_pac" HeaderText="Nome do Paciente"/>
                 <asp:TemplateField HeaderText="Data do Obito">
                     <EditItemTemplate>
                         <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                     </EditItemTemplate>
                     <ItemTemplate>
                         <asp:Label ID="Label1" runat="server" Text='<%# Eval("data_do", "{0:d}") %>'>></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>  
    </Columns>

<PagerStyle CssClass="pgr"></PagerStyle>
        </asp:GridView>
                    <br />
                    <br />
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Width="90%" GridLines="Horizontal" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" OnRowCommand="GridView2_RowCommand">
<AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                        <Columns>
                            <asp:TemplateField HeaderText="D.O">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageButton1" CommandArgument="" CommandName="DO" runat="server" Width="34px" ImageUrl="~/images/visulizar.jpg" />
                                    <br />
                                    Visualizar
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Prontuario">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("pron") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageButton2" CommandName="pront" runat="server" Width="34px" ImageUrl="~/images/visulizar.jpg"/>
                                    <br />
                                    Visualizar
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Arquivos">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("arquivos") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageButton3" CommandName="arquivos" runat="server" Width="34px" ImageUrl="~/images/visulizar.jpg" />
                                    <br />
                                    Visualizar
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>

<PagerStyle CssClass="pgr"></PagerStyle>
                        <RowStyle HorizontalAlign="Center" />
                    </asp:GridView>

                    <script src="../principal/js/bootstrap.min.js"></script>
	<script src="../principal/js/scripts.js"></script>
            <script src="../principal/js/scripts.js"></script>

                    </div>
                </div>
            </div>

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
                    <asp:Label ID="Label10" runat="server"></asp:Label>
                </p>
                </div>
            </div>
        </div>
            </div>
        
    </form>
</body>
</html>
