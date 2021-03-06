﻿<%@ Page  Language="C#" AutoEventWireup="true" CodeBehind="frmCategoryDonut.aspx.cs" Inherits="Ticker.Forms.Pages.frmCategoryDonut" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../Themes/js/jquery-1.5.1.min.js"></script>
    <script src="../../Themes/js/highcharts.src.js"></script>
    <script src="../../Themes/js/highcharts-more.js"></script>
    <script src="http://code.highcharts.com/modules/exporting.js"></script>
    <script src="../../Themes/js/jquery-2.0.2.js"></script>
     <link href="../../Themes/Css/ssResponsive.css" rel="stylesheet" />
</head>
<body  style="width: 495px; height: 360px;" >
    <form id="form1" runat="server" style="width: 495px; height: 360px;">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
      <%--  <div style="" id="asdFlick" class="boxStyleKey">--%>
        <div id="OrderInner" class="boxStyleKey1">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <span>
                        <asp:Label Width="500" ID="Label16" runat="server" Text="PRODUCT CATEGORIES BY UNITS SOLD" CssClass="lblChartTitle" ForeColor="Black" Font-Size="15px" Font-Names="Arial" />
                        <div class="CenterLabel1">
                            <asp:Label ID="lblNewOrderNH" runat="server" Text="100" Font-Names="Arial" />
                        </div>
                    </span>
                    <asp:Literal ID="ltrChart" runat="server"></asp:Literal>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div id="Div1" class="boxStyleKey2" >
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <span>
                        <asp:Label Width="500" ID="Label1" runat="server" Text="PRODUCT CATEGORIES BY SALES AMT" CssClass="lblChartTitle" ForeColor="Black" Font-Size="15px" Font-Names="Arial" />
                        <div class="CenterLabel1">
                            <asp:Label ID="lbltotalamount" runat="server" Text="100" Font-Names="Arial" />
                        </div>
                    </span>
                    <asp:Literal ID="litOrderAmount" runat="server"></asp:Literal>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
            <asp:Timer ID="Timer1" runat="server" Interval="60000" OnTick="Timer1_Tick"></asp:Timer>
       <%-- </div>--%>
    </form>
</body>
</html>
