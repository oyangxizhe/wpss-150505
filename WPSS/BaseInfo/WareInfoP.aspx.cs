using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Net;
using System.Text;
using XizheC;
using System.IO;
using System.Diagnostics;

namespace WPSS.BaseInfo
{
    public partial class WareInfoP : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        basec bc = new basec();
        public string sql = @"
select A.WAREID AS WAREID,E.CNAME AS CNAME,A.CO_WAREID AS CO_WAREID,A.WNAME AS WNAME,
A.CWAREID AS CWAREID,A.SPEC AS SPEC,A.UNIT AS UNIT, 
C.PURCHASEUNITPRICE AS PURCHASEUNITPRICE ,D.SNAME AS SNAME,
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=A.MAKERID) AS MAKER,
SUBSTRING(A.DATE,1,10) AS DATE,C.REMARK AS REMARK,
CASE WHEN A.ACTIVE='Y' THEN '正常'
WHEN A.ACTIVE='HOLD' THEN 'Hold'
ELSE '作废'
END  AS ACTIVE
from  WareInfo  A 
LEFT JOIN PURCHASEUNITPRICE C ON A.WAREID=C.WAREID
LEFT JOIN SUPPLIERINFO_MST D ON C.SUID=D.SUID
LEFT JOIN CUSTOMERINFO_MST E ON A.CUID=E.CUID
";
        private string _USID;
        public string USID
        {
            set { _USID = value; }
            get { return _USID; }

        }
        string EMID;
        WPSS.Validate va = new Validate();
        int i;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.Response.Expires = 0;
            Bind();
            if (va.returnb() == true)
                Response.Redirect("\\Default.aspx");

        }
        #region Bind()
        private void Bind()
        {
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 10, 10);

            hint.Value = "";
            x.Value = "";
            x1.Value = "";
            GridView1.PageSize = 10;

            if (Request.QueryString["emid"] != null)
            {


                EMID = Request.QueryString["EMID"].ToString();
                select();

            }
            else
            {
                string varMakerID = bc.getOnlyString("SELECT EMID FROM USERINFO WHERE USID='" + n2 + "'");
                EMID = varMakerID;
                select();

            }
            try
            {


            }
            catch (Exception)
            {

            }
        }
        #endregion

        #region select()
        protected void select()
        {

            string v6 = "", v7 = "";
            string v2 = StartDate.Value;
            string v3 = EndDate.Value;
            string v8 = Text2.Value;
            string v9 = Text3.Value;
            if (!bc.juagedate(v2, v3))
            {
                hint.Value = bc.ErrowInfo;
                clear();
                return;
            }
            if (v2 != "" && v3 != "")
            {
                DateTime v4 = Convert.ToDateTime(v2);
                DateTime v5 = Convert.ToDateTime(v3);
                v6 = v4.ToString("yyyy-MM-dd") + " 00:00:00";
                v7 = v5.ToString("yyyy-MM-dd") + " 23:59:59";

            }
            if (CheckBox1.Checked)
            {
                showdata(@" where  A.WNAME like '%" + v8 + "%' AND A.CWAREID like '%" + v9 + "%' AND A.DATE BETWEEN  '" + v6 + "'AND '" + v7 + "' ");
            }

            else
            {
                if (v8 == "" && v9 == "" && DropDownList1.Text == "")
                {

                    showdata(" WHERE DateDiff(day,A.DATE,getdate()) >-1 and DateDiff(day,A.DATE,getdate()) <+7");


                }
                else
                {

                    showdata(@" where  A.WNAME like '%" + v8 + "%' AND A.CWAREID like '%" + v9 + "%' ");


                }


            }
            nextpage();
        }
        #endregion
        private void clear()
        {

            dt = null;
            GridView1.DataSource = dt;
            GridView1.DataBind();



        }
        #region showdata
        protected void showdata(string sqlo)
        {

            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 10, 10);
            string sqlth = "";
            string sqlt = " ORDER BY A.DATE DESC";
            string sqlf = "";

            string varMakerID = bc.getOnlyString("SELECT EMID FROM USERINFO WHERE USID='" + n2 + "'");

            if (Request.QueryString["EMID"] != null)
            {
                USID = bc.getOnlyString("SELECT USID FROM USERINFO WHERE EMID='" + Request.QueryString["EMID"].ToString() + "'");
            }
            else
            {
                USID = n2;
            }
            string v7 = bc.getOnlyString("SELECT SCOPE FROM SCOPE_OF_AUTHORIZATION WHERE USID='" + USID + "'");
            if (v7 == "Y")
            {

            }
            else if (v7 == "GROUP")
            {
                sqlth = @" AND A.MAKERID IN (SELECT EMID FROM USERINFO A WHERE USER_GROUP IN 
 (SELECT USER_GROUP FROM USERINFO WHERE USID='" + USID + "'))";

            }
            else
            {

                sqlth = " AND A.MAKERID='" + EMID + "'";

            }
            sqlth = "";
            if (DropDownList1.Text == "正常" || DropDownList1.Text == "")
            {

                sqlf = " AND A.ACTIVE='Y' ";
            }
            else if (DropDownList1.Text == "Hold")
            {

                sqlf = "  AND A.ACTIVE='HOLD' ";
            }
            else if (DropDownList1.Text == "作废")
            {


                sqlf = "  AND A.ACTIVE='N' ";
            }

            dt = bc.getdt(sql + sqlo + sqlf + sqlth + sqlt);
            if (dt.Rows.Count > 0)
            {
                x.Value = Convert.ToString(1);
                x1.Value = Convert.ToString(1);

            }

            GridView1.DataSource = dt;
            GridView1.DataBind();

        }
        #endregion
        #region nextpage()
        protected void nextpage()
        {

            GridView1.DataKeyNames = new string[] { "WAREID" };
            GridView1.DataBind();
            lblRecordCount.Text = "记录总数" + dt.Rows.Count + "条";
            lblPageCount.Text = "总页数" + (GridView1.PageCount).ToString() + "页";
            lblCurrentIndex.Text = "当前页第" + ((GridView1.PageIndex) + 1).ToString() + "页";
            if (dt.Rows.Count > 0)
            {
                if (GridView1.PageIndex == 0)
                {
                    btnFirst.Enabled = false;
                    btnPrev.Enabled = false;
                }
                else
                {
                    btnFirst.Enabled = true;
                    btnPrev.Enabled = true;
                }
                if (GridView1.PageIndex == GridView1.PageCount - 1)
                {
                    btnNext.Enabled = false;
                    btnLast.Enabled = false;
                }
                else
                {
                    btnNext.Enabled = true;
                    btnLast.Enabled = true;
                }

                // 计算生成分页页码,分别为："首 页" "上一页" "下一页" "尾 页"
                btnFirst.CommandName = "1";
                btnPrev.CommandName = (GridView1.PageIndex == 0 ? "1" : GridView1.PageIndex.ToString());

                btnNext.CommandName = (GridView1.PageCount == 1 ? GridView1.PageCount.ToString() : (GridView1.PageIndex + 2).ToString());
                btnLast.CommandName = GridView1.PageCount.ToString();
            }
            else
            {
                btnFirst.Enabled = false;
                btnPrev.Enabled = false;
                btnNext.Enabled = false;
                btnLast.Enabled = false;
            }

        }
        #endregion
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string var1 = bc.numYM(9, 4, "0001", "SELECT * FROM WareINFO", "WAREID", "9");
            WareInfoT.str1[0] = var1;
            Response.Redirect("../BaseInfo/WareInfoT.aspx");
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            Bind();

        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            string varWareID = GridView1.DataKeys[GridView1.SelectedIndex].Values[0].ToString();
            String[] str = new string[] { varWareID };
            WPSS.BaseInfo.WareInfoT.strE[0] = str[0];
            Response.Redirect("../BaseInfo/WareInfoT.aspx");

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string id = GridView1.DataKeys[e.RowIndex][0].ToString();
                string sql = "SELECT * FROM WAREFILE WHERE WAREID='" + id + "'";
                DataTable dt1 = basec.getdts(sql);
                if (dt1.Rows.Count > 0)
                {
                    for (i = 0; i < dt1.Rows.Count; i++)
                    {
                        string FilePath = bc.getOnlyString("SELECT PATH FROM WAREFILE WHERE FLKEY='" + dt1.Rows[i]["FLKEY"].ToString() + "'");
                        string s1 = Server.MapPath(FilePath);
                        if (File.Exists(s1))
                        {
                            File.Delete(s1);
                        }
                    }
                }
                string strSql = "DELETE FROM WAREFILE WHERE WAREID='" + id + "'";
                basec.getcoms(strSql);
                string strSql1 = "DELETE FROM WareInfo WHERE WAREID='" + id + "'";
                basec.getcoms(strSql1);
                GridView1.EditIndex = -1;
                Bind();
            }
            catch (Exception)
            {


            }

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //当鼠标放上去的时候 先保存当前行的背景颜色 并给附一颜色 
                e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#C9D3E2',this.style.fontWeight='';");
                //当鼠标离开的时候 将背景颜色还原的以前的颜色 
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor,this.style.fontWeight='';");
                e.Row.Attributes["style"] = "Cursor:pointer";
            }
        }


        protected void PageButton_Click(object sender, EventArgs e)
        {
            GridView1.PageIndex = Convert.ToInt32(((LinkButton)sender).CommandName) - 1;
            Bind();
        }

        protected void btngo_Click(object sender, EventArgs e)
        {
            #region btngo
            try
            {
                if (txtNum.Text == "")
                {
                    //opAndvalidate.Show("页数不能为空");
                }
                else
                {
                    int vargo = Convert.ToInt32(txtNum.Text);
                    if (vargo <= GridView1.PageCount)
                    {
                        GridView1.PageIndex = Convert.ToInt32(txtNum.Text) - 1;
                        Bind();
                    }
                    else
                    {
                        hint.Value = "没有找到记录";
                    }
                }
            }
            catch (Exception)
            {
                //opAndvalidate.Show("输入格式不正确，请检查！");
            }

            #endregion
        }

        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            Bind();
        }

    }
}
