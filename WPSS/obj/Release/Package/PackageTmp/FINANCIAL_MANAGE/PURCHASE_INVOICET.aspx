<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PURCHASE_INVOICET.aspx.cs" Inherits="WPSS.FINANCIAL_MANAGE.PURCHASE_INVOICET" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>¼��ɹ���Ʊ</title>
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
<input id="wareid" type="hidden"  runat="server" />
<div class ="c13101905">
      <div class="c13101906" id ="Div9">
          ¼��ɹ���Ʊ </div>
     <div class="c13101907" id ="Div10">
 </div>
    </div>
  <div id="i15013001" class ="c13110501">
      <div class="c13110502" id ="Div17">
   <span class="c13110508" id ="Span1">
          </span>
       </div>
              <div class="c13110510" id ="Div18">
   <span class="c13110511" id ="Span4">
          </span>
       </div>
             <div class="c13110502" id ="Div19">
   <span class="c13110508" id ="Span3">
       
          </span>
       </div>
              <div class="c13110510" id ="Div20">
   <span class="c13110511" id ="Span5">
                
          </span>
       </div>
          
         <div class="c13110507" id ="Div22">
                  <span class="c13110503" id ="Span2">
    
          </span>
   </div>
                 <div class="c13110510" id ="Div23">
   <span class="c13110511" id ="Span6">
                 
          </span>
       </div>
        <div class="c14060904" id ="Div32">
                <span class="c14060903" id ="Span7">
    <asp:LinkButton ID="btnReconcile" runat="server" onclick="btnReconcile_Click" CssClass ="">�������������ҵ</asp:LinkButton>
    </span> 
   </div>
          
                 <div class="c13110510" id ="Div33">
   <span class="c13110511" id ="Span8">
                 
          </span>
       </div>
                              <div class="c14060904" id ="Div1">
                <span class="c14060903" id ="Span9">
    
    </span> 
   </div>
          
                 <div class="c13110510" id ="Div2">
   <span class="c13110511" id ="Span10">
                 
          </span>
       </div>
    </div> 
                     
<div  id="i13102301" class ="c13102101">
<span  class ="c13102102"><asp:Label ID="prompt" runat="server"  ForeColor="#f80707"></asp:Label></span>
</div> 
  
           <div id="i14073102" class ="c13111601">
     
      <div class ="c15013101">    
       <asp:CheckBox ID="CheckBox2" runat="server"  Text ="ȫѡ" oncheckedchanged="CheckBox2_CheckedChanged"  /> 
           <asp:CheckBox ID="CheckBox3" runat="server" Text ="��ѡ" oncheckedchanged="CheckBox3_CheckedChanged" />
           </div>
     <div class="c15013001" id ="Div36">

      <span style="color :#990033">
      (1.ͬһ����Ӧ��ֻ���ѡ���еĵ�һ�����뷢Ʊ���� ��Ʊδ˰ ��Ʊ˰�� ��Ʊ��˰����) 
        </span>
</div>

          </div>   
                     <div id="i15020501" class ="c13111601">
              <div  class ="c15013101"></div>      
     <div class="c15020401" id ="Div7">
      <span style="color :#990033"> 
      (2.��ѡ����Ĳɹ��������˻� ��δ������ ����˻�����һ�����ŵ����������ҵ 3.ѡ�����˵㾭�����ı��� 4.ֻ�н᰸(�����)�Ĳɹ������ڴ���ʾ)</span>
</div>
</div>

          <div id="i15020101" class ="c13101902">
                      <div class="c13101903" id ="Div3">
                          ���Ա����</div>
     <div class="c14031403"id ="Div4">
         <input id="Text4" type="text" runat="server"   onclick ="f13100202('Text4','')" class ="c14112009" /> 
       
               <asp:Label ID="Label1" runat="server" Text="" ></asp:Label>
         </div>
 
                        <div class="c13101903" id ="Div38">
                            �������</div>
    <div class="c14031403" id ="Div5">
  <input id="Text3" type="text" runat="server" onclick ="f13100202('Text3')" readonly="readonly" class ="c13110901"/>
         
         </div>

           </div>
<div id="i14073101" class ="c15012901">
            <asp:GridView ID="GridView1" runat="server" 
                    AllowSorting="True"   
                    onrowdatabound="GridView1_RowDataBound" 
                        AutoGenerateColumns="False" PageSize="15" 
                             CssClass ="c14073101"
                   >
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns > 
                        <asp:TemplateField HeaderText="ѡ��" >
                <ItemTemplate >
                    <asp:CheckBox ID="CheckBox1" runat="server"  Checked='<%# Bind("ѡ��")%>'   CssClass ="c14080104" />
                </ItemTemplate>
                 <HeaderStyle Width="2%" />
                 <ItemStyle Width="2%"  />
            </asp:TemplateField>
                     <asp:TemplateField HeaderText="���">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox20" runat="server"  Text='<%#Eval ("Ŀ¼���") %>'  CssClass ="c14070203" ></asp:TextBox>                     
                </ItemTemplate>
                <HeaderStyle Width="1.5%" />
                 <ItemStyle Width="1.5%"  />
            </asp:TemplateField>
                   <asp:TemplateField HeaderText="��Ӧ��">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox18" runat="server"  Text='<%#Eval ("��Ӧ������") %>' CssClass ="c14070203"  ></asp:TextBox>                     
                </ItemTemplate>
          <HeaderStyle Width="4%" />
                 <ItemStyle Width="4%"/>
            </asp:TemplateField>
         <asp:TemplateField HeaderText="�ɹ�����">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox1" runat="server"  Text='<%#Eval ("�ɹ�����") %>' CssClass ="c14070203" ></asp:TextBox>                     
                </ItemTemplate>
               <HeaderStyle Width="4%" />
                 <ItemStyle Width="4%"  />
            </asp:TemplateField>
                    <asp:TemplateField HeaderText="���">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox2" runat="server"  Text='<%#Eval ("���") %>'  CssClass ="c14070203" ></asp:TextBox>                     
                </ItemTemplate>
                <HeaderStyle Width="2%" />
                 <ItemStyle Width="2%"  />
            </asp:TemplateField> 
 
                    <asp:TemplateField HeaderText="Ʒ��">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox4" runat="server"  Text='<%#Eval ("Ʒ��") %>'  CssClass ="c14070203" ></asp:TextBox>                     
                </ItemTemplate>
              <HeaderStyle Width="4%" />
                 <ItemStyle Width="4%"  />
            </asp:TemplateField> 
               
      <asp:TemplateField HeaderText="�ۼ����">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox51" runat="server" Text='<%#Eval ("�ۼ��������") %>' CssClass ="c14071615" ></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="2%" />
                 <ItemStyle Width="2%"/>
            </asp:TemplateField>
               <asp:TemplateField HeaderText="�ɹ�����">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox7" runat="server"  Text='<%#Eval ("�ɹ�����") %>' CssClass ="c14071615"></asp:TextBox>                     
                </ItemTemplate>
              <HeaderStyle Width="2%" />
                 <ItemStyle Width="2%"/>
            </asp:TemplateField> 
                    
                <asp:TemplateField HeaderText="��Ʊ����">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox12" runat="server"  Text='<%#Eval ("��Ʊ����") %>'  CssClass ="c14120202"></asp:TextBox>                     
                </ItemTemplate>
                <HeaderStyle Width="4%" />
                 <ItemStyle Width="4%"/>
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="��Ʊδ˰">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox13" runat="server"  Text='<%#Eval ("��Ʊδ˰���") %>'  CssClass ="c13112302"></asp:TextBox>                     
                </ItemTemplate>
                <HeaderStyle Width="4%" />
                 <ItemStyle Width="4%"/>
            </asp:TemplateField> 
                <asp:TemplateField HeaderText="��Ʊ˰��">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox14" runat="server"  Text='<%#Eval ("��Ʊ˰��") %>'  CssClass ="c13112302"></asp:TextBox>                     
                </ItemTemplate>
                <HeaderStyle Width="4%" />
                 <ItemStyle Width="4%"/>
            </asp:TemplateField> 
                <asp:TemplateField HeaderText="��Ʊ��˰">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox15" runat="server"  Text='<%#Eval ("��Ʊ��˰���") %>'  CssClass ="c13112302"></asp:TextBox>                     
                </ItemTemplate>
                <HeaderStyle Width="4%" />
                 <ItemStyle Width="4%"/>
            </asp:TemplateField> 
             <asp:TemplateField HeaderText="˰��">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox8" runat="server"  Text='<%#Eval ("˰��") %>'  CssClass ="c14071616"></asp:TextBox>                     
                </ItemTemplate>
                <HeaderStyle Width="2%" />
                 <ItemStyle Width="2%"/>
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="δ˰���">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox9" runat="server"  Text='<%#Eval ("δ˰���") %>'  CssClass ="c14071616"></asp:TextBox>                     
                </ItemTemplate>
                <HeaderStyle Width="4%" />
                 <ItemStyle Width="4%"/>
            </asp:TemplateField> 
                <asp:TemplateField HeaderText="˰��">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox10" runat="server"  Text='<%#Eval ("˰��") %>'  CssClass ="c14071616"></asp:TextBox>                     
                </ItemTemplate>
                <HeaderStyle Width="4%" />
                 <ItemStyle Width="4%"/>
            </asp:TemplateField> 
                <asp:TemplateField HeaderText="��˰���">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox11" runat="server"  Text='<%#Eval ("��˰���") %>'  CssClass ="c14071616"></asp:TextBox>                     
                </ItemTemplate>
                <HeaderStyle Width="4%" />
                 <ItemStyle Width="4%"/>
            </asp:TemplateField> 
              <asp:TemplateField HeaderText="ID">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox16" runat="server"  Text='<%#Eval ("ID") %>' CssClass ="c14070203" ></asp:TextBox>                     
                </ItemTemplate>
              <HeaderStyle Width="4%" />
                 <ItemStyle Width="4%"  />
            </asp:TemplateField>
           <asp:TemplateField HeaderText="�Ϻ�">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox17" runat="server"  Text='<%#Eval ("�Ϻ�") %>' CssClass ="c14070203" ></asp:TextBox>                     
                </ItemTemplate>
              <HeaderStyle Width="4%" />
                 <ItemStyle Width="4%"  />
            </asp:TemplateField>
                 <asp:TemplateField HeaderText="�ɹ�����">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox5" runat="server" Text='<%#Eval ("�ɹ�����") %>' CssClass ="c14071615" ></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="2%" />
                 <ItemStyle Width="2%"/>
            </asp:TemplateField>
                                  <asp:TemplateField HeaderText="��λ">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox6" runat="server"  Text='<%#Eval ("�ɹ���λ") %>'  CssClass ="c14071615"></asp:TextBox>      
                                
                </ItemTemplate>
         <HeaderStyle Width="2%" />
                 <ItemStyle Width="2%"/>
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
                  document.getElementById("i14073101").style.display = "block";
                  document.getElementById("i14073102").style.display = "block";
                  document.getElementById("i15013001").style.display = "block";
                  document.getElementById("i15020101").style.display = "block";
                  document.getElementById("i15020501").style.display = "block";
              }
              else {
                  document.getElementById("i14073101").style.display = "none";
                  document.getElementById("i14073102").style.display = "none";
                  document.getElementById("i15013001").style.display = "none";
                  document.getElementById("i15020101").style.display = "none";
                  document.getElementById("i15020501").style.display = "none";
              }
          }

          function f13100202(obj, obj1) {
              var dlgResult;
              if (obj == "Text2") {
                  dlgResult = window.showModalDialog("../PURCHASEManage/Supplierinfo.aspx", window, "dialogWidth:970px; dialogHeight:490px; status:0");
                  if (dlgResult != undefined) {
                      document.getElementById("Text2").value = dlgResult[0];
                      document.getElementById("Text5").value = dlgResult[1];
                  }
              }
              else if (obj == "TextBox1") {
              dlgResult = window.showModalDialog("../BaseInfo/Wareinfo.aspx?CUID=" + document.getElementById("Text2").value + "&nature=PURCHASE_det", window, "dialogWidth:970px; dialogHeight:490px; status:0");

                  if (dlgResult != undefined) {

                      var table = document.getElementById('<%=GridView1.ClientID%>');
                      var tr = table.getElementsByTagName("tr");
                      for (i = 1; i < tr.length; i++) {
                          if (obj1 == i) {
                              var v0 = tr[i].getElementsByTagName("td")[0].getElementsByTagName("input")[0]; /*wareid*/
                              var v1 = tr[i].getElementsByTagName("td")[1].getElementsByTagName("input")[0];/*co_wareid*/
                              var v2 = tr[i].getElementsByTagName("td")[2].getElementsByTagName("input")[0];/*wname*/
                              var v3 = tr[i].getElementsByTagName("td")[3].getElementsByTagName("input")[0];/*spec*/
                              var v4 = tr[i].getElementsByTagName("td")[4].getElementsByTagName("input")[0];/*brand*/
                              var v5 = tr[i].getElementsByTagName("td")[5].getElementsByTagName("input")[0];/*cwareid*/
                              /*var v6 = tr[i].getElementsByTagName("td")[6].getElementsByTagName("input")[0]; pcount*/
                              
                              var v7 = tr[i].getElementsByTagName("td")[7].getElementsByTagName("input")[0]; /*mpa_unit*/
                              var v8 = tr[i].getElementsByTagName("td")[8].getElementsByTagName("input")[0]; /*currency*/
                              var v9 = tr[i].getElementsByTagName("td")[9].getElementsByTagName("input")[0]; /*sellunitprice*/
                              v0.value = dlgResult[0];
                              v1.value = dlgResult[1];
                              v2.value = dlgResult[2];
                              v3.value = dlgResult[6];
                              v4.value = dlgResult[11];
                              v5.value = dlgResult[3];
                              
                              v7.value = dlgResult[10];
                              v8.value = dlgResult[13];
                              v9.value = dlgResult[9];
                              document.getElementById("wareid").value = dlgResult[0];
                              break;
                          }
                      }
                  }
              }
              else if (obj == "TextBox10") {
              dlgResult = window.showModalDialog("../BaseInfo/unit.aspx?wareid=" + document.getElementById("wareid").value + "&nature=PURCHASE_det", window, "dialogWidth:970px; dialogHeight:490px; status:0");
                  if (dlgResult != undefined) {
                      var table1 = document.getElementById('<%=GridView1.ClientID%>');
                      var tr1 = table1.getElementsByTagName("tr");
                      for (i = 1; i < tr1.length; i++) {
                          if (obj1 == i) {
                              var v10 = tr1[i].getElementsByTagName("td")[7].getElementsByTagName("input")[0]; //��ȡgirdview���1��TextBox��ֵ
                              v10.value = dlgResult[0];
                              break;
                          }
                      }
                  }

              }
              else if (obj == "TextBox12") {
                  dlgResult = window.showModalDialog("../BaseInfo/currency.aspx", window, "dialogWidth:970px; dialogHeight:490px; status:0");
                  if (dlgResult != undefined) {
                      var table2 = document.getElementById('<%=GridView1.ClientID%>');
                      var tr2 = table2.getElementsByTagName("tr");
                      for (i = 1; i < tr2.length; i++) {
                          if (obj1 == i) {
                              var v11 = tr2[i].getElementsByTagName("td")[9].getElementsByTagName("input")[0]; //��ȡgirdview���1��TextBox��ֵ
                              v11.value = dlgResult[0];
                              break;
                          }
                      }
                  }
              }
              else if (obj == "TextBox14") {
                  dlgResult = window.showModalDialog("../WDate.aspx", window, "dialogWidth:160px; dialogHeight:240px; status:0;");
                  if (dlgResult != undefined) {

                      table = document.getElementById('<%=GridView1.ClientID%>');
                      tr = table.getElementsByTagName("tr");
                      for (i = 1; i < tr.length; i++) {
                          if (obj1 == i) {
                              v1 = tr[i].getElementsByTagName("td")[11].getElementsByTagName("input")[0]; //��ȡgirdview���1��TextBox��ֵ
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
              else if (obj == "Text4") {
                  dlgResult = window.showModalDialog("../BaseInfo/EMPLOYEEINFO.aspx", window, "dialogWidth:970px; dialogHeight:490px; status:0;");
                  if (dlgResult != undefined) {

                      document.getElementById("Text4").value = dlgResult[0];
                      document.all("Label1").innerText =dlgResult[1];
                  }
              }
       
          
             else  if (obj == "Text12") {
                  dlgResult = window.showModalDialog("../BASEINFO/ReceivingAndDelivery.aspx", window, "dialogWidth:970px; dialogHeight:490px; status:0");
                  if (dlgResult != undefined) {

                      document.getElementById("RDID").value = dlgResult[0];
                      document.getElementById("Text12").value = dlgResult[2];
                      document.getElementById("Text13").value = dlgResult[4];
                  }
              }
              
              else if (obj == "Text15") {
                  dlgResult = window.showModalDialog("../BASEINFO/companyinfox.aspx", window, "dialogWidth:970px; dialogHeight:490px; status:0");
                  if (dlgResult != undefined) {

                      document.getElementById("COKEY").value = dlgResult[0];
                      document.getElementById("Text14").value = dlgResult[1];
                      document.getElementById("Text15").value = dlgResult[2];
                      document.getElementById("Text16").value = dlgResult[3];
                  }
              }
              else {
                  dlgResult = window.showModalDialog("../BaseInfo/EMPLOYEEINFO.aspx", window, "dialogWidth:970px; dialogHeight:490px; status:0;");
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