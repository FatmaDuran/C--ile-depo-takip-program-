<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MevcutSorgulama.aspx.cs" Inherits="DepoTakip.MevcutSorgulama" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            height: 613px;
        }
    </style>
</head>
<body style="height: 622px">
    <form id="form1" runat="server">
    <div style="height: 51px; background-color: #33CCCC">
    
    </div>
        <br />
        <asp:ImageButton ID="ImageButton1" runat="server" Height="70px" ImageUrl="~/resimler/images.jpeg" Width="100px" />
        <br />
        <asp:GridView ID="GridViewMevcutSorgu" runat="server" AutoGenerateColumns="False" Height="363px" Width="1163px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <%--<asp:BoundField HeaderText="Urun" DataField="UrunAdi" SortExpression="UrunAdi" />--%>
                  <asp:BoundField HeaderText="Urun" DataField="UrunAdi" SortExpression="UrunAdi" />
                <asp:BoundField HeaderText="Birim" DataField="BirimAdi" SortExpression="BirimAdi" />
                <%--<asp:BoundField HeaderText="Depo" DataField="DepoAdi" SortExpression="DepoAdi" />--%>
                 <asp:BoundField HeaderText="Depo" DataField="DepoAdi" SortExpression="DepoAdi"/>
                <asp:BoundField HeaderText="Adet" DataField="adet" SortExpression="adet" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
