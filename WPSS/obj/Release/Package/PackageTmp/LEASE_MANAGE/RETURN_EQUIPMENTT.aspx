<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RETURN_EQUIPMENTT.aspx.cs" Inherits="WPSS.LEASE_MANAGE.RETURN_EQUIPMENTT" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>�༭�黹��ҵ��Ϣ</title>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" /> 
<meta name ="Description" content ="ERP����ϵͳ" />
<meta name ="keywords" content ="ERP����ϵͳ,ERP�������,ERP,С΢��ҵ����ϵͳ,ϣ�����" />
       <link href ="../Css/SSBase.css"  type ="text/css" rel ="Stylesheet" />
       <link href ="../Css/S131017.css"  type ="text/css" rel ="Stylesheet" />
    </head>
<body >

   <form id="form1" runat="server">
    <input id="cuid" type="hidden"  runat="server" />
   <input id="hint" type="hidden"  runat="server" />
      <input id="x" type="hidden"  runat="server" />
       <input id="ControlFileDisplay" type="hidden"  runat="server" />
        <input id="x2" type="hidden"  runat="server" />
         <input id="CUKEY" type="hidden"  runat="server" />
         <input id="emid" type="hidden"  runat="server" />
                <div class ="c13101905">
      <div class="c13101906" id ="Div9">
          &gt;�༭�黹��ҵ </div>
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
    </div>
<div  id="i13102301" class ="c13102101">
<span  class ="c13102102"><asp:Label ID="prompt" runat="server"  ForeColor="#f80707"></asp:Label></span>
</div> 
  <div class ="c13101902">
      <div class="c13101903" id ="Div24">
          �黹����</div>
     <div class="c13102904" id ="Div25">
<input id="Text1" type="text"  runat="server"   readonly ="readonly"   class="c14031401" /> 
         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="Text1" Text="����" runat="server" /></div>
                            <div class="c13101903" id ="Div28">
                                ��������</div>
       <div class="c13102904" id ="Div11">
         <input id="Text3" type="text" runat="server" onclick ="f13100202('Text3')" class ="c14031405"/> 
       <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="Text3" Text="����" runat="server" />
         </div>
                               <div class="c13101903" id ="Div2">
                                   �黹Ա����</div>                        
<div class="c14120312" id ="Div4">
<input id="Text4" type="text" runat="server" class ="c14120310" />
<span style =" margin-left :0px;"><a  href="javascript:f13100202('Text4','');">ѡ�� </a> </span> 
 <span  style =" margin-left :0px"><asp:Label ID="Label1" runat="server" Text="" ></asp:Label></span>
</div>  


           </div>
           <div class ="c13101902">
      <div class="c13101903" id ="Div29">
          �������</div>
     <div class="c13110801" id ="Div30">
<input id="Text8" type="text"  runat="server"    class ="c15050902" /> 
  <span style =" margin-left :5px; margin-right :5px;"><a  href="javascript:f13100202('Text8','');">
         ѡ�� </a></span> 
  <asp:LinkButton 
             ID="btnSure" runat="server" onclick="btnSure_Click"  
            >ȷ��</asp:LinkButton>
        </div>
      
 
           </div>
           <div class ="c13101902">
      <div class="c13101903" id ="Div5">
          �ͻ�����</div>
     <div class="c13102904" id ="Div6">
<input id="Text5" type="text"  runat="server"    class ="c14031401" /> 
  <span style =" margin-left :5px"></span> 
        </div>
                            <div class="c13101903" id ="Div7">
                                �ͻ�����</div>
       <div class="c13102904" id ="Div8">
         <input id="Text6" type="text" runat="server" onclick ="f13100202('Text3')" class ="c14031401"/> 
   
         </div>
                               <div class="c13101903" id ="Div12">
                                   �绰</div>                        
<div class="c14120312" id ="Div13">
<input id="Text7" type="text" runat="server"  class ="c14031401" />

</div>
           </div>
<div  class ="c14062101" id="i15051001">
           <asp:GridView ID="GridView1" runat="server" 
                    AllowSorting="True"   
                    onrowdatabound="GridView1_RowDataBound" 
                        AutoGenerateColumns="False" 
                        CssClass ="c15050903"  onrowdeleting="GridView1_RowDeleting" 
                   >
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns > 
                       <asp:TemplateField HeaderText="ɾ��" >
                <ItemTemplate >
                    <asp:LinkButton ID="LinkButton2" runat="server" 
                        OnClientClick="return confirm('��ȷ��ɾ���ü�¼��?');" Text="ɾ��"  CommandName ="delete" ></asp:LinkButton>                     
                </ItemTemplate>
                 <HeaderStyle Width="1%" />
                 <ItemStyle Width="1%"  />
            </asp:TemplateField>
           
            
             
                    <asp:TemplateField HeaderText="Ʒ��">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox4" runat="server"  Text='<%#Eval ("Ʒ��") %>'   CssClass="c14071609" ></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="2%" />
                 <ItemStyle Width="2%"  ForeColor="#595d5a"/>
            </asp:TemplateField> 
              <asp:TemplateField HeaderText="�������">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox71" runat="server" Text='<%#Eval ("�������") %>' ReadOnly ="true" CssClass="c14071609"></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="2%" />
                 <ItemStyle Width="2%"  ForeColor="#595d5a"/>
            </asp:TemplateField> 
             <asp:TemplateField HeaderText="δ�黹��">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox7" runat="server" Text='<%#Eval ("δ�黹����") %>' ReadOnly ="true" CssClass ="c14071615"></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="2%" />
                 <ItemStyle Width="2%"  ForeColor="#595d5a"/>
            </asp:TemplateField> 
                      <asp:TemplateField HeaderText="�ۼƹ黹">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox8" runat="server" Text='<%#Eval ("�ۼƹ黹����") %>' ReadOnly ="true" CssClass ="c14071615"></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="2%" />
                 <ItemStyle Width="2%"  ForeColor="#595d5a"/>
            </asp:TemplateField> 
                     <asp:TemplateField HeaderText="�黹����">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox9" runat="server" Text='<%#Eval ("�黹����") %>'  ReadOnly ="true"  CssClass ="c13112302"></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="2%" />
                 <ItemStyle Width="2%"  ForeColor="#595d5a"/>
            </asp:TemplateField> 
                <asp:TemplateField HeaderText="�ֿ�">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox10" runat="server" Text='<%#Eval ("�ֿ�") %>'   CssClass="c14071617"></asp:TextBox>
                 <a  href="javascript:f13100202('TextBox10','<%#Eval ("���") %>');">ѡ�� </a>                     
                </ItemTemplate>
                 <HeaderStyle Width="3%" />
                 <ItemStyle Width="3%"  ForeColor="#595d5a"/>
            </asp:TemplateField> 
                              <asp:TemplateField HeaderText="����">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox11" runat="server" Text='<%#Eval ("����") %>' CssClass="c14112003"></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="2%" />
                 <ItemStyle Width="2%"  ForeColor="#595d5a"/>
            </asp:TemplateField> 
             <asp:TemplateField HeaderText="�����">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox72" runat="server" Text='<%#Eval ("�����") %>' ReadOnly ="true" CssClass ="c14071615"></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="2%" />
                 <ItemStyle Width="2%"  ForeColor="#595d5a"/>
            </asp:TemplateField> 
            
                       <asp:TemplateField HeaderText="�黹����">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox74" runat="server"  Text='<%#Eval ("�黹����") %>' CssClass ="c15051001"></asp:TextBox>      
                    <a  href="javascript:f13100202('TextBox74','<%#Eval ("���") %>');"> ѡ��</a>                
                </ItemTemplate>
                   <HeaderStyle Width="4%"  />
                 <ItemStyle Width="4%"   ForeColor="#595d5a" />
            </asp:TemplateField>
             <asp:TemplateField HeaderText="��������">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox75" runat="server"  ReadOnly ="true" Text='<%#Eval ("��������") %>' CssClass ="c14071615"></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="2%" />
                 <ItemStyle Width="2%"  ForeColor="#595d5a"/>
            </asp:TemplateField> 
            
             <asp:TemplateField HeaderText="���">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox76" runat="server"  ReadOnly ="true" Text='<%#Eval ("���") %>' CssClass ="c14071615"></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="2%" />
                 <ItemStyle Width="2%"  ForeColor="#595d5a"/>
            </asp:TemplateField> 
               <asp:TemplateField HeaderText="Ѻ��">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox73" runat="server" Text='<%#Eval ("Ѻ��") %>' ReadOnly ="true" CssClass ="c14071615"></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="2%" />
                 <ItemStyle Width="2%"  ForeColor="#595d5a"/>
            </asp:TemplateField> 
               <asp:TemplateField HeaderText="�˻�Ѻ��">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox77" runat="server"  ReadOnly ="true"  Text='<%#Eval ("�˻�Ѻ��") %>' CssClass ="c14071615"></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="2%" />
                 <ItemStyle Width="2%"  ForeColor="#595d5a"/>
            </asp:TemplateField> 
              
                        <asp:TemplateField HeaderText="���黹���ۼƹ黹����">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox12" runat="server" Text='<%#Eval ("���黹���ۼƹ黹����") %>'  ReadOnly ="true" CssClass ="c13112503"></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="5%" />
                 <ItemStyle Width="5%"  ForeColor="#595d5a"/>
            </asp:TemplateField> 
                          <asp:TemplateField HeaderText="��ע">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox14" runat="server"  CssClass ="c13120501"></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="5%" />
                 <ItemStyle Width="5%"  ForeColor="#595d5a"/>
            </asp:TemplateField>
                 <asp:TemplateField HeaderText="Free����">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox13" runat="server"     CssClass ="c14071618"></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="4%" />
                 <ItemStyle Width="4%"  ForeColor="#595d5a"/>
            </asp:TemplateField> 
                        <asp:TemplateField HeaderText="�ͻ��Ϻ�">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox5" runat="server" Text='<%#Eval ("�ͻ��Ϻ�") %>'  CssClass ="c14071613" ></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="5%" />
                 <ItemStyle Width="5%"  ForeColor="#595d5a"/>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ID" >
                <ItemTemplate >
                                <asp:TextBox ID="TextBox1" runat="server"  Text='<%#Eval ("Ʒ��") %>' CssClass="c14071609"  ></asp:TextBox>   
                               
                </ItemTemplate>
                 <HeaderStyle Width="3%" />
                 <ItemStyle Width="3%"  ForeColor="#595d5a" />
            </asp:TemplateField>
                               <asp:TemplateField HeaderText="���" >
                <ItemTemplate >
                  <asp:TextBox ID="TextBox2" runat="server"  Text='<%#Eval ("���") %>'  ReadOnly ="true" CssClass="c14071612" ></asp:TextBox>   
                               
                </ItemTemplate>
                 <HeaderStyle Width="2%" />
                 <ItemStyle Width="2%"  ForeColor="#595d5a" />
            </asp:TemplateField> 
      <asp:TemplateField HeaderText="�Ϻ�">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox3" runat="server" Text='<%#Eval ("�Ϻ�") %>'  CssClass="c14071609"></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="2%" />
                 <ItemStyle Width="2%"  ForeColor="#595d5a"/>
            </asp:TemplateField>
                    <asp:TemplateField HeaderText="�������">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox6" runat="server" Text='<%#Eval ("�������") %>'  ReadOnly ="true" CssClass ="c14071615"></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="4%" />
                 <ItemStyle Width="4%"  ForeColor="#595d5a"/>
            </asp:TemplateField>
          
                    </Columns>
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" Font-Bold="False" />   
                </asp:GridView>
                </div>
                <div id ="i13111501" class ="c13101902">
                                 <div class="c13102907" id ="Div16">
                                 </div>
     
          <div class="c14112014" id ="Div161">
              �ϼ����</div>
     <div class="c13101904" id ="Div21">
   <input id="Text51" type="text"  runat ="server" class="c13102908" /> 
         </div>
       <div class="c14112014" id ="Div26">
              �ϼ��˻�Ѻ��</div>
     <div class="c13101904" id ="Div27">
   <input id="Text52" type="text"  runat ="server" class="c13102908" /> 
         </div>
           </div>
         <div id="i13111001" class ="c13102201">
        <asp:GridView ID="GridView2" runat="server" 
                    
                    AllowSorting="True"   
                    onrowdatabound="GridView2_RowDataBound" 
                        AutoGenerateColumns="False" style="margin-left: 8px" PageSize="15" 
                        CssClass ="c13112304"
                   >
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns > 
          
                                     <asp:BoundField DataField="����" HeaderText="����"    >
                              <ItemStyle Width="40px"  ForeColor="#595d5a"/>
                                    <HeaderStyle Width="40px" HorizontalAlign="Center" />
                          </asp:BoundField>
                          <asp:BoundField DataField="���" HeaderText="���" >
                              <ItemStyle Width="40px"  ForeColor="#595d5a"/>
                                    <HeaderStyle Width="40px" HorizontalAlign="Center" />
                          </asp:BoundField>
          <asp:BoundField DataField="ID" HeaderText="ID" >
                              <ItemStyle Width="80px"  ForeColor="#595d5a"/>
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
              <asp:BoundField DataField="�Ϻ�" HeaderText="�Ϻ�" >
                              <ItemStyle Width="80px"  ForeColor="#595d5a"/>
                                    <HeaderStyle  HorizontalAlign="Center" />
                          </asp:BoundField>
            <asp:BoundField DataField="Ʒ��" HeaderText="Ʒ��" >
                              <ItemStyle Width="80px"  ForeColor="#595d5a"/>
                                    <HeaderStyle HorizontalAlign="Center" />
                          </asp:BoundField> 
       <asp:BoundField DataField="״̬" HeaderText="״̬" >
                              <ItemStyle Width="120px"  ForeColor="#595d5a"/>
                                    <HeaderStyle Width="120px" HorizontalAlign="Center" />
                          </asp:BoundField>
                            <asp:BoundField DataField="�������" HeaderText="�������" >
                              <ItemStyle Width="120px"  ForeColor="#595d5a"/>
                                    <HeaderStyle Width="120px" HorizontalAlign="Center" />
                          </asp:BoundField>
        <asp:BoundField DataField="�黹����" HeaderText="�黹����" >
                              <ItemStyle Width="120px"  ForeColor="#595d5a"/>
                                    <HeaderStyle Width="120px" HorizontalAlign="Center" />
                          </asp:BoundField>
            <asp:BoundField DataField="�黹����" HeaderText="�黹����" >
                              <ItemStyle Width="80px"  ForeColor="#595d5a"  HorizontalAlign="Right" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                           <asp:BoundField DataField="��������" HeaderText="��������" >
                              <ItemStyle Width="80px"  ForeColor="#595d5a"/>
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                           <asp:BoundField DataField="��λ" HeaderText="��λ" >
                              <ItemStyle Width="80px"  ForeColor="#595d5a"   />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                             <asp:BoundField DataField="�����" HeaderText="�����" >
                              <ItemStyle Width="80px"  ForeColor="#595d5a"   />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                             <asp:BoundField DataField="���" HeaderText="���" >
                              <ItemStyle Width="80px"  ForeColor="#595d5a"   />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                             <asp:BoundField DataField="Ѻ��" HeaderText="Ѻ��" >
                              <ItemStyle Width="80px"  ForeColor="#595d5a"   />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                          
                             <asp:BoundField DataField="�˻�Ѻ��" HeaderText="�˻�Ѻ��" >
                              <ItemStyle Width="80px"  ForeColor="#595d5a"   />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
            <asp:BoundField DataField="�ֿ�" HeaderText="�ֿ�" >
                              <ItemStyle Width="120px"  ForeColor="#595d5a"  />
                                    <HeaderStyle Width="120px" HorizontalAlign="Center" />
                          </asp:BoundField>

                           <asp:BoundField DataField="����" HeaderText="����" >
                              <ItemStyle Width="80px"  ForeColor="#595d5a" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                         
                           <asp:BoundField DataField="�Ƶ���" HeaderText="�Ƶ���" >
                              <ItemStyle Width="80px"  ForeColor="#595d5a" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
               <asp:BoundField DataField="�Ƶ�����" HeaderText="�Ƶ�����"   >
                              <ItemStyle Width="130px"  ForeColor="#595d5a" HorizontalAlign="Center" />
                                    <HeaderStyle Width="130px" HorizontalAlign="Center" />
                          </asp:BoundField>
                              <asp:BoundField DataField="��ע" HeaderText="��ע"   >
                              <ItemStyle Width="100px"  ForeColor="#595d5a" HorizontalAlign="Center" />
                                    <HeaderStyle Width="100px" HorizontalAlign="Center" />
                          </asp:BoundField>
                      
                    </Columns>
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" Font-Bold="False" />   
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
                  document.getElementById("i13111501").style.display = "block";
                  document.getElementById("i15051001").style.display = "block";
              }
              else {
                  document.getElementById("i13111501").style.display = "none";
                  document.getElementById("i15051001").style.display = "none";

              }
          
              if (Invocation3 != "") {

                  document.getElementById("i13111001").style.display = "block";

              }
              else {

                  document.getElementById("i13111001").style.display = "none";

              }
          }
          function f13100202(obj, obj1) {
              var dlgResult;
             if (obj == "Text8") {
                  dlgResult = window.showModalDialog("../lease_manage/lend.aspx?emid=" + document.getElementById("emid").value + "", window, "dialogWidth:970px; dialogHeight:490px; status:0");
                  if (dlgResult != undefined) {

                      document.getElementById("Text8").value = dlgResult[0];
                      document.getElementById("Text5").value = dlgResult[1];
                      document.getElementById("Text6").value = dlgResult[2];
                      document.getElementById("Text7").value = dlgResult[3];
                  }
              }
            
       
              else if (obj == "TextBox10") {
                  dlgResult = window.showModalDialog("../StockManage/StorageInfo.aspx?move=1", window, "dialogWidth:970px; dialogHeight:490px; status:0");

                  if (dlgResult != undefined) {

                      var table = document.getElementById('<%=GridView1.ClientID%>');
                      var tr = table.getElementsByTagName("tr");
                      for (i = 1; i < tr.length; i++) {
                          if (obj1 == i) {
                              var v5 = tr[i].getElementsByTagName("td")[6].getElementsByTagName("input")[0];
                              v5.value = dlgResult[1];
                              break;
                          }
                      }


                  }

              }
              else if (obj == "TextBox74") {
                  dlgResult = window.showModalDialog("../WDate.aspx?hh=1", window, "dialogWidth:160px; dialogHeight:240px; status:0;");
                  if (dlgResult != undefined) {

                      table1 = document.getElementById('<%=GridView1.ClientID%>');
                      tr1 = table1.getElementsByTagName("tr");
                      for (i = 1; i < tr1.length; i++) {
                          if (obj1 == i) {
                              v1 = tr1[i].getElementsByTagName("td")[9].getElementsByTagName("input")[0]; //��ȡgirdview���1��TextBox��ֵ
                              v1.value = dlgResult;
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