<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditRight.aspx.cs" Inherits="WPSS.UserManage.EditRight" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>�༭�û�Ȩ��</title>
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
       <div >
                  <div class ="c13101905">
      <div class="c13101906" id ="Div9">
          &gt;�༭�û�Ȩ�� </div>
     <div class="c13101907" id ="Div10">
 </div>
     </div>
     <div class ="c13110501">
      <div class="c13110502" id ="Div14">
   <span class="c13110508" id ="Span1">
       <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="~/Image/btnAdd.png" 
              onclick="btnAdd_Click"  />
          </span>
       </div>
       <div class="c13110510" id ="Div1">
   <span class="c13110511" id ="Span3">
           (����)
          </span>
       </div>
       <div class="c13110504" id ="Div19">
<span id="i13052904"  class ="c13110505"  >
��������</span> </div>
          <div class="c13110506" id ="Div20">
          <div class ="c13110101">
                        <div class="c13110104" id ="Div5">
                            �û�����</div>
     <div class="c14111903" id ="Div6">
            <input id="Text1" type="text"  runat ="server" class="c14111902" /></div>
          <div class="c13110102" id ="Div15">
                 </div>
     <div class="c14111903" id ="Div16">
         &nbsp;</div>
           </div>
           <div class ="c13110105">
                        <div class="c13110104" id ="Div2">
                               <asp:CheckBox ID="CheckBox1" runat="server" 
                             />�����ڼ䣺</div>
     <div class="c14111903" id ="Div8">
     <span style =" margin-right :8px;">
     <input id="StartDate" type="text" runat="server" onclick ="f13100202('StartDate')" class ="c14111902" />
   </span> </div>
          <div class="c13110102" id ="Div12">
            <span class="c14111901">��</span>
                 </div>
     <div class="c14111903" id ="Div13">
  <input id="EndDate" type="text" runat="server" onclick ="f13100202('EndDate')" class ="c14111902" /></div>
     
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
   <span class="c13110511" id ="Span4">
(����)
          </span>
       </div>
    </div>
 
             </div>
   <div  id="i13102301" class ="c13102101">
<span  class ="c13102102"><asp:Label ID="prompt" runat="server"  ForeColor="#f80707"></asp:Label></span>
</div>
                <div >
         
               <asp:GridView ID="GridView1" runat="server" Width="65%" 
                    AllowPaging="True" 
                    onpageindexchanging="GridView1_PageIndexChanging" 
                    onrowdeleting="GridView1_RowDeleting" 
                    AllowSorting="True"   
                    onrowdatabound="GridView1_RowDataBound" 
                        onselectedindexchanged="GridView1_SelectedIndexChanged" 
                        AutoGenerateColumns="False" style="margin-left: 8px" PageSize="15" 
                         CssClass ="c13102001"
                   
                   >
                   
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns >
          
                <asp:CommandField ShowDeleteButton="True" HeaderText="ɾ��" >
                              <ItemStyle Width="40px"  ForeColor="#595d5a"/>
                                    <HeaderStyle HorizontalAlign="Center" Width="40px" />
                          </asp:CommandField>
             <asp:TemplateField HeaderText="�û���">
                <ItemTemplate >
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Select" 
                        Text='<%# Bind("�û���") %>'></asp:LinkButton>                     
                </ItemTemplate>
                 <HeaderStyle Width="60px" />
                 <ItemStyle Width="60px"  ForeColor="#595d5a"/>
            </asp:TemplateField>   
                   
                            <asp:BoundField DataField="����" HeaderText="�û�����" >
                              <ItemStyle Width="80px"  ForeColor="#595d5a"/>
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                          </asp:BoundField>
                                  <asp:BoundField DataField="��ҵ����" HeaderText="��ҵ����" >
                              <ItemStyle Width="120px"  ForeColor="#595d5a"/>
                                    <HeaderStyle Width="120px" HorizontalAlign="Center" />
                          </asp:BoundField>
                          <asp:BoundField DataField="�Ƶ���" HeaderText="�Ƶ���" >
                              <ItemStyle Width="80px"  ForeColor="#595d5a"/>
                                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                          </asp:BoundField>
                          <asp:BoundField DataField="�Ƶ�����" HeaderText="�Ƶ�����" 
                              DataFormatString="{0:yyyy-MM-dd}" >
                               <HeaderStyle HorizontalAlign="Center" Width="120px" />
                              <ItemStyle Width="120px"  ForeColor="#595d5a"/>
                          </asp:BoundField>
                
                            
                    </Columns>
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" Font-Bold="False" />   
                </asp:GridView>
                </div> 
          <div id="i13111401" class ="c13102303">
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
<script type="text/javascript" language="javascript">
    function f13100302(result) {
        if (window.opener != undefined) {
            //for chrome
            window.opener.returnValue = result;
        }
        else {
            window.returnValue = result;
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
            document.getElementById("i13111401").style.display = "block";

        }
        else {
            document.getElementById("i13111401").style.display = "none";
       
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

