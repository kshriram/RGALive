using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShippingController_V1._0_.Forms.Web_Forms
{
    public partial class frmRMAPopup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //protected void btnAdd_Click(object sender, EventArgs e)
        //{
        //    if (RadioButtonList1.SelectedIndex==-1)
        //    {
        //        lblMessage.Text = "Please select appropriate Radiobutton";
        //    }
        //    else
        //    {
        //        if(RadioButtonList1.SelectedIndex==0)
        //        {                  
                   
        //        }
        //        else if(RadioButtonList1.SelectedIndex==1)
        //        {

        //        }
        //        else if (RadioButtonList1.SelectedIndex == 2)
        //        {
        //            String RowId = txtRMAwith.Text.Trim();
        //            Response.Redirect("~/Forms/Web Forms/frmSRNumber.aspx?RGAROWID=" + RowId);
        //        }
        //    }
        //}

        protected void txtRMAwith_TextChanged(object sender, EventArgs e)
        {
            btnAdd.Visible = true;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedItem != null)
            {
                string rbd = RadioButtonList1.SelectedItem.Value;
                if (rbd == "wthpo")
                {
                    String po = txtRMAwith.Text;
                    Response.Redirect("~/Forms/Web Forms/frmRMAEnterWithPO.aspx?RMAPO=" + po);

                }
                else if (rbd == "wthotpo")
                {
                    // Server.Transfer(@"~\Forms\Web Forms\frmRMAEnterWithPO.aspx");
                    Response.Redirect("frmRMAEnter.aspx");
                }
                else if (rbd == "wthsr")
                {
                   // Response.Redirect(@"~\Forms\Web Forms\frmRMAEnterWithSR.aspx");
                    String srnumber = txtRMAwith.Text.Trim();
                    Response.Redirect("~/Forms/Web Forms/frmSRNumber.aspx?RMANumber=" + srnumber);
                }

            }
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedItem != null)
            {
                string rbd = RadioButtonList1.SelectedItem.Value;
                if (rbd == "wthpo")
                {
                    txtRMAwith.Visible = true;
                    txtRMAwith.Focus();
                }
                else if (rbd == "wthotpo")
                {
                    // Server.Transfer(@"~\Forms\Web Forms\frmRMAEnterWithPO.aspx");
                    txtRMAwith.Visible = false;
                }
                else if (rbd == "wthsr")
                {
                    // Response.Redirect(@"~\Forms\Web Forms\frmRMAEnterWithSR.aspx");
                    txtRMAwith.Visible = true;
                    txtRMAwith.Focus();
                }

            }
           
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmHomePage.aspx");
        }



    }
}