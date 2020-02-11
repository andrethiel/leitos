<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>    
</head>
<body>
    <form id="form1" runat="server">      
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click"/> 
        <textarea class="form-control" rows="10" id="resultText" readonly="readonly" runat="server"></textarea>
    </form>
</body>
</html>
