using System;
using System.Collections.Generic;
using System.Text;
using THOK.Util;
using System.Data;
using THOK.WMS.Dao;

namespace THOK.WMS.BLL
{
    public class Balance
    {
        public void ExecBalance(string wh_code,DateTime settleDate,string type)
        {
            using (PersistentManager persistentManager = new PersistentManager())
            {
                BalanceDao dao = new BalanceDao();
                StoredProcParameter para = new StoredProcParameter();
                para.AddParameter("wh_code", wh_code, DbType.String);
                para.AddParameter("day", settleDate, DbType.Date);
                para.AddParameter("type", type, DbType.String);
                dao.ExecProc("cp_DailyBalance", para);
            }
        }

        //��ѯ�Ѿ��ս������
        public DataSet QueryBalanceList(int pageIndex, int pageSize, string filter)
        {
            using (PersistentManager persistentManager = new PersistentManager())
            {
                BalanceDao dao = new BalanceDao();
                string sql = string.Format("select * FROM V_WMS_BALANCELIST WHERE {0} ORDER BY SETTLEDATE DESC", filter);
                return dao.Query(sql, "V_WMS_BALANCELIST", pageIndex, pageSize);
            }
        }

        public int GetBalanceListRowCount(string filter)
        {
            using (PersistentManager persistentManager = new PersistentManager())
            {
                BalanceDao dao = new BalanceDao();
                return dao.GetRowCount("V_WMS_BALANCELIST", filter);
            }
        }

        //��ѯ�ս���
        public DataSet QueryDailyBalance(int pageIndex, int pageSize, string filter)
        {
            using (PersistentManager persistentManager = new PersistentManager())
            {
                BalanceDao dao = new BalanceDao();
                return dao.Query("V_WMS_DAILYBALANCE", "ID", "*", pageIndex, pageSize, "PRODUCTCODE,SETTLEDATE", filter, "WMS_DAILYBALANCE");
            }
        }

        public int GetRowCount(string filter)
        {
            using (PersistentManager persistentManager = new PersistentManager())
            {
                BalanceDao dao = new BalanceDao();
                return dao.GetRowCount("V_WMS_DAILYBALANCE", filter);
            }
        }

        /// <summary>
        /// ����������ѯ���вֿ��浼��Execl
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public DataTable QueryStorageGeneralExecl(string file)
        {
            using (PersistentManager persistentManager = new PersistentManager())
            {
                BalanceDao dao = new BalanceDao();
                string sql = string.Format("SELECT * FROM V_WMS_DAILYBALANCE WHERE {0}", file);
                return dao.GetData(sql).Tables[0];
            }
        }

        //��ѯ�ֿ�������
        public DataSet QueryStorageGeneralAccount(int pageIndex, int pageSize, string filter)
        {
            using (PersistentManager persistentManager = new PersistentManager())
            {
                BalanceDao dao = new BalanceDao();
                return dao.Query("V_WMS_DAILYBALANCE", "ID", "*", pageIndex, pageSize, "PRODUCTCODE,SETTLEDATE", filter, "WMS_DAILYBALANCE");
            }
        }

        //��ѯ�ս����⡢���⡢�̵����浥����ϸ��
        public DataSet QueryStorageDetail(int pageIndex, int pageSize, string filter)
        {
            using (PersistentManager persistentManager = new PersistentManager())
            {
                BalanceDao dao = new BalanceDao();
                string sql = string.Format("SELECT * FROM V_STORAGE_DETAIL WHERE {0}",filter);
                return dao.Query(sql, "V_STORAGE_DETAIL", pageIndex, pageSize);
            }
        }

        //��ѯ��Ʒ����(���ֲֿ�)
        public DataSet QueryProductGeneralAccount(int pageIndex, int pageSize,string filter)
        {
            string sql = string.Format("SELECT * FROM V_PRODUCT_GENERAL WHERE {0}", filter);
            using (PersistentManager persistentManager = new PersistentManager())
            {
                BalanceDao dao = new BalanceDao();
                return dao.Query(sql, "V_PRODUCT_GENERAL", pageIndex, pageSize);
            }
        }

        //��ѯ��Ʒ�ս����⡢���⡢�̵����浥����ϸ��(���ֲֿ�)
        public DataSet QueryProductDetail(int pageIndex, int pageSize, string filter)
        {
            string sql = string.Format("SELECT * FROM V_PRODUCT_DETAIL WHERE {0}", filter);

            using (PersistentManager persistentManager = new PersistentManager())
            {
                BalanceDao dao = new BalanceDao();
                return dao.Query(sql, "V_STORAGE_DETAIL", pageIndex, pageSize);
            }
        }


        public int GetStorageGeneralRowCount(string filter)
        {
            using (PersistentManager persistentManager = new PersistentManager())
            {
                BalanceDao dao = new BalanceDao();
                return dao.GetRowCount("V_WMS_DAILYBALANCE", filter);
            }
        }

        public int GetStorageDetailRowCount(string filter)
        {
            using (PersistentManager persistentManager = new PersistentManager())
            {
                BalanceDao dao = new BalanceDao();
                return dao.GetRowCount("V_STORAGE_DETAIL", filter);
            }
        }


        public int GetProductGeneralRowCount(string filter)
        {
            using (PersistentManager persistentManager = new PersistentManager())
            {
                BalanceDao dao = new BalanceDao();
                return dao.GetRowCount("V_PRODUCT_GENERAL", filter);
            }
        }

        public int GetProductDetailRowCount(string filter)
        {
            using (PersistentManager persistentManager = new PersistentManager())
            {
                BalanceDao dao = new BalanceDao();
                return dao.GetRowCount("V_PRODUCT_DETAIL", filter);
            }
        }

    }
}
