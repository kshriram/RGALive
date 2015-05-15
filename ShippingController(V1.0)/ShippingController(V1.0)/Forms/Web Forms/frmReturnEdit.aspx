<%@ Page Language="C#" MasterPageFile="~/Forms/Master Forms/Admin.Master" AutoEventWireup="true" CodeBehind="frmReturnEdit.aspx.cs" Inherits="ShippingController_V1._0_.Forms.Web_Forms.frmReturnEdit" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
    <script type="text/javascript">
        function SelectItem(id) {
            var button = document.getElementById(id);
            button.click();
            // window.open(imagename, 'popUpWindow', 'scrollbars=no,width=900,height=900,toolbars=no');
        }



    </script>
     <style type="text/css">
         .hideGridColumn {
             display: none;
         }

         .linkbtn {
             text-decoration: none;
             border: 1px solid #000;
             color: whitesmoke;
         }
     </style>
    <style type="text/css">
        .modalBackground {
            background-color: Gray;
            filter: alpha(opacity=80);
            opacity: 0.8;
            z-index: 10000;
        }
    </style>
    <script>
        function demoDisplay()
        {
            document.getElementById("myP").style.display="none";
            $("#tblmg").empty();
        }
    </script>
    <style>
        button.image1 {
            background-image: url(Themes/Images/close.jpg);
            background-repeat: no-repeat;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div id="Border" style="width: 100%; float: none;  background-image:url(../../3.jpg)">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <script>
        function CheckOtherIsCheckedByGVID(RadioButton1) {
            var isChecked = RadioButton1.checked;
            var row = RadioButton1.parentNode.parentNode;
            if (isChecked) {
                row.style.backgroundColor = '#B6C4DE';
                row.style.color = 'black';
            }
            var currentRdbID = RadioButton1.id;
            parent = document.getElementById("<%= gvReturnDetails.ClientID %>");
            var items = parent.getElementsByTagName('input');

            for (i = 0; i < items.length; i++) {
                if (items[i].id != currentRdbID && items[i].type == "radio") {
                    if (items[i].checked) {
                        items[i].checked = false;
                        items[i].parentNode.parentNode.style.backgroundColor = 'white';
                        items[i].parentNode.parentNode.style.color = '#696969';
                    }
                }
            }
        }
    </script>
    <script language="javascript" type="text/javascript">
        function window.confirm(str)
        {
            execScript('n = msgbox("'+str+'","4132")', "vbscript");
            return(n == 6);
        }
    </script>



   <%-- <div style="width: 1350px; height: 850px">--%>

        <div style="width: 100%; height: 775px">

        <div style="margin: 0px 170px">
            <table style="width: 1250px;">
                <%--<tr>
                    <td style="height: 40px;">
                        <asp:LinkButton ID="lkbtnPath2" runat="server" Text="Return Details Edit" CssClass="link" Style="color: black" BorderColor="blue"></asp:LinkButton>
                    </td>
                </tr>--%>
                <tr>
                    <td class="TitleStrip">
                         <asp:UpdatePanel ID="updatePanel6" runat="server" UpdateMode="Always">
                                   <ContentTemplate>
                        &nbsp;&nbsp;&nbsp;
              
                <asp:Label ID="Label5" runat="server" Text="Last Modified By"></asp:Label>
                        &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp

                 <asp:Label ID="lblUserName" runat="server" Text="" Font-Bold="true" ForeColor="White"></asp:Label>

                        &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp

                 <asp:Label ID="lblLastTime" runat="server" Text="" Font-Bold="true" ForeColor="White"></asp:Label>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:Button ID="Button16" runat="server" Text="Print" OnClick="btnPrint_Click" CssClass="btnmaker" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="Button17" runat="server" Text="Reprint Label" CssClass="btnmaker" OnClick="btnReprint_Click" />
                        &nbsp&nbsp&nbsp
               <%--  <a href="mailto:customerservice@kraususa.com"> <asp:Button ID="Button2" runat="server" Text="Email" CssClass="btn"  /></a>--%> &nbsp&nbsp&nbsp&nbsp
                    <a href="mailto:Name@Domain.com" class="btn" style="display:none">Email</a>
                        <%--   <a href='mailto:name@domain.com?Subject=SubjTxt&Body=Bod_Txt&Attachment=""C:\file.txt"" '>--%>

                        <%-- <a href="mailto:customerservice@kraususa.com">customerservice@kraususa.com</a>--%>

                        <asp:Button ID="Button3" runat="server" Text="Cancel" CssClass="btnmaker" OnClick="btnCancelBox_Click" Style="margin-left: 10px;" />&nbsp&nbsp&nbsp&nbsp
                    <asp:Button ID="Button1" runat="server" Text="Save" CssClass="btnmaker" OnClick="btnConfirmBox_Click" />
                          </ContentTemplate>
                                   <Triggers>
                                       <asp:AsyncPostBackTrigger ControlID="Button1" />
                                       <asp:AsyncPostBackTrigger ControlID="Button3" />
                                        <asp:PostBackTrigger ControlID="Button17" />
                                         <asp:PostBackTrigger ControlID="Button16" />
                                   </Triggers>
                               </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>

                    <td style="width: 50%" align="center">
                        <asp:Label ID="lblMassege" runat="server" Text="" Font-Bold="True" Font-Size="20px" ForeColor="white"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <div class="border">
                            <asp:UpdatePanel ID="updatePanelbtnComment" runat="server" UpdateMode="Always">
                                <ContentTemplate>
                                    <table id="tblmain" runat="server" style="width: 100%; padding: 2px;" class="border">
                                        <tr>
                                            <td class="tdLeft">
                                                <asp:Label ID="lblRGAnumber" runat="server" Text="RGA Number " CssClass="lbl"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtrganumber" runat="server" ReadOnly="true" Enabled="false"></asp:TextBox>
                                            </td>
                                            <td class="tdLeft">
                                                <asp:Label ID="lblRMANumber" runat="server" Text="Vendor Number" CssClass="lbl"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtvendornumber" runat="server" ReadOnly="true" Enabled="false"></asp:TextBox>
                                            </td>
                                            <td class="auto-style1" colspan="2" Style="text-align:center;vertical-align:middle;">
                                                <asp:Label ID="lblcomments"  runat="server" Text="Comment" CssClass="lbl"></asp:Label>
                                            </td>
                                            <%--<td style="width:20%">
<asp:TextBox CssClass="txt" ID="TextBox3" runat="server" ReadOnly="true"></asp:TextBox>
</td>--%>
                                        </tr>
                                        <tr>
                                            <td class="tdLeft">
                                                <asp:Label ID="lblRMAstatus" runat="server" Text="PO Number" CssClass="lbl"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtponumber" runat="server"></asp:TextBox>
                                            </td>
                                            <td class="tdLeft">
                                                <asp:Label ID="lblshipment" runat="server" Text="Vendor Name" CssClass="lbl"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtvendorName" runat="server" ReadOnly="true" Enabled="false"></asp:TextBox>
                                            </td>
                                            <td rowspan="4" class="auto-style1" Style="text-align:center;vertical-align:middle;">
                                                <asp:TextBox ID="txtcomment" Style="margin-left: 30px; max-height:100px;min-height: 100px;max-width:200px;min-width:200px;" runat="server" TextMode="MultiLine" Height="80" Width="180px"></asp:TextBox>
                                            </td>
                                            <td rowspan="6" class="auto-style1" Style="text-align:left; vertical-align:middle;">
                                                <div style="width: 100%; overflow: auto; height: 180px; max-height:180px;min-height: 180px;max-width:200px;min-width:200px;border:ridge;border-color:black;border-radius:10px;">
                                                    <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">

                                                        <ItemTemplate>
                                                            <hr />

                                                            <div style="background-color: #3399FF">
                                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("UserName") %>'></asp:Label>
                                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("Time") %>'></asp:Label>
                                                            </div>

                                                            <div>
                                                                <%-- <asp:Literal ID="lit" runat="server" Text='<%# Eval("Content") %>' Mode="Transform" />--%>
                                                                <asp:Label ID="Label8" Style="color: red; background-color: transparent;" runat="server" Text='<%# Eval("Content") %>'></asp:Label>
                                                            </div>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblEmptyData"
                                                                        Text="No Comment To Display" runat="server" Visible="false" Font-Bold="True" ForeColor="Red">
                                                                    </asp:Label>
                                                                </td>
                                                            </tr>
                                                            </table>           
                                                        </FooterTemplate>
                                                    </asp:Repeater>
                                                </div>
                                            </td>


                                        </tr>
                                        <tr>
                                            <td class="tdLeft">
                                                <asp:Label ID="Label3" runat="server" Text="RMA Number" CssClass="lbl"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtRMAnumber" runat="server" ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <td class="tdLeft">
                                                <asp:Label ID="Label2" runat="server" Text="Customer Name" CssClass="lbl"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtcustomerName" runat="server" Enabled="false"></asp:TextBox>
                                            </td>

                                        </tr>
                                        <tr>
                                            <td class="tdLeft">
                                                <asp:Label ID="Label1" runat="server" Text="Shipment Number" CssClass="lbl"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtreturndate"></asp:CalendarExtender>
                                                <asp:TextBox ID="txtshipmentnumber" runat="server" Enabled="false"></asp:TextBox>
                                            </td>
                                            <td class="tdLeft">
                                                <asp:Label ID="lblorderdate" runat="server" Text="Address" CssClass="lbl"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCustomerAddress" runat="server" ReadOnly="true" Enabled="false"></asp:TextBox>
                                            </td>

                                        </tr>
                                        <tr>
                                            <td class="tdLeft">
                                                <asp:Label ID="lblCustomerName" runat="server" Text="Return Date" CssClass="lbl"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtreturndate" runat="server"></asp:TextBox>
                                            </td>
                                            <td class="tdLeft">
                                                <asp:Label ID="lblVendorname" runat="server" Text="City" CssClass="lbl"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCustomerCity" runat="server" ReadOnly="true" Enabled="false"></asp:TextBox>
                                            </td>

                                        </tr>
                                        <tr>
                                            <td class="tdLeft">
                                                <asp:Label ID="lblordernumber" runat="server" Text="RMA Status" CssClass="lbl"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlstatus" runat="server" Width="127px" AutoPostBack="True">
                                                    <asp:ListItem Value="0">Incomplete</asp:ListItem>
                                                    <asp:ListItem Value="1">Complete</asp:ListItem>
                                                    <asp:ListItem Value="2">Wrong RMA</asp:ListItem>
                                                    <asp:ListItem Value="3">To Process</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td class="tdLeft">
                                                <asp:Label ID="lblvendornumber" runat="server" Text="State" CssClass="lbl"></asp:Label>
                                                <br />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCustomerState" runat="server" ReadOnly="true" Enabled="false"></asp:TextBox>
                                            </td>
                                            <td class="auto-style1" Style="text-align:center;vertical-align:middle;">
                                                <asp:Button ID="btnComment" Style="margin-left: 50px;" runat="server" CssClass="btnmaker" Visible="true" Width="120" Text="Add Comment" OnClick="btnComment_Click" />
                                            </td>
                                            <%--<td style="width:10%">
<asp:TextBox CssClass="txt" ID="TextBox5" runat="server" ReadOnly="true" Enabled="false"></asp:TextBox>
</td>--%>
                                        </tr>
                                        <tr>
                                            <td class="tdLeft">
                                                <asp:Label ID="Label6" runat="server" Text="RMA Decision" CssClass="lbl"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddldecision" runat="server" Width="127px" AutoPostBack="True">
                                                    <asp:ListItem Value="0">Pending</asp:ListItem>
                                                    <asp:ListItem Value="1">Deny</asp:ListItem>
                                                    <asp:ListItem Value="2">Full Refund</asp:ListItem>
                                                    <asp:ListItem Value="3">Partial-Refund</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td class="tdLeft">
                                                <asp:Label ID="Label7" runat="server" Text="ZIP" CssClass="lbl"></asp:Label>
                                                <br />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCustomerZip" runat="server" ReadOnly="true" Enabled="false"></asp:TextBox>
                                            </td>

                                            <%--<td style="width:10%">
<asp:TextBox CssClass="txt" ID="TextBox5" runat="server" ReadOnly="true" Enabled="false"></asp:TextBox>
</td>--%>
                                        </tr>

                                        <tr>
                                            <td colspan="10" height="50">
                                                <asp:Label ID="Label4" runat="server" Text="Call tag" CssClass="lbl"></asp:Label>
                                                &nbsp&nbsp&nbsp&nbsp
                                <asp:TextBox ID="txtCalltag" runat="server" Width="1025px"></asp:TextBox>
                                                &nbsp&nbsp&nbsp&nbsp
                                <asp:CheckBox ID="chkflag" Text="Flag" Font-Bold="true" Font-Size="20" runat="server" ForeColor="Black" />
                                            </td>
                                            <%--<td colspan="3" >
                                <asp:Label ID="Label6" runat="server" Text="Comment" CssClass="lbl" ></asp:Label>
                                   &nbsp&nbsp&nbsp&nbsp
                                <asp:TextBox ID="txtcomment" runat="server" Width="300px"></asp:TextBox>
                                 &nbsp&nbsp&nbsp&nbsp
                                 <asp:Button ID="btnComment"  runat="server" Text="Add Comment" OnClick="btnComment_Click" />
                            &nbsp;
                                 <asp:Label ID="lblcomments" runat="server" Text="" Font-Size="10"></asp:Label>
                            </td>--%>
                                        </tr>


                                    </table>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnComment" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>

                    </td>

                </tr>
            </table>
        </div>

        <div>
            <table>
                <tr>
                    <td>

                    </td>
                </tr>
            </table>
        </div>

        <div style="margin: 0px 12px; width: 1555px;">

            <table style="width: 1250px;">
                <tr>
                    <td style="width: 700px; height: 330px">
                          <table style="width: 985px;">
                              <tr>
                                <td>
                                     <asp:Panel ID="Panel3" runat="server" DefaultButton="BtnAddNewItem">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Always">
                            <ContentTemplate>

                                <table style="width: 978px;">
                                     <tr>
                                                    <td class="TitleStripDetails">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Details &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                 <asp:Button ID="btnaddnew" runat="server" Text="Add new product" CssClass="btnmaker" OnClick="btnaddnew_Click" Width="135px" />
                                            &nbsp&nbsp&nbsp&nbsp&nbsp
                <asp:TextBox ID="txtNewItem" runat="server" Visible="false"></asp:TextBox>
                                                         <asp:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server"
                                                ServiceMethod="SearchSKUNumber"
                                                MinimumPrefixLength="1"
                                                ServicePath="~/Forms/Web Forms/AutoCompleteService.aspx"
                                                CompletionInterval="100"
                                                EnableCaching="true"
                                                CompletionSetCount="10"
                                                TargetControlID="txtNewItem">
                                            </asp:AutoCompleteExtender>


                                       &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp

                <asp:Button ID="BtnAddNewItem" runat="server" Text="Add" Visible="false" CssClass="btnmaker" OnClick="BtnAddNewItem_Click" />

                                    </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnaddnew" />
                                <asp:AsyncPostBackTrigger ControlID="btnAddNewItem" />
                            </Triggers>
                        </asp:UpdatePanel>
                                     </asp:Panel>
                          </td>
                            </tr>
                            <tr>
                                 <td>
                                 <table>
                                       <tr>
                                         <td></td>
                                                </tr>
                                                </table>
                                            </td>
                            </tr>
                            <tr>
                                <td style="width: 700px;">       
                              <div style="width: 976px;border:1px solid #084B8A;color:#ffffff;font-weight:bold;">
        <table bgcolor="black" rules="all">
            <tr>
                <%-- <td style ="width:30px;height:35px"></td>
               
                <td style ="width:185px; text-align:center">SKU'S</td>
               
                <td style ="width:35px; text-align:center">Qty</td>
                <td style ="width:75px; text-align:center">No of Images</td>
                  
                <td style ="width:245px; text-align:center">Uplaod Images(jpg/jpeg)</td>
                 <td style ="width:90px;height:35px; text-align:center">Remove SKU</td>--%>

               <td style ="width:42px;height:35px"></td>
               
                <td style ="width:248px; text-align:center">SKU'S</td>
               
                <td style ="width:38px; text-align:center">Qty</td>
                <td style ="width:83px; text-align:center">No of Images</td>
                  
                <td style ="width:308px; text-align:center">Uplaod Images(jpg/jpeg)</td>
                  <td style ="width:195px; text-align:center">Tracking Number</td>
                  <td style ="width:132px; text-align:center">Received Date</td>
                 <td style ="width:148px;height:35px; text-align:center">Remove SKU</td>
            </tr>
        </table>
                                       </div>
          
                   
                        <div class="border" id="Div2" style="height: 275px; width: 975px; overflow: scroll" onscroll="SetDivPosition()">
                                                        <asp:Panel ID="panel1" runat="server" >

                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                                    <asp:GridView ID="gvReturnDetails" Width="100%" ShowHeader="False" runat="server" HorizontalAlign="Center"  AutoGenerateColumns="False" 
                                                        BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" 
                                                        ForeColor="Black" AllowSorting="True" OnRowDeleting="gvReturnDetails_RowDeleting" OnSelectedIndexChanged="gvReturnDetails_SelectedIndexChanged">


                                            <Columns>
                                                <asp:TemplateField HeaderText="">
                                                    <ItemTemplate>

                                                        <asp:UpdatePanel ID="Updateforrdobutton" runat="server" UpdateMode="Always">
                                                            <ContentTemplate>

                                                                <%-- <asp:RadioButton ID="rdbselect" runat="server" OnCheckedChanged="RadioButton1_CheckedChanged" />--%>
                                                                <asp:RadioButton ID="RadioButton1" GroupName="test" AutoPostBack="true" OnCheckedChanged="RadioButton1_CheckedChanged" onclick="javascript:CheckOtherIsCheckedByGVID(this);"
                                                                    runat="server" />

                                                            </ContentTemplate>

                                                            <Triggers>
                                                                <asp:AsyncPostBackTrigger ControlID="RadioButton1" />
                                                            </Triggers>

                                                        </asp:UpdatePanel>

                                                    </ItemTemplate>
                                                    <ControlStyle Width="10px" />
                                                    <ItemStyle Width="10px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Return Detail Number" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:TextBox Enabled="false" ID="txtRGANumberID" runat="server" Text='<%# Eval("RGADROWID") %>' />
                                                    </ItemTemplate>
                                                    <ControlStyle Width="100px" />
                                                    <ItemStyle Width="100px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="SKU">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSKU" runat="server" Text='<%# Eval("SKUNumber") %>' OnTextChanged="txtSKU_TextChanged" AutoPostBack="True" Width="25"></asp:TextBox>
                                                        <asp:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server"
                                                            ServiceMethod="SearchSKUNumber"
                                                            MinimumPrefixLength="1"
                                                            ServicePath="~/Forms/Web Forms/AutoCompleteService.aspx"
                                                            CompletionInterval="100"
                                                            EnableCaching="true"
                                                            CompletionSetCount="10"
                                                            TargetControlID="txtSKU">
                                                        </asp:AutoCompleteExtender>
                                                    </ItemTemplate>
                                                    <ControlStyle Width="150px" />
                                                    <ItemStyle Width="180px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Qty" ItemStyle-Width="23px">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSKU_Qty_Seq" runat="server" Text='<%#Eval("SKU_Qty_Seq") %>'></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ControlStyle Width="20px" />
                                                    <ItemStyle Width="20px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Status" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSKU_Status" runat="server" Enabled="false" Text='<%#Eval("SKU_Status") %>'></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ControlStyle Width="100px" />
                                                    <ItemStyle Width="100px" />
                                                </asp:TemplateField>


                                                <asp:TemplateField HeaderText="ProductID" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtProductID" runat="server" Enabled="false" Text='<%#Eval("ProductID") %>'></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ControlStyle Width="100px" />
                                                    <ItemStyle Width="100px" />
                                                </asp:TemplateField>


                                                <asp:TemplateField HeaderText="SKU Sequence" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSKU_Sequence" runat="server" Text='<%#Eval("SKU_Sequence") %>' Enabled="false"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ControlStyle Width="100px" />
                                                    <ItemStyle Width="100px" />
                                                </asp:TemplateField>
                                                <%-- <asp:TemplateField HeaderText="ProductID">
<ItemTemplate>
<asp:TextBox ID="txtProductID" runat="server" Text='<%#Eval("ProductID") %>'></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>--%>
                                                <asp:TemplateField HeaderText="Sales Price" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSalesPrice" runat="server" Text='<%#Eval("SalesPrice") %>'></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ControlStyle Width="70px" />
                                                    <ItemStyle Width="70px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="No. of images">
                                                    <ItemTemplate>
                                                        <%--  <asp:UpdatePanel ID="updtForImages" runat="server" UpdateMode="Always">
                                                        <ContentTemplate>--%>
                                                        <asp:LinkButton ID="txtImageCount" runat="server" Text='<%#Eval("NoofImages") %>' OnClick="txtImageCount_Click"></asp:LinkButton>
                                                        <%--  <asp:LinkButton ID="lnkDownload" Text = "Download" runat="server" OnClick = "lnkDownload_Click1"></asp:LinkButton>--%>
                                                        <%--</ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="txtImageCount" />
                                                            <asp:AsyncPostBackTrigger ControlID="lnkDownload" />
                                                        </Triggers>
                                                        </asp:UpdatePanel>--%>
                                                    </ItemTemplate>
                                                    <ControlStyle Width="70px" />
                                                    <ItemStyle Width="70px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Upload Images(jpg/jpeg)">
                                                    <ItemTemplate>
                                                        <asp:FileUpload ID="FileUpload1" runat="server" OnLoad="FileUpload1_Load" AllowMultiple="true" />
                                                        <asp:Button ID="btnUpdate" runat="server" Text="Upload Image" OnClick="btnUpdate_Click1"    />
                                                      
                                                        <div style="width: 10%; height: 50%">
                                                            <asp:Label ID="lblImagesName" runat="server" Height="50%" Width="10%" ForeColor="Red" Text='<%# Eval("ImageName") %>' Visible="false" />
                                                        </div>
                                                    </ItemTemplate>
                                                    <ControlStyle Width="240px" />
                                                    <ItemStyle Width="240px" />
                                                </asp:TemplateField>                                               
                                                <asp:TemplateField HeaderText="LT" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtLineType" Enabled="false" runat="server" Text='<%#Eval("LineType") %>'></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ControlStyle Width="100px" />
                                                    <ItemStyle Width="100px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="SL" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtShipmentLines" runat="server" Enabled="false" Text='<%#Eval("ShipmentLines") %>'></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ControlStyle Width="100px" />
                                                    <ItemStyle Width="100px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="RL" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtReturnLines" Enabled="false" runat="server" Text='<%#Eval("ReturnLines") %>'></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ControlStyle Width="100px" />
                                                    <ItemStyle Width="100px" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Guid" Visible="false">
                                                    <ItemTemplate>
                                                        <%--<asp:TextBox ID="txtReturnLines" runat="server" Text='<%#Eval("ReturnLines") %>'></asp:TextBox>--%>
                                                        <asp:Label ID="lblguid" Enabled="false" runat="server" Text='<%#Eval("ReturnDetailID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ControlStyle Width="100px" />
                                                    <ItemStyle Width="100px" />
                                                </asp:TemplateField>

                                                   <asp:TemplateField HeaderText="Tracking Number" Visible="true">
                                                                <ItemTemplate>
                                                                    <asp:Panel ID="Panel1" runat="server" DefaultButton="SubmitButton">
                                                                             <asp:TextBox ID="txtTrackingNumber" runat="server"  Width="140px" Text='<%#Eval("TrackingNumber") %>' Enabled="false" ></asp:TextBox>
                                                                         <asp:UpdatePanel ID="UpdatePanel32" runat="server" UpdateMode="Always">
                                                                        <contenttemplate>
                                                                            <asp:Button ID="SubmitButton" runat="server" Text="Submit" OnClick="SubmitButton_Click" Enabled="false"/>
                                                                              </contenttemplate>
                                                                        <triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="SubmitButton" />
                                                  
                                                </triggers>
                                                                                    </asp:UpdatePanel>
                                                                    </asp:Panel>                                                                  
                                                                </ItemTemplate>
                                                                <ControlStyle Width="145px" />
                                                                <ItemStyle Width="145px" />
                                                            </asp:TemplateField>                                                           
                                                          
                                                            <asp:TemplateField HeaderText="Received Date" Visible="true">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtReceivedDate" runat="server" Text='<%#Eval("ReceivedDate") %>' Enabled="false"></asp:TextBox>
                                                                </ItemTemplate>
                                                                <ControlStyle Width="100px" />
                                                                <ItemStyle Width="100px" />
                                                            </asp:TemplateField>            
                                                           

                                                <%-- <asp:TemplateField HeaderText="Product Return Reasons">
<ItemTemplate>
<asp:LinkButton ID="txtreasons" runat="server" Text="[ Edit Reasons]" OnClick="txtreasons_Click"></asp:LinkButton>
</ItemTemplate>                                  
</asp:TemplateField>--%>                      <asp:TemplateField>

                                                         <ItemTemplate>

                                           

                              <span onclick="return confirm('Are you sure want to delete?')">


                         <asp:LinkButton ID="btnDelete" Text="Remove SKU" runat="server" Height="20px" ForeColor="white" Font-Underline="false" BorderStyle="Groove" BackColor="#5998ff" OnClick="btnDelete_Click" CommandName="Delete"/>
                                                             
                       </span>

                                </ItemTemplate>
                         </asp:TemplateField>
                                                 <%--<asp:TemplateField HeaderText="Tracking" Visible="true">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtTrakingNum" runat="server"  Text='<%#Eval("TrackingNumber") %>' ></asp:TextBox>
                                                                </ItemTemplate>
                                                                <ControlStyle Width="100px" />
                                                                <ItemStyle Width="100px" />
                                                            </asp:TemplateField>--%>
                                                                    
                                           <%--    <asp:CommandField ShowDeleteButton="True" ButtonType="Button"/> --%>
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

                                    </ContentTemplate>
                                    <Triggers>

                                        <%-- <asp:AsyncPostBackTrigger ControlID = "btnAsyncUpload"

          EventName = "Click" />--%>

                                        <asp:PostBackTrigger ControlID="gvReturnDetails" />

                                    </Triggers>
                                </asp:UpdatePanel>
                            </asp:Panel>



                        </div>
                      
                                </td>
                            </tr>
                        </table>

                    </td>
                    <td style="width: 550px">
                        <table style="width: 550px;">
                            <tr>
                                <td class="TitleStripProduct" style="text-align: center; vertical-align: middle;">
                                    <span>Product Decisions:
                                   </span>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                             </td>
                            </tr>
                        </table>


                      



                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
                            <ContentTemplate>
                                <%-- <asp:Label ID="Label8" runat="server" Text="Product Decision " Font-Bold="True" Font-Size="14px" ForeColor="Black" CssClass="product"></asp:Label>--%>


                                <table id="Table1" class="border" style="width: 100%" runat="server" name="tblm">
                                    <tr>
                                        <td colspan="5">
                                            <table style="width: 100%">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblitemNew" Text="Item is New" runat="server" CssClass="lbl" />
                                                    </td>
                                                    <td style="width: 30%">
                                                        <%--<asp:CheckBox ID="chkitemordered" Text="Incorrect item ordered." runat="server" CssClass="lbl" />--%>

                                                        <asp:RadioButtonList ID="brdItemNew" runat="server" RepeatDirection="Horizontal" CssClass="lbl" Width="300px" AutoPostBack="true" OnSelectedIndexChanged="brdItemNew_SelectedIndexChanged">
                                                            <asp:ListItem>Yes</asp:ListItem>
                                                            <asp:ListItem>No</asp:ListItem>
                                                        </asp:RadioButtonList>

                                                    </td>
                                                    <%--<td style="width:30%">
                            <asp:CheckBox ID="chkwrongitem" Text="Received wrong item." runat="server" CssClass="lbl"/>
                        </td>--%>
                                                </tr>

                                            </table>

                                        </td>

                                    </tr>
                                    <tr>
                                        <td colspan="5">
                                            <table style="width: 100%">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblInstalled" Text="Installed" runat="server" CssClass="lbl" />
                                                    </td>
                                                    <td style="width: 30%">
                                                        <%--<asp:CheckBox ID="CheckBox1" Text="Incorrect item ordered." runat="server" CssClass="lbl" />--%>
                                                        <asp:RadioButtonList ID="brdInstalled" runat="server" RepeatDirection="Horizontal" Width="300px" CssClass="lbl" AutoPostBack="true" OnSelectedIndexChanged="brdInstalled_SelectedIndexChanged">
                                                            <asp:ListItem>Yes</asp:ListItem>
                                                            <asp:ListItem>No</asp:ListItem>
                                                        </asp:RadioButtonList>

                                                    </td>
                                                    <%--   <td style="width:30%">
                            <asp:CheckBox ID="CheckBox2" Text="Received wrong item." runat="server" CssClass="lbl"/>
                        </td>--%>
                                                </tr>

                                            </table>

                                        </td>

                                    </tr>
                                    <tr>
                                        <td colspan="5">
                                            <table style="width: 100%">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblstatus" Text="Chip/Bended/Scratch/Broken" runat="server" CssClass="lbl" />
                                                    </td>
                                                    <td style="width: 30%">
                                                        <%--<asp:CheckBox ID="CheckBox3" Text="Incorrect item ordered." runat="server" CssClass="lbl" />--%>

                                                        <asp:RadioButtonList ID="brdstatus" runat="server" RepeatDirection="Horizontal" Width="300px" CssClass="lbl" AutoPostBack="true" OnSelectedIndexChanged="brdstatus_SelectedIndexChanged">
                                                            <asp:ListItem>Yes</asp:ListItem>
                                                            <asp:ListItem>No</asp:ListItem>
                                                        </asp:RadioButtonList>

                                                    </td>
                                                    <%-- <td style="width:30%">
                           <asp:CheckBox ID="CheckBox4" Text="Received wrong item." runat="server" CssClass="lbl"/>
                        </td>--%>
                                                </tr>

                                            </table>

                                        </td>

                                    </tr>
                                    <tr>
                                        <td colspan="5">
                                            <table style="width: 100%">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblManifacturerDefective" Text="Manufacturer Defective" runat="server" CssClass="lbl" />
                                                    </td>
                                                    <td style="width: 30%">
                                                        <%-- <asp:CheckBox ID="CheckBox5" Text="Incorrect item ordered." runat="server" CssClass="lbl" />--%>
                                                        <asp:RadioButtonList ID="brdManufacturer" runat="server" RepeatDirection="Horizontal" Width="300px" CssClass="lbl" AutoPostBack="true" OnSelectedIndexChanged="brdManufacturer_SelectedIndexChanged">
                                                            <asp:ListItem>Yes</asp:ListItem>
                                                            <asp:ListItem>No</asp:ListItem>
                                                        </asp:RadioButtonList>


                                                    </td>
                                                    <%--  <td style="width:30%">
                            <asp:CheckBox ID="CheckBox6" Text="Received wrong item." runat="server" CssClass="lbl"/>
                        </td>--%>
                                                </tr>

                                            </table>

                                        </td>

                                    </tr>
                                    <tr>
                                        <td colspan="5">
                                            <table style="width: 100%">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblDefectintransite" Text="Defect in Transit" runat="server" CssClass="lbl" />
                                                    </td>
                                                    <td style="width: 30%">
                                                        <%--<asp:CheckBox ID="chkduplicate" Text="Duplicate Shipment." runat="server" CssClass="lbl"/>--%>
                                                        <asp:RadioButtonList ID="brdDefecttransite" runat="server" RepeatDirection="Horizontal" Width="300px" CssClass="lbl" AutoPostBack="true" OnSelectedIndexChanged="brdDefecttransite_SelectedIndexChanged">
                                                            <asp:ListItem>Yes</asp:ListItem>
                                                            <asp:ListItem>No</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>

                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="vertical-align: middle; text-align: center;">
                                            <asp:Label ID="lblotherreasons" runat="server" Text="-----------------------------------Enter Other Reasons:-----------------------------------" CssClass="lbl"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="vertical-align: middle; text-align: center;">
                                            <asp:DropDownList ID="ddlotherreasons" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlotherreasons_SelectedIndexChanged"></asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="vertical-align: middle; text-align: center;">
                                            <asp:Label ID="lblReasonMessaage" runat="server" ForeColor="Red" Text="If you did not found any appropriate reason then enter your reason in below textbox."></asp:Label>
                                        </td>
                                    </tr>

                                    <%--  <tr>
                                    <td>
                                        <asp:Label ID="lblotherreasons" runat="server" Text="Enter Other Reasons  :" CssClass="lbl"></asp:Label>
                                    </td>

                                </tr>--%>
                                    <tr>
                                        <td style="vertical-align: middle; text-align: center;">
                                            <asp:TextBox ID="txtotherreasons" runat="server" Width="242px"></asp:TextBox>


                                            <%-- <asp:DropDownList ID="ddlotherreasons" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlotherreasons_SelectedIndexChanged"></asp:DropDownList>--%>
                                        </td>
                                    </tr>

                                    <tr>

                                        <td style="width: 109%" align="center">
                                            <%-- <asp:Label ID="Label5" Text="Defect in Transite." runat="server" CssClass="lbl"/>--%>

                                            <%--<asp:CheckBox ID="chkduplicate" Text="Duplicate Shipment." runat="server" CssClass="lbl"/>--%>
                                            <%-- <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" Width="300px">
                                <asp:ListItem>Yes</asp:ListItem>
                                <asp:ListItem>No</asp:ListItem>
                            </asp:RadioButtonList>--%>


                                            <asp:UpdateProgress ID="uprupnlSubmit" AssociatedUpdatePanelID="upnlSubmit" runat="server">
                                                <ProgressTemplate>
                                                    <div id="imageDivSubmit" align="center" valign="middle" runat="server" style="position: absolute; visibility: visible; vertical-align: middle; border-style: none; border-color: black; background-color: transparent;">
                                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Themes/Images/loading83.gif" Width="120px" Height="32px" />Loading... 
                                                    </div>
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>

                                            <asp:UpdatePanel runat="server" ID="upnlSubmit">
                                                <ContentTemplate>

                                                    <asp:Button ID="btnsubmit" runat="server" Text="Submit" CssClass="btnmaker" OnClick="btnsubmit_Click" Enabled="false" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>

                                        </td>

                                    </tr>
                                    
                                   <%-- </table>
                                    </td>
                                    </tr>--%>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
            <div>
                <table>
                    <tr>
                        <td style="height:10px;">

                        </td>                       
                    </tr>
                   
                </table>
            </div>
            <div style="height: 50px;" align="center">


                  <asp:UpdatePanel ID="updatePanel5" runat="server" UpdateMode="Always">
                                   <ContentTemplate>

                <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="btnmaker" OnClick="btnPrint_Click" />
                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                        <asp:Button ID="btnReprint" runat="server" Text="Reprint Label" CssClass="btnmaker" OnClick="btnReprint_Click" />
                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                    <asp:Button ID="btnEmail" runat="server" Text="Email" CssClass="btnmaker" OnClick="btnEmail_Click" Visible="false" />

                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                                                
                                    <asp:Button ID="btnCancle" runat="server" Text="Cancel" CssClass="btnmaker" OnClick="btnCancelBox_Click" />
                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp

                             
                                    <asp:Button ID="btnupdate" runat="server" Text="Save" CssClass="btnmaker" OnClick="btnConfirmBox_Click" />

                  </ContentTemplate>
                                   <Triggers>
                                       <asp:AsyncPostBackTrigger ControlID="btnupdate" />
                                          <asp:AsyncPostBackTrigger ControlID="btnCancle" />
                                        <asp:AsyncPostBackTrigger ControlID="btnEmail" />
                                          <asp:PostBackTrigger ControlID="btnReprint" />
                                       <asp:PostBackTrigger ControlID="btnPrint" />
                                   </Triggers>
                               </asp:UpdatePanel>


            </div>


        </div>




        <%--    <div style="height: 50px; margin-top: 5px; width: 1500px" align="center">


          

            <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="btn" OnClick="btnPrint_Click" />
            &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                        <asp:Button ID="btnReprint" runat="server" Text="Reprint Label" CssClass="btn" OnClick="btnReprint_Click" />
            &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                    <asp:Button ID="btnEmail" runat="server" Text="Email" CssClass="btn" OnClick="btnEmail_Click" />
          
            &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                                                
                                    <asp:Button ID="btnCancle" runat="server" Text="Cancel" CssClass="btn" OnClientClick="javascript:return confirm('You want to exit without saving the records');" OnClick="btnOk_Click" />
            &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp

                             
                                    <asp:Button ID="btnupdate" runat="server" Text="Save" CssClass="btn" OnClick="btnupdate_Click" />


        </div>--%>










        <asp:Button ID="btnShowPopup" runat="server" Style="display: none" />
        <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnShowPopup" PopupControlID="pnlpopup"
            BackgroundCssClass="modalBackground">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlpopup" runat="server" BackColor="White" Height="142px" Width="400px" Style="display: none">
            <table width="100%" style="border: Solid 4px #4d8ed1; background-color: white; width: 100%; height: 100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="height: 10%; color: #4d8ed1; font-weight: bold; padding: 3px; font-size: larger; font-family: Calibri" align="Left">Confirm Box</td>
                    <td style="color: #4d8ed1; font-weight: bold; padding: 3px; font-size: larger" align="Right">
                        <%-- <a href="javascript:void(0)" onclick="closepopup()">
                            <img src="../../images/close.jpg" style="border: 0px" align="right" /></a>--%>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="left" style="padding: 5px; font-family: Calibri; background-color: #4d8ed1;">
                        <asp:Label ID="lblUser" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td></td>
                    <td align="right" style="padding-right: 15px" backcolor="White">
                        <%-- <asp:LinkButton ID="lnkSaveCont" runat="server" Font-Bold="True" Font-Size="15px" PostBackUrl="~/Forms/Web Forms/frmReturnEdit.aspx">Save&Continue</asp:LinkButton>
                        &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp--%>
                        <%-- <asp:LinkButton ID="lnkSaveex" runat="server" PostBackUrl="~/Forms/Web Forms/DemoGrid.aspx" Font-Bold="True" Font-Size="15px" Style="color: #4d8ed1;">Save & Exit</asp:LinkButton> --%>
                         <asp:LinkButton ID="lnkSaveex" runat="server" PostBackUrl="~/Forms/Web Forms/DemoGrid.aspx" Font-Bold="True" Font-Size="15px" Style="color: #4d8ed1;">Ok</asp:LinkButton>
                        <%--<a id="lnkSaveExt" href="frmRetunDetail.aspx" style="font-size: 15px; text-decoration: underline; color: #0000FF">Save&Exit </a>--%>
                    </td>
                </tr>
            </table>
        </asp:Panel>


        <asp:Button ID="Button4" runat="server" Text="Button" Style="display: none" />
        <asp:Panel ID="pnlPopupForAddYes" runat="server" CssClass="modalPopup" Style="display: none">
            <div class="header">
                Message Box
            </div>
            <div class="body" style="color: red">
                <asp:Label ID="lblPopUpForAddYes" runat="server" Text="SKU is Added successfully."></asp:Label>
            </div>
            <div class="footer" align="center">
                <asp:Button ID="btnOkForAddYes" runat="server" Text="Ok" />
            </div>
        </asp:Panel>
        <cc1:ModalPopupExtender ID="mpePopupForAddYes" runat="server" BackgroundCssClass="modalBackground" PopupControlID="pnlPopupForAddYes"
            Enabled="True" TargetControlID="Button4" OkControlID="btnOkForAddYes">
        </cc1:ModalPopupExtender>


        <asp:Button ID="Button5" runat="server" Text="Button" Style="display: none" />
        <asp:Panel ID="pnlPopupForAddNo" runat="server" CssClass="modalPopup" Style="display: none">
            <div class="header">
                Message Box
            </div>
            <div class="body" style="color: red">
                <asp:Label ID="lblPopupForAddNo" runat="server" Text="SKU is Not Added. Please Click Add Button after selecting proper SKU from Add New Product textfield."></asp:Label>
            </div>
            <div class="footer" align="center">
                <asp:Button ID="btnOkForAddNo" runat="server" Text="Ok" />
            </div>
        </asp:Panel>
        <cc1:ModalPopupExtender ID="mpePopupForAddNo" runat="server" BackgroundCssClass="modalBackground" PopupControlID="pnlPopupForAddNo"
            Enabled="True" TargetControlID="Button5" OkControlID="btnOkForAddNo">
        </cc1:ModalPopupExtender>


        <asp:Button ID="Button6" runat="server" Text="Button" Style="display: none" />
        <asp:Panel ID="pnlPopupForCommentYes" runat="server" CssClass="modalPopup" Style="display: none">
            <div class="header">
                Message Box
            </div>
            <div class="body" style="color: red">
                <asp:Label ID="lblPopupForCommentYes" runat="server" Text="Comment Added successfully. Go Ahead."></asp:Label>
            </div>
            <div class="footer" align="center">
                <asp:Button ID="btnOkForCommentYes" runat="server" Text="Ok" />
            </div>
        </asp:Panel>
        <cc1:ModalPopupExtender ID="mpePopupForCommentYes" runat="server" BackgroundCssClass="modalBackground" PopupControlID="pnlPopupForCommentYes"
            Enabled="True" TargetControlID="Button6" OkControlID="btnOkForCommentYes">
        </cc1:ModalPopupExtender>


        <asp:Button ID="Button7" runat="server" Text="Button" Style="display: none" />
        <asp:Panel ID="pnlPopupForImageYes" runat="server" CssClass="modalPopup" Style="display: none">
            <div class="header">
                Message Box
            </div>
            <div class="body" style="color: red">
                <asp:Label ID="lblPopupForImageYes" runat="server" Text="Image is Uploaded successfully. "></asp:Label>
            </div>
            <div class="footer" align="center">
                <asp:Button ID="btnOkForImageYes" runat="server" Text="Ok" />
            </div>
        </asp:Panel>
        <cc1:ModalPopupExtender ID="mpePopupForImageYes" runat="server" BackgroundCssClass="modalBackground" PopupControlID="pnlPopupForImageYes"
            Enabled="True" TargetControlID="Button7" OkControlID="btnOkForImageYes">
        </cc1:ModalPopupExtender>


        <asp:Button ID="Button8" runat="server" Text="Button" Style="display: none" />
        <asp:Panel ID="pnlPopupForImageNo" runat="server" CssClass="modalPopup" Style="display: none">
            <div class="header">
                Message Box
            </div>
            <div class="body" style="color: red">
                <asp:Label ID="lblPopupForImageNo" runat="server" Text="SKU Not Added. Please Try Again!!!!!!"></asp:Label>
            </div>
            <div class="footer" align="center">
                <asp:Button ID="btnOkForImageNo" runat="server" Text="Ok" />
            </div>
        </asp:Panel>
        <cc1:ModalPopupExtender ID="mpePopupForImageNo" runat="server" BackgroundCssClass="modalBackground" PopupControlID="pnlPopupForImageNo"
            Enabled="True" TargetControlID="Button8" OkControlID="btnOkForImageNo">
        </cc1:ModalPopupExtender>


        <asp:Button ID="Button9" runat="server" Text="Button" Style="display: none" />
        <asp:Panel ID="pnlPopupForSubmitYes" runat="server" CssClass="modalPopup" Style="display: none">
            <div class="header">
                Message Box
            </div>
            <div class="body" style="color: red">
                <asp:Label ID="lblPopupForSubmitYes" runat="server" Text="Your Information is Submitted successfully. After all changes are done Please Click Save Button to See Your Information."></asp:Label>
            </div>
            <div class="footer" align="center">
                <asp:Button ID="btnOkForSubmitYes" runat="server" Text="Ok" />
            </div>
        </asp:Panel>
        <cc1:ModalPopupExtender ID="mpePopupForSubmitYes" runat="server" BackgroundCssClass="modalBackground" PopupControlID="pnlPopupForSubmitYes"
            Enabled="True" TargetControlID="Button9" OkControlID="btnOkForSubmitYes">
        </cc1:ModalPopupExtender>


        <asp:Button ID="Button10" runat="server" Text="Button" Style="display: none" />
        <asp:Panel ID="pnlPopupForSubmitNo" runat="server" CssClass="modalPopup" Style="display: none">
            <div class="header">
                Message Box
            </div>
            <div class="body" style="color: red">
                <asp:Label ID="lblPopupForSubmitNo" runat="server" Text="SKU Not Added. Please Try Again!!!!!!"></asp:Label>
            </div>
            <div class="footer" align="center">
                <asp:Button ID="btnOkForSubmitNo" runat="server" Text="Ok" />
            </div>
        </asp:Panel>
        <cc1:ModalPopupExtender ID="mpePopupForSubmitNo" runat="server" BackgroundCssClass="modalBackground" PopupControlID="pnlPopupForSubmitNo"
            Enabled="True" TargetControlID="Button10" OkControlID="btnOkForSubmitNo">
        </cc1:ModalPopupExtender>


        <asp:Button ID="Button11" runat="server" Text="Button" Style="display: none" />
        <asp:Panel ID="pnlPopupForSaveYes" runat="server" CssClass="modalPopup" Style="display: none">
            <div class="header">
                Message Box
            </div>
            <div class="body" style="color: red">
                <asp:Label ID="lblPopupForSaveYes" runat="server" Text="Your Information is Saved successfully. Please Click Ok to See Your Information."></asp:Label>
            </div>
            <div class="footer" align="center">
                <asp:Button ID="btnOkForSaveYes" runat="server" Text="Ok" OnClick="btnOkForSaveYes_Click" />
            </div>
        </asp:Panel>
        <cc1:ModalPopupExtender ID="mpePopupForSaveYes" runat="server" BackgroundCssClass="modalBackground" PopupControlID="pnlPopupForSaveYes"
            Enabled="True" TargetControlID="Button11">
        </cc1:ModalPopupExtender>


      <%--  <asp:Button ID="Button12" runat="server" Text="Button" Style="display: none" />
        <asp:Panel ID="pnlPopupForSaveNo" runat="server" CssClass="modalPopup" Style="display: none">
            <div class="header">
                Message Box
            </div>
            <div class="body" style="color: red">
                <asp:Label ID="lblPopupForSaveNo" runat="server" Text="SKU Not Added. Please Try Again!!!!!!"></asp:Label>
            </div>
            <div class="footer" align="center">
                <asp:Button ID="btnOkForSaveNo" runat="server" Text="Ok" />
            </div>
        </asp:Panel>
        <cc1:ModalPopupExtender ID="mpePopupForSaveNo" runat="server" BackgroundCssClass="modalBackground" PopupControlID="pnlPopupForSaveNo"
            Enabled="True" TargetControlID="Button12" OkControlID="btnOkForSaveNo">
        </cc1:ModalPopupExtender>--%>


              <asp:Button ID="Button52" runat="server" Text="Button" Style="display: none" />
        <asp:Panel ID="pnlPopupForSaveNo" runat="server" CssClass="modalPopup" Style="display: none; width:auto">
            <div class="header">
                Message Box
            </div>
            <div class="body" style="color: red">
                <asp:Label ID="lblPopupForSaveNo" runat="server" Text="Select any one of the following option."></asp:Label>
            </div>
            <div class="footer" align="center">
                 <asp:Button ID="btnOkForSaveYe" runat="server" Text="Add SKU'S from PO" OnClick="btnOkForSaveYe_Click" />
                <asp:Button ID="btnOkForSaveN" runat="server" Text="Add other SKU'S" OnClick="btnOkForSaveN_Click" />
                 <asp:Button ID="btnOkForCancelAdd" runat="server" Text="Cancel" />
            </div>
        </asp:Panel>
        <cc1:ModalPopupExtender ID="mpePopupForSaveNo" runat="server" BackgroundCssClass="modalBackground" PopupControlID="pnlPopupForSaveNo"
            Enabled="True" TargetControlID="Button52" CancelControlID="btnOkForCancelAdd" >
        </cc1:ModalPopupExtender>


        <asp:Button ID="Button13" runat="server" Text="Button" Style="display: none" />
        <asp:Panel ID="pnlForCancel" runat="server" CssClass="modalPopup" Style="display: none">
            <div class="header">
                Enter PO Number
            </div>
            <div class="body" style="color: red">
                <asp:Label ID="lblForCancel" runat="server" Text="SKU Not Added. Please Try Again!!!!!!"></asp:Label>
            </div>
            <div class="footer" align="center">
                <asp:Button ID="btnYesForCancel" runat="server" Text="Yes" />
                <%--<asp:Button ID="btnNoPO" runat="server" Text="No" OnClick="btnNoPO" />--%>
                <asp:Button ID="btnNoForCancel" runat="server" Text="No" />
            </div>
        </asp:Panel>
        <cc1:ModalPopupExtender ID="mpeForCancel" runat="server" BackgroundCssClass="modalBackground" PopupControlID="pnlForCancel"
            Enabled="True" TargetControlID="Button13" CancelControlID="btnNoForCancel">
        </cc1:ModalPopupExtender>


        <asp:Button ID="Button14" runat="server" Text="Button" Style="display: none" />
        <asp:Panel ID="pnlForLineType" runat="server" CssClass="modalPopup" Style="display: none">
            <div class="header">
                Message Box
            </div>
            <div class="body" style="color: red">
                <asp:Label ID="lblForLineType" runat="server" Text="Can not add comment/parent sku for combination item."></asp:Label>
            </div>
            <div class="footer" align="center">
                <asp:Button ID="btnOkForLineType" runat="server" Text="Ok" />
            </div>
        </asp:Panel>
        <cc1:ModalPopupExtender ID="mpeForLineType" runat="server" BackgroundCssClass="modalBackground" PopupControlID="pnlForLineType"
            Enabled="True" TargetControlID="Button14" OkControlID="btnOkForLineType">
        </cc1:ModalPopupExtender>



              <asp:Button ID="Button41" runat="server" Text="Button" Style="display: none" />
        <asp:Panel ID="pnlConfirmBox" runat="server" CssClass="modalPopup" Style="display: none">
            <div class="header">
                Message Box
            </div>
            <div class="body" style="color: red">
                <asp:Label ID="lblPopUpForConfirmBox" runat="server" Text="Are you sure you want to save the Details."></asp:Label>
            </div>
            <div class="footer" align="center">
                 <%-- <asp:UpdatePanel ID="updatePanel4" runat="server" UpdateMode="Always">
                                   <ContentTemplate>--%>
                <asp:Button ID="btnConfirmYes" runat="server" Text="Yes" OnClick="btnupdate_Click" />
                 <asp:Button ID="btnConfirmNo" runat="server" Text="No"  OnClick="btnConfirmNo_Click" />
<%-- </ContentTemplate>
                                   <Triggers>
                                       <asp:AsyncPostBackTrigger ControlID="btnConfirmYes" />
                                       <asp:AsyncPostBackTrigger ControlID="btnConfirmNo" />
                                   </Triggers>
                               </asp:UpdatePanel>--%>
            </div>
        </asp:Panel>
        <cc1:ModalPopupExtender ID="mpePopupForConfirmBox" runat="server" BackgroundCssClass="modalBackground"  PopupControlID="pnlConfirmBox"
            Enabled="True" TargetControlID="Button41" CancelControlID="btnConfirmNo">
        </cc1:ModalPopupExtender>


            
              <asp:Button ID="Button42" runat="server" Text="Button" Style="display: none" />
        <asp:Panel ID="pnlCancelBox" runat="server" CssClass="modalPopup" Style="display: none">
            <div class="header">
                Message Box
            </div>
            <div class="body" style="color: red">
                <asp:Label ID="lblPopUpForCancelBox" runat="server" Text="Are you sure you want to cancel without saving the Details."></asp:Label>
            </div>
            <div class="footer" align="center">
                <asp:Button ID="btnCancelYes" runat="server" Text="Yes" OnClick="btnOk_Click" />
                 <asp:Button ID="btnCancelNo" runat="server" Text="No" />
            </div>
        </asp:Panel>
        <cc1:ModalPopupExtender ID="mpePopupForCancelBox" runat="server" BackgroundCssClass="modalBackground"  PopupControlID="pnlCancelBox"
            Enabled="True" TargetControlID="Button42" CancelControlID="btnCancelNo">
        </cc1:ModalPopupExtender>

      

               <asp:Button ID="btnforError" runat="server" Text="Button" Style="display: none" />
        <asp:Panel ID="pnlForError" runat="server" CssClass="modalPopup" Style="display: none">
            <div class="header">
                Message Box
            </div>
            <div class="body" style="color: red">
                <asp:Label ID="lblForError" runat="server" Text=""></asp:Label>
            </div>
            <div class="footer" align="center">
                <asp:Button ID="btnOkForError" runat="server" Text="Ok" />
            </div>
        </asp:Panel>
        <cc1:ModalPopupExtender ID="mpeForError" runat="server" BackgroundCssClass="modalBackground" PopupControlID="pnlForError"
            Enabled="True" TargetControlID="btnforError" OkControlID="btnOkForError">
        </cc1:ModalPopupExtender>

       <asp:Button ID="Button15" runat="server" Text="Button" Style="display: none" />
        <asp:Panel ID="pnlForBitMap" runat="server" CssClass="modalPopup" Style="display: none">
            <div class="header">
                Message Box
            </div>
            <div class="body" style="color: red">
                <asp:Label ID="lblForBitMap" runat="server" Text="Only JPG/JPEG formats are allowed."></asp:Label>
            </div>
            <div class="footer" align="center">
                <asp:Button ID="btnOkForBitMap" runat="server" Text="Ok" />
            </div>
        </asp:Panel>
        <cc1:ModalPopupExtender ID="mpeForBitMap" runat="server" BackgroundCssClass="modalBackground" PopupControlID="pnlForBitMap"
            Enabled="True" TargetControlID="Button15" OkControlID="btnOkForBitMap">
        </cc1:ModalPopupExtender>

           <asp:Button ID="Button20" runat="server" Text="Button" Style="display: none" />
        <asp:Panel ID="pnlForImage" runat="server" CssClass="modalPopup" Style="display: none;width:1000px; height:700px;">
            <div class="header">
               Images:
            </div>
            <div class="body" style="color: red; height:600px; width:900px;overflow:scroll;">               
                <asp:Repeater runat="server" ID="repforimage">
                    <ItemTemplate>
                         <img  src="<%# Eval("photo") %>" alt="Images here.........." width="300" height="200" />
                    </ItemTemplate>                   
                </asp:Repeater>
            </div>
            <div class="footer" align="center">
                <asp:Button ID="btnOkForImage" runat="server" Text="Ok" />
            </div>
        </asp:Panel>
        <cc1:ModalPopupExtender ID="mpeForImage" runat="server" BackgroundCssClass="modalBackground" PopupControlID="pnlForImage"
            Enabled="True" TargetControlID="Button20" OkControlID="btnOkForImage">
        </cc1:ModalPopupExtender>


              <asp:Panel ID="gridViewData" runat="server" CssClass="modalPopup"  style="background-image:url(../../3.jpg)" Height="500px" Width="600px" top="170px">
                              
                            <div class="border" id="Div1" style="height:auto; width: 530px;  margin:30px 30px 30px 30px" overflow: "scroll" onscroll="SetDivPosition()">
                             
                                  <div style="margin:10px;height:40px;text-align:center; vertical-align:middle;" class="header">
                                   <asp:Label ID="lblMessageForPO" runat="server" Font-Size="Medium" style="color:black;text-align:center; vertical-align:middle;"></asp:Label>
                                  </div>

                                <div class="body">


                                    <asp:GridView ID="gvReturnDetails2" BorderColor="#4D8ED1" BorderWidth="5" Height="250" Width="515" runat="server" AutoGenerateColumns="False" Font-Names = "Arial"  Font-Size = "14pt"
                                         AlternatingRowStyle-BackColor = "#4D8ED1" HeaderStyle-BackColor = "#4D8ED1" AllowPaging ="true" PageSize = "10"   >
                                        <Columns>
                                           
                                              <%-- <asp:TemplateField>
                                                    <ItemTemplate>
                                                            <asp:CheckBox ID="chkSelectAll"  runat="server" AutoPostBack="false" BorderColor="#4D8ED1" oncl/>
                                                     </ItemTemplate>
                                            </asp:TemplateField>
    --%>

  
                  <%--  <asp:BoundField DataField="StudentID" HeaderText="StudentID" ReadOnly="True" ItemStyle-ForeColor="YellowGreen" ItemStyle-BackColor="SlateGray"
                                                SortExpression="StudentID" />--%>
                                           
                                            <asp:BoundField DataField="SKUNumber"  HeaderText="SKUNumber" ItemStyle-ForeColor="black" ItemStyle-BackColor="white" ItemStyle-BorderColor="#4D8ED1"
                                                SortExpression="SKUNumber"/>
                                         
                                              <asp:BoundField DataField="SKU_Qty_Seq"  HeaderText="Quantity" ItemStyle-ForeColor="black" ItemStyle-BackColor="white" ItemStyle-BorderColor="#4D8ED1"
                                                 SortExpression="SKU_Qty_Seq" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>
                                              <asp:BoundField DataField="SKU_Sequence"  HeaderText="SKU_Sequence" ItemStyle-ForeColor="black" ItemStyle-BackColor="white" ItemStyle-BorderColor="#4D8ED1"
                                                SortExpression="SKU_Sequence" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>
                                              <asp:BoundField DataField="ProductID"  HeaderText="ProductID" ItemStyle-ForeColor="black" ItemStyle-BackColor="white" ItemStyle-BorderColor="#4D8ED1"
                                                 SortExpression="ProductID" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>
                                            
                                              <asp:BoundField DataField="LineType"  HeaderText="LineType" ItemStyle-ForeColor="black" ItemStyle-BackColor="white" ItemStyle-BorderColor="#4D8ED1"
                                                 SortExpression="LineType" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>
                                             <asp:BoundField DataField="ShipmentLines"  HeaderText="ShipmentLines" ItemStyle-ForeColor="black" ItemStyle-BackColor="white" ItemStyle-BorderColor="#4D8ED1"
                                                 SortExpression="ShipmentLines" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>
                                             <asp:BoundField DataField="ReturnLines"  HeaderText="ReturnLines" ItemStyle-ForeColor="black" ItemStyle-BackColor="white" ItemStyle-BorderColor="#4D8ED1"
                                                 SortExpression="ReturnLines" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>
                                             <asp:BoundField DataField="DeliveredQty"  HeaderText="Quantity" ItemStyle-ForeColor="black" ItemStyle-BackColor="white" ItemStyle-BorderColor="#4D8ED1"
                                                 SortExpression="DeliveredQty"/>
                                           <%--   <asp:BoundField DataField="SalesPrice"  HeaderText="SalesPrice" ItemStyle-ForeColor="black" ItemStyle-BackColor="white" ItemStyle-BorderColor="#4D8ED1"
                                                SortExpression="SalesPrice" />
                                                <asp:BoundField DataField="LineType"  HeaderText="LineType" ItemStyle-ForeColor="black" ItemStyle-BackColor="white" ItemStyle-BorderColor="#4D8ED1"
                                                SortExpression="LineType" />--%>

                                         <%--   <asp:TemplateField>
                                                    <ItemTemplate>
                                                            <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="false" BorderColor="#4D8ED1"/>
                                                     </ItemTemplate>
                                            </asp:TemplateField>--%>
                         
                                            <asp:TemplateField>
        <HeaderTemplate>
            <asp:CheckBox ID="chkSelectAll" Text="Select All" TextAlign="left" runat="server"  onclick="checkAllRow(this);" />
        </HeaderTemplate>
                                     
                                                    <ItemTemplate>
                                                            <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="false" BorderColor="#4D8ED1"/>
                                                     </ItemTemplate>
       <%-- <ItemTemplate>
            <asp:CheckBox ID="chkSelectRow" runat="server" TextAlign="Left"  onclick="CheckRow(this);" />
        </ItemTemplate>--%>
    </asp:TemplateField>
   
                                        </Columns>
   
                                     <AlternatingRowStyle BackColor="#4D8ED1"  />
                                    </asp:GridView>






                                  
                                </div>
                               
                                 <div class="footer" align="center">
                                    <asp:Button ID="Button2" runat="server" CssClass="btnmaker" Text="Next" OnClick="btnAddGrid"/>
                                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                                     <asp:Button ID="btnCancelForPO" runat="server" CssClass="btnmaker" Text="Cancel"/>
                                </div>







                            </div>
                        </asp:Panel>
                                     <asp:Button ID="Button45" runat="server" Text="Button" Style="display: none" />
                        <cc1:ModalPopupExtender ID="DataGrid" runat="server" PopupControlID="gridViewData" BackgroundCssClass="modalBackground"
                            Enabled="True" TargetControlID="Button45">
                        </cc1:ModalPopupExtender>




    </div>

            <asp:Panel ID="gridViewData1"  runat="server" CssClass="modalPopup"  style="background-image:url(../../3.jpg);overflow:scroll; overflow-style:scrollbar"  Width="675px" Height="600px" top="40px">
                              <asp:Button ID="Button19" runat="server" CssClass="btnmaker" style="margin-left:500px;" Text="Close"/>
                            <div class="border" id="Div3" style="height:auto; width:600px;  margin:30px 30px 30px 30px" >
                             
                                  <div style="margin:10px;height:40px;text-align:center; vertical-align:middle;" class="header">
                                    <asp:Label ID="lblMessageForImage" runat="server" Font-Size="Medium" style="color:black;text-align:center; vertical-align:middle;"></asp:Label>
                                  </div>

                                <asp:GridView ID="GridView1" runat="server" OnRowCommand="GridView1_RowCommand" AutoGenerateColumns="False" EmptyDataText="No Image Found" Font-Bold="True" CellPadding="4" ForeColor="Black" GridLines="Horizontal" style="margin-left:142px" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                                    <Columns>
                                        <asp:ImageField DataImageUrlField="FilePath" ControlStyle-Height="200px" ControlStyle-Width="200px"  >
                                            <ControlStyle Height="200px" Width="200px" />
                                        </asp:ImageField>
                                        <asp:ButtonField Text="Remove"  ButtonType="Button" CommandName="deleterow" ControlStyle-Height="50px" ControlStyle-Width="71px" ControlStyle-Font-Bold="true">

                                         <ControlStyle Font-Bold="True" Height="50px" Width="71px" />
                                        </asp:ButtonField>

                                         <asp:TemplateField HeaderText="FilePath"  Visible="false" >
                                            <ItemTemplate>
                                               <asp:Label ID="lblFilePath" runat="server" Text='<%#Eval("FilePath") %>' Enabled="false"></asp:Label>
                                                
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="FileName"  Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFileName" runat="server" Text='<%#Eval("FileName") %>' Enabled="false"></asp:Label>
                                               
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Name" Visible="false">
                                            <ItemTemplate>
                                                 <asp:Label ID="lblName" runat="server" Text='<%#Eval("Name") %>' ForeColor="Black" Font-Bold="True" Enabled="false"></asp:Label>
                                               
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                    </Columns>
                                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                    <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                    <SortedDescendingHeaderStyle BackColor="#242121" />
                                </asp:GridView>
                               
                                 <div class="footer" align="center">
                                    
                                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                                     
                                </div>
                                 </div>
                        </asp:Panel>
           
                                     <asp:Button ID="Button221" runat="server" Text="Button" Style="display: none" />
                        <cc1:ModalPopupExtender ID="GridImage" runat="server" PopupControlID="gridViewData1" BackgroundCssClass="modalBackground"
                            Enabled="True" TargetControlID="Button221">
                        </cc1:ModalPopupExtender>
          <asp:HiddenField ID="hdfRetunDetailID" runat="server" />
    </div>
</asp:Content>
