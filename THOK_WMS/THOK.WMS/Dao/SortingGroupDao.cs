using System;
using System.Collections.Generic;
using System.Text;
using THOK.Util;
using System.Data;
namespace THOK.WMS.Dao
{
    public class SortingGroupDao : BaseDao
    {
        
        /// <summary>
        /// ���ݷ�ҳ��ѯ����
        /// </summary>
        /// <param name="code"></param>
        /// <param name="desc"></param>
        public void FindSortingGroupInfo(string code,string desc)
        {
            string sql = string.Format("SELECT * FROM DWV_DPS_SORTING_GROUP {0}{1}", code, desc);
        }



        /// <summary>
        /// ��ѯ�ּ𳧼Ҽ�¼
        /// </summary>
        /// <param name="filte"></param>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        public int FindSortingGroupCount(string filte, string strTableName)
        {
            string sql = string.Format("SELECT COUNT(*) FROM {0} WHERE {1}", strTableName, filte);
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
            int preRec = (pageIndex - 1) * pageSize;
            string sql = string.Format("select top {4} {2} ,case when ISACTIVE=1 then 'ʹ��' else 'ͣ��' end as SORTINGSTATE from {0} " +
                                        " where {1} not in ( select top {3} {1} from {0} where {6} order by {5}) " +
                                        " and {6} order by {5}"
                                        , TableViewName, PrimaryKey, QueryFields, preRec.ToString(), pageSize.ToString(), orderBy, filter);

            return ExecuteQuery(sql).Tables[0].DataSet;
        }


        /// <summary>
        /// ��ѯ�ּ��߱��
        /// </summary>
        /// <returns></returns>
        public string FindSortingGroupId()
        {
            string sql = "SELECT TOP 1 SORTING_CODE FROM DWV_DPS_SORTING ORDER BY SORTINGID DESC";
            int sn = Convert.ToInt32( ExecuteScalar(sql));
            
            sn++;
            string id=""+sn;
            //if (sn < 10 )
            //    id = "0" + sn;
            return id;
        }

        public void delete(string dataSet)
        {
            string sql = string.Format("delete DWV_DPS_SORTING where SORTING_CODE ={0}", dataSet);
            this.ExecuteNonQuery(sql);
         }

        public void SetData(string sql)
        {
            ExecuteNonQuery(sql);
        }
    }
}
    