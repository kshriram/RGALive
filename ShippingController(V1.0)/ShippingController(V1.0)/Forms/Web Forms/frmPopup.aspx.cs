using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ShippingController_V1._0_.Models;

namespace ShippingController_V1._0_.Forms.Web_Forms
{
    public partial class frmPopup : System.Web.UI.Page
    {
        string _reasons;
        int count;


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
            Obj._popupValue.ReasnValue = _reasons;
            string script = "self.close();</script>";
            ScriptManager.RegisterStartupScript(this, Page.GetType(), "Close", script, true);

            chkreasons.ClearSelection();
        }

      
    }
}