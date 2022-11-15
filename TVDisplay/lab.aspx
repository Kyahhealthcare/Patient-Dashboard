<%@ Page Title="" Language="C#" MasterPageFile="~/display.Master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="lab.aspx.cs" Inherits="TVDisplay.lab" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
   
    <style type="text/css">
       * {
         padding:0;
         margin:0;
        }
        body {
       /* background-color:#166D89;*/
       margin:0;

        }
        ::placeholder {
          color: lightgray;
          opacity: 1; /* Firefox */
        }

        :-ms-input-placeholder { /* Internet Explorer 10-11 */
         color: lightgray;
        }

        ::-ms-input-placeholder { /* Microsoft Edge */
         color: lightgray;
        }
      
        .input-box { 
          position: relative; 
        }

        input { 
          display: block; 
          
          padding: 10px 10px 10px 20px; 
          width: 195px; 
        }

        .unit { 
          position: absolute; 
          display: block; 
          right: 5px; 
          top: 10px; 
          z-index: 9;
          color:#166D89;
          
        }


#accordion section, #accordion .pointer, #accordion h1, #accordion p {
  -webkit-transition: all 0.5s ease-in-out;
  -moz-transition: all 0.5s ease-in-out;
  -ms-transition: all 0.5s ease-in-out;
   transition: all 0.5s ease-in-out;
}
        
#accordion {
  margin-bottom:30px;
}
#accordion h1 {
  line-height:1.2;
  font-size:18px;
  background-color:#f8f8f8;
  color:#166D89;
  margin:0;
  padding: 10px 10px 10px 15px;
  width:100%; 
  text-align:left;
  /*position: inherit;*/
}

#accordion h1 a {
  color:#166D89;
  text-decoration:none;
  
}
#accordion section {
 overflow:visible;
 height:contain;
 /* border:1px #166D89 solid;*/
 background-color:#f7f7f7;
 margin-bottom:5px;
}
#accordion p {
  padding:0 10px;
  color:black;
}
#accordion section.ac_hidden p:not(.pointer) {
  color:#fff;
}

#accordion section.ac_hidden {
  height:44px;
  overflow:hidden;
}
#accordion .pointer {
  padding:0;/**/
  /* margin:10px 0 0 6px;*/
  /* line-height:20px;*/
  /*width:13px;*/
  position:fixed;
  text-align:right;
  margin-right:0;
}
#accordion section:not(.ac_hidden) h1 {
  background-color:#166D89;
}

#accordion section:not(.ac_hidden) h1 a{
 color:white;
 text-decoration:none;
}
#accordion section:not(.ac_hidden) .pointer {
  display:block;
  -webkit-transform:rotate(90deg);
  -moz-transform:rotate(90deg);
  -o-transform:rotate(90deg);
  transform:rotate(90deg);
  padding:0;
}

        .modalBackground {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }

        .modalPopup {
            background-color: #fff;
            border-left: 3px solid #ccc;
            border-right: 3px solid #ccc;
            border-bottom: 3px solid #ccc;
            width: 70%;
            height: 70vh;
            /*overflow-y:scroll;*/
        }

    </style>
<meta charset="UTF-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1"/>
<link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css"/>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
<script src="https://cdn.jsdelivr.net/momentjs/2.14.1/moment.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
   
<script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datetimepicker/4.17.37/js/bootstrap-datetimepicker.min.js"></script>
    
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datetimepicker/4.17.37/css/bootstrap-datetimepicker.min.css">
    
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css">
    
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   

        <div class="w3-row w3-margin-top w3-padding">
            <asp:Panel ID="image_Panel1" runat="server" CssClass="modalPopup w3-animate-zoom" Visible="false" align="center w3-center">
                    <div class="w3-bar" style="background: #ccc; padding: 3px;">
                        <div style="float: right;">
                            <asp:Button Width="40px" Text="X" ID="btn_x" BackColor="Red" OnClick="image_close" CssClass="w3-button w3-hover-black w3-text-white w3-padding-small" runat="server" />
                        </div>
                    </div>
                    <div class="w3-panel w3-white  cd4_grid" id="Div1" runat="server">
                        <asp:GridView ID="gv1" runat="server" Width="100%" AutoGenerateColumns="False" ViewStateMode="Enabled" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" ShowHeaderWhenEmpty="True" AllowSorting="True">
                            <Columns>
                                <asp:BoundField HeaderText="Result" DataField="result" SortExpression="result" DataFormatString="{0:dd-MM-yyyy}" HtmlEncode="false" />
                                <asp:BoundField HeaderText="Date" DataField="date" SortExpression="date" DataFormatString="{0:dd-MM-yyyy}" HtmlEncode="false" />
                                <asp:BoundField HeaderText="Time" DataField="time" SortExpression="time" HtmlEncode="false" />
                            </Columns>
                            <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                        </asp:GridView>
                    </div>

                </asp:Panel>
                <asp:HiddenField ID="hdnField" runat="server" />

                <ajaxToolkit:ModalPopupExtender ID="mpe1" runat="server" PopupControlID="image_Panel1" TargetControlID="hdnField" CancelControlID="btn_x" BackgroundCssClass="modalBackground">
                    <Animations>  
              <OnShowing>  
                 <FadeIn Duration=".2" Fps="30" />  
              </OnShowing>  
              <OnShown>  
                 <FadeIn Duration=".2" Fps="30" />  
              </OnShown>  
              <OnHiding>  
                 <FadeOut Duration=".2" Fps="30" />  
              </OnHiding>  
              <OnHidden>  
                 <FadeOut Duration=".2" Fps="30" />  
              </OnHidden>  
                    </Animations>
                </ajaxToolkit:ModalPopupExtender>


                <div id="accordion">
                  <section id="item1" >
                    <p class="pointer"></p><h1 class="w3-btn" style=""><a href="#">HB</a><%--<a href="#" class="w3-right pointer" style="font-size:large;">&#128899;</a>--%></h1>
                      <div class="w3-row w3-margin-top w3-padding-small">
                          <div class=" w3-col l6 s12 w3-padding-small">
                            <div class="input-box">
                            <asp:TextBox ID="tb_hb" CssClass="w3-input w3-border w3-round-large w3-padding" runat="server" />
                            <span class="unit">gms/dL</span>
                            </div>
                            </div>
                            <div class=" w3-col l3 s6 w3-padding-small">
                                <div class='input-group date' id='datetimepicker1' >
                                 <asp:TextBox ID="tb_hb_date" type='text' class="w3-input w3-border w3-round" runat="server" />
                                 <span class="input-group-addon">
                                 <span class="glyphicon glyphicon-calendar"></span>
                                 </span>
                                 </div>
                            </div>
                            <div class=" w3-col l3 s6 w3-padding-small">
                                <div class='input-group date' id='time1'>
                                 <asp:TextBox ID="tb_hb_time" type='text' class="w3-input w3-border w3-round" runat="server" />
                                 <span class="input-group-addon">
                                 <span class="glyphicon glyphicon-time"></span>
                                 </span>
                                 </div>
                            </div>
                            <div class=" w3-col l3 s4 w3-padding-small" >
                                <asp:Button Width="80px" Text="Add" OnClick="Add_hb" CssClass="w3-button w3-padding w3-hover-light-blue w3-large w3-round-xxlarge w3-text-white" BackColor="#166D89" runat="server" />
                            </div>
                            <div class=" w3-col l9 s8 w3-padding-small " >
                                <asp:Button Width="130px" OnClick="mpe_HB" Text="Prev. Values" CssClass="w3-button w3-right w3-padding w3-large w3-round-xxlarge w3-text-white" BackColor="Black" runat="server" />
                            </div>
                      </div>
                  </section>
                  <section id="item2" class="ac_hidden ">
                    <p class="pointer"></p><h1><a href="#">TLC</a><%--<a href="#" class="w3-right" style="font-size:large;">&#128899;</a>--%></h1>
                      <div class="w3-row w3-margin-top w3-padding-small">
                          <div class=" w3-col l6 s12 w3-padding-small">
                            <div class="input-box">
                            <asp:TextBox ID="tb_tlc" CssClass="w3-input w3-border w3-round-large w3-padding" runat="server" />
                            <span class="unit">Cumm</span>
                            </div>
                           </div>
                           <div class=" w3-col l3 s6 w3-padding-small">
                                <div class='input-group date' id='datetimepicker2'>
                                 <asp:TextBox ID="tb_tlc_date" type='text' class="w3-input w3-border w3-round" runat="server" />
                                 <span class="input-group-addon">
                                 <span class="glyphicon glyphicon-calendar"></span>
                                 </span>
                                 </div>
                            </div>
                           <div class=" w3-col l3 s6 w3-padding-small">
                                <div class='input-group date' id='time2'>
                                 <asp:TextBox ID="tb_tlc_time" type='text' class="w3-input w3-border w3-round" runat="server" />
                                 <span class="input-group-addon">
                                 <span class="glyphicon glyphicon-time"></span>
                                 </span>
                                 </div>
                            </div>
                            <div class=" w3-col l3 s4 w3-padding-small">
                                <asp:Button Width="80px" Text="Add" OnClick="Add_tlc" CssClass="w3-button w3-padding w3-hover-light-blue w3-large w3-round-xxlarge w3-text-white" BackColor="#166D89" runat="server" />
                            </div>
                           <div class=" w3-col l9 s8 w3-padding-small " >
                                <asp:Button OnClick="mpe_tlc" Width="130px" Text="Prev. Values" CssClass="w3-button w3-padding w3-right w3-large w3-round-xxlarge w3-text-white" BackColor="Black" runat="server" />
                           </div>
                      </div>
                  </section>
                  <section id="item3" class="ac_hidden">
                    <p class="pointer"></p><h1><a href="#">Glucose Fasting</a><%--<a href="#" class="w3-right" style="font-size:large;">&#128899;</a>--%></h1>
                       <div class="w3-row w3-margin-top w3-padding-small">
                          <div class=" w3-col l6 s12 w3-padding-small">
                            <div class="input-box">
                            <asp:TextBox ID="tb_fasting" CssClass="w3-input w3-border w3-round-large w3-padding" runat="server" />
                            <span class="unit">mg/dL</span>
                            </div>
                            </div>
                            <div class=" w3-col l3 s6 w3-padding-small">
                                <div class='input-group date' id='datetimepicker3'>
                                 <asp:TextBox ID="tb_fasting_date" type='text' class="w3-input w3-border w3-round" runat="server" />
                                 <span class="input-group-addon">
                                 <span class="glyphicon glyphicon-calendar"></span>
                                 </span>
                                 </div>
                            </div>
                            <div class=" w3-col l3 s6 w3-padding-small">
                                <div class='input-group date' id='time3'>
                                 <asp:TextBox ID="tb_fasting_time" type='text' class="w3-input w3-border w3-round" runat="server" />
                                 <span class="input-group-addon">
                                 <span class="glyphicon glyphicon-time"></span>
                                 </span>
                                 </div>
                            </div>
                            <div class=" w3-col l3 s4 w3-padding-small">
                                <asp:Button Width="80px" Text="Add" OnClick="Add_fasting" CssClass="w3-button w3-padding w3-hover-light-blue w3-large w3-round-xxlarge w3-text-white" BackColor="#166D89" runat="server" />
                            </div>
                           <div class=" w3-col l9 s8 w3-padding-small" >
                                <asp:Button OnClick="mpe_fasting"  Width="130px" Text="Prev. Values" CssClass="w3-button w3-padding  w3-large w3-round-xxlarge w3-text-white w3-right" BackColor="Black" runat="server" />
                           </div>
                      </div>
                  </section>
                    <section id="item4" class="ac_hidden">
                    <p class="pointer"></p><h1><a href="#">Glucose PP</a><%--<a href="#" class="w3-right" style="font-size:large;">&#128899;</a>--%></h1>
                       <div class="w3-row w3-margin-top w3-padding-small">
                          <div class=" w3-col l6 s12 w3-padding-small">
                            <div class="input-box">
                            <asp:TextBox ID="tb_pp" CssClass="w3-input w3-border w3-round-large w3-padding" runat="server" />
                            <span class="unit">mg/dL</span>
                            </div>
                            </div>
                            <div class=" w3-col l3 s6 w3-padding-small">
                                <div class='input-group date' id='datetimepicker4'>
                                 <asp:TextBox ID="tb_pp_date" type='text' class="w3-input w3-border w3-round" runat="server" />
                                 <span class="input-group-addon">
                                 <span class="glyphicon glyphicon-calendar"></span>
                                 </span>
                                 </div>
                            </div>
                            <div class=" w3-col l3 s6 w3-padding-small">
                                <div class='input-group date' id='time4'>
                                 <asp:TextBox ID="tb_pp_time" type='text' class="w3-input w3-border w3-round" runat="server" />
                                 <span class="input-group-addon">
                                 <span class="glyphicon glyphicon-time"></span>
                                 </span>
                                 </div>
                            </div>
                            <div class=" w3-col l3 s4 w3-padding-small">
                                <asp:Button Width="80px" Text="Add" OnClick="Add_pp" CssClass="w3-button w3-padding w3-hover-light-blue w3-large w3-round-xxlarge w3-text-white" BackColor="#166D89" runat="server" />
                            </div>
                           <div class=" w3-col l9 s8 w3-padding-small w3-right" >
                                <asp:Button OnClick="mpe_pp" Width="130px" Text="Prev. Values" CssClass="w3-button w3-right w3-padding w3-large w3-round-xxlarge w3-text-white" BackColor="Black" runat="server" />
                           </div>
                      </div>
                  </section>
                  <section id="item5" class="ac_hidden">
                    <p class="pointer"></p><h1><a href="#">Urea</a><%--<a href="#" class="w3-right" style="font-size:large;">&#128899;</a>--%></h1>
                        <div class="w3-row w3-margin-top w3-padding-small">
                          <div class=" w3-col l6 s12 w3-padding-small">
                            <div class="input-box">
                            <asp:TextBox ID="tb_urea" CssClass="w3-input w3-border w3-round-large w3-padding" runat="server" />
                            <span class="unit">mg%</span>
                            </div>
                            </div>
                           <div class=" w3-col l3 s6 w3-padding-small">
                                <div class='input-group date' id='datetimepicker5'>
                                 <asp:TextBox ID="tb_urea_date" type='text' class="w3-input w3-border w3-round" runat="server" />
                                 <span class="input-group-addon">
                                 <span class="glyphicon glyphicon-calendar"></span>
                                 </span>
                                 </div>
                            </div>
                             <div class=" w3-col l3 s6 w3-padding-small">
                                <div class='input-group date' id='time5'>
                                 <asp:TextBox ID="tb_urea_time" type='text' class="w3-input w3-border w3-round" runat="server" />
                                 <span class="input-group-addon">
                                 <span class="glyphicon glyphicon-time"></span>
                                 </span>
                                 </div>
                            </div>
                            <div class=" w3-col l3 s4 w3-padding-small">
                                <asp:Button Width="80px" Text="Add" OnClick="Add_urea" CssClass="w3-button w3-padding w3-hover-light-blue w3-large w3-round-xxlarge w3-text-white" BackColor="#166D89" runat="server" />
                            </div>
                           <div class=" w3-col l9 s8 w3-padding-small ">
                                <asp:Button OnClick="mpe_urea" Width="130px" Text="Prev. Values"  CssClass="w3-button w3-right w3-padding  w3-large w3-round-xxlarge w3-text-white" BackColor="Black" runat="server" />
                           </div>
                      </div>
                  </section>
                  <section id="item6" class="ac_hidden">
                    <p class="pointer"></p><h1><a href="#">Creatnine</a><%--<a href="#" class="w3-right" style="font-size:large;">&#128899;</a>--%></h1>
                       <div class="w3-row w3-margin-top w3-padding-small">
                          <div class=" w3-col l6 s12 w3-padding-small">
                            <div class="input-box">
                            <asp:TextBox ID="tb_creat" CssClass="w3-input w3-border w3-round-large w3-padding" runat="server" />
                            <span class="unit">mg%</span>
                            </div>
                            </div>
                            <div class=" w3-col l3 s6 w3-padding-small">
                                <div class='input-group date' id='datetimepicker6'>
                                 <asp:TextBox ID="tb_creat_date" type='text' class="w3-input w3-border w3-round" runat="server" />
                                 <span class="input-group-addon">
                                 <span class="glyphicon glyphicon-calendar"></span>
                                 </span>
                                 </div>
                            </div>
                            <div class=" w3-col l3 s6 w3-padding-small">
                                <div class='input-group date' id='time6'>
                                 <asp:TextBox ID="tb_creat_time" type='text' class="w3-input w3-border w3-round" runat="server" />
                                 <span class="input-group-addon">
                                 <span class="glyphicon glyphicon-time"></span>
                                 </span>
                                 </div>
                            </div>
                            <div class=" w3-col l3 s4 w3-padding-small">
                                <asp:Button Width="80px" Text="Add" OnClick="Add_creat"  CssClass="w3-button w3-padding w3-hover-light-blue w3-large w3-round-xxlarge w3-text-white" BackColor="#166D89" runat="server" />
                            </div>
                           <div class=" w3-col l9 s8 w3-padding-small" >
                                <asp:Button OnClick="mpe_creat" Width="130px" Text="Prev. Values" CssClass="w3-button w3-right w3-padding  w3-large w3-round-xxlarge w3-text-white" BackColor="Black" runat="server" />
                           </div>
                      </div>
                  </section>
                  <section id="item7" class="ac_hidden">
                    <p class="pointer"></p><h1><a href="#">Na</a><%--<a href="#" class="w3-right" style="font-size:large;">&#128899;</a>--%></h1>
                        <div class="w3-row w3-margin-top w3-padding-small">
                          <div class=" w3-col l6 s12 w3-padding-small">
                            <div class="input-box">
                            <asp:TextBox ID="tb_na" CssClass="w3-input w3-border w3-round-large w3-padding" runat="server" />
                            <span class="unit">gms/dL</span>
                            </div>
                            </div>
                            <div class=" w3-col l3 s6 w3-padding-small">
                                <div class='input-group date' id='datetimepicker7'>
                                 <asp:TextBox ID="tb_na_date" type='text' class="w3-input w3-border w3-round" runat="server" />
                                 <span class="input-group-addon">
                                 <span class="glyphicon glyphicon-calendar"></span>
                                 </span>
                                 </div>
                            </div>
                             <div class=" w3-col l3 s6 w3-padding-small">
                                <div class='input-group date' id='time7'>
                                 <asp:TextBox ID="tb_na_time" type='text' class="w3-input w3-border w3-round" runat="server" />
                                 <span class="input-group-addon">
                                 <span class="glyphicon glyphicon-time"></span>
                                 </span>
                                 </div>
                            </div>
                            <div class=" w3-col l3 s4 w3-padding-small">
                                <asp:Button Width="80px" Text="Add" OnClick="Add_na" CssClass="w3-button w3-padding w3-hover-light-blue w3-large w3-round-xxlarge w3-text-white" BackColor="#166D89" runat="server" />
                            </div>
                           <div class=" w3-col l9 s8 w3-padding-small " >
                                <asp:Button OnClick="mpe_na" Width="130px" Text="Prev. Values" CssClass="w3-right w3-button w3-padding  w3-large w3-round-xxlarge w3-text-white" BackColor="Black" runat="server" />
                           </div>
                      </div>
                  </section>
                  <section id="item8" class="ac_hidden">
                    <p class="pointer"></p><h1><a href="#">K</a><%--<a href="#" class="w3-right" style="font-size:large;">&#128899;</a>--%></h1>
                       <div class="w3-row w3-margin-top w3-padding-small">
                          <div class=" w3-col l6 s12 w3-padding-small">
                            <div class="input-box">
                            <asp:TextBox ID="tb_k" CssClass="w3-input w3-border w3-round-large w3-padding" runat="server" />
                            <span class="unit">gms/dL</span>
                            </div>
                            </div>
                            <div class=" w3-col l3 s6 w3-padding-small">
                                <div class='input-group date' id='datetimepicker8'>
                                 <asp:TextBox ID="tb_k_date" type='text' class="w3-input w3-border w3-round" runat="server" />
                                 <span class="input-group-addon">
                                 <span class="glyphicon glyphicon-calendar"></span>
                                 </span>
                                 </div>
                            </div>
                            <div class=" w3-col l3 s6 w3-padding-small">
                                <div class='input-group date' id='time8'>
                                 <asp:TextBox ID="tb_k_time" type='text' class="w3-input w3-border w3-round" runat="server" />
                                 <span class="input-group-addon">
                                 <span class="glyphicon glyphicon-time"></span>
                                 </span>
                                 </div>
                            </div>
                            <div class=" w3-col l3 s4 w3-padding-small">
                                <asp:Button Width="80px" Text="Add" OnClick="Add_k" CssClass="w3-button w3-padding w3-hover-light-blue w3-large w3-round-xxlarge w3-text-white" BackColor="#166D89" runat="server" />
                            </div>
                           <div class=" w3-col l9 s8 w3-padding-small " >
                                <asp:Button OnClick="mpe_k" Width="130px" Text="Prev. Values" CssClass="w3-button w3-right w3-padding  w3-large w3-round-xxlarge w3-text-white" BackColor="Black" runat="server" />
                           </div>
                      </div>
                  </section>
                  <section id="item9" class="ac_hidden">
                    <p class="pointer"></p><h1><a href="#">CSF WBC</a><%--<a href="#" class="w3-right" style="font-size:large;">&#128899;</a>--%></h1>
                      <div class="w3-row w3-margin-top w3-padding-small">
                          <div class=" w3-col l6 s12 w3-padding-small">
                            <div class="input-box">
                            <asp:TextBox ID="tb_wbc" CssClass="w3-input w3-border w3-round-large w3-padding" runat="server" />
                            <span class="unit">mm3</span>
                            </div>
                            </div>
                            <div class=" w3-col l3 s6 w3-padding-small">
                                <div class='input-group date' id='datetimepicker9'>
                                 <asp:TextBox ID="tb_wbc_date" type='text' class="w3-input w3-border w3-round" runat="server" />
                                 <span class="input-group-addon">
                                 <span class="glyphicon glyphicon-calendar"></span>
                                 </span>
                                 </div>
                            </div>
                           <div class=" w3-col l3 s6 w3-padding-small">
                                <div class='input-group date' id='time9'>
                                 <asp:TextBox ID="tb_wbc_time" type='text' class="w3-input w3-border w3-round" runat="server" />
                                 <span class="input-group-addon">
                                 <span class="glyphicon glyphicon-time"></span>
                                 </span>
                                 </div>
                            </div>
                            <div class=" w3-col l3 s4 w3-padding-small">
                                <asp:Button Width="80px" Text="Add" OnClick="Add_wbc" CssClass="w3-button w3-padding w3-hover-light-blue w3-large w3-round-xxlarge w3-text-white" BackColor="#166D89" runat="server" />
                            </div>
                           <div class=" w3-col l9 s8 w3-padding-small" >
                                <asp:Button OnClick="mpe_wbc" Width="130px" Text="Prev. Values" CssClass="w3-right w3-button w3-padding  w3-large w3-round-xxlarge w3-text-white" BackColor="Black" runat="server" />
                           </div>
                      </div>
                  </section>
                  <section id="item10" class="ac_hidden">
                    <p class="pointer"></p><h1><a href="#">CSF RBC</a><%--<a href="#" class="w3-right" style="font-size:large;">&#128899;</a>--%></h1>
                       <div class="w3-row w3-margin-top w3-padding-small">
                          <div class=" w3-col l6 s12 w3-padding-small">
                            <div class="input-box">
                            <asp:TextBox ID="tb_rbc" CssClass="w3-input w3-border w3-round-large w3-padding" runat="server" />
                            <span class="unit">mm3</span>
                            </div>
                            </div>
                            <div class=" w3-col l3 s6 w3-padding-small">
                                <div class='input-group date' id='datetimepicker10'>
                                 <asp:TextBox ID="tb_rbc_date" type='text' class="w3-input w3-border w3-round" runat="server" />
                                 <span class="input-group-addon">
                                 <span class="glyphicon glyphicon-calendar"></span>
                                 </span>
                                 </div>
                            </div>
                            <div class=" w3-col l3 s6 w3-padding-small">
                                <div class='input-group date' id='time10'>
                                 <asp:TextBox ID="tb_rbc_time" type='text' class="w3-input w3-border w3-round" runat="server" />
                                 <span class="input-group-addon">
                                 <span class="glyphicon glyphicon-time"></span>
                                 </span>
                                 </div>
                            </div>
                            <div class=" w3-col l3 s4 w3-padding-small">
                                <asp:Button Width="80px" Text="Add" OnClick="Add_rbc" CssClass="w3-button w3-padding w3-hover-light-blue w3-large w3-round-xxlarge w3-text-white" BackColor="#166D89" runat="server" />
                            </div>
                           <div class=" w3-col l9 s8 w3-padding-small " >
                                <asp:Button OnClick="mpe_rbc" Width="130px" Text="Prev. Values" CssClass="w3-right w3-button w3-padding  w3-large w3-round-xxlarge w3-text-white" BackColor="Black" runat="server" />
                           </div>
                      </div>
                  </section>
                  <section id="item11" class="ac_hidden">
                    <p class="pointer"></p><h1><a href="#">CSF Blood Sugar</a><%--<a href="#" class="w3-right" style="font-size:large;">&#128899;</a>--%></h1>
                       <div class="w3-row w3-margin-top w3-padding-small">
                          <div class=" w3-col l6 s12 w3-padding-small">
                            <div class="input-box">
                            <asp:TextBox ID="tb_csf_sugar" CssClass="w3-input w3-border w3-round-large w3-padding" runat="server" />
                            <span class="unit">mg/100mL</span>
                            </div>
                            </div>
                           <div class=" w3-col l3 s6 w3-padding-small">
                                <div class='input-group date' id='datetimepicker11'>
                                 <asp:TextBox ID="tb_csf_sugar_date" type='text' class="w3-input w3-border w3-round" runat="server" />
                                 <span class="input-group-addon">
                                 <span class="glyphicon glyphicon-calendar"></span>
                                 </span>
                                 </div>
                            </div>
                            <div class=" w3-col l3 s6 w3-padding-small">
                                <div class='input-group date' id='time11'>
                                 <asp:TextBox ID="tb_csf_sugar_time" type='text' class="w3-input w3-border w3-round" runat="server" />
                                 <span class="input-group-addon">
                                 <span class="glyphicon glyphicon-time"></span>
                                 </span>
                                 </div>
                            </div>
                            <div class=" w3-col l3 s4 w3-padding-small">
                                <asp:Button Width="80px" Text="Add" OnClick="Add_csf_sugar" CssClass="w3-button w3-padding w3-hover-light-blue w3-large w3-round-xxlarge w3-text-white" BackColor="#166D89" runat="server" />
                            </div>
                           <div class=" w3-col l9 s8 w3-padding-small " >
                                <asp:Button Width="130px" OnClick="mpe_csf_sugar" Text="Prev. Values" CssClass="w3-right w3-button w3-padding  w3-large w3-round-xxlarge w3-text-white" BackColor="Black" runat="server" />
                           </div>
                      </div>
                  </section>
                    <section id="item12" class="ac_hidden">
                    <p class="pointer"></p><h1><a href="#">Platelets</a><%--<a href="#" class="w3-right" style="font-size:large;">&#128899;</a>--%></h1>
                       <div class="w3-row w3-margin-top w3-padding-small">
                          <div class=" w3-col l6 s12 w3-padding-small">
                            <div class="input-box">
                            <asp:TextBox ID="tb_platelets" CssClass="w3-input w3-border w3-round-large w3-padding" runat="server" />
                            <span class="unit"></span>
                            </div>
                            </div>
                           <div class=" w3-col l3 s6 w3-padding-small">
                                <div class='input-group date' id='datetimepicker12'>
                                 <asp:TextBox ID="tb_platelets_date" type='text' class="w3-input w3-border w3-round" runat="server" />
                                 <span class="input-group-addon">
                                 <span class="glyphicon glyphicon-calendar"></span>
                                 </span>
                                 </div>
                            </div>
                            <div class=" w3-col l3 s6 w3-padding-small">
                                <div class='input-group date' id='time12'>
                                 <asp:TextBox ID="tb_platelets_time" type='text' class="w3-input w3-border w3-round" runat="server" />
                                 <span class="input-group-addon">
                                 <span class="glyphicon glyphicon-time"></span>
                                 </span>
                                 </div>
                            </div>
                            <div class=" w3-col l3 s4 w3-padding-small">
                                <asp:Button Width="80px" Text="Add" OnClick="Add_platelets" CssClass="w3-button w3-padding w3-hover-light-blue w3-large w3-round-xxlarge w3-text-white" BackColor="#166D89" runat="server" />
                            </div>
                           <div class=" w3-col l9 s8 w3-padding-small " >
                                <asp:Button OnClick="mpe_platelets" Width="130px" Text="Prev. Values" CssClass="w3-right w3-button w3-padding  w3-large w3-round-xxlarge w3-text-white" BackColor="Black" runat="server" />
                           </div>
                      </div>
                  </section>
                     <section id="item13" class="ac_hidden">
                    <p class="pointer"></p><h1><a href="#">PT/INR</a><%--<a href="#" class="w3-right" style="font-size:large;">&#128899;</a>--%></h1>
                       <div class="w3-row w3-margin-top w3-padding-small">
                          <div class=" w3-col l6 s12 w3-padding-small">
                            <div class="input-box">
                            <asp:TextBox ID="tb_ptinr" CssClass="w3-input w3-border w3-round-large w3-padding" runat="server" />
                            <span class="unit"></span>
                            </div>
                            </div>
                           <div class=" w3-col l3 s6 w3-padding-small">
                                <div class='input-group date' id='datetimepicker13'>
                                 <asp:TextBox ID="tb_ptinr_date" type='text' class="w3-input w3-border w3-round" runat="server" />
                                 <span class="input-group-addon">
                                 <span class="glyphicon glyphicon-calendar"></span>
                                 </span>
                                 </div>
                            </div>
                            <div class=" w3-col l3 s6 w3-padding-small">
                                <div class='input-group date' id='time13'>
                                 <asp:TextBox ID="tb_ptinr_time" type='text' class="w3-input w3-border w3-round" runat="server" />
                                 <span class="input-group-addon">
                                 <span class="glyphicon glyphicon-time"></span>
                                 </span>
                                 </div>
                            </div>
                            <div class=" w3-col l3 s4 w3-padding-small">
                                <asp:Button Width="80px" Text="Add" OnClick="Add_ptinr" CssClass="w3-button w3-padding w3-hover-light-blue w3-large w3-round-xxlarge w3-text-white" BackColor="#166D89" runat="server" />
                            </div>
                           <div class=" w3-col l9 s8 w3-padding-small" >
                                <asp:Button OnClick="mpe_ptinr" Width="130px" Text="Prev. Values" CssClass="w3-right w3-button w3-padding  w3-large w3-round-xxlarge w3-text-white" BackColor="Black" runat="server" />
                           </div>
                      </div>
                  </section>
               </div>
                 <script>
                     $(function () {
                         $('#datetimepicker1').datetimepicker({
                             format: 'DD-MM-YYYY',
                             defaultDate: moment(),
                             sideBySide: true
                             
                         });
                         $('#datetimepicker2').datetimepicker({
                             format: 'DD-MM-YYYY',
                             defaultDate: moment(),
                             sideBySide: true
                         });
                         $('#datetimepicker3').datetimepicker({
                             format: 'DD-MM-YYYY',
                             defaultDate: moment(),
                             sideBySide: true
                         });
                         $('#datetimepicker4').datetimepicker({
                             format: 'DD-MM-YYYY'
                         });
                         $('#datetimepicker5').datetimepicker({
                             format: 'DD-MM-YYYY',
                             defaultDate: moment(),
                             sideBySide: true
                         });
                         $('#datetimepicker6').datetimepicker({
                             format: 'DD-MM-YYYY',
                             defaultDate: moment(),
                             sideBySide: true
                         });
                         $('#datetimepicker7').datetimepicker({
                             format: 'DD-MM-YYYY',
                             defaultDate: moment(),
                             sideBySide: true
                         });
                         $('#datetimepicker8').datetimepicker({
                             format: 'DD-MM-YYYY',
                             defaultDate: moment(),
                             sideBySide: true
                         });
                         $('#datetimepicker9').datetimepicker({
                             format: 'DD-MM-YYYY',
                             defaultDate: moment(),
                             sideBySide: true
                         });
                         $('#datetimepicker10').datetimepicker({
                             format: 'DD-MM-YYYY',
                             defaultDate: moment(),
                             sideBySide: true
                         });
                         $('#datetimepicker11').datetimepicker({
                             format: 'DD-MM-YYYY',
                             defaultDate: moment(),
                             sideBySide: true
                         });
                         $('#datetimepicker12').datetimepicker({
                             format: 'DD-MM-YYYY',
                             defaultDate: moment(),
                             sideBySide: true
                         });
                         $('#datetimepicker13').datetimepicker({
                             format: 'DD-MM-YYYY',
                             defaultDate: moment(),
                             sideBySide: true
                         });
                         $('#time1').datetimepicker({
                             format: 'LT',
                             defaultDate: moment(),
                             sideBySide: true
                         });
                         $('#time2').datetimepicker({
                             format: 'LT',
                             defaultDate: moment(),
                             sideBySide: true
                         });
                         $('#time3').datetimepicker({
                             format: 'LT',
                             defaultDate: moment(),
                             sideBySide: true
                         });
                         $('#time4').datetimepicker({
                             format: 'LT',
                             defaultDate: moment(),
                             sideBySide: true
                         });
                         $('#time5').datetimepicker({
                             format: 'LT',
                             defaultDate: moment(),
                             sideBySide: true
                         });
                         $('#time6').datetimepicker({
                             format: 'LT',
                             defaultDate: moment(),
                             sideBySide: true
                         });
                         $('#time7').datetimepicker({
                             format: 'LT',
                             defaultDate: moment(),
                             sideBySide: true
                         });
                         $('#time8').datetimepicker({
                             format: 'LT',
                             defaultDate: moment(),
                             sideBySide: true
                         });
                         $('#time9').datetimepicker({
                             format: 'LT',
                             defaultDate: moment(),
                             sideBySide: true
                         });
                         $('#time10').datetimepicker({
                             format: 'LT',
                             defaultDate: moment(),
                             sideBySide: true
                         });
                         $('#time11').datetimepicker({
                             format: 'LT',
                             defaultDate: moment(),
                             sideBySide: true
                         });
                         $('#time12').datetimepicker({
                             format: 'LT',
                             defaultDate: moment(),
                             sideBySide: true
                         });
                         $('#time13').datetimepicker({
                             format: 'LT',
                             defaultDate: moment(),
                             sideBySide: true
                         });
                     });
                 </script>
                <script type="text/javascript">
                    $(document).ready(function () {
                        $("#accordion section h1").click(function (e) {
                            $(this).parents().siblings("section").addClass("ac_hidden");
                            $(this).parents("section").removeClass("ac_hidden");

                            e.preventDefault();
                        });
                    });
                </script>


    </div>
 
                       
</asp:Content>
