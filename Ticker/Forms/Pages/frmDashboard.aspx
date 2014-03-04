<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/MasterForms/mstMain.Master" AutoEventWireup="true" CodeBehind="frmDashboard.aspx.cs" Inherits="Ticker.Forms.Pages.frmDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
    <script src="../../Themes/js/jquery-1.5.1.min.js"></script>
    <script src="../../Themes/js/highcharts.src.js"></script>
    <script src="../../Themes/js/highcharts-more.js"></script>
    <script src="http://code.highcharts.com/modules/exporting.js"></script>
    <script src="../../Themes/js/jquery-2.0.2.js"></script>
    <table class="maintbl">
        <tr>
            <td style="vertical-align: bottom;">
                <%--    <div id="dvBoxLeftTop" class="leftSideBox">
                    <asp:UpdatePanel ID="upPanel" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="lblregularorder" runat="server" Text="Regular Order" CssClass="lblChartTitle" />
                            <asp:Literal ID="ltrRegularOrder" runat="server"></asp:Literal>
                            <p>
                                <div style="margin-top: 30px">
                                    <asp:Label ID="lblErrorRegular" runat="server" CssClass="lblShipmentSubtitle" ForeColor="Red"></asp:Label>
                                </div>
                            </p>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>--%>
            </td>
            <td style="width: 30%; vertical-align: top">
                <asp:Label ID="Label8" runat="server" Text="Order Details" Font-Size="X-Large" ForeColor="#ffffff" />
                <div id="asdFlick" class="boxStyleKey">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <span>
                                <asp:Label ID="Label16" runat="server" Text="QTY ORDERED BY CATEGORY" CssClass="lblChartTitle" />
                                <span>
                                    <asp:Label ID="lblNewOrderNH" runat="server" Text="100" CssClass="CenterLabel1" /></span>
                                <asp:Literal ID="ltrChart" runat="server"></asp:Literal>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="BottomChartBOx" style="float: left;">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <asp:Literal ID="ltrStackedColumnTop5SKU" runat="server"></asp:Literal>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="smallBox" style="background: #97560f">
                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                        <ContentTemplate>

                            <div style="text-align: right;">
                                <asp:Label runat="server" ID="lblship" CssClass="lblShipmentSubtitle" ForeColor="#5fc0fe" Text="074" Font-Size="55"> </asp:Label>
                            </div>
                            <div style="text-align: left;">
                                <asp:Label runat="server" ID="lblShipped" Text="% Shipped" CssClass="lblChartTitle" Font-Bold="false" Font-Size="15"></asp:Label>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="smallBox" style="margin-left:10px">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>

                            <div style="text-align: right;">
                                <asp:Label runat="server" ID="lblHoldOrder" CssClass="lblShipmentSubtitle" ForeColor="#5fc0fe" Text="074" Font-Size="55"> </asp:Label>
                            </div>
                            <div style="text-align: left;">
                                <asp:Label runat="server" ID="lblHold" Text="Hold Orders" CssClass="lblChartTitle" Font-Bold="false" Font-Size="15"></asp:Label>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </td>
            <td style="vertical-align: top;">
                <table id="tblOrderDetails" style="width: 78%; float: left;">
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lblOrderHeader" runat="server" Text="Order Processing" Font-Size="X-Large" ForeColor="#ffffff" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center;">
                            <div class="ShipmentNewDiv">
                                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                    <ContentTemplate>
                                        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                                        <p class="leftSideBoxChartp">
                                            <asp:Label ID="Label6" runat="server" Text="New" ForeColor="#cccccc" />
                                        </p>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div id="dvNywhDetails" style="float: right; width: 250px">
                                <table style="width: 100%">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label3" runat="server" Text="In Process" Font-Size="17" ForeColor="WhiteSmoke" />
                                        </td>
                                    </tr>
                                    <tr>

                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                <ContentTemplate>
                                                    <div class="ShipmentInfoDiv" style="width: 250px; background: #0f7673">
                                                        <asp:Literal ID="ltrInProcessSOS" runat="server"></asp:Literal>
                                                        <p class="leftSideBoxChartp">
                                                            <asp:Label ID="Label1" runat="server" Text="SYOSSET" />
                                                        </p>
                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label9" runat="server" Text="Shipped" Font-Size="17" ForeColor="WhiteSmoke" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                                <ContentTemplate>
                                                    <div class="ShipmentInfoDiv" style="width: 250px; background: #171717;">
                                                        <asp:Literal ID="ltrShippedSYS" runat="server"></asp:Literal>
                                                        <p class="leftSideBoxChartp">
                                                            <asp:Label ID="Label2" runat="server" Text="SYOSSET" ForeColor="WhiteSmoke" />
                                                        </p>
                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>

                        <td>
                            <div id="Div2" style="float: right; width: 250px">
                                <table style="width: 100%">
                                    <tr>
                                        <td style="height: 25px">
                                            <asp:Label ID="Label4" runat="server" Text=" " Font-Size="17" ForeColor="Black" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                                <ContentTemplate>
                                                    <div class="ShipmentInfoDiv" style="width: 250px; background: #0f7673">
                                                        <asp:Literal ID="ltrInprocessNyWH" runat="server"></asp:Literal>
                                                        <p class="leftSideBoxChartp">
                                                            <asp:Label ID="Label5" runat="server" Text="PORT WASHINGTON" Font-Size="Large" />
                                                        </p>
                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 25px">

                                            <asp:Label ID="Label10" runat="server" Text=" " Font-Size="17" ForeColor="Black" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                                <ContentTemplate>
                                                    <div class="ShipmentInfoDiv" style="width: 250px; background: #171717;">
                                                        <asp:Literal ID="ltrShippedNYWH" runat="server"></asp:Literal>
                                                        <p class="leftSideBoxChartp">
                                                            <asp:Label ID="Label7" runat="server" Text="PORT WASHINGTON" Font-Size="Large" ForeColor="WhiteSmoke" />
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
                </table>
            </td>
            <td style="vertical-align: bottom; width: 50px;">
                &nbsp</td>
            <td style="vertical-align: top;">
                <asp:Label ID="Label11" runat="server" Text="Partner Performance" Font-Size="X-Large" ForeColor="#ffffff" />
                <div class="leftSideBoxChart">
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <ContentTemplate>
                            <asp:Literal ID="ltrStackedColumnTop5Partner" runat="server"></asp:Literal>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div id="Div1" class="leftSideBox" style="background: rgba(239, 239, 239, 0.60)">
                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="lblpart" runat="server" Text="Part Order" CssClass="lblChartTitle" />
                            <asp:Literal ID="litPartOrderQuantity" runat="server"></asp:Literal>
                            <p>
                                <div style="margin-top: 30px">
                                    <asp:Label ID="lblError" runat="server" CssClass="lblShipmentSubtitle" ForeColor="Red"></asp:Label>
                                </div>
                            </p>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </td>
        </tr>
        <%--    <tr>
            <td>&nbsp;</td>
            <td colspan="2">
                <div id="dvMain" class="HomeDivKey">
                    <table style="width: 100%">
                        <tr>
                            <td>
                                
                                <div id="Div3" class="leftSideBox" style="width: 40%; height: 200px; margin-left: 5px; margin-top: 5px; background:rgba(0, 0, 0, 0.00); float: left;"></div>

                            </td>
                        </tr>
                    </table>

                </div>
            </td>
            <td>&nbsp;</td>
        </tr>--%>
    </table>
    <asp:Timer ID="tmrAjaxOrderOnCold" runat="server" Interval="30000" OnTick="tmrAjaxOrderOnCold_Tick"></asp:Timer>

</asp:Content>
