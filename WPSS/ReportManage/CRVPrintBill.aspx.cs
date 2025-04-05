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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using XizheC;
namespace WPSS.ReportManage
{
    public partial class CRVPrintBill : System.Web.UI.Page
    {
        basec bc = new basec();
        public static string[] Array = new string[] { "", "" };
        WPSS.Validate va = new Validate();
        PrintPurchaseBill print = new PrintPurchaseBill();
        PrintSellTableBill printo = new PrintSellTableBill();
        PrintOfferBill printt = new PrintOfferBill();
        public static DataTable search;
        public static DataTable SEARCH
        {
            set { search = value; }
            get { return search; }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Bind();
            if (va.returnb() == true)
            Response.Redirect("../Default.aspx");  
        }
        protected void Bind()
        {
            CrystalReportViewer1.PrintMode = CrystalDecisions.Web.PrintMode.Pdf;
            SqlConnection sqlcon = bc.getcon();
            sqlcon.Open();
            DataTable dt = print.asko(Array[0]);
            DataTable dto = printo.asko(Array[0]);
            DataTable dtt = printt.askt(Array[0]);
            DataTable dtx = search;
            if (Array[0].Length > 2)
            {
                if (Array[0] == "PURCHASE_SEARCH")
                {
                    
                    WPSS.ReportManage.CRPURCHASE_SEARCH oRpt = new CRPURCHASE_SEARCH();
                    string ul = Server.MapPath("../ReportManage/CRPURCHASE_SEARCH.rpt");
                    oRpt.Load(ul);
                    oRpt.SetDataSource(dtx);
                    CrystalReportViewer1.ReportSource = oRpt;
                 


                }
                else if (Array[0].Substring(0, 2) == "PU")
                {
                    WPSS.ReportManage.CRPurchase oRpt = new CRPurchase();
                    string ul = Server.MapPath("../ReportManage/CRPurchase.rpt");
                    oRpt.Load(ul);
                    oRpt.SetDataSource(dt);
                    CrystalReportViewer1.ReportSource = oRpt;
                }
                else if (Array[0].Substring(0, 2) == "SE")
                {
                    WPSS.ReportManage.CRSellTable oRpt = new CRSellTable();
                    string ul = Server.MapPath("../ReportManage/CRSellTable.rpt");
                    oRpt.Load(ul);
                    oRpt.SetDataSource(dto);
                    CrystalReportViewer1.ReportSource = oRpt;
                }
                else if (Array[0].Substring(0, 1) == "Q")
                {
                    WPSS.ReportManage.CROffer oRpt = new CROffer();
                    string ul = Server.MapPath("../ReportManage/CROffer.rpt");
                    oRpt.Load(ul);
                    oRpt.SetDataSource(dtt);
                    CrystalReportViewer1.ReportSource = oRpt;
                  
                }
                else if (Array[0] == "ORDER_SEARCH")
                {
                    WPSS.ReportManage.CRORDER_SEARCH oRpt = new CRORDER_SEARCH();
                    string ul = Server.MapPath("../ReportManage/CRORDER_SEARCH.rpt");
                    oRpt.Load(ul);
                    oRpt.SetDataSource(dtx);
                    CrystalReportViewer1.ReportSource = oRpt;
               

                }
                else if (Array[0] == "LEND")
                {
                    WPSS.ReportManage.CRLEND oRpt =new CRLEND ();
                    string ul = Server.MapPath("../ReportManage/CRLEND.rpt");
                    oRpt.Load(ul);
                    oRpt.SetDataSource(dtx);
                    CrystalReportViewer1.ReportSource = oRpt;


                }

                else if (Array[0] == "RETURN_EQUIPMENT")
                {
                    WPSS.ReportManage.CRRETURN_EQUIPMENT oRpt = new CRRETURN_EQUIPMENT();
                    string ul = Server.MapPath("../ReportManage/CRRETURN_EQUIPMENT.rpt");
                    oRpt.Load(ul);
                    oRpt.SetDataSource(dtx);
                    CrystalReportViewer1.ReportSource = oRpt;


                }
            }
         
        }

        protected void CrystalReportViewer1_Init(object sender, EventArgs e)
        {

        }
    }
}
