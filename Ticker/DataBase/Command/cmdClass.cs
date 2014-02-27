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

        public List<OrderDTO> GetQuantityOrderedCategory()
        {
            List<OrderDTO> lsorder = new List<OrderDTO>();
            try
            {
                 var Catorder = _x3v6.ExecuteStoreQuery<OrderDTO>(@"SELECT itm.TCLCOD_0 [Category],
                                                                          cast(SUM(soq.QTY_0) as float) [QtyOrdered]
                                                                          FROM PRODUCTION.SORDER so INNER JOIN PRODUCTION.SORDERQ soq
                                                                          ON soq.SOHNUM_0 = so.SOHNUM_0
                                                                          INNER JOIN PRODUCTION.SORDERP sop ON so.SOHNUM_0 = sop.SOHNUM_0 AND soq.SOPLIN_0 = sop.SOPLIN_0
                                                                          INNER JOIN PRODUCTION.ITMMASTER itm ON itm.ITMREF_0 = soq.ITMREF_0
                                                                          WHERE  cast(soq.ORDDAT_0 as date)= cast(dateadd(d,0,getdate()) as date)
                                                                          GROUP BY itm.TCLCOD_0 ORDER BY [QtyOrdered] desc, [Category];").ToList();
                if (Catorder.Count() > 0)
                {
                    foreach (var item in Catorder)
                    {
                        OrderDTO order = (OrderDTO)item;
                        lsorder.Add(order);
                    }
                }
            }
            catch (Exception)
            { }
            return lsorder;
        }

        public List<RegularOrderDTO> GetRegularQuantityOrdred()
        {
            List<RegularOrderDTO> lsorder = new List<RegularOrderDTO>();
            try
            {
                var Reugular = _x3v6.ExecuteStoreQuery<RegularOrderDTO>(@"select distinct soh.SOHTYP_0 [OrderType] , ISNULL(a.[NoofRegularOrders],0) AS [NoofRegularOrders]
from PRODUCTION.SORDER soh left join (SELECT

so.SOHTYP_0 [OrderType],

cast(COUNT(so.SOHNUM_0) as float) [NoofRegularOrders]

FROM

PRODUCTION.SORDER so

WHERE cast(so.ORDDAT_0 as date)= cast(dateadd(d,0,getdate()) as date)

AND so.SOHTYP_0 IN ('SOI')

GROUP BY so.SOHTYP_0

union

SELECT

so.SOHTYP_0 [OrderType],

cast(COUNT(so.SOHNUM_0) as float) [NoofRegularOrders]

FROM

PRODUCTION.SORDER so

WHERE cast(so.ORDDAT_0 as date)= cast(dateadd(d,0,getdate()) as date)

AND so.SOHTYP_0 IN ('SON')

GROUP BY so.SOHTYP_0


union

SELECT

so.SOHTYP_0 [OrderType],

cast(COUNT(so.SOHNUM_0) as float) [NoofRegularOrders]

FROM

PRODUCTION.SORDER so

WHERE cast(so.ORDDAT_0 as date)= cast(dateadd(d,0,getdate()) as date)

AND so.SOHTYP_0 IN ('SOP')

GROUP BY so.SOHTYP_0) as a

on soh.SOHTYP_0 = a.[OrderType]
where soh.SOHTYP_0 IN ('SON','SOI','SOP')
ORDER BY [NoofRegularOrders] DESC;").ToList();
                if (Reugular.Count() > 0)
                {
                    foreach (var item in Reugular)
                    {
                        RegularOrderDTO regularorder = (RegularOrderDTO)item;
                        lsorder.Add(regularorder);
                    }
                }
            }
            catch (Exception)
            {
            }
            return lsorder;
        }

        public List<PartOrderDTO> GetPartQuantityOrdered()
        {
            List<PartOrderDTO> lsorder = new List<PartOrderDTO>();
            try
            {
                var parts = _x3v6.ExecuteStoreQuery<PartOrderDTO>(@"SELECT so.SOHTYP_0 [OrderType],cast(COUNT(so.SOHNUM_0) as float) [NoofPartOrders]
                                                                FROM PRODUCTION.SORDER so WHERE cast(so.ORDDAT_0 as date)= cast(dateadd(d,0,getdate()) as date)
                                                                AND so.SOHTYP_0 IN ('SOPR','SOPRM','WRT') GROUP BY so.SOHTYP_0
                                                                ORDER BY [NoofPartOrders] desc, [OrderType];").ToList();
                if (parts.Count() > 0)
                {
                    foreach (var item in parts)
                    {
                        PartOrderDTO partorder = (PartOrderDTO)item;
                        lsorder.Add(partorder);
                    }
                }
            }
            catch (Exception)
            {
            }
            return lsorder;
        
        }

        public int GetNoOfHoldOrders()
        {
            int Orders=0;
            try
            {
              var Order = _x3v6.ExecuteStoreQuery<HoldOrder>(@"SELECT cast(COUNT(so.SOHNUM_0) as int) [NoofHoldOrders] FROM PRODUCTION.SORDER so WHERE so.ORDSTA_0 = 1 AND so.XB_HLDSTA_0 = 3;");
              foreach (var item in Order)
              {
                  Orders = item.NoofHoldOrders;
              }
            }
            catch (Exception)
            {
            }
            return Orders;
        
        }

        public List<TopQuantityOrdered> GetTopQuantityOrder()
        {
            List<TopQuantityOrdered> lstopquantity = new List<TopQuantityOrdered>();
            try
            {
                var top = _x3v6.ExecuteStoreQuery<TopQuantityOrdered>(@"SELECT top 10 soq.ITMREF_0 [ProductID],sop.ITMDES_0 [SKU],cast(SUM(soq.QTY_0) as float) [QtyOrdered]
                                                                        FROM PRODUCTION.SORDER so INNER JOIN PRODUCTION.SORDERQ soq ON soq.SOHNUM_0 = so.SOHNUM_0
                                                                        INNER JOIN PRODUCTION.SORDERP sop ON so.SOHNUM_0 = sop.SOHNUM_0 AND soq.SOPLIN_0 = sop.SOPLIN_0 AND sop.LINTYP_0 <> 7
                                                                        WHERE cast(soq.ORDDAT_0 as date)= cast(dateadd(d,0,getdate()) as date)
                                                                        GROUP BY soq.ITMREF_0, sop.ITMDES_0
                                                                        ORDER BY [QtyOrdered] desc, [ProductID];").ToList();
                if (top.Count() > 0)
                {
                    foreach (var item in top)
                    {
                        TopQuantityOrdered partorder = (TopQuantityOrdered)item;
                        lstopquantity.Add(partorder);
                    }
                }
            }
            catch (Exception)
            {
            }
            return lstopquantity;
        }

        public List<TopPartnerDTO> GetTopParnerOrder()
        {
            List<TopPartnerDTO> lspartner = new List<TopPartnerDTO>();
            try
            {
                var partner = _x3v6.ExecuteStoreQuery<TopPartnerDTO>(@"SELECT top 10 so.BPCORD_0 [PartnerID],so.BPCNAM_0 [Partner],cast(SUM(soq.QTY_0) as float) [QtyOrdered]
                                                                       FROM PRODUCTION.SORDER so INNER JOIN PRODUCTION.SORDERQ soq ON soq.SOHNUM_0 = so.SOHNUM_0 INNER JOIN
                                                                       PRODUCTION.SORDERP sop ON so.SOHNUM_0 = sop.SOHNUM_0 AND soq.SOPLIN_0 = sop.SOPLIN_0 AND sop.LINTYP_0 <> 7
                                                                       WHERE cast(soq.ORDDAT_0 as date)= cast(dateadd(d,0,getdate()) as date)
                                                                       GROUP BY so.BPCORD_0, so.BPCNAM_0
                                                                       ORDER BY [QtyOrdered] DESC, [Partner];").ToList();

                if (partner.Count() > 0)
                {
                    foreach (var item in partner)
                    {
                        TopPartnerDTO partnertop = (TopPartnerDTO)item;
                        lspartner.Add(partnertop);
                    }
                }
            }
            catch (Exception)
            {
            }
            return lspartner;

        }

    }
}