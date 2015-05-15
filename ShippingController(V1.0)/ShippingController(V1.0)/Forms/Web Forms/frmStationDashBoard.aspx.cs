using PackingClassLibrary.CustomEntity;
using PackingClassLibrary.CustomEntity.ReportEntitys;
using ShippingController_V1._0_.Models;
using ShippingController_V1._0_.Views;
using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ShippingController_V1._0_.Forms.Web_Forms
{
    public partial class frmStationDashBoard : System.Web.UI.Page
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
            StaionInfo();
        }


        private int _getUserLogErrors(String Username)
        {
            int Errorcount=0;
            try
            {
                Guid UserId = Obj.call.GetUserInfoList().SingleOrDefault(i => i.UserFullName == Username).UserID;
                List<cstAutditLog> lsAudit = Obj.call.GetUserLogAll(UserId, DateTime.UtcNow);
                foreach (cstAutditLog _audit in lsAudit)
                {
                    if (_audit.ActionType.Contains("_00"))
                    {
                        Errorcount++;
                    }
                }

            }
            catch (Exception)
            {}
            return Errorcount;
        }

        public void StaionInfo()
        {
            List<cstUserCurrentStationAndDeviceID> lsCurrent = new List<cstUserCurrentStationAndDeviceID>();
            List<cstUserCurrentStationAndDeviceID> lsStation =Obj.call.GetlastLoginStationAllUsers();
            foreach (var Stationitem in lsStation)
            {
                DateTime Dt = Convert.ToDateTime(Stationitem.Datetime);
                if (Dt.Date == DateTime.UtcNow.Date)
                {
                    lsCurrent.Add(Stationitem);
                }
            }
            

            try
            {
                var StaionDetails = from st in lsCurrent
                                    select new
                                    {
                                        stationName = st.StationName,
                                        TotalPacked = Obj.Rcall.TotalPackedTodayByStationID(st.StationName),
                                        UserName = st.UserName,
                                        userid = st.UserID,
                                        shippingnum = Obj.Rcall.GetShippingNumByStation(st.StationName)
                                    };
                
                List<cstDashBoardStion> lsDashBoard = new List<cstDashBoardStion>();
                foreach (var infoItem in StaionDetails)
                {
                    cstDashBoardStion _Dstation = new cstDashBoardStion();
                    _Dstation.StationName = infoItem.stationName;
                    _Dstation.TotalPacked = infoItem.TotalPacked;
                    _Dstation.PackerName = infoItem.UserName;
                    _Dstation.ErrorCaught = _getUserLogErrors(infoItem.UserName);
                    _Dstation.ShipmentNumber = infoItem.shippingnum;
                    _Dstation.packagePerhr = AvgPackingTimerPerUser(infoItem.userid);
                    lsDashBoard.Add(_Dstation);
                }


                foreach (cstDashBoardStion Dab in lsDashBoard)
                {
                    MainDiv.Controls.Add(SetTable(Dab));
                }
            }
            catch (Exception)
            { }
            
           
        }

        public HtmlTable SetTable(cstDashBoardStion cStation)
        {
            HtmlTable StationTable = new HtmlTable();
            StationTable.BgColor = "White";
            StationTable.Border = 2;
            StationTable.BorderColor = "Gray";
            StationTable.Style.Add("float", "left");
            StationTable.Style.Add("margin-right", "10px");
            StationTable.Style.Add("margin", "5px");
            StationTable.Style.Add("width", "47%");
            HtmlTableRow row = new HtmlTableRow();
            HtmlTableRow trow = new HtmlTableRow();
            HtmlTableCell tcell = new HtmlTableCell();
            tcell.ColSpan = 2;
            tcell.InnerHtml = " <table style=\"width: 100%;\"><tr><td style=\"text-align: center; font-size: 40px; color: #ff6a00; background-color:#1e1d1d\">" + cStation.StationName + "</td></tr></table>";
            trow.Cells.Add(tcell);
            HtmlTableCell cell;
            for (int i = 0; i < 2; i++)
            {
                cell = new HtmlTableCell();
                if (i == 0)
                {
                    cell.InnerHtml = "<table style=\"width:100%\"><tr><td style=\"text-align:center; font-size:60px; color:darkgreen;\">" + cStation.TotalPacked + "</td></tr><tr><td style=\"text-align:center; font-size:40px; color:black\"> Packed</td></tr></table>";
                }
                if (i == 1)
                {
                    cell.InnerHtml = "<table style=\"width: 100%;\"><tr><td style=\"font-size:20px; color:black; text-align:right\">Packer :</td><td style=\"font-size:20px; color:darkblue; text-align:left\">" + cStation.PackerName + "</td></tr><tr><td style=\"font-size:20px; color:black; text-align:right\">Error Caught :</td><td style=\"font-size:20px; color:darkblue; text-align:left\">" + cStation.ErrorCaught + "</td></tr><tr><td style=\"font-size:20px; color:black; text-align:right\">Avg Shipment Packing Time :</td><td style=\"font-size:20px; color:darkblue; text-align:left\">" + cStation.packagePerhr + "</td></tr><tr><td style=\"font-size:20px; color:black; text-align:right\">Active Shipment :</td><td style=\"font-size:20px; color:darkblue; text-align:left\">" + cStation.ShipmentNumber + "</td></tr></table>";
                }
                row.Cells.Add(cell);
            }
            StationTable.Rows.Add(trow);
            StationTable.Rows.Add(row);
            return StationTable;
        }


        public String AvgPackingTimerPerUser(Guid UserID)
        {
            String _return = "N/A";
            // Code for average time
            TimeSpan Tm = TimeSpan.FromSeconds(Obj.call.GetAverageTime(UserID)[0].Value);
            string min = Tm.Minutes.ToString();
            string sec = Tm.Seconds.ToString();
            sec = sec.TrimStart(new char[] { '0' }) + "";
            if (sec != "")
            {
                sec = "" + sec + "sec";
            }
            min = min.TrimStart(new char[] { '0' }) + "";
            if (min != "")
            {
                min = min + "min:";
            }
            if( (min + sec )!= "")
                _return = min + sec;


            return _return;
        }
    }
}