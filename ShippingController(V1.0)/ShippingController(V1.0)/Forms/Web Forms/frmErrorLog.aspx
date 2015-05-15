<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Master Forms/Admin.Master" AutoEventWireup="true" CodeBehind="frmErrorLog.aspx.cs" Inherits="ShippingController_V1._0_.Forms.Web_Forms.frmErrorLog" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <%-- <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>--%>
      <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
                        </asp:ScriptManager>
    <div style="width:100%; font-family:Arial;">
        <table id="tblMainTop" runat="server" style="width: 100%; margin: 0px auto;">
            <tr class="TitleStrip">
                <td>
                        <%--<asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
                        </asp:ScriptManager>--%>
                        Error Log
                </td>
            </tr>
            <tr>
                <td>
                    <table style="width: 100%; border-bottom-color: #0094ff; border-bottom-width: medium; border-bottom-style: groove;">
                        <tr style="text-align: left; vertical-align: text-bottom; height: 23px">
                            <td style="width: 2%; text-align: left;">
                                <asp:TextBox Width="500px" ID="txtSearchLog" runat="server" AutoPostBack="True" Height="22px" OnTextChanged="txtSearchLog_TextChanged"></asp:TextBox>
                                <asp:AutoCompleteExtender ID="txtSearchLog_AutoCompleteExtender" runat="server"
                                    ServiceMethod="SearchLog"
                                    MinimumPrefixLength="1"
                                    ServicePath="~/Forms/Web Forms/AutoCompleteService.aspx"
                                    CompletionInterval="100"
                                    EnableCaching="true"
                                    CompletionSetCount="20"
                                    TargetControlID="txtSearchLog">
                                </asp:AutoCompleteExtender>
                                <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server"
                                    TargetControlID="txtSearchLog" WatermarkText="Enter Text To Search Log">
                                </asp:TextBoxWatermarkExtender>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div id="dvLeft" runat="server">
                                    <asp:Panel ID="panel1" runat="server" Height="300px" ScrollBars="Auto">
                                        <asp:GridView ID="gvErrorInformation" Width="95%" runat="server" HorizontalAlign="Center" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black">
                                            <Columns>
                                                <asp:BoundField HeaderText="Error ID" DataField="ErrorID"  />
                                                <asp:BoundField HeaderText="Error Description" DataField="ErrorDescription" />
                                                <asp:BoundField HeaderText="Error Location" DataField="ErrorLocation" />
                                                <asp:BoundField HeaderText="User Name" DataField="UserName" />
                                                <asp:BoundField HeaderText="Error Time" DataField="ErrorDate" />
                                            </Columns>
                                            <FooterStyle BackColor="#CCCCCC" />
                                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                                            <RowStyle BackColor="White" />
                                            <SelectedRowStyle BackColor="Brown" Font-Bold="True" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                            <SortedAscendingHeaderStyle BackColor="#808080" />
                                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                            <SortedDescendingHeaderStyle BackColor="#383838" />
                                        </asp:GridView>
                                    </asp:Panel>
                                    <asp:HiddenField ID="PosY" runat="server" Value="0" />
                                    <asp:HiddenField ID="PosX" runat="server" Value="0" />
                                </div>
                            </td>
            </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>

</asp:Content>
