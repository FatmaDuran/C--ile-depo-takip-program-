<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UrunBilgileri.aspx.cs" Inherits="DepoTakip.UrunBilgileri" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 177%;
            height: 48px;
            margin-bottom: 0px;
            background-color: #33CCCC;
        }
        #form1 {
            margin-top: 0px;
        }
        .auto-style9 {
            width: 161%;
            height: 299px;
        }
        .auto-style24 {
            width: 140px;
            height: 65px;
        }
        .auto-style25 {
            width: 710px;
            height: 65px;
        }
        .auto-style26 {
            height: 65px;
        }
    </style>
</head>
<body style="height: 1002px; width: 620px; margin-right: 0px; margin-bottom: 9px;">
    <form id="form1" runat="server">
        <h1 class="auto-style1"><em>Ürün Bilgileri</em></h1>
        <asp:ImageButton ID="ImageButton1" runat="server" Height="70px" ImageUrl="~/Utility/images.jpeg" OnClick="ImageButton1_Click" Width="98px" />
        <br />
        <br />
        <table class="auto-style9">
            <tr>
                <td class="auto-style24">
                    <asp:Label ID="Label5" runat="server" Text="Ürün Grubu"></asp:Label>
                </td>
                <td class="auto-style25">
                    <asp:DropDownList ID="DDLUrunGrubu" runat="server" DataTextField="UrunGrubu" DataValueField="UrunGrupID"  Height="40px" Width="227px" OnSelectedIndexChanged="DDLUrunGrubu_SelectedIndexChanged" AutoPostBack="true"  AppendDataBoundItems="true">
                    <asp:ListItem Text="-Seciniz-" Value="" />
                    </asp:DropDownList>

                  <%--  <asp:DropDownList ID="ddlMylist" runat="server" AppendDataBoundItems="true">
    
</asp:DropDownList>--%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnYeniGrup" runat="server"  Text="+ Yeni Grup" Width="120px" OnClick="btnYeniGrup_Click" />
                </td>
                <td class="auto-style26">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnEkle" runat="server" Height="35px" OnClick="btnEkle_Click" Text="EKLE" Width="95px" />
                </td>
            </tr>
            <tr>
                <td class="auto-style24">
                    <asp:Label ID="Label2" runat="server" Text="Markası"></asp:Label>
                </td>
                <td class="auto-style25">
                    <asp:DropDownList ID="DDLMarka" runat="server" DataTextField="MarkaAdi" DataValueField="MarkaID"  Height="40px" Width="227px" OnSelectedIndexChanged="DDLMarka_SelectedIndexChanged" AutoPostBack="true" AppendDataBoundItems="true">
                    <asp:ListItem Text="-Seciniz-" Value="" />
                    </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="ChcbxMarka" runat="server" AutoPostBack="true"  OnCheckedChanged="ChcbxMarka_CheckedChanged" Text="Tüm Markalar" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="BtnYeniMarka" runat="server"  Text="+ Yeni Marka" Width="120px" OnClick="BtnYeniMarka_Click" />
                </td>
                <td class="auto-style26">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style24">
                    <asp:Label ID="Label3" runat="server" Text="Modeli"></asp:Label>
                </td>
                <td class="auto-style25">
                    <asp:DropDownList ID="DDLModel" runat="server"
                        
                         DataTextField="ModelAdi"  DataValueField="ModelID" Height="40px" Width="227px" AutoPostBack="true" OnSelectedIndexChanged="DDLModel_SelectedIndexChanged" >
                    <asp:ListItem Text="-Seciniz-" Value="" />
                    </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;<asp:Button ID="BtnYeniModel" runat="server"  style="margin-left: 0px" Text="+ Yeni Model" Width="120px" OnClick="BtnYeniModel_Click" />
                </td>
                <td class="auto-style26">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnSil" runat="server" Height="35px" OnClick="btnSil_Click" Text="SİL" Width="95px" />
                </td>
            </tr>
            <tr>
                <td class="auto-style24">
                    <asp:Label ID="Label1" runat="server" Text="Ürün Adı"></asp:Label>
                </td>
                <td class="auto-style25"><asp:TextBox ID="txtUrunAdi" runat="server" Height="22px" Width="227px"></asp:TextBox>
                    </td>
                <td class="auto-style26">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style24">
                    <asp:Label ID="Label4" runat="server" Text="Haber Limiti"></asp:Label>
                </td>
                <td class="auto-style25">
                    <asp:TextBox ID="txtHaberlimit" runat="server" Height="20px"  Width="227px"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
                <td class="auto-style26">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnGuncelle" runat="server" Height="35px" OnClick="btnGuncelle_Click" Text="GÜNCELLE" Width="95px" />
                </td>
            </tr>
        </table>
        <br />
        <h1 class="auto-style1"><em>Ürünler</em></h1>
        <br />
        <br />
        <asp:GridView ID="GridViewUrunBilgileri" runat="server" DataKeyNames="UrunID" AutoGenerateColumns="False" Height="252px" Width="1099px" OnSelectedIndexChanged="GridViewUrunBilgileri_SelectedIndexChanged">
            <Columns>
               <%--  <asp:BoundField  HeaderText="UrunGrubu" />--%>
                <asp:CommandField SelectText="-&gt;" ShowSelectButton="True" />
                    <asp:BoundField DataField="UrunGrupID" HeaderText="UrunAdi" SortExpression="UrunAdi" Visible="false"/>
                 <asp:BoundField DataField="MarkaID" HeaderText="UrunAdi" SortExpression="UrunAdi" Visible="false"/>
                 <asp:BoundField DataField="ModelID" HeaderText="UrunAdi" SortExpression="UrunAdi" Visible="false"/>

                <asp:BoundField DataField="UrunAdi" HeaderText="UrunAdi" SortExpression="UrunAdi" />
                <asp:BoundField DataField="UrunGrubu" HeaderText="UrunGrubu" SortExpression="UrunGrubu"/>
                <asp:BoundField DataField="Marka" HeaderText="Marka" SortExpression="Marka" />
                <asp:BoundField DataField="Model" HeaderText="Model" SortExpression="Model" />
                <asp:BoundField DataField="Limit" HeaderText="Limit" SortExpression="Limit" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
