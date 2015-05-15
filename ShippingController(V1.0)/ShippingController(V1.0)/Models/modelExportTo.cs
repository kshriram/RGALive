using PackingClassLibrary.CustomEntity;
using PackingClassLibrary.CustomEntity.SMEntitys;
using PackingClassLibrary.CustomEntity.SMEntitys.RGA;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShippingController_V1._0_.Models
{
    public class modelExportTo 
    {
         /// <summary>
        /// Export all data to excel file.
        /// </summary>
        /// <param name="ds">Dataset table to be export</param>
        /// <param name="filename"> File name of excel.</param>
        public static void Excel(List<String> lsPCKROWID, string filename)
        {
            List<string> Boxnumbers = new List<string>();

            foreach (var item in lsPCKROWID)
            {
                List<cstBoxPackage> lsBoxInfo = Obj.call.GetBoxPackageByPackingID(Obj.call.GetPackageIDFromROWID(item));
                foreach (cstBoxPackage boxitem in lsBoxInfo)
                {
                    Boxnumbers.Add(boxitem.BOXNUM);
                }
            }
            

            //Find Box information from the Box Numbers
            List<BoxManifist> _lsBoxManifist = new List<BoxManifist>();
            foreach (string item in Boxnumbers)
            {

                //Box Information
                cstBoxPackage _boxInfo = Obj.call.GetBoxPackageByBoxNumber(item);

                //Package Information
                cstPackageTbl packing = Obj.call.GetPackingList(_boxInfo.PackingID, true);

                BoxManifist manifist = new BoxManifist();
                manifist.BoxNumber = _boxInfo.BOXNUM;
                manifist.PackingNumber = packing.PCKROWID;
                manifist.ShippingNumber = packing.ShippingNum;
                try
                {
                    manifist.TrackingNumber = Obj.call.GetTrackingTbl(item).FirstOrDefault().TrackingNum.ToString();
                }
                catch (Exception)
                {
                    manifist.TrackingNumber = "N/A";
                }
                
                manifist.Location = packing.ShipmentLocation;
                manifist.Weight = _boxInfo.BoxWeight.ToString();
                manifist.Width = _boxInfo.BoxWidth.ToString();
                manifist.Lenght = _boxInfo.BoxHeight.ToString();
                manifist.Height = _boxInfo.BoxHeight.ToString();
                manifist.UserName = Obj.call.GetSelcetedUserMaster(packing.UserID).FirstOrDefault().UserFullName;

                //Convet UTC time to EST Time.
                TimeZoneInfo EstTime = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
                manifist.PackedDate = TimeZoneInfo.ConvertTimeFromUtc(packing.EndTime,EstTime).ToString("MMM dd, yyyy hh:mm:ss tt");

                _lsBoxManifist.Add(manifist);

            }



            HttpResponse response = HttpContext.Current.Response;

            // first let's clean up the response.object
            response.Clear();
            response.Charset = "";

            // set the response mime type for excel
            response.ContentType = "application/vnd.MS-Excel";
            response.AddHeader("Content-Disposition", "attachment;filename=\"" + filename + ".xls\"");

            // create a string writer
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                {
                    // instantiate a datagrid
                    DataGrid dg = new DataGrid();
                    dg.DataSource = _lsBoxManifist;
                    dg.DataBind();
                    dg.RenderControl(htw);
                    response.Write(sw.ToString());
                    response.End();
                }
            }
        }


        public static void RGAExcel(List<Return> lsReturn)
        {
            //Convet UTC time to EST Time.
                TimeZoneInfo EstTime = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
             
            var ReturnDetais = from rm in lsReturn
                               join Rd in Obj.Rcall.ReturnDetailAll()
                               on rm.ReturnID equals Rd.ReturnID
                               select new
                               {
                                   rm.ReturnDate,
                                   rm.RGAROWID,
                                   rm.RMANumber,
                                   rm.RMAStatus,
                                   rm.Decision,
                                   rm.DeliveryDate,
                                   rm.CustomerName1,
                                   rm.CustomerName2,
                                   rm.VendorNumber,
                                   rm.VendoeName,
                                   rm.PONumber,
                                   rm.ShipmentNumber
                                  
                               };


            //Find Box information from the Box Numbers
            List<RGAManifist> _lsRGAManifist = new List<RGAManifist>();
            foreach (var _RGAitem in ReturnDetais)
            {
                RGAManifist RgaManifist = new RGAManifist();
                RgaManifist.RGA_Number = _RGAitem.RGAROWID;
                RgaManifist.RMA_Number = _RGAitem.RMANumber;
                RgaManifist.CustomerAddress1 = _RGAitem.CustomerName1;
                RgaManifist.CustomerAddress2 = _RGAitem.CustomerName2;
                RgaManifist.Delivery_Date = TimeZoneInfo.ConvertTimeFromUtc(_RGAitem.DeliveryDate,EstTime).ToString("MMM dd, yyyy hh:mm:ss tt");
                RgaManifist.Return_Date = TimeZoneInfo.ConvertTimeFromUtc(_RGAitem.ReturnDate, EstTime).ToString("MMM dd, yyyy hh:mm:ss tt");
                RgaManifist.Vendor_Number = _RGAitem.VendorNumber;
                RgaManifist.Vendor_Name = _RGAitem.VendoeName;
                RgaManifist.PO_Number = _RGAitem.PONumber;
                RgaManifist.Shipping_Number = _RGAitem.ShipmentNumber;
                if (_RGAitem.RMAStatus==0)
                {
                    RgaManifist.RMA_Satus = "New";
                }
                else if (_RGAitem.RMAStatus == 1)
                {
                    RgaManifist.RMA_Satus = "Approved";
                }
                else if (_RGAitem.RMAStatus == 2)
                {
                    RgaManifist.RMA_Satus = "Pending";
                }
                else if (_RGAitem.RMAStatus==3)
                {
                    RgaManifist.RMA_Satus = "Canceled";
                }
                if (_RGAitem.Decision == 0)
                {
                    RgaManifist.RMA_Decision = "New";
                }
                else if (_RGAitem.Decision == 1)
                {
                    RgaManifist.RMA_Decision = "Approved";
                }
                else if (_RGAitem.Decision == 2)
                {
                    RgaManifist.RMA_Decision = "Pending";
                }
                else if (_RGAitem.Decision == 3)
                {
                    RgaManifist.RMA_Decision = "Canceled";
                }

                _lsRGAManifist.Add(RgaManifist);
            }


            HttpResponse response = HttpContext.Current.Response;

            // first let's clean up the response.object
            response.Clear();
            response.Charset = "";

            // set the response mime type for excel
            response.ContentType = "application/vnd.MS-Excel";
            response.AddHeader("Content-Disposition", "attachment;filename=\"" + DateTime.Now.ToString("hh_mm_ss_tt") + ".xls\"");

            // create a string writer
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                {
                    // instantiate a datagrid
                    DataGrid dg = new DataGrid();
                    dg.DataSource = _lsRGAManifist;
                    dg.DataBind();
                    dg.RenderControl(htw);
                    response.Write(sw.ToString());
                    response.End();
                }
            }
        }
    }


    public class BoxManifist
    {
        public String BoxNumber { get; set; }
        public String PackingNumber { get; set; }
        public String ShippingNumber { get; set; }
        public String TrackingNumber { get; set; }
        public String Width { get; set; }
        public String Height { get; set; }
        public String Lenght { get; set; }
        public String Weight { get; set; }
        public String UserName { get; set; }
        public String Location { get; set; }
        public String PackedDate { get; set; }
    }


    public class RGAManifist
    {
        public String RGA_Number { get; set; }
        public String RMA_Number { get; set; }
        public String Shipping_Number { get; set; }
        public String PO_Number { get; set; }
        public String Vendor_Number { get; set; }
        public String Vendor_Name { get; set; }
        public String CustomerAddress1 { get; set; }
        public String CustomerAddress2 { get; set; }
        public String Delivery_Date { get; set; }
        public String Return_Date { get; set; }
        public String RMA_Satus { get; set; }
        public String RMA_Decision { get; set; }
         
    }

     

}