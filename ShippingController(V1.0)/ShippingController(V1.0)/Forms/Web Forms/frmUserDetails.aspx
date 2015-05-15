<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Master Forms/Admin.Master" AutoEventWireup="true" CodeBehind="frmUserDetails.aspx.cs" Inherits="ShippingController_V1._0_.Forms.Web_Forms.frmUserDetails" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="dvMain" runat="server" style="width: 100%">
        <div id="dvSearch" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <table id="tblmain" runat="server" style="width: 100%; padding: 2px;" class="border">
                <tr>
                    <td colspan="8" class="TitleStrip">User Information</td>
                </tr>
                <tr>
                    <td class="tdRight">
                        <asp:Label ID="lblUserName" runat="server" Text="User Name:" CssClass="lbl"></asp:Label>
                    </td>
                    <td class="tdLeft">
                        <asp:TextBox CssClass="txt" ID="txtUserName" runat="server" OnTextChanged="txtUserName_TextChanged" AutoPostBack="True"></asp:TextBox>
                    </td>
                    <td class="tdRight">
                        <asp:Label ID="Label3" runat="server" Text="User Full Name :" CssClass="lbl"></asp:Label>
                    </td>
                    <td class="tdLeft">
                        <asp:TextBox CssClass="txt" ID="txtUserFullName" runat="server" OnTextChanged="txtUserFullName_TextChanged" AutoPostBack="True"></asp:TextBox>
                    </td>
                    <td class="tdRight">
                        <asp:Label ID="Label1" runat="server" Text="Role :" CssClass="lbl"></asp:Label>
                    </td>
                    <td class="tdLeft">
                        <asp:TextBox CssClass="txt" ID="txtRoleName" runat="server" OnTextChanged="txtRoleName_TextChanged" AutoPostBack="True"></asp:TextBox>
                    </td>
                    <td class="tdRight">
                        <asp:Button ID="btnShowReport" runat="server" CssClass="btn" Text="Filter" OnClick="btnShowReport_Click" />
                    </td>
                    <td class="tdLeft" rowspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td class="tdRight">
                        <asp:Label ID="Label4" runat="server" Text="Joinig Date From:" CssClass="lbl"></asp:Label>
                    </td>
                    <td class="tdLeft">
                        <asp:TextBox CssClass="txt" ID="txtJoiningDateFrom" runat="server" OnTextChanged="txtJoiningDateFrom_TextChanged" AutoPostBack="True"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtJoiningDateFrom"></asp:CalendarExtender>
                    </td>
                    <td class="tdRight">
                        <asp:Label ID="Label5" runat="server" Text="Joining Date To :" CssClass="lbl"></asp:Label>
                    </td>
                    <td class="tdLeft">
                        <asp:TextBox CssClass="txt" ID="txtJoiningDateTo" runat="server" OnTextChanged="txtJoiningDateTo_TextChanged" AutoPostBack="True"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtJoiningDateTo"></asp:CalendarExtender>
                    </td>
                    <td class="tdRight">
                        <asp:Label ID="Label2" runat="server" Text="Address :" CssClass="lbl"></asp:Label>
                    </td>
                    <td class="tdLeft">
                        <asp:TextBox CssClass="txt" ID="txtAddress" runat="server" OnTextChanged="txtAddress_TextChanged" AutoPostBack="True"></asp:TextBox>
                    </td>
                    <td class="tdRight">
                        <asp:Button ID="btnRefresh" runat="server" CssClass="btn" Text="Reset" OnClick="btnRefresh_Click" />
                    </td>

                </tr>
            </table>
        </div>
        <div id="dvGrid" runat="server" style="padding-top: 10px; Height: 170px">
            <asp:Panel ID="pnlUserInformation" runat="server" Width="100%" Height="170px" BorderStyle="Groove" BorderColor="#FF9933" BorderWidth="2px" ScrollBars="Auto">
                <asp:GridView ID="gvUserInformation" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC"
                    CellPadding="4" CellSpacing="2" ForeColor="Black"
                    Width="100%" OnSelectedIndexChanged="gvUserInformation_SelectedIndexChanged">
                    <Columns>
                        <asp:CommandField HeaderText="Select" ShowSelectButton="True">
                            <ItemStyle ForeColor="#003399" />
                        </asp:CommandField>
                        <asp:BoundField HeaderText="User ID" DataField="UserID" />
                        <asp:BoundField HeaderText="User Name" DataField="UserName" />
                        <asp:BoundField HeaderText="User Full Name" DataField="UserFullName" />
                        <asp:BoundField HeaderText="Address" DataField="UserAddress" />
                        <asp:BoundField HeaderText="Role" DataField="RoleName" />
                        <asp:BoundField HeaderText="Joining Date" DataFormatString="{0:MMM dd, yyyy}" DataField="JoiningDate" />
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                    <RowStyle BackColor="White" />
                    <SelectedRowStyle BackColor="#0099cc" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                </asp:GridView>
            </asp:Panel>
        </div>
        <div id="dVEDITinfo" runat="server" style="width: 99%; margin-top:20px" class="border">
            <div id="dvTitleEdit" runat="server" class="TitleStrip" style="margin-top: 10px; margin-bottom: 5px;">User Detail</div>
            <div id="dvInfoEdit" runat="server">
                <table id="tblInfoEdit" runat="server" style="width: 90%">
                    <tr>
                        <td class="tdRight">
                            <asp:Label ID="Label6" runat="server" Text="User Full Name :" CssClass="lbl"></asp:Label>
                        </td>
                        <td class="tdLeft">
                            <asp:TextBox CssClass="txt" ID="txtEUserFName" runat="server"></asp:TextBox>
                        </td>

                        <td class="tdRight">
                            <asp:Label ID="Label7" runat="server" Text="User Name :" CssClass="lbl"></asp:Label>
                        </td>
                        <td class="tdLeft">
                            <asp:TextBox CssClass="txt" ID="txtEUserName" runat="server"></asp:TextBox>
                        </td>
                        <td class="tdRight">
                            <asp:Label ID="Label8" runat="server" Text="Password :" CssClass="lbl"></asp:Label>
                        </td>
                        <td class="tdLeft">
                            <asp:TextBox CssClass="txt" ID="txtEPass" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="btnAdd" runat="server" CssClass="btn" Text="Add User" OnClick="btnAdd_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td class="tdRight">
                            <asp:Label ID="Label9" runat="server" Text="User Role :" CssClass="lbl"></asp:Label>
                        </td>
                        <td class="tdLeft">
                            <asp:DropDownList ID="ddlRoles" runat="server" Width="130px"></asp:DropDownList>
                        </td>
                        <td class="tdRight">
                            <asp:Label ID="Label10" runat="server" Text="Joining Date :" CssClass="lbl"></asp:Label>
                        </td>
                        <td class="tdLeft">
                            <asp:TextBox CssClass="txt" ID="txtEJoiningDate" runat="server"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtEJoiningDate" Format="MMM dd, yyyy"></asp:CalendarExtender>
                        </td>
                        <td class="tdRight">
                            <asp:Label ID="Label12" runat="server" Text="Address :" CssClass="lbl"></asp:Label>
                        </td>
                        <td class="tdLeft" rowspan="2">
                            <asp:TextBox CssClass="txt" ID="txtEaddress" runat="server" Height="55px" Width="220px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="btnUpdate" runat="server" CssClass="btn" Text="Update" OnClick="btnUpdate_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td class="tdRight">&nbsp;</td>
                        <td class="tdLeft">&nbsp;</td>

                        <td class="tdRight">&nbsp;</td>
                        <td class="tdRight">&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>

                            <asp:Button ID="btnReset" runat="server" CssClass="btn" Text="Reset" OnClick="btnReset_Click" />

                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
