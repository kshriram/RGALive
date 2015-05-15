<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Master Forms/Admin.Master" AutoEventWireup="true" CodeBehind="frmStationDashBoard.aspx.cs" Inherits="ShippingController_V1._0_.Forms.Web_Forms.frmStationDashBoard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <style>
        .main {
            height: 600px;
            overflow: auto;
            vertical-align: top;
            background-color: rgba(128, 128, 128, 0.40);
            width: 99%;
            border: medium groove #0094ff;
        }
    </style>
     <table style="width: 1350px;">
                <tr>
                    <td>
                        <asp:LinkButton ID="lkbtnPath" runat="server" Font-Italic Font-Size="Large" Text="Station" BackColor="Silver" BorderColor="blue" ></asp:LinkButton>
                        <asp:Label ID="lblDivider" runat="server" Font-Italic Font-Size="Large" Text=">>" ForeColor="blue"></asp:Label>
                        <asp:LinkButton ID="lkbtnPath1" runat="server" Font-Italic Font-Size="Large" Text="Station View" BackColor="white" BorderColor="blue"></asp:LinkButton>
                    </td>
                </tr>
    <div id="MainDiv" runat="server" class="main">
    </div>
</asp:Content>
