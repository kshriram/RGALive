
using ShippingController_V1._0_.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Media;
using System.IO;
using ShippingController_V1._0_.Models;
using KeepAutomation.Barcode.Bean;
using PackingClassLibrary.CustomEntity.SMEntitys.RGA;

namespace ShippingController_V1._0_.Forms.Web_Forms
{
    public partial class frmSlipPrint : System.Web.UI.Page
    {
        BarCode barcode = new BarCode();
        List<ReturnedSKUPoints> listofstatus = new List<ReturnedSKUPoints>();
        //public UPCA upc = null;
        //BarcodeLib.Barcode b = new BarcodeLib.Barcode();

        //private void Page_PreInit(object sender, EventArgs e)
        //{
        //    string user = Session["UserID"].ToString().ToUpper();
        //    if (Session["UserID"].ToString().ToUpper() == "0DD3CB2D-33B6-431F-9DA0-042F9FF3963B")
        //    {
        //        this.MasterPageFile = "~/Forms/Master Forms/Admin.Master";
        //    }
        //    else
        //    {
        //        this.MasterPageFile = "~/Forms/Master Forms/TestUser.Master";
        //    }

        //}

      //  List<cSlipInfo> _lsInfoSlip = new List<cSlipInfo>();
        protected void Page_Load(object sender, EventArgs e)
        {
            //int i = 0;
            //foreach (var n in Global._lsSlipPrintSKUNumber)
            //{


            //C:\Users\Shiva3\Documents\GitHub\ShipmentComptroller\ShippingController(V1.0)\ShippingController(V1.0)\Themes\Images
            int k = 0;
       
            string imgurlPrd = "";
            string imgurl = "";
            //string imgurlPrd = "C://Users/Shiva3/Documents/GitHub/ShipmentComptroller/ShippingController(V1.0)/ShippingController(V1.0)/Themes/Images/barcodeProduct"+k+".png";

            //string imgurl = "C://Users/Shiva3/Documents/GitHub/ShipmentComptroller/ShippingController(V1.0)/ShippingController(V1.0)/Themes/Images/barcode" + k + ".png";

            for (k = 0; k < 5; k++)
            {
                // imgurlPrd = "C://Users/Shiva3/Documents/GitHub/ShipmentComptroller/ShippingController(V1.0)/ShippingController(V1.0)/Themes/Images/barcodeProduct"+k+".png";

                // imgurl = "C://Users/Shiva3/Documents/GitHub/ShipmentComptroller/ShippingController(V1.0)/ShippingController(V1.0)/Themes/Images/barcode" + k + ".png";
               // imgurl = @"D:\Shriram\RGA Phase-2\10th April 2015-1\ShipmentComptroller\ShippingController(V1.0)\ShippingController(V1.0)\Themes\Images\barcode" + k + ".png";
                //imgurlPrd = @"D:\Shriram\RGA Phase-2\10th April 2015-1\ShipmentComptroller\ShippingController(V1.0)\ShippingController(V1.0)\Themes\Images\barcodeProduct" + k + ".png";

                imgurlPrd = "C://inetpub/ShippingRGA/Themes/Images/barcodeProduct" + k + ".png";
                              
                imgurl = "C://inetpub/ShippingRGA/Themes/Images/barcode" + k + ".png";



               // imgurl = @"D:\Shriram\RGA Phase-2\10th April 2015-1\ShipmentComptroller\ShippingController(V1.0)\ShippingController(V1.0)\Themes\Images\barcode" + k + ".png";

                // imgurlPrd = @"D:\Shriram\RGA Phase-2\10th April 2015-1\ShipmentComptroller\ShippingController(V1.0)\ShippingController(V1.0)\Themes\Images\barcodeProduct" + k + ".png";

            
            FileInfo TheFile = new FileInfo(imgurl);
            if (TheFile.Exists)
            {
                File.Delete(imgurl);   // It not works if file is used in another process
            }
            FileInfo TheFile2 = new FileInfo(imgurlPrd);
            if (TheFile2.Exists)
            {
                File.Delete(imgurlPrd);   // It not works if file is used in another process
            }
            }
            k = 0;
                for (int i = 0; i < ((List<cSlipInfo>) Session["lsSlipInfo"]).Count; i++)
                {
                    k++;
                // _lsInfoSlip = Global.lsSlipInfo;


                   // imgurlPrd = "C://Users/Shiva3/Documents/GitHub/ShipmentComptroller/ShippingController(V1.0)/ShippingController(V1.0)/Themes/Images/barcodeProduct" + k + ".png";

                   // imgurl = "C://Users/Shiva3/Documents/GitHub/ShipmentComptroller/ShippingController(V1.0)/ShippingController(V1.0)/Themes/Images/barcode" + k + ".png";

                  //  imgurl = @"D:\Shriram\RGA Phase-2\10th April 2015-1\ShipmentComptroller\ShippingController(V1.0)\ShippingController(V1.0)\Themes\Images\barcode" + k + ".png";
                   // imgurlPrd = @"D:\Shriram\RGA Phase-2\10th April 2015-1\ShipmentComptroller\ShippingController(V1.0)\ShippingController(V1.0)\Themes\Images\barcodeProduct" + k + ".png";

                    imgurlPrd = "C://inetpub/ShippingRGA/Themes/Images/barcodeProduct" + k + ".png";

                    imgurl = "C://inetpub/ShippingRGA/Themes/Images/barcode" + k + ".png";

                  //  imgurl = @"D:\Shriram\RGA Phase-2\10th April 2015-1\ShipmentComptroller\ShippingController(V1.0)\ShippingController(V1.0)\Themes\Images\barcode" + k + ".png";

                   // imgurlPrd = @"D:\Shriram\RGA Phase-2\10th April 2015-1\ShipmentComptroller\ShippingController(V1.0)\ShippingController(V1.0)\Themes\Images\barcodeProduct" + k + ".png";


                    string SRnumber = ((List<cSlipInfo>)Session["lsSlipInfo"])[i].SRNumber;
                    string SKUName = ((List<cSlipInfo>)Session["lsSlipInfo"])[i].ProductName;

                //string SKUName = Global.lsSlipInfo[i].EANCode;
                    string productname = ((List<cSlipInfo>)Session["lsSlipInfo"])[i].EANCode;
                    DateTime ReceivedDate = ((List<cSlipInfo>)Session["lsSlipInfo"])[i].ReceivedDate;
                    DateTime Expiration = ((List<cSlipInfo>)Session["lsSlipInfo"])[0].Expiration;
                    string UserName = ((List<cSlipInfo>)Session["lsSlipInfo"])[0].ReceivedBY;

                string RMAStatusReal = "N/A";
                String RMAStatus = ((List<cSlipInfo>)Session["lsSlipInfo"])[0].RMAStatus;


                string ponumber = ((List<cSlipInfo>)Session["lsSlipInfo"])[0].PoNumber;

                Guid retundtlId = ((List<cSlipInfo>)Session["lsSlipInfo"])[i].ReturnDetailID;

                string listo = "";
                if (Session["FlagForPrint"].ToString() == "1")
                {
                    listofstatus = Obj.Rcall.ReturnedSKUansPoints((Guid)Session["ReturnFromID"]); // Session["ReturnFromID"]
                }
                else
                {
                    listofstatus = Obj.Rcall.ReturnedSKUansPoints(((Return)Session["ReteunGlobal"]).ReturnID);
                }
                //foreach (var item in listofstatus)
                //{
                //    if (retundtlId == item.ReturnDetailID)
                //    {
                //        listo = item.Reason + "-" + item.Reason_Value;
                //    }
                //}

                var list = from mm in listofstatus
                           where mm.ReturnDetailID == retundtlId
                           select new
                           {
                               mm.Reason,
                               mm.Reason_Value
                           };





                //((List<skuAndreturndetail>)Session["_lsSlipPrintSKUNumber2"])[i].ReturnID;
                string reasons = Obj.Rcall.GetReasonsInStringByReturnDetailIDF(retundtlId);

                if (RMAStatus == "0")
                {
                    RMAStatusReal = "Incomplete";
                }
                else if (RMAStatus == "1")
                {
                    RMAStatusReal = "Complete"; //"Rejected";
                }
                else if (RMAStatus == "2")
                {
                    RMAStatusReal = "Wrong RMA";//"Rejected";
                }

                string ItemStatus = ((List<cSlipInfo>)Session["lsSlipInfo"])[0].ItemStatus;

                string Reason = "N/A";

                if (((List<cSlipInfo>)Session["lsSlipInfo"])[0].Reason != "")
                    Reason = ((List<cSlipInfo>)Session["lsSlipInfo"])[0].Reason;

                ////var sBoxNumber = b.Encode(BarcodeLib.TYPE.CODE128, SRnumber, System.Drawing.Color.Black, System.Drawing.Color.Transparent, 1500, 550);
                // var sproductname = b.Encode(BarcodeLib.TYPE.UPCA, productname, System.Drawing.Color.Black, System.Drawing.Color.Transparent, 2000, 500);

                string txtTextToAdd = ((List<cSlipInfo>)Session["lsSlipInfo"])[i].EANCode;

                if (((List<cSlipInfo>)Session["lsSlipInfo"])[i].EANCode == "" || ((List<cSlipInfo>)Session["lsSlipInfo"])[i].EANCode == "N/A" || ((List<cSlipInfo>)Session["lsSlipInfo"])[i].EANCode == null)
                {
                    txtTextToAdd = "000000000000";
                    SKUName = "*[UPC Code Not Found] " + SKUName;
                }





                BarcodeUpca ua = new BarcodeUpca();

                if (txtTextToAdd != "" && txtTextToAdd != null)
                {
                    //this.txtTextToAdd.Text = this.txtTextToAdd.Text.Substring(0, 11) + upca.GetCheckSum(this.txtTextToAdd.Text).ToString();
                    //System.Drawing.Image img;
                    //img = upca.CreateBarCode(this.txtTextToAdd.Text, 3);

                    //this.image.Left = System.Convert.ToInt32((this.image.Width / 2) - (img.Width / 2));
                    ////Deepak 

                    txtTextToAdd = txtTextToAdd.Substring(0, 11) + ua.GetCheckSum(txtTextToAdd).ToString();
                    System.Drawing.Image img;
                    img = ua.CreateBarCode(txtTextToAdd, 3);
                   //// string tempPath = Path.GetTempFileName();

                    // string imgurlPrd ="D://barcodeProduct.png";
                    //  string imgurl ="D://barcode.png";
                  
                    //string imgurlPrd = "~/barcodeProduct.png";
                    ////(@"ftp://fileshare.kraususa.com
                    ///  string imgurl = @"ftp://fileshare.kraususa.com/barcode.png";
                    ///  

                    try
                    {
                       

                        img.Save(imgurlPrd);

                        ///  ExtensionMethods.Upload(@"ftp://fileshare.kraususa.com", "rgauser", "rgaICG2014", "D:\\barcodeProduct.png");


                        barcode.Symbology = KeepAutomation.Barcode.Symbology.UPCE;

                        // barcode.CodeToEncode = txtTextToAdd.Text;
                        barcode.ChecksumEnabled = true;
                        barcode.X = 1;
                        barcode.Y = 80;
                        barcode.BarCodeWidth = 180;
                        barcode.BarCodeHeight = 110;
                        barcode.Orientation = KeepAutomation.Barcode.Orientation.Degree0;
                        barcode.BarcodeUnit = KeepAutomation.Barcode.BarcodeUnit.Pixel;
                        barcode.DPI = 72;
                        barcode.ImageFormat = System.Drawing.Imaging.ImageFormat.Png;


                        ///   Image1.ImageUrl = "~/Themes/Images/barcode.png";
                   ///     Image1.ImageUrl = "~/Themes/Images/barcodeProduct.png";
                        if (ponumber != null && ponumber != "")
                        {
                            barcode.CodeToEncode = ponumber;
                        }

                        else
                        {
                            barcode.CodeToEncode = SRnumber;
                        }
                        barcode.Symbology = KeepAutomation.Barcode.Symbology.Code128A;
                        barcode.generateBarcodeToImageFile(imgurl);

                 ///       imgbarcode.ImageUrl = "~/Themes/Images/barcode.png";
                        // File.Delete(imgurl);  
                      ///  txtTextToAdd.Visible = false;
                      ///  
                        //////For print Dynamically
                        this.Controls.Add(new LiteralControl("<form id='form1' runat='server'>"));
                        this.Controls.Add(new LiteralControl("<html><body>"));
                        this.Controls.Add(new LiteralControl("<table width='100%' height='100' style='border: medium solid;'><tr><td style='width: 100%;'>"));

                        this.Controls.Add(new LiteralControl("<div id ='printdiv'><table style='width: -moz-max-content;height: 127px;'><tr><td height='10'><font size='2'>Received:</font></td><td><font size='2'>" + ReceivedDate.ToString("MMM dd, yyyy") + "</font></td><td height='10'><font size='2'>Recived By:</font ><font size='2'>" + UserName + "</font ></td><td height='10'><font size='2'>Expiration :</td><td><font size='2'>" + Expiration.ToString("MMM dd, yyyy") + "</font ></td></tr> "));
                        this.Controls.Add(new LiteralControl("<tr><td height='10'><font size='2'>Reason:</font><font size='2'>" + reasons + "</font></td>"));
                        this.Controls.Add(new LiteralControl("<td rowspan='8' colspan='4'><img src='../../Themes/Images/barcode" + k + ".png' alt='No Barcode'></td></tr>"));

                        //this.Controls.Add(new LiteralControl("<tr><td><font size='2'>Descion:</font><table>"));
                        string Reason1 = "";
                        string value = "";
                        foreach (var itm in list)
                        {
                            // reson += itm.Reason + "-" + itm.Reason_Value+";";

                            if (itm.Reason == "Item is New" && itm.Reason_Value == "Yes")
                            {
                                Reason1 = Reason1 + "New" + ",";
                            }
                            else if (itm.Reason == "Item is New" && itm.Reason_Value == "No")
                            {
                                Reason1 = Reason1 + "Not New" + ",";
                            }
                            else if (itm.Reason == "Installed" && itm.Reason_Value == "Yes")
                            {
                                Reason1 = Reason1 + "Installed" + ",";
                            }
                            else if (itm.Reason == "Installed" && itm.Reason_Value == "No")
                            {
                                Reason1 = Reason1 + "Not Installed" + ",";
                            }
                            else if (itm.Reason == "Chip/Bended/Scratch/Broken" && itm.Reason_Value == "Yes")
                            {
                                Reason1 = Reason1 + "Chip..-Yes" + "\n,";
                            }
                            else if (itm.Reason == "Chip/Bended/Scratch/Broken" && itm.Reason_Value == "No")
                            {
                                Reason1 = Reason1 + "Not Chip.." + "\n,";
                            }
                            else if (itm.Reason == "Manufacturer Defective" && itm.Reason_Value == "Yes")
                            {
                                Reason1 = Reason1 + "Mfg. Def." + ",";
                            }
                            else if (itm.Reason == "Manufacturer Defective" && itm.Reason_Value == "No")
                            {
                                Reason1 = Reason1 + "Not Mfg. Def." + ",";
                            }
                            else if (itm.Reason == "Defect in Transit" && itm.Reason_Value == "Yes")
                            {
                                Reason1 = Reason1 + "Defect in Transite" + ",";
                            }
                            else if (itm.Reason == "Defect in Transit" && itm.Reason_Value == "No")
                            {
                                Reason1 = Reason1 + "Not-Defect in Transite" + ",";
                            }

                        }
                        // this.Controls.Add(new LiteralControl("<tr><td><font size='2'>" + reson + "</font ></td></tr>"));

                        this.Controls.Add(new LiteralControl("<tr><td><font size='2'>" + SRnumber + "</font ></td><td></td></tr><tr><td><font size='2'>" + SKUName + "</font ></td><td></td></tr>"));
                        this.Controls.Add(new LiteralControl("<tr><td></td></tr>"));
                        this.Controls.Add(new LiteralControl("<tr><td></td></tr>"));
                        this.Controls.Add(new LiteralControl("</table>"));
                        this.Controls.Add(new LiteralControl("</td></tr><tr><td><font size='2'>Decision:</font ><font size='2'>" + Reason1 + "</font ></td></tr>"));
                        //this.Controls.Add(new LiteralControl("<div id ='barcoderga'><table><tr><td><font size='5'>" + SRnumber + "</font ></td></tr></table></div>"));
                        this.Controls.Add(new LiteralControl("<tr><td height='30'>"));
                        this.Controls.Add(new LiteralControl("<div id ='barcodeSKU'><table><tr><td><img src='../../Themes/Images/barcodeProduct" + k + ".png' alt='No Barcode'  style='width: 288px; height: 55px; margin-bottom: -8px; margin-top: -7px;'></td></tr></table></div>"));
                        this.Controls.Add(new LiteralControl("</font></td></tr></table>"));


                        // this.Controls.Add(new LiteralControl(" printWindow.document.write('</body></html>'); printWindow.document.close(); setTimeout(function () { printWindow.print(); }, 500); return false; }</script>"));
                        this.Controls.Add(new LiteralControl("</body></html>"));

                        this.Controls.Add(new LiteralControl("<P CLASS='pagebreakhere'>"));

                        this.Controls.Add(new LiteralControl("</form>"));
                        /////end
                        /////end


                        //txtExpiration.Text = Expiration.ToString("MMM dd, yyyy");
                //txtReceivedDate.Text = ReceivedDate.ToString("MMM dd, yyyy");
                //txtReceived.Text = UserName;
                //txtReason.Text = Reason;
                //txtSRNumber.Text = SRnumber;
                //txtproductName.Text = SKUName;
                //txtRMAStatus.Text = RMAStatusReal;
                //txtItemStatus.Text = ItemStatus;



                    }
                    catch (Exception)
                    {
                    }



                    ///End

                    //   var newimag = Imaging.CreateBitmapSourceFromHBitmap(imges.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                    //  var newimag = System.Windows.intrptr.Imaging.CreateBitmapSourceFromHBitmap(imges.GetHbitmap(), IntPtr.Zero, System.Windows.Int32Rect.Empty, System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());

                    ///  Image1.ImageUrl = newimag;

                    //this.pctBarCode.Image = img;
                    //this.txtTextToAdd.SelectAll();
                }
                else
                {
                   //// this.imgbarcode.ImageUrl = null;
                }

                ///// var bitmapBox = new System.Drawing.Bitmap(sBoxNumber);
                //   var pbitmapBox = new System.Drawing.Bitmap(sproductname);

                ///////  var bBoxSource = Imaging.CreateBitmapSourceFromHBitmap(bitmapBox.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                // var pproduct = Imaging.CreateBitmapSourceFromHBitmap(pbitmapBox.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

                ///   bitmapBox.Dispose();

                //   imgbarcode.ImageUrl = bBoxSource;
                //  image.Source = pproduct;

                //txtExpiration.Text = Expiration.ToString("MMM dd, yyyy");
                //txtReceivedDate.Text = ReceivedDate.ToString("MMM dd, yyyy");
                //txtReceived.Text = UserName;
                //txtReason.Text = Reason;
                //txtSRNumber.Text = SRnumber;
                //txtproductName.Text = SKUName;
                //txtRMAStatus.Text = RMAStatusReal;
                //txtItemStatus.Text = ItemStatus;

            //}
              
                
                    //this.Controls.Add(new LiteralControl("<script type = 'text/javascript'> function PrintPanel() {var div = document.getElementById('<%=prntdiv.ClientID %>'); var printWindow = window.open('', '', 'height=400,width=800'); printWindow.document.write('<html><head><title>DIV Contents</title>') printWindow.document.write('</head><body >') printWindow.document.write("));


                //}

            }
        }
    }
}