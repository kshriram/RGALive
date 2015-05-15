<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Master Forms/Admin.Master" AutoEventWireup="true" CodeBehind="frmHomePage.aspx.cs" Inherits="ShippingController_V1._0_.Forms.Web_Forms.frmHomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<meta http-equiv="refresh" content="60" />--%>
    <style>
        .lblVeriables {
            color: #2a8011;
            font-family: Arial;
            font-size: 20px;
            font-weight: bold;
        }

        .tdStrip {
            text-align: center;
            color: #d5a111;
        }

        .lblConst {
            color: black;
            font-family: Arial;
            font-size: 20px;
            font-weight: bold;
        }

        #dvMain {
            background-color: rgba(128, 128, 128, 0.40);
            border: medium groove #0094ff;
            vertical-align: top;
        }
    </style>
    <div id="dvMain" style="width: 98%; height: 570px;">
        <div id="dvleft" style="float: left; width: 70%" >
            <div id="StationTotalPacking" runat="server" style="height: 300px;padding-bottom:20px;">
                <table style="width: 100%;padding:5px; ">
                    <tr>
                        <td style="width: 50%; padding-right:5px;">
                            <div class="border">
                                <asp:Literal ID="ltrChart" runat="server" />
                            </div>
                        </td>
                        <td class="border" >
                            <iframe id="iFrmInternalKraus" runat="server" src="http://internal.kraususa.net/ticker.php" style="background-color: white;height:299px; width:100%; overflow-x:hidden" />
                        </td>
                    </tr>
                </table>
            </div>
            <div class="border" >
            <table style="width: 100%;">
                <tr style="margin-left:0px;">
                    <td class="TitleStrip">&nbsp;▷ 
                    User Logged Today
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:Panel HorizontalAlign="Center" ID="panel1" runat="server" Height="190px" ScrollBars="Auto">
                                    <asp:GridView Width="100%" HorizontalAlign="Right" ID="gvLatestLogin" runat="server" AutoGenerateColumns="False" CellPadding="3" ForeColor="Black" GridLines="Vertical" BackColor="White" Style="margin-left: 0px" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px">
                                        <AlternatingRowStyle BackColor="#CCCCCC" />
                                        <Columns>
                                            <asp:TemplateField ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:LinkButton PostBackUrl="~/Forms/Web Forms/frmUserInformation.aspx" ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select" Text="Select"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="User Name" DataField="UserName" />
                                            <asp:BoundField HeaderText="Station Name" DataField="StationName" />
                                            <asp:BoundField HeaderText="Station Login Time" DataField="Datetime" />
                                            <asp:BoundField HeaderText="Device ID" DataField="DeviceID" />
                                        </Columns>
                                        <FooterStyle BackColor="#CCCCCC" />
                                        <HeaderStyle BackColor="Black" ForeColor="White" CssClass="fixedHeader " Font-Bold="True" />
                                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#0099CC" Font-Bold="True" ForeColor="White" />
                                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                        <SortedAscendingHeaderStyle BackColor="#808080" />
                                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                        <SortedDescendingHeaderStyle BackColor="#383838" />
                                    </asp:GridView>
                                </asp:Panel>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
                </div>
        </div>
        <div id="dvRight" style="width: 29%; float: right;"class="border">
            <table style="width: 100%">
                <tr>
                    <td class="TitleStrip" style="vertical-align: top">&nbsp;▷
                    Shippments Packing
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top">
                        <asp:Panel HorizontalAlign="Center" ID="panelContainer" runat="server" Height="510px" ScrollBars="Auto">
                            <asp:GridView HorizontalAlign="Right" ID="gvShipmentPacking" Width="100%" runat="server" AutoGenerateColumns="False" CellPadding="3" ForeColor="Black" GridLines="Vertical" BackColor="White" Style="margin-left: 0px" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px">
                                <AlternatingRowStyle BackColor="#CCCCCC" />
                                <Columns>
                                    <asp:BoundField HeaderText="ShipmentID" DataField="PackingID" />
                                    <asp:BoundField HeaderText="Location" DataField="ShipmentLocation" />
                                    <asp:BoundField HeaderText="User Name" DataField="UserName" />
                                </Columns>
                                <FooterStyle BackColor="#CCCCCC" />
                                <HeaderStyle BackColor="Black" ForeColor="White" CssClass="fixedHeader " Font-Bold="True" />
                                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                <SortedAscendingHeaderStyle BackColor="#808080" />
                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                <SortedDescendingHeaderStyle BackColor="#383838" />
                            </asp:GridView>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </div>
        <script src="../../Themes/js/jquery-1.5.1.min.js"></script>
        <script src="../../Themes/js/highcharts.js"></script>
    </div>
</asp:Content>
