<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="progetti.aspx.cs" Inherits="Cubo_Ingegneria.progetti" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContentPlaceHolder" runat="server">
    <div class="progettiWrapper">
        <h1>Progetti</h1>
        <img class="fascia" src="images/fascia.png" />
        <div id="progettiContainer" runat="server">
        </div>
    </div>
</asp:Content>
