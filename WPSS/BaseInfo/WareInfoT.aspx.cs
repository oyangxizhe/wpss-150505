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

namespace WPSS.BaseInfo
{
    public partial class WareInfoT : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        DataTable dto = new DataTable();
        basec bc = new basec();

        WPSS.Validate va = new Validate();
        int i;
        public static string[] str1 = new string[] { "", "", "" };
        public static string[] strE = new string[] { "" };
       
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                Bind1();
                Bind();
            }
            if (va.returnb() == true)
                Response.Redirect("\\Default.aspx");
            try
            {
               

            }
            catch (Exception)
            {

            }
        }
        protected void Bind1()
        {
        
            getbinddata();
            if (str1[0] != "")
            {
                Text1.Value = str1[0];
                x2.Value = str1[1];
                x3.Value = str1[2];
                str1[0] = "";
                str1[1] = "";
                str1[2] = "";

            }
            else
            {

                Text1.Value = strE[0];
                strE[0] = "";
                dt = basec.getdts("select * from WareInfo where WAREID='" + Text1.Value + "'");
                if (dt.Rows.Count > 0)
                {

                    Text1.Value = dt.Rows[0]["WAREID"].ToString();
                    Text2.Value = dt.Rows[0]["CO_WAREID"].ToString();
                    Text3.Value = dt.Rows[0]["WNAME"].ToString();
                    Text4.Value = dt.Rows[0]["CWAREID"].ToString();
                    DropDownList1.Text = dt.Rows[0]["SPEC"].ToString();
                  
                    Text6.Value = dt.Rows[0]["UNIT"].ToString();
                    Text5.Value = bc.getOnlyString("SELECT CNAME FROM CUSTOMERINFO_MST WHERE CUID='" + dt.Rows[0]["CUID"].ToString() + "'");

                    if (dt.Rows[0]["ACTIVE"].ToString() == "Y")
                    {
                        DropDownList3.Text = "正常";
                    }
                    else if (dt.Rows[0]["ACTIVE"].ToString() == "HOLD")
                    {
                        DropDownList3.Text = "Hold";
                    }
                    else
                    {
                        DropDownList3.Text = "作废";
                    }
                }

            }


        }
        #region getBindData()
        protected void getbinddata()
        {

        
            dto = SqlDT.SqlDTM("SPEC", "SPEC");
            if (DropDownList1.Items.Count - 1 != dto.Rows.Count)
            {
                DropDownList1.Items.Add("");
                foreach (DataRow dr1 in dto.Rows)
                {

                    DropDownList1.Items.Add(dr1[0].ToString());

                }
            }
        }
        #endregion
        protected void Bind()
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
            DataList1.DataSource = dtx();
            DataList1.DataBind();
         
            DataTable dt1 = basec.getdts("SELECT * FROM WAREFILE WHERE WAREID='" + Text1.Value + "'");
            GridView1.DataSource = dt1;
            GridView1.DataKeyNames = new string[] { "FLKEY" };
            GridView1.DataBind();
             dt1 = basec.getdts("SELECT * FROM WAREIMAGE WHERE WAREID='" + Text1.Value + "'");
             if (dt1.Rows.Count > 0)
             {
                 Image1.ImageUrl = dt1.Rows[0]["PATH"].ToString();
             }

        }
        protected DataTable dtx()
        {
            dt.Columns.Add("C", typeof(string));
            for (i = 0; i < 4; i++)
            {
                DataRow dr = dt.NewRow();
                dr["C"] = Convert.ToString(i);
                dt.Rows.Add(dr);
            }
            return dt;
        }
        protected DataTable dtxO()
        {
            dt.Columns.Add("CO", typeof(string));
            for (i = 0; i < 1; i++)
            {
                DataRow dr = dt.NewRow();
                dr["CO"] = Convert.ToString(i);
                dt.Rows.Add(dr);
            }
            return dt;
        }
        #region ClearText()
        protected void ClearText()
        {
            Text2.Value = "";
            Text3.Value = "";
            Text4.Value = "";
            DropDownList1.Text = "";
            Text6.Value = "";
            Text5.Value = "";
            TextBox1.Text = "";

        }
        #endregion
        protected void btnOnloadFile_Click(object sender, EventArgs e)
        {
            CFileInfo cf = new CFileInfo();
            cf.OnloadFile(Text1.Value);
            hint.Value = cf.ErrowInfo;
            Bind();
            try
            {
              
            }
            catch (Exception)
            {

            }

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

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string id = GridView1.DataKeys[e.RowIndex][0].ToString();
                string FilePath = bc.getOnlyString("SELECT PATH FROM WAREFILE WHERE FLKEY='" + id + "'");
                string s1 = Server.MapPath(FilePath);
                if (File.Exists(s1))
                {
                    File.Delete(s1);
                }
                string strSql = "DELETE FROM WAREFILE WHERE FLKEY='" + id + "'";
                basec.getcoms(strSql);
                GridView1.EditIndex = -1;
                Bind();
            }
            catch (Exception)
            {


            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string v1 = GridView1.DataKeys[GridView1.SelectedIndex].Values[0].ToString();
            string FilePath = bc.getOnlyString("SELECT PATH FROM WAREFILE WHERE FLKEY='" + v1 + "'");
            FileInfo file = new FileInfo(Server.MapPath(FilePath));
            if (file.Exists)
            {
                Response.Clear();
                string fileName = HttpUtility.UrlEncode(file.Name);
                Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
                //Response.AddHeader("Content-Length", file.Length.ToString());
                Response.ContentType = "application/octet-stream;charset=gb2312";
                Response.Filter.Close();
                Response.WriteFile(file.FullName);
                Response.End();
            }
            try
            {
            
            }
            catch (Exception)
            {

            }

        }

        protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        {

            try
            {
                add();
            }
            catch (Exception)
            {
            }


        }
           #region add()
        protected void add()
        {
            Bind();
            ClearText();
            Text1.Value = bc.numYM(9, 4, "0001", "SELECT * FROM WAREINFO", "WAREID", "9");

            /*purchaseunitprice*/
            string a = bc.numYM(10, 4, "0001", "select * from PurchaseUnitPrice", "PPID", "PP");
            if (a == "Exceed limited")
            {

                hint.Value = "编码超出限制！";
            }
            else
            {
                x2.Value = a;

            }
            /*purchaseunitprice*/

            /*sellunitprice*/
            string a1 = bc.numYM(10, 4, "0001", "select * from SellUnitPrice", "SPID", "SP");
            if (a1 == "Exceed limited")
            {

                hint.Value = "编码超出限制！";
            }
            else
            {
                x3.Value = a1;

            }
            ADD_OR_UPDATE = "ADD";
            /*sellunitprice*/
            
         
           
        }
        #endregion
        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {


            save();
            if (IFExecution_SUCCESS == true && ADD_OR_UPDATE == "ADD")
            {
                add();
            }
            else if (IFExecution_SUCCESS == true)
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
            string sql;
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss");
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 10, 10);
            string varMakerID = bc.getOnlyString("SELECT EMID FROM USERINFO WHERE USID='" + n2 + "'");
            if (ac1() == 0)
            {
               
            }
            else if (!bc.exists("SELECT WAREID FROM WAREINFO WHERE WAREID='" + Text1.Value + "'"))
            {

                SqlConnection sqlcon = bc.getcon();
                sql = @"INSERT INTO WAREINFO(
WAREID,
CO_WAREID,
WNAME,
CWAREID,
SPEC,
UNIT,
CUID,
REMARK,
DATE,
MAKERID,
YEAR,
ACTIVE,
MONTH
)
VALUES 
(
@WAREID,
@CO_WAREID,
@WNAME,
@CWAREID,
@SPEC,
@UNIT,
@CUID,
@REMARK,
@DATE,
@MAKERID,
@YEAR,
@ACTIVE,
@MONTH
)

";
                SQlcommandE(sql);
                if (DropDownList3.Text == "正常")
                {
                    /*purchaseunitprice 1/1*/

                    if (!bc.exists("SELECT * FROM PURCHASEUNITPRICE WHERE PPID='" + x2.Value + "'"))
                    {
                        basec.getcoms(@"insert into PurchaseUnitPrice(PPID,WAREID,MakerID,
Date,Year,Month) values('" + x2.Value + "','" + Text1.Value + "','" + varMakerID + "', '" + varDate +
             "','" + year + "','" + month + "')");
                    }
                    /*purchaseunitprice 1/1*/

                    /*sellunitprice 1/1*/

                    if (!bc.exists("SELECT * FROM SELLUNITPRICE WHERE SPID='" + x3.Value + "'"))
                    {
                        basec.getcoms(@"insert into SELLUNITPRICE(SPID,WAREID,MakerID,
Date,Year,Month) values('" + x3.Value + "','" + Text1.Value + "','" + varMakerID + "', '" + varDate +
             "','" + year + "','" + month + "')");
                    }
                    /*sellunitprice 1/1*/
                }
                IFExecution_SUCCESS = true;
            }
            else
            {
                SqlConnection sqlcon = bc.getcon();
                sql = @"UPDATE WAREINFO SET 

CO_WAREID=@CO_WAREID,
WNAME=@WNAME,
CWAREID=@CWAREID,
SPEC=@SPEC,
UNIT=@UNIT,
CUID=@CUID,
REMARK=@REMARK,
DATE=@DATE,
YEAR=@YEAR,
MONTH=@MONTH,
ACTIVE=@ACTIVE
WHERE WAREID='" + Text1.Value + "'";
                SQlcommandE(sql);
                IFExecution_SUCCESS = true;
            }


        }
        #region ac1()
        private int ac1()
        {

            int x = 1;
            if (Text3.Value == "")
            {
                x = 0;
                hint.Value = "品名不能为空！";
            }
     

            return x;

        }
        #endregion
        protected void btnExit_Click(object sender, ImageClickEventArgs e)
        {
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 16, 16);
            Response.Redirect("../BaseInfo/WareInfo.aspx" + n2);
        }
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
            sqlcom.Parameters.Add("@WAREID", SqlDbType.VarChar, 20).Value = Text1.Value;
            sqlcom.Parameters.Add("@CO_WAREID", SqlDbType.VarChar, 20).Value = Text2.Value;
            sqlcom.Parameters.Add("@WNAME", SqlDbType.VarChar, 20).Value = Text3.Value;
            sqlcom.Parameters.Add("@CWAREID", SqlDbType.VarChar, 20).Value = Text4.Value;
            sqlcom.Parameters.Add("@SPEC", SqlDbType.VarChar, 20).Value = DropDownList1.Text;
            sqlcom.Parameters.Add("@UNIT", SqlDbType.VarChar, 20).Value = Text6.Value;
            sqlcom.Parameters.Add("@CUID", SqlDbType.VarChar, 20).Value = bc.getOnlyString("SELECT CUID FROM CUSTOMERINFO_MST WHERE CNAME='" + Text5.Value + "'");
            sqlcom.Parameters.Add("@REMARK", SqlDbType.VarChar, 1000).Value = TextBox1.Text;
            sqlcom.Parameters.Add("@DATE", SqlDbType.VarChar, 20).Value = varDate;
            sqlcom.Parameters.Add("@MAKERID", SqlDbType.VarChar, 20).Value = varMakerID;
            sqlcom.Parameters.Add("@YEAR", SqlDbType.VarChar, 20).Value = year;
            sqlcom.Parameters.Add("@MONTH", SqlDbType.VarChar, 20).Value = month;

            if (DropDownList3.Text == "正常")
            {
                sqlcom.Parameters.Add("@ACTIVE", SqlDbType.VarChar, 20).Value = "Y";
            }
            else if (DropDownList3.Text == "Hold")
            {
                sqlcom.Parameters.Add("@ACTIVE", SqlDbType.VarChar, 20).Value = "HOLD";
            }
            else
            {
                sqlcom.Parameters.Add("@ACTIVE", SqlDbType.VarChar, 20).Value = "N";

            }

            sqlcon.Open();
            sqlcom.ExecuteNonQuery();
            sqlcon.Close();
        }
        #endregion

        protected void btnOnloadImage_Click(object sender, EventArgs e)
        {
           
            string FilePath = bc.getOnlyString("SELECT PATH FROM WAREIMAGE WHERE WAREID='"+Text1 .Value +"'");
            string s1 = Server.MapPath(FilePath);
            if (File.Exists(s1))
            {
                File.Delete(s1);
            }
            if (FilePath.Length > 0)
            {
                string filepath2 = FilePath.Substring(16, FilePath.Length - 16);
                string s2 = Server.MapPath("../File/"+filepath2);
                if (File.Exists(s2))
                {
                    File.Delete(s2);
                }
            }
         
            string strSql = "DELETE FROM WAREIMAGE WHERE WAREID='" + Text1.Value + "'";
            basec.getcoms(strSql);
       
           
            //CFileInfo cf = new CFileInfo();
            OnloadImage(Text1.Value);

            //hint.Value = cf.ErrowInfo;
            Bind();
        }
        #region makethumbnail
        public static void MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height, string mode)
        {
            System.Drawing.Image originalImage = System.Drawing.Image.FromFile(originalImagePath);

            int towidth = width;
            int toheight = height;

            int x = 0;
            int y = 0;
            int ow = originalImage.Width;
            int oh = originalImage.Height;

            switch (mode)
            {
                case "HW"://指定高宽缩放（可能变形）                
                    break;
                case "W"://指定宽，高按比例                    
                    toheight = originalImage.Height * width / originalImage.Width;
                    break;
                case "H"://指定高，宽按比例
                    towidth = originalImage.Width * height / originalImage.Height;
                    break;
                case "Cut"://指定高宽裁减（不变形）                
                    if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                    {
                        oh = originalImage.Height;
                        ow = originalImage.Height * towidth / toheight;
                        y = 0;
                        x = (originalImage.Width - ow) / 2;
                    }
                    else
                    {
                        ow = originalImage.Width;
                        oh = originalImage.Width * height / towidth;
                        x = 0;
                        y = (originalImage.Height - oh) / 2;
                    }
                    break;
                default:
                    break;
            }

            //新建一个bmp图片
            System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

            //新建一个画板
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);

            //设置高质量插值法
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //清空画布并以透明背景色填充
            g.Clear(System.Drawing.Color.Transparent);

            //在指定位置并且按指定大小绘制原图片的指定部分
            g.DrawImage(originalImage, new System.Drawing.Rectangle(0, 0, towidth, toheight),
                new System.Drawing.Rectangle(x, y, ow, oh),
                System.Drawing.GraphicsUnit.Pixel);

            try
            {
                //以jpg格式保存缩略图
                bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (System.Exception e)
            {
                throw e;
            }
            finally
            {
                originalImage.Dispose();
                bitmap.Dispose();
                g.Dispose();
            }
        }
        #endregion
        public void OnloadImage(string WareID)
        {
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            System.Web.HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
            Random ro = new Random();
            string dirpath = Server.MapPath("../File/");
            for (i = 0; i < 1; i++)
            {
                System.Web.HttpPostedFile myFile = files[i];
                string FileName = "";
                string FileExtention = "";
                int name = 0;
                FileName = System.IO.Path.GetFileName(myFile.FileName);
                string stro = ro.Next(100, 100000000).ToString() + name.ToString();//产生一个随机数用于新命名的图片 
                string NewName = DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + stro;
                if (FileName.Length > 0)//有文件才执行上传操作再保存到数据库 
                {
                    FileExtention = System.IO.Path.GetExtension(myFile.FileName);
                    string ppath = dirpath + "/" + NewName + FileExtention;
                    myFile.SaveAs(ppath);
                    string FJname = FileName;

                    string fileName_s = "300x300-" + NewName + FileExtention;                           // 缩略图文件名称
                    //string fileName_s1 = "50x50-" + NewName + FileExtention;                           // 缩略图文件名称
                    string fileName_s2 = NewName + FileExtention;

                    string webFilePath = Server.MapPath("../File/" + NewName + FileExtention);        // 服务器端文件路径
                    string webFilePath_s = Server.MapPath("../File/" + fileName_s);　　// 服务器端缩略图路径
                    //string webFilePath_s1 = Server.MapPath("../File/" + fileName_s1);　　// 服务器端缩略图路径
                    MakeThumbnail(webFilePath, webFilePath_s, 300, 300, "Cut");     // 生成缩略图方法
                    //MakeThumbnail(webFilePath, webFilePath_s1, 50, 50, "Cut");     // 生成缩略图方法

                    string a = "../File/" + fileName_s;
                    //string a1 = "../File/" + fileName_s1;
                    string a2 = "../File/" + fileName_s2;

                    string v1 = bc.numYMD(20, 12, "000000000001", "SELECT * FROM WAREIMAGE", "WIKEY", "WI");
                    basec.getcoms(@"INSERT INTO WAREIMAGE(WIKEY,WAREID,OLDFILENAME,PATH,DATE,YEAR,MONTH,DAY) VALUES 
('" + v1 + "','" + WareID + "','" + FileName + "','" + a + "','" + varDate + "','" + year + "','" + month + "','" + day + "')");


                }
            }
            

        }
    }
}
