using PackingClassLibrary.CustomEntity;
using PackingClassLibrary.CustomEntity.ReportEntitys;
using ShippingController_V1._0_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.Objects;
using System.Web.UI.WebControls;
using ShippingController_V1._0_.Views;
using System.IO;
using System.Data;


namespace ShippingController_V1._0_.Forms.Web_Forms
{
    
    public partial class frmHomeIcon : System.Web.UI.Page
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
        int ActiveUsers = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //fill active gridview.
                FillgvActiveUsers();
                FillCounter();

            }
        }

        public void FillCounter()
        {
            int TotalUsers = Obj.call.GetUserInfoList().Count();
            int InActiveUsers = TotalUsers - ActiveUsers;

            //Set Users to label
            lblCActiveUsers.Text = ActiveUsers.ToString();
            lblCInactiveUsers.Text = InActiveUsers.ToString();
            lblCTotalUsers.Text = TotalUsers.ToString();
        }

        /// <summary>
        /// User Station Information fill.
        /// </summary>
        public void FillgvActiveUsers()
        {
            try
            {
                List<cstUserCurrentStationAndDeviceID> lsCurrent = new List<cstUserCurrentStationAndDeviceID>();
                List<cstUserCurrentStationAndDeviceID> lsStation = Obj.call.GetlastLoginStationAllUsers();
                foreach (var Stationitem in lsStation)
                {
                    DateTime Dt = Convert.ToDateTime(Stationitem.Datetime);
                    if (Dt.Date == DateTime.UtcNow.Date)
                    {
                        lsCurrent.Add(Stationitem);
                    }
                }
                List<cstShipmentPackedTodayAndAvgTime> lsAvg = Obj.call.GetPackingCountCurrentShipmentUserName();

                List<cstHomePageGv> lsHomeinfo = new List<cstHomePageGv>();


                List<cstPackageTbl> lsPackingtbl = Obj.call.GetPackingTbl();
                var CurrentShp = from current in lsPackingtbl
                                 where current.PackingStatus == 1
                                 select current;


                foreach (var Packingitem in lsCurrent)
                {
                    cstHomePageGv HomeGv = new cstHomePageGv();
                    HomeGv.UserID = Packingitem.UserID;
                    HomeGv.UserName = Packingitem.UserName;
                    HomeGv.Packed = 0;
                    try { HomeGv.Packed = lsAvg.SingleOrDefault(i => i.UserID == Packingitem.UserID).Packed; }
                    catch (Exception) { }
                    HomeGv.CurrentPackingShipmentID = "Not Packing";
                    try { HomeGv.CurrentPackingShipmentID = CurrentShp.SingleOrDefault(k => k.UserID == Packingitem.UserID).ShippingNum; }
                    catch (Exception) { }
                    HomeGv.StationName = Packingitem.StationName;
                    HomeGv.DeviceID = Packingitem.DeviceID;
                    HomeGv.Datetime = Packingitem.Datetime;
                    lsHomeinfo.Add(HomeGv);
                }
                //Count Active Users
                ActiveUsers = lsHomeinfo.Count();

                if (lsHomeinfo.Count > 0)
                {
                    lblActive.Text = "Active Users";
                    lblActive.ForeColor = System.Drawing.Color.White;
                    gvLatestLogin.DataSource = lsHomeinfo;
                    gvLatestLogin.DataBind();
                    gvLatestLogin.Columns[7].Visible = false;
                }
                else
                {
                    lblActive.Text = "No Active User";
                    lblActive.ForeColor = System.Drawing.Color.FromArgb(255, 140, 0);
                }

            }
            catch (Exception)
            {
            }
        }

        protected void gvLatestLogin_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Guid UserID = Guid.Empty;
                Guid.TryParse(gvLatestLogin.SelectedRow.Cells[7].Text, out UserID);

                List<cstUserMasterTbl> _lsUser = Obj.call.GetSelcetedUserMaster(UserID);
                _uNamelbl.Text = _lsUser[0].UserName.ToString();
                _uFullNamelbl.Text = _lsUser[0].UserFullName;
                _uRole.Text = _lsUser[0].RoleName.ToString();
                _uJoiningDatelbl.Text = _lsUser[0].JoiningDate.ToString("MMM dd, yyyy");
                _uAddress.Text = _lsUser[0].UserAddress;
                _uCurrentStationlbl.Text = gvLatestLogin.SelectedRow.Cells[2].Text.ToString();
                _uTotalPackedlbl.Text = gvLatestLogin.SelectedRow.Cells[5].Text.ToString();
                _uCurrentShipmentlbl.Text = gvLatestLogin.SelectedRow.Cells[6].Text.ToString();
                _uLoginlbl.Text = gvLatestLogin.SelectedRow.Cells[3].Text.ToString();
            }
            catch (Exception)
            { }
                                                           
        }
       
    }
}