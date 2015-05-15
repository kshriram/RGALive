﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PackingClassLibrary.CustomEntity.SMEntitys.RGA
{
    public class ReturnDetail
    {

        public Guid ReturnDetailID { get; set; }
        public Guid ReturnID { get; set; }
        public String SKUNumber { get; set; }
        public String ProductName { get; set; }
        public String TCLCOD_0 { get; set; }
        public int DeliveredQty { get; set; }
        public int ExpectedQty { get; set; }
        public int ReturnQty { get; set; }
        public int ProductStatus { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpadatedDate { get; set; }
        public string SKU_Status { get; set; }
        public int SKU_Reason_Total_Points { get; set; }
        public int IsSkuScanned { get; set; }
        public int IsManuallyAdded { get; set; }
        public int SKU_Sequence { get; set; }
        public int SKU_Qty_Seq { get; set; }

        public string ProductID { get; set; }
        public decimal? SalesPrice { get; set; }

        public int? LineType { get; set; }

        public int? ReturnLines { get; set; }
        public int? ShipmentLines { get; set; }

        public String RGADROWID { get; set; }

        public string TrackingNumber { get; set; }

        public ReturnDetail(SetRGAService.ReturnDetailsDTO _ReturnDetails)
        {
            if (_ReturnDetails.ReturnDetailID != Guid.Empty) this.ReturnDetailID = _ReturnDetails.ReturnDetailID;
            if (_ReturnDetails.ReturnID != Guid.Empty) this.ReturnID = _ReturnDetails.ReturnID;
            if (_ReturnDetails.SKUNumber != null) this.SKUNumber = _ReturnDetails.SKUNumber;
            if (_ReturnDetails.ProductName != null) this.ProductName = _ReturnDetails.ProductName;
            if (_ReturnDetails.TCLCOD_0 != null) this.TCLCOD_0 = _ReturnDetails.TCLCOD_0;
            this.DeliveredQty = (int)_ReturnDetails.DeliveredQty;
            this.ExpectedQty = (int)_ReturnDetails.ExpectedQty;
            this.ReturnQty = (int)_ReturnDetails.ReturnQty;
            this.ProductStatus = (int)_ReturnDetails.ProductStatus;
            if (_ReturnDetails.CreatedBy != Guid.Empty) this.CreatedBy = (Guid)_ReturnDetails.CreatedBy;
            if (_ReturnDetails.UpdatedBy != Guid.Empty) this.UpdatedBy = (Guid)_ReturnDetails.UpdatedBy;
            if (_ReturnDetails.CreatedDate != null) this.CreatedDate = (DateTime)_ReturnDetails.CreatedDate;
            if (_ReturnDetails.UpadatedDate != null) this.UpadatedDate = (DateTime)_ReturnDetails.UpadatedDate;

            if (_ReturnDetails.SKU_Status != null) this.SKU_Status = _ReturnDetails.SKU_Status;
            this.SKU_Reason_Total_Points = (int)_ReturnDetails.SKU_Reason_Total_Points;
            this.IsSkuScanned = (int)_ReturnDetails.IsSkuScanned;
            this.IsManuallyAdded = (int)_ReturnDetails.IsManuallyAdded;

            this.SKU_Sequence = (int)_ReturnDetails.SKU_Sequence;
            this.SKU_Qty_Seq = (int)_ReturnDetails.SKU_Qty_Seq;

            if (_ReturnDetails.ProductID != null) this.ProductID = _ReturnDetails.ProductID;
            if (_ReturnDetails.SalesPrice != null) this.SalesPrice = _ReturnDetails.SalesPrice;

            if (_ReturnDetails.LineType != null) this.LineType = _ReturnDetails.LineType;

            if (_ReturnDetails.ShipmentLines != null) this.ShipmentLines = _ReturnDetails.ShipmentLines;
            if (_ReturnDetails.ReturnLines != null) this.ReturnLines = _ReturnDetails.ReturnLines;

            if (_ReturnDetails.TrackingNumber != null) this.TrackingNumber = _ReturnDetails.TrackingNumber;


            this.RGADROWID = _ReturnDetails.RGADROWID;
        }
        public ReturnDetail(GetRGAService.ReturnDetailsDTO _ReturnDetails)
        {
            if (_ReturnDetails.ReturnDetailID != Guid.Empty) this.ReturnDetailID = _ReturnDetails.ReturnDetailID;
            if (_ReturnDetails.ReturnID != Guid.Empty) this.ReturnID = _ReturnDetails.ReturnID;
            if (_ReturnDetails.SKUNumber != null) this.SKUNumber = _ReturnDetails.SKUNumber;
            if (_ReturnDetails.ProductName != null) this.ProductName = _ReturnDetails.ProductName;
            if (_ReturnDetails.TCLCOD_0 != null) this.TCLCOD_0 = _ReturnDetails.TCLCOD_0;
            this.DeliveredQty = (int)_ReturnDetails.DeliveredQty;
            this.ExpectedQty = (int)_ReturnDetails.ExpectedQty;
            this.ReturnQty = (int)_ReturnDetails.ReturnQty;
            this.ProductStatus = (int)_ReturnDetails.ProductStatus;
            if (_ReturnDetails.CreatedBy != Guid.Empty) this.CreatedBy = (Guid)_ReturnDetails.CreatedBy;
            if (_ReturnDetails.UpdatedBy != Guid.Empty) this.UpdatedBy = (Guid)_ReturnDetails.UpdatedBy;
            if (_ReturnDetails.CreatedDate != null) this.CreatedDate = (DateTime)_ReturnDetails.CreatedDate;
            if (_ReturnDetails.UpadatedDate != null) this.UpadatedDate = (DateTime)_ReturnDetails.UpadatedDate;

            if (_ReturnDetails.SKU_Status != null) this.SKU_Status = _ReturnDetails.SKU_Status;
            this.SKU_Reason_Total_Points = (int)_ReturnDetails.SKU_Reason_Total_Points;
            this.IsSkuScanned = (int)_ReturnDetails.IsSkuScanned;
            this.IsManuallyAdded = (int)_ReturnDetails.IsManuallyAdded;

            this.SKU_Sequence = (int)_ReturnDetails.SKU_Sequence;
            this.SKU_Qty_Seq = (int)_ReturnDetails.SKU_Qty_Seq;

            if (_ReturnDetails.ProductID != null) this.ProductID = _ReturnDetails.ProductID;
            if (_ReturnDetails.SalesPrice != null) this.SalesPrice = _ReturnDetails.SalesPrice;

            if (_ReturnDetails.LineType != null) this.LineType = _ReturnDetails.LineType;

            if (_ReturnDetails.ShipmentLines != null) this.ShipmentLines = _ReturnDetails.ShipmentLines;
            if (_ReturnDetails.ReturnLines != null) this.ReturnLines = _ReturnDetails.ReturnLines;

            if (_ReturnDetails.TrackingNumber != null) this.TrackingNumber = _ReturnDetails.TrackingNumber;

            this.RGADROWID = _ReturnDetails.RGADROWID;
        }

        public SetRGAService.ReturnDetailsDTO ConvertToSaveDTO(ReturnDetail _ReturnDetails)
        {
            SetRGAService.ReturnDetailsDTO _return = new SetRGAService.ReturnDetailsDTO();

            if (_ReturnDetails.ReturnDetailID != Guid.Empty) _return.ReturnDetailID = _ReturnDetails.ReturnDetailID;
            if (_ReturnDetails.ReturnID != Guid.Empty) _return.ReturnID = _ReturnDetails.ReturnID;
            if (_ReturnDetails.SKUNumber != null) _return.SKUNumber = _ReturnDetails.SKUNumber;
            if (_ReturnDetails.ProductName != null) _return.ProductName = _ReturnDetails.ProductName;
            if (_ReturnDetails.TCLCOD_0 != null) _return.TCLCOD_0 = _ReturnDetails.TCLCOD_0;
            _return.DeliveredQty = (int)_ReturnDetails.DeliveredQty;
            _return.ExpectedQty = (int)_ReturnDetails.ExpectedQty;
            _return.ReturnQty = (int)_ReturnDetails.ReturnQty;
            _return.ProductStatus = (int)_ReturnDetails.ProductStatus;
            if (_ReturnDetails.CreatedBy != Guid.Empty) _return.CreatedBy = (Guid)_ReturnDetails.CreatedBy;
            if (_ReturnDetails.UpdatedBy != Guid.Empty) _return.UpdatedBy = (Guid)_ReturnDetails.UpdatedBy;
            if (_ReturnDetails.CreatedDate != null) _return.CreatedDate = (DateTime)_ReturnDetails.CreatedDate;
            if (_ReturnDetails.UpadatedDate != null) _return.UpadatedDate = (DateTime)_ReturnDetails.UpadatedDate;

            if (_ReturnDetails.SKU_Status != null) _return.SKU_Status = _ReturnDetails.SKU_Status;
            _return.SKU_Reason_Total_Points = (int)_ReturnDetails.SKU_Reason_Total_Points;
            _return.IsSkuScanned = (int)_ReturnDetails.IsSkuScanned;
            _return.IsManuallyAdded = (int)_ReturnDetails.IsManuallyAdded;
            _return.SKU_Sequence = (int)_ReturnDetails.SKU_Sequence;
            _return.SKU_Qty_Seq = (int)_ReturnDetails.SKU_Qty_Seq;

            if (_ReturnDetails.ProductID != null) _return.ProductID = _ReturnDetails.ProductID;
            if (_ReturnDetails.SalesPrice != null) _return.SalesPrice = _ReturnDetails.SalesPrice;

            if (_ReturnDetails.LineType != null) _return.LineType = _ReturnDetails.LineType;

            if (_ReturnDetails.ShipmentLines != null) _return.ShipmentLines = _ReturnDetails.ShipmentLines;
            if (_ReturnDetails.ReturnLines != null) _return.ReturnLines = _ReturnDetails.ReturnLines;

            if (_ReturnDetails.TrackingNumber != null) _return.TrackingNumber = _ReturnDetails.TrackingNumber;

            _return.RGADROWID = _ReturnDetails.RGADROWID;
            return _return;

        }
        public ReturnDetail()
        {

        }
    }
}
