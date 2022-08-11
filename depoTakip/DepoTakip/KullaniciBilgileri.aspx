<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KullaniciBilgileri.aspx.cs" Inherits="DepoTakip.KisiBilgileri" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: left;
            color: #333399;
            background-color: #33CCCC;
            height: 45px;
            width: 1469px;
            font-style: italic;
        }
        .auto-style2 {
            width: 82%;
            height: 469px;
        }
        #form1 {
            height: 45px;
            width: 715px;
            margin-bottom: 893px;
            margin-right: 1027px;
        }
        .auto-style7 {
            width: 311px;
        }
        .auto-style9 {
            width: 430px;
        }
        .auto-style10 {
            width: 426px;
        }
        .auto-style11 {
            width: 426px;
            height: 60px;
        }
        .auto-style12 {
            width: 430px;
            height: 60px;
        }
        .auto-style13 {
            width: 311px;
            height: 60px;
        }
        .auto-style20 {
            width: 426px;
            height: 50px;
        }
        .auto-style21 {
            width: 430px;
            height: 50px;
        }
        .auto-style22 {
            width: 311px;
            height: 50px;
        }
        .auto-style23 {
            width: 426px;
            height: 69px;
        }
        .auto-style24 {
            width: 430px;
            height: 69px;
        }
        .auto-style25 {
            width: 311px;
            height: 69px;
        }
        .auto-style26 {
            width: 426px;
            height: 80px;
        }
        .auto-style27 {
            width: 430px;
            height: 80px;
        }
        .auto-style28 {
            width: 311px;
            height: 80px;
        }
        .auto-style29 {
            width: 426px;
            height: 54px;
        }
        .auto-style30 {
            width: 430px;
            height: 54px;
        }
        .auto-style31 {
            width: 311px;
            height: 54px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1 class="auto-style1"><em>Kullanıcı Bilgileri</em></h1>
    </div>
        <table class="auto-style2">
            <tr>
                <td class="auto-style26">Kullanıcı Adı</td>
                <td class="auto-style27">
                    <asp:TextBox ID="TxtkulAdi" runat="server" Width="156px" ></asp:TextBox>
                </td>
                <td class="auto-style28">
                    <asp:Button ID="BtnEkle" runat="server" Height="36px" OnClick="Button1_Click" Text="EKLE" Width="104px" />
                </td>
            </tr>
            <tr>
                <td class="auto-style11">Şifre</td>
                <td class="auto-style12">
                    <asp:TextBox ID="Txtsifre" runat="server" Height="24px"></asp:TextBox>
                </td>
                <td class="auto-style13"></td>
            </tr>
            <tr>
                <td class="auto-style23">Adı</td>
                <td class="auto-style24">
                    <asp:TextBox ID="TxtAd" runat="server" Height="16px"></asp:TextBox>
                </td>
                <td class="auto-style25">
                    <asp:Button ID="BtnSil" runat="server" Height="36px" Text="SİL" Width="104px" OnClick="BtnSil_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style29">Soyadı</td>
                <td class="auto-style30">
                    <asp:TextBox ID="TxtSoyad" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style31"></td>
            </tr>
            <tr>
                <td class="auto-style10">Email Adresi</td>
                <td class="auto-style9">
                    <asp:TextBox ID="TxtMail" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style7">
                    <asp:Button ID="BtnGuncelle" runat="server" Height="36px" OnClick="Button3_Click" Text="GÜNCELLE" Width="104px" />
                </td>
            </tr>
            <tr>
                <td class="auto-style29">Rolü</td>
                <td class="auto-style30">
                    <asp:DropDownList ID="DDLrol" runat="server"  AutoPostBack="True" >
                        <asp:ListItem Text="-Seciniz-" Value="" />
                        <asp:ListItem Value="1">Bölüm Yöneticisi</asp:ListItem>
                        <asp:ListItem Value="2">Normal Kullanıcı</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style31"></td>
            </tr>
            <tr>
                <td class="auto-style20">Birimi</td>
                <td class="auto-style21">
                    <asp:DropDownList ID="DDLbirim" runat="server"  Width="145px" AutoPostBack="True"  DataTextField="BirimAdi" DataValueField="BirimID"  >
                       <asp:ListItem></asp:ListItem>
                         <asp:ListItem Text="-Seciniz-" Value="" />
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSourceBirim" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnectionString %>" SelectCommand="SELECT [BirimID], [BirimAdi] FROM [Birimler]"></asp:SqlDataSource>
                </td>
                <td class="auto-style22">
                    &nbsp;</td>
            </tr>
        </table>
        <br />
        <h1 class="auto-style1">Eklenen Kullanıcılar</h1>
        <asp:GridView ID="GridView1" runat="server" DataKeyNames="KullaniciID" AutoGenerateColumns="False"  Height="224px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="1041px">
            <Columns>
                <asp:CommandField   SelectText="-&gt;" ShowSelectButton="True" />

                <%--<asp:BoundField DataField="KullaniciID" Visible="true" HeaderText ="KullanıcıID" SortExpression="KullaniciID"  />--%>
                <asp:BoundField DataField="KullaniciID" HeaderText="Kullanıcı No" SortExpression="KullaniciAdi" Visible="false"/>
                <asp:BoundField DataField="Adı" HeaderText="Adı" SortExpression="Adı" />
                <asp:BoundField DataField="Soyadı" HeaderText="Soyadı" SortExpression="Soyadı" />
                <asp:BoundField DataField="Mail adresi" HeaderText="Mail Adresi" SortExpression="Mail_adresi" />
                <asp:BoundField DataField="BirimAdi" HeaderText="Birim Adı" SortExpression="BirimID" />
                <asp:BoundField DataField="Rolü" HeaderText="Rolü" SortExpression="Rolü" />
            </Columns>
        </asp:GridView>
             <asp:SqlDataSource ID="DB" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnectionString %>" SelectCommand="SELECT [BirimID], [KullaniciAdi], [Sifre], [Soyadı], [Adı], [Rolü], [Mail adresi] AS Mail_adresi, [KullaniciID] FROM [Kullanicilar]"></asp:SqlDataSource>

        <br />
        <br />
    </form>
</body>
</html>
