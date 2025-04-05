﻿using System;
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

namespace WPSS.FINANCIAL_MANAGE
{
    public partial class ADVANCE_PAYMENTT : System.Web.UI.Page
    {

        DataTable dt = new DataTable();
        basec bc = new basec();
      

        private string _APKEY;
        public string APKEY
        {
            set { _APKEY = value; }
            get { return _APKEY; }

        }
        private string _GEKEY;
        public string GEKEY
        {
            set { _GEKEY = value; }
            get { return _GEKEY; }

        }
        private string _MRKEY;
        public string MRKEY
        {
            set { _MRKEY = value; }
            get { return _MRKEY; }

        }

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

        WPSS.Validate va = new Validate();
        CADVANCE_PAYMENT cadvance_payment = new CADVANCE_PAYMENT();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Text1.Value = IDO;
                Bind();
            }

            if (va.returnb() == true)
                Response.Redirect("\\Default.aspx");
        }
        protected void Bind()
        {

            if (bc.GET_IFExecutionSUCCESS_HINT_INFO(IFExecution_SUCCESS) != "")
            {
                hint.Value = bc.GET_IFExecutionSUCCESS_HINT_INFO(IFExecution_SUCCESS);
            }
            else
            {
                hint.Value = "";
            }
         
            dt = basec.getdts(cadvance_payment.sql + " where A.APID='" + Text1.Value + "'");
            if (dt.Rows.Count > 0)
            {

                Text2.Value = dt.Rows[0]["供应商代码"].ToString();
                Text3.Value = dt.Rows[0]["供应商名称"].ToString();
                Text4.Value = dt.Rows[0]["预付金额"].ToString();
                Text5.Value = dt.Rows[0]["经手人工号"].ToString();
                Text6.Value = dt.Rows[0]["预付日期"].ToString();
                Label1.Text = dt.Rows[0]["经手人"].ToString();
                TextBox1.Text = dt.Rows[0]["备注"].ToString();
            }
            else
            {

                currentdate();
            }

        }
    
        protected void currentdate()
        {

            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 10, 10);
            string varMakerID = bc.getOnlyString("SELECT EMID FROM USERINFO WHERE USID='" + n2 + "'");
            Text5.Value = varMakerID;
            Text6.Value =DateTime.Now.ToString("yyyy-MM-dd").Replace("/", "-");
            Label1.Text = bc.getOnlyString("SELECT ENAME FROM EMPLOYEEINFO WHERE EMID='" + varMakerID + "'");

        }
        protected void ClearText()
        {
            Text1.Value = "";
            Text2.Value = "";
            Text3.Value = "";
            Text4.Value = "";
            Text5.Value = "";
            Text6.Value = "";
            TextBox1.Text = "";
            Label1.Text = "";
        }


        protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        {
            add();
        }
        protected void add()
        {

      
            ClearText();
            Text1.Value = cadvance_payment.GETID();
            currentdate();
            Bind();
            ADD_OR_UPDATE = "ADD";

        }
        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {

            save();
            if (IFExecution_SUCCESS == true && ADD_OR_UPDATE == "ADD")
            {
                add();
            }
            else if (IFExecution_SUCCESS == true)
            {
                Bind();
            }
            try
            {
               

            }
            catch (Exception)
            {

            }

        }
        protected void save()
        {
            hint.Value = "";
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyy/MM/dd HH:mm:ss").Replace("-", "/");
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 10, 10);
            string varMakerID = bc.getOnlyString("SELECT EMID FROM USERINFO WHERE USID='" + n2 + "'");
            
            APKEY = bc.numYMD(20, 12, "000000000001", "SELECT * FROM ADVANCE_PAYMENT", "APKEY", "AP");
            if (bc.exists("SELECT * FROM REQUEST_MONEY_MST WHERE APID='" + Text1.Value + "'"))
            {
                hint.Value = "此预付款单已经存在请款单 不允许保存";
            }
            else  if (juage1())
            {

            }
            else if (APKEY == "Exceed Limited")
            {
                hint.Value = "编码超出限制！";

            }
            else
            {
                GEKEY = APKEY;
                if (!bc.exists("SELECT * FROM ADVANCE_PAYMENT WHERE APID='"+Text1 .Value +"'"))
                {
                    SQlcommandE(cadvance_payment.sqlo);
                    SQlcommandE_GODE(cadvance_payment.sqlt);
                }
                else
                {
                    SQlcommandE(cadvance_payment.sqlf+" WHERE APID='"+Text1 .Value +"'");
                    SQlcommandE_GODE(cadvance_payment.sqlfi + " WHERE GODEID='" + Text1.Value + "'");

                }
                IFExecution_SUCCESS = true;
            }

        }
        #region juage1()
        private bool juage1()
        {
            bool b = false;
            if (Text4.Value =="")
            {
                b = true;
                hint.Value = "预付金额不能为空！";

            }
            else  if (bc.yesno(Text4.Value) == 0)
            {
                b = true;
                hint.Value = "金额只能输入数字！";

            }
            else if (!bc.exists("SELECT * FROM SUPPLIERINFO_MST WHERE SUID='" + Text2.Value + "'"))
            {
                hint.Value = "供应商代码不存在于系统中！";
                b = true;

            }
            else if (Text5.Value == "")
            {
                hint.Value = "工号不能为空！";
                b = true;
            }
            else if (!bc.exists("SELECT * FROM EMPLOYEEINFO WHERE EMID='" + Text5.Value + "'"))
            {
                hint.Value = "员工工号不存在于系统中！";
                b = true;
            }
            return b;
        }
        #endregion

        protected void btnExit_Click(object sender, ImageClickEventArgs e)
        {
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 16, 16);
            Response.Redirect("../financial_manage/advance_payment.aspx" + n2);
        }
        #region SQlcommandE
        protected void SQlcommandE(string sql)
        {
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").Replace("/", "-");
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 10, 10);
            string varMakerID = bc.getOnlyString("SELECT EMID FROM USERINFO WHERE USID='" + n2 + "'");
            SqlConnection sqlcon = bc.getcon();
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            sqlcom.Parameters.Add("@APKEY", SqlDbType.VarChar, 20).Value = APKEY;
            sqlcom.Parameters.Add("@APID", SqlDbType.VarChar, 20).Value = Text1.Value;
            sqlcom.Parameters.Add("@SUID", SqlDbType.VarChar, 20).Value = Text2.Value;
            sqlcom.Parameters.Add("@ADVANCE_PAYMENT_MAKERID", SqlDbType.VarChar, 20).Value = Text5.Value;
            sqlcom.Parameters.Add("@ADVANCE_PAYMENT_DATE", SqlDbType.VarChar, 20).Value = Text6.Value;
            sqlcom.Parameters.Add("@IF_ALREADY_USE", SqlDbType.VarChar, 20).Value = "N";
            sqlcom.Parameters.Add("@REMARK", SqlDbType.VarChar, 20).Value = TextBox1.Text;
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
  
        #region SQlcommandE_GODE
        protected void SQlcommandE_GODE(string sql)
        {
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").Replace("/", "-");
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 10, 10);
            string varMakerID = bc.getOnlyString("SELECT EMID FROM USERINFO WHERE USID='" + n2 + "'");
            SqlConnection sqlcon = bc.getcon();
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            sqlcom.Parameters.Add("@GEKEY", SqlDbType.VarChar, 20).Value = GEKEY;
            sqlcom.Parameters.Add("@GODEID", SqlDbType.VarChar, 20).Value = Text1.Value;
            sqlcom.Parameters.Add("@ADVANCE_PAYMENT_AMOUNT", SqlDbType.VarChar, 20).Value = Text4.Value;
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
        #region SQlcommandE_MATERE
        protected void SQlcommandE_MATERE(string sql)
        {
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").Replace("/", "-");
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 10, 10);
            string varMakerID = bc.getOnlyString("SELECT EMID FROM USERINFO WHERE USID='" + n2 + "'");
            SqlConnection sqlcon = bc.getcon();
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            sqlcom.Parameters.Add("@MRKEY", SqlDbType.VarChar, 20).Value = MRKEY;
            sqlcom.Parameters.Add("@MATEREID", SqlDbType.VarChar, 20).Value = Text1.Value;
            sqlcom.Parameters.Add("@ADVANCE_PAYMENT_AMOUNT", SqlDbType.VarChar, 20).Value = Text4.Value;
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
    }
}


