﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cancella-progetto.aspx.cs" Inherits="Cubo_Ingegneria.members.cancella_progetto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="stylesheet" href="../css/main-master.css" type="text/css" />
    <link rel="stylesheet" href="../css/effects.css" type="text/css" />
    <script src="../js/jquery-1.9.1.min.js"></script>
    <script src="../js/cubo.js"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="divCreate">
         <h1>Cancella Progetti</h1>
        <img class="fascia" src="../images/fascia.png" />
        <div id="progettiDelete" runat="server"></div>
        <img class="fascia" src="../images/fascia.png" />
        <asp:ImageButton id="indietro" runat="server" ImageUrl="../images/indietro.png" OnClick="indietro_click"/>
    </div>
    </form>
</body>
</html>

