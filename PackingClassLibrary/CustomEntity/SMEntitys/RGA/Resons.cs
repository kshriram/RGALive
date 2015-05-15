using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PackingClassLibrary.CustomEntity.SMEntitys.RGA
{
    public class Reason
    {

        //public Guid ReasonID { get; set; }
        //public string Reason1 { get; set; }
        //public int ReasonPoints { get; set; }
        //public Reason()
        //{

        //}

        //public Reason(SetRGAService.ReasonsDTO _ReasonsDTO)
        //{
        //    if (_ReasonsDTO.ReasonID != null) this.ReasonID = _ReasonsDTO.ReasonID;
        //    if (_ReasonsDTO.Reason != null) this.Reason1 = _ReasonsDTO.Reason;
        //    this.ReasonPoints = _ReasonsDTO.ReasonPoints;
        //}

        //public Reason(GetRGAService.ReasonsDTO _ReasonsDTO)
        //{
        //    if (_ReasonsDTO.ReasonID != null) this.ReasonID = _ReasonsDTO.ReasonID;
        //    if (_ReasonsDTO.Reason != null) this.Reason1 = _ReasonsDTO.Reason;
        //    this.ReasonPoints = _ReasonsDTO.ReasonPoints;
        //}

        //public GetRGAService.ReasonsDTO CopyToGetDTO(Reason _Reason)
        //{
        //    GetRGAService.ReasonsDTO _return = new GetRGAService.ReasonsDTO();
        //    if (_Reason.ReasonID != null) _return.ReasonID = _Reason.ReasonID;
        //    if (_Reason.Reason1 != null) _return.Reason = _Reason.Reason1;
        //    _return.ReasonPoints = _Reason.ReasonPoints;
        //    return _return;
        //}

        //public SetRGAService.ReasonsDTO CopyToSaveDTO(Reason _Reason)
        //{
        //    SetRGAService.ReasonsDTO _return = new SetRGAService.ReasonsDTO();
        //    if (_Reason.ReasonID != null) _return.ReasonID = _Reason.ReasonID;
        //    if (_Reason.Reason1 != null) _return.Reason = _Reason.Reason1;
        //    _return.ReasonPoints = _Reason.ReasonPoints;
        //    return _return;
        //}


        public Guid ReasonID { get; set; }
        public string Reason1 { get; set; }
        public int ReasonPoints { get; set; }
        public int ReasonFlag { get; set; }
        public Reason()
        {

        }

        public Reason(SetRGAService.ReasonsDTO _ReasonsDTO)
        {
            if (_ReasonsDTO.ReasonID != null) this.ReasonID = _ReasonsDTO.ReasonID;
            if (_ReasonsDTO.Reason != null) this.Reason1 = _ReasonsDTO.Reason;
            this.ReasonPoints = _ReasonsDTO.ReasonPoints;
           this.ReasonFlag = _ReasonsDTO.ReasonFlag;
        }

        public Reason(GetRGAService.ReasonsDTO _ReasonsDTO)
        {
            if (_ReasonsDTO.ReasonID != null) this.ReasonID = _ReasonsDTO.ReasonID;
            if (_ReasonsDTO.Reason != null) this.Reason1 = _ReasonsDTO.Reason;
            this.ReasonPoints = _ReasonsDTO.ReasonPoints;
           this.ReasonFlag = _ReasonsDTO.ReasonFlag;

        }

        public GetRGAService.ReasonsDTO CopyToGetDTO(Reason _Reason)
        {
            GetRGAService.ReasonsDTO _return = new GetRGAService.ReasonsDTO();
            if (_Reason.ReasonID != null) _return.ReasonID = _Reason.ReasonID;
            if (_Reason.Reason1 != null) _return.Reason = _Reason.Reason1;
            _return.ReasonPoints = _Reason.ReasonPoints;
            _return.ReasonFlag = _Reason.ReasonFlag;
            return _return;
        }

        public SetRGAService.ReasonsDTO CopyToSaveDTO(Reason _Reason)
        {
            SetRGAService.ReasonsDTO _return = new SetRGAService.ReasonsDTO();
            if (_Reason.ReasonID != null) _return.ReasonID = _Reason.ReasonID;
            if (_Reason.Reason1 != null) _return.Reason = _Reason.Reason1;
            _return.ReasonPoints = _Reason.ReasonPoints;
           _return.ReasonFlag = _Reason.ReasonFlag;
            return _return;
        }




    }
}
