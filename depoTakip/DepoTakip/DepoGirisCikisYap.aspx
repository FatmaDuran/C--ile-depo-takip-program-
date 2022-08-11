<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DepoGirisCikisYap.aspx.cs" Inherits="DepoTakip.DepoyaGiris" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 103%;
            height: 394px;
            margin-top: 0px;
        }
        .auto-style6 {
            height: 66px;
            }
        .auto-style8 {
            height: 79px;
        }
        .auto-style25 {
            height: 66px;
            width: 100px;
        }
        .auto-style26 {
            height: 79px;
            width: 100px;
        }
        .auto-style27 {
            width: 165%;
            height: 44px;
        }
        .auto-style28 {
            width: 301px;
            height: 41px;
        }
        .auto-style29 {
            height: 88px;
            width: 100px;
        }
        .auto-style30 {
            height: 88px;
            }
        .auto-style31 {
            height: 88px;
            width: 133px;
        }
        .auto-style32 {
            height: 66px;
            width: 133px;
        }
        .auto-style33 {
            height: 79px;
            width: 133px;
        }
        .auto-style34 {
            height: 88px;
            width: 197px;
        }
        .auto-style35 {
            height: 66px;
            width: 197px;
        }
        .auto-style36 {
            height: 79px;
            width: 197px;
        }
        .auto-style37 {
            height: 41px;
        }
        #form1 {
            height: 1454px;
        }
    </style>
</head>
<body style="height: 1182px; width: 1208px">
    <form id="form1" runat="server">
    <div>
    <h1 style="width: 1471px; background-color: #33CCCC; margin-bottom: 17px;">Depo Giriş</h1>
    </div>
&nbsp;<asp:ImageButton ID="ImageBtnGeri" runat="server" Height="70px" ImageUrl="~/resimler/images.jpeg" OnClick="ImageBtnGeri_Click" Width="100px" />
        <table class="auto-style1">
            <tr>
                <td class="auto-style29">
                    <asp:Label ID="Label1" runat="server" Text="İşlem"></asp:Label>
                </td>
                <td class="auto-style31">
                    <%--                    <asp:SqlDataSource ID="SqlDataSourceDepo" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnectionString %>" SelectCommand="SELECT [DepoID], [DepoAdi], [BirimID] FROM [Depolar]"></asp:SqlDataSource>--%>
                    <asp:DropDownList ID="DDLIslemTipi" runat="server"  AppendDataBoundItems="true" DataTextField="IslemAdi" DataValueField="IslemTipiID" Width="227px" OnSelectedIndexChanged="DDLIslemTipi_SelectedIndexChanged" AutoPostBack="true">
                     <%--<asp:ListItem Text="-Seciniz-" Value="" />--%>
                        <asp:ListItem Text="-Seciniz-" Value="0" />

                    </asp:DropDownList>
                </td>
                <td class="auto-style34">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<asp:Label ID="Label2" runat="server" Text="Verilen Kişi"></asp:Label>
                </td>
                <td class="auto-style30">
                    <asp:DropDownList ID="DDLVerilenKisi" runat="server" DataTextField="AdiSoyadi" DataValueField="KisiID"  Width="227px">
                      <asp:ListItem Text="-Seciniz-" Value="" />
                         </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style25">Depo Adı</td>
                <td class="auto-style32">
                    <%--<asp:ListItem Text="-Seciniz-" Value="" />--%><%--                    <asp:SqlDataSource ID="depogirisurun" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnectionString %>" SelectCommand="SELECT [BarkodNo], [UrunAdi] FROM [urunler]"></asp:SqlDataSource>--%><%-- <asp:DropDownList ID="DDLbirim" runat="server"  Width="145px" AutoPostBack="True"  DataTextField="BirimAdi" DataValueField="BirimID"--%>
                    <asp:DropDownList ID="DDLDepolar" runat="server" DataTextField="DepoAdi" DataValueField="DepoID" Height="50px" Width="227px" OnSelectedIndexChanged="DDLDepolar_SelectedIndexChanged" AutoPostBack="True" >
                       <asp:ListItem Text="-Seciniz-" Value="" />
                    </asp:DropDownList>
                </td>
                <td class="auto-style35">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Alınan Firma</td>
                <td class="auto-style6">
                    <asp:DropDownList ID="DDLFirmalar" runat="server" DataTextField="FirmaAdi" DataValueField="FirmaID" Width="227px" Height="50px">
                      <asp:ListItem Text="-Seciniz-" Value="" />
                         </asp:DropDownList>
                    <%-- <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnectionString %>" SelectCommand="SELECT [BarkodNo], [UrunAdi] FROM [urunler]"></asp:SqlDataSource>--%>
                </td>
            </tr>
            <tr>
                <td class="auto-style26">Ürün Adı</td>
                <td class="auto-style33">
                    <asp:DropDownList ID="DDLurunler" runat="server" DataTextField="UrunAdi" DataValueField="UrunID" Height="50px" Width="227px" OnSelectedIndexChanged="DDLurunler_SelectedIndexChanged">
                       <asp:ListItem Text="-Seciniz-" Value="" />
                    </asp:DropDownList>
                </td>
                <td class="auto-style36">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Tarih</td>
                <td class="auto-style8">
                    <asp:TextBox ID="TxtTarih" runat="server" Width="227px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style26">&nbsp;Adet</td>
                <td class="auto-style33">
                    <asp:TextBox ID="TxtUrunAdet" runat="server" Width="227px"></asp:TextBox>
                </td>
                <td class="auto-style36">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Açıklama</td>
                <td class="auto-style8">
                    <asp:TextBox ID="TxtAcıklama" runat="server" Height="51px" Width="227px"></asp:TextBox>
                </td>
            </tr>
        </table>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <table class="auto-style27">
            <tr>
                <td class="auto-style28">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                <td class="auto-style37">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="BtnGridviewEkle" runat="server" Text="+ EKLE" OnClick="BtnGridviewEkle_Click" />
                </td>
            </tr>
        </table>
        <br />
        <asp:GridView ID="GridViewDepoGirisCikis"  runat="server" DataKeyNames="id" OnRowDeleting="GridViewDepoGirisCikis_RowDeleting" Height="218px" Width="1199px" style="margin-top: 0px" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False" OnSelectedIndexChanged="GridViewDepoGirisCikis_SelectedIndexChanged">
            <Columns>
               <asp:CommandField ShowDeleteButton="true" SelectText="-&gt;" ShowSelectButton="True" />
             <%--   DataField="BirimAdi" HeaderText="BirimAdi" SortExpression="BirimID"--%>
                <asp:BoundField HeaderText="İşlem" DataField="IslemText" SortExpression="Islemid"/>
                <asp:BoundField HeaderText="Ürün" DataField="urunadi" SortExpression="urunid"/>   
                <asp:BoundField HeaderText="Adet" DataField="urunAdet"/>
                <asp:BoundField HeaderText="Depo" DataField="depoText" SortExpression="depoId"/>
                <asp:BoundField HeaderText="Verilen Kişi" DataField="VerilenKisiText" SortExpression="VerilenKisiId"/>
                <asp:BoundField HeaderText="Alınan Firma" DataField="AlınanFirmaText" SortExpression="AlınanFirmaId"/>
                <asp:BoundField HeaderText="Tarih"  DataField="Tarih"/>
                <asp:BoundField HeaderText="Açıklama"  DataField="Aciklama"/>
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Kaydet" runat="server" Width="84px" style="margin-left: 0px" OnClick="Kaydet_Click" Text="Kaydet" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
    </form>
</body>
</html>
