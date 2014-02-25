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
    <div id="Flick" class="HomeDivKey">
        <div id="dvNewyorkBoxHolder" class="boxStyleKey">
            <asp:Literal ID="ltrChart" runat="server"></asp:Literal>
        </div>
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
</asp:Content>
