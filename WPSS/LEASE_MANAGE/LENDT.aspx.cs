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
using Excel = Microsoft.Office.Interop.Excel;


namespace WPSS.LEASE_MANAGE
{
    public partial class LENDT : System.Web.UI.Page
    {

        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();
        DataTable dtx2 = new DataTable();
        DataTable dtx3 = new DataTable();
        basec bc = new basec();
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
        private string _DAILY_RENT;
        public string DAILY_RENT
        {
            set { _DAILY_RENT = value; }
            get { return _DAILY_RENT; }

        }
        private string _DEPOSIT;
        public string DEPOSIT
        {
            set { _DEPOSIT = value; }
            get { return _DEPOSIT; }

        }
        private string _LEND_DATE;
        public string LEND_DATE
        {
            set { _LEND_DATE = value; }
            get { return _LEND_DATE; }

        }
        CLEND cLEND = new CLEND();

        CCASH_ADD ccash_add = new CCASH_ADD();
        WPSS.Validate va = new Validate();
        int i = 0;
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
        #endregion
        PrintSellTableBill print = new PrintSellTableBill();
        string LEKEY;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                Text1.Value = IDO;
                dt = bc.getdt(cLEND.sqlfi + " WHERE A.LEID='" + IDO + "'");
                if (dt.Rows.Count > 0)
                {
                    Text1.Value = dt.Rows[0]["借出单号"].ToString();
                    Text3.Value = dt.Rows[0]["单据日期"].ToString();
                    Text4.Value = dt.Rows[0]["制单人工号"].ToString();
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
            string v1 = bc.getOnlyString("SELECT ADD_NEW FROM RIGHTLIST WHERE USID='" + n2 + "' AND NODE_NAME='借出作业'");
            string v2 = bc.getOnlyString("SELECT EDIT FROM RIGHTLIST WHERE USID='" + n2 + "' AND NODE_NAME='借出作业'");
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
            CIRCULATION_COUNT = 1;

            GridView1.DataSource = dtx();
            GridView1.DataKeyNames = new string[] { "项次" };
            GridView1.DataBind();

            dt4 = cLEND.ask(Text1.Value);
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
            dtx3 = cLEND.ask(Text1.Value);
            if (dtx3.Rows.Count > 0)
            {
                Text3.Value = dtx3.Rows[0]["单据日期"].ToString();
                Text4.Value = dtx3.Rows[0]["借出员工号"].ToString();
                Label1.Text = dtx3.Rows[0]["借出员"].ToString();
            }
            else
            {
              
                Text3.Value = DateTime.Now.ToString("yyy-MM-dd");
                Text4.Value = varMakerID;
                Label1.Text = bc.getOnlyString("SELECT ENAME FROM EMPLOYEEINFO WHERE EMID='" + varMakerID + "'");
            }

            DataTable dtx4 = basec.getdts(@"SELECT LEID,SUM(DAILY_RENT),SUM(DEPOSIT)
FROM LEND_DET WHERE LEID='" + Text1.Value + "' GROUP BY LEID ");

            if (dtx4.Rows.Count > 0)
            {
                string v8 = dtx4.Rows[0][1].ToString();
                string v9 = dtx4.Rows[0][2].ToString();
            
                Text50.Value = string.Format("{0:F2}", Convert.ToDouble(v8));
                Text51.Value = string.Format("{0:F2}", Convert.ToDouble(v9));
    
                x.Value = Convert.ToString(1);

            }
            else
            {
                Text50.Value = "";
                Text51.Value = "";
           

            }
      
        }
        #endregion
        protected DataTable dtx()
        {

            DataTable dt4 = new DataTable();
            dt4.Columns.Add("项次", typeof(string));
            dt4.Columns.Add("借出日期", typeof(string));
            for (i = 1; i <= CIRCULATION_COUNT; i++)
            {
                DataRow dr = dt4.NewRow();
                dr["项次"] = Convert.ToString(i);
                dr["借出日期"] = DateTime.Now.ToString("yyy-MM-dd");
                dt4.Rows.Add(dr);
            }
            return dt4;
        }
        protected void btnSure_Click(object sender, EventArgs e)
        {
            hint.Value = "";
            if (juage())
            {

            }
            else
            {

                bind();
            }

        }
        private bool juage()
        {

            bool b = false;
          
            if (!bc.exists("SELECT * FROM EMPLOYEEINFO WHERE EMID='" + Text4.Value + "'"))
            {
                hint.Value = "借出员工工号不存在于系统中！";
                b = true;
            }
            /*else if (bc.exists("SELECT * FROM LEND_MST WHERE LEID='" + Text1.Value + "'"))
            {

                hint.Value = "此借出单已经存在系统中，不能再保存！";
                b = true;
            }*/
             else if (bc.exists("SELECT * FROM RETURN_EQUIPMENT_DET WHERE LEID='" + Text1.Value + "'"))
            {

                hint.Value = "此借出单已经存在有归还单，不能再保存！";
                b = true;
            }
            else if (Text5.Value == "")
            {
                hint.Value = "客户代码不能为空！";
                b = true;
            }
            else if (!bc.exists("SELECT * FROM CUSTOMERINFO_MST WHERE CUID='" + Text5.Value + "'"))
            {
                hint.Value = "客户代码不存在于系统中！";
                b = true;
            }
            else if (LEKEY == "Exceed Limited")
            {
                hint.Value = "编码超出限制！";
                b = true;
            }
            /*else if (Text10.Value == "0.00")
            {
                hint.Value = "借出套数需大于0！";
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
           
                bind();
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
            string varDate = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss").Replace("/", "-");
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 10, 10);
            string sqlth = "";


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
            int count = GridView1.Rows.Count;
            string s1;
            int s2;
            for (k = 0; k < GridView1.Rows.Count; k++)
            {

                if (ac1(k))
                {

                   
                }
                else
                {

                    LEKEY = bc.numYMD(20, 12, "000000000001", "select * from LEND_DET", "LEKEY", "LE");
                    string MPCOUNT = ((TextBox)GridView1.Rows[k].Cells[3].FindControl("TextBox4")).Text;
                    string STORAGENAME = ((TextBox)GridView1.Rows[k].Cells[5].FindControl("TextBox6")).Text;
    
                    string BATCHID = ((TextBox)GridView1.Rows[k].Cells[7].FindControl("TextBox8")).Text;
                    string STORAGECOUNT = ((TextBox)GridView1.Rows[k].Cells[8].FindControl("TextBox9")).Text;
                    string WAREID = ((TextBox)GridView1.Rows[k].Cells[0].FindControl("TextBox1")).Text;
                    string STORAGEID = bc.getOnlyString("SELECT STORAGEID FROM STORAGEINFO WHERE STORAGENAME='" + STORAGENAME + "'");
                  
                    string SN = ((TextBox)GridView1.Rows[k].Cells[0].FindControl("TextBox1")).Text;
                    string REMARK = ((TextBox)GridView1.Rows[k].Cells[0].FindControl("TextBox14")).Text;
                 
                    if (WAREID == "")
                    {
                      
                    }
                    else
                    {
                        
                        DataTable dty = bc.getdt("SELECT * FROM LEND_DET WHERE LEID='" + Text1.Value + "'");
                        if (dty.Rows.Count > 0)
                        {
                            s1 = dty.Rows[dty.Rows.Count - 1]["SN"].ToString();
                            s2 = Convert.ToInt32(s1) + 1;
                        }
                        else
                        {
                            s2 = 1;
                        }
                        SN = Convert.ToString(s2);
                        SQlcommandE(cLEND.sqlo, LEKEY, SN, REMARK);
                        SQlcommandE(cLEND.sqlf, LEKEY, WAREID, SN, MPCOUNT, STORAGEID, BATCHID);
                        bc.STORAGE_MAKERID = sqlth;
                        DataTable dtx6 = bc.getmaxstoragecount(WAREID);
                       
                        if (dtx6.Rows.Count > 0)
                        {
                            for (int n = 0; n < count; n++)
                            {
                                if (((TextBox)GridView1.Rows[n].Cells[0].FindControl("TextBox1")).Text == WAREID)
                                {
                                    ((TextBox)GridView1.Rows[n].Cells[5].FindControl("TextBox6")).Text = dtx6.Rows[0]["仓库"].ToString();
                                   
                                    ((TextBox)GridView1.Rows[n].Cells[7].FindControl("TextBox8")).Text = dtx6.Rows[0]["批号"].ToString();
                                    ((TextBox)GridView1.Rows[n].Cells[8].FindControl("TextBox9")).Text = dtx6.Rows[0]["库存数量"].ToString();
                                }
                            }
                        }
                        else
                        {
                            
                            for (int n = 0; n < count; n++)
                            {
                                if (((TextBox)GridView1.Rows[n].Cells[0].FindControl("TextBox1")).Text == WAREID)
                                {
                                    ((TextBox)GridView1.Rows[n].Cells[5].FindControl("TextBox6")).Text = "";
                     
                                    ((TextBox)GridView1.Rows[n].Cells[7].FindControl("TextBox8")).Text = "";
                                    ((TextBox)GridView1.Rows[n].Cells[8].FindControl("TextBox9")).Text = "";
                                }
                            }
                        }
                    }
                }

            }/*under FOR OUTSIDE*/
            //cLEND.UPDATE_LEND_STATUS(Text2.Value);
            if (!bc.exists("SELECT LEID FROM LEND_DET WHERE LEID='" + Text1.Value + "'"))
            {
               
                return;
            }
            if (!bc.exists("SELECT LEID FROM LEND_MST WHERE LEID='" + Text1.Value + "'"))
            {

                SQlcommandE(cLEND.sqlt);
                IFExecution_SUCCESS = true;
            }
            else
            {
                SQlcommandE(cLEND.sqlth + " WHERE LEID='" + Text1.Value + "'");
                IFExecution_SUCCESS = true;
            }
    
            ccash_add.EMID = varMakerID;
          
            ccash_add.BILL_DATE =DateTime.Now .ToString("yyyy-MM-dd").Replace("/", "-");
            ccash_add.CASH = DEPOSIT;
            ccash_add.CDID = Text1.Value;
            ccash_add.HANLDER_ID = Text4.Value;
            ccash_add.USER_GROUP = bc.getOnlyString("SELECT USER_GROUP FROM USERINFO WHERE EMID='"+varMakerID +"'");
            ccash_add.REMARK = "";
            ccash_add.save();
            IFExecution_SUCCESS = true;
            hint.Value = ccash_add.ErrowInfo;
           
        }
        #endregion

        #region ac1()
        private bool ac1(int k)
        {
          
            bool b = false;
            string WAREID = ((TextBox)GridView1.Rows[k].Cells[0].FindControl("TextBox1")).Text;
            string MPCOUNT = ((TextBox)GridView1.Rows[k].Cells[3].FindControl("TextBox4")).Text;
            string STORAGENAME = ((TextBox)GridView1.Rows[k].Cells[5].FindControl("TextBox6")).Text;
            string BATCHID = ((TextBox)GridView1.Rows[k].Cells[7].FindControl("TextBox8")).Text;
            string STORAGECOUNT = ((TextBox)GridView1.Rows[k].Cells[8].FindControl("TextBox9")).Text;

            DAILY_RENT = ((TextBox)GridView1.Rows[k].Cells[0].FindControl("TextBox15")).Text;
            DEPOSIT = ((TextBox)GridView1.Rows[k].Cells[0].FindControl("TextBox16")).Text;
            LEND_DATE  = ((TextBox)GridView1.Rows[k].Cells[0].FindControl("TextBox17")).Text;
            string k1 = bc.CheckingWareidAndStorage(WAREID, STORAGENAME, BATCHID);
            if (WAREID == "")
            {
                b = true;
            }
            else if (string.IsNullOrEmpty (MPCOUNT ))
            {
                b = true;
                hint.Value = "借出数量不能为空或为0！";
              
            }
            else if (bc.yesno(MPCOUNT) == 0)
            {
                b = true;
                hint.Value = "数量只能输入数字！";
            }
            else if (string.IsNullOrEmpty(DAILY_RENT ))
            {
                b = true;
                hint.Value = "日租金不能为空或为0！";

            }
            else if (bc.yesno(DAILY_RENT ) == 0)
            {
                b = true;
                hint.Value = "日租金只能输入数字！";
            }
            else if (string.IsNullOrEmpty(DEPOSIT ))
            {
                b = true;
                hint.Value = "押金不能为空或为0！";

            }
            else if (bc.yesno(DEPOSIT ) == 0)
            {
                b = true;
                hint.Value = "押金只能输入数字！";
            }
            else if (STORAGENAME == "")
            {
                b = true;
                hint.Value = "仓库不能为空！";

            }
            else if (!bc.exists("SELECT * FROM STORAGEINFO WHERE STORAGENAME='" + STORAGENAME + "'"))
            {
                b = true;
                hint.Value = "该仓库不存在于系统中！";
            }
      
            else if (BATCHID == "")
            {
                b = true;
                hint.Value = "批号不能为空！";
            }

            /*else if (decimal.Parse(MPCOUNT) > decimal.Parse(NOMPCOUNT))
            {
                b=true;
                hint.Value = "借出数量不能大于未借出数量！";
            }*/
            else if (k1 != STORAGECOUNT)
            {
                b = true;
                hint.Value = "选择的库存品号与此项次借出品号不一致！";
            }
            else if (decimal.Parse(MPCOUNT) > decimal.Parse(STORAGECOUNT))
            {
                b = true;

                hint.Value = "借出数量不能大于库存数量！";
            }
         
            return b;
        }
        #endregion

        #region SQlcommandE
        protected void SQlcommandE(string sql, string LEKEY, string SN, string REMARK)
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
            sqlcom.Parameters.Add("@LEKEY", SqlDbType.VarChar, 20).Value = LEKEY;
            sqlcom.Parameters.Add("@LEID", SqlDbType.VarChar, 20).Value = Text1.Value;
            sqlcom.Parameters.Add("@SN", SqlDbType.VarChar, 20).Value = SN;
         
            sqlcom.Parameters.Add("@DAILY_RENT", SqlDbType.VarChar, 20).Value = DAILY_RENT;
            sqlcom.Parameters.Add("@DEPOSIT", SqlDbType.VarChar, 20).Value = DEPOSIT;
            sqlcom.Parameters.Add("@LEND_STATUS_DET", SqlDbType.VarChar, 20).Value = "OPEN";
            sqlcom.Parameters.Add("@LEND_DATE", SqlDbType.VarChar, 20).Value = LEND_DATE;
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
            sqlcom.Parameters.Add("@LEID", SqlDbType.VarChar, 20).Value = Text1.Value;
            sqlcom.Parameters.Add("@CUID", SqlDbType.VarChar, 20).Value = Text5.Value;
            sqlcom.Parameters.Add("@BILL_DATE", SqlDbType.VarChar, 20).Value = Text3.Value;
            sqlcom.Parameters.Add("@LEND_MAKERID", SqlDbType.VarChar, 20).Value = Text4.Value;
            sqlcom.Parameters.Add("@LEND_STATUS_MST", SqlDbType.VarChar, 20).Value = "OPEN";
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
        protected void SQlcommandE(string sql, string MRKEY, string WAREID, string SN,
            string MRCOUNT, string STORAGEID, string BATCHID)
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
            sqlcom.Parameters.Add("@SN", SqlDbType.VarChar, 20).Value = SN;
            sqlcom.Parameters.Add("@WAREID", SqlDbType.VarChar, 20).Value = WAREID;
            sqlcom.Parameters.Add("@MRCOUNT", SqlDbType.VarChar, 20).Value = MRCOUNT;
     
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
   

        protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        {
            ClearText();
            Text1.Value = cLEND.GETID;
            bind();
        }
        protected void btnExit_Click(object sender, ImageClickEventArgs e)
        {
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 16, 16);
            Response.Redirect("../LEASE_MANAGE/LEND.aspx" + n2);
        }
     

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



   
        private void Print()
        {
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string date = Text1.Value;
            Microsoft.Office.Interop.Excel.Application application = new Microsoft.Office.Interop.Excel.Application();
            Excel.Workbook workbook = application.Workbooks.Add(Type.Missing);
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets[1];

            Excel.ApplicationClass excel = new Excel.ApplicationClass();
            excel.Application.Workbooks.Add(true);
            dt2 = bc.getdt(cLEND.sqlfi +" WHERE A.LEID='"+Text1.Value +"'");
            if (dt2.Rows.Count > 0)
            {
                excel.Cells[2, 1] = "借出单号：";
                excel.Cells[2, 2] = dt2.Rows[0]["借出单号"].ToString();
                excel.Cells[2, 4] = "单据日期：";
                excel.Cells[2, 5] = dt2.Rows[0]["单据日期"].ToString();
                excel.Cells[2,7] = "借出人：";
                excel.Cells[2, 8] = dt2.Rows[0]["借出员"].ToString();

                excel.Cells[3, 1] = "客户：";
                excel.Cells[3, 2] = dt2.Rows[0]["客户或供应商"].ToString();

                excel.Cells[3, 4] = "手机：";
                excel.Cells[3, 5] = dt2.Rows[0]["客户电话或供应商电话"].ToString();
                excel.Cells[5, 1] = "品号";
                excel.Cells[5, 2] = "品名";
                excel.Cells[5, 3] = "借出数量";
                excel.Cells[5, 4] = "借出日期";
                excel.Cells[5, 5] = "日租金";
                excel.Cells[5, 6] = "押金";
                excel.Cells[6, 1] = dt2.Rows[0]["ID"].ToString();
                excel.Cells[6, 2] = dt2.Rows[0]["品名"].ToString();
                excel.Cells[6, 3] = dt2.Rows[0]["借出数量"].ToString();
                excel.Cells[6, 4] = dt2.Rows[0]["借出日期"].ToString();
                excel.Cells[6, 5] = dt2.Rows[0]["日租金"].ToString();
                excel.Cells[6, 6] = dt2.Rows[0]["押金"].ToString();
                excel.get_Range(excel.Cells[1, 1], excel.Cells[3, 1]).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                excel.get_Range(excel.Cells[2, 4], excel.Cells[3, 4]).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
        
            }
            worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, 6]).MergeCells = true;
            worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[65536, 256]).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            //excel.get_Range(excel.Cells[1, 1], excel.Cells[65536, 256]).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            excel.get_Range(excel.Cells[1, 1], excel.Cells[65536, 256]).Columns.AutoFit();
            excel.get_Range(excel.Cells[1, 1], excel.Cells[1, 1]).Select();
            excel.get_Range(excel.Cells[5, 1], excel.Cells[6, 8]).Borders.LineStyle = 1;
            excel.Visible = false;
            excel.ExtendList = false;
            excel.DisplayAlerts = false;
            excel.AlertBeforeOverwriting = false;
            string vx = Server.MapPath("../File/"+date );
            excel.ActiveWorkbook.SaveAs(vx, Excel.XlFileFormat.xlExcel7, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            excel.Quit();
            excel = null;
            GC.Collect();
            string SAVE_PATH = "../File/" + date;
            basec.getcoms("DELETE WAREFILE WHERE WAREID='"+Text1 .Value +"'");
            string v2 = bc.numYMD(20, 12, "000000000001", "SELECT * FROM WAREFILE", "FLKEY", "FL");
            basec.getcoms(@"INSERT INTO WAREFILE(FLKEY,WAREID,OLDFILENAME,PATH,DATE,YEAR,MONTH,DAY) VALUES 
('" + v2 + "','" + Text1.Value + "','" +date +".xls"+ "','" + SAVE_PATH +".xls"+ "','" + varDate + "','" + year + "','" + month + "','" + day + "')"); 


        }
        #region ExcelPrint
        public void ExcelPrint(DataTable dt2)
        {   
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string path = "";
            Microsoft.Office.Interop.Excel.Application application = new Microsoft.Office.Interop.Excel.Application();
            Excel.Workbook workbook;
            Excel.Worksheet worksheet;
            Page p = new Page();
            HttpServerUtility httpsu = p.Server;
            int m = dt2.Rows.Count - 1;
          
            for (i = 0; i < dt2.Rows .Count ; i++)
            {
                path = httpsu.MapPath("..//File/PrintModelForLend.xls");
                   workbook = application.Workbooks.Open(path, Type.Missing, Type.Missing,
Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);/* 13 to parameter 15 */
                    worksheet = (Excel.Worksheet)workbook.Worksheets[1];

                    application.Visible = false;/*140323 use printpreview false to true1/2*/
                    application.ExtendList = false;
                    application.DisplayAlerts = false;
                    application.AlertBeforeOverwriting = false;

                    worksheet.Cells[2, 2] = "";
                    worksheet.Cells[2, 5] = "";
                    worksheet.Cells[2, 7] = "";
                    worksheet.Cells[3, 2] = "";
                    worksheet.Cells[3, 5] = "";
                    worksheet.Cells[6, 1] = "";
                    worksheet.Cells[6, 2] = "";
                    worksheet.Cells[6, 3] = "";
                    worksheet.Cells[6, 4] = "";
                    worksheet.Cells[6, 5] = "";
                    worksheet.Cells[6, 6] = "";
                    
                    worksheet.Cells[2,2] = dt2.Rows[i]["借出单号"].ToString();
                    worksheet.Cells[2,5] = dt2.Rows[i]["单据日期"].ToString();
                    worksheet.Cells[2,7] = dt2.Rows[i]["借出员"].ToString();

                    worksheet.Cells[3, 2] = dt2.Rows[i]["客户或供应商"].ToString();
                    worksheet.Cells[3, 5] = dt2.Rows[i]["客户电话或供应商电话"].ToString();
                 

                    worksheet.Cells[6, 1] = dt2.Rows[i]["ID"].ToString();
                    worksheet.Cells[6, 2] = dt2.Rows[i]["品名"].ToString();
                    worksheet.Cells[6, 3] = dt2.Rows[i]["借出数量"].ToString();
                    worksheet.Cells[6, 4] = dt2.Rows[i]["借出日期"].ToString();
                    worksheet.Cells[6, 5] = dt2.Rows[i]["日租金"].ToString();
                    worksheet.Cells[6, 6] = dt2.Rows[i]["押金"].ToString();
                    workbook.Save();
               

            }
            application.Quit();
            worksheet = null;
            workbook = null;
            application = null;
            GC.Collect();
        }
        #endregion
        #region gridview2 delete
        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string sql;
            string sql1;
            hint.Value = "";
            string id = GridView2.DataKeys[e.RowIndex][0].ToString();
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 10, 10);
            string v1 = bc.getOnlyString("SELECT DEL FROM RIGHTLIST WHERE USID='" + n2 + "' AND NODE_NAME='借出作业'");
            if (bc.exists("SELECT LEID FROM  RETURN_EQUIPMENT_DET  WHERE LEID='" +Text1 .Value  + "'"))
            {
                hint.Value = "该单号存在于归还单中，不能删除";
            }
            else if (v1 != "Y")
            {
                hint.Value = "您无删除权限！";
            }
            else
            {
                sql1 = "DELETE FROM LEND_DET WHERE LEKEY='" + id + "'";
                if (bc.juageOne("SELECT * FROM LEND_DET WHERE LEID='" + Text1.Value + "'"))
                {
                    basec.getcoms(sql1);
                    sql = "DELETE LEND_MST WHERE LEID='" + Text1.Value + "'";
                    basec.getcoms(sql);
                    basec.getcoms("DELETE MATERE WHERE MRKEY='" + id + "'");
                    GridView2.EditIndex = -1;
                    bind();
                }
                else
                {
                    basec.getcoms(sql1);
                    GridView2.EditIndex = -1;
                    basec.getcoms("DELETE MATERE WHERE MRKEY='" + id + "'");
                    bind();
                }
                basec.getcoms("DELETE WAREFILE WHERE WAREID='"+Text1 .Value +"'");
                basec.getcoms("DELETE CASH_ADD WHERE CDID='"+Text1 .Value +"'");
                basec.getcoms("DELETE GODE WHERE GODEID='" + Text1.Value + "'");
            }
            try
            {

             

            }
            catch (Exception)
            {


            }
        }
        #endregion

        protected void btnPrint_Click(object sender, ImageClickEventArgs e)
        {
          
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 10, 10);
            string varMakerID = bc.getOnlyString("SELECT EMID FROM USERINFO WHERE USID='" + n2 + "'");
            cLEND.USID =n2;
            dt=bc.getdt(cLEND.sqlfi + " WHERE A.LEID='" + Text1.Value + "'");
            WPSS.ReportManage.CRVPrintBill.SEARCH = cLEND.ADD_COMPANYINFO(dt,"借出单");
            WPSS.ReportManage.CRVPrintBill.Array[0] = "LEND";
            Response.Redirect("../ReportManage/CRVPrintBill.aspx");
          
            try
            {
               
            }
            catch (Exception)
            {


            }


        }
   
    }
}
