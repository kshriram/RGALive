using PackingClassLibrary.CustomEntity.SMEntitys.RGA;
using ShippingController_V1._0_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PackingClassLibrary;
using System.IO;
using System.Data;
using System.Threading;

namespace ShippingController_V1._0_.Forms.Web_Forms
{
    public partial class frmRetunDetail : System.Web.UI.Page
    {
        #region Declaration

        string ImagesName;
        //Create object of modelReturn.
        modelReturn _mReturn = new modelReturn();

        #endregion

        //On Page_Load Event call FillReturnMasterGridView and ImageHide methods.
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillReturnMasterGv(Obj.Rcall.ReturnAll());

                ImagesHide();
            }
        }

        #region Functions

        public void SetScrooToTop()
        {
            //Run the Javascript from code;
            Page.ClientScript.RegisterStartupScript(GetType(), "MyScript", "javascript:ResetScrollToTop();", true);

        }

        /// <summary>
        /// Fill ReturnMaster Grid By passing ReturnList.
        /// </summary>
        /// <param name="lsReturn">
        /// Return List pass as parameter.
        /// </param>
        public void FillReturnMasterGv(List<Return> lsReturn)
        {

            Obj._lsreturn = lsReturn;

            gvReturnInfo.DataSource = lsReturn.OrderByDescending(i => i.UpdatedDate).ToList();
            gvReturnInfo.DataBind();

            foreach (GridViewRow row in gvReturnInfo.Rows)
            {
                int Value = Convert.ToInt32(row.Cells[7].Text);
                row.Cells[7].Text = _mReturn.ConvertToStatus(Value);
                if (Value == 0) row.Cells[7].ForeColor = System.Drawing.Color.DarkGreen;

                else if (Value == 3) row.Cells[7].ForeColor = System.Drawing.Color.DarkRed;
                int Value1 = Convert.ToInt32(row.Cells[8].Text);
                if (Value1 == 0) row.Cells[8].ForeColor = System.Drawing.Color.Green;

                else if (Value1 == 3) row.Cells[8].ForeColor = System.Drawing.Color.DarkRed;
                row.Cells[8].Text = _mReturn.ConvertToDecision(Value1);


                //int flag = Convert.ToInt32(row.Cells[3].Text);
                //row.Cells[3].Text = _mReturn.ConvertToFlag(flag);

                //if (flag == 1) row.BackColor = System.Drawing.Color.SkyBlue;

                string ToProcessFlag = (row.FindControl("lblToProcess") as Label).Text;
                if (ToProcessFlag == "1")
                {
                    row.BackColor = System.Drawing.Color.SkyBlue;
                }
                else
                {
                    (row.FindControl("imgFlag") as Image).Visible = false;
                }


                //int flag2 = Convert.ToInt32(row.Cells[4].Text);
                //row.Cells[4].Text = _mReturn.ConvertToFlag(flag2);

                //if (flag2 == 1) row.BackColor = System.Drawing.Color.SkyBlue;


                if (row.Cells[14].Text == "&nbsp;")
                {
                    row.Cells[14].Text = "";
                }
                else
                {
                    Guid UserID = Guid.Parse(row.Cells[14].Text);
                    row.Cells[14].Text = _mReturn.UserName(UserID);
                }

            }

            //if (IsPostBack)
            //{
            //    FillReturnDetails(_mReturn.ReturnAllRowsfromReturnTbl(lsReturn));
            //}
        }

        /// <summary>
        /// This Method is for FillReturnDetails GridView.
        /// </summary>
        /// <param name="lsReturnDetails">
        /// list ReturnDetail pass as parameter.
        /// </param>
        public void FillReturnDetails(List<ReturnDetail> lsReturnDetails)
        {
            try
            {
                Obj._lsReturnDetails = lsReturnDetails;
                var ReaturnDetails = from Rs in lsReturnDetails
                                     select new
                                     {
                                         Rs.RGADROWID,
                                         Rs.SKUNumber,
                                         Rs.ProductName,
                                         Rs.DeliveredQty,
                                         Rs.ReturnQty,
                                         ReturnReasons = Obj.Rcall.ReasonsListByReturnDetails(Rs.ReturnDetailID)
                                     };

                gvReturnDetails.DataSource = ReaturnDetails.ToList();
                gvReturnDetails.DataBind();

                gvReturnDetails_SelectedIndexChanged(null, EventArgs.Empty);
            }
            catch (Exception)
            { }
        }


        /// <summary>
        /// Reset All Controls
        /// </summary>
        public void ResetAll()
        {
            txtCustomerName.Text = "";
            txtOrderNumber.Text = "";
            txtPoNum.Text = "";
            txtRMANumber.Text = "";
            txtShipmentID.Text = "";
            txtVendorName.Text = "";
            txtVendorNumber.Text = "";
            FillReturnMasterGv(Obj.Rcall.ReturnAll());
            dtpFromDate.Text = "";
            dtpToDate.Text = "";
            ImagesHide();

        }

        /// <summary>
        /// Hide All Images
        /// </summary>
        public void ImagesHide()
        {
            lblImagesFor.Text = "";
            Img0.Visible = false;
            Img2.Visible = false;
            Img3.Visible = false;
            Img4.Visible = false;
            Img1.Visible = false;
            Img5.Visible = false;
            Img6.Visible = false;
            Img7.Visible = false;
            Img8.Visible = false;
            Img9.Visible = false;
            Img10.Visible = false;
        }
        #endregion

        //Button Export Click RGA in Excel Format.
        protected void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                modelExportTo.RGAExcel(Obj._lsreturn);
            }
            catch (Exception)
            { }
        }

        //txtRMAnumber_TextChanged Fill ReturnMaster GridView By passing RMANumber.
        protected void txtRMANumber_TextChanged(object sender, EventArgs e)
        {
            if (txtRMANumber.Text.Trim() != "")
            {
                var RMA = from returnALL in Obj.Rcall.ReturnAll()
                          where returnALL.RMANumber == txtRMANumber.Text
                          select returnALL;

                FillReturnMasterGv(RMA.ToList());
                SetScrooToTop();
            }
        }
        //txtShipmentID_TextChanged Fill ReturnMaster GridView By passing ShipmentID.
        protected void txtShipmentID_TextChanged(object sender, EventArgs e)
        {
            if (txtShipmentID.Text.Trim() != "")
            {
                var ShipID = from returnAll in Obj.Rcall.ReturnAll()
                             where returnAll.ShipmentNumber == txtShipmentID.Text
                             select returnAll;

                FillReturnMasterGv(ShipID.ToList());
                SetScrooToTop();
            }
        }
        //txtOrderNumber_TextChanged Fill ReturnMaster GridView By passing OrderNumber.
        protected void txtOrderNumber_TextChanged(object sender, EventArgs e)
        {
            if (txtOrderNumber.Text.Trim() != "")
            {
                var OrderNum = from all in Obj.Rcall.ReturnAll()
                               where all.OrderNumber == txtOrderNumber.Text
                               select all;

                FillReturnMasterGv(OrderNum.ToList());
                SetScrooToTop();
            }
        }
        //txtPoNum_TextChanged Fill ReturnMaster GridView By passing PONumber.
        protected void txtPoNum_TextChanged(object sender, EventArgs e)
        {
            if (txtPoNum.Text.Trim() != "")
            {
                var PONum = from all in Obj.Rcall.ReturnAll()
                            where all.PONumber == txtPoNum.Text
                            select all;

                FillReturnMasterGv(PONum.ToList());
                SetScrooToTop();
            }
        }
        //pass value of gridview to the FillReturnDetails function and FillGrid.
        protected void gvReturnInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FillReturnDetails(Obj.Rcall.ReturnDetailByRGAROWID(_mReturn.linkButtonText("lbtnRGANumberID", gvReturnInfo)));
            }
            catch (Exception)
            { }
        }
        //gvReturnDetails_SelectedIndexChanged event display images By returnDetailID 
        protected void gvReturnDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ImagesHide();
                string ReturnROWID = _mReturn.linkButtonText("lbtnRmaDetailNumberID", gvReturnDetails);
                lblImagesFor.Text = "Sorry! Images for GRA Detail Number : " + ReturnROWID + " not found!";
                List<string> lsImages2 = Obj.Rcall.ReturnImagesByReturnDetailsID(Obj.Rcall.ReturnDetailByRGADROWID(ReturnROWID)[0].ReturnDetailID);
                List<String> lsImages = new List<string>();
                String ImgServerString = System.Configuration.ConfigurationManager.AppSettings["ImageServerPath"].ToString();

                foreach (var Imaitem in lsImages2)
                {
                    //lsImages.Add("~/images/"+Imaitem.Split(new char[] { '\\' }).Last().ToString());
                    lsImages.Add(ImgServerString.Replace("#{ImageName}#", Imaitem.Split(new char[] { '\\' }).Last().ToString()));
                }
                if (lsImages.Count > 0)
                {
                    lblImagesFor.Text = "Images for GRA Detail Number : " + ReturnROWID;
                    for (int j = 0; j < lsImages.Count(); j++)
                    {
                        if (j == 0)
                        {
                            Img0.Visible = true;
                            Img0.Src = lsImages[j];
                            ImagesName = lsImages[j];
                        }
                        if (j == 1)
                        {
                            Img1.Visible = true;
                            Img1.Src = lsImages[j];
                        }
                        if (j == 2)
                        {
                            Img2.Visible = true;
                            Img2.Src = lsImages[j];
                        }
                        if (j == 3)
                        {
                            Img3.Visible = true;
                            Img3.Src = lsImages[j];
                        }
                        if (j == 4)
                        {
                            Img4.Visible = true;
                            Img4.Src = lsImages[j];
                        }
                        if (j == 5)
                        {
                            Img5.Visible = true;
                            Img5.Src = lsImages[j];
                        }
                        if (j == 6)
                        {
                            Img6.Visible = true;
                            Img6.Src = lsImages[j];
                        }
                        if (j == 7)
                        {
                            Img7.Visible = true;
                            Img7.Src = lsImages[j];
                        }
                        if (j == 8)
                        {
                            Img8.Visible = true;
                            Img8.Src = lsImages[j];
                        }
                        if (j == 9)
                        {
                            Img9.Visible = true;
                            Img9.Src = lsImages[j];
                        }
                        if (j == 10)
                        {
                            Img10.Visible = true;
                            Img10.Src = lsImages[j];
                        }
                    }
                }


            }
            catch (Exception)
            { }
        }

        protected void btnRefresh2_Click(object sender, EventArgs e)
        {
            ResetAll();
        }
       
        //Text Suggest for CustomerName and call FillReturnMaster method for fill GridView by CustomerList.
        protected void txtCustomerName_TextChanged(object sender, EventArgs e)
        {
            if (txtCustomerName.Text.Trim() != "")
            {
                List<Return> LsCustomers = new List<Return>();
                foreach (var item in Obj._lsreturn)
                {
                    if (item.CustomerName1.Contains(txtCustomerName.Text))
                    {
                        LsCustomers.Add(item);
                    }
                }
                FillReturnMasterGv(LsCustomers.ToList());
                SetScrooToTop();
            }
        }
        //Text Suggest for vendorName and Call FillReturnMaster Method for Fill Gridview by Vendor name.
        protected void txtVendorName_TextChanged(object sender, EventArgs e)
        {
            if (txtVendorName.Text.Trim() != "")
            {
                List<Return> LsVendor = new List<Return>();
                foreach (var item in Obj._lsreturn)
                {
                    if (item.VendoeName.Contains(txtVendorName.Text))
                    {
                        LsVendor.Add(item);
                    }
                }
                FillReturnMasterGv(LsVendor.ToList());
                SetScrooToTop();
            }
        }

        protected void dtpToDate_TextChanged(object sender, EventArgs e)
        {
            if (dtpToDate.Text.Trim() != "" && dtpFromDate.Text.Trim() != "")
            {
                DateTime Fdate;
                DateTime TDate;
                DateTime.TryParse(dtpFromDate.Text, out Fdate);
                DateTime.TryParse(dtpToDate.Text, out TDate);

                var fromTo = from ls in Obj._lsreturn
                             where ls.ReturnDate.Date >= Fdate.Date && ls.ReturnDate <= TDate.Date
                             select ls;
                FillReturnMasterGv(fromTo.ToList());
                SetScrooToTop();
            }
        }
        //Text Suggest for vendorNumber and Call FillReturnMaster Method for Fill Gridview by Vendor Number.
        protected void txtVendorNumber_TextChanged(object sender, EventArgs e)
        {
            if (txtVendorNumber.Text.Trim() != "")
            {
                List<Return> LsVendorNUm = new List<Return>();
                foreach (var item in Obj._lsreturn)
                {
                    if (item.VendorNumber.Contains(txtVendorNumber.Text))
                    {
                        LsVendorNUm.Add(item);
                    }
                }
                FillReturnMasterGv(LsVendorNUm.ToList());
                SetScrooToTop();
            }

        }

        #region Sorting
        public SortDirection GridViewSortDirection
        {
            get
            {
                if (ViewState["sortDirection"] == null)
                    ViewState["sortDirection"] = SortDirection.Ascending;

                return (SortDirection)ViewState["sortDirection"];
            }
            set { ViewState["sortDirection"] = value; }
        }

        protected void gvReturnInfo_Sorting(object sender, GridViewSortEventArgs e)
        {
            // FillReturnMasterGv(_mReturn.SortedListOFReturn(e.SortExpression.ToString()));


            List<Return> lsReturn;
            lsReturn = Obj.Rcall.ReturnAll();
            gvReturnInfo.DataSource = lsReturn.OrderByDescending(i => i.UpdatedDate).ToList();
            gvReturnInfo.DataBind();

            if (lsReturn != null)
            {
                var param = Expression.Parameter(typeof(Return), e.SortExpression);
                var sortExpression = Expression.Lambda<Func<Return, object>>(Expression.Convert(Expression.Property(param, e.SortExpression), typeof(object)), param);


                if (GridViewSortDirection == SortDirection.Ascending)
                {
                    gvReturnInfo.DataSource = lsReturn.AsQueryable<Return>().OrderBy(sortExpression).ToList();
                    GridViewSortDirection = SortDirection.Descending;
                }
                else
                {
                    gvReturnInfo.DataSource = lsReturn.AsQueryable<Return>().OrderByDescending(sortExpression).ToList();
                    GridViewSortDirection = SortDirection.Ascending;
                };


                gvReturnInfo.DataBind();

                foreach (GridViewRow row in gvReturnInfo.Rows)
                {
                    int Value = Convert.ToInt32(row.Cells[7].Text);
                    row.Cells[7].Text = _mReturn.ConvertToStatus(Value);
                    if (Value == 0) row.Cells[7].ForeColor = System.Drawing.Color.DarkGreen;

                    else if (Value == 3) row.Cells[7].ForeColor = System.Drawing.Color.DarkRed;
                    int Value1 = Convert.ToInt32(row.Cells[8].Text);
                    if (Value1 == 0) row.Cells[8].ForeColor = System.Drawing.Color.Green;

                    else if (Value1 == 3) row.Cells[8].ForeColor = System.Drawing.Color.DarkRed;
                    row.Cells[8].Text = _mReturn.ConvertToDecision(Value1);


                    //int flag = Convert.ToInt32(row.Cells[3].Text);
                    //row.Cells[3].Text = _mReturn.ConvertToFlag(flag);

                    //if (flag == 1) row.BackColor = System.Drawing.Color.SkyBlue;

                    string ToProcessFlag = (row.FindControl("lblToProcess") as Label).Text;
                    if (ToProcessFlag == "1")
                    {
                        row.BackColor = System.Drawing.Color.SkyBlue;
                    }
                    else
                    {
                        (row.FindControl("imgFlag") as Image).Visible = false;
                    }


                    //int flag2 = Convert.ToInt32(row.Cells[4].Text);
                    //row.Cells[4].Text = _mReturn.ConvertToFlag(flag2);

                    //if (flag2 == 1) row.BackColor = System.Drawing.Color.SkyBlue;


                    if (row.Cells[14].Text == "&nbsp;")
                    {
                        row.Cells[14].Text = "";
                    }
                    else
                    {
                        Guid UserID = Guid.Parse(row.Cells[14].Text);
                        row.Cells[14].Text = _mReturn.UserName(UserID);
                    }

                }
            }

        }
        #endregion

        protected void gvReturnDetails_Sorting(object sender, GridViewSortEventArgs e)
        {
            ImagesHide();
            FillReturnDetails(_mReturn.SortedListOfReturnDetails(e.SortExpression.ToString()));
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            String RowId = (((GridViewRow)((LinkButton)sender).Parent.Parent).Cells[0].FindControl("lbtnRGANumberID") as LinkButton).Text;
            Response.Redirect("~/Forms/Web Forms/frmReturnEdit.aspx?RGAROWID=" + RowId);
        }
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            //String RowId = (((GridViewRow)((LinkButton)sender).Parent.Parent).Cells[0].FindControl("lbtnRGANumberID") as LinkButton).Text;
            //Response.Redirect("~/Forms/Web Forms/frmRMAFormPrint2.aspx?RGAROWID=" + RowId);

            //string RgaNo = (gvReturnInfo.Rows[i - 1].FindControl("lbtnRGANumberID") as LinkButton).Text;

            //myList.Add(RgaNo);
            var myList = new List<string>();
            string[] arr = { };
             int i = 0;
             String RowId = (((GridViewRow)((LinkButton)sender).Parent.Parent).Cells[0].FindControl("lbtnRGANumberID") as LinkButton).Text;

             myList.Add(RowId);


            // Views.Global.arr = myList.ToArray();
             
             Response.Redirect("~/Forms/Web Forms/frmRMAFormPrint2.aspx");
        }
        protected void gvReturnInfo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowIndex == 0)
                {
                    e.Row.Style.Add("vertical-align", "bottom");
                    e.Row.Style.Add("height", "70px");
                }
            }
        }

        protected void gvReturnDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowIndex == 0)
                {
                    e.Row.Style.Add("vertical-align", "bottom");
                    e.Row.Style.Add("height", "70px");
                }

            }
        }

        //protected void chkprint_CheckedChanged(object sender, EventArgs e)
        //{

        //}

        protected void btnPrint_Click1(object sender, EventArgs e)
        {
            try
            {
                var myList = new List<string>();
                string[] arr = { };
                //ArrayList arr = new ArrayList();
                int i = 0;
                foreach (GridViewRow row in gvReturnInfo.Rows)
                {
                    i++;
                    
                    CheckBox chkRow = (row.Cells[0].FindControl("chkprint") as CheckBox);
                    if (chkRow.Checked)
                    {
                        //String RgaNo = gvReturnInfo.Cells[1].FindControl("lbtnRGANumberID").ToString();

                        string RgaNo = (gvReturnInfo.Rows[i-1].FindControl("lbtnRGANumberID") as LinkButton ).Text;

                        myList.Add(RgaNo);
                        

                       // Views.Global.arr = myList.ToArray();
                    }
                }
               /// Session["RGA"] = arr;
                Response.Redirect("~/Forms/Web Forms/frmRMAFormPrint2.aspx");
            }
            catch (Exception)
            {
            }
        }

        protected void gvReturnInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
           
            gvReturnInfo.PageIndex = e.NewPageIndex;
      

            FillReturnMasterGv(Obj.Rcall.ReturnAll());

        }

    }                                                                                                                                                                                                                                                                                                                                                                                           
}