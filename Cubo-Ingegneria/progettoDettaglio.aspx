<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="progettoDettaglio.aspx.cs" Inherits="Cubo_Ingegneria.progettoDettaglio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContentPlaceHolder" runat="server">
    <div class="progettiWrapper">
        <h1>Nome Progetto</h1>
        <img id="fascia" src="images/fascia.png" />
        
        <div id="slideContainer">
            <div id="slideshow-area">
              <div id="slideshow-scroller">
                <div id="slideshow-holder">
                  <div class="slideshow-content">
                      <img class="slide" src="imgProjects/canovetta/canovetta1.png" />
                  </div>
                  <div class="slideshow-content">
                    <img class="slide" src="imgProjects/canovetta/canovetta2.png" />
                  </div>
                  <div class="slideshow-content">
                    <img class="slide" src="imgProjects/canovetta/canovetta3.png" />
                  </div>
                    <div class="slideshow-content">
                    <img class="slide" src="imgProjects/canovetta/canovetta4.png" />
                  </div>
                </div>
              </div>
              <div id="slideshow-previous" class="arrowl"></div>
              <div id="slideshow-next" class="arrowr"></div>
            </div>
            <div id="thumb-scroller">
                <div id="thumbnail"></div>
            </div>
        </div>
        <div id="projectDescription"></div>
    </div>
     
</asp:Content>
