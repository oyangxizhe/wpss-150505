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
using System.Net;
using System.Text;
using XizheC;
using System.IO;
using System.Diagnostics;

namespace WPSS.PurchaseManage
{
    public partial class PurchaseSearch : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dtx2 = new DataTable();
        DataTable dtx4 = new DataTable();
        basec bc = new basec();
        CPURCHASE cpurchase = new CPURCHASE();
        CREQUEST_MONEY crequest_money = new CREQUEST_MONEY();
        int i, j;

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

        string sqlth = @"
SELECT 
A.PUID AS PUID,
A.SN AS SN,
B.WAREID AS WAREID,
D.PCount AS PCOUNT,
D.PurchaseUnitPrice AS PURCHASEUNITPRICE,
D.TAXRATE AS TAXRATE,
C.STORAGENAME AS STORAGENAME,
B.BATCHID AS BATCHID,
SUM(B.MRCount) AS MRCOUNT 
FROM RETURN_DET A 
LEFT JOIN MateRe  B ON A.REKEY=B.MRKEY
LEFT JOIN STORAGEINFO C ON B.STORAGEID=C.STORAGEID
LEFT JOIN Purchase_DET D ON D.PUID=A.PUID AND D.SN=A.SN 

";
        string sqlf = @"
GROUP BY 
A.PUID,
A.SN,
B.WAREID,
D.PCOUNT,
D.PurchaseUnitPrice,
D.TAXRATE,
C.STORAGENAME,
B.BATCHID
";
        protected string M_str_sql = @" 
SELECT 
A.PGKEY AS 索引,
A.PUID AS 采购单号,
A.PGID AS 入库单号,
A.SN AS 项次,
E.WAREID AS ID,
B.CO_WAREID AS 料号,
B.WNAME AS 品名,
B.CWAREID AS 客户料号,
C.PCOUNT AS 采购数量,
C.PURCHASEUNITPRICE AS 采购单价,
C.TAXRATE AS 税率,
E.GECOUNT AS 入库数量 ,
C.PURCHASEUNITPRICE*E.GECOUNT AS 未税金额,
C.PURCHASEUNITPRICE*E.GECOUNT*C.TAXRATE/100 AS 税额,
C.PURCHASEUNITPRICE*E.GECOUNT*(1+C.TAXRATE/100) AS 含税金额,
C.SUID AS 供应商代码,
D.SNAME AS 供应商名称,
F.PDATE AS 采购日期,
F.DATE AS 采购制单日期,
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=F.PURID ) AS  采购员,G.GODEDATE AS 入库日期,
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=G.GODERID ) AS 入库员,G.DATE AS 入库制单日期,
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=E.MAKERID )  AS 入库制单人 FROM PURCHASEGODE_DET A 
LEFT JOIN PURCHASE_DET C ON A.PUID=C.PUID AND A.SN=C.SN
LEFT JOIN SUPPLIERINFO_MST D ON C.SUID=D.SUID
LEFT JOIN GODE E ON A.PGKEY=E.GEKEY
LEFT JOIN WAREINFO B ON E.WAREID=B.WAREID
LEFT JOIN PURCHASE_MST F ON F.PUID=C.PUID
LEFT JOIN PURCHASEGODE_MST G ON A.PGID=G.PGID
";/*detail*/
        protected string M_str_sql1;
        WPSS.Validate va = new Validate();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (va.returnb() == true)
                Response.Redirect("\\Default.aspx");
          

        }
        #region bind()
        private void bind()
        {
            hint.Value = "";
            x.Value = "";
            x1.Value = "";
            GridView1.AllowPaging = true;
            GridView1.PageSize = 10;
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 10, 10);
            if (Request.QueryString["emid"] != null)
            {


                EMID = Request.QueryString["EMID"].ToString();
                select();

            }
            else
            {
                string varMakerID = bc.getOnlyString("SELECT EMID FROM USERINFO WHERE USID='" + n2 + "'");
                EMID = varMakerID;
                select();

            }
            select();
       
            try
            {
            
              
            }
            catch (Exception)
            {

            }
        }
        #endregion
        #region select()
        protected void select()
        {

            string v6 = "", v7 = "";
            string v1 = Text1.Value;
            string v2 = StartDate.Value;
            string v3 = EndDate.Value;
            string v9 = Text2.Value;
            string v10 = Text3.Value;
            string v11 = DropDownList1.Text;
            string v12 = Text4.Value;
            if (!bc.juagedate(v2, v3))
            {
                hint.Value = bc.ErrowInfo;
                clear();
                return;
            }
            if (v2 != "" && v3 != "")
            {
                DateTime v4 = Convert.ToDateTime(v2);
                DateTime v5 = Convert.ToDateTime(v3);
                v6 = v4.ToString("yyyy-MM-dd") + " 00:00:00";
                v7 = v5.ToString("yyyy-MM-dd") + " 23:59:59";

            }
            if (CheckBox1.Checked)
            {
                showdata(@" where    D.SNAME like '%" + v1 + "%' AND B.CWAREID like '%" + v10 +
                    "%'  AND F.DATE BETWEEN  '" + v6 + "'AND '" + v7 + "' AND B.WNAME like '%" + v9 +
                    "%' AND A.PUID LIKE '%" + v12 + "%'");
            }

            else
            {
                showdata(@" where    D.SNAME like '%" + v1 + "%' AND B.CWAREID like '%" + v10 +
              "%'  AND B.WNAME like '%" + v9 + "%' AND A.PUID LIKE '%" + v12 + "%'");
            }

        }
        #endregion
        private void clear()
        {

            dt = null;
            GridView1.DataSource = dt;
            GridView1.DataBind();
            Text1.Value = "";
            Text2.Value = "";
            Text3.Value = "";

        }
        #region showdata
        protected void showdata(string sqlo)
        {
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 10, 10);
            string sqlth = "";
            //string sqlt = " ORDER BY A.DATE DESC";
            string sqlf = "";

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
                sqlth = @" AND F.MAKERID IN (SELECT EMID FROM USERINFO A WHERE USER_GROUP IN 
 (SELECT USER_GROUP FROM USERINFO WHERE USID='" + USID + "'))";

            }
            else
            {

                sqlth = " AND F.MAKERID='" + EMID + "'";

            }
            if (DropDownList1.Text == "已入库")
            {
                
                sqlf = " AND F.PurchaseStatus_MST='CLOSE'";

            }
            else if (DropDownList1.Text == "部分入库")
            {

                
                sqlf = " AND F.PurchaseStatus_MST='PROGRESS'";
            }
            else if (DropDownList1.Text == "Delay")
            {

                
                sqlf = " AND F.PurchaseStatus_MST='DELAY'";
            }
            else if (DropDownList1.Text == "Open")
            {

          
                sqlf = " AND F.PurchaseStatus_MST='OPEN'";
            }
            else
            {
              
            }
            dt = ask(sqlo + sqlth + sqlf);
            if (dt.Rows.Count > 1)
            {
                x.Value = Convert.ToString(1);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else
            {
                hint.Value = "没有找到记录！";
            }

            nextpage();
        }
        #endregion
  
        #region nextpage()
        protected void nextpage()
        {

            GridView1.DataKeyNames = new string[] { "采购单号" };
            GridView1.DataBind();
            lblRecordCount.Text = "记录总数" + dt.Rows.Count + "条";
            lblPageCount.Text = "总页数" + (GridView1.PageCount).ToString() + "页";
            lblCurrentIndex.Text = "当前页第" + ((GridView1.PageIndex) + 1).ToString() + "页";
            if (dt.Rows.Count > 0)
            {
                if (GridView1.PageIndex == 0)
                {
                    btnFirst.Enabled = false;
                    btnPrev.Enabled = false;
                }
                else
                {
                    btnFirst.Enabled = true;
                    btnPrev.Enabled = true;
                }
                if (GridView1.PageIndex == GridView1.PageCount - 1)
                {
                    btnNext.Enabled = false;
                    btnLast.Enabled = false;
                }
                else
                {
                    btnNext.Enabled = true;
                    btnLast.Enabled = true;
                }

                // 计算生成分页页码,分别为："首 页" "上一页" "下一页" "尾 页"
                btnFirst.CommandName = "1";
                btnPrev.CommandName = (GridView1.PageIndex == 0 ? "1" : GridView1.PageIndex.ToString());

                btnNext.CommandName = (GridView1.PageCount == 1 ? GridView1.PageCount.ToString() : (GridView1.PageIndex + 2).ToString());
                btnLast.CommandName = GridView1.PageCount.ToString();
            }
            else
            {
                btnFirst.Enabled = false;
                btnPrev.Enabled = false;
                btnNext.Enabled = false;
                btnLast.Enabled = false;
            }

        }
        #endregion
        #region ask
        private DataTable ask(string sql)
        {
            DataTable dtt = new DataTable();
            dtt.Columns.Add("采购单号", typeof(string));
            dtt.Columns.Add("项次", typeof(string));
            dtt.Columns.Add("状态", typeof(string));
            dtt.Columns.Add("ID", typeof(string));
            dtt.Columns.Add("料号", typeof(string));
            dtt.Columns.Add("品名", typeof(string));
            dtt.Columns.Add("客户料号", typeof(string));
            dtt.Columns.Add("采购单价", typeof(decimal));
            dtt.Columns.Add("税率", typeof(decimal));
            dtt.Columns.Add("采购数量", typeof(decimal));
            dtt.Columns.Add("累计入库数量", typeof(decimal));
            dtt.Columns.Add("累计退货数量", typeof(decimal));
            dtt.Columns.Add("实际累计入库数量", typeof(decimal), "累计入库数量-累计退货数量");
            dtt.Columns.Add("未入库数量", typeof(decimal), "采购数量-累计入库数量+累计退货数量");
            dtt.Columns.Add("未税金额", typeof(decimal));
            dtt.Columns.Add("税额", typeof(decimal));
            dtt.Columns.Add("含税金额", typeof(decimal));

            dtt.Columns.Add("入库开票数量", typeof(decimal));
            dtt.Columns.Add("退货开票数量", typeof(decimal));
           
           
            dtt.Columns.Add("已开票数量", typeof(decimal));
            dtt.Columns.Add("未开票数量", typeof(decimal));
            dtt.Columns.Add("发票号码", typeof(string));
            dtt.Columns.Add("发票含税金额", typeof(decimal));
            dtt.Columns.Add("已开票含税金额", typeof(decimal));
            dtt.Columns.Add("未开票含税金额", typeof(decimal));
            dtt.Columns.Add("请款单号", typeof(string));
            dtt.Columns.Add("预付款单号", typeof(string));
            dtt.Columns.Add("预付款金额", typeof(string));
            dtt.Columns.Add("扣款项目", typeof(string));
            dtt.Columns.Add("扣款金额", typeof(string));
            dtt.Columns.Add("实际请款金额", typeof(decimal));
            dtt.Columns.Add("已付款金额", typeof(decimal));
            dtt.Columns.Add("未付款金额", typeof(decimal));

            dtt.Columns.Add("需求日期", typeof(string));
            dtt.Columns.Add("供应商代码", typeof(string));
            dtt.Columns.Add("供应商名称", typeof(string));
            dtt.Columns.Add("电话", typeof(string));
            dtt.Columns.Add("地址", typeof(string));
            dtt.Columns.Add("制单人", typeof(string));
            dtt.Columns.Add("制单日期", typeof(string));



            DataTable dtx1 = bc.getdt(@"
SELECT
A.PUID AS PUID,
A.SN AS SN,
A.WAREID AS WAREID,
CASE WHEN A.PurchaseUnitPrice IS NULL THEN '0'
ELSE A.PURCHASEUNITPRICE
END 
AS PURCHASEUNITPRICE,
CASE WHEN A.TaxRate IS NULL THEN '1'
ELSE A.TAXRATE
END
 AS TAXRATE,A.NEEDDATE AS NEEDDATE,A.PCOUNT AS PCOUNT,D.SUID AS SUID,D.SNAME AS SNAME,
E.PHONE AS PHONE,E.ADDRESS AS ADDRESS,
SUBSTRING(F.DATE,1,10) AS DATE,(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=F.MAKERID) AS MAKER,B.CWAREID AS CWAREID,
CASE WHEN F.PurchaseStatus_MST='CLOSE' THEN '已入库'
WHEN F.PurchaseStatus_MST='PROGRESS' THEN '部分入库'
WHEN F.PurchaseStatus_MST='DELAY' THEN 'Delay'
ELSE 'Open'
END  AS PurchaseStatus_MST,
B.WNAME AS WNAME FROM PURCHASE_DET A 
 LEFT JOIN PURCHASE_MST F ON A.PUID=F.PUID 
LEFT JOIN SUPPLIERINFO_MST D ON A.SUID=D.SUID
LEFT JOIN SUPPLIERINFO_DET E ON D.SUKEY=E.SUKEY
LEFT JOIN WAREINFO B ON A.WAREID=B.WAREID 
" + sql);
            if (dtx1.Rows.Count > 0)
            {
                for (i = 0; i < dtx1.Rows.Count; i++)
                {
                    DataRow dr = dtt.NewRow();
                    dr["采购单号"] = dtx1.Rows[i]["PUID"].ToString();
                    dr["项次"] = dtx1.Rows[i]["SN"].ToString();
                    dr["ID"] = dtx1.Rows[i]["WAREID"].ToString();
                    dtx2 = bc.getdt("select * from wareinfo where wareid='" + dtx1.Rows[i]["WAREID"].ToString() + "'");
                    dr["料号"] = dtx2.Rows[0]["CO_WAREID"].ToString();
                    dr["品名"] = dtx2.Rows[0]["WNAME"].ToString();
                    dr["客户料号"] = dtx2.Rows[0]["CWAREID"].ToString();
                    dr["采购单价"] = decimal.Parse(dtx1.Rows[i]["PURCHASEUNITPRICE"].ToString());
                    dr["税率"] = dtx1.Rows[i]["TAXRATE"].ToString();
                    dr["采购数量"] = dtx1.Rows[i]["PCOUNT"].ToString();
                    dr["累计入库数量"] = 0;
                    dr["累计退货数量"] = 0;
                    dr["需求日期"] = dtx1.Rows[i]["NEEDDATE"].ToString();
                    dr["供应商代码"] = dtx1.Rows[i]["SUID"].ToString();
                    dr["供应商名称"] = dtx1.Rows[i]["SNAME"].ToString();
                    dr["电话"] = dtx1.Rows[i]["PHONE"].ToString();
                    dr["地址"] = dtx1.Rows[i]["ADDRESS"].ToString();
                    dr["制单人"] = dtx1.Rows[i]["MAKER"].ToString();
                    dr["制单日期"] = dtx1.Rows[i]["DATE"].ToString();
                    dr["状态"] = dtx1.Rows[i]["PURCHASESTATUS_MST"].ToString();
                    dtt.Rows.Add(dr);

                }

            }

            DataTable dtx41 = bc.getdt(cpurchase .sqlf + sql + cpurchase .sqlfi);
            if (dtx41.Rows.Count > 0)
            {
                for (i = 0; i < dtx41.Rows.Count; i++)
                {
                    for (j = 0; j < dtt.Rows.Count; j++)
                    {
                        if (dtt.Rows[j]["采购单号"].ToString() == dtx41.Rows[i]["采购单号"].ToString() && dtt.Rows[j]["项次"].ToString() == dtx41.Rows[i]["项次"].ToString())
                        {
                            dtt.Rows[j]["累计入库数量"] = dtx41.Rows[i]["累计入库数量"].ToString();
                            break;
                        }

                    }
                }

            }
            DataTable dtx6 = bc.getdt(sqlth+sqlf );
            if (dtx6.Rows.Count > 0)
            {
                for (i = 0; i < dtx6.Rows.Count; i++)
                {
                    for (j = 0; j < dtt.Rows.Count; j++)
                    {
                        if (dtt.Rows[j]["采购单号"].ToString() == dtx6.Rows[i]["PUID"].ToString() && dtt.Rows[j]["项次"].ToString() == dtx6.Rows[i]["SN"].ToString())
                        {
                            dtt.Rows[j]["累计退货数量"] = dtx6.Rows[i]["MRCOUNT"].ToString();
                            break;
                        }
                    }
                }
            }
            DataTable dtx61 = bc.getdt(crequest_money.sqlth + " WHERE SUBSTRING (B.PRKEY,1,2)='PG'");
            if (dtx61.Rows.Count > 0)
            {
                for (i = 0; i < dtx61.Rows.Count; i++)
                {
                    for (j = 0; j < dtt.Rows.Count; j++)
                    {
                        if (dtt.Rows[j]["采购单号"].ToString() == dtx61.Rows[i]["采购单号"].ToString() && dtt.Rows[j]["项次"].ToString() == dtx61.Rows[i]["项次"].ToString())
                        {
                            dtt.Rows[j]["发票号码"] = dtx61.Rows[i]["发票号码"].ToString();
                            dtt.Rows[j]["发票含税金额"] = dtx61.Rows[i]["发票含税金额"].ToString();
                            dtt.Rows[j]["请款单号"] = dtx61.Rows[i]["请款单号"].ToString();
                            break;
                        }
                    }
                }
            }
            DataTable dtx42 = bc.getdt(cpurchase .sqlf  + " WHERE A.IF_HAVE_INVOICE ='Y'" + cpurchase .sqlfi);
            if (dtx42.Rows.Count > 0)
            {
                for (i = 0; i < dtx42.Rows.Count; i++)
                {
                    for (j = 0; j < dtt.Rows.Count; j++)
                    {
                        if (dtt.Rows[j]["采购单号"].ToString() == dtx42.Rows[i]["采购单号"].ToString() && dtt.Rows[j]["项次"].ToString() == dtx42.Rows[i]["项次"].ToString())
                        {
                            dtt.Rows[j]["入库开票数量"] = dtx42.Rows[i]["累计入库数量"].ToString();
                            break;
                        }
                    }
                }
            }
            DataTable dtx43 = bc.getdt(sqlth + " WHERE A.IF_HAVE_INVOICE ='Y'" + sqlf);
            if (dtx43.Rows.Count > 0)
            {
                for (i = 0; i < dtx43.Rows.Count; i++)
                {
                    for (j = 0; j < dtt.Rows.Count; j++)
                    {
                        if (dtt.Rows[j]["采购单号"].ToString() == dtx43.Rows[i]["PUID"].ToString() && dtt.Rows[j]["项次"].ToString() == dtx43.Rows[i]["SN"].ToString())
                        {
                            dtt.Rows[j]["退货开票数量"] = dtx43.Rows[i]["MRCOUNT"].ToString();
                            break;
                        }
                    }
                }
            }
            DataTable dtx44 = crequest_money.RETURN_DT();
            foreach (DataRow dr4 in dtt.Rows )
            {

                foreach (DataRow dr5 in dtx44.Rows)
                {

                    if (dr4["请款单号"].ToString() == dr5["请款单号"].ToString())
                    {
                        dr4["预付款单号"] = dr5["预付款单号"].ToString();
                        dr4["预付款金额"] = dr5["预付款金额"].ToString();
                        dr4["扣款项目"] = dr5["扣款项目"].ToString();
                        dr4["扣款金额"] = dr5["扣款金额"].ToString();
                        dr4["实际请款金额"] = dr5["实际请款金额"].ToString();
                        dr4["已付款金额"] = dr5["累计付款金额"].ToString();
                        dr4["未付款金额"] = dr5["未付款金额"].ToString();
                        break;
                    }


                }


            }
            decimal d11=0,d12=0,d13=0,d14=0,d15=0,d16=0;
            DataTable dtx = new DataTable();

            dtx.Columns.Add("请款单号", typeof(string));
            dtx.Columns.Add("预付款金额", typeof(string));
            dtx.Columns.Add("实际请款金额", typeof(string));
            dtx.Columns.Add("已付款金额", typeof(string));
            dtx.Columns.Add("未付款金额", typeof(string));
            foreach (DataRow dr in dtt.Rows)
            {

                decimal d1 = decimal.Parse(dr["采购单价"].ToString());
                decimal d2 = decimal.Parse(dr["累计入库数量"].ToString());
                decimal d3 = decimal.Parse(dr["税率"].ToString());
                decimal d4 = decimal.Parse(dr["累计退货数量"].ToString());
                decimal d5 = (d2 - d4) * d1;
                decimal d6 = (d2 - d4) * d1 * d3/100;
                decimal d7 = (d2 - d4) * d1 * (1 + d3 / 100);
                decimal d8 = 0, d9 = 0,d10=0;
                if (!string.IsNullOrEmpty(dr["入库开票数量"].ToString()))
                {
                    d8 = decimal.Parse(dr["入库开票数量"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["退货开票数量"].ToString()))
                {
                    d9 = decimal.Parse(dr["退货开票数量"].ToString());
                }
                d10 = (d2 - d4) - (d8 - d9);
                dr["已开票数量"] = (d8 - d9).ToString ("0.00");
                dr["未开票数量"] = (decimal.Parse(dr["实际累计入库数量"].ToString()) - (d8 - d9)).ToString("0.00");
                dr["已开票含税金额"] = ((d8 - d9) * (1 + d3 / 100)*d1).ToString("0.00");
                dr["未开票含税金额"] = (d10 * (1 + d3 / 100)*d1).ToString("0.00");
                dr["未税金额"] = d5.ToString("0.00");
                dr["税额"] = d6.ToString("0.00");
                dr["含税金额"] = d7.ToString("0.00");
            
                DataTable  dtx2 = bc.GET_DT_TO_DV_TO_DT(dtx, "", "请款单号='" + dr["请款单号"].ToString() + "' AND 请款单号 IS NOT NULL");
                if (dtx2.Rows.Count > 0)
                {
                    
                }
                else
                {
               
                    if (!string.IsNullOrEmpty (dr["预付款金额"].ToString()))
                    {

                        d11 = d11+decimal.Parse(dr["预付款金额"].ToString());
                    }
                    if (!string.IsNullOrEmpty(dr["实际请款金额"].ToString()))
                    {

                        d12 =d12+ decimal.Parse(dr["实际请款金额"].ToString());
                    }
                    if (!string.IsNullOrEmpty(dr["已付款金额"].ToString()))
                    {

                        d13 = d13 + decimal.Parse(dr["已付款金额"].ToString());
                    }
                    if (!string.IsNullOrEmpty(dr["未付款金额"].ToString()))
                    {

                        d14 = d14 + decimal.Parse(dr["未付款金额"].ToString());
                    }
                    if (!string.IsNullOrEmpty(dr["扣款金额"].ToString()))
                    {

                        d15= d15 + decimal.Parse(dr["扣款金额"].ToString());
                    }
                    if (!string.IsNullOrEmpty(dr["发票含税金额"].ToString()))
                    {

                        d16 = d16 + decimal.Parse(dr["发票含税金额"].ToString());
                    }
                    DataRow drx=dtx.NewRow ();
                    drx["请款单号"] = dr["请款单号"].ToString();
                    drx["预付款金额"] = dr["预付款金额"].ToString();
            
                    dtx.Rows.Add(drx);
                }
            }
         
            DataRow dr1 = dtt.NewRow();
            dr1["采购单号"] = "合计";
            dr1["采购数量"] = dtt.Compute("SUM(采购数量)", "");
            dr1["累计入库数量"] = dtt.Compute("SUM(累计入库数量)", "");
            dr1["累计退货数量"] = dtt.Compute("SUM(累计退货数量)", "");
            dr1["实际累计入库数量"] = dtt.Compute("SUM(实际累计入库数量)", "");
            dr1["未入库数量"] = dtt.Compute("SUM(未入库数量)", "");
            dr1["未税金额"] = dtt.Compute("SUM(未税金额)", "");
            dr1["税额"] = dtt.Compute("SUM(税额)", "");
            dr1["含税金额"] = dtt.Compute("SUM(含税金额)", "");
            dr1["已开票数量"] = dtt.Compute("SUM(已开票数量)", "");
            dr1["未开票数量"] = dtt.Compute("SUM(未开票数量)", "");
            dr1["已开票含税金额"] = dtt.Compute("SUM(已开票含税金额)", "");
            dr1["未开票含税金额"] = dtt.Compute("SUM(未开票含税金额)", "");

            dr1["预付款金额"] = d11;
            dr1["实际请款金额"] = d12;
            dr1["已付款金额"] = d13;
            dr1["未付款金额"] = d14;
            dr1["扣款金额"] = d15;
            dr1["发票含税金额"] = d16;
            dtt.Rows.Add(dr1);
            return dtt;
        }
        #endregion

       
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            string varID = GridView1.DataKeys[GridView1.SelectedIndex].Values[0].ToString();
            String[] str = new string[] { varID };
            WPSS.PurchaseManage.PurchaseGodeT.IDO  = str[0];
            Response.Redirect("../StockManage/PurchaseGodeT.aspx");

        }
        protected void PageButton_Click(object sender, EventArgs e)
        {
            GridView1.PageIndex = Convert.ToInt32(((LinkButton)sender).CommandName) - 1;
            bind();
        }

        protected void btngo_Click(object sender, EventArgs e)
        {
            #region btngo
            try
            {
                if (txtNum.Text == "")
                {
                    //opAndvalidate.Show("页数不能为空");
                }
                else
                {
                    int vargo = Convert.ToInt32(txtNum.Text);
                    if (vargo <= GridView1.PageCount)
                    {
                        GridView1.PageIndex = Convert.ToInt32(txtNum.Text) - 1;
                        bind();
                    }
                    else
                    {
                        hint.Value = "没有找到记录";
                        x.Value = "";
                        x1.Value = "";
                    }
                }
            }
            catch (Exception)
            {
                //opAndvalidate.Show("输入格式不正确，请检查！");
            }

            #endregion
        }
        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            bind();
        }

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

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            bind();
        }

        protected void btnEXCEL_Click(object sender, ImageClickEventArgs e)
        {
            bind();
       
            WPSS.ReportManage.CRVPrintBill.Array[0] = "PURCHASE_SEARCH";
            WPSS.ReportManage.CRVPrintBill.SEARCH = dt;
          
            Response.Redirect("../ReportManage/CRVPrintBill.aspx");
        }




    }
}
