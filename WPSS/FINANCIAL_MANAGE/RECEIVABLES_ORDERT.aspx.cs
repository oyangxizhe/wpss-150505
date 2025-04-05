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

namespace WPSS.FINANCIAL_MANAGE
{
    public partial class RECEIVABLES_ORDERT : System.Web.UI.Page
    {

        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        basec bc = new basec();
        private string _ROKEY;
        public string ROKEY
        {
            set { _ROKEY = value; }
            get { return _ROKEY; }

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
        CRECEIVABLES creceivables = new CRECEIVABLES();
        CRECEIVABLES_ORDER CRECEIVABLES_ORDER = new CRECEIVABLES_ORDER();
    
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

            dt = bc.GET_DT_TO_DV_TO_DT(CRECEIVABLES_ORDER.RETURN_DT(), "", "收款单号='"+Text1.Value +"'");
            if (dt.Rows.Count > 0)
            {
                dt1 = bc.GET_DT_TO_DV_TO_DT(creceivables.RETURN_DT(), "", "应收单号='" + dt.Rows[0]["应收单号"].ToString() + "'");
                if (dt1.Rows.Count > 0)
                {
                    Text3.Value = dt1.Rows[0]["客户名称"].ToString();
                    Text4.Value = dt1.Rows[0]["发票号码"].ToString();
                    Text5.Value = dt1.Rows[0]["发票含税金额"].ToString();
                    Text6.Value = dt1.Rows[0]["预收款单号"].ToString();
                    Text7.Value = dt1.Rows[0]["预收款金额"].ToString();
                    Text8.Value = dt1.Rows[0]["扣款项目"].ToString();
                    Text9.Value = dt1.Rows[0]["扣款金额"].ToString();
                    Text10.Value = dt1.Rows[0]["实际应收金额"].ToString();
                    Text11.Value = dt1.Rows[0]["累计收款金额"].ToString();
                    Text12.Value = dt1.Rows[0]["未收款金额"].ToString();
                }
                Text2.Value = dt.Rows[0]["应收单号"].ToString();
                Text13.Value = dt.Rows[0]["收款金额"].ToString();
                Text14.Value = dt.Rows[0]["收款人工号"].ToString();
                Text15.Value = dt.Rows[0]["收款日期"].ToString();
                Label1.Text = dt.Rows[0]["收款人"].ToString();
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
            Text14.Value = varMakerID;
            Text15.Value =DateTime.Now.ToString("yyyy-MM-dd").Replace("/", "-");
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
            Text7.Value = "";
            Text8.Value = "";
            Text9.Value = "";
            Text10.Value = "";
            Text11.Value = "";
            Text12.Value = "";
            Text13.Value = "";
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
            Text1.Value = CRECEIVABLES_ORDER.GETID();
            currentdate();
            Bind();
            ADD_OR_UPDATE = "ADD";

        }
        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {

            save();
            if (IFExecution_SUCCESS == true)
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
            
            ROKEY = bc.numYMD(20, 12, "000000000001", "SELECT * FROM RECEIVABLES_ORDER", "ROKEY", "RO");
            string v1 = bc.getOnlyString("SELECT RECEIVABLES_ORDER_AMOUNT FROM RECEIVABLES_ORDER WHERE ROID='"+Text1.Value +"'");
            if (juage1())
            {

            }
            else if (ROKEY == "Exceed Limited")
            {
                hint.Value = "编码超出限制！";

            }
            else
            {
                GEKEY = ROKEY;
                if (!bc.exists("SELECT * FROM RECEIVABLES_ORDER WHERE ROID='"+Text1 .Value +"'"))
                {
                    if (decimal.Parse(Text13.Value) > decimal.Parse(Text12.Value))
                    {
                        hint.Value = "收款金额不能大余未收金额";
                        IFExecution_SUCCESS = false;


                    }
                    else
                    {
                        SQlcommandE(CRECEIVABLES_ORDER.sqlo);
                        //SQlcommandE_GODE(CRECEIVABLES_ORDER.sqlt);
                        IFExecution_SUCCESS = true;
                    }
                }
                else if (v1 != Text11.Value)
                {
                    if (decimal.Parse(Text11.Value) > decimal.Parse(Text10.Value))
                    {
                        hint.Value = "收款金额不能大余未收金额";
                        IFExecution_SUCCESS = false;


                    }
                    else
                    {
                        SQlcommandE(CRECEIVABLES_ORDER.sqlf + " WHERE ROID='" + Text1.Value + "'");
                        IFExecution_SUCCESS = true;

                    }
                }
                else
                {
                    SQlcommandE(CRECEIVABLES_ORDER.sqlf + " WHERE ROID='" + Text1.Value + "'");
                    IFExecution_SUCCESS = true;
                    //SQlcommandE_GODE(CRECEIVABLES_ORDER.sqlfi + " WHERE GODEID='" + Text1.Value + "'");

                }
               
            }

        }
        #region juage1()
        private bool juage1()
        {
            decimal d1 = 0;
            DataTable dtx1 = bc.getdt(@"
SELECT 
RCID AS RCID,
SUM(RECEIVABLES_ORDER_AMOUNT) AS RECEIVABLES_ORDER_AMOUNT 
FROM RECEIVABLES_ORDER 
WHERE
RCID='" + Text2.Value  + "' AND ROID!='"+Text1.Value +"' GROUP BY RCID");
            if (dtx1.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(dtx1.Rows[0]["RECEIVABLES_ORDER_AMOUNT"].ToString()))
                {
                   d1=decimal.Parse(dtx1.Rows[0]["RECEIVABLES_ORDER_AMOUNT"].ToString());
           
                }

            }
            decimal INVOICE_HAVETAX_AMOUNT =0, ADVANCE_AMOUNT = 0, CUTRECEIVABLES_AMOUNT = 0;
            if (Text5.Value != "")
            {
                INVOICE_HAVETAX_AMOUNT = decimal.Parse(Text5.Value);
            }
            if (!string.IsNullOrEmpty(Text7.Value))
            {
                ADVANCE_AMOUNT = decimal.Parse(Text7.Value);
            }
       
            if (!string.IsNullOrEmpty(Text9.Value))
            {
                CUTRECEIVABLES_AMOUNT = decimal.Parse(Text9.Value);
            }
            
            bool b = false;
            if (Text2.Value =="")
            {
                b = true;
                hint.Value = "应收款单号不能为空！";
            }
            else if (!bc.exists("SELECT * FROM RECEIVABLES_MST WHERE RCID='" + Text2.Value + "'"))
            {
                hint.Value = "应收款单号不存在于系统中！";
                b = true;
            }
            else if (decimal .Parse (Text10.Value )!=INVOICE_HAVETAX_AMOUNT -ADVANCE_AMOUNT -CUTRECEIVABLES_AMOUNT )
            {
                b = true;
                hint.Value = "实际应收款金额 " + Text10.Value + " 需=发票含税金额 " + INVOICE_HAVETAX_AMOUNT +
                    " - 预收款金额 " + ADVANCE_AMOUNT + " - 扣款金额 " + CUTRECEIVABLES_AMOUNT;
            }
            else  if (Text13.Value =="")
            {
                b = true;
                hint.Value = "收款金额不能为空！";

            }
            else  if (bc.yesno(Text13.Value) == 0)
            {
                b = true;
                hint.Value = "收款金额只能输入数字！";

            }
            else if (d1+decimal.Parse(Text13.Value )>decimal .Parse (Text10.Value ))
            {
                b = true;
                hint.Value = "收款金额 " + Text13.Value  + " + 此收款单外累计收款金额 " + d1.ToString ("0.00")+ " 不能大余实际应收款金额 " + Text10.Value;

            }
            else if (Text14.Value == "")
            {
                hint.Value = "工号不能为空！";
                b = true;
            }
            else if (!bc.exists("SELECT * FROM EMPLOYEEINFO WHERE EMID='" + Text14.Value + "'"))
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
            Response.Redirect("../financial_manage/RECEIVABLES_ORDER.aspx" + n2);
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
            sqlcom.Parameters.Add("@ROKEY", SqlDbType.VarChar, 20).Value = ROKEY;
            sqlcom.Parameters.Add("@ROID", SqlDbType.VarChar, 20).Value = Text1.Value;
            sqlcom.Parameters.Add("@RCID", SqlDbType.VarChar, 20).Value = Text2.Value;
            sqlcom.Parameters.Add("@RECEIVABLES_ORDER_MAKERID", SqlDbType.VarChar, 20).Value = Text14.Value;
            sqlcom.Parameters.Add("@RECEIVABLES_ORDER_DATE", SqlDbType.VarChar, 20).Value = Text15.Value;
            sqlcom.Parameters.Add("@RECEIVABLES_ORDER_AMOUNT", SqlDbType.VarChar, 20).Value = Text13.Value;
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
  
    
    }
}


