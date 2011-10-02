using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using THOK.Util;
using THOK.WMS.Download.Dao;

namespace THOK.WMS.Download.Bll
{
    public class DownUnitBll
    {
        #region ��Ӫ��ϵͳ���ص�λ����

        /// <summary>
        /// ���ص�λ����
        /// </summary>
        /// <returns></returns>
        public bool DownUnitInfo()
        {
            bool tag = true;
            //���ص�λ��Ϣ
            DataTable unitCodeTable = this.GetUnitCode();
            string unitCodeList = UtinString.StringMake(unitCodeTable, "UNITCODE");
            unitCodeList = UtinString.StringMake(unitCodeList);
            unitCodeList = "BRAND_UNIT_CODE NOT IN (" + unitCodeList + ")";
            DataTable brandUnitCodeTable = this.GetUnitInfo(unitCodeList);
            if (brandUnitCodeTable.Rows.Count > 0)
            {
                DataSet unitCodeDs = this.InsertUnit(brandUnitCodeTable);
                this.Insert(unitCodeDs);
            }
            else
                tag = false;

            //���ؼ�����λϵ������
            DataTable ulistCodeTable = this.GetUlistCode();
            string ulistCodeList = UtinString.StringMake(ulistCodeTable, "BRAND_ULIST_CODE");
            ulistCodeList = UtinString.StringMake(ulistCodeList);
            ulistCodeList = "BRAND_ULIST_CODE NOT IN (" + ulistCodeList + ")";
            DataTable brandUlistCodeTable = this.GetBrandUlist(ulistCodeList);
            if (brandUlistCodeTable.Rows.Count > 0)
            {
                this.InsertUlist(brandUlistCodeTable);
            }
            else
                tag = false;
            return tag;
        }

        /// <summary>
        /// ���ؼ�����λϵ�б��
        /// </summary>
        /// <returns></returns>
        public DataTable GetBrandUlist(string ulistCodeList)
        {
            using (PersistentManager pm = new PersistentManager("YXConnection"))
            {
                DownUnitDao dao = new DownUnitDao();
                dao.SetPersistentManager(pm);
                return dao.GetBrandUlistInfo(ulistCodeList);
            }
        }

        /// <summary>
        /// ���ص�λ����
        /// </summary>
        /// <returns></returns>
        public DataTable GetUnitInfo(string unitCodeList)
        {
            using (PersistentManager dbPm = new PersistentManager("YXConnection"))
            {
                DownUnitDao dao = new DownUnitDao();
                dao.SetPersistentManager(dbPm);
                return dao.GetUnitInfo(unitCodeList);
            }
        }

        /// <summary>
        /// ��ѯ������λϵ�б��
        /// </summary>
        /// <returns></returns>
        public DataTable GetUlistCode()
        {
            using (PersistentManager pm = new PersistentManager())
            {
                DownUnitDao dao = new DownUnitDao();
                dao.SetPersistentManager(pm);
                return dao.GetUlistCode();
            }
        }


        /// <summary>
        /// ��ѯ���ֲִ���λ���
        /// </summary>
        /// <returns></returns>
        public DataTable GetUnitCode()
        {
            using (PersistentManager pm = new PersistentManager())
            {
                DownUnitDao dao = new DownUnitDao();
                dao.SetPersistentManager(pm);
                return dao.GetUnitCode();
            }
        }

        public DataTable GetUnitProduct()
        {
            using (PersistentManager pm = new PersistentManager())
            {
                DownUnitDao dao = new DownUnitDao();
                dao.SetPersistentManager(pm);
                return dao.GetUnitProduct();
            }
        }

        /// <summary>
        /// �ѵ�λ������ӵ����ݿ�
        /// </summary>
        /// <param name="ds"></param>
        public void Insert(DataSet unitCodeDs)
        {
            using (PersistentManager pm = new PersistentManager())
            {
                DownUnitDao dao = new DownUnitDao();
                dao.SetPersistentManager(pm);
                if (unitCodeDs.Tables["WMS_UNIT_INSERT"].Rows.Count > 0)
                {
                    dao.InsertUnit(unitCodeDs);
                }
            }
        }

        /// <summary>
        /// �ѵ�λ������ӵ����ݿ�
        /// </summary>
        /// <param name="ds"></param>
        public void InsertUlist(DataTable ulistCodeTable)
        {
            using (PersistentManager pm = new PersistentManager())
            {
                DownUnitDao dao = new DownUnitDao();
                dao.SetPersistentManager(pm);
                dao.InsertUlist(ulistCodeTable);
            }
        }

        /// <summary>
        /// ��ת�����������ӵ������
        /// </summary>
        /// <param name="unitdr"></param>
        /// <returns></returns>
        public DataSet InsertUnit(DataTable unitCodeTable)
        {
            DataSet ds = this.GenerateEmptyTables();
            foreach (DataRow row in unitCodeTable.Rows)
            {
                DataRow dr = ds.Tables["WMS_UNIT_INSERT"].NewRow();
                dr["UNITCODE"] = row["BRAND_UNIT_CODE"];
                dr["UNITNAME"] = row["BRAND_UNIT_NAME"];
                dr["STANDARDRATE"] = row["COUNT"];
                dr["ISACTIVE"] = row["ISACTIVE"];
                dr["MEMO"] = "";
                ds.Tables["WMS_UNIT_INSERT"].Rows.Add(dr);
            }
            return ds;
        }

        /// <summary>
        /// ���������
        /// </summary>
        /// <returns></returns>
        private DataSet GenerateEmptyTables()
        {
            DataSet ds = new DataSet();
            DataTable intable = ds.Tables.Add("WMS_UNIT_INSERT");
            intable.Columns.Add("ID");
            //intable.Columns.Add("PRODUCTCODE");
            intable.Columns.Add("UNITCODE");
            intable.Columns.Add("UNITNAME");
            intable.Columns.Add("ISDEFAULT");
            intable.Columns.Add("ISACTIVE");
            intable.Columns.Add("STANDARDRATE");
            intable.Columns.Add("MEMO");

            DataTable uptable = ds.Tables.Add("WMS_UNIT_PRODUCT");
            uptable.Columns.Add("UNITCODE");
            uptable.Columns.Add("PRODUCTCODE");
            return ds;
        }

        #endregion

        #region ��Ӫ��ϵͳ���ص�λ���� -����
        /// <summary>
        /// ���ص�λ����
        /// </summary>
        /// <returns></returns>
        public bool DownUnitCodeInfo()
        {
            bool tag = true;
            DataTable Unitdt = this.GetUnitInfo();//��������
            DataTable codedt = this.GetUnitCode();//ȡ�õ�λ
            DataTable unitProductDt = this.GetUnitProduct();//ȡ���м������
            DataSet ds = this.Insert(Unitdt);//������ת���ŵ���λ����м��
            DataTable unitTable = ds.Tables["WMS_UNIT_INSERT"];//ȡ�õ�λ��
            string codeList = UtinString.StringMake(codedt, "UNITCODE");
            string code = UtinString.StringMake(codeList);
            DataRow[] unitdr = unitTable.Select("UNITCODE NOT IN (" + code + ")");//��û�����ع���ȡ����

            DataSet unitDs = this.InsertUnit(unitdr);

            DataTable unitProductTable = ds.Tables["WMS_UNIT_PRODUCT"];
            string productcodeList = UtinString.StringMake(unitProductDt, "PRODUCTCODE");
            string productcode = UtinString.StringMake(productcodeList);
            DataRow[] unirProductdr = unitProductTable.Select("PRODUCTCODE NOT IN (" + productcode + ")");//��û�������м���ȡ����
            DataSet productds = this.InsertProduct(unirProductdr);

            this.Insert(unitDs, productds);

            return tag;
        }

        /// <summary>
        /// ��ת�����������ӵ������
        /// </summary>
        /// <param name="unitdr"></param>
        /// <returns></returns>
        public DataSet InsertUnit(DataRow[] unitdr)
        {
            DataSet ds = this.GenerateEmptyTables();
            foreach (DataRow row in unitdr)
            {
                DataRow dr = ds.Tables["WMS_UNIT_INSERT"].NewRow();
                dr["UNITCODE"] = row["UNITCODE"];
                dr["UNITNAME"] = row["UNITNAME"];
                dr["ISDEFAULT"] = row["ISDEFAULT"];
                dr["ISACTIVE"] = row["ISACTIVE"];
                dr["STANDARDRATE"] = row["STANDARDRATE"];
                dr["MEMO"] = "";
                ds.Tables["WMS_UNIT_INSERT"].Rows.Add(dr);
            }
            return ds;
        }


        /// <summary>
        /// �ѵ�λ������ӵ����ݿ�
        /// </summary>
        /// <param name="ds"></param>
        public void Insert(DataSet unitds, DataSet productds)
        {
            using (PersistentManager pm = new PersistentManager())
            {
                DownUnitDao dao = new DownUnitDao();
                dao.SetPersistentManager(pm);

                if (unitds.Tables["WMS_UNIT_INSERT"].Rows.Count > 0)
                {
                    dao.InsertUnit(unitds);
                }
                if (productds.Tables["WMS_UNIT_PRODUCT"].Rows.Count > 0)
                {
                    dao.InsertUnitProduct(productds);
                }
            }
        }

        /// <summary>
        /// ��ת�����������ӵ��м������
        /// </summary>
        /// <param name="unitdr"></param>
        /// <returns></returns>
        public DataSet InsertProduct(DataRow[] productdr)
        {
            DataSet ds = this.GenerateEmptyTables();
            foreach (DataRow row in productdr)
            {
                DataRow dr = ds.Tables["WMS_UNIT_PRODUCT"].NewRow();
                dr["UNITCODE"] = row["UNITCODE"].ToString().Trim();
                dr["PRODUCTCODE"] = row["PRODUCTCODE"].ToString().Trim();
                ds.Tables["WMS_UNIT_PRODUCT"].Rows.Add(dr);
            }
            return ds;
        }

        /// <summary>
        /// ���ص�λ����
        /// </summary>
        /// <returns></returns>
        public DataTable GetUnitInfo()
        {
            using (PersistentManager dbPm = new PersistentManager("DB2Connection"))
            {
                DownUnitDao dao = new DownUnitDao();
                dao.SetPersistentManager(dbPm);
                return dao.GetUnitInfo();
            }
        }
      
        /// <summary>
        /// ������ת����ӵ������
        /// </summary>
        /// <param name="unitdr"></param>
        /// <returns></returns>
        public DataSet Insert(DataTable unittable)
        {
            DataSet ds = this.GenerateEmptyTables();
            string zhi = "";
            //��ȡ֧��Ӧ�ľ��̱���ת������
            DataRow[] zhiDr = unittable.Select("BRAND_UNIT_CODE=01 AND BRAND_UNIT_NAME <>'null' ", "COUNT ASC");
            foreach (DataRow row in zhiDr)
            {
                if (row["BRAND_UNIT_CODE"].ToString() + "_" + row["COUNT"].ToString() != zhi)
                {
                    DataRow zhidr = ds.Tables["WMS_UNIT_INSERT"].NewRow();
                    // zhidr["PRODUCTCODE"] = row["BRAND_CODE"].ToString().Trim();
                    zhidr["UNITCODE"] = row["BRAND_UNIT_CODE"].ToString() + "_" + row["COUNT"].ToString();
                    zhidr["UNITNAME"] = row["BRAND_UNIT_NAME"] + "(" + row["COUNT"] + ")";
                    zhidr["ISDEFAULT"] = "0";
                    zhidr["ISACTIVE"] = "1";
                    zhidr["STANDARDRATE"] = row["COUNT"];
                    zhidr["MEMO"] = "";
                    zhi = row["BRAND_UNIT_CODE"].ToString() + "_" + row["COUNT"].ToString();
                    ds.Tables["WMS_UNIT_INSERT"].Rows.Add(zhidr);
                }
                //��֧�ļ�����λ�;��̱���浽�м��
                DataRow UnitzhiDr = ds.Tables["WMS_UNIT_PRODUCT"].NewRow();
                UnitzhiDr["UNITCODE"] = row["BRAND_UNIT_CODE"].ToString() + "_" + row["COUNT"].ToString();
                UnitzhiDr["PRODUCTCODE"] = row["BRAND_CODE"].ToString().Trim();
                ds.Tables["WMS_UNIT_PRODUCT"].Rows.Add(UnitzhiDr);

            }

            string he = "";
            //��ȡ�����ߺж�Ӧ֧��ת������
            DataRow[] heDr = unittable.Select("BRAND_UNIT_CODE=02 AND BRAND_UNIT_NAME <>'null' ", "COUNT ASC");
            foreach (DataRow row in heDr)
            {

                if (row["BRAND_UNIT_CODE"].ToString() + "_" + row["COUNT"].ToString() != he)
                {
                    DataRow hedr = ds.Tables["WMS_UNIT_INSERT"].NewRow();
                    hedr["UNITCODE"] = row["BRAND_UNIT_CODE"].ToString() + "_" + row["COUNT"].ToString();
                    hedr["UNITNAME"] = row["BRAND_UNIT_NAME"] + "(" + row["COUNT"] + ")";
                    hedr["ISDEFAULT"] = "0";
                    hedr["ISACTIVE"] = "1";
                    hedr["STANDARDRATE"] = row["COUNT"];
                    hedr["MEMO"] = "";
                    he = row["BRAND_UNIT_CODE"].ToString() + "_" + row["COUNT"].ToString();
                    ds.Tables["WMS_UNIT_INSERT"].Rows.Add(hedr);
                }
                //�Ѱ����ߺе����о��̱����Ӧ֧��ת������������м��
                DataRow UnitHeDr = ds.Tables["WMS_UNIT_PRODUCT"].NewRow();
                UnitHeDr["UNITCODE"] = row["BRAND_UNIT_CODE"].ToString() + "_" + row["COUNT"].ToString();
                UnitHeDr["PRODUCTCODE"] = row["BRAND_CODE"].ToString().Trim();
                ds.Tables["WMS_UNIT_PRODUCT"].Rows.Add(UnitHeDr);

            }

            string tiao = "";
            //��ȡ����Ӧ֧��ת������
            DataRow[] tiaoDr = unittable.Select("BRAND_UNIT_CODE=03 AND BRAND_UNIT_NAME <>'null' ", "COUNT ASC");
            foreach (DataRow row in tiaoDr)
            {

                if (row["BRAND_UNIT_CODE"].ToString() + "_" + row["COUNT"].ToString() != tiao)
                {
                    DataRow tiaodr = ds.Tables["WMS_UNIT_INSERT"].NewRow();
                    tiaodr["UNITCODE"] = row["BRAND_UNIT_CODE"].ToString() + "_" + row["COUNT"].ToString();
                    tiaodr["UNITNAME"] = row["BRAND_UNIT_NAME"] + "(" + row["COUNT"] + ")";
                    tiaodr["ISDEFAULT"] = "0";
                    tiaodr["ISACTIVE"] = "1";
                    tiaodr["STANDARDRATE"] = row["COUNT"];
                    tiaodr["MEMO"] = "";
                    tiao = row["BRAND_UNIT_CODE"].ToString() + "_" + row["COUNT"].ToString();
                    ds.Tables["WMS_UNIT_INSERT"].Rows.Add(tiaodr);
                }
                //���������о���Ʒ�ֶ�Ӧ֧��ת�������浽�м��
                DataRow UnitTiaoDr = ds.Tables["WMS_UNIT_PRODUCT"].NewRow();
                UnitTiaoDr["UNITCODE"] = row["BRAND_UNIT_CODE"].ToString() + "_" + row["COUNT"].ToString();
                UnitTiaoDr["PRODUCTCODE"] = row["BRAND_CODE"].ToString().Trim();
                ds.Tables["WMS_UNIT_PRODUCT"].Rows.Add(UnitTiaoDr);

            }

            string jian = "";
            //��ȡ����Ӧ֧��ת������
            DataRow[] jianDr = unittable.Select("BRAND_UNIT_CODE=04 AND BRAND_UNIT_NAME <>'null' ", "COUNT ASC");
            foreach (DataRow row in jianDr)
            {
                if (row["BRAND_UNIT_CODE"].ToString() + "_" + row["COUNT"].ToString() != jian)
                {
                    DataRow jiandr = ds.Tables["WMS_UNIT_INSERT"].NewRow();
                    jiandr["UNITCODE"] = row["BRAND_UNIT_CODE"].ToString() + "_" + row["COUNT"].ToString();
                    jiandr["UNITNAME"] = row["BRAND_UNIT_NAME"] + "(" + row["COUNT"] + ")";
                    jiandr["ISDEFAULT"] = "0";
                    jiandr["ISACTIVE"] = "1";
                    jiandr["STANDARDRATE"] = row["COUNT"];
                    jiandr["MEMO"] = "";
                    jian = row["BRAND_UNIT_CODE"].ToString() + "_" + row["COUNT"].ToString();
                    ds.Tables["WMS_UNIT_INSERT"].Rows.Add(jiandr);
                }
                //�Ѽ������о��̱����Ӧ֧��ת������������м��
                DataRow UnitJianDr = ds.Tables["WMS_UNIT_PRODUCT"].NewRow();
                UnitJianDr["UNITCODE"] = row["BRAND_UNIT_CODE"].ToString() + "_" + row["COUNT"].ToString();
                UnitJianDr["PRODUCTCODE"] = row["BRAND_CODE"].ToString().Trim();
                ds.Tables["WMS_UNIT_PRODUCT"].Rows.Add(UnitJianDr);
            }
            return ds;
        }

        #endregion
    }
}
