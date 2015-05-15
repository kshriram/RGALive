using ShippingController_V1._0_.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



using ShippingController_V1._0_.Views;
using PackingClassLibrary.CustomEntity.SMEntitys.RGA;
using PackingClassLibrary.Commands.SMcommands.RGA;

using System.Text.RegularExpressions;
using System.Drawing.Imaging;
using System.Drawing;


namespace ShippingController_V1._0_.Forms.Master_Forms
{
    public partial class Admin : System.Web.UI.MasterPage
    {

        cmdReturnDetails _ReturnDetails = new cmdReturnDetails();

        //cmdReturnDetails _ReturnDetails = new cmdReturnDetails();
        Models.modelReturn _newRMA = new Models.modelReturn();

        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                try
                {
                    lblPageName.Text = Session["Admin Page"].ToString();
                    lblUserNameTop.Text = Session["UserFullName"].ToString();
                }
                catch (Exception)
                {
                    Response.Redirect("../Web%20Forms/frmLogin.aspx");
                    ScriptManager.RegisterStartupScript(this, Page.GetType(), "alert", "alert('Session expired. Please Login again to continue');", true);
                }



                //   FillReturnDetails(Obj.Rcall.ReturnDetailByPoNumber(Request.QueryString["RMAPO"].ToString()));

            }

            //if (txtPONumber.Text.Trim() != "")
            //{
            string path = HttpContext.Current.Request.Url.AbsolutePath;

            string Filenam = Path.GetFileName(HttpContext.Current.Request.Url.AbsolutePath);

            if (Filenam == "DemoGrid.aspx" || Filenam == "frmShipmentInformation.aspx")
            {
                checkPOnumber();
            }

            //}

        }

        public void checkPOnumber()
        {
           // String po = txtPONumber.Text.Trim();
           // Session["PO"] = po;
            if (Session["PO"] == "" || Session["PO"] == null)//txtPONumber.Text.Trim();
            {

            }
            else
            {

                //Session["PO"] = po;
                if (_ReturnDetails.IsPONumberAlreadyPresent(Session["PO"].ToString()))
                {
                    mpeForPresentedPO.Show();
                }
                else
                {
                    List<RMAInfo> lsCustomeronfo = _newRMA.GetCustomer(Session["PO"].ToString());

                    if (lsCustomeronfo.Count > 0)
                    {
                        try
                        {
                            FillReturnDetails(lsCustomeronfo);
                        }
                        catch (Exception ex)
                        {
                        }
                        DataGrid.Show();
                        lblMessageForPO.Text = "Select SKU'S from PO number:- " + Session["PO"].ToString();
                        //Response.Redirect("~/Forms/Web Forms/frmRMAEnterWithPO.aspx?RMAPO=" + po);
                    }
                    else
                    {
                        mpeForWrongPO.Show();
                    }
                }

            }

        }

        public void FillReturnDetails(List<RMAInfo> ls)
        {
            try
            {
                List<ReturnDetail> _lsReDetails = new List<ReturnDetail>();
                Obj._lsReturnDetailsWithPO = ls;
                foreach (var rm in ls)
                {
                    if (rm.LineType.ToString() == "" || rm.LineType == null || rm.LineType == 6)
                    {

                    }
                    else
                    {
                        ReturnDetail rd = new ReturnDetail();

                        rd.SKUNumber = rm.SKUNumber;
                        rd.SKU_Qty_Seq = rm.SKU_Qty_Seq;
                        rd.SKU_Sequence = rm.SKU_Sequence;
                        rd.ProductID = rm.ProductID;
                        //  rd.SalesPrice =Convert.ToInt32(gvReturnDetails.Rows[j].Cells[4].Text.ToString());
                        rd.LineType = rm.LineType;
                        rd.ShipmentLines = rm.ShipmentLines;
                        rd.ReturnLines = rm.ReturnLines;
                        rd.DeliveredQty = rm.DeliveredQty;
                        //rd.TrackingNumber=rm.tr

                        _lsReDetails.Add(rd);
                    }
                }

                // var ReaturnDetails = from Rs in _lsReDetails
                var ReaturnDetails = from Rs in _lsReDetails
                                     select new
                                     {
                                         // Rs.RGADROWID,
                                         Rs.SKUNumber,
                                         Rs.SKU_Qty_Seq,
                                         // Rs.SKU_Status,
                                         SKU_Status = "",
                                         Rs.SKU_Sequence,
                                         Rs.ProductID,
                                         //  Rs.SalesPrice,
                                         Rs.LineType,
                                         Rs.ShipmentLines,
                                         Rs.ReturnLines,
                                           // Rs.tr
                                         //   ReasonIDs = _Update.ReasonsIdByHasg(Rs.ReturnDetailID),
                                         ImageName = "",
                                         NoofImages = "",
                                         Rs.DeliveredQty,
                                         //string imagename=""
                                     };


                gvReturnDetails.DataSource = ReaturnDetails.ToList();
                gvReturnDetails.DataBind();
                gvReturnDetails.Columns[1].Visible = false;
                gvReturnDetails.Columns[2].Visible = false;
                gvReturnDetails.Columns[3].Visible = false;
                gvReturnDetails.Columns[4].Visible = false;
                gvReturnDetails.Columns[5].Visible = false;
                gvReturnDetails.Columns[6].Visible = false;


                Session["RT"] = _lsReDetails;

            }
            catch (Exception)
            { }
        }

        protected void btnPassGrid_Click(object sender, EventArgs e)
        {
            String po = txtPONumber.Text.Trim();
            List<RMAInfo> lsCustomeronfo = _newRMA.GetCustomer(po);
            var ReaturnDetails1 = from Rs in lsCustomeronfo
                                  select new
                                  {
                                      // Rs.RGADROWID,
                                      Rs.SKUNumber,
                                      Rs.SKU_Qty_Seq,
                                      // Rs.SKU_Status,
                                      SKU_Status = "",
                                      Rs.SKU_Sequence,
                                      Rs.ProductID,
                                      //  Rs.SalesPrice,
                                      Rs.LineType,
                                      Rs.ShipmentLines,
                                      Rs.ReturnLines,
                                     //   Rs.tr
                                      //   ReasonIDs = _Update.ReasonsIdByHasg(Rs.ReturnDetailID),
                                      ImageName = "",
                                      NoofImages = "",
                                      //string imagename=""
                                      Rs.DeliveredQty,

                                  };


            //gvReturnDetails.DataSource = ReaturnDetails1.ToList();
            //gvReturnDetails.DataBind();
            //List<object> _lsReturnDetails = new List<object>();
            //_lsReturnDetails = ReaturnDetails1.;
            //DataTable dt = new DataTable();
            //dt = ReaturnDetails1.ToList();






            List<ReturnDetail> _lsReturnDetails = new List<ReturnDetail>();
            //string lsredetail;

            for (int j = 0; j < gvReturnDetails.Rows.Count; j++)
            {
                CheckBox cb = (gvReturnDetails.Rows[j].FindControl("CheckBox1")) as CheckBox;

                // if (Convert.ToInt32(gvReturnDetails.Rows[j].Cells[4].Text.ToString()) == 7 || Convert.ToInt32(gvReturnDetails.Rows[j].Cells[4].Text.ToString()) == 1)
                //  {
                if (cb.Checked == true)
                {
                    ReturnDetail rd = new ReturnDetail();

                    rd.SKUNumber = gvReturnDetails.Rows[j].Cells[0].Text.ToString();
                    rd.SKU_Qty_Seq = Convert.ToInt32(gvReturnDetails.Rows[j].Cells[1].Text.ToString());
                    rd.SKU_Sequence = Convert.ToInt32(gvReturnDetails.Rows[j].Cells[2].Text.ToString());
                    rd.ProductID = gvReturnDetails.Rows[j].Cells[3].Text.ToString();
                    //  rd.SalesPrice =Convert.ToInt32(gvReturnDetails.Rows[j].Cells[4].Text.ToString());
                    rd.LineType = Convert.ToInt32(gvReturnDetails.Rows[j].Cells[4].Text.ToString());
                    rd.ShipmentLines = Convert.ToInt32(gvReturnDetails.Rows[j].Cells[5].Text.ToString());
                    rd.ReturnLines = Convert.ToInt32(gvReturnDetails.Rows[j].Cells[6].Text.ToString());
                    rd.DeliveredQty = Convert.ToInt32(gvReturnDetails.Rows[j].Cells[7].Text.ToString());

                    _lsReturnDetails.Add(rd);
                }
            }


            Session["RT"] = _lsReturnDetails;
            Response.Redirect("~/Forms/Web Forms/frmRMAEnterWithPO.aspx?RMAPO=" + po);
        }


        public void Showrt(Object sender, EventArgs e)
        {

        }
        protected void TreeView1_SelectedNodeChanged1(object sender, EventArgs e)
        {
            //try
            //{
            //    //TreeView Tr = (TreeView)sender;
            //    //Tr.SelectedNode.Selected = true;
            //    Response.Redirect(tvMenu.SelectedValue);
            //   // Server.Transfer(tvMenu.SelectedValue);
            //}
            //catch (Exception)
            //{}
        }

        protected void TreeView1_Load(object sender, EventArgs e)
        {

        }

        protected void Logout_buttonClicked(object sender, EventArgs e)
        {
            Response.Redirect("~/Forms/Web Forms/frmLogin.aspx");
            //Server.Transfer("~/Forms/Web Forms/frmLogin.aspx");
        }

        protected void btnYesPO_Click(object sender, EventArgs e)
        {
            String po = txtPONumber.Text.Trim();
            Session["PO"] = po;
            if (_ReturnDetails.IsPONumberAlreadyPresent(po))
            {
                mpeForPresentedPO.Show();
                txtPONumber.Text = "";
                Session["PO"] = "";
            }
            else
            {
                List<RMAInfo> lsCustomeronfo = _newRMA.GetCustomer(po);

                if (lsCustomeronfo.Count > 0)
                {
                    try
                    {
                        FillReturnDetails(lsCustomeronfo);
                    }
                    catch (Exception ex)
                    {
                    }
                    DataGrid.Show();
                    lblMessageForPO.Text = "Select SKU'S from PO number:- " + po;
                    //Response.Redirect("~/Forms/Web Forms/frmRMAEnterWithPO.aspx?RMAPO=" + po);
                }
                else
                {
                    mpeForWrongPO.Show();
                }
            }
           // txtPONumber.Text = "";
        }

        protected void btnPassGrid_Click1(object sender, EventArgs e)
        {

            //String po = Session["PO"].ToString();

            if (Session["PO"] != "")
            {

                //List<RMAInfo> lsCustomeronfo = _newRMA.GetCustomer(po);
                //var ReaturnDetails1 = from Rs in lsCustomeronfo
                //                      select new
                //                      { // Rs.RGADROWID,
                //                          Rs.SKUNumber,
                //                          Rs.SKU_Qty_Seq,
                //                          // Rs.SKU_Status,
                //                          SKU_Status = "",
                //                          Rs.SKU_Sequence,
                //                          Rs.ProductID,
                //                          //Rs.SalesPrice,
                //                          Rs.LineType,
                //                          Rs.ShipmentLines,
                //                          Rs.ReturnLines,
                //                          //   Rs.ReturnDetailID,
                //                          //   ReasonIDs = _Update.ReasonsIdByHasg(Rs.ReturnDetailID),
                //                          ImageName = "",
                //                          NoofImages = "",
                //                          //string imagename=""
                //                          Rs.DeliveredQty,

                //                      };

                //List<object> _lsReturnDetails = new List<object>();
                //_lsReturnDetails = ReaturnDetails1.;
                //DataTable dt = new DataTable();
                //dt = ReaturnDetails1.ToList();






                List<ReturnDetail> _lsReturnDetails = new List<ReturnDetail>();
                //string lsredetail;

                for (int j = 0; j < gvReturnDetails.Rows.Count; j++)
                {
                    CheckBox cb = (gvReturnDetails.Rows[j].FindControl("CheckBox1")) as CheckBox;
                    if (cb.Checked == true)
                    {
                        ReturnDetail rd = new ReturnDetail();

                        rd.SKUNumber = gvReturnDetails.Rows[j].Cells[0].Text.ToString();
                        rd.SKU_Qty_Seq = Convert.ToInt32(gvReturnDetails.Rows[j].Cells[1].Text.ToString());
                        rd.SKU_Sequence = Convert.ToInt32(gvReturnDetails.Rows[j].Cells[2].Text.ToString());
                        rd.ProductID = gvReturnDetails.Rows[j].Cells[3].Text.ToString();
                        //  rd.SalesPrice =Convert.ToInt32(gvReturnDetails.Rows[j].Cells[4].Text.ToString());
                        rd.LineType = Convert.ToInt32(gvReturnDetails.Rows[j].Cells[4].Text.ToString());
                        rd.ShipmentLines = Convert.ToInt32(gvReturnDetails.Rows[j].Cells[5].Text.ToString());
                        rd.ReturnLines = Convert.ToInt32(gvReturnDetails.Rows[j].Cells[6].Text.ToString());
                        rd.DeliveredQty = Convert.ToInt32(gvReturnDetails.Rows[j].Cells[7].Text.ToString());



                        _lsReturnDetails.Add(rd);

                    }
                }
                Session["RT"] = _lsReturnDetails;
                //Response.Redirect("~/Forms/Web Forms/frmRMAEnterWithPO.aspx?RMAPO=" + po);
                //_lsReturnDetails = (List<ReturnDetail>)Session["RT"];
                if (_lsReturnDetails.Count > 0)
                {
                    Response.Redirect("~/Forms/Web Forms/frmRMAEnterWithPO.aspx?RMAPO=" + Session["PO"].ToString());
                }
                else
                {

                    try
                    {


                        if (Session["PO"] != null)
                        {
                            mpeForWarning.Show();
                            // String po1 = txtPONumber.Text.Trim();
                            // Session["PO"] = po1;
                            //string ponumber = Session["PO"].ToString();
                            DataGrid.Show();
                            //ShowGrid(ponumber);

                            btnCancelForPO.Visible = false;
                        }


                    }
                    catch (Exception)
                    {
                    }


                }
                txtPONumber.Text = "";
            }

                //Open It Afterwords



                //String po = txtPONumber.Text.Trim();
                ////List<RMAInfo> lsCustomeronfo = _newRMA.GetCustomer(po);
                //////List<RMAInfo> lsCustomeronfo = _newRMA.GetCustomer(RGA);
                ////                 Obj._lsReturnDetailsWithPO = lsCustomeronfo;
                ////                 var ReaturnDetails = from Rs in lsCustomeronfo
                ////                                      select new
                ////                                      {
                ////                                          // Rs.RGADROWID,
                ////                                          Rs.SKUNumber,
                ////                                      };

                ////List<string> _lsReturnDetails = new List<string>();
                ////_lsReturnDetails = ReaturnDetails.ToList();

                ////GridView gvforrd=new GridView();
                ////gvforrd.DataSource=ReaturnDetails.ToList();
                ////gvforrd.DataBind();

                //List<string> _lsReturnDetails = new List<string>();
                ////dtforrd.Columns.Add("SKU");
                //for (int i = 0; i < gvReturnDetails.Rows.Count; i++)
                //{
                //    //DataRow drforrd = dtforrd.NewRow();
                //    //drforrd["SKU"] = gvReturnDetails.Rows[i];
                //    _lsReturnDetails.Add(gvReturnDetails.Rows[i].Cells[0].Text);
                //}
            
        }

        public void ShowGrid(string po)
        {
            //String po = txtPONumber.Text.Trim();
            //Session["PO"] = po;
            if (_ReturnDetails.IsPONumberAlreadyPresent(po))
            {
                mpeForPresentedPO.Show();
            }
            else
            {
                List<RMAInfo> lsCustomeronfo = _newRMA.GetCustomer(po);

                if (lsCustomeronfo.Count > 0)
                {
                    try
                    {
                        FillReturnDetails(lsCustomeronfo);
                    }
                    catch (Exception ex)
                    {
                    }
                    DataGrid.Show();
                    lblMessageForPO.Text = "Select SKU'S from PO number:- " + po;
                    //Response.Redirect("~/Forms/Web Forms/frmRMAEnterWithPO.aspx?RMAPO=" + po);
                }
                else
                {
                    mpeForWrongPO.Show();
                }
            }
        }

        //protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        //{
        //    List<string> _lsReturnDetails = new List<string>();
        //    for (int j = 0; j < gvReturnDetails.Rows.Count; j++)
        //    {
        //        CheckBox cb = (gvReturnDetails.Rows[j].FindControl("CheckBox1")) as CheckBox;
        //        if (cb.Checked == true)
        //        {
        //            string ReturnLines = gvReturnDetails.Rows[j].Cells[1].Text.ToString();
        //            _lsReturnDetails.Add(ReturnLines);
        //        }
        //    }
        //    Session["RT"] = _lsReturnDetails;
        //}



        //    foreach (GridViewRow row in gvReturnDetails.Rows)
        //    {


        //        CheckBox cb = (CheckBox)gvReturnDetails.Rows.FindControl("CheckBox1");
        //        if (cb.Checked && gvReturnDetails.Rows)
        //        {

        //            //                         Label username = (Label)row.FindControl("Label1");
        //            //                          Membership.DeleteUser(username.Text);
        //            //                           BindGridviewData();
        //            //}
        //        }
        //    }


        //    Session["SKUNumber"] = new List<string>();

        //    Session[po] = txtPONumber.Text.Trim();
        //    //foreach (GridViewRow row in gvReturnDetails.Rows)
        //    //{
        //    for (int j = 0; j < gvReturnDetails.Rows.Count; j++)
        //    {
        //        String SKUNumber = (gvReturnDetails.Rows[j].FindControl("CheckBox1") as CheckBox).ToString();
        //        // CheckBox cb = (gvReturnDetails.Rows[j].FindControl("CheckBox1")) as CheckBox;
        //        if (Session[po] == Session[SKUNumber])
        //        {
        //            Response.Redirect("~/Forms/Web Forms/frmSRNumber.aspx");
        //        }
        //    }
        //}
        //if (lsCustomeronfo.Count > 0)
        //{
        //    Response.Redirect("~/Forms/Web Forms/frmRMAEnterWithPO.aspx?RMAPO=" + po);
        //}
        //}
        //    foreach (GridViewRow gvRow in gvReaturnDetails.Rows)
        //   {

        //   CheckBox cb = (CheckBox)gvRow.Cells[0].FindControl("chk");
        //   if (cb != null && cb.Checked)
        //{
        //    responce.redirect("~/Forms/Web Forms/frmSRNumber.aspx");
        //}
        //else
        //{
        //   responce.redirect("~/Forms/Web Forms/frmRMAEnter.aspx");

        //}



        protected void btnYesSR_Click(object sender, EventArgs e)
        {
            String SRNumber = txtSRNumber.Text.Trim();
            if (_ReturnDetails.IsSRNumberAlreadyPresent(SRNumber))
            {
                mpeForPresentedSR.Show();
            }
            else
            {
                // Views.Global.lsReturnGlobalBySRNumber = _newRMA.GetCustomerByRMANumber(srnumber);

                List<RMAInfo> lsCustomeronfo = _newRMA.GetCustomerByRMANumber(SRNumber);
                if (lsCustomeronfo.Count > 0)
                {
                    try
                    {
                        //FilReturnDetailsForSR(lsCustomeronfo);
                    }
                    catch (Exception ex)
                    {
                    }
                    // DataGrid1.Show();
                    Response.Redirect("~/Forms/Web Forms/frmSRNumber.aspx?RMANumber=" + SRNumber);
                    //Response.Redirect("~/Forms/Web Forms/frmRMAEnterWithPO.aspx?RMAPO=" + po);
                }
                else
                {
                    mpeForWrongSR.Show();
                }
            }
        }

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            switch (e.Item.Value)
            {
                case "Add RMA With PO":
                    // Response.Write("<script>window.open('Default.aspx', 'hello', 'width=700,height=400,scrollbars=yes');</script>");
                    mpeForPO.Show();
                    return;
                //case "Add RMA Without PO":
                //    return;
                case "Add RMA With SR":
                    mpeForSR.Show();
                    return;
            }
        }

        protected void btnCancelForPO_Click(object sender, EventArgs e)
        {
            DataGrid.Hide();

            txtPONumber.Text = "";
            Session["PO"] = "";
            

        }

        //protected void Button7_Click(object sender, EventArgs e)
        //{
        //    FillReturnDetails(Obj.Rcall.ReturnDetailByPoNumber(Request.QueryString["RMAPO"].ToString()));
        //    String po = txtPONumber.Text.Trim();

        //    List<RMAInfo> lsCustomeronfo = _newRMA.GetCustomer(po);
        //    Session["SKUNumber"] = new List<string>();

        //    Session[po] = txtPONumber.Text.Trim();
        //    foreach (GridViewRow row in gvReturnDetails.Rows)
        //    {
        //    for (int j = 0; j < gvReturnDetails.Rows.Count; j++)
        //    {
        //        String SKUNumber = (gvReturnDetails.Rows[j].FindControl("CheckBox1") as CheckBox).ToString();
        //         CheckBox cb = (gvReturnDetails.Rows[j].FindControl("CheckBox1")) as CheckBox;
        //        if (Session[po] == Session[SKUNumber])
        //        {
        //            Response.Redirect("~/Forms/Web Forms/frmSRNumber.aspx");
        //        }
        //    }
        //}

        //              List<ListItem> selectItems = new List<ListItem>();

        //foreach (ListItem item in cblScope.Items)
        //{
        //    if (item.Selected)
        //        selectItems.Add(item);
        //}

        //Session.Add("MySelectedItems", selectItems);


        //        }

    }
}
