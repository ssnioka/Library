<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="_4_laboratorinis.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Laboras</title>
    <style>
        body{
            background-image: url("https://www.photoblog.com/learn/wp-content/uploads/2019/02/kev-costello-467080-unsplash.jpg");
            font-weight: bold;
            color: white;
            background-color: #fefbd8;
            
        }
    </style>
</head>
<body style="height: 580px">
    <form id="form1" runat="server">
        <div style="height: 640px">
            U4_16. Biblioteka.<br />
            <br />
            2 ir daugiau metų senumo leidinių skaičius:
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            Visi moksliniai leidiniai:<asp:Table ID="Table1" runat="server" BorderStyle="Solid" GridLines="Both">
            </asp:Table>
            <br />
            Visų nenaujų leidinių sąrašas:<asp:Table ID="Table2" runat="server" BorderStyle="Solid" GridLines="Both">
            </asp:Table>
            <br />
            <br />
            Leidiniai, kurių tiražas viršija 10 000 vnt:<br />
            <asp:Table ID="Table3" runat="server" BorderStyle="Solid" GridLines="Both">
            </asp:Table>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        </div>
    </form>
</body>
</html>
