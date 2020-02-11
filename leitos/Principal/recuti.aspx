<%@ Page Language="C#" AutoEventWireup="true" CodeFile="recuti.aspx.cs" Inherits="Principal_recuti" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Digitalização de D.O - Leitos Rocio</title>
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
    <script src="js/pie-chart.js" type="text/javascript"></script>
    <script src="js/skycons.js"></script>
</head>
<body>
    <form id="form1" runat="server">

        <div id="wrapper">
            <nav class="navbar-default navbar-static-top" role="navigation">
                <div class="navbar-header">
                    <h1>
                        <img src="../images/HOSP ROCIO.png" style="width: 200px; margin-left: 2px; margin-top: 2px; margin-bottom: 2px" /></h1>
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
                                    <asp:LinkButton ID="LinkButton1" class=" hvr-bounce-to-right" runat="server" OnClick="LinkButton1_Click"><i class="fa fa-desktop nav_icon"></i><span class="nav-label">Leitos</span></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="LinkButton2" class=" hvr-bounce-to-right" runat="server" OnClick="LinkButton2_Click"><i class="fa fa-desktop nav_icon"></i><span class="nav-label">Procurar D.O</span></asp:LinkButton>
                                </li>
                            </ul>
                        </div>
                    </div>
            </nav>
            <div id="page-wrapper" class="gray-bg dashbard-1">
                <div class="banner">
                    <h1>DIGITALIZAÇÃO DE DOCUMENTOS</h1>
                    <br />
                    <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label>

                    <asp:Label ID="Label6" runat="server" Visible="False"></asp:Label>

                    <asp:Label ID="Label7" runat="server" Visible="False"></asp:Label>
                    <br />
                    <br />

                    <asp:Label ID="Label2" runat="server" Text="N° do Prontuario"></asp:Label>
                    <br />
                    <asp:TextBox ID="TextBox1" CssClass="textbox" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label3" runat="server" Text="Nome do paciente"></asp:Label>
                    <br />
                    <asp:TextBox ID="TextBox2" CssClass="textbox" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label5" runat="server" Text="Data do Obito"></asp:Label>
                    <br />
                    <asp:TextBox ID="TextBox3" CssClass="textbox" TextMode="Date" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="Label4" runat="server" Text="D.O"></asp:Label>
                    <br />
                    <asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="True" />
                    <br />
                    <asp:Label ID="Label8" runat="server" Text="Prontuario"></asp:Label>
                    <br />
                    <asp:FileUpload ID="FileUpload2" CssClass="textbox" runat="server" />
                    <br />
                    <asp:Label ID="Label9" runat="server" Text="Documentos"></asp:Label>
                    <br />
                    <asp:FileUpload ID="FileUpload3" CssClass="textbox" runat="server" />
                    <br />
                    <br />
                    <asp:Button ID="Button1" class="button" runat="server" Text="Importar" OnClick="Button1_Click" />
                    <asp:Button ID="Button2" class="button" runat="server" Text="dddd" OnClick="Button2_Click" />
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                </div>
                <asp:Label ID="Label11" runat="server" Visible="false" Text="null"></asp:Label>
                <asp:Label ID="Label12" runat="server" Visible="false" Text="null"></asp:Label>
                <asp:Label ID="Label13" runat="server" Visible="false" Text="null"></asp:Label>
            </div>
        </div>
        <script src="../principal/js/bootstrap.min.js"></script>
        <script src="../principal/js/scripts.js"></script>
        <script src="../principal/js/scripts.js"></script>
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
                        <p style="font-size: 15px; text-align: center; color: red">Atenção</p>
                    </div>
                    <div class="modal-body">
                        <p style="font-size: 15px; text-align: center">
                            <asp:Label ID="Label10" runat="server"></asp:Label>
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </form>

</body>
</html>
