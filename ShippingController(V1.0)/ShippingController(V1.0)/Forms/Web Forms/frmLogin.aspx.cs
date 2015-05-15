using PackingClassLibrary;
using PackingClassLibrary.Commands;
using PackingClassLibrary.CustomEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShippingController_V1._0_.Forms.Web_Forms
{
    public partial class frmLogin : System.Web.UI.Page
    {
        smController call = new smController(); 
        protected void Page_Load(object sender, EventArgs e)
        {
            txtUserName.Focus();
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                

                String Msg = "Invalid User Name";
                List<cstUserMasterTbl> lsUserInfo = call.GetSelcetedUserMaster(txtUserName.Text.ToString());
                Session["UName"] = txtUserName.Text.ToString();
                Session["transaction"] = "todays";

                if (lsUserInfo.Count>0)
                {
                    Session["UserFullName"] = lsUserInfo[0].UserFullName;
                    Session["UserID"] = lsUserInfo[0].UserID;
                    Session["RoleID"] = lsUserInfo[0].Role;
                    Session["UserName"] = lsUserInfo[0].UserName;
                    String Password = lsUserInfo[0].Password.ToString();
                    String Roleid = lsUserInfo[0].RoleName.ToString();

                    if (String.Compare(Password,txtPassword.Text) == 0)
                    {
                        if (Roleid == "Admin" || Roleid == "Packer")
                        {
                            Server.Transfer(@"~\Forms\Web Forms\frmHomePage.aspx");
                        }
                        else
                        {
                            Msg = "Access Denied. Need administrator permission to login.";
                        }
                    }
                    else
                    {
                        Msg = "User Name, Password incorrect.";
                    }
                }
                ScriptManager.RegisterStartupScript(this, Page.GetType(), "alert", "alert('"+ Msg +"');", true);
            }
            catch (Exception)
            {
                
            }
           
        }
    }
}