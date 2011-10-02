using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using THOK.Util;
using THOK.WMS.Dao;

namespace THOK.WMS.BLL
{
    public class EntryAllot
    {
        /// <summary>
        /// ��ȡ���Է���Ĵ�λ��������
        /// </summary>
        /// <returns></returns>
        public DataSet GetAvailableCellRowFirst()
        {
            string sql = @"SELECT SUBSTRING(CELLCODE,1,6) AS AREA,SUBSTRING(CELLCODE,12,2) AS COL
                          ,[CELL_ID],[MAX_QUANTITY],[SHELFCODE] ,[CELLCODE],[CELLNAME],[CURRENTPRODUCT],U.UNITNAME AS CELLUNIT
                          ,'' AS BILLNO,0.00 AS DETAILID,'' AS PRODUCTCODE,'' AS PRODUCTNAME
                          ,'' AS UNITCODE,'' AS UNITNAME  ,0.00 AS ALLOTQUANTITY
                          ,MAX_QUANTITY-[FROZEN_IN_QTY]-QUANTITY AS AVAILABLE,[ASSIGNEDPRODUCT]
                          FROM [WMS_WH_CELL] C 
                           LEFT JOIN WMS_UNIT U ON U.UNITCODE=C.UNITCODE 
                           WHERE C.ISACTIVE='1' AND ISLOCKED='0'  AND MAX_QUANTITY-QUANTITY-FROZEN_IN_QTY>0 AND [FROZEN_IN_QTY]=0
                           AND (U.UNITNAME LIKE '%��%'or U.UNITNAME LIKE '%��%') AND AREATYPE='0'
                           ORDER BY SHELFCODE,CELLCODE";   //MAX_QUANTITY-[FROZEN_IN_QTY]-QUANTITY >0
            using (PersistentManager persistentManager = new PersistentManager())
            {
                EntryAllotDao dao = new EntryAllotDao();
                return dao.GetData(sql);
            }
        }
        //*************
        #region ��ȡ�ݴ��̵���λ��������
        public DataSet GetAvailableCellRowFirst3()
        {
            string sql = @"SELECT SUBSTRING(CELLCODE,1,6) AS AREA,SUBSTRING(CELLCODE,12,2) AS COL
                          ,[CELL_ID],[MAX_QUANTITY],[SHELFCODE] ,[CELLCODE],[CELLNAME],[CURRENTPRODUCT],U.UNITNAME AS CELLUNIT
                          ,'' AS BILLNO,0.00 AS DETAILID,'' AS PRODUCTCODE,'' AS PRODUCTNAME
                          ,'' AS UNITCODE,'' AS UNITNAME  ,0.00 AS ALLOTQUANTITY
                          ,MAX_QUANTITY-[FROZEN_IN_QTY]-QUANTITY AS AVAILABLE,[ASSIGNEDPRODUCT]
                          FROM [WMS_WH_CELL] C 
                           LEFT JOIN WMS_UNIT U ON U.UNITCODE=C.UNITCODE 
                           WHERE C.ISACTIVE='1' AND ISLOCKED='0'  AND MAX_QUANTITY-QUANTITY-FROZEN_IN_QTY>0 AND [FROZEN_IN_QTY]=0
                           AND AREATYPE='3'
                           ORDER BY SHELFCODE,CELLCODE";   //MAX_QUANTITY-[FROZEN_IN_QTY]-QUANTITY >0
            using (PersistentManager persistentManager = new PersistentManager())
            {
                EntryAllotDao dao = new EntryAllotDao();
                return dao.GetData(sql);
            }
        }
        #endregion
        #region
        /// <summary>
        /// ��ȡ�ɷ������̹�λ��������
        /// </summary>
        /// <returns></returns>
        public DataSet GetAvailableCellRowFirst1()
        {
            string sql = @"SELECT SUBSTRING(CELLCODE,1,6) AS AREA,SUBSTRING(CELLCODE,12,2) AS COL
                          ,[CELL_ID],[MAX_QUANTITY],[SHELFCODE] ,[CELLCODE],[CELLNAME],[CURRENTPRODUCT],U.UNITNAME AS CELLUNIT
                          ,'' AS BILLNO,0.00 AS DETAILID,'' AS PRODUCTCODE,'' AS PRODUCTNAME
                          ,'' AS UNITCODE,'' AS UNITNAME  ,0.00 AS ALLOTQUANTITY
                          ,MAX_QUANTITY-[FROZEN_IN_QTY]-QUANTITY AS AVAILABLE,[ASSIGNEDPRODUCT]
                          FROM [WMS_WH_CELL] C 
                           LEFT JOIN WMS_UNIT U ON U.UNITCODE=C.UNITCODE 
                           WHERE C.ISACTIVE='1' AND ISLOCKED='0' AND MAX_QUANTITY-QUANTITY-FROZEN_IN_QTY>0 
                           AND U.UNITNAME not LIKE '%��%' AND U.UNITNAME not like '%��%' AND AREATYPE='1'
                           ORDER BY SHELFCODE,CELLCODE";   //MAX_QUANTITY-[FROZEN_IN_QTY]-QUANTITY >0
            using (PersistentManager persistentManager = new PersistentManager())
            {
                EntryAllotDao dao = new EntryAllotDao();
                return dao.GetData(sql);
            }
        }
        /// <summary>
        /// ��ȡ�ɷ������̹�λ������������
        /// </summary>
        /// <returns></returns>
        public DataSet GetAvailableCellColFirst1()
        {
            string sql = "SELECT SUBSTRING(CELLCODE,1,6) AS AREA,SUBSTRING(CELLCODE,12,2) AS COL" +
                         ",[CELL_ID],[MAX_QUANTITY],[SHELFCODE] ,[CELLCODE],[CELLNAME],[CURRENTPRODUCT],U.UNITNAME AS CELLUNIT" +
                        " ,'' AS BILLNO,0.00 AS DETAILID,'' AS PRODUCTCODE,'' AS PRODUCTNAME" +
                        ",'' AS UNITCODE,'' AS UNITNAME  ,0.00 AS ALLOTQUANTITY" +
                        " ,MAX_QUANTITY-[FROZEN_IN_QTY]-QUANTITY AS AVAILABLE,[ASSIGNEDPRODUCT]" +
                        " FROM [WMS_WH_CELL] C " +
                        " LEFT JOIN WMS_UNIT U ON U.UNITCODE=C.UNITCODE " +
                        " WHERE C.ISACTIVE='1' AND ISLOCKED='0'  AND MAX_QUANTITY-QUANTITY-FROZEN_IN_QTY>0" +
                        " AND U.UNITNAME not LIKE '%��%' AND U.UNITNAME not like '%��%' AND AREATYPE='1'" +
                        " ORDER BY SUBSTRING(CELLCODE,1,6), SUBSTRING(CELLCODE,12,2),CELLCODE";
            using (PersistentManager persistentManager = new PersistentManager())
            {
                EntryAllotDao dao = new EntryAllotDao();
                return dao.GetData(sql);
            }
        }
        #endregion

        #region ��ȡ�ݴ��̵���λ������������
        public DataSet GetAvailableCellColFirst3()
        {
            string sql = "SELECT SUBSTRING(CELLCODE,1,6) AS AREA,SUBSTRING(CELLCODE,12,2) AS COL" +
                         ",[CELL_ID],[MAX_QUANTITY],[SHELFCODE] ,[CELLCODE],[CELLNAME],[CURRENTPRODUCT],U.UNITNAME AS CELLUNIT" +
                        " ,'' AS BILLNO,0.00 AS DETAILID,'' AS PRODUCTCODE,'' AS PRODUCTNAME" +
                        ",'' AS UNITCODE,'' AS UNITNAME  ,0.00 AS ALLOTQUANTITY" +
                        " ,MAX_QUANTITY-[FROZEN_IN_QTY]-QUANTITY AS AVAILABLE,[ASSIGNEDPRODUCT]" +
                        " FROM [WMS_WH_CELL] C " +
                        " LEFT JOIN WMS_UNIT U ON U.UNITCODE=C.UNITCODE " +
                        " WHERE C.ISACTIVE='1' AND ISLOCKED='0' AND MAX_QUANTITY-QUANTITY-FROZEN_IN_QTY>0 AND [FROZEN_IN_QTY]=0" +
                        " AND AREATYPE='3' " +
                        " ORDER BY SUBSTRING(CELLCODE,1,6), SUBSTRING(CELLCODE,12,2),CELLCODE";
            using (PersistentManager persistentManager = new PersistentManager())
            {
                EntryAllotDao dao = new EntryAllotDao();
                return dao.GetData(sql);
            }
        }
        #endregion
        /// <summary>
        /// ��ȡ���Է���Ĵ�λ������������
        /// </summary>
        /// <returns></returns>
        public DataSet GetAvailableCellColFirst()
        {
            string sql = "SELECT SUBSTRING(CELLCODE,1,6) AS AREA,SUBSTRING(CELLCODE,12,2) AS COL" +
                         ",[CELL_ID],[MAX_QUANTITY],[SHELFCODE] ,[CELLCODE],[CELLNAME],[CURRENTPRODUCT],U.UNITNAME AS CELLUNIT" +
                        " ,'' AS BILLNO,0.00 AS DETAILID,'' AS PRODUCTCODE,'' AS PRODUCTNAME" +
                        ",'' AS UNITCODE,'' AS UNITNAME  ,0.00 AS ALLOTQUANTITY" +
                        " ,MAX_QUANTITY-[FROZEN_IN_QTY]-QUANTITY AS AVAILABLE,[ASSIGNEDPRODUCT]" +
                        " FROM [WMS_WH_CELL] C " +
                        " LEFT JOIN WMS_UNIT U ON U.UNITCODE=C.UNITCODE " +
                        " WHERE C.ISACTIVE='1' AND ISLOCKED='0' AND MAX_QUANTITY-QUANTITY-FROZEN_IN_QTY>0 AND [FROZEN_IN_QTY]=0" +
                        " AND (U.UNITNAME LIKE '%��%'or U.UNITNAME LIKE '%��%') AND AREATYPE='0' " +
                        " ORDER BY SUBSTRING(CELLCODE,1,6), SUBSTRING(CELLCODE,12,2),CELLCODE";
            using (PersistentManager persistentManager = new PersistentManager())
            {
                EntryAllotDao dao = new EntryAllotDao();
                return dao.GetData(sql);
            }
        }

        /// <summary>
        /// ��ȡ�մ�λ����δ�����κξ���
        /// </summary>
        /// <returns></returns>
        public DataSet GetNullCell()
        {
            string sql = "SELECT WH_CODE,AREACODE, [CELL_ID],C.[SHELFCODE] ,C.[CELLCODE],C.[CELLNAME],U.UNITNAME AS CELLUNIT" +
                            " ,'' AS BILLNO,0.00 AS DETAILID,'' AS PRODUCTCODE,'' AS PRODUCTNAME"+
                            " ,'' AS UNITCODE,'' AS UNITNAME  ,0.00 AS ALLOTQUANTITY"+
                            " ,[ASSIGNEDPRODUCT],MAX_QUANTITY-[FROZEN_IN_QTY]-QUANTITY AS AVAILABLE,C.MAX_QUANTITY" +
                            " FROM [WMS_WH_CELL] C"+
                            " LEFT JOIN WMS_UNIT U ON U.UNITCODE=C.UNITCODE"+
                            " LEFT JOIN WMS_WH_SHELF S ON S.SHELFCODE=C.SHELFCODE" +
                            " WHERE C.ISACTIVE='1' AND ISLOCKED='0' AND QUANTITY=0  AND [FROZEN_IN_QTY]=0" +
                            " ORDER BY C.SHELFCODE,C.CELLCODE";
            using (PersistentManager persistentManager = new PersistentManager())
            {
                EntryAllotDao dao = new EntryAllotDao();
                return dao.GetData(sql);
            }
        }

        /// <summary>
        /// ��ȡ����ձ�
        /// </summary>
        /// <returns></returns>
        public DataTable GetEmptyAllotTable()
        {
            using (PersistentManager persistentManager = new PersistentManager())
            {
                string sql = "SELECT * FROM WMS_IN_ALLOT  where 1=0";
                EntryAllotDao dao = new EntryAllotDao();
                return dao.GetData(sql).Tables[0];
            }
        }
        public bool UpdateCell(string max_Quantity,string unitCode,string cellCode)
        {
            using (PersistentManager persistentManager = new PersistentManager())
            {
                EntryAllotDao dao = new EntryAllotDao();
                string sql = string.Format("update WMS_WH_CELL SET MAX_QUANTITY='{0}',UNITCODE='{1}' WHERE CELLCODE='{2}' AND AREATYPE<>'1' AND AREATYPE<>'4' ;"
               , max_Quantity, unitCode, cellCode);
                dao.SetData(sql);
                return true;
            }
        }
        /// <summary>
        /// ���������,���»�λ��ⶳ����
        /// </summary>
        /// <param name="tableAllotment"></param>
        /// <returns></returns>
        public bool SaveAllotment(DataTable tableAllotment)
        {
            using (PersistentManager persistentManager = new PersistentManager())
            {
                EntryAllotDao dao = new EntryAllotDao();
                dao.BatchInsertAllotment(tableAllotment);
                StringBuilder sb = new StringBuilder();
                foreach (DataRow r in tableAllotment.Rows)
                {
                    sb.Append(string.Format("update WMS_WH_CELL SET FROZEN_IN_QTY=FROZEN_IN_QTY+'{0}',UNITCODE= '{1}' WHERE CELLCODE='{2}' ;"
                                               , r["QUANTITY"].ToString(),r["UNITCODE"].ToString(), r["CELLCODE"].ToString()));
                }
                try
                {
                    dao.SetData(sb.ToString()); return true;
                }
                catch
                {
                    foreach (DataRow r2 in tableAllotment.Rows)
                    {
                        sb = new StringBuilder();
                        sb.Append(string.Format("Delete from WMS_IN_ALLOT WHERE BILLNO='{0}';",r2["BILLNO"].ToString()));
                    }
                    dao.SetData(sb.ToString()); return true;
                }
                
            }
        }

        /// <summary>
        /// ɾ��������,������ⵥ״̬,  ���»�λ��ⶳ����
        /// </summary>
        /// <param name="BillNO"></param>
        /// <returns></returns>
        public bool DeleteAllotment(string BillNo)
        {
            using (PersistentManager persistentManager = new PersistentManager())
            {
                EntryAllotDao dao = new EntryAllotDao();
                DataSet ds = dao.GetData("SELECT * FROM WMS_IN_ALLOT WHERE BILLNO='" + BillNo + "'");
                StringBuilder sb = new StringBuilder();
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    sb.Append(string.Format("update WMS_WH_CELL SET FROZEN_IN_QTY=FROZEN_IN_QTY-{0} WHERE CELLCODE='{1}' ;"
                                               , r["QUANTITY"].ToString(), r["CELLCODE"].ToString()));
                }
                sb.Append(string.Format("Delete from WMS_IN_ALLOT WHERE BILLNO='{0}'; update WMS_IN_BILLMASTER SET STATUS='2' where BILLNO='{0}'", BillNo));
                dao.SetData(sb.ToString());
                return true;
            }
        }


        private string strTableView = "V_WMS_IN_ALLOT";
        private string strPrimaryKey = "ID";
        //private string strOrderByFields = "BILLNO,ID";
        private string strQueryFields = "*";

        public DataSet QueryAllotment(int pageIndex, int pageSize, string filter, string OrderByFields)
        {
            using (PersistentManager persistentManager = new PersistentManager())
            {
                EntryAllotDao dao = new EntryAllotDao();
                return dao.Query(strTableView, strPrimaryKey, strQueryFields, pageIndex, pageSize, OrderByFields, filter, strTableView);
            }
        }

        public int GetRowCount(string filter)
        {
            using (PersistentManager persistentManager = new PersistentManager())
            {
                EntryAllotDao dao = new EntryAllotDao();
                return dao.GetRowCount(strTableView, filter);
            }
        }
        //��ȡ��Ȼ�����Լ���Ȼ��λ�洢����
        public DataSet QueryJian2(string productCode)
        {
            using (PersistentManager persistentManager = new PersistentManager())
            {
                EntryAllotDao dao = new EntryAllotDao();
                return dao.GetData("select STANDARDRATE,MAXCELLPIECE from WMS_UNIT U left join WMS_PRODUCT P ON U.UNITCODE=P.JIANCODE where PRODUCTCODE='" + productCode + "'");
            }
        }
        //��ȡ��Ȼ�����Լ���Ȼ��λ�洢����
        public DataSet QueryTiao2(string productCode)
        {
            using (PersistentManager persistentManager = new PersistentManager())
            {
                EntryAllotDao dao = new EntryAllotDao();
                return dao.GetData("select STANDARDRATE,MAXCELLPIECE from WMS_UNIT U left join WMS_PRODUCT P ON U.UNITCODE=P.TIAOCODE where PRODUCTCODE='" + productCode + "'");
            }
        }
        public DataSet QueryProductCode(string productCode)
        {
            using (PersistentManager persistentManager = new PersistentManager())
            {
                EntryAllotDao dao = new EntryAllotDao();
                return dao.GetData("select JIANCODE,TIAOCODE,MAXCELLPIECE from  WMS_PRODUCT  where PRODUCTCODE='" + productCode + "'");
            }
        }
        //��ȡ��λ����
        public DataSet QueryUnitName(string unitCode)
        {
            using (PersistentManager persistentManager = new PersistentManager())
            {
                EntryAllotDao dao = new EntryAllotDao();
                return dao.GetData("SELECT UNITNAME,STANDARDRATE FROM [WMS_UNIT] WHERE UNITCODE='" + unitCode + "'");
            }
        }
    }
}
