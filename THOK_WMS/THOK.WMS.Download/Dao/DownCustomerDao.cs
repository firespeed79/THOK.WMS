using System;
using System.Collections.Generic;
using System.Text;
using THOK.Util;
using System.Data;

namespace THOK.WMS.Download.Dao
{
    public class DownCustomerDao : BaseDao
    {
        #region ���ؿͻ���Ϣ

        /// <summary>
        /// ���ؿ⻧��Ϣ
        /// </summary>
        /// <returns></returns>
        public DataTable GetCustomerInfo()
        {
            string sql = "SELECT * FROM IC.V_WMS_CUSTOMER ";
            return this.ExecuteQuery(sql).Tables[0];
        }

        /// <summary>
        /// ���ݿͻ��������ؿ⻧��Ϣ
        /// </summary>
        /// <returns></returns>
        public DataTable GetCustomerInfo(string customerCode)
        {
            string sql = string.Format("SELECT * FROM IC.V_WMS_CUSTOMER WHERE {0}", customerCode);
            return this.ExecuteQuery(sql).Tables[0];
        }

        #endregion

        #region ��ѯ�ִ��ͻ�����

        /// <summary>
        /// ��ѯ�ͻ�����
        /// </summary>
        /// <returns></returns>
        public DataTable GetCustomerCode()
        {
            string sql = "SELECT CUST_CODE FROM DWV_IORG_CUSTOMER";
            return this.ExecuteQuery(sql).Tables[0];
        }

        /// <summary>
        /// ������ݵ����ݿ�
        /// </summary>
        /// <param name="customerDt"></param>
        public void Insert(DataSet customerDs)
        {
            this.BatchInsert(customerDs.Tables["DWV_IINF_BRAND"], "DWV_IORG_CUSTOMER");
        }

        #endregion

    }
}
