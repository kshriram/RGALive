<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmRMAPopup.aspx.cs" Inherits="ShippingController_V1._0_.Forms.Web_Forms.frmRMAPopup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../Themes/CSS/BlackCoffeeCSS.css" rel="stylesheet" />
    <style type="text/css">
        td {
            color: black;
            font-weight: bold;
            font-size: 15px;
            font-family: Arial;
            -webkit-transition: all 0.7s;
            transition: all 0.7s;
            width: 50%;
            margin-top: 5px;
        }

            /*td:hover {
                color: #509010;
                font-weight: bold;
                font-size: 15px;
                font-family: Arial;
                transform: scale(1.1,1.1);
                -webkit-transform: scale(1.1,1.1);
            }*/
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <div style="width: 70%; top: 50%; left: 50%;">
            <asp:Panel ID="pnModelPopup" runat="server">

                <table id="Table1" align="center" style="float: none; margin-left: 50%; margin-top: 10%; border-bottom-color: black; border-top-color: black; border-left-color: black; border-right-color: black;" runat="server" border="1">
                    <tr>
                        <td colspan="2">

                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Vertical" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" RepeatLayout="Table" AutoPostBack="true">

                                <asp:ListItem Text="Add RMA With PO" Value="wthpo"></asp:ListItem>
                                <asp:ListItem Text="Add RMA Without PO" Value="wthotpo"></asp:ListItem>
                                <asp:ListItem Text=" RMA With SR" Value="wthsr"></asp:ListItem>

                            </asp:RadioButtonList>
                            <asp:TextBox ID="txtRMAwith" runat="server" OnTextChanged="txtRMAwith_TextChanged" Visible="False" BorderColor="Black" BorderStyle="Solid" Height="23px" Width="230px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 50%">
                            <asp:Button ID="btnAdd" runat="server" Text="Next" CssClass="btn" OnClick="btnAdd_Click" />
                        </td>
                        <td>
                           <%-- <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn" OnClientClick="window.close();" />--%>
                             <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn" OnClientClick="btnCancel_Click" OnClick="btnCancel_Click" />
                        </td>
                    </tr>
                   
                </table>
               
            </asp:Panel>
        </div>
        <div>
            <asp:Panel ID="pnlMessage" runat="server" >
                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
