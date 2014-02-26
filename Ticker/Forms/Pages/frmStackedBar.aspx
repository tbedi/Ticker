<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmStackedBar.aspx.cs" Inherits="Ticker.Forms.Pages.frmStackedBar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
      <script src="../../Themes/js/jquery-1.5.1.min.js"></script>
    <script src="../../Themes/js/highcharts.src.js"></script>
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="HomeDivKey">
     <div id="dvNewyorkBoxHolder" class="boxStyleKey">
            <asp:Literal ID="ltrChart" runat="server"></asp:Literal>
       </div>
    </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
    </form>
</body>
</html>
