<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Master Forms/Admin.Master" AutoEventWireup="true" CodeBehind="frmChart.aspx.cs" Inherits="ShippingController_V1._0_.Forms.Web_Forms.frmChart" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <%-- <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>--%>
      <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <script src="../../Themes/js/jquery-1.5.1.min.js"></script>
    <script src="../../Themes/js/highcharts.js"></script>
    <style type="text/css">  
       
          
        .accordionHeader {  
            border: 1px solid #2F4F4F;  
           color:#cfa917;
            background:rgba(0,0,0,0.80); 
            font-family: Arial, Sans-Serif;  
            font-size: 12px;  
            font-weight: bold;  
            padding: 5px;  
            margin-top: 5px;  
            cursor: pointer;  
        }  
          
        .accordionHeaderSelected {  
            border: 1px solid #2F4F4F;  
            color: white;  
            background-color: #5078B3;  
            font-family: Arial, Sans-Serif;  
            font-size: 12px;  
            font-weight: bold;  
            padding: 5px;  
            margin-top: 5px;  
            cursor: pointer;  
        }  
          
        .accordionContent {  
            background-color: #D3DEEF;  
            border: 1px dashed #2F4F4F;  
            border-top: none;  
            padding: 5px;  
            padding-top: 10px;  
            
        }  
    </style>
    <script>
        $('[id="userpnl"]').click(function () {
            
        });
                        </script>  
   
    <div style="width:100%">
         <%--<div id="Div1" runat="server" style="width:1000px; height:300px; background-color:whitesmoke;">
        <asp:Image ID="imgTrack" Height="60px" Width="999px" runat="server" ImageUrl="~/Images/TrackingImages/New.PNG" />
    </div>--%>
       <div>
                        <asp:LinkButton ID="lkbtnPath" runat="server" Font-Italic Font-Size="Large" Text="Reports" BackColor="Silver" BorderColor="blue"></asp:LinkButton>
                    </div>
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
            SuppressHeaderPostbacks="true" Width="98%">
            <Panes>
                <asp:AccordionPane runat="server" ID="userpnl"
                    HeaderCssClass="accordionHeader"
                    HeaderSelectedCssClass="accordionHeaderSelected"
                    ContentCssClass="accordionContent">
                    <Header> User Packing Graph</Header>
                    <Content >
                        
                        <div style="border: groove medium #0094ff;" id="dvUserPacking" runat="server" >
                            <asp:Literal ID="ltrChart" runat="server"></asp:Literal>
                        </div>
                    </Content>
                </asp:AccordionPane>
            </Panes>
            <Panes>
                <asp:AccordionPane ID="AccordionPane1" runat="server"
                    HeaderCssClass="accordionHeader"
                    HeaderSelectedCssClass="accordionHeaderSelected"
                    ContentCssClass="accordionContent">
                    <Header> 
                        <div id="dvAcc1" runat="server" onclick="OndvAcc1click" >
                        Shipment Packing Time
                            </div>
                    </Header>
                    <Content>
                        <div  style="border: groove medium #0094ff; width:99%; vertical-align:middle;" id="dvShipmentPacking" runat="server">
                            <asp:Literal ID="ltrTodayspacking" runat="server" >                                
                            </asp:Literal>
                        </div>
                    </Content>
                </asp:AccordionPane>
            </Panes>
            <HeaderTemplate>ASX</HeaderTemplate>
            <ContentTemplate>asdfasdfasdf</ContentTemplate>
        </asp:Accordion>

    
    </div>
  
</asp:Content>
