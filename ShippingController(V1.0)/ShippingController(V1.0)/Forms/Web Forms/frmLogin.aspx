<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Master Forms/Home.Master" AutoEventWireup="true" CodeBehind="frmLogin.aspx.cs" Inherits="ShippingController_V1._0_.Forms.Web_Forms.frmLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        #tdError {
            color:wheat;
            text-align:center;
            background-color:#ff6a00;
            width:100%;
        }

        .bdrmain {
            margin:auto;
            border: thick groove #0094ff;
            border-radius:20px;
        }
        
    </style>
    <div id="dvGap" style="height:150px;"></div>
    <div id="dvmain" style="width:26%; margin:auto">
        <table id="tblMaintblLogin" style=" width:100%; vertical-align:middle; float:none; margin:0;" class="bdrmain">
            <tr class="TitleStrip" style="margin-top:0;">
                <td id="TitleStrip" colspan="2" style="height: 40px">&nbsp;▷ Login
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align:right">
                    <asp:Label ID="lblUserName" runat="server" Text="User Name : &nbsp;" ForeColor="skyblue" Font-Bold="true"></asp:Label>
                </td>
                <td style="text-align:left">
                    <asp:TextBox ID="txtUserName" runat="server" Width="150px"></asp:TextBox>
                </td>

            </tr>
            <tr>
                <td style="text-align:right">
                    <asp:Label ID="Label1" runat="server" Text="Password : &nbsp;" ForeColor="skyblue" Font-Bold="true" Visible="false"></asp:Label>
                </td>
                <td style="text-align:left">
                    <asp:TextBox ID="txtPassword" runat="server" Width="150px" TextMode="Password" Text="2wvcDW8j" Visible="false" ></asp:TextBox>
                </td>
                
            </tr>
            <tr>
                <td colspan="2">
                    <div id="tdError" style="font-weight: bold; visibility: hidden; color: #fff; margin-bottom: 0px;">
                        <asp:Label Text="Error Msg" ID="lblMsg" runat="server"></asp:Label>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: right">
                    <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn" OnClick="btnLogin_Click" />
                    &nbsp;
                </td>
               </tr>
            
            </table>
      
    </div>
      <div id="Div1" style="height:250px"></div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
</asp:Content>
