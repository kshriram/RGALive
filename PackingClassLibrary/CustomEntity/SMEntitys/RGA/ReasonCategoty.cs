using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PackingClassLibrary.CustomEntity.SMEntitys.RGA
{
   public class ReasonCategoty
    {
         public Guid ReasonCatID { get; set; }
        public Guid ReasonID { get; set; }
        public String CategoryName { get; set; }
        public ReasonCategoty()
        {

        }

        public ReasonCategoty(SetRGAService.ReasonCategoryDTO _ReasonsCatDTO)
        {
            if (_ReasonsCatDTO.ReasonID != null) this.ReasonID = _ReasonsCatDTO.ReasonID;
            if (_ReasonsCatDTO.ReasonCatID != null) this.ReasonCatID = _ReasonsCatDTO.ReasonCatID;
            if (_ReasonsCatDTO.CategoryName != null) this.CategoryName = _ReasonsCatDTO.CategoryName;
        }

        public ReasonCategoty(GetRGAService.ReasonCategoryDTO _ReasonsCatDTO)
        {
            if (_ReasonsCatDTO.ReasonID != null) this.ReasonID = _ReasonsCatDTO.ReasonID;
            if (_ReasonsCatDTO.ReasonCatID != null) this.ReasonCatID = _ReasonsCatDTO.ReasonCatID;
            if (_ReasonsCatDTO.CategoryName != null) this.CategoryName = _ReasonsCatDTO.CategoryName;
        }

        public GetRGAService.ReasonCategoryDTO CopyToGetDTO(ReasonCategoty _Reason)
        {
            GetRGAService.ReasonCategoryDTO _return = new GetRGAService.ReasonCategoryDTO();
            if (_Reason.ReasonID != null) _return.ReasonID = _Reason.ReasonID;
            if (_Reason.ReasonCatID != null) _return.ReasonCatID = _Reason.ReasonCatID;
            if (_Reason.CategoryName != null) _return.CategoryName = _Reason.CategoryName;
            return _return;
        }

        public SetRGAService.ReasonCategoryDTO CopyToSaveDTO(ReasonCategoty _Reason)
        {
            SetRGAService.ReasonCategoryDTO _return = new SetRGAService.ReasonCategoryDTO();
            if (_Reason.ReasonID != null) _return.ReasonID = _Reason.ReasonID;
            if (_Reason.ReasonCatID != null) _return.ReasonCatID = _Reason.ReasonCatID;
            if (_Reason.CategoryName != null) _return.CategoryName = _Reason.CategoryName;
            return _return;
        }
    }
}
