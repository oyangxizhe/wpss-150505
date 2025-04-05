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
    public class CCASH
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
        private string _WP_COUNT;
        public string WP_COUNT
        {
            set { _WP_COUNT = value; }
            get { return _WP_COUNT; }
        }
        #endregion

        #region sql
        string setsql = @"
SELECT 
A.CSID AS CSID,
A.BILL_DATE AS BILL_DATE,
A.HANDLER_ID AS HANDLER_ID,
A.REMARK AS REMARK,
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=B.MAKERID ) AS MAKER,
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=A.HANDLER_ID ) AS HANDLER,
B.CASH,
B.USER_GROUP AS USER_GROUP,
B.MAKERID,
B.DATE
FROM CASH A 
LEFT JOIN GODE B ON A.CSKEY=B.GEKEY
";
        string setsqlo = @"
INSERT INTO 
CASH
(
CSKEY,
CSID,
HANDLER_ID,
BILL_DATE,
REMARK,
YEAR,
MONTH,
DAY
)
VALUES
(
@CSKEY,
@CSID,
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
UPDATE CASH SET 
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
        public CCASH()
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
        public DataTable ask(string CSID)
        {
            string sql1 = sqlo;
            DataTable dtt = bc.getdt(sqlfi + " WHERE A.CSID='" + CSID + "' ORDER BY A.CSKEY ASC");
            return dtt;
        }
        #endregion
 
       
    }
}
