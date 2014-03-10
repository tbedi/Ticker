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
            <td style="vertical-align: bottom; width: 10px;">
                &nbsp</td>
            <td style="vertical-align: bottom;">
                <%--    <div id="dvBoxLeftTop" class="leftSideBox">
                    <asp:UpdatePanel ChildrenAsTriggers="false" UpdateMode="Conditional" ID="upPanel" runat="server">
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
            <td style="width: 30%; vertical-align: top;overflow:hidden;">
                <asp:Label ID="Label8" runat="server" Text="▶▶ Order Details" Font-Size="X-Large" Font-Bold="true" ForeColor="Black" />
                <div id="asdFlick" class="boxStyleKey" style="overflow:hidden" >
                    <asp:UpdatePanel  ID="UpdatePanel1" runat="server">
                        <ContentTemplate >
                            <iframe id="iDonutTopLeft" src="frmCategoryDonut.aspx" style="overflow:hidden;width:510px;height:370px; border:thin solid whiteSmoke; margin:0px;"></iframe>
                            <%--<asp:Timer ID="Timer1" runat="server" Interval="10000" OnTick="Timer1_Tick"></asp:Timer>
                            <span>
                                <asp:Label Width="500" ID="Label16" runat="server" Text="QTY ORDERED BY CATEGORY" CssClass="lblChartTitle" ForeColor="Black" Font-Size="25px" />
                                <span>
                                    <asp:Label ID="lblNewOrderNH" runat="server" Text="100" CssClass="CenterLabel1" /></span>
                                <asp:Literal ID="ltrChart" runat="server"></asp:Literal>
                                <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" OnClientClick="mainDonut()" />--%>
                        </ContentTemplate>
                    </asp:UpdatePanel> 
                    
                </div>
                <div class="BottomChartBOx" style="float: left;">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <iframe id="iTopSKus" src="frmTopSKUs.aspx"  style="overflow:hidden;width:510px;height:365px; border:thin solid whiteSmoke;" ></iframe>
                          <%--  <asp:Literal ID="ltrStackedColumnTop5SKU" runat="server"></asp:Literal>--%>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </td>
            <td class="gapdiv">
                &nbsp</td>
            <td style="vertical-align: top;overflow:hidden;">
                <asp:UpdatePanel ID="GuageUpdate" runat="server">

                    <ContentTemplate>
                        <iframe id="Guages" src="frmGuages.aspx" style="overflow:hidden;width:515px;height:799px;border:thin solid whiteSmoke; overflow:hidden;" ></iframe>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="gapdiv">
                &nbsp</td>
            <td style="vertical-align: top;">
               <asp:UpdatePanel runat="server" ID="updateStackedCulunm" >
                   <ContentTemplate>
                       <iframe id="iStackedColunm" style="overflow:hidden;width:510px;height:798px;border:thin solid whitesmoke;" src="frmRightStackedColunm.aspx"></iframe>
                   </ContentTemplate>

               </asp:UpdatePanel>
            </td>
            <td style="vertical-align: bottom; width: 10px;">
                &nbsp</td>
        </tr>
    </table>
</asp:Content>
