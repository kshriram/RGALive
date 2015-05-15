<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Master Forms/Admin.Master" AutoEventWireup="true" CodeBehind="frmRoles.aspx.cs" Inherits="ShippingController_V1._0_.Forms.Web_Forms.frmRoles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <%-- <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>--%>
     <asp:ScriptManager ID="ScriptManager1" runat="server"> </asp:ScriptManager>
    <div id="dvMain" class="border">
       <div>
                        <asp:LinkButton ID="lkbtnPath" runat="server" Font-Italic Font-Size="Large" Text="Admin" BackColor="Silver" BorderColor="blue"></asp:LinkButton>
                        <asp:Label ID="lblDivider" runat="server" Font-Italic Font-Size="Large" Text=">>" ForeColor="blue"></asp:Label>
                        <asp:LinkButton ID="lkbtnPath1" runat="server" Font-Italic Font-Size="Large" Text="Admin Log" BackColor="white" BorderColor="blue" ></asp:LinkButton>
                    </div>
                
        <div id="dvTitle" class="TitleStrip" style="height: 30px;"> Role Information
           
        </div>
        <div id="dvGrid" runat="server" style="padding-top: 10px; Height: 200px">
            <asp:Panel ID="pnlUserInformation" Width="70%" runat="server" BorderStyle="Groove" BorderColor="#FF9933" BorderWidth="2px" ScrollBars="Auto">
                <asp:GridView ID="gvUserInformation" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC"
                   Width="100%" CellPadding="4" CellSpacing="2" ForeColor="Black" OnSelectedIndexChanged="gvUserInformation_SelectedIndexChanged">
                    <Columns>
                        <asp:TemplateField HeaderText="Role ID">
                            <ItemTemplate>
                                 <asp:LinkButton ID="lbtnRoleId" CommandName="Select" runat="server" Text='<%# Eval("RoleId") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Role" DataField="Name" />
                        <asp:BoundField HeaderText="Actions" DataField="Permission" />
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
      
    </div>
      <div id="dvEditRoles" style="padding-top: 10px;">
            <div class="border" runat="server" style="padding-top: 10px; Height: 80px">
                <table id="tblEditRoles" runat="server" style="width: 90%; vertical-align: top; float: left; ">
                    <tr>
                        <td class="tdRight">
                            <asp:Label ID="lblcRoleName" CssClass="lbl" runat="server" Text="Role Name : " ForeColor="#4D8ED1" />
                        </td>
                        <td class="tdLeft">
                            <asp:TextBox ID="txtRoleName" CssClass="txt" runat="server" Text=""  ForeColor="Black" />
                        </td>
                        <td class="tdLeft">
                            <asp:CheckBox ID="rchIsSuperUser" runat="server" Text="Is Super User"   ForeColor="#4D8ED1"/>
                        </td>
                        <td class="tdLeft">
                            <asp:CheckBox ID="rchView" runat="server" Text="View Shipment"  ForeColor="#4D8ED1"/>
                        </td>
                        <td class="tdLeft">
                            <asp:CheckBox ID="rchScan" runat="server" Text="Scan Shipment"  ForeColor="#4D8ED1"/>
                        </td>
                        <td class="tdLeft">
                            <asp:CheckBox ID="rchReScan" runat="server" Text="Re-Scan Shipment" ForeColor="#4D8ED1" />
                        </td>
                        <td class="tdLeft">
                            <asp:CheckBox ID="rchOverride" runat="server" Text="Override Shipment"  ForeColor="#4D8ED1"/>
                        </td>

                    </tr>
                    <tr>
                        <td colspan="7" class="tdRight">
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn" OnClick="btnUpdate_Click"/>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn" OnClick="btnReset_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
</asp:Content>
