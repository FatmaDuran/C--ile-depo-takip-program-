<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YeniModelEkleme.aspx.cs" Inherits="DepoTakip.YeniModelEkleme" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 42%;
            height: 251px;
            margin-left: 99px;
        }
        #form1 {
            height: 26px;
        }
        .auto-style2 {
            width: 183px;
        }
        .auto-style3 {
            width: 155px;
        }
        .auto-style4 {
            width: 155px;
            height: 68px;
        }
        .auto-style5 {
            width: 183px;
            height: 68px;
        }
        .auto-style6 {
            height: 68px;
        }
    </style>
</head>
<body style="height: 692px">
    <form id="form1" runat="server">
    <div style="height: 35px; background-color: #33CCCC; width: 1179px;">
    
        <br />
        <br />
        <asp:ImageButton ID="ImgBtnGeri" runat="server" Height="70px" ImageUrl="~/Utility/images.jpeg" Width="100px" OnClick="ImgBtnGeri_Click" />
        <br />
&nbsp;&nbsp;&nbsp;
        <table class="auto-style1">
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="Label2" runat="server" Text="Marka"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:DropDownList ID="DDL2marka" DataTextField="MarkaAdi" DataValueField="MarkaID" runat="server" Width="168px">
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">Model</td>
                <td class="auto-style2">
                    <asp:TextBox ID="TxtModel" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="BtnEkle" runat="server" Text="EKLE" OnClick="BtnEkle_Click" Height="27px" Width="75px" />
                </td>
                <td class="auto-style5">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="BtnSil" runat="server" OnClick="BtnSil_Click"  Text="SİL" Width="73px" OnClientClick="return confirm('Bu işlem gerçekleşirse veri ile ilgi bütün yerler silinecektir. Emin misiniz?');" />
                </td>
                <td class="auto-style6">
                    <asp:Button ID="BtnGüncelle" runat="server" Text="GÜNCELLE" Width="90px" OnClick="BtnGüncelle_Click" />
                </td>
            </tr>
        </table>
        <br />
        <br />
        <asp:GridView ID="GridViewModel" runat="server" DataKeyNames="ModelID" AutoGenerateColumns="False" Height="238px"  Width="376px" OnSelectedIndexChanged="GridViewModel_SelectedIndexChanged" style="margin-left: 162px">
            <Columns>
                <asp:CommandField SelectText="-&gt;" ShowSelectButton="True" />
               
                <asp:BoundField DataField="ModelID" HeaderText="ID" SortExpression="ModelID" Visible="false"/>
                 <asp:BoundField DataField="ModelAdi" HeaderText="ModelAdı" SortExpression="ModelAdi" />
                <asp:BoundField DataField="MarkaID" HeaderText="MarkaAdı" SortExpression="MarkaID" Visible="false" />
            </Columns>
        </asp:GridView>
        <br />
        <br />
        <br />
    
    </div>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
&nbsp;&nbsp; 
    </form>
</body>
</html>
