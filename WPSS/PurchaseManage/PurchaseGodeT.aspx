<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchaseGodeT.aspx.cs" Inherits="WPSS.PurchaseManage.PurchaseGodeT" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>�༭�ɹ���Ϣ</title>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" /> 
<meta name ="Description" content ="���������ϵͳ" />
<meta name ="keywords" content ="���������ϵͳ,������������,ERP,С΢��ҵ����ϵͳ,ϣ�����" />
       <link href ="../Css/SSBase.css"  type ="text/css" rel ="Stylesheet" />
       <link href ="../Css/S131017.css"  type ="text/css" rel ="Stylesheet" />

    </head>
<body >
   <form id="form1" runat="server">
   <input id="suid" type="hidden"  runat="server" />
     <input id="emid" type="hidden"  runat="server" />
   <input id="hint" type="hidden"  runat="server" />
      <input id="x" type="hidden"  runat="server" />
       <input id="ControlFileDisplay" type="hidden"  runat="server" />
        <input id="x2" type="hidden"  runat="server" />
                <div class ="c13101905">
      <div class="c13101906" id ="Div9">
          &gt;�༭�ɹ���ⵥ </div>
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
    </div>
<div  id="i13102301" class ="c13102101">
<span  class ="c13102102"><asp:Label ID="prompt" runat="server"  ForeColor="#f80707"></asp:Label></span>
</div> 
  <div class ="c13101902">
      <div class="c13101903" id ="Div24">
          ��ⵥ��</div>
     <div class="c13101904" id ="Div25">
<input id="Text1" type="text"  runat="server"   readonly ="readonly" class="c14031401"/> 
         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="Text1" Text="����" runat="server" /></div>
                  <div class="c13101903" id ="Div5">
                      ��Ӧ������</div>
     <div class="c13111503" id ="Div6">
   <input id="Text5" type="text"  runat ="server"  class ="c13102103"/>
     <span style =" margin-left :2px; margin-right :2px;"><a  href="javascript:f13100202('Text5','');">
         ѡ��</a></span> 
   
   </div>
         <div class="c13101903" id ="Div26">
             �ɹ�����</div>
     <div class="c13110801" id ="Div27">
   <input id="Text2" type="text"  runat ="server" readonly ="readonly" class ="c14112002"  />
   <span style =" margin-left :2px; margin-right :2px;"><a  href="javascript:f13100202('Text2','');">
         ѡ��</a></span> 
   <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="Text2" Text="����" runat="server" />
       <asp:LinkButton 
             ID="btnSure" runat="server" onclick="btnSure_Click"  
            >ȷ��</asp:LinkButton></div>

           </div>
  <div class ="c13101902">
                      <div class="c13101903" id ="Div28">
                          �������</div>
     <div class="c13101904" id ="Div29">
         <input id="Text3" type="text" runat="server" onclick ="f13100202('Text3')" readonly="readonly" class ="c14112001"/>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="Text3" Text="����" runat="server" /></div>
                      <div class="c13101903" id ="Div2">
                          ���Ա����</div>
                          
     <div class="c13111503" id ="Div4">
         <input id="Text4" type="text" runat="server"  class ="c14112010"/>
          <span style =" margin-left :2px; margin-right :2px;"><a  href="javascript:f13100202('Text4','');">
         ѡ��</a>
               <asp:Label ID="Label1" runat="server" Text="" ></asp:Label></span>
          </div>
          
 

  
           </div>
       

<div id="i13111001" class ="c13102201">
              
           <asp:GridView ID="GridView1" runat="server" 
                    AllowSorting="True"   
                    onrowdatabound="GridView1_RowDataBound" 
                        AutoGenerateColumns="False" 
                        CssClass ="c13122603"  onrowdeleting="GridView1_RowDeleting" onselectedindexchanged="GridView1_SelectedIndexChanged"
                   >
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns > 
                       <asp:TemplateField HeaderText="ɾ��" >
                <ItemTemplate >
                    <asp:LinkButton ID="LinkButton2" runat="server" 
                        OnClientClick="return confirm('��ȷ��ɾ���ü�¼��?');" Text="ɾ��"  CommandName ="delete" ></asp:LinkButton>                     
                </ItemTemplate>
                 <HeaderStyle Width="3%" />
                 <ItemStyle Width="3%"  />
            </asp:TemplateField>
                              <asp:TemplateField HeaderText="���" >
                <ItemTemplate >
                  <asp:TextBox ID="TextBox1" runat="server"  Text='<%#Eval ("���") %>'  ReadOnly ="true" CssClass="c14071612" ></asp:TextBox>   
                               
                </ItemTemplate>
                 <HeaderStyle Width="3%" />
                 <ItemStyle Width="3%"  ForeColor="#595d5a" />
            </asp:TemplateField> 
           <asp:TemplateField HeaderText="ID" >
                <ItemTemplate >
                                <asp:TextBox ID="TextBox2" runat="server"  Text='<%#Eval ("Ʒ��") %>' CssClass="c14071609"  ></asp:TextBox>   
                               
                </ItemTemplate>
                 <HeaderStyle Width="5%" />
                 <ItemStyle Width="5%"  ForeColor="#595d5a" />
            </asp:TemplateField> 
             <asp:TemplateField HeaderText="�Ϻ�">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox3" runat="server" Text='<%#Eval ("�Ϻ�") %>'  CssClass="c14071609"></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="5%" />
                 <ItemStyle Width="5%"  ForeColor="#595d5a"/>
            </asp:TemplateField>
                    <asp:TemplateField HeaderText="Ʒ��">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox4" runat="server"  Text='<%#Eval ("Ʒ��") %>'   CssClass="c14071609" ></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="6%" />
                 <ItemStyle Width="6%"  ForeColor="#595d5a"/>
            </asp:TemplateField> 
               <asp:TemplateField HeaderText="δ�����">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox7" runat="server" Text='<%#Eval ("δ�������") %>' ReadOnly ="true" CssClass ="c14071615"></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="5%" />
                 <ItemStyle Width="5%"  ForeColor="#595d5a"/>
            </asp:TemplateField> 
                      <asp:TemplateField HeaderText="�ۼ����">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox8" runat="server" Text='<%#Eval ("�ۼ��������") %>' ReadOnly ="true" CssClass ="c14071615"></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="5%" />
                 <ItemStyle Width="5%"  ForeColor="#595d5a"/>
            </asp:TemplateField> 
                     <asp:TemplateField HeaderText="�������">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox9" runat="server" Text='<%#Eval ("�������") %>'  CssClass ="c13112302"></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="4%" />
                 <ItemStyle Width="4%"  ForeColor="#595d5a"/>
            </asp:TemplateField> 
                <asp:TemplateField HeaderText="�ֿ�">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox10" runat="server" Text='<%#Eval ("�ֿ�") %>'  CssClass="c14071617"></asp:TextBox>
                 <a  href="javascript:f13100202('TextBox10','<%#Eval ("���") %>');">ѡ�� </a>                     
                </ItemTemplate>
                 <HeaderStyle Width="7%" />
                 <ItemStyle Width="7%"  ForeColor="#595d5a"/>
            </asp:TemplateField> 
                              <asp:TemplateField HeaderText="����">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox11" runat="server" Text='<%#Eval ("����") %>' CssClass="c14112003"></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="5%" />
                 <ItemStyle Width="5%"  ForeColor="#595d5a"/>
            </asp:TemplateField> 
                        <asp:TemplateField HeaderText="����ⵥ�ۼ��������">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox12" runat="server" Text='<%#Eval ("����ⵥ�ۼ��������") %>'  ReadOnly ="true" CssClass ="c13112503"></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="10%" />
                 <ItemStyle Width="10%"  ForeColor="#595d5a"/>
            </asp:TemplateField> 
                          <asp:TemplateField HeaderText="��ע">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox13" runat="server"  CssClass ="c13120501"></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="7%" />
                 <ItemStyle Width="7%"  ForeColor="#595d5a"/>
            </asp:TemplateField>
                 <asp:TemplateField HeaderText="Free����">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox14" runat="server"     CssClass ="c14071618"></asp:TextBox>                     
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
      
                    <asp:TemplateField HeaderText="�ɹ�����">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox6" runat="server" Text='<%#Eval ("�ɹ�����") %>'  ReadOnly ="true" CssClass ="c14071615"></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="4%" />
                 <ItemStyle Width="4%"  ForeColor="#595d5a"/>
            </asp:TemplateField>
                       <asp:TemplateField HeaderText="�ۼ��˻�">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox71" runat="server" Text='<%#Eval ("�ۼ��˻�����") %>'  ReadOnly ="true" CssClass ="c14071615"></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="4%" />
                 <ItemStyle Width="4%"  ForeColor="#595d5a"/>
            </asp:TemplateField>
                    </Columns>
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" Font-Bold="False" />   
                </asp:GridView>
         
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
          
                    <asp:GridView ID="GridView2" runat="server"  CssClass ="c13112502"  >
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

              }
              else {
                
                  document.getElementById("i13111001").style.display = "none";

              }
          }

          function f13100202(obj, obj1) {
              var dlgResult;
              if (obj == "Text2") {
                  
                  dlgResult = window.showModalDialog("../PurchaseManage/PURCHASE.aspx?suid=" + document.getElementById("suid").value + "&emid=" + document.getElementById("emid").value + "", window, "dialogWidth:970px; dialogHeight:490px; status:0");
                  if (dlgResult != undefined) {

                      document.getElementById("Text2").value = dlgResult[0];
                      document.getElementById("Text5").value = dlgResult[1];

                  }
              }
              else if (obj == "Text5") {
              dlgResult = window.showModalDialog("../PurchaseManage/Supplierinfo.aspx?emid=" + document.getElementById("emid").value + "", window, "dialogWidth:970px; dialogHeight:490px; status:0");
                  if (dlgResult != undefined) {

                      document.getElementById("suid").value = dlgResult[0];
                      document.getElementById("Text5").value = dlgResult[1];
                     

                  }
              }
              else if (obj == "TextBox10") {
              dlgResult = window.showModalDialog("../StockManage/StorageInfo.aspx?emid=" + document.getElementById("emid").value + "", window, "dialogWidth:970px; dialogHeight:490px; status:0");

                  if (dlgResult != undefined) {

                      var table = document.getElementById('<%=GridView1.ClientID%>');
                      var tr = table.getElementsByTagName("tr");
                      for (i = 1; i < tr.length; i++) {
                          if (obj1 == i) {
                              var v5 = tr[i].getElementsByTagName("td")[8].getElementsByTagName("input")[0];
                              v5.value = dlgResult[1];
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