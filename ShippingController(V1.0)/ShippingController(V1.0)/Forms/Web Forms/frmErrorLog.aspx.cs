using PackingClassLibrary.CustomEntity;
using ShippingController_V1._0_.Models;
using ShippingController_V1._0_.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShippingController_V1._0_.Forms.Web_Forms
{
    public partial class frmErrorLog : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                fillErrorLogGrid();
            }
        }


       

        public void fillErrorLogGrid()
        {
            try
            {
                List<cstErrorLog> lsErrorLog = Obj.call.GetErrorLog();
                List<cstDspErrorLog> LsNewErroe = new List<cstDspErrorLog>();
                foreach (var Erroritem in lsErrorLog)
                {
                    cstDspErrorLog _error = new cstDspErrorLog();
                    _error.ErrorDescription = Erroritem.ErrorDesc;
                    _error.ErrorLocation = Erroritem.ErrorLocation;
                    _error.ErrorDate = Erroritem.ErrorTime; 
                    _error.ErrorID = Erroritem.ErrorLogID;
                    _error.UserName = "--";
                    if (Erroritem.UserID != Guid.Empty)
                    {
                        try
                        { _error.UserName = Obj.call.GetSelcetedUserMaster(Erroritem.UserID).SingleOrDefault(o => o.UserID == Erroritem.UserID).UserFullName; }
                        catch (Exception) { }

                    }
                    LsNewErroe.Add(_error);
                   
                }
                gvErrorInformation.DataSource = LsNewErroe;
                gvErrorInformation.DataBind();
            }
            catch (Exception)
            {}
        }

        protected void txtSearchLog_TextChanged(object sender, EventArgs e)
        {
            txtSearchLog.Focus();

            try
            {
                String SearchText = txtSearchLog.Text;
                String[] Part = SearchText.Split(new char[] { '|' });

                if (Part[0].ToString() != "" || Part[0].ToString() != null)
                {
                    Guid Rowid ;
                    Guid.TryParse(Part[0].ToString(), out Rowid);
                    List<cstErrorLog> lsErrorLog = Obj.call.GetErrorLog();

                    cstErrorLog _Err = lsErrorLog.SingleOrDefault(i => i.ErrorLogID == Rowid);
                    cstDspErrorLog _error = new cstDspErrorLog();
                    _error.ErrorDescription = _Err.ErrorDesc;
                    _error.ErrorLocation = _Err.ErrorLocation;
                    _error.ErrorDate = _Err.ErrorTime;
                    _error.ErrorID = _Err.ErrorLogID;
                    _error.UserName = "--";
                    if (_Err.UserID != Guid.Empty)
                    {
                        try
                        { _error.UserName = Obj.call.GetSelcetedUserMaster(_Err.UserID).SingleOrDefault(o => o.UserID == _Err.UserID).UserFullName; }
                        catch (Exception) { }

                    }
                    List<cstDspErrorLog> lsDataSource = new List<cstDspErrorLog>();
                    lsDataSource.Add(_error);
                    gvErrorInformation.DataSource = lsDataSource;
                    gvErrorInformation.DataBind();
                    txtSearchLog.Text = "";
                }
            }
            catch (Exception)
            { }
            
        }
    }
}