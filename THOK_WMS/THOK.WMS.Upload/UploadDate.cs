using System;
using System.Collections.Generic;
using System.Text;
using THOK.WMS.BLL;
using THOK.WMS.Upload.Bll;

namespace THOK.WMS.Upload
{
   public class UploadDate
    {
       public event ScheduleEventHandler OnSchedule = null;
       UploadBll updateBll = new UploadBll();

       public void UploadInfoData()
       {
           string tag = "";
           try
           {
               //�ϱ�������Ϣ��
               //tag = updateBll.FindProduct();
               if (OnSchedule != null)
                   OnSchedule(this, new ScheduleEventArgs(1, "�����ϱ�������Ϣ", 1, 18));

               //�ϱ���֯�ṹ��Ϣ��
               tag = updateBll.FindOrganization();
               if (OnSchedule != null)
                   OnSchedule(this, new ScheduleEventArgs(1, "�����ϱ���֯�ṹ��Ϣ", 2, 18));

               //�ϱ���Ա��Ϣ��
               tag = updateBll.FindPerson();
               if (OnSchedule != null)
                   OnSchedule(this, new ScheduleEventArgs(1, "�����ϱ���Ա��Ϣ", 3, 18));

               //�ϱ��ͻ���Ϣ��
               tag = updateBll.FindCustomer();
               if (OnSchedule != null)
                   OnSchedule(this, new ScheduleEventArgs(1, "�����ϱ��ͻ���Ϣ", 4, 18));

               //�ϱ��ִ����Ա�
               tag = updateBll.FindIbasSorting();
               if (OnSchedule != null)
                   OnSchedule(this, new ScheduleEventArgs(1, "�����ϱ��ִ�������Ϣ", 5, 18));

               //�ϱ��ֿ����
              tag = updateBll.FindStoreStock();
               if (OnSchedule != null)
                   OnSchedule(this, new ScheduleEventArgs(1, "�����ϱ��ֿ�����Ϣ", 6, 18));

               //�ϱ�ҵ�����
               tag = updateBll.FindBusiStock();
               if (OnSchedule != null)
                   OnSchedule(this, new ScheduleEventArgs(1, "�����ϱ�ҵ������Ϣ", 7, 18));

               //�ϱ��ֿ���ⵥ������
               tag = updateBll.FindInMasterBill();
               if (OnSchedule != null)
                   OnSchedule(this, new ScheduleEventArgs(1, "�����ϱ���ⵥ��������Ϣ", 8, 18));

               //�ϱ��ֿ���ⵥ��ϸ��
               tag = updateBll.FindInDetailBill();
               if (OnSchedule != null)
                   OnSchedule(this, new ScheduleEventArgs(1, "�����ϱ���ⵥ��ϸ����Ϣ", 9, 18));

               //�ϱ����ҵ�񵥾ݱ�
               tag = updateBll.FindInBusiBill();
               if (OnSchedule != null)
                   OnSchedule(this, new ScheduleEventArgs(1, "�����ϱ����ҵ�񵥾���Ϣ", 10, 18));

               //�ϱ��ֿ���ⵥ������
               tag = updateBll.FindOutMasterBill();
               if (OnSchedule != null)
                   OnSchedule(this, new ScheduleEventArgs(1, "�����ϱ����ⵥ��������Ϣ", 11, 18));

               //�ϱ��ֿ���ⵥ��ϸ��
               tag = updateBll.FindOutDetailBill();
               if (OnSchedule != null)
                   OnSchedule(this, new ScheduleEventArgs(1, "�����ϱ����ⵥ��ϸ����Ϣ", 12, 18));

               //�ϱ�����ҵ�񵥾ݱ�
               tag = updateBll.FindOutBusiBill();
               if (OnSchedule != null)
                   OnSchedule(this, new ScheduleEventArgs(1, "�����ϱ�����ҵ�񵥾ݱ���Ϣ", 13, 18));

               ////�ϱ��ּ𶩵�����
               //tag = updateBll.FindIordMasterOrder();
               //if (OnSchedule != null)
               //    OnSchedule(this, new ScheduleEventArgs(1, "�����ϱ��ּ𶩵�������Ϣ", 14, 18));

               ////�ϱ��ּ𶩵�ϸ��
               //tag = updateBll.FindIordDetailOrder();
               //if (OnSchedule != null)
               //    OnSchedule(this, new ScheduleEventArgs(1, "�����ϱ��ּ𶩵�ϸ����Ϣ", 15, 18));

               ////�ϱ��ּ������
               //tag = updateBll.FindSortStatus();
               //if (OnSchedule != null)
               //    OnSchedule(this, new ScheduleEventArgs(1, "�����ϱ��ּ��������Ϣ", 16, 18));

               ////�ϱ��ּ�����Ϣ��
               //tag = updateBll.FindIdpsSorting();
               //if (OnSchedule != null)
               //    OnSchedule(this, new ScheduleEventArgs(1, "�����ϱ��ּ�����Ϣ", 17, 18));

               //�ϱ�ͬ��״̬��
               tag = updateBll.FindSynchroInfo();
               if (OnSchedule != null)
                   OnSchedule(this, new ScheduleEventArgs(1, "�����ϱ�ͬ��״̬��Ϣ", 18, 18));

           }
           catch (Exception exp)
           {
               if (OnSchedule != null)
                   OnSchedule(this, new ScheduleEventArgs(OptimizeStatus.ERROR, exp.Message));
               throw new Exception(exp.Message);
           }
       }

    }
}
