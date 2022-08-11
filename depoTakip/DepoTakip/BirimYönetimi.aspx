<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BirimYönetimi.aspx.cs" Inherits="DepoTakip.BirimDüzenle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style2 {
            width: 239px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 32px; background-color: #33CCCC;">
    
        <br />
        <br />
        <asp:ImageButton ID="ImageBtnGri" runat="server" Height="70px" ImageUrl="~/resimler/images.jpeg"  Width="100px" OnClick="ImageBtnGri_Click" />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Birim Adı"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TxbirimAd" runat="server"></asp:TextBox>
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <%--      <asp:RadioButtonList ID="RadioButtonList1" runat="server" Height="22px"  Width="193px">
     
    <asp:ListItem Text ="Aktif" Value="1" />
    <asp:ListItem Text ="Pasif" Value="0" />


        </asp:RadioButtonList>--%>
        <table style="width: 248px"> 
            <tr>
                <td class="auto-style2"> <asp:CheckBox runat="server"  Text="Aktif                                       " TextAlign="Left" ID="cbAktif"  /> </td>
                

            </tr>
        </table>
       
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="BtnBirimEkle" runat="server"  Text="EKLE" OnClick="BtnBirimEkle_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="BtnSil" runat="server"  Text="SİL" Width="62px" OnClick="BtnSil_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="BtnGüncelle" runat="server" OnClick="BtnGüncelle_Click" Text="Güncelle" />
        <br />
        <br />
        <asp:GridView ID="GridView1Birim" runat="server"  DataKeyNames="BirimID" AutoGenerateColumns="False" CellPadding="18"  Height="251px" style="margin-left: 156px" Width="560px"  OnSelectedIndexChanged="GridView1Birim_SelectedIndexChanged">
            <Columns>
                <asp:CommandField SelectText="-&gt;" ShowSelectButton="True" />
                <%--<asp:BoundField DataField="BirimID" HeaderText="BirimID" Visible="True" ReadOnly="True" SortExpression="BirimID" />--%>
                <asp:BoundField DataField="BirimAdi" HeaderText="BirimAdi" SortExpression="BirimID" />
                <asp:CheckBoxField DataField="Aktiflik" HeaderText="Aktiflik" SortExpression="Aktiflik" />
                <asp:TemplateField HeaderText="BirimID" Visible="False"></asp:TemplateField>
            </Columns>
        </asp:GridView>
        <%--<asp:BoundField DataField="BirimID" HeaderText="BirimID" Visible="True" ReadOnly="True" SortExpression="BirimID" />--%>
        <br />
    
    </div>
    </form>
</body>
</html>
