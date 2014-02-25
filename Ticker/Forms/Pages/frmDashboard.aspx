<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/MasterForms/mstMain.Master" AutoEventWireup="true" CodeBehind="frmDashboard.aspx.cs" Inherits="Ticker.Forms.Pages.frmDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../Themes/js/jquery-1.5.1.min.js"></script>
    <script src="../../Themes/js/highcharts.src.js"></script>
    <div id="Flick" class="HomeDivKey">
        <div id="dvNewyorkBoxHolder" class="boxStyleKey">
            <asp:Literal ID="ltrChart" runat="server"></asp:Literal>
        </div>
    </div>
   
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
</asp:Content>
