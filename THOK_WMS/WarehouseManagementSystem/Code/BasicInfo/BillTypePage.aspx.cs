﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using THOK.WMS.BLL;
using System.Drawing;

public partial class Code_BasicInfo_BillTypePage : BasePage
{
    int pageIndex = 1;
    int pageSize = 15;
    int totalCount = 0;
    int pageCount = 0;
    string filter = "1=1";
    DataSet dsType;
    string PrimaryKey = "TYPECODE";
    string OrderByFields = "TYPECODE";
    BillType objType = new BillType();

    #region 窗体加载
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["sys_PageCount"] != null)
            {
                pageSize = Convert.ToInt32(Session["sys_PageCount"].ToString());
                pager.PageSize = pageSize;
            }
            if (Session["pager_ShowPageIndex"] != null)
            {
                pager.ShowPageIndex = Convert.ToBoolean(Session["pager_ShowPageIndex"].ToString());
            }

            if (!IsPostBack)
            {
                this.hdnBusiness.Value = Request.QueryString["business"];
                filter = "BUSINESS='"+this.hdnBusiness.Value+"'";
                totalCount = objType.GetRowCount(filter);
                pager.RecordCount = totalCount;
                GridDataBind();
            }
            else
            {
                pageCount = Convert.ToInt32(ViewState["pageCount"]);
                pageIndex = Convert.ToInt32(ViewState["pageIndex"]);
                totalCount = Convert.ToInt32(ViewState["totalCount"]);
                filter = ViewState["filter"].ToString();
                OrderByFields = ViewState["OrderByFields"].ToString();

                totalCount = objType.GetRowCount(filter);
                GridDataBind();
            }

        }
        catch (Exception exp)
        {
            JScript.Instance.ShowMessage(this.UpdatePanel1, exp.Message);
        }
    }
    #endregion

    #region 数据源绑定
    void GridDataBind()
    {
        dsType = objType.QueryBillType(pageIndex, pageSize, filter, OrderByFields);
        if (dsType.Tables[0].Rows.Count == 0)
        {
            dsType.Tables[0].Rows.Add(dsType.Tables[0].NewRow());
            gvMain.DataSource = dsType;
            gvMain.DataBind();
            int columnCount = gvMain.Rows[0].Cells.Count;
            gvMain.Rows[0].Cells.Clear();
            gvMain.Rows[0].Cells.Add(new TableCell());
            gvMain.Rows[0].Cells[0].ColumnSpan = columnCount;
            gvMain.Rows[0].Cells[0].Text = "没有符合以上条件的数据,请重新查询 ";
            gvMain.Rows[0].Visible = true;

        }
        else
        {
            this.gvMain.DataSource = dsType.Tables[0];
            this.gvMain.DataBind();
        }

        ViewState["pageIndex"] = pageIndex;
        ViewState["totalCount"] = totalCount;
        ViewState["pageCount"] = pageCount;
        ViewState["filter"] = filter;
        ViewState["OrderByFields"] = OrderByFields;
    }
    #endregion

    #region 显示切换
    private void SwitchView(int index)
    {
        if (index == 0)
        {
            this.pnlList.Visible = true;
            this.pnlEdit.Visible = false;
        }
        else
        {
            this.pnlList.Visible = false;
            this.pnlEdit.Visible = true;
        }
    }
    #endregion

    #region GridView绑定
    protected void gvMain_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            CheckBox chk = new CheckBox();
            chk.Attributes.Add("style", " font-weight:bold; text-align:center;word-break:keep-all; white-space:nowrap");
            chk.ID = "checkAll";
            chk.Attributes.Add("onclick", "checkboxChange(this,'gvMain',0);");
            chk.Text = "操作";
            e.Row.Cells[0].Controls.Add(chk);
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.RowIndex % 2 == 0)
            {
                e.Row.BackColor = Color.FromName(Session["grid_OddRowColor"].ToString());
            }
            else
            {
                e.Row.BackColor = Color.FromName(Session["grid_EvenRowColor"].ToString());
            }
            e.Row.Cells[0].Attributes.Add("style", "word-break:keep-all; white-space:nowrap");

            CheckBox chk = new CheckBox();
            LinkButton lkbtn = new LinkButton();
            lkbtn.CommandName = "Edit";
            lkbtn.ID = e.Row.ID;
            lkbtn.Text = " 编辑 ";
            if (this.hdnXGQX.Value == "0")
            {
                lkbtn.Enabled = false;
            }
            e.Row.Cells[0].Controls.Add(chk);
            e.Row.Cells[0].Controls.Add(lkbtn);


            if (e.Row.Cells[3].Text == "1")
            {
                e.Row.Cells[3].Text = "是";
            }
            else
            {
                e.Row.Cells[3].Text = "否";
            }

            //e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#f5f5f5',this.style.fontWeight=''; this.style.cursor='hand';");
            ////当鼠标离开的时候 将背景颜色还原的以前的颜色
            //e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor,this.style.fontWeight='';");

        }
    }
    #endregion

    #region 数据编辑
    protected void gvMain_RowEditing(object sender, GridViewEditEventArgs e)
    {
        hdnOpFlag.Value = "1";
        ViewState["OpFlag"] = "1";
        SwitchView(1);
        this.txtID.Text = dsType.Tables[0].Rows[e.NewEditIndex]["ID"].ToString();
        this.txtTYPECODE.Text = dsType.Tables[0].Rows[e.NewEditIndex]["TYPECODE"].ToString();
        this.txtTYPENAME.Text = dsType.Tables[0].Rows[e.NewEditIndex]["TYPENAME"].ToString();
        //this.txtBUSINESS.Text = dsType.Tables[0].Rows[e.NewEditIndex]["BUSINESS"].ToString();
        this.ddlNeedCell.SelectedValue = dsType.Tables[0].Rows[e.NewEditIndex]["ISNEEDCELL"].ToString();
        this.txtMEMO.Text = dsType.Tables[0].Rows[e.NewEditIndex]["MEMO"].ToString();
    }
    #endregion

    #region 按字段查询
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        try
        {
            filter = string.Format(" {0} like '{1}%'  and BUSINESS='{2}'", this.ddl_Field.SelectedValue, this.txtKeyWords.Text.Trim().Replace("'", ""),this.hdnBusiness.Value);
            ViewState["filter"] = filter;
            if (rbASC.Checked)
            {
                OrderByFields = this.ddl_Field.SelectedValue + " asc ";
            }
            else
            {
                OrderByFields = this.ddl_Field.SelectedValue + " desc ";
            }

            totalCount = objType.GetRowCount(filter);
            pageIndex = 1;
            pager.CurrentPageIndex = 1;
            pager.RecordCount = totalCount;
            GridDataBind();
        }
        catch (Exception exp)
        {
            JScript.Instance.ShowMessage(this.UpdatePanel1, exp.Message);
        }
    }
    #endregion

    #region 新增
    protected void btnCreate_Click(object sender, EventArgs e)
    {
        ClearData();
        this.hdnOpFlag.Value = "0";
        ViewState["OpFlag"] = "0";
        SwitchView(1);
        this.txtTYPECODE.Text = objType.GetNewTypeCode(this.hdnBusiness.Value);
    }
    #endregion

    #region 删除
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            for (int i = 0; i < gvMain.Rows.Count; i++)
            {
                if (gvMain.Rows[0].Cells[0].Text == "没有符合以上条件的数据,请重新查询 ")
                {
                    break;
                }
                else
                {
                    CheckBox chk = (CheckBox)gvMain.Rows[i].Cells[0].Controls[0];
                    if (chk.Enabled && chk.Checked)
                    {
                        dsType.Tables[0].Rows[i].Delete();
                    }
                }
            }
            objType.Delete(dsType);
            totalCount = objType.GetRowCount(filter);
            pager.RecordCount = totalCount;
            if (pageIndex > pager.PageCount)
            {
                pageIndex = pager.PageCount;
            }
            GridDataBind();
        }
        catch (Exception exp)
        {
            JScript.Instance.ShowMessage(this.UpdatePanel1, exp.Message);
        }
    }
    #endregion

    # region 分页控件 页码changing事件
    protected void pager_PageChanging(object src, PageChangingEventArgs e)
    {
        pager.CurrentPageIndex = e.NewPageIndex;
        pager.RecordCount = totalCount;
        pageIndex = pager.CurrentPageIndex;
        ViewState["pageIndex"] = pageIndex;
        GridDataBind();
    }
    #endregion

    #region 数据保存
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (ViewState["OpFlag"].ToString() == "0")//新增
            {
                objType.TYPECODE = this.txtTYPECODE.Text;
                objType.TYPENAME = this.txtTYPENAME.Text.Replace("\'", "\''");
                objType.BUSINESS = this.hdnBusiness.Value;
                objType.ISNEEDCELL = this.ddlNeedCell.SelectedValue;
                objType.MEMO = this.txtMEMO.Text.Replace("\'", "\''"); ;
                objType.Insert();

                totalCount = objType.GetRowCount(filter);
                pager.RecordCount = totalCount;
                GridDataBind();
                SwitchView(0);
                JScript.Instance.ShowMessage(this.UpdatePanel1, "单据类型添加成功！");
            }
            else//修改
            {
                objType.ID = Convert.ToInt32(this.txtID.Text);
                objType.TYPECODE = this.txtTYPECODE.Text;
                objType.TYPENAME = this.txtTYPENAME.Text.Replace("\'","\''") ;
                objType.BUSINESS = this.hdnBusiness.Value;
                objType.ISNEEDCELL = this.ddlNeedCell.SelectedValue;
                objType.MEMO = this.txtMEMO.Text.Replace("\'", "\''"); ;
                objType.Update();

                GridDataBind();
                JScript.Instance.ShowMessage(this.UpdatePanel1, "单据类型修改成功！");
                SwitchView(0);
            }
        }
        catch (Exception exp)
        {
            JScript.Instance.ShowMessage(this.UpdatePanel1, exp.Message);
        }
    }
    #endregion

    #region 取消
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearData();
        SwitchView(0);
    }

    protected void ClearData()
    {
        this.txtID.Text = "";
        this.txtTYPECODE.Text = "";
        this.txtTYPENAME.Text = "";
        this.ddlNeedCell.SelectedIndex = 0;
        this.txtMEMO.Text = "";
    }
    #endregion

    #region 退出
    protected void btnExit_Click(object sender, EventArgs e)
    {
        Response.Redirect("../../MainPage.aspx");
    }
    #endregion

    //protected void btnDown_Click(object sender, EventArgs e)
    //{
    //    DownBillTypeBLL bibll = new DownBillTypeBLL();
    //    try
    //    {
    //        bibll.GetBillTypeInfo();
    //    }
    //    catch (Exception)
    //    {
            
    //        throw;
    //    }
    //}
}
