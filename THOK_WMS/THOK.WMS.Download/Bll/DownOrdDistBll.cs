using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using THOK.Util;
using THOK.WMS.Download.Dao;

namespace THOK.WMS.Download.Bll
{
    public class DownOrdDistBll
    {
        #region ��Ӫ��ϵͳ�����䳵����Ϣ
        /// <summary>
        /// �����䳵����Ϣ
        /// </summary>
        /// <returns></returns>
        public bool DownOrgDistBillInfo()
        {
            bool tag = true;
            DataTable orgTable = this.QueryOrgDistCode();
            string distCodeList = UtinString.StringMake(orgTable, "DIST_BILL_ID");
            distCodeList = UtinString.StringMake(distCodeList);
            distCodeList = "DIST_BILL_ID NOT IN (" + distCodeList + ")";

            DataTable bistBillMasterTable = this.GetDistBillMaster(distCodeList);
            DataTable bistBillDetailTable = this.GetDistBillDetail(distCodeList);
            if (bistBillMasterTable.Rows.Count > 0 && bistBillDetailTable.Rows.Count>0)
                this.Insert(bistBillMasterTable, bistBillDetailTable);
            else
                tag = false;
            return tag;
        }

        /// <summary>
        /// �����䳵��������Ϣ
        /// </summary>
        /// <returns></returns>
        public DataTable GetDistBillMaster(string bistMaster)
        {
            using (PersistentManager dbpm = new PersistentManager("YXConnection"))
            {
                DownOrdDistDao dao = new DownOrdDistDao();
                dao.SetPersistentManager(dbpm);
                return dao.GetDistBillMaster(bistMaster);
            }
        }

        /// <summary>
        /// �����䳵��ϸ����Ϣ
        /// </summary>
        /// <returns></returns>
        public DataTable GetDistBillDetail(string bistDetail)
        {
            using (PersistentManager dbpm = new PersistentManager("YXConnection"))
            {
                DownOrdDistDao dao = new DownOrdDistDao();
                dao.SetPersistentManager(dbpm);
                return dao.GetDistBillDetail(bistDetail);
            }
        }

        /// <summary>
        /// ��ѯ�����ع����䳵������
        /// </summary>
        /// <returns></returns>
        public DataTable QueryOrgDistCode()
        {
            using (PersistentManager dbpm = new PersistentManager())
            {
                DownOrdDistDao dao = new DownOrdDistDao();
                dao.SetPersistentManager(dbpm);
                return dao.QueryOrgDistCode();
            }
        }

        /// <summary>
        /// �����ص����ݲ������ݿ�
        /// </summary>
        /// <param name="orgDistBillTable"></param>
        public void Insert(DataTable bistBillMasterTable, DataTable bistBillDetailTable)
        {
            using (PersistentManager dbpm = new PersistentManager())
            {
                DownOrdDistDao dao = new DownOrdDistDao();
                dao.SetPersistentManager(dbpm);
                dao.Insert(bistBillMasterTable, bistBillDetailTable);
            }
        }
        #endregion
    }
}
