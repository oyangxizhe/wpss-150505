<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PAYMENT_ORDERT.aspx.cs" Inherits="WPSS.FINANCIAL_MANAGE.PAYMENT_ORDERT" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>�༭������Ϣ</title>
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
                <div class ="c13101905">
      <div class="c13101906" id ="Div9">
>�༭������Ϣ</div>
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
      <div class="c13101903" id ="Div24">
          �����</div>
     <div class="c14031403" id ="Div25">
<input id="Text1" type="text"  runat="server"   readonly ="readonly" class="c14031401"/> 
         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="Text1" Text="����" runat="server" /></div>
         <div class="c13101903" id ="Div26">
             ����</div>
     <div class="c14031403" id ="Div27">
       <input id="Text2" type="text"  runat="server" class="c14011901" />
          <span style =" margin-left :2px; margin-right :10px;"><a  href="javascript:f13100202('Text2','');">
         ѡ��</a></span>
       </div>
  
           <div class="c13101903" id ="Div44">
               ��Ӧ������</div>
     <div class="c14031403"  id ="Div45">
   <input id="Text3" type="text"  runat ="server"  class ="c15020101"  onclick="return Text3_onclick()" /></div>
                     <div class="c13101903" id ="Div1">
                            ��Ʊ����</div>
    <div class="c14031403" id ="Div2">
  <input id="Text4" type="text" runat="server"  readonly="readonly" class ="c13112201"/>
         </div>

           </div>
             <div class ="c13101902">
                               <div class="c13101903" id ="Div38">
                            ��Ʊ��˰���</div>
    <div class="c14031403" id ="Div5">
  <input id="Text5" type="text" runat="server"  readonly="readonly" class ="c15020204"/>
         </div>
                    <div class="c13101903" id ="Div28">
                        Ԥ�����</div>
     <div class="c14031403" id ="Div29">
 <input id="Text6" type="text" runat="server"  readonly="readonly" class ="c13112201"/>
         
         </div>
                             <div class="c13101903" id ="Div18">
                                 Ԥ�����</div>
     <div class="c14031403" id ="Div19">
   <input id="Text7" type="text" runat="server" readonly="readonly" class ="c15020204"/>
      </div>
                                <div class="c13101903" id ="Div8">
                                    �ۿ���Ŀ </div>
     <div class="c14031403" id ="Div20">
     <input id="Text8" type="text" runat="server"  readonly="readonly" class ="c15020204"/> </div>
      </div> 
             <div class ="c13101902">
                                                      <div class="c13101903" id ="Div30">
                                    �ۿ��� </div>
     <div class="c14031403" id ="Div31">
     <input id="Text9" type="text" runat="server"  readonly="readonly" class ="c15020204"/> </div>
                                          <div class="c13101903" id ="Div16">
                                    ʵ������� </div>
     <div class="c14031403" id ="Div17">
     <input id="Text10" type="text" runat="server"  readonly="readonly" class ="c15020204"/> </div>
                               <div class="c13101903" id ="Div3">
                                   �ۼƸ�����</div>
    <div class="c14031403" id ="Div4">
  <input id="Text11" type="text" runat="server" readonly="readonly" class ="c15020204"/>
         </div>
                    <div class="c13101903" id ="Div6">
                        δ������</div>
     <div class="c14031403" id ="Div7">
 <input id="Text12" type="text"  runat="server"  class ="c15020204" />
         
         </div>
   

 
      </div> 
      <div class ="c13101902">
                      <div class="c13101903" id ="Div32">
                        ������</div>
     <div class="c14031403" id ="Div33">
 <input id="Text13" type="text"  runat="server"  class="c15020203" />
         
         </div>
    
                                     <div class="c13101903" id ="Div34">
                                 ������</div>
     <div class="c14031403" id ="Div35">
     <input id="Text14" type="text"  runat="server"   onclick="f13100202('Text14','')" class="c14112604" />
      
                   <asp:Label ID="Label1" runat="server" Text="" ></asp:Label>
      </div>
                           <div class="c13101903" id ="Div22">
                              �������� </div>
     <div class="c14031403" id ="Div23">
     <span style =" margin-right :8px;">
   <input id="Text15" type="text"  runat="server" onclick ="f13100202('Text15')"  readonly="readonly" class="c14011901" />
       
                    </span> </div>
                    
                              
      </div>
      <div class ="c13111601">
       
<div class="c13111503" id ="Div36">
      <span style="color :#990033"> (ѡ�����˵㾭�����ı���) </span>
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
                  dlgResult = window.showModalDialog("../financial_manage/request_money.aspx", window, "dialogWidth:970px; dialogHeight:490px; status:0;");
                  if (dlgResult != undefined) {

                      document.getElementById("Text2").value = dlgResult[0];
                      document.getElementById("Text3").value = dlgResult[1];
                      document.getElementById("Text4").value = dlgResult[2];
                      document.getElementById("Text5").value = dlgResult[3];
                      document.getElementById("Text6").value = dlgResult[4];
                      document.getElementById("Text7").value = dlgResult[5];
                      document.getElementById("Text8").value = dlgResult[6];
                      document.getElementById("Text9").value = dlgResult[7];
                      document.getElementById("Text10").value = dlgResult[8];
                      document.getElementById("Text11").value = dlgResult[9];
                      document.getElementById("Text12").value = dlgResult[10];
                      document.getElementById("Text13").focus();
                  }

              }
              else if (obj == "Text14") {

              dlgResult = window.showModalDialog("../BaseInfo/EMPLOYEEINFO.aspx", window, "dialogWidth:970px; dialogHeight:490px; status:0;");
              if (dlgResult != undefined) {
                  document.getElementById("Text14").value = dlgResult[0];
                  document.all("Label1").innerText = dlgResult[1];
              }
               

              }
              else if (obj == "Text15") {
              dlgResult = window.showModalDialog("../WDate.aspx", window, "dialogWidth:160px; dialogHeight:240px; status:0;");
              if (dlgResult != undefined) {


                  document.getElementById("Text15").value = dlgResult;
              }

              }
         

          }
          function enter2tab(e) {
              if (window.event.keyCode == 13) window.event.keyCode = 9
          }
          document.onkeydown = enter2tab;
          document.getElementById("Text13").focus();
          function Text3_onclick() {

          }

      </script>

    </form>
</body>
</html>
