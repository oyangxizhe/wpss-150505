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
    public class CLEND
    {
        basec bc = new basec();
        #region nature
        private string _GETID;
        public string GETID
        {
            set { _GETID = value; }
            get { return _GETID; }

        }
        private string _USID;
        public string USID
        {
            set { _USID = value; }
            get { return _USID; }

        }


        private string _WAREID;
        public string WAREID
        {
            set { _WAREID = value; }
            get { return _WAREID; }

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
        DataTable dtx2 = new DataTable();
        DataTable dt = new DataTable();
        #region sql
        string setsql = @"
SELECT 
A.LEID AS LEID,
A.LEND_DATE AS LEND_DATE,
A.LEND_MAKERID AS LEND_MAKERID,
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=A.LEND_MAKERID )  AS LEND_MEMBER,
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=A.MAKERID ) AS MAKER,
A.DATE AS DATE
FROM LEND_MST A
";
        string setsqlo = @"
INSERT INTO LEND_DET
(
LEKEY,
LEID,
SN,
DAILY_RENT,
DEPOSIT,
LEND_STATUS_DET,
LEND_DATE,
REMARK,
YEAR,
MONTH,
DAY
)
VALUES
(
@LEKEY,
@LEID,
@SN,
@DAILY_RENT,
@DEPOSIT,
@LEND_STATUS_DET,
@LEND_DATE,
@REMARK,
@YEAR,
@MONTH,
@DAY

)
";
        string setsqlt = @"
INSERT INTO LEND_MST
(
LEID,
CUID,
BILL_DATE,
LEND_MAKERID,
LEND_STATUS_MST,
DATE,
MAKERID,
YEAR,
MONTH,
DAY
)
VALUES
(
@LEID,
@CUID,
@BILL_DATE,
@LEND_MAKERID,
@LEND_STATUS_MST,
@DATE,
@MAKERID,
@YEAR,
@MONTH,
@DAY
)
";
        string setsqlth = @"
UPDATE LEND_MST SET 
CUID=@CUID,
BILL_DATE=@BILL_DATE,
LEND_STATUS_MST=@LEND_STATUS_MST,
DATE=@DATE,
MAKERID=@MAKERID,
YEAR=@YEAR,
MONTH=@MONTH,
DAY=@DAY

";
        string setsqlf = @"
INSERT INTO MATERE
(
MRKEY,
MATEREID,
SN,
WAREID,
MRCOUNT,
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
@MRKEY,
@MATEREID,
@SN,
@WAREID,
@MRCOUNT,
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
A.LEKEY AS 索引,
A.LEID AS 借出单号, 
A.SN AS 项次,
A.DAILY_RENT AS 日租金,
A.DEPOSIT AS 押金,
CASE WHEN A.LEND_STATUS_DET='OPEN' THEN '开立'
WHEN A.LEND_STATUS_DET='PROGRESS' THEN '部分归还'
ELSE '已归还'
END AS 状态,
A.LEND_DATE AS 借出日期,
C.WAREID AS ID,
D.CO_WAREID AS 料号,
D.WNAME AS 品名,
D.SPEC AS 规格,
D.UNIT AS 库存单位,
D.CWAREID AS 客户料号,
C.MRCOUNT AS 借出数量,

CASE WHEN E.CUID IS NOT NULL THEN E.CUID  
ELSE J.SUID  
END 
AS 客户ID或供应商ID,
CASE WHEN E.CNAME IS NOT NULL THEN E.CNAME 
ELSE J.SNAME 
END 
AS 客户或供应商,
CASE WHEN K.PHONE IS NOT NULL THEN K.Phone 
ELSE L.Phone  
END 
AS 客户电话或供应商电话,
F.BILL_DATE AS 单据日期,
F.LEND_MAKERID AS 借出员工号,
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=F.LEND_MAKERID )  AS 借出员,
F.MAKERID AS 制单人工号,
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=F.MAKERID )  AS 制单人,
F.DATE AS 制单日期,
H.STORAGENAME AS 仓库,
C.BATCHID AS 批号,
A.REMARK AS 备注
FROM LEND_DET A 
LEFT JOIN MATERE C ON A.LEKEY=C.MRKEY
LEFT JOIN WAREINFO D ON C.WAREID=D.WAREID
LEFT JOIN LEND_MST F ON A.LEID=F.LEID
LEFT JOIN CUSTOMERINFO_MST E ON F.CUID=E.CUID
LEFT JOIN STORAGEINFO H ON H.STORAGEID=C.STORAGEID
LEFT JOIN SUPPLIERINFO_MST J ON D.CUID=J.SUID
LEFT JOIN CustomerInfo_DET K ON E.CUKEY =K.CUKEY 
LEFT JOIN SupplierInfo_DET L ON J.SUKEY =L.SUKEY 


";
        #endregion
        int i, j;
        public CLEND()
        {
            string year, month, day;
            year = DateTime.Now.ToString("yy");
            month = DateTime.Now.ToString("MM");
            day = DateTime.Now.ToString("dd");
            GETID = bc.numYM(10, 4, "0001", "SELECT * FROM LEND_MST", "LEID", "LE");

            sql = setsql;
            sqlo = setsqlo;
            sqlt = setsqlt;
            sqlth = setsqlth;
            sqlf = setsqlf;
            sqlfi = setsqlfi;
        }
        #region ask
        public DataTable ask(string LEID)
        {
            string sql1 = sqlo;
            DataTable dtt = bc.getdt(sqlfi + " WHERE A.LEID='" + LEID + "' ORDER BY A.LEKEY ASC");
            return dtt;
        }
        #endregion
        #region GET_TOTAL_LEND
        public DataTable GET_TOTAL_LEND()
        {
            DataTable dtt = new DataTable();
            dtt.Columns.Add("索引", typeof(string));
            dtt.Columns.Add("借出单号", typeof(string));
            dtt.Columns.Add("项次", typeof(string));
            dtt.Columns.Add("ID", typeof(string));
            dtt.Columns.Add("料号", typeof(string));
            dtt.Columns.Add("品名", typeof(string));
            dtt.Columns.Add("规格", typeof(string));
            dtt.Columns.Add("客户料号", typeof(string));
            dtt.Columns.Add("借出单数量", typeof(decimal));
            dtt.Columns.Add("累计归还数量", typeof(decimal));
            dtt.Columns.Add("借出单未结数量", typeof(decimal), "借出单数量-累计归还数量");
            dtt.Columns.Add("状态", typeof(string));
          

            DataTable dtx1 = bc.getdt(this .sqlfi );
            if (dtx1.Rows.Count > 0)
            {
                for (i = 0; i < dtx1.Rows.Count; i++)
                {
                    DataRow dr = dtt.NewRow();
                    dr["索引"] = dtx1.Rows[i]["索引"].ToString();
                    dr["借出单号"] = dtx1.Rows[i]["借出单号"].ToString();
                    dr["项次"] = dtx1.Rows[i]["项次"].ToString();
                    dr["ID"] = dtx1.Rows[i]["ID"].ToString();
                    dr["借出单数量"] = dtx1.Rows[i]["借出数量"].ToString();
                    dtx2 = bc.getdt("select * from wareinfo where wareid='" + dtx1.Rows[i]["ID"].ToString() + "'");
                    dr["料号"] = dtx2.Rows[0]["CO_WAREID"].ToString();
                    dr["品名"] = dtx2.Rows[0]["WNAME"].ToString();
                    dr["规格"] = dtx2.Rows[0]["SPEC"].ToString();
                    dr["客户料号"] = dtx2.Rows[0]["CWAREID"].ToString();
                  
                    dr["累计归还数量"] = 0;
             
                   
                    if (dtx1.Rows[i]["状态"].ToString() == "OPEN")
                    {
                        dr["状态"] = "OPEN";
                    }
                    else if (dtx1.Rows[i]["状态"].ToString() == "PROGRESS")
                    {
                        dr["状态"] = "部分归还";
                    }
                    else if (dtx1.Rows[i]["状态"].ToString() == "DELAY")
                    {
                        dr["状态"] = "DELAY";
                    }
                    else
                    {
                        dr["状态"] = "已归还";
                    }

                    dtt.Rows.Add(dr);
                }

            }

            DataTable dtx4 = bc.getdt(@"
SELECT
A.LEID AS LEID,
A.SN AS SN,
B.WAREID AS WAREID,
SUM(B.GECOUNT) AS GECOUNT 
FROM RETURN_EQUIPMENT_DET A 
LEFT JOIN GODE B ON A.EQKEY=B.GEKEY 
GROUP BY A.LEID,A.SN,B.WAREID
");
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


            return dtt;
        }
        #endregion
        #region UPDATE_LEND_STATUS
        public void UPDATE_LEND_STATUS(string LEID)
        {
            DataView dv = new DataView(GET_TOTAL_LEND());
            dv.RowFilter = "借出单号='" + LEID + "'";
            DataTable dt = dv.ToTable();
            if (dt.Rows.Count > 0)
            {

                foreach (DataRow dr in dt.Rows)
                {
                    decimal d0 = decimal.Parse(dr["借出单数量"].ToString());
                    decimal d1 = decimal.Parse(dr["累计归还数量"].ToString());
                 

                    if (decimal.Parse(dr["借出单未结数量"].ToString()) == 0)
                    {
                        basec.getcoms("UPDATE LEND_DET SET LEND_STATUS_DET='CLOSE' WHERE LEID='" + LEID + "' AND SN='" + dr["项次"].ToString() + "'");
                    }
                    else
                    {
                        basec.getcoms("UPDATE LEND_DET SET LEND_STATUS_DET='OPEN' WHERE LEID='" + LEID + "' AND SN='" + dr["项次"].ToString() + "'");
                    }
                }
                if (bc.JuageLENDStatus(LEID))
                {
                    basec.getcoms("UPDATE LEND_MST SET LEND_STATUS_MST='CLOSE' WHERE LEID='" + LEID + "'");

                }
           
                else if (JUAGE_REALTY_IFHAVE_RETURN_EQUIPMENTCOUNT(LEID))
                {

                    basec.getcoms("UPDATE LEND_MST SET LEND_STATUS_MST='PROGRESS' WHERE LEID='" + LEID + "'");
                }
                else
                {
                    basec.getcoms("UPDATE LEND_MST SET LEND_STATUS_MST='OPEN' WHERE LEID='" + LEID + "'");

                }
            }
        }
        #endregion
        #region JUAGE_REALTY_IFHAVE_RETURN_EQUIPMENTCOUNT
        public bool JUAGE_REALTY_IFHAVE_RETURN_EQUIPMENTCOUNT(string LEID)
        {
            bool b = false;
            DataView dv = new DataView(GET_TOTAL_LEND());
            dv.RowFilter = "借出单号='" + LEID + "'";
            DataTable dt = dv.ToTable();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {

                    decimal d1 = decimal.Parse(dr["累计归还数量"].ToString());
                
                    if (d1> 0)
                    {
                        b = true;
                        break;
                    }

                }
            }
            return b;
        }
        #endregion
        #region GET_LEND_COUNT_TALBE
        public DataTable GET_LEND_COUNT_TALBE(string LEID)
        {
      
            DataTable dtx1 = bc.getdt(@"
SELECT
A.LEKEY AS LEKEY,
A.LEID AS LEID,
A.SN AS SN,
B.WAREID AS WAREID,
B.MRCOUNT AS MRCOUNT 
FROM LEND_DET A LEFT JOIN MATERE B ON A.LEKEY=B.MRKEY WHERE A.LEID='"+LEID +"'");

            return dtx1;
        }
        #endregion

        #region ADD_COMPANYINFO
        public DataTable ADD_COMPANYINFO(DataTable dt,string BILLNAME)
        {

            DataTable dtt = this.RETURN_DT();
            DataTable dtx=bc.getdt(@"
SELECT 
CONAME 
FROM COMPANYINFO_MST
WHERE MAKERID IN (SELECT EMID FROM USERINFO A WHERE USER_GROUP IN (SELECT USER_GROUP FROM USERINFO WHERE USID='" + USID + "'))");
            if (dtx.Rows.Count > 0)
            {
                foreach (DataRow dr1 in dt.Rows)
                {
                    if (BILLNAME == "借出单")
                    {
                        DataRow dr = dtt.NewRow();
                        dr["公司名称"] = dtx.Rows[0]["CONAME"].ToString();
                        dr["借出单号"] = dr1["借出单号"].ToString();
                        dr["ID"] = dr1["ID"].ToString();
                        dr["品名"] = dr1["品名"].ToString();
                        dr["借出数量"] = dr1["借出数量"].ToString();
                        dr["借出日期"] = dr1["借出日期"].ToString();
                        dr["单据日期"] = dr1["单据日期"].ToString();
                        dr["借出员"] = dr1["借出员"].ToString();
                        dr["日租金"] = dr1["日租金"].ToString();
                        dr["押金"] = dr1["押金"].ToString();
                        dr["客户名称"] = dr1["客户或供应商"].ToString();
                        dr["客户电话或供应商电话"] = dr1["客户电话或供应商电话"].ToString();
                        dtt.Rows.Add(dr);
                    }
                    else
                    {
                        DataRow dr = dtt.NewRow();
                        dr["公司名称"] = dtx.Rows[0]["CONAME"].ToString();
                        dr["借出单号"] = dr1["借出单号"].ToString();
                        dr["归还单号"] = dr1["归还单号"].ToString();
                        dr["ID"] = dr1["ID"].ToString();
                        dr["品名"] = dr1["品名"].ToString();
                        dr["归还数量"] = dr1["归还数量"].ToString();
                        dr["借出日期"] = dr1["借出日期"].ToString();
                        dr["单据日期"] = dr1["单据日期"].ToString();
                        dr["归还员"] = dr1["归还人"].ToString();
                        dr["日租金"] = dr1["日租金"].ToString();
                        dr["押金"] = dr1["押金"].ToString();
                        dr["客户名称"] = dr1["客户或供应商"].ToString();
                        dr["客户电话或供应商电话"] = dr1["客户电话或供应商电话"].ToString();
                        dr["租赁天数"] = dr1["租赁天数"].ToString();
                        dr["归还日期"] = dr1["归还日期"].ToString();
                        decimal d1 = decimal.Parse(dr1["租金"].ToString());
                        decimal d2 = decimal.Parse(dr1["退还押金"].ToString());
                        dr["租金"] = d1.ToString("0.00");
                        dr["退还押金"] = d2.ToString("0.00");
                        dtt.Rows.Add(dr);

                    }

                }

            }

            return dtt;
        }
        #endregion

        #region RETURN_DT
        public DataTable RETURN_DT()
        {
            DataTable dtt = new DataTable();
            dtt.Columns.Add("索引", typeof(string));
            dtt.Columns.Add("项次", typeof(string));
            dtt.Columns.Add("ID", typeof(string));
            dtt.Columns.Add("料号", typeof(string));
            dtt.Columns.Add("品名", typeof(string));
            dtt.Columns.Add("规格", typeof(string));
            dtt.Columns.Add("客户料号", typeof(string));
            dtt.Columns.Add("借出数量", typeof(decimal));
            dtt.Columns.Add("累计归还数量", typeof(decimal));
            dtt.Columns.Add("借出单未结数量", typeof(decimal));
            dtt.Columns.Add("状态", typeof(string));
            dtt.Columns.Add("借出单号", typeof(string));
            dtt.Columns.Add("借出日期", typeof(string));
            dtt.Columns.Add("公司名称", typeof(string));
            dtt.Columns.Add("单据日期", typeof(string));
            dtt.Columns.Add("借出员", typeof(string));
            dtt.Columns.Add("日租金", typeof(string));
            dtt.Columns.Add("押金", typeof(string));
            dtt.Columns.Add("客户电话或供应商电话", typeof(string));
            dtt.Columns.Add("客户名称", typeof(string));

            dtt.Columns.Add("归还单号", typeof(string));
            dtt.Columns.Add("归还日期", typeof(string));
            dtt.Columns.Add("租赁天数", typeof(string));
            dtt.Columns.Add("归还数量", typeof(string));
            dtt.Columns.Add("归还员", typeof(string));
            dtt.Columns.Add("租金", typeof(string));
            dtt.Columns.Add("退还押金", typeof(string));
            return dtt;
        }
        #endregion
    }
}
