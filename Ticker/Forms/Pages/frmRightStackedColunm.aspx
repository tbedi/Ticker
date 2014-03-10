<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmRightStackedColunm.aspx.cs" Inherits="Ticker.Forms.Pages.frmRightStackedColunm" %>

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
<body>
    <form id="form1" runat="server" style="width:500px; height:795px; overflow:hidden">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
            <table style="width:495px; height:794px;">
                <tr>
                  
                        <td style="vertical-align: top;">
                            <asp:Label ID="Label11" runat="server" Text="▶▶ Partner Performance" Font-Size="X-Large" ForeColor="Black" Font-Bold="true" />
                            <div class="leftSideBoxChart" style="width:500px; ">
                                <asp:UpdatePanel ChildrenAsTriggers="false" UpdateMode="Conditional" ID="UpdatePanel4" runat="server">
                                    <ContentTemplate>
                                        <asp:Literal ID="ltrStackedColumnTop5Partner" runat="server"></asp:Literal>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="leftSideBoxChart" style="width:500px;">
                                <asp:UpdatePanel ChildrenAsTriggers="false" UpdateMode="Conditional" ID="UpdatePanel12" runat="server">
                                    <ContentTemplate>
                                        <asp:Literal ID="ltrTOPPartnerByOrder" runat="server"></asp:Literal>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </td>
                    
                    
                </tr>
            </table>

        </div>
         <asp:Timer ID="Timer1" runat="server" Interval="64000" OnTick="Timer1_Tick"></asp:Timer>
    </form>
</body>
</html>
