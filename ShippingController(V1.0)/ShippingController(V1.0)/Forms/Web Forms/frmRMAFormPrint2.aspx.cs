using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using PackingClassLibrary.CustomEntity.SMEntitys.RGA;
using ShippingController_V1._0_.Models;
using PackingClassLibrary.Commands.SMcommands.RGA;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using PackingClassLibrary.CustomEntity.SMEntitys.RGA;
using ShippingController_V1._0_.Models;

namespace ShippingController_V1._0_.Forms.Web_Forms
{
    public partial class frmRMAFormPrint2 : System.Web.UI.Page
    {
        modelReaturnUpdate _Update = new modelReaturnUpdate();

        Models.modelReturn _newRMA = new Models.modelReturn();

        modelReasons rm = new modelReasons();
        modelReturn mf = new modelReturn();
        cmdReturn cmr = new cmdReturn();

        List<ReturnedSKUPoints> listofstatus = new List<ReturnedSKUPoints>();

        List<SKUReason> lsSKUReasons = new List<SKUReason>();

        
       // mupdatedForPonumber forgetdata = new mupdatedForPonumber();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
            if (!IsPostBack)
            {

                string rga;
                ///rga = Request.QueryString["RGAROWID"].ToString();
              //  rga = Session["RGA"].ToString();
              //  string[] arr = Views.Global.arr; //rga.Trim('(', ')').Split(',');
                /////
                string[] arr2 = (string[])Session["RGAROWIDPrint"];
                

                dos(arr2 , 2);
                
            }
        }


        public void dos(string[] na, int size)
        {


            foreach (string j in na)
            {
                Return retuen = Obj.Rcall.ReturnByRGAROWID(j)[0];


                this.Controls.Add(new LiteralControl("<form id='form1' runat='server'> "));



                this.Controls.Add(new LiteralControl("<table width='100%'> <tr> <td >"));
                this.Controls.Add(new LiteralControl("<h1> Kraus</h1> "));
                this.Controls.Add(new LiteralControl("</td><td>"));
                this.Controls.Add(new LiteralControl("<h3>RMA REQUEST FORM <h3>"));
                this.Controls.Add(new LiteralControl("</td></tr> </table>"));

                this.Controls.Add(new LiteralControl("<table width='100%'> <tr> <td bgcolor='#757575' height='1' >"));
                this.Controls.Add(new LiteralControl("<h8> <b>Instructions for Return:</h8> "));
                this.Controls.Add(new LiteralControl("</td><tr><td>"));
                //this.Controls.Add(new LiteralControl("<h3>RMA REQUEST FORM <h3>"));
                this.Controls.Add(new LiteralControl("</td></tr> </table>"));

                this.Controls.Add(new LiteralControl("<table width='100%'> <tr> <td ></td><td> 1.</td><td>"));
                this.Controls.Add(new LiteralControl(" Insert copy of original P.O and this form inside the return package. "));
                this.Controls.Add(new LiteralControl("</td></tr><tr><td></td><td>2.</td><td>"));
                this.Controls.Add(new LiteralControl("Please make sure that the RMA number is written on the outer portion of the box."));
                this.Controls.Add(new LiteralControl("</td></tr><tr><td></td><td>3.</td><td>"));
                this.Controls.Add(new LiteralControl("Ship return Package to Kraus USA,Inc.Return Department,12 Harbor Park Drive, Port Washington,NY 11050."));
                this.Controls.Add(new LiteralControl("</td></tr> </table>"));

                //RMA Detail 
                this.Controls.Add(new LiteralControl("<table width='100%'> <tr> <td bgcolor='#757575' height='1' >"));
                this.Controls.Add(new LiteralControl("<h8><b> RMA Details:</h8> "));
                this.Controls.Add(new LiteralControl("</td></tr>"));
                this.Controls.Add(new LiteralControl("</tr> </table>"));

                this.Controls.Add(new LiteralControl("<table width='100%'> <tr> <td > RMA Request Date: </td><td>" + retuen.ReturnDate + "</td>"));
                string rma = "";
                if (retuen.RMANumber != "")
                {
                    rma = retuen.RMANumber;
                }
                this.Controls.Add(new LiteralControl("<td> Vendor Name:</td><td>" + retuen.VendoeName + "</td></tr><tr><td> RMA#: </td><td>"+rma+"</td></tr></table>"));



                //RMA END


                //PO Detail
                this.Controls.Add(new LiteralControl("<table width='100%'> <tr> <td bgcolor='#757575' height='1' >"));
                this.Controls.Add(new LiteralControl("<h8><b> PO Details:</h8> "));
                this.Controls.Add(new LiteralControl("</td></tr>"));
                this.Controls.Add(new LiteralControl("</tr> </table>"));

                this.Controls.Add(new LiteralControl("<table width='100%'> <tr> <td > P.O. #: </td><td>" + retuen.PONumber + "</td></tr>"));

                this.Controls.Add(new LiteralControl("<tr><td>Name:</td><td>" + retuen.CustomerName1 + "</td></tr><tr><td>  Address: </td><td>" + retuen.Address1 + "</td></tr></table>"));


                //EnD PO Detail

                //DataTable
                this.Controls.Add(new LiteralControl("<table width='100%'> <tr> <td bgcolor='#757575' height='2' >"));
                this.Controls.Add(new LiteralControl("<h8> <b>Return Details:</h8> "));
                this.Controls.Add(new LiteralControl("</td></tr>"));
                this.Controls.Add(new LiteralControl("</tr> </table>"));
                DetailDatabase(j);

                //EnD
                this.Controls.Add(new LiteralControl("<table width='100%'> "));
                this.Controls.Add(new LiteralControl(" <tr> <td bgcolor='#757575' height='2' width='100%' > <h8><b>Note:</h8></td></tr><tr><td>"));
                this.Controls.Add(new LiteralControl("<h8> All returns items will be rejected if the requirements are not completed as requested.Items returned will be inspected.</h8> "));
                this.Controls.Add(new LiteralControl("<h8>If you have any further questions, comments, or concerns, please do not hesitate to let us know. We will be more than happy to assist you.</h8> "));
                this.Controls.Add(new LiteralControl("<h8>Thank you for choosing Kraus Products.</h8> "));
                this.Controls.Add(new LiteralControl("</td></tr> </table>"));
                this.Controls.Add(new LiteralControl("<P CLASS='pagebreakhere'>"));

                this.Controls.Add(new LiteralControl("</form  > "));

                this.Controls.Add(new LiteralControl("<script>window.print();</script>"));


                //TextBox box = new TextBox();
                //box.Text = "hiiiiiiiii";
                //this.Controls.Add(box);
                //this.Controls.Add(new LiteralControl("<p style='page-break-before: always'>"));
                //this.Controls.Add(new LiteralControl("</p>"));
                //this.Controls.Add(new LiteralControl("<h3>Value2:"));

                //this.Controls.Add(new LiteralControl("</h3>"));

                //Server.Execute("D:\\Sample Code Demos\\partner\\class_pdf\\html2pdf");



                //if (Script != string.Empty)
                //{
                //    pg.ClientScript.RegisterStartupScript(pg.GetType(), "PrintJavaScript", Script);
                //}
                //  HtmlForm frm = new HtmlForm();
                //  pg.Controls.Add(frm);
                //  frm.Attributes.Add("runat", "server");
                ////  frm.Controls.Add(ctrl);
                //  pg.DesignerInitialize();
                //  pg.RenderControl(htmlWrite);
                //  string strHTML = stringWrite.ToString();
                //  HttpContext.Current.Response.Clear();
                //  HttpContext.Current.Response.Write(strHTML);
                //  HttpContext.Current.Response.Write("<script>window.print();</script>");
                //  HttpContext.Current.Response.End();


            }
        }
            string Reason="";
            //public void  ReturnedReasons()
            //{
            //    string Reason1 = "";
            //    try
            //    {
            //        //string r;
                    
            //        listofstatus = Obj.Rcall.ReturnedSKUansPoints(Views.Global.ReteunGlobal.ReturnID);

            //        for (int i = 0; i < Views.Global.lsReturnDetail.Count; i++)
            //        {

            //            string SkuName = Views.Global.lsReturnDetail[i].SKUNumber;

            //            int SKUQtySequence = Views.Global.lsReturnDetail[i].SKU_Qty_Seq;




            //            for (int j = 0; j < listofstatus.Count; j++)
            //            {
            //                if (listofstatus[j].SKU == SkuName && listofstatus[j].SkuSequence == SKUQtySequence)
            //                {
            //                    if (listofstatus[j].Reason == "Item is New" && listofstatus[j].Reason_Value == "Yes")
            //                    {
            //                        Reason = Reason + "New" + ",";
            //                    }
            //                    else if (listofstatus[j].Reason == "Item is New" && listofstatus[j].Reason_Value == "No")
            //                    {
            //                        Reason = Reason + "Not New" + ",";
            //                    }
            //                    else if (listofstatus[j].Reason == "Installed" && listofstatus[j].Reason_Value == "Yes")
            //                    {
            //                        Reason = Reason + "Installed" + ",";
            //                    }
            //                    else if (listofstatus[j].Reason == "Installed" && listofstatus[j].Reason_Value == "No")
            //                    {
            //                        Reason = Reason + "Not Installed" + ",";
            //                    }
            //                    else if (listofstatus[j].Reason == "Chip/Bended/Scratch/Broken" && listofstatus[j].Reason_Value == "Yes")
            //                    {
            //                        Reason = Reason + "Chip/Bended/Scratch/Broken" + ",";
            //                    }
            //                    else if (listofstatus[j].Reason == "Chip/Bended/Scratch/Broken" && listofstatus[j].Reason_Value == "No")
            //                    {
            //                        Reason = Reason + "Not Chip/Bended/Scratch/Broken" + ",";
            //                    }
            //                    else if (listofstatus[j].Reason == "Manufacturer Defective" && listofstatus[j].Reason_Value == "Yes")
            //                    {
            //                        Reason = Reason + "Manufacturer Defective" + ",";
            //                    }
            //                    else if (listofstatus[j].Reason == "Manufacturer Defective" && listofstatus[j].Reason_Value == "No")
            //                    {
            //                        Reason = Reason + "Not Manufacturer Defective" + ",";
            //                    }
            //                    else if (listofstatus[j].Reason == "Defect in Transite" && listofstatus[j].Reason_Value == "Yes")
            //                    {
            //                        Reason = Reason + "Defect in Transite" + ",";
            //                    }
            //                    else if (listofstatus[j].Reason == "Defect in Transite" && listofstatus[j].Reason_Value == "No")
            //                    {
            //                        Reason = Reason + "Not Defect in Transite" + ",";
            //                    }
            //                }
            //            }
            //            Reason1 = Reason.TrimEnd(',');
            //            this.Controls.Add(new LiteralControl("<td>" + Reason1 + "</td>"));

            //            #region Forregion

            //            for (int k = 0; k < lsSKUReasons.Count; k++)
            //            {
            //                if (lsSKUReasons[k].ReturnDetailID==Views.Global.lsReturnDetail[i].ReturnDetailID)
            //                {
            //                    string reasonOriginal = Obj.Rcall.GetReasonsInStringByReturnDetailIDF(lsSKUReasons[k].ReturnDetailID);
            //                }


            //            }


            //            #endregion






            //        }
                    
            //    } 
                  
            //    catch (Exception)
            //    {

            //    }

            //   // List<ReturnDetail> retuen = Obj.Rcall.ReturnDetailByRGAROWID(Request.QueryString["RGAROWID"]);
            //    lsSKUReasons = Obj.Rcall.SKUReasonsByReturnDetails(Views.Global.lsReturnDetail);





                










               
            //}



        public void DetailDatabase(string jk)
        {
            ////For Status Following
            

            ///////END of Status

            //DataSet ds = rm.GetAllReasons();

           Session["lsReturnDetail"] = Obj.Rcall.ReturnDetailByRGAROWID(jk);

          //  Views.Global.lsReturnDetail = Obj.Rcall.ReturnDetailByRGAROWID(jk);
           // Return rn = Obj.Rcall.ReturnByRGADROWID(rga)[0];



           Session["ReteunGlobal"] = Obj.Rcall.ReturnByRGAROWID(jk)[0];

            listofstatus = Obj.Rcall.ReturnedSKUansPoints(((Return)Session["ReteunGlobal"]).ReturnID);

            lsSKUReasons = Obj.Rcall.SKUReasonsByReturnDetails((List<ReturnDetail>)Session["lsReturnDetail"]);


            DataTable dt = new DataTable();
            dt.Columns.Add("Reason1");
            dt.Columns.Add("ReasonID");
            dt.Columns.Add("ReasonPoints");
            //dt.Columns.Add("");


            DataTable dt2 = new DataTable();
            dt2.Columns.Add("third");



            foreach (var item in rm.GetAllReasons() )
            {
                
                DataRow dr = dt.NewRow();
                dr[0] = item.Reason1;
                dr[1] = item.ReasonID;
                dr[2] = item.ReasonPoints;
             
                dt.Rows.Add(dr);
            }
            foreach (var item in mf.GetReasons())
            {
                DataRow dr = dt2.NewRow();
                dr[0] = item.ReasonPoints;
                dt2.Rows.Add(dr);
            }
            ////////HTML Bind CODE/////

            if (dt.Rows.Count > 0)
            {
               
                



                this.Controls.Add(new LiteralControl("<table border='1' cellpadding='2'  WIDTH='75%'>"));

                this.Controls.Add(new LiteralControl("<tr><th>SKU</th><th>Quantity</th><th>Status</th><th>Reason</th>"));
                this.Controls.Add(new LiteralControl("</tr>"));

               
                    //this.Controls.Add(new LiteralControl("<tr>"));

                for (int i = 0; i < ((List<ReturnDetail>)Session["lsReturnDetail"]).Count; i++)
                    {
                        this.Controls.Add(new LiteralControl("<tr>"));
                        this.Controls.Add(new LiteralControl("<td>" + ((List<ReturnDetail>)Session["lsReturnDetail"])[i].SKUNumber + "</td>"));
                        this.Controls.Add(new LiteralControl("<td>" + ((List<ReturnDetail>)Session["lsReturnDetail"])[i].SKU_Qty_Seq + "</td>"));
                       // ReturnedReasons();

                        string SkuName = ((List<ReturnDetail>)Session["lsReturnDetail"])[i].SKUNumber;

                        int SKUSequence = ((List<ReturnDetail>)Session["lsReturnDetail"])[i].SKU_Sequence;


                       

                        for (int j = 0; j < listofstatus.Count; j++)
                        {
                            if (listofstatus[j].SKU == SkuName && listofstatus[j].SkuSequence == SKUSequence)
                            {
                                if (listofstatus[j].Reason == "Item is New" && listofstatus[j].Reason_Value == "Yes")
                                {
                                    Reason = Reason + "New" + ",";
                                }
                                else if (listofstatus[j].Reason == "Item is New" && listofstatus[j].Reason_Value == "No")
                                {
                                    Reason = Reason + "Not New" + ",";
                                }
                                else if (listofstatus[j].Reason == "Installed" && listofstatus[j].Reason_Value == "Yes")
                                {
                                    Reason = Reason + "Installed" + ",";
                                }
                                else if (listofstatus[j].Reason == "Installed" && listofstatus[j].Reason_Value == "No")
                                {
                                    Reason = Reason + "Not Installed" + ",";
                                }
                                else if (listofstatus[j].Reason == "Chip/Bended/Scratch/Broken" && listofstatus[j].Reason_Value == "Yes")
                                {
                                    Reason = Reason + "Chip/Bended/Scratch/Broken" + ",";
                                }
                                else if (listofstatus[j].Reason == "Chip/Bended/Scratch/Broken" && listofstatus[j].Reason_Value == "No")
                                {
                                    Reason = Reason + "Not Chip/Bended/Scratch/Broken" + ",";
                                }
                                else if (listofstatus[j].Reason == "Manufacturer Defective" && listofstatus[j].Reason_Value == "Yes")
                                {
                                    Reason = Reason + "Manufacturer Defective" + ",";
                                }
                                else if (listofstatus[j].Reason == "Manufacturer Defective" && listofstatus[j].Reason_Value == "No")
                                {
                                    Reason = Reason + "Not Manufacturer Defective" + ",";
                                }
                                else if (listofstatus[j].Reason == "Defect in Transite" && listofstatus[j].Reason_Value == "Yes")
                                {
                                    Reason = Reason + "Defect in Transite" + ",";
                                }
                                else if (listofstatus[j].Reason == "Defect in Transite" && listofstatus[j].Reason_Value == "No")
                                {
                                    Reason = Reason + "Not Defect in Transite" + ",";
                                }
                            }
                        }

                        string Reason1 = Reason.TrimEnd(',');
                        this.Controls.Add(new LiteralControl("<td>" + Reason1 + "</td>"));
                        Reason = "";
                        string reasonOriginal = "";
                        for (int k = 0; k < lsSKUReasons.Count; k++)
                        {
                            if (lsSKUReasons[k].ReturnDetailID == ((List<ReturnDetail>)Session["lsReturnDetail"])[i].ReturnDetailID)
                            {
                                 reasonOriginal = Obj.Rcall.GetReasonsInStringByReturnDetailIDF(lsSKUReasons[k].ReturnDetailID);
                            }
                        }

                        this.Controls.Add(new LiteralControl("<td>" + reasonOriginal + "</td>"));


                        Reason1 = "";
                        
                        this.Controls.Add(new LiteralControl("</tr>"));
                       // this.Controls.Add(new LiteralControl("<td>" + Views.Global.ReteunGlobal[i].ReturnReason + "</td>"));
                    }

                   
                   // 
                
                this.Controls.Add(new LiteralControl("</table>"));
                ////END
            }
        }
    }
}