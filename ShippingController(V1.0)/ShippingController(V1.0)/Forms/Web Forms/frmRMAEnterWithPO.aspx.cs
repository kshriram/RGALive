//using KrausRGA.Models;

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
using System.Net;

namespace ShippingController_V1._0_.Forms.Web_Forms
{

    public partial class frmRMAEnterWithPO : System.Web.UI.Page
    {
        cmdReturn _retn = new cmdReturn();

        modelReaturnUpdate _Update = new modelReaturnUpdate();
        DataTable dt = new DataTable();
        DataTable DtTracking = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable DtReturnReason = new DataTable();
        //  cmdRMAInfo cd = new cmdRMAInfo();
        //  mPOnumberRMA _mponumber = new mPOnumberRMA();
        List<RMAInfo> _lsRMAInfo = new List<RMAInfo>();
        Models.modelReturn _newRMA = new Models.modelReturn();
        List<ReturnedSKUPoints> listofstatus = new List<ReturnedSKUPoints>();
        Boolean NonPo = true;
        DateTime eastern = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "Eastern Standard Time");

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
                Session["PO"] = "";
                SavedShowComments();
                Session["Admin Page"] = "Add RMA With PO";
                Session["_lsSlipPrintSKUNumber"] = new List<string>();
                List<RMAComment> rmaComment = new List<RMAComment>();

                Session["rmacomment"] = rmaComment;

                List<SkuReasonIDSequence> lsskureason = new List<SkuReasonIDSequence>();
                Session["_lsReasonSKU"] = lsskureason;

                Session["FlagForPrint"] = "1";

                DtTracking.Columns.Add("SKU", typeof(string));
                DtTracking.Columns.Add("ReturnLineForSKU", typeof(int));
                DtTracking.Columns.Add("TrackingNumber", typeof(string));
                Session["DtTracking"] = DtTracking;

                List<cSlipInfo> _lsslipinfo = new List<cSlipInfo>();
                DtReturnReason.Columns.Add("SKU", typeof(string));
                DtReturnReason.Columns.Add("Reason", typeof(string));
                DtReturnReason.Columns.Add("Reason_Value", typeof(string));
                DtReturnReason.Columns.Add("Points", typeof(int));
                DtReturnReason.Columns.Add("ItemQuantity", typeof(string));
                DtReturnReason.Columns.Add("ReturnLineForSKU", typeof(int));
                DtReturnReason.Columns.Add("FromDDLOrText", typeof(int));
                DtReturnReason.Columns.Add("OtherDecisionReason", typeof(string));
                Session["dt"] = DtReturnReason;

                display(Request.QueryString["RMAPO"].ToString());
                List<ReturnDetail> _lsReturnDetails = (List<ReturnDetail>)(Session["RT"]);



                List<RMAInfo> _lsRMAInfo = new List<RMAInfo>();
                List<RMAInfo> _lsRMAInfo1 = new List<RMAInfo>();

                //String po = txtPONumber.Text.Trim();
                //  List<RMAInfo> lsCustomeronfo = _newRMA.GetCustomer(po);
                //for grid of admin
                string ponumber = Request.QueryString["RMAPO"].ToString();
                _lsRMAInfo = _newRMA.GetCustomer(ponumber);

                foreach (var rm in _lsRMAInfo)
                {
                    foreach (var rd in _lsReturnDetails)
                    {
                        if (rm.SKUNumber == rd.SKUNumber && rm.ReturnLines == rd.ReturnLines)
                        {
                            RMAInfo rma = new RMAInfo();

                            // _lsRMAInfo1.Add(rm);
                            var ReaturnDetails = from Rs in _lsReturnDetails
                                                 select new
                                                 { // Rs.RGADROWID,
                                                     Rs.SKUNumber,
                                                     Rs.SKU_Qty_Seq,
                                                     // Rs.SKU_Status,
                                                     SKU_Status = "",
                                                     Rs.SKU_Sequence,
                                                     Rs.ProductID,
                                                     Rs.SalesPrice,
                                                     Rs.LineType,
                                                     Rs.ShipmentLines,
                                                     Rs.ReturnLines,
                                                       //Rs.tr
                                                     //   ReasonIDs = _Update.ReasonsIdByHasg(Rs.ReturnDetailID),
                                                     ImageName = "",
                                                     NoofImages = "",
                                                     //string imagename=""
                                                     TrackingNumber = "---",
                                                     ReceivedDate = DateTime.Now.ToShortDateString()

                                                 };




                            gvReturnDetails.DataSource = ReaturnDetails.ToList();
                            gvReturnDetails.DataBind();


                            GetCount();

                        }
                    }
                }

                for (int j = 0; j < gvReturnDetails.Rows.Count; j++)
                {
                    TextBox QTY = (gvReturnDetails.Rows[j].FindControl("txtSKU_Qty_Seq")) as TextBox;

                    if (QTY.Text == "0")
                    {
                        QTY.Text = "---";
                    }
                }
                //List<ReturnDetail> _lsReturnDetails1 = (List<ReturnDetail>)(Session["RT"]);



                //List<RMAInfo> _IsRMA = new List<RMAInfo>();
                //List<RMAInfo> _lsRMAInfo2 = new List<RMAInfo>();

                ////String po = txtPONumber.Text.Trim();
                ////  List<RMAInfo> lsCustomeronfo = _newRMA.GetCustomer(po);

                //string ponumber1 = Request.QueryString["RMAPO"].ToString();
                //_lsRMAInfo = _newRMA.GetCustomer(ponumber1);

                //foreach (var rm in _IsRMA)
                //{
                //    foreach (var rd in _lsReturnDetails1)
                //    {
                //        if (rm.SKUNumber == rd.SKUNumber && rm.ReturnLines == rd.ReturnLines)
                //        {
                //            RMAInfo rma = new RMAInfo();

                //            // _lsRMAInfo1.Add(rm);
                //            var ReaturnDetails = from Rs in _lsReturnDetails1
                //                                 select new
                //                                 { // Rs.RGADROWID,
                //                                     Rs.SKUNumber,
                //                                     Rs.SKU_Qty_Seq,
                //                                     // Rs.SKU_Status,
                //                                     SKU_Status = "",
                //                                     Rs.SKU_Sequence,
                //                                     Rs.ProductID,
                //                                     Rs.SalesPrice,
                //                                     Rs.LineType,
                //                                     Rs.ShipmentLines,
                //                                     Rs.ReturnLines,
                //                                     //   Rs.ReturnDetailID,
                //                                     //   ReasonIDs = _Update.ReasonsIdByHasg(Rs.ReturnDetailID),
                //                                     ImageName = "",
                //                                     NoofImages = "",
                //                                     //string imagename=""


                //                                 };




                //            gvReturnDetails.DataSource = ReaturnDetails.ToList();
                //            gvReturnDetails.DataBind();


                //            GetCount();

                //        }
                //    }
                //}






                //dt.Columns.Add("SKU", typeof(string));
                //dt.Columns.Add("Reason", typeof(string));
                //dt.Columns.Add("Reason_Value", typeof(string));
                //dt.Columns.Add("Points", typeof(int));
                //dt.Columns.Add("ItemQuantity", typeof(string));

                //dt.Columns.Add("ReturnedSKUID", typeof(Guid));
                //dt.Columns.Add("ReturnDetailID", typeof(Guid));


                // FillReturnDetails(Obj.Rcall.ReturnDetailByPoNumber(Request.QueryString["RMAPO"].ToString()));

                //  fillGrid();


                //  fillReturnedstatusandpoit();

                //  GetLatestUser();

                fillReturnDetailAndStatus();

                fillddlotherReasons();
                // ShowComments();
                //   FillReturnDetails(Obj.Rcall.ReturnDetailByPoNumber(Request.QueryString["RGAROWID"]));
            }
            //  ShowComments();
        }
        //public void GetLatestUser()
        //{
        //    //UserMaster user = new UserMaster();
        //    Guid userId = (Guid)Views.Global.ReteunGlobal.CreatedBy;
        //    Obj.Rcall.GetUserInfobyUserID(userId);
        //    lblUserName.Text = Obj.Rcall.GetUserInfobyUserID(userId).UserFullName;
        //    string dr = Convert.ToString(Obj.Rcall.GetUserInfobyUserID(userId).UserID);
        //}
        //public void FillReturnDetails5(List<RMAInfo> ls)
        //{
        //      try
        //      {

        //        Obj._lsReturnDetailsWithPO = ls;
        //        var ReaturnDetails = from Rs in ls
        //                             select new
        //                             {
                                        
        //                                 //   Rs.ReturnDetailID,
        //                                 //   ReasonIDs = _Update.ReasonsIdByHasg(Rs.ReturnDetailID),
        //                                 ImageName = "",
        //                                 NoofImages = "",
        //                                 //string imagename=""


        //                             };


        //        gvReturnDetails3.DataSource = ReaturnDetails.ToList();
        //        gvReturnDetails3.DataBind();
              



        //    }
        //    catch (Exception)
        //    { }
        //}

        
        
        
        public void FillReturnDetails(List<RMAInfo> ls)
        {
            try
            {

                Obj._lsReturnDetailsWithPO = ls;
                var ReaturnDetails = from Rs in ls
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
                                         //   Rs.ReturnDetailID,
                                         //   ReasonIDs = _Update.ReasonsIdByHasg(Rs.ReturnDetailID),
                                         ImageName = "",
                                         NoofImages = "",
                                         //string imagename=""


                                     };


                gvReturnDetails.DataSource = ReaturnDetails.ToList();
                gvReturnDetails.DataBind();
                gvReturnDetails.Columns[2].Visible = false;
                gvReturnDetails.Columns[3].Visible = false;
                gvReturnDetails.Columns[4].Visible = false;
                gvReturnDetails.Columns[5].Visible = false;
                gvReturnDetails.Columns[6].Visible = false;




            }
            catch (Exception)
            { }
        }



        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            //Deleting Previously added TrackingNumber for SKU

            for (int i = ((DataTable)Session["DtTracking"]).Rows.Count - 1; i >= 0; i--)
            {
                DataRow d = ((DataTable)Session["DtTracking"]).Rows[i];
                if (d["SKU"].ToString() == ViewState["SelectedskuName"].ToString() && d["ReturnLineForSKU"].ToString() == ViewState["SelectedreturnLine"].ToString())
                {
                    d.Delete();
                }
            }

            //Inserting New TrackingNumber for SKU

            for (int j = 0; j < gvReturnDetails.Rows.Count; j++)
            {
                RadioButton rb = (gvReturnDetails.Rows[j].FindControl("RadioButton1")) as RadioButton;
                if (rb.Checked == true)
                {
                    TextBox txtTracking = (gvReturnDetails.Rows[j].FindControl("txtTrackingNumber") as TextBox);

                    String TrackingNumber = (gvReturnDetails.Rows[j].FindControl("txtTrackingNumber") as TextBox).Text;

                    DataRow dr = ((DataTable)Session["DtTracking"]).NewRow();
                    dr["SKU"] = ViewState["SelectedskuName"];
                    dr["ReturnLineForSKU"] = ViewState["SelectedreturnLine"];
                    dr["TrackingNumber"] = TrackingNumber;

                    ((DataTable)Session["DtTracking"]).Rows.Add(dr);

                    txtTracking.BackColor = System.Drawing.ColorTranslator.FromHtml("Red");
                    txtTracking.ForeColor = System.Drawing.ColorTranslator.FromHtml("Black");
                }
            }


        }




        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "deleterow")
                {
                    List<fileps> lstpath = new List<fileps>();
                    ///   DirectoryInfo dir = new DirectoryInfo(Server.MapPath("~/Themes/img"));
                    string path = @"\\192.168.1.172\Macintosh HD\ftp_share\RGAImages\";
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = GridView1.Rows[index];
                    //string skuNumber = ((gvReturnDetails.row.FindControl("txtSKU")) as TextBox).Text;
                    // string name1 = ((Label)gvReturnDetails.Rows[i].FindControl("lblImagesName")).Text;
                    //string name1 = ((Label)row.Cells[2].FindControl("FilePath")).Text;
                    string name1 = row.Cells[2].Text;
                    Label lbl = row.FindControl("lblFileName") as Label;
                    //string ReturnLine = (row.FindControl("FilePath") as TextBox).Text;
                    //TextBox name2 = ((TextBox)row.Cells[3].FindControl("FilePath"));
                    string d = lbl.Text;
                    //string name1 = (row.FindControl("FilePath") as Label).Text;
                    // string name =path+row.Cells[4].Text;
                    //  FileInfo[] file = dir.GetFiles();
                    File.Delete(d);
                    //for (int i = 0; i < gvReturnDetails.Rows.Count; i++)
                    //{
                    //   // ((Label)gvReturnDetails.Rows[i].FindControl("lblImagesName")).Text = "";
                    //    ((LinkButton)gvReturnDetails.Rows[i].FindControl("txtImageCount")).Text = "0" + " " + "Image(s)";
                    //}

                    //   GridViewRow gvRow = (sender as LinkButton).NamingContainer as GridViewRow;
                    for (int i = 0; i < gvReturnDetails.Rows.Count; i++)
                    {

                        string lblshipmentLine = (gvReturnDetails.Rows[i].FindControl("txtShipmentLines") as TextBox).Text;
                        string lblreturnline = (gvReturnDetails.Rows[i].FindControl("txtReturnLines") as TextBox).Text;
                        string lblSKU_Sequence = (gvReturnDetails.Rows[i].FindControl("txtSKU_Sequence") as TextBox).Text;
                        if (lblshipmentLine == hdfShipmentLine.Value && lblreturnline == hdRetunLine.Value && lblSKU_Sequence == hdfskusequence.Value)
                        {
                            string ImageNo = (gvReturnDetails.Rows[i].FindControl("txtImageCount") as LinkButton).Text;
                            int img = Convert.ToInt16(ImageNo.Split(new char[] { ' ' })[0]);
                            int noOfImages;
                            noOfImages = img - 1;
                            (gvReturnDetails.Rows[i].FindControl("txtImageCount") as LinkButton).Text = noOfImages.ToString() + " " + "Image(s)";
                        }
                    }

                    //this.GridView1.Columns[2].Visible = false;
                    //this.GridView1.Columns[3].Visible = false;////NoofImages

                    // bindData();
                    //File.Delete(name);

                    //  DirectoryInfo dir = new DirectoryInfo(@"D:/images");
                    //FileInfo[] file = dir.GetFiles();
                    //foreach (FileInfo f2 in file)
                    //{
                    //    fileps ls = new fileps();
                    //  ls.FilePath = @"\\192.168.1.172\Macintosh HD\ftp_share\RGAImages\" + f2.Name;
                    //ls.FilePath = @"~/Themes/img/" + f2.Name;
                    //ls.FileName = f2.Name;
                    //// ExtensionMethods.Upload(@"\\192.168.1.172\Macintosh HD\ftp_share\RGAImages", "mediaserver", "kraus2013", "C:\\Images\\" + fileName.ToString(), bytes);
                    //ExtensionMethods.Upload(@"ftp://fileshare.kraususa.com", "rgauser", "rgaICG2014", "C:\\Images\\" + fileName.ToString(), bytes);
                    //lstpath.Add(ls);
                    //lstpath.Add(f2.Name);
                    //Console.WriteLine(dir);

                    //}

                }
            }
            catch (Exception)
            {
            }
        }
        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (Repeater1.Items.Count < 1)
            {
                if (e.Item.ItemType == ListItemType.Footer)
                {
                    Label lblFooter = (Label)e.Item.FindControl("lblEmptyData");
                    lblFooter.Visible = true;
                }
            }
        }


        protected void btnCancelBox_Click(object sender, EventArgs e)
        {
            mpePopupForCancelBox.Show();
        }


        protected void btnCancelHeader_Click1(object sender, EventArgs e)
        {
            mpeForCancel1.Show();
        }
        protected void btnYesForCancel_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/Forms/Web Forms/DemoGrid.aspx");
        }

        public void SavedShowComments()
        {
            DataTable dtRepeater = new DataTable();
            dtRepeater.Columns.Add("UserName");
            dtRepeater.Columns.Add("Time");
            dtRepeater.Columns.Add("Content");


            Repeater1.DataSource = dtRepeater;
            Repeater1.DataBind();
            //if(txtcomment.Text!="" || txtcomment.Text!=null)
            //{
            //    DataRow rd = dtRepeater.NewRow();
            //    string Usernm = Obj.Rcall.GetUserInfobyUserID((Guid)Session["UserID"]).UserFullName;

            //    rd["UserName"] = Usernm;
            //    rd["Time"] = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "Eastern Standard Time").ToString("MM/dd/yyyy hh:mm tt");
            //    rd["Content"] = txtcomment.Text;               
            //    dtRepeater.Rows.Add(rd);
            //}


            //string comment = "";
            //List<RMAComment> lsComment = Obj.Rcall.GetRMACommentByReturnID(((Return)Session["ReteunGlobal"]).ReturnID);

            //foreach (var item in lsComment)
            //{
            //    comment = comment + item.Comment;
            //}
            //lblcomments.Text = comment;
        }



        protected void btnOk_Click(object sender, EventArgs e)
        {

            // this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked YES!')", true);

            Response.Redirect(@"~\Forms\Web Forms\DemoGrid.aspx");
        }

        protected void lkbtnPath_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmHomePage.aspx");
        }

        public void fillReturnDetailAndStatus()
        {
            //List<ReturnDetail> retuen = Obj.Rcall.ReturnDetailByRGAROWID(Request.QueryString["RGAROWID"]);
            //Views.Global.lsSKUReasons = Obj.Rcall.SKUReasonsByReturnDetails(retuen);



            //foreach (var item in Views.Global.lsSKUReasons)
            //{

            //    SkuReasonIDSequence lsskusequenceReasons = new SkuReasonIDSequence();
            //    lsskusequenceReasons.ReasonID = item.ReasonID;
            //    lsskusequenceReasons.SKU_sequence = item.//Convert.ToInt16(Convert.ToInt16(ViewState["ItemQuantity"]));
            //    lsskusequenceReasons.SKUName = ViewState["SelectedskuName"].ToString();
            //    Views.Global._lsReasonSKU.Add(lsskusequenceReasons);
            //}
            List<StatusAndPoints> listofstatusAndPoint = new List<StatusAndPoints>();
            for (int i = 0; i < Obj._lsReturnDetails.Count; i++)
            {
                StatusAndPoints _lsstatusandpoints = new StatusAndPoints();

                //  Session["listofstatusAndPoint"] = _lsstatusandpoints;



                if (Obj._lsReturnDetails[i].SKU_Status != "")
                {
                    _lsstatusandpoints.SKUName = Obj._lsReturnDetails[i].SKUNumber;
                    _lsstatusandpoints.Status = Obj._lsReturnDetails[i].SKU_Status;
                    _lsstatusandpoints.Points = Obj._lsReturnDetails[i].SKU_Reason_Total_Points;
                    _lsstatusandpoints.IsMannually = Obj._lsReturnDetails[i].IsManuallyAdded;
                    _lsstatusandpoints.IsScanned = Obj._lsReturnDetails[i].IsSkuScanned;
                    _lsstatusandpoints.NewItemQuantity = Obj._lsReturnDetails[i].SKU_Sequence;
                    _lsstatusandpoints.skusequence = Obj._lsReturnDetails[i].SKU_Qty_Seq;


                    // Session["listofstatusAndPoint"] = listofstatusAndPoint

                    listofstatusAndPoint.Add(_lsstatusandpoints);
                }

            }
            Session["listofstatusAndPoint"] = listofstatusAndPoint;

            // ViewState["ReturnStatus"] = listofstatusAndPoint;
        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
               // btnDelete.Enabled = false;
                btnsubmit.Enabled = false;


                brdDefecttransite.Enabled = false;
                brdManufacturer.Enabled = false;
                brdstatus.Enabled = false;
                brdInstalled.Enabled = false;
                brdItemNew.Enabled = true;

                brdItemNew.Items.FindByText("Yes").Selected = false;
                brdItemNew.Items.FindByText("No").Selected = false;

                brdDefecttransite.Items.FindByText("Yes").Selected = false;
                brdDefecttransite.Items.FindByText("No").Selected = false;

                brdManufacturer.Items.FindByText("Yes").Selected = false;
                brdManufacturer.Items.FindByText("No").Selected = false;

                brdstatus.Items.FindByText("Yes").Selected = false;
                brdstatus.Items.FindByText("No").Selected = false;

                brdInstalled.Items.FindByText("Yes").Selected = false;
                brdInstalled.Items.FindByText("No").Selected = false;



                DataTable DT = new DataTable();
                DT = ViewState["dt"] as DataTable;

                for (int j = 0; j < gvReturnDetails.Rows.Count; j++)
                {
                    RadioButton rb = (gvReturnDetails.Rows[j].FindControl("RadioButton1")) as RadioButton;
                    if (rb.Checked == true)
                    {
                        // Id = gvReturnDetails.Rows[i].Cells[1].Text;

                        #region Deepak
                        String SKUNumberforprint = (gvReturnDetails.Rows[j].FindControl("txtSKU") as TextBox).Text;
                        ((List<String>)Session["_lsSlipPrintSKUNumber"]).Add(SKUNumberforprint);

                        // _lsSlipPrintSKUNumber.Add(SKUNumberforprint);

                       // gvReturnDetails.Rows[j].Enabled = true;
                        #endregion

                        String LinetType = (gvReturnDetails.Rows[j].FindControl("txtLineType") as TextBox).Text;

                        if (Convert.ToInt16(LinetType) != 6)
                        {
                            //String SKUNumber = (gvReturnDetails.Rows[j].FindControl("txtSKU") as TextBox).Text;

                            //ViewState["SelectedskuName"] = SKUNumber;

                            //String SKUSequence = (gvReturnDetails.Rows[j].FindControl("txtSKU_Sequence") as TextBox).Text;

                            //ViewState["ItemQuantity"] = SKUSequence;

                            //(gvReturnDetails.Rows[j].FindControl("txtSKU_Qty_Seq") as TextBox).Text = "1";

                            //String SkuQuantitySequence = (gvReturnDetails.Rows[j].FindControl("txtSKU_Qty_Seq") as TextBox).Text;

                            ////String ReturnDetailID = (gvReturnDetails.Rows[j].FindControl("txtSKU_Sequence") as TextBox).Text;

                            //string GuidReturnDetail = (gvReturnDetails.Rows[j].FindControl("lblguid") as Label).Text;

                            //ViewState["SkuQuantitySequence"] = SkuQuantitySequence;

                            //ViewState["ReturnDetailID"] = GuidReturnDetail;

                            ////row.Cells[5].Text = _mReturn.ConvertToDecision(Value1);

                            //String SKUStatus = (gvReturnDetails.Rows[j].FindControl("txtSKU_Status") as TextBox).Text;

                            //ViewState["Sku_status"] = SKUStatus;

                            //if (SKUStatus != "")
                            //{
                            //    for (int i = 0; i < DT.Rows.Count; i++)
                            //    {

                            //        // string kU = DT.Rows[i][1].ToString();

                            //        if (SKUNumber == DT.Rows[i][0].ToString() && SKUSequence == DT.Rows[i][4].ToString())
                            //        {
                            //            // msg = dt.Rows[i][1].ToString() + " : " + dt.Rows[i][2].ToString() + "\n" + msg;

                            //            string data1 = DT.Rows[i][1].ToString();
                            //            string data2 = DT.Rows[i][2].ToString();

                            //            if (DT.Rows[i][1].ToString() == "Item is New" && DT.Rows[i][2].ToString() == "Yes")
                            //            {
                            //                brdItemNew.Items.FindByText("Yes").Selected = true;
                            //            }
                            //            else if ((DT.Rows[i][1].ToString() == "Item is New" && DT.Rows[i][2].ToString() == "No"))
                            //            {
                            //                brdItemNew.Items.FindByText("No").Selected = true;
                            //            }
                            //            else if ((DT.Rows[i][1].ToString() == "Installed" && DT.Rows[i][2].ToString() == "Yes"))
                            //            {
                            //                brdInstalled.Items.FindByText("Yes").Selected = true;
                            //            }
                            //            else if ((DT.Rows[i][1].ToString() == "Installed" && DT.Rows[i][2].ToString() == "No"))
                            //            {
                            //                brdInstalled.Items.FindByText("No").Selected = true;
                            //            }
                            //            else if ((DT.Rows[i][1].ToString() == "Chip/Bended/Scratch/Broken" && DT.Rows[i][2].ToString() == "Yes"))
                            //            {
                            //                brdstatus.Items.FindByText("Yes").Selected = true;
                            //            }
                            //            else if ((DT.Rows[i][1].ToString() == "Chip/Bended/Scratch/Broken" && DT.Rows[i][2].ToString() == "No"))
                            //            {
                            //                brdstatus.Items.FindByText("No").Selected = true;
                            //            }
                            //            else if ((DT.Rows[i][1].ToString() == "Manufacturer Defective" && DT.Rows[i][2].ToString() == "Yes"))
                            //            {
                            //                brdManufacturer.Items.FindByText("Yes").Selected = true;
                            //            }
                            //            else if ((DT.Rows[i][1].ToString() == "Manufacturer Defective" && DT.Rows[i][2].ToString() == "No"))
                            //            {
                            //                brdManufacturer.Items.FindByText("No").Selected = true;
                            //            }
                            //            else if ((DT.Rows[i][1].ToString() == "Defect in Transite" && DT.Rows[i][2].ToString() == "Yes"))
                            //            {
                            //                brdDefecttransite.Items.FindByText("Yes").Selected = true;
                            //            }
                            //            else if ((DT.Rows[i][1].ToString() == "Defect in Transite" && DT.Rows[i][2].ToString() == "No"))
                            //            {
                            //                brdDefecttransite.Items.FindByText("No").Selected = true;
                            //            }
                            //        }
                            //    }


                            //    //for (int k = 0; k < Views.Global.lsSKUReasons.Count; k++)
                            //    //{
                            //    //    if (Views.Global.lsSKUReasons[k].ReturnDetailID == Guid.Parse(GuidReturnDetail))
                            //    //    {
                            //    //        System.Guid ReturnID = Views.Global.lsSKUReasons[k].ReturnDetailID;

                            //    //     //  string reas = Obj.Rcall.GetReasonstringbyReturnID(ReturnID);

                            //    //    //    ddlotherreasons.SelectedItem.Text = reas;

                            //    //        //cmbSkuReasons.Text = reas;
                            //    //    }
                            //    //}

                            //}
                            //else
                            //{

                            //    brdItemNew.Items.FindByText("Yes").Selected = false;
                            //    brdItemNew.Items.FindByText("No").Selected = false;

                            //    brdDefecttransite.Items.FindByText("Yes").Selected = false;
                            //    brdDefecttransite.Items.FindByText("No").Selected = false;

                            //    brdManufacturer.Items.FindByText("Yes").Selected = false;
                            //    brdManufacturer.Items.FindByText("No").Selected = false;

                            //    brdstatus.Items.FindByText("Yes").Selected = false;
                            //    brdstatus.Items.FindByText("No").Selected = false;

                            //    brdInstalled.Items.FindByText("Yes").Selected = false;
                            //    brdInstalled.Items.FindByText("No").Selected = false;


                            //}
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "fnCall", "<script language='javascript'>alert('Can not add comment/parent sku for combination item');</script>");
                            //  lblMassege.Text = "Can not add comment/parent sku for combination item";
                            //  string display = "This is Line Type 6";
                            // ClientScript.RegisterStartupScript(this.GetType(), "yourMessage", "alert('" + display + "');", true);

                            rb.Checked = false;

                            brdDefecttransite.Enabled = false;
                            brdManufacturer.Enabled = false;
                            brdstatus.Enabled = false;
                            brdInstalled.Enabled = false;
                            brdItemNew.Enabled = false;

                            brdItemNew.Items.FindByText("Yes").Selected = false;
                            brdItemNew.Items.FindByText("No").Selected = false;

                            brdDefecttransite.Items.FindByText("Yes").Selected = false;
                            brdDefecttransite.Items.FindByText("No").Selected = false;

                            brdManufacturer.Items.FindByText("Yes").Selected = false;
                            brdManufacturer.Items.FindByText("No").Selected = false;

                            brdstatus.Items.FindByText("Yes").Selected = false;
                            brdstatus.Items.FindByText("No").Selected = false;

                            brdInstalled.Items.FindByText("Yes").Selected = false;
                            brdInstalled.Items.FindByText("No").Selected = false;


                        }
                    }
                    else
                    {
                        LinkButton lnkImageCnt = (gvReturnDetails.Rows[j].FindControl("txtImageCount")) as LinkButton;
                        TextBox txtskuqty = (gvReturnDetails.Rows[j].FindControl("txtSKU_Qty_Seq")) as TextBox;
                        TextBox txtsku = (gvReturnDetails.Rows[j].FindControl("txtSKU")) as TextBox;
                        //LinkButton lnkImageCnt = (gvReturnDetails.Rows[j].FindControl("txtImageCount")) as LinkButton;
                        FileUpload fp1 = (gvReturnDetails.Rows[j].FindControl("FileUpload1")) as FileUpload;

                        Button btnupload = gvReturnDetails.Rows[j].FindControl("btnUpdate") as Button;

                        lnkImageCnt.Enabled = false;
                        txtskuqty.Enabled = false;
                        txtsku.Enabled = false;
                        fp1.Enabled = false;
                        btnupload.Visible = false;

                    }
                }
            }
            catch (Exception)
            {
            }

            //  GetCount();

        }

        public void fillddlotherReasons()
        {
            // List Of return Reasons.
            List<Reason> lsReturn1 = _newRMA.GetReasons();
            List<Reason> lsReturn = new List<Reason>();
            foreach (var Re in lsReturn1)
            {
                if (Re.ReasonFlag == 1)
                {
                    lsReturn.Add(Re);
                }
            }

            //Create Object Of Reason.
            //Fill Dropdown list Of OtherReason.
            Reason re = new Reason();
            re.ReasonID = Guid.NewGuid();
            re.Reason1 = "--Select--";

            lsReturn.Insert(0, re);

            ddlotherreasons.DataTextField = "Reason1";
            ddlotherreasons.DataValueField = "ReasonID";
            ddlotherreasons.DataSource = lsReturn;
            ddlotherreasons.DataBind();
        }
        protected void btnComment_Click(object sender, EventArgs e)
        {


            fnforComment();
            ShowComments();

            //  fnforComment();
            ////  List<RMAComment> lsComment = Obj.Rcall.GetRMACommentByReturnID(Views.Global.ReteunGlobal.ReturnID);
            //  DataTable dtRepeater = new DataTable();
            //  dtRepeater.Columns.Add("UserName");
            //  dtRepeater.Columns.Add("Time");
            //  dtRepeater.Columns.Add("Content");
            //  foreach (var item in lsComment.OrderByDescending(y => y.CommentDate))
            //  {

            //      DataRow rd = dtRepeater.NewRow();
            //      string Usernm = Obj.Rcall.GetUserInfobyUserID((Guid)item.UserID).UserFullName;

            //      rd["UserName"] = Usernm;
            //      rd["Time"] = item.CommentDate.ToString("MM/dd/yyyy hh:mm tt");
            //      rd["Content"] = item.Comment;
            //      dtRepeater.Rows.Add(rd);

            //  }
            //  Repeater1.DataSource = dtRepeater;
            //  Repeater1.DataBind();

            lblMassege.Text = "Comment Added";
            MpeForComment.Show();
        }
        #region Function For Comment
        public void fnforComment()
        {


            //foreach (var item in rmaComment)
            //{
            List<RMAComment> lscoment = new List<RMAComment>();

            lscoment = (List<RMAComment>)Session["rmacomment"];

            RMAComment lscomment = new RMAComment();
            lscomment.RMACommentID = Guid.NewGuid();
            lscomment.ReturnID = Guid.NewGuid();
            lscomment.UserID = (Guid)Session["UserID"];
            lscomment.Comment = txtcomment.Text;
            lscomment.CommentDate = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "Eastern Standard Time");

            // Views.Global.rmaComment.Add(lscomment);


            lscoment.Add(lscomment);

            Session["rmacomment"] = lscoment;

            //  }


            //rmaComment.RMACommentID = Guid.NewGuid();
            //rmaComment.ReturnID = Views.Global.ReteunGlobal.ReturnID;
            //rmaComment.UserID = (Guid)Session["UserID"];
            //rmaComment.Comment = txtcomment.Text;
            //rmaComment.CommentDate = DateTime.UtcNow;
            //Obj.Rcall.InsertRMACommnt(rmaComment);
            txtcomment.Text = "";
        }
        #endregion
        //public void fnforComment()
        //{
        //    RMAComment rmaComment = new RMAComment();

        //    rmaComment.RMACommentID = Guid.NewGuid();
        //    rmaComment.ReturnID = Views.Global.ReteunGlobal.ReturnID;
        //    rmaComment.UserID = (Guid)Session["UserID"];
        //    rmaComment.Comment = txtcomment.Text;
        //    rmaComment.CommentDate = DateTime.UtcNow;


        //    Obj.Rcall.InsertRMACommnt(rmaComment);

        //    txtcomment.Text = "";




        //}
        public void ShowComments()
        {
            //string comment = "";
            //List<RMAComment> lsComment = Obj.Rcall.GetRMACommentByReturnID(Views.Global.ReteunGlobal.ReturnID);

            //foreach (var item in lsComment)
            //{
            //    comment = comment + item.Comment;
            //}
            //lblcomments.Text = comment;

            ///Deeepak 19-08-2014
            ///

            // this.Controls.Add(new LiteralControl("<div style=' border-radius: 11px 0 0 11px;  border: 1px solid; position : absolute; color:#179090; left :958px; right : 50px; top :218px;width:395px;height:248px;overflow: auto;'>"));





            // //Guid userId = (Guid)Views.Global.ReteunGlobal.UpdatedBy;
            // //Obj.Rcall.GetUserInfobyUserID(userId);
            // // string comment = "";
            //// List<RMAComment> lsComment = Obj.Rcall.GetRMACommentByReturnID(Views.Global.ReteunGlobal.ReturnID);

            // List<RMAComment> rmaComment = new List<RMAComment>();

            // rmaComment = (List<RMAComment>)Session["rmacomment"];


            // foreach (var item in rmaComment.OrderByDescending(y => y.CommentDate))
            // {
            //     // comment = comment + item.Comment;

            //     this.Controls.Add(new LiteralControl("<table width='100%' >"));
            //     this.Controls.Add(new LiteralControl("<tr><td bgcolor='#8DC6FF'>"));
            //     this.Controls.Add(new LiteralControl("<h8> " + Obj.Rcall.GetUserInfobyUserID((Guid)item.UserID).UserFullName + " || " + item.CommentDate.ToString("MM/dd/yyyy hh:mm tt") + "</h8> "));
            //     this.Controls.Add(new LiteralControl("</td></tr><tr><td bgcolor='#FFFFFF'shape='rect'><b>" + item.Comment + "</td></tr>"));
            //     // this.Controls.Add(new LiteralControl("<h3>RMA REQUEST FORM <h3>"));
            //     // this.Controls.Add(new LiteralControl("<h8> ----------</h8> "));
            //     this.Controls.Add(new LiteralControl(" </table>"));
            // }
            // // lblcomments.Text = comment;
            // this.Controls.Add(new LiteralControl("</div>"));
            ///ENDD
            ///

            List<RMAComment> rmaComment = new List<RMAComment>();

            rmaComment = (List<RMAComment>)Session["rmacomment"];


            DataTable dtRepeater = new DataTable();
            dtRepeater.Columns.Add("UserName");
            dtRepeater.Columns.Add("Time");
            dtRepeater.Columns.Add("Content");

            // this.Controls.Add(new LiteralControl("<div style=' border-radius: 11px 0 0 11px;  border: 1px solid; position : absolute; color:#179090; left :  1190px; right : 50px; top :137px;width:360px;height:220px;overflow: auto;'>"));
            //List<RMAComment> lsComment = Obj.Rcall.GetRMACommentByReturnID(Views.Global.ReteunGlobal.ReturnID);
            foreach (var item in rmaComment.OrderByDescending(y => y.CommentDate))
            {
                DataRow rd = dtRepeater.NewRow();
                string Usernm = Obj.Rcall.GetUserInfobyUserID((Guid)item.UserID).UserFullName;

                rd["UserName"] = Usernm;
                rd["Time"] = item.CommentDate.ToString("MM/dd/yyyy hh:mm tt");
                rd["Content"] = item.Comment;
                dtRepeater.Rows.Add(rd);
            }

            Repeater1.DataSource = dtRepeater;
            Repeater1.DataBind();

        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {


            System.Threading.Thread.Sleep(3000);

            lblMassege.Text = "Process is completed";
            //((DataTable)Session["dt"]) = ViewState["dt"] as DataTable;

            //  List<StatusAndPoints> listofstatusAndPoint1 = new List<StatusAndPoints>();

            // listofstatusAndPoint1 = ViewState["ReturnStatus"] as List<StatusAndPoints>;

            //for (int i = ((DataTable)Session["dt"]).Rows.Count - 1; i >= 0; i--)
            //{
            //    DataRow d = ((DataTable)Session["dt"]).Rows[i];
            //    if (d["SKU"].ToString() == ViewState["SelectedskuName"].ToString() && d["ItemQuantity"].ToString() == ViewState["ItemQuantity"])
            //        d.Delete();
            //}


            #region Delete SKUReason From Datatable
            // Delete SKUReason from Session _lsReasonSKU for Previous SKUNumber
            for (int i = 0; i < ((List<SkuReasonIDSequence>)Session["_lsReasonSKU"]).Count; i++)
            {
                if (((List<SkuReasonIDSequence>)Session["_lsReasonSKU"])[i].SKUName == ViewState["SelectedskuName"].ToString() && ((List<SkuReasonIDSequence>)Session["_lsReasonSKU"])[i].SKU_sequence == Convert.ToInt32(Convert.ToInt32(ViewState["ItemQuantity"])))
                {
                    ((List<SkuReasonIDSequence>)Session["_lsReasonSKU"]).RemoveAt(i);
                }
            }

            #endregion



            for (int i = ((DataTable)Session["dt"]).Rows.Count - 1; i >= 0; i--)
            {
                DataRow d = ((DataTable)Session["dt"]).Rows[i];
                if (d["SKU"].ToString() == ViewState["SelectedskuName"].ToString() && d["ItemQuantity"].ToString() == ViewState["ItemQuantity"].ToString())
                {
                    d.Delete();
                }
            }


            #region DtOperaion
            DataRow dr = ((DataTable)Session["dt"]).NewRow();
            dr["SKU"] = ViewState["SelectedskuName"];
            dr["ItemQuantity"] = ViewState["ItemQuantity"];
            dr["ReturnLineForSKU"] = ViewState["SelectedreturnLine"];
            if (ddlotherreasons.SelectedIndex>0)
            {
		          dr["FromDDLOrText"]=1;
                 dr["OtherDecisionReason"]=ddlotherreasons.SelectedItem.Text;
            }
            else if(txtotherreasons.Text!="" || txtotherreasons.Text!=null)
            {
                 dr["FromDDLOrText"]=2;
                 dr["OtherDecisionReason"]=txtotherreasons.Text;
            }
            else 
            {
                 dr["FromDDLOrText"]=0;
                 dr["OtherDecisionReason"]="";
            }
            
           
            //  string retun = ViewState["ReturnDetailID"].ToString();

            //if (ViewState["ReturnDetailID"] == "")
            //{
            //    dr["ReturnDetailID"] = "00000000-0000-0000-0000-000000000000";
            //}
            //else
            //{
            //    dr["ReturnDetailID"] = ViewState["ReturnDetailID"];
            //}
            //dr[""]
            if (brdItemNew.Items.FindByText("Yes").Selected == true)
            {
                dr["Reason"] = lblitemNew.Text;
                dr["Reason_Value"] = "Yes";
                dr["Points"] = 100;
                ((DataTable)Session["dt"]).Rows.Add(dr);
            }
            else if (brdItemNew.Items.FindByText("No").Selected == true)
            {
                dr["Reason"] = lblitemNew.Text;
                dr["Reason_Value"] = "No";
                dr["Points"] = 0;
                ((DataTable)Session["dt"]).Rows.Add(dr);
            }

            DataRow dr1 = ((DataTable)Session["dt"]).NewRow();
            dr1["SKU"] = ViewState["SelectedskuName"];
            dr1["ItemQuantity"] = ViewState["ItemQuantity"];
            dr1["ReturnLineForSKU"] = ViewState["SelectedreturnLine"];
            //dr["ReturnLineForSKU"] = ViewState["SelectedreturnLine"];
            if (ddlotherreasons.SelectedIndex > 0)
            {
                dr1["FromDDLOrText"] = 1;
                dr1["OtherDecisionReason"] = ddlotherreasons.SelectedItem.Text;
            }
            else if (txtotherreasons.Text != "" || txtotherreasons.Text != null)
            {
                dr1["FromDDLOrText"] = 2;
                dr1["OtherDecisionReason"] = txtotherreasons.Text;
            }
            else
            {
                dr1["FromDDLOrText"] = 0;
                dr1["OtherDecisionReason"] = "";
            }
            
            //if (ViewState["ReturnDetailID"] == "")
            //{
            //    dr1["ReturnDetailID"] = "00000000-0000-0000-0000-000000000000";
            //}
            //else
            //{
            //    dr1["ReturnDetailID"] = ViewState["ReturnDetailID"];
            //}
            if (brdInstalled.Items.FindByText("Yes").Selected == true)
            {
                dr1["Reason"] = lblInstalled.Text;
                dr1["Reason_Value"] = "Yes";
                dr1["Points"] = 0;
                ((DataTable)Session["dt"]).Rows.Add(dr1);
            }
            else if (brdInstalled.Items.FindByText("No").Selected == true)
            {
                dr1["Reason"] = lblInstalled.Text;
                dr1["Reason_Value"] = "No";
                dr1["Points"] = 100;
                ((DataTable)Session["dt"]).Rows.Add(dr1);
            }

            DataRow dr2 = ((DataTable)Session["dt"]).NewRow();
            dr2["SKU"] = ViewState["SelectedskuName"];
            dr2["ItemQuantity"] = ViewState["ItemQuantity"];
            dr2["ReturnLineForSKU"] = ViewState["SelectedreturnLine"];
            //dr["ReturnLineForSKU"] = ViewState["SelectedreturnLine"];
            if (ddlotherreasons.SelectedIndex > 0)
            {
                dr2["FromDDLOrText"] = 1;
                dr2["OtherDecisionReason"] = ddlotherreasons.SelectedItem.Text;
            }
            else if (txtotherreasons.Text != "" || txtotherreasons.Text != null)
            {
                dr2["FromDDLOrText"] = 2;
                dr2["OtherDecisionReason"] = txtotherreasons.Text;
            }
            else
            {
                dr2["FromDDLOrText"] = 0;
                dr2["OtherDecisionReason"] = "";
            }
            
            //if (ViewState["ReturnDetailID"] == "")
            //{
            //    dr2["ReturnDetailID"] = "00000000-0000-0000-0000-000000000000";
            //}
            //else
            //{
            //    dr2["ReturnDetailID"] = ViewState["ReturnDetailID"];
            //}
            if (brdstatus.Items.FindByText("Yes").Selected == true)
            {
                dr2["Reason"] = lblstatus.Text;
                dr2["Reason_Value"] = "Yes";
                dr2["Points"] = 0;
                ((DataTable)Session["dt"]).Rows.Add(dr2);
            }
            else if (brdstatus.Items.FindByText("No").Selected == true)
            {
                dr2["Reason"] = lblstatus.Text;
                dr2["Reason_Value"] = "No";
                dr2["Points"] = 100;
                ((DataTable)Session["dt"]).Rows.Add(dr2);
            }

            DataRow dr3 = ((DataTable)Session["dt"]).NewRow();
            dr3["SKU"] = ViewState["SelectedskuName"];
            dr3["ItemQuantity"] = ViewState["ItemQuantity"];
            dr3["ReturnLineForSKU"] = ViewState["SelectedreturnLine"];
            //dr["ReturnLineForSKU"] = ViewState["SelectedreturnLine"];
            if (ddlotherreasons.SelectedIndex > 0)
            {
                dr3["FromDDLOrText"] = 1;
                dr3["OtherDecisionReason"] = ddlotherreasons.SelectedItem.Text;
            }
            else if (txtotherreasons.Text != "" || txtotherreasons.Text != null)
            {
                dr3["FromDDLOrText"] = 2;
                dr3["OtherDecisionReason"] = txtotherreasons.Text;
            }
            else
            {
                dr3["FromDDLOrText"] = 0;
                dr3["OtherDecisionReason"] = "";
            }
            
            //if (ViewState["ReturnDetailID"] == "")
            //{
            //    dr3["ReturnDetailID"] = "00000000-0000-0000-0000-000000000000";
            //}
            //else
            //{
            //    dr3["ReturnDetailID"] = ViewState["ReturnDetailID"];
            //}
            if (brdManufacturer.Items.FindByText("Yes").Selected == true)
            {
                dr3["Reason"] = lblManifacturerDefective.Text;
                dr3["Reason_Value"] = "Yes";
                dr3["Points"] = 100;
                ((DataTable)Session["dt"]).Rows.Add(dr3);
            }
            else if (brdManufacturer.Items.FindByText("No").Selected == true)
            {
                dr3["Reason"] = lblManifacturerDefective.Text;
                dr3["Reason_Value"] = "No";
                dr3["Points"] = 0;
                ((DataTable)Session["dt"]).Rows.Add(dr3);
            }

            DataRow dr4 = ((DataTable)Session["dt"]).NewRow();
            dr4["SKU"] = ViewState["SelectedskuName"];
            dr4["ItemQuantity"] = ViewState["ItemQuantity"];
            dr4["ReturnLineForSKU"] = ViewState["SelectedreturnLine"];
            //dr["ReturnLineForSKU"] = ViewState["SelectedreturnLine"];
            if (ddlotherreasons.SelectedIndex > 0)
            {
                dr4["FromDDLOrText"] = 1;
                dr4["OtherDecisionReason"] = ddlotherreasons.SelectedItem.Text;
            }
            else if (txtotherreasons.Text != "" || txtotherreasons.Text != null)
            {
                dr4["FromDDLOrText"] = 2;
                dr4["OtherDecisionReason"] = txtotherreasons.Text;
            }
            else
            {
                dr4["FromDDLOrText"] = 0;
                dr4["OtherDecisionReason"] = "";
            }
            
            //if (ViewState["ReturnDetailID"] == "")
            //{
            //    dr4["ReturnDetailID"] = "00000000-0000-0000-0000-000000000000";
            //}
            //else
            //{
            //    dr4["ReturnDetailID"] = ViewState["ReturnDetailID"];
            //}
            if (brdDefecttransite.Items.FindByText("Yes").Selected == true)
            {
                dr4["Reason"] = lblDefectintransite.Text;
                dr4["Reason_Value"] = "Yes";
                dr4["Points"] = 100;
                ((DataTable)Session["dt"]).Rows.Add(dr4);
            }
            else if (brdDefecttransite.Items.FindByText("No").Selected == true)
            {
                dr4["Reason"] = lblDefectintransite.Text;
                dr4["Reason_Value"] = "No";
                dr4["Points"] = 0;
                ((DataTable)Session["dt"]).Rows.Add(dr4);
            }
            #endregion

            StatusAndPoints _lsstatusandpoints = new StatusAndPoints();
            _lsstatusandpoints.SKUName = ViewState["SelectedskuName"].ToString();

            //if (!NonPo)
            //{
            //    Views.clGlobal.SKU_Staus = "Deny";
            //    NonPo = true;
            //}

            _lsstatusandpoints.Status = ViewState["Sku_status"].ToString();
            _lsstatusandpoints.Points = 100;//Views.clGlobal.TotalPoints;
            _lsstatusandpoints.NewItemQuantity = Convert.ToInt32(ViewState["ItemQuantity"]);
            _lsstatusandpoints.skusequence = Convert.ToInt32(ViewState["SkuQuantitySequence"]);

            //for (int i = 0; i < lsskuIsScanned.Count; i++)
            //{
            //    if (lsskuIsScanned[i].SKUName == SelectedskuName)
            //    {
            //        _lsstatusandpoints.IsScanned = lsskuIsScanned[i].IsScanned;
            //        break;
            //    }
            //}

            List<StatusAndPoints> mylist = new List<StatusAndPoints>();

            mylist = (List<StatusAndPoints>)Session["listofstatusAndPoint"];

            for (int i = mylist.Count - 1; i >= 0; i--)
            {
                if (mylist[i].SKUName == ViewState["SelectedskuName"] && mylist[i].NewItemQuantity == Convert.ToInt32(ViewState["ItemQuantity"]))
                {
                    mylist.RemoveAt(i);
                }
            }


            _lsstatusandpoints.IsMannually = 0;

            mylist.Add(_lsstatusandpoints);

            ((List<StatusAndPoints>)Session["listofstatusAndPoint"]).Add(_lsstatusandpoints);



            #region SaveSKUReason
          
            Guid SkuReasonID = Guid.NewGuid();
            if (txtotherreasons.Text != "")
            {
                SkuReasonID = Obj.Rcall.UpsertReasons(txtotherreasons.Text);
            }
            else
            {
                SkuReasonID = new Guid(ddlotherreasons.SelectedValue);
            }
            SkuReasonIDSequence lsskusequenceReasons = new SkuReasonIDSequence();
            lsskusequenceReasons.ReasonID = SkuReasonID;
            lsskusequenceReasons.SKU_sequence = Convert.ToInt32(Convert.ToInt32(ViewState["ItemQuantity"]));
            lsskusequenceReasons.SKUName = ViewState["SelectedskuName"].ToString();



            ((List<SkuReasonIDSequence>)Session["_lsReasonSKU"]).Add(lsskusequenceReasons);


            #endregion


        




            btnsubmit.Enabled = false;


            brdDefecttransite.Enabled = false;
            brdManufacturer.Enabled = false;
            brdstatus.Enabled = false;
            brdInstalled.Enabled = false;
            brdItemNew.Enabled = false;

            brdItemNew.Items.FindByText("Yes").Selected = false;
            brdItemNew.Items.FindByText("No").Selected = false;

            brdDefecttransite.Items.FindByText("Yes").Selected = false;
            brdDefecttransite.Items.FindByText("No").Selected = false;

            brdManufacturer.Items.FindByText("Yes").Selected = false;
            brdManufacturer.Items.FindByText("No").Selected = false;

            brdstatus.Items.FindByText("Yes").Selected = false;
            brdstatus.Items.FindByText("No").Selected = false;

            brdInstalled.Items.FindByText("Yes").Selected = false;
            brdInstalled.Items.FindByText("No").Selected = false;

            txtotherreasons.Text = "";
            ddlotherreasons.SelectedIndex = 0;

          //  mpePopupForSubmitYes.Show();
        }

        protected void btnEmail_Click(object sender, EventArgs e)
        {
            if (gvReturnDetails.Rows.Count > 0)
            {

                List<Return> _lsreturn = new List<Return>();
                Return ret = new Return();
                ret.RMANumber = txtRMAnumber.Text;
                ret.VendoeName = txtvendorName.Text;
                ret.VendorNumber = txtvendornumber.Text;
                ret.ScannedDate = DateTime.UtcNow;
                ret.ExpirationDate = DateTime.UtcNow.AddDays(60);
                //   eastern = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(txtRMAReqDate.SelectedDate.Value, "Eastern Standard Time");
                ret.ReturnDate = Convert.ToDateTime(txtreturndate.Text);
                ret.PONumber = txtponumber.Text;
                ret.CustomerName1 = txtcustomerName.Text;
                //ret.Address1 = txtAddress.Text;
                //   ret.City = txtCustCity.Text;
                //   ret.Country = txtCountry.Text;
                //   ret.ZipCode = txtZipCode.Text;
                //   ret.State = txtState.Text;
                ret.CallTag = TextBox1.Text;
                ret.RGAROWID = txtrganumber.Text;

                _lsreturn.Add(ret);

                int InProgress = 0;

                if (chkflag.Checked == true)
                {
                    InProgress = 1;
                }
                //Save to RMA Master Table.
                //  Guid ReturnTblID = _mNewRMA.SetReturnTbl(_lsreturn, "", RMAStatus, Decision, clGlobal.mCurrentUser.UserInfo.UserID, Views.clGlobal.WrongRMAFlag, Views.clGlobal.Warranty, 60, 0, InProgress, txtcalltag.Text);

            }
        }
        protected void txtImageCount_Click(object sender, EventArgs e)
        {
            ////////////this.Controls.Add(new LiteralControl("<div id='myP' style=' border-radius: 11px 0 0 11px;  border: 1px solid; position : absolute; color:#179090; left : 50px; right : 50px; top :49px;width:auto !important; max-width:1240px;height:430px;overflow: auto;'>"));
            ////////////this.Controls.Add(new LiteralControl("<b><input type='submit' align='right' onclick='demoDisplay()' value='Close' ><table id='tblmg' height='100%' width='100%' bgcolor='#00FF00'><tr><td bgcolor='#8DC6FF'>"));


            ////////////GridViewRow gvRow = (sender as LinkButton).NamingContainer as GridViewRow;

            //////////////string ReturndetailID = (gvRow.FindControl("lblguid") as Label).Text;
            ////////////if ((gvRow.FindControl("txtImageCount") as LinkButton).Enabled == true)
            ////////////{

            ////////////    string imglist = (gvRow.FindControl("lblImagesName") as Label).Text;
            ////////////    Session["ImgList"] = imglist;

            ////////////    foreach (var item in imglist.Split(new char[] { '\n' }))
            ////////////    {
            ////////////        if (item != null && item != "")
            ////////////        {



            ////////////            String NameImage = System.Configuration.ConfigurationManager.AppSettings["PhysicalPath"].ToString() + "\\" + item.ToString();

            ////////////            ///Show Image Popup

            ////////////            //<input type='image' src='../Themes/Images/close.jpg'  align='right' width='48px' height='48px' onclick='demoDisplay()' style='background-color: #FF0000' alt='Close' fontsize='30'>
            ////////////            //for (int i = 0; i < 4; i++)
            ////////////            //{
            ////////////            //    string path = "sample.jpg";
            ////////////            //    this.Controls.Add(new LiteralControl(" <img src='../../images/" + path + "' alt='Deeeepak' height='400' width='400'>"));
            ////////////            //}


            ////////////            //GridViewRow gvRow = (sender as LinkButton).NamingContainer as GridViewRow;

            ////////////            //string ReturndetailID = (gvRow.FindControl("lblguid") as Label).Text;



            ////////////            //for (int i = 0; i < gvReturnDetails.Rows.Count; i++)
            ////////////            //{
            ////////////            //    int flg = 1;

            ////////////            //    string ReturnROWID = Views.Global.ReteunGlobal.RGAROWID;

            ////////////            //    string GuidReturnDetail = (gvReturnDetails.Rows[i].FindControl("lblguid") as Label).Text;
            ////////////            ///////////   lblImagesFor.Text = "Sorry! Images for GRA Detail Number : " + ReturnROWID + " not found!";
            ////////////            // List<string> lsImages2 = Obj.Rcall.ReturnImagesByReturnDetailsID(Guid.Parse(ReturndetailID));

            ////////////            if (File.Exists(NameImage))
            ////////////            {

            ////////////                List<String> lsImages = new List<string>();
            ////////////                String ImgServerString = System.Configuration.ConfigurationManager.AppSettings["ImageServerPath"].ToString();
            ////////////                //foreach (var Imaitem in lsImages2)
            ////////////                //{
            ////////////                //lsImages.Add("~/images/"+Imaitem.Split(new char[] { '\\' }).Last().ToString());
            ////////////                lsImages.Add(ImgServerString.Replace("#{ImageName}#", NameImage.Split(new char[] { '\\' }).Last().ToString()));
            ////////////                //}
            ////////////                //foreach (var Imaitem in lsImages2)
            ////////////                //{
            ////////////                //    //lsImages.Add("~/images/"+Imaitem.Split(new char[] { '\\' }).Last().ToString());
            ////////////                //    lsImages.Add(ImgServerString.Replace("#{ImageName}#", Imaitem.Split(new char[] { '\\' }).Last().ToString()));
            ////////////                //}
            ////////////                /////192.168.1.172/Macintosh HD/ftp_share/RGAImages/
            ////////////                //if (lsImages2.Count > 0)
            ////////////                //{
            ////////////                ////////// lblImagesFor.Text = "Images for GRA Detail Number : " + ReturnROWID;
            ////////////                for (int j = 0; j < lsImages.Count; j++)
            ////////////                {
            ////////////                    // flg = 2;
            ////////////                    string path = lsImages[j].ToString();
            ////////////                    this.Controls.Add(new LiteralControl(" <img src='" + path + "' height='400' width='400'>"));
            ////////////                }
            ////////////                //}
            ////////////                //else
            ////////////                //{

            ////////////                //}

            ////////////            }

            ////////////            else
            ////////////            {
            ////////////                this.Controls.Add(new LiteralControl("<b>Image not found"));
            ////////////            }


            ////////////            //}
            ////////////        }
            ////////////    }
            ////////////    this.Controls.Add(new LiteralControl("</td></tr></table>"));
            ////////////    this.Controls.Add(new LiteralControl("</div>"));
            ////////////}
        }

        protected void btnConfirmBox_Click(object sender, EventArgs e)
        {
            mpePopupForConfirmBox.Show();
        }

        protected void btnConfirmNo_Click(object sender, EventArgs e)
        {
            mpePopupForConfirmBox.Hide(); ;
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {


            List<skuAndreturndetail> ls = new List<skuAndreturndetail>();
            //object of return.

            Guid returnid;
            int InProgress = 0;

            if (chkflag.Checked == true)
            {
                InProgress = 1;
            }


            //  Return ret = Obj.Rcall.ReturnByRGAROWID(rga)[0];

            DateTime ScannedDate = DateTime.UtcNow;
            DateTime ExpirationDate = DateTime.UtcNow.AddDays(60);

            #region ReturnDetail





            List<Return> _lsreturn = new List<Return>();
            Return ret = new Return();
            //Return ret = Obj.Rcall.ReturnByPONumber(Request.QueryString["RMAPO"].ToString())[0];
            //List<Return> ret = new List<Return>();
            List<ReturnDetail> lsretundetail = new List<ReturnDetail>();
            ret.RMANumber = txtRMAnumber.Text;
            ret.VendoeName = txtvendorName.Text;
            ret.VendorNumber = txtvendornumber.Text;
            ret.ScannedDate = DateTime.UtcNow;
            ret.ExpirationDate = DateTime.UtcNow.AddDays(60);
            eastern = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(Convert.ToDateTime(txtreturndate.Text), "Eastern Standard Time");
            //eastern = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(txtreturndate.SelectedDate.Value, "Eastern Standard Time");
            ret.ReturnDate = eastern;
            ret.PONumber = txtponumber.Text;
            ret.CustomerName1 = txtcustomerName.Text;
            //lsretundetail = txtAddress.Text;
            //ret.City = txtCustCity.Text;
            //ret.Country = txtCountry.Text;
            //ret.ZipCode = txtZipCode.Text;
            //ret.State = txtState.Text;
            ret.CallTag = TextBox1.Text;
            ret.RGAROWID = txtRMAnumber.Text;

            DateTime DeliveryDate = ((List<RMAInfo>)Session["lstrmainsert"])[0].DeliveryDate;
            DateTime CurrentDate = DateTime.UtcNow;
            TimeSpan Diff = CurrentDate.Subtract(DeliveryDate);
            int Days = Diff.Days;
            ViewState["Days"] = Days;



            string wrongRMA = "0";
            string Warranty = "1";

            _lsreturn.Add(ret);

            //Set the Return Information in Return Table.  Views.Global.ReteunGlobal
            //   Guid returnid = _Update.SetReturnTbl(ret, Convert.ToByte(ddlstatus.SelectedValue.ToString()), Convert.ToByte(ddldecision.SelectedValue.ToString()), Convert.ToDateTime(txtreturndate.Text), "");

            returnid = _Update.SetReturnByPonumberTblNew((List<RMAInfo>)Session["lstrmainsert"], Convert.ToByte(ddlstatus.SelectedValue.ToString()), Convert.ToByte(ddldecision.SelectedValue.ToString()), (Guid)Session["UserID"], ScannedDate, ExpirationDate, InProgress, TextBox1.Text, wrongRMA, Warranty, 60, (int)ViewState["Days"]);

            Session["ReturnFromID"] = returnid;


            //set Gridview information in ReturnDetail Table.
            for (int i = 0; i < gvReturnDetails.Rows.Count; i++)
            {
                int flag = 0;

                //  Guid ReturnDetailsID = Views.Global.lsReturnDetail[i].ReturnDetailID;

                //string Dquantity = (gvReturnDetails.Rows[i].FindControl("txtdeliveredquantity") as TextBox).Text;

                string Rquantity = (gvReturnDetails.Rows[i].FindControl("txtSKU_Qty_Seq") as TextBox).Text;

                if (Rquantity == "---")
                {
                    Rquantity = "0";
                }

                String SKUNumber = (gvReturnDetails.Rows[i].FindControl("txtSKU") as TextBox).Text;

                string ProductID = "";

                string SKUSequence = (gvReturnDetails.Rows[i].FindControl("txtSKU_Sequence") as TextBox).Text;

                string SalesPrice = "0";// (gvReturnDetails.Rows[i].FindControl("txtSalesPrice") as TextBox).Text;

                string Linetype = (gvReturnDetails.Rows[i].FindControl("txtLineType") as TextBox).Text;

                string ShipmentLine = (gvReturnDetails.Rows[i].FindControl("txtShipmentLines") as TextBox).Text;

                string ReturnLine = (gvReturnDetails.Rows[i].FindControl("txtReturnLines") as TextBox).Text;

                // string GuidReturnDetail = (gvReturnDetails.Rows[i].FindControl("lblguid") as Label).Text;

                string imglist = ((Label)gvReturnDetails.Rows[i].FindControl("lblImagesName")).Text;

                string TrackingNumber = (gvReturnDetails.Rows[i].FindControl("txtTrackingNumber") as TextBox).Text;

                if (TrackingNumber == "---")
                {
                    TrackingNumber = "";
                }

                string SKUNewName = "";
                Boolean checkflag = false;

                List<StatusAndPoints> statusAndPoint = new List<StatusAndPoints>();
                statusAndPoint = (List<StatusAndPoints>)Session["listofstatusAndPoint"];


                if (statusAndPoint.Count > 0)
                {
                    for (int j = statusAndPoint.Count - 1; j >= 0; j--)
                    {
                        if (statusAndPoint[j].SKUName == SKUNumber && statusAndPoint[j].NewItemQuantity == Convert.ToInt32(SKUSequence))
                        {
                            SKUNewName = SKUNumber;
                            ViewState["SKU_Staus"] = statusAndPoint[j].Status;
                            ViewState["TotalPoints"] = statusAndPoint[j].Points;
                            ViewState["IsScanned"] = statusAndPoint[j].IsScanned;
                            ViewState["IsManually"] = statusAndPoint[j].IsMannually;
                            ViewState["NewItemQty"] = statusAndPoint[j].NewItemQuantity;
                            ViewState["_SKU_Qty_Seq"] = statusAndPoint[j].skusequence;

                            statusAndPoint.RemoveAt(j);
                            checkflag = true;

                            break;
                        }
                    }
                    if (!checkflag)
                    {
                        ViewState["SKU_Staus"] = "";
                        ViewState["TotalPoints"] = 0;
                        ViewState["IsScanned"] = 1;//listofstatus[i].IsScanned;
                        ViewState["IsManually"] = 1;//listofstatus[i].IsMannually;
                        ViewState["NewItemQty"] = 1;
                        ViewState["_SKU_Qty_Seq"] = 0;
                    }
                }
                else
                {
                    SKUNewName = SKUNumber;
                    ViewState["SKU_Staus"] = "";
                    ViewState["TotalPoints"] = 0;
                    ViewState["IsScanned"] = 1;
                    ViewState["IsManually"] = 1;
                    ViewState["NewItemQty"] = 1;
                    ViewState["_SKU_Qty_Seq"] = 0;

                }
                Session["listofstatusAndPoint"] = statusAndPoint;

                //for (int j = 0; j < Views.Global.lsReturnDetail.Count; j++)
                //{
                //    if (Views.Global.lsReturnDetail[j].SKUNumber == SKUNumber && Views.Global.lsReturnDetail[j].SKU_Sequence == Convert.ToInt16(SKUSequence))
                //    {
                //        flag = 1;
                //        break;
                //    }

                //}
                Guid ReturnDetailsID = Guid.NewGuid();

                skuAndreturndetail lsskuandreturn = new skuAndreturndetail();
                //if (GuidReturnDetail != "")
                //{
                //    ReturnDetailsID = _Update.SetReturnDetailTbl(Guid.Parse(GuidReturnDetail), returnid, SKUNumber, "", Convert.ToInt32(Rquantity), (Guid)Session["UserID"], Views.Global.SKU_Staus, Views.Global.TotalPoints, Views.Global.IsScanned, Views.Global.IsManually, Convert.ToInt16(SKUSequence), Views.Global._SKU_Qty_Seq, ProductID, Convert.ToDecimal(SalesPrice), Convert.ToInt16(Linetype), Convert.ToInt16(ShipmentLine), Convert.ToInt16(ReturnLine));

                //}
                //else
                //{
                ReturnDetailsID = _Update.SetReturnDetailNewInsertTbl(Guid.NewGuid(), returnid, SKUNumber, "", Convert.ToInt32(Rquantity), (Guid)Session["UserID"], (String)ViewState["SKU_Staus"], (int)ViewState["TotalPoints"], (int)ViewState["IsScanned"], (int)ViewState["IsManually"], Convert.ToInt32(SKUSequence), (int)ViewState["_SKU_Qty_Seq"], ProductID, Convert.ToDecimal(SalesPrice), Convert.ToInt32(Linetype), Convert.ToInt32(ShipmentLine), Convert.ToInt32(ReturnLine), TrackingNumber);
                //}
                lsskuandreturn.ReturnID = ReturnDetailsID;
                lsskuandreturn.skuname = SKUNumber;

                ls.Add(lsskuandreturn);
            #endregion



                #region SKUReasons Delete and Insert

                if (((List<SkuReasonIDSequence>)Session["_lsReasonSKU"]).Count > 0)
                {
                    for (int k = ((List<SkuReasonIDSequence>)Session["_lsReasonSKU"]).Count - 1; k >= 0; k--)
                    {
                        if (((List<SkuReasonIDSequence>)Session["_lsReasonSKU"])[k].SKUName == SKUNumber && ((List<SkuReasonIDSequence>)Session["_lsReasonSKU"])[k].SKU_sequence == Convert.ToInt32(SKUSequence))
                        {
                            Obj.Rcall.SetTransaction1(Guid.NewGuid(), ((List<SkuReasonIDSequence>)Session["_lsReasonSKU"])[k].ReasonID, ReturnDetailsID);
                            ((List<SkuReasonIDSequence>)Session["_lsReasonSKU"]).RemoveAt(k);
                        }
                    }
                }


                #endregion




                #region ReturnedQuantity

                if (((DataTable)Session["dt"]).Rows.Count > 0)
                {
                    for (int k = ((DataTable)Session["dt"]).Rows.Count - 1; k >= 0; k--)
                    {
                        DataRow d = ((DataTable)Session["dt"]).Rows[k];
                        if (d["SKU"].ToString() == SKUNumber && d["ItemQuantity"].ToString() == SKUSequence)
                        {
                            //string RetirID = d["ReturnDetailID"].ToString();

                            //if (Guid.Parse(d["ReturnDetailID"].ToString()) == ReturnDetailsID && d["ReturnedSKUID"].ToString() != null && d["ReturnedSKUID"].ToString() != "")
                            //{
                            //    // Guid skureturn = Guid.Parse(d["ReturnedSKUID"].ToString());

                            //    Guid ReturnedSKUPoints = _Update.SetReturnedSKUPoints(Guid.Parse(d["ReturnedSKUID"].ToString()), ReturnDetailsID, returnid, ((DataTable)Session["dt"]).Rows[k][0].ToString(), ((DataTable)Session["dt"]).Rows[k][1].ToString(), ((DataTable)Session["dt"]).Rows[k][2].ToString(), Convert.ToInt16(((DataTable)Session["dt"]).Rows[k][3].ToString()), Convert.ToInt16(((DataTable)Session["dt"]).Rows[k][4].ToString()));
                            //    d.Delete();
                            //}
                            //else
                            //{
                            _Update.SetReturnedSKUPoints(Guid.NewGuid(), ReturnDetailsID, returnid, ((DataTable)Session["dt"]).Rows[k][0].ToString(), ((DataTable)Session["dt"]).Rows[k][1].ToString(), ((DataTable)Session["dt"]).Rows[k][2].ToString(), Convert.ToInt32(((DataTable)Session["dt"]).Rows[k][3].ToString()), Convert.ToInt32(((DataTable)Session["dt"]).Rows[k][4].ToString()));
                            d.Delete();
                            //}

                        }
                    }
                }


                #endregion

                #region SaveComments

                // Session["rmacomment"]

                if (((List<RMAComment>)Session["rmacomment"]).Count > 0)
                {

                    foreach (var item in ((List<RMAComment>)Session["rmacomment"]))
                    {
                        RMAComment lscomments = new RMAComment();
                        lscomments.CommentDate = item.CommentDate;
                        lscomments.ReturnID = returnid;
                        lscomments.RMACommentID = item.RMACommentID;
                        lscomments.UserID = item.UserID;
                        lscomments.Comment = item.Comment;
                        Obj.Rcall.InsertRMACommnt(lscomments);
                    }
                    // Views.Global.rmaComment = null;
                }
                #endregion




                #region InsertImages

                foreach (var item in imglist.Split(new char[] { '\n' }))
                {
                    if (item != null && item != "")
                    {

                        String NameImage = System.Configuration.ConfigurationManager.AppSettings["PhysicalPath"].ToString() + "\\" + item.ToString();

                        Guid ImageID = _newRMA.SetReturnedImages(Guid.NewGuid(), ReturnDetailsID, NameImage, (Guid)Session["UserID"]);
                    }
                }

                #endregion



                #region Deepak Slip Barcode Print
                //foreach (var n in ((List<String>)Session["_lsSlipPrintSKUNumber"]))
                //{
                //    if (n == SKUNumber)
                //    {

                //        Guid userId = (Guid)Session["UserID"];
                //        string nm = Obj.Rcall.GetUserInfobyUserID(userId).UserName;
                //        //_retn.GetReturnTblByReturnID(returnid)
                //        var rr = _retn.GetReturnTblByReturnID(returnid).RGAROWID;
                //        string nrr = rr.ToString();
                //        Session["lsSlipInfo"] = _Update.GetSlipInfo(_lsreturn, SKUNumber, Obj.Rcall.EncodeCode(n), "", nrr, ddlstatus.SelectedIndex.ToString(), "Refund", nm);
                //        //  Views.Global.lsSlipInfo = _Update.GetSlipInfo(_lsreturn, Global.arr[i], Obj.Rcall.EncodeCode(Global.arr[i]), "", nrr, ddlstatus.SelectedIndex.ToString(), "Refund", nm);

                //        Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('frmSlipPrint.aspx','_newtab');", true);






                //        // literal.Text += "a ID='linkcontact' runat='server' href='" + "www.website./pagename.aspx?ID=" + id + "'>contact</a>";
                //    }
                //}
                #endregion





                // _Update.SetReturnDetailTbl(lsretundetail[i], Convert.ToInt16(Dquantity), Convert.ToInt16(Rquantity), SKUNumber,ProductName);

            }
            Session["_lsSlipPrintSKUNumber2"] = ls;
            List<cSlipInfo> lspr = new List<cSlipInfo>();
            foreach (var n in ((List<skuAndreturndetail>)Session["_lsSlipPrintSKUNumber2"]))
            {
                string encd = Obj.Rcall.EncodeCode(n.skuname);
                Guid userId = (Guid)Session["UserID"];
                string nm = Obj.Rcall.GetUserInfobyUserID(userId).UserName;
                //_retn.GetReturnTblByReturnID(returnid)
                var rr = ((List<RMAInfo>)Session["lstrmainsert"])[0].PONumber;

                string nrr = rr.ToString();

                Guid rt = new Guid();
                string po = txtponumber.Text;
                lspr.Add(_Update.GetSlipInfo(n.skuname, encd, "", nrr, ddlstatus.SelectedIndex.ToString(), "Refund", nm, po, n.ReturnID));

                //Session["lsSlipInfo"] //= _Update.GetSlipInfo(n, encd, "", nrr, ddlstatus.SelectedIndex.ToString(), "Refund", nm);

                //Session["lsSlipInfo"] = _Update.GetSlipInfo(SKUNumber, encd, "", nrr, ddlstatus.SelectedIndex.ToString(), "Refund", nm);
                //  Views.Global.lsSlipInfo = _Update.GetSlipInfo(_lsreturn, Global.arr[i], Obj.Rcall.EncodeCode(Global.arr[i]), "", nrr, ddlstatus.SelectedIndex.ToString(), "Refund", nm);

                //  string script = "window.open('http://192.168.1.16:12/Forms/Web%20Forms/frmRMAFormPrint2.aspx', 'myNewWindow')";
                // literal.Text += "a ID='linkcontact' runat='server' href='" + "www.website./pagename.aspx?ID=" + id + "'>contact</a>";

            }
             Session["lsSlipInfo"] = lspr;
             Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('frmSlipPrint.aspx','_newtab');", true);


            //Clear the Reasons list from Global Object.
            Obj._ReasonList = new List<Views.ReasonList>();

            //Response.Redirect("~/Forms/Web Forms/frmRetunDetail.aspx");
            //  Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('frmSlipPrint.aspx','_newtab');", true);

            lblMassege.Text = "Success";
          //  mpePopupForSaveYes.Show();
             ModalPopupExtender1.Show();

            lblUser.Text = "Information Saved Succesfully";
           // Response.Redirect("~/Forms/Web Forms/DemoGrid.aspx");
            // ModalPopupExtender1.Show();



        }
      

        //protected void BtnAddCheckGrid_Click(object sender, EventArgs e)
        //{
        //    List<ReturnDetail> _lsReturnDetails = new List<ReturnDetail>();

        //    dt2.Columns.Add("SKUNumber");
        //    dt2.Columns.Add("SKU_Qty_Seq");
        //    dt2.Columns.Add("SKU_Sequence");
        //    dt2.Columns.Add("ProductID");
        //    dt2.Columns.Add("LineType");
        //    dt2.Columns.Add("ShipmentLines");
        //    dt2.Columns.Add("ReturnLines");
        //    dt2.Columns.Add("ImageName");
        //    dt2.Columns.Add("DeliveredQty");

        //    for (int j = 0; j < gvReturnDetails.Rows.Count; j++)
        //    {
        //        CheckBox cb = (gvReturnDetails.Rows[j].FindControl("CheckBox1")) as CheckBox;
        //        if (Convert.ToInt32(gvReturnDetails.Rows[j].Cells[4].Text.ToString()) == 7 || Convert.ToInt32(gvReturnDetails.Rows[j].Cells[4].Text.ToString()) == 1)
        //        {
        //            if (cb.Checked == true)
        //            {
        //                DataRow dr2 = dt.NewRow();


        //                CheckBox SKUNumber = (CheckBox)gvReturnDetails.Rows[j].FindControl("SKUNumber");
        //                CheckBox SKU_Qty_Seq = (CheckBox)gvReturnDetails.Rows[j].FindControl("SKU_Qty_Seq");
        //                CheckBox SKU_Sequence = (CheckBox)gvReturnDetails.Rows[j].FindControl("SKU_Sequence");
        //                CheckBox ProductID = (CheckBox)gvReturnDetails.Rows[j].FindControl("ProductID");
        //                CheckBox LineType = (CheckBox)gvReturnDetails.Rows[j].FindControl("LineType");
        //                CheckBox ShipmentLines = (CheckBox)gvReturnDetails.Rows[j].FindControl("ShipmentLines");
        //                CheckBox ReturnLines = (CheckBox)gvReturnDetails.Rows[j].FindControl("ReturnLines");
        //                CheckBox DeliveredQty = (CheckBox)gvReturnDetails.Rows[j].FindControl("DeliveredQty");


        //                dr2[0] = SKUNumber.Checked;
        //                dr2[1] = SKU_Qty_Seq.Checked;
        //                dr2[2] = SKU_Sequence.Checked;
        //                dr2[3] = ProductID.Checked;
        //                dr2[4] = LineType.Checked;
        //                dr2[5] = ShipmentLines.Checked;
        //                dr2[6] = ReturnLines.Checked;
        //                dr2[7] = DeliveredQty.Checked;

        //                dt2.Rows.Add(dr2);


        //            }

        //        }

        //    }
        //}


        //protected void btnAddGrid(object sender, EventArgs e)
        //{
        //    List<ReturnDetail> _lsReturnDetails = new List<ReturnDetail>();
        //    for (int j = 0; j < gvReturnDetails2.Rows.Count; j++)
        //    {
        //        CheckBox cb = (gvReturnDetails2.Rows[j].FindControl("CheckBox1")) as CheckBox;
        //        try
        //        {
        //            if (cb.Checked == true)
        //            {
        //                ReturnDetail rd = new ReturnDetail();
        //                rd.SKUNumber = gvReturnDetails2.Rows[j].Cells[0].Text.ToString();
        //                rd.SKU_Qty_Seq = Convert.ToInt16(gvReturnDetails2.Rows[j].Cells[1].Text.ToString());
        //                rd.SKU_Sequence = Convert.ToInt32(gvReturnDetails2.Rows[j].Cells[2].Text.ToString());
        //                rd.ProductID = gvReturnDetails2.Rows[j].Cells[3].Text.ToString();
        //                rd.LineType = Convert.ToInt32(gvReturnDetails2.Rows[j].Cells[4].Text.ToString());
        //                rd.ShipmentLines = Convert.ToInt32(gvReturnDetails2.Rows[j].Cells[5].Text.ToString());
        //                rd.ReturnLines = Convert.ToInt32(gvReturnDetails2.Rows[j].Cells[6].Text.ToString());
        //                rd.DeliveredQty = Convert.ToInt32(gvReturnDetails2.Rows[j].Cells[7].Text.ToString());
        //                _lsReturnDetails.Add(rd);
        //            }
        //        }
        //        catch (Exception essss)
        //        {
        //        }
        //    }

        //    List<string> _lsSkuNumber = new List<string>();
        //    DataTable dt3 = new DataTable();
        //    dt3.Columns.Add("SKUNumber");
        //    dt3.Columns.Add("SKU_Qty_Seq");
        //    dt3.Columns.Add("ProductID");
        //    dt3.Columns.Add("SKU_Sequence");
        //    dt3.Columns.Add("LineType");
        //    dt3.Columns.Add("ShipmentLines");
        //    dt3.Columns.Add("ReturnLines");
        //    dt3.Columns.Add("ImageName");
        //    dt3.Columns.Add("NoofImages");

        //    #region GridData
        //    for (int i = 0; i < gvReturnDetails.Rows.Count; i++)
        //    {
        //        try
        //        {
        //            DataRow dr1 = dt3.NewRow();
        //            TextBox SKUNumber = (TextBox)gvReturnDetails.Rows[i].FindControl("txtsku");
        //            TextBox SKU_Qty_Seq = (TextBox)gvReturnDetails.Rows[i].FindControl("txtSKU_Qty_Seq");
        //            TextBox ProductID = (TextBox)gvReturnDetails.Rows[i].FindControl("txtProductID");
        //            TextBox SKU_Sequence = (TextBox)gvReturnDetails.Rows[i].FindControl("txtSKU_Sequence");
        //            TextBox LineType = (TextBox)gvReturnDetails.Rows[i].FindControl("txtLineType");
        //            TextBox ShipmentLines = (TextBox)gvReturnDetails.Rows[i].FindControl("txtShipmentLines");
        //            TextBox ReturnLines = (TextBox)gvReturnDetails.Rows[i].FindControl("txtReturnLines");
        //            Label lblimages = (Label)gvReturnDetails.Rows[i].FindControl("lblImagesName");
        //            LinkButton NoOfImages = (LinkButton)gvReturnDetails.Rows[i].FindControl("txtImageCount");

        //            dr1[0] = SKUNumber.Text;
        //            dr1[1] = SKU_Qty_Seq.Text;
        //            dr1[2] = ProductID.Text;
        //            dr1[3] = SKU_Sequence.Text;
        //            dr1[4] = LineType.Text;
        //            dr1[5] = ShipmentLines.Text;
        //            dr1[6] = ReturnLines.Text;
        //            dr1[7] = lblimages.Text;
        //            dr1[8] = NoOfImages.Text;
        //            dt3.Rows.Add(dr1);
        //            //_lsSkuNumber.Add(SKUNumber.Text.Trim());
        //            //_lsSkuNumber.Add(SKU_Sequence.Text.Trim());
        //            //_lsSkuNumber.Add(ShipmentLines.Text.Trim());
        //            //_lsSkuNumber.Add(ReturnLines.Text);

        //        }
        //        catch (Exception ex)
        //        {
        //        }
        //    }


        //    #endregion
        //        #region ModalPopUp
        //        //List<ReturnDetail> _lsReturnDetails = new List<ReturnDetail>();
        //        //for (int j = 0; j < gvReturnDetails2.Rows.Count; j++)
        //        //{
        //        //    CheckBox cb = (gvReturnDetails2.Rows[j].FindControl("CheckBox1")) as CheckBox;
        //        //    try
        //        //    {
        //        //        if (cb.Checked == true)
        //        //        {
        //        //            ReturnDetail rd = new ReturnDetail();
        //        //            rd.SKUNumber = gvReturnDetails2.Rows[j].Cells[0].Text.ToString();
        //        //            rd.SKU_Qty_Seq = Convert.ToInt16(gvReturnDetails2.Rows[j].Cells[1].Text.ToString());                       
        //        //            rd.SKU_Sequence = Convert.ToInt32(gvReturnDetails2.Rows[j].Cells[2].Text.ToString());
        //        //            rd.ProductID = gvReturnDetails2.Rows[j].Cells[3].Text.ToString();                      
        //        //            rd.LineType = Convert.ToInt32(gvReturnDetails2.Rows[j].Cells[4].Text.ToString());
        //        //            rd.ShipmentLines = Convert.ToInt32(gvReturnDetails2.Rows[j].Cells[5].Text.ToString());
        //        //            rd.ReturnLines = Convert.ToInt32(gvReturnDetails2.Rows[j].Cells[6].Text.ToString());
        //        //            rd.DeliveredQty = Convert.ToInt32(gvReturnDetails2.Rows[j].Cells[7].Text.ToString());
        //        //            _lsReturnDetails.Add(rd);
        //        //        }
        //        //    }
        //        //    catch (Exception essss)
        //        //    {
        //        //    }
        //        //}
        //        #endregion


        //        (Session["_lsReturnDetails"]) = new List<ReturnDetail>();
        //        Session["_lsReturnDetails"] = _lsReturnDetails;

        //        #region Matched SKU
        //        // List<ReturnDetail> _MatchedSKU = new List<ReturnDetail>();
        //        for (int i = 0; i < gvReturnDetails.Rows.Count; i++)
        //          {
                       
        //            TextBox SKUNumber = (TextBox)gvReturnDetails.Rows[i].FindControl("txtsku");
        //            TextBox SKU_Qty_Seq = (TextBox)gvReturnDetails.Rows[i].FindControl("txtSKU_Qty_Seq");
        //            TextBox ProductID = (TextBox)gvReturnDetails.Rows[i].FindControl("txtProductID");
        //            TextBox SKU_Sequence = (TextBox)gvReturnDetails.Rows[i].FindControl("txtSKU_Sequence");
        //            TextBox LineType = (TextBox)gvReturnDetails.Rows[i].FindControl("txtLineType");
        //            TextBox ShipmentLines = (TextBox)gvReturnDetails.Rows[i].FindControl("txtShipmentLines");
        //            TextBox ReturnLines = (TextBox)gvReturnDetails.Rows[i].FindControl("txtReturnLines");
             
        //            for (int l = 0; l < ((List<ReturnDetail>)Session["_lsReturnDetails"]).Count; l++)
        //            {
        //                if (SKUNumber.Text == ((List<ReturnDetail>)Session["_lsReturnDetails"])[l].SKUNumber.ToString())
        //                {
        //                    if (max < Convert.ToInt16(SKU_Sequence.Text))
        //                    {
        //                        max = Convert.ToInt16(SKU_Sequence.Text);
        //                    }
        //                    if (shipmax < Convert.ToInt16(ShipmentLines.Text))
        //                    {
        //                        shipmax = Convert.ToInt16(ShipmentLines.Text);
        //                    }
        //                    if (returnmax < Convert.ToInt16(ReturnLines.Text))
        //                    {
        //                        returnmax = Convert.ToInt16(ReturnLines.Text);
        //                    }
        //                }
        //                else
        //                    NonPo = false;
        //            }
                    
                





        //        //        ReturnDetail _lsforMatchedSKU = new ReturnDetail();
        //        //        _lsforMatchedSKU.SKUNumber = ((List<ReturnDetail>)Session["_lsReturnDetails"])[l].SKUNumber.ToString();
        //        //        _lsforMatchedSKU.SKU_Qty_Seq = ((List<ReturnDetail>)Session["_lsReturnDetails"])[l].SKU_Qty_Seq;
        //        //        _lsforMatchedSKU.SKU_Sequence = ((List<ReturnDetail>)Session["_lsReturnDetails"])[l].SKU_Sequence;
        //        //        _lsforMatchedSKU.ProductID = ((List<ReturnDetail>)Session["_lsReturnDetails"])[l].ProductID.ToString();
        //        //        _lsforMatchedSKU.LineType = ((List<ReturnDetail>)Session["_lsReturnDetails"])[l].LineType;
        //        //        _lsforMatchedSKU.ShipmentLines = ((List<ReturnDetail>)Session["_lsReturnDetails"])[l].ShipmentLines;
        //        //        _lsforMatchedSKU.ReturnLines = ((List<ReturnDetail>)Session["_lsReturnDetails"])[l].ReturnLines;
        //        //        _lsforMatchedSKU.DeliveredQty = ((List<ReturnDetail>)Session["_lsReturnDetails"])[l].DeliveredQty;

        //        //        _MatchedSKU.Add(_lsforMatchedSKU);
        //        //        ((List<ReturnDetail>)Session["_lsReturnDetails"]).RemoveAt(l);
        //        //        break;

        //        //    }
        //        //}








        //        // List<ReturnDetail> _MatchedSKU = new List<ReturnDetail>();
        //        //foreach (var rm in _lsReturnDetails)
        //        //{
        //        //    for (int m = 0; m < _lsSkuNumber.Count; m++)
        //        //    {
        //        //        if (_lsSkuNumber[m].ToString() == rm.SKUNumber)
        //        //        {
        //        //            _MatchedSKU.Add(rm);                        
        //        //        }
        //        //    }
        //        //}
        //        #endregion

        //        //#region UnMatched SKU
        //        //List<ReturnDetail> _UnMatchedSKU = new List<ReturnDetail>();
        //        //foreach (var rm in _lsReturnDetails)
        //        //{
        //        //    for (int m = 0; m < _lsSkuNumber.Count; m++)
        //        //    {
        //        //        if (_lsSkuNumber[m].ToString() != rm.SKUNumber)
        //        //        {
        //        //            foreach(var rd in _MatchedSKU)
        //        //            {
        //        //                 if(rd.SKUNumber==rm.SKUNumber)
        //        //                 {

        //        //                 }
        //        //                 else
        //        //                 {
        //        //                     _UnMatchedSKU.Add(rm);
        //        //                 }
        //        //            }


        //        //        }
        //        //    }
        //        //}
        //        //#endregion

                

        //        #region DataBindingForGridView of Matched SKU's


        //        DataRow dr5 = dt3.NewRow();
              
        //            dr5[0] = SKUNumber;
        //            dr5[1] = SKU_Qty_Seq;
        //            dr5[2] = ProductID;
        //            dr5[3] = max + 1000;
        //            dr5[4] = LineType;
        //            dr5[5] = shipmax + 1000;
        //            dr5[6] = returnmax + 1000;
        //            dr5[7] = "";
        //            dr5[8] = "0 Image(s)";
        //            Session["drr"] = dr5;
        //            dt3.Rows.Add(dr5);
                
        //    }
    









        //        #endregion

        //    #region DataBindingForGridView of UnMatched SKU's
        //    //for (int r = 0; r < ((List<ReturnDetail>)Session["_lsReturnDetails"]).Count; r++)
        //    //{
        //    //    DataRow dr5 = dt3.NewRow();

        //    //    dr5[0] = ((List<ReturnDetail>)Session["_lsReturnDetails"])[r].SKUNumber.ToString();
        //    //    dr5[1] = ((List<ReturnDetail>)Session["_lsReturnDetails"])[r].SKU_Qty_Seq;
        //    //    dr5[2] = ((List<ReturnDetail>)Session["_lsReturnDetails"])[r].SKU_Sequence;
        //    //    dr5[3] = ((List<ReturnDetail>)Session["_lsReturnDetails"])[r].ProductID.ToString();
        //    //    dr5[4] = ((List<ReturnDetail>)Session["_lsReturnDetails"])[r].LineType;
        //    //    dr5[5] = ((List<ReturnDetail>)Session["_lsReturnDetails"])[r].ShipmentLines;
        //    //    dr5[6] = ((List<ReturnDetail>)Session["_lsReturnDetails"])[r].ReturnLines;
        //    //    dr5[7] = "";
        //    //    dr5[8] = "0 Image(s)";

        //    //    dt3.Rows.Add(dr5);
        //    //}

        //    //foreach (DataRow row in dt3.Rows)
        //    //{

        //    //}
        //    //foreach (var rm in _UnMatchedSKU)
        //    //{
        //    //    DataRow dr5 = dt3.NewRow();

        //    //    dr5[0] = rm.SKUNumber;
        //    //    dr5[1] = rm.SKU_Qty_Seq;
        //    //    dr5[2] = rm.ProductID;
        //    //    dr5[3] = rm.SKU_Sequence;
        //    //    dr5[4] = rm.LineType;
        //    //    dr5[5] = rm.ShipmentLines;
        //    //    dr5[6] = rm.ReturnLines;
        //    //    dr5[7] = "";
        //    //    dr5[8] = "0 Image(s)";

        //    //    dt3.Rows.Add(dr5);
        //    //}
        //    #endregion

        //    max = 0;
        //    returnmax = 0;
        //    shipmax = 0;
        //    txtNewItem.Text = "";
        //    gvReturnDetails.DataSource = dt3;
        //    gvReturnDetails.DataBind();
        //    dt3.Clear();
        //}
        //int max, shipmax, returnmax;
        protected void btnAddGrid2(object sender, EventArgs e)
        {

            List<ReturnDetail> _lsReturnDetailsForgvReturnDetailsFirst = new List<ReturnDetail>();
            Session["A"] = _lsReturnDetailsForgvReturnDetailsFirst;
            Session["B"] = _lsReturnDetailsForgvReturnDetailsFirst;

            //  int maxSKU_Sequence = 0, maxShipmentLines = 0, maxReturnLines = 0;
            #region Taking values from PopUp
            List<ReturnDetail> _lsReturnDetailsForgvReturnDetails = new List<ReturnDetail>();
            List<ReturnDetail> _lsReturnDetailsForgvReturnDetailss = new List<ReturnDetail>();
            List<ReturnDetail> _lsReturnDetailsForgvReturnDetails1 = new List<ReturnDetail>();
            List<ReturnDetail> _lsReturnDetails = new List<ReturnDetail>();
            for (int j = 0; j < gvReturnDetails2.Rows.Count; j++)
            {
                CheckBox cb = (gvReturnDetails2.Rows[j].FindControl("CheckBox1")) as CheckBox;
                try
                {
                    if (cb.Checked == true)
                    {
                        ReturnDetail rd = new ReturnDetail();
                        rd.SKUNumber = gvReturnDetails2.Rows[j].Cells[0].Text.ToString();
                        rd.SKU_Qty_Seq = Convert.ToInt32(gvReturnDetails2.Rows[j].Cells[1].Text.ToString());
                        rd.SKU_Sequence = Convert.ToInt32(gvReturnDetails2.Rows[j].Cells[2].Text.ToString());
                        rd.ProductID = gvReturnDetails2.Rows[j].Cells[3].Text.ToString();
                        rd.LineType = Convert.ToInt32(gvReturnDetails2.Rows[j].Cells[4].Text.ToString());
                        rd.ShipmentLines = Convert.ToInt32(gvReturnDetails2.Rows[j].Cells[5].Text.ToString());
                        rd.ReturnLines = Convert.ToInt32(gvReturnDetails2.Rows[j].Cells[6].Text.ToString());
                        rd.DeliveredQty = Convert.ToInt32(gvReturnDetails2.Rows[j].Cells[7].Text.ToString());
                        _lsReturnDetails.Add(rd);
                        Session["C"] = _lsReturnDetails;
                    }
                }
                catch (Exception essss)
                {
                }
            }

            #endregion




            List<string> _lsSkuNumber = new List<string>();
            DataTable dt3 = new DataTable();
            dt3.Columns.Add("SKUNumber");
            dt3.Columns.Add("SKU_Qty_Seq");
            dt3.Columns.Add("ProductID");
            dt3.Columns.Add("SKU_Sequence");
            dt3.Columns.Add("LineType");
            dt3.Columns.Add("ShipmentLines");
            dt3.Columns.Add("ReturnLines");
            dt3.Columns.Add("ImageName");
            dt3.Columns.Add("NoofImages");
            dt3.Columns.Add("TrackingNumber");
            dt3.Columns.Add("ReceivedDate");

            #region GridData
            for (int i = 0; i < gvReturnDetails.Rows.Count; i++)
            {
                try
                {
                    DataRow dr1 = dt3.NewRow();
                    TextBox SKUNumber = (TextBox)gvReturnDetails.Rows[i].FindControl("txtsku");
                    TextBox SKU_Qty_Seq = (TextBox)gvReturnDetails.Rows[i].FindControl("txtSKU_Qty_Seq");
                    TextBox ProductID = (TextBox)gvReturnDetails.Rows[i].FindControl("txtProductID");
                    TextBox SKU_Sequence = (TextBox)gvReturnDetails.Rows[i].FindControl("txtSKU_Sequence");
                    TextBox LineType = (TextBox)gvReturnDetails.Rows[i].FindControl("txtLineType");
                    TextBox ShipmentLines = (TextBox)gvReturnDetails.Rows[i].FindControl("txtShipmentLines");
                    TextBox ReturnLines = (TextBox)gvReturnDetails.Rows[i].FindControl("txtReturnLines");
                    Label lblimages = (Label)gvReturnDetails.Rows[i].FindControl("lblImagesName");
                    LinkButton NoOfImages = (LinkButton)gvReturnDetails.Rows[i].FindControl("txtImageCount");
                    TextBox TrackingNumber = (TextBox)gvReturnDetails.Rows[i].FindControl("txtTrackingNumber");
                    TextBox ReceivedDate = (TextBox)gvReturnDetails.Rows[i].FindControl("txtReceivedDate");

                    _lsSkuNumber.Add(SKUNumber.Text.Trim());
                    dr1[0] = SKUNumber.Text;
                    dr1[1] = SKU_Qty_Seq.Text;
                    dr1[2] = ProductID.Text;
                    dr1[3] = SKU_Sequence.Text;
                    dr1[4] = LineType.Text;
                    dr1[5] = ShipmentLines.Text;
                    dr1[6] = ReturnLines.Text;
                    dr1[7] = lblimages.Text;
                    dr1[8] = NoOfImages.Text;
                    dr1[9] = TrackingNumber.Text;
                    dr1[10] = ReceivedDate.Text;
                    dt3.Rows.Add(dr1);


                    ReturnDetail rd = new ReturnDetail();
                    rd.SKUNumber = SKUNumber.Text;
                    rd.SKU_Sequence = Convert.ToInt32(SKU_Sequence.Text);
                    _lsReturnDetailsForgvReturnDetails.Add(rd);
                    _lsReturnDetailsForgvReturnDetailss.Add(rd);
                    Session["A"] = _lsReturnDetailsForgvReturnDetails;
                    Session["B"] = _lsReturnDetailsForgvReturnDetailss;
                }
                catch (Exception ex)
                {
                }
            }

            #endregion


            #region Taking Maximum
            int maxSKUSequence = 0;
            string Sku = "";

            if (((List<ReturnDetail>)Session["B"]).Count > 0)
            {
                foreach (var item in (List<ReturnDetail>)Session["A"])
                {
                    if (((List<ReturnDetail>)Session["B"]).Count > 0)
                    {
                        Boolean statusForFirst = true;
                        int MAX = 0;
                        int COUNT = 0;
                        string Skuuu1 = "";
                        //foreach (var item1 in (List<ReturnDetail>)Session["B"])
                        //for (int k = ((List<ReturnDetail>)Session["B"]).Count - 1; k >= 0; k--)
                        for (int k = 0; k < ((List<ReturnDetail>)Session["B"]).Count; k++)
                        {

                            COUNT = ((List<ReturnDetail>)Session["B"]).Count;

                            if (item.SKUNumber == ((List<ReturnDetail>)Session["B"])[k].SKUNumber)
                            {
                                maxSKUSequence = ((List<ReturnDetail>)Session["B"])[k].SKU_Sequence;
                                Sku = ((List<ReturnDetail>)Session["B"])[k].SKUNumber;
                                Skuuu1 = Sku;
                                //First entry in MAX
                                if (statusForFirst == true)
                                {
                                    statusForFirst = false;
                                    MAX = maxSKUSequence;
                                }
                                //Second onwords entries in MAX
                                if (statusForFirst == false && MAX < maxSKUSequence)
                                {
                                    MAX = maxSKUSequence;
                                }

                            }
                        }

                        //Removing Same Items
                        //for (int i = 0; i < COUNT; i++)
                        for (int i = ((List<ReturnDetail>)Session["B"]).Count; i > 0; i--)
                        {
                            if (((List<ReturnDetail>)Session["B"])[i - 1].SKUNumber == Skuuu1)
                            {
                                ((List<ReturnDetail>)Session["B"]).RemoveAt(i - 1);
                            }
                        }



                        ReturnDetail rd1 = new ReturnDetail();
                        rd1.SKUNumber = Sku;
                        rd1.SKU_Sequence = MAX;
                        //rd1.LineType = linetype;
                        //rd1.ProductID = productid;
                        //rd1.SKU_Qty_Seq = skuqty;
                        _lsReturnDetailsForgvReturnDetails1.Add(rd1);
                    }
                }
            }

            #endregion
            //List<ReturnDetail> ls = new List<ReturnDetail>();

            //ls = _lsReturnDetailsForgvReturnDetails1;

            //List<String> lsString = new List<String>();
            #region Adding Proper Records
            if (_lsReturnDetailsForgvReturnDetails1.Count > 0)
            {
                foreach (var item in _lsReturnDetailsForgvReturnDetails1)
                {
                    int max1 = item.SKU_Sequence;
                    int COUnt = 0;
                    string Skuuu = "";
                    for (int i = 0; i < ((List<ReturnDetail>)Session["C"]).Count; i++)
                    {
                        COUnt = ((List<ReturnDetail>)Session["C"]).Count;
                        if (item.SKUNumber == ((List<ReturnDetail>)Session["C"])[i].SKUNumber)
                        {

                            DataRow dr2 = dt3.NewRow();

                            dr2[0] = ((List<ReturnDetail>)Session["C"])[i].SKUNumber;
                            dr2[1] = ((List<ReturnDetail>)Session["C"])[i].SKU_Qty_Seq;
                            dr2[2] = ((List<ReturnDetail>)Session["C"])[i].ProductID;
                            dr2[3] = max1 + 1000;
                            dr2[4] = ((List<ReturnDetail>)Session["C"])[i].LineType;
                            dr2[5] = max1 + 1000;
                            dr2[6] = max1 + 1000;
                            dr2[7] = "";
                            dr2[8] = "0 image(s)";
                            dr2[9] = "---";
                            dr2[10] = DateTime.Now.ToShortDateString();
                            max1 = max1 + 1000;


                            dt3.Rows.Add(dr2);

                            Skuuu = item.SKUNumber;
                        }
                    }
                    for (int i = ((List<ReturnDetail>)Session["C"]).Count; i > 0; i--)
                    {

                        if (((List<ReturnDetail>)Session["C"])[i - 1].SKUNumber == Skuuu)
                        {
                            ((List<ReturnDetail>)Session["C"]).RemoveAt(i - 1);
                        }

                    }
                }
            }

            #endregion

            #region Add Remaining SKU's
            //Adding Remaining SKU's that are not same

            for (int i = 0; i < ((List<ReturnDetail>)Session["C"]).Count; i++)
            {
                DataRow dr2 = dt3.NewRow();

                dr2[0] = ((List<ReturnDetail>)Session["C"])[i].SKUNumber;
                dr2[1] = ((List<ReturnDetail>)Session["C"])[i].SKU_Qty_Seq;
                dr2[2] = ((List<ReturnDetail>)Session["C"])[i].ProductID;
                dr2[3] = ((List<ReturnDetail>)Session["C"])[i].SKU_Sequence;
                dr2[4] = ((List<ReturnDetail>)Session["C"])[i].LineType;
                dr2[5] = ((List<ReturnDetail>)Session["C"])[i].ShipmentLines;
                dr2[6] = ((List<ReturnDetail>)Session["C"])[i].ReturnLines;
                dr2[7] = "";
                dr2[8] = "0 image(s)";
                dr2[9] = "---";
                dr2[10] = DateTime.Now.ToShortDateString();
                dt3.Rows.Add(dr2);

                // ((List<ReturnDetail>)Session["C"]).RemoveAt(i);

            }
            #endregion
            ((List<ReturnDetail>)Session["C"]).Clear();

            gvReturnDetails.DataSource = dt3;
            gvReturnDetails.DataBind();

            dt3.Clear();









            //////  (Session["_lsReturnDetails"]) = new List<ReturnDetail>();
            //////  Session["_lsReturnDetails"] = _lsReturnDetails;
            //////  //for (int i = 0; i < gvReturnDetails.Rows.Count; i++)
            //////  //{
            //////  //    TextBox SKU_Sequence = (TextBox)gvReturnDetails.Rows[i].FindControl("txtSKU_Sequence");
            //////  //    if (max < Convert.ToInt16(SKU_Sequence.Text))
            //////  //    {
            //////  //        max = Convert.ToInt16(SKU_Sequence.Text);
            //////  //    }
            //////  //    else
            //////  //    {

            //////  //    }
            //////  //}
            //////foreach (var rm in _lsReturnDetails)
            //////  {
            //////      DataRow dr5 = dt3.NewRow();

            //////      dr5[0] = rm.SKUNumber;
            //////      dr5[1] = rm.SKU_Qty_Seq;
            //////      dr5[2] = rm.ProductID;
            //////      dr5[3] = max+1000;
            //////      dr5[4] = rm.LineType;
            //////      dr5[5] = max + 1000;
            //////      dr5[6] = max + 1000;
            //////      dr5[7] = "";
            //////      dr5[8] = "0 Image(s)";

            //////      dt3.Rows.Add(dr5);

            //////      max = max + 1000;
            //////  }


            //////  gvReturnDetails.DataSource = dt3;
            //////  gvReturnDetails.DataBind();
            //////  max = 0;
            //////  dt3.Clear();











        }




      


            //#region SKUNumber
            //foreach (var rm in _lsReturnDetails)
            //{
            //    for (int m = 0; m <_lsSkuNumber.Count; m++)
            //    {
            //        DataRow dr5 = dt3.NewRow();
            //        if (_lsSkuNumber[m].ToString() == rm.SKUNumber)
            //        {
            //            dr5[0] = rm.SKUNumber;
            //            dr5[1] = rm.SKU_Qty_Seq;
            //            dr5[2] = rm.ProductID;
            //            dr5[3] = rm.SKU_Sequence + 1000;
            //            dr5[4] = rm.LineType;
            //            dr5[5] = rm.ShipmentLines + 1000;
            //            dr5[6] = rm.ReturnLines + 1000;
            //            dr5[7] = "";
            //            dr5[8] = "0 Image(s)";
            //            dt3.Rows.Add(dr5);
            //        }
            //        else
            //        {
            //            dr5[0] = rm.SKUNumber;
            //            dr5[1] = rm.SKU_Qty_Seq;
            //            dr5[2] = rm.ProductID;
            //            dr5[3] = rm.SKU_Sequence;
            //            dr5[4] = rm.LineType;
            //            dr5[5] = rm.ShipmentLines;
            //            dr5[6] = rm.ReturnLines;
            //            dr5[7] = "";
            //            dr5[8] = "0 Image(s)";
            //            dt3.Rows.Add(dr5);
            //        }                   
            //    }
            //    gvReturnDetails.DataSource = dt3;
            //    gvReturnDetails.DataBind();
            //    dt3.Clear();
            //}
            //#endregion
        

                

        // ClientScript.RegisterStartupScript(this.GetType(), "fnCall", "<script language='javascript'>alert('SKU Added');</script>");
        //else
        //{
        //    lblMassege.Text = "Please Enter SKU Name";
        //    mpePopupForAddNo.Show();
        //}
        //for delete row

        //protected void btnAddGrid1(object sender, EventArgs e)
        //{
        //    DataTable dt3 = new DataTable();
        //    dt3.Columns.Add("SKUNumber");
        //    dt3.Columns.Add("SKU_Qty_Seq");

        //    //  dt.Columns.Add("SKU_Status");
        //    dt3.Columns.Add("ProductID");
        //    dt3.Columns.Add("SKU_Sequence");


        //    dt3.Columns.Add("NoofImages");
        //    dt3.Columns.Add("SalesPrice");
        //    dt3.Columns.Add("ImageName");
        //    dt3.Columns.Add("LineType");
        //    dt3.Columns.Add("ShipmentLines");

        //    dt3.Columns.Add("ReturnLines");
        //    //dt.Columns.Add("ImageName");
        //    //dt.Columns.Add("LineType");
        //    //dt.Columns.Add("ShipmentLines");
        //    //dt.Columns.Add("ReturnLines");
        //    //dt.Columns.Add("ReturnDetailID");


        //    for (int i = 0; i < gvReturnDetails.Rows.Count; i++)
        //    {
        //        try
        //        {
        //            DataRow dr1 = dt3.NewRow();

        //            TextBox RowID = (TextBox)gvReturnDetails.Rows[i].FindControl("txtRGANumberID");
        //            TextBox SKUNumber = (TextBox)gvReturnDetails.Rows[i].FindControl("txtsku");
        //            TextBox SKU_Qty_Seq = (TextBox)gvReturnDetails.Rows[i].FindControl("txtSKU_Qty_Seq");
        //            //  TextBox SKU_Status = (TextBox)gvReturnDetails.Rows[i].FindControl("txtSKU_Status");
        //            TextBox ProductID = (TextBox)gvReturnDetails.Rows[i].FindControl("txtProductID");

        //            TextBox SKU_Sequence = (TextBox)gvReturnDetails.Rows[i].FindControl("txtSKU_Sequence");

        //            // LinkButton reasons = (LinkButton)gvReturnDetails.Rows[i].FindControl("txtreasons");
        //            //TextBox SalesPrice = (TextBox)gvReturnDetails.Rows[i].FindControl("txtSalesPrice");
        //            TextBox LineType = (TextBox)gvReturnDetails.Rows[i].FindControl("txtLineType");
        //            TextBox ShipmentLines = (TextBox)gvReturnDetails.Rows[i].FindControl("txtShipmentLines");
        //            TextBox ReturnLines = (TextBox)gvReturnDetails.Rows[i].FindControl("txtReturnLines");
        //            Label lblimages = (Label)gvReturnDetails.Rows[i].FindControl("lblImagesName");
        //            LinkButton NoOfImages = (LinkButton)gvReturnDetails.Rows[i].FindControl("txtImageCount");
        //            //    Label lblimages = (Label)gvReturnDetails.Rows[i].FindControl("lblImagesName");

        //            //      LinkButton NoOfImages = (LinkButton)gvReturnDetails.Rows[i].FindControl("txtImageCount");

        //            //     Label lblReturnDetailID = (Label)gvReturnDetails.Rows[i].FindControl("lblguid");

        //            //  dr1[0] = "";
        //            dr1[0] = SKUNumber.Text;
        //            dr1[1] = SKU_Qty_Seq.Text;
        //            dr1[2] = ProductID.Text;
        //            dr1[3] = SKU_Sequence.Text;

        //            dr1[4] = NoOfImages.Text;
        //            //dr1[5] = SalesPrice.Text;
        //            dr1[6] = lblimages.Text;
        //            dr1[7] = LineType.Text;

        //            dr1[8] = ShipmentLines.Text;
        //            dr1[9] = ReturnLines.Text;
        //            // dr1[8] = lblimages.Text;
        //            //dr1[9] = LineType.Text;
        //            //dr1[10] = ShipmentLines.Text;
        //            //dr1[11] = ReturnLines.Text;
        //            //dr1[12] = lblReturnDetailID.Text;




        //            dt3.Rows.Add(dr1);

        //            //if (SKUNumber.Text == txtNewItem.Text)
        //            //{
        //            //    NonPo = false;
        //            //    if (max < Convert.ToInt16(SKU_Sequence.Text))
        //            //    {
        //            //        max = Convert.ToInt16(SKU_Sequence.Text);
        //            //    }
        //            //    if (shipmax < Convert.ToInt16(ShipmentLines.Text))
        //            //    {
        //            //        shipmax = Convert.ToInt16(ShipmentLines.Text);
        //            //    }

        //            //    if (returnmax < Convert.ToInt16(ReturnLines.Text))
        //            //    {
        //            //        returnmax = Convert.ToInt16(ReturnLines.Text);
        //            //    }
        //            //}
        //            //else
        //            //{
        //            //    NonPo = false;
        //            //}
        //        }
        //        catch (Exception)
        //        {
        //        }
        //    }


        //    List<ReturnDetail> _lsReturnDetails = new List<ReturnDetail>();

        //    //string lsredetail;

        //    for (int j = 0; j < gvReturnDetails2.Rows.Count; j++)
        //    {
        //        CheckBox cb = (gvReturnDetails2.Rows[j].FindControl("CheckBox1")) as CheckBox;

        //        if (cb.Checked == true)
        //        {
        //            //if (Convert.ToInt32(gvReturnDetails2.Rows[j].Cells[4].Text.ToString()) == 7)
        //            //{
        //            ReturnDetail rd = new ReturnDetail();

        //            rd.SKUNumber = gvReturnDetails2.Rows[j].Cells[0].Text.ToString();
        //            rd.SKU_Qty_Seq = Convert.ToInt32(gvReturnDetails2.Rows[j].Cells[1].Text.ToString());
        //            //rd.SKU_Qty_Seq = Convert.ToInt32(((gvReturnDetails2.Rows[j].FindControl("SKU_Sequence")) as BoundField));
        //            rd.SKU_Sequence = Convert.ToInt32(gvReturnDetails2.Rows[j].Cells[2].Text.ToString());
        //            rd.ProductID = gvReturnDetails2.Rows[j].Cells[3].Text.ToString();
        //            //  rd.SalesPrice =Convert.ToInt32(gvReturnDetails.Rows[j].Cells[4].Text.ToString());
        //            rd.LineType = Convert.ToInt32(gvReturnDetails2.Rows[j].Cells[4].Text.ToString());
        //            rd.ShipmentLines = Convert.ToInt32(gvReturnDetails2.Rows[j].Cells[5].Text.ToString());
        //            rd.ReturnLines = Convert.ToInt32(gvReturnDetails2.Rows[j].Cells[6].Text.ToString());
        //            rd.DeliveredQty = Convert.ToInt32(gvReturnDetails2.Rows[j].Cells[7].Text.ToString());

        //            _lsReturnDetails.Add(rd);
        //            // }

        //        }

        //    }




        //    foreach (var rm in _lsReturnDetails)
        //    {
        //        DataRow dr = dt3.NewRow();
        //        dr[0] = rm.SKUNumber;
        //        dr[1] = rm.SKU_Qty_Seq;
        //        dr[2] = rm.ProductID;
        //        dr[3] = rm.SKU_Sequence;
        //        dr[4] = "0 Image(s)";
        //        // dr[5] = "0";
        //        dr[6] = "";
        //        dr[7] = rm.LineType;
        //        dr[8] = rm.ShipmentLines;
        //        dr[9] = rm.ReturnLines;
        //        dt3.Rows.Add(dr);
        //    }

        //    //dr[0] = txtNewItem.Text;
        //    //dr[1] = "0";
        //    //dr[2] = "0";
        //    //dr[3] = max + 1000;
        //    //dr[4] = "0 Image(s)";
        //    //dr[5] = "0";
        //    //dr[6] = "";
        //    //dr[7] = "1";

        //    //dr[8] = shipmax + 1000;
        //    //dr[9] = returnmax + 1000;
        //    //dr[8] = "";
        //    //dr[9] = "1";
        //    //dr[10] = shipmax + 1000;
        //    //dr[11] = returnmax + 1000;
        //    //dr[12] = "";




        //    //max = 0;
        //    //returnmax = 0;
        //    //shipmax = 0;
        //    //txtNewItem.Text = "";

        //    gvReturnDetails3.DataSource = dt3;
        //    gvReturnDetails3.DataBind();

        //    dt3.Clear();
        //    lblMassege.Text = "SKU Added";
        //    mpePopupForAddYes.Show();
        //}




        //}

        protected void BtnAddNewItem_Click(object sender, EventArgs e)
        {

            int maxSKU_Sequence = 0, maxShipmentLines = 0, maxReturnLines = 0;
            if (txtNewItem.Text != "")
            {
                //dt.Columns.Add("RGADROWID");
                dt.Columns.Add("SKUNumber");
                dt.Columns.Add("SKU_Qty_Seq");

                //  dt.Columns.Add("SKU_Status");
                dt.Columns.Add("ProductID");
                dt.Columns.Add("SKU_Sequence");


                dt.Columns.Add("NoofImages");
                dt.Columns.Add("SalesPrice");
                dt.Columns.Add("ImageName");
                dt.Columns.Add("LineType");
                dt.Columns.Add("ShipmentLines");

                dt.Columns.Add("ReturnLines");
                dt.Columns.Add("TrackingNumber");
                dt.Columns.Add("ReceivedDate");
                //dt.Columns.Add("ShipmentLines");
                //dt.Columns.Add("ReturnLines");
                //dt.Columns.Add("ReturnDetailID");


                for (int i = 0; i < gvReturnDetails.Rows.Count; i++)
                {
                    try
                    {
                        DataRow dr1 = dt.NewRow();

                        TextBox RowID = (TextBox)gvReturnDetails.Rows[i].FindControl("txtRGANumberID");
                        TextBox SKUNumber = (TextBox)gvReturnDetails.Rows[i].FindControl("txtsku");
                        TextBox SKU_Qty_Seq = (TextBox)gvReturnDetails.Rows[i].FindControl("txtSKU_Qty_Seq");
                        TextBox ProductID = (TextBox)gvReturnDetails.Rows[i].FindControl("txtProductID");
                        TextBox SKU_Sequence = (TextBox)gvReturnDetails.Rows[i].FindControl("txtSKU_Sequence");
                        TextBox LineType = (TextBox)gvReturnDetails.Rows[i].FindControl("txtLineType");
                        TextBox ShipmentLines = (TextBox)gvReturnDetails.Rows[i].FindControl("txtShipmentLines");
                        TextBox ReturnLines = (TextBox)gvReturnDetails.Rows[i].FindControl("txtReturnLines");
                        Label lblimages = (Label)gvReturnDetails.Rows[i].FindControl("lblImagesName");
                        LinkButton NoOfImages = (LinkButton)gvReturnDetails.Rows[i].FindControl("txtImageCount");
                        TextBox TrackingNumber = (TextBox)gvReturnDetails.Rows[i].FindControl("txtTrackingNumber");
                        TextBox ReceivedDate = (TextBox)gvReturnDetails.Rows[i].FindControl("txtReceivedDate");

                        dr1[0] = SKUNumber.Text;
                        dr1[1] = SKU_Qty_Seq.Text;
                        dr1[2] = ProductID.Text;
                        dr1[3] = SKU_Sequence.Text;
                        dr1[4] = NoOfImages.Text;
                        dr1[6] = lblimages.Text;
                        dr1[7] = LineType.Text;
                        dr1[8] = ShipmentLines.Text;
                        dr1[9] = ReturnLines.Text;
                        dr1[10] = TrackingNumber.Text;
                        dr1[11] = ReceivedDate.Text;

                        dt.Rows.Add(dr1);

                        if (SKUNumber.Text == txtNewItem.Text)
                        {
                            NonPo = false;
                            if (maxSKU_Sequence < Convert.ToInt32(SKU_Sequence.Text))
                            {
                                maxSKU_Sequence = Convert.ToInt32(SKU_Sequence.Text);
                            }
                            if (maxShipmentLines < Convert.ToInt32(ShipmentLines.Text))
                            {
                                maxShipmentLines = Convert.ToInt32(ShipmentLines.Text);
                            }

                            if (maxReturnLines < Convert.ToInt32(ReturnLines.Text))
                            {
                                maxReturnLines = Convert.ToInt32(ReturnLines.Text);
                            }
                        }
                        else
                        {
                            NonPo = false;
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
                DataRow dr = dt.NewRow();
                dr[0] = txtNewItem.Text;
                dr[1] = "0";
                dr[2] = "0";
                dr[3] = maxSKU_Sequence + 1000;
                dr[4] = "0 Image(s)";
                dr[5] = "0";
                dr[6] = "";
                dr[7] = "1";

                dr[8] = maxShipmentLines + 1000;
                dr[9] = maxReturnLines + 1000;
                dr[10] = "---";
                dr[11] = DateTime.Now.ToShortDateString();
                //dr[8] = "";
                //dr[9] = "1";
                //dr[10] = shipmax + 1000;
                //dr[11] = returnmax + 1000;
                //dr[12] = "";


                dt.Rows.Add(dr);

                maxSKU_Sequence = 0;
                maxShipmentLines = 0;
                maxReturnLines = 0;
                txtNewItem.Text = "";

                gvReturnDetails.DataSource = dt;
                gvReturnDetails.DataBind();

                dt.Clear();
                lblMassege.Text = "SKU Added";
                mpePopupForAddYes.Show();
            }
            // ClientScript.RegisterStartupScript(this.GetType(), "fnCall", "<script language='javascript'>alert('SKU Added');</script>");
            else
            {
                lblMassege.Text = "Please Enter SKU Name";
                mpePopupForAddNo.Show();
            }

            //  }

        }
        protected void btnCancelHeader_Click(object sender, EventArgs e)
        {
            mpeForCancel.Show();
        }
        protected void btnYesForCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Forms/Web Forms/DemoGrid.aspx");
        }

        protected void btnNonPO_Click(object sender, EventArgs e)
        {
            txtNewItem.BackColor = System.Drawing.ColorTranslator.FromHtml("blue");

            //ModalPopupFORNonPO.Show();
            //txtNewItem.Visible = true;
            //BtnAddNewItem.Visible = true;

        }

        protected void btnAddPO_click(object sender, EventArgs e)
        {
            ModalPopupForGrid.Show();

        }

        protected void btnaddnew_Click(object sender, EventArgs e)
        {
            mpePopupForSaveNo.Show();
            //    ModalPopupFORNonPO.Show();
            //mpeForaddPO.Show();
            //txtNewItem.Visible = true;
            //BtnAddNewItem.Visible = true;
        }

        protected void brdstatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void brdManufacturer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //protected void btnOkForSaveYe_Click(object sender, EventArgs e)
        //{
        //    mpePopupForCommentYes.Show();
        //}

        protected void btnOkForSaveN_Click(object sender, EventArgs e)
        {
            // ModalPopupBitMap.Show();
            txtNewItem.Focus();
            txtNewItem.BackColor = System.Drawing.ColorTranslator.FromHtml("yellow");
            txtNewItem.Visible = true;
            BtnAddNewItem.Visible = true;



        }

        protected void btnOkForSaveYe_Click(object sender, EventArgs e)
        {
            String po = Request.QueryString["RMAPO"].ToString();


            {
                List<RMAInfo> lsCustomeronfo = _newRMA.GetCustomer(po);

                if (lsCustomeronfo.Count > 0)
                {
                    try
                    {
                        FillReturn(lsCustomeronfo);
                    }
                    catch (Exception ex)
                    {
                    }
                    DataGrid.Show();
                    lblMessageForPO.Text = "Select SKU'S From PO Number :- " + po;
                    //Response.Redirect("~/Forms/Web Forms/frmRMAEnterWithPO.aspx?RMAPO=" + po);
                }

            }
        }
        //for deleterow
        //public void BtnDeleteNewItem_Click(object sender, EventArgs e)
        //{

        //    String po = Request.QueryString["RMAPO"].ToString();


        //    {
        //        List<RMAInfo> lsCustomeronfo = _newRMA.GetCustomer(po);

        //        if (lsCustomeronfo.Count > 0)
        //        {
        //            try
        //            {
        //                FillReturnDel(lsCustomeronfo);
        //            }
        //            catch (Exception ex)
        //            {
        //            }
        //            datagrid1.Show();
        //            lblMessageForPO.Text = "Select SKU'S From PO Number :- " + po;
        //            //Response.Redirect("~/Forms/Web Forms/frmRMAEnterWithPO.aspx?RMAPO=" + po);
        //        }

        //    }
        //}





        protected void brdItemNew_SelectedIndexChanged(object sender, EventArgs e)
        {

            //Making Color Changes
            brdItemNew.BackColor = System.Drawing.ColorTranslator.FromHtml("white");
            brdInstalled.BackColor = System.Drawing.ColorTranslator.FromHtml("white");
            brdManufacturer.BackColor = System.Drawing.ColorTranslator.FromHtml("white");
            brdDefecttransite.BackColor = System.Drawing.ColorTranslator.FromHtml("white");
            brdstatus.BackColor = System.Drawing.ColorTranslator.FromHtml("white");

            lblitemNew.BackColor = System.Drawing.ColorTranslator.FromHtml("white");
            lblInstalled.BackColor = System.Drawing.ColorTranslator.FromHtml("white");
            lblstatus.BackColor = System.Drawing.ColorTranslator.FromHtml("white");
            lblManifacturerDefective.BackColor = System.Drawing.ColorTranslator.FromHtml("white");
            lblDefectintransite.BackColor = System.Drawing.ColorTranslator.FromHtml("white");

            if (brdItemNew.Items.FindByText("Yes").Selected == true)
            {
                ViewState["Sku_status"] = "Refund";

                brdDefecttransite.Enabled = false;
                brdManufacturer.Enabled = false;
                brdstatus.Enabled = false;
                brdInstalled.Enabled = false;

                brdDefecttransite.Items.FindByText("Yes").Selected = false;
                brdDefecttransite.Items.FindByText("No").Selected = false;

                brdManufacturer.Items.FindByText("Yes").Selected = false;
                brdManufacturer.Items.FindByText("No").Selected = false;

                brdstatus.Items.FindByText("Yes").Selected = false;
                brdstatus.Items.FindByText("No").Selected = false;

                brdInstalled.Items.FindByText("Yes").Selected = false;
                brdInstalled.Items.FindByText("No").Selected = false;

                btnsubmit.Enabled = true;



            }
            else if (brdItemNew.Items.FindByText("No").Selected == true)
            {
                ViewState["Sku_status"] = "Deny";

                brdDefecttransite.Enabled = true;
                brdManufacturer.Enabled = true;
                brdstatus.Enabled = true;
                brdInstalled.Enabled = true;

                btnsubmit.Enabled = true;
            }
        }

        protected void brdDefecttransite_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (brdDefecttransite.Items.FindByText("Yes").Selected == true)
            {

            }
            else if (brdDefecttransite.Items.FindByText("No").Selected == true)
            {

            }
        }

        protected void ddlotherreasons_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlotherreasons.SelectedIndex == 0)
            {
                txtotherreasons.Text = "";
            }
            else
            {
                // txtotherreasons.Text = ddlotherreasons.SelectedItem.Text;
            }
        }
        //public void fillReturnedstatusandpoit()
        //{
        //    // retuen = Obj.Rcall.ReturnByRGAROWID(RGA)[0];
        //    listofstatus = Obj.Rcall.ReturnedSKUansPoints(Views.Global.ReteunGlobal.ReturnID);


        //    for (int i = 0; i > listofstatus.Count; i++)
        //    {
        //        DataRow dr0 = DtReturnReason.NewRow();
        //        dr0["SKU"] = listofstatus[i].SKU;
        //        dr0["Reason"] = listofstatus[i].Reason;
        //        dr0["Reason_Value"] = listofstatus[i].Reason_Value;
        //        dr0["Points"] = listofstatus[i].Points;
        //        dr0["ItemQuantity"] = listofstatus[i].SkuSequence;
        //        DtReturnReason.Rows.Add(dr0);
        //    }



        //}
        public void fillGrid()
        {
            dt.Columns.Add("RGADROWID");
            dt.Columns.Add("SKUNumber");
            dt.Columns.Add("SKU_Qty_Seq");
            dt.Columns.Add("SKU_Status");
            dt.Columns.Add("SKU_Sequence");
            dt.Columns.Add("SalesPrice");
            dt.Columns.Add("ImageName");
            dt.Columns.Add("LineType");
            dt.Columns.Add("ShipmentLines");
            dt.Columns.Add("ReturnLines");
            DataRow dr = dt.NewRow();

            dr[0] = "";
            dr[1] = "";
            dr[2] = "1";
            dr[3] = "";
            dr[4] = "";
            dr[5] = "";
            dr[6] = "";
            dr[7] = "";
            dr[8] = "";
            dr[9] = "";
            dt.Rows.Add(dr);

            gvReturnDetails.DataSource = dt;
            gvReturnDetails.DataBind();

        }
        //protected void gvReturnDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        //{

        //    //int row = gvReturnDetails.RowIndex;



        //    for (int j = 0; j < gvReturnDetails.Rows.Count; j++)
        //    {

        //        //TextBox txtSKU = (gvReturnDetails.Rows[j].FindControl("SKUNumber")) as TextBox;
        //        //int SKUNumber = Convert.ToInt32(txtSKU.Text);
        //        if (e.CommandName == "Delete")
        //        {
        //            int row = gvReturnDetails.Rows[j].RowIndex;
        //            string ReturnLines = (e.CommandArgument).ToString();
        //            int ReturnLines1 = Convert.ToInt32(e.CommandArgument);
        //            gvReturnDetails.DeleteRow(ReturnLines1);
        //            gvReturnDetails.DataBind();
        //        }
        //        //int SKUNumber=0;

        //        //bind your Grid ,it must
        //    }
        //}

        //TextBox txtSKU = (TextBox)gvReturnDetails.Rows[e.RowIndex].FindControl("SKUNumber");





        //void GvMyCart_RowCommand(Object sender, GridViewCommandEventArgs e)
        //{
        //    ReturnDetail rd = new ReturnDetail();


        //    for (int j = 0; j < gvReturnDetails.Rows.Count; j++)
        //    {
        //        if (e.CommandName == "Delete")
        //        {
        //            rd.SKUNumber = gvReturnDetails.Rows[j].Cells[0].Text.ToString();
        //            var id = Int32.Parse(e.CommandArgument);
        //            .DeleteRow();
        //            bind your Grid ,it must
        //        }
        //    }
        //}

        //FillErrorEventArgs grid in popage
        public void FillReturn(List<RMAInfo> ls)
        {
            try
            {
                List<ReturnDetail> _lsReDetails = new List<ReturnDetail>();
                string ImageName;
                string NoofImages;
                string SKU_Status;

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

                        _lsReDetails.Add(rd);
                    }
                }
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
                                         Rs.SalesPrice,
                                         Rs.LineType,
                                         Rs.ShipmentLines,
                                         Rs.ReturnLines,
                                         //   Rs.ReturnDetailID,
                                         //   ReasonIDs = _Update.ReasonsIdByHasg(Rs.ReturnDetailID),
                                         ImageName = "",
                                         NoofImages = "",
                                         Rs.DeliveredQty,
                                         //string imagename=""

                                     };
              

                gvReturnDetails2.DataSource = ReaturnDetails.ToList();
                gvReturnDetails2.DataBind();
                //gvReturnDetails2.Columns[1].Visible = false;
                //gvReturnDetails2.Columns[2].Visible = false;
                //gvReturnDetails2.Columns[3].Visible = false;
                //gvReturnDetails2.Columns[4].Visible = false;
                //gvReturnDetails2.Columns[5].Visible = false;
                //gvReturnDetails2.Columns[6].Visible = false;
                //Session["GV"] = gvReturnDetails2;

                //  GetCount();
                //foreach (GridViewRow row in gvReturnDetails.Rows)
                //{

                //    string GuidReturnDetail = (row.FindControl("lblguid") as Label).Text;

                //    List<string> lsImages2 = Obj.Rcall.ReturnImagesByReturnDetailsID(Guid.Parse(GuidReturnDetail));

                //    string ImageCount = Convert.ToString(lsImages2.Count);

                //    row.Cells[8].Text = ImageCount + " " + "Image(s)";
                //}




                //gvReturnDetails.Columns[9].Visible = false;
                //gvReturnDetails.Columns[10].Visible = false;
                //gvReturnDetails.Columns[11].Visible = false;
                //gvReturnDetails.Columns[12].Visible = false;

                GetCount();
            }
            catch (Exception)
            { }
        }
        //for Deletedfill


        //public void FillReturnDel(List<RMAInfo> ls)
        //{


        //    try
        //    {
        //        List<ReturnDetail> _lsReDetails = new List<ReturnDetail>();



        //        string ImageName;
        //        string NoofImages;
        //        string SKU_Status;

        //        Obj._lsReturnDetailsWithPO = ls;
        //        foreach (var rm in ls)
        //        {
        //            if (rm.LineType == 7)
        //            {
        //                ReturnDetail rd = new ReturnDetail();

        //                rd.SKUNumber = rm.SKUNumber;
        //                rd.SKU_Qty_Seq = rm.SKU_Qty_Seq;
        //                rd.SKU_Sequence = rm.SKU_Sequence;
        //                rd.ProductID = rm.ProductID;
        //                //  rd.SalesPrice =Convert.ToInt32(gvReturnDetails.Rows[j].Cells[4].Text.ToString());
        //                rd.LineType = rm.LineType;
        //                rd.ShipmentLines = rm.ShipmentLines;
        //                rd.ReturnLines = rm.ReturnLines;
        //                rd.DeliveredQty = rm.DeliveredQty;

        //                _lsReDetails.Add(rd);
        //            }
        //        }
        //        var ReaturnDetails = from Rs in _lsReDetails
        //                             select new
        //                             {
        //                                 // Rs.RGADROWID,
        //                                 Rs.SKUNumber,
        //                                 Rs.SKU_Qty_Seq,
        //                                 // Rs.SKU_Status,
        //                                 SKU_Status = "",
        //                                 Rs.SKU_Sequence,
        //                                 Rs.ProductID,
        //                                 Rs.SalesPrice,
        //                                 Rs.LineType,
        //                                 Rs.ShipmentLines,
        //                                 Rs.ReturnLines,
        //                                 //   Rs.ReturnDetailID,
        //                                 //   ReasonIDs = _Update.ReasonsIdByHasg(Rs.ReturnDetailID),
        //                                 ImageName = "",
        //                                 NoofImages = "",
        //                                 Rs.DeliveredQty,
        //                                 //string imagename=""

        //                             };


        //        gvReturnDetails3.DataSource = gvReturnDetails.ToString();
        //        gvReturnDetails3.DataBind();
        //        gvReturnDetails3.Columns[1].Visible = false;
        //        gvReturnDetails3.Columns[2].Visible = false;
        //        gvReturnDetails3.Columns[3].Visible = false;
        //        gvReturnDetails3.Columns[4].Visible = false;
        //        gvReturnDetails3.Columns[5].Visible = false;
        //        gvReturnDetails3.Columns[6].Visible = false;

        //        //  GetCount();
        //        //foreach (GridViewRow row in gvReturnDetails.Rows)
        //        //{

        //        //    string GuidReturnDetail = (row.FindControl("lblguid") as Label).Text;

        //        //    List<string> lsImages2 = Obj.Rcall.ReturnImagesByReturnDetailsID(Guid.Parse(GuidReturnDetail));

        //        //    string ImageCount = Convert.ToString(lsImages2.Count);

        //        //    row.Cells[8].Text = ImageCount + " " + "Image(s)";
        //        //}




        //        //gvReturnDetails.Columns[9].Visible = false;
        //        //gvReturnDetails.Columns[10].Visible = false;
        //        //gvReturnDetails.Columns[11].Visible = false;
        //        //gvReturnDetails.Columns[12].Visible = false;

        //        GetCount();
        //    }
        //    catch (Exception)
        //    { }
        //}

        //protected void btnPassGrid_Click(object sender, EventArgs e)
        //{
        //    String po = txtPONumber.Text.Trim();
        //    List<RMAInfo> lsCustomeronfo = _newRMA.GetCustomer(po);
        //    var ReaturnDetails1 = from Rs in lsCustomeronfo
        //                          select new
        //                          {
        //                              // Rs.RGADROWID,
        //                              Rs.SKUNumber,
        //                              Rs.SKU_Qty_Seq,
        //                              // Rs.SKU_Status,
        //                              SKU_Status = "",
        //                              Rs.SKU_Sequence,
        //                              Rs.ProductID,
        //                              //  Rs.SalesPrice,
        //                              Rs.LineType,
        //                              Rs.ShipmentLines,
        //                              Rs.ReturnLines,
        //                              //   Rs.ReturnDetailID,
        //                              //   ReasonIDs = _Update.ReasonsIdByHasg(Rs.ReturnDetailID),
        //                              ImageName = "",
        //                              NoofImages = "",
        //                              //string imagename=""


        //                          };

        //    //List<object> _lsReturnDetails = new List<object>();
        //    //_lsReturnDetails = ReaturnDetails1.;
        //    //DataTable dt = new DataTable();
        //    //dt = ReaturnDetails1.ToList();






        //    List<ReturnDetail> _lsReturnDetails = new List<ReturnDetail>();
        //    //string lsredetail;

        //    for (int j = 0; j < gvReturnDetails2.Rows.Count; j++)
        //    {
        //        CheckBox cb = (gvReturnDetails2.Rows[j].FindControl("CheckBox1")) as CheckBox;
        //        if (cb.Checked == true)
        //        {
        //            ReturnDetail rd = new ReturnDetail();

        //            rd.SKUNumber = gvReturnDetails2.Rows[j].Cells[0].Text.ToString();
        //            rd.SKU_Qty_Seq = Convert.ToInt32(gvReturnDetails2.Rows[j].Cells[1].Text.ToString());
        //            rd.SKU_Sequence = Convert.ToInt32(gvReturnDetails2.Rows[j].Cells[2].Text.ToString());
        //            rd.ProductID = gvReturnDetails2.Rows[j].Cells[3].Text.ToString();
        //            //  rd.SalesPrice =Convert.ToInt32(gvReturnDetails.Rows[j].Cells[4].Text.ToString());
        //            rd.LineType = Convert.ToInt32(gvReturnDetails2.Rows[j].Cells[4].Text.ToString());
        //            rd.ShipmentLines = Convert.ToInt32(gvReturnDetails2.Rows[j].Cells[5].Text.ToString());
        //            rd.ReturnLines = Convert.ToInt32(gvReturnDetails2.Rows[j].Cells[6].Text.ToString());


        //            _lsReturnDetails.Add(rd);

        //        }
        //    }
        //    Session["RT"] = _lsReturnDetails;
        //    Response.Redirect("~/Forms/Web Forms/frmRMAEnterWithPO.aspx?RMAPO=" + po);
        //}



        #region Getting Image Counts
        //public void GetCount()
        //{
        //    foreach (GridViewRow row in gvReturnDetails.Rows)
        //    {
        //        //string GuidReturnDetail = (row.FindControl("lblguid") as Label).Text;
        //        //List<string> lsImages2 = Obj.Rcall.ReturnImagesByReturnDetailsID(Guid.Parse(GuidReturnDetail));
        //        //string ImageCount = Convert.ToString(lsImages2.Count);
        //        (row.FindControl("txtImageCount") as LinkButton).Text = "0" + " " + "Image(s)";
        //    }
        //}
        #endregion
        public Boolean display(String RGA)
        {
            Boolean _flag = false;
            try
            {
                //Views.Global.ReteunGlobal = Obj.Rcall.ReturnByPONumber(RGA)[0];
                //txtcustomerName.Text = Views.Global.ReteunGlobal.CustomerName1;
                //txtponumber.Text = Views.Global.ReteunGlobal.PONumber;

                ////  txtponumber.Text =Convert.ToString(retuen.UpdatedBy);

                //txtvendorName.Text = Views.Global.ReteunGlobal.VendoeName;
                //txtRMAnumber.Text = Views.Global.ReteunGlobal.RMANumber;
                //txtshipmentnumber.Text = Views.Global.ReteunGlobal.ShipmentNumber;
                //txtvendornumber.Text = Views.Global.ReteunGlobal.VendorNumber;
                //txtrganumber.Text = Views.Global.ReteunGlobal.RGAROWID;
                //txtreturndate.Text = Convert.ToString(Views.Global.ReteunGlobal.ReturnDate.ToShortDateString());
                //txtorderdate.Text = Convert.ToString(Views.Global.ReteunGlobal.OrderDate.ToShortDateString());
                //txtordernumber.Text = Views.Global.ReteunGlobal.OrderNumber;
                //ddlstatus.SelectedIndex = Convert.ToInt16(Views.Global.ReteunGlobal.RMAStatus);
                //ddldecision.SelectedIndex = Convert.ToInt16(Views.Global.ReteunGlobal.Decision);

                //GetCustomer
                // List<RMAInfo> lsCustomeronfo = _newRMA.ReturnByRMANumber(txtponumber.Text);






                List<RMAInfo> lsCustomeronfo = _newRMA.GetCustomer(RGA);
                // Views.Global.ReteunGlobal = lsCustomeronfo;

                Session["lstrmainsert"] = lsCustomeronfo;
                // Views.Global.lstrmainsert = lsCustomeronfo;

                if (lsCustomeronfo.Count > 0)
                {
                    txtRMAnumber.Text = "N/A";
                    txtponumber.Text = lsCustomeronfo[0].PONumber;
                    txtrganumber.Text = "Generated After Saving this Information.";
                    txtvendorName.Text = lsCustomeronfo[0].VendorName;
                    txtvendornumber.Text = lsCustomeronfo[0].VendorNumber;
                    DateTime dtReturnDate = lsCustomeronfo[0].ReturnDate;
                    txtreturndate.Text = dtReturnDate.ToString("MM/dd/yyyy hh:mm tt");
                    //txtRMAnumber.Text = "";//lsCustomeronfo[0].OrderNumber;
                    txtcustomerName.Text = lsCustomeronfo[0].CustomerName1;
                    txtCustomerAddress.Text = lsCustomeronfo[0].Address1;
                    txtCustomerCity.Text = lsCustomeronfo[0].City;
                    txtCustomerState.Text = lsCustomeronfo[0].State;
                    txtCustomerZip.Text = lsCustomeronfo[0].ZipCode;
                    //txtrganumber.Text=lsCustomeronfo[0]
                    txtshipmentnumber.Text = lsCustomeronfo[0].ShipmentNumber;
                    // TextBox1.Text = lsCustomeronfo[0].CallTag;
                    //txtordernumber.Text = "";//lsCustomeronfo[0].OrderNumber;
                    DateTime dt = lsCustomeronfo[0].OrderDate;
                    //txtorderdate.Text = "";//dt.ToString("MM/dd/yyyy hh:mm tt");

                    string ImageName;
                    string NoofImages;
                    string SKU_Status;

                    //Obj._lsReturnDetailsWithPO = lsCustomeronfo;
                    //var ReaturnDetails = from Rs in lsCustomeronfo
                    //                     select new
                    //                     { // Rs.RGADROWID,
                    //                         Rs.SKUNumber,
                    //                         Rs.SKU_Qty_Seq,
                    //                         // Rs.SKU_Status,
                    //                         SKU_Status = "",
                    //                         Rs.SKU_Sequence,
                    //                         Rs.ProductID,
                    //                         Rs.SalesPrice,
                    //                         Rs.LineType,
                    //                         Rs.ShipmentLines,
                    //                         Rs.ReturnLines,
                    //                         //   Rs.ReturnDetailID,
                    //                         //   ReasonIDs = _Update.ReasonsIdByHasg(Rs.ReturnDetailID),
                    //                         ImageName = "",
                    //                         NoofImages = "",
                    //                         //string imagename=""


                    //                     };




                    //gvReturnDetails.DataSource = ReaturnDetails.ToList();
                    //gvReturnDetails.DataBind();

                    GetCount();

                }


                _flag = true;
            }
            catch (Exception)
            {
            }
            return _flag;
        }


        public void GetCount()
        {
            foreach (GridViewRow row in gvReturnDetails.Rows)
            {
                //string GuidReturnDetail = (row.FindControl("lblguid") as Label).Text;
                //List<string> lsImages2 = Obj.Rcall.ReturnImagesByReturnDetailsID(Guid.Parse(GuidReturnDetail));
                //string ImageCount = Convert.ToString(lsImages2.Count);
                (row.FindControl("txtImageCount") as LinkButton).Text = "0" + " " + "Image(s)";
            }
        }
        protected void txtponumber_TextChanged(object sender, EventArgs e)
        {
            ////     List<RMAInfo> lsCustomeronfo = _newRMA.GetCustomer(txtponumber.Text);

            ///     if (lsCustomeronfo.Count > 0)
            ///    {
            ////        txtponumber.Text = lsCustomeronfo[0].PONumber;
            // txtcustomeraddress.Text = lsCustomeronfo[0].Address1;
            //   txtcountry.Text = lsCustomeronfo[0].Country;
            //   txtcity.Text = lsCustomeronfo[0].City;
            //   txtstate.Text = lsCustomeronfo[0].State;
            //  txtzipcode.Text = lsCustomeronfo[0].ZipCode;
            ///       txtvendorName.Text = lsCustomeronfo[0].VendorName;
            ///      txtvendornumber.Text = lsCustomeronfo[0].VendorNumber;
            ///       txtRMAnumber.Text = lsCustomeronfo[0].OrderNumber;
            ///        txtcustomerName.Text = lsCustomeronfo[0].CustomerName1;
            //txtrganumber.Text=lsCustomeronfo[0]
            ///         txtshipmentnumber.Text = lsCustomeronfo[0].ShipmentNumber;
            ///       TextBox1.Text = lsCustomeronfo[0].CallTag;
            ///      txtordernumber.Text = lsCustomeronfo[0].OrderNumber;
            ///      DateTime dt = lsCustomeronfo[0].OrderDate;
            //      txtorderdate.Text = dt.ToString("MM/dd/yyyy hh:mm tt");

            ///    }

            //  List<Return> ls = Obj.Rcall.ReturnByPONumber(txtponumber.Text);


            // FillReturnDetails(ls);

            ///     FillReturnDetails(Obj.Rcall.ReturnDetailByPoNumber(txtponumber.Text));
        }
        #region RadioButton1_CheckedChanged1
        protected void RadioButton1_CheckedChanged1(object sender, EventArgs e)
        {
            try
            {
                btnsubmit.Enabled = true;
               // btnDelete.Enabled = true;
                txtotherreasons.Text = "";
                brdDefecttransite.Enabled = true;
                brdManufacturer.Enabled = true;
                brdstatus.Enabled = true;
                brdInstalled.Enabled = true;
                brdItemNew.Enabled = true;

                brdItemNew.Items.FindByText("Yes").Selected = false;
                brdItemNew.Items.FindByText("No").Selected = false;

                brdDefecttransite.Items.FindByText("Yes").Selected = false;
                brdDefecttransite.Items.FindByText("No").Selected = false;

                brdManufacturer.Items.FindByText("Yes").Selected = false;
                brdManufacturer.Items.FindByText("No").Selected = false;

                brdstatus.Items.FindByText("Yes").Selected = false;
                brdstatus.Items.FindByText("No").Selected = false;

                brdInstalled.Items.FindByText("Yes").Selected = false;
                brdInstalled.Items.FindByText("No").Selected = false;


                ddlotherreasons.SelectedIndex = 0;


                DataTable DT = new DataTable();
                DT = Session["dt"] as DataTable;

                DataTable DTTracking = new DataTable();
                DTTracking = Session["DtTracking"] as DataTable;

                for (int j = 0; j < gvReturnDetails.Rows.Count; j++)
                {
                    RadioButton rb = (gvReturnDetails.Rows[j].FindControl("RadioButton1")) as RadioButton;
                    if (rb.Checked == true)
                    {                       
                        String SKUNumberforprint = (gvReturnDetails.Rows[j].FindControl("txtSKU") as TextBox).Text;
                        ((List<String>)Session["_lsSlipPrintSKUNumber"]).Add(SKUNumberforprint);
                        ///To enable all row
                        /// txtImageCount txtSKU_Qty_Seq txtSKU txtImageCount FileUpload1
                        LinkButton lnkImageCnt = (gvReturnDetails.Rows[j].FindControl("txtImageCount")) as LinkButton;
                        TextBox txtskuqty = (gvReturnDetails.Rows[j].FindControl("txtSKU_Qty_Seq")) as TextBox;
                        TextBox txtsku = (gvReturnDetails.Rows[j].FindControl("txtSKU")) as TextBox;
                        //LinkButton lnkImageCnt = (gvReturnDetails.Rows[j].FindControl("txtImageCount")) as LinkButton;
                        FileUpload fp1 = (gvReturnDetails.Rows[j].FindControl("FileUpload1")) as FileUpload;

                        Button btnupload = gvReturnDetails.Rows[j].FindControl("btnUpdate") as Button;

                        lnkImageCnt.Enabled = true;
                        txtskuqty.Enabled = true;
                        txtsku.Enabled = true;
                        fp1.Enabled = true;
                        btnupload.Visible = true;

                        TextBox TrackingNumber = (gvReturnDetails.Rows[j].FindControl("txtTrackingNumber")) as TextBox;

                        TrackingNumber.Enabled = true;

                        if (TrackingNumber.Text == "---")
                        {
                            TrackingNumber.Text = "";
                        }


                        Button btnSubmit = gvReturnDetails.Rows[j].FindControl("SubmitButton") as Button;
                        btnSubmit.Enabled = true;


                        String LinetType = (gvReturnDetails.Rows[j].FindControl("txtLineType") as TextBox).Text;

                        if (Convert.ToInt16(LinetType) != 6 || LinetType == "" || LinetType == null)
                        {

                            //Making Color Changes
                            brdItemNew.BackColor = System.Drawing.ColorTranslator.FromHtml("InactiveCaption");
                            brdInstalled.BackColor = System.Drawing.ColorTranslator.FromHtml("InactiveCaption");
                            brdManufacturer.BackColor = System.Drawing.ColorTranslator.FromHtml("InactiveCaption");
                            brdDefecttransite.BackColor = System.Drawing.ColorTranslator.FromHtml("InactiveCaption");
                            brdstatus.BackColor = System.Drawing.ColorTranslator.FromHtml("InactiveCaption");

                            lblitemNew.BackColor = System.Drawing.ColorTranslator.FromHtml("InactiveCaption");
                            lblInstalled.BackColor = System.Drawing.ColorTranslator.FromHtml("InactiveCaption");
                            lblstatus.BackColor = System.Drawing.ColorTranslator.FromHtml("InactiveCaption");
                            lblManifacturerDefective.BackColor = System.Drawing.ColorTranslator.FromHtml("InactiveCaption");
                            lblDefectintransite.BackColor = System.Drawing.ColorTranslator.FromHtml("InactiveCaption");


                            String SKUNumber = (gvReturnDetails.Rows[j].FindControl("txtSKU") as TextBox).Text;

                            ViewState["SelectedskuName"] = SKUNumber;

                            String ReturnLi = (gvReturnDetails.Rows[j].FindControl("txtReturnLines") as TextBox).Text;

                            ViewState["SelectedreturnLine"] = ReturnLi;

                            String SKUSequence = (gvReturnDetails.Rows[j].FindControl("txtSKU_Sequence") as TextBox).Text;

                            ViewState["ItemQuantity"] = SKUSequence;                            

                            (gvReturnDetails.Rows[j].FindControl("txtSKU_Qty_Seq") as TextBox).Text = "1";

                            String SkuQuantitySequence = (gvReturnDetails.Rows[j].FindControl("txtSKU_Qty_Seq") as TextBox).Text;

                            ViewState["SkuQuantitySequence"] = SkuQuantitySequence;                            

                            //string GuidReturnDetail = (gvReturnDetails.Rows[j].FindControl("lblguid") as Label).Text;

                            //ViewState["ReturnDetailID"] = GuidReturnDetail;

                            //String SKUStatus = (gvReturnDetails.Rows[j].FindControl("txtSKU_Status") as TextBox).Text;

                            //ViewState["Sku_status"] = SKUStatus;

                            ////////////////////////////////if (SKUStatus != "")
                            ////////////////////////////////{


                            for (int i = 0; i < DTTracking.Rows.Count; i++)
                            {
                                if (SKUNumber == DTTracking.Rows[i][0].ToString() && ReturnLi == DTTracking.Rows[i][1].ToString())
                                {
                                    TrackingNumber.Text = DTTracking.Rows[i][2].ToString();
                                }
                                else if (TrackingNumber.Text == "---")
                                {
                                    TrackingNumber.Text = "";
                                }
                            }




                                for (int i = 0; i < DT.Rows.Count; i++)
                                {

                                    // string kU = DT.Rows[i][1].ToString();

                                    // string sku = DT.Rows[i][4].ToString();

                                    if (SKUNumber == DT.Rows[i][0].ToString() && ReturnLi == DT.Rows[i][5].ToString())
                                    {
                                        // msg = dt.Rows[i][1].ToString() + " : " + dt.Rows[i][2].ToString() + "\n" + msg;

                                        string data1 = DT.Rows[i][1].ToString();
                                        string data2 = DT.Rows[i][2].ToString();

                                        if (DT.Rows[i][1].ToString() == "Item is New" && DT.Rows[i][2].ToString() == "Yes")
                                        {
                                            brdItemNew.Items.FindByText("Yes").Selected = true;
                                        }
                                        else if ((DT.Rows[i][1].ToString() == "Item is New" && DT.Rows[i][2].ToString() == "No"))
                                        {
                                            brdItemNew.Items.FindByText("No").Selected = true;
                                            brdDefecttransite.Enabled = true;
                                            brdManufacturer.Enabled = true;
                                            brdstatus.Enabled = true;
                                            brdInstalled.Enabled = true;
                                        }
                                        else if ((DT.Rows[i][1].ToString() == "Installed" && DT.Rows[i][2].ToString() == "Yes"))
                                        {
                                            brdInstalled.Items.FindByText("Yes").Selected = true;
                                        }
                                        else if ((DT.Rows[i][1].ToString() == "Installed" && DT.Rows[i][2].ToString() == "No"))
                                        {
                                            brdInstalled.Items.FindByText("No").Selected = true;
                                        }
                                        else if ((DT.Rows[i][1].ToString() == "Chip/Bended/Scratch/Broken" && DT.Rows[i][2].ToString() == "Yes"))
                                        {
                                            brdstatus.Items.FindByText("Yes").Selected = true;
                                        }
                                        else if ((DT.Rows[i][1].ToString() == "Chip/Bended/Scratch/Broken" && DT.Rows[i][2].ToString() == "No"))
                                        {
                                            brdstatus.Items.FindByText("No").Selected = true;
                                        }
                                        else if ((DT.Rows[i][1].ToString() == "Manufacturer Defective" && DT.Rows[i][2].ToString() == "Yes"))
                                        {
                                            brdManufacturer.Items.FindByText("Yes").Selected = true;
                                        }
                                        else if ((DT.Rows[i][1].ToString() == "Manufacturer Defective" && DT.Rows[i][2].ToString() == "No"))
                                        {
                                            brdManufacturer.Items.FindByText("No").Selected = true;
                                        }
                                        else if ((DT.Rows[i][1].ToString() == "Defect in Transit" && DT.Rows[i][2].ToString() == "Yes"))
                                        {
                                            brdDefecttransite.Items.FindByText("Yes").Selected = true;
                                        }
                                        else if ((DT.Rows[i][1].ToString() == "Defect in Transit" && DT.Rows[i][2].ToString() == "No"))
                                        {
                                            brdDefecttransite.Items.FindByText("No").Selected = true;
                                        }

                                        if (Convert.ToInt32(DT.Rows[i][6].ToString())==0)
                                        {
                                            ddlotherreasons.SelectedIndex = 0;
                                            txtotherreasons.Text = "";
                                        }
                                        else if(Convert.ToInt32(DT.Rows[i][6].ToString())==1)
                                        {
                                            ddlotherreasons.SelectedIndex = ddlotherreasons.Items.IndexOf(ddlotherreasons.Items.FindByText(DT.Rows[i][7].ToString()));
                                        }
                                        else if (Convert.ToInt32(DT.Rows[i][6].ToString()) == 2)
                                        {
                                            txtotherreasons.Text = DT.Rows[i][7].ToString();
                                        }
                                    }
                                }
                        }
                        else
                        {
                            mpeForLineType.Show();

                            // ClientScript.RegisterStartupScript(this.GetType(), "fnCall", "<script language='javascript'>alert('Can not add comment/parent sku for combination item');</script>");
                            lblMassege.Text = "Can not add comment/parent sku for combination item";
                            //  string display = "This is Line Type 6";
                            // ClientScript.RegisterStartupScript(this.GetType(), "yourMessage", "alert('" + display + "');", true);

                            rb.Checked = false;

                            brdDefecttransite.Enabled = false;
                            brdManufacturer.Enabled = false;
                            brdstatus.Enabled = false;
                            brdInstalled.Enabled = false;
                            brdItemNew.Enabled = false;

                            brdItemNew.Items.FindByText("Yes").Selected = false;
                            brdItemNew.Items.FindByText("No").Selected = false;

                            brdDefecttransite.Items.FindByText("Yes").Selected = false;
                            brdDefecttransite.Items.FindByText("No").Selected = false;

                            brdManufacturer.Items.FindByText("Yes").Selected = false;
                            brdManufacturer.Items.FindByText("No").Selected = false;

                            brdstatus.Items.FindByText("Yes").Selected = false;
                            brdstatus.Items.FindByText("No").Selected = false;

                            brdInstalled.Items.FindByText("Yes").Selected = false;
                            brdInstalled.Items.FindByText("No").Selected = false;


                        }
                    }
                    else
                    {
                        LinkButton lnkImageCnt = (gvReturnDetails.Rows[j].FindControl("txtImageCount")) as LinkButton;
                        TextBox txtskuqty = (gvReturnDetails.Rows[j].FindControl("txtSKU_Qty_Seq")) as TextBox;
                        TextBox txtsku = (gvReturnDetails.Rows[j].FindControl("txtSKU")) as TextBox;
                        //LinkButton lnkImageCnt = (gvReturnDetails.Rows[j].FindControl("txtImageCount")) as LinkButton;
                        FileUpload fp1 = (gvReturnDetails.Rows[j].FindControl("FileUpload1")) as FileUpload;

                        Button btnupload = gvReturnDetails.Rows[j].FindControl("btnUpdate") as Button;

                        lnkImageCnt.Enabled = false;
                        txtskuqty.Enabled = false;
                        txtsku.Enabled = false;
                        fp1.Enabled = false;
                        btnupload.Visible = false;

                        TextBox TrackingNumber = (gvReturnDetails.Rows[j].FindControl("txtTrackingNumber")) as TextBox;

                        TrackingNumber.Enabled = false;


                        Button btnSubmit = gvReturnDetails.Rows[j].FindControl("SubmitButton") as Button;
                        btnSubmit.Enabled = false;

                    }
                }
            }
            catch (Exception)
            {
            }


        }
        #endregion
        public static void ResizeImage(int size, string filePath, string saveFilePath)
        {
            //variables for image dimension/scale
            double newHeight = 0;
            double newWidth = 0;
            double scale = 0;

            //create new image object
            Bitmap curImage = new Bitmap(filePath);

            //Determine image scaling
            if (curImage.Height > curImage.Width)
            {
                scale = Convert.ToSingle(size) / curImage.Height;
            }
            else
            {
                scale = Convert.ToSingle(size) / curImage.Width;
            }
            if (scale < 0 || scale > 1) { scale = 1; }

            //New image dimension
            newHeight = Math.Floor(Convert.ToSingle(curImage.Height) * scale);
            newWidth = Math.Floor(Convert.ToSingle(curImage.Width) * scale);

            //Create new object image
            Bitmap newImage = new Bitmap(curImage, Convert.ToInt32(newWidth), Convert.ToInt32(newHeight));
            Graphics imgDest = Graphics.FromImage(newImage);
            imgDest.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            imgDest.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            imgDest.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            imgDest.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            ImageCodecInfo[] info = ImageCodecInfo.GetImageEncoders();
            EncoderParameters param = new EncoderParameters(1);
            param.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L);

            //Draw the object image
            imgDest.DrawImage(curImage, 0, 0, newImage.Width, newImage.Height);

            //Save image file
            newImage.Save(saveFilePath, info[1], param);

            //Dispose the image objects
            curImage.Dispose();
            newImage.Dispose();
            imgDest.Dispose();
        }

        public static string RemoveSpecialCharacters(string str)
        {
            return Regex.Replace(str, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);
        }




        protected void chkflag_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void btnUpdate_Click1(object sender, EventArgs e)
        {
            #region Uploading Multiple Images
            string updir = System.Configuration.ConfigurationManager.AppSettings["PhysicalPath"].ToString();
            GridViewRow gvRow = (sender as Button).NamingContainer as GridViewRow;
            FileUpload fupload = gvRow.FindControl("FileUpload1") as FileUpload;
            bool hasfile = fupload.HasFile;
            //int c=fupload.FileName.Count();
            //Label Image = (gvRow.FindControl("lblNoImages") as Label);



            bool folderExists = Directory.Exists(@"C:\Images1\");
            if (folderExists)
            {
                foreach (string directory in Directory.GetDirectories(@"C:\Images1\"))
                {
                    string filepath = directory;
                    foreach (string file in Directory.GetFiles(filepath))
                    {
                        File.Delete(file);
                    }
                    Directory.Delete(directory);
                }

                foreach (string file in Directory.GetFiles(@"C:\Images1\"))
                {
                    File.Delete(file);
                }

            }
            else
            {
                Directory.CreateDirectory(@"C:\Images1\");
            }
            bool folderExists1 = Directory.Exists(@"C:\Images\");

            if (folderExists1)
            {

            }
            else
            {
                Directory.CreateDirectory(@"C:\Images\");
            }

            HttpFileCollection fileCollection = Request.Files;

            int count = 0;
            for (int i = 0; i < fileCollection.Count; i++)
            {
                HttpPostedFile uploadfile = fileCollection[i];
                string fileName = Path.GetFileName(uploadfile.FileName);


                string fileextension = Path.GetExtension(uploadfile.FileName);

                String[] allowedExtensions = { ".jpeg", ".jpg", ".JPG", ".JPEG" };
                for (int b = 0; b < allowedExtensions.Length; b++)
                {
                    if (fileextension == allowedExtensions[b])
                    {


                        fileName = "img" + RemoveSpecialCharacters(Convert.ToString(DateTime.Now) + fileName);

                        if (uploadfile.ContentLength > 0)
                        {
                            count++;
                            uploadfile.SaveAs(@"C:\Images1\" + fileName);
                            // uploadfile.SaveAs(@"C:\Images\" + fileName);
                            #region  Resizing of Images1
                            String filepath = @"C:\Images1\" + fileName;
                            ResizeImage(800, filepath, @"C:\Images\" + fileName);
                            #endregion

                            byte[] bytes = File.ReadAllBytes(@"C:\Images\" + fileName);
                            // ExtensionMethods.Upload(@"\\192.168.1.172\Macintosh HD\ftp_share\RGAImages", "mediaserver", "kraus2013", "C:\\Images\\" + fileName.ToString(), bytes);
                            ExtensionMethods.Upload(@"ftp://fileshare.kraususa.com", "rgauser", "rgaICG2014", "C:\\Images\\" + fileName.ToString(), bytes);
                            File.Delete(@"C:\Images\" + fileName.ToString());
                            File.Delete(@"C:\Images1\" + fileName.ToString());
                            Label lbl = gvRow.FindControl("lblImagesName") as Label;
                            lbl.Text = lbl.Text + "\n" + fileName.ToString();
                            mpePopupForImageYes.Show();
                        }




                    }
                }



            }
            Directory.Delete(@"C:\Images1\");
            #endregion

            string ImageNo = (gvRow.FindControl("txtImageCount") as LinkButton).Text;
            int img = Convert.ToInt16(ImageNo.Split(new char[] { ' ' })[0]);

            int noOfImages;
            noOfImages = img + count;

            string displayImageCount = noOfImages.ToString() + " " + "Image(s)";
            // gvRow.Cells[8].Text = displayImageCount.ToString();


            foreach (GridViewRow row in gvReturnDetails.Rows)
            {
                if (gvRow.RowIndex == row.RowIndex)
                {
                    (row.FindControl("txtImageCount") as LinkButton).Text = displayImageCount.ToString();
                }
                else
                {
                    //string GuidReturnDetail = (row.FindControl("lblguid") as Label).Text;

                    // List<string> lsImages2 = Obj.Rcall.ReturnImagesByReturnDetailsID(Guid.Parse(GuidReturnDetail));
                    //string PresentCount = (row.FindControl("txtImageCount") as LinkButton).Text;

                    //string ImageCount = Convert.ToString(lsImages2.Count);

                    //(row.FindControl("txtImageCount") as LinkButton).Text = PresentCount;
                }
            }
        }

        protected void FileUpload1_Load1(object sender, EventArgs e)
        {
            GridViewRow gvRow = (sender as FileUpload).NamingContainer as GridViewRow;
            Button btnupload = gvRow.FindControl("btnUpdate") as Button;

            //string ImageNo = (gvRow.FindControl("lblNoImages") as Label).Text;

            //int NoImgages = Convert.ToInt16(ImageNo.Split(new char[] { ' ' })[0]);

            //(gvRow.FindControl("lblNoImages") as Label).Text = NoImgages + 1 + " " + "Image(s)";

            btnupload.Enabled = true;
        }

        protected void btnOkForSaveYes_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/Forms/Web Forms/frmHomePage.aspx");
            Response.Redirect("~/Forms/Web Forms/DemoGrid.aspx");

        }

        protected void txtcustomerName_TextChanged(object sender, EventArgs e)
        {

        }

        protected void brdInstalled_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (brdInstalled.Items.FindByText("Yes").Selected == true)
            {
                ViewState["Sku_status"] = "Deny";

                brdDefecttransite.Enabled = false;
                brdManufacturer.Enabled = false;
                brdstatus.Enabled = false;


                brdDefecttransite.Items.FindByText("Yes").Selected = false;
                brdDefecttransite.Items.FindByText("No").Selected = false;

                brdManufacturer.Items.FindByText("Yes").Selected = false;
                brdManufacturer.Items.FindByText("No").Selected = false;

                brdstatus.Items.FindByText("Yes").Selected = false;
                brdstatus.Items.FindByText("No").Selected = false;



            }
            else if (brdInstalled.Items.FindByText("No").Selected == true)
            {
                brdDefecttransite.Enabled = true;
                brdManufacturer.Enabled = true;
                brdstatus.Enabled = true;

            }
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {


        }


        protected void gvReturnDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {

                btnsubmit.Enabled = true;
               // btnDelete.Enabled = false;


                brdDefecttransite.Enabled = true;
                brdManufacturer.Enabled = true;
                brdstatus.Enabled = true;
                brdInstalled.Enabled = true;
                brdItemNew.Enabled = true;

                brdItemNew.Items.FindByText("Yes").Selected = false;
                brdItemNew.Items.FindByText("No").Selected = false;

                brdDefecttransite.Items.FindByText("Yes").Selected = false;
                brdDefecttransite.Items.FindByText("No").Selected = false;

                brdManufacturer.Items.FindByText("Yes").Selected = false;
                brdManufacturer.Items.FindByText("No").Selected = false;

                brdstatus.Items.FindByText("Yes").Selected = false;
                brdstatus.Items.FindByText("No").Selected = false;

                brdInstalled.Items.FindByText("Yes").Selected = false;
                brdInstalled.Items.FindByText("No").Selected = false;


                // mpeForaddPO.Show();
                //Taking DataTable for storing New data after deleting records
                DataTable dt5 = new DataTable();

                dt5.Columns.Add("SKUNumber");
                dt5.Columns.Add("SKU_Qty_Seq");
                dt5.Columns.Add("SKU_Sequence");
                dt5.Columns.Add("ProductID");
                dt5.Columns.Add("NoofImages");
                dt5.Columns.Add("ImageName");
                dt5.Columns.Add("LineType");
                dt5.Columns.Add("ShipmentLines");
                dt5.Columns.Add("ReturnLines");
                dt5.Columns.Add("TrackingNumber");
                dt5.Columns.Add("ReceivedDate");

                //Making Datatable for Taking all data from Gridview "gvReturnDetails"
                DataTable dt4 = new DataTable();

                dt4.Columns.Add("SKUNumber");
                dt4.Columns.Add("SKU_Qty_Seq");
                dt4.Columns.Add("SKU_Sequence");
                dt4.Columns.Add("ProductID");
                dt4.Columns.Add("NoofImages");
                dt4.Columns.Add("ImageName");
                dt4.Columns.Add("LineType");
                dt4.Columns.Add("ShipmentLines");
                dt4.Columns.Add("ReturnLines");
                dt4.Columns.Add("TrackingNumber");
                dt4.Columns.Add("ReceivedDate");

                for (int i = 0; i < gvReturnDetails.Rows.Count; i++)
                {
                    try
                    {
                        //Creating Row in DataTable
                        DataRow dr1 = dt4.NewRow();

                        //Taking values from Gridview "gvReturnDetails"

                        TextBox SKUNumber = (TextBox)gvReturnDetails.Rows[i].FindControl("txtSKU");
                        TextBox SKU_Qty_Seq = (TextBox)gvReturnDetails.Rows[i].FindControl("txtSKU_Qty_Seq");
                        TextBox SKU_Sequence = (TextBox)gvReturnDetails.Rows[i].FindControl("txtSKU_Sequence");
                        TextBox ProductID = (TextBox)gvReturnDetails.Rows[i].FindControl("txtProductID");
                        TextBox LineType = (TextBox)gvReturnDetails.Rows[i].FindControl("txtLineType");
                        TextBox ShipmentLines = (TextBox)gvReturnDetails.Rows[i].FindControl("txtShipmentLines");
                        TextBox ReturnLines = (TextBox)gvReturnDetails.Rows[i].FindControl("txtReturnLines");
                        Label lblimages = (Label)gvReturnDetails.Rows[i].FindControl("lblImagesName");
                        LinkButton NoOfImages = (LinkButton)gvReturnDetails.Rows[i].FindControl("txtImageCount");
                        TextBox TrackingNumber = (TextBox)gvReturnDetails.Rows[i].FindControl("txtTrackingNumber");
                        TextBox ReceivedDate = (TextBox)gvReturnDetails.Rows[i].FindControl("txtReceivedDate");

                        //Inserting values in Row                   
                        dr1[0] = SKUNumber.Text;
                        dr1[1] = SKU_Qty_Seq.Text;
                        dr1[2] = SKU_Sequence.Text;
                        dr1[3] = ProductID.Text;
                        dr1[4] = NoOfImages.Text;
                        dr1[5] = lblimages.Text;
                        dr1[6] = LineType.Text;
                        dr1[7] = ShipmentLines.Text;
                        dr1[8] = ReturnLines.Text;
                        dr1[9] = TrackingNumber.Text;
                        dr1[10] = ReceivedDate.Text;
                        //Inserting Row in DataTable
                        dt4.Rows.Add(dr1);
                    }
                    catch (Exception exa)
                    {

                    }
                }

                //Taking ReturnLine from gridview "gvReturnDetails" & Deleting row from Datatable & Binding new DataTable to Gridview "gvReturnDetails"
                for (int i = 0; i <= gvReturnDetails.Rows.Count - 1; i++)
                {


                    //Taking index from Delete Button in GridView "gvReturnDetails"
                    int index = Convert.ToInt32(e.RowIndex);

                    //Checking index
                    if (index == gvReturnDetails.Rows[i].RowIndex)
                    {
                        //Getting UniqueID "returnLine" & "skuNumber" from gridview "gvReturnDetails"
                        string SKU_Sequence = ((gvReturnDetails.Rows[i].FindControl("txtSKU_Sequence")) as TextBox).Text;
                        string skuNumber = ((gvReturnDetails.Rows[i].FindControl("txtSKU")) as TextBox).Text;

                        //Deleting Row from Datatable "dt4"
                        foreach (DataRow row in dt4.Rows) //(int l = 0; l < dt4.Rows.Count - 1;l++ )
                        {
                            if (SKU_Sequence == row["SKU_Sequence"].ToString() && skuNumber == row["SKUNumber"].ToString())
                            {


                            }
                            else
                            {
                                //dt5.Rows.Add(row);
                                //Creating Row in DataTable
                                DataRow dr1 = dt5.NewRow();

                                //Inserting values in Row                           
                                dr1[0] = row["SKUNumber"].ToString();
                                dr1[1] = row["SKU_Qty_Seq"].ToString();
                                dr1[2] = row["SKU_Sequence"].ToString();
                                dr1[3] = row["ProductID"].ToString();
                                dr1[4] = row["NoofImages"].ToString();
                                dr1[5] = row["ImageName"].ToString();
                                dr1[6] = row["LineType"].ToString();
                                dr1[7] = row["ShipmentLines"].ToString();
                                dr1[8] = row["ReturnLines"].ToString();
                                dr1[9] = row["TrackingNumber"].ToString();
                                dr1[10] = row["ReceivedDate"].ToString();

                                //Inserting Row in DataTable
                                dt5.Rows.Add(dr1);
                            }
                        }
                    }
                }

                //Binding DataTable to GridView "gvReturnDetails"
                gvReturnDetails.DataSource = dt5;
                gvReturnDetails.DataBind();

            }
            catch (Exception ttttt)
            { }
        }
        

        //if (_lsReturnDetails == gvReturnDetails.Rows.Count[])
        //    {


        //    }
        //protected void gvReturnDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
           
        //        // e.Row.Cells[5].Visible = false;

        
        //        //for (int i = 0; i <= gvReturnDetails.Rows.Count - 1; i++)
        //        //{
        //        //      int index = Convert.ToInt32(e.RowIndex);
        //        //    if (gvReturnDetails.Rows[i].RowType == DataControlRowType.DataRow)
        //        //    {
        //        //        string item = gvReturnDetails.Rows[i].Cells[0].Text;
        //        //        foreach (Button button in gvReturnDetails.Rows[i].Controls.OfType<Button>())
        //        //        {


        //        //            if (button == gvReturnDetails.Rows[i].Controls.OfType<Button>())
        //        //            {
        //        //                button.Attributes["onclick"] = "if(!confirm('Do you want to delete " + item + "?')){ return false; };";
        //        //            }
        //        //        }


        //        //        LinkButton lb = ((LinkButton)gvReturnDetails.Rows[i].Cells[5].Controls[2]);
        //        //        if (lb != null)
        //        //        {
        //        //            attach the JavaScript function with the ID as the paramter
        //        //            lb.Attributes.Add("onclick", "return ConfirmOnDelete('" + item + "');");
        //        //        }
        //        //        ((LinkButton)gvReturnDetails.Rows[i].Cells[0].Controls[2]).OnClientClick = "return confirm('Do you really want to delete?');";
        //        //    }
        //        //}
            
        //}

        protected void gvReturnDetails3_ImageDeleting(object sender, GridViewDeleteEventArgs e )
        { 
        
        }







        protected void gvReturnDetails_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void gvReturnDetails3_SelectedIndexChanged(object sender, EventArgs e)
        { 
        
        }

        protected void BtnDeleteImage_Click(object sender, EventArgs e)
        {
            bindData();
            GridImage.Show();
        }
        public class fileps
        {
            public String FilePath { get; set; }
            public String FileName { get; set; }
            public String Name { get; set; }
        }
        public void bindData()
        {
            try
            {
                //   List<fileps> lstpathprevious = new List<fileps>();
                //  List<fileps>)Session["rmacomment"] lstpath = new List<fileps>();
                //string path=Server.MapPath(@"~\Themes\img");
                //System.IO.DirectoryInfo downloadedMessageInfo = new DirectoryInfo(path);

                //foreach (FileInfo file in downloadedMessageInfo.GetFiles())
                //{
                //   // file.Delete();
                //}
                List<fileps> lstpath = new List<fileps>();


                //  lstpathprevious = (List<fileps>)Session["ImgList"];
                //if (lstpathprevious.Count > 0)
                //{
                //    for (int i = 0; i < lstpathprevious.Count; i++)
                //    {
                //        fileps ps = new fileps();
                //        ps.Name = lstpathprevious[i].Name;
                //        ps.FilePath = lstpathprevious[i].FilePath;
                //        ps.FileName = lstpathprevious[i].FileName;
                //        lstpath.Add(ps);

                //    }
                //    //GridView1.DataSource = lstpath;
                //    //GridView1.DataBind();
                //}


                for (int i = 0; i < gvReturnDetails.Rows.Count; i++)
                {
                    string imglist = ((Label)gvReturnDetails.Rows[i].FindControl("lblImagesName")).Text;

                    Session["ImgList"] = imglist;


                    foreach (var item in imglist.Split(new char[] { '\n' }))
                    {
                        if (item != null && item != "")
                        {



                            String NameImage = System.Configuration.ConfigurationManager.AppSettings["PhysicalPath"].ToString() + "\\" + item.ToString();

                            //using (System.Net.WebClient client = new System.Net.WebClient())
                            //{
                            //    try
                            //    {


                            //        ////String FName = new FileInfo(filename).Name;
                            //        ////String FullName = ftpServer + "/" + FName;
                            //        byte[] data2 = client.DownloadData(NameImage);
                            //    }
                            //    catch (Exception)
                            //    {
                            //    }
                            //}
                            if (File.Exists(NameImage))
                            {

                                hdfShipmentLine.Value = ((TextBox)gvReturnDetails.Rows[i].FindControl("txtShipmentLines")).Text;

                                hdRetunLine.Value = ((TextBox)gvReturnDetails.Rows[i].FindControl("txtReturnLines")).Text;

                                hdfskusequence.Value = ((TextBox)gvReturnDetails.Rows[i].FindControl("SKU_Sequence")).Text;


                                string v = NameImage.Replace(@"\\192.168.1.172\Macintosh HD\ftp_share\RGAImages\", string.Empty);

                                WebClient wc = new WebClient();
                                wc.DownloadFile(NameImage,
                                    Server.MapPath(@"~\Themes\img\" + v));

                                //Byte[] data;///~/Themes/img
                                //using (WebClient client = new WebClient())
                                //{
                                //    //////cheminInstall.Text = System.Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\Storationer";
                                //    data = client.DownloadData(NameImage);
                                //    data = client.DownloadFile(NameImage, "");
                                //}

                                //Bitmap b = new Bitmap("name of the file");

                                //b.Save("path of the folder to save");

                                ////     Bitmap b = new Bitmap();

                                ///////  b.Save(@"C:\Extract\test.jpg");



                                //         File.WriteAllBytes(@"D:\images", data);
                                //string path=@"C:\Images\";
                                //          File.Copy(@"D:\images\"+NameImage, Server.MapPath("~/Themes/img"));
                                //          File.WriteAllBytes(Server.MapPath("~/Themes/img"), data);

                                //  DirectoryInfo dir = new DirectoryInfo(Server.MapPath("~/Themes/img"));
                                //    FileInfo[] file = dir.GetFiles();
                                //  ls.FilePath = @"\\192.168.1.172\Macintosh HD\ftp_share\RGAImages\" + f2.Name;
                                /// @"\\192.168.1.172\Macintosh HD\ftp_share\RGAImages\" +
                                //    foreach (FileInfo f2 in file)
                                //    {
                                fileps ls = new fileps();
                                ls.FilePath = @"~/Themes/img/" + v;
                                ls.FileName = NameImage;
                                ls.Name = v;
                                //   ((List<fileps>)Session["ImgList"]).Add(ls);

                                //////////  ExtensionMethods.Upload(@"\\192.168.1.172\Macintosh HD\ftp_share\RGAImages", "mediaserver", "kraus2013", "C:\\Images\\" + fileName.ToString(), bytes);
                                ///// ExtensionMethods.Upload(@"ftp://fileshare.kraususa.com", "rgauser", "rgaICG2014", "C:\\Images\\" + fileName.ToString(), bytes);
                                lstpath.Add(ls);
                                //           ResizeImage(800, Server.MapPath(ls.FilePath), Server.MapPath(ls.FilePath));
                                //    }
                            }
                            /////// Guid ImageID = _newRMA.SetReturnedImages(Guid.NewGuid(), ReturnDetailsID, NameImage, (Guid)Session["UserID"]);
                        }
                    }
                }
                //  DirectoryInfo dir = new DirectoryInfo(@"D:/images");
                //     FileInfo[] file = dir.GetFiles();
                //foreach (FileInfo f2 in file)
                //{
                //    fileps ls = new fileps();
                //  //  ls.FilePath = @"\\192.168.1.172\Macintosh HD\ftp_share\RGAImages\" + f2.Name;
                //    ls.FilePath = @"~/Themes/img/" + f2.Name;
                //    ls.FileName = @"D:/images/" + f2.Name;
                //    //// ExtensionMethods.Upload(@"\\192.168.1.172\Macintosh HD\ftp_share\RGAImages", "mediaserver", "kraus2013", "C:\\Images\\" + fileName.ToString(), bytes);
                //    //ExtensionMethods.Upload(@"ftp://fileshare.kraususa.com", "rgauser", "rgaICG2014", "C:\\Images\\" + fileName.ToString(), bytes);
                //    lstpath.Add(ls);
                //    //lstpath.Add(f2.Name);
                //    //Console.WriteLine(dir);

                //}
                //dtlstimage.DataSource = lstpath;
                //dtlstimage.DataBind();
                //     lstimg.DataSource = lstpath;
                //   lstimg.DataBind();
                GridView1.DataSource = lstpath;
                GridView1.DataBind();
                //  (List<fileps>)Session["rmacomment"] = lstpath;

                //DataTable dt = new DataTable();
                //dt.Columns.Add("compname");
                //dt.Columns.Add("news");
                //dt.Columns.Add("image");




                //DataTable dt1 = new DataTable();
                //dt1.Columns.Add("compname");
                //dt1.Columns.Add("lbl");



                //foreach (string ls in lstpath)
                //{
                //    for (int i = 0; i < lstpath.Count; i++)
                //    {
                //        DataRow dr13456 = dt1.NewRow();
                //        dr13456[0] = "ss";
                //        dr13456[1] = "D://images" + ls;
                //        dt1.Rows.Add(dr13456);
                //    }
                //}
                //foreach (string ls in lstpath)
                //{
                //    for (int i = 0; i < lstpath.Count; i++)
                //    {
                //        DataRow dr33 = dt.NewRow();
                //        dr33[0] = "ss";
                //        dr33[1] = "www2";
                //        dr33[2] = "NoImge";
                //        dt.Rows.Add(dr33);
                //    }
                //}

                //DataSet ds = new DataSet();
                //ds.Tables.Add(dt);

                //  DataSet ds1 = new DataSet();

                //ds.Tables.Add(dt1);
                //ds.Relations.Add("InnerVal", ds.Tables[0].Columns["compname"], ds.Tables[1].Columns["compname"]);   // making a relation between two tables.
                //GridView1.DataSource = ds;
                //GridView1.DataBind();
            }
            catch (Exception)
            {
            }

        }


    }
}
