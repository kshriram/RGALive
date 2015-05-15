using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PackingClassLibrary.CustomEntity.SMEntitys.RGA;

namespace PackingClassLibrary.Commands.SMcommands.RGA
{
    public class cmdRMAComment
    {

        public List<RMAComment> GetCommentByReturnID(Guid ReturnID)
        {
            List<RMAComment> _lscomment = new List<RMAComment>();
            try
            {
                var v = from ls in Service.GetRMA.GetRMAComments(ReturnID)
                        select ls;

                foreach (var Ritem in v)
                {
                    _lscomment.Add(new RMAComment(Ritem));
                }
            }
            catch (Exception)
            { }
            return _lscomment;
        }

        public Boolean InsertComment(RMAComment _lsreturn)
        {
            Boolean _flag = false;
            try
            {
                _flag = Service.SetRMA.InsertRMAComment(_lsreturn.ConvertTOSaveDTO(_lsreturn));
            }
            catch (Exception)
            {
            }
            return _flag;

        }

    }
}
