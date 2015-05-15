using PackingClassLibrary.CustomEntity.SMEntitys.RGA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PackingClassLibrary.Commands.SMcommands.RGA
{
   public class cmdReasonCategory
    {

       public Boolean UpsertReasonCategory(ReasonCategoty ReasonCat)
       {
           Boolean _return = false;
           try
           {
               Service.SetRMA.ReasonCategory(ReasonCat.CopyToSaveDTO(ReasonCat));
           }
           catch (Exception)
           {}
           return _return;
       }


       public List<ReasonCategoty> All()
       {
           List<ReasonCategoty> _lsreturn = new List<ReasonCategoty>();
           try
           {
              var lsAll= Service.GetRMA.CategotyReasonAll().ToList();
              foreach (var item in lsAll)
              {
                  _lsreturn.Add(new ReasonCategoty(item));
              }
           }
           catch (Exception)
           {}
           return _lsreturn;

       }
       public List<ReasonCategoty> CategotyReasonNameByReasonID( Guid ReasonID)
       {
           List<ReasonCategoty> _lsreturn = new List<ReasonCategoty>();
           try
           {var lsAll= Service.GetRMA.CategotyReasonNameByReasonID(ReasonID);
              foreach (var item in lsAll)
              {
                  _lsreturn.Add(new ReasonCategoty(item));
              }
           }
           catch (Exception)
           { }
           return _lsreturn;

       }


    }
}
