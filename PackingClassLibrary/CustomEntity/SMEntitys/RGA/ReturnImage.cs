﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PackingClassLibrary.CustomEntity.SMEntitys.RGA
{
    public class ReturnImage
    {

        public Guid ReturnImageID { get; set; }
        public Guid ReturnDetailID { get; set; }
        public String SKUImagePath { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid UpadatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpadatedDate { get; set; }

        public ReturnImage()
        {

        }
        public ReturnImage(SetRGAService.ReturnImagesDTO _ReturnImages)
        {
            if (_ReturnImages.ReturnImageID != Guid.Empty) this.ReturnImageID = _ReturnImages.ReturnImageID;
            if (_ReturnImages.ReturnDetailID != Guid.Empty) this.ReturnDetailID = _ReturnImages.ReturnDetailID;
            if (_ReturnImages.SKUImagePath != null) this.SKUImagePath = _ReturnImages.SKUImagePath;
            if (_ReturnImages.CreatedBy != Guid.Empty) this.CreatedBy = (Guid)_ReturnImages.CreatedBy;
            if (_ReturnImages.UpadatedBy != Guid.Empty) this.UpadatedBy = (Guid)_ReturnImages.UpadatedBy;
            if (_ReturnImages.CreatedDate != Convert.ToDateTime("01/01/0001")) this.CreatedDate = (DateTime)_ReturnImages.CreatedDate;
            if (_ReturnImages.UpadatedDate != Convert.ToDateTime("01/01/0001")) this.UpadatedDate = (DateTime)_ReturnImages.UpadatedDate;
        }

        public SetRGAService.ReturnImagesDTO CopyToSaveDTO(ReturnImage _ReturnImages)
        {
            SetRGAService.ReturnImagesDTO _return = new SetRGAService.ReturnImagesDTO();
            if (_ReturnImages.ReturnImageID != Guid.Empty) _return.ReturnImageID = _ReturnImages.ReturnImageID;
            if (_ReturnImages.ReturnDetailID != Guid.Empty) _return.ReturnDetailID = _ReturnImages.ReturnDetailID;
            if (_ReturnImages.SKUImagePath != null) _return.SKUImagePath = _ReturnImages.SKUImagePath;
            if (_ReturnImages.CreatedBy != Guid.Empty) _return.CreatedBy = (Guid)_ReturnImages.CreatedBy;
            if (_ReturnImages.UpadatedBy != Guid.Empty) _return.UpadatedBy = (Guid)_ReturnImages.UpadatedBy;
            if (_ReturnImages.CreatedDate != Convert.ToDateTime("01/01/0001")) _return.CreatedDate = (DateTime)_ReturnImages.CreatedDate;
            if (_ReturnImages.UpadatedDate != Convert.ToDateTime("01/01/0001")) _return.UpadatedDate = (DateTime)_ReturnImages.UpadatedDate;
            return _return;
        }
    }
}
