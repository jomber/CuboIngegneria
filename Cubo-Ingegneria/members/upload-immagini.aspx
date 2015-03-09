<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="upload-immagini.aspx.cs" Inherits="Cubo_Ingegneria.members.upload_immagini" %>

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
    <div id="divUpload">
    
        <div id="uploadForm" runat="server">
            <table id="tableUpload" style="width:300px">
                <tr>
                  <td><asp:FileUpload ID="fileUpload1" runat="server" class="fileUpload"/></td>
                  <td><label style="color:green; font-weight:bold">Default</label></td> 
                </tr>
                <tr>
                  <td><asp:FileUpload ID="fileUpload2" runat="server" class="fileUpload"/></td>
                  <td></td> 
                </tr>
                <tr>
                  <td><asp:FileUpload ID="fileUpload3" runat="server" class="fileUpload"/></td>
                  <td></td> 
                </tr>
                <tr>
                  <td><asp:FileUpload ID="fileUpload4" runat="server" class="fileUpload"/></td>
                  <td></td> 
                </tr>
                <tr>
                  <td><asp:FileUpload ID="fileUpload5" runat="server" class="fileUpload"/></td>
                  <td></td> 
                </tr>
                <tr>
                  <td></td>
                  <td><asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="Upload" /></td> 
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
            <asp:ImageButton id="indietro" runat="server" ImageUrl="../images/indietro.png" OnClick="indietro_click"/>
        </div>
    </div>
    </form>
</body>
</html>
