using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using THOK.Util;

namespace THOK.WMS
{
    public class BillExcelDao : BaseDao
    {
        /// <summary>
        /// ��ѯ��Ӧ������ϸ
        /// </summary>
        /// <param name="filter">��ѯ��Χ</param>
        /// <param name="tableName">����ͼ����</param>
        /// <param name="billNo">���ݺ�</param>
        /// <returns></returns>
        public DataTable QueryBillDetail(string filter,string tableName, string billNo)
        {
            string sql = string.Format("select {0} from {1} where BILLNO='{2}'", filter, tableName, billNo);
            return this.ExecuteQuery(sql).Tables[0];
        }

        /// <summary>
        /// ��ѯ��Ӧ������ϸ����
        /// </summary>
        /// <param name="tableName">����ͼ����</param>
        /// <param name="billNo">���ݺ�</param>
        /// <param name="filter">�������͡�WMS_COMPARISON��</param>
        /// <returns></returns>
        public DataTable QueryBillAllot(string tableName,string billNo,string filter)
        {
            string sql = string.Format("select A.*,C.TEXT from {0} as A left join WMS_COMPARISON  as C on A.STATUS = C.VALUE where A.BILLNO='{1}' and C.FIELD='{2}'",
                tableName, billNo, filter);
            return this.ExecuteQuery(sql).Tables[0];

        }
    }
}
