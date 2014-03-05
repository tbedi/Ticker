using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ticker.DataBase;
using Ticker.Views;

namespace Ticker.DataBase.Command
{
    public class cmdClass
    {
        x3v6Entities _x3v6 = new x3v6Entities();

        /// <summary>
        /// This Method is for Get Quantity Order Category.
        /// </summary>
        /// <returns>
        /// Return list of order category.
        /// </returns>
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
                                                                    INNER JOIN PRODUCTION.ITMMASTER itm ON itm.ITMREF_0 = soq.ITMREF_0 AND sop.LINTYP_0 <> 7
                                                                    WHERE  cast(soq.ORDDAT_0 as date)= cast(dateadd(d,0,getdate()) as date)
                                                                    AND so.SOHTYP_0 IN ('SON','SOI','SOP')
                                                                    GROUP BY itm.TCLCOD_0 ORDER BY [Category];").ToList();
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

        /// <summary>
        /// This Method is for Get Regular Quantity Order.
        /// </summary>
        /// <returns>
        /// List of Regular Quantity Order.
        /// </returns>
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

        /// <summary>
        /// This Method Is used for Get Part Quantity Ordered.
        /// </summary>
        /// <returns>
        /// Return List of PartQuantityOrder.
        /// </returns>
        public List<PartOrderDTO> GetPartQuantityOrdered()
        {
            List<PartOrderDTO> lsorder = new List<PartOrderDTO>();
            try
            {
                var parts = _x3v6.ExecuteStoreQuery<PartOrderDTO>(@"select distinct soh.SOHTYP_0 [OrderType] , ISNULL(a.[NoofRegularOrders],0) AS [NoofPartsOrders]
                                                                        from PRODUCTION.SORDER soh left join (
                                                                        SELECT
                                                                        so.SOHTYP_0 [OrderType],
                                                                        cast(COUNT(so.SOHNUM_0) as float) [NoofRegularOrders]
                                                                        FROM
                                                                        PRODUCTION.SORDER so
                                                                        WHERE cast(so.ORDDAT_0 as date)= cast(dateadd(d,0,getdate()) as date)
                                                                        AND so.SOHTYP_0 IN ('SOPR')
                                                                        GROUP BY so.SOHTYP_0
                                                                        union
                                                                        SELECT
                                                                        so.SOHTYP_0 [OrderType],
                                                                        cast(COUNT(so.SOHNUM_0) as float) [NoofRegularOrders]
                                                                        FROM
                                                                        PRODUCTION.SORDER so
                                                                        WHERE cast(so.ORDDAT_0 as date)= cast(dateadd(d,0,getdate()) as date)
                                                                        AND so.SOHTYP_0 IN ('SOPRM')
                                                                        GROUP BY so.SOHTYP_0
                                                                        union
                                                                        SELECT
                                                                        so.SOHTYP_0 [OrderType],
                                                                        cast(COUNT(so.SOHNUM_0) as float) [NoofRegularOrders]
                                                                        FROM
                                                                        PRODUCTION.SORDER so
                                                                        WHERE cast(so.ORDDAT_0 as date)= cast(dateadd(d,0,getdate()) as date)
                                                                        AND so.SOHTYP_0 IN ('WRT')
                                                                        GROUP BY so.SOHTYP_0) as a
                                                                        on soh.SOHTYP_0 = a.[OrderType]
                                                                        where soh.SOHTYP_0 IN ('SOPR','SOPRM','WRT')
                                                                        ORDER BY [NoofPartsOrders] DESC;").ToList();
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

        /// <summary>
        /// This Method Used for Get No. of HoldOreder.
        /// </summary>
        /// <returns>
        /// Return Integer Value of Number of Hold Orders.
        /// </returns>
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

        /// <summary>
        /// this Method is for Get Top 5 SKU Quantity Order.
        /// </summary>
        /// <returns>
        /// Return List of Top e SKU Quntity Order. 
        /// </returns>
        public List<TopQuantityOrdered> GetTop5SkuQuantityOrder()
        {
            List<TopQuantityOrdered> lstopquantity = new List<TopQuantityOrdered>();
            try
            {
                var top = _x3v6.ExecuteStoreQuery<TopQuantityOrdered>(@"SELECT top 5 soq.ITMREF_0 [ProductID],sop.ITMDES_0 [SKU],cast(SUM(soq.QTY_0) as float) [QtyOrdered]
                                                                        FROM 
                                                                        PRODUCTION.SORDER so 
                                                                        INNER JOIN 
                                                                        PRODUCTION.SORDERQ soq 
                                                                        ON soq.SOHNUM_0 = so.SOHNUM_0 
                                                                        INNER JOIN PRODUCTION.SORDERP sop 
                                                                        ON so.SOHNUM_0 = sop.SOHNUM_0 AND soq.SOPLIN_0 = sop.SOPLIN_0 AND sop.LINTYP_0 <> 7 
                                                                        WHERE cast(soq.ORDDAT_0 as date)= cast(dateadd(d,0,getdate()) as date) 
                                                                        AND so.SOHTYP_0 IN ('SON','SOI','SOP')
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


        /// <summary>
        /// This Method is for Get Top 5 Partner sales Order.
        /// </summary>
        /// <returns>
        /// Return list of Top 5 partner.
        /// </returns>
        public List<TopPartnerDTO> GetTop5ParnerSale()
        {
            List<TopPartnerDTO> lspartner = new List<TopPartnerDTO>();
            try
            {
                var partner = _x3v6.ExecuteStoreQuery<TopPartnerDTO>(@"SELECT top 5 so.BPCORD_0 [PartnerID],so.BPCNAM_0 [Partner],
                                                                        cast(sum(sop.NETPRI_0 * soq.QTY_0) as float) [QtyOrdered]
                                                                        FROM
                                                                        PRODUCTION.SORDER so
                                                                        INNER JOIN
                                                                        PRODUCTION.SORDERQ soq
                                                                        ON soq.SOHNUM_0 = so.SOHNUM_0
                                                                        INNER JOIN
                                                                        PRODUCTION.SORDERP sop
                                                                        ON so.SOHNUM_0 = sop.SOHNUM_0 AND soq.SOPLIN_0 = sop.SOPLIN_0 AND sop.LINTYP_0 <> 7
                                                                        WHERE cast(so.ORDDAT_0 as date)= cast(dateadd(d,0,getdate()) as date)
                                                                        AND so.SOHTYP_0 IN ('SON','SOI','SOP')
                                                                        GROUP BY so.BPCORD_0, so.BPCNAM_0
                                                                        ORDER BY [QtyOrdered] DESC, [Partner]; ").ToList();

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

        /// <summary>
        /// This Method for No. of Total Shipped.
        /// </summary>
        /// <returns>
        /// Return list of double of no. of total shipped.
        /// </returns>
        public List<double> GetShipped()
        {
            List<double> lsshipped = new List<double>();
            try
            {
                var shipped = _x3v6.ExecuteStoreQuery<int>(@"SELECT COUNT(*) [Shipped]
                                                                    FROM
                                                                    PRODUCTION.SDELIVERY 
                                                                    WHERE CAST(SHIDAT_0 AS DATE) = CAST(DATEADD(D,0,GETDATE()) AS DATE)
                                                                    AND CFMFLG_0 = 2
                                                                    UNION ALL
                                                                    SELECT
                                                                    COUNT(*)
                                                                    FROM
                                                                    PRODUCTION.SDELIVERY
                                                                    WHERE CAST(CREDAT_0 AS DATE) = CAST(DATEADD(D,0,GETDATE()) AS DATE)").ToList();
                                                                   
                if (shipped.Count() > 0)
                {
                    foreach (var item in shipped)
                    {
                        double partnertop = (double)item;
                        lsshipped.Add(partnertop);
                    }
                }
            }
            catch (Exception)
            {
            }
            return lsshipped;
        }

        /// <summary>
        /// This Method is for Get Top 5 Partner Order.
        /// </summary>
        /// <returns>
        /// Return list of Top 5 partner.
        /// </returns>
        public List<TopPartnerDTO> GetTop5ParnerByOrder()
        {
            List<TopPartnerDTO> lspartner = new List<TopPartnerDTO>();
            try
            {
                var partner = _x3v6.ExecuteStoreQuery<TopPartnerDTO>(@"SELECT top 5 so.BPCORD_0 [PartnerID],so.BPCNAM_0 [Partner],
                                                                        count(SOHNUM_0) [QtyOrdered]
                                                                        FROM
                                                                        PRODUCTION.SORDER so
                                                                        WHERE cast(so.ORDDAT_0 as date)= cast(dateadd(d,0,getdate()) as date)
                                                                        AND so.SOHTYP_0 IN ('SON','SOI','SOP')
                                                                        GROUP BY so.BPCORD_0, so.BPCNAM_0
                                                                        ORDER BY [QtyOrdered] DESC, [Partner]; ").ToList();

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