<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CASH_ADDT.aspx.cs" Inherits="WPSS.CASH_MANAGE.CASH_ADDT" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>�༭����ֽ��˻���ֵ</title>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" /> 
<meta name ="Description" content ="" />
<meta name ="keywords" content ="" />
       <link href ="../Css/SSBase.css"  type ="text/css" rel ="Stylesheet" />
       <link href ="../Css/S131017.css"  type ="text/css" rel ="Stylesheet" />
    </head>
<body >
   <form id="form1" runat="server">
   <input id="hint" type="hidden"  runat="server" />
     <input id="emid" type="hidden"  runat="server" />
                <div class ="c13101905">
      <div class="c13101906" id ="Div9">
          &gt;�༭����ֽ��˻���ֵ<div class="c13101907" id ="Div10">
 </div>
    </div></div> 
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
          
         <div class="c13110507" id ="Div21">
                  <span class="c13110503" id ="Span2">
     <asp:ImageButton ID="btnExit" 
                 runat="server" ImageUrl="~/Image/btnExit.png" Width="60px" 
                      onclick="btnExit_Click" />
          </span>
   </div>
                 <div class="c13110510" id ="Div15">
   <span class="c13110511" id ="Span6">
                     (�˳�)
          </span>
       </div>
    </div>
<div  id="i13102301" class ="c13102101">
<span  class ="c13102102"><asp:Label ID="prompt" runat="server"  ForeColor="#f80707"></asp:Label></span>
</div> 
  <div class ="c13101902">
      <div class="c13101903" id ="Div2">
   ��� </div>
     <div class="c13101904"  id ="Div4">
<input id="Text1" type="text"  runat="server"   readonly ="readonly" class="c13102103" /> 
         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="Text1" Text="����" runat="server" /></div>
         <div class="c13101903" id ="Div5">
            �˻���</div>
     <div class="c13101904"  id ="Div6">
   <input id="Text2" type="text"  runat ="server" class ="c15051101" /> 
           <span style =" margin-left :2px; margin-right :10px;"><a  href="javascript:f13100202('Text2','');">
         ѡ��</a></span> </div>
      <div class="c13101903" id ="Div7">
          ��ֵ��� </div>
     <div class="c14120501" id ="Div8">
     <span style =" margin-right :8px;">
<input id="Text4" type="text"  runat="server"    class="c15051102" />
   <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="Text4" Text="����" runat="server" />                 
                    </span> </div>
           </div>
             <div class ="c13101902">

                          <div class="c13101903" id ="Div16">
                              �쿨���� </div>
     <div class="c13101904" id ="Div17">
     <span style =" margin-right :8px;">
   <input id="Text5" type="text"  runat="server" onclick ="f13100202('Text5')" readonly="readonly" class ="c13110901" />
       
                    </span> </div>
                             <div class="c13101903" id ="Div18">
                                 ������</div>
     <div class="c13111503" id ="Div19">
     <input id="Text6" type="text"  runat="server"   class ="c14112009"/>
        <span style =" margin-left :2px; margin-right :10px;"><a  href="javascript:f13100202('Text6','');">
         ѡ��</a></span>
                   <asp:Label ID="Label1" runat="server" Text="" ></asp:Label>
      </div>
      </div> 
           <div class ="c13122402">

          <div class="c13101903" id ="Div108">
                 ��ע</div>
     <div class="c13122401" id ="Div109">

         <asp:TextBox ID="TextBox1" runat="server"   TextMode="MultiLine" CssClass ="c13122403"></asp:TextBox>
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
              var dlgResult;
              if (obj == "Text2") {
                  dlgResult = window.showModalDialog("../usermanage/userinfo.aspx?emid="+document .getElementById ("emid").value +"", window, "dialogWidth:970px; dialogHeight:490px; status:0;");
                  if (dlgResult != undefined) {


                      document.getElementById("Text2").value = dlgResult[2];
                  }

              }
              else  if (obj == "Text5") {
                  dlgResult = window.showModalDialog("../WDate.aspx", window, "dialogWidth:160px; dialogHeight:240px; status:0;");
                  if (dlgResult != undefined) {


                      document.getElementById("Text5").value = dlgResult;
                  }

              }
              else if (obj == "Text6") {
              dlgResult = window.showModalDialog("../BaseInfo/EMPLOYEEINFO.aspx?emid=" + document.getElementById("emid").value + "", window, "dialogWidth:970px; dialogHeight:490px;status:0;");
                  if (dlgResult != undefined) {


                      document.getElementById("Text6").value = dlgResult[0];
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
