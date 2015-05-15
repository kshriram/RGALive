<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Master Forms/Admin.Master" AutoEventWireup="true" CodeBehind="frmTrackShipment.aspx.cs" Inherits="ShippingController_V1._0_.Forms.Web_Forms.frmTrackShipment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
    <script src="../../Themes/js/jquery-1.5.1.min.js"></script>
    <script src="../../Themes/js/highcharts.js"></script>
    <div  >
         <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <table id="tblShippingnumber" runat="server" style="width: 100%">
            <tr class="TitleStrip">
                <td class="tdLeft">
                    <asp:Label ID="lblShippingNumber" Font-Size="14"  runat="server" Text="Enter Shipping number to track: "></asp:Label>
                    <asp:TextBox ID="txtShippingNumber" runat="server" Width="150" AutoPostBack="True" OnTextChanged="txtShippingNumber_TextChanged"></asp:TextBox>
                    <asp:AutoCompleteExtender ID="txtShipmentID_AutoCompleteExtender" runat="server"
                        ServiceMethod="SearchpackingID"
                        ServicePath="~/Forms/Web Forms/AutoCompleteService.aspx"
                        MinimumPrefixLength="2"
                        CompletionInterval="100"
                        EnableCaching="true"
                        CompletionSetCount="20" 
                        TargetControlID="txtShippingNumber">
                    </asp:AutoCompleteExtender>
                </td>
            </tr>
           
            <tr >
                <td>
                    <div style="border:medium groove #0094ff">
                    <asp:Literal ID="ltrChart" runat="server" />
                        </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
