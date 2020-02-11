<%@ Page Language="C#" AutoEventWireup="true" CodeFile="asocial.aspx.cs" Inherits="Principal_transfere_asocial" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
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
    <script src="../js/pie-chart.js" type="text/javascript"></script>
    <script src="../js/skycons.js"></script>
    <script>
        function sucesso() {
            var div = document.getElementById('MyAlert').style.visibility = 'visible';
        };
        function error() {
            var div = document.getElementById('MyAlert').style.visibility = 'visible';
            document.getElementById('MyAlert').className = 'alert alert-danger';
        };
    </script>
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
                            </ul>
                        </div>
                    </div>
                </div>
            </nav>
            <div id="page-wrapper" class="gray-bg dashbard-1">
                <div class="banner">
                    <h1>PEDIDO ALTA ASSISTENTE SOCIAL</h1>
                    <div id="MyAlert" class="alert alert-success" role="alert" style="visibility: hidden">
                        <asp:Label ID="Label11" runat="server"></asp:Label>
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <br />
                    <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label>
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="Setor de Trabalho"></asp:Label>
                    <br />
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="textbox" Enabled="false"></asp:TextBox><br />
                    <asp:Label ID="Label3" runat="server" Text="N° Atendimento"></asp:Label>
                    <br />
                    <asp:TextBox ID="TextBox2" runat="server" CssClass="textbox" AutoCompleteType="Disabled" OnTextChanged="TextBox2_TextChanged" AutoPostBack="true"></asp:TextBox><br />
                    <asp:Label ID="Label4" runat="server" Text="Nome do Paciente"></asp:Label>
                    <br />
                    <asp:TextBox ID="TextBox3" runat="server" CssClass="textbox"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label6" runat="server" Text="Quarto"></asp:Label>
                    <br />
                    <asp:TextBox ID="TextBox4" runat="server" CssClass="textbox" AutoCompleteType="Disabled"></asp:TextBox><br />
                    <asp:Label ID="Label5" runat="server" Text="Municipio"></asp:Label>
                    <br />
                    <asp:TextBox ID="TextBox5" runat="server" CssClass="textbox" AutoCompleteType="Disabled"></asp:TextBox><br />
                    <asp:Label ID="Label7" runat="server" Text="Tipo da Alta"></asp:Label>
                    <br />
                    <asp:DropDownList ID="DropDownList1" CssClass="textbox" runat="server">
                        <asp:ListItem Value=""></asp:ListItem>
                        <asp:ListItem>Carro</asp:ListItem>
                        <asp:ListItem>Familia</asp:ListItem>
                        <asp:ListItem>Maca</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <asp:Label ID="Label9" runat="server" Text="Acompanhante"></asp:Label>
                    <br />
                    <asp:DropDownList ID="DropDownList2" CssClass="textbox" runat="server">
                        <asp:ListItem Value=""></asp:ListItem>
                        <asp:ListItem>Sim</asp:ListItem>
                        <asp:ListItem>Não</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <asp:Label ID="Label10" runat="server" Text="Oxigenio"></asp:Label>
                    <br />
                    <asp:DropDownList ID="DropDownList3" CssClass="textbox" runat="server">
                        <asp:ListItem Value=""></asp:ListItem>
                        <asp:ListItem>Sim</asp:ListItem>
                        <asp:ListItem>Não</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <br />
                    <br />

                    <asp:Button ID="Button1" class="button" runat="server" Text="Solicitar Alta" OnClick="Button1_Click" />
                </div>
            </div>
        </div>
        <script src="../js/scripts.js"></script>
        <!--//scrolling js-->
        <div style="display: none">
            <asp:Label ID="Label8" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
