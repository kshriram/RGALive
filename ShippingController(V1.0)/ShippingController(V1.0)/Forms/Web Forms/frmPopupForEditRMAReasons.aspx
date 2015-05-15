<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmPopupForEditRMAReasons.aspx.cs" Inherits="ShippingController_V1._0_.Forms.Web_Forms.frmPopupForEditRMAReasons" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <title>Select Reason</title>
    <link href="../../Themes/CSS/BlackCoffeeCSS.css" rel="stylesheet" />
    <style type="text/css">
        td {
            color:black;
            font-weight:bold;
            font-size:15px;
            font-family:Arial;
            -webkit-transition:all 0.7s;
            transition:all 0.7s;
            width:50%;
            margin-top:5px;
        }
        td:hover {
            color:#509010;
            font-weight:bold;
            font-size:15px;
            font-family:Arial;
            transform:scale(1.1,1.1);
            -webkit-transform:scale(1.1,1.1);
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
  <div style="width:100%;">
    <asp:Panel ID="pnModelPopup" runat="server"   >
            <table style="float:none; margin-left:60px;margin-top:20px;">
                <tr>
                    <td colspan="2">
                        <asp:CheckBoxList ID="chkreasons" runat="server" Height="45px" Width="389px"></asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <td style="width:50%">
                   <asp:Button ID="btnAdd" runat="server" CssClass="btn" Text="Add"  Style="margin-left: 100px" OnClick="btnAdd_Click1" />
                     </td>
                    <td style="width:50%">
                        <asp:Button ID="btnCancel" runat="server" CssClass="btn" Text="Cancel"  onclientclick="window.close();" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
