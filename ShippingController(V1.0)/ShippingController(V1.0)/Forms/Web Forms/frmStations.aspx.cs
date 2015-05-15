using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PackingClassLibrary.CustomEntity.ReportEntitys;
using ShippingController_V1._0_.Models;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;



namespace ShippingController_V1._0_.Forms.Web_Forms
{
    public partial class frmStations : System.Web.UI.Page
    {

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

        protected void Page_Load(object sender, EventArgs e)
        {
            SetGraph();
        }

        public void SetGraph()
        {
            List<cstStationToatlPacked> _lsTotalPacekedPerStation = Obj.Rcall.GetStationTotalPaked();

            gvStationInfo.DataSource = _lsTotalPacekedPerStation.ToList();
            gvStationInfo.DataBind();

           Series[] sr = new Series[_lsTotalPacekedPerStation.Count];
                     
           // chart Veriables
            String[] StationNames= new string[_lsTotalPacekedPerStation.Count];

            for (int i = 0; i < _lsTotalPacekedPerStation.Count; i++)
            {
                sr[i] = new Series { Name = _lsTotalPacekedPerStation[i].StationName, Data = new Data(new object[] { _lsTotalPacekedPerStation[i].TotalPacked, _lsTotalPacekedPerStation[i].PartiallyPacked}) };
            }

            DotNet.Highcharts.Highcharts chart = new DotNet.Highcharts.Highcharts("Chart")
            .InitChart(new DotNet.Highcharts.Options.Chart
            {
                Type = ChartTypes.Bar,
                BackgroundColor = new BackColorOrGradient(System.Drawing.Color.White),
                Height=400,
               

            })
            .SetXAxis(new DotNet.Highcharts.Options.XAxis
            {

                Categories = (new string[]{"Packed","Partially Packed"}),
                Title = new XAxisTitle { Text = "Packi", Style = "fontSize: '15px', fontFamily: 'Verdana', color: 'Black'" }

            })
             .SetTitle(new Title
             {
                 Text = "Station Information ",
                 Style = "fontSize: '30px',fontFamily: 'Verdana', fontBold: 'true', color: 'Black' "
             })
             .SetYAxis(new YAxis
             {
                 Title = new YAxisTitle { Text = "Staion Names", Style = "fontSize: '15px', fontFamily: 'Verdana', color: 'Black'" },
             })
             .SetSeries(sr);
            
            ltrChart.Text = chart.ToHtmlString();
           
        }
    }
}