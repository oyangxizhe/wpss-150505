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
using XizheC;
using System.IO;
using System.Diagnostics;

namespace WPSS.SellManage
{
    public partial class OfferSearchT : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        basec bc = new basec();
        WPSS.Validate va = new Validate();
        PrintOfferBill print = new PrintOfferBill();
        COFFER_SEARCH coffer_search = new COFFER_SEARCH();
        string v1, v2;
        public static string[] str1 = new string[] { "" };
        public static string[] strE = new string[] { "" };
        private static string _IDO;
        public static string IDO
        {
            set { _IDO = value; }
            get { return _IDO; }

        }
        private static string _ADD_OR_UPDATE;
        public static string ADD_OR_UPDATE
        {
            set { _ADD_OR_UPDATE = value; }
            get { return _ADD_OR_UPDATE; }

        }
        private bool _IFExecutionSUCCESS;
        public bool IFExecution_SUCCESS
        {
            set { _IFExecutionSUCCESS = value; }
            get { return _IFExecutionSUCCESS; }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //ViewState["pageindex"] = "0";
                Text15.Value = IDO;
                bind();
            }
            try
            {
            
            }
            catch (Exception)
            {


            }

            if (va.returnb() == true)
                Response.Redirect("\\Default.aspx");
        }
        private void bind()
        {
            if (bc.GET_IFExecutionSUCCESS_HINT_INFO(IFExecution_SUCCESS) != "")
            {
                hint.Value = bc.GET_IFExecutionSUCCESS_HINT_INFO(IFExecution_SUCCESS);
            }
            else
            {
                hint.Value = "";
            }

          
                dt = basec.getdts(coffer_search .sql +" WHERE A.OFID='"+Text15.Value +"'");
                if (dt.Rows.Count > 0)
                {
                    

                    Text2.Value = dt.Rows[0]["ID"].ToString();
                    Text3.Value = dt.Rows[0]["料号"].ToString();
                    Text4.Value = dt.Rows[0]["品名"].ToString();
                    Text5.Value = dt.Rows[0]["客户料号"].ToString();
                    Text6.Value = dt.Rows[0]["客户"].ToString();
                    //Text7.Value = dt.Rows[0]["SELLUNITPRICE"].ToString();
                    //TextBox1.Text = dt.Rows[0]["REMARK"].ToString();

                    Text8.Value = dt.Rows[0]["量产单价"].ToString();
                    Text9.Value = dt.Rows[0]["量产数量"].ToString();
                    Text10.Value = dt.Rows[0]["SAMPLE单价"].ToString();
                    Text11.Value = dt.Rows[0]["SAMPLE数量"].ToString();
                    Text12.Value = dt.Rows[0]["小量单价"].ToString();
                    Text13.Value = dt.Rows[0]["SAMPLE数量"].ToString() + "～" + dt.Rows[0]["量产数量"].ToString();
                    Text15.Value = dt.Rows[0]["报价单号"].ToString();
                    Text14.Value = dt.Rows[0]["工程费"].ToString();
                    TextBox1.Text = dt.Rows[0]["备注"].ToString();
                }
        }
        protected void ClearText()
        {
           
        }
        #region
        protected void save()
        {
            hint.Value = "";
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss");
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 10, 10);
            string varMakerID = bc.getOnlyString("SELECT EMID FROM USERINFO WHERE USID='" + n2 + "'");
            v1 = bc.getOnlyString("SELECT WAREID FROM SELLUNITPRICE WHERE  SPID='" + Text1.Value + "'");
            v2 = bc.getOnlyString("SELECT CUID FROM CUSTOMERINFO_MST WHERE CNAME='" + Text3.Value + "'");
            string v3 = bc.getOnlyString("SELECT CUID FROM SELLUNITPRICE WHERE  SPID='" + Text1.Value + "'");
            if (!juage1(v2))
            {

            }
            else
            {


            }
        }
        #endregion
        private bool juage1(string v2)
        {
            bool ju = true;

            if (!bc.exists("SELECT * FROM WAREINFO WHERE WAREID='" + Text2.Value + "' AND ACTIVE='Y'"))
            {
                ju = false;
                hint.Value = "该品号不存在于系统或状态不为正常！";
            }

            else if (bc.yesno(Text7.Value) == 0)
            {
                ju = false;
                hint.Value = "单价只能输入数字！";
            }

            return ju;

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
 
        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {
         

            try
            {
                hint.Value = "";
                if (Text2.Value == "")
                {
                    hint.Value = "ID不能为空！";
                }

                else
                {
                    SQlcommandE(coffer_search.sqlt + " WHERE OFID='" + Text15.Value + "'");

                    if (IFExecution_SUCCESS == true)
                    {
                        bind();

                    }
                }
            }
            catch (Exception)
            {


            }
        }
        #region SQlcommandE
        protected void SQlcommandE(string sql)
        {
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss");
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 10, 10);
            string varMakerID = bc.getOnlyString("SELECT EMID FROM USERINFO WHERE USID='" + n2 + "'");
            SqlConnection sqlcon = bc.getcon();
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            sqlcom.Parameters.Add("@OFID", SqlDbType.VarChar, 20).Value = Text15.Value;
            sqlcom.Parameters.Add("@WAREID", SqlDbType.VarChar, 20).Value = Text2.Value;
            sqlcom.Parameters.Add("@QUANTITY_UNITPRICE", SqlDbType.VarChar, 20).Value = Text8.Value;
            sqlcom.Parameters.Add("@QUANTITY_COUNT", SqlDbType.VarChar, 20).Value = Text9.Value;
            sqlcom.Parameters.Add("@SAMPLE_UNITPRICE", SqlDbType.VarChar, 20).Value = Text10.Value;
            sqlcom.Parameters.Add("@SAMPLE_COUNT", SqlDbType.VarChar, 20).Value = Text11.Value;
            sqlcom.Parameters.Add("@SMALLQUANTITY_UNITPRICE", SqlDbType.VarChar, 20).Value = Text12.Value;
            sqlcom.Parameters.Add("@PROJECT_COST", SqlDbType.VarChar, 20).Value = Text14.Value;
            sqlcom.Parameters.Add("@REMARK", SqlDbType.VarChar, 1000).Value = TextBox1.Text;
            sqlcom.Parameters.Add("@DATE", SqlDbType.VarChar, 20).Value = varDate;
            sqlcom.Parameters.Add("@MAKERID", SqlDbType.VarChar, 20).Value = varMakerID;
            sqlcom.Parameters.Add("@YEAR", SqlDbType.VarChar, 20).Value = year;
            sqlcom.Parameters.Add("@MONTH", SqlDbType.VarChar, 20).Value = month;
            sqlcom.Parameters.Add("@DAY", SqlDbType.VarChar, 20).Value = day;
            sqlcon.Open();
            sqlcom.ExecuteNonQuery();
            sqlcon.Close();
        }
        #endregion
        protected void btnExit_Click(object sender, ImageClickEventArgs e)
        {
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 16, 16);
            Response.Redirect("../SELLManage/offersearch.aspx" + n2);
        }
        protected void btnPrint_Click(object sender, ImageClickEventArgs e)
        {
            /*string vard1 = Text15.Value;
            String[] Carstr = new string[] { vard1 };
            WPSS.ReportManage.CRVPrintBill.Array[0] = Carstr[0];
            Response.Redirect("../ReportManage/CRVPrintBill.aspx");
            //excelprint();*/
            hint.Value = "购买后联系供应商开通使用";
        }

    }
}
