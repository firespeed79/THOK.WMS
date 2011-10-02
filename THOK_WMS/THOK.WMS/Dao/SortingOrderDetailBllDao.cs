using System;
using System.Collections.Generic;
using System.Text;
using THOK.Util;
using System.Data;

namespace THOK.WMS.Dao
{
   public class SortingOrderDetailBllDao:BaseDao
    {


        /// <summary>
        /// ��ҳ��ѯ��ϸ
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="tableName"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public DataSet Query(string sql, string tableName, int pageIndex, int pageSize)
        {
            int start = (pageIndex - 1) * pageSize;
            return ExecuteQuery(sql, tableName, start, pageSize);
        }


       /// <summary>
       /// ͨ������id�޸ķ����ֶ�
       /// </summary>
       /// <param name="sortingCode"></param>
       /// <param name="orderId"></param>
       /// <returns></returns>
       public string UpdateOrderDeatil(string sortingCode, string orderId)
       {
           string tag = "true";
           try
           {
               string sql = string.Format("UPDATE DWV_OUT_ORDER_DETAIL SET SORTING_CODE ='{0}' WHERE ORDER_ID IN({1})", sortingCode, orderId);
               this.ExecuteNonQuery(sql);
           }
           catch (Exception e)
           {
               return tag = e.Message;
           }
           return tag;
       }

       /// <summary>
       /// ��������idɾ����ϸ������
       /// </summary>
       /// <param name="orderid"></param>
       public void DeleteOrderId(string orderid)
       {
           string sql = string.Format("DELETE DWV_OUT_ORDER_DETAIL WHERE ORDER_ID IN({0})",orderid);
           this.ExecuteNonQuery(sql);
       }
    }
}
