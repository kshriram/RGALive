<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Master Forms/Admin.Master" AutoEventWireup="true" CodeBehind="frmUserInformation.aspx.cs" Inherits="ShippingController_V1._0_.Forms.Web_Forms.frmHomeIcon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <meta http-equiv="refresh" content="60;frmUserInformation.aspx"  />
    <style >
        .lblVeriables {
            color:#fff;
            font-family:Arial;
            font-size:20px;
            font-weight:bold;
        }
        .tdStrip {
            text-align:center;
            color:#d5a111;
            font-size:20px;
            background-color:black;
        }
        .lblConst {
            color:black;
            font-family:Arial;
            font-size:18px;
        }
         .dvMain {
             background-color: rgba(128, 128, 128, 0.40);
             border: medium groove #0094ff;
             vertical-align: top;
         }
    </style>
    <div class="dvMain">
        <table id="Table2" class="tblmain" style="width: 100%">
            <tr>
                <td class="TitleStrip">User Information</td>
            </tr>
            <tr>
                <td>
                    <div id="dvleft" style="width: 59%; float: left;" class="border">
                        <table id="tblmainall" class="tblmain" style="width: 100%">
                            <tr>
                                <td style="width: 100%">
                                    <div style=" text-align: center; width: 99%">
                                        <table id="Table1" style="width: 100%;padding:2px;">
                                            <tr class="TitleStrip">
                                                <td  colspan="8">
                                                    <asp:Label ID="lblActive" runat="server" Text="Active Users"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdRight" style="width: 18%">
                                                    <asp:Label ID="Label3" runat="server" CssClass="lbl" Text="Active Users: "></asp:Label>
                                                </td>
                                                <td class="tdLeft">
                                                    <asp:Label ID="lblCActiveUsers" runat="server" CssClass="lblVeriables" Text="00 "></asp:Label>
                                                </td>
                                                <td class="tdRight">
                                                    <asp:Label ID="Label1" runat="server" CssClass="lbl" Text="In-Active Users: "></asp:Label>
                                                </td>
                                                <td class="tdLeft">
                                                    <asp:Label ID="lblCInactiveUsers" runat="server" CssClass="lblVeriables" Text="00"></asp:Label>
                                                </td>
                                                <td class="tdRight">
                                                    <asp:Label ID="lblTotalUsers" runat="server" CssClass="lbl" Text="Total Users: "></asp:Label>
                                                </td>
                                                <td class="tdLeft">
                                                    <asp:Label ID="lblCTotalUsers" runat="server" CssClass="lblVeriables" Text="0"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="8">&nbsp;</td>
                                            </tr>
                                        </table>
                                        <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="100%" Height="200px">
                                            <asp:GridView HorizontalAlign="Center" Width="100%" VerticalAlign="Top" ID="gvLatestLogin" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="Black" GridLines="Horizontal" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" Style="margin-left: 0px" OnSelectedIndexChanged="gvLatestLogin_SelectedIndexChanged">
                                                <Columns>
                                                    <asp:CommandField ShowSelectButton="True" />
                                                    <asp:BoundField HeaderText="User Name" DataField="UserName" />
                                                    <asp:BoundField HeaderText="Station Name" DataField="StationName" />
                                                    <asp:BoundField HeaderText="Station Login Time" DataField="Datetime" />
                                                    <asp:BoundField HeaderText="Device ID" DataField="DeviceID" />
                                                    <asp:BoundField HeaderText="Packed" DataField="Packed" />
                                                    <asp:BoundField HeaderText="Current Shipment" DataField="CurrentPackingShipmentID" />
                                                    <asp:BoundField HeaderText="UserID" DataField="UserID" Visible="true" />
                                                </Columns>
                                                <FooterStyle BackColor="#4D8ED1" ForeColor="#4D8ED1" />
                                                <HeaderStyle BackColor="#333333" ForeColor="White" CssClass="fixedHeader " />
                                                <PagerStyle BackColor="#4D8ED1" ForeColor="#4D8ED1" HorizontalAlign="Right" />
                                                <SelectedRowStyle BackColor="#0099CC" Font-Bold="True" ForeColor="White" />
                                                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                                <SortedDescendingHeaderStyle BackColor="#242121" />
                                            </asp:GridView>

                                        </asp:Panel>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="dvright" style="width: 40%; float: right; padding: 2px" class="border">
                        <table id="Table3" style="width: 100%;">
                            <tr>
                                <td class="TitleStrip" colspan="2">
                                    <asp:Label ID="Label2" runat="server" Text="User Details"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdRight" style="width: 40%">
                                    <asp:Label ID="Label4" runat="server" CssClass="lbl" Text="User Name: "></asp:Label>
                                </td>
                                <td class="tdLeft" style="width: 60%">
                                    <asp:Label ID="_uNamelbl" runat="server" CssClass="lblVeriables" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdRight">
                                    <asp:Label ID="Label11" runat="server" CssClass="lbl" Text="User Role: "></asp:Label>
                                </td>
                                <td class="tdLeft">
                                    <asp:Label ID="_uRole" runat="server" CssClass="lblVeriables" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdRight" style="width: 30%">
                                    <asp:Label ID="Label6" runat="server" CssClass="lbl" Text="User Full Name: "></asp:Label>
                                </td>
                                <td class="tdLeft" style="width: 20%">
                                    <asp:Label ID="_uFullNamelbl" runat="server" CssClass="lblVeriables" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdRight">
                                    <asp:Label ID="Label12" runat="server" CssClass="lbl" Text="Address: "></asp:Label>
                                </td>
                                <td class="tdLeft" rowspan="2">
                                    <asp:Label ID="_uAddress" runat="server" CssClass="lblVeriables" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdRight">&nbsp;
                                </td>

                            </tr>
                            <tr>
                                <td class="tdRight">
                                    <asp:Label ID="Label9" runat="server" CssClass="lbl" Text="Joining Date: "></asp:Label>
                                </td>
                                <td class="tdLeft">
                                    <asp:Label ID="_uJoiningDatelbl" runat="server" CssClass="lblVeriables" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdRight">
                                    <asp:Label ID="Label8" runat="server" CssClass="lbl" Text="Login Time: "></asp:Label>
                                </td>
                                <td class="tdLeft">
                                    <asp:Label ID="_uLoginlbl" runat="server" CssClass="lblVeriables" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdRight">
                                    <asp:Label ID="Label5" runat="server" CssClass="lbl" Text="Current Station: "></asp:Label>
                                </td>
                                <td class="tdLeft">
                                    <asp:Label ID="_uCurrentStationlbl" runat="server" CssClass="lblVeriables" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdRight">
                                    <asp:Label ID="Label10" runat="server" CssClass="lbl" Text="Current Shipment: "></asp:Label>
                                </td>
                                <td class="tdLeft">
                                    <asp:Label ID="_uCurrentShipmentlbl" runat="server" CssClass="lblVeriables" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdRight">
                                    <asp:Label ID="Label7" runat="server" CssClass="lbl" Text="Total shipments packed: "></asp:Label>
                                </td>
                                <td class="tdLeft">
                                    <asp:Label ID="_uTotalPackedlbl" runat="server" CssClass="lblVeriables" Text=""></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
