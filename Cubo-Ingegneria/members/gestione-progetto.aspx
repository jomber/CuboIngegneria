﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gestione-progetto.aspx.cs" Inherits="Cubo_Ingegneria.members.gestione_progetto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="../css/main-master.css" type="text/css" />
    <link rel="stylesheet" href="../css/effects.css" type="text/css" />
    <script src="../js/jquery-1.9.1.min.js"></script>
    <script src="../js/cubo.js"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="divUpload">
    
        <div id="uploadForm" runat="server">
           <table id="tableUpload" style="width:300px">
                <tr>
                  <td><label id="nomeProgettoLabel" class="inputContattiLabel" runat="server">Nome Progetto:</label></td>
                  <td><asp:TextBox ID="uploadNomeProgetto" runat="server" class="inputUploadProgetto"></asp:TextBox>
                        <label id="nomeProgettoValidatorLabel" runat="server" />
                  </td> 
                </tr>
                <tr>
                  <td><label id="committenteLabel" class="inputContattiLabel" runat="server">Committente:</label></td>
                  <td><asp:TextBox ID="uploadCommittente" runat="server" class="inputUploadProgetto"></asp:TextBox>
                        <label id="committenteValidatorLabel" runat="server" />
                  </td> 
              
                </tr>
                <tr>
                  <td><label id="statoLabel" class="inputContattiLabel" runat="server">Stato:</label></td>
                  <td><asp:TextBox ID="uploadStato" runat="server" class="inputUploadProgetto"></asp:TextBox>
                        <label id="statoValidatorLabel" runat="server" />
                  </td> 
              
                </tr>
                <tr>
                  <td><label id="annoLabel" class="inputContattiLabel" runat="server">Anno:</label></td>
                  <td><asp:TextBox ID="uploadAnno" runat="server" class="inputUploadProgetto"></asp:TextBox>
                        <label id="annoValidatorLabel" runat="server" />
                  </td> 
              
                </tr>
                <tr>
                  <td><label  id="descrizioneProgettoLabel" class="inputContattiLabel" runat="server">Descrizione:</label></td>
                  <td><asp:TextBox ID="uploadDescrizioneProgetto" runat="server" class="inputUploadProgetto" rows="5" TextMode="multiline"></asp:TextBox>
                        <label id="descrizioneProgettoValidatorLabel" runat="server" />
                  </td> 
                </tr>
                <tr>
                  <td></td>
                  <td>
                        <asp:Button ID="btnUpload" runat="server" Text="Modifica Campi" OnClick="Edit" />
                  </td> 
                </tr>
            </table>
            
            
            <hr />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" ShowHeader="false">
                <Columns>
                    <asp:BoundField DataField="Text" />
                    <asp:ImageField DataImageUrlField="Value" ControlStyle-Height="100" ControlStyle-Width="100" />
                </Columns>
            </asp:GridView>
            <label  id="uploadErrorLabel" class="inputContattiLabel" runat="server"></label>
            <asp:ImageButton class="gestioneProgettoImg" runat="server" ImageUrl="../images/homeSmall.png" OnClick="home_Click"/>
            <asp:ImageButton class="gestioneProgettoImg" runat="server" ImageUrl="../images/editSmall.png" OnClick="modifica_Click"/>
            <asp:ImageButton class="gestioneProgettoImg" runat="server" ImageUrl="../images/deleteSmall.png" OnClick="cancella_Click"/>
            <asp:ImageButton class="gestioneProgettoImg" runat="server" ImageUrl="../images/uploadSmall.png" OnClick="immagini_Click"/>
        </div>
    </div>
    </form>
</body>
</html>
