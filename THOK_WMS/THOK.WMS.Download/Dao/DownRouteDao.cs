using System;
using System.Collections.Generic;
using System.Text;
using THOK.Util;
using System.Data;

namespace THOK.WMS.Download.Dao
{
    public class DownRouteDao : BaseDao
    {
        #region �����ͻ���·��Ϣ

        /// <summary>
        /// �����ͻ���·����Ϣ
        /// </summary>
        public DataTable GetRouteInfo(string routeCodeList)
        {
            string sql = string.Format("SELECT * FROM IC.V_WMS_DELIVER_LINE WHERE {0}",routeCodeList);
            return this.ExecuteQuery(sql).Tables[0];
        }

        /// <summary>
        /// �����ͻ���·����Ϣ
        /// </summary>
        public DataTable GetRouteInfo()
        {
            string sql = "SELECT * FROM IC.V_WMS_DELIVER_LINE ";
            return this.ExecuteQuery(sql).Tables[0];
        }

        /// <summary>
        /// ��ѯ��·���е���·����
        /// </summary>
        /// <returns></returns>
        public DataTable GetRouteCode()
        {
            string sql = " SELECT DELIVER_LINE_CODE FROM DWV_OUT_DELIVER_LINE";
            return this.ExecuteQuery(sql).Tables[0];
        }

        /// <summary>
        /// ����·��Ϣ�������ݿ�
        /// </summary>
        /// <param name="ds"></param>
        public void Insert(DataSet ds)
        {
            BatchInsert(ds.Tables["DWV_OUT_DELIVER_LINE"], "DWV_OUT_DELIVER_LINE");
        }

        /// <summary>
        /// ����ͻ���·��
        /// </summary>
        public void Delete()
        {
            string sql = "DELETE DWV_OUT_DELIVER_LINE";
            this.ExecuteNonQuery(sql);
        }

        #endregion
    }
}
