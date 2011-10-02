using System;
using System.Collections.Generic;
using System.Text;
using THOK.WMS.Dao;
using System.Data;
using THOK.Util;

namespace THOK.WMS.BLL
{
  public  class SortingGroupBll
    {
      private string strTableName = "DWV_DPS_SORTING";
      private string strPrimaryKey = "SORTING_CODE";
      private string strQueryFields = "*";

      /// <summary>
      /// ����������ѯ�ּ𳧼Ҽ�¼
      /// </summary>
      /// <param name="file"></param>
      /// <returns></returns>
      public int GetSortingGroup(string file)
      {
          using (PersistentManager persistentManager = new PersistentManager())
          {
              SortingGroupDao dao = new SortingGroupDao();
              return dao.FindSortingGroupCount(file, strTableName);
          }
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
      public DataSet GetExecuteQuery(int pageIndex, int pageSize, string filter, string OrderByFields)
      {
          using (PersistentManager persistentManager = new PersistentManager())
          {
              SortingGroupDao dao = new SortingGroupDao();
              return dao.FindExecuteQuery(strTableName, strPrimaryKey, strQueryFields, pageIndex, pageSize, OrderByFields, filter, strTableName);
          }
      }


      public string GetSortingGroupId()
      {
          using (PersistentManager persistentManager = new PersistentManager())
          {
              SortingGroupDao dao = new SortingGroupDao();
              return dao.FindSortingGroupId();
          }
      }

      /// <summary>
      /// ���
      /// </summary>
      /// <returns></returns>
      public bool Insert()
      {
          bool flag = false;
          using (PersistentManager persistentManager = new PersistentManager())
          {
              SortingGroupDao dao = new SortingGroupDao();
              string date = DateTime.Now.Date.ToString("yyyyMMdd");
              string sql = string.Format("insert into DWV_DPS_SORTING(SORTING_CODE,SORTING_NAME,SORTING_TYPE,ISACTIVE,UPDATE_DATE) " +
                   " values('{0}','{1}','{2}','{3}',{4}) ", this.SORTING_CODE1, this.SORTING_NAME1, this.SORTING_TYPE1, this.ISACTIVE1, date);
              dao.SetData(sql);
              flag = true;
          }
          return flag;
      }

      /// <summary>
      /// �޸�
      /// </summary>
      /// <returns></returns>
      public bool Update()
      {
          bool flag = false;
          using (PersistentManager persistentManager = new PersistentManager())
          {
              SortingGroupDao dao = new SortingGroupDao();
              string date = DateTime.Now.Date.ToString("yyyyMMdd");
              string sql = string.Format("update DWV_DPS_SORTING set SORTING_NAME='{1}',SORTING_TYPE='{2}',ISACTIVE='{3}',UPDATE_DATE='{4}'  where SORTING_CODE='{0}'"
                                           , this.SORTING_CODE1,
                          this.SORTING_NAME1,
                          this.SORTING_TYPE1,
                          this.ISACTIVE1,date
                         );

              dao.SetData(sql);
              flag = true;
          }
          return flag;
      }

      /// <summary>
      /// ɾ��
      /// </summary>
      /// <param name="dataSet"></param>
      /// <returns></returns>
      public bool Delete(string dataSet)
      {
          bool flag = false;
          using (PersistentManager persistentManager = new PersistentManager())
          {
              SortingGroupDao dao = new SortingGroupDao();
              dao.delete(dataSet);
              flag = true;
          }
          return flag;
      }


      #region property

      private string SORTING_CODE;

      public string SORTING_CODE1
      {
          get { return SORTING_CODE; }
          set { SORTING_CODE = value; }
      }


      private string EXTERIOR_CODE;

      public string EXTERIOR_CODE1
      {
          get { return EXTERIOR_CODE; }
          set { EXTERIOR_CODE = value; }
      }


      private string SORTING_NAME;

      public string SORTING_NAME1
      {
          get { return SORTING_NAME; }
          set { SORTING_NAME = value; }
      }


      private string SORTING_TYPE;

      public string SORTING_TYPE1
      {
          get { return SORTING_TYPE; }
          set { SORTING_TYPE = value; }
      }

      private string SORTING_GROUP_CODE;

      public string SORTING_GROUP_CODE1
      {
          get { return SORTING_GROUP_CODE; }
          set { SORTING_GROUP_CODE = value; }
      }


      private string ISACTIVE;


      public string ISACTIVE1
      {
          get { return ISACTIVE; }
          set { ISACTIVE = value; }
      }

      private string UPDATE_DATE;

      public string UPDATE_DATE1
      {
          get { return UPDATE_DATE; }
          set { UPDATE_DATE = value; }
      }


      
        #endregion
    }
}
