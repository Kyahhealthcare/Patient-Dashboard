<%@ Page Title="" Language="C#"  MasterPageFile="~/display.Master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="documents.aspx.cs" Inherits="TVDisplay.documents" %>

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
      
         .modalBackground  
        {  
            background-color: Black;  
            filter: alpha(opacity=90);  
            opacity: 0.8;  
        }  
        .modalPopup  
        {  
            background-color: #fff;  
            border-left:3px solid #ccc;
            border-right:3px solid #ccc;
            border-bottom:3px solid #ccc;
            width:95%;
            height:90vh;           
        }
    
        .search_bar
        {
            border-top-left-radius:7px;
            border-bottom-left-radius:7px;
        }
        .search_btn {
            border-top-right-radius:7px;
            border-bottom-right-radius:7px;
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
            <div class="w3-col l4 m4 s12 w3-padding" >
                   <asp:Label Text="Form type" runat="server" />
                   <asp:DropDownList ID="ddl_type" AutoPostBack="true" Height="40px" CssClass="w3-input w3-border w3-hover-border-black w3-round-large" runat="server">
                       <asp:ListItem Text="Select" Value="" />
                       <asp:ListItem Text="Treatment" Value="Treatment" />
                       <asp:ListItem Text="Patient Monitor Screen" Value="Monitor Screen" />
                       <asp:ListItem Text="Ventilator Screen" Value="Ventilator Screen" />
                       <asp:ListItem Text="Discharge Summary" Value="Discharge Summary" />
                       <asp:ListItem Text="Nursing Front Sheet" Value="Nursing Notes" />
                       <asp:ListItem Text="Lab Investigation Report" Value="Lab Investigation Report" />
                       <asp:ListItem Text="CT Head" Value="CT Head" />
                       <asp:ListItem Text="CT Spinal" Value="CT Spinal" />
                       <asp:ListItem Text="Chest Xray" Value="xray" />
                       <asp:ListItem Text="MRI" Value="MRI" />
                       <asp:ListItem Text="ABG" Value="ABG" />
                       <asp:ListItem Text="Other Document" Value="Other Document" />
                   </asp:DropDownList>
               </div>
            <div class="w3-col l3 m4 s6 w3-padding" >
                <asp:Label Text="Date" runat="server" />
                <div class='input-group date' id='date1'>
                    <asp:TextBox ID="tb_date" OnTextChanged="upload_date" AutoPostBack="true" type='text' class="w3-input w3-border w3-round" runat="server" />
                    <span class="input-group-addon">
                    <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>
            </div>
            <div class="w3-col l4 s6 m4 w3-padding-small">
                <asp:Label Text="Time" CssClass="w3-large  " ForeColor="#166D89" runat="server" />
                <div class='input-group date' id='time1'>
                    <asp:TextBox ID="tb_time" OnTextChanged="upload_time" AutoPostBack="true" type='text' class="w3-input w3-border w3-round" runat="server" />
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-time"></span>
                    </span>
                </div>
            </div>
            
               
            </div>
           <div class="w3-row w3-padding">
               <div class="w3-col l9 m4 s12 w3-padding" >
                   <input type="file" id="myFile" runat="server" Height="40px" class="w3-input w3-border  w3-round-large" name="postedFile" />
               </div>
               <div class="w3-col l3 m4 s6 w3-padding" >
                    <input type="button" id="btnUpload"  value="Upload" style="background-color:#166D89;" class="w3-button w3-padding-large  w3-hover-light-blue w3-large w3-round-xxlarge w3-text-white" />
               </div>
          </div>

    <progress id="fileProgress" style="display: none"></progress>
    <hr />
    <span id="lblMessage" style="color: Green"></span>
<%--    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>--%>
    <script type="text/javascript">
     
            $("body").on("click", "#btnUpload",
                function () {
                    if (!$('input[type=file]').val()) {
                        alert('Please choose a file');
                    }
                    else {
                        $.ajax({
                            url: 'Handler.ashx',
                            type: 'POST',
                            data: new FormData($('form')[0]),
                            cache: false,
                            contentType: false,
                            processData: false,
                            success: function (file) {
                                $("#fileProgress").hide();
                                $("#lblMessage").html("<b>" + file.name + "</b> has been uploaded.");
                            },
                            xhr: function () {
                                var fileXhr = $.ajaxSettings.xhr();
                                if (fileXhr.upload) {
                                    $("progress").show();
                                    fileXhr.upload.addEventListener("progress", function (e) {
                                        if (e.lengthComputable) {
                                            $("#fileProgress").attr({
                                                value: e.loaded,
                                                max: e.total
                                            });
                                        }
                                    }, false);
                                }
                                return fileXhr;
                            }
                        });
                    }                    
                }
            );
    </script>
    <script>
        $(function () {
            $('#date1').datetimepicker({
                format: 'DD-MM-YYYY',
                defaultDate: moment(),
                sideBySide: true
            });

            $('#time1').datetimepicker({
                format: 'LT',
                defaultDate: moment(),
                sideBySide: true
            });

            $('#date1').datetimepicker().on('dp.change', function (event) {
                __doPostBack('<%= Page.ClientID %>');
            });
            $('#time1').datetimepicker().on('dp.change', function (event) {
                __doPostBack('<%= Page.ClientID %>');
            });
        });
        
    </script>

  <%--  <div class="w3-container w3-padding-large" >
        <div class="w3-light-grey w3-round-xlarge">
          <div id="myBar" class="w3-container w3-green w3-round-xlarge" style="height:24px;width:5%"></div>
        </div>
    </div>
   <script>

       function move() {
           var elem = document.getElementById("myBar");
           var width = 5;
           var id = setInterval(frame, 5);
           function frame() {
               if (width >= 100) {
                   clearInterval(id);
               } else {
                   width = width + 0.1;
                   elem.style.width = width + '%';
               }
           }
       }
   </script>--%>

 
        <hr />        
        <h4 class="w3-margin-bottom w3-padding">Documents</h4>  
   
         <div class=" w3-row" style="min-height:150px;">
            <div id="i1" runat="server" visible="false" class=" w3-col l3 m4 s4 w3-padding w3-center">
                <video id="vid1" src="" width="100%"  visible="false" runat="server" controls autoplay loop muted/>
  
                <asp:ImageButton ID="img1" OnClick="img1_clicked" Width="100%"  runat="server" />
                <div class="w3-container w3-center" style="font-size:14px;">
                    <asp:Label ID="img_date1" Text="" runat="server" /><br />
                    <asp:Label ID="img_time1" Text="" runat="server" />
                </div>
            </div>
            <div id="i2" runat="server" visible="false" class="w3-col l3 m4 s4 w3-padding w3-center">
                <video id="vid2" src="" width="100%"  visible="false" runat="server" controls autoplay loop muted/>
                <asp:ImageButton ID="img2" OnClick="img2_clicked" Width="100%"  runat="server" />
                <div class="w3-container w3-center" style="font-size:14px;">
                    <asp:Label ID="img_date2" Text="" runat="server" /><br />
                    <asp:Label ID="img_time2" Text="" runat="server" />
                </div>
            </div>
            <div id="i3" runat="server" visible="false" class="w3-col l3 m4 s4 w3-padding w3-center">
                <video id="vid3" src="" width="100%"  visible="false" runat="server" controls autoplay loop muted/>
                <asp:ImageButton ID="img3" OnClick="img3_clicked" Width="100%"  runat="server" />
                <div class="w3-container w3-center" style="font-size:14px;">
                    <asp:Label ID="img_date3" Text="" runat="server" /><br />
                    <asp:Label ID="img_time3" Text="" runat="server" />
                </div>
            </div>
            <div id="i4" runat="server" visible="false" class="w3-col l3 m4 s4 w3-padding w3-center">
                <video id="vid4" src="" width="100%"  visible="false" runat="server" controls autoplay loop muted/>
                <asp:ImageButton ID="img4" OnClick="img4_clicked" Width="100%"  runat="server" />
               <div class="w3-container w3-center" style="font-size:14px;">
                    <asp:Label ID="img_date4" Text="" runat="server" /><br />
                    <asp:Label ID="img_time4" Text="" runat="server" />
                </div>
            </div>
            <div id="i5" runat="server" visible="false" class="w3-col l3 m4 s4 w3-padding w3-center">
                <video id="vid5" src="" width="100%"  visible="false" runat="server" controls autoplay loop muted/>
                <asp:ImageButton ID="img5" OnClick="img5_clicked" Width="100%"  runat="server" />
                <div class="w3-container w3-center" style="font-size:14px;">
                    <asp:Label ID="img_date5" Text="" runat="server" /><br />
                    <asp:Label ID="img_time5" Text="" runat="server" />
                </div>
            </div>
            <div id="i6" runat="server" visible="false" class="w3-col l3 m4 s4 w3-padding w3-center">
                <video id="vid6" src="" width="100%"  visible="false" runat="server" controls autoplay loop muted/>
                <asp:ImageButton ID="img6" OnClick="img6_clicked" Width="100%"  runat="server" />
               <div class="w3-container w3-center" style="font-size:14px;">
                    <asp:Label ID="img_date6" Text="" runat="server" /><br />
                    <asp:Label ID="img_time6" Text="" runat="server" />
                </div>
            </div>
 
        </div>
      <asp:Panel ID="image_Panel1" runat="server" CssClass="modalPopup w3-animate-zoom" Visible="false" align="center w3-center"> 
         <div class="w3-bar" style="background:#ccc; padding:3px;">
             <div style="float:right;">
                 <asp:Button Text="X" ID="btn_x" BackColor="Red" OnClick="image_close" CssClass="w3-button  w3-text-white w3-padding-small" runat="server" />
             </div>
         </div>
          <div style="width:100%; height:calc(90vh - 40px);  overflow-y:scroll;">
              <asp:Image ID="image1" ClientIDMode="Static" Width="100%"  runat="server" />
          </div>
                  
      </asp:Panel>  
      <asp:HiddenField ID="hdnField" runat="server" />
      <ajaxToolkit:ModalPopupExtender ID="mpe1" runat="server" PopupControlID="image_Panel1" TargetControlID="hdnField" CancelControlID="btn_x" BackgroundCssClass="modalBackground" >  
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
    <div class="w3-row w3-margin-bottom">
        <div id="i7" runat="server" visible="false" class="w3-col l3 m4 s4 w3-padding w3-center">
            <video id="vid7" src="" width="100%"  visible="false" runat="server" controls autoplay loop muted/>
            <asp:ImageButton ID="img7" OnClick="img7_clicked" Width="100%"  runat="server" />
             <div class="w3-container w3-center" style="font-size:14px;">
                    <asp:Label ID="img_date7" Text="" runat="server" /><br />
                    <asp:Label ID="img_time7" Text="" runat="server" />
                </div>
        </div>
        <div id="i8" runat="server" visible="false" class="w3-col l3 m4 s4 w3-padding w3-center">
            <video id="vid8" src="" width="100%"  visible="false" runat="server" controls autoplay loop muted/>
            <asp:ImageButton ID="img8" OnClick="img8_clicked" Width="100%"  runat="server" />
            <div class="w3-container w3-center" style="font-size:14px;">
                <asp:Label ID="img_date8" Text="" runat="server" /><br />
                <asp:Label ID="img_time8" Text="" runat="server" />
            </div>
        </div>
        <div id="i9" runat="server" visible="false" class="w3-col l3 m4 s4 w3-padding w3-center">
            <video id="vid9" src="" width="100%"  visible="false" runat="server" controls autoplay loop muted/>
            <asp:ImageButton ID="img9" OnClick="img9_clicked" Width="100%"  runat="server" />
            <div class="w3-container w3-center" style="font-size:14px;">
                <asp:Label ID="img_date9" Text="" runat="server" /><br />
                <asp:Label ID="img_time9" Text="" runat="server" />
            </div>
        </div>
        <div id="i10" runat="server" visible="false" class="w3-col l3 m4 s4 w3-padding w3-center">
            <video id="vid10" src="" width="100%"  visible="false" runat="server" controls autoplay loop muted/>
            <asp:ImageButton ID="img10" OnClick="img10_clicked" Width="100%"  runat="server" />
            <div class="w3-container w3-center" style="font-size:14px;">
                <asp:Label ID="img_date10" Text="" runat="server" /><br />
                <asp:Label ID="img_time10" Text="" runat="server" />
            </div>
        </div>
        <div id="i11" runat="server" visible="false" class="w3-col l3 m4 s4 w3-padding w3-center">
            <video id="vid11" src="" width="100%"  visible="false" runat="server" controls autoplay loop muted/>
            <asp:ImageButton ID="img11" OnClick="img11_clicked" Width="100%"  runat="server" />
            <div class="w3-container w3-center" style="font-size:14px;">
                <asp:Label ID="img_date11" Text="" runat="server" /><br />
                <asp:Label ID="img_time11" Text="" runat="server" />
            </div>
        </div>
        <div id="i12" runat="server" visible="false" class="w3-col l3 m4 s4 w3-padding w3-center">
            <video id="vid12" src="" width="100%"  visible="false" runat="server" controls autoplay loop muted/>
            <asp:ImageButton ID="img12" OnClick="img12_clicked" Width="100%" runat="server" />
            <div class="w3-container w3-center" style="font-size:14px;">
                <asp:Label ID="img_date12" Text="" runat="server" /><br />
                <asp:Label ID="img_time12" Text="" runat="server" />
            </div>
        </div>
    </div>
    
    
 </asp:Content>