using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ticker.DataBase;
using Ticker.Views;
using Ticker.DataBase.BL;
using Ticker.DataBase.Views;
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
                                                                    GROUP BY itm.TCLCOD_0 ORDER BY [QtyOrdered];").AsParallel().ToList();
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
        public List<AmountOrderDTO> GetAmountCategoryOrdred()
        {
            List<AmountOrderDTO> lsorder = new List<AmountOrderDTO>();
            try
            {
                var Reugular = _x3v6.ExecuteStoreQuery<AmountOrderDTO>(@"SELECT itm.TCLCOD_0 [Category],
                                                                            cast(sum(sop.NETPRI_0 * soq.QTY_0) as float) [Amount]
                                                                            FROM
                                                                            PRODUCTION.SORDER so
                                                                            INNER JOIN PRODUCTION.SORDERQ soq ON soq.SOHNUM_0 = so.SOHNUM_0
                                                                            INNER JOIN PRODUCTION.SORDERP sop ON so.SOHNUM_0 = sop.SOHNUM_0 AND soq.SOPLIN_0 = sop.SOPLIN_0 AND sop.LINTYP_0 <> 7
                                                                            INNER JOIN PRODUCTION.ITMMASTER itm ON itm.ITMREF_0 = soq.ITMREF_0
                                                                            WHERE cast(soq.ORDDAT_0 as date)= cast(dateadd(d,0,getdate()) as date)
                                                                            AND so.SOHTYP_0 IN ('SON','SOI','SOP')
                                                                            GROUP BY itm.TCLCOD_0 ORDER BY [Amount];
                                                                            ").AsParallel().ToList();
                if (Reugular.Count() > 0)
                {
                    foreach (var item in Reugular)
                    {
                        AmountOrderDTO regularorder = (AmountOrderDTO)item;
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
                                                                        ORDER BY [NoofPartsOrders] DESC;").AsParallel().ToList();
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
                var Order = _x3v6.ExecuteStoreQuery<HoldOrder>(@"SELECT cast(COUNT(so.SOHNUM_0) as int) [NoofHoldOrders] FROM PRODUCTION.SORDER so WHERE so.ORDSTA_0 = 1 AND so.XB_HLDSTA_0 = 3 AND LTRIM(RTRIM(CCLREN_0)) = '';").AsParallel();
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
                                                                        ORDER BY [QtyOrdered] desc, [ProductID];").AsParallel().ToList();
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
                                                                        ORDER BY [QtyOrdered] DESC, [Partner]; ").AsParallel().ToList();

                if (partner.Count() > 0)
                {
                    foreach (var item in partner)
                    {
                        TopPartnerDTO partnertop = (TopPartnerDTO)item;
                        item.Partner = item.Partner.Replace("'", "");
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
                var shipped = _x3v6.ExecuteStoreQuery<int>(@"Select COUNT(*) from 
                                                                                   (
                                                                                   SELECT
                                                                                                   shd.SDHNUM_0,COUNT(shd.SDHNUM_0) as Col1
                                                                                   FROM
                                                                                                   x3v6.PRODUCTION.SORDER so
                                                                                   inner join PRODUCTION.SDELIVERY sh on sh.SOHNUM_0 = so.SOHNUM_0
                                                                                   inner join PRODUCTION.SDELIVERYD shd on shd.SDHNUM_0 = sh.SDHNUM_0
                                                                                   inner join PRODUCTION.SPACKD sp on sp.VCRNUM_0 = sh.SDHNUM_0
                                                                                   Where
                                                                                                   ORDSTA_0 = 2
                                                                                                   and SOHTYP_0 in ('SON','SOEXP')
                                                                                                   and CAST(sp.CREDAT_0 AS DATE) >= CAST(GETDATE() AS DATE)
                                                                                                   and sp.CREDAT_0 <= sh.SHIDAT_0
                                                                                                   and sh.CFMFLG_0 = 2 -- Validated
                                                                                   group by
                                                                                                   shd.SDHNUM_0
                                                                                   ) as AllShipped").AsParallel().ToList();
                                                                   
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
                                                                       cast(count(SOHNUM_0) as float) [QtyOrdered]
                                                                        FROM
                                                                        PRODUCTION.SORDER so
                                                                        WHERE cast(so.ORDDAT_0 as date)= cast(dateadd(d,0,getdate()) as date)
                                                                        AND so.SOHTYP_0 IN ('SON','SOI','SOP')
                                                                        GROUP BY so.BPCORD_0, so.BPCNAM_0
                                                                        ORDER BY [QtyOrdered] DESC, [Partner]; ").AsParallel().ToList();

                if (partner.Count() > 0)
                {
                    foreach (var item in partner)
                    {
                        TopPartnerDTO partnertop = (TopPartnerDTO)item;
                        item.Partner = item.Partner.Replace("'", "");
                        lspartner.Add(partnertop);
                    }
                }
            }
            catch (Exception)
            {
            }
            return lspartner;

        }

        public int GetTodaysOrder()
        {
            int todayorder = 0;
            try
            {
               var order =_x3v6.ExecuteStoreQuery<int>(@"SELECT COUNT(SOHNUM_0) OrdersToday FROM PRODUCTION.SORDER WHERE CAST(ORDDAT_0 AS DATE) = CAST(DATEADD(D,0,GETDATE()) AS DATE) AND SOHTYP_0 IN ('SOI','SON','SOP')").AsParallel();

               if (order != null)
                   todayorder = Convert.ToInt32(order.FirstOrDefault().ToString());
            }
            catch (Exception)
            {
            }
            return todayorder;
        }

        public int GetYesterdayOrder()
        {
            int yesterday = 0;
            try
            {
               var orderyes =_x3v6.ExecuteStoreQuery<int>(@"SELECT COUNT(SOHNUM_0) OrdersYesterday FROM PRODUCTION.SORDER WHERE CAST(ORDDAT_0 AS DATE) = CAST(DATEADD(D,-1,GETDATE()) AS DATE) AND SOHTYP_0 IN ('SOI','SON','SOP')").AsParallel();
               if (orderyes != null)
                   yesterday = Convert.ToInt32(orderyes.FirstOrDefault().ToString());
            }
            catch (Exception)
            {
            }
            return yesterday;
        }

        public List<WeekOrederDTO> GetWeekOrders()
        {
            List<WeekOrederDTO> lsweekorder = new List<WeekOrederDTO>();
            try
            {
                var orderweek = _x3v6.ExecuteStoreQuery<WeekOrederDTO>(@"SELECT CAST(ORDDAT_0 AS DATE) DATE,
                                                                            COUNT(SOHNUM_0) ORDERS
                                                                            FROM
                                                                            PRODUCTION.SORDER
                                                                            WHERE SOHTYP_0 IN ('SON','SOI','SOP')
                                                                            AND CAST(ORDDAT_0 AS DATE) >= CAST(DATEADD(DD,-13,GETDATE()) AS DATE)
                                                                            AND CAST(ORDDAT_0 AS DATE) !> CAST(GETDATE() AS DATE)
                                                                            GROUP BY ORDDAT_0, DATENAME(DW,ORDDAT_0)
                                                                            ORDER BY ORDDAT_0 DESC ").AsParallel().ToList();

                if (orderweek.Count() > 0)
                {
                    foreach (var item in orderweek)
                    {
                      WeekOrederDTO  partnertop = (WeekOrederDTO)item;
                        lsweekorder.Add(partnertop);
                    }
                }
            }
            catch (Exception)
            {
            }
            return lsweekorder;
        }

        public List<YearAvg> GetYearAvg()
        {
            List<YearAvg> lsYearAvgReturn = new List<YearAvg>();
            try
            {
                var orderweek = _x3v6.ExecuteStoreQuery<YearAvg>(@"SELECT
                                                                        DayName,
                                                                        AVG(ORDERS) Avarage
                                                                        FROM
                                                                        (
                                                                        SELECT
                                                                        CAST(ORDDAT_0 AS DATE) DATE,
                                                                        DATENAME(DW,ORDDAT_0) DayName,
                                                                        COUNT(SOHNUM_0) ORDERS
                                                                        FROM
                                                                        PRODUCTION.SORDER
                                                                        WHERE SOHTYP_0 IN ('SON','SOI','SOP')
                                                                        AND CAST(ORDDAT_0 AS DATE) !> CAST(DATEADD(DD,-1,GETDATE()) AS DATE)
                                                                        AND YEAR(ORDDAT_0) = YEAR(GETDATE())
                                                                        GROUP BY ORDDAT_0, DATENAME(DW,ORDDAT_0)
                                                                        ) AS D
                                                                        GROUP BY DayName ").AsParallel().ToList();

                if (orderweek.Count() > 0)
                {
                    foreach (var item in orderweek)
                    {
                        YearAvg partnertop = (YearAvg)item;
                        lsYearAvgReturn.Add(partnertop);
                    }
                }
            }
            catch (Exception)
            {
            }
            return lsYearAvgReturn;
        }


    }
}