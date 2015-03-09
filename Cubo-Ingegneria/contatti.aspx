<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="contatti.aspx.cs" Inherits="Cubo_Ingegneria.contatti" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContentPlaceHolder" runat="server">
    <div class="contattiWrapper">
        <h1>Contatti</h1>
        <img class="fascia" src="images/fascia.png" />
        <div id="wrapperMap">
            <div id="infoContatti">
                <p>Indirizzo: <span>Via Jacopo da Corte, 8 - 35028 - Piove di Sacco (PD)</span></p>
                <p>Telefono: <span>+39.049 2612819</span></p>
                <p>Fax: <span>+39.049 2612819</span></p>
                <p>Email: <span>info@cuboingegneria.it</span></p>
            </div>
            <div id="googleMap"></div>
            <div id="formContatti">
                <div id="mailingForm" runat="server">
                
                <label id="mailingNomeLabel" class="inputContattiLabel" runat="server">Nome:</label>
                <asp:TextBox ID="mailingNome" runat="server" class="inputContatti"></asp:TextBox>
                <label id="nomeValidatorLabel" runat="server" />
                
                <label  id="mailingCognomeLabel" class="inputContattiLabel" runat="server">Cognome:</label>
                <asp:TextBox ID="mailingCognome" runat="server" class="inputContatti"></asp:TextBox>
                <label id="cognomeValidatorLabel" runat="server" />
 
                <label id="mailingEmailLabel" class="inputContattiLabel" runat="server">Email:</label>
                <asp:TextBox ID="mailingEmail" runat="server" class="inputContatti"></asp:TextBox>
                <label id="mailValidatorLabel" runat="server" />
                
                <label id="mailingIndirizzoLabel" class="inputContattiLabel" runat="server">Indirizzo:</label>
                <asp:TextBox ID="mailingIndirizzo" runat="server" class="inputContatti"></asp:TextBox>
                
                <label id="mailingCittaLabel" class="inputContattiLabel" runat="server">Citta':</label>
                <asp:TextBox ID="mailingCitta" runat="server" class="inputContatti"></asp:TextBox>

                <label id="mailingTelefonoLabel" class="inputContattiLabel" runat="server">Telefono:</label>
                <asp:TextBox ID="mailingTelefono" runat="server" class="inputContatti"></asp:TextBox>

                <label id="mailingOggettoLabel" class="inputContattiLabel" runat="server">Oggetto:</label>
                <asp:TextBox ID="mailingOggetto" runat="server" class="inputContatti"></asp:TextBox>
                <label id="oggettoValidatorLabel" runat="server" />

                <label id="mailingTestoLabel" class="inputContattiLabel" runat="server">Testo:</label>
                <asp:TextBox ID="mailingTesto" runat="server" type="text" class="inputContatti" rows="6" TextMode="multiline"></asp:TextBox>
                <label id="testoValidatorLabel" runat="server" />

                <div id="mailingPrivacy">
                    <asp:CheckBox class="formInputText" id="contact_privacy" runat="server"/>
                    <label id="privacyLabel" runat="server">Dichiaro di dare il consenso al trattamento dei miei dati personali</label>
                    <span id="validationText" style="color:red" runat="server"></span>
                    <p id="informativaLabel"> INFORMATIVA EX ART. 13 D. LGS. 196/2003 (CODICE DELLA PRIVACY) PER IL TRATTAMENTO DEI DATI PERSONALI.</p>  
                </div>
                <div id="mailingButton">
                    <div id="labelValid">
                        <label id="validitaCampi" runat="server">CAMPI NON VALIDI!</label>
                    </div>
                    <asp:Button ID="mailingSubmit" runat="server" Text="Invia Richiesta" OnClick="SendEmail" />
                </div>
            </div>
            </div>
            
        </div>
        
        
    </div>
</asp:Content>
