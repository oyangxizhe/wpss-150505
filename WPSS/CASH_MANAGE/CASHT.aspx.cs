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

namespace WPSS.CASH_MANAGE
{
    public partial class CASHT : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        basec bc = new basec();
        WPSS.Validate va = new Validate();
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

        private static int _CIRCULATION_COUNT;
        public static int CIRCULATION_COUNT
        {
            set { _CIRCULATION_COUNT = value; }
            get { return _CIRCULATION_COUNT; }

        }
        private bool _IFExecutionSUCCESS;
        public bool IFExecution_SUCCESS
        {
            set { _IFExecutionSUCCESS = value; }
            get { return _IFExecutionSUCCESS; }

        }
        private string _CASH;
        public string CASH
        {
            set { _CASH = value; }
            get { return _CASH; }

        }
        private string _CSKEY;
        public string CSKEY
        {
            set { _CSKEY = value; }
            get { return _CSKEY; }

        }

        CCASH cCASH = new CCASH();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Text1.Value = IDO;
                bind();
            }

            if (va.returnb() == true)
                Response.Redirect("\\Default.aspx");
        }
   
        #region bind
        protected void bind()
        {
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 10, 10);
            string varMakerID = bc.getOnlyString("SELECT EMID FROM USERINFO WHERE USID='" + n2 + "'");
            emid.Value = varMakerID;
            if (bc.GET_IFExecutionSUCCESS_HINT_INFO(IFExecution_SUCCESS) != "")
            {
                hint.Value = bc.GET_IFExecutionSUCCESS_HINT_INFO(IFExecution_SUCCESS);
            }
            else
            {
                hint.Value = "";
            }
            DataTable   dtx3 =bc.getdt(cCASH .sql +" WHERE A.CSID='"+Text1.Value +"'");
            if (dtx3.Rows.Count > 0)
            {
                Text2.Value = dtx3.Rows[0]["USER_GROUP"].ToString();
                Text4.Value = dtx3.Rows[0]["CASH"].ToString();
                Text5.Value = dtx3.Rows[0]["BILL_DATE"].ToString();
                Text6.Value = dtx3.Rows[0]["HANDLER_ID"].ToString();
                Label1.Text = dtx3.Rows[0]["HANDLER"].ToString();
            }
            else
            {

                Text5.Value = DateTime.Now.ToString("yyyy-MM-dd");
                Text6.Value = varMakerID;
                Label1.Text = bc.getOnlyString("SELECT ENAME FROM EMPLOYEEINFO WHERE EMID='" + varMakerID + "'");
            }
       }
        
        #endregion
        protected void ClearText()
        {
            Text1.Value = "";
            Text2.Value = "";
  
            Text4.Value = "";
            Text5.Value = "";
            Text6.Value = "";
            TextBox1.Text = "";
            Label1.Text = "";
        }
        protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        {
            btnSave.Enabled = true;
            ClearText();
            string var1 = bc.numYM(10, 4, "0001", "SELECT * FROM CASH", "CSID", "CS");
            if (var1 == "Exceed Limited")
            {
                hint.Value = "编码超出限制！";
                return;
            }
            Text1.Value = var1;
            bind();
          
        }

        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {
            if (juage())
            {

            }
            else
            {
                save();
            }
            if (IFExecution_SUCCESS == true && ADD_OR_UPDATE == "ADD")
            {
               
                add();
            }
            else if (IFExecution_SUCCESS == true)
            {
               
                bind();
            }
            try
            {
              
            }
            catch (Exception)
            {


            }

        }
        #region save
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
            string v2;
            v2 = bc.getOnlyString("SELECT USER_GROUP FROM GODE WHERE  GODEID='" + Text1.Value + "'");
            CSKEY = bc.numYMD(20, 12, "000000000001", "select * from CASH", "CSKEY", "CS");
            if (!bc.exists("SELECT CSID FROM CASH WHERE CSID='" + Text1.Value + "'"))
            {
                if (bc.exists("select * from GODE where USER_GROUP='" + Text2.Value + "'"))
                {

                    hint.Value = "该用户组已经存在了！";

                }
                else
                {
                   
                    SQlcommandE(cCASH.sqlo);
                    SQlcommandE(cCASH.sqlf,CSKEY );
                    IFExecution_SUCCESS = true;


                }
            }
            else if (v2 != Text2.Value)
            {
               
                if (bc.exists("select * from GODE where USER_GROUP='" + Text2.Value + "'"))
                {
                    hint.Value = "该用户组已经存在了！";
                }
                else if (bc.JuageDeleteCASH_MoreThanStorageCASH(Text1.Value, Text2.Value))
                {
                    hint.Value = bc.ErrowInfo;
                
                }
                else
                {
                    SQlcommandE(cCASH.sqlth + " WHERE CSID='" + Text1.Value + "'");
                    SQlcommandE(cCASH.sqlfi + " WHERE GODEID='" + Text1.Value + "'", CSKEY);
                    IFExecution_SUCCESS = true;
                }

            }
            else
            {
                if (bc.JuageDeleteCASH_MoreThanStorageCASH(Text1.Value, Text2.Value))
                {
                    hint.Value = bc.ErrowInfo;
               
                }
                else
                {
                    SQlcommandE(cCASH.sqlth + " WHERE CSID='" + Text1.Value + "'");
                    SQlcommandE(cCASH.sqlfi + " WHERE GODEID='" + Text1.Value + "'", CSKEY);
                    IFExecution_SUCCESS = true;
                }
            }
        }
        #endregion
        protected void add()
        {

            ClearText();
            Text1.Value  = bc.numYM(10, 4, "0001", "SELECT * FROM CASH", "CSID", "CS");
            bind();
            ADD_OR_UPDATE = "ADD";
        }
        private bool juage()
        {

            bool b = false;
            if (!bc.exists("SELECT * FROM EMPLOYEEINFO WHERE EMID='" + Text6.Value + "'"))
            {
                hint.Value = "员工工号不存在于系统中！";
                b = true;
            }
            else if (Text2.Value =="")
            {
                hint.Value = "用户组不能为空！";
                b = true;
            }
            else if (!bc.exists("SELECT * FROM USERINFO WHERE USER_GROUP='" + Text2.Value + "'"))
            {
                hint.Value = "用户组不存在于系统中！";
                b = true;
            }
            else if (Text4.Value=="")
            {

                hint.Value = "金额不能为空！";
                b = true;
            }
            else if (bc.yesno(Text4.Value ) == 0)
            {

                hint.Value = "金额只能输入数字！";
                b = true;
            }
         
            else if (CSKEY == "Exceed Limited")
            {
                hint.Value = "编码超出限制！";
                b = true;
            }
            /*else if (Text10.Value == "0.00")
            {
                hint.Value = "归还套数需大于0！";
                b = false;
            }
           */
            return b;
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
            sqlcom.Parameters.Add("@CSKEY", SqlDbType.VarChar, 20).Value = CSKEY;
            sqlcom.Parameters.Add("@CSID", SqlDbType.VarChar, 20).Value = Text1.Value;
            sqlcom.Parameters.Add("@HANDLER_ID", SqlDbType.VarChar, 20).Value = Text6.Value;
            sqlcom.Parameters.Add("@BILL_DATE", SqlDbType.VarChar, 20).Value = Text5.Value;
            sqlcom.Parameters.Add("@REMARK", SqlDbType.VarChar, 1000).Value = TextBox1.Text;
            sqlcom.Parameters.Add("@YEAR", SqlDbType.VarChar, 20).Value = year;
            sqlcom.Parameters.Add("@MONTH", SqlDbType.VarChar, 20).Value = month;
            sqlcom.Parameters.Add("@DAY", SqlDbType.VarChar, 20).Value = day;
            sqlcon.Open();
            sqlcom.ExecuteNonQuery();
            sqlcon.Close();
        }
        #endregion
        #region SQlcommandE
        protected void SQlcommandE(string sql, string GEKEY)
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
            sqlcom.Parameters.Add("@GEKEY", SqlDbType.VarChar, 20).Value = GEKEY;
            sqlcom.Parameters.Add("@GODEID", SqlDbType.VarChar, 20).Value = Text1.Value;
            sqlcom.Parameters.Add("@USER_GROUP", SqlDbType.VarChar, 20).Value = Text2.Value;
            sqlcom.Parameters.Add("@CASH", SqlDbType.VarChar, 20).Value = Text4.Value;
            sqlcom.Parameters.Add("@DATE", SqlDbType.VarChar, 20).Value = varDate;
            sqlcom.Parameters.Add("@DEBIT_MAKERID", SqlDbType.VarChar, 20).Value = varMakerID;
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
            Response.Redirect("../cash_manage/cash.aspx" + n2);
        }
    }
}


