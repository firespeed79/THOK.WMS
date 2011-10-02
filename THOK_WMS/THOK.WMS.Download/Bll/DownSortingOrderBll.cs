using System;
using System.Collections.Generic;
using System.Text;
using THOK.Util;
using System.Data;
using THOK.WMS.Download.Dao;
using System.Threading;

namespace THOK.WMS.Download.Bll
{
    public class DownSortingOrderBll
   {

       #region �ֶ���Ӫ��ϵͳ���طּ���Ϣ

       /// <summary>
       /// �ֶ�����
       /// </summary>
       /// <param name="billno"></param>
       /// <returns></returns>
       public string GetSortingOrderById(string orderid)
       {
           string tag = "true";
           using (PersistentManager dbPm = new PersistentManager())
           {
               DownSortingOrderDao dao = new DownSortingOrderDao();
               dao.SetPersistentManager(dbPm);
               try
               {
                   orderid = "ORDER_ID IN (" + orderid + ")";
                   DataTable masterdt = this.GetSortingOrder(orderid);
                   DataTable detaildt = this.GetSortingOrderDetail(orderid);
                   if (masterdt.Rows.Count > 0 && detaildt.Rows.Count>0)
                   {
                       DataSet masterds = this.SaveSortingOrder(masterdt);
                       DataSet detailds = this.SaveSortingOrderDetail(detaildt);
                       this.Insert(masterds, detailds);
                   }
                   else
                       return "û�����ݿ����أ�";
               }
               catch (Exception e)
               {
                   tag = e.Message;
               }
           }
           return tag;
       }
       #endregion

       #region �Զ���Ӫ��ϵͳ���طּ���Ϣ

       /// <summary>
       /// �Զ����ض���
       /// </summary>
       /// <returns></returns>
       public string DownSortingOrder()
       {
           string tag = "true";
           using (PersistentManager dbpm = new PersistentManager())
           {
               DownSortingOrderDao dao = new DownSortingOrderDao();
               dao.SetPersistentManager(dbpm);
               try
               {
                   DataTable orderdt = this.GetOrderId();
                   string orderlist = UtinString.StringMake(orderdt, "ORDER_ID");
                   orderlist = UtinString.StringMake(orderlist);
                   orderlist = "ORDER_ID NOT IN(" + orderlist + ")";

                   DataTable masterdt = this.GetSortingOrder(orderlist);
                   DataTable detaildt = this.GetSortingOrderDetail(orderlist);
                   if (masterdt.Rows.Count > 0 && detaildt.Rows.Count > 0)
                   {
                       DataSet masterds = this.SaveSortingOrder(masterdt);
                       DataSet detailds = this.SaveSortingOrderDetail(detaildt);
                       this.Insert(masterds, detailds);
                   }
                   else
                       return "û�п��õ��������أ�";
               }
               catch (Exception e)
               {
                   tag = e.Message;
               }
           }
           return tag;
       }

       #endregion

       #region ѡ�����ڴ�Ӫ��ϵͳ���طּ���Ϣ

       /// <summary>
       /// ѡ�����ڴ�Ӫ��ϵͳ���طּ���Ϣ
       /// </summary>
       /// <param name="startDate"></param>
       /// <param name="endDate"></param>
       /// <returns></returns>
       public string GetSortingOrderDate(string startDate, string endDate)
       {
           string tag = "true";
           using (PersistentManager dbpm = new PersistentManager())
           {
               DownSortingOrderDao dao = new DownSortingOrderDao();
               dao.SetPersistentManager(dbpm);
               try
               {
                   //��ѯ�ֿ�7���ڵĶ�����
                   DataTable orderdt = this.GetOrderId();
                   string orderlist = UtinString.StringMake(orderdt, "ORDER_ID");
                   orderlist = UtinString.StringMake(orderlist);
                   string orderlistDate = "ORDER_DATE>='" + startDate + "' AND ORDER_DATE<='" + endDate + "' AND ORDER_ID NOT IN(" + orderlist + ")";
                   DataTable masterdt = this.GetSortingOrder(orderlistDate);//����ʱ���ѯ������Ϣ

                   string ordermasterlist = UtinString.StringMake(masterdt, "ORDER_ID");//ȡ�ø���ʱ���ѯ�Ķ�����
                   string ordermasterid = UtinString.StringMake(ordermasterlist);
                   ordermasterid = "ORDER_ID IN (" + ordermasterid + ")";
                   DataTable detaildt = this.GetSortingOrderDetail(ordermasterid);//���ݶ����Ų�ѯ��ϸ
                   if (masterdt.Rows.Count > 0 && detaildt.Rows.Count > 0)
                   {
                       DataSet masterds = this.SaveSortingOrder(masterdt);
                       DataSet detailds = this.SaveSortingOrderDetail(detaildt);
                       this.Insert(masterds, detailds);
                   }
                   else
                       return "û�п��õ��������أ�";
               }
               catch (Exception e)
               {
                   tag = e.Message;
               }
           }
           return tag;
       }

       #endregion

       #region ��ҳ��Ӫ��ϵͳ�ݲ�ѯ�ּ𶩵�����

       /// <summary>
       /// ��ѯӪ��ϵͳ�ּ𶩵��������ݽ�������
       /// </summary>
       /// <param name="pageIndex"></param>
       /// <param name="pageSize"></param>
       /// <returns></returns>
       public DataTable GetSortingOrder(int pageIndex, int pageSize)
       {
           using (PersistentManager dbpm = new PersistentManager("YXConnection"))
           {
               DownSortingOrderDao dao = new DownSortingOrderDao();
               dao.SetPersistentManager(dbpm);
               DataTable orderdt = this.GetOrderId();
               string orderlist = UtinString.StringMake(orderdt, "ORDER_ID");
               orderlist = UtinString.StringMake(orderlist);
               orderlist = "ORDER_ID NOT IN(" + orderlist + ")";
               return dao.GetSortingOrder(orderlist);
           }
       }

       /// <summary>
       /// ����ʱ���ѯӪ��ϵͳ�ּ𶩵��������ݽ�������
       /// </summary>
       /// <param name="pageIndex"></param>
       /// <param name="pageSize"></param>
       /// <returns></returns>
       public DataTable GetSortingOrder(int pageIndex, int pageSize,string startDate,string endDate)
       {
           using (PersistentManager dbpm = new PersistentManager("YXConnection"))
           {
               DownSortingOrderDao dao = new DownSortingOrderDao();
               dao.SetPersistentManager(dbpm);
               DataTable orderdt = this.GetOrderId();
               string orderlist = UtinString.StringMake(orderdt, "ORDER_ID");
               orderlist = UtinString.StringMake(orderlist);
               //orderlist = "ORDER_DATE>='" + startDate + "' AND ORDER_DATE<='" + endDate + "' AND ORDER_ID NOT IN(" + orderlist + ")";
               orderlist = "ORDER_ID NOT IN(" + orderlist + ")";
               DataTable masert = dao.GetSortingOrder("ORDER_ID NOT IN('')");
               DataRow[] orderdr = masert.Select(orderlist);
               return this.SaveSortingOrder(orderdr).Tables[0];
           }
       }

       /// <summary>
       /// ��ѯӪ��ϵͳ�ּ���ϸ������
       /// </summary>
       /// <param name="pageIndex"></param>
       /// <param name="pageSize"></param>
       /// <param name="inBillNo"></param>
       /// <returns></returns>
       public DataTable GetSortingOrderDetail(int pageIndex, int pageSize, string inBillNo)
       {
           using (PersistentManager dbpm = new PersistentManager("YXConnection"))
           {
               DownSortingOrderDao dao = new DownSortingOrderDao();
               dao.SetPersistentManager(dbpm);
               inBillNo = "ORDER_ID = '" + inBillNo + "'";
               return dao.GetSortingOrderDetail(inBillNo);
           }
       }

       #endregion

       #region ��ѯ�ִ��ּ���Ϣ

       /// <summary>
       /// ��ѯ4��֮�ڵķּ𶩵�
       /// </summary>
       /// <returns></returns>
       public DataTable GetOrderId()
       {
           using (PersistentManager dbpm = new PersistentManager())
           {
               DownSortingOrderDao dao = new DownSortingOrderDao();
               dao.SetPersistentManager(dbpm);
               return dao.GetOrderId();
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
               DownDistDao dao = new DownDistDao();
               dao.SetPersistentManager(dbpm);
               return dao.GetCompany().ToString();
           }
       }
       #endregion

       #region ���������Ϣ

       /// <summary>
       /// �����ص�������ӵ����ݿ⡣
       /// </summary>
       /// <param name="masterds"></param>
       /// <param name="detailds"></param>
       public void Insert(DataSet masterds, DataSet detailds)
       {
           using (PersistentManager pm = new PersistentManager())
           {
               DownSortingOrderDao dao = new DownSortingOrderDao();
               dao.SetPersistentManager(pm);
               if (masterds.Tables["DWV_OUT_ORDER"].Rows.Count > 0)
               {
                   dao.InsertSortingOrder(masterds);
               }
               if (detailds.Tables["DWV_OUT_ORDER_DETAIL"].Rows.Count > 0)
               {
                   dao.InsertSortingOrderDetail(detailds);
               }
           }
       }

       /// <summary>
       /// ���涩��������Ϣ���������������DATATABLE
       /// </summary>
       /// <param name="dr"></param>
       /// <returns></returns>
       public DataSet SaveSortingOrder(DataTable masterdt)
       {
           DataSet ds = this.GenerateEmptyTables();
           foreach (DataRow row in masterdt.Rows)
           {
               DataRow masterrow = ds.Tables["DWV_OUT_ORDER"].NewRow();
               masterrow["ORDER_ID"] = row["ORDER_ID"].ToString().Trim();//�������
               masterrow["ORG_CODE"] = row["ORG_CODE"].ToString().Trim();//������λ���
               masterrow["SALE_REG_CODE"] = row["SALE_REG_CODE"].ToString().Trim();//Ӫ�������
               masterrow["ORDER_DATE"] = row["ORDER_DATE"].ToString().Trim();//��������
               masterrow["ORDER_TYPE"] = row["ORDER_TYPE"].ToString().Trim();//��������
               masterrow["CUST_CODE"] = row["CUST_CODE"].ToString().Trim();//�ͻ����
               masterrow["CUST_NAME"] = row["CUST_NAME"].ToString().Trim();//�ͻ�����
               masterrow["QUANTITY_SUM"] = Convert.ToDecimal(row["QUANTITY_SUM"].ToString());//������
               masterrow["AMOUNT_SUM"] = Convert.ToDecimal(row["AMOUNT_SUM"].ToString());//�ܽ��
               masterrow["DETAIL_NUM"] = Convert.ToInt32(row["DETAIL_NUM"].ToString());//��ϸ��
               masterrow["DIST_BILL_ID"] = row["DIST_BILL_ID"].ToString().Trim();//�䳵����
               masterrow["DIST_STA_CODE"] =  row["DIST_STA_CODE"].ToString().Trim();//�ͻ��������
               masterrow["DIST_STA_NAME"] =  row["DIST_STA_NAME"].ToString().Trim();//�ͻ���������
               masterrow["DELIVER_LINE_CODE"] = row["DELIVER_LINE_CODE"].ToString().Trim();//�ͻ���·����
               masterrow["DELIVER_LINE_NAME"] = row["DELIVER_LINE_NAME"].ToString().Trim();//�ͻ���·����
               masterrow["DELIVER_ORDER"] = row["DELIVER_ORDER"];//�ͻ�˳�����
               masterrow["ISACTIVE"] = row["ISACTIVE"];//�Ƿ����
               masterrow["UPDATE_DATE"] = row["UPDATE_DATE"];//����ʱ��
               masterrow["SORTING_CODE"] = "";//�ּ����
               masterrow["IS_IMPORT"] = "0";
               ds.Tables["DWV_OUT_ORDER"].Rows.Add(masterrow);
           }
           return ds;
       }


       /// <summary>
       /// ���涩��������Ϣ���������������DATATABLE
       /// </summary>
       /// <param name="dr"></param>
       /// <returns></returns>
       public DataSet SaveSortingOrder(DataRow[] masterdr)
       {
           DataSet ds = this.GenerateEmptyTables();
           foreach (DataRow row in masterdr)
           {
               DataRow masterrow = ds.Tables["DWV_OUT_ORDER"].NewRow();
               masterrow["ORDER_ID"] = row["ORDER_ID"].ToString().Trim();//�������
               masterrow["ORG_CODE"] = row["ORG_CODE"].ToString().Trim();//������λ���
               masterrow["SALE_REG_CODE"] = row["SALE_REG_CODE"].ToString().Trim();//Ӫ�������
               masterrow["ORDER_DATE"] = row["ORDER_DATE"].ToString().Trim();//��������
               masterrow["ORDER_TYPE"] = row["ORDER_TYPE"].ToString().Trim();//��������
               masterrow["CUST_CODE"] = row["CUST_CODE"].ToString().Trim();//�ͻ����
               masterrow["CUST_NAME"] = row["CUST_NAME"].ToString().Trim();//�ͻ�����
               masterrow["QUANTITY_SUM"] = Convert.ToDecimal(row["QUANTITY_SUM"].ToString());//������
               masterrow["AMOUNT_SUM"] = Convert.ToDecimal(row["AMOUNT_SUM"].ToString());//�ܽ��
               masterrow["DETAIL_NUM"] = Convert.ToInt32(row["DETAIL_NUM"].ToString());//��ϸ��
               masterrow["DIST_BILL_ID"] = row["DIST_BILL_ID"].ToString().Trim();//�䳵����
               masterrow["DIST_STA_CODE"] =  row["DIST_STA_CODE"].ToString().Trim();//�ͻ��������
               masterrow["DIST_STA_NAME"] =  row["DIST_STA_NAME"].ToString().Trim();//�ͻ���������
               masterrow["DELIVER_LINE_CODE"] = row["DELIVER_LINE_CODE"].ToString().Trim();//�ͻ���·����
               masterrow["DELIVER_LINE_NAME"] =  row["DELIVER_LINE_NAME"].ToString().Trim();//�ͻ���·����
               masterrow["DELIVER_ORDER"] = row["DELIVER_ORDER"];//�ͻ�˳�����
               masterrow["ISACTIVE"] = row["ISACTIVE"];//�Ƿ����
               masterrow["UPDATE_DATE"] = row["UPDATE_DATE"];//����ʱ��
               masterrow["SORTING_CODE"] = "";//�ּ����
               masterrow["IS_IMPORT"] = "0";
               ds.Tables["DWV_OUT_ORDER"].Rows.Add(masterrow);
           }
           return ds;
       }

       /// <summary>
       /// ���涩����ϸ�����������DataTable
       /// </summary>
       /// <param name="dr"></param>
       /// <returns></returns>
       public DataSet SaveSortingOrderDetail(DataTable detaildt)
       {
           DataSet ds = this.GenerateEmptyTables();
           foreach (DataRow row in detaildt.Rows)
           {
               string id = DateTime.Now.ToString("yyMMddHHmmssfff");
               id = id.Substring(1, 14);
               DataRow detailrow = ds.Tables["DWV_OUT_ORDER_DETAIL"].NewRow();
               detailrow["ORDER_DETAIL_ID"] = id;// row["ORDER_DETAIL_ID"].ToString().Trim();
               detailrow["ORDER_ID"] = row["ORDER_ID"].ToString().Trim();
               detailrow["BRAND_CODE"] = row["BRAND_CODE"].ToString().Trim();
               detailrow["BRAND_NAME"] = row["BRAND_NAME"].ToString().Trim();
               detailrow["BRAND_UNIT_NAME"] = row["BRAND_UNIT_NAME"].ToString().Trim();
               detailrow["QUANTITY"] = Convert.ToDecimal(row["QUANTITY"]);
               detailrow["PRICE"] = Convert.ToDecimal(row["PRICE"]);
               detailrow["AMOUNT"] = Convert.ToDecimal(row["AMOUNT"]);
               detailrow["SORTING_CODE"] = "";
               detailrow["IS_IMPORT"] = "0";
               detailrow["ORDER_DATE"] = "";// row["ORDER_DATE"].ToString().Trim();
               ds.Tables["DWV_OUT_ORDER_DETAIL"].Rows.Add(detailrow);
               Thread.Sleep(1);
           }
           return ds;
       }

       /// <summary>
       /// �������������ϸ�������
       /// </summary>
       /// <returns></returns>
       private DataSet GenerateEmptyTables()
       {
           DataSet ds = new DataSet();
           DataTable mastertable = ds.Tables.Add("DWV_OUT_ORDER");
           mastertable.Columns.Add("ORDER_ID");
           mastertable.Columns.Add("ORG_CODE");
           mastertable.Columns.Add("SALE_REG_CODE");
           mastertable.Columns.Add("ORDER_DATE");
           mastertable.Columns.Add("ORDER_TYPE");
           mastertable.Columns.Add("CUST_CODE");
           mastertable.Columns.Add("CUST_NAME");
           mastertable.Columns.Add("QUANTITY_SUM");
           mastertable.Columns.Add("AMOUNT_SUM");
           mastertable.Columns.Add("DETAIL_NUM");
           mastertable.Columns.Add("DIST_BILL_ID");
           mastertable.Columns.Add("DIST_STA_CODE");
           mastertable.Columns.Add("DIST_STA_NAME");
           mastertable.Columns.Add("DELIVER_LINE_CODE");
           mastertable.Columns.Add("DELIVER_LINE_NAME");
           mastertable.Columns.Add("DELIVER_ORDER");
           mastertable.Columns.Add("ISACTIVE");
           mastertable.Columns.Add("UPDATE_DATE");
           mastertable.Columns.Add("SORTING_CODE");
           mastertable.Columns.Add("IS_IMPORT");

           DataTable detailtable = ds.Tables.Add("DWV_OUT_ORDER_DETAIL");
           detailtable.Columns.Add("ORDER_DETAIL_ID");
           detailtable.Columns.Add("ORDER_ID");
           detailtable.Columns.Add("BRAND_CODE");
           detailtable.Columns.Add("BRAND_NAME");
           detailtable.Columns.Add("BRAND_UNIT_NAME");
           detailtable.Columns.Add("QUANTITY");
           detailtable.Columns.Add("PRICE");
           detailtable.Columns.Add("AMOUNT");
           detailtable.Columns.Add("SORTING_CODE");
           detailtable.Columns.Add("IS_IMPORT");
           detailtable.Columns.Add("ORDER_DATE");
           return ds;
       }
       #endregion

       #region ������ѯ���طּ����ݵķ���


       /// <summary>
       /// �����û�ѡ��Ķ������طּ��߶�������
       /// </summary>
       /// <returns></returns>
       public DataTable GetSortingOrder(string orderid)
       {
           using (PersistentManager dbpm = new PersistentManager("YXConnection"))
           {
               DownSortingOrderDao dao = new DownSortingOrderDao();
               dao.SetPersistentManager(dbpm);
               return dao.GetSortingOrder(orderid);
           }
       }

       /// <summary>
       /// �����û�ѡ��Ķ������طּ��߶�����ϸ��
       /// </summary>
       /// <returns></returns>
       public DataTable GetSortingOrderDetail(string orderid)
       {
           using (PersistentManager dbpm = new PersistentManager("YXConnection"))
           {
               DownSortingOrderDao dao = new DownSortingOrderDao();
               dao.SetPersistentManager(dbpm);
               return dao.GetSortingOrderDetail(orderid);
           }
       }

       #endregion

   }
}
