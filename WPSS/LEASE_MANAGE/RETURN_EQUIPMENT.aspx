<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RETURN_EQUIPMENT.aspx.cs" Inherits="WPSS.LEASE_MANAGE.RETURN_EQUIPMENT" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>�黹��ҵ</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" /> 
<meta name ="Description" content ="ERP����ϵͳ" />
<meta name ="keywords" content ="ERP����ϵͳ,ERP�������,ERP,С΢��ҵ����ϵͳ,ϣ�����" />
   <link href ="../Css/SSBase.css"  type ="text/css" rel ="Stylesheet" />
      <link href ="../Css/S131017.css"  type ="text/css" rel ="Stylesheet" />
 <base target ="_self" /> 
    </head>
<body>  

    <form id="form1" runat="server">
           <input id="hint" type="hidden"  runat="server" />
        <input id="x" type="hidden"  runat="server" />
          <input id="x1" type="hidden"  runat="server" />
       <div >
                  <div class ="c13101905">
      <div class="c13101906" id ="Div9">
          &gt;�黹��ҵ</div>
     <div class="c13101907" id ="Div10">
 </div>
     </div>
        </div>
<div class ="c13110501">
   <div class="c13110502" id ="Div4">
   <span class="c13110508" id ="Span1">
       <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="~/Image/btnAdd.png"    onclick="btnAdd_Click"  />
          </span>
       </div>
              <div class="c13110510" id ="Div7">
   <span class="c13110511" id ="Span11">
                  <asp:Label ID="Label1" runat="server" Text="(����)"></asp:Label>
          </span>
       </div>
       <div class="c13110504" id ="Div19">
<span id="i13052904"  class ="c13110505"  >
           ��������</span> </div>
          <div class="c13110506" id ="Div20">
          <div class ="c13110101">
                        <div class="c13110104" id ="Div5">
                                                      <asp:CheckBox ID="CheckBox1" runat="server" />  �ͻ���</div>
     <div class="c14111903" id ="Div6">
            <input id="Text1" type="text"  runat ="server" class="c14062804" /></div>
                                   <div class="c13110104" id ="Div34">
                                       �黹���ţ�
                              </div>
     <div class="c14111903" id ="Div35">
 <input id="Text2" type="text"  runat ="server" class="c14111902" />
                            </div>
           </div>
          <div class ="c13110101">
                        <div class="c13110104" id ="Div27">
                            Ʒ����</div>
     <div class="c14111903" id ="Div28">
            <input id="Text3" type="text"  runat ="server" class="c14062804" /></div>
                            <div class="c13110104" id ="Div29">
                                Ʒ�ţ�</div>
     <div class="c14111903" id ="Div30">
     <input id="Text4" type="text"  runat ="server" class="c14111902" />
                            </div>
           </div> 
           
</div>
         <div class="c13110507" id ="Div21">
                  <span class="c13110503" id ="Span2">
     <asp:ImageButton ID="btnSearch" 
                 runat="server" ImageUrl="~/Image/btnSearch.png" Width="60px" 
                      onclick="btnSearch_Click" />
          </span>
   </div>
          <div class="c13110510" id ="Div3">
   <span class="c13110505" id ="Span4">
              <asp:Label ID="Label2" runat="server" Text="(����)"></asp:Label>
              </span>
       </div>
       <div class="c13110507" id ="Div16">
   </div>
    </div>
    
     
 <div  id="i13102301" class ="c13102101">
<span  class ="c13102102"><asp:Label ID="prompt" runat="server"  ForeColor="#f80707"></asp:Label></span>
</div>

                      <div id="i14061401">
         
                          
         
               <asp:GridView ID="GridView1" runat="server" 
                    AllowPaging="True" 
                    onpageindexchanging="GridView1_PageIndexChanging" 
                    onrowdeleting="GridView1_RowDeleting" 
                    AllowSorting="True"   
                    onrowdatabound="GridView1_RowDataBound" 
                        onselectedindexchanged="GridView1_SelectedIndexChanged" 
                        AutoGenerateColumns="False" style="margin-left: 8px" PageSize="15" 
                         CssClass ="c14061201"
                   
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
             <asp:TemplateField HeaderText="�黹����">
                <ItemTemplate >
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Select" 
                        Text='<%# Bind("�黹����") %>'></asp:LinkButton>                     
                </ItemTemplate>
                 <HeaderStyle Width="100px" />
                 <ItemStyle Width="100px"  ForeColor="#595d5a"/>
            </asp:TemplateField>  
                           <asp:BoundField DataField="ID" HeaderText="ID" >
                              <ItemStyle Width="80px" ForeColor="#595d5a" />
                                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                          </asp:BoundField>
               <asp:BoundField DataField="�Ϻ�" HeaderText="Ʒ��" >
                              <ItemStyle Width="150px" ForeColor="#595d5a" />
                                    <HeaderStyle HorizontalAlign="Center" Width="150px" />
                          </asp:BoundField>  
                        
                             <asp:BoundField DataField="Ʒ��" HeaderText="Ʒ��" >
                              <ItemStyle Width="130px" ForeColor="#595d5a" />
                                    <HeaderStyle HorizontalAlign="Center" Width="130px" />
                          </asp:BoundField>
                                   <asp:BoundField DataField="�黹����" HeaderText="�������" >
                              <ItemStyle Width="80px" ForeColor="#595d5a" />
                                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                          </asp:BoundField>
                            <asp:BoundField DataField="�����" HeaderText="�����" >
                              <ItemStyle Width="80px" ForeColor="#595d5a" />
                                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                          </asp:BoundField>
                           <asp:BoundField DataField="��������" HeaderText="��������" >
                              <ItemStyle Width="80px" ForeColor="#595d5a" />
                                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                          </asp:BoundField>
                          
                              <asp:BoundField DataField="���" HeaderText="���" >
                              <ItemStyle Width="80px" ForeColor="#595d5a" />
                                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                          </asp:BoundField>
                             <asp:BoundField DataField="Ѻ��" HeaderText="Ѻ��" >
                              <ItemStyle Width="80px" ForeColor="#595d5a" />
                                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                          </asp:BoundField>
                               <asp:BoundField DataField="�Ƶ���" HeaderText="�Ƶ���" >
                              <ItemStyle Width="80px" ForeColor="#595d5a" />
                                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                          </asp:BoundField>
                              <asp:BoundField DataField="�Ƶ�����" HeaderText="�Ƶ�����" >
                              <ItemStyle Width="140px" ForeColor="#595d5a" />
                                    <HeaderStyle HorizontalAlign="Center" Width="140px" />
                          </asp:BoundField>
                    </Columns>
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" Font-Bold="False" />   
                </asp:GridView>
                </div> 
          <div id="i14031701" class ="c13102303">
          <span class="c13102304"><asp:Label ID="lblRecordCount" runat="server"></asp:Label></span>
          <span class="c13102304"><asp:Label ID="lblPageCount" runat="server"></asp:Label></span>
          <span class="c13102304"><asp:Label ID="lblCurrentIndex" runat="server"></asp:Label></span>
          <span class="c13102304"><asp:LinkButton ID="btnFirst" runat="server" CommandArgument="First" onclick="PageButton_Click">��ҳ</asp:LinkButton></span>
          <span class="c13102304"><asp:LinkButton ID="btnPrev" runat="server" CommandArgument="Prev" onclick="PageButton_Click">��һҳ</asp:LinkButton></span>  
          <span class="c13102304"><asp:LinkButton ID="btnNext" runat="server" CommandArgument="Next" onclick="PageButton_Click">��һҳ</asp:LinkButton></span>
          <span class="c13102304"><asp:LinkButton ID="btnLast" runat="server" CommandArgument="Last" onclick="PageButton_Click">βҳ</asp:LinkButton></span>
          <span class="c13102304"> ת��</span>
          <span class="c13102304"><asp:TextBox ID="txtNum" runat="server"  Width="73px"></asp:TextBox></span>
          <span class="c13102304"> ҳ</span>
          <span class="c13102304"> <asp:Button ID="btngo" runat="server"  Text="GO��"   style="width:45px" onclick="btngo_Click" /></span>
               
</div>
<div id ="i13111501" class ="c13101902">
                                 <div class="c13102907" id ="Div1">
                                 </div>
    <div class="c14112014" id ="Div14">
          �ϼ������</div>
     <div class="c13101904" id ="Div15">
        <input id="Text50" type="text"  runat="server"    class="c13102908"/></div>
   <div class="c14112014" id ="Div2">
          �ϼ�Ѻ��</div>
     <div class="c13101904" id ="Div8">
        <input id="Text51" type="text"  runat="server"    class="c13102908"/></div>
  <div class="c14112014" id ="Div11">
          �ϼ����</div>
     <div class="c13101904" id ="Div12">
        <input id="Text52" type="text"  runat="server"    class="c13102908"/></div>
 
           </div>
<script type="text/javascript" language="javascript">
    function f13100302(obj, obj1,obj2,obj3,obj4) {
        var arr1 = new Array();
        arr1[0] = obj;
        arr1[1] = obj1;
        arr1[2] = obj2;
        arr1[3] = obj3;
        arr1[4] = obj4;
        
        if (window.opener != undefined) {
            //for chrome
            window.opener.returnValue = arr1;
        }
        else {
            window.returnValue = arr1;
        }
        window.close();
    }
    window.onload = function onload1() {
    var Invocation = document.getElementById("hint").value;
    var Invocation1 = document.getElementById("x").value;
        if (Invocation != "") {
            document.getElementById("i13102301").style.display = "block";
            document.all("prompt").innerText = Invocation;
        }
        else {
            document.getElementById("i13102301").style.display = "none";
        }
        if (Invocation1 != "") {
            document.getElementById("i14031701").style.display = "block";
            document.getElementById("i14061401").style.display = "block";

        }
        else {
            document.getElementById("i14031701").style.display = "none";
            document.getElementById("i14061401").style.display = "none";
        }
    }
    function f13100202(obj) {
        var dlgResult;
        if (obj == "StartDate") {
            dlgResult = window.showModalDialog("../WDate.aspx", window, "dialogWidth:160px; dialogHeight:240px; status:0;");
            if (dlgResult != undefined) {


                document.getElementById("startdate").value = dlgResult;
            }

        }
        else {
            dlgResult = window.showModalDialog("../WDate.aspx", window, "dialogWidth:160px; dialogHeight:240px; status:0;");
            if (dlgResult != undefined) {


                document.getElementById("enddate").value = dlgResult;
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
