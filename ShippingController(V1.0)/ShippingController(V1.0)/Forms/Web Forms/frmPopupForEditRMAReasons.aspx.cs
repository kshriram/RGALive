using ShippingController_V1._0_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShippingController_V1._0_.Forms.Web_Forms
{
    public partial class frmPopupForEditRMAReasons : System.Web.UI.Page
    {
        string _reasons;
        int count;

        private void Page_PreInit(object sender, EventArgs e)
        {
            string user = Session["UserID"].ToString().ToUpper();
            if (Session["UserID"].ToString().ToUpper() == "0DD3CB2D-33B6-431F-9DA0-042F9FF3963B")
            {
                this.MasterPageFile = "~/Forms/Master Forms/Admin.Master";
            }
            else
            {
                this.MasterPageFile = "~/Forms/Master Forms/TestUser.Master";
            }

        }


        //Get Category from QueryString.
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String s = Request.QueryString["Category"];

                //call fillReasons.
                FilldgReasons(s);
            }
        }

        /// <summary>
        /// fill Reason checkboxlist by using Category.
        /// </summary>
        /// <param name="cat">
        /// Pass Category String as parameter.
        /// </param>
        public void FilldgReasons(String cat)
        {
            chkreasons.DataSource = Obj.Rcall.ReasonByCategoryName(cat);
            chkreasons.DataTextField = "Reason1";
            chkreasons.DataValueField = "ReasonID";
            chkreasons.DataBind();
        }

        //Get Reason string Which are Selected.
        protected void btnAdd_Click(object sender, EventArgs e)
        {

            count = 0;
            foreach (ListItem li in chkreasons.Items)
            {
                if (li.Selected)
                {
                    _reasons += li.Value + "#";
                    count++;
                }
            }

        }

        //Get Reason string Which are Selected.
        protected void btnAdd_Click1(object sender, EventArgs e)
        {
            count = 0;
            foreach (ListItem li in chkreasons.Items)
            {
                if (li.Selected)
                {
                    _reasons += li.Value + "#";
                    count++;
                }
            }
            Obj.ReasonsIDs.UpdatePopupValue = _reasons;
            string script = "self.close();</script>";
            ScriptManager.RegisterStartupScript(this, Page.GetType(), "Close", script, true);

            chkreasons.ClearSelection();
        }
    }
}