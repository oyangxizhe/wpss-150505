<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditRightT.aspx.cs" Inherits="WPSS.UserManage.EditRightT" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>�༭�û�Ȩ��</title>
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
      <input id="emid" type="hidden"  runat="server" />
                <div class ="c13101905">
      <div class="c13101906" id ="Div9">
          &gt;�༭�û�Ȩ��</div>
     <div class="c13101907" id ="Div10">
 </div>
    </div>
    <div class ="c13110501">
      <div class="c13110502" id ="Div14">
   <span class="c13110508" id ="Span1">
       <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="~/Image/btnAdd.png"    onclick="btnAdd_Click"  />
          </span>
       </div>
              <div class="c13110510" id ="Div12">
   <span class="c13110511" id ="Span4">
                  (����)
          </span>
       </div>
             <div class="c13110502" id ="Div11">
   <span class="c13110508" id ="Span3">
       <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/Image/btnSave.png" 
                     onclick="btnSave_Click"  />
          </span>
       </div>
              <div class="c13110510" id ="Div13">
   <span class="c13110511" id ="Span5">
                  (����)
          </span>
       </div>
          
         <div class="c13110507" id ="Div21" >
                  <span class="c13110503" id ="Span2">
     <asp:ImageButton ID="btnExit" 
                 runat="server" ImageUrl="~/Image/btnExit.png" Width="60px" 
                      onclick="btnExit_Click" />
          </span>
   </div>
                 <div class="c13110510" id ="Div15" >
   <span class="c13110511" id ="Span6">
                     (�˳�)
          </span>
       </div>
    </div>
<div  id="i13102301" class ="c13102101">
<span  class ="c13102102"><asp:Label ID="prompt" runat="server"  ForeColor="#f80707"></asp:Label></span>
</div> 
  <div class ="c13101902">
                <div class="c13101903" id ="Div1">
                    �û���</div>
       <div class="c13111106" id ="Div8">
 <input id="Text1" type="text"  runat ="server" class ="c15012106" /> 
        <span style =" margin-left :2px; margin-right :2px;"><a  href="javascript:f13100202('Text1','');">
           ѡ��</a></span>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="Text1" Text="����" runat="server" />
       
         </div>
         <div class="c13111301" id ="Div34">
                        <span  style =" margin-left :30px"><asp:Label ID="Label1" runat="server" Text="" ></asp:Label></span>
                          </div>
                          <div class="c15012402" id ="Div19">
                        <span  style =" margin-left :30px"><asp:Label ID="Label2" runat="server" Text="" ></asp:Label></span>
                          </div>
           </div>
  <div id="Div3" class ="c15020901">
                <div class ="c15020902">
                <asp:GridView ID="GridView2" runat="server" 
                    AllowSorting="True"   
                  
                        AutoGenerateColumns="False" style="margin-left: 8px" PageSize="15" 
                         CssClass ="c15020903" 
                       
                   >
                   
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns > 
           <asp:TemplateField HeaderText="��ѡ" HeaderStyle-HorizontalAlign="Center" >
                <ItemTemplate >
                  
                </ItemTemplate>
                   <HeaderStyle Width="4%" />
                 <ItemStyle Width="4%"  ForeColor="#595d5a"/>
            </asp:TemplateField> 
       
               <asp:TemplateField HeaderText="��ҵ����" HeaderStyle-HorizontalAlign="Center" >
                <ItemTemplate >

                    <asp:Label ID="Label3" runat="server"   Visible ="false" CssClass ="c13120501" Text=""></asp:Label>                 
                </ItemTemplate>
                 <HeaderStyle Width="20%" />
                 <ItemStyle Width="20%"  ForeColor="#595d5a"/>
            </asp:TemplateField>
          
                <asp:TemplateField HeaderText="��ѯ"  HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate >
               
                </ItemTemplate>
           <HeaderStyle Width="4%" />
                 <ItemStyle Width="4%"  ForeColor="#595d5a"/>
            </asp:TemplateField> 
               <asp:TemplateField HeaderText="����" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate >
         
                </ItemTemplate>
              <HeaderStyle Width="4%" />
                 <ItemStyle Width="4%"  ForeColor="#595d5a"/>
            </asp:TemplateField> 
                    <asp:TemplateField HeaderText="�޸�" HeaderStyle-HorizontalAlign="Center" >
                <ItemTemplate >
              
                </ItemTemplate>
               <HeaderStyle Width="4%" />
                 <ItemStyle Width="4%"  ForeColor="#595d5a"/>
            </asp:TemplateField> 
                 <asp:TemplateField HeaderText="ɾ��" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate >
                 
                </ItemTemplate>
              <HeaderStyle Width="4%" />
                 <ItemStyle Width="4%"  ForeColor="#595d5a"/>
            </asp:TemplateField> 
         
            
                    </Columns>
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" Font-Bold="False" />  
                  
 
                </asp:GridView>
                </div>
                 
             
                </div>
                <div id="Div2" class ="c15012102">
                <div class ="c15012108">
                <asp:GridView ID="GridView1" runat="server" 
                    AllowSorting="True"   
                    onrowdatabound="GridView1_RowDataBound" 
                        AutoGenerateColumns="False" style="margin-left: 8px" PageSize="15" 
                         CssClass ="c15012107"
                       
                   >
                   
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns > 
           <asp:TemplateField HeaderText="��ѡ" >
                <ItemTemplate >
                    <asp:CheckBox ID="CheckBox1" runat="server"  Checked='<%# Bind("��ѡ��")%>'  CssClass ="c14071504"/>
                </ItemTemplate>
                   <HeaderStyle Width="4%" />
                 <ItemStyle Width="4%"  ForeColor="#595d5a"/>
            </asp:TemplateField> 
       
               <asp:TemplateField HeaderText="��ҵ����">
                <ItemTemplate >
                 <asp:TextBox ID="TextBox1" runat="server"  Text='<%#Eval ("��ҵ����") %>'  CssClass ="c13120501" ></asp:TextBox>                     
                </ItemTemplate>
                 <HeaderStyle Width="20%" />
                 <ItemStyle Width="20%"  ForeColor="#595d5a"/>
            </asp:TemplateField>
          
                <asp:TemplateField HeaderText="��ѯ" >
                <ItemTemplate >
                    <asp:CheckBox ID="CheckBox2" runat="server"  Checked='<%# Bind("��ѯ")%>'  CssClass ="c14071504"/>
                </ItemTemplate>
           <HeaderStyle Width="4%" />
                 <ItemStyle Width="4%"  ForeColor="#595d5a"/>
            </asp:TemplateField> 
               <asp:TemplateField HeaderText="����" >
                <ItemTemplate >
                    <asp:CheckBox ID="CheckBox3" runat="server"  Checked='<%# Bind("����")%>'  CssClass ="c14071504"/>
                </ItemTemplate>
              <HeaderStyle Width="4%" />
                 <ItemStyle Width="4%"  ForeColor="#595d5a"/>
            </asp:TemplateField> 
                    <asp:TemplateField HeaderText="�޸�" >
                <ItemTemplate >
                    <asp:CheckBox ID="CheckBox4" runat="server"  Checked='<%# Bind("�޸�")%>'  CssClass ="c14071504"/>
                </ItemTemplate>
               <HeaderStyle Width="4%" />
                 <ItemStyle Width="4%"  ForeColor="#595d5a"/>
            </asp:TemplateField> 
                 <asp:TemplateField HeaderText="ɾ��" >
                <ItemTemplate >
                    <asp:CheckBox ID="CheckBox5" runat="server"  Checked='<%# Bind("ɾ��")%>'  CssClass ="c14071504"/>
                </ItemTemplate>
              <HeaderStyle Width="4%" />
                 <ItemStyle Width="4%"  ForeColor="#595d5a"/>
            </asp:TemplateField> 
         
            
                    </Columns>
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" Font-Bold="False" />  
                  
 
                </asp:GridView>
                </div>
                 <div class ="c15012405">
                        <div  style ="width:100%; height :30px;  margin-top :10px;">     
                        <asp:CheckBox ID="CheckBox6" runat="server"  CssClass ="c15012403"  Text="ȫѡ" 
                                oncheckedchanged="CheckBox6_CheckedChanged" AutoPostBack="True" 
                                />
                
                        <asp:CheckBox ID="CheckBox7"  runat="server"   Text="��ѡ" AutoPostBack="True" oncheckedchanged="CheckBox7_CheckedChanged" 
                                />
                     </div>
                       <div  class="c15012406">     
                       <span  class ="c15012407">��Ȩ��Χ��</span>
                      
                           <asp:RadioButton ID="RadioButton1" runat="server"  CssClass ="c15012404" 
                               Text="�����û�" oncheckedchanged="RadioButton1_CheckedChanged" 
                               AutoPostBack="True" />
                           <asp:RadioButton ID="RadioButton2" runat="server" CssClass ="c15012404" 
                               Text="�����û�" AutoPostBack="True" 
                               oncheckedchanged="RadioButton2_CheckedChanged" />
                           <asp:RadioButton ID="RadioButton3" runat="server" CssClass ="c15012404" 
                               Text="��ǰ�û�" AutoPostBack="True" 
                               oncheckedchanged="RadioButton3_CheckedChanged" />
                     </div>
                     <div  class="c15012406">     
                       <span  class ="c15012407"><asp:Label ID="Label4" runat="server" Text="Label"></asp:Label></span>
                         <asp:CheckBox ID="CheckBox8" runat="server" AutoPostBack="True"  oncheckedchanged="CheckBox8_CheckedChanged"/>
                      
                           
                           
                           
                     </div>
                </div>
             
                </div>
                
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
              dlgResult = window.showModalDialog("../USERMANAGE/USERINFO.aspx?emid="+document .getElementById ("emid").value +"", window, "dialogWidth:970px; dialogHeight:490px; status:0;");
              if (dlgResult != undefined) {

                  document.getElementById("Text1").value = dlgResult[0];
                  document.all("Label1").innerText = dlgResult[1];
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