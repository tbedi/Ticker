<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmWeekOrderTotalLineChart.aspx.cs" Inherits="Ticker.Forms.Pages.frmWeekOrderTotalLineChart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <link href="../../Themes/Css/ssResponsive.css" rel="stylesheet" />
    <script src="../../Themes/js/jquery-1.5.1.min.js"></script>
    <script src="../../Themes/js/highcharts.src.js"></script>
    <script src="../../Themes/js/highcharts-more.js"></script>
    <script src="http://code.highcharts.com/modules/exporting.js"></script>
    <script src="../../Themes/js/jquery-2.0.2.js"></script>
    <title></title>
</head>
<body style="width:495px;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
        <div style="" id="asdFlick" class="leftSideBoxChart"  >
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Literal ID="ltrWeekToatalLineChart" runat="server"></asp:Literal>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:Timer ID="Timer1" runat="server" Interval="70000" OnTick="Timer1_Tick"></asp:Timer>
        </div>
    </form>
</body>
</html>
