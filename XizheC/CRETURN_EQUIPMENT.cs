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
    public class CRETURN_EQUIPMENT
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
        private string _sqlsi;
        public string sqlsi
        {
            set { _sqlsi = value; }
            get { return _sqlsi; }

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
A.EQID AS EQID,
A.EQUIPMENT_DATE AS EQUIPMENT_DATE,
A.EQUIPMENT_MAKERID AS EQUIPMENT_MAKERID,
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=A.EQUIPMENT_MAKERID )  AS EQUIPMENT_MEMBER,
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=A.MAKERID ) AS MAKER,
A.DATE AS DATE
FROM RETURN_EQUIPMENT_MST A
";
        string setsqlo = @"
INSERT INTO 
RETURN_EQUIPMENT_DET
(
EQKEY,
EQID,
LEID,
SN,
EQUIPMENT_DATE,
LEASE_DAYS,
REMARK,
YEAR,
MONTH,
DAY
)
VALUES
(
@EQKEY,
@EQID,
@LEID,
@SN,
@EQUIPMENT_DATE,
@LEASE_DAYS,
@REMARK,
@YEAR,
@MONTH,
@DAY
)
";
        string setsqlt = @"
INSERT INTO 
RETURN_EQUIPMENT_MST
(
EQID,
BILL_DATE,
EQUIPMENT_MAKERID,
DATE,
MAKERID,
YEAR,
MONTH,
DAY
)
VALUES
(
@EQID,
@BILL_DATE,
@EQUIPMENT_MAKERID,
@DATE,
@MAKERID,
@YEAR,
@MONTH,
@DAY
)
";
        string setsqlth = @"
UPDATE RETURN_EQUIPMENT_MST SET 
BILL_DATE=@BILL_DATE,
EQUIPMENT_MAKERID=@EQUIPMENT_MAKERID,
DATE=@DATE,
MAKERID=@MAKERID,
YEAR=@YEAR,
MONTH=@MONTH,
DAY=@DAY

";
        string setsqlf = @"
INSERT INTO GODE
(
GEKEY,
GODEID,
SN,
WAREID,
GECOUNT,
STORAGEID,
BATCHID,
DATE,
MAKERID,
YEAR,
MONTH,
DAY
)
VALUES
(
@GEKEY,
@GODEID,
@SN,
@WAREID,
@GECOUNT,
@STORAGEID,
@BATCHID,
@DATE,
@MAKERID,
@YEAR,
@MONTH,
@DAY
)
";
        string setsqlfi = @"


SELECT 
A.EQKEY AS 索引,
A.EQID AS 归还单号, 
A.SN AS 项次,
A.EQUIPMENT_DATE AS 归还日期,
A.REMARK AS 备注,
A.LEASE_DAYS AS 租赁天数,
C.WAREID AS ID,
D.CO_WAREID AS 料号,
D.WNAME AS 品名,
D.SPEC AS 规格,
D.CWAREID AS 客户料号,
D.UNIT AS 单位,
C.GECOUNT AS 归还数量,
CASE WHEN E.CUID IS NOT NULL THEN E.CUID  
ELSE J.SUID  
END 
AS 客户ID或供应商ID,
CASE WHEN E.CNAME IS NOT NULL THEN E.CNAME 
ELSE J.SNAME 
END 
AS 客户或供应商,
CASE WHEN M.PHONE IS NOT NULL THEN M.Phone 
ELSE N.Phone  
END 
AS 客户电话或供应商电话,
F.BILL_DATE AS 单据日期,
F.EQUIPMENT_MAKERID AS 归还人工号,
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=F.EQUIPMENT_MAKERID )  AS 归还人,
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=F.MAKERID )  AS 制单人,
F.DATE AS 制单日期,
H.STORAGENAME AS 仓库,
C.BATCHID AS 批号,
K.LEND_DATE AS 借出日期,
K.DAILY_RENT AS 日租金,
K.DEPOSIT AS 押金,
K.DAILY_RENT*C.GECOUNT*A.LEASE_DAYS AS 租金,
K.DEPOSIT-K.DAILY_RENT*C.GECOUNT*A.LEASE_DAYS AS 退还押金,
CASE WHEN K.LEND_STATUS_DET='OPEN' THEN '开立'
WHEN K.LEND_STATUS_DET='PROGRESS' THEN '部分归还'
ELSE '已归还'
END AS 状态,
L.LEID AS 借出单号
FROM RETURN_EQUIPMENT_DET A 
LEFT JOIN GODE  C ON A.EQKEY=C.GEKEY
LEFT JOIN WAREINFO D ON C.WAREID=D.WAREID
LEFT JOIN RETURN_EQUIPMENT_MST F ON A.EQID=F.EQID
LEFT JOIN STORAGEINFO H ON H.STORAGEID=C.STORAGEID
LEFT JOIN SUPPLIERINFO_MST J ON D.CUID=J.SUID
LEFT JOIN LEND_DET K ON A.LEID=K.LEID AND A.SN=K.SN
LEFT JOIN LEND_MST L ON L.LEID =K.LEID 
LEFT JOIN CUSTOMERINFO_MST E ON L.CUID=E.CUID
LEFT JOIN CustomerInfo_DET M ON E.CUKEY =M.CUKEY 
LEFT JOIN SupplierInfo_DET N ON J.SUKEY =N.SUKEY 
";
        string setsqlsi = @"
       
INSERT INTO MATERE
(
MRKEY,
MATEREID,
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
@MRKEY,
@MATEREID,
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
        #endregion
        public CRETURN_EQUIPMENT()
        {
            string year, month, day;
            year = DateTime.Now.ToString("yy");
            month = DateTime.Now.ToString("MM");
            day = DateTime.Now.ToString("dd");
            GETID = bc.numYM(10, 4, "0001", "SELECT * FROM RETURN_EQUIPMENT_MST", "EQID", "EQ");
            sql = setsql;
            sqlo = setsqlo;
            sqlt = setsqlt;
            sqlth = setsqlth;
            sqlf = setsqlf;
            sqlfi = setsqlfi;
            sqlsi = setsqlsi;
        }
        #region ask
        public DataTable ask(string EQID)
        {
            string sql1 = sqlo;
            DataTable dtt = bc.getdt(sqlfi + " WHERE A.EQID='" + EQID + "' ORDER BY A.EQKEY ASC");
            return dtt;
        }
        #endregion
        #region  JUAGE_CURRENT_STORAGECOUNT_IF_LESSTHAN_DELETE_COUNT
        public bool JUAGE_CURRENT_STORAGECOUNT_IF_LESSTHAN_DELETE_COUNT(string EQID)
        {
            bool b = false;
            DataTable dt = bc.getdt(sqlfi  + " WHERE A.EQID='" + EQID + "'");
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    WAREID  = dr["ID"].ToString();
                    SKU = dr["库存单位"].ToString();
                    decimal d= decimal.Parse(dr["归还数量"].ToString());
                    decimal d1 = 0;
                    DataView dv = new DataView(bc.getstoragecount());
                    dv.RowFilter = "品号='" + WAREID  + "' AND 库存单位='" + SKU + "'";
                    DataTable dtx = dv.ToTable();
                    if (dtx.Rows.Count > 0)
                    {
                        d1 = decimal.Parse(dtx.Rows[0]["库存数量"].ToString());
                        if (d1 < d)
                        {
                            b = true;
                            ErrowInfo = "品号ID："+WAREID +" 库存数量：" + d1.ToString("#0.00") 
                                +"小于该品号要删除的归还数量：" + d.ToString("0.00") + "，不允许编辑或删除该单据";
                            break;
                        }
                    }
                    else
                    {

                        b = true;
                        ErrowInfo = "品号："+WAREID +" 库存数量为0："+"不允许编辑或删除该单据";
                        break;
                    }
                }
            }
            return b;
        }
        #endregion
        #region GET_LEASE_DAYS
        public int  GET_LEASE_DAYS(string LEND_DATE,string EQUIPMENT_DATE)
        {
          
            DateTime d1 = Convert.ToDateTime(LEND_DATE);
            DateTime d2 = Convert.ToDateTime(EQUIPMENT_DATE);
            int daycount = Convert.ToInt32((d2 - d1).Days);

            string Hour = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").Substring(11, 2);
            string minite = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").Substring(14, 2);
            if (Convert.ToInt32(Hour) >= 12)
            {
                if (Convert.ToInt32(minite) >= 1)
                {

                    daycount = daycount + 1;
                }
            }
            return daycount  ;
        }
        #endregion
       
    }
}
