<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YeniUrunGrubuEkleme.aspx.cs" Inherits="DepoTakip.YeniUrunGrubuEkleme" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            height: 678px;
        }
        .auto-style1 {
            width: 86%;
            height: 204px;
            margin-left: 104px;
        }
        .auto-style4 {
            width: 197px;
            height: 77px;
        }
        .auto-style5 {
            width: 206px;
            height: 77px;
        }
        .auto-style6 {
            height: 77px;
        }
        .auto-style7 {
            width: 197px;
            height: 69px;
        }
        .auto-style8 {
            width: 206px;
            height: 69px;
        }
        .auto-style9 {
            height: 69px;
        }
    </style>
</head>
<body style="height: 644px; width: 761px; margin-bottom: 326px;">
    <form id="form1" runat="server">
    <div style="height: 47px; font-style: italic; width: 761px; background-color: #33CCCC">
    
    </div>
    &nbsp;<br />
        <asp:ImageButton ID="BtnGeri" runat="server" Height="70px" ImageUrl="~/Utility/images.jpeg" OnClick="BtnGeri_Click" Width="100px" />
        <br />
        <br />
        <table class="auto-style1">
            <tr>
                <td class="auto-style7">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Text="Yeni Grup Adı"></asp:Label>
                </td>
                <td class="auto-style8">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TxtYeniGrup" runat="server" style="margin-left: 28px"></asp:TextBox>
                </td>
                <td class="auto-style9"></td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Btngrupekle" runat="server"  Text="EKLE" Width="100px" OnClick="Btngrupekle_Click" />
                </td>
                <td class="auto-style5">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="BtnSil" runat="server" Text="SİL" Width="100px" OnClick="BtnSil_Click" />
                </td>
                <td class="auto-style6">
                    <asp:Button ID="BtnGüncelle" runat="server" Text="GÜNCELLE" Width="100px" OnClick="BtnGüncelle_Click" />
                </td>
            </tr>
        </table>
        <br />
        <asp:GridView ID="GrdviewUrunGrup" runat="server" DataKeyNames="UrunGrupID" AutoGenerateColumns="False" Height="221px"  OnSelectedIndexChanged="GrdviewUrunGrup_SelectedIndexChanged" Width="410px" style="margin-left: 200px">
            <Columns>
                <asp:CommandField SelectText="-&gt;" ShowSelectButton="True" />
                <asp:BoundField DataField="UrunGrupID" HeaderText="ID" SortExpression="UrunGrupID" Visible="false"/>
                 <asp:BoundField DataField="UrunGrubu" HeaderText="Grup" SortExpression="UrunGrupID" />
                <%-- <asp:TemplateField HeaderText="UrunGrupID">
                   <ItemTemplate>
   <asp:Label ID="lblID" runat="server"

                                  Text='<%#Eval("UrunGrupID")%>'></asp:Label>

                    </ItemTemplate>
                   
                </asp:TemplateField>--%>
                <%-- <asp:TemplateField HeaderText="UrunGrupID">
                    <ItemTemplate>
   <asp:TextBox ID="lblID2" runat="server"

                                  Text='<%#Eval("UrunGrubu")%>'></asp:TextBox>

                    </ItemTemplate>
                   
                </asp:TemplateField>
                <asp:TemplateField HeaderText="UrunGrubu"></asp:TemplateField>--%>
               
            </Columns>
        </asp:GridView>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </form>
</body>
</html>
