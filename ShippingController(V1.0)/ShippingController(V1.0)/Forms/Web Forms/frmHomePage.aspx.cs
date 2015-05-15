using PackingClassLibrary;
using PackingClassLibrary.CustomEntity;
using PackingClassLibrary.CustomEntity.ReportEntitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Objects;
using ShippingController_V1._0_.Models;
using DotNet.Highcharts.Options;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Enums;
using PackingClassLibrary.CustomEntity.SMEntitys;
namespace ShippingController_V1._0_.Forms.Web_Forms
{
    public partial class frmHomePage : System.Web.UI.Page
    {
        smController Call = new smController();
        //Set Time Zon To UTC.
        TimeZoneInfo EstTime = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");

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
           //ss MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {
                Session["Admin Page"] = "Home Page";
                Session["transaction"] = "todays";
                FillgvPackingShipments();
                FillgvlatestLogin();
                SetGraph();
            }
        }

        public void SetGraph()
        {

            List<cstUserEachPacked> _lsTotalPacekedPerStation = Obj.Rcall.GetEachUserPacked(DateTime.UtcNow);

            Series[] sr = new Series[_lsTotalPacekedPerStation.Count];

            // chart Veriables
            String[] StationNames = new string[_lsTotalPacekedPerStation.Count];

            for (int i = 0; i < _lsTotalPacekedPerStation.Count; i++)
            {
                sr[i] = new Series { Name = _lsTotalPacekedPerStation[i].UserName, Data = new Data(new object[] { _lsTotalPacekedPerStation[i].TotalPacked }) };
            }

            DotNet.Highcharts.Highcharts chart = new DotNet.Highcharts.Highcharts("Chart")
            .InitChart(new DotNet.Highcharts.Options.Chart
            {
                Type = ChartTypes.Bar,
                BackgroundColor = new BackColorOrGradient(System.Drawing.Color.White),
                Height = 299,
            })
            .SetXAxis(new DotNet.Highcharts.Options.XAxis
            {

                Categories = (new string[] { "Packed" }),
                Title = new XAxisTitle { Text = "Packing Status", Style = "fontSize: '15px', fontFamily: 'Verdana', color: 'Black'" }
            })
             .SetTitle(new Title
             {
                 Text = "User Information ",
                 Style = "fontSize: '30px',fontFamily: 'Verdana', fontBold: 'true', color: 'Black' "
             })
             .SetYAxis(new YAxis
             {

                 Title = new YAxisTitle { Text = "User Names", Style = "fontSize: '15px', fontFamily: 'Verdana', color: 'Black'" },
             })
             .SetSeries(sr);

            ltrChart.Text = chart.ToHtmlString();


        }
       
        public void FillgvPackingShipments()
        {
            try
            {
                List<cstPackageTbl> lsShipmetn =Obj.call.GetPackingTbl();
                var v = (from s in lsShipmetn
                        where s.PackingStatus == 1
                        && s.StartTime.Date == DateTime.UtcNow.Date 
                        select new
                        {
                            PackingID = s.ShippingNum,
                            ShipmentLocation = s.ShipmentLocation,
                            UserName = Call.GetSelcetedUserMaster(s.UserID).FirstOrDefault().UserFullName,
                            Date = s.StartTime
                        }).OrderByDescending(X=>X.Date);

                gvShipmentPacking.DataSource = v;
                gvShipmentPacking.DataBind();
            }
            catch (Exception)
            {
              
            }
        }
        public void FillgvlatestLogin()
        {
            try
            {
                List<cstUserCurrentStationAndDeviceID> lsCurrent = new List<cstUserCurrentStationAndDeviceID>();
                List<cstUserCurrentStationAndDeviceID> lsStation = Call.GetlastLoginStationAllUsers();
                foreach (var Stationitem in lsStation)
                {
                    DateTime Dt = Convert.ToDateTime(Stationitem.Datetime);
                    if (Dt.Date == DateTime.UtcNow.Date)
                    {
                        lsCurrent.Add(Stationitem);
                    }
                    Stationitem.Datetime = TimeZoneInfo.ConvertTimeFromUtc(Dt, EstTime).ToString();
                }
                gvLatestLogin.DataSource = lsCurrent;
                gvLatestLogin.DataBind();
            }
            catch (Exception)
            {
            }
        }
    }
}