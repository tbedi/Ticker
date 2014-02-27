﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/MasterForms/mstMain.Master" AutoEventWireup="true" CodeBehind="frmDashboard.aspx.cs" Inherits="Ticker.Forms.Pages.frmDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
    <script src="../../Themes/js/jquery-1.5.1.min.js"></script>
    <script src="../../Themes/js/highcharts.src.js"></script>
    <table class="maintbl">
        <tr>
            <td style="vertical-align: bottom;">
                <div id="dvBoxLeftTop" class="leftSideBox">
                    <%--<asp:Label ID="lblDate" runat="server" Text="14" ForeColor="#cccccc" Font-Size="50" />--%>
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <ContentTemplate>
                            <asp:Literal ID="ltrRegularOrder" runat="server"></asp:Literal>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </td>
            <td style="width: 30%;" rowspan="2">
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
                </table>
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
                

            </td>
            <td rowspan="2" style="vertical-align: bottom;">
                <table id="tblOrderDetails" style="width: 78%; float:left;">
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lblOrderHeader" runat="server" Text="ORDER PROCESSING" Font-Size="X-Large" ForeColor="#ffffff" />
                        </td>
                    </tr>
                    <tr >
                        <td colspan="2" style="text-align:center;">
                            <div class="ShipmentInfoDiv">
                                <p>
                                    <asp:Label ID="Label6" runat="server" Text="New Shipment" CssClass="lblShipmentSubtitle" />
                                </p>
                                <asp:Label ID="Label7" runat="server" Text="000" CssClass="lblShipmentNumber" />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div id="dvNywhDetails" class="divOrderDetails" style="float: right">
                                <table style="width: 100%">
                                    <tr>
                                        <td style="height:55px">
                                            <asp:Label ID="Label3" runat="server" Text="SYOSSET" Font-Size="17" ForeColor="Black" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div class="ShipmentInfoDiv">
                                                <p >
                                                    <asp:Label ID="Label8" runat="server" Text="In process" CssClass="lblShipmentSubtitle" />
                                                </p>
                                                <asp:Label ID="Label9" runat="server" Text="000" CssClass="lblShipmentNumber" />
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div class="ShipmentInfoDiv">
                                                <p>
                                                    <asp:Label ID="Label10" runat="server" Text="Shipped" CssClass="lblShipmentSubtitle" />
                                                </p>
                                                <asp:Label ID="Label11" runat="server" Text="000" CssClass="lblShipmentNumber" />
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>

                        <td>
                            <div id="dvNywt" class="divOrderDetails" style="float: left">
                                <table style="width: 100%">
                                    <tr>
                                        <td>
                                           
                                            <asp:Label ID="Label4" runat="server" Text="PORT WASHINGTON" Font-Size="17" ForeColor="Black" />
                                           
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div class="ShipmentInfoDiv">
                                                <p>
                                                    <asp:Label ID="Label12" runat="server" Text="In process " CssClass="lblShipmentSubtitle" />
                                                </p>
                                                <asp:Label ID="Label13" runat="server" Text="000" CssClass="lblShipmentNumber" />
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div class="ShipmentInfoDiv">
                                                <p>
                                                    <asp:Label ID="Label14" runat="server" Text="Shipped" CssClass="lblShipmentSubtitle" />
                                                </p>
                                                <asp:Label ID="Label15" runat="server" Text="000" CssClass="lblShipmentNumber" />
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
                <div id="Div2" class="leftSideBox" style="width: 78%; height:90px; margin-left:5px; background: #fff"></div>
            </td>
            <td>
                <div class="leftSideBox" style="width: 200px;"></div>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; float: left;">
                <div id="Div1" class="leftSideBox" style="background: rgba(239, 239, 239, 0.60)">
                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                        <ContentTemplate>
                            <asp:Literal ID="litPartOrderQuantity" runat="server"></asp:Literal>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
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
                                   
                                    <div class="BottomChartBOx" >
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                            <ContentTemplate>
                                                <asp:Literal ID="ltrStackedColumn" runat="server"></asp:Literal>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div id="dvSetting" class="leftSideBox" style="width: 230px; background: rgba(135, 56, 5, 0.89)"></div>
                                </div>
                            </td>
                        </tr>
                    </table>

                </div>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <asp:Timer ID="tmrAjaxOrderOnCold" runat="server" Interval="30000" OnTick="tmrAjaxOrderOnCold_Tick"></asp:Timer>
    
</asp:Content>
