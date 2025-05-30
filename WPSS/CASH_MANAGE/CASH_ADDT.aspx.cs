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

namespace WPSS.CASH_MANAGE
{
    public partial class CASH_ADDT : System.Web.UI.Page
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
        private string _CDKEY;
        public string CDKEY
        {
            set { _CDKEY = value; }
            get { return _CDKEY; }

        }

        CCASH_ADD ccash_add = new CCASH_ADD();
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
            DataTable   dtx3 =bc.getdt(ccash_add .sql +" WHERE A.CDID='"+Text1.Value +"'");
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
            Text1.Value = ccash_add.RETURN_ID();
            bind();
          
        }

        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {
            if (juage())
            {

            }
            else
            {
                string n1 = Request.Url.AbsoluteUri;
                string n2 = n1.Substring(n1.Length - 10, 10);
                string varMakerID = bc.getOnlyString("SELECT EMID FROM USERINFO WHERE USID='" + n2 + "'");
                ccash_add.EMID = varMakerID;
                DateTime date1 = Convert.ToDateTime(Text5.Value);
                ccash_add.BILL_DATE = date1.ToString("yyyy-MM-dd").Replace("/", "-");
                ccash_add.CASH = Text4.Value;
                ccash_add.CDID = Text1.Value;
                ccash_add.HANLDER_ID = Text6.Value;
                ccash_add.USER_GROUP = Text2.Value;
                ccash_add.REMARK = TextBox1.Text;
                ccash_add.save();
                IFExecution_SUCCESS = true;
                hint.Value = ccash_add.ErrowInfo;
                
              
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
  
        protected void add()
        {

            ClearText();
            Text1.Value = ccash_add.RETURN_ID();
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
       
            else if (CDKEY == "Exceed Limited")
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


  
        protected void btnExit_Click(object sender, ImageClickEventArgs e)
        {
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 16, 16);
            Response.Redirect("../cash_manage/cash_add.aspx" + n2);
        }
    }
}


