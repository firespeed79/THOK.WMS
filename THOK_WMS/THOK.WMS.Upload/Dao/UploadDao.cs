using System;
using System.Collections.Generic;
using System.Text;
using THOK.Util;
using System.Data;

namespace THOK.WMS.Upload.Dao
{
    public class UploadDao:BaseDao
    {

        #region ��ѯ������Ϣ���ݣ��ϱ�����

        /// <summary>
        /// ��ѯ������Ϣ��DWV_IINF_BRAND�����ϱ�����
        /// </summary>
        /// <returns></returns>
        public DataTable QueryProductInfo()
        {
            string sql = "SELECT * FROM V_DWV_IINF_BRAND WHERE IS_IMPORT ='0'";
            return this.ExecuteQuery(sql).Tables[0];
        }

        /// <summary>
        /// ���������Ϣ��DWV_IINF_BRAND�����������ݿ�
        /// </summary>
        /// <param name="brandTable"></param>
        public void InsertProduct(DataTable brandTable)
        {
            foreach (DataRow row in brandTable.Rows)
            {
                string sql = string.Format("INSERT INTO ms.DWV_IINF_BRAND(BRAND_CODE,BRAND_TYPE,BRAND_NAME,IS_FILTERTIP,IS_NEW,IS_FAMOUS" +
                   " ,IS_MAINPRODUCT,IS_MAINPROVINCE,BELONG_REGION,IS_ABNORMITY_BRAND,QTY_UNIT" +
                   " ,UPDATE_DATE,ISACTIVE,IS_CONFISCATE,IS_IMPORT)" +
                   " VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}',{10},'{11}','{12}','{13}','{14}')", row["BRAND_N"], row["BRAND_TYPE"], row["BRAND_NAME"],
                   row["IS_FILTERTIP"], row["IS_NEW"], row["IS_FAMOUS"], row["IS_MAINPRODUCT"], row["IS_MAINPROVINCE"], row["BELONG_REGION"],
                   row["IS_ABNORMITY_BRAND"], row["QTY_UNIT"], row["UPDATE_DATE"], row["ISACTIVE"], row["IS_CONFISCATE"], row["IS_IMPORT"]);
                this.ExecuteNonQuery(sql);
            }
        }

        /// <summary>
        /// �޸ľ�����Ϣ����Ϣ�ϱ�״̬
        /// </summary>
        /// <param name="productCode"></param>
        public void UpdateProduct()
        {
            string sql = "UPDATE DWV_IINF_BRAND SET IS_IMPORT='1' WHERE IS_IMPORT='0'";
            this.ExecuteNonQuery(sql);
        }

        #endregion


        #region ��ѯ��֯�ṹ�����ݣ��ϱ�����

        /// <summary>
        /// ��ѯ��֯�ṹ��DWV_IORG_ORGANIZATION�� ���ϱ�����
        /// </summary>
        /// <returns></returns>
        public DataTable QueryOrganization()
        {
            string sql = "SELECT * FROM V_DWV_IORG_ORGANIZATION WHERE IS_IMPORT ='0'";
            return this.ExecuteQuery(sql).Tables[0];
        }


        /// <summary>
        /// ������֯�ṹ��DWV_IORG_ORGANIZATION�����������ݿ�
        /// </summary>
        /// <param name="organTable"></param>
        public void InsertOrganization(DataTable organTable)
        {
            foreach (DataRow row in organTable.Rows)
            {
                string date = Convert.ToDateTime(row["UPDATE_DATE"]).ToString("yyyyMMddHHmmss");
                string sql = string.Format("INSERT INTO DWV_IORG_ORGANIZATION(ORGANIZATION_CODE,ORGANIZATION_NAME,ORGANIZATION_TYPE" +
                " ,N_ORGANIZATION_CODE,STORE_ROOM_AREA,STORE_ROOM_NUM,STORE_ROOM_CAPACITY,SORTING_NUM,UPDATE_DATE,ISACTIVE,IS_IMPORT)" +
                "VALUES('{0}','{1}','{2}','{3}',{4},{5},{6},{7},'{8}','{9}','{10}')", row["ORGANIZATION_CODE"], row["ORGANIZATION_NAME"], row["ORGANIZATION_TYPE"],
                row["N_ORGANIZATION_CODE"], row["STORE_ROOM_AREA"], row["STORE_ROOM_NUM"], row["STORE_ROOM_CAPACITY"], row["SORTING_NUM"],
                date, row["ISACTIVE"], row["IS_IMPORT"]);
                this.ExecuteNonQuery(sql);
            }
        }

        /// <summary>
        /// �޸���֯�ṹ����Ϣ�ϱ�״̬
        /// </summary>
        /// <param name="productCode"></param>
        public void UpdateOrganization()
        {
            string sql = string.Format("UPDATE DWV_IORG_ORGANIZATION SET IS_IMPORT='1' WHERE IS_IMPORT='0'");
            this.ExecuteNonQuery(sql);
        }

        #endregion


        #region ��ѯ��Ա��Ϣ�����ݣ��ϱ�����

        /// <summary>
        /// ��ѯ��Ա��Ϣ��DWV_IORG_PERSON�����ϱ�����
        /// </summary>
        /// <returns></returns>
        public DataTable QueryPerson()
        {
            string sql = "SELECT * FROM V_DWV_IORG_PERSON WHERE IS_IMPORT ='0'";
            return this.ExecuteQuery(sql).Tables[0];
        }


        /// <summary>
        /// ������Ա��Ϣ��DWV_IORG_PERSON�����������ݿ�
        /// </summary>
        /// <param name="presonTable"></param>
        public void InsertPreson(DataTable presonTable)
        {
            foreach (DataRow row in presonTable.Rows)
            {
                string date = Convert.ToDateTime(row["UPDATE_DATE"]).ToString("yyyyMMddHHmmss");
                string sql = string.Format("INSERT INTO DWV_IORG_PERSON(PERSON_CODE,PERSON_N,PERSON_NAME,SEX,SUPER_ADMIN,SYSTEM_ADMIN," +
                    " UPDATE_DATE,ISACTIVE,IS_IMPORT)VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')", row["PERSON_CODE"],
                    row["PERSON_N"], row["PERSON_NAME"], row["SEX"], row["SUPER_ADMIN"], row["SYSTEM_ADMIN"], date, row["ISACTIVE"], row["IS_IMPORT"]);
                this.ExecuteNonQuery(sql);
            }
        }


        /// <summary>
        /// �޸���Ա��Ϣ����Ϣ�ϱ�״̬
        /// </summary>
        /// <param name="productCode"></param>
        public void UpdatePerson()
        {
            string sql = "UPDATE DWV_IORG_PERSON SET IS_IMPORT='1' WHERE IS_IMPORT='0'";
            this.ExecuteNonQuery(sql);
        }

        #endregion


        #region ��ѯ�ͻ���Ϣ�����ݣ��ϱ�����

        /// <summary>
        /// ��ѯ�ͻ���Ϣ��DWV_IORG_CUSTOMER�����ϱ�����
        /// </summary>
        /// <returns></returns>
        public DataTable QueryCustomer()
        {
            string sql = "SELECT * FROM V_DWV_IORG_CUSTOMER WHERE IS_IMPORT ='0'";
            return this.ExecuteQuery(sql).Tables[0];
        }


        /// <summary>
        /// ����ͻ���Ϣ��DWV_IORG_CUSTOMER�����������ݿ�
        /// </summary>
        /// <param name="customerTable"></param>
        public void InsertCustomer(DataTable customerTable)
        {
            foreach (DataRow row in customerTable.Rows)
            {
                string sql = string.Format("INSERT INTO DWV_IORG_CUSTOMER(CUST_CODE,CUST_N,CUST_NAME,ORG_CODE,SALE_REG_CODE,CUST_TYPE,RTL_CUST_TYPE_CODE," +
                    "CUST_GEO_TYPE_CODE,DIST_ADDRESS,DIST_PHONE,UPDATE_DATE,ISACTIVE,IS_IMPORT)VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}')", row["CUST_CODE"], row["CUST_N"],
                    row["CUST_NAME"], row["ORG_CODE"], row["SALE_REG_CODE"], row["CUST_TYPE"], row["RTL_CUST_TYPE_CODE"], row["CUST_GEO_TYPE_CODE"], row["DIST_ADDRESS"], row["DIST_PHONE"],
                    row["UPDATE_DATE"], row["ISACTIVE"], row["IS_IMPORT"]);
                this.ExecuteNonQuery(sql);
            }
        }


        /// <summary>
        /// �޸Ŀͻ���Ϣ����Ϣ�ϱ�״̬
        /// </summary>
        /// <param name="productCode"></param>
        public void UpdateCustomer(string customerCode)
        {
            string sql = "UPDATE DWV_IORG_CUSTOMER SET IS_IMPORT='1' WHERE IS_IMPORT='0'";
            this.ExecuteNonQuery(sql);
        }


        #endregion


        #region ��ѯ�ֿ�������ݣ��ϱ�����

        /// <summary>
        /// ��ѯ�ֿ����DWV_IWMS_STORE_STOCK�����ϱ�����
        /// </summary>
        /// <returns></returns>
        public DataTable QueryStoreStock()
        {
            string sql = "SELECT * FROM V_DWV_IWMS_STORE_STOCK WHERE IS_IMPORT ='0'";
            return this.ExecuteQuery(sql).Tables[0];
        }


        /// <summary>
        /// ����ֿ����DWV_IWMS_STORE_STOCK��
        /// </summary>
        /// <param name="stockTable"></param>
        public void InsertStoreStock(DataTable stockTable)
        {
            DataTable place=this.ExecuteQuery("SELECT STORE_PLACE_CODE FROM DWV_IWMS_STORE_STOCK ").Tables[0];
            foreach (DataRow row in stockTable.Rows)
            {
                string sql;
                //if (place.Rows.ToString().Contains(row["STORE_PLACE_CODE"].ToString()))
                //{
                sql = string.Format("UPDATE DWV_IWMS_STORE_STOCK SET BRAND_CODE='{0}',BRAND_BATCH='{1}',QUANTITY={2},IS_IMPORT='{3}' WHERE STORE_PLACE_CODE='{4}' ", row["BRAND_CODE"], row["BRAND_BATCH"], row["QUANTITY"], row["IS_IMPORT"], row["STORE_PLACE_CODE"]);
                //}
                //else
                //{
                  //   sql = string.Format("INSERT INTO DWV_IWMS_STORE_STOCK(STORE_PLACE_CODE,BRAND_CODE,AREA_TYPE,BRAND_BATCH,DIST_CTR_CODE,QUANTITY,IS_IMPORT)VALUES('{0}','{1}','{2}','{3}','{4}',{5},'{6}')",
                   //     row["STORE_PLACE_CODE"], row["BRAND_CODE"], row["AREA_TYPE"], row["BRAND_BATCH"], row["DIST_CTR_CODE"], row["QUANTITY"], row["IS_IMPORT"]);
                //}
                this.ExecuteNonQuery(sql);
            }
        }

        /// <summary>
        /// �޸Ĳֿ������Ϣ�ϱ�״̬
        /// </summary>
        /// <param name="productCode"></param>
        public void UpdateStoreStock(string storeStockCode)
        {
            string sql = string.Format("UPDATE DWV_IWMS_STORE_STOCK SET IS_IMPORT='1' WHERE IS_IMPORT='0'");
            this.ExecuteNonQuery(sql);
        }

        #endregion


        #region ��ѯҵ��������ݣ��ϱ�����


        /// <summary>
        /// ��ѯҵ�����DWV_IWMS_BUSI_STOCK�����ϱ�����
        /// </summary>
        /// <returns></returns>
        public DataTable QueryBusiStock()
        {
            string sql = "SELECT * FROM V_DWV_IWMS_BUSI_STOCK WHERE IS_IMPORT ='0'";
            return this.ExecuteQuery(sql).Tables[0];
        }


        /// <summary>
        /// ����ҵ�����DWV_IWMS_BUSI_STOCK��
        /// </summary>
        /// <param name="stockTable"></param>
        public void InsertBustStock(DataTable stockTable)
        {
            DataTable place = this.ExecuteQuery("SELECT * FROM DWV_IWMS_BUSI_STOCK ").Tables[0];
            foreach (DataRow row in stockTable.Rows)
            {
                //string sql = string.Format("INSERT INTO DWV_IWMS_BUSI_STOCK(ORG_CODE,BRAND_CODE,DIST_CTR_CODE,QUANTITY,IS_IMPORT)VALUES('{0}','{1}','{2}',{3},'{4}')",
                //    row["ORG_CODE"], row["BRAND_CODE"], row["DIST_CTR_CODE"], row["QUANTITY"], row["IS_IMPORT"]);
                string sql = string.Format("update DWV_IWMS_BUSI_STOCK SET ORG_CODE='{0}',DIST_CTR_CODE='{1}',QUANTITY={2},IS_IMPORT='{3}' WHERE BRAND_CODE='{4}' ",
                    row["ORG_CODE"], row["DIST_CTR_CODE"], row["QUANTITY"], row["IS_IMPORT"], row["BRAND_CODE"]);
                this.ExecuteNonQuery(sql);
            }
        }

        /// <summary>
        /// �޸�ҵ�������Ϣ�ϱ�״̬
        /// </summary>
        /// <param name="productCode"></param>
        public void UpdateBusiStock(string busiStockCode)
        {
            string sql = string.Format("UPDATE DWV_IWMS_BUSI_STOCK SET IS_IMPORT='1' WHERE IS_IMPORT='0'");
            this.ExecuteNonQuery(sql);
        }

        #endregion


        #region ��ѯ�ֿ���ⵥ���������ݣ��ϱ�����


        /// <summary>
        /// ��ѯ�ֿ���ⵥ������DWV_IWMS_IN_STORE_BILL�����ϱ�����
        /// </summary>
        /// <returns></returns>
        public DataTable QueryInMasterBill()
        {
            string sql = "SELECT * FROM V_DWV_IWMS_IN_STORE_BILL WHERE IS_IMPORT ='0'";
            return this.ExecuteQuery(sql).Tables[0];
        }

        /// <summary>
        /// ����ֿ���ⵥ������DWV_IWMS_IN_STORE_BILL�����������ݿ�
        /// </summary>
        /// <param name="masterTable"></param>
        public void InsertInMasterBill(DataTable inMasterTable)
        {
            foreach (DataRow row in inMasterTable.Rows)
            {
                string sql = string.Format("INSERT INTO DWV_IWMS_IN_STORE_BILL(STORE_BILL_ID,RELATE_BUSI_BILL_NUM,DIST_CTR_CODE,AREA_TYPE,QUANTITY_SUM," +
                    "AMOUNT_SUM,DETAIL_NUM,CREATOR_CODE,CREATE_DATE,AUDITOR_CODE,AUDIT_DATE,ASSIGNER_CODE,ASSIGN_DATE,AFFIRM_CODE,AFFIRM_DATE," +
                    "IN_OUT_TYPE,BILL_TYPE,BILL_STATUS,DISUSE_STATUS,IS_IMPORT)VALUES('{0}',{1},'{2}','{3}',{4},{5},{6},'{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}')",
                    row["STORE_BILL_ID"], row["RELATE_BUSI_BILL_NUM"], row["DIST_CTR_CODE"], row["AREA_TYPE"], row["QUANTITY_SUM"], row["AMOUNT_SUM"], row["DETAIL_NUM"],
                    row["CREATOR_CODE"], row["CREATE_DATE"], row["AUDITOR_CODE"], row["AUDIT_DATE"], row["ASSIGNER_CODE"], row["ASSIGN_DATE"], row["AFFIRM_CODE"],
                    row["AFFIRM_DATE"], row["IN_OUT_TYPE"], row["BILL_TYPE"], row["BILL_STATUS"], row["DISUSE_STATUS"], row["IS_IMPORT"]);
                this.ExecuteNonQuery(sql);
            }
        }

        /// <summary>
        /// �޸Ĳֿ���ⵥ��������Ϣ�ϱ�״̬
        /// </summary>
        /// <param name="productCode"></param>
        public void UpdateInMaster(string inMasterCode)
        {
            string sql = "UPDATE DWV_IWMS_IN_STORE_BILL SET IS_IMPORT='1' WHERE IS_IMPORT='0'";
            this.ExecuteNonQuery(sql);
        }


        #endregion


        #region ��ѯ�ֿ���ⵥ��ϸ�����ݣ��ϱ�����


        /// <summary>
        /// ��ѯ�ֿ���ⵥ��ϸ��DWV_IWMS_IN_STORE_BILL_DETAIL�����ϱ�����
        /// </summary>
        /// <returns></returns>
        public DataTable QueryInDetailBill()
        {
            string sql = "SELECT * FROM V_DWV_IWMS_IN_STORE_BILL_DETAIL WHERE IS_IMPORT ='0'";
            return this.ExecuteQuery(sql).Tables[0];
        }


        /// <summary>
        /// ����ֿ���ⵥ��ϸ��DWV_IWMS_IN_STORE_BILL_DETAIL�����������ݿ�
        /// </summary>
        /// <param name="detailTable"></param>
        public void InsertInDetailBill(DataTable inDetailTable)
        {
            foreach (DataRow row in inDetailTable.Rows)
            {
                string sql = string.Format("INSERT INTO DWV_IWMS_IN_STORE_BILL_DETAIL(STORE_BILL_DETAIL_ID,STORE_BILL_ID,BRAND_CODE,BRAND_NAME,QUANTITY,IS_IMPORT)" +
                    "VALUES('{0}','{1}','{2}','{3}',{4},'{5}')",
                    row["STORE_BILL_DETAIL_ID"], row["STORE_BILL_ID"], row["BRAND_N"], row["BRAND_NAME"], row["QUANTITY"], row["IS_IMPORT"]);
                this.ExecuteNonQuery(sql);
            }
        }


        /// <summary>
        /// �޸Ĳֿ���ⵥ��ϸ����Ϣ�ϱ�״̬
        /// </summary>
        /// <param name="productCode"></param>
        public void UpdateInDetail(string inDetailCode)
        {
            string sql = "UPDATE DWV_IWMS_IN_STORE_BILL_DETAIL SET IS_IMPORT='1' WHERE IS_IMPORT='0'";
            this.ExecuteNonQuery(sql);
        }
        #endregion


        #region ��ѯ���ҵ�񵥾ݱ����ݣ��ϱ�����


        /// <summary>
        /// ��ѯ���ҵ�񵥾ݱ�DWV_IWMS_IN_BUSI_BILL�����ϱ�����
        /// </summary>
        /// <returns></returns>
        public DataTable QueryInBusiBill()
        {
            string sql = "SELECT * FROM V_DWV_IWMS_IN_BUSI_BILL WHERE IS_IMPORT ='0' ORDER BY BUSI_BILL_ID,BRAND_NAME,END_STOCK_QUANTITY";
            return this.ExecuteQuery(sql).Tables[0];
        }


        /// <summary>
        ///  �������ҵ�񵥾ݱ�DWV_IWMS_IN_BUSI_BILL�����������ݿ�
        /// </summary>
        /// <param name="busiTable"></param>
        public void InsertInBusiBill(DataTable inBusiTable)
        {
            foreach (DataRow row in inBusiTable.Rows)
            {
                string sql = string.Format("INSERT INTO DWV_IWMS_IN_BUSI_BILL(BUSI_ACT_ID,BUSI_BILL_DETAIL_ID,BUSI_BILL_ID,BRAND_CODE," +
                    "BRAND_NAME,QUANTITY,DIST_CTR_CODE,ORG_CODE,STORE_ROOM_CODE,STORE_PLACE_CODE,TARGET_NAME,IN_OUT_TYPE,BILL_TYPE,BEGIN_STOCK_QUANTITY," +
                    "END_STOCK_QUANTITY,DISUSE_STATUS,RECKON_STATUS,RECKON_DATE,UPDATE_CODE,UPDATE_DATE,IS_IMPORT)VALUES('{0}','{1}','{2}','{3}','{4}',{5},'{6}','{7}','{8}','{9}','{10}','{11}','{12}',{13},{14},'{15}','{16}','{17}','{18}','{19}','{20}')",
                    row["BUSI_ACT_ID"], row["BUSI_BILL_DETAIL_ID"], row["BUSI_BILL_ID"], row["BRAND_N"], row["BRAND_NAME"], row["QUANTITY"],
                    row["DIST_CTR_CODE"], row["ORG_CODE"], row["STORE_ROOM_CODE"], row["STORE_PLACE_CODE"], row["TARGET_NAME"], row["IN_OUT_TYPE"], row["BILL_TYPE"],
                    row["BEGIN_STOCK_QUANTITY"], row["END_STOCK_QUANTITY"], row["DISUSE_STATUS"], row["RECKON_STATUS"], row["RECKON_DATE"], row["UPDATE_CODE"], row["UPDATE_DATE"], row["IS_IMPORT"]);
                this.ExecuteNonQuery(sql);
            }
        }

        /// <summary>
        /// �޸����ҵ�񵥾ݱ���Ϣ�ϱ�״̬
        /// </summary>
        /// <param name="productCode"></param>
        public void UpdateInBusi(string inBusiCode)
        {
            string sql = "UPDATE DWV_IWMS_IN_BUSI_BILL SET IS_IMPORT='1' WHERE IS_IMPORT='0'";
            this.ExecuteNonQuery(sql);
        }

        #endregion


        #region ��ѯ�ֿ���ⵥ���������ݣ��ϱ�����


        /// <summary>
        /// ��ѯ�ֿ���ⵥ������DWV_IWMS_OUT_STORE_BILL�����ϱ�����
        /// </summary>
        /// <returns></returns>
        public DataTable QueryOutMasterBill()
        {
            string sql = "SELECT * FROM V_DWV_IWMS_OUT_STORE_BILL WHERE IS_IMPORT ='0'";
            return this.ExecuteQuery(sql).Tables[0];
        }

        /// <summary>
        /// ����ֿ���ⵥ������DWV_IWMS_OUT_STORE_BILL�����������ݿ�
        /// </summary>
        /// <param name="outMasterTable"></param>
        public void InsertOutMasertBill(DataTable outMasterTable)
        {
            foreach (DataRow row in outMasterTable.Rows)
            {
                string sql = string.Format("INSERT INTO DWV_IWMS_OUT_STORE_BILL(STORE_BILL_ID,RELATE_BUSI_BILL_NUM,DIST_CTR_CODE,AREA_TYPE,QUANTITY_SUM," +
                    "AMOUNT_SUM,DETAIL_NUM,CREATOR_CODE,CREATE_DATE,AUDITOR_CODE,AUDIT_DATE,ASSIGNER_CODE,ASSIGN_DATE,AFFIRM_CODE,AFFIRM_DATE," +
                    "IN_OUT_TYPE,BILL_TYPE,BILL_STATUS,DISUSE_STATUS,IS_IMPORT)VALUES('{0}',{1},'{2}','{3}',{4},{5},{6},'{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}')",
                    row["STORE_BILL_ID"], row["RELATE_BUSI_BILL_NUM"], row["DIST_CTR_CODE"], row["AREA_TYPE"], row["QUANTITY_SUM"], row["AMOUNT_SUM"], row["DETAIL_NUM"],
                    row["CREATOR_CODE"], row["CREATE_DATE"], row["AUDITOR_CODE"], row["AUDIT_DATE"], row["ASSIGNER_CODE"], row["ASSIGN_DATE"], row["AFFIRM_CODE"],
                    row["AFFIRM_DATE"], row["IN_OUT_TYPE"], row["BILL_TYPE"], row["BILL_STATUS"], row["DISUSE_STATUS"], row["IS_IMPORT"]);
                this.ExecuteNonQuery(sql);
            }
        }

        /// <summary>
        /// �޸Ĳֿ���ⵥ��������Ϣ�ϱ�״̬
        /// </summary>
        /// <param name="productCode"></param>
        public void UpdateOutMaster(string outMasterCode)
        {
            string sql = "UPDATE DWV_IWMS_OUT_STORE_BILL SET IS_IMPORT='1' WHERE IS_IMPORT='0'";
            this.ExecuteNonQuery(sql);
        }

        #endregion


        #region ��ѯ�ֿ���ⵥ��ϸ�����ݣ��ϱ�����


        /// <summary>
        /// ��ѯ�ֿ���ⵥ��ϸ��DWV_IWMS_OUT_STORE_BILL_DETAIL�����ϱ�����
        /// </summary>
        /// <returns></returns>
        public DataTable QueryOutDetailBill()
        {
            string sql = "SELECT * FROM V_DWV_IWMS_OUT_STORE_BILL_DETAIL WHERE IS_IMPORT ='0'";
            return this.ExecuteQuery(sql).Tables[0];
        }

        /// <summary>
        /// ����ֿ���ⵥ��ϸ��DWV_IWMS_OUT_STORE_BILL_DETAIL�����������ݿ�
        /// </summary>
        /// <param name="detailTable"></param>
        public void InsertOutDetailBill(DataTable outDetailTable)
        {
            string sql = "DELETE FROM DWV_IWMS_OUT_STORE_BILL_DETAIL";
            this.ExecuteNonQuery(sql);
            foreach (DataRow row in outDetailTable.Rows)
            {
                sql = string.Format("INSERT INTO DWV_IWMS_OUT_STORE_BILL_DETAIL(STORE_BILL_DETAIL_ID,STORE_BILL_ID,BRAND_CODE,BRAND_NAME,QUANTITY,IS_IMPORT)" +
                   "VALUES('{0}','{1}','{2}','{3}',{4},'{5}')",
                   row["STORE_BILL_DETAIL_ID"], row["STORE_BILL_ID"], row["BRAND_N"], row["BRAND_NAME"], row["QUANTITY"], row["IS_IMPORT"]);
                this.ExecuteNonQuery(sql);
            }
        }


        /// <summary>
        /// �޸Ĳֿ���ⵥ��ϸ����Ϣ�ϱ�״̬
        /// </summary>
        /// <param name="productCode"></param>
        public void UpdateOutDetail(string outDetailCode)
        {
            string sql = "UPDATE DWV_IWMS_OUT_STORE_BILL_DETAIL SET IS_IMPORT='1' WHERE IS_IMPORT='0'";
            this.ExecuteNonQuery(sql);
        }

        #endregion


        #region ��ѯ����ҵ�񵥾ݱ����ݣ��ϱ�����

        /// <summary>
        /// ��ѯ����ҵ�񵥾ݱ�DWV_IWMS_OUT_BUSI_BILL�����ϱ�����
        /// </summary>
        /// <returns></returns>
        public DataTable QueryOutBusiBill()
        {
            string sql = "SELECT * FROM V_DWV_IWMS_OUT_BUSI_BILL WHERE IS_IMPORT ='0' ORDER BY BUSI_BILL_ID,BRAND_NAME,END_STOCK_QUANTITY ";
            return this.ExecuteQuery(sql).Tables[0];
        }

        /// <summary>
        ///  �������ҵ�񵥾ݱ�DWV_IWMS_OUT_BUSI_BILL�����������ݿ�
        /// </summary>
        /// <param name="busiTable"></param>
        public void InsertOutBusiBill(DataTable outBusiTable)
        {
            string sql = "DELETE FROM DWV_IWMS_OUT_BUSI_BILL";
            this.ExecuteNonQuery(sql);
            foreach (DataRow row in outBusiTable.Rows)
            {
                sql = string.Format("INSERT INTO DWV_IWMS_OUT_BUSI_BILL(BUSI_ACT_ID,BUSI_BILL_DETAIL_ID,BUSI_BILL_ID,BRAND_CODE," +
                   "BRAND_NAME,QUANTITY,DIST_CTR_CODE,ORG_CODE,STORE_ROOM_CODE,STORE_PLACE_CODE,TARGET_NAME,IN_OUT_TYPE,BILL_TYPE,BEGIN_STOCK_QUANTITY," +
                   "END_STOCK_QUANTITY,DISUSE_STATUS,RECKON_STATUS,RECKON_DATE,UPDATE_CODE,UPDATE_DATE,IS_IMPORT)VALUES('{0}','{1}','{2}','{3}','{4}',{5},'{6}','{7}','{8}','{9}','{10}','{11}','{12}',{13},{14},'{15}','{16}','{17}','{18}','{19}','{20}')",
                   row["BUSI_ACT_ID"], row["BUSI_BILL_DETAIL_ID"], row["BUSI_BILL_ID"], row["BRAND_N"], row["BRAND_NAME"], row["QUANTITY"],
                   row["DIST_CTR_CODE"], row["ORG_CODE"], row["STORE_ROOM_CODE"], row["STORE_PLACE_CODE"], row["TARGET_NAME"], row["IN_OUT_TYPE"], row["BILL_TYPE"],
                   row["BEGIN_STOCK_QUANTITY"], row["END_STOCK_QUANTITY"], row["DISUSE_STATUS"], row["RECKON_STATUS"], row["RECKON_DATE"], row["UPDATE_CODE"], row["UPDATE_DATE"], row["IS_IMPORT"]);
                this.ExecuteNonQuery(sql);
            }
        }

        /// <summary>
        /// �޸ĳ���ҵ�񵥾ݱ���Ϣ�ϱ�״̬
        /// </summary>
        /// <param name="productCode"></param>
        public void UpdateOutBusi(string outBusiCode)
        {
            string sql = "UPDATE DWV_IWMS_OUT_BUSI_BILL SET IS_IMPORT='1' WHERE IS_IMPORT='0'";
            this.ExecuteNonQuery(sql);
        }

        #endregion


        #region ��ѯͬ��״̬�����ݣ��ϱ�����


        /// <summary>
        /// ��ѯͬ��״̬��DWV_IOUT_SYNCHRO_INFO�����ϱ�����
        /// </summary>
        /// <returns></returns>
        public DataTable QuerySynchroInfo()
        {
            string sql = "SELECT * FROM V_DWV_IOUT_SYNCHRO_INFO WHERE IS_IMPORT ='0'";
            return this.ExecuteQuery(sql).Tables[0];
        }


        /// <summary>
        /// ����ͬ��״̬��DWV_IOUT_SYNCHRO_INFO��
        /// </summary>
        /// <param name="synchroTable"></param>
        public void InsertSynchro(DataTable synchroTable)
        {
            string sql = "DELETE FROM DWV_IOUT_SYNCHRO_INFO";
            this.ExecuteNonQuery(sql);
            foreach (DataRow row in synchroTable.Rows)
            {
                sql = string.Format("INSERT INTO DWV_IOUT_SYNCHRO_INFO(SYNC_TYPE_CODE,SYNC_TYPE_NAME,UPDATE_DATE,IS_IMPORT,REMARK)VALUES('{0}','{1}','{2}','{3}','{4}')",
                    row["SYNC_TYPE_CODE"], row["SYNC_TYPE_NAME"], row["UPDATE_DATE"], row["IS_IMPORT"], row["REMARK"]);
                this.ExecuteNonQuery(sql);
            }
        }

        /// <summary>
        /// �޸�ͬ��״̬����Ϣ�ϱ�״̬
        /// </summary>
        /// <param name="productCode"></param>
        public void UpdateSyachro(string syachroCode)
        {
            string dtOrder = DateTime.Now.AddDays(-30d).ToString("yyyyMMdd");
            string sql = string.Format("UPDATE DWV_IOUT_SYNCHRO_INFO SET IS_IMPORT='1' WHERE IS_IMPORT='0'");
            this.ExecuteNonQuery(sql);
            sql = string.Format("DELETE FROM DWV_IOUT_SYNCHRO_INFO WHERE UPDATE_DATE <'{0}'", dtOrder);
            this.ExecuteNonQuery(sql);
        }

        #endregion


        #region ��ѯ�ּ𶩵��������ݣ��ϱ�����


        /// <summary>
        /// ��ѯ�ּ𶩵�����DWV_OUT_ORDER�����ϱ�����
        /// </summary>
        /// <returns></returns>
        public DataTable QueryIordMasterOrder()
        {
            string sql = "SELECT * FROM V_WMS_SORT_ORDER WHERE IS_IMPORT ='0'";
            return this.ExecuteQuery(sql).Tables[0];
        }

        /// <summary>
        /// ����ּ𶩵�����DWV_IORD_ORDER�����������ݿ�
        /// </summary>
        /// <param name="orderMasterTable"></param>
        public void InsertIordOrder(DataTable orderMasterTable)
        {
            foreach (DataRow row in orderMasterTable.Rows)
            {
                string sql = string.Format("INSERT INTO DWV_IORD_ORDER(ORDER_ID,ORG_CODE,SALE_REG_CODE,ORDER_DATE,ORDER_TYPE," +
                    "CUST_CODE,CUST_NAME,QUANTITY_SUM,AMOUNT_SUM,DETAIL_NUM,DELIVER_ORDER,ISACTIVE,UPDATE_DATE,IS_IMPORT)VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}',{7},{8},{9},{10},'{11}','{12}','{13}')",
                    row["ORDER_ID"], row["ORG_CODE"], row["SALE_REG_CODE"], row["ORDER_DATE"], row["ORDER_TYPE"], row["CUST_N"], row["CUST_NAME"],
                    row["QUANTITY_SUM"], row["AMOUNT_SUM"], row["DETAIL_NUM"], row["DELIVER_ORDER"], row["ISACTIVE"], row["UPDATE_DATE"], row["IS_IMPORT"]);
                this.ExecuteNonQuery(sql);
            }
        }


        /// <summary>
        /// �޸ķּ𶩵�������Ϣ�ϱ�״̬
        /// </summary>
        /// <param name="productCode"></param>
        public void UpdateOrderMaster(string orderMasterCode)
        {
            string sql = "UPDATE DWV_OUT_ORDER SET IS_IMPORT='1' WHERE IS_IMPORT='0'";
            this.ExecuteNonQuery(sql);
        }
        #endregion


        #region ��ѯ�ּ𶩵�ϸ�����ݣ��ϱ�����

        /// <summary>
        /// ��ѯ�ּ𶩵�ϸ��DWV_OUT_ORDER_DETAIL�����ϱ�����
        /// </summary>
        /// <returns></returns>
        public DataTable QueryIordDetailOrder()
        {
            string sql = "SELECT * FROM V_WMS_SORT_ORDER_DETAIL WHERE IS_IMPORT ='0'";
            return this.ExecuteQuery(sql).Tables[0];
        }

        /// <summary>
        /// ����ּ𶩵�ϸ��DWV_IORD_ORDER_DETAIL�����������ݿ�
        /// </summary>
        /// <param name="orderDetailTable"></param>
        public void InsertIordOrderDetail(DataTable orderDetailTable)
        {
            foreach (DataRow row in orderDetailTable.Rows)
            {
                string sql = string.Format("INSERT INTO DWV_IORD_ORDER_DETAIL(ORDER_DETAIL_ID,ORDER_ID,BRAND_CODE,BRAND_NAME,BRAND_UNIT_NAME," +
                    "QTY_DEMAND,QUANTITY,PRICE,AMOUNT,IS_IMPORT)VALUES('{0}','{1}','{2}','{3}','{4}',{5},{6},{7},{8},'{9}')",
                    row["ORDER_DETAIL_ID"], row["ORDER_ID"], row["BRAND_CODE"], row["BRAND_NAME"], row["BRAND_UNIT_NAME"], row["QTY_DEMAND"], row["QUANTITY"],
                    row["PRICE"], row["AMOUNT"], row["IS_IMPORT"]);
                this.ExecuteNonQuery(sql);
            }
        }


        /// <summary>
        /// �޸ķּ𶩵�ϸ����Ϣ�ϱ�״̬
        /// </summary>
        /// <param name="productCode"></param>
        public void UpdateOrderDetail(string orderDetailCode)
        {
            string sql = "UPDATE DWV_OUT_ORDER_DETAIL SET IS_IMPORT='1' WHERE IS_IMPORT='0'";
            this.ExecuteNonQuery(sql);
        }


        #endregion


        #region ��ѯ�ּ���������ݣ��ϱ�����


        /// <summary>
        /// ��ѯ�ּ������DWV_IORD_SORT_STATUS�����ϱ�����
        /// </summary>
        /// <returns></returns>
        public DataTable QuerySortStatus()
        {
            string sql = "SELECT * FROM V_DWV_IORD_SORT_STATUS WHERE IS_IMPORT ='0'";
            return this.ExecuteQuery(sql).Tables[0];
        }

        /// <summary>
        /// ����ּ������DWV_IORD_SORT_STATUS�����������ݿ�
        /// </summary>
        /// <param name="orderDetailTable"></param>
        public void InsertSortStatus(DataTable sortStatusTable)
        {
            foreach (DataRow row in sortStatusTable.Rows)
            {
                string sql = string.Format("INSERT INTO DWV_IORD_SORT_STATUS(SORT_BILL_ID,ORG_CODE,SORTING_CODE,SORT_DATE,SORT_SPEC," +
                    "SORT_QUANTITY,SORT_ORDER_NUM,SORT_BEGIN_DATE,SORT_END_DATE,SORT_COST_TIME,IS_IMPORT)VALUES('{0}','{1}','{2}','{3}',{4},{5},{6},'{7}','{8}',{9},'{10}')",
                    row["SORT_BILL_ID"], row["ORG_CODE"], row["SORTING_CODE"], row["SORT_DATE"], row["SORT_SPEC"], row["SORT_QUANTITY"], row["SORT_ORDER_NUM"],
                    row["SORT_BEGIN_DATE"], row["SORT_END_DATE"], row["SORT_COST_TIME"], row["IS_IMPORT"]);
                this.ExecuteNonQuery(sql);
            }
        }

        /// <summary>
        /// �޸ķּ��������Ϣ�ϱ�״̬
        /// </summary>
        /// <param name="productCode"></param>
        public void UpdateSortStatus(string sortStatusCode)
        {
            string sql = "UPDATE DWV_IORD_SORT_STATUS SET IS_IMPORT='1' WHERE IS_IMPORT='0'";
            this.ExecuteNonQuery(sql);
        }


        #endregion


        #region ��ѯ�ּ�����Ϣ�����ݣ��ϱ�����

        /// <summary>
        /// ��ѯ�ּ�����Ϣ��DWV_IDPS_SORTING�����ϱ�����
        /// </summary>
        /// <returns></returns>
        public DataTable QueryIdpsSorting()
        {
            string sql = "SELECT * FROM V_DWV_IDPS_SORTING WHERE IS_IMPORT ='0'";
            return this.ExecuteQuery(sql).Tables[0];
        }

        /// <summary>
        /// ����ּ�����Ϣ��DWV_IORD_SORT_STATUS�����������ݿ�
        /// </summary>
        /// <param name="orderDetailTable"></param>
        public void InsertIdpsSorting(DataTable SortingTable)
        {
            foreach (DataRow row in SortingTable.Rows)
            {
                string sql = string.Format("INSERT INTO DWV_IDPS_SORTING(SORTING_CODE,SORTING_NAME,SORTING_TYPE,ISACTIVE,UPDATE_DATE," +
                    "IS_IMPORT)VALUES('{0}','{1}','{2}','{3}','{4}','{5}')",
                    row["SORTING_CODE"], row["SORTING_NAME"], row["SORTING_TYPE"], row["ISACTIVE"], row["UPDATE_DATE"], row["IS_IMPORT"]);
                this.ExecuteNonQuery(sql);
            }
        }

        /// <summary>
        /// �޸ķּ�����Ϣ���ϱ�״̬
        /// </summary>
        /// <param name="productCode"></param>
        public void UpdateSorting(string sortingCode)
        {
            string sql = string.Format("UPDATE DWV_DPS_SORTING SET IS_IMPORT='1' WHERE IS_IMPORT='0'");
            this.ExecuteNonQuery(sql);
        }

        #endregion


        #region ��ѯ�ִ����Ա�

        /// <summary>
        /// ��ѯ�ִ����Ա�DWV_IBAS_STORAGE�����ϱ�����
        /// </summary>
        /// <returns></returns>
        public DataTable QueryIbasSorting()
        {
            string sql = "SELECT * FROM V_DWV_IBAS_STORAGE WHERE IS_IMPORT ='0'";
            return this.ExecuteQuery(sql).Tables[0];
        }

        /// <summary>
        /// ����ִ����Ա�DWV_IORD_SORT_STATUS�����������ݿ�
        /// </summary>
        /// <param name="orderDetailTable"></param>
        public void InsertIbasSorting(DataTable IbasSortingTable)
        {
            foreach (DataRow row in IbasSortingTable.Rows)
            {
                string date = Convert.ToDateTime(row["UPDATE_DATE"]).ToString("yyyyMMddHHmmss");
                string sql = string.Format("INSERT INTO DWV_IBAS_STORAGE(STORAGE_CODE,STORAGE_TYPE ,CONTAINER,STORAGE_NAME,UP_CODE,CAPACITY," +
                    "AREA_TYPE,UPDATE_DATE,ISACTIVE,IS_IMPORT)VALUES('{0}','{1}','{2}','{3}','{4}',{5},'{6}','{7}','{8}','{9}')",
                    row["STORAGE_CODE"], row["STORAGE_TYPE"], row["CONTAINER"], row["STORAGE_NAME"], row["UP_CODE"], row["CAPACITY"], row["AREA_TYPE"],
                    date, row["ISACTIVE"], row["IS_IMPORT"]);
                this.ExecuteNonQuery(sql);
            }
        }

        /// <summary>
        /// �޸Ĳִ����Ա��ϱ�״̬
        /// </summary>
        /// <param name="productCode"></param>
        public void UpdateIbsaSorting(string IbasSortingCode)
        {
            string sql = string.Format("UPDATE WMS_WH_CELL SET IS_IMPORT='1' WHERE IS_IMPORT='0'");
            this.ExecuteNonQuery(sql);
        }

        #endregion


        #region ��ѯ��������

        /// <summary>
        /// ��ͬ�����в�������
        /// </summary>
        /// <param name="syncCode"></param>
        /// <param name="syncName"></param>
        public void InsertSynchroInfo(string syncCode, string syncName)
        {
            string sql = string.Format("INSERT INTO DWV_IOUT_SYNCHRO_INFO([SYNC_TYPE_CODE],[SYNC_TYPE_NAME],[DESCRIPTION],[UPDATE_DATE],[IS_IMPORT],[REMARK]) " +
            "VALUES('{0}','{1}','{2}','{3}','{4}','{5}')",
              syncCode, syncName, " ", DateTime.Now.ToString("yyyyMMddHHmmss"), "0", " ");
            this.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// ���ݵ��ݺŲ�ѯ�ս�״̬
        /// </summary>
        /// <param name="orderCode"></param>
        /// <returns></returns>
        public string GetOrderCodeByDayStatus(string orderCode)
        {
            string sql = string.Format("{0}", orderCode);
            return Convert.ToString(this.ExecuteScalar(sql).ToString());
        }

        /// <summary>
        /// ��ѯ��λ��ҵ���������
        /// </summary>
        /// <returns></returns>
        public DataTable QueryCellQuantity()
        {
            string sql = @"SELECT '01' AS ORG_CODE,CURRENTPRODUCT,SUM(QTY_STA) AS QUANTITY
                            FROM V_WMS_WH_CELL WHERE CURRENTPRODUCT IS NOT NULL GROUP BY CURRENTPRODUCT";
            return this.ExecuteQuery(sql).Tables[0];
        }

        /// <summary>
        /// ��ѯ��λ��ҵ����������
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public DataTable QueryCellTiao(string product)
        {
            string sql = string.Format("SELECT ISNULL(SUM(QUANTITY),0) AS QUANTITY FROM  WMS_WH_CELL WHERE CURRENTPRODUCT='{0}' AND AREATYPE='1'", product);
            return this.ExecuteQuery(sql).Tables[0];
        }

        /// <summary>
        /// �������ݵ�ҵ�����
        /// </summary>
        /// <param name="busiTable"></param>
        public void InsertBusiStockQuntity(DataTable busiTable)
        {
            this.BatchInsert(busiTable, "DWV_IWMS_BUSI_STOCK");
        }

        /// <summary>
        /// ��ȡ�������ı���
        /// </summary>
        /// <returns></returns>
        public string GetCompany()
        {
            string sql = "SELECT DIST_CTR_CODE FROM DWV_OUT_DIST_CTR";
            return this.ExecuteScalar(sql).ToString();
        }

        /// <summary>
        /// ֧ת��Ϊ���Ļ���
        /// </summary>
        /// <param name="productCode"></param>
        /// <returns></returns>
        public DataTable ProductRate(string productCode)
        {
            string sql = "SELECT A.PRODUCTCODE,A.PRODUCTNAME,A.UNITCODE,A.JIANCODE," +
                "(SELECT B.STANDARDRATE FROM WMS_PRODUCT AS A,WMS_UNIT AS B WHERE A.JIANCODE=B.UNITCODE AND A.PRODUCTCODE='" + productCode + "') AS JIANRATE," +
                "(SELECT B.STANDARDRATE FROM WMS_PRODUCT AS A,WMS_UNIT AS B WHERE A.TIAOCODE=B.UNITCODE AND A.PRODUCTCODE='" + productCode + "') AS TIAORATE " +
                "FROM WMS_PRODUCT AS A,WMS_UNIT AS B WHERE  A.PRODUCTCODE='" + productCode + "' GROUP BY A.PRODUCTCODE,A.PRODUCTNAME,A.UNITCODE,A.JIANCODE";
            return this.ExecuteQuery(sql).Tables[0];
        }

        #endregion

    }
}
