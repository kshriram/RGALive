using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShippingController_V1._0_.Models;
using PackingClassLibrary.CustomEntity.SMEntitys.RGA;
using System.Configuration;
using PackingClassLibrary.Commands.SMcommands.RGA;
using System.Threading;
using System.Windows;


namespace ShippingController_V1._0_.Forms.Web_Forms
{
    public partial class frmRMAConfig : System.Web.UI.Page
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
                txtImageServer.Text = System.Configuration.ConfigurationManager.AppSettings["ImageServerPath"].ToString();
                txtServerPhysicalPath.Text = System.Configuration.ConfigurationManager.AppSettings["PhysicalPath"].ToString();
                FillReturnGrid();
            }
        }

        /// <summary>
        /// Fill Grid View with the Reason.
        /// </summary>
        private void FillReturnGrid()
        {
            try
            {

                var resn = from ls in Obj.Rcall.ReasonsAll()
                           select new
                           {
                               ls.ReasonID,
                               ls.ReasonPoints,
                               ls.Reason1,
                               Category = GetCategoty(ls.ReasonID)
                           };

                gvReasons.DataSource = resn;
                gvReasons.DataBind();

            }
            catch (Exception)
            {
            }

        }

        /// <summary>
        /// Get All categories by reason id.
        /// </summary>
        /// <param name="ReasonID">
        /// Reason ID Guild
        /// </param>
        /// <returns>
        /// String of Categories.
        /// </returns>
        private String GetCategoty(Guid ReasonID)
        {
            String _return = "";
            try
            {
                var Cat = Obj.Rcall.GetReasonCategoryByReasonID(ReasonID);
                foreach (var item in Cat)
                {
                    if (item.CategoryName != "")
                        _return += item.CategoryName + ",";
                }
            }
            catch (Exception)
            { }
            return _return;
        }

        protected void btnUpdateImageServer_Click(object sender, EventArgs e)
        {
            try
            {
                Configuration objConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
                objConfig.AppSettings.Settings.Remove("ImageServerPath");
                objConfig.AppSettings.Settings.Add("ImageServerPath", txtImageServer.Text);
                objConfig.Save();
            }
            catch (Exception)
            { }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
            //    Guid ReID = Guid.NewGuid();
            //    if (txtRetunID.Value != "" && txtRetunID.Value != null)
            //        Guid.TryParse(txtRetunID.Value, out ReID);

            //    Reason _reson = new Reason();
            //    _reson.ReasonID = ReID;
            //    _reson.Reason1 = txtReason.Text;
            //    _reson.ReasonPoints = Convert.ToInt32(txtPoint.Text);
            //    Obj.Rcall.UpsertReasons(_reson);

            //    UpsertCategory(ReID);

            //    FillReturnGrid();

            //    clearAll();
            }
            catch (Exception)
            { }
        }


        /// <summary>
        /// Text Of link Button
        /// </summary>
        /// <param name="LinkButtonID">
        /// String Link Button ID
        /// </param>
        /// <param name="GridViewName">
        /// Gridview Object link button belongs to
        /// </param>
        /// <returns>
        /// String Text Of Link Button 
        /// </returns>
        public String linkButtonText(String LinkButtonID, GridView GridViewName)
        {
            String _return = "";
            try
            {
                LinkButton lnk = (LinkButton)GridViewName.SelectedRow.FindControl(LinkButtonID);
                _return = lnk.Text;
            }
            catch (Exception)
            { }
            return _return;
        }

        protected void gvReasons_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gvReasons.SelectedIndex > -1)
            {
                string Reason = linkButtonText("lbtnReason", gvReasons);
                String ReasonID = gvReasons.SelectedRow.Cells[3].Text.Trim();
                String CateGotys = gvReasons.SelectedRow.Cells[2].Text.Trim().Replace("&nbsp;", "");
                String Points = gvReasons.SelectedRow.Cells[1].Text.Trim();

                txtCategory.Text = CateGotys;
                txtPoint.Text = Points;
                txtReason.Text = Reason;
                txtRetunID.Value = ReasonID;

            }
        }

        /// <summary>
        /// Upsert the categories table
        /// </summary>
        /// <param name="ReID"></param>
        private void UpsertCategory(Guid ReID)
        {
            try
            {
                List<ReasonCategoty> Rcategorys = new List<ReasonCategoty>();
                Rcategorys = Obj.Rcall.GetReasonCategoryByReasonID(ReID);
                string[] Categories = txtCategory.Text.ToString().Split(new char[] { ',' });
                if (Rcategorys.Count() > 0 && Categories.Count() > 0)
                {

                    if (Rcategorys.Count() > Categories.Count())
                    {
                        for (int i = 0; i < Rcategorys.Count(); i++)
                        {
                            try
                            {
                                ReasonCategoty cat = Rcategorys[i];
                                cat.CategoryName = Categories[i].ToString().Trim();
                                Obj.Rcall.UpsertReasonCategory(cat);
                            }
                            catch (Exception)
                            {
                                ReasonCategoty cat = Rcategorys[i];
                                cat.CategoryName = " ";
                                Obj.Rcall.UpsertReasonCategory(cat);
                            }
                        }
                    }
                    else if (Rcategorys.Count() < Categories.Count())
                    {
                        for (int i = 0; i < Categories.Count(); i++)
                        {
                            try
                            {
                                ReasonCategoty cat = Rcategorys[i];
                                cat.CategoryName = Categories[i].ToString().Trim();
                                Obj.Rcall.UpsertReasonCategory(cat);
                            }
                            catch (Exception)
                            {
                                ReasonCategoty cat = new ReasonCategoty();
                                cat.ReasonCatID = Guid.NewGuid();
                                cat.ReasonID = ReID;
                                cat.CategoryName = Categories[i].ToString(); ;
                                Obj.Rcall.UpsertReasonCategory(cat);
                            }
                        }
                    }
                    else if (Rcategorys.Count() == Categories.Count())
                    {
                        for (int i = 0; i < Categories.Count(); i++)
                        {
                            ReasonCategoty cat = Rcategorys[i];
                            cat.CategoryName = Categories[i].ToString().Trim();
                            Obj.Rcall.UpsertReasonCategory(cat);
                        }
                    }
                }
                else if (Categories.Count() > 0)
                {
                    for (int i = 0; i < Categories.Count(); i++)
                    {
                        ReasonCategoty cat = new ReasonCategoty();
                        cat.ReasonCatID = Guid.NewGuid();
                        cat.ReasonID = ReID;
                        cat.CategoryName = Categories[i].ToString().Trim();
                        Obj.Rcall.UpsertReasonCategory(cat);
                    }
                }
            }
            catch (Exception)
            { }
        }

        private void clearAll()
        {
            txtCategory.Text = "";
            txtImageServer.Text = System.Configuration.ConfigurationManager.AppSettings["ImageServerPath"].ToString();
            txtPoint.Text = "";
            txtReason.Text = "";
            txtRetunID.Value = "";
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        protected void btnUpdatePhysicalPath_Click(object sender, EventArgs e)
        {
            Configuration Config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
            Config.AppSettings.Settings.Remove("PhysicalPath");
            Config.AppSettings.Settings.Add("PhysicalPath", txtServerPhysicalPath.Text);
            Config.Save();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string confirmValue = Request.Form["confirm_value"];
                if (confirmValue == "Yes")
                {

                    String Reas = (((GridViewRow)((LinkButton)sender).Parent.Parent).Cells[3]).Text;
                    Guid ReasonID = Guid.Parse(Reas);
                    Boolean _Flag = Obj.Rcall.DeleteReasonByReasonID(ReasonID);
                    if (!_Flag)
                    {
                        String s = "Delete fail: \\nThis Reason is linked to other Returns.\\n[foreign key reference exist.]";
                        ScriptManager.RegisterStartupScript(this, Page.GetType(), "alert", "alert('" + s + "');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, Page.GetType(), "alert", "alert('Delete successfull');", true);
                        FillReturnGrid();
                    }
                }
            }
            catch (Exception)
            { }
        }

        protected void gvReasons_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowIndex == 0)
                {
                    e.Row.Style.Add("vertical-align", "bottom");
                    e.Row.Style.Add("height", "50px");
                }

            }
        }
    }
}