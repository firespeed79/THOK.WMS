using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using THOK.Util;
using THOK.WMS.Dao;

namespace THOK.WMS
{
    public class BillExcelBLL
    {
        /// <summary>
        /// ��ѯ��Ӧ������ϸ
        /// </summary>
        /// <param name="filter">��ѯ��Χ</param>
        /// <param name="tableName">����</param>
        /// <param name="billNo">���ݺ�</param>
        /// <returns></returns>
        public DataTable QueryBillDetail(string filter,string tableName,string billNo)
        {
            using (PersistentManager pm = new PersistentManager())
            {
                BillExcelDao dao = new BillExcelDao();
                dao.SetPersistentManager(pm);
                return dao.QueryBillDetail(filter, tableName, billNo);
            }
        }


        public DataTable QueryBillAllot(string tableName, string billNo, string filter)
        {
            using (PersistentManager pm = new PersistentManager())
            {
                BillExcelDao dao = new BillExcelDao();
                dao.SetPersistentManager(pm);
                return dao.QueryBillAllot(tableName, billNo, filter);
            }
        }
    }
}
