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
namespace WPSS.LEASE_MANAGE
{
    public partial class RETURN_EQUIPMENTT : System.Web.UI.Page
    {

        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();
        DataTable dtx2 = new DataTable();
        DataTable dtx3 = new DataTable();
        basec bc = new basec();
    
        CRETURN_EQUIPMENT cRETURN_EQUIPMENT = new CRETURN_EQUIPMENT();
        WPSS.Validate va = new Validate();
      
        int i = 0,j;
        DataTable dt4 = new DataTable();
        #region nature
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
        private string _WAREID;
        public string WAREID
        {
            set { _WAREID = value; }
            get { return _WAREID; }

        }
        private string _DEBIT_MAKERID;
        public string DEBIT_MAKERID
        {
            set { _DEBIT_MAKERID = value; }
            get { return _DEBIT_MAKERID; }

        }
        private string _SN;
        public string SN
        {
            set { _SN = value; }
            get { return _SN; }

        }
        private string _EQUIPMENT_DATE;
        public string EQUIPMENT_DATE
        {
            set { _EQUIPMENT_DATE = value; }
            get { return _EQUIPMENT_DATE; }

        }
        private string _LEND_DATE;
        public string LEND_DATE
        {
            set { _LEND_DATE = value; }
            get { return _LEND_DATE; }

        }
        private string _STORAGENAME;
        public string STORAGENAME
        {
            set { _STORAGENAME = value; }
            get { return _STORAGENAME; }

        }
        private string _BATCHID;
        public string BATCHID
        {
            set { _BATCHID = value; }
            get { return _BATCHID; }

        }
        private int _LEASE_DAYS;
        public int LEASE_DAYS
        {
            set { _LEASE_DAYS = value; }
            get { return _LEASE_DAYS; }

        }
        private string _EQCOUNT;
        public string EQCOUNT
        {
            set { _EQCOUNT = value; }
            get { return _EQCOUNT; }

        }
        private string _USER_GROUP;
        public string USER_GROUP
        {
            set { _USER_GROUP = value; }
            get { return _USER_GROUP; }

        }
        #endregion
        PrintSellTableBill print = new PrintSellTableBill();
        string EQKEY;
        CLEND clend = new CLEND();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                Text1.Value = IDO;
                dt = bc.getdt(cRETURN_EQUIPMENT.sqlfi  + " WHERE A.EQID='" + IDO + "'");
                if (dt.Rows.Count > 0)
                {
                    Text1.Value = dt.Rows[0]["归还单号"].ToString();
                    Text3.Value = dt.Rows[0]["单据日期"].ToString();
                    Text4.Value = dt.Rows[0]["归还人工号"].ToString();
                    Text8.Value = dt.Rows[0]["借出单号"].ToString();
                    Text5.Value = dt.Rows[0]["客户ID或供应商ID"].ToString();
                    Text6.Value = dt.Rows[0]["客户或供应商"].ToString();
                    Text7.Value = dt.Rows[0]["客户电话或供应商电话"].ToString();
                }
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
        #region bind
        protected void bind()
        {
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 10, 10);
            string varMakerID = bc.getOnlyString("SELECT EMID FROM USERINFO WHERE USID='" + n2 + "'");
            string v1 = bc.getOnlyString("SELECT ADD_NEW FROM RIGHTLIST WHERE USID='" + n2 + "' AND NODE_NAME='归还作业'");
            string v2 = bc.getOnlyString("SELECT EDIT FROM RIGHTLIST WHERE USID='" + n2 + "' AND NODE_NAME='归还作业'");
            if (v1 == "Y")
            {
                btnAdd.Visible = true;
                Label2.Visible = true;
            }
            else
            {
                btnAdd.Visible = false;
                Label2.Visible = false;
            }
            if (v1 == "Y" || v2 == "Y")
            {
                btnSave.Visible = true;
                Label3.Visible = true;
            }
            else
            {
                btnSave.Visible = false;
                Label3.Visible = false;
            }
            emid.Value = varMakerID;
            if (bc.GET_IFExecutionSUCCESS_HINT_INFO(IFExecution_SUCCESS) != "")
            {
                hint.Value = bc.GET_IFExecutionSUCCESS_HINT_INFO(IFExecution_SUCCESS);
            }
            else
            {
                hint.Value = "";
            }
            x.Value = "";
            CUKEY.Value = "";
            ControlFileDisplay.Value = "";
            CIRCULATION_COUNT = 4;

            if (as1(Text1.Value, Text8.Value).Rows.Count > 0)
            {
                x.Value = "1";
                x2.Value = "1";
            }
            GridView1.DataSource = as1(Text1.Value, Text8.Value);
            GridView1.DataKeyNames = new string[] { "项次" };
            GridView1.DataBind();

            dt4 = cRETURN_EQUIPMENT.ask(Text1.Value);
            if (dt4.Rows.Count > 0)
            {
                GridView2.DataSource = dt4;
                GridView2.DataKeyNames = new string[] { "索引" };
                GridView2.DataBind();
                x.Value = Convert.ToString(1);
            }
            else
            {
                GridView2.DataSource = null;
                GridView2.DataBind();
            }
            dtx3 = cRETURN_EQUIPMENT.ask(Text1.Value);
            if (dtx3.Rows.Count > 0)
            {
                Text3.Value = dtx3.Rows[0]["单据日期"].ToString();
                Text4.Value = dtx3.Rows[0]["归还人工号"].ToString();
                Label1.Text = dtx3.Rows[0]["归还人"].ToString();
            }
            else
            {
               
                Text3.Value = DateTime.Now.ToString("yyyy-MM-dd");
                Text4.Value = varMakerID;
                Label1.Text = bc.getOnlyString("SELECT ENAME FROM EMPLOYEEINFO WHERE EMID='" + varMakerID + "'");
            }
            DataTable dtx4 = bc.getdt(cRETURN_EQUIPMENT.sqlfi + " WHERE A.EQID='"+Text1 .Value +"'");
            if (dtx4.Rows.Count > 0)
            {
              
                string v9 = dt4.Compute("SUM(租金)", "").ToString();
                string v10 = dt4.Compute("SUM(退还押金)", "").ToString();
                if (!string.IsNullOrEmpty(v9))
                {
                 
                    Text51.Value = string.Format("{0:F2}", Convert.ToDouble(v9));
                    Text52.Value = string.Format("{0:F2}", Convert.ToDouble(v10));
                }
                x.Value = Convert.ToString(1);
            }
            else
            {
              
                Text51.Value = "";
                Text52.Value = "";

            }
        }
        #endregion
    
        #region ask
        private DataTable ask(string v1, string v2)
        {
            DataTable dtt = new DataTable();
            dtt.Columns.Add("借出单号", typeof(string));
            dtt.Columns.Add("项次", typeof(string));
            dtt.Columns.Add("品号", typeof(string));
            dtt.Columns.Add("料号", typeof(string));
            dtt.Columns.Add("品名", typeof(string));
            dtt.Columns.Add("客户料号", typeof(string));
            dtt.Columns.Add("借出数量", typeof(decimal));
            dtt.Columns.Add("累计归还数量", typeof(decimal));
            dtt.Columns.Add("未归还数量", typeof(decimal), "借出数量-累计归还数量");
            dtt.Columns.Add("归还数量", typeof(decimal));
            dtt.Columns.Add("仓库", typeof(string));
            dtt.Columns.Add("批号", typeof(string));
            dtt.Columns.Add("本归还单累计归还数量", typeof(decimal));
            dtt.Columns.Add("借出日期", typeof(string));
            dtt.Columns.Add("日租金", typeof(decimal ));
            dtt.Columns.Add("押金", typeof(decimal ));
            dtt.Columns.Add("归还日期", typeof(string));
            dtt.Columns.Add("租用天数", typeof(decimal ));
            dtt.Columns.Add("租金", typeof(decimal));
            dtt.Columns.Add("退还押金", typeof(decimal));
            DataTable dtx1 = bc.getdt(clend.sqlfi + " WHERE A.LEID='"+v2+"'");
            if (dtx1.Rows.Count > 0)
            {
                for (i = 0; i < dtx1.Rows.Count; i++)
                {
                    DataRow dr = dtt.NewRow();
                    dr["借出单号"] = dtx1.Rows[i]["借出单号"].ToString();
                    dr["项次"] = dtx1.Rows[i]["项次"].ToString();
                    dr["品号"] = dtx1.Rows[i]["ID"].ToString();

                    dtx2 = bc.getdt("select * from wareinfo where wareid='" + dtx1.Rows[i]["ID"].ToString() + "'");
                    dr["料号"] = dtx2.Rows[0]["CO_WAREID"].ToString();
                    dr["品名"] = dtx2.Rows[0]["WNAME"].ToString();
                    dr["客户料号"] = dtx2.Rows[0]["CWAREID"].ToString();
                    dr["借出数量"] = dtx1.Rows[i]["借出数量"].ToString();
                    dr["累计归还数量"] = 0;
                    dr["本归还单累计归还数量"] = 0;
                    dr["借出日期"] = dtx1.Rows[i]["借出日期"].ToString();
                    dr["日租金"] = dtx1.Rows[i]["日租金"].ToString();
                    dr["押金"] = dtx1.Rows[i]["押金"].ToString();
                    dr["归还日期"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                 
                    dr["租用天数"] = cRETURN_EQUIPMENT.GET_LEASE_DAYS(dtx1.Rows[i]["借出日期"].ToString(), DateTime.Now.ToString("yyyy-MM-dd"));
                    int days = cRETURN_EQUIPMENT.GET_LEASE_DAYS(dtx1.Rows[i]["借出日期"].ToString(), DateTime.Now.ToString("yyyy-MM-dd"));
                    dr["租金"] = "0.00";
                    dr["退还押金"] = "0.00";
                    dtt.Rows.Add(dr);

                }

            }

            DataTable dtx4 = bc.getdt(@"
SELECT A.LEID AS LEID,A.SN AS SN,B.WAREID AS WAREID,CAST(ROUND(SUM(B.GECOUNT),2) AS DECIMAL(18,2)) AS GECOUNT FROM RETURN_EQUIPMENT_DET A 
LEFT JOIN GODE B ON A.EQKEY=B.GEKEY  WHERE  A.LEID='" + v2 + "' GROUP BY A.LEID,A.SN,B.WAREID");
            if (dtx4.Rows.Count > 0)
            {
                for (i = 0; i < dtx4.Rows.Count; i++)
                {
                    for (j = 0; j < dtt.Rows.Count; j++)
                    {
                        if (dtt.Rows[j]["借出单号"].ToString() == dtx4.Rows[i]["LEID"].ToString() && dtt.Rows[j]["项次"].ToString() == dtx4.Rows[i]["SN"].ToString())
                        {
                            dtt.Rows[j]["累计归还数量"] = dtx4.Rows[i]["GECOUNT"].ToString();
                            break;
                        }

                    }
                }

            }

            DataTable dtx5 = bc.getdt(@"SELECT A.LEID AS LEID,A.EQID AS EQID,A.SN AS SN,B.WAREID AS WAREID,
CAST(ROUND(SUM(B.GECOUNT),2) AS DECIMAL(18,2)) AS GECOUNT FROM RETURN_EQUIPMENT_DET A 
LEFT JOIN GODE B ON A.EQKEY=B.GEKEY  WHERE  A.LEID='" + v2 + "' AND A.EQID='" + v1 + "' GROUP BY A.LEID,A.EQID,A.SN,B.WAREID");
            if (dtx5.Rows.Count > 0)
            {
                for (i = 0; i < dtx5.Rows.Count; i++)
                {
                    for (j = 0; j < dtt.Rows.Count; j++)
                    {
                        if (dtt.Rows[j]["借出单号"].ToString() == dtx5.Rows[i]["LEID"].ToString() &&
                            dtt.Rows[j]["项次"].ToString() == dtx5.Rows[i]["SN"].ToString())
                        {
                            dtt.Rows[j]["本归还单累计归还数量"] = dtx5.Rows[i]["GECOUNT"].ToString();
                            break;
                        }

                    }
                }

            }
            return dtt;
        }
        #endregion
        #region as1
        private DataTable as1(string v1, string v2)
        {
            DataTable dtt = ask(v1, v2);
            for (i = 0; i < dtt.Rows.Count; i++)
            {
                dtt.Rows[i]["归还数量"] = dtt.Rows[i]["未归还数量"].ToString();
                if (decimal.Parse(dtt.Rows[i]["未归还数量"].ToString()) == 0)
                {
                    /*dtt.Rows[i]["押金"] = "0";
                    dtt.Rows[i]["租用天数"] = "0";
                    dtt.Rows[i]["日租金"] = "0";*/
                  
                    
                }
            }
            return dtt;
        }
        #endregion
        private bool juage()
        {

            bool b = false;
            if (!bc.exists("SELECT * FROM EMPLOYEEINFO WHERE EMID='" + Text4.Value + "'"))
            {
                hint.Value = "归还员工工号不存在于系统中！";
                b = true;
            }
            else if (bc.exists("SELECT * FROM RETURN_EQUIPMENT_MST WHERE EQID='" + Text1.Value + "'"))
            {

                hint.Value = "此归还单已经存在系统中，不能再保存！";
                b = true;
            }
            else if (EQKEY == "Exceed Limited")
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


        protected void ClearText()
        {
            Text3.Value = "";
            Text4.Value = "";
            Label1.Text = "";
        }
        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {
            if (juage())
            {

            }
            else
            {
                add2();
            }
            try
            {

            }
            catch (Exception)
            {

            }
        }


        #region add2
        private void add2()
        {

            int k;
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss");
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 10, 10);
            string varMakerID = bc.getOnlyString("SELECT EMID FROM USERINFO WHERE USID='" + n2 + "'");
            int count = GridView1.Rows.Count;
           
            for (k = 0; k < GridView1.Rows.Count; k++)
            {

                if (ac1(k))
                {


                }
                else
                {
                   
                    EQKEY = bc.numYMD(20, 12, "000000000001", "select * from RETURN_EQUIPMENT_DET", "EQKEY", "EQ");
                    string STORAGEID = bc.getOnlyString("SELECT STORAGEID FROM STORAGEINFO WHERE STORAGENAME='" + STORAGENAME + "'");
                    string REMARK = ((TextBox)GridView1.Rows[k].Cells[0].FindControl("TextBox14")).Text;
                     LEASE_DAYS  = cRETURN_EQUIPMENT.GET_LEASE_DAYS(LEND_DATE ,EQUIPMENT_DATE );
                    if (WAREID == "")
                    {

                    }
                    else
                    {

                     
                        SQlcommandE(cRETURN_EQUIPMENT.sqlo, EQKEY, SN, REMARK);
                        SQlcommandE(cRETURN_EQUIPMENT.sqlf, EQKEY, WAREID, SN, EQCOUNT, STORAGEID, BATCHID);
                
                    }
                }

            }/*under FOR OUTSIDE*/
            clend.UPDATE_LEND_STATUS(Text8.Value);
            if (!bc.exists("SELECT EQID FROM RETURN_EQUIPMENT_DET WHERE EQID='" + Text1.Value + "'"))
            {

                return;
            }
            if (!bc.exists("SELECT EQID FROM RETURN_EQUIPMENT_MST WHERE EQID='" + Text1.Value + "'"))
            {
        
                SQlcommandE(cRETURN_EQUIPMENT.sqlt);
                IFExecution_SUCCESS = true;
            }
            else
            {
                SQlcommandE(cRETURN_EQUIPMENT.sqlth + " WHERE EQID='" + Text1.Value + "'");
                IFExecution_SUCCESS = true;

            }
            USER_GROUP = bc.getOnlyString("SELECT B.USER_GROUP FROM STORAGEINFO A LEFT JOIN USERINFO B ON A.MAKERID=B.EMID WHERE A.STORAGENAME='"+STORAGENAME  +"'");
            DEBIT_MAKERID = bc.getOnlyString("SELECT EMID FROM USERINFO WHERE USER_GROUP='"+USER_GROUP +"'");
            bind();
            SQlcommandE(cRETURN_EQUIPMENT.sqlsi, EQKEY);
        }
        #endregion

        #region ac1()
        private bool ac1(int k)
        {

            bool b = false;
            WAREID = ((TextBox)GridView1.Rows[k].Cells[0].FindControl("TextBox1")).Text;
            SN = ((TextBox)GridView1.Rows[k].Cells[0].FindControl("TextBox2")).Text;
            EQCOUNT = ((TextBox)GridView1.Rows[k].Cells[0].FindControl("TextBox9")).Text;
            STORAGENAME = ((TextBox)GridView1.Rows[k].Cells[0].FindControl("TextBox10")).Text;
            BATCHID = ((TextBox)GridView1.Rows[k].Cells[0].FindControl("TextBox11")).Text;
            LEND_DATE = ((TextBox)GridView1.Rows[k].Cells[0].FindControl("TextBox71")).Text;
            EQUIPMENT_DATE  = ((TextBox)GridView1.Rows[k].Cells[0].FindControl("TextBox74")).Text;
            string v1 = EQUIPMENT_DATE.Substring(0, 10);
            DateTime d1 = Convert.ToDateTime(LEND_DATE);
            DateTime d2 = Convert.ToDateTime(v1);

            if (WAREID == "")
            {
                b = true;
            }
            else if (string.IsNullOrEmpty(EQCOUNT))
            {
                b = true;
                hint.Value = "归还数量不能为空或为0！";

            }
            else if (bc.yesno(EQCOUNT) == 0)
            {
                b = true;
                hint.Value = "数量只能输入数字！";
            }
            else if (STORAGENAME == "")
            {
                b = true;
                hint.Value = "项次："+SN +"仓库不能为空！";

            }
            else if (!bc.exists("SELECT * FROM STORAGEINFO WHERE STORAGENAME='" + STORAGENAME + "'"))
            {
                b = true;
                hint.Value = "项次：" + SN + "该仓库不存在于系统中！";
            }
     
            else if (BATCHID == "")
            {
                b = true;
                hint.Value = "批号不能为空！";
            }
            else if (d1>d2)
            {
                b = true;
                hint.Value = "借出日期不能大于归还日期";
            }
            /*else if (decimal.Parse(MGCOUNT) > decimal.Parse(NOMGCOUNT))
            {
                b=true;
                hint.Value = "归还数量不能大于未归还数量！";
            }*/
         
       

            return b;
        }
        #endregion

        #region SQlcommandE
        protected void SQlcommandE(string sql, string EQKEY, string SN, string REMARK)
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
            sqlcom.Parameters.Add("@EQKEY", SqlDbType.VarChar, 20).Value = EQKEY;
            sqlcom.Parameters.Add("@EQID", SqlDbType.VarChar, 20).Value = Text1.Value;
            sqlcom.Parameters.Add("@LEID", SqlDbType.VarChar, 20).Value = Text8.Value;
            sqlcom.Parameters.Add("@SN", SqlDbType.VarChar, 20).Value = SN;
            sqlcom.Parameters.Add("@LEASE_DAYS", SqlDbType.VarChar, 20).Value = LEASE_DAYS;
            sqlcom.Parameters.Add("@EQUIPMENT_DATE", SqlDbType.VarChar, 20).Value = EQUIPMENT_DATE;
            sqlcom.Parameters.Add("@REMARK", SqlDbType.VarChar, 20).Value = REMARK;
            sqlcom.Parameters.Add("@YEAR", SqlDbType.VarChar, 20).Value = year;
            sqlcom.Parameters.Add("@MONTH", SqlDbType.VarChar, 20).Value = month;
            sqlcom.Parameters.Add("@DAY", SqlDbType.VarChar, 20).Value = day;
            sqlcon.Open();
            sqlcom.ExecuteNonQuery();
            sqlcon.Close();
        }
        #endregion
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
            sqlcom.Parameters.Add("@EQID", SqlDbType.VarChar, 20).Value = Text1.Value;
            sqlcom.Parameters.Add("@BILL_DATE", SqlDbType.VarChar, 20).Value = Text3.Value;
            sqlcom.Parameters.Add("@EQUIPMENT_MAKERID", SqlDbType.VarChar, 20).Value = Text4.Value;
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
        #region SQlcommandE
        protected void SQlcommandE(string sql, string GEKEY, string WAREID, string SN,
            string GECOUNT, string STORAGEID, string BATCHID)
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
            sqlcom.Parameters.Add("@SN", SqlDbType.VarChar, 20).Value = SN;
            sqlcom.Parameters.Add("@WAREID", SqlDbType.VarChar, 20).Value = WAREID;
            sqlcom.Parameters.Add("@GECOUNT", SqlDbType.VarChar, 20).Value = GECOUNT;
            
            sqlcom.Parameters.Add("@STORAGEID", SqlDbType.VarChar, 20).Value = STORAGEID;
   
            sqlcom.Parameters.Add("@BATCHID", SqlDbType.VarChar, 20).Value = BATCHID;
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

        #region SQlcommandE
        protected void SQlcommandE(string sql, string MRKEY)
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
            sqlcom.Parameters.Add("@MRKEY", SqlDbType.VarChar, 20).Value = MRKEY;
            sqlcom.Parameters.Add("@MATEREID", SqlDbType.VarChar, 20).Value = Text1.Value;
            sqlcom.Parameters.Add("@USER_GROUP", SqlDbType.VarChar, 20).Value = USER_GROUP;
            sqlcom.Parameters.Add("@CASH", SqlDbType.VarChar, 20).Value = Text52.Value;
            sqlcom.Parameters.Add("@DATE", SqlDbType.VarChar, 20).Value = varDate;
            sqlcom.Parameters.Add("@DEBIT_MAKERID", SqlDbType.VarChar, 20).Value = DEBIT_MAKERID;
            sqlcom.Parameters.Add("@MAKERID", SqlDbType.VarChar, 20).Value = varMakerID;
            sqlcom.Parameters.Add("@YEAR", SqlDbType.VarChar, 20).Value = year;
            sqlcom.Parameters.Add("@MONTH", SqlDbType.VarChar, 20).Value = month;
            sqlcom.Parameters.Add("@DAY", SqlDbType.VarChar, 20).Value = day;
            sqlcon.Open();
            sqlcom.ExecuteNonQuery();
            sqlcon.Close();
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

        protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
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
        protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        {
            ClearText();
            Text1.Value = cRETURN_EQUIPMENT.GETID;
            bind();
        }
        protected void btnExit_Click(object sender, ImageClickEventArgs e)
        {
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 16, 16);
            Response.Redirect("../LEASE_MANAGE/RETURN_EQUIPMENT.aspx" + n2);
        }
        #region gridview deleting
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string sql, sql1;
            hint.Value = "";
         
            sql = "DELETE RETURN_EQUIPMENT_MST WHERE EQID='" + Text1.Value + "'";
            sql1 = "DELETE RETURN_EQUIPMENT_DET WHERE EQID='" + Text1.Value + "'";

            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 10, 10);
            string v1 = bc.getOnlyString("SELECT DEL FROM RIGHTLIST WHERE USID='" + n2 + "' AND NODE_NAME='归还作业'");
            if (v1 != "Y")
            {
                hint.Value = "您无删除权限！";
            }
            else
            {
                basec.getcoms(sql);
                basec.getcoms(sql1);
                basec.getcoms("DELETE GODE WHERE GODEID='" + Text1.Value + "'");
                basec.getcoms("DELETE MATERE WHERE MATEREID='" + Text1.Value + "'");

                GridView1.EditIndex = -1;
                bind();
            }

            try
            {
            }
            catch (Exception)
            {


            }
        }
        #endregion

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
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



        protected void btnPrint_Click(object sender, ImageClickEventArgs e)
        {
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 10, 10);
            string varMakerID = bc.getOnlyString("SELECT EMID FROM USERINFO WHERE USID='" + n2 + "'");
            clend.USID = n2;
            dt = bc.getdt(cRETURN_EQUIPMENT .sqlfi  + " WHERE A.EQID='" + Text1.Value + "'");
            WPSS.ReportManage.CRVPrintBill.SEARCH = clend.ADD_COMPANYINFO(dt, "归还单");
            WPSS.ReportManage.CRVPrintBill.Array[0] = "RETURN_EQUIPMENT";
            Response.Redirect("../ReportManage/CRVPrintBill.aspx");
        }
   
        protected void excelprint()
        {


            try
            {
                DataTable dtn = print.askt(Text1.Value);
                if (dtn.Rows.Count > 1)
                {

                    int i = dtn.Rows.Count - 1;
                    if (i > 0 && i <= 10)
                    {
                        if (bc.JuagePrintModelIfExists(1, "SE"))
                        {

                            bc.ExcelPrint(dtn, "归还单", "");
                        }
                        else
                        {
                            hint.Value = bc.ErrowInfo;

                        }

                    }
                    else if (i > 10 && i <= 20)
                    {
                        if (bc.JuagePrintModelIfExists(2, "SE"))
                        {

                            bc.ExcelPrint(dtn, "归还单", "");
                        }
                        else
                        {
                            hint.Value = bc.ErrowInfo;

                        }

                    }
                    else
                    {
                        hint.Value = "一张归还单最多支持打印20个归还项。超出20请建多张归还单！";

                    }


                }
                else
                {


                    hint.Value = "无数据可打印！";

                }

            }
            catch (Exception)
            {


            }
        }
        protected void btnSure_Click(object sender, EventArgs e)
        {

            if (!bc.exists("SELECT * FROM LEND_MST WHERE LEID='" + Text8.Value + "'"))
            {
                hint.Value = "该借出单号不存在于系统中！";
                return;

            }

            bind();
        }
    }
}
