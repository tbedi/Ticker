using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ticker.DataBase;
using Ticker.Views;
using Ticker.BI;

namespace Ticker.DataBase.Command
{
    public class cmdClass
    {
        x3v6Entities _x3v6 = new x3v6Entities();

        public List<OrderDTO> GetCategoryOrder()
        {
            List<OrderDTO> lsorder = new List<OrderDTO>();
            try
            {
                 var Catorder = _x3v6.ExecuteStoreQuery<OrderDTO>(@"SELECT itm.TCLCOD_0 [Category],
                                                                          cast(SUM(soq.QTY_0) as float) [QtyOrdered]
                                                                          FROM PRODUCTION.SORDER so INNER JOIN PRODUCTION.SORDERQ soq
                                                                          ON soq.SOHNUM_0 = so.SOHNUM_0
                                                                          INNER JOIN PRODUCTION.SORDERP sop ON so.SOHNUM_0 = sop.SOHNUM_0 AND soq.SOPLIN_0 = sop.SOPLIN_0 AND sop.LINTYP_0 <> 7
                                                                          INNER JOIN PRODUCTION.ITMMASTER itm ON itm.ITMREF_0 = soq.ITMREF_0
                                                                          WHERE  cast(soq.ORDDAT_0 as date)= cast(dateadd(d,0,getdate()) as date)
                                                                          GROUP BY itm.TCLCOD_0 ORDER BY [QtyOrdered] desc, [Category];").ToList();
                if (Catorder.Count() > 0)
                {
                    foreach (var RMAitem in Catorder)
                    {
                        OrderDTO rmaInfo = (OrderDTO)RMAitem;
                        lsorder.Add(rmaInfo);
                    }
                }
            }
            catch (Exception)
            { }
            return lsorder;
        }
    }
}