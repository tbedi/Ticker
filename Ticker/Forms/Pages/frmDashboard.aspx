<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/MasterForms/mstMain.Master" AutoEventWireup="true" CodeBehind="frmDashboard.aspx.cs" Inherits="Ticker.Forms.Pages.frmDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../Themes/js/jquery-1.5.1.min.js"></script>
    <script src="../../Themes/js/highcharts.src.js"></script>
  <%--  <script type="text/javascript">
        $(document).ready(function Donutchart() {
            var chart = new Highcharts.Chart({
                chart: {
                    renderTo: 'container',
                    type: 'pie'
                },

                plotOptions: {
                    pie: {
                        borderColor: '#000000',
                        innerSize: '60%'
                    }
                },
                series: [{
                    data:[ <%=p1%>]
                }]
            },
            // using 

            function (chart) {
                var xpos = '50%'; var ypos = '53%'; var circleradius = 102; chart.renderer.circle(xpos, ypos, circleradius).attr({ fill: '#ddd', }).add();

                // Render the text 
                chart.renderer.text('<span style="color:Gray; fontSize:35;">35%</span>', 155, 215).css({
                    width: circleradius * 2,
                    color: '#4572A7',
                    fontSize: '16px',
                    textAlign: 'center'
                }).attr({
                    // why doesn't zIndex get the text in front of the chart?
                    zIndex: 999
                }).add();
            });
        });
    </script>
     <div id="container" style="height: 200px; width: 350px"></div>--%>
    <table class="maintbl">
        <tr>
            <td colspan="4">&nbsp;</td>
        </tr>
        <tr>
            <td style="vertical-align: bottom;">
                <div id="dvBoxLeftTop" class="leftSideBox">
                    <asp:Label ID="lblDate" runat="server" Text="14" ForeColor="#cccccc" Font-Size="50" />
                </div>
            </td>
            <td style="width: 30%;">
                <table style="width: 100%">
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="Label2" runat="server" Text="ORDER DETAILS" Font-Size="X-Large" ForeColor="#ffffff" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="smallBox"></div>
                        </td>
                        <td>
                            <div class="smallBox"></div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="smallBox"></div>
                        </td>
                        <td>
                            <div class="smallBox"></div>
                        </td>
                    </tr>

                </table>

            </td>
            <td rowspan="2" style="vertical-align: bottom;">
                <table id="tblOrderDetails" style="width: 100%;">
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lblOrderHeader" runat="server" Text="ORDER PROCESSING" Font-Size="X-Large" ForeColor="#ffffff" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div id="dvNywhDetails" class="divOrderDetails" style="float: right">
                                <table style="width: 100%">
                                    <tr>
                                        <td style="text-align: center;">
                                            <asp:Label ID="Label3" runat="server" Text="NYWH" Font-Size="Large" ForeColor="#fff00" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                    </tr>
                                </table>
                            </div>
                        </td>

                        <td>
                            <div id="dvNywt" class="divOrderDetails" style="float: left">
                                <table style="width: 100%">
                                    <tr>
                                        <td style="text-align: center;">
                                            <asp:Label ID="Label4" runat="server" Text="NYWT" Font-Size="Large" ForeColor="#fff00" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>

            </td>
            <td>
                <div class="leftSideBox" style="width: 200px"></div>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; float: left;">
                <div id="Div1" class="leftSideBox" style="background: rgba(239, 239, 239, 0.60)"></div>
            </td>
            <td style="vertical-align: bottom">
                <div class="leftSideBox" style="width: 97%; float: left"></div>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td colspan="2">
                <div id="dvMain" class="HomeDivKey">
                    <table style="width: 100%">
                        <tr>
                            <td>
                                <div>
                                    <div id="asdFlick" class="boxStyleKey">
                                        <asp:Label ID="lblNewOrderNH" runat="server" Text="100" CssClass="CenterLabel1" />
                                        <asp:Literal ID="ltrChart" runat="server"></asp:Literal>
                                    </div>
                                    <div id="Div2" class="boxStyleKey">
                                        <asp:Label ID="Label1" runat="server" Text="910" CssClass="CenterLabel1" />
                                        <asp:Literal ID="ltrOrderhold" runat="server"></asp:Literal>
                                    </div>
                                    <div id="dvSetting" class="leftSideBox" style="width: 230px; background: #007acc"></div>
                                </div>
                            </td>
                        </tr>
                    </table>

                </div>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
   
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
</asp:Content>
