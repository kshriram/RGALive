
<%@ Page Title="Shipment Details" Language="C#" MasterPageFile="~/Forms/Master Forms/Admin.Master" AutoEventWireup="true" CodeBehind="frmShipmentInfoDetails.aspx.cs" Inherits="ShippingController_V1._0_.Forms.Web_Forms.frmShipmentInfoDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <script src="../../Themes/js/jquery-1.5.1.min.js"></script>
    <script src="../../Themes/js/highcharts.js"></script>
    <style>
        .ExportExcel {
            background-image: url(../../Themes/Images/excel_icon.png);
            background-repeat: no-repeat;
            background-position:left;
            height: 32px;
            width: 165px;
            border-color: #ff6a00;
            border-radius: 10px;
            border-width: thin;
            border-style: groove;
            font-weight: 700;
            font-family: Arial;
            font-size: 14px;
            text-align:right
        }
             .lblVeriables {
            color: #000;
            font-family: Arial;
            font-size: 14px;
            font-weight: bold;
        }

        .tdStrip {
            text-align: center;
            color: #d5a111;
        }
        .Test {
            height:44px;
            width:95px;
            background-image:url("../../Themes/Images/Arrow.gif");
            background-size:contain;
            background-position:left;
            background-repeat:no-repeat;
            vertical-align:central;
            text-align:center;
            align-content:center;
            font-size:smaller;
            color:black;
        }
    </style>
   
    <table id="tblMain" style="width: 99.9%">
         <table style="width: 1350px;">
                <tr>
                    <td>
                        <asp:LinkButton ID="lkbtnPath" runat="server" Font-Italic Font-Size="Large" Text="Shipment" BackColor="Silver" BorderColor="blue" ></asp:LinkButton>
                        <asp:Label ID="lblDivider" runat="server" Font-Italic Font-Size="Large" Text=">>" ForeColor="blue"></asp:Label>
                        <asp:LinkButton ID="lkbtnPath1" runat="server" Font-Italic Font-Size="Large" Text="Shipment Details" BackColor="white" BorderColor="blue" ></asp:LinkButton>
                    </td>
                </tr>
        <tr>
            <td class="TitleStrip">Shipment Detail Information
            </td>
        </tr>
        <tr>
            <td>
                <div id="dvIDonly" runat="server">
                    <asp:Accordion
                        ID="Accordion1"
                        runat="Server"
                        SelectedIndex="1"
                        HeaderCssClass="accordionHeader"
                        HeaderSelectedCssClass="accordionHeaderSelected"
                        ContentCssClass="accordionContent"
                        AutoSize="None"
                        FadeTransitions="true"
                        TransitionDuration="250"
                        FramesPerSecond="40"
                        RequireOpenedPane="false"
                        SuppressHeaderPostbacks="true" Width="100%" Height="112px">
                        <Panes>
                            <asp:AccordionPane runat="server" ID="AccordionPane1"
                                HeaderCssClass="accordionHeader" 
                                ContentCssClass="accordionContent">
                                <Header>&nbsp;∇∇&nbsp;Basic Search</Header>
                                <Content>
                                    <table style="width: 100%; border-bottom-color: #0094ff; border-bottom-width: medium; border-bottom-style: groove;">
                                        <tr>
                                            <td class="tdRight">
                                                <asp:Label ID="Label2" runat="server" Text="ShipmentID :" CssClass="lbl"></asp:Label>
                                            </td>
                                            <td class="tdLeft">
                                                <asp:TextBox CssClass="txt" ID="txtShipmentID" runat="server" OnTextChanged="txtShipmentID_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                <asp:AutoCompleteExtender ID="txtShipmentID_AutoCompleteExtender" runat="server"
                                                    ServiceMethod="SearchpackingID"
                                                    MinimumPrefixLength="1"
                                                    ServicePath="~/Forms/Web Forms/AutoCompleteService.aspx"
                                                    CompletionInterval="100"
                                                    EnableCaching="true"
                                                    CompletionSetCount="20"
                                                    TargetControlID="txtShipmentID">
                                                </asp:AutoCompleteExtender>
                                            </td>
                                            <td class="tdRight">
                                                <asp:Label ID="lblBoxNumber" runat="server" Text="Box Number :" CssClass="lbl"></asp:Label>
                                            </td>
                                            <td class="tdLeft">
                                                <asp:TextBox CssClass="txt" ID="txtBoxNumber" runat="server" AutoPostBack="true" OnTextChanged="txtBoxNumber_TextChanged"></asp:TextBox>
                                                <asp:AutoCompleteExtender ID="AutoCompleteExtender5" runat="server"
                                                    ServiceMethod="serachBoxNumber"
                                                    MinimumPrefixLength="1"
                                                    ServicePath="~/Forms/Web Forms/AutoCompleteService.aspx"
                                                    CompletionInterval="100"
                                                    EnableCaching="true"
                                                    CompletionSetCount="20"
                                                    TargetControlID="txtBoxNumber">
                                                </asp:AutoCompleteExtender>
                                            </td>
                                            <td class="tdRight">
                                                <asp:Label ID="lblTrackingNumber" runat="server" Text="Tracking Number :" CssClass="lbl"></asp:Label>
                                            </td>
                                            <td class="tdLeft">
                                                <asp:TextBox CssClass="txt" ID="txtTrackingNumber" runat="server" AutoPostBack="true" OnTextChanged="txtTrackingNumber_TextChanged"></asp:TextBox>
                                                <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server"
                                                    ServiceMethod="SearchTrackingNumber"
                                                    MinimumPrefixLength="1"
                                                    ServicePath="~/Forms/Web Forms/AutoCompleteService.aspx"
                                                    CompletionInterval="100"
                                                    EnableCaching="true"
                                                    CompletionSetCount="20"
                                                    TargetControlID="txtTrackingNumber">
                                                </asp:AutoCompleteExtender>
                                            </td>
                                            <td class="tdLeft" style="width: 30%; text-align: right;">
                                                <asp:Button ID="btnRefresh2" runat="server" Text="Reset" CssClass="btn" OnClick="btnRefresh_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </Content>
                            </asp:AccordionPane>
                        </Panes>
                        <Panes>
                            <asp:AccordionPane runat="server" ID="AccordionPane2"
                                HeaderCssClass="accordionHeader"
                                ContentCssClass="accordionContent">
                                <Header>&nbsp;∇∇&nbsp;Advance Search</Header>
                                <Content>
                                    <div id="dvAllinfo" runat="server" class="border">
                                        <table style="width: 100%;">
                                            <tr>
                                                <td class="tdRight">
                                                    <asp:Label ID="lblUserName" runat="server" Text="User Name :" CssClass="lbl"></asp:Label>
                                                </td>
                                                <td class="tdLeft">
                                                    <asp:DropDownList ID="ddlUserName"  runat="server" Width="150px" AutoPostBack="True" OnTextChanged="ddlUserName_TextChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td class="tdRight">
                                                    <asp:Label ID="Label1" runat="server" Text="Packing Status :" CssClass="lbl"></asp:Label>
                                                </td>
                                                <td class="tdLeft">
                                                    <asp:DropDownList ID="ddlpackingStatus" runat="server" Width="100px" AutoPostBack="True" OnTextChanged="ddlpackingStatus_TextChanged">
                                                        <asp:ListItem Value="-1" Text="Select">--All Status--</asp:ListItem>
                                                        <asp:ListItem Value="0" Text="Packed">Packed</asp:ListItem>
                                                        <asp:ListItem Value="1" Text="PackedPatially">Patially Packed</asp:ListItem>
                                                        <asp:ListItem Value="2" Text="Shipping">Shipping</asp:ListItem>
                                                        <asp:ListItem Value="3" Text="Shipped">Shipped</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td class="tdRight">
                                                    <asp:Label ID="lblLocation" runat="server" Text="Override Mode:" CssClass="lbl"></asp:Label>
                                                </td>
                                                <td class="tdLeft">
                                                    <asp:DropDownList ID="ddlOverrideMode" runat="server" Width="100px" AutoPostBack="True" OnTextChanged="ddlOverrideMode_TextChanged">
                                                        <asp:ListItem Value="-1" Text="Any">--All Modes--</asp:ListItem>
                                                        <asp:ListItem Value="0" Text="NoOverride">No Override</asp:ListItem>
                                                        <asp:ListItem Value="1" Text="Manager">Manager Override</asp:ListItem>
                                                        <asp:ListItem Value="2" Text="Salf">Salf Override</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td class="tdRight">
                                                    <asp:Label ID="lblPoNnumber" runat="server" Text="PO Number:" CssClass="lbl"></asp:Label>
                                                </td>
                                                <td class="tdLeft">
                                                    <asp:TextBox CssClass="txt" ID="txtPoNumber" runat="server" OnTextChanged="txtPoNumber_TextChanged" AutoPostBack="True"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdRight">
                                                    <asp:Label ID="lblFromDate" runat="server"  Text="From Date :" CssClass="lbl"></asp:Label>
                                                </td>
                                                <td class="tdLeft">
                                                    <asp:TextBox CssClass="txt" ID="dtpFromDate" runat="server" OnTextChanged="dtpFromDate_TextChanged" AutoPostBack="True"></asp:TextBox>
                                                    <asp:CalendarExtender ID="CalendarExtender1" TargetControlID="dtpFromDate" runat="server" Format="MMM dd, yyyy"></asp:CalendarExtender>
                                                </td>
                                                <td class="tdRight">
                                                    <asp:Label ID="lblTodate" runat="server" Text="To Date :" CssClass="lbl"></asp:Label>
                                                </td>
                                                <td class="tdLeft">
                                                    <asp:TextBox CssClass="txt" ID="dtpToDate" runat="server" OnTextChanged="dtpToDate_TextChanged" AutoPostBack="True"></asp:TextBox>
                                                    <asp:CalendarExtender ID="CalendarExtender2" TargetControlID="dtpToDate" runat="server" Format="MMM dd, yyyy"></asp:CalendarExtender>
                                                </td>
                                                <td class="tdRight">
                                                    <asp:Label ID="Label18" runat="server" Text="Location :" CssClass="lbl"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlLocation" runat="server" Width="150px" AutoPostBack="True" OnTextChanged="ddlLocation_TextChanged">
                                                        <asp:ListItem Value="-1" Text="Select">--All Locations--</asp:ListItem>
                                                        <asp:ListItem Value="0" Text="NYWH">NYWH</asp:ListItem>
                                                        <asp:ListItem Value="1" Text="NYWT">NYWT</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td class="tdRight" colspan="2">
                                                     <asp:Button ID="btnExport" runat="server" Text="Export Manifest"  CssClass="ExportExcel" Onclick="btnExport_Click"/>
                                                &nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Button ID="btnRefresh" runat="server" Text="Reset" CssClass="btn" OnClick="btnRefresh_Click" />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp
                                                </td>
                                            </tr>

                                        </table>
                                    </div>
                                </Content>
                            </asp:AccordionPane>
                        </Panes>
                        <HeaderTemplate>ASX</HeaderTemplate>
                        <ContentTemplate>asdfasdfasdf</ContentTemplate>
                    </asp:Accordion>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <div id="Div3" runat="server">
                    <asp:Accordion
                        ID="Accordion2"
                        runat="Server"
                        SelectedIndex="0"
                        HeaderCssClass="accordionHeader"
                        HeaderSelectedCssClass="accordionHeaderSelected"
                        ContentCssClass="accordionContent"
                        AutoSize="None"
                        FadeTransitions="true"
                        TransitionDuration="250"
                        FramesPerSecond="40"
                        RequireOpenedPane="false"
                        SuppressHeaderPostbacks="true" Width="100%">
                        <Panes>
                            <asp:AccordionPane runat="server" ID="AccordionPane4"
                                HeaderCssClass="accordionHeader"
                                ContentCssClass="accordionContent">
                                <Header>
                                    &nbsp;∇∇&nbsp;Shipping information
                                </Header>
                                <Content>
                                    <div id="dvShippingInfo" runat="server">
                                        <asp:Panel ID="panel2" runat="server" Height="300px" ScrollBars="Auto">
                                            <asp:GridView ID="gvShippingInfo" Width="100%" runat="server" HorizontalAlign="Center" AutoGenerateColumns="False"
                                                 BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2"
                                                 ForeColor="Black" 
                                                OnSelectedIndexChanged="gvShippingInfo_SelectedIndexChanged">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="ShipmentID">
                                                        <ItemTemplate>
                                                          <asp:LinkButton ID="lbtnShipmentId" OnClick="gvShippingInfo_SelectedIndexChanged" CommandName="Select" runat="server" Text='<%# Eval("ShippingNum") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="Start Date" DataFormatString="{0:MMM dd, yyyy hh:mm tt}" DataField="ShippingStartTime" />
                                                    <asp:BoundField HeaderText="Delivery Provider" DataField="DeliveryProvider" />
                                                    <asp:BoundField HeaderText="Delivery Mode" DataField="DeliveryMode" />
                                                    <asp:BoundField HeaderText="Order ID" DataField="OrderID" />
                                                    <asp:BoundField HeaderText="PO Number" DataField="CustomerPO" />
                                                    <asp:BoundField HeaderText="Carrier" DataField="Carrier" />
                                                    <asp:BoundField HeaderText="Vendor Name" DataField="VendorName" />
                                                </Columns>
                                                <FooterStyle BackColor="#CCCCCC" />
                                                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                                                <RowStyle BackColor="White" />
                                                <SelectedRowStyle BackColor="#0099cc" Font-Bold="True" ForeColor="Black" />
                                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                <SortedAscendingHeaderStyle BackColor="#808080" />
                                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                <SortedDescendingHeaderStyle BackColor="#383838" />
                                            </asp:GridView>
                                        </asp:Panel>
                                    </div>
                                </Content>
                            </asp:AccordionPane>
                        </Panes>
                       <HeaderTemplate>ASX</HeaderTemplate>
                        <ContentTemplate>asdfasdfasdf</ContentTemplate>
                    </asp:Accordion>
                </div>
                <div>
                    <asp:Accordion
                        ID="Accordion3"
                        runat="Server"
                        SelectedIndex="0"
                        HeaderCssClass="accordionHeader"
                        HeaderSelectedCssClass="accordionHeaderSelected"
                        ContentCssClass="accordionContent"
                        AutoSize="None"
                        FadeTransitions="true"
                        TransitionDuration="250"
                        FramesPerSecond="40"
                        RequireOpenedPane="false"
                        SuppressHeaderPostbacks="true" Width="100%" Height="80px">
                        <Panes>
                            <asp:AccordionPane runat="server" ID="AccordionPane5"
                                HeaderCssClass="accordionHeader"
                                ContentCssClass="accordionContent">
                                <Header>&nbsp;∇∇&nbsp;Packing Information<asp:Label ID="lblPShipNumSelected" runat="server" Text=" "></asp:Label>
                                </Header>
                                <Content>
                                    <div id="mainPacking" runat="server" style="width: 100%">
                                        <div id="Div1" runat="server" style="float: left; width: 100%">
                                            <asp:Panel ID="panel1" runat="server" Height="80px" ScrollBars="Auto">
                                                <asp:GridView ID="gvPackingInformation" Width="100%" runat="server" HorizontalAlign="Center" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" OnSelectedIndexChanged="gvPackingInformation_SelectedIndexChanged">
                                                    <Columns>
                                                        <asp:TemplateField  HeaderText="PackingID">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="PackingID" runat="server" Text='<%#Eval("PCKRowID") %>' OnClick="gvPackingInformation_SelectedIndexChanged" CommandName="Select" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField HeaderText="ShipmentID" DataField="ShipmentID" />
                                                        <asp:BoundField HeaderText="Location" DataField="Location" />
                                                        <asp:BoundField HeaderText="Who" DataField="UserName" />
                                                        <asp:BoundField HeaderText="Start Time" DataField="StartTime" />
                                                        <asp:BoundField HeaderText="Time Spent" DataField="TimeSpent" />
                                                        <asp:BoundField HeaderText="Packing Status" DataField="PackingStatus" />
                                                        <asp:BoundField HeaderText="Override" DataField="ManagerOVerride" />
                                                        <asp:BoundField HeaderText="Shipping Status" DataField="ShippedStatus" />
                                                        <asp:BoundField HeaderText="Tracking Number" DataField="TrackingNumber"  Visible="false"/>
                                                    </Columns>
                                                    <FooterStyle BackColor="#CCCCCC" />
                                                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                                                    <RowStyle BackColor="White" />
                                                    <SelectedRowStyle BackColor="#0099cc" Font-Bold="True" ForeColor="Black" />
                                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                    <SortedAscendingHeaderStyle BackColor="#808080" />
                                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                    <SortedDescendingHeaderStyle BackColor="#383838" />
                                                </asp:GridView>
                                            </asp:Panel>
                                            <asp:HiddenField ID="PosY" runat="server" Value="0" />
                                            <asp:HiddenField ID="PosX" runat="server" Value="0" />
                                        </div>

                                    </div>
                                </Content>
                            </asp:AccordionPane>
                        </Panes>
                        <HeaderTemplate>ASX</HeaderTemplate>
                        <ContentTemplate>asdfasdfasdf</ContentTemplate>
                    </asp:Accordion>
                </div>
                <div id="dvShipmentAll" runat="server" style="width: 100%">
                    <table id="tblShipmentsAll" runat="server" style="width: 100%; margin: 0px auto;">
                        <tr>
                            <td>
                                <div style="width: 100%">
                                    <asp:Accordion
                                        ID="MyAccordion"
                                        runat="Server"
                                        SelectedIndex="0"
                                        HeaderCssClass="accordionHeader"
                                        HeaderSelectedCssClass="accordionHeaderSelected"
                                        ContentCssClass="accordionContent"
                                        AutoSize="None"
                                        FadeTransitions="true"
                                        TransitionDuration="250"
                                        FramesPerSecond="40"
                                        RequireOpenedPane="false"
                                        SuppressHeaderPostbacks="true" Width="100%">
                                        <Panes>
                                            <asp:AccordionPane runat="server" ID="userpnl"
                                                HeaderCssClass="accordionHeader"
                                                ContentCssClass="accordionContent">
                                                <Header>&nbsp;∇∇&nbsp;Packing Detail Information<asp:Label ID="lblpdShipNumSelected" runat="server"  Text=" "></asp:Label></Header>
                                                <Content>
                                                    <table id="tblSSKUfo" runat="server" style="width: 100%">
                                                        <tr>
                                                            <td>
                                                                
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <div style="width: 54%; float: left;" class="border">
                                                                    <asp:Panel ID="pnlBoxinfo" runat="server" ScrollBars="Auto" Height="200px">
                                                                    <table id="Table1" runat="server" style="width: 100%;">
                                                                        <tr>
                                                                            <td style="font-size: 15px; font-weight: bold; color: #0094ff; background-color: black; font-family: Arial;">Box Details<asp:Label ID="lblBoxDetailFor" runat="server" Text=" "></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:GridView HorizontalAlign="Center" ID="gvBoxDetails" runat="server" Width="100%" AutoGenerateColumns="False"
                                                                                    BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2"
                                                                                    ForeColor="Black" OnSelectedIndexChanged="gvBoxDetails_SelectedIndexChanged">
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="Box No">
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton ID="BOXNUM" runat="server" Text='<%#Eval("BOXNUM") %>' OnClick="gvBoxDetails_SelectedIndexChanged" CommandName="Select" />
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:BoundField HeaderText="Weight" DataField="BoxWeight" />
                                                                                        <asp:BoundField HeaderText="Height" DataField="BoxHeight" />
                                                                                        <asp:BoundField HeaderText="Length" DataField="BoxLength" />
                                                                                        <asp:BoundField HeaderText="Width" DataField="BoxWidth" />
                                                                                        <asp:BoundField HeaderText="Packed" DataField="BoxCreatedTime" DataFormatString="{0:MMM dd, yyyy hh:mm:ss tt}" />
                                                                                        <asp:BoundField HeaderText="Tracking Number" DataField="TrackingNumber"/>
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
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                        </asp:Panel>
                                                                </div>

                                                                <div id="dvTableSku" runat="server" style="width: 45%; float: right" class="border">
                                                                    <asp:Panel ID="PnlSKuInfo" runat="server" ScrollBars="Auto" Height="200px">
                                                                        <table id="tblSKu" runat="server" style="width: 100%; padding: 2px">
                                                                            <tr>
                                                                                <td colspan="6" style="font-size: 15px; font-weight: bold; color: #0094ff; background-color: black; font-family: Arial;">SKU Details</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="6">
                                                                                    <asp:Label ID="lblpackingDetails" runat="server" ForeColor="#E27C1D" Font-Size="Medium" Font-Names="Arial" Font-Bold="true" />
                                                                                    <div style="width: 100%; float: right">
                                                                                        <asp:GridView HorizontalAlign="Center" ID="gvSKUinfo" runat="server" Width="100%" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black">
                                                                                            <Columns>
                                                                                                <asp:BoundField HeaderText="SKU Name" DataField="SKUNumber" />
                                                                                                <asp:BoundField HeaderText="Qty." DataField="SKUQuantity" />
                                                                                                <asp:BoundField HeaderText="Start Time" DataField="PackingDetailStartDateTime" DataFormatString="{0:MMM dd, yyyy hh:mm:ss tt}" Visible="false" />
                                                                                                <asp:BoundField HeaderText="Location" DataField="ShipmentLocation" />
                                                                                                <asp:BoundField HeaderText="Box Number" DataField="BoxNumber"/>
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
                                                                                        
                                                                                    </div>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </asp:Panel>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </Content>
                                            </asp:AccordionPane>
                                        </Panes>
                                        <HeaderTemplate>ASX</HeaderTemplate>
                                        <ContentTemplate>asdfasdfasdf</ContentTemplate>
                                    </asp:Accordion>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    
    <div style="width: 100%">
        <div style="width: 55%; float: left" class="border">
            <table style="margin: 2px; width: 99%; height: 200px">
                <tr>
                    <td colspan="6" style="font-size: 15px; font-weight: bold; color: #0094ff; background-color: black; font-family: Arial;">Tracking Details</td>
                </tr>
                <tr>
                    <td colspan="6">
                        <asp:Label ID="lblTrackingError" runat="server" ForeColor="#E27C1D" Font-Size="Medium" Font-Names="Arial" Font-Bold="true" />
                         <asp:Panel ID="Panel3" runat="server" ScrollBars="Auto" Height="150" >
                            <asp:GridView HorizontalAlign="Center" ID="gvTrackingInformation" runat="server" Width="100%" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" OnSelectedIndexChanged="gvTrackingInformation_SelectedIndexChanged">
                                <Columns>
                                    <asp:BoundField HeaderText="Box Number" DataField="BoxNum" />
                                    <asp:BoundField HeaderText="Tracking Number" DataField="TrackingNum" />
                                    <asp:BoundField HeaderText="Charges" DataField="PCKCHG" DataFormatString="${0:C}"/>
                                    <asp:BoundField HeaderText="Weight" DataField="Weight" />
                                     <asp:BoundField HeaderText="Voided" DataField="VOIIND" />
                                    <asp:TemplateField HeaderText="Ready to Export" SortExpression="ReadyToExport">
                                        <ItemTemplate><%--<%# (Boolean.Parse(Eval("ReadyToExport").ToString())) ? "Yes" : "No" %>--%>
                                              <asp:LinkButton ID="lbtnReadyTOExport" runat="server" Text='<%#(Boolean.Parse(Eval("ReadyToExport").ToString())) ? "Ready" : "Not Ready"  %>' CommandName="Select" OnClick="gvTrackingInformation_SelectedIndexChanged" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Exported" SortExpression="Exported">
                                       <ItemTemplate>
                                           <asp:Label ID="lblExported" runat="server" Text='<%#(Boolean.Parse(Eval("Exported").ToString()))?"Yes":"No" %>' />
                                       </ItemTemplate>
                                   </asp:TemplateField>
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
                    </td>
                </tr>
            </table>
            
        </div>
        <div style="width:43%; float: right; margin-right:20px " >
            <div style="margin: 1px; text-align: center; align-content: center;" id="dvUserPacking" runat="server" class="border">
                <asp:Literal ID="ltrChart" runat="server" />
            </div>
        </div>
    </div>
    </asp:Content>
