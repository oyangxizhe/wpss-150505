<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SellTableT.aspx.cs" Inherits="WPSS.SellManage.SellTableT" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>�༭������</title>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" /> 
<meta name ="Description" content ="���������ϵͳ" />
<meta name ="keywords" content ="���������ϵͳ,������������,ERP,С΢��ҵ����ϵͳ,ϣ�����" />
       <link href ="../Css/SSBase.css"  type ="text/css" rel ="Stylesheet" />
       <link href ="../Css/S131017.css"  type ="text/css" rel ="Stylesheet" />
    </head>
<body >
   <form id="form1" runat="server">
    <input id="cuid" type="hidden"  runat="server" />
   <input id="hint" type="hidden"  runat="server" />
    <input id="emid" type="hidden"  runat="server" />
      <input id="x" type="hidden"  runat="server" />
       <input id="ControlFileDisplay" type="hidden"  runat="server" />
        <input id="x2" type="hidden"  runat="server" />
         <input id="CUKEY" type="hidden"  runat="server" />
                <div class ="c13101905">
      <div class="c13101906" id ="Div9">
          &gt;�༭������ </div>
     <div class="c13101907" id ="Div10">
 </div>
    </div>
<div class ="c13110501">
      <div class="c13110502" id ="Div17">
   <span class="c13110508" id ="Span1">
       <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="~/Image/btnAdd.png"    onclick="btnAdd_Click"  />
          </span>
       </div>
              <div class="c13110510" id ="Div18">
   <span class="c13110511" id ="Span4">
                  
                  <asp:Label ID="Label2" runat="server" Text="Label">(����)</asp:Label>
          </span>
       </div>
             <div class="c13110502" id ="Div19">
   <span class="c13110508" id ="Span3">
       <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/Image/btnSave.png" 
                     onclick="btnSave_Click"  />
          </span>
       </div>
              <div class="c13110510" id ="Div20">
   <span class="c13110511" id ="Span5">
                  <asp:Label ID="Label3" runat="server" Text="Label">(����)</asp:Label>
          </span>
       </div>
          
         <div class="c13110507" id ="Div22">
                  <span class="c13110503" id ="Span2">
     <asp:ImageButton ID="btnExit" 
                 runat="server" ImageUrl="~/Image/btnExit.png" Width="60px" 
                      onclick="btnExit_Click" />
          </span>
   </div>
                 <div class="c13110510" id ="Div23">
   <span class="c13110511" id ="Span6">
                     (�˳�)
          </span>
       </div>
            <div class="c13110507" id ="Div1">
                  <span class="c13110503" id ="Span7">
     <asp:ImageButton ID="btnPrint" 
                 runat="server" ImageUrl="~/Image/btnPrint.png" Width="60px" 
                      onclick="btnPrint_Click" />
          </span>
   </div>
                 <div class="c13110510" id ="Div3">
   <span class="c13110511" id ="Span8">
                     (��ӡ)
          </span>
       </div>
                 <div class="c13110507" id ="Div30" style="display :none;">
                  <span class="c13110503" id ="Span9">
     <asp:ImageButton ID="btnEXCEL_PRINT" 
                 runat="server" ImageUrl="~/Image/btnPrint.png" Width="60px" 
                      onclick="btnEXCEL_PRINT_Click" />
          </span>
   </div>
                 <div class="c13110510" id ="Div31">
   <span class="c13110511" id ="Span10" style ="display:none ">
                     (Eӡ)
          </span>
       </div>
    </div>
<div  id="i13102301" class ="c13102101">
<span  class ="c13102102"><asp:Label ID="prompt" runat="server"  ForeColor="#f80707"></asp:Label></span>
</div> 
  <div class ="c13101902">
      <div class="c13101903" id ="Div24">
          ��������</div>
     <div class="c13101904" id ="Div25">
<input id="Text1" type="text"  runat="server"   readonly ="readonly" class="c13102103"/> 
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="Text1" Text="����ģ�" runat="server" /></div>
       <div class="c13101903" id ="Div5">
             �ͻ�����</div>
     <div class="c13111503" id ="Div6">
   <input id="Text5" type="text"  runat ="server"  class ="c13102103"  />
     <span style =" margin-left :2px; margin-right :2px;"><a  href="javascript:f13100202('Text5','');">
         ѡ��</a></span></div>
         <div class="c13101903" id ="Div26">
             ������</div>
     <div class="c13110801"  id ="Div27">
   <input id="Text2" type="text"  runat ="server"  readonly ="readonly" class ="c14112013" />
   <span style =" margin-left :2px; margin-right :2px;"><a  href="javascript:f13100202('Text2','');">
         ѡ��</a></span> 
   <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="Text2" Text="����ģ�" runat="server" />
       <asp:LinkButton 
             ID="btnSure" runat="server" onclick="btnSure_Click"  
            >ȷ��</asp:LinkButton></div>
   
           </div>
  <div class ="c13101902">
                   <div class="c13101903" id ="Div28">
                        ��������</div>
     <div class="c13101904" id ="Div29">
         <input id="Text3" type="text" runat="server" onclick ="f13100202('Text3')" readonly="readonly" class ="c13110901"/>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="Text3" Text="����ģ�" runat="server" />
          </div>
                      <div class="c13101903" id ="Div2">
                          ����Ա����</div>
                          
     <div class="c13111503" id ="Div4">
         <input id="Text4" type="text" runat="server"  class ="c14112009"/>
          <span style =" margin-left :2px; margin-right :2px;"><a  href="javascript:f13100202('Text4','');">
         ѡ��</a></span>
                   <span  style =" margin-left :10px"><asp:Label ID="Label1" runat="server" Text="" ></asp:Label></span>
   </div>

  <div class="c13101903" id ="Div38">
                          ��ϵ��</div>
     <div class="c13101904" id ="Div39">
         <input id="Text6" type="text" runat="server"  class ="c13102103"/> 
         </div>
           </div>
              <div class ="c13101902">
    
       <div class="c13101903" id ="Div15">
                   �ͻ���ַ</div>
     <div class="c13102604" id ="Div21">
           <input id="Text11" type="text"  runat="server"  readonly ="readonly" class="c13102103"/>
             <span style =" margin-left :2px; margin-right :2px;"><a  href="javascript:f13100202('Text11','');">
           ѡ��</a></span>
           </div>
          <div class="c13101903" id ="Div40">
              ��ϵ�绰</div>
     <div class="c13101904" id ="Div41">
   <input id="Text10" type="text"  runat ="server"  class ="c13102103"  /></div>
           </div>

<div id="i13111001" class ="c13102201">
     <div class="c15013001" id ="Div36">
      <span style="color :#990033">(��ͬ�ֿ����ŵ��Ϻ���һ����������������ӡ ֻ��һֱ�����水Ť����)</span>
</div>
           <asp:GridView ID="GridView1" runat="server" 
                    AllowSorting="True"   
                    onrowdatabound="GridView1_RowDataBound" 
                        AutoGenerateColumns="False"  PageSize="15" 
                           CssClass ="c13122601" onrowdeleting="GridView1_RowDeleting"
                   >
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns > 
                    <asp:TemplateField HeaderText="ɾ��" >
                <ItemTemplate >
                    <asp:LinkButton ID="LinkButton2" runat="server" 
                        OnClientClick="return confirm('��ȷ��ɾ���ü�¼��?');" Text="ɾ��"  CommandName ="delete" ></asp:LinkButton>                     
                </ItemTemplate>
               <HeaderStyle Width="2%" />
                 <ItemStyle Width="2%"  />
            </asp:TemplateField>
                              <asp:TemplateField HeaderText="���" >
                <ItemTemplate >
                  <asp:TextBox ID="TextBox1" runat="server"  Text='<%#Eval ("���") %>'  CssClass="c14071612" ></asp:TextBox>   
                               
                </ItemTemplate>
                    <HeaderStyle Width="2%" />
                 <ItemStyle Width="2%"  ForeColor="#595d5a" />
            </asp:TemplateField> 
           <asp:TemplateField HeaderText="ID" >
                <ItemTemplate >
                                <asp:TextBox ID="TextBox2" runat="server"  Text='<%#Eval ("Ʒ��") %>' CssClass="c14071609" ></asp:TextBox>   
                               
                </ItemTemplate>
                  <HeaderStyle Width="4%" />
                 <ItemStyle Width="4%"  ForeColor="#595d5a" />
            </asp:TemplateField> 
                       <asp:TemplateField HeaderText="�Ϻ�">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox5" runat="server"  Text='<%#Eval ("�Ϻ�") %>' CssClass="c14071609"></asp:TextBox>                     
                </ItemTemplate>
                <HeaderStyle Width="4%" />
                 <ItemStyle Width="4%"  ForeColor="#595d5a" />
            </asp:TemplateField> 
               <asp:TemplateField HeaderText="Ʒ��">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox3" runat="server" Text='<%#Eval ("Ʒ��") %>'  CssClass="c14071609"></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="5%" />
                 <ItemStyle Width="5%"  ForeColor="#595d5a" />
            </asp:TemplateField> 
                    
               <asp:TemplateField HeaderText="δ��������">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox9" runat="server" Text='<%#Eval ("δ��������") %>'   CssClass ="c14071615"></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="4%" />
                 <ItemStyle Width="4%"  ForeColor="#595d5a"/>
            </asp:TemplateField> 
                      <asp:TemplateField HeaderText="�ۼ���������"   >
                <ItemTemplate >
                 <asp:TextBox ID="TextBox10" runat="server" Text='<%#Eval ("�ۼ���������") %>'  CssClass ="c14071615"></asp:TextBox>                     
                </ItemTemplate>
                    <HeaderStyle Width="5%" />
                 <ItemStyle Width="5%"  ForeColor="#595d5a"/>
            </asp:TemplateField> 
                     <asp:TemplateField HeaderText="��������">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox11" runat="server" Text='<%#Eval ("��������") %>'  CssClass ="c13112302"></asp:TextBox>                     
                </ItemTemplate>
              <HeaderStyle Width="4%" />
                 <ItemStyle Width="4%"  ForeColor="#595d5a"/>
            </asp:TemplateField> 
                <asp:TemplateField HeaderText="�ֿ�">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox12" runat="server" Text='<%#Eval ("�ֿ�") %>'  CssClass="c14071617"></asp:TextBox>
                 <a  href="javascript:f13100202('TextBox10','<%#Eval ("���") %>');">ѡ�� </a>                     
                </ItemTemplate>
               <HeaderStyle Width="6%" />
                 <ItemStyle Width="6%"  ForeColor="#595d5a"/>
            </asp:TemplateField> 
                <asp:TemplateField HeaderText="����">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox13" runat="server" Text='<%#Eval ("����") %>' CssClass ="c13112302"></asp:TextBox>                     
                </ItemTemplate>
               <HeaderStyle Width="5%" />
                 <ItemStyle Width="5%"  ForeColor="#595d5a"/>
            </asp:TemplateField> 
                          <asp:TemplateField HeaderText="�������">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox14" runat="server" Text='<%#Eval ("�������") %>'     CssClass ="c14071615"></asp:TextBox>                     
                </ItemTemplate>
                <HeaderStyle Width="4%" />
                 <ItemStyle Width="4%"  ForeColor="#595d5a"/>
            </asp:TemplateField> 
                        <asp:TemplateField HeaderText="���������ۼ���������">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox15" runat="server" Text='<%#Eval ("���������ۼ���������") %>'   CssClass ="c14071615"></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="8%" />
                 <ItemStyle Width="8%"  ForeColor="#595d5a"/>
            </asp:TemplateField> 
                                 <asp:TemplateField HeaderText="��ע">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox16" runat="server"     CssClass ="c14071615"></asp:TextBox>                     
                </ItemTemplate>
                <HeaderStyle Width="4%" />
                 <ItemStyle Width="4%"  ForeColor="#595d5a"/>
            </asp:TemplateField>
               <asp:TemplateField HeaderText="Free����">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox17" runat="server"   CssClass ="c14071615"></asp:TextBox>                     
                </ItemTemplate>
                  <HeaderStyle Width="3%" />
                 <ItemStyle Width="3%"  ForeColor="#595d5a"/>
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="���">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox4" runat="server" Text='<%#Eval ("���") %>'  CssClass="c14071609"></asp:TextBox>                     
                </ItemTemplate>
             <HeaderStyle Width="5%" />
                 <ItemStyle Width="5%"  ForeColor="#595d5a" />
            </asp:TemplateField> 
         
        <asp:TemplateField HeaderText="�ͻ��Ϻ�">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox100" runat="server" Text='<%#Eval ("�ͻ��Ϻ�") %>'   CssClass="c14071609"></asp:TextBox>                     
                </ItemTemplate>
                  <HeaderStyle Width="4%" />
                 <ItemStyle Width="4%"  ForeColor="#595d5a" />
            </asp:TemplateField> 
                    <asp:TemplateField HeaderText="��������">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox6" runat="server" Text='<%#Eval ("��������") %>'  CssClass ="c14071615"></asp:TextBox>                     
                </ItemTemplate>
                   <HeaderStyle Width="4%" />
                 <ItemStyle Width="4%"  ForeColor="#595d5a"/>
            </asp:TemplateField>
                             <asp:TemplateField HeaderText="���۵���">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox7" runat="server" Text='<%#Eval ("���۵���") %>'  CssClass ="c14071615"></asp:TextBox>                     
                </ItemTemplate>
                    <HeaderStyle Width="4%" />
                 <ItemStyle Width="4%"  ForeColor="#595d5a"/>
            </asp:TemplateField>
                             <asp:TemplateField HeaderText="˰��">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox8" runat="server" Text='<%#Eval ("˰��") %>' CssClass ="c14071615"></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="3%" />
                 <ItemStyle Width="3%"  ForeColor="#595d5a"/>
            </asp:TemplateField>
                    </Columns>
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" Font-Bold="False" />   
                </asp:GridView>
                </div>
    <div id ="i13111501" class ="c13101902">
                                 <div class="c13102907" id ="Div16">
                                 </div>
      <div class="c14112014" id ="Div7">
          �ϼ�δ˰���</div>
     <div class="c13101904" id ="Div8">
        <input id="Text7" type="text"  runat="server"    class="c13102908"/></div>
          <div class="c14112014" id ="Div12">
              �ϼ�˰��</div>
     <div class="c13101904" id ="Div13">
   <input id="Text8" type="text"  runat ="server" class="c13102908" /> 
         </div>
                  <div class="c14112014" id ="Div11">
                      �ϼƺ�˰���</div>
     <div class="c13101904" id ="Div14">
   <input id="Text9" type="text"  runat ="server" class ="c13102908"  /> 
         </div>
           </div>         
            <div id="i13103002" class ="c13102201">
        <asp:GridView ID="GridView3" runat="server" Width="65%" 
                    AllowSorting="True"   
                    onrowdatabound="GridView3_RowDataBound" 
                        onselectedindexchanged="GridView3_SelectedIndexChanged" 
                        AutoGenerateColumns="False" style="margin-left: 8px" PageSize="15" 
                        CssClass ="c13102001"
                   >
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns > 
              
                                     <asp:BoundField DataField="FLKEY" HeaderText="����"  Visible ="false"  >
                              <ItemStyle Width="40px"  ForeColor="#595d5a"/>
                                    <HeaderStyle Width="40px" HorizontalAlign="Center" />
                          </asp:BoundField>

          <asp:BoundField DataField="WAREID" HeaderText="ID" >
                              <ItemStyle Width="80px"  ForeColor="#595d5a"/>
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                <asp:TemplateField HeaderText="����">
                <ItemTemplate >
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Select" 
                        Text='<%# Bind("OLDFILENAME") %>'></asp:LinkButton>                     
                </ItemTemplate>
                 <HeaderStyle Width="500px" />
                 <ItemStyle Width="500px"  ForeColor="#595d5a"/>
            </asp:TemplateField>  
                      
         
           
                    </Columns>
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" Font-Bold="False" />   
                </asp:GridView>
                   
                </div>
                <div id="i13103001" class ="c13102201">
          
                    <asp:GridView ID="GridView2" runat="server"  CssClass ="c13112502"   >
                          <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    </asp:GridView>
                </div>
      <script type ="text/javascript" >
          window.onload = function onload1() {
              var Invocation = document.getElementById("hint").value;
              var Invocation1 = document.getElementById("x").value;
              var Invocation2 = document.getElementById("ControlFileDisplay").value;
              var Invocation3 = document.getElementById("x2").value;
              if (Invocation != "") {
                  document.getElementById("i13102301").style.display = "block";
                  document.all("prompt").innerText = Invocation;
              }
              else {
                  document.getElementById("i13102301").style.display = "none";
              }
              if (Invocation1 != "") {
                  document.getElementById("i13103001").style.display = "block";
                
              }
              else {
                  document.getElementById("i13103001").style.display = "none";
                
              }
              if (Invocation2 != "") {
                  document.getElementById("i13103002").style.display = "block";

              }
              else {
                  document.getElementById("i13103002").style.display = "none";
              }
              if (Invocation3 != "") {

                  document.getElementById("i13111001").style.display = "block";
                  document.getElementById("i13111501").style.display = "block";

              }
              else {

                  document.getElementById("i13111001").style.display = "none";
                  document.getElementById("i13111501").style.display = "none";

              }
          }

          function f13100202(obj, obj1) {
              var dlgResult;
              if (obj == "Text2") {
                  //alert(document.getElementById("cuid").value);
                  //alert(document.getElementById("emid").value);
                  dlgResult = window.showModalDialog("../SellManage/order.aspx?cuid=" + document.getElementById("cuid").value + "&emid=" + document.getElementById("emid").value + "", window, "dialogWidth:970px; dialogHeight:490px; status:0");
                  if (dlgResult != undefined) {

                      document.getElementById("Text2").value = dlgResult[0];
                      document.getElementById("Text5").value = dlgResult[1];
                      document.getElementById("Text6").value = dlgResult[2];
                      document.getElementById("Text10").value = dlgResult[3];
                      document.getElementById("Text11").value = dlgResult[4];
                  
             

                  }
              }
              else if (obj == "TextBox10") {
              dlgResult = window.showModalDialog("../StockManage/StorageCase.aspx?emid=" + document.getElementById("emid").value + "", window, "dialogWidth:970px; dialogHeight:490px; status:0");

                  if (dlgResult != undefined) {

                      var table = document.getElementById('<%=GridView1.ClientID%>');
                      var tr = table.getElementsByTagName("tr");
                      for (i = 1; i < tr.length; i++) {
                          if (obj1 == i) {
                              var v5 = tr[i].getElementsByTagName("td")[8].getElementsByTagName("input")[0];
                              var v6 = tr[i].getElementsByTagName("td")[9].getElementsByTagName("input")[0];
                              var v7 = tr[i].getElementsByTagName("td")[10].getElementsByTagName("input")[0];
                              v5.value = dlgResult[0];
                              v6.value = dlgResult[1];
                              v7.value = dlgResult[2];
                              break;
                          }
                      }


                  }

              }
              else if (obj == "Text3") {
                  dlgResult = window.showModalDialog("../WDate.aspx", window, "dialogWidth:160px; dialogHeight:240px; status:0;");
                  if (dlgResult != undefined) {


                      document.getElementById("Text3").value = dlgResult;
                  }

              }
              else if (obj == "Text5") {
              dlgResult = window.showModalDialog("../sellmanage/customerinfo.aspx?emid=" + document.getElementById("emid").value + "", window, "dialogWidth:970px; dialogHeight:490px; status:0");
                  if (dlgResult != undefined) {

                      document.getElementById("cuid").value = dlgResult[0];
                      document.getElementById("Text5").value = dlgResult[1];


                  }
              }
              else if (obj == "Text11") {
              dlgResult = window.showModalDialog("../BASEINFO/CompanyInfoPS.aspx?emid=" + document.getElementById("emid").value + "", window, "dialogWidth:970px; dialogHeight:490px; status:0");
                  if (dlgResult != undefined) {

                      document.getElementById("CUKEY").value = dlgResult[0];
                      document.getElementById("Text6").value = dlgResult[1];
                      document.getElementById("Text10").value = dlgResult[2];
                      document.getElementById("Text11").value = dlgResult[3];

                  }
              }
              else {
                  dlgResult = window.showModalDialog("../BaseInfo/EMPLOYEEINFO.aspx?emid=" + document.getElementById("emid").value + "", window, "dialogWidth:970px; dialogHeight:490px; status:0;");
                  if (dlgResult != undefined) {

                      document.getElementById("Text4").value = dlgResult[0];
                      document.all("Label1").innerText = dlgResult[1];
                  }

              }
          }
          function enter2tab(e) {
              if (window.event.keyCode == 13) window.event.keyCode = 9
          }
          document.onkeydown = enter2tab;
          
        </script>

    </form>
</body>
</html>