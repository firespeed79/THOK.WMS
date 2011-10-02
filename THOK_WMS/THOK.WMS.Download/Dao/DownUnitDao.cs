using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using THOK.Util;

namespace THOK.WMS.Download.Dao
{
    public class DownUnitDao : BaseDao
    {
        #region ��Ӫϵͳ�����ص�λ����

        /// <summary>
        /// ���ص�λ��Ϣ
        /// </summary>
        /// <returns></returns>
        public DataTable GetUnitInfo(string unitCode)
        {
            string sql = string.Format("SELECT * FROM IC.V_WMS_BRAND_UNIT WHERE {0}", unitCode);
            return this.ExecuteQuery(sql).Tables[0];
        }

        /// <summary>
        /// ��ѯ������λϵ�б�
        /// </summary>
        /// <param name="ulistCode"></param>
        /// <returns></returns>
        public DataTable GetBrandUlistInfo(string ulistCode)
        {
            string sql = string.Format("SELECT * FROM IC.V_WMS_BRAND_ULIST WHERE {0}", ulistCode);
            return this.ExecuteQuery(sql).Tables[0];
        }

        /// <summary>
        /// �����ص����ݲ������ݿ�
        /// </summary>
        /// <param name="ds"></param>
        public void InsertUnit(DataSet ds)
        {
            BatchInsert(ds.Tables["WMS_UNIT_INSERT"], "WMS_UNIT");
        }

        public void InsertUlist(DataTable ulistCodeTable)
        {
            BatchInsert(ulistCodeTable, "WMS_BRAND_ULIST");
        }

        /// <summary>
        /// �����ص��м�����ݲ������ݿ�
        /// </summary>
        /// <param name="ds"></param>
        public void InsertUnitProduct(DataSet ds)
        {
            BatchInsert(ds.Tables["WMS_UNIT_PRODUCT"], "WMS_UNIT_PRODUCT");
        }

        /// <summary>
        /// ��ѯ�ִ���λϵ�б��
        /// </summary>
        /// <returns></returns>
        public DataTable GetUlistCode()
        {
            string sql = "SELECT BRAND_ULIST_CODE FROM WMS_BRAND_ULIST";
            return this.ExecuteQuery(sql).Tables[0];
        }

        /// <summary>
        /// ��ѯ�ִ���λ���
        /// </summary>
        /// <returns></returns>
        public DataTable GetUnitCode()
        {
            string sql = "SELECT UNITCODE FROM WMS_UNIT";
            return this.ExecuteQuery(sql).Tables[0];
        }


        public DataTable GetUnitProduct()
        {
            string sql = "SELECT PRODUCTCODE FROM WMS_UNIT_PRODUCT WHERE UNITCODE LIKE '04%'";
            return this.ExecuteQuery(sql).Tables[0];
        }

        /// <summary>
        /// �������λ����λ
        /// </summary>
        /// <returns></returns>
        public DataTable GetProductByUnitCodeTiao()
        {
            string sql = "SELECT * FROM DBO.WMS_UNIT WHERE UNITNAME LIKE '��%'";
            return this.ExecuteQuery(sql).Tables[0];
        }

        /// <summary>
        /// ���ݼ�����λϵ�б�Ų�ѯ����
        /// </summary>
        /// <param name="ulistCode"></param>
        /// <returns></returns>
        public DataTable FindUnitCodeByUlistCode(string ulistCode)
        {
            string sql = string.Format("SELECT * FROM WMS_BRAND_ULIST WHERE BRAND_ULIST_CODE='{0}'", ulistCode);
            return this.ExecuteQuery(sql).Tables[0];
        }
     
        #endregion

        #region ��Ӫϵͳ�����ص�λ����-�����˳�

        /// <summary>
        /// ���ص�λ��Ϣ
        /// </summary>
        /// <returns></returns>
        public DataTable GetUnitInfo()
        {
            string sql = "SELECT BRAND_CODE,BRAND_UNIT_CODE,BRAND_UNIT_NAME,COUNT FROM V_WMS_BRAND_UNIT";
            return this.ExecuteQuery(sql).Tables[0];
        }

        /// <summary>
        /// �������λ��Ϣ
        /// </summary>
        /// <returns></returns>
        public DataTable GetProductByUnitCode(string unitcode, string product)
        {
            string sql = string.Format("SELECT * FROM WMS_UNIT_PRODUCT WHERE UNITCODE LIKE '{0}%' AND PRODUCTCODE='{1}'", unitcode, product);
            return this.ExecuteQuery(sql).Tables[0];
        }
        #endregion
    }
}
