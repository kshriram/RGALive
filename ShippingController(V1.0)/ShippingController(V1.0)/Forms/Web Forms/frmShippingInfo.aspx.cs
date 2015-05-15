using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PackingClassLibrary;
using ShippingController_V1._0_.Models;

namespace ShippingController_V1._0_.Forms.Web_Forms
{
    public partial class frmShippingInfo : System.Web.UI.Page
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
            FillGvShippingInfo();
        }

        /// <summary>
        /// Gridview Shipping Information fill 
        /// </summary>
        public void FillGvShippingInfo()
        {
            try
            {
               var ShippingInfo= Obj.Rcall.GetBpinfoOFShippingNum();
               gvShippingInfo.DataSource = ShippingInfo.ToList();
               gvShippingInfo.DataBind();
            }
            catch (Exception)
            {}
        }
        
    }
}