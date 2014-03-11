using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ticker.DataBase.Command
{
    public class cmdTicker
    {
        x3v6Entities _x3v6 = new x3v6Entities();

        /// <summary>
        /// This Method is for Get New Order.
        /// </summary>
        /// <returns>
        /// Return List of Integer of Single Value of New Order.
        /// </returns>
        public List<int> GetNewOrder()
        {
            List<int> lsNewOreder = new List<int>();
            try
            {
                var neworder = _x3v6.ExecuteStoreQuery<int>(@"SELECT COUNT(*) FROM PRODUCTION.SORDER
                                                                WHERE ORDSTA_0 = 1 AND DLVSTA_0 = 1 AND XB_HLDSTA_0 <> 3
                                                                AND SOHTYP_0 IN ('SON','SOP')").ToList();

                if (neworder.Count() > 0)
                {
                    foreach (var item in neworder)
                    {
                        int neword = (int)item;
                        lsNewOreder.Add(neword);
                    }
                }
            }
            catch (Exception)
            {
            }
            return lsNewOreder;
        
        }

        /// <summary>
        /// This Method is for get NYWH shipped Quantity.
        /// </summary>
        /// <returns>
        /// Return List of Integer of Single Value of NYWH shipped Quantity.
        /// </returns>
        public List<int> GetNYWHShipped()
        {
            List<int> lsshipped = new List<int>();
            try
            {
                var NYWHShipped = _x3v6.ExecuteStoreQuery<int>(@"Select COUNT(*) from 
                                                                                       (
                                                                                       SELECT
                                                                                                       COUNT(shd.SDHNUM_0) as Col1
                                                                                       FROM
                                                                                                       x3v6.PRODUCTION.SORDER so
                                                                                       inner join PRODUCTION.SDELIVERY sh on sh.SOHNUM_0 = so.SOHNUM_0
                                                                                       inner join PRODUCTION.SDELIVERYD shd on shd.SDHNUM_0 = sh.SDHNUM_0
                                                                                       inner join PRODUCTION.SPACKD sp on sp.VCRNUM_0 = sh.SDHNUM_0
                                                                                       inner join x3v6.PRODUCTION.STOJOU st on st.VCRNUM_0 = sh.SDHNUM_0 and st.VCRTYP_0 = 4 and st.VCRLIN_0 = shd.SDDLIN_0
                                                                                       Where
                                                                                                       ORDSTA_0 = 2
                                                                                                       and SOHTYP_0 in ('SON','SOEXP')
                                                                                                       and CAST(sp.CREDAT_0 AS DATE) >= CAST(GETDATE() AS DATE)
                                                                                                       and sp.CREDAT_0 <= sh.SHIDAT_0
                                                                                                       and sh.CFMFLG_0 = 2 -- Validated
                                                                                                       and st.LOC_0 = 'NYWH'
                                                                                       group by
                                                                                                       shd.SDHNUM_0
                                                                                       ) NYWH").ToList();

                if (NYWHShipped.Count() > 0)
                {
                    foreach (var item in NYWHShipped)
                    {
                        int Shipped = (int)item;
                        lsshipped.Add(Shipped);
                    }
                }
            }
            catch (Exception)
            {
            }
            return lsshipped;
        }

        /// <summary>
        /// This Method is for get NYWT Shipped Quantity.
        /// </summary>
        /// <returns>
        /// Return List of Integer of Single Value of NYWT shipped Quantity.
        /// </returns>
        public List<int> GetNYWTShipped()
        {
            List<int> lsshipped = new List<int>();
            try
            {
                var NYWTShipped = _x3v6.ExecuteStoreQuery<int>(@"Select COUNT(*) from 
                                                                                       (
                                                                                       SELECT
                                                                                                       COUNT(shd.SDHNUM_0) as Col1
                                                                                       FROM
                                                                                                       x3v6.PRODUCTION.SORDER so
                                                                                       inner join PRODUCTION.SDELIVERY sh on sh.SOHNUM_0 = so.SOHNUM_0
                                                                                       inner join PRODUCTION.SDELIVERYD shd on shd.SDHNUM_0 = sh.SDHNUM_0
                                                                                       inner join PRODUCTION.SPACKD sp on sp.VCRNUM_0 = sh.SDHNUM_0
                                                                                       inner join x3v6.PRODUCTION.STOJOU st on st.VCRNUM_0 = sh.SDHNUM_0 and st.VCRTYP_0 = 4 and st.VCRLIN_0 = shd.SDDLIN_0
                                                                                       Where
                                                                                                       ORDSTA_0 = 2
                                                                                                       and SOHTYP_0 in ('SON','SOEXP')
                                                                                                       and CAST(sp.CREDAT_0 AS DATE) >= CAST(GETDATE() AS DATE)
                                                                                                       and sp.CREDAT_0 <= sh.SHIDAT_0
                                                                                                       and sh.CFMFLG_0 = 2 -- Validated
                                                                                                       and st.LOC_0 = 'NYWT'
                                                                                       group by
                                                                                                       shd.SDHNUM_0
                                                                                       ) NYWT").ToList();

                if (NYWTShipped.Count() > 0)
                {
                    foreach (var item in NYWTShipped)
                    {
                        int NYWTShip = (int)item;
                        lsshipped.Add(NYWTShip);
                    }
                }
            }
            catch (Exception)
            {
            }
            return lsshipped;
        }

        /// <summary>
        /// This Method is for Get NYWH Processing Quantity.
        /// </summary>
        /// <returns>
        /// Return list of Integer of Single Value of NYWH Processing Quantity.
        /// </returns>
        public List<int> GetNYWHProccessing()
        {
            List<int> lsProccessing = new List<int>();
            try
            {
                var NYWHProccessing = _x3v6.ExecuteStoreQuery<int>(@"SELECT COUNT(SDHNUM_0) FROM 
                                                                        (SELECT
                                                                        sh.SDHNUM_0, count(sh.SDHNUM_0) AS count_sdd
                                                                        FROM x3v6.PRODUCTION.SORDER so
                                                                        inner join PRODUCTION.SDELIVERY sh on sh.SOHNUM_0 = so.SOHNUM_0
                                                                        inner join PRODUCTION.SDELIVERYD shd on shd.SDHNUM_0 = sh.SDHNUM_0
                                                                        left join 
                                                                        (select * from x3v6.PRODUCTION.STOCK st where LOC_0 in 
                                                                        ('NYWT','NYWH') and UPDDAT_0 = 
                                                                        (select MAX(UPDDAT_0) from PRODUCTION.STOCK st1 
                                                                        where LOC_0 in ('NYWT','NYWH') and st1.ITMREF_0 = st.ITMREF_0)) as stock on stock.ITMREF_0 = shd.ITMREF_0
                                                                        where
                                                                        ORDSTA_0 = 2
                                                                        and SOHTYP_0 in ('SON','SOP')
                                                                        and ORDDAT_0 > DATEADD(DD,-7,GETDATE())
                                                                        and so.XB_HLDSTA_0 <> 3
                                                                        and DLVSTA_0 = 3
                                                                        and sh.CFMFLG_0 = 1
                                                                        and stock.LOC_0 = 'NYWH'
                                                                        group by sh.SDHNUM_0
                                                                        ) as a").ToList();

                if (NYWHProccessing.Count() > 0)
                {
                    foreach (var item in NYWHProccessing)
                    {
                        int Proccessing = (int)item;
                        lsProccessing.Add(Proccessing);
                    }
                }
            }
            catch (Exception)
            {
            }
            return lsProccessing;
        }

        /// <summary>
        /// This Method id for Get NYWTProcessing Quantity.
        /// </summary>
        /// <returns>
        /// Return list of Integer of Single Value of NYWH Processing Quantity.
        /// </returns>
        public List<int> GetNYWTProccessing()
        {
            List<int> lsProccess = new List<int>();
            try
            {
                var NYWTProccessing = _x3v6.ExecuteStoreQuery<int>(@"SELECT COUNT(SDHNUM_0) FROM
                                                                        (SELECT
                                                                        sh.SDHNUM_0, count(sh.SDHNUM_0) AS count_sdd
                                                                        FROM x3v6.PRODUCTION.SORDER so
                                                                        inner join PRODUCTION.SDELIVERY sh on sh.SOHNUM_0 = so.SOHNUM_0
                                                                        inner join PRODUCTION.SDELIVERYD shd on shd.SDHNUM_0 = sh.SDHNUM_0
                                                                        left join
                                                                        (select * from x3v6.PRODUCTION.STOCK st where LOC_0 in
                                                                        ('NYWT','NYWH') and UPDDAT_0 =
                                                                        (select MAX(UPDDAT_0) from PRODUCTION.STOCK st1
                                                                        where LOC_0 in ('NYWT','NYWH') and st1.ITMREF_0 = st.ITMREF_0)) as stock on stock.ITMREF_0 = shd.ITMREF_0
                                                                        where
                                                                        ORDSTA_0 = 2
                                                                        and SOHTYP_0 in ('SON','SOP')
                                                                        and ORDDAT_0 > DATEADD(DD,-7,GETDATE())
                                                                        and so.XB_HLDSTA_0 <> 3
                                                                        and DLVSTA_0 = 3
                                                                        and sh.CFMFLG_0 = 1
                                                                        and stock.LOC_0 = 'NYWT'
                                                                        group by sh.SDHNUM_0) as b ").ToList();

                if (NYWTProccessing.Count() > 0)
                {
                    foreach (var item in NYWTProccessing)
                    {
                        int NYWTPross = (int)item;
                        lsProccess.Add(NYWTPross);
                    }
                }
            }
            catch (Exception)
            {
            }
            return lsProccess;
        }

    }
}