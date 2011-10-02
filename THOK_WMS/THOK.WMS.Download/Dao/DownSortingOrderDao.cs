using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using THOK.Util;

namespace THOK.WMS.Download.Dao
{
    public class DownSortingOrderDao : BaseDao
   {
       #region ��Ӫ��ϵͳ���طּ���Ϣ

       /// <summary>
       /// �����������طּ𶩵�������Ϣ
       /// </summary>
       /// <returns></returns>
       public DataTable GetSortingOrder(string orderid)
       {
           string sql = string.Format("SELECT * FROM IC.V_WMS_SORT_ORDER WHERE {0} AND QUANTITY_SUM>0", orderid);
           return this.ExecuteQuery(sql).Tables[0];
       }

       /// <summary>
       /// �����������طּ𶩵���ϸ����Ϣ
       /// </summary>
       /// <returns></returns>
       public DataTable GetSortingOrderDetail(string orderid)
       {
           string sql = string.Format("SELECT * FROM IC.V_WMS_SORT_ORDER_DETAIL WHERE {0} ", orderid);
           return this.ExecuteQuery(sql).Tables[0];
       }

       /// <summary>
       /// �������зּ𶩵���ϸ����Ϣ
       /// </summary>
       /// <returns></returns>
       public DataTable GetSortingOrderDetail()
       {
           string sql = " SELECT * FROM IC.V_WMS_SORT_ORDER_DETAIL";
           return this.ExecuteQuery(sql).Tables[0];
       }

       /// <summary>
       /// ����ǰ����ǰʱ������֮�ڵ�����
       /// </summary>
       public void DeleteOrder()
       {
           string dtOrder = DateTime.Now.AddDays(-2d).ToString("yyyyMMdd");
           //DateTime historyDate = dtOrder.AddDays(-8d).ToShortDateString();
           string sql = string.Format("DELETE FROM DWV_OUT_ORDER WHERE ORDER_DATE < '{0}'", dtOrder);
           this.ExecuteNonQuery(sql);
           sql = "DELETE FROM DWV_OUT_ORDER WHERE ORDER_DATE < '{0}'";
           this.ExecuteNonQuery(sql);
       }

       #endregion

       #region ��ѯ�ִ��ּ���Ϣ

       public void InsertSortingOrder(DataTable masertdt, DataTable detaildt)
       {
           BatchInsert(masertdt, "DWV_OUT_ORDER");
           BatchInsert(detaildt, "DWV_OUT_ORDER_DETAIL");
       }

       /// <summary>
       /// ����������ݵ��� DWV_OUT_ORDER
       /// </summary>
       /// <param name="ds"></param>
       public void InsertSortingOrder(DataSet ds)
       {
           BatchInsert(ds.Tables["DWV_OUT_ORDER"], "DWV_OUT_ORDER");
       }

       /// <summary>
       /// �����ϸ�����ݵ��� DWV_OUT_ORDER_DETAIL
       /// </summary>
       /// <param name="ds"></param>
       public void InsertSortingOrderDetail(DataSet ds)
       {
           BatchInsert(ds.Tables["DWV_OUT_ORDER_DETAIL"], "DWV_OUT_ORDER_DETAIL");
       }

       /// <summary>
       /// ��ѯ3��֮�ڵ�����
       /// </summary>
       /// <returns></returns>
       public DataTable GetOrderId()
       {
           string sql = " SELECT ORDER_ID FROM DWV_OUT_ORDER WHERE ORDER_DATE>DATEADD(DAY, -5, CONVERT(VARCHAR(14), GETDATE(), 112)) ";
           return this.ExecuteQuery(sql).Tables[0];
       }

       #endregion

   }
}
