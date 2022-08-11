<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YeniMarkaEkleme.aspx.cs" Inherits="DepoTakip.YeniMarkaEkleme" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 74%;
            height: 215px;
            margin-left: 102px;
        }
        .auto-style2 {
            width: 217px;
        }
        .auto-style3 {
            width: 179px;
        }
        .auto-style4 {
            width: 179px;
            height: 108px;
        }
        .auto-style5 {
            width: 217px;
            height: 108px;
        }
        .auto-style6 {
            height: 108px;
        }
    </style>
</head>
<body style="height: 557px; width: 877px;">
    <form id="form1" runat="server">
    <div style="height: 43px; background-color: #33CCCC">
    
        <br />
        <br />
        <br />
        <asp:ImageButton ID="ImageButton1" runat="server" Height="61px" ImageUrl="~/Utility/images.jpeg" Width="100px" />
        <br />
        <br />
        <table class="auto-style1">
            <tr>
                <td class="auto-style4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; Marka</td>
                <td class="auto-style5">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TxtMarka" runat="server" ></asp:TextBox>
                    </td>
                <td class="auto-style6"></td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="BTNMarkaEkle" runat="server" Text="EKLE" OnClick="BTNMarkaEkle_Click" Width="77px"  />
                </td>
                <td class="auto-style2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="BtnSil" runat="server" OnClick="BtnSil_Click" Text="SİL" Width="88px" OnClientClick="return confirm('Bu işlem gerçekleşirse veri ile ilgi bütün yerler silinecektir. Emin misiniz?');" />
                </td>
                <td>&nbsp;
                    <asp:Button ID="BtnGüncelle" runat="server" OnClick="BtnGüncelle_Click" Text="GÜNCELLE" Width="88px" />
                </td>
            </tr>
        </table>
        &nbsp;<br />
        <asp:GridView ID="GridViewMarka" runat="server" DataKeyNames="MarkaID" AutoGenerateColumns="False" Height="237px" OnSelectedIndexChanged="GridViewMarka_SelectedIndexChanged" Width="401px" style="margin-left: 205px">
            <Columns>
                <asp:CommandField SelectText="-&gt;" ShowSelectButton="True" />
                  <asp:BoundField DataField="MarkaID" HeaderText="ID" SortExpression="MarkaID" Visible="false"/>
                 <asp:BoundField DataField="MarkaAdi" HeaderText="MarkaAdı" SortExpression="MarkaID" />
               
            </Columns>
        </asp:GridView>
    
        <br />
    
    </div>
    </form>
</body>
</html>
