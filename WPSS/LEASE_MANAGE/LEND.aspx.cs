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

namespace WPSS.LEASE_MANAGE
{
    public partial class LEND : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        basec bc = new basec();

        CLEND cLEND = new CLEND();
        WPSS.Validate va = new Validate();
        private string _USID;
        public string USID
        {
            set { _USID = value; }
            get { return _USID; }

        }
        private string _EMID;
        public string EMID
        {
            set { _EMID = value; }
            get { return _EMID; }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.Response.Expires = 0;
           if (va.returnb() == true)
                Response.Redirect("\\Default.aspx");
            Bind();
        }
        #region Bind()
        private void Bind()
        {
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 10, 10);

            hint.Value = "";
            dt1 = bc.getdt("SELECT * FROM RIGHTLIST WHERE USID='" + n2 + "' AND NODE_NAME='借出作业'");
            if (dt1.Rows.Count > 0)
            {

                if (dt1.Rows[0]["SEARCH"].ToString() == "Y")
                {
                    btnSearch.Visible = true;
                    Label2.Visible = true;
                }
                else
                {
                    btnSearch.Visible = false;
                    Label2.Visible = false;

                }
                if (dt1.Rows[0]["ADD_NEW"].ToString() == "Y")
                {
                    btnAdd.Visible = true;
                    Label1.Visible = true;
                }
                else
                {
                    btnAdd.Visible = false;
                    Label1.Visible = false;

                }
            }
            GridView1.PageSize = 10;

            if (Request.QueryString["emid"] != null)
            {


                EMID = Request.QueryString["EMID"].ToString();
                showdata();

            }
            else
            {
                string varMakerID = bc.getOnlyString("SELECT EMID FROM USERINFO WHERE USID='" + n2 + "'");
                EMID = varMakerID;
                showdata();

            }
            try
            {


            }
            catch (Exception)
            {

            }
        }
        #endregion

       
        #region clear
        private void clear()
        {

            dt = null;
            GridView1.DataSource = dt;
            GridView1.DataBind();
            Text1.Value = "";


        }
        #endregion
        #region showdata
        protected void showdata()
        {
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 10, 10);
            string sqlth = "";
            string sqlt = " ORDER BY F.DATE DESC";

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
                sqlth = @" WHERE F.MAKERID IN (SELECT EMID FROM USERINFO A WHERE USER_GROUP IN 
 (SELECT USER_GROUP FROM USERINFO WHERE USID='" + USID + "'))";

            }
            else
            {

                sqlth = " WHERE F.MAKERID='" + EMID + "'";

            }


            dt = bc.getdt(cLEND .sqlfi+sqlth + sqlt);
           if (CheckBox1.Checked)
            {
                dt = bc.GET_DT_TO_DV_TO_DT(dt, "", "客户或供应商 like ('%"+Text1.Value +"%') AND 借出单号 like ('%" + Text2.Value + "%') AND 品名 like ('%" + Text3.Value + "%') AND 料号 like ('%" + Text4.Value + "%')");
            }

            else
            {
                dt = bc.GET_DT_TO_DV_TO_DT(dt, "", "借出单号 like ('%" + Text2.Value + "%') AND 品名 like ('%" + Text3.Value + "%') AND 料号 like ('%" + Text4.Value + "%')");


            }
            if (dt.Rows.Count > 0)
            {
                string v1 = dt.Compute("SUM(日租金)", "").ToString();
                if (!string.IsNullOrEmpty(v1))
                {

                    Text50.Value = string.Format("{0:F2}", Convert.ToDouble(v1));
                }
                string v2 = dt.Compute("SUM(押金)", "").ToString();
                if (!string.IsNullOrEmpty(v2))
                {

                    Text51.Value = string.Format("{0:F2}", Convert.ToDouble(v2));
                }
                x.Value = "1";
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else
            {

                //hint.Value  = "找不到所要搜索项！";
                GridView1.DataSource = null;

            }
            nextpage();
        }
        #endregion

        #region nextpage()
        protected void nextpage()
        {

            GridView1.DataKeyNames = new string[] { "借出单号" };
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

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            Bind();

        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            string v = GridView1.DataKeys[GridView1.SelectedIndex].Values[0].ToString();
           
       
                WPSS.LEASE_MANAGE.LENDT.IDO = v;
                string n1 = Request.Url.AbsoluteUri;
                string n2 = n1.Substring(n1.Length - 16, 16);
                Response.Redirect("../LEASE_MANAGE/LENDt.aspx" + n2);
            
        }
        #region delete
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string sql, sql1;
            hint.Value = "";
            string id = GridView1.DataKeys[e.RowIndex][0].ToString();
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 10, 10);
            string v1 = bc.getOnlyString("SELECT DEL FROM RIGHTLIST WHERE USID='" + n2 + "' AND NODE_NAME='借出作业'");
            if (bc.exists("SELECT LEID FROM  RETURN_EQUIPMENT_DET  WHERE LEID='"+id+"'"))
            {
                hint.Value = "该单号存在于归还单中，不能删除";
            }
            else if (v1 != "Y")
            {
                hint.Value = "您无删除权限！";
            }
            else
            {
               
                sql = "DELETE LEND_MST WHERE LEID='" + id + "'";
                sql1 = "DELETE LEND_DET WHERE LEID='" + id + "'";
                basec.getcoms(sql);
                basec.getcoms(sql1);
                basec.getcoms("DELETE MATERE WHERE MATEREID='" + id + "'");
                basec.getcoms("DELETE WAREFILE WHERE WAREID='" + Text1.Value + "'");
                basec.getcoms("DELETE CASH_ADD WHERE CDID='" + id  + "'");
                basec.getcoms("DELETE GODE WHERE GODEID='" + id + "'");
                GridView1.EditIndex = -1;
                Bind();
            }
            try
            {
            }
            catch (Exception)
            {


            }

        }
        #endregion

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
        protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        {
            hint.Value = "";
            LENDT.IDO = cLEND.GETID;
            LENDT.ADD_OR_UPDATE = "ADD";
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 16, 16);
            Response.Redirect("../LEASE_MANAGE/LENDt.aspx" + n2);

        }

        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            Bind();
        }

    }
}
