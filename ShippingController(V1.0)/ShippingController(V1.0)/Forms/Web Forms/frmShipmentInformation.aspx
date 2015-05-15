<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Master Forms/Admin.Master" AutoEventWireup="true" CodeBehind="frmShipmentInformation.aspx.cs" Inherits="ShippingController_V1._0_.Forms.Web_Forms.frmShipmentInformation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
    <%@ Import Namespace="ShippingController_V1._0_.Models" %>
    <%@ Import Namespace="DotNet.Highcharts" %>
    <%@ Import Namespace="DotNet.Highcharts.Enums" %>
    <%@ Import Namespace="DotNet.Highcharts.Helpers" %>
    <%@ Import Namespace="DotNet.Highcharts.Options" %>
    <%@ Import Namespace="PackingClassLibrary.CustomEntity.ReportEntitys" %>
    <%@ Import Namespace="PackingClassLibrary.CustomEntity" %>
    <%@ Import Namespace="PackingClassLibrary.CustomEntity.SMEntitys" %>
    <%@ Import Namespace="PackingClassLibrary.CustomEntity.SMEntitys.RGA" %>
    <%@ Import Namespace="ShippingController_V1._0_.Views" %>




    <%@ Import Namespace="System.Xml.Xsl" %>
    <%@ Import Namespace="System.Xml" %>
    <%@ Import Namespace="System.Linq" %>


    <style>
        .list-item {
            font: normal 11px tahoma, arial, helvetica, sans-serif;
            padding: 3px 10px 3px 10px;
            border: 1px solid #fff;
            border-bottom: 1px solid #eeeeee;
            white-space: normal;
            color: #555;
        }

            .list-item h3 {
                display: block;
                font: inherit;
                font-weight: bold;
                margin: 0px;
                color: #222;
            }
    </style>

    <script>
        var showResult = function (btn) {
            Ext.Msg.notify("Button Click", "You clicked the " + btn + " button");
        };

        var showResultText = function (btn, text) {
            Ext.Msg.notify("Button Click", "You clicked the " + btn + 'button and entered the text "' + text + '".');
        };
    </script>


    <script>
        function getCompanyValue() {
            var value = this.getComponent(1).getValue();
            return (Ext.isEmpty(value) ? "" : this.getComponent(0).text) + value;
        }

        function getSizeValue() {
            var text = [];

            this.menu.items.each(function (item) {
                if (item.checked) {
                    text.push(item.text);
                }
            });

            if (text.length == 0) {
                return "";
            } else {
                return "any " + text.join(",");
            }
        }

        function onItemCheck(menuItem) {
            var checked = false,
                button = menuItem.up('button');

            menuItem.parentMenu.items.each(function (item) {
                if (item.checked) {
                    checked = true;
                    return false;
                }
            });

            if (checked) {
                button.setText("[Filtered]");
            } else {
                button.setText("[No Filter]");
            }

            menuItem.up('grid').filterHeader.onFieldChange(button);
        }
    </script>

    <script runat="server">
    
        Boolean flag = true;



        private void Page_PreInit(object sender, EventArgs e)
        {
            //string user = Session["UserID"].ToString().ToUpper();
            //if (Session["UserID"].ToString().ToUpper() == "0DD3CB2D-33B6-431F-9DA0-042F9FF3963B")
            string role = Session["RoleID"].ToString().ToUpper();
            if (Session["RoleID"].ToString().ToUpper() == "077A2FA0-88D3-4732-9D7B-203D6DE2D875")
            {
                this.MasterPageFile = "~/Forms/Master Forms/Admin.Master";
            }
            else
            {
                this.MasterPageFile = "~/Forms/Master Forms/TestUser.Master";
            }

        }
    </script>
  <%--  <style>
        .child-row .x-grid-cell {
            background-color: #ffe2e2;
            color: #900;
        }

        .adult-row .x-grid-cell {
            background-color: #e2ffe2;
            color: #090;
        }

        .dirty-row .x-grid-cell, .dirty-row .x-grid-rowwrap-div {
            background-color: #FFFDD8 !important;
        }

        .new-row .x-grid-cell, .new-row .x-grid-rowwrap-div {
            background-color: #c8ffc8 !important;
        }
    </style>--%>


    <style>
       .child-row .x-grid-cell {
           background-color: #ffe2e2;
           color: #900;
       }

       .adult-row .x-grid-cell {
           background-color: #e2ffe2;
           color: #090;
       }

       .dirty-row .x-grid-cell {
           background-color: #767BE4 ;
       }
       .dirty-row .x-grid-rowwrap-div {
           background-color: #900 ;
       }

       .new-row .x-grid-cell, .new-row .x-grid-rowwrap-div {
           background-color: #3BDE32 !important;
       }
       .new-row2 .x-grid-cell,.x-grid-row-alt {
            background-color: #ff6a00!important;
       }

       .Complete-row .x-grid-cell, .x-grid-row-alt {
            background-color: #0ff!important;
       }
   </style>

    <style type="text/css">
       .dirty-row {
           background: #2027E9;
       }

       .new-row {
           background: #E92121;
       }
       .new-row2 {
           background: #b200ff;
       }
      

        .new-row12 {
           background: #2027E9;
       }
   </style>



    <script>
        Ext.net.FilterHeader.behaviour.addBehaviour("string", {
            name: "any",

            is: function (value) {
                return Ext.net.StringUtils.startsWith(value, "any ");
            },

            getValue: function (value) {
                var values = Ext.net.FilterHeader.behaviour.getStrValue(value).substring(4).split(" "),
                tmp = [];

                Ext.each(values, function (v) {
                    v = v.trim();
                    if (!Ext.isEmpty(v)) {
                        tmp.push(v);
                    }
                });

                values = tmp;

                return { value: values, valid: values.length > 0 };
            },

            match: function (recordValue, matchValue) {
                for (var i = 0; i < matchValue.length; i++) {
                    if (recordValue === matchValue[i]) {
                        return true;
                    }
                }

                return false;
            },

            isValid: function (value) {
                return this.getValue(value, field).valid;
            },

            serialize: function (value) {
                return {
                    type: "string",
                    op: "any",
                    value: value
                };
            }
        });



    </script>

    <script runat="server">
        TimeZoneInfo EstZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
        List<PackingClassLibrary.CustomEntity.SMEntitys.cstBoxPackageNew> lsBoxPackageNew = new List<cstBoxPackageNew>();




        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["Admin Page"] = "Return Details";
                if (!X.IsAjaxRequest)
                {
                    this.BindData();
                }
            }
        }

        protected void MyData_Refresh(object sender, StoreReadDataEventArgs e)
        {
            this.BindData();
        }


        public void Store2_Refresh(object sender, StoreReadDataEventArgs e)
        {
            List<cstPackageBoxTracking> GridPanel2 = new List<cstPackageBoxTracking>();
            GridPanel2 = ((List<cstPackageBoxTracking>)Session["GridPanel2"]);
            Store store2 = this.GridPanel2.GetStore();
            this.Store2.DataSource = GridPanel2;
            this.Store2.DataBind();
        }

        private void BindData()
        {
            // Here GridPanel1 is filled.
            FillGvShippingingInforamtion();


            // Creating Session for All
            List<cstShipmentDetailPageGrid1> lsShipping = new List<cstShipmentDetailPageGrid1>();
            Session["Today"] = lsShipping;
            Session["Total"] = lsShipping;
            Session["DateSearch"] = lsShipping;

            // Here GridPanel2 is filled.
            List<PackingClassLibrary.CustomEntity.SMEntitys.cstBoxPackageNew> lsBoxPackageNew = new List<cstBoxPackageNew>();
            Session["GridPanel2"] = lsBoxPackageNew;

            // Getting Count and Showing on Button
            // String Date1 = "3/17/2015";
            //String Date1 = DateTime.Now.ToShortDateString(); 
            //int TodaysCount =Obj.call.GetShipmentDetailPageGrid1ByDate(Date1).Count;
            //btntodays.Text = "Today's Shipment" + "(" + TodaysCount + ")";

            //int TotalCount = Obj.call.GetShipmentDetailPageGrid1ByDateTotal(Date1).Count;
            //btnViewAll.Text = "Total Shipment's" + "(" + TotalCount + ")";

            //lblGrid1.Text = "This Grid Shows Today's Shipment's";

            this.Store3.DataSource = new object[]
        {
            new object[] { "Expected Date"},
            new object[] { "Shipping Date"}
        };


            this.Store4.DataSource = new object[]
       {
           new object[] { "Waiting to be Packed"},
           new object[] { "Partially Packed"},
           new object[] { "Shipped"},
           new object[] { "Completely Packed - Waiting for Tracking"}
       };

        }





        public void BindDataForGridPanel2()
        {
            //GridPanel2 Session
            List<cstPackageBoxTracking> lsBoxPackageNew11111 = new List<cstPackageBoxTracking>();
            lsBoxPackageNew11111 = ((List<cstPackageBoxTracking>)Session["GridPanel2"]);
            Store store2 = this.GridPanel2.GetStore();
            this.Store2.DataSource = lsBoxPackageNew11111;
            this.Store2.DataBind();
            this.Store2.Reload();
        }
        
    </script>

    <link href="/resources/css/examples.css" rel="stylesheet" />

    <script>
        var submitValue = function (grid, hiddenFormat, format) {
            hiddenFormat.setValue(format);
            grid.submitData(false, { isUpload: true });
        };

        //var template = '<span style="color:{0};">{1}</span>';

        //var change = function (value) {
        //    return Ext.String.format(template, (value > 0) ? "green" : "red", value);
        //};

        //var pctChange = function (value) {
        //    return Ext.String.format(template, (value > 0) ? "green" : "red", value + "%");
        //};
    </script>

    <script>
        var getRowClass = function (record) {
            if (record.get("ShipmentStatus") == "Waiting to be Packed")
                return "dirty-row";

            else if (record.get("ShipmentStatus") == "Shipped")
                return "new-row";

            else if (record.get("ShipmentStatus") == "Partially Packed")
                return "new-row2";

            else if (record.get("ShipmentStatus") == "Completely Packed - Waiting for Tracking")
                return "Complete-row";

        };
    </script>
    <!DOCTYPE html>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <html>


    <head>
        <title></title>
        <script runat="server">
        
        
            protected void Store1_Submit(object sender, StoreSubmitDataEventArgs e)
            {
                string format = this.FormatType.Value.ToString();

                XmlNode xml = e.Xml;

                this.Response.Clear();

                switch (format)
                {
                    case "xml":
                        string strXml = xml.OuterXml;
                        this.Response.AddHeader("Content-Disposition", "attachment; filename=submittedData.xml");
                        this.Response.AddHeader("Content-Length", strXml.Length.ToString());
                        this.Response.ContentType = "application/xml";
                        this.Response.Write(strXml);
                        break;

                    case "xls":
                        this.Response.ContentType = "application/vnd.ms-excel";
                        this.Response.AddHeader("Content-Disposition", "attachment; filename=submittedData.xls");
                        XslCompiledTransform xtExcel = new XslCompiledTransform();
                        xtExcel.Load(Server.MapPath("Excel.xsl"));
                        xtExcel.Transform(xml, null, Response.OutputStream);

                        break;

                    case "csv":
                        this.Response.ContentType = "application/octet-stream";
                        this.Response.AddHeader("Content-Disposition", "attachment; filename=submittedData.csv");
                        XslCompiledTransform xtCsv = new XslCompiledTransform();
                        xtCsv.Load(Server.MapPath("Csv.xsl"));
                        xtCsv.Transform(xml, null, Response.OutputStream);

                        break;
                }

                this.Response.End();
            }







            [DirectMethod]
            public void FillGvShippingingInforamtion()
            {
                try
                {
                    String Date1 = DateTime.Now.ToShortDateString();
                    // String Date1 = "3/17/2015";

                    List<cstShipmentDetailPageGrid1> lsShipping = new List<cstShipmentDetailPageGrid1>();
                    lsShipping = Obj.call.GetShipmentDetailPageGrid1ByDate(Date1);

                    //Creating Session for showing Count
                    Session["Today"] = lsShipping;

                    Store store = this.GridPanel1.GetStore();
                    this.Store1.DataSource = lsShipping;
                    this.Store1.DataBind();
                    Session["GridPanel1"] = lsShipping;

                    int TodaysCount = ((List<cstShipmentDetailPageGrid1>)Session["Today"]).Count;
                    btntodays.Text = "Today's Shipment " + "(" + TodaysCount + ")";

                    lblGrid1.Text = "This Grid Shows Today's Shipment's (" + TodaysCount + ")";

                    DateField1.Clear();
                    DateField2.Clear();
                }
                catch (Exception)
                { }
            }

            [DirectMethod]
            public void FillGvShippingingInforamtionTotal()
            {
                try
                {
                    String Date1 = DateTime.Now.ToShortDateString();

                    List<cstShipmentDetailPageGrid1> lsShipping = new List<cstShipmentDetailPageGrid1>();
                    lsShipping = Obj.call.GetShipmentDetailPageGrid1ByDateTotal(Date1);

                    //Creating Session for showing Count
                    Session["Total"] = lsShipping;

                    Store store = this.GridPanel1.GetStore();
                    this.Store1.DataSource = lsShipping;
                    this.Store1.DataBind();
                    Session["GridPanel1"] = lsShipping;

                    int TotalCount = ((List<cstShipmentDetailPageGrid1>)Session["Total"]).Count;
                    btnViewAll.Text = "Total Shipment's " + "(" + TotalCount + ")";

                    lblGrid1.Text = "This Grid Shows Total Shipment's (" + TotalCount + ")";

                    DateField1.Clear();
                    DateField2.Clear();
                }
                catch (Exception)
                { }
            }

            [DirectMethod]
            public void TotalShipments()
            {
                FillGvShippingingInforamtionTotal();

                int TodaysCount = ((List<cstShipmentDetailPageGrid1>)Session["Today"]).Count;
                btntodays.Text = "Today's Shipment " + "(" + TodaysCount + ")";

                //lblGrid1.Text = "This Grid Shows Total Shipment's";
            }

            [DirectMethod]
            public void TodayShipments()
            {
                FillGvShippingingInforamtion();

                int TotalCount = ((List<cstShipmentDetailPageGrid1>)Session["Total"]).Count;
                btnViewAll.Text = "Total Shipment's " + "(" + TotalCount + ")";

            }

            [DirectMethod]
            public void DateSearchByShippingDate()
            {
                string Date1 = DateField1.SelectedDate.ToShortDateString();
                string Date2 = DateField2.SelectedDate.ToShortDateString();

                List<cstShipmentDetailPageGrid1> lsShipping = new List<cstShipmentDetailPageGrid1>();
                lsShipping = Obj.call.GetShipmentDetailPageGrid1ByDateSearch(Date1, Date2);

                //Creating Session for showing Count
                Session["DateSearch"] = lsShipping;

                Store store = this.GridPanel1.GetStore();
                this.Store1.DataSource = lsShipping;
                this.Store1.DataBind();
                Session["GridPanel1"] = lsShipping;

                int DateSearch = ((List<cstShipmentDetailPageGrid1>)Session["DateSearch"]).Count;
                //btntodays.Text = "Today's Shipment" + "(" + DateSearch + ")";

                lblGrid1.Text = "This Grid Shows Shipment's From " + Date1 + " To " + Date2 + " (" + DateSearch + ")";

                int TodaysCount = ((List<cstShipmentDetailPageGrid1>)Session["Today"]).Count;
                btntodays.Text = "Today's Shipment " + "(" + TodaysCount + ")";

                int TotalCount = ((List<cstShipmentDetailPageGrid1>)Session["Total"]).Count;
                btnViewAll.Text = "Total Shipment's " + "(" + TotalCount + ")";
            }

            [DirectMethod]
            public void DateSearchByExpectedDate()
            {
                string Date1 = DateField1.SelectedDate.ToShortDateString();
                string Date2 = DateField2.SelectedDate.ToShortDateString();

                List<cstShipmentDetailPageGrid1> lsShipping = new List<cstShipmentDetailPageGrid1>();
                lsShipping = Obj.call.GetShipmentDetailPageGrid1ByDateSearchExpecteds(Date1, Date2);

                //Creating Session for showing Count
                Session["DateSearch"] = lsShipping;

                Store store = this.GridPanel1.GetStore();
                this.Store1.DataSource = lsShipping;
                this.Store1.DataBind();
                Session["GridPanel1"] = lsShipping;

                int DateSearch = ((List<cstShipmentDetailPageGrid1>)Session["DateSearch"]).Count;
                //btntodays.Text = "Today's Shipment" + "(" + DateSearch + ")";

                lblGrid1.Text = "This Grid Shows Shipment's From " + Date1 + " To " + Date2 + " (" + DateSearch + ")";

                int TodaysCount = ((List<cstShipmentDetailPageGrid1>)Session["Today"]).Count;
                btntodays.Text = "Today's Shipment " + "(" + TodaysCount + ")";

                int TotalCount = ((List<cstShipmentDetailPageGrid1>)Session["Total"]).Count;
                btnViewAll.Text = "Total Shipment's " + "(" + TotalCount + ")";
            }

            [DirectMethod]
            public void DateSearch1()
            {
                if (ComboBox1.Text == "" || ComboBox1.Text == null)
                {
                    X.Msg.Alert("Alert Message", "Select any option from Dropdown.", new JFunction { Fn = "showResult" }).Show();
                }
                else
                {
                    //if ( DateField1.Text=="" || DateField2.Text=="" || DateField1.Text==null || DateField2.Text==null)
                    //{

                    //}
                    if (ComboBox1.Text == "Expected Date")
                    {
                        DateSearchByExpectedDate();
                    }
                    else if (ComboBox1.Text == "Shipping Date")
                    {
                        DateSearchByShippingDate();
                    }
                }
            }


            //[DirectMethod]
            //public void DateExport()
            //{

            //    //if ( DateField1.Text=="" || DateField2.Text=="" || DateField1.Text==null || DateField2.Text==null)
            //    //{

            //    //}
            //    if (ComboBox1.Text == "Expected Date")
            //    {
            //        DateSearchByExpectedDate();
            //    }
            //    else if (ComboBox1.Text == "Shipping Date")
            //    {
            //        DateSearchByShippingDate();
            //    }

            //}


            [DirectMethod]
            public void GridPanel1_SelectedIndexChanged(string ShipmentID)
            {
                lblForTracking.Text = "Tracking Details For " + ShipmentID;
                // lblBoxDetailFor.Text = "Tracking Details For " + ShipmentID;
                List<cstPackageBoxTracking> lsPacking = new List<cstPackageBoxTracking>();
                try
                {
                    //GetPackageBoxTrackingBySHO
                    lsPacking = Obj.call.GetPackageBoxTrackingBySHO(ShipmentID);

                    Store store = this.GridPanel2.GetStore();
                    this.Store2.DataSource = lsPacking;
                    this.Store2.DataBind();
                    Session["GridPanel2"] = lsPacking;

                    BindDataForGridPanel2();
                }
                catch (Exception)
                { }
            }

            [DirectMethod(Namespace = "CompanyX")]
            public void DoSomethingforGridPanel2()
            {
                System.Threading.Thread.Sleep(2000);
                X.Mask.Hide();
            }

            [DirectMethod(Namespace = "CompanyX")]
            public void DoSomethingforGridPanel3()
            {
                System.Threading.Thread.Sleep(4000);
                X.Mask.Hide();
            }

            [DirectMethod(Namespace = "CompanyX")]
            public void DoSomethingforTotal()
            {
                System.Threading.Thread.Sleep(4000);
                X.Mask.Hide();
            }

            [DirectMethod(Namespace = "CompanyX")]
            public void DoSomethingfortoday()
            {
                System.Threading.Thread.Sleep(4000);
                X.Mask.Hide();
            }

            [DirectMethod(Namespace = "CompanyX")]
            public void DoSomethingforDateSearch()
            {
                System.Threading.Thread.Sleep(4000);
                X.Mask.Hide();
            }
            
        </script>
    </head>
    <body>
        <form id="Form1">

            <ext:Hidden ID="FormatType" runat="server" />
            <ext:ResourceManager ID="ResourceManager1" runat="server" />
            <div id="SingleForm">
                <table id="TableForm" style="width: 100%; height: auto; z-index: 1;">
                    <tr>
                        <td rowspan="3">
                            <table>
                                <tr>
                                    <td>
                                        <div>
                                            <ext:FieldSet ID="fieldForGrid1" runat="server" Title="Shipping Status Board" Style="font-size: large" Layout="AnchorLayout" DefaultAnchor="400%">
                                                <Items>
                                                    <ext:FieldContainer ID="fieldContainerForGrid1" runat="server" FieldLabel="Name" Layout="HBoxLayout" CombineErrors="true">
                                                        <FieldDefaults HideLabel="true" />
                                                        <Items>
                                                            <ext:Button runat="server" Text="Total Shipments" ID="btnViewAll" Cls="lnkbtn" Icon="ApplicationViewList">
                                                                <Listeners>
                                                                    <Click Handler="Ext.net.Mask.show({ msg : 'Loading Please wait...' }); CompanyX.DoSomethingforTotal();     App.direct.TotalShipments();" />
                                                                </Listeners>
                                                            </ext:Button>
                                                            <ext:MenuSeparator Width="30px" />
                                                            <ext:Button runat="server" Text="Todays Shipment" ID="btntodays" Cls="lnkbtn" Icon="ApplicationViewList">
                                                                <Listeners>
                                                                    <Click Handler="Ext.net.Mask.show({ msg : 'Loading Please wait...' }); CompanyX.DoSomethingfortoday();      App.direct.TodayShipments();" />
                                                                </Listeners>
                                                            </ext:Button>
                                                            <ext:MenuSeparator Width="30px" />
                                                            <ext:Label ID="Label3" runat="server" Text="Search By :"></ext:Label>
                                                            <ext:ComboBox ID="ComboBox1"
                                                                runat="server"
                                                                Width="250"
                                                                Editable="false"
                                                                DisplayField="Date"
                                                                QueryMode="Local"
                                                                ForceSelection="true"
                                                                TriggerAction="All"
                                                                EmptyText="Select a Date...">
                                                                <Store>
                                                                    <ext:Store ID="Store3" runat="server">
                                                                        <Model>
                                                                            <ext:Model ID="Model3" runat="server">
                                                                                <Fields>
                                                                                    <ext:ModelField Name="Date" />
                                                                                </Fields>
                                                                            </ext:Model>
                                                                        </Model>
                                                                    </ext:Store>
                                                                </Store>
                                                                <ListConfig>
                                                                    <ItemTpl ID="ItemTpl1" runat="server">
                                                                        <Html>
                                                                            <div class="list-item">
							                                                   <h3>{Date}</h3>
                                                                            </div>
                                                                        </Html>
                                                                    </ItemTpl>
                                                                </ListConfig>
                                                            </ext:ComboBox>
                                                            <ext:MenuSeparator Width="30px" />
                                                            <ext:Label ID="Label1" runat="server" Text="From Date :"></ext:Label>
                                                            <ext:DateField ID="DateField1" runat="server">
                                                                <Listeners>
                                                                    <Select Handler="#{DisplayField1}.setValue(Ext.util.Format.time(this.getValue()));" />
                                                                </Listeners>
                                                            </ext:DateField>
                                                            <ext:MenuSeparator Width="30px" />
                                                            <ext:Label ID="Label2" runat="server" Text="To Date :"></ext:Label>
                                                            <ext:DateField ID="DateField2" runat="server">
                                                                <Listeners>
                                                                    <Select Handler="#{DisplayField1}.setValue(Ext.util.Format.time(this.getValue()));" />
                                                                </Listeners>
                                                            </ext:DateField>
                                                            <ext:MenuSeparator Width="30px" />
                                                            <ext:Button runat="server" Text="Search" ID="btnDateSearch" Cls="lnkbtn" Icon="ApplicationViewList">
                                                                <Listeners>
                                                                    <Click Handler="Ext.net.Mask.show({ msg : 'Loading Please wait...' }); CompanyX.DoSomethingforDateSearch();      App.direct.DateSearch1();" />
                                                                </Listeners>
                                                            </ext:Button>
                                                              <ext:MenuSeparator Width="30px" />
                                                            <ext:Button runat="server" Text="Export" ID="btnExport" Cls="lnkbtn" Icon="PageExcel">
                                                                <Listeners>
                                                                    <Click Handler="submitValue(#{GridPanel1}, #{FormatType}, 'xls');" />
                                                                </Listeners>
                                                            </ext:Button>
                                                        </Items>
                                                    </ext:FieldContainer>
                                                </Items>
                                            </ext:FieldSet>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div>
                                            <ext:FieldSet ID="FieldSet2" runat="server" Title="Tracking Status Board" Style="font-size: larger" Layout="AnchorLayout" DefaultAnchor="400%">
                                                <Items>
                                                    <ext:FieldContainer ID="fieldContainer2" runat="server" FieldLabel="Name" Layout="HBoxLayout" CombineErrors="true">
                                                        <FieldDefaults HideLabel="true" />
                                                        <Items>
                                                            <ext:Label runat="server" Text="" ID="lblGrid1" Style="color: red"></ext:Label>
                                                        </Items>
                                                    </ext:FieldContainer>
                                                </Items>
                                            </ext:FieldSet>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 500px; height: 220px">
                                        <div id="divForGrid1" style="height: auto; width: 100%; overflow: scroll" onscroll="SetDivPosition()">
                                            <ext:GridPanel
                                                ID="GridPanel1"
                                                runat="server"
                                                Title="Shipping information"
                                                Width="1550"
                                                UI="Danger">
                                                <Store>
                                                    <ext:Store ID="Store1" runat="server" OnReadData="Page_Load" PageSize="25" OnSubmitData="Store1_Submit">
                                                        <Model>
                                                            <ext:Model ID="Model1" runat="server" IDProperty="ShipmentID">
                                                                <Fields>
                                                                    <ext:ModelField Name="ShipmentID" Type="String" />
                                                                    <ext:ModelField Name="ShippingDate" Type="String" />
                                                                    <ext:ModelField Name="ShippingTime" Type="String" />
                                                                    <ext:ModelField Name="OrderID" Type="String" />
                                                                    <ext:ModelField Name="PONumber" Type="String" />
                                                                    <ext:ModelField Name="PartnerID" Type="String" />
                                                                    <ext:ModelField Name="DeliveryMode" Type="String" />
                                                                    <ext:ModelField Name="Carrier" Type="String" />
                                                                    <ext:ModelField Name="ExpectedShipDate" Type="String" />
                                                                    <%-- <ext:ModelField Name="shqty" Type="Int" />
                                                                    <ext:ModelField Name="pkqty" Type="Int" />
                                                                    <ext:ModelField Name="TrkCount" Type="Int" />
                                                                    <ext:ModelField Name="BoxCount" Type="Int" />--%>
                                                                    <ext:ModelField Name="ShipmentStatus" Type="String" />
                                                                </Fields>
                                                            </ext:Model>
                                                        </Model>
                                                    </ext:Store>
                                                </Store>
                                                <ColumnModel ID="ColumnModel1" runat="server" UI="Primary">
                                                    <Columns>
                                                        <ext:RowNumbererColumn ID="RowNumbererColumn1" runat="server" Width="50" />
                                                        <ext:CommandColumn ID="CommandColumn1" Width="60" runat="server" Filterable="false">
                                                            <Commands>
                                                                <ext:GridCommand CommandName="Select" Text="Select" />
                                                            </Commands>
                                                            <Listeners>
                                                                <Command Handler=" Ext.net.Mask.show({ msg : 'Loading Please wait...' }); CompanyX.DoSomethingforGridPanel2();   App.direct.GridPanel1_SelectedIndexChanged(record.data.ShipmentID)" />
                                                            </Listeners>
                                                        </ext:CommandColumn>
                                                        <ext:Column ID="Column1" runat="server" Text="Shipment ID" DataIndex="ShipmentID" Width="150" Filterable="false">
                                                            <HeaderItems>
                                                                <ext:Container ID="Container1" runat="server" Layout="HBoxLayout" Margin="2">
                                                                    <Items>
                                                                        <ext:CycleButton ID="CycleButton1" runat="server" ShowText="true" Width="48" ForceIcon="#Magnifier">
                                                                            <Menu>
                                                                                <ext:Menu ID="Menu1" runat="server">
                                                                                    <Items>
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem1" runat="server" Text="=" ToolTip="Equals" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem2" runat="server" Text="+" ToolTip="Starts with" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem3" runat="server" Text="-" ToolTip="Ends with" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem4" runat="server" Text="*" Checked="true" ToolTip="Contains" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem5" runat="server" Text="!" ToolTip="Doesn't contain" />
                                                                                    </Items>
                                                                                </ext:Menu>
                                                                            </Menu>
                                                                            <Listeners>
                                                                                <Change Handler="this.up('grid').filterHeader.onFieldChange(this.up('container'));" />
                                                                            </Listeners>
                                                                        </ext:CycleButton>

                                                                        <ext:TextField ID="TextField1" runat="server" Flex="1">
                                                                            <Plugins>
                                                                                <ext:ClearButton ID="ClearButton1" runat="server" />
                                                                            </Plugins>
                                                                            <Listeners>
                                                                                <Change Handler="this.up('grid').filterHeader.onFieldChange(this.up('container'));" />
                                                                            </Listeners>
                                                                        </ext:TextField>
                                                                    </Items>
                                                                    <CustomConfig>
                                                                        <ext:ConfigItem Name="getValue" Value="getCompanyValue" Mode="Raw" />
                                                                    </CustomConfig>
                                                                </ext:Container>
                                                            </HeaderItems>
                                                        </ext:Column>
                                                        <ext:Column ID="Column2" runat="server" Text="Shipping Date" Width="120" DataIndex="ShippingDate">
                                                            <HeaderItems>
                                                                <ext:Container ID="Container2" runat="server" Layout="HBoxLayout" Margin="2">
                                                                    <Items>
                                                                        <ext:CycleButton ID="CycleButton2" runat="server" ShowText="true" Width="48" ForceIcon="#Magnifier">
                                                                            <Menu>
                                                                                <ext:Menu ID="Menu2" runat="server">
                                                                                    <Items>
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem6" runat="server" Text="=" ToolTip="Equals" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem7" runat="server" Text="+" ToolTip="Starts with" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem8" runat="server" Text="-" ToolTip="Ends with" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem9" runat="server" Text="*" Checked="true" ToolTip="Contains" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem10" runat="server" Text="!" ToolTip="Doesn't contain" />
                                                                                    </Items>
                                                                                </ext:Menu>
                                                                            </Menu>
                                                                            <Listeners>
                                                                                <Change Handler="this.up('grid').filterHeader.onFieldChange(this.up('container'));" />
                                                                            </Listeners>
                                                                        </ext:CycleButton>

                                                                        <ext:TextField ID="TextField2" runat="server" Flex="1">
                                                                            <Plugins>
                                                                                <ext:ClearButton ID="ClearButton2" runat="server" />
                                                                            </Plugins>
                                                                            <Listeners>
                                                                                <Change Handler="this.up('grid').filterHeader.onFieldChange(this.up('container'));" />
                                                                            </Listeners>
                                                                        </ext:TextField>
                                                                    </Items>
                                                                    <CustomConfig>
                                                                        <ext:ConfigItem Name="getValue" Value="getCompanyValue" Mode="Raw" />
                                                                    </CustomConfig>
                                                                </ext:Container>
                                                            </HeaderItems>
                                                        </ext:Column>
                                                        <ext:Column ID="Column3" runat="server" Text="Shipping Time" Width="120" DataIndex="ShippingTime">
                                                            <HeaderItems>
                                                                <ext:Container ID="Container3" runat="server" Layout="HBoxLayout" Margin="2">
                                                                    <Items>
                                                                        <ext:CycleButton ID="CycleButton3" runat="server" ShowText="true" Width="48" ForceIcon="#Magnifier">
                                                                            <Menu>
                                                                                <ext:Menu ID="Menu3" runat="server">
                                                                                    <Items>
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem11" runat="server" Text="=" ToolTip="Equals" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem12" runat="server" Text="+" ToolTip="Starts with" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem13" runat="server" Text="-" ToolTip="Ends with" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem14" runat="server" Text="*" Checked="true" ToolTip="Contains" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem15" runat="server" Text="!" ToolTip="Doesn't contain" />
                                                                                    </Items>
                                                                                </ext:Menu>
                                                                            </Menu>
                                                                            <Listeners>
                                                                                <Change Handler="this.up('grid').filterHeader.onFieldChange(this.up('container'));" />
                                                                            </Listeners>
                                                                        </ext:CycleButton>

                                                                        <ext:TextField ID="TextField3" runat="server" Flex="1">
                                                                            <Plugins>
                                                                                <ext:ClearButton ID="ClearButton3" runat="server" />
                                                                            </Plugins>
                                                                            <Listeners>
                                                                                <Change Handler="this.up('grid').filterHeader.onFieldChange(this.up('container'));" />
                                                                            </Listeners>
                                                                        </ext:TextField>
                                                                    </Items>
                                                                    <CustomConfig>
                                                                        <ext:ConfigItem Name="getValue" Value="getCompanyValue" Mode="Raw" />
                                                                    </CustomConfig>
                                                                </ext:Container>
                                                            </HeaderItems>
                                                        </ext:Column>
                                                        <ext:Column ID="Column4" runat="server" Text="Order ID" Width="150" DataIndex="OrderID">
                                                            <HeaderItems>
                                                                <ext:Container ID="Container4" runat="server" Layout="HBoxLayout" Margin="2">
                                                                    <Items>
                                                                        <ext:CycleButton ID="CycleButton4" runat="server" ShowText="true" Width="48" ForceIcon="#Magnifier">
                                                                            <Menu>
                                                                                <ext:Menu ID="Menu4" runat="server">
                                                                                    <Items>
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem16" runat="server" Text="=" ToolTip="Equals" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem17" runat="server" Text="+" ToolTip="Starts with" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem18" runat="server" Text="-" ToolTip="Ends with" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem19" runat="server" Text="*" Checked="true" ToolTip="Contains" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem20" runat="server" Text="!" ToolTip="Doesn't contain" />
                                                                                    </Items>
                                                                                </ext:Menu>
                                                                            </Menu>
                                                                            <Listeners>
                                                                                <Change Handler="this.up('grid').filterHeader.onFieldChange(this.up('container'));" />
                                                                            </Listeners>
                                                                        </ext:CycleButton>

                                                                        <ext:TextField ID="TextField4" runat="server" Flex="1">
                                                                            <Plugins>
                                                                                <ext:ClearButton ID="ClearButton4" runat="server" />
                                                                            </Plugins>
                                                                            <Listeners>
                                                                                <Change Handler="this.up('grid').filterHeader.onFieldChange(this.up('container'));" />
                                                                            </Listeners>
                                                                        </ext:TextField>
                                                                    </Items>
                                                                    <CustomConfig>
                                                                        <ext:ConfigItem Name="getValue" Value="getCompanyValue" Mode="Raw" />
                                                                    </CustomConfig>
                                                                </ext:Container>
                                                            </HeaderItems>
                                                        </ext:Column>
                                                        <ext:Column ID="Column5" runat="server" Text="PO Number" Width="150" DataIndex="PONumber">
                                                            <HeaderItems>
                                                                <ext:Container ID="Container5" runat="server" Layout="HBoxLayout" Margin="2">
                                                                    <Items>
                                                                        <ext:CycleButton ID="CycleButton5" runat="server" ShowText="true" Width="48" ForceIcon="#Magnifier">
                                                                            <Menu>
                                                                                <ext:Menu ID="Menu5" runat="server">
                                                                                    <Items>
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem21" runat="server" Text="=" ToolTip="Equals" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem22" runat="server" Text="+" ToolTip="Starts with" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem23" runat="server" Text="-" ToolTip="Ends with" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem24" runat="server" Text="*" Checked="true" ToolTip="Contains" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem25" runat="server" Text="!" ToolTip="Doesn't contain" />
                                                                                    </Items>
                                                                                </ext:Menu>
                                                                            </Menu>
                                                                            <Listeners>
                                                                                <Change Handler="this.up('grid').filterHeader.onFieldChange(this.up('container'));" />
                                                                            </Listeners>
                                                                        </ext:CycleButton>

                                                                        <ext:TextField ID="TextField5" runat="server" Flex="1">
                                                                            <Plugins>
                                                                                <ext:ClearButton ID="ClearButton5" runat="server" />
                                                                            </Plugins>
                                                                            <Listeners>
                                                                                <Change Handler="this.up('grid').filterHeader.onFieldChange(this.up('container'));" />
                                                                            </Listeners>
                                                                        </ext:TextField>
                                                                    </Items>
                                                                    <CustomConfig>
                                                                        <ext:ConfigItem Name="getValue" Value="getCompanyValue" Mode="Raw" />
                                                                    </CustomConfig>
                                                                </ext:Container>
                                                            </HeaderItems>
                                                        </ext:Column>
                                                        <ext:Column ID="Column6" runat="server" Text="Partner ID" Width="150" DataIndex="PartnerID">
                                                            <HeaderItems>
                                                                <ext:Container ID="Container6" runat="server" Layout="HBoxLayout" Margin="2">
                                                                    <Items>
                                                                        <ext:CycleButton ID="CycleButton6" runat="server" ShowText="true" Width="48" ForceIcon="#Magnifier">
                                                                            <Menu>
                                                                                <ext:Menu ID="Menu6" runat="server">
                                                                                    <Items>
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem26" runat="server" Text="=" ToolTip="Equals" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem27" runat="server" Text="+" ToolTip="Starts with" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem28" runat="server" Text="-" ToolTip="Ends with" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem29" runat="server" Text="*" Checked="true" ToolTip="Contains" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem30" runat="server" Text="!" ToolTip="Doesn't contain" />
                                                                                    </Items>
                                                                                </ext:Menu>
                                                                            </Menu>
                                                                            <Listeners>
                                                                                <Change Handler="this.up('grid').filterHeader.onFieldChange(this.up('container'));" />
                                                                            </Listeners>
                                                                        </ext:CycleButton>

                                                                        <ext:TextField ID="TextField6" runat="server" Flex="1">
                                                                            <Plugins>
                                                                                <ext:ClearButton ID="ClearButton6" runat="server" />
                                                                            </Plugins>
                                                                            <Listeners>
                                                                                <Change Handler="this.up('grid').filterHeader.onFieldChange(this.up('container'));" />
                                                                            </Listeners>
                                                                        </ext:TextField>
                                                                    </Items>
                                                                    <CustomConfig>
                                                                        <ext:ConfigItem Name="getValue" Value="getCompanyValue" Mode="Raw" />
                                                                    </CustomConfig>
                                                                </ext:Container>
                                                            </HeaderItems>
                                                        </ext:Column>
                                                        <ext:Column ID="Column7" runat="server" Text="Delivery Mode" Width="120" DataIndex="DeliveryMode">
                                                            <HeaderItems>
                                                                <ext:Container ID="Container7" runat="server" Layout="HBoxLayout" Margin="2">
                                                                    <Items>
                                                                        <ext:CycleButton ID="CycleButton7" runat="server" ShowText="true" Width="48" ForceIcon="#Magnifier">
                                                                            <Menu>
                                                                                <ext:Menu ID="Menu7" runat="server">
                                                                                    <Items>
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem31" runat="server" Text="=" ToolTip="Equals" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem32" runat="server" Text="+" ToolTip="Starts with" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem33" runat="server" Text="-" ToolTip="Ends with" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem34" runat="server" Text="*" Checked="true" ToolTip="Contains" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem35" runat="server" Text="!" ToolTip="Doesn't contain" />
                                                                                    </Items>
                                                                                </ext:Menu>
                                                                            </Menu>
                                                                            <Listeners>
                                                                                <Change Handler="this.up('grid').filterHeader.onFieldChange(this.up('container'));" />
                                                                            </Listeners>
                                                                        </ext:CycleButton>

                                                                        <ext:TextField ID="TextField7" runat="server" Flex="1">
                                                                            <Plugins>
                                                                                <ext:ClearButton ID="ClearButton7" runat="server" />
                                                                            </Plugins>
                                                                            <Listeners>
                                                                                <Change Handler="this.up('grid').filterHeader.onFieldChange(this.up('container'));" />
                                                                            </Listeners>
                                                                        </ext:TextField>
                                                                    </Items>
                                                                    <CustomConfig>
                                                                        <ext:ConfigItem Name="getValue" Value="getCompanyValue" Mode="Raw" />
                                                                    </CustomConfig>
                                                                </ext:Container>
                                                            </HeaderItems>
                                                        </ext:Column>
                                                        <ext:Column ID="Column8" runat="server" Text="Carrier" Width="120" DataIndex="Carrier">
                                                            <HeaderItems>
                                                                <ext:Container ID="Container8" runat="server" Layout="HBoxLayout" Margin="2">
                                                                    <Items>
                                                                        <ext:CycleButton ID="CycleButton8" runat="server" ShowText="true" Width="48" ForceIcon="#Magnifier">
                                                                            <Menu>
                                                                                <ext:Menu ID="Menu8" runat="server">
                                                                                    <Items>
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem36" runat="server" Text="=" ToolTip="Equals" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem37" runat="server" Text="+" ToolTip="Starts with" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem38" runat="server" Text="-" ToolTip="Ends with" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem39" runat="server" Text="*" Checked="true" ToolTip="Contains" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem40" runat="server" Text="!" ToolTip="Doesn't contain" />
                                                                                    </Items>
                                                                                </ext:Menu>
                                                                            </Menu>
                                                                            <Listeners>
                                                                                <Change Handler="this.up('grid').filterHeader.onFieldChange(this.up('container'));" />
                                                                            </Listeners>
                                                                        </ext:CycleButton>

                                                                        <ext:TextField ID="TextField8" runat="server" Flex="1">
                                                                            <Plugins>
                                                                                <ext:ClearButton ID="ClearButton8" runat="server" />
                                                                            </Plugins>
                                                                            <Listeners>
                                                                                <Change Handler="this.up('grid').filterHeader.onFieldChange(this.up('container'));" />
                                                                            </Listeners>
                                                                        </ext:TextField>
                                                                    </Items>
                                                                    <CustomConfig>
                                                                        <ext:ConfigItem Name="getValue" Value="getCompanyValue" Mode="Raw" />
                                                                    </CustomConfig>
                                                                </ext:Container>
                                                            </HeaderItems>
                                                        </ext:Column>
                                                        <ext:Column ID="Column10" runat="server" Text="Expected Date" Width="120" DataIndex="ExpectedShipDate">
                                                            <HeaderItems>
                                                                <ext:Container ID="Container10" runat="server" Layout="HBoxLayout" Margin="2">
                                                                    <Items>
                                                                        <ext:CycleButton ID="CycleButton10" runat="server" ShowText="true" Width="48" ForceIcon="#Magnifier">
                                                                            <Menu>
                                                                                <ext:Menu ID="Menu10" runat="server">
                                                                                    <Items>
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem46" runat="server" Text="=" ToolTip="Equals" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem47" runat="server" Text="+" ToolTip="Starts with" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem48" runat="server" Text="-" ToolTip="Ends with" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem49" runat="server" Text="*" Checked="true" ToolTip="Contains" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem50" runat="server" Text="!" ToolTip="Doesn't contain" />
                                                                                    </Items>
                                                                                </ext:Menu>
                                                                            </Menu>
                                                                            <Listeners>
                                                                                <Change Handler="this.up('grid').filterHeader.onFieldChange(this.up('container'));" />
                                                                            </Listeners>
                                                                        </ext:CycleButton>

                                                                        <ext:TextField ID="TextField10" runat="server" Flex="1">
                                                                            <Plugins>
                                                                                <ext:ClearButton ID="ClearButton10" runat="server" />
                                                                            </Plugins>
                                                                            <Listeners>
                                                                                <Change Handler="this.up('grid').filterHeader.onFieldChange(this.up('container'));" />
                                                                            </Listeners>
                                                                        </ext:TextField>
                                                                    </Items>
                                                                    <CustomConfig>
                                                                        <ext:ConfigItem Name="getValue" Value="getCompanyValue" Mode="Raw" />
                                                                    </CustomConfig>
                                                                </ext:Container>
                                                            </HeaderItems>
                                                        </ext:Column>
                                                        <ext:Column ID="Column11" runat="server" Text="Shipment Status" Width="260" DataIndex="ShipmentStatus">
                                                            <HeaderItems>
                                                                <ext:ComboBox ID="ComboBox2"
                                                                    runat="server"
                                                                    Width="250"
                                                                    Editable="false"
                                                                    DisplayField="Status"
                                                                    QueryMode="Local"
                                                                    ForceSelection="true"
                                                                    TriggerAction="All"
                                                                    EmptyText="Select a Status...">
                                                                    <Store>
                                                                        <ext:Store ID="Store4" runat="server">
                                                                            <Model>
                                                                                <ext:Model ID="Model4" runat="server">
                                                                                    <Fields>
                                                                                        <ext:ModelField Name="Status" />
                                                                                    </Fields>
                                                                                </ext:Model>
                                                                            </Model>
                                                                        </ext:Store>
                                                                    </Store>
                                                                    <ListConfig>
                                                                        <ItemTpl ID="ItemTpl2" runat="server">
                                                                            <Html>
                                                                                <div class="list-item">
							                                                   <h3>{Status}</h3>
                                                                            </div>
                                                                            </Html>
                                                                        </ItemTpl>
                                                                    </ListConfig>
                                                                    <Listeners>
                                                                        <Change Handler="this.up('grid').filterHeader.onFieldChange(this.up('container'));" />
                                                                    </Listeners>
                                                                </ext:ComboBox>
                                                            </HeaderItems>
                                                            <%-- <HeaderItems>
                                                                <ext:Container ID="Container11" runat="server" Layout="HBoxLayout" Margin="2">
                                                                    <Items>
                                                                        <ext:CycleButton ID="CycleButton11" runat="server" ShowText="true" Width="48" ForceIcon="#Magnifier">
                                                                            <Menu>
                                                                                <ext:Menu ID="Menu11" runat="server">
                                                                                    <Items>
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem51" runat="server" Text="=" ToolTip="Equals" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem52" runat="server" Text="+" ToolTip="Starts with" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem53" runat="server" Text="-" ToolTip="Ends with" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem54" runat="server" Text="*" Checked="true" ToolTip="Contains" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem55" runat="server" Text="!" ToolTip="Doesn't contain" />
                                                                                    </Items>
                                                                                </ext:Menu>
                                                                            </Menu>
                                                                            <Listeners>
                                                                                <Change Handler="this.up('grid').filterHeader.onFieldChange(this.up('container'));" />
                                                                            </Listeners>
                                                                        </ext:CycleButton>

                                                                        <ext:TextField ID="TextField11" runat="server" Flex="1">
                                                                            <Plugins>
                                                                                <ext:ClearButton ID="ClearButton11" runat="server" />
                                                                            </Plugins>
                                                                            <Listeners>
                                                                                <Change Handler="this.up('grid').filterHeader.onFieldChange(this.up('container'));" />
                                                                            </Listeners>
                                                                        </ext:TextField>
                                                                    </Items>
                                                                    <CustomConfig>
                                                                        <ext:ConfigItem Name="getValue" Value="getCompanyValue" Mode="Raw" />
                                                                    </CustomConfig>
                                                                </ext:Container>
                                                            </HeaderItems>--%>
                                                        </ext:Column>

                                                    </Columns>
                                                </ColumnModel>
                                                 <View>
                                                    <ext:GridView ID="GridView2" runat="server" StripeRows="true">
                                                        <GetRowClass Fn="getRowClass" />
                                                    </ext:GridView>
                                                </View>
                                                <Plugins>
                                                    <ext:FilterHeader ID="FilterHeader1" runat="server" />
                                                </Plugins>
                                                <BottomBar>
                                                    <ext:PagingToolbar ID="PagingToolbar1" runat="server">
                                                        <Items>
                                                            <%--<ext:Label ID="Label1" runat="server" Text="Page size:" />--%>
                                                            <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" Width="10" />
                                                        </Items>
                                                        <Plugins>
                                                            <ext:ProgressBarPager ID="ProgressBarPager1" runat="server" />
                                                        </Plugins>
                                                    </ext:PagingToolbar>
                                                </BottomBar>
                                            </ext:GridPanel>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div>
                                            <ext:FieldSet ID="FieldSet1" runat="server" Title="Tracking Status Board" Style="font-size: larger" Layout="AnchorLayout" DefaultAnchor="400%">
                                                <Items>
                                                    <ext:FieldContainer ID="fieldContainer1" runat="server" FieldLabel="Name" Layout="HBoxLayout" CombineErrors="true">
                                                        <FieldDefaults HideLabel="true" />
                                                        <Items>
                                                            <ext:Label runat="server" Text="" ID="lblForTracking" Style="color: red"></ext:Label>
                                                        </Items>
                                                    </ext:FieldContainer>
                                                </Items>
                                            </ext:FieldSet>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div id="divForGrid2" style="height: auto; width: auto; overflow: scroll" onscroll="SetDivPosition()">
                                            <ext:GridPanel
                                                ID="GridPanel2"
                                                runat="server"
                                                Title="Tracking Detail's"
                                                Width="1550"
                                                UI="Danger">
                                                <Store>
                                                    <ext:Store ID="Store2" runat="server" OnReadData="Store2_Refresh" PageSize="5">
                                                        <Model>
                                                            <ext:Model ID="Model2" runat="server" IDProperty="BOXNUM">
                                                                <Fields>
                                                                    <ext:ModelField Name="BOXNUM" Type="String" />
                                                                    <ext:ModelField Name="TrackingNumber" Type="String" />
                                                                    <ext:ModelField Name="BoxLocation" Type="String" />
                                                                    <ext:ModelField Name="Status" Type="String" />
                                                                    <ext:ModelField Name="Heights" Type="String" />
                                                                    <ext:ModelField Name="Lengths" Type="String" />
                                                                    <ext:ModelField Name="Widths" Type="String" />
                                                                    <ext:ModelField Name="Weights" Type="String" />
                                                                    <ext:ModelField Name="FreightCharges" Type="String" />
                                                                    <ext:ModelField Name="Carrier" Type="String" />
                                                                    <ext:ModelField Name="Date" Type="String" />


                                                                </Fields>
                                                            </ext:Model>
                                                        </Model>
                                                    </ext:Store>
                                                </Store>
                                                <ViewConfig EnableTextSelection="true"></ViewConfig>

                                                <ColumnModel ID="ColumnModel3" runat="server" UI="Primary">
                                                    <Columns>
                                                        <ext:RowNumbererColumn ID="RowNumbererColumn3" runat="server" Width="30" />

                                                        <%--  <ext:CommandColumn ID="CommandColumn2" Width="60" runat="server" Filterable="false">
                                                            <Commands>

                                                                <ext:GridCommand CommandName="Select" Text="Select" />

                                                            </Commands>
                                                            <Listeners>
                                                                <Command Handler="Ext.net.Mask.show({ msg : 'Loading Please wait...' }); CompanyX.DoSomethingforGridPanel3();  App.direct.GridPanel3_SelectedIndexChanged(record.data.BOXNUM)" />
                                                            </Listeners>

                                                        </ext:CommandColumn>--%>
                                                        <ext:Column ID="Column19" runat="server" Text="Box Number" DataIndex="BOXNUM" Width="200" Filterable="false">
                                                            <HeaderItems>
                                                                <ext:Container ID="Container19" runat="server" Layout="HBoxLayout" Margin="2">
                                                                    <Items>
                                                                        <ext:CycleButton ID="CycleButton19" runat="server" ShowText="true" Width="48" ForceIcon="#Magnifier">
                                                                            <Menu>
                                                                                <ext:Menu ID="Menu19" runat="server">
                                                                                    <Items>
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem91" runat="server" Text="=" ToolTip="Equals" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem92" runat="server" Text="+" ToolTip="Starts with" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem93" runat="server" Text="-" ToolTip="Ends with" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem94" runat="server" Text="*" Checked="true" ToolTip="Contains" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem95" runat="server" Text="!" ToolTip="Doesn't contain" />
                                                                                    </Items>
                                                                                </ext:Menu>
                                                                            </Menu>
                                                                            <Listeners>
                                                                                <Change Handler="this.up('grid').filterHeader.onFieldChange(this.up('container'));" />
                                                                            </Listeners>
                                                                        </ext:CycleButton>

                                                                        <ext:TextField ID="TextField19" runat="server" Flex="1">
                                                                            <Plugins>
                                                                                <ext:ClearButton ID="ClearButton19" runat="server" />
                                                                            </Plugins>
                                                                            <Listeners>
                                                                                <Change Handler="this.up('grid').filterHeader.onFieldChange(this.up('container'));" />
                                                                            </Listeners>
                                                                        </ext:TextField>
                                                                    </Items>
                                                                    <CustomConfig>
                                                                        <ext:ConfigItem Name="getValue" Value="getCompanyValue" Mode="Raw" />
                                                                    </CustomConfig>
                                                                </ext:Container>
                                                            </HeaderItems>
                                                        </ext:Column>
                                                        <ext:Column ID="Column25" runat="server" Text="Tracking Number" Width="220" DataIndex="TrackingNumber">
                                                            <HeaderItems>
                                                                <ext:Container ID="Container25" runat="server" Layout="HBoxLayout" Margin="2">
                                                                    <Items>
                                                                        <ext:CycleButton ID="CycleButton25" runat="server" ShowText="true" Width="48" ForceIcon="#Magnifier">
                                                                            <Menu>
                                                                                <ext:Menu ID="Menu25" runat="server">
                                                                                    <Items>
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem121" runat="server" Text="=" ToolTip="Equals" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem122" runat="server" Text="+" ToolTip="Starts with" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem123" runat="server" Text="-" ToolTip="Ends with" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem124" runat="server" Text="*" Checked="true" ToolTip="Contains" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem125" runat="server" Text="!" ToolTip="Doesn't contain" />
                                                                                    </Items>
                                                                                </ext:Menu>
                                                                            </Menu>
                                                                            <Listeners>
                                                                                <Change Handler="this.up('grid').filterHeader.onFieldChange(this.up('container'));" />
                                                                            </Listeners>
                                                                        </ext:CycleButton>

                                                                        <ext:TextField ID="TextField25" runat="server" Flex="1">
                                                                            <Plugins>
                                                                                <ext:ClearButton ID="ClearButton25" runat="server" />
                                                                            </Plugins>
                                                                            <Listeners>
                                                                                <Change Handler="this.up('grid').filterHeader.onFieldChange(this.up('container'));" />
                                                                            </Listeners>
                                                                        </ext:TextField>
                                                                    </Items>
                                                                    <CustomConfig>
                                                                        <ext:ConfigItem Name="getValue" Value="getCompanyValue" Mode="Raw" />
                                                                    </CustomConfig>
                                                                </ext:Container>
                                                            </HeaderItems>
                                                        </ext:Column>
                                                        <ext:Column ID="Column12" runat="server" Text="Location" Width="150" DataIndex="BoxLocation">
                                                            <HeaderItems>
                                                                <ext:Container ID="Container12" runat="server" Layout="HBoxLayout" Margin="2">
                                                                    <Items>
                                                                        <ext:CycleButton ID="CycleButton12" runat="server" ShowText="true" Width="48" ForceIcon="#Magnifier">
                                                                            <Menu>
                                                                                <ext:Menu ID="Menu12" runat="server">
                                                                                    <Items>
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem56" runat="server" Text="=" ToolTip="Equals" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem57" runat="server" Text="+" ToolTip="Starts with" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem58" runat="server" Text="-" ToolTip="Ends with" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem59" runat="server" Text="*" Checked="true" ToolTip="Contains" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem60" runat="server" Text="!" ToolTip="Doesn't contain" />
                                                                                    </Items>
                                                                                </ext:Menu>
                                                                            </Menu>
                                                                            <Listeners>
                                                                                <Change Handler="this.up('grid').filterHeader.onFieldChange(this.up('container'));" />
                                                                            </Listeners>
                                                                        </ext:CycleButton>

                                                                        <ext:TextField ID="TextField12" runat="server" Flex="1">
                                                                            <Plugins>
                                                                                <ext:ClearButton ID="ClearButton12" runat="server" />
                                                                            </Plugins>
                                                                            <Listeners>
                                                                                <Change Handler="this.up('grid').filterHeader.onFieldChange(this.up('container'));" />
                                                                            </Listeners>
                                                                        </ext:TextField>
                                                                    </Items>
                                                                    <CustomConfig>
                                                                        <ext:ConfigItem Name="getValue" Value="getCompanyValue" Mode="Raw" />
                                                                    </CustomConfig>
                                                                </ext:Container>
                                                            </HeaderItems>
                                                        </ext:Column>
                                                        <ext:Column ID="Column9" runat="server" Text="Box Status" Width="150" DataIndex="Status">
                                                            <HeaderItems>
                                                                <ext:Container ID="Container9" runat="server" Layout="HBoxLayout" Margin="2">
                                                                    <Items>
                                                                        <ext:CycleButton ID="CycleButton9" runat="server" ShowText="true" Width="48" ForceIcon="#Magnifier">
                                                                            <Menu>
                                                                                <ext:Menu ID="Menu9" runat="server">
                                                                                    <Items>
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem41" runat="server" Text="=" ToolTip="Equals" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem42" runat="server" Text="+" ToolTip="Starts with" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem43" runat="server" Text="-" ToolTip="Ends with" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem44" runat="server" Text="*" Checked="true" ToolTip="Contains" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem45" runat="server" Text="!" ToolTip="Doesn't contain" />
                                                                                    </Items>
                                                                                </ext:Menu>
                                                                            </Menu>
                                                                            <Listeners>
                                                                                <Change Handler="this.up('grid').filterHeader.onFieldChange(this.up('container'));" />
                                                                            </Listeners>
                                                                        </ext:CycleButton>

                                                                        <ext:TextField ID="TextField9" runat="server" Flex="1">
                                                                            <Plugins>
                                                                                <ext:ClearButton ID="ClearButton9" runat="server" />
                                                                            </Plugins>
                                                                            <Listeners>
                                                                                <Change Handler="this.up('grid').filterHeader.onFieldChange(this.up('container'));" />
                                                                            </Listeners>
                                                                        </ext:TextField>
                                                                    </Items>
                                                                    <CustomConfig>
                                                                        <ext:ConfigItem Name="getValue" Value="getCompanyValue" Mode="Raw" />
                                                                    </CustomConfig>
                                                                </ext:Container>
                                                            </HeaderItems>
                                                        </ext:Column>
                                                        <ext:Column ID="Column13" runat="server" Text="Box Height" DataIndex="Heights" Width="100" Filterable="false">
                                                            <HeaderItems>
                                                                <ext:Container ID="Container13" runat="server" Layout="HBoxLayout" Margin="2">
                                                                    <Items>
                                                                        <ext:CycleButton ID="CycleButton13" runat="server" ShowText="true" Width="48" ForceIcon="#Magnifier">
                                                                            <Menu>
                                                                                <ext:Menu ID="Menu13" runat="server">
                                                                                    <Items>
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem61" runat="server" Text="=" ToolTip="Equals" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem62" runat="server" Text="+" ToolTip="Starts with" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem63" runat="server" Text="-" ToolTip="Ends with" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem64" runat="server" Text="*" Checked="true" ToolTip="Contains" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem65" runat="server" Text="!" ToolTip="Doesn't contain" />
                                                                                    </Items>
                                                                                </ext:Menu>
                                                                            </Menu>
                                                                            <Listeners>
                                                                                <Change Handler="this.up('grid').filterHeader.onFieldChange(this.up('container'));" />
                                                                            </Listeners>
                                                                        </ext:CycleButton>

                                                                        <ext:TextField ID="TextField13" runat="server" Flex="1">
                                                                            <Plugins>
                                                                                <ext:ClearButton ID="ClearButton13" runat="server" />
                                                                            </Plugins>
                                                                            <Listeners>
                                                                                <Change Handler="this.up('grid').filterHeader.onFieldChange(this.up('container'));" />
                                                                            </Listeners>
                                                                        </ext:TextField>
                                                                    </Items>
                                                                    <CustomConfig>
                                                                        <ext:ConfigItem Name="getValue" Value="getCompanyValue" Mode="Raw" />
                                                                    </CustomConfig>
                                                                </ext:Container>
                                                            </HeaderItems>
                                                        </ext:Column>
                                                        <ext:Column ID="Column14" runat="server" Text="Box Length" Width="100" DataIndex="Lengths">
                                                            <HeaderItems>
                                                                <ext:Container ID="Container14" runat="server" Layout="HBoxLayout" Margin="2">
                                                                    <Items>
                                                                        <ext:CycleButton ID="CycleButton14" runat="server" ShowText="true" Width="48" ForceIcon="#Magnifier">
                                                                            <Menu>
                                                                                <ext:Menu ID="Menu14" runat="server">
                                                                                    <Items>
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem66" runat="server" Text="=" ToolTip="Equals" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem67" runat="server" Text="+" ToolTip="Starts with" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem68" runat="server" Text="-" ToolTip="Ends with" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem69" runat="server" Text="*" Checked="true" ToolTip="Contains" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem70" runat="server" Text="!" ToolTip="Doesn't contain" />
                                                                                    </Items>
                                                                                </ext:Menu>
                                                                            </Menu>
                                                                            <Listeners>
                                                                                <Change Handler="this.up('grid').filterHeader.onFieldChange(this.up('container'));" />
                                                                            </Listeners>
                                                                        </ext:CycleButton>

                                                                        <ext:TextField ID="TextField14" runat="server" Flex="1">
                                                                            <Plugins>
                                                                                <ext:ClearButton ID="ClearButton14" runat="server" />
                                                                            </Plugins>
                                                                            <Listeners>
                                                                                <Change Handler="this.up('grid').filterHeader.onFieldChange(this.up('container'));" />
                                                                            </Listeners>
                                                                        </ext:TextField>
                                                                    </Items>
                                                                    <CustomConfig>
                                                                        <ext:ConfigItem Name="getValue" Value="getCompanyValue" Mode="Raw" />
                                                                    </CustomConfig>
                                                                </ext:Container>
                                                            </HeaderItems>
                                                        </ext:Column>
                                                        <ext:Column ID="Column15" runat="server" Text="Box Width" DataIndex="Widths" Width="100" Filterable="false">
                                                            <HeaderItems>
                                                                <ext:Container ID="Container15" runat="server" Layout="HBoxLayout" Margin="2">
                                                                    <Items>
                                                                        <ext:CycleButton ID="CycleButton15" runat="server" ShowText="true" Width="48" ForceIcon="#Magnifier">
                                                                            <Menu>
                                                                                <ext:Menu ID="Menu15" runat="server">
                                                                                    <Items>
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem71" runat="server" Text="=" ToolTip="Equals" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem72" runat="server" Text="+" ToolTip="Starts with" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem73" runat="server" Text="-" ToolTip="Ends with" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem74" runat="server" Text="*" Checked="true" ToolTip="Contains" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem75" runat="server" Text="!" ToolTip="Doesn't contain" />
                                                                                    </Items>
                                                                                </ext:Menu>
                                                                            </Menu>
                                                                            <Listeners>
                                                                                <Change Handler="this.up('grid').filterHeader.onFieldChange(this.up('container'));" />
                                                                            </Listeners>
                                                                        </ext:CycleButton>

                                                                        <ext:TextField ID="TextField15" runat="server" Flex="1">
                                                                            <Plugins>
                                                                                <ext:ClearButton ID="ClearButton15" runat="server" />
                                                                            </Plugins>
                                                                            <Listeners>
                                                                                <Change Handler="this.up('grid').filterHeader.onFieldChange(this.up('container'));" />
                                                                            </Listeners>
                                                                        </ext:TextField>
                                                                    </Items>
                                                                    <CustomConfig>
                                                                        <ext:ConfigItem Name="getValue" Value="getCompanyValue" Mode="Raw" />
                                                                    </CustomConfig>
                                                                </ext:Container>
                                                            </HeaderItems>
                                                        </ext:Column>
                                                        <ext:Column ID="Column16" runat="server" Text="Box Weight" Width="100" DataIndex="Weights">
                                                            <HeaderItems>
                                                                <ext:Container ID="Container16" runat="server" Layout="HBoxLayout" Margin="2">
                                                                    <Items>
                                                                        <ext:CycleButton ID="CycleButton16" runat="server" ShowText="true" Width="48" ForceIcon="#Magnifier">
                                                                            <Menu>
                                                                                <ext:Menu ID="Menu16" runat="server">
                                                                                    <Items>
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem76" runat="server" Text="=" ToolTip="Equals" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem77" runat="server" Text="+" ToolTip="Starts with" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem78" runat="server" Text="-" ToolTip="Ends with" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem79" runat="server" Text="*" Checked="true" ToolTip="Contains" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem80" runat="server" Text="!" ToolTip="Doesn't contain" />
                                                                                    </Items>
                                                                                </ext:Menu>
                                                                            </Menu>
                                                                            <Listeners>
                                                                                <Change Handler="this.up('grid').filterHeader.onFieldChange(this.up('container'));" />
                                                                            </Listeners>
                                                                        </ext:CycleButton>

                                                                        <ext:TextField ID="TextField16" runat="server" Flex="1">
                                                                            <Plugins>
                                                                                <ext:ClearButton ID="ClearButton16" runat="server" />
                                                                            </Plugins>
                                                                            <Listeners>
                                                                                <Change Handler="this.up('grid').filterHeader.onFieldChange(this.up('container'));" />
                                                                            </Listeners>
                                                                        </ext:TextField>
                                                                    </Items>
                                                                    <CustomConfig>
                                                                        <ext:ConfigItem Name="getValue" Value="getCompanyValue" Mode="Raw" />
                                                                    </CustomConfig>
                                                                </ext:Container>
                                                            </HeaderItems>
                                                        </ext:Column>
                                                        <ext:Column ID="Column17" runat="server" Text="Freight Charges" DataIndex="FreightCharges" Width="100" Filterable="false">
                                                            <HeaderItems>
                                                                <ext:Container ID="Container17" runat="server" Layout="HBoxLayout" Margin="2">
                                                                    <Items>
                                                                        <ext:CycleButton ID="CycleButton17" runat="server" ShowText="true" Width="48" ForceIcon="#Magnifier">
                                                                            <Menu>
                                                                                <ext:Menu ID="Menu17" runat="server">
                                                                                    <Items>
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem81" runat="server" Text="=" ToolTip="Equals" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem82" runat="server" Text="+" ToolTip="Starts with" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem83" runat="server" Text="-" ToolTip="Ends with" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem84" runat="server" Text="*" Checked="true" ToolTip="Contains" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem85" runat="server" Text="!" ToolTip="Doesn't contain" />
                                                                                    </Items>
                                                                                </ext:Menu>
                                                                            </Menu>
                                                                            <Listeners>
                                                                                <Change Handler="this.up('grid').filterHeader.onFieldChange(this.up('container'));" />
                                                                            </Listeners>
                                                                        </ext:CycleButton>

                                                                        <ext:TextField ID="TextField17" runat="server" Flex="1">
                                                                            <Plugins>
                                                                                <ext:ClearButton ID="ClearButton17" runat="server" />
                                                                            </Plugins>
                                                                            <Listeners>
                                                                                <Change Handler="this.up('grid').filterHeader.onFieldChange(this.up('container'));" />
                                                                            </Listeners>
                                                                        </ext:TextField>
                                                                    </Items>
                                                                    <CustomConfig>
                                                                        <ext:ConfigItem Name="getValue" Value="getCompanyValue" Mode="Raw" />
                                                                    </CustomConfig>
                                                                </ext:Container>
                                                            </HeaderItems>
                                                        </ext:Column>
                                                        <ext:Column ID="Column18" runat="server" Text="Carrier" Width="150" DataIndex="Carrier">
                                                            <HeaderItems>
                                                                <ext:Container ID="Container18" runat="server" Layout="HBoxLayout" Margin="2">
                                                                    <Items>
                                                                        <ext:CycleButton ID="CycleButton18" runat="server" ShowText="true" Width="48" ForceIcon="#Magnifier">
                                                                            <Menu>
                                                                                <ext:Menu ID="Menu18" runat="server">
                                                                                    <Items>
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem86" runat="server" Text="=" ToolTip="Equals" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem87" runat="server" Text="+" ToolTip="Starts with" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem88" runat="server" Text="-" ToolTip="Ends with" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem89" runat="server" Text="*" Checked="true" ToolTip="Contains" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem90" runat="server" Text="!" ToolTip="Doesn't contain" />
                                                                                    </Items>
                                                                                </ext:Menu>
                                                                            </Menu>
                                                                            <Listeners>
                                                                                <Change Handler="this.up('grid').filterHeader.onFieldChange(this.up('container'));" />
                                                                            </Listeners>
                                                                        </ext:CycleButton>

                                                                        <ext:TextField ID="TextField18" runat="server" Flex="1">
                                                                            <Plugins>
                                                                                <ext:ClearButton ID="ClearButton18" runat="server" />
                                                                            </Plugins>
                                                                            <Listeners>
                                                                                <Change Handler="this.up('grid').filterHeader.onFieldChange(this.up('container'));" />
                                                                            </Listeners>
                                                                        </ext:TextField>
                                                                    </Items>
                                                                    <CustomConfig>
                                                                        <ext:ConfigItem Name="getValue" Value="getCompanyValue" Mode="Raw" />
                                                                    </CustomConfig>
                                                                </ext:Container>
                                                            </HeaderItems>
                                                        </ext:Column>
                                                        <ext:Column ID="Column24" runat="server" Text="Shipping Date" Width="150" DataIndex="Date">
                                                            <HeaderItems>
                                                                <ext:Container ID="Container24" runat="server" Layout="HBoxLayout" Margin="2">
                                                                    <Items>
                                                                        <ext:CycleButton ID="CycleButton24" runat="server" ShowText="true" Width="48" ForceIcon="#Magnifier">
                                                                            <Menu>
                                                                                <ext:Menu ID="Menu24" runat="server">
                                                                                    <Items>
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem116" runat="server" Text="=" ToolTip="Equals" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem117" runat="server" Text="+" ToolTip="Starts with" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem118" runat="server" Text="-" ToolTip="Ends with" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem119" runat="server" Text="*" Checked="true" ToolTip="Contains" />
                                                                                        <ext:CheckMenuItem ID="CheckMenuItem120" runat="server" Text="!" ToolTip="Doesn't contain" />
                                                                                    </Items>
                                                                                </ext:Menu>
                                                                            </Menu>
                                                                            <Listeners>
                                                                                <Change Handler="this.up('grid').filterHeader.onFieldChange(this.up('container'));" />
                                                                            </Listeners>
                                                                        </ext:CycleButton>

                                                                        <ext:TextField ID="TextField24" runat="server" Flex="1">
                                                                            <Plugins>
                                                                                <ext:ClearButton ID="ClearButton24" runat="server" />
                                                                            </Plugins>
                                                                            <Listeners>
                                                                                <Change Handler="this.up('grid').filterHeader.onFieldChange(this.up('container'));" />
                                                                            </Listeners>
                                                                        </ext:TextField>
                                                                    </Items>
                                                                    <CustomConfig>
                                                                        <ext:ConfigItem Name="getValue" Value="getCompanyValue" Mode="Raw" />
                                                                    </CustomConfig>
                                                                </ext:Container>
                                                            </HeaderItems>
                                                        </ext:Column>


                                                    </Columns>
                                                </ColumnModel>
                                                <%--  <TopBar>
                                                    <ext:Toolbar ID="Toolbar2" runat="server">
                                                        <Items>
                                                            <ext:Label ID="lblBoxDetailFor" runat="server" Text="">
                                                            </ext:Label>
                                                            <ext:Label ID="lblpdShipNumSelected" runat="server" Text="">
                                                            </ext:Label>
                                                        </Items>
                                                    </ext:Toolbar>
                                                </TopBar>--%>
                                               <%-- <View>
                                                    <ext:GridView ID="GridView2" runat="server" StripeRows="true">
                                                        <GetRowClass Fn="getRowClass" />
                                                    </ext:GridView>
                                                </View>--%>
                                                <Plugins>
                                                    <ext:FilterHeader ID="FilterHeader3" runat="server" />
                                                </Plugins>
                                                <BottomBar>
                                                    <ext:PagingToolbar ID="PagingToolbar3" runat="server">
                                                        <Items>
                                                            <%--<ext:Label ID="Label1" runat="server" Text="Page size:" />--%>
                                                            <ext:ToolbarSpacer ID="ToolbarSpacer3" runat="server" Width="10" />
                                                        </Items>
                                                        <Plugins>
                                                            <ext:ProgressBarPager ID="ProgressBarPager3" runat="server" />
                                                        </Plugins>
                                                    </ext:PagingToolbar>
                                                </BottomBar>
                                            </ext:GridPanel>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
        </form>
    </body>
    </html>
</asp:Content>

