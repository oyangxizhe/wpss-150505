<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchaseT.aspx.cs" Inherits="WPSS.PurchaseManage.PurchaseT" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>�༭�ɹ���</title>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" /> 
<meta name ="Description" content ="���������ϵͳ" />
<meta name ="keywords" content ="���������ϵͳ,������������,ERP,С΢��ҵ����ϵͳ,ϣ�����" />
       <link href ="../Css/SSBase.css"  type ="text/css" rel ="Stylesheet" />
       <link href ="../Css/S131017.css"  type ="text/css" rel ="Stylesheet" />

    </head>
<body >
   <form id="form1" runat="server">
   <input id="hint" type="hidden"  runat="server" />
      <input id="x" type="hidden"  runat="server" />
       <input id="x1" type="hidden"  runat="server" />
       <input id="pur" type="hidden"  runat="server" />
         <input id="RDID" type="hidden"  runat="server" />
            <input id="COKEY" type="hidden"  runat="server" />
              <input id="emid" type="hidden"  runat="server" />
                <div class ="c13101905">
      <div class="c13101906" id ="Div9">
          �༭�ɹ��� </div>
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
       <asp:Label ID="Label2" runat="server" Text="(����)"></asp:Label>
                  
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
   <asp:Label ID="Label3" runat="server" Text="(����)"></asp:Label>
             
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
                <div class="c13110507" id ="Div30">
                <span class="c13110503" id ="Span7">
    <asp:LinkButton ID="btnReconcile" runat="server" onclick="btnReconcile_Click" CssClass ="">ȷ�϶���</asp:LinkButton>
    </span> 
   </div>
          
                 <div class="c13110510" id ="Div31">
   <span class="c13110511" id ="Span8">
                 
          </span>
       </div>
                       <div class="c13110507" id ="Div32">
                <span class="c13110503" id ="Span9">
    <asp:LinkButton ID="btnReductionReconcil" runat="server" onclick="btnReductionReconcile_Click" CssClass ="">���ʻ�ԭ</asp:LinkButton>
    </span> 
   </div>
                 <div class="c13110510" id ="Div50">
   <span class="c13110511" id ="Span13">
                 
          </span>
       </div>
                       <div class="c13110507" id ="Div51">
                <span class="c13110503" id ="Span14">
    <asp:LinkButton ID="btnForceClose" runat="server" onclick=" btnForceClose_Click" CssClass ="">ǿ�ƽ᰸</asp:LinkButton>
    </span> 
   </div>
   
          
                 <div class="c13110510" id ="Div33">
   <span class="c13110511" id ="Span10">
                 
          </span>
       </div>
                      <div class="c13110507" id ="Div48">
                  <span class="c13110503" id ="Span11">
     <asp:ImageButton ID="btnPrint" 
                 runat="server" ImageUrl="~/Image/btnPrint.png" Width="60px" 
                      onclick="btnPrint_Click" />
          </span>
   </div>
                 <div class="c13110510" id ="Div49">
   <span class="c13110511" id ="Span12">
                     (��ӡ)
          </span>
       </div>
    </div>
<div  id="i13102301" class ="c13102101">
<span  class ="c13102102"><asp:Label ID="prompt" runat="server"  ForeColor="#f80707"></asp:Label></span>
</div> 
  <div class ="c13101902">
      <div class="c13101903" id ="Div24">
          �ɹ�����</div>
     <div class="c13111503" id ="Div25">
<input id="Text1" type="text"  runat="server"   readonly ="readonly" class="c14112011"/> 
         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="Text1" Text="����" runat="server" /></div>
         <div class="c13101903" id ="Div26">
             ��Ӧ�̴���</div>
     <div class="c13102401" id ="Div27">
   <input id="Text2" type="text"  runat ="server"  class ="c14112009"  />
    <span style =" margin-left :5px; margin-right :2px;"><a  href="javascript:f13100202('Text2','');"> 
         ѡ��</a></span>
       </div>
                    <div class="c13101903" id ="Div28">
                        �ɹ�����</div>
     <div class="c14112005" id ="Div29">
         <input id="Text3" type="text" runat="server" onclick ="f13100202('Text3')" readonly="readonly" class ="c13110901"/>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="Text3" Text="����" runat="server" />
         </div>
           </div>
           
  <div class ="c13101902">
                      <div class="c13101903" id ="Div2">
                          �ɹ�Ա����</div>
     <div class="c13111503" id ="Div4">
         <input id="Text4" type="text" runat="server"  class ="c14112009" /> 
         <span style =" margin-left :5px;"><a  href="javascript:f13100202('Text4','');"> 
         ѡ��</a></span>
               <asp:Label ID="Label1" runat="server" Text="" ></asp:Label>
         </div>
         <div class="c13101903" id ="Div5">
             ��Ӧ������</div>
     <div class="c13102401" id ="Div6">
   <input id="Text5" type="text"  runat ="server"  class ="c14111909"  /></div>
                        <div class="c13101903" id ="Div38">
                            ��ϵ��</div>
     <div class="c14112005" id ="Div39">
         <input id="Text10" type="text" runat="server"  class ="c14112007" /> 
         </div>
           </div>
       <div class ="c13101902">
      <div class="c13101903" id ="Div1">
                   ��ַ</div>
     <div class="c14032101" id ="Div3">
           <input id="Text6" type="text"  runat="server"  readonly ="readonly" class="c14112004"/></div>
                  <div class="c13101903" id ="Div40">
                      ��ϵ�绰</div>
     <div class="c14112005" id ="Div41">
   <input id="Text11" type="text"  runat ="server"  class ="c14112007"  /></div>
           </div>
           
           <div class ="c13101902">
                      <div class="c13101903" id ="Div15">
                          �ջ���</div>
     <div class="c13111503" id ="Div21">
         <input id="Text12" type="text" runat="server"  readonly ="readonly" class ="c14111912"/> 
              <span style =" margin-left :5px;"><a  href="javascript:f13100202('Text12','');"> 
         ѡ��</a></span>
         </div>
         <div class="c13101903" id ="Div34">
             �ջ���ַ</div>
     <div class="c13102402" id ="Div37">
   <input id="Text13" type="text"  runat ="server"  class ="c14112008"  /></div>
  
           </div>
           <div class ="c13101902">
                      <div class="c13101903" id ="Div42">
                          ��˾����</div>
     <div class="c13111503" id ="Div43">
         <input id="Text14" type="text" runat="server" class ="c14032102" /> 
         </div>
         <div class="c13101903" id ="Div44">
             ��ϵ��</div>
     <div class="c14112006" id ="Div45">
   <input id="Text15" type="text"  runat ="server"  readonly ="readonly" class ="c14032103"  />
           <span style =" margin-left :5px;"><a  href="javascript:f13100202('Text15','');"> 
         ѡ��</a></span>
   </div>
                        <div class="c13101903" id ="Div46">
                            �绰</div>
     <div class="c14112005" id ="Div47">
         <input id="Text16" type="text" runat="server"  class ="c14112007"/> 
         </div>
           </div>
           <div class ="c13111601">
       <div class="c13101903" id ="Div35">
           ���Ʒ����Ϣ</div>
     <div class="c13111503" id ="Div36">
      <span style="color :#990033">(˰������17��17����)</span>
</div>
 
         
           </div>
<div class ="c13111602">
             
          
            <asp:GridView ID="GridView1" runat="server" 
                    AllowSorting="True"   
                    onrowdatabound="GridView1_RowDataBound" 
                        AutoGenerateColumns="False"  PageSize="15" 
                             CssClass ="c13122602" onselectedindexchanged="GridView1_SelectedIndexChanged"
                   >
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns > 
           <asp:TemplateField HeaderText="ID" >
                <ItemTemplate >
                                <asp:TextBox ID="TextBox1" runat="server"  Text='<%#Eval ("Ʒ��") %>' CssClass ="c14071603"     ></asp:TextBox>   
                                 <a  href="javascript:f13100202('TextBox1','<%#Eval ("���") %>');"> ѡ��</a> 
                </ItemTemplate>
                 <HeaderStyle Width="11%" />
                 <ItemStyle Width="11%"  ForeColor="#595d5a" />
            </asp:TemplateField> 
           <asp:TemplateField HeaderText="�Ϻ�">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox2" runat="server"  Text='<%#Eval ("�Ϻ�") %>'  CssClass ="c13120501"  ></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="8%" />
                 <ItemStyle Width="8%"  ForeColor="#595d5a"/>
            </asp:TemplateField>
                    <asp:TemplateField HeaderText="Ʒ��">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox3" runat="server"  Text='<%#Eval ("Ʒ��") %>'  CssClass ="c13120501" ></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="9%" />
                 <ItemStyle Width="9%"  ForeColor="#595d5a"/>
            </asp:TemplateField> 
         
                          <asp:TemplateField HeaderText="�ͻ��Ϻ�">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox4" runat="server"  Text='<%#Eval ("�ͻ��Ϻ�") %>'  CssClass ="c13120501"></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="7%" />
                 <ItemStyle Width="7%"  ForeColor="#595d5a"/>
            </asp:TemplateField>
  
      
                    <asp:TemplateField HeaderText="�ɹ�����">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox5" runat="server" Text='<%#Eval ("�ɹ�����") %>' CssClass ="c13112302"  ></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="6%" />
                 <ItemStyle Width="6%"  ForeColor="#595d5a"/>
            </asp:TemplateField>
               <asp:TemplateField HeaderText="�ɹ�����">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox6" runat="server" CssClass ="c13112302"  ></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="6%" />
                 <ItemStyle Width="6%"  ForeColor="#595d5a"/>
            </asp:TemplateField> 
                     <asp:TemplateField HeaderText="˰��">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox7" runat="server"  Text='<%#Eval ("˰��") %>' CssClass ="c13112302" ></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="4%" />
                 <ItemStyle Width="4%"  ForeColor="#595d5a"/>
            </asp:TemplateField> 
                     <asp:TemplateField HeaderText="��������">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox8" runat="server"  Text='<%#Eval ("��������") %>' CssClass ="c14071603"></asp:TextBox>      
                    <a  href="javascript:f13100202('TextBox8','<%#Eval ("���") %>');"> ѡ��</a>                
                </ItemTemplate>
                 <HeaderStyle Width="11%" />
                 <ItemStyle Width="11%"  ForeColor="#595d5a"/>
            </asp:TemplateField> 
                    <asp:TemplateField HeaderText="��ע">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox9" runat="server"  Text='<%#Eval ("��ע") %>'   CssClass ="c13120501"></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="15%" />
                 <ItemStyle Width="15%"  ForeColor="#595d5a"/>
            </asp:TemplateField> 
                    </Columns>
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" Font-Bold="False" />   
                </asp:GridView>
                </div>


 <div id="i13103001" class ="c13102201">
        <asp:GridView ID="GridView2" runat="server" 
                    onrowdeleting="GridView2_RowDeleting" 
                    AllowSorting="True"   
                    onrowdatabound="GridView2_RowDataBound" 
                        AutoGenerateColumns="False" style="margin-left: 8px" PageSize="15" 
                        CssClass ="c13112304"
                   >
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns > 
                            <asp:TemplateField HeaderText="ɾ��" >
                <ItemTemplate >
                    <asp:LinkButton ID="LinkButton2" runat="server" 
                        OnClientClick="return confirm('��ȷ��ɾ���ü�¼��?');" Text="ɾ��"  CommandName ="delete" ></asp:LinkButton>                     
                </ItemTemplate>
                 <HeaderStyle Width="40px" />
                 <ItemStyle Width="40px"  />
            </asp:TemplateField>
                                     <asp:BoundField DataField="����" HeaderText="����"  Visible ="false"  >
                              <ItemStyle Width="40px"  ForeColor="#595d5a"/>
                                    <HeaderStyle Width="40px" HorizontalAlign="Center" />
                          </asp:BoundField>
                          <asp:BoundField DataField="���" HeaderText="���" >
                              <ItemStyle Width="40px"  ForeColor="#595d5a"/>
                                    <HeaderStyle Width="40px" HorizontalAlign="Center" />
                          </asp:BoundField>
          <asp:BoundField DataField="Ʒ��" HeaderText="ID" >
                              <ItemStyle Width="80px"  ForeColor="#595d5a"/>
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
              <asp:BoundField DataField="�Ϻ�" HeaderText="�Ϻ�" >
                              <ItemStyle Width="80px"  ForeColor="#595d5a"/>
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
            <asp:BoundField DataField="Ʒ��" HeaderText="Ʒ��" >
                              <ItemStyle Width="200px"  ForeColor="#595d5a"/>
                                    <HeaderStyle Width="200px" HorizontalAlign="Center" />
                          </asp:BoundField> 
       <asp:BoundField DataField="�ͻ��Ϻ�" HeaderText="�ͻ��Ϻ�" >
                              <ItemStyle Width="120px"  ForeColor="#595d5a"/>
                                    <HeaderStyle Width="120px" HorizontalAlign="Center" />
                          </asp:BoundField>
      
            <asp:BoundField DataField="�ɹ�����" HeaderText="�ɹ�����" >
                              <ItemStyle Width="80px"  ForeColor="#595d5a"  HorizontalAlign="Right" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                          
            <asp:BoundField DataField="�ɹ�����" HeaderText="�ɹ�����" >
                              <ItemStyle Width="80px"  ForeColor="#595d5a" HorizontalAlign="Right" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
             <asp:BoundField DataField="˰��" HeaderText="˰��" >
                              <ItemStyle Width="40px"  ForeColor="#595d5a" HorizontalAlign="Right" />
                                    <HeaderStyle Width="40px" HorizontalAlign="Center" />
                          </asp:BoundField>
           <asp:BoundField DataField="δ˰���" HeaderText="δ˰���"    DataFormatString="{0:0.00}"  >
                              <ItemStyle Width="80px"  ForeColor="#595d5a" HorizontalAlign="Right" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
             <asp:BoundField DataField="˰��" HeaderText="˰��"   DataFormatString="{0:0.00}">
                              <ItemStyle Width="80px"  ForeColor="#595d5a" HorizontalAlign="Right" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
            <asp:BoundField DataField="��˰���" HeaderText="��˰���"   DataFormatString="{0:0.00}">
                              <ItemStyle Width="80px"  ForeColor="#595d5a" HorizontalAlign="Right" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
             <asp:BoundField DataField="��������" HeaderText="��������"   >
                              <ItemStyle Width="80px"  ForeColor="#595d5a" HorizontalAlign="Center" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                              <asp:BoundField DataField="��ע" HeaderText="��ע"   >
                              <ItemStyle Width="200px"  ForeColor="#595d5a" HorizontalAlign="Center" />
                                    <HeaderStyle Width="200px" HorizontalAlign="Center" />
                          </asp:BoundField>
                      
                    </Columns>
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" Font-Bold="False" />   
                </asp:GridView>
                   
                </div>
                            <div class ="c13101902">
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
      <script type ="text/javascript" >
          window.onload = function onload1() {
              var Invocation = document.getElementById("hint").value;
              var Invocation1 = document.getElementById("x").value;
              var Invocation2 = document.getElementById("x1").value;
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
          }

          function f13100202(obj, obj1) {
              var dlgResult;
              if (obj == "Text2") {
                  dlgResult = window.showModalDialog("../PurchaseManage/Supplierinfo.aspx?emid="+document .getElementById ("emid").value +"", window, "dialogWidth:970px; dialogHeight:490px; status:0");
                  if (dlgResult != undefined) {

                      document.getElementById("Text2").value = dlgResult[0];
                      document.getElementById("Text5").value = dlgResult[1];
                      document.getElementById("Text6").value = dlgResult[2];
                      document.getElementById("Text10").value = dlgResult[3];
                      document.getElementById("Text11").value = dlgResult[4];
                   
                  }
              }
              else if (obj == "TextBox1") {
              dlgResult = window.showModalDialog("../BaseInfo/WareinfoP.aspx?emid=" + document.getElementById("emid").value + "", window, "dialogWidth:970px; dialogHeight:490px; status:0");

                  if (dlgResult != undefined) {

                      var table = document.getElementById('<%=GridView1.ClientID%>');
                      var tr = table.getElementsByTagName("tr");
                      for (i = 1; i < tr.length; i++) {
                          if (obj1 == i) {
                              var v1 = tr[i].getElementsByTagName("td")[0].getElementsByTagName("input")[0]; //��ȡgirdview���1��TextBox��ֵ
                              var v2 = tr[i].getElementsByTagName("td")[1].getElementsByTagName("input")[0];
                              var v3 = tr[i].getElementsByTagName("td")[2].getElementsByTagName("input")[0];
                              var v4 = tr[i].getElementsByTagName("td")[3].getElementsByTagName("input")[0];
                              var v5 = tr[i].getElementsByTagName("td")[5].getElementsByTagName("input")[0];
                              var v8 = tr[i].getElementsByTagName("td")[8].getElementsByTagName("input")[0];
                         
                              v1.value = dlgResult[0];
                              v2.value = dlgResult[1];
                              v3.value = dlgResult[2];
                              v4.value = dlgResult[3];
                              v5.value = dlgResult[5];
                              v8.value = dlgResult[7];

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
              else if (obj == "TextBox8") {
              dlgResult = window.showModalDialog("../WDate.aspx", window, "dialogWidth:160px; dialogHeight:240px; status:0;");
                  if (dlgResult != undefined) {

                       table = document.getElementById('<%=GridView1.ClientID%>');
                       tr = table.getElementsByTagName("tr");
                      for (i = 1; i < tr.length; i++) {
                          if (obj1 == i) {
                              v1 = tr[i].getElementsByTagName("td")[7].getElementsByTagName("input")[0]; //��ȡgirdview���1��TextBox��ֵ
                           
                              v1.value = dlgResult;
                        

                              break;
                          }
                      }


                  }

              }
             else  if (obj == "Text12") {
             dlgResult = window.showModalDialog("../BASEINFO/ReceivingAndDelivery.aspx?emid=" + document.getElementById("emid").value + "", window, "dialogWidth:970px; dialogHeight:490px; status:0");
                  if (dlgResult != undefined) {

                      document.getElementById("RDID").value = dlgResult[0];
                      document.getElementById("Text12").value = dlgResult[2];
                      document.getElementById("Text13").value = dlgResult[4];
                      

                  }
              }
              else if (obj == "Text15") {
              dlgResult = window.showModalDialog("../BASEINFO/companyinfox.aspx?emid=" + document.getElementById("emid").value + "", window, "dialogWidth:970px; dialogHeight:490px; status:0");
                  if (dlgResult != undefined) {

                      document.getElementById("COKEY").value = dlgResult[0];
                      document.getElementById("Text14").value = dlgResult[1];
                      document.getElementById("Text15").value = dlgResult[2];
                      document.getElementById("Text16").value = dlgResult[3];


                  }
              }
              else {
                  dlgResult = window.showModalDialog("../BaseInfo/EMPLOYEEINFO.aspx?emid="+document .getElementById ("emid").value +"", window, "dialogWidth:970px; dialogHeight:490px; status:0;");
                  if (dlgResult != undefined) {

                      document.getElementById("Text4").value = dlgResult[0];
                      document.all("Label1").innerText =dlgResult[1];
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