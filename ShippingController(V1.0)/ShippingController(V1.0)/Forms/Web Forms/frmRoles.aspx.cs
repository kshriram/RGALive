using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShippingController_V1._0_.Models;

namespace ShippingController_V1._0_.Forms.Web_Forms
{
    public partial class frmRoles : System.Web.UI.Page
    {
        /// <summary>
        /// Model Object
        /// </summary>
        modelRoles MRole = new modelRoles();


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

            _fillGvRoles();
        }

        /// <summary>
        /// Fill Grid View Of Role information.
        /// </summary>
        private void _fillGvRoles()
        {
            var roles = from rol in Obj.call.GetRole()
                        select new
                        {
                            rol.RoleId,
                            rol.Name,
                            permission = MRole.ActionString(rol.Action)
                        };

            gvUserInformation.DataSource = roles;
            gvUserInformation.DataBind();


        }

        protected void gvUserInformation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Clear();
                LinkButton lbtn = (LinkButton) gvUserInformation.SelectedRow.FindControl("lbtnRoleId");
                String RoleID = lbtn.Text;

                rchIsSuperUser.Checked = MRole.IsSuperUser(RoleID);
                rchOverride.Checked = MRole.IsPermisson("Override", RoleID);
                 rchView.Checked= MRole.IsPermisson("View", RoleID);
                rchScan.Checked = MRole.IsPermisson("Scan", RoleID);
                rchReScan.Checked = MRole.IsPermisson("Rescan", RoleID);

                txtRoleName.Text = gvUserInformation.SelectedRow.Cells[1].Text.ToString();


            }
            catch (Exception)
            {}
        }


        private void Clear()
        {
            try
            {
                rchIsSuperUser.Checked = false;
                rchOverride.Checked = false;
                rchView.Checked = false;
                rchScan.Checked = false;
                rchReScan.Checked = false;
                txtRoleName.Text = "";
            }
            catch (Exception)
            { }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                Clear();
                gvUserInformation.DataSource = null;
                gvUserInformation.DataBind();
                _fillGvRoles();
            }
            catch (Exception)
            {
            } 
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            if (txtRoleName.Text.Trim() != "")
            {

                Boolean IsSuperUser = false;
                Boolean View = false;
                Boolean Scan = false;
                Boolean Resacan = false;
                Boolean Override = false;
                String Name = txtRoleName.Text;

                if (rchIsSuperUser.Checked == true)
                    IsSuperUser = true;
                if (rchView.Checked == true)
                    View = true;
                if (rchScan.Checked == true)
                    Scan = true;
                if (rchReScan.Checked == true)
                    Resacan = true;
                if (rchOverride.Checked == true)
                    Override = true;
                LinkButton lbtn = (LinkButton)gvUserInformation.SelectedRow.FindControl("lbtnRoleId");

                Guid RoleID = Guid.Parse(lbtn.Text);

                Boolean isSaved = Obj.call.UpdateRole(RoleID, txtRoleName.Text, IsSuperUser, View, Scan, Resacan, Override);
                if (isSaved)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Role Information Updated ');", true);
                    Clear();
                    _fillGvRoles();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Role Information Update Fail! please try again. ');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Role Name Must not be blank ');", true);
            }
        }
    }
}