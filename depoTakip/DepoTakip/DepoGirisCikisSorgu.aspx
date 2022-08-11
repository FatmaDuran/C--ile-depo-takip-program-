<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DepoGirisCikisSorgu.aspx.cs" Inherits="DepoTakip.DepoyaGirisSorgu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            margin-bottom: 375px;
        }
    </style>
</head>
<body style="height: 734px">
    <form id="form1" runat="server">
    <div style="height: 45px; background-color: #33CCCC">
    
        <br />
        <br />
    
    </div>
        <br />
        <asp:ImageButton ID="ImageButton1" runat="server" Height="70px" ImageUrl="~/resimler/images.jpeg" OnClick="ImageButton1_Click" Width="100px" />
        <br />
        <br />
        <asp:GridView ID="GridViewGirisCikisSorgu" runat="server" AutoGenerateColumns="False" Height="327px" Width="1240px" OnSelectedIndexChanged="GridViewGirisCikisSorgu_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="Yapılan İslem"  DataField="IslemAdi" SortExpression="IslemTipiID"/>
                <asp:BoundField HeaderText="İslemi YapanKisi" DataField="KullaniciAdi" SortExpression="KullaniciID" />
                <asp:BoundField HeaderText="Depo" DataField="DepoAdi" SortExpression="DepoAdi"/>
                <asp:BoundField HeaderText="Urun" DataField="UrunAdi" SortExpression="UrunAdi" />
                <asp:BoundField HeaderText="Verilen Kisi" DataField="VerilenKisi" SortExpression="KisiID" />
                <asp:BoundField HeaderText="Alınan Firma" DataField="FirmaAdi" SortExpression="FirmaID" />
                <asp:BoundField HeaderText="Tarih" DataField="Tarih" SortExpression="Tarih" />
                <asp:BoundField HeaderText="Açıklama" DataField="Aciklama" SortExpression="Aciklama"/>
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
