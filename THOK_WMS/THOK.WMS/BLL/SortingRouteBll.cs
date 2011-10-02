using System;
using System.Collections.Generic;
using System.Text;
using THOK.Util;
using THOK.WMS.Dao;
using System.Data;

namespace THOK.WMS.BLL
{
   public class SortingRouteBll
    {
       private string strTableView = "DWV_OUT_DELIVER_LINE";
       private string strPrimaryKey = "DELIVER_LINE_CODE";
       private string strQueryFields = "*";


       /// <summary>
       /// ��ҳ��ѯ
       /// </summary>
       /// <param name="pageIndex"></param>
       /// <param name="pageSize"></param>
       /// <returns></returns>
       public DataSet QuerySortingRoute(int pageIndex, int pageSize,string file,string isZhi)
       {
           DateTime dateTime = DateTime.Now;
           string date = Convert.ToString(dateTime.ToString("yyyyMMdd"));
           using (PersistentManager persistentManager = new PersistentManager())
           {
               SortingRouteDao dao = new SortingRouteDao();
               return dao.QuerySortingRoute(pageIndex, pageSize,file,date,isZhi);
           }
       }

       /// <summary>
       /// ��ѯδ�ϱ��ķּ��������ͽ��
       /// </summary>
       /// <returns></returns>
       public DataTable QuerySortingQuantity()
       {
           using (PersistentManager persistentManager = new PersistentManager())
           {
               SortingRouteDao dao = new SortingRouteDao();
               return dao.QuerySortingQuantity();
           }
       }

       /// <summary>
       /// ��ѯ��¼
       /// </summary>
       /// <param name="filter"></param>
       /// <returns></returns>
       public int GetRowCount(string filter,string isZhi)
       {
           DateTime dateTime = DateTime.Now;
           string date = Convert.ToString(dateTime.ToString("yyyyMMdd"));
           using (PersistentManager persistentManager = new PersistentManager())
           {
               SortingRouteDao dao = new SortingRouteDao();
               return dao.GetRowCount(filter,date,isZhi);
           }
       }


       /// <summary>
       /// ������·��ţ����ķ���״̬
       /// </summary>
       /// <param name="RouteCode"></param>
       public void UpdateRouteAllotState(string RouteCode,string isAllot)
       {
           using (PersistentManager persistentManager = new PersistentManager())
           {
               SortingRouteDao dao = new SortingRouteDao();
               dao.UpdateRouteAllotState(RouteCode,isAllot);
           }
       }

       /// <summary>
       /// ��ѯÿ����·��ÿ�����̵�����
       /// </summary>
       /// <param name="file"></param>
       /// <returns></returns>
       public DataSet QuerySortingRouteDetail(string file)
       {
           using (PersistentManager persistentManager = new PersistentManager())
           {
               SortingRouteDao dao = new SortingRouteDao();
               return dao.QuerySortingRouteDetail(file);
           }
       }
    }
}
