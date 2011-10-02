using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using THOK.Util;

namespace THOK.WMS.Dao
{
    public class EmployeeDao:BaseDao
    {
        public DataSet Query(string TableViewName, string PrimaryKey, string QueryFields, int pageIndex, int pageSize, string orderBy, string filter, string strTableName)
        {
            return ExecuteQuery(TableViewName, PrimaryKey, QueryFields, pageIndex, pageSize, orderBy, filter, strTableName);
        }

        public string GetNewEmployeeCode()
        {
            string sql = "select top 1 EMPLOYEECODE from BI_EMPLOYEE order by EMPLOYEECODE desc";
            string sn = (string)ExecuteScalar(sql);
            DataSet ds = new DataSet();
            ds.ReadXml(AppDomain.CurrentDomain.BaseDirectory + "code\\TableXML\\BI_EMPLOYEE.xml");
            string prefix = ds.Tables["TABLE"].Rows[0]["PrefixText"].ToString();

            if (sn == null)
            {
                return prefix+"0001";
            }
            int num = Convert.ToInt32(sn.Substring(prefix.Length));
            num++;
            string newcode = num.ToString();
            for (int i = 0; i < 4 - num.ToString().Length; i++)
            {
                newcode = "0" + newcode;
            }
            return prefix + newcode;
        }


        public int GetRowCount(string TableViewName, string filter)
        {
            string sql = string.Format("select count(*) from {0}" +
                                         " where {1} "
                                         , TableViewName, filter);
            return (int)ExecuteScalar(sql);
        }


        public void DeleteEntity(DataSet dataSet)
        {
            try
            {
                foreach (DataRow dataRow in dataSet.Tables[0].Rows)
                {
                    if (dataRow.RowState == DataRowState.Deleted)
                    {
                        ExecuteNonQuery("delete BI_EMPLOYEE WHERE EMPLOYEECODE='" + dataRow["EMPLOYEECODE", DataRowVersion.Original] + "'");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetData(string sql)
        {
            return ExecuteQuery(sql);
        }

        public void SetData(string sql)
        {
            ExecuteNonQuery(sql);
        }
    }
}