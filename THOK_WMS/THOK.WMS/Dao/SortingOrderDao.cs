using System;
using System.Collections.Generic;
using System.Text;
using THOK.Util;
using System.Data;

namespace THOK.WMS.Dao
{
   public class SortingOrderDao:BaseDao
    {
       /// <summary>
       /// һ������һ��������ѯ�ּ𶩵�����
       /// </summary>
       /// <param name="TableViewName"></param>
       /// <param name="filter"></param>
       /// <returns></returns>
       public int GetRowCount(string TableViewName, string filter)
       {
           string sql = string.Format("SELECT COUNT(*) FROM {0}" +
                                        " WHERE {1} "
                                        , TableViewName, filter);
           return (int)ExecuteScalar(sql);
       }


       /// <summary>
       /// ��ҳ��ѯ���ݣ�ָ�����ݼ�����TableName
       /// </summary>
       /// <param name="TableViewName">��������ͼ��</param>
       /// <param name="PrimaryKey">�������ֶ�����</param>
       /// <param name="QueryFields">��ѯ�ֶ��ַ������ֶ����ƶ��Ÿ���</param>
       /// <param name="pageIndex">��ѯҳ��</param>
       /// <param name="pageSize">ҳ���С</param>
       /// <param name="orderBy">�����ֶκͷ�ʽ</param>
       /// <param name="filter">��ѯ����</param>
       /// <param name="strTableName">�������ݼ����ı���</param>
       /// <returns>����DataSet</returns>
       public DataSet FindExecuteQuery(string TableViewName, string PrimaryKey, string QueryFields, int pageIndex, int pageSize, string orderBy, string filter, string strTableName)
       {
           //string bei = ",case when ISACTIVE=1 then 'ʹ��' else 'ͣ��' end as SORTINGSTATE ";
           int preRec = (pageIndex - 1) * pageSize;
           string sql = string.Format("select top {4} {2} from {0} " +
                                       " where {1} not in ( select top {3} {1} from {0} where {6} order by {5}) " +
                                       " and {6} order by {5}"
                                       , TableViewName, PrimaryKey, QueryFields, preRec.ToString(), pageSize.ToString(), orderBy, filter);

           return ExecuteQuery(sql).Tables[0].DataSet;
       }

       /// <summary>
       /// ��������������Ϣ
       /// </summary>
       public void deleteOrderDate(string date)
       {
           string sql = string.Format("DELETE DWV_OUT_ORDER WHERE ORDER_DATE ='{0}'", date);
           this.ExecuteNonQuery(sql);
       }

       public DataTable QueryDate(string date)
       {
           string sql = string.Format("SELECT * FROM DWV_OUT_ORDER WHERE ORDER_DATE='{0}'",date);
           return this.ExecuteQuery(sql).Tables[0];
       }

       /// <summary>
       /// ������·��ź�ʱ���ѯ�����Id
       /// </summary>
       /// <param name="RouteCode"></param>
       /// <returns></returns>
       public DataTable QueryOrderId(string RouteCode,string orderDate)
       {
           string sql = string.Format("SELECT ORDER_ID FROM DWV_OUT_ORDER WHERE DELIVER_LINE_CODE IN ({0}) AND ORDER_DATE IN({1})", RouteCode,orderDate);
           return this.ExecuteQuery(sql).Tables[0];
       
       }


       /// <summary>
       ///������·����޸Ķ����������
       /// </summary>
       /// <param name="SortingCode"></param>
       /// <param name="routeCode"></param>
       public void UpdateOrderMaster(string SortingCode, string routeCode,string orderDate)
       {
           string sql = string.Format("UPDATE DWV_OUT_ORDER SET SORTING_CODE ='{0}' WHERE DELIVER_LINE_CODE IN({1}) AND ORDER_DATE IN({2})", SortingCode, routeCode, orderDate);
           this.ExecuteNonQuery(sql);
       }

    }
}
