<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Master Forms/Admin.Master" AutoEventWireup="true" CodeBehind="frmRetunDetail.aspx.cs" Inherits="ShippingController_V1._0_.Forms.Web_Forms.frmRetunDetail" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" ScriptMode="Release" />
    <script src="../../Themes/js/jquery-1.5.1.min.js"></script>
    <script src="../../Themes/js/highcharts.js"></script>
    <script type="text/javascript">
        window.onload = function () {
            var strCook = document.cookie;
            if (strCook.indexOf("!~") != 0) {
                var intS = strCook.indexOf("!~");
                var intE = strCook.indexOf("~!");
                var strPos = strCook.substring(intS + 2, intE);
                document.getElementById("dvReturnInfo").scrollTop = strPos;
            }
        }
        function SetDivPosition() {
            var intY = document.getElementById("dvReturnInfo").scrollTop;
            document.cookie = "yPos=!~" + intY + "~!";
        }
    </script>
    <script type="text/javascript">
        function ResetScrollToTop() {
            document.cookie = "yPos=!~" + 00 + "~!";
        }
    </script>
    <script type="text/javascript">
        function imageMethod(id) {
            var imagename = document.getElementById(id).src;
            window.open(imagename, 'popUpWindow', 'scrollbars=no,width=900,height=900,toolbars=no');
        }

        function windowOpen() {
            myWindow = window.open('~/Forms/Web Forms/ImageShow.aspx', 'Images', 'width=200,height=100, scrollbars=no,resizable=no')
            myWindow.focus()
            return false;
        }
    </script>
    <style>
        .ExportExcel {
            background-image: url(../../Themes/Images/excel_icon.png);
            background-repeat: no-repeat;
            background-position: left;
            height: 32px;
            width: 165px;
            border-color: #ff6a00;
            border-radius: 10px;
            border-width: thin;
            border-style: groove;
            font-weight: 700;
            font-family: Arial;
            font-size: 14px;
            text-align: right;
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
            height: 44px;
            width: 95px;
            background-image: url("../../Themes/Images/Arrow.gif");
            background-size: contain;
            background-position: left;
            background-repeat: no-repeat;
            vertical-align: central;
            text-align: center;
            align-content: center;
            font-size: smaller;
            color: black;
        }
        /*.ImageSize {
            height:180px;
            width:220px;
        }*/
    </style>

    <table id="tblMain" style="width: 1350px; height">
        <tr>
                <td>
                    <asp:LinkButton ID="lkbtnPath" runat="server" Font-Italic Font-Size="Large" Text="Home Page" BackColor="white" BorderColor="blue" ></asp:LinkButton>
                    <asp:Label ID="lblDivider" runat="server" Font-Italic Font-Size="Large" Text=">>" ForeColor="blue"></asp:Label>
                    <asp:LinkButton ID="lkbtnPath1" runat="server" Font-Italic Font-Size="Large" Text="Return Details" BackColor="white" BorderColor="blue" ></asp:LinkButton>
                    
                </td>
            </tr>
        <tr>
            <td class="TitleStrip">Return Details Information (RMA)
            </td>
        </tr>
        <tr>
            <td>
                <div id="dvIDonly" runat="server">
                    <asp:Accordion
                        ID="Accordion1"
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
                                                <asp:Label ID="Label4" runat="server" Text="RMA Number :" CssClass="lbl"></asp:Label>
                                            </td>
                                            <td class="tdLeft">
                                                <asp:TextBox CssClass="txt" ID="txtRMANumber" runat="server" AutoPostBack="true" OnTextChanged="txtRMANumber_TextChanged"></asp:TextBox>
                                                <asp:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server"
                                                    ServiceMethod="SearchRMANumber"
                                                    MinimumPrefixLength="1"
                                                    ServicePath="~/Forms/Web Forms/AutoCompleteService.aspx"
                                                    CompletionInterval="100"
                                                    EnableCaching="true"
                                                    CompletionSetCount="20"
                                                    TargetControlID="txtRMANumber">
                                                </asp:AutoCompleteExtender>
                                            </td>

                                            <td class="tdRight">
                                                <asp:Label ID="lblPONumber" runat="server" Text="PO Number :" CssClass="lbl"></asp:Label>
                                            </td>
                                            <td class="tdLeft">
                                                <asp:TextBox CssClass="txt" ID="txtPoNum" runat="server" AutoPostBack="true" OnTextChanged="txtPoNum_TextChanged"></asp:TextBox>
                                                <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server"
                                                    ServiceMethod="SearchOPnumber"
                                                    MinimumPrefixLength="1"
                                                    ServicePath="~/Forms/Web Forms/AutoCompleteService.aspx"
                                                    CompletionInterval="100"
                                                    EnableCaching="true"
                                                    CompletionSetCount="20"
                                                    TargetControlID="txtPoNum">
                                                </asp:AutoCompleteExtender>
                                            </td>
                                            <td class="tdRight">
                                                <asp:Label ID="Label2" runat="server" Text="ShipmentID :" CssClass="lbl"></asp:Label>
                                            </td>
                                            <td class="tdLeft">
                                                <asp:TextBox CssClass="txt" ID="txtShipmentID" runat="server" AutoPostBack="true" OnTextChanged="txtShipmentID_TextChanged"></asp:TextBox>
                                                <asp:AutoCompleteExtender ID="txtShipmentID_AutoCompleteExtender" runat="server"
                                                    ServiceMethod="SearchShipmentID"
                                                    MinimumPrefixLength="1"
                                                    ServicePath="~/Forms/Web Forms/AutoCompleteService.aspx"
                                                    CompletionInterval="100"
                                                    EnableCaching="true"
                                                    CompletionSetCount="20"
                                                    TargetControlID="txtShipmentID">
                                                </asp:AutoCompleteExtender>
                                            </td>
                                            <td class="tdRight">
                                                <asp:Label ID="lblOrderNum" runat="server" Text="Order Number :" CssClass="lbl"></asp:Label>
                                            </td>
                                            <td class="tdLeft">
                                                <asp:TextBox CssClass="txt" ID="txtOrderNumber" runat="server" AutoPostBack="true" OnTextChanged="txtOrderNumber_TextChanged"></asp:TextBox>
                                                <asp:AutoCompleteExtender ID="AutoCompleteExtender5" runat="server"
                                                    ServiceMethod="SearchOrderID"
                                                    MinimumPrefixLength="1"
                                                    ServicePath="~/Forms/Web Forms/AutoCompleteService.aspx"
                                                    CompletionInterval="100"
                                                    EnableCaching="true"
                                                    CompletionSetCount="20"
                                                    TargetControlID="txtOrderNumber">
                                                </asp:AutoCompleteExtender>
                                            </td>

                                            <td class="tdLeft" style="width: 10%; text-align: right;">
                                                <asp:Button ID="btnRefresh2" runat="server" Text="Reset" CssClass="btn" OnClick="btnRefresh2_Click" />
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
                                                    <asp:Label ID="lblUserName" runat="server" Text="Customer Name :" CssClass="lbl"></asp:Label>
                                                </td>
                                                <td class="tdLeft">
                                                    <asp:TextBox CssClass="txt" ID="txtCustomerName" runat="server" AutoPostBack="True" OnTextChanged="txtCustomerName_TextChanged"></asp:TextBox>
                                                </td>
                                                <td class="tdRight">
                                                    <asp:Label ID="Label1" runat="server" Text="Vendor Name :" CssClass="lbl"></asp:Label>
                                                </td>
                                                <td class="tdLeft">
                                                    <asp:TextBox CssClass="txt" ID="txtVendorName" runat="server" AutoPostBack="True" OnTextChanged="txtVendorName_TextChanged"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdRight">
                                                    <asp:Label ID="lblFromDate" runat="server" Text="From Date :" CssClass="lbl"></asp:Label>
                                                </td>
                                                <td class="tdLeft">
                                                    <asp:TextBox CssClass="txt" ID="dtpFromDate" runat="server" AutoPostBack="True"></asp:TextBox>
                                                    <asp:CalendarExtender ID="CalendarExtender1" TargetControlID="dtpFromDate" runat="server" Format="MMM dd, yyyy"></asp:CalendarExtender>
                                                </td>
                                                <td class="tdRight">
                                                    <asp:Label ID="lblTodate" runat="server" Text="To Date :" CssClass="lbl"></asp:Label>
                                                </td>
                                                <td class="tdLeft">
                                                    <asp:TextBox CssClass="txt" ID="dtpToDate" runat="server" AutoPostBack="True" OnTextChanged="dtpToDate_TextChanged"></asp:TextBox>
                                                    <asp:CalendarExtender ID="CalendarExtender2" TargetControlID="dtpToDate" runat="server" Format="MMM dd, yyyy"></asp:CalendarExtender>
                                                </td>
                                                <td class="tdRight">
                                                    <asp:Label ID="Label3" runat="server" Text="Vendor Number :" CssClass="lbl"></asp:Label>
                                                </td>
                                                <td class="tdLeft">
                                                    <asp:TextBox CssClass="txt" ID="txtVendorNumber" runat="server" AutoPostBack="True" OnTextChanged="txtVendorNumber_TextChanged"></asp:TextBox>
                                                </td>
                                                <td class="tdRight" colspan="2">
                                                    <asp:Button ID="btnExport" runat="server" Text="Export Manifest" CssClass="ExportExcel" OnClick="btnExport_Click" />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Button ID="btnRefresh" runat="server" Text="Reset" CssClass="btn" OnClick="btnRefresh2_Click" />
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
                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/Printer-icon.png" Width="25px" Height="25px" />
                <asp:Button ID="btnPrint" runat="server" Text="Print Selected" OnClick="btnPrint_Click1" />
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
                        SuppressHeaderPostbacks="true" Width="100%" Height="325px">
                        <Panes>
                            <asp:AccordionPane runat="server" ID="AccordionPane4"
                                HeaderCssClass="accordionHeader"
                                ContentCssClass="accordionContent">
                                <Header>
                                    &nbsp;∇∇&nbsp;Return information
                                </Header>
                                <Content>
                                    <div id="dvReturnInfo" style="height: 600px; overflow: scroll" onscroll="SetDivPosition()">
                                        <asp:Panel ID="panel2" runat="server" Height="600px">
                                            <asp:GridView ID="gvReturnInfo" runat="server" HorizontalAlign="Center" AutoGenerateColumns="False"
                                                BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2"
                                                ForeColor="Black" AllowSorting="true" AllowPaging="true" PageSize="20"
                                                OnSelectedIndexChanged="gvReturnInfo_SelectedIndexChanged" OnPageIndexChanging="gvReturnInfo_PageIndexChanging"
                                                OnSorting="gvReturnInfo_Sorting" SelectedIndex="0" OnRowDataBound="gvReturnInfo_RowDataBound"
                                                PagerSettings-LastPageText="Last" PagerSettings-FirstPageText="First" PagerSettings-NextPageText="Next" PagerSettings-PageButtonCount="20" PagerSettings-PreviousPageText="Previous">
                                                <Columns>
                                                    <asp:TemplateField HeaderStyle-Width="40px" ItemStyle-Width="50px">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkprint" runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-Width="25px" ItemStyle-Width="25px">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnPrint" runat="server" CommandName="Edit" Text="Print" OnClick="btnPrint_Click" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-Width="25px" ItemStyle-Width="25px">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" Text="Edit" OnClick="btnEdit_Click" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                   
                                                    <asp:TemplateField HeaderStyle-Width="25px" ItemStyle-Width="25px">
                                                        <ItemTemplate>
                                                            <asp:Image ID="imgFlag" ImageUrl="~/images/Red_flag.png" runat="server" />
                                                            <asp:Label ID="lblToProcess" runat="server" Visible="false" Text='<%# Eval("ProgressFlag") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                        <%--<asp:ImageField DataImageUrlField="Red_flag.png" HeaderText="Image"></asp:ImageField> --%>



                                                  <%--  <asp:BoundField HeaderText="In Process" DataField="ProgressFlag" SortExpression="ProgressFlag" HeaderStyle-Width="70px" ItemStyle-Width="70px" />--%>
                                                    <asp:TemplateField HeaderText="RGA Number" SortExpression="RGAROWID" HeaderStyle-Width="99px" ItemStyle-Width="100px">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lbtnRGANumberID" CommandName="Select" runat="server" Text='<%# Eval("RGAROWID") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="RMA Number" DataField="RMANumber" SortExpression="RMANumber" HeaderStyle-Width="200px" ItemStyle-Width="200px" />


                                                    <asp:BoundField HeaderText="PO Number" DataField="PONumber" SortExpression="PONumber" HeaderStyle-Width="75px" ItemStyle-Width="75px" />

                                                    <asp:BoundField HeaderText="RMA Status" DataField="RMAStatus" SortExpression="RMAStatus" HeaderStyle-Width="70px" ItemStyle-Width="70px" />
                                                    <asp:BoundField HeaderText="RMA Decision" DataField="Decision" SortExpression="Decision" HeaderStyle-Width="70px" ItemStyle-Width="70px" />

                                                    <asp:BoundField HeaderText="Partner Name" DataField="VendoeName" SortExpression="VendoeName" HeaderStyle-Width="150px" ItemStyle-Width="150px" />

                                                    <asp:BoundField HeaderText="Customer Name" DataField="CustomerName1" SortExpression="CustomerName" HeaderStyle-Width="170px" ItemStyle-Width="200px" />

                                                    <asp:BoundField HeaderText="Shipment Number" DataField="ShipmentNumber" SortExpression="ShipmentNumber" HeaderStyle-Width="70px" ItemStyle-Width="70px" />

                                                    <asp:BoundField HeaderText="Order Number" DataField="OrderNumber" SortExpression="OrderNumber" HeaderStyle-Width="70px" ItemStyle-Width="70px" />

                                                    <asp:BoundField HeaderText="Return Date" DataFormatString="{0:MMM dd, yyyy}" DataField="ReturnDate" SortExpression="ReturnDate" HeaderStyle-Width="100px" ItemStyle-Width="100px" />

                                                    <asp:BoundField HeaderText="Last UpdatedBy" DataField="UpdatedBy" SortExpression="UpdatedBy" HeaderStyle-Width="70px" ItemStyle-Width="70px" />










                                                </Columns>
                                                <RowStyle CssClass="gridRowStyleKey" />
                                                <FooterStyle BackColor="#CCCCCC" />
                                                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" CssClass="FixedHeader" Width="1310" />
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
            </td>
        </tr>
        <tr>
            <td>

                <div id="Div1" runat="server">
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
                        SuppressHeaderPostbacks="true" Width="100%" Style="margin-bottom: 0px">
                        <Panes>
                            <asp:AccordionPane runat="server" ID="AccordionPane3"
                                HeaderCssClass="accordionHeader"
                                ContentCssClass="accordionContent">
                                <Header>
                                    &nbsp;∇∇&nbsp;Return Detail information
                                </Header>
                                <Content>
                                    <div id="Div2" style="height: 200px; overflow: scroll" onscroll="SetDivPosition()">
                                        <asp:Panel ID="panel1" runat="server" Height="300px">
                                            <asp:GridView ID="gvReturnDetails" runat="server" HorizontalAlign="Center" AutoGenerateColumns="False"
                                                BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2"
                                                ForeColor="Black" AllowSorting="true"
                                                OnSelectedIndexChanged="gvReturnDetails_SelectedIndexChanged"
                                                OnSorting="gvReturnDetails_Sorting" SelectedIndex="0" HeaderStyle-CssClass="FixedHeader"
                                                OnRowDataBound="gvReturnDetails_RowDataBound">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Return Detail Number" SortExpression="RGADROWID" ItemStyle-Width="200px" HeaderStyle-Width="200px">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lbtnRmaDetailNumberID" CommandName="Select" runat="server" Text='<%# Eval("RGADROWID") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="SKU" DataField="SKUNumber" SortExpression="SKUNumber" HeaderStyle-Width="100px" ItemStyle-Width="100px" />
                                                    <asp:BoundField HeaderText="Product Name" DataField="ProductName" SortExpression="ProductName" HeaderStyle-Width="200px" ItemStyle-Width="200px" />
                                                    <asp:BoundField HeaderText="Delivered Quantity" DataField="DeliveredQty" SortExpression="DeliveredQty" HeaderStyle-Width="80px" ItemStyle-Width="80px" />
                                                    <asp:BoundField HeaderText="Return Quantity" DataField="ReturnQty" SortExpression="ReturnQty" HeaderStyle-Width="150px" ItemStyle-Width="150px" />
                                                    <asp:BoundField HeaderText="Product Return Reason" DataField="ReturnReasons" HeaderStyle-Width="520px" ItemStyle-Width="520px" />
                                                </Columns>
                                                <FooterStyle BackColor="#CCCCCC" />
                                                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" Width="1305px" />
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
            </td>
        </tr>
        <tr>
            <td>
                <div id="dvName" style="height: 30px; vertical-align: central; text-align: left;">
                    <asp:Label ID="lblImagesFor" runat="server" Text="" CssClass="accordionHeader" />
                </div>
                <div id="dvImages" runat="server" style="height: 170px; width: 100%; overflow: auto;">
                    <%--  <img runat="server" id="Img0"  src="#" class="ImageSize" />--%>
                    <input type="hidden" id="hiddenfield1" />
                    <table>
                        <tr>
                            <td>
                                <img runat="server" id="Img0" src="#" class="ImageSize" onclick="imageMethod(id)" /></td>
                            <td>
                                <img runat="server" id="Img1" src="#" class="ImageSize" onclick="imageMethod(id)" /></td>
                            <td>
                                <img runat="server" id="Img2" src="#" class="ImageSize" onclick="imageMethod(id)" /></td>
                            <td>
                                <img runat="server" id="Img3" src="#" class="ImageSize" onclick="imageMethod(id)" /></td>
                            <td>
                                <img runat="server" id="Img4" src="#" class="ImageSize" onclick="imageMethod(id)" /></td>
                            <td>
                                <img runat="server" id="Img5" src="#" class="ImageSize" onclick="imageMethod(id)" /></td>
                            <td>
                                <img runat="server" id="Img6" src="#" class="ImageSize" onclick="imageMethod(id)" /></td>
                            <td>
                                <img runat="server" id="Img7" src="#" class="ImageSize" onclick="imageMethod(id)" /></td>
                            <td>
                                <img runat="server" id="Img8" src="#" class="ImageSize" onclick="imageMethod(id)" /></td>

                        </tr>
                        <tr>
                            <td>
                                <img runat="server" id="Img9" src="#" class="ImageSize" onclick="imageMethod(id)" /></td>
                            <td>
                                <img runat="server" id="Img10" src="#" class="ImageSize" onclick="imageMethod(id)" /></td>
                        </tr>
                    </table>
                </div>



            </td>
        </tr>
    </table>

</asp:Content>
