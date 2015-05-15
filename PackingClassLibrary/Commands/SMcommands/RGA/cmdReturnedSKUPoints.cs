using PackingClassLibrary.CustomEntity.SMEntitys.RGA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PackingClassLibrary.Commands.SMcommands.RGA
{
   public class cmdReturnedSKUPoints
    {
        public List<ReturnedSKUPoints> GetReturnedSKUPointsByReturnID(Guid ReturnID)
        {
            List<ReturnedSKUPoints> lsskuandpoint = new List<ReturnedSKUPoints>();
            try
            {


                var points = Service.GetRMA.GetSKUReasonandPointsByReturnID(ReturnID);

                foreach (var item in points)
                {
                    ReturnedSKUPoints skuandpoint = new ReturnedSKUPoints();
                    skuandpoint.ID = item.ID;
                    skuandpoint.ReturnID = item.ReturnID;
                    skuandpoint.ReturnDetailID = item.ReturnDetailID;
                    skuandpoint.Reason_Value = item.Reason_Value;
                    skuandpoint.Reason = item.Reason;
                    skuandpoint.SKU = item.SKU;
                    skuandpoint.Points = item.Points;
                    skuandpoint.SkuSequence = item.SkuSequence;
                    lsskuandpoint.Add(skuandpoint);
                }


            }
            catch (Exception)
            {
            }
            return lsskuandpoint;
        }


        public Boolean UpsertReturnedSKUPoints(ReturnedSKUPoints ObjReturnedSKU)
        {
            Boolean _returnFlag = false;
            try
            {
                _returnFlag = Service.SetRMA.ReturnedSKUPoints(ObjReturnedSKU.ConvertToSaveDTO(ObjReturnedSKU));
            }
            catch (Exception)
            {
                //ex.LogThis("cmdReturnedSKUpoint/UpsertReturnedSKUPoints");
            }
            return _returnFlag;
        }
    }
}
