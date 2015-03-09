<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="dettaglio-progetto.aspx.cs" Inherits="Cubo_Ingegneria.progettoDettaglio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContentPlaceHolder" runat="server">
    <div class="progettiWrapper">
        <div id="dettaglioWrapper" runat="server">
            <h1 id="titoloProgettoDettaglio" runat="server"></h1>
            <img class="fascia" src="images/fascia.png" />
        
            <div id="slideContainer">
                <div id="slideshow-area">
                  <div id="slideshow-scroller">
                    <div id="slideshow-holder">
                        <div id="slidewrapper" runat="server"></div>
                    </div>
                  </div>
                  <div id="slideshow-previous" class="arrowl"></div>
                  <div id="slideshow-next" class="arrowr"></div>
                </div>
                <div id="thumb-scroller">
                    <div id="thumbnail"></div>
                </div>
            </div>
        </div>
    </div>
     
</asp:Content>
