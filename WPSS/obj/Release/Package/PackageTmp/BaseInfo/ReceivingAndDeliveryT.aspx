<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReceivingAndDeliveryT.aspx.cs" Inherits="WPSS.BaseInfo.ReceivingAndDeliveryT" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>�༭���͵�ַ��Ϣ</title>
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
      <input id="RDID" type="hidden"  runat="server" />
        <input id="emid" type="hidden"  runat="server" />
                <div class ="c13101905">
      <div class="c13101906" id ="Div9">
          &gt;�༭��˾��Ϣ </div>
     <div class="c13101907" id ="Div10">
 </div>
    </div>
  <div class ="c13110501">
      <div class="c13110502" id ="Div1">
   <span class="c13110508" id ="Span1">

          </span>
       </div>
              <div class="c13110510" id ="Div3">
   <span class="c13110511" id ="Span4">
          
          </span>
       </div>
             <div class="c13110502" id ="Div18">
   <span class="c13110508" id ="Span3">
  
          </span>
       </div>
              <div class="c13110510" id ="Div19">
   <span class="c13110511" id ="Span5">
         
          </span>
       </div>
          
         <div class="c13110507" id ="Div22">
                  <span class="c13110503" id ="Span2">
     <asp:ImageButton ID="btnExit" 
                 runat="server" ImageUrl="~/Image/btnExit.png" Width="60px" 
                      onclick="btnExit_Click" />
          </span>
   </div>
                 <div class="c13110510" id ="Div24">
   <span class="c13110511" id ="Span6">
                     (�˳�)
          </span>
       </div>
    </div>

<div  id="i13102301" class ="c13102101">
<span  class ="c13102102"><asp:Label ID="prompt" runat="server"  ForeColor="#f80707"></asp:Label></span>
</div> 
  
          <div class ="c13101902">

         <div class="c13101903" id ="Div5">
             ��˾����</div>
     <div class="c13102401" id ="Div6">
   <input id="Text1" type="text"  runat ="server"  class="c13112201" /></div>
     <div class="c13101903" id ="Div2">
          ��ϵ��</div>
     <div class="c13101904" id ="Div4">
        <input id="Text2" type="text"  runat="server"    readonly ="readonly"  class="c13112201"/></div>
           </div>
           
           
           <div class ="c13101902">
 
    <div class="c13101903" id ="Div7">
          ��ϵ�绰</div>
     <div class="c13102401" id ="Div8">
        <input id="Text3" type="text"  runat="server"    readonly ="readonly"  class="c13112201"/></div>
                         <div class="c13101903" id ="Div20">
                             ��ַ</div>
     <div class="c13121902" id ="Div23">
                    <input id="Text4" type="text"  runat="server"  readonly ="readonly" class="c14111907"/></div>
           </div>        
           <div class ="c13111601">
       <div class="c13101903" id ="Div35">
           �����Ϣ</div>
     <div class="c13111503" id ="Div36">
     <span style =" margin-right :20px;  display :none "><asp:Button ID="btnClear" runat="server" Text="���" 
             onclick="btnClear_Click" /></span>
         <asp:Button ID="btnAddContactInfo" runat="server" Text="���" 
             onclick="btnAddContactInfo_Click" />
</div>
 
         
             <span class ="c13112202">�����ĸ��ı������ϢΪ��ǰĬ����Ϣ.���������Ϣ,Ȼ�󵥻���˾����ΪĬ����ϵ��Ϣ</span></div>
<div class ="c13111602">
             
          
            <asp:GridView ID="GridView1" runat="server" 
                    AllowSorting="True"   
                    onrowdatabound="GridView1_RowDataBound" 
                        AutoGenerateColumns="False" PageSize="15" 
                        CssClass ="c14111905"
                   >
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns >
                            <asp:TemplateField HeaderText="SN"  Visible ="false"  >
                <ItemTemplate >
                                
                                <a ><%#Eval ("���") %>'</a>   
                </ItemTemplate>
                 <HeaderStyle Width="60px" />
                 <ItemStyle Width="60px"  ForeColor="#595d5a" />
            </asp:TemplateField> 
                      <asp:TemplateField HeaderText="��˾����">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox1" runat="server"  Text='<%#Eval ("��˾����") %>' Width ="200px"  CssClass ="c13120501" ></asp:TextBox> 
                    <a  href="javascript:f13100202('TextBox1','<%#Eval ("���") %>');"> ѡ��</a>                     
                </ItemTemplate>
                 <HeaderStyle Width="250px" />
                 <ItemStyle Width="250px"  ForeColor="#595d5a"/>
            </asp:TemplateField>  
           <asp:TemplateField HeaderText="��ϵ��" >
                <ItemTemplate >
              <asp:TextBox ID="TextBox2" runat="server"  Text='<%#Eval ("��ϵ��") %>' Width ="60px" BackColor ="#e0efda"  ></asp:TextBox>   
                </ItemTemplate>
                 <HeaderStyle Width="60px" />
                 <ItemStyle Width="60px"  ForeColor="#595d5a" />
            </asp:TemplateField> 
               <asp:TemplateField HeaderText="��ϵ�绰" >
                <ItemTemplate >
                 <asp:TextBox ID="TextBox3" runat="server" Text='<%#Eval ("��ϵ�绰") %>'  Width ="100px"  CssClass ="c13120501" ></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="100px" />
                 <ItemStyle Width="100px"  ForeColor="#595d5a"/>
            </asp:TemplateField> 
               <asp:TemplateField HeaderText="��ַ">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox4" runat="server"  Width ="400px" BackColor ="#e0efda" ></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="400px" />
                 <ItemStyle Width="400px"  ForeColor="#595d5a"/>
            </asp:TemplateField>  
                    </Columns>
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" Font-Bold="False" />   
                </asp:GridView>
                </div>

           <asp:GridView ID="GridView2" runat="server" 
                    onrowdeleting="GridView2_RowDeleting" 
                    AllowSorting="True"   
                    onrowdatabound="GridView2_RowDataBound" 
                        onselectedindexchanged="GridView2_SelectedIndexChanged" 
                        AutoGenerateColumns="False" style="margin-left: 8px" PageSize="15" 
                        CssClass ="c13112301"
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
           <asp:BoundField DataField="RDID" HeaderText="��ַ����"  Visible ="false" >
                              <ItemStyle Width="100px"  ForeColor="#595d5a"/>
                                    <HeaderStyle HorizontalAlign="Center" Width="100px" />
                          </asp:BoundField>         
             <asp:TemplateField HeaderText="��˾����">
                <ItemTemplate >
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Select" 
                        Text='<%# Bind("CONAME") %>'></asp:LinkButton>                     
                </ItemTemplate>
                 <HeaderStyle Width="200px" />
                 <ItemStyle Width="200px"  ForeColor="#595d5a"/>
            </asp:TemplateField>   
            <asp:BoundField DataField="CONTACT" HeaderText="��ϵ��" >
                              <ItemStyle Width="100px"  ForeColor="#595d5a"/>
                                    <HeaderStyle HorizontalAlign="Center" Width="100px" />
                          </asp:BoundField>
            <asp:BoundField DataField="PHONE" HeaderText="��ϵ�绰" >
                              <ItemStyle Width="120px"  ForeColor="#595d5a"/>
                                    <HeaderStyle HorizontalAlign="Center" Width="100px" />
                          </asp:BoundField>
                            <asp:BoundField DataField="ADDRESS" HeaderText="��ַ" >
                              <ItemStyle Width="400px"  ForeColor="#595d5a"/>
                                    <HeaderStyle HorizontalAlign="Center" Width="400px" />
                          </asp:BoundField>
                    </Columns>
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" Font-Bold="False" />   
                </asp:GridView>
      
      <script type ="text/javascript" >
          window.onload = function onload1() {
              var Invocation = document.getElementById("hint").value;
              if (Invocation != "") {
                  document.getElementById("i13102301").style.display = "block";
                  document.all("prompt").innerText = Invocation;
              }
              else {
                  document.getElementById("i13102301").style.display = "none";
              }
          }
          function f13100202(obj, obj1) {
              var dlgResult;
                 if (obj == "TextBox1") {
                  dlgResult = window.showModalDialog("../BaseInfo/CompanyInfoP.aspx?emid="+document .getElementById ("emid").value +"", window, "dialogWidth:960px; dialogHeight:480px; status:0");

                  if (dlgResult != undefined) {

                      var table = document.getElementById('<%=GridView1.ClientID%>');
                      var tr = table.getElementsByTagName("tr");
                      for (i = 1; i < tr.length; i++) {
                          if (obj1 == i) {
                              var v1 = tr[i].getElementsByTagName("td")[0].getElementsByTagName("input")[0]; //��ȡgirdview���1��TextBox��ֵ
                              var v2 = tr[i].getElementsByTagName("td")[1].getElementsByTagName("input")[0];
                              var v3 = tr[i].getElementsByTagName("td")[2].getElementsByTagName("input")[0];
                              var v4 = tr[i].getElementsByTagName("td")[3].getElementsByTagName("input")[0];
                              v1.value = dlgResult[1];
                              v2.value = dlgResult[2];
                              v3.value = dlgResult[3];
                              v4.value = dlgResult[4];
                              break;
                          }
                      }


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