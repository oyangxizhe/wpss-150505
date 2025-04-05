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
    public partial class SellUnitPriceT : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        basec bc = new basec();
        WPSS.Validate va = new Validate();
        PrintOfferBill print = new PrintOfferBill();
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
        string sqlt = @"
INSERT INTO OFFER(
OFID,
WAREID,
CUID,
DATE,
MAKERID,
YEAR,
MONTH,
DAY
)
VALUES 
(
@OFID,
@WAREID,
@CUID,
@DATE,
@MAKERID,
@YEAR,
@MONTH,
@DAY
)

";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //ViewState["pageindex"] = "0";
                Text1.Value = IDO;
                bind();
                Bind();


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
          
                dt = basec.getdts(@"
SELECT
A.WAREID AS WAREID,
A.CUID AS CUID,
B.CO_WAREID AS CO_WAREID,
B.WNAME AS WNAME,
B.CWAREID AS CWAREID,
C.CNAME AS CNAME,
A.SELLUNITPRICE AS SELLUNITPRICE ,
A.REMARK AS REMARK
from SELLUNITPRICE A
LEFT JOIN WAREINFO B ON A.WAREID=B.WAREID
LEFT JOIN CUSTOMERINFO_MST C ON A.CUID=C.CUID
where A.SPID='" + Text1.Value + "'");
                if (dt.Rows.Count > 0)
                {

                    Text2.Value = dt.Rows[0]["WAREID"].ToString();
                    Text3.Value = dt.Rows[0]["CO_WAREID"].ToString();
                    Text4.Value = dt.Rows[0]["WNAME"].ToString();
                    Text5.Value = dt.Rows[0]["CWAREID"].ToString();
                    Text6.Value = dt.Rows[0]["CUID"].ToString();
                    Text7.Value = dt.Rows[0]["SELLUNITPRICE"].ToString();
                    Text8.Value = dt.Rows[0]["CNAME"].ToString();
                    TextBox1.Text = dt.Rows[0]["REMARK"].ToString();

                }


            


        }
        protected void ClearText()
        {
            Text2.Value = "";
            Text3.Value = "";
            Text4.Value = "";
            Text5.Value = "";
            Text6.Value = "";
            Text7.Value = "";
            Text8.Value = "";
            TextBox1.Text = "";
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
            if (juage())
            {

            }
            else if (!bc.exists("SELECT SPID FROM SELLUNITPRICE WHERE SPID='" + Text1.Value + "'"))
            {
                if (bc.exists("select * from SELLUNITPRICE where  WAREID='" + Text2.Value + "'"))
                {
                    hint.Value = "此品号客户已经有核价信息！";
                }
                else
                {
                    basec.getcoms(@"
insert into SELLUNITPRICE(
SPID,
WAREID,
CUID,
SELLUNITPRICE,
MakerID,
Date,
Year,
Month,
Day,
REMARK
) 
values('" + Text1.Value + "','" + Text2.Value + "', '"+Text6.Value +"','" + Text7.Value + "' ,'" + varMakerID + "','" + varDate +
                      "','" + year + "','" + month + "','" + day + "','" + TextBox1.Text + "')");
                    IFExecution_SUCCESS = true;
                }
            }
            else if (v1 != Text2.Value)
            {
                if (bc.exists("select * from SELLUNITPRICE where  WAREID='" + Text2.Value + "'"))
                {

                    hint.Value = "此品号客户已经有核价信息！";

                }
                else
                {

                    basec.getcoms("UPDATE SELLUNITPRICE SET WAREID='" + Text2.Value + "' ,SELLUNITPRICE='" + Text7.Value +
                        "',CUID='"+Text6 .Value +"',MAKERID='" + varMakerID + "',DATE='" + varDate + 
                        "',REMARK='" + TextBox1.Text + "' WHERE SPID='" + Text1.Value + "'");
                    IFExecution_SUCCESS = true;
                }
            }
            else
            {
                basec.getcoms("UPDATE SELLUNITPRICE SET WAREID='" + Text2.Value + "' ,SELLUNITPRICE='" + Text7.Value +
                         "',CUID='"+Text6 .Value +"',MAKERID='" + varMakerID + "',DATE='" + varDate +
                         "',REMARK='" + TextBox1.Text + "' WHERE SPID='" + Text1.Value + "'");
                IFExecution_SUCCESS = true;
            }
        }
        #endregion
        private bool juage()
        {
            bool b = false;

            if (!bc.exists("SELECT * FROM WAREINFO WHERE WAREID='" + Text2.Value + "' AND ACTIVE='Y'"))
            {
                b = true;
                hint.Value = "该品号不存在于系统或状态不为正常！";
            }
            else if (Text6.Value == "")
            {
                b = true;
                hint.Value = "客户代码不能为空！";
            }
            else if (!bc.exists("SELECT * FROM CUSTOMERINFO_MST WHERE CUID='" + Text6.Value + "'"))
            {

                b = true;
                hint.Value = "客户代码不存在于系统中！";
            }
            else if (Text7.Value == "")
            {
                b = true;
                hint.Value = "单价不能为空！";
            }
            else if (bc.yesno(Text7.Value) == 0)
            {
                b = true;
                hint.Value = "单价只能输入数字！";
            }
            return b;

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

        protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        {
            add();
         
        }
        protected void add()
        {
           
            ClearText();
            string a = bc.numYM(10, 4, "0001", "select * from SELLUNITPRICE", "SPID", "SP");
            if (a == "Exceed limited")
            {

                hint.Value = "编码超出限制！";
            }
            else
            {
                Text1.Value = a;

            }
            bind();
            Bind();
            ADD_OR_UPDATE = "ADD";


        }
        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {
            hint.Value = "";
            if (Text2.Value == "")
            {
                hint.Value = "ID不能为空！";
            }

            else
            {
                save();
                if (IFExecution_SUCCESS == true && ADD_OR_UPDATE == "ADD")
                {
                    add();
                }
                else if (IFExecution_SUCCESS == true)
                {
                    bind();
                    Bind();
                }
            }

            try
            {
        
            }
            catch (Exception)
            {


            }
        }

        protected void btnExit_Click(object sender, ImageClickEventArgs e)
        {
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 16, 16);
            Response.Redirect("../SELLManage/SELLUNITPRICE.aspx" + n2);
        }

        protected void btnOnloadFile_Click(object sender, EventArgs e)
        {
            try
            {
                CFileInfo cf = new CFileInfo();
                cf.OnloadFile(Text1.Value);
                hint.Value = cf.ErrowInfo;
                Bind();
            }
            catch (Exception)
            {

            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string id = GridView1.DataKeys[e.RowIndex][0].ToString();
                string FilePath = bc.getOnlyString("SELECT PATH FROM WAREFILE WHERE FLKEY='" + id + "'");
                string s1 = Server.MapPath(FilePath);
                if (File.Exists(s1))
                {
                    File.Delete(s1);
                }
                string strSql = "DELETE FROM WAREFILE WHERE FLKEY='" + id + "'";
                basec.getcoms(strSql);
                GridView1.EditIndex = -1;
                Bind();
            }
            catch (Exception)
            {


            }
        }
        protected void Bind()
        {
            DataList1.DataSource = dtx();
            DataList1.DataBind();
            DataTable dt1 = basec.getdts("SELECT * FROM WAREFILE WHERE WAREID='" + Text1.Value + "'");
            GridView1.DataSource = dt1;
            GridView1.DataKeyNames = new string[] { "FLKEY" };
            GridView1.DataBind();
        }
        protected DataTable dtx()
        {
            dt.Columns.Add("C", typeof(string));
            for (int i = 0; i < 4; i++)
            {
                DataRow dr = dt.NewRow();
                dr["C"] = Convert.ToString(i);
                dt.Rows.Add(dr);
            }
            return dt;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string v1 = GridView1.DataKeys[GridView1.SelectedIndex].Values[0].ToString();
                string FilePath = bc.getOnlyString("SELECT PATH FROM WAREFILE WHERE FLKEY='" + v1 + "'");
                FileInfo file = new FileInfo(Server.MapPath(FilePath));
                if (file.Exists)
                {
                    Response.Clear();
                    string fileName = HttpUtility.UrlEncode(file.Name);
                    Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
                    //Response.AddHeader("Content-Length", file.Length.ToString());
                    Response.ContentType = "application/octet-stream;charset=gb2312";
                    Response.Filter.Close();
                    Response.WriteFile(file.FullName);
                    Response.End();
                }
            }
            catch (Exception)
            {

            }

        }



        #region SQlcommandE
        protected void SQlcommandE(string sql, string a)
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
            sqlcom.Parameters.Add("@OFID", SqlDbType.VarChar, 20).Value = a;
            sqlcom.Parameters.Add("@WAREID", SqlDbType.VarChar, 20).Value = Text2.Value;
            sqlcom.Parameters.Add("@CUID", SqlDbType.VarChar, 20).Value = Text6.Value;
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

        protected void GenerateUNITPRICE_Click(object sender, EventArgs e)
        {
            jenerate_unitprice();
            try
            {
             
            }
            catch (Exception)
            {



            }
        }
 
        protected void jenerate_unitprice()
        {

            dt = print.ask(Text2.Value);
            if (dt.Rows.Count > 0)
            {

                if (juage())
                {

                }
                else
                {
                  

                    string a = bc.numYMD(11, 4, "0001", "select * from OFFER", "OFID", "Q");
                    Text15.Value = a;
                    if (a == "Exceed limited")
                    {

                        hint.Value = "编码超出限制！";
                    }
                    else
                    {
                        SqlConnection sqlcon = bc.getcon();
                        SQlcommandE(sqlt, a);

                    }
                }

            }


        }

    }
}
