<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OfferSearchT.aspx.cs" Inherits="WPSS.SellManage.OfferSearchT" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>编辑报价单</title>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" /> 
<meta name ="Description" content ="进销存管理系统" />
<meta name ="keywords" content ="进销存管理系统,进销存管理软件,ERP,小微企业管理系统,希哲软件" />
       <link href ="../Css/SSBase.css"  type ="text/css" rel ="Stylesheet" />
       <link href ="../Css/S131017.css"  type ="text/css" rel ="Stylesheet" />
    </head>
<body >
   <form id="form1" runat="server">
   <input id="hint" type="hidden"  runat="server" />
                <div class ="c13101905">
      <div class="c13101906" id ="Div9">
>编辑报价单 </div>
     <div class="c13101907" id ="Div10">
 </div>
    </div>
<div class ="c13110501">
      <div class="c13110502" id ="Div2">
       </div>
              <div class="c13110510" id ="Div4">
   <span class="c13110511" id ="Span4">

          </span>
       </div>
             <div class="c13110502" id ="Div5">
   <span class="c13110508" id ="Span3">
       <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/Image/btnSave.png" 
                     onclick="btnSave_Click"  />
          </span>
       </div>
              <div class="c13110510" id ="Div6">
   <span class="c13110511" id ="Span5">
(保存)
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
                     (退出)
          </span>
       </div>
       <div class="c13110507" id ="Div41">
                  <span class="c13110503" id ="Span7">
     <asp:ImageButton ID="btnPrint" 
                 runat="server" ImageUrl="~/Image/btnPrint.png" Width="60px" 
                      onclick="btnPrint_Click" />
          </span>
   </div>
                 <div class="c13110510" id ="Div42">
   <span class="c13110511" id ="Span8">
                     (打印)
          </span>
       </div>
    </div>
<div  id="i13102301" class ="c13102101">
<span  class ="c13102102"><asp:Label ID="prompt" runat="server"  ForeColor="#f80707"></asp:Label></span>
</div> 

           <div class ="c13101902">
      <div class="c13122302" id ="Div1">
          销售单价代码</div>
     <div class="c14031403" id ="Div3">
<input id="Text1" type="text"  runat="server"   readonly ="readonly" class="c14031401"/> 
         </div>
                 <div class="c13122302" id ="Div12">
              ID</div>
     <div class="c14031403" id ="Div13">
   <input id="Text2" type="text"    runat ="server" class ="c14040704" /> 
        <span style =" margin-left :5px"> <a  href="javascript:f13100202('Text2');"></a></span> 
        </div>
                  <div class="c13122302" id ="Div11">
                     料号</div>
     
  <div class="c14031403" id ="Div14">
   <input id="Text3" type="text"  runat ="server" class ="c14040704" /> </div>
         <div class="c13122302" id ="Div7">
          品名</div>
     <div  class="c14120501" id ="Div8">
<input id="Text4" type="text"  runat="server"   readonly ="readonly" class="c14040704"/> 
         </div>
           </div>
           <div class ="c13101902">

                 <div class="c13122302" id ="Div18">
              客户料号</div>
     <div class="c14031403" id ="Div19">
   <input id="Text5" type="text"    runat ="server" class ="c14040704" /> 
     </div>
                  <div class="c13122302" id ="Div20">
                      客户</div>
     
  <div class="c14031403" id ="Div22">
   <input id="Text6" type="text"  runat ="server" class ="c14040705" /> 
           </div>
                            <div class="c13122302" id ="Div16">
                     销售单价</div>
     <div class="c14031403" id ="Div17">
   <input id="Text7" type="text"    runat ="server" class ="c14040704" /> (未税)
         </div>
              <div class="c13122302" id ="Div26">
              量产单价</div>
     <div  class="c14120501" id ="Div27">
   <input id="Text8" type="text"    runat ="server" class="c14031401" /> 
     </div>
           </div> 
           <div class ="c13101902">

                   <div class="c13122302" id ="Div28">
              量产数量</div>
     <div class="c14031403" id ="Div29">
   <input id="Text9" type="text"    runat ="server" class="c14031401" /> 
     </div>
                      <div class="c13122302" id ="Div30">
                    Sample单价</div>
     <div class="c14031403" id ="Div31">
   <input id="Text10" type="text"    runat ="server" class="c14031401"/> 
         </div>
              <div class="c13122302" id ="Div32">
              Sample数量</div>
     <div class="c14031403" id ="Div33">
   <input id="Text11" type="text"    runat ="server" class="c14031401" /> 
     </div>
                   <div class="c13122302" id ="Div34">
              小量单价</div>
     <div  class="c14120501" id ="Div35">
   <input id="Text12" type="text"    runat ="server" class="c14031401" /> 
     </div>
           </div>
           <div class ="c13101902">
                 <div class="c13122302" id ="Div36">
                     小量数量</div>
     <div class="c14031403" id ="Div37">
   <input id="Text13" type="text"    runat ="server" class ="c14040705" /> 
         </div>
              <div class="c13122302" id ="Div38">
               工程费</div>
     <div class="c14031403" id ="Div39">
   <input id="Text14" type="text"    runat ="server" class="c14031401" /> 
     </div>  
                <div class="c13122302" id ="Div43">
               报价单号</div>
     <div class="c14031403" id ="Div44">
   <input id="Text15" type="text"    runat ="server" class ="c14040704" /> 
     </div>
      <div class="c13122302" id ="Div40">
                     </div>

           </div>
           <div class ="c13122402">

          <div class="c13122302" id ="Div108">
                 备注</div>
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
          function f13100202(obj) {
              var dlgResult;
              if (obj == "Text2") {
                  dlgResult = window.showModalDialog("../baseinfo/wareinfo.aspx", window, "dialogWidth:970px; dialogHeight:490px; status:0");
                  if (dlgResult != undefined) {

                      document.getElementById("Text2").value = dlgResult[0];
                      document.getElementById("Text3").value = dlgResult[1];
                      document.getElementById("Text4").value = dlgResult[2];
                      document.getElementById("Text5").value = dlgResult[3];
                      document.getElementById("Text6").value = dlgResult[4];

                  }
              }
              else if (obj == "Text3") {
                  dlgResult = window.showModalDialog("../SELLManage/CUSTOMERinfo.aspx", window, "dialogWidth:970px; dialogHeight:490px; status:0");
                  if (dlgResult != undefined) {

                      document.getElementById("Text3").value = dlgResult[1];
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