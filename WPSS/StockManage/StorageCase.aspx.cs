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

namespace WPSS.StockManage
{
    public partial class StorageCase : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dtx4 = new DataTable();
        basec bc = new basec();
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
            if (va.returnb() == true)
                Response.Redirect("\\Default.aspx");


        }
        #region bind()
        private void bind()
        {
            hint.Value = "";
            x.Value = "";
            x1.Value = "";
            GridView1.PageSize = 10;
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 10, 10);
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

            string v2 = Text2.Value;/*storagename*/
            string v3 = Text3.Value;/*batchid*/
            string v4 = Text4.Value;/*wname*/
            string v5 = Text5.Value;/*co_wareid*/

            if (v2 == "" && v3 == "" && v4 == "" && v5 == "")
            {
                showdata("");

            }
            else
            {

                showdata("品名 like '%" + v4 + "%' AND 仓库 like '%" + v2 + "%' AND 批号  like '%" + v3 + "%' AND 料号  like '%" + v5 + "%'");
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
        protected void showdata(string sql)
        {
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 10, 10);
            string sqlth = "";
            //string sqlt = " ORDER BY A.DATE DESC";

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
                sqlth = @" AND C.MAKERID IN (SELECT EMID FROM USERINFO A WHERE USER_GROUP IN 
 (SELECT USER_GROUP FROM USERINFO WHERE USID='" + USID + "'))";

            }
            else
            {

                sqlth = " AND C.MAKERID='" + EMID + "'";

            }
            bc.STORAGE_MAKERID = sqlth;
            dt1 = bc.getstoragecount();
            DataRow[] dr = dt1.Select(sql);
            if (dr.Length > 0)
            {

                dt = bc.getstoragetable();
                x.Value = "Y";
                for (i = 0; i < dr.Length; i++)
                {
                    DataRow dr1 = dt.NewRow();
                    dr1["品号"] = dr[i]["品号"].ToString();
                    DataTable dtx1 = basec.getdts("SELECT * FROM WAREINFO WHERE WAREID='" + dr[i]["品号"].ToString() + "'");
                    if (dtx1.Rows.Count > 0)
                    {
                        dr1["料号"] = dtx1.Rows[0]["CO_WAREID"].ToString();
                        dr1["客户料号"] = dtx1.Rows[0]["CWAREID"].ToString();

                    }
                    dr1["品名"] = dr[i]["品名"].ToString();
                    dr1["规格"] = dr[i]["规格"].ToString();
                    dr1["单位"] = dr[i]["单位"].ToString();
                    dr1["仓库"] = dr[i]["仓库"].ToString();
                    dr1["批号"] = dr[i]["批号"].ToString();
                    dr1["库存数量"] = dr[i]["库存数量"].ToString();
                    dr1["客户名称"] = dr[i]["客户名称"].ToString();
                    dr1["仓库制单人ID"] = bc.getOnlyString("SELECT MAKERID FROM STORAGEINFO WHERE STORAGENAME='" + dr[i]["仓库"].ToString() + "'");
                    dt.Rows.Add(dr1);

                }
                //dt = bc.GET_DT_TO_DV_TO_DT(dt, "", "仓库制单人ID IN ("+sqlth +") " );
                x.Value = Convert.ToString(1);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else
            {

                hint.Value = "没有找到记录";
            }
        }
        #endregion
        #region nextpage()
        protected void nextpage()
        {


            GridView1.DataKeyNames = new string[] { "品号" };
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
        protected void PageButton_Click(object sender, EventArgs e)
        {
            GridView1.PageIndex = Convert.ToInt32(((LinkButton)sender).CommandName) - 1;
            bind();
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
                        bind();
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
            bind();
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

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            bind();
        }


    }
}
