using System;
using System.Collections.Generic;
using System.Text;
using THOK.WMS.Upload.Dao;
using System.Data;
using THOK.Util;

namespace THOK.WMS.Upload.Bll
{
    public class UploadBll
    {

        #region ��ѯ������Ϣ����

        /// <summary>
        /// ��ѯ������Ϣ���ϱ�
        /// </summary>
        public string FindProduct()
        {
            string tag = "�ϱ�������Ϣ��ɹ���";
            using (PersistentManager dbpm = new PersistentManager("ZYDB2Connection"))
            {
                UploadDao dao = new UploadDao();                
                dao.SetPersistentManager(dbpm);
                DataTable brandTable = this.QueryProductInfo();
                if (brandTable.Rows.Count > 0)
                {
                    try
                    {
                        dbpm.BeginTransaction();
                        dao.InsertProduct(brandTable);
                        this.UpdateProduct();
                        dbpm.Commit();
                    }
                    catch (Exception exp)
                    {
                        dbpm.Rollback();
                        throw new Exception(exp.Message);
                    }
                }
                else
                    tag = "û���µľ�����ϢҪ�ϱ���";
            }
            return tag;
        }

        /// <summary>
        /// ��ѯ���̲�Ʒ��Ϣ
        /// </summary>
        /// <returns></returns>
        public DataTable QueryProductInfo()
        {
            using (PersistentManager pm = new PersistentManager())
            {
                UploadDao dao = new UploadDao();
                dao.SetPersistentManager(pm);
                return dao.QueryProductInfo();
            }
        }

        /// <summary>
        /// �޸ľ�����Ϣ���ϱ�״̬
        /// </summary>
        /// <param name="productCode"></param>
        public void UpdateProduct()
        {
            using (PersistentManager pm = new PersistentManager())
            {
                UploadDao dao = new UploadDao();
                dao.SetPersistentManager(pm);
                dao.UpdateProduct();
                dao.InsertSynchroInfo("DWV_IINF_BRAND", "������Ϣ��");
            }
        }

        #endregion


        #region ��ѯ��֯�ṹ������

        /// <summary>
        /// ��ѯ��֯�ṹ���ϱ�
        /// </summary>
        public string FindOrganization()
        {
            string tag = "�ϱ���֯�ṹ��ɹ���";
            using (PersistentManager dbpm = new PersistentManager("ZYDB2Connection"))
            {
                UploadDao dao = new UploadDao();
                dao.SetPersistentManager(dbpm);
                DataTable organizationTable = this.QueryOrganization();
                if (organizationTable.Rows.Count > 0)
                {
                    try
                    {
                        dbpm.BeginTransaction();
                        dao.InsertOrganization(organizationTable);
                        this.UpdateOrganization();
                        dbpm.Commit();
                    }
                    catch (Exception exp)
                    {
                        dbpm.Rollback();
                        throw new Exception(exp.Message);
                    }
                }
                else
                    tag = "û���µ���֯�ṹ��ϢҪ�ϱ���";
            }
            return tag;
        }

        /// <summary>
        /// ��ѯ��֯�ṹ��
        /// </summary>
        /// <returns></returns>
        public DataTable QueryOrganization()
        {
            using (PersistentManager pm = new PersistentManager())
            {
                UploadDao dao = new UploadDao();
                dao.SetPersistentManager(pm);
                return dao.QueryOrganization();
            }
        }

        /// <summary>
        /// �޸���֯�ṹ����Ϣ�ϱ�״̬
        /// </summary>
        /// <param name="productCode"></param>
        public void UpdateOrganization()
        {
            using (PersistentManager pm = new PersistentManager())
            {
                UploadDao dao = new UploadDao();
                dao.SetPersistentManager(pm);
                dao.UpdateOrganization();
                dao.InsertSynchroInfo("DWV_IORG_ORGANIZATION", "��֯�ṹ��");
            }
        }


        #endregion


        #region ��ѯ��Ա��Ϣ������

        /// <summary>
        /// ��ѯ��Ա��Ϣ���ϱ�
        /// </summary>
        public string FindPerson()
        {
            string tag = "�ϱ���Ա��Ϣ��ɹ���";
            using (PersistentManager dbpm = new PersistentManager("ZYDB2Connection"))
            {
                UploadDao dao = new UploadDao();
                dao.SetPersistentManager(dbpm);
                DataTable personTable = this.QueryPerson();
                if (personTable.Rows.Count > 0)
                {
                    try
                    {
                        dbpm.BeginTransaction();
                        dao.InsertPreson(personTable);
                        this.UpdatePerson();
                        dbpm.Commit();
                    }
                    catch (Exception exp)
                    {
                        dbpm.Rollback();
                        throw new Exception(exp.Message);
                    }
                }
                else
                    tag = "û���µ���Ա��ϢҪ�ϱ���";
            }
            return tag;
        }

        /// <summary>
        /// ��ѯ��Ա��Ϣ��
        /// </summary>
        /// <returns></returns>
        public DataTable QueryPerson()
        {
            using (PersistentManager pm = new PersistentManager())
            {
                UploadDao dao = new UploadDao();
                dao.SetPersistentManager(pm);
                return dao.QueryPerson();
            }
        }

        /// <summary>
        /// �޸���Ա��Ϣ����Ϣ�ϱ�״̬
        /// </summary>
        /// <param name="productCode"></param>
        public void UpdatePerson()
        {
            using (PersistentManager pm = new PersistentManager())
            {
                UploadDao dao = new UploadDao();
                dao.SetPersistentManager(pm);
                dao.UpdatePerson();
                dao.InsertSynchroInfo("DWV_IORG_PERSON", "��Ա��Ϣ��");
            }
        }
        #endregion


        #region ��ѯ�ͻ���Ϣ������

        /// <summary>
        /// ��ѯ�ͻ���Ϣ���ϱ�
        /// </summary>
        public string FindCustomer()
        {
            string tag = "�ϱ��ͻ���Ϣ��ɹ���";
            using (PersistentManager dbpm = new PersistentManager("ZYDB2Connection"))
            {
                UploadDao dao = new UploadDao();
                dao.SetPersistentManager(dbpm);
                DataTable customerTable = this.QueryCustomer();
                if (customerTable.Rows.Count > 0)
                {
                    try
                    {
                        dbpm.BeginTransaction();
                        dao.InsertCustomer(customerTable);
                        this.UpdateCustomer("");
                        dbpm.Commit();
                    }
                    catch (Exception exp)
                    {
                        dbpm.Rollback();
                        throw new Exception(exp.Message);
                    }
                }
                else
                    tag = "û���µĿͻ���ϢҪ�ϱ���";
            } return tag;
        }

        /// <summary>
        /// ��ѯ�ͻ���Ϣ��
        /// </summary>
        /// <returns></returns>
        public DataTable QueryCustomer()
        {
            using (PersistentManager pm = new PersistentManager())
            {
                UploadDao dao = new UploadDao();
                dao.SetPersistentManager(pm);
                return dao.QueryCustomer();
            }
        }

        /// <summary>
        /// �޸Ŀͻ���Ϣ����Ϣ�ϱ�״̬
        /// </summary>
        /// <param name="productCode"></param>
        public void UpdateCustomer(string customerCode)
        {
            using (PersistentManager pm = new PersistentManager())
            {
                UploadDao dao = new UploadDao();
                dao.SetPersistentManager(pm);
                dao.UpdateCustomer(customerCode);
                dao.InsertSynchroInfo("DWV_IORG_CUSTOMER", "�ͻ���Ϣ��");
            }
        }

        #endregion


        #region ��ѯ�ֿ��������

        /// <summary>
        /// ��ѯ�ֿ�����ϱ�
        /// </summary>
        public string FindStoreStock()
        {
            string tag = "�ϱ��ֿ����ɹ���";
            using (PersistentManager dbpm = new PersistentManager("ZYDB2Connection"))
            {
                UploadDao dao = new UploadDao();
                dao.SetPersistentManager(dbpm);
                DataTable stockTable = this.QueryStoreStock();
                DataTable stockQuantityTable = this.InsertStoreQuantity(stockTable);
                if (stockQuantityTable.Rows.Count > 0)
                {
                    try
                    {
                        dbpm.BeginTransaction();
                        dao.InsertStoreStock(stockQuantityTable);
                        this.UpdateStoreStock("");
                        dbpm.Commit();
                    }
                    catch (Exception exp)
                    {
                        dbpm.Rollback();
                        throw new Exception(exp.Message);
                    }
                }
                else
                    tag = "û���µĲֿ����Ҫ�ϱ���";
            }
            return tag;
        }


        /// <summary>
        /// ��ѯ�ֿ����
        /// </summary>
        /// <returns></returns>
        public DataTable QueryStoreStock()
        {
            using (PersistentManager pm = new PersistentManager())
            {
                UploadDao dao = new UploadDao();
                dao.SetPersistentManager(pm);
                return dao.QueryStoreStock();
            }
        }

        /// <summary>
        /// �޸Ĳֿ������Ϣ�ϱ�״̬
        /// </summary>
        /// <param name="productCode"></param>
        public void UpdateStoreStock(string storeStockCode)
        {
            using (PersistentManager pm = new PersistentManager())
            {
                UploadDao dao = new UploadDao();
                dao.SetPersistentManager(pm);
                dao.UpdateStoreStock(storeStockCode);
                dao.InsertSynchroInfo("DWV_IWMS_STORE_STOCK", "�ֿ����");
            }
        }

        /// <summary>
        /// �Ѳֿ�������ݲ��������
        /// </summary>
        /// <param name="busiTable"></param>
        public DataTable InsertStoreQuantity(DataTable stortStockQuantityTable)
        {
            DataSet ds = this.GenerateStoreTables();
            foreach (DataRow row in stortStockQuantityTable.Rows)
            {
                DataRow storerow = ds.Tables["DWV_IWMS_STORE_STOCK"].NewRow();
                storerow["STORE_PLACE_CODE"] = row["STORE_PLACE_CODE"].ToString().Trim();
                storerow["BRAND_CODE"] = row["CURRENTPRODUCT"].ToString().Trim();
                storerow["AREA_TYPE"] = row["AREA_TYPE"];
                storerow["BRAND_BATCH"] = row["BRAND_BATCH"];
                storerow["DIST_CTR_CODE"] = this.GetCompany().ToString();
                storerow["QUANTITY"] = row["QUANTITY"];
                storerow["IS_IMPORT"] = "0";
                ds.Tables["DWV_IWMS_STORE_STOCK"].Rows.Add(storerow);
            }
            return ds.Tables[0];
        }



        /// <summary>
        /// ���������
        /// </summary>
        /// <returns></returns>
        private DataSet GenerateStoreTables()
        {
            DataSet ds = new DataSet();
            DataTable storedetail = ds.Tables.Add("DWV_IWMS_STORE_STOCK");
            storedetail.Columns.Add("STORE_PLACE_CODE");
            storedetail.Columns.Add("BRAND_CODE");
            storedetail.Columns.Add("AREA_TYPE");
            storedetail.Columns.Add("BRAND_BATCH");
            storedetail.Columns.Add("DIST_CTR_CODE");
            storedetail.Columns.Add("QUANTITY");
            storedetail.Columns.Add("IS_IMPORT");
            return ds;
        }

        #endregion


        #region ��ѯҵ���������

        /// <summary>
        /// ��ѯҵ�������ϱ�
        /// </summary>
        public string FindBusiStock()
        {
            string tag = "�ϱ�ҵ�����ɹ���";
            using (PersistentManager dbpm = new PersistentManager("ZYDB2Connection"))
            {
                UploadDao dao = new UploadDao();
                dao.SetPersistentManager(dbpm);
                DataTable busiStockTable = this.QueryBusiStock();
                if (busiStockTable.Rows.Count > 0)
                {
                    try
                    {
                        dbpm.BeginTransaction();
                        dao.InsertBustStock(busiStockTable);
                        this.UpdateBusiStock("");
                        dbpm.Commit();
                    }
                    catch (Exception exp)
                    {
                        dbpm.Rollback();
                        throw new Exception(exp.Message);
                    }
                }
                else
                    tag = "û���µ�ҵ������ϢҪ�ϱ���";
            }
            return tag;
        }

        /// <summary>
        /// ��ѯҵ�����
        /// </summary>
        /// <returns></returns>
        public DataTable QueryBusiStock()
        {
            using (PersistentManager pm = new PersistentManager())
            {
                UploadDao dao = new UploadDao();
                dao.SetPersistentManager(pm);
                return dao.QueryBusiStock();
            }
        }

        /// <summary>
        /// �޸�ҵ�������Ϣ�ϱ�״̬
        /// </summary>
        /// <param name="productCode"></param>
        public void UpdateBusiStock(string busiStockCode)
        {
            using (PersistentManager pm = new PersistentManager())
            {
                UploadDao dao = new UploadDao();
                dao.SetPersistentManager(pm);
                dao.UpdateBusiStock(busiStockCode);
                dao.InsertSynchroInfo("DWV_IWMS_BUSI_STOCK", "ҵ�����");
            }
        }

        #endregion


        #region ��ѯ�ֿ���ⵥ����������

        /// <summary>
        /// ��ѯ�ֿ���ⵥ�������ϱ�
        /// </summary>
        public string FindInMasterBill()
        {
            string tag = "�ϱ��ֿ���ⵥ������ɹ���";
            using (PersistentManager dbpm = new PersistentManager("ZYDB2Connection"))
            {
                UploadDao dao = new UploadDao();
                dao.SetPersistentManager(dbpm);
                DataTable inMasterTable = this.QueryInMasterBill();
                if (inMasterTable.Rows.Count > 0)
                {
                    try
                    {
                        dbpm.BeginTransaction();
                        dao.InsertInMasterBill(inMasterTable);
                        this.UpdateInMaster("");
                        dbpm.Commit();
                    }
                    catch (Exception exp)
                    {
                        dbpm.Rollback();
                        throw new Exception(exp.Message);
                    }
                }
                else
                    tag = "û���µĲֿ������ϢҪ�ϱ���";
            }
            return tag;
        }

        /// <summary>
        /// ��ѯ�ֿ���ⵥ������
        /// </summary>
        /// <returns></returns>
        public DataTable QueryInMasterBill()
        {
            using (PersistentManager pm = new PersistentManager())
            {
                UploadDao dao = new UploadDao();
                dao.SetPersistentManager(pm);
                return dao.QueryInMasterBill();
            }
        }

        /// <summary>
        /// �޸Ĳֿ���ⵥ��������Ϣ�ϱ�״̬
        /// </summary>
        /// <param name="productCode"></param>
        public void UpdateInMaster(string inMasterCode)
        {
            using (PersistentManager pm = new PersistentManager())
            {
                UploadDao dao = new UploadDao();
                dao.SetPersistentManager(pm);
                dao.UpdateInMaster(inMasterCode);
                dao.InsertSynchroInfo("DWV_IWMS_IN_STORE_BILL", "�ֿ���ⵥ������");
            }
        }
        #endregion


        #region ��ѯ�ֿ���ⵥ��ϸ������

        /// <summary>
        /// ��ѯ�ֿ���ⵥ��ϸ���ϱ�
        /// </summary>
        public string FindInDetailBill()
        {
            string tag = "�ϱ��ֿ���ⵥ��ϸ��ɹ���";
            using (PersistentManager dbpm = new PersistentManager("ZYDB2Connection"))
            {
                UploadDao dao = new UploadDao();
                dao.SetPersistentManager(dbpm);
                DataTable inDetailTable = this.QueryInDetailBill();
                if (inDetailTable.Rows.Count > 0)
                {
                    try
                    {
                        dbpm.BeginTransaction();
                        dao.InsertInDetailBill(inDetailTable);
                        this.UpdateInDetail("");
                        dbpm.Commit();
                    }
                    catch (Exception exp)
                    {
                        dbpm.Rollback();
                        throw new Exception(exp.Message);
                    }
                }
                else
                    tag = "û���µĲֿ����ϸ����ϢҪ�ϱ���";
            }
            return tag;
        }


        /// <summary>
        /// ��ѯ�ֿ���ⵥ��ϸ��
        /// </summary>
        /// <returns></returns>
        public DataTable QueryInDetailBill()
        {
            using (PersistentManager pm = new PersistentManager())
            {
                UploadDao dao = new UploadDao();
                dao.SetPersistentManager(pm);
                return dao.QueryInDetailBill();
            }
        }

        /// <summary>
        /// �޸Ĳֿ���ⵥ��ϸ����Ϣ�ϱ�״̬
        /// </summary>
        /// <param name="productCode"></param>
        public void UpdateInDetail(string inDetailCode)
        {
            using (PersistentManager pm = new PersistentManager())
            {
                UploadDao dao = new UploadDao();
                dao.SetPersistentManager(pm);
                dao.UpdateInDetail(inDetailCode);
                dao.InsertSynchroInfo("DWV_IWMS_IN_STORE_BILL_DETAIL", "�ֿ���ⵥ��ϸ��");
            }
        }
        #endregion


        #region ��ѯ���ҵ�񵥾ݱ�����

        /// <summary>
        /// ��ѯ���ҵ�񵥾ݱ��ϱ�
        /// </summary>
        public string FindInBusiBill()
        {
            string tag = "�ϱ��ֿ����ҵ�񵥾ݱ�ɹ���";
            using (PersistentManager dbpm = new PersistentManager("ZYDB2Connection"))
            {
                UploadDao dao = new UploadDao();
                dao.SetPersistentManager(dbpm);
                DataTable inBusiTable = this.QueryInBusiBill();
                if (inBusiTable.Rows.Count > 0)
                {
                    try
                    {
                        dbpm.BeginTransaction();
                        dao.InsertInBusiBill(inBusiTable);
                        this.UpdateInBusi("");
                        dbpm.Commit();
                    }
                    catch (Exception exp)
                    {
                        dbpm.Rollback();
                        throw new Exception(exp.Message);
                    }
                }
                else
                    tag = "û���µ����ҵ�񵥾���ϢҪ�ϱ���";
            }
            return tag;
        }


        /// <summary>
        /// ��ѯ���ҵ�񵥾ݱ�
        /// </summary>
        /// <returns></returns>
        public DataTable QueryInBusiBill()
        {
            using (PersistentManager pm = new PersistentManager())
            {
                UploadDao dao = new UploadDao();
                dao.SetPersistentManager(pm);
                return dao.QueryInBusiBill();
            }
        }

        /// <summary>
        /// �޸����ҵ�񵥾ݱ���Ϣ�ϱ�״̬
        /// </summary>
        /// <param name="productCode"></param>
        public void UpdateInBusi(string inBusiCode)
        {
            using (PersistentManager pm = new PersistentManager())
            {
                UploadDao dao = new UploadDao();
                dao.SetPersistentManager(pm);
                dao.UpdateInBusi(inBusiCode);
                dao.InsertSynchroInfo("DWV_IWMS_IN_BUSI_BILL", "���ҵ�񵥾ݱ�");
            }
        }

        #endregion


        #region ��ѯ�ֿ���ⵥ����������

        /// <summary>
        /// ��ѯ�ֿ���ⵥ�������ϱ�
        /// </summary>
        public string FindOutMasterBill()
        {
            string tag = "�ϱ��ֿ���ⵥ������ɹ���";
            using (PersistentManager dbpm = new PersistentManager("ZYDB2Connection"))
            {
                UploadDao dao = new UploadDao();
                dao.SetPersistentManager(dbpm);
                DataTable outMasterTable = this.QueryOutMasterBill();
                if (outMasterTable.Rows.Count > 0)
                {
                    try
                    {
                        dbpm.BeginTransaction();
                        dao.InsertOutMasertBill(outMasterTable);
                        this.UpdateOutMaster("");
                        dbpm.Commit();
                    }
                    catch (Exception exp)
                    {
                        dbpm.Rollback();
                        throw new Exception(exp.Message);
                    }
                }
                else
                    tag = "û���µĲֿ���ⵥ������Ҫ�ϱ���";
            }
            return tag;
        }

        /// <summary>
        /// ��ѯ�ֿ���ⵥ������
        /// </summary>
        /// <returns></returns>
        public DataTable QueryOutMasterBill()
        {
            using (PersistentManager pm = new PersistentManager())
            {
                UploadDao dao = new UploadDao();
                dao.SetPersistentManager(pm);
                return dao.QueryOutMasterBill();
            }
        }

        /// <summary>
        /// �޸Ĳֿ���ⵥ��������Ϣ�ϱ�״̬
        /// </summary>
        /// <param name="productCode"></param>
        public void UpdateOutMaster(string outMasterCode)
        {
            using (PersistentManager pm = new PersistentManager())
            {
                UploadDao dao = new UploadDao();
                dao.SetPersistentManager(pm);
                dao.UpdateOutMaster(outMasterCode);
                dao.InsertSynchroInfo("DWV_IWMS_OUT_STORE_BILL", "�ֿ���ⵥ������");
            }
        }
        #endregion


        #region ��ѯ�ֿ���ⵥ��ϸ������

        /// <summary>
        /// ��ѯ�ֿ���ⵥ��ϸ���ϱ�
        /// </summary>
        public string FindOutDetailBill()
        {
            string tag = "�ϱ��ֿ���ⵥ��ϸ��ɹ���";
            using (PersistentManager dbpm = new PersistentManager("ZYDB2Connection"))
            {
                UploadDao dao = new UploadDao();
                dao.SetPersistentManager(dbpm);
                DataTable outDetailTable = this.QueryOutDetailBill();
                if (outDetailTable.Rows.Count > 0)
                {
                    try
                    {
                        dbpm.BeginTransaction();
                        dao.InsertOutDetailBill(outDetailTable);
                        this.UpdateOutDetail("");
                        dbpm.Commit();
                    }
                    catch (Exception exp)
                    {
                        dbpm.Rollback();
                        throw new Exception(exp.Message);
                    }
                }
                else
                    tag = "û���µĲֿ���ⵥ��ϸ��Ҫ�ϱ���";
            }
            return tag;
        }


        /// <summary>
        /// ��ѯ�ֿ���ⵥ��ϸ��
        /// </summary>
        /// <returns></returns>
        public DataTable QueryOutDetailBill()
        {
            using (PersistentManager pm = new PersistentManager())
            {
                UploadDao dao = new UploadDao();
                dao.SetPersistentManager(pm);
                return dao.QueryOutDetailBill();
            }
        }

        /// <summary>
        /// �޸Ĳֿ���ⵥ��ϸ����Ϣ�ϱ�״̬
        /// </summary>
        /// <param name="productCode"></param>
        public void UpdateOutDetail(string outDetailCode)
        {
            using (PersistentManager pm = new PersistentManager())
            {
                UploadDao dao = new UploadDao();
                dao.SetPersistentManager(pm);
                dao.UpdateOutDetail(outDetailCode);
                dao.InsertSynchroInfo("DWV_IWMS_OUT_STORE_BILL_DETAIL", "�ֿ���ⵥ��ϸ��");
            }
        }
        #endregion


        #region ��ѯ����ҵ�񵥾ݱ�����

        /// <summary>
        /// ��ѯ����ҵ�񵥾ݱ��ϱ�
        /// </summary>
        public string FindOutBusiBill()
        {
            string tag = "�ϱ��ֿ����ҵ�񵥾ݱ�ɹ���";
            using (PersistentManager dbpm = new PersistentManager("ZYDB2Connection"))
            {
                UploadDao dao = new UploadDao();
                dao.SetPersistentManager(dbpm);
                DataTable outBusiTable = this.QueryOutBusiBill();
                if (outBusiTable.Rows.Count > 0)
                {
                    try
                    {
                        dbpm.BeginTransaction();
                        dao.InsertOutBusiBill(outBusiTable);
                        this.UpdateOutBusi("");
                        dbpm.Commit();
                    }
                    catch (Exception exp)
                    {
                        dbpm.Rollback();
                        throw new Exception(exp.Message);
                    }
                }
                else
                    tag = "û���µĲֿ����ҵ�񵥾ݱ�Ҫ�ϱ���";
            }
            return tag;
        }

        /// <summary>
        /// ��ѯ����ҵ�񵥾ݱ�
        /// </summary>
        /// <returns></returns>
        public DataTable QueryOutBusiBill()
        {
            using (PersistentManager pm = new PersistentManager())
            {
                UploadDao dao = new UploadDao();
                dao.SetPersistentManager(pm);
                return dao.QueryOutBusiBill();
            }
        }

        /// <summary>
        /// �޸ĳ���ҵ�񵥾ݱ���Ϣ�ϱ�״̬
        /// </summary>
        /// <param name="productCode"></param>
        public void UpdateOutBusi(string outBusiCode)
        {
            using (PersistentManager pm = new PersistentManager())
            {
                UploadDao dao = new UploadDao();
                dao.SetPersistentManager(pm);
                dao.UpdateOutBusi(outBusiCode);
                dao.InsertSynchroInfo("DWV_IWMS_OUT_BUSI_BILL", "����ҵ�񵥾ݱ�");
            }
        }

        #endregion


        #region ��ѯͬ��״̬������

        /// <summary>
        /// ��ѯͬ��״̬���ϱ�
        /// </summary>
        public string FindSynchroInfo()
        {
            string tag = "�ϱ�ͬ��״̬��ɹ���";
            using (PersistentManager dbpm = new PersistentManager("ZYDB2Connection"))
            {
                UploadDao dao = new UploadDao();
                dao.SetPersistentManager(dbpm);
                DataTable synchroTable = this.QuerySynchroInfo();
                if (synchroTable.Rows.Count > 0)
                {
                    try
                    {
                        dbpm.BeginTransaction();
                        dao.InsertSynchro(synchroTable);
                        this.UpdateSyachro("");
                        dbpm.Commit();
                    }
                    catch (Exception exp)
                    {
                        dbpm.Rollback();
                        throw new Exception(exp.Message);
                    }
                }
                else
                    tag = "û��ͬ��״̬�����ݿ��ϱ���";
            }
            return tag;
        }

        /// <summary>
        /// ��ѯͬ��״̬��
        /// </summary>
        /// <returns></returns>
        public DataTable QuerySynchroInfo()
        {
            using (PersistentManager pm = new PersistentManager())
            {
                UploadDao dao = new UploadDao();
                dao.SetPersistentManager(pm);
                return dao.QuerySynchroInfo();
            }
        }

        /// <summary>
        /// �޸�ͬ��״̬����Ϣ�ϱ�״̬
        /// </summary>
        /// <param name="productCode"></param>
        public void UpdateSyachro(string syachroCode)
        {
            using (PersistentManager pm = new PersistentManager())
            {
                UploadDao dao = new UploadDao();
                dao.SetPersistentManager(pm);
                dao.UpdateSyachro(syachroCode);
            }
        }

        #endregion


        #region ��ѯ�ּ𶩵���������
        /// <summary>
        /// ��ѯ�ּ𶩵������ϱ�
        /// </summary>
        public string FindIordMasterOrder()
        {
            string tag = "�ϱ��ּ𶩵�����ɹ���";
            using (PersistentManager dbpm = new PersistentManager("ZYDB2Connection"))
            {
                UploadDao dao = new UploadDao();
                dao.SetPersistentManager(dbpm);
                DataTable orderMasterTable = this.QueryIordMasterOrder();
                if (orderMasterTable.Rows.Count > 0)
                {
                    try
                    {
                        dbpm.BeginTransaction();
                        dao.InsertIordOrder(orderMasterTable);
                        this.UpdateOrderMaster("");
                        dbpm.Commit();
                    }
                    catch (Exception exp)
                    {
                        dbpm.Rollback();
                        throw new Exception(exp.Message);
                    }
                }
                else
                    tag = "û���µķּ𶩵�����Ҫ�ϱ���";
            }
            return tag;
        }

        /// <summary>
        /// ��ѯ�ּ𶩵�����
        /// </summary>
        /// <returns></returns>
        public DataTable QueryIordMasterOrder()
        {
            using (PersistentManager pm = new PersistentManager())
            {
                UploadDao dao = new UploadDao();
                dao.SetPersistentManager(pm);
                return dao.QueryIordMasterOrder();
            }
        }

        /// <summary>
        /// �޸ķּ𶩵�������Ϣ�ϱ�״̬
        /// </summary>
        /// <param name="productCode"></param>
        public void UpdateOrderMaster(string orderMasterCode)
        {
            using (PersistentManager pm = new PersistentManager())
            {
                UploadDao dao = new UploadDao();
                dao.SetPersistentManager(pm);
                dao.UpdateOrderMaster(orderMasterCode);
                dao.InsertSynchroInfo("DWV_OUT_ORDER", "�ּ𶩵�����");
            }
        }
        #endregion


        #region ��ѯ�ּ𶩵�ϸ������

        /// <summary>
        /// ��ѯ�ּ𶩵�ϸ���ϱ�
        /// </summary>
        public string FindIordDetailOrder()
        {
            string tag = "�ϱ��ּ𶩵�ϸ��ɹ���";
            using (PersistentManager dbpm = new PersistentManager("ZYDB2Connection"))
            {
                UploadDao dao = new UploadDao();
                dao.SetPersistentManager(dbpm);
                DataTable orderDetailTable = this.QueryIordDetailOrder();
                if (orderDetailTable.Rows.Count > 0)
                {
                    try
                    {
                        dbpm.BeginTransaction();
                        dao.InsertIordOrderDetail(orderDetailTable);
                        this.UpdateOrderDetail("");
                        dbpm.Commit();
                    }
                    catch (Exception exp)
                    {
                        dbpm.Rollback();
                        throw new Exception(exp.Message);
                    }
                }
                else
                    tag = "û���µķּ𶩵�ϸ��Ҫ�ϱ���";
            }
            return tag;
        }

        /// <summary>
        /// ��ѯ�ּ𶩵�ϸ��
        /// </summary>
        /// <returns></returns>
        public DataTable QueryIordDetailOrder()
        {
            using (PersistentManager pm = new PersistentManager())
            {
                UploadDao dao = new UploadDao();
                dao.SetPersistentManager(pm);
                return dao.QueryIordDetailOrder();
            }
        }

        /// <summary>
        /// �޸ķּ𶩵�ϸ����Ϣ�ϱ�״̬
        /// </summary>
        /// <param name="productCode"></param>
        public void UpdateOrderDetail(string orderDetailCode)
        {
            using (PersistentManager pm = new PersistentManager())
            {
                UploadDao dao = new UploadDao();
                dao.SetPersistentManager(pm);
                dao.UpdateOrderDetail(orderDetailCode);
                dao.InsertSynchroInfo("DWV_OUT_ORDER_DETAIL", "�ּ𶩵�ϸ��");
            }
        }
        #endregion


        #region ��ѯ�ּ����������

        /// <summary>
        /// ��ѯ�ּ�������ϱ�
        /// </summary>
        public string FindSortStatus()
        {
            string tag = "�ϱ��ּ������ɹ���";
            using (PersistentManager dbpm = new PersistentManager("ZYDB2Connection"))
            {
                UploadDao dao = new UploadDao();
                dao.SetPersistentManager(dbpm);
                DataTable sortStockTable = this.QuerySortStatus();
                if (sortStockTable.Rows.Count > 0)
                {
                    try
                    {
                        dbpm.BeginTransaction();
                        dao.InsertSortStatus(sortStockTable);
                        this.UpdateSortStatus("");
                        dbpm.Commit();
                    }
                    catch (Exception exp)
                    {
                        dbpm.Rollback();
                        throw new Exception(exp.Message);
                    }
                }
                else
                    tag = "û���µķּ������Ҫ�ϱ���";
            } return tag;
        }

        /// <summary>
        /// ��ѯ�ּ������
        /// </summary>
        /// <returns></returns>
        public DataTable QuerySortStatus()
        {
            using (PersistentManager pm = new PersistentManager())
            {
                UploadDao dao = new UploadDao();
                dao.SetPersistentManager(pm);
                return dao.QuerySortStatus();
            }
        }

        /// <summary>
        /// �޸ķּ��������Ϣ�ϱ�״̬
        /// </summary>
        /// <param name="productCode"></param>
        public void UpdateSortStatus(string sortStatusCode)
        {
            using (PersistentManager pm = new PersistentManager())
            {
                UploadDao dao = new UploadDao();
                dao.SetPersistentManager(pm);
                dao.UpdateSortStatus(sortStatusCode);
                dao.InsertSynchroInfo("DWV_IORD_SORT_STATUS", "�ּ������");
            }
        }

        #endregion


        #region ��ѯ�ּ�����Ϣ������

        /// <summary>
        /// ��ѯ�ּ�����Ϣ���ϱ�
        /// </summary>
        public string FindIdpsSorting()
        {
            string tag = "�ϱ��ּ�����Ϣ��ɹ���";
            using (PersistentManager dbpm = new PersistentManager("ZYDB2Connection"))
            {
                UploadDao dao = new UploadDao();
                dao.SetPersistentManager(dbpm);
                DataTable sortingTable = this.QueryIdpsSorting();
                if (sortingTable.Rows.Count > 0)
                {
                    try
                    {
                        dbpm.BeginTransaction();
                        dao.InsertIdpsSorting(sortingTable);
                        this.UpdateSorting("");
                        dbpm.Commit();
                    }
                    catch (Exception exp)
                    {
                        dbpm.Rollback();
                        throw new Exception(exp.Message);
                    }
                }
                else
                    tag = "û���µķּ�����Ϣ��Ҫ�ϱ���";
            }
            return tag;
        }

        /// <summary>
        /// ��ѯ�ּ�����Ϣ��
        /// </summary>
        /// <returns></returns>
        public DataTable QueryIdpsSorting()
        {
            using (PersistentManager pm = new PersistentManager())
            {
                UploadDao dao = new UploadDao();
                dao.SetPersistentManager(pm);
                return dao.QueryIdpsSorting();
            }
        }

        /// <summary>
        /// �޸ķּ�����Ϣ���ϱ�״̬
        /// </summary>
        /// <param name="productCode"></param>
        public void UpdateSorting(string sortingCode)
        {
            using (PersistentManager pm = new PersistentManager())
            {
                UploadDao dao = new UploadDao();
                dao.SetPersistentManager(pm);
                dao.UpdateSorting(sortingCode);
                dao.InsertSynchroInfo("DWV_DPS_SORTING", "�ּ�����Ϣ��");
            }
        }

        #endregion


        #region ��ѯ�ִ����Ա�
        /// <summary>
        /// ��ѯ�ִ����Ա��ϱ�
        /// </summary>
        public string FindIbasSorting()
        {
            string tag = "�ϱ��ִ����Ա�ɹ���";
            using (PersistentManager dbpm = new PersistentManager("ZYDB2Connection"))
            {
                UploadDao dao = new UploadDao();
                dao.SetPersistentManager(dbpm);
                DataTable ibasSortingTable = this.QueryIbasSorting();
                if (ibasSortingTable.Rows.Count > 0)
                {
                    try
                    {
                        dbpm.BeginTransaction();
                        dao.InsertIbasSorting(ibasSortingTable);
                        this.UpdateIbasSorting("");
                        dbpm.Commit();
                    }
                    catch (Exception exp)
                    {
                        dbpm.Rollback();
                        throw new Exception(exp.Message);
                    }
                }
                else
                    tag = "û���µĲִ����Ա�Ҫ�ϱ���";
            }
            return tag;
        }

        /// <summary>
        /// ��ѯ�ִ����Ա�
        /// </summary>
        /// <returns></returns>
        public DataTable QueryIbasSorting()
        {
            using (PersistentManager pm = new PersistentManager())
            {
                UploadDao dao = new UploadDao();
                dao.SetPersistentManager(pm);
                return dao.QueryIbasSorting();
            }
        }

        /// <summary>
        /// �޸Ĳִ����Ա��ϱ�״̬
        /// </summary>
        /// <param name="productCode"></param>
        public void UpdateIbasSorting(string sortingCode)
        {
            using (PersistentManager pm = new PersistentManager())
            {
                UploadDao dao = new UploadDao();
                dao.SetPersistentManager(pm);
                dao.UpdateIbsaSorting(sortingCode);
                dao.InsertSynchroInfo("DWV_IBAS_STORAGE", "�ִ����Ա�");
            }
        }
        #endregion


        #region ��ҵ�����ݱ��������

        /// <summary>
        /// �������ݵ�ҵ�����
        /// </summary>
        public void InsertBusiStock()
        {
            using (PersistentManager pm = new PersistentManager())
            {
                UploadDao dao = new UploadDao();
                dao.SetPersistentManager(pm);
                DataTable cellQuantityTable = dao.QueryCellQuantity();//��ѯ��������
                DataTable busiTable = this.InsertBusiQuantity(cellQuantityTable);
                dao.InsertBusiStockQuntity(busiTable);
            }
        }

        /// <summary>
        /// ���ݲ�Ʒ�����ѯҵ�������̹�����
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public DataTable QueryCellTiao(string product)
        {
            using (PersistentManager pm = new PersistentManager())
            {
                UploadDao dao = new UploadDao();
                dao.SetPersistentManager(pm);
                return dao.QueryCellTiao(product);
            }
        }

        /// <summary>
        /// �����ݲ��������
        /// </summary>
        /// <param name="busiTable"></param>
        public DataTable InsertBusiQuantity(DataTable cellQuantityTable)
        {
            DataSet ds = this.GenerateEmptyTables();
            foreach (DataRow row in cellQuantityTable.Rows)
            {
                DataTable prodt = this.ProductRate(row["CURRENTPRODUCT"].ToString());
                DataTable tiaoTable = this.QueryCellTiao(row["CURRENTPRODUCT"].ToString());
                
                int quantityTiao = Convert.ToInt32(Convert.ToInt32(row["QUANTITY"]) / Convert.ToInt32(prodt.Rows[0]["TIAORATE"].ToString()));

                DataRow storerow = ds.Tables["DWV_IWMS_BUSI_STOCK"].NewRow();
                storerow["ORG_CODE"] = row["ORG_CODE"].ToString().Trim();
                storerow["BRAND_CODE"] = row["CURRENTPRODUCT"].ToString().Trim();
                storerow["DIST_CTR_CODE"] = this.GetCompany().ToString();
                storerow["QUANTITY"] = quantityTiao;
                storerow["IS_IMPORT"] = "0";
                ds.Tables["DWV_IWMS_BUSI_STOCK"].Rows.Add(storerow);
            }
            return ds.Tables[0];
        }
        #endregion

        #region ����

        //��ȡ��Ʒ�ĵ�λ����
        public DataTable ProductRate(string productCode)
        {
            using (PersistentManager dbPm = new PersistentManager())
            {
                UploadDao dao = new UploadDao();
                dao.SetPersistentManager(dbPm);
                return dao.ProductRate(productCode);
            }
        }

        /// <summary>
        /// ��ȡ�������ı���
        /// </summary>
        /// <returns></returns>
        public string GetCompany()
        {
            using (PersistentManager dbpm = new PersistentManager())
            {
                UploadDao dao = new UploadDao();
                dao.SetPersistentManager(dbpm);
                return dao.GetCompany().ToString();
            }
        }

        /// <summary>
        /// ���������
        /// </summary>
        /// <returns></returns>
        private DataSet GenerateEmptyTables()
        {
            DataSet ds = new DataSet();
            DataTable storedetail = ds.Tables.Add("DWV_IWMS_BUSI_STOCK");
            storedetail.Columns.Add("ORG_CODE");
            storedetail.Columns.Add("BRAND_CODE");
            storedetail.Columns.Add("DIST_CTR_CODE");
            storedetail.Columns.Add("QUANTITY");
            storedetail.Columns.Add("IS_IMPORT");
            return ds;
        }

        /// <summary>
        /// �޸��ս���Ϣ
        /// </summary>
        /// <param name="uase"></param>
        public void UpdateDayReckno(string uase)
        {
            string datetime = DateTime.Now.ToString("yyyyMMddHHmmss");
            using (PersistentManager persistentManager = new PersistentManager())
            {
                UpdateUploadDao dao = new UpdateUploadDao();
                dao.SetPersistentManager(persistentManager);
                dao.UpdateDate(uase, datetime);
            }
        }
        #endregion

    }
}
