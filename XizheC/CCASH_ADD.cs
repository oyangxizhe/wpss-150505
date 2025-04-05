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

namespace XizheC
{
    public class CCASH_ADD
    {
        basec bc = new basec();

        #region nature
        private string _GETID;
        public string GETID
        {
            set { _GETID = value; }
            get { return _GETID; }

        }
        private string _WAREID;
        public string WAREID
        {
            set { _WAREID = value; }
            get { return _WAREID; }

        }
        private string _EMID;
        public string EMID
        {
            set { _EMID = value; }
            get { return _EMID; }

        }
        private string _SKU;
        public string SKU
        {
            set { _SKU = value; }
            get { return _SKU; }

        }
        private string _sql;
        public string sql
        {
            set { _sql = value; }
            get { return _sql; }

        }
        private string _sqlo;
        public string sqlo
        {
            set { _sqlo = value; }
            get { return _sqlo; }

        }
        private string _sqlt;
        public string sqlt
        {
            set { _sqlt = value; }
            get { return _sqlt; }

        }
        private string _sqlth;
        public string sqlth
        {
            set { _sqlth = value; }
            get { return _sqlth; }

        }
        private string _sqlf;
        public string sqlf
        {
            set { _sqlf = value; }
            get { return _sqlf; }

        }
        private string _CDKEY;
        public string CDKEY
        {
            set { _CDKEY = value; }
            get { return _CDKEY; }

        }
        private string _sqlfi;
        public string sqlfi
        {
            set { _sqlfi = value; }
            get { return _sqlfi; }

        }
        private string _MAKERID;
        public string MAKERID
        {
            set { _MAKERID = value; }
            get { return _MAKERID; }

        }
        private string _HANLDER_ID;
        public string HANLDER_ID
        {
            set { _HANLDER_ID = value; }
            get { return _HANLDER_ID; }

        }
        private static bool _IFExecutionSUCCESS;
        public static bool IFExecution_SUCCESS
        {
            set { _IFExecutionSUCCESS = value; }
            get { return _IFExecutionSUCCESS; }

        }
        private string _ErrowInfo;
        public string ErrowInfo
        {

            set { _ErrowInfo = value; }
            get { return _ErrowInfo; }

        }
        private string _BILL_DATE;
        public string BILL_DATE
        {
            set { _BILL_DATE = value; }
            get { return _BILL_DATE; }

        }

        private string _WP_COUNT;
        public string WP_COUNT
        {
            set { _WP_COUNT = value; }
            get { return _WP_COUNT; }
        }
        private string _CDID;
        public string CDID
        {
            set { _CDID = value; }
            get { return _CDID; }

        }
        private string _USER_GROUP;
        public string USER_GROUP
        {
            set { _USER_GROUP = value; }
            get { return _USER_GROUP; }

        }
        private string _CASH;
        public string CASH
        {
            set { _CASH = value; }
            get { return _CASH; }

        }
        private string _REMARK;
        public string REMARK
        {
            set { _REMARK = value; }
            get { return _REMARK; }

        }

        #endregion

        #region sql
        string setsql = @"
SELECT 
A.CDID AS CDID,
A.BILL_DATE AS BILL_DATE,
A.HANDLER_ID AS HANDLER_ID,
A.REMARK AS REMARK,
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=B.MAKERID ) AS MAKER,
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=A.HANDLER_ID ) AS HANDLER,
B.USER_GROUP AS USER_GROUP,
B.CASH,
B.MAKERID,
B.DATE
FROM CASH_ADD A 
LEFT JOIN GODE B ON A.CDKEY=B.GEKEY
";
        string setsqlo = @"
INSERT INTO 
CASH_ADD
(
CDKEY,
CDID,
HANDLER_ID,
BILL_DATE,
REMARK,
YEAR,
MONTH,
DAY
)
VALUES
(
@CDKEY,
@CDID,
@HANDLER_ID,
@BILL_DATE,
@REMARK,
@YEAR,
@MONTH,
@DAY
)
";
        string setsqlt = @"

";
        string setsqlth = @"
UPDATE CASH_ADD SET 
BILL_DATE=@BILL_DATE,
HANDLER_ID=@HANDLER_ID,
REMARK=@REMARK,
YEAR=@YEAR,
MONTH=@MONTH,
DAY=@DAY

";
        string setsqlf = @"
INSERT INTO GODE
(
GEKEY,
GODEID,
USER_GROUP,
CASH,
DATE,
DEBIT_MAKERID,
MAKERID,
YEAR,
MONTH,
DAY
)
VALUES
(
@GEKEY,
@GODEID,
@USER_GROUP,
@CASH,
@DATE,
@DEBIT_MAKERID,
@MAKERID,
@YEAR,
@MONTH,
@DAY
)
";
        string setsqlfi = @"
UPDATE GODE SET 
USER_GROUP=@USER_GROUP,
CASH=@CASH


";
        #endregion
        public CCASH_ADD()
        {
            string year, month, day;
            year = DateTime.Now.ToString("yy");
            month = DateTime.Now.ToString("MM");
            day = DateTime.Now.ToString("dd");
        
            sql = setsql;
            sqlo = setsqlo;
            sqlt = setsqlt;
            sqlth = setsqlth;
            sqlf = setsqlf;
            sqlfi = setsqlfi;
        }
        #region ask
        public DataTable ask(string CDID)
        {
            string sql1 = sqlo;
            DataTable dtt = bc.getdt(sqlfi + " WHERE A.CDID='" + CDID + "' ORDER BY A.CDKEY ASC");
            return dtt;
        }
        #endregion
        #region RETURN_ID
        public string RETURN_ID()
        {
            string ID = "";
            string var1 = bc.numYM(10, 4, "0001", "SELECT * FROM CASH_ADD", "CDID", "CD");
            if (var1 == "Exceed Limited")
            {

                ErrowInfo = "编码超出限制！";
            }
            else
            {
                ID = var1;
            }
            return ID;
        }
        #endregion

        #region save
        public  void save()
        {

        
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss").Replace ("/","-");
          
            string v2;
            v2 = bc.getOnlyString("SELECT USER_GROUP FROM GODE WHERE  GODEID='" +CDID + "'");
            CDKEY = bc.numYMD(20, 12, "000000000001", "select * from CASH_ADD", "CDKEY", "CD");
            if (!bc.exists("SELECT CDID FROM CASH_ADD WHERE CDID='" +CDID  + "'"))
            {

                SQlcommandE(sqlo);
                SQlcommandE(sqlf, CDKEY);
                IFExecution_SUCCESS = true;
            }
            else if (bc.JuageDeleteCASH_MoreThanStorageCASH(CDID ,USER_GROUP ))
            {
                ErrowInfo  = bc.ErrowInfo;

            }
            else
            {
                SQlcommandE(sqlth + " WHERE CDID='" + CDID  + "'");
                SQlcommandE(sqlfi + " WHERE GODEID='" +CDID  + "'", CDKEY);
                IFExecution_SUCCESS = true;
            }
        }
        #endregion
        #region SQlcommandE
        protected void SQlcommandE(string sql)
        {
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss");
        
            SqlConnection sqlcon = bc.getcon();
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            sqlcom.Parameters.Add("@CDKEY", SqlDbType.VarChar, 20).Value = CDKEY;
            sqlcom.Parameters.Add("@CDID", SqlDbType.VarChar, 20).Value = CDID;
            sqlcom.Parameters.Add("@HANDLER_ID", SqlDbType.VarChar, 20).Value = HANLDER_ID;
            sqlcom.Parameters.Add("@BILL_DATE", SqlDbType.VarChar, 20).Value = BILL_DATE;
            sqlcom.Parameters.Add("@REMARK", SqlDbType.VarChar, 1000).Value = REMARK;
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
          

            SqlConnection sqlcon = bc.getcon();
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            sqlcom.Parameters.Add("@GEKEY", SqlDbType.VarChar, 20).Value = GEKEY;
            sqlcom.Parameters.Add("@GODEID", SqlDbType.VarChar, 20).Value =CDID ;
            sqlcom.Parameters.Add("@USER_GROUP", SqlDbType.VarChar, 20).Value =USER_GROUP ;
            sqlcom.Parameters.Add("@CASH", SqlDbType.VarChar, 20).Value = CASH ;
            sqlcom.Parameters.Add("@DATE", SqlDbType.VarChar, 20).Value = varDate;
            sqlcom.Parameters.Add("@DEBIT_MAKERID", SqlDbType.VarChar, 20).Value =EMID ;
            sqlcom.Parameters.Add("@MAKERID", SqlDbType.VarChar, 20).Value = EMID;
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
