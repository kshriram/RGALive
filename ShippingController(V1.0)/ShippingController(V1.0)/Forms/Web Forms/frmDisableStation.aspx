<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Master Forms/Admin.Master" AutoEventWireup="true" CodeBehind="frmDisableStation.aspx.cs" Inherits="ShippingController_V1._0_.Forms.Web_Forms.frmDisableStation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div id="dvmain" style="width:100%;border: medium groove #0099CC;">
        <table id="tblmain" style="width:100%;">
            <tr>
                <td class="TitleStrip" colspan="2">InActive/Active Stations</td>
            </tr>
            <tr>
                <td colspan="2" style="margin: 0px auto;">
                    <asp:GridView HorizontalAlign="Center" Width="100%" ID="gvStations" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" ForeColor="Black" OnSelectedIndexChanged="gvStations_SelectedIndexChanged" OnLoad="gvStations_Load" CellSpacing="2">
                        <Columns>
                            <asp:CommandField  SelectText="InActive/Activate" ShowSelectButton="True">
                                <ItemStyle ForeColor="Black" />
                            </asp:CommandField>
                            <asp:BoundField HeaderText="Station Name" DataField="StationName">
                                <ItemStyle ForeColor="Black" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Active Status" DataField="ActiveStatus">
                                <ItemStyle ForeColor="Black" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Device ID" DataField="DeviceID">
                                <ItemStyle ForeColor="Black" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Requested User" DataField="RequestedUserName">
                                <ItemStyle ForeColor="Black" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Request date" DataField="RequestedDate" >
                                <ItemStyle ForeColor="Black" />
                            </asp:BoundField>
                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" Font-Names="Arial"  />
                        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                        <RowStyle BackColor="White" />
                        <SelectedRowStyle BackColor=" #3399FF" Font-Bold="True" ForeColor="Black" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#808080" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#383838" />
                    </asp:GridView>
                  
                    
                </td>
                

            </tr>
        </table>

    </div>
</asp:Content>
