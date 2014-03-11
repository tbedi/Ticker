<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmGuages.aspx.cs" Inherits="Ticker.Forms.Pages.frmGuages" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../../Themes/Css/ssResponsive.css" rel="stylesheet" />
    <script src="../../Themes/js/jquery-1.5.1.min.js"></script>
    <script src="../../Themes/js/highcharts.src.js"></script>
    <script src="../../Themes/js/highcharts-more.js"></script>
    <script src="http://code.highcharts.com/modules/exporting.js"></script>
    <script src="../../Themes/js/jquery-2.0.2.js"></script>
</head>
<body>
    <form id="form1" runat="server" style="width: 480px">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
        <div>
            <asp:UpdatePanel runat="server" ID="Updateguage">
                <ContentTemplate>
                    <table id="tblOrderDetails">
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="lblOrderHeader" runat="server" Text="▶▶ Order Processing" Font-Size="20px" Font-Bold="true" ForeColor="Black" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: center;">
                                <div class="ShipmentNewDiv">
                                    <asp:UpdatePanel ChildrenAsTriggers="false" UpdateMode="Conditional" ID="UpdatePanel7" runat="server">
                                        <ContentTemplate>
                                            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                                            <p class="leftSideBoxChartp">
                                                <asp:Label ID="Label6" runat="server" Text="New" ForeColor="#007acc" Font-Size="35px" />
                                            </p>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: center">
                                <asp:Label ID="Label3" runat="server" Text="IN PROCESS" Font-Size="15" ForeColor="Black" />
                            </td>
                        </tr>
                        <tr>
                            <td style="vertical-align:top">
                                <div id="dvNywhDetails" style="float: right; width: 250px">
                                    <table style="width: 100%">

                                        <tr>

                                            <td>
                                                <asp:UpdatePanel ChildrenAsTriggers="false" UpdateMode="Conditional" ID="UpdatePanel8" runat="server">
                                                    <ContentTemplate>
                                                        <div class="ShipmentInfoDiv" style="width: 250px; background: white">
                                                            <asp:Literal ID="ltrInProcessSOS" runat="server"></asp:Literal>
                                                            <p class="leftSideBoxChartp">
                                                                <asp:Label ID="Label1" runat="server" Text="SYOSSET" ForeColor="#007acc" Font-Size="Large" />
                                                            </p>
                                                        </div>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>

                                            </td>
                                        </tr>
                                       </table>
                                </div>

                            </td>

                            <td style="vertical-align: top;">
                                <div id="Div2" style="float: right; width: 250px">
                                    <table style="width: 100%">
                                        <tr>
                                            <td>
                                                <asp:UpdatePanel ChildrenAsTriggers="false" UpdateMode="Conditional" ID="UpdatePanel9" runat="server">
                                                    <ContentTemplate>
                                                        <div class="ShipmentInfoDiv" style="width: 250px; background: White">
                                                            <asp:Literal ID="ltrInprocessNyWH" runat="server"></asp:Literal>
                                                            <p class="leftSideBoxChartp">
                                                                <asp:Label ID="Label5" runat="server" Text="PORT WASHINGTON" ForeColor="#007acc" Font-Size="Large" />
                                                            </p>
                                                        </div>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>

                                            </td>
                                        </tr>
                                    
                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: center" >
                                 <asp:Label ID="Label4" runat="server" Text="SHIPPED" Font-Size="15" ForeColor="Black" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div id="Div1" style="float: right; width: 250px">
                                    <table style="width: 100%">
                                        <tr>
                                            <td>
                                                <asp:UpdatePanel ChildrenAsTriggers="false" UpdateMode="Conditional" ID="UpdatePanel10" runat="server">
                                                    <ContentTemplate>
                                                        <div class="ShipmentInfoDiv" style="width: 250px; background: White;">
                                                            <asp:Literal ID="ltrShippedSYS" runat="server"></asp:Literal>
                                                            <p class="leftSideBoxChartp">
                                                                <asp:Label ID="Label2" runat="server" Text="SYOSSET" ForeColor="#007acc" Font-Size="Large" />
                                                            </p>
                                                        </div>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr style="margin-top: -1px;">
                                            <td>
                                                <div class="smallBox" style="background: white">
                                                    <asp:UpdatePanel ChildrenAsTriggers="false" UpdateMode="Conditional" ID="UpdatePanel4" runat="server">
                                                        <ContentTemplate>

                                                            <div style="text-align: right; width: 90px; float: right;">
                                                                <asp:Label runat="server" ID="lblOrdersToday" ForeColor="#44A7ED" Text="074" Font-Size="27" Font-Bold="true"> </asp:Label>
                                                            </div>
                                                            <div style="text-align: left; width: 150px">
                                                                <asp:Label runat="server" ID="Label13" Text="Orders Today" CssClass="lblChartTitle" Font-Bold="false" ForeColor="#44A7ED" Font-Size="15"></asp:Label>
                                                            </div>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                            </td>
                                        </tr>
                                         <tr style="margin-top: -1px;">
                                            <td>
                                                <div class="smallBox" style="background: white">
                                                    <asp:UpdatePanel ChildrenAsTriggers="false" UpdateMode="Conditional" ID="UpdatePanel6" runat="server">
                                                        <ContentTemplate>

                                                            <div style="text-align: right; width: 90px; float: right;">
                                                                <asp:Label runat="server" ID="lblship" ForeColor="#44A7ED" Text="074" Font-Size="27" Font-Bold="true"> </asp:Label>
                                                            </div>
                                                            <div style="text-align: left; width: 150px">
                                                                <asp:Label runat="server" ID="lblShipped" Text="Total Shipped" CssClass="lblChartTitle" Font-Bold="false" ForeColor="#44A7ED" Font-Size="15"></asp:Label>
                                                            </div>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </div>

                            </td>
                            <td>
                                <div id="Div3" style="float: left; width: 250px">
                                    <table style="width: 100%">
                                          <tr>
                                            <td>
                                                <asp:UpdatePanel ChildrenAsTriggers="false" UpdateMode="Conditional" ID="UpdatePanel11" runat="server">
                                                    <ContentTemplate>
                                                        <div class="ShipmentInfoDiv" style="width: 250px; background: White;">
                                                            <asp:Literal ID="ltrShippedNYWH" runat="server"></asp:Literal>
                                                            <p class="leftSideBoxChartp">
                                                                <asp:Label ID="Label7" runat="server" Text="PORT WASHINGTON" Font-Size="Large" ForeColor="#007acc" />
                                                            </p>
                                                        </div>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                         <tr style="margin-top: -1px;">
                                            <td>
                                                <div class="smallBox" style="background: white">
                                                    <asp:UpdatePanel ChildrenAsTriggers="false" UpdateMode="Conditional" ID="UpdatePanel3" runat="server">
                                                        <ContentTemplate>

                                                            <div style="text-align: right; width: 80px; float: right;">
                                                                <asp:Label runat="server" ID="lblToatalYesterday" ForeColor="#e1530b" Text="074" Font-Size="27" Font-Bold="true">  </asp:Label>
                                                            </div>
                                                            <div style="text-align: left; width: 160px">
                                                                <asp:Label runat="server" ID="lblty" Text="Orders Yesterday" CssClass="lblChartTitle" Font-Bold="false" ForeColor="#e1530b" Font-Size="15"></asp:Label>
                                                            </div>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                            </td>
                                        </tr>
                                         <tr style="margin-top: -1px;">
                                            <td>
                                                <div class="smallBox" style="background: white">
                                                    <asp:UpdatePanel ChildrenAsTriggers="false" UpdateMode="Conditional" ID="UpdatePanel2" runat="server">
                                                        <ContentTemplate>

                                                            <div style="text-align: right; width: 90px; float: right;">
                                                                <asp:Label runat="server" ID="lblHoldOrder" ForeColor="#ee0000" Text="074" Font-Size="27" Font-Bold="true"> </asp:Label>
                                                            </div>
                                                            <div style="text-align: left; width: 150px">
                                                                <asp:Label runat="server" ID="lblHold" Text="Hold Orders" CssClass="lblChartTitle" Font-Bold="false" ForeColor="#ee0000" Font-Size="15"></asp:Label>
                                                            </div>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </div>

                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:Timer ID="Timer1" runat="server" Interval="62000" OnTick="Timer1_Tick"></asp:Timer>
        </div>
    </form>
</body>
</html>
