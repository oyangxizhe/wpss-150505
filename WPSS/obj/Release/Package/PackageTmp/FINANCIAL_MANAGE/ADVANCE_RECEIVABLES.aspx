<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ADVANCE_RECEIVABLES.aspx.cs" Inherits="WPSS.FINANCIAL_MANAGE.ADVANCE_RECEIVABLES" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Ԥ�տ���ҵ</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" /> 
<meta name ="Description" content ="���������ϵͳ" />
<meta name ="keywords" content ="���������ϵͳ,������������,ERP,С΢��ҵ����ϵͳ,ϣ�����" />
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
          &gt;Ԥ�տ���ҵ</div>
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
                  (����)
          </span>
       </div>
       <div class="c13110504" id ="Div19">
<span id="i13052904"  class ="c13110505"  >
           ��������</span> </div>
          <div class="c13110506" id ="Div20">
          <div class ="c13110101">
                        <div class="c13110104" id ="Div5">
                                                        Ԥ�տ�ţ�</div>
     <div class="c14111903" id ="Div6">
            <input id="Text1" type="text"  runat ="server" class="c14111902" /></div>
                            <div class="c13110104" id ="Div1">
                                �ͻ�
                            </div>
     <div class="c14111903" id ="Div14">
     <input id="Text2" type="text"  runat ="server" class="c14111902" />
                        </div>
           </div>
           <div class ="c13110105">
                        <div class="c13110104" id ="Div2">
                            <asp:CheckBox ID="CheckBox1" runat="server" 
                             />
                            �����ڼ䣺</div>
     <div class="c14111903" id ="Div8">
     <span style =" margin-right :8px;">
     <input id="StartDate" type="text" runat="server"   onclick ="f13100202('StartDate')" class ="c14111902" />
   </span> </div>
          <div class="c13110104" id ="Div12">
              <span class="c14111901">��</span>
  
  
                 </div>
     <div class="c14111903" id ="Div13">
  <input id="EndDate" type="text" runat="server"  onclick ="f13100202('EndDate')" class ="c14111902" /></div>
     
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

             <div >
         
               <asp:GridView ID="GridView1" runat="server" 
                    AllowPaging="True" 
                    onpageindexchanging="GridView1_PageIndexChanging" 
                    onrowdeleting="GridView1_RowDeleting" 
                    AllowSorting="True"   
                    onrowdatabound="GridView1_RowDataBound" 
                        onselectedindexchanged="GridView1_SelectedIndexChanged" 
                        AutoGenerateColumns="False" PageSize="15" 
                       CssClass ="c15020202"
                   
                   >
                   
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns >
                    <asp:TemplateField HeaderText="ѡȡ">
                   <ItemTemplate>
         <a href ="javascript:f13100302('<%#Eval ("Ԥ�տ��") %>','<%#Eval ("Ԥ�ս��") %>')">
                       ѡȡ</a>
                   </ItemTemplate>
                            <HeaderStyle Width="40px" HorizontalAlign="Center" />
                 <ItemStyle Width="40px"  />
                   </asp:TemplateField>
              <asp:TemplateField HeaderText="ɾ��" >
                <ItemTemplate >
                    <asp:LinkButton ID="LinkButton2" runat="server" 
                        OnClientClick="return confirm('��ȷ��ɾ���ü�¼��?');" Text="ɾ��"  CommandName ="delete" ></asp:LinkButton>                     
                </ItemTemplate>
                 <HeaderStyle Width="40px" />
                 <ItemStyle Width="40px"  />
            </asp:TemplateField>  
             <asp:TemplateField HeaderText="Ԥ�տ��">
                <ItemTemplate >
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Select"  
                        Text='<%# Bind("Ԥ�տ��") %>'></asp:LinkButton>                     
                </ItemTemplate>
                 <HeaderStyle Width="100px" />
                 <ItemStyle Width="100px"  ForeColor="#595d5a"/>
            </asp:TemplateField>   
                    
                       
                                   <asp:BoundField DataField="�ͻ�����" HeaderText="�ͻ�����" >
                    <ItemStyle Width="150px" ForeColor="#595d5a" />
                                    <HeaderStyle HorizontalAlign="Center" Width="150px" />
                          </asp:BoundField>
                             <asp:BoundField DataField="Ԥ�ս��" HeaderText="Ԥ�ս��" >
                            <ItemStyle Width="80px"  ForeColor="#595d5a"  HorizontalAlign="Right" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Right" />
                          </asp:BoundField>
                            <asp:BoundField DataField="�����" HeaderText="�����" >
                            <ItemStyle Width="80px"  ForeColor="#595d5a"   />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                           
                          <asp:BoundField DataField="�Ƶ���" HeaderText="�Ƶ���" >
                              <ItemStyle Width="80px"  ForeColor="#595d5a"/>
                                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                          </asp:BoundField>
                          <asp:BoundField DataField="�Ƶ�����" HeaderText="�Ƶ�����" 
                              DataFormatString="{0:yyyy-MM-dd}" >
                               <HeaderStyle HorizontalAlign="Center" Width="140px" />
                              <ItemStyle Width="140px"  ForeColor="#595d5a"/>
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
          <span class="c13102304"> ת��<asp:TextBox ID="txtNum" runat="server"  Width="73px"></asp:TextBox></span><span class="c13102304">ҳ</span>
          <span class="c13102304"> <asp:Button ID="btngo" runat="server"  Text="GO��"   style="width:45px" onclick="btngo_Click" /></span>
               
</div>
<script type="text/javascript" language="javascript">
    function f13100302(obj,obj1) {
        var arr1 = new Array();
        arr1[0] = obj;
        arr1[1] = obj1;
      
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

        }
        else {
            document.getElementById("i14031701").style.display = "none";

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
