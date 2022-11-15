<%@ Page Language="C#" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="mob_dash.aspx.cs" Inherits="TVDisplay.mob_dash" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body{
            background-color:#e6e6e6;
           /* max-height:100vh;*/
            height:80vh;
        }
         *{
            /*font-family: 'Montserrat', sans-serif;*/
            font-family: 'Roboto', sans-serif;
          }

         .red_dot {
          height: 10px;
          width: 10px;
          background-color: red;
          border-radius: 50%;
          display: inline-block;
         }
        .yellow_dot {
          height: 10px;
          width: 10px;
          background-color: #f5cf25;
          border-radius: 50%;
          display: inline-block;
        }
         .blue_heading{
            color:#166D89;
        }
        .blue{
            color:#166D89;
        }
        .blue_small{
            color:#166D89;
            
        }
        .grey_text{
            color:#575757;              
        }
        .grey{
            color:#575757;
        }
        .grey_small{
            color:#575757;            
        }
        .textdec
        {
            text-decoration:none;
        }
          .modalBackground  
        {  
            background-color: Black;  
            filter: alpha(opacity=90);  
            opacity: 0.8;  
           /* backdrop: "static ";
            keyboard: false;*/
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
        .image_css{
            width:100%;
            aspect-ratio: 1;
        }
       
 .myImg {
  border-radius: 5px;
  cursor: pointer;
  transition: 0.3s;
}

.myImg:hover {opacity: 0.7;}

/* The Modal (background) */
.modal {
  display: none; /* Hidden by default */
  position: fixed; /* Stay in place */
  z-index: 1; /* Sit on top */
  padding-top: 30px; /* Location of the box */
  left: 0;
  top: 0;
  width: 100%; /* Full width */
  height: 100%; /* Full height */
  overflow: auto; /* Enable scroll if needed */
  background-color: rgb(0,0,0); /* Fallback color */
  background-color: rgba(0,0,0,0.9); /* Black w/ opacity */
}

/* Modal Content (image) */
.modal-content {
 /* margin: auto;
  margin-top:20px;*/
  display: block;
 /* width: 80%;
  max-width: 700px;*/
}

.modalv {
  display: none; /* Hidden by default */
  position: fixed; /* Stay in place */
  z-index: 1; /* Sit on top */
  padding-top: 50px; /* Location of the box */
  left: 0;
  top: 0;
  width: 100%; /* Full width */
  height: 100%; /* Full height */
  overflow: auto; /* Enable scroll if needed */
  background-color: rgb(0,0,0); /* Fallback color */
  background-color: rgba(0,0,0,0.9); /* Black w/ opacity */
}

/* Modal Content (image) */
.modal-contentv {
 /* margin: auto;*/
 /* margin-top:20px;*/
  display: block;
  width: 100%;
  max-width: 100%;
}

/* Caption of Modal Image */
#caption {
  margin: auto;
  display: block;
  width: 80%;
  max-width: 700px;
  text-align: center;
  color: #ccc;
  padding: 10px 0;
  height: 150px;
}

/* Add Animation */
.modal-content, #caption {  
  -webkit-animation-name: zoom;
  -webkit-animation-duration: 0.6s;
  animation-name: zoom;
  animation-duration: 0.6s;
}

.modal-contentv, #caption {  
  -webkit-animation-name: zoom;
  -webkit-animation-duration: 0.6s;
  animation-name: zoom;
  animation-duration: 0.6s;
}

@-webkit-keyframes zoom {
  from {-webkit-transform:scale(0)} 
  to {-webkit-transform:scale(1)}
}

@keyframes zoom {
  from {transform:scale(0)} 
  to {transform:scale(1)}
}

/* The Close Button */
.close {
 /* position: absolute;*/
 /* top: 15px;
  right: 35px;*/
  color: #f1f1f1;
  /*font-size: 30px;*/
  font-weight: bold;
  transition: 0.3s;
}

.close:hover,
.close:focus {
  color: #bbb;
  text-decoration: none;
  cursor: pointer;
}

.closev {
 /* position: absolute;*/
 /* top: 15px;
  right: 35px;*/
  color: #f1f1f1;
  /*font-size: 30px;*/
  font-weight: bold;
  transition: 0.3s;
}

.closev:hover,
.closev:focus {
  color: #bbb;
  text-decoration: none;
  cursor: pointer;
}

/* rr */
.rr {
  /*position: absolute;*/
 /* top: 5px;
  left: 20px;*/
  color: #f1f1f1;/*
  font-size: 20px;*/
  font-weight: bold;
  transition: 0.3s;
}

.rr:hover,
.rr:focus {
  color: #bbb;
  text-decoration: none;
  cursor: pointer;
}


/* 100% Image Width on Smaller Screens */
@media only screen and (max-width: 700px){
  .modal-content {
    width: 100%;
  }
}
      

    </style>

    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <%--<link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css"/>--%>
    <link href="css/w3_css.css" rel="stylesheet" />


    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
    <link href="css/font_awesome.css" rel="stylesheet" />
   

   <%-- <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet"/>--%>

    <script src='https://kit.fontawesome.com/a076d05399.js' crossorigin='anonymous'></script>

    <script src="https://your-site-or-cdn.com/fontawesome/v6.0.0-beta3/js/all.js" data-auto-replace-svg="nest"></script>

    <link rel="preconnect" href="https://fonts.googleapis.com"/>
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin/>
    <%--<link href="https://fonts.googleapis.com/css2?family=Roboto:wght@100;300;400;500&display=swap" rel="stylesheet"/>--%>
    <link href="css/roboto_font.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
       <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>         
        <div class="w3-bar w3-small w3-text-white" style=" background-color:#166D89;">
            <div class="w3-bar-item">
                <div style="font-weight:400; font-size:23px;"><asp:Label ID="p_name" Text="testing" runat="server" /></div>
            </div>
            <div class="w3-bar-item w3-large " style="float:right; padding-top:13px;">
                <asp:LinkButton OnClick="remove_dash" runat="server" ><i class="fa fa-close w3-hover-text-grey w3-xlarge w3-text-amber"></i></asp:LinkButton>
            </div>
            <div class="w3-bar-item w3-large " style="float:right; padding-top:13px;">
                <asp:LinkButton OnClick="home_dash" runat="server" ><i class="fa fa-home w3-xlarge w3-hover-text-grey w3-text-amber"></i></asp:LinkButton>
            </div>
          <%--  <div class="w3-bar-item w3-large " style="float:right; padding-top:13px;">
                <asp:LinkButton OnClick="home_click" runat="server" ><i class="fa fa-home w3-xlarge w3-text-white"></i></asp:LinkButton>
            </div>--%>
        </div>

        
        <div class="w3-row w3-margin-top" >
            <div class="w3-col s12 w3-padding-small" >
                <div class="w3-round-xlarge w3-padding" style="background-color:#fff; color:#166D89; height:contain; ">
                    <div class="w3-row  w3-round-large" >
                         <div class="w3-col m4 s6 w3-padding-small " style="">
                            <div class="w3-round w3-center w3-padding" style="font-weight:500; font-size:16px;background-color:#FEE715FF; color:#101820FF;">Ward: <asp:Label ID="ward" Text="" runat="server" /></div>
                        </div>
                        <div class="w3-col m4 s6 w3-padding-small " style="">
                            <div class="w3-round w3-center w3-padding" style="font-weight:500; font-size:16px;background-color:#FEE715FF; color:#101820FF;">Bed No.: <asp:Label ID="bed" Text="" runat="server" /></div>
                        </div>
                    </div>
                </div>
            </div>
       <%-- </div>--%>
    
        <%--<div class="w3-row " >--%>
            <div class="w3-col s12 w3-padding-small" >
                <%--pt_details--%>
                <%--<asp:LinkButton OnClick="goto_pt_details" CssClass="textdec" runat="server">--%>
                <div class="w3-round-xlarge w3-padding" style="background-color:#fff; color:#166D89; height:contain; ">
                    <div class="w3-row  w3-round-large" >
                        <div class="w3-col m4 s6 w3-padding-small">
                            <div style="font-weight:600; font-size:16px;">UHID: <asp:Label ID="uhid" Text="" runat="server" /></div>
                        </div>
                        <div class="w3-col m4 s6 w3-padding-small">
                            <div style="font-weight:600; font-size:16px;">Age/Sex: <asp:Label ID="age_sex" Text="" runat="server" /></div>
                        </div>
                         <div class="w3-col m4 s6 w3-padding-small">
                            <div style="font-weight:600; font-size:16px;">DOA: <asp:Label ID="doa" Text="" runat="server" /></div>
                        </div>
                        <div class="w3-col m4 s6 w3-padding-small">
                            <div style="font-weight:600; font-size:16px;">LOS: <asp:Label ID="los" Text="" runat="server" /></div>
                        </div>
                        <div class="w3-col m4 s6 w3-padding-small">
                            <div style="font-weight:600; font-size:16px;">Bld Grp: <asp:Label ID="bld_grp" Text="" runat="server" /></div>
                        </div>
                        <div class="w3-col m4 s6 w3-padding-small">
                            <div style="font-weight:600; font-size:16px;">Bld Donated: <asp:Label ID="bld_donated" Text="" runat="server" /></div>
                        </div>
                    </div>
                </div>
                <%--</asp:LinkButton>--%>
            </div>
            <div class="w3-col s12 w3-padding-small">
                <%--GCS--%>
                <div class="w3-white w3-round-xlarge w3-padding" style="height:contain;">
                    <div class="w3-center w3-border-bottom w3-border-light-gray" style="font-weight:500; font-size:25px; margin-bottom:5px;">
                        <asp:Label Text="GCS" ForeColor="#166D89" runat="server" />
                        <div class="w3-right">
                            <asp:LinkButton  OnClick="goto_gcs" CssClass="textdec" runat="server"><i class="fa fa-edit w3-xlarge " style="color:#166d89;"></i></asp:LinkButton>
                        </div>
                    </div>
                    <div class="w3-row  " style="font-weight:400; font-size:18px; color:#166D89;">
                        <div class="w3-col s4 m4 w3-padding-small ">
                            <div class="w3-light-grey w3-round-large w3-center w3-padding-small">
                                E: <asp:Label Text="" ID="e" runat="server" Font-Size="16px" ForeColor="Gray" />
                            </div>
                        </div>
                        <div class="w3-col s4 m4 w3-padding-small">
                            <div class="w3-light-grey w3-round-large w3-center w3-padding-small">
                                V: <asp:Label Text="" ID="v" runat="server" Font-Size="16px" ForeColor="Gray" />
                            </div>
                        </div>
                        <div class="w3-col s4 m4 w3-padding-small "> 
                            <div class="w3-light-grey w3-round-large w3-center w3-padding-small">
                                M: <asp:Label Text="" ID="m" runat="server" Font-Size="16px" ForeColor="Gray" />
                            </div>
                        </div>
                        <br />
                        <div class="w3-center w3-w3-large">
                            Total: <asp:Label Text="" ID="gcs_tot" runat="server" Font-Size="16px" ForeColor="Gray" />
                        </div>
                    </div>                    
                </div>
            </div>     
            <div class="w3-col s12 w3-padding-small">
                <div class="w3-white w3-round-xlarge w3-padding-small" style="height:auto; min-height:contain;">
                    <div class="w3-center w3-border-bottom w3-border-light-gray" style="font-weight:500; margin-bottom:5px; font-size:25px; "><asp:Label Text="Diagnosis" ForeColor="#166D89" runat="server" />
                        <div class="w3-right">
                             <asp:LinkButton OnClick="goto_pt_details_diag" CssClass="textdec" runat="server"><i class="fa fa-edit w3-xlarge " style="color:#166d89;"></i></asp:LinkButton>
                        </div>
                    </div>
                    
                    <div  runat="server" class=" w3-border-bottom w3-border-light-gray" style="font-weight:400; min-height:8vh; height:auto; font-size:18px; color:#166D89;">1. <asp:Label ID="diag1" Text="" ForeColor="Gray"  runat="server" /></div>
                    
                    <div id="d2" visible="false" runat="server" class=" w3-border-bottom w3-border-light-gray" style="font-weight:400; min-height:8vh; height:auto; font-size:18px; color:#166D89;">2. <asp:Label ID="diag2" Text="" ForeColor="Gray"  runat="server" /></div>
                   
                    <div id="d3" visible="false" runat="server" class=" w3-border-bottom w3-border-light-gray" style="font-weight:400; min-height:8vh; height:auto; font-size:18px; color:#166D89;">3. <asp:Label ID="diag3" Text="" ForeColor="Gray"  runat="server" /></div>
                
                </div>
            </div>
            <div class="w3-col s12 w3-padding-small">
                <%--surgery--%>
                <div class="w3-white w3-round-xlarge w3-padding-small" style="height:auto; min-height:30vh; ">
                    <div class="w3-center w3-border-bottom w3-border-light-gray" style="font-weight:500; padding-left:10px; padding-right:10px; margin-bottom:5px; font-size:25px;">
                        <asp:Label Text="Surgery" ForeColor="#166D89" runat="server" />
                        <div class="w3-right">
                            <asp:LinkButton OnClick="goto_surgery" CssClass="textdec" runat="server"><i class="fa fa-edit w3-xlarge " style="color:#166d89;"></i></asp:LinkButton>
                        </div>
                    </div>
                    <div class="w3-row w3-padding">
                        <div class="w3-col s6 w3-left"  style="color:#166D89; font-weight:500; font-size:25px;">Dr. <asp:Label ID="faculty" Text="" runat="server" /></div>
                        <div class="w3-col s6 w3-right"  style="color:#166D89; font-weight:500; font-size:25px;">
                            <div class="w3-right">Dr. <asp:Label ID="sr" Text="" runat="server" /></div>
                        </div>
                    </div>
                    <div class="w3-row" style="height:100%;" >
                        <div class="w3-col l3 s12 m6 w3-padding-small " style="height:85%; ">
                            <div class="w3-round-large " style="width:100%;  height:contain; background-color:#f7fbfc; ">
                                <div class="w3-row w3-cell-row" style="height:contain;">
                                    <div class="w3-cell w3-cell-middle w3-padding-large" style="text-align:center;">
                                        <asp:Label ID="s_name1" Text="" CssClass="grey_text " runat="server" />
                                    </div>
                                </div>
                                <div class=" w3-row w3-center " style="text-align:center; border-top:solid; border-width:1px; border-color:lightgray;">
                                    <div class="w3-col l6 m6 s6">
                                        <asp:Label ID="dos1" Text="DOS1" CssClass="blue_heading" runat="server" /><br />
                                        <asp:Label ID="dos1_date" Text="" CssClass="grey" runat="server" />
                                    </div>
                                    <div class="w3-col l6 m6 s6">
                                        <asp:Label ID="pod1" Text="POD1" CssClass="blue_heading" runat="server" /><br />
                                        <asp:Label ID="pod1_days" Text="" CssClass="grey" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="su2" visible="false" runat="server" class="w3-col l3 s12 m6 w3-padding-small " style="height:85%; ">
                            <div class="w3-round-large " style="width:100%;  height:contain; background-color:#f7fbfc; ">
                                <div class="w3-row w3-cell-row" style="height:contain;">
                                    <div class="w3-cell w3-cell-middle w3-padding-large" style="text-align:center;">
                                        <asp:Label ID="s_name2" Text="" CssClass="grey_text" runat="server" />
                                    </div>
                                </div>
                                <div class=" w3-row w3-center " style="text-align:center; border-top:solid; border-width:1px; border-color:lightgray;">
                                    <div class="w3-col l6 m6 s6">
                                        <asp:Label ID="dos2" Text="DOS2" CssClass="blue_heading" runat="server" /><br />
                                        <asp:Label ID="dos2_date" Text="" CssClass="grey" runat="server" />
                                    </div>
                                    <div class="w3-col l6 m6 s6">
                                        <asp:Label ID="pod2" Text="POD2" CssClass="blue_heading" runat="server" /><br />
                                        <asp:Label ID="pod2_days" Text="" CssClass="grey" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="su3" visible="false" runat="server" class="w3-col l3 s12 m6 w3-padding-small " style="height:85%; ">
                            <div class="w3-round-large" style="width:100%;  height:contain; background-color:#f7fbfc; ">
                                <div class="w3-row w3-cell-row" style="height:contain;">
                                    <div class="w3-cell w3-cell-middle w3-padding-large" style="text-align:center;">
                                        <asp:Label ID="s_name3" Text="" CssClass="grey_text" runat="server" />
                                    </div>
                                </div>
                                <div class=" w3-row w3-center " style="text-align:center; border-top:solid; border-width:1px; border-color:lightgray;">
                                    <div class="w3-col l6 m6 s6">
                                        <asp:Label ID="dos3" Text="DOS3" CssClass="blue_heading" runat="server" /><br />
                                        <asp:Label ID="dos3_date" Text="" CssClass="grey" runat="server" />
                                    </div>
                                    <div class="w3-col l6 m6 s6">
                                        <asp:Label ID="pod3" Text="POD3" CssClass="blue_heading" runat="server" /><br />
                                        <asp:Label ID="pod3_days" Text="" CssClass="grey" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="su4" visible="false" runat="server" class="w3-col l3 s12 m6 w3-padding-small " style="height:85%;">
                            <div class="w3-round-large " style="width:100%;  height:contain; background-color:#f7fbfc; ">
                                <div class="w3-row w3-cell-row" style="height:contain;">
                                    <div class="w3-cell w3-cell-middle w3-padding-large" style="text-align:center;">
                                        <asp:Label ID="s_name4" Text="" CssClass="grey_text" runat="server" />
                                    </div>
                                </div>
                                <div class=" w3-row w3-center " style="text-align:center; border-top:solid; border-width:1px; border-color:lightgray;">
                                    <div class="w3-col l6 m6 s6">
                                        <asp:Label ID="dos4" Text="DOS4" CssClass="blue_heading" runat="server" /><br />
                                        <asp:Label ID="dos4_date" Text="" CssClass="grey" runat="server" />
                                    </div>
                                    <div class="w3-col l6 m6 s6">
                                        <asp:Label ID="pod4" Text="POD4" CssClass="blue_heading" runat="server" /><br />
                                        <asp:Label ID="pod4_days" Text="" CssClass="grey" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
               </div>
            </div>
            <div class="w3-col s12 w3-padding-small">
                <%--issues--%>
                <div class="w3-white w3-round-xlarge w3-padding-small" style="height:auto; min-height:contain; ">
                    <div class="w3-center  w3-border-bottom w3-border-light-gray " style="font-weight:500; margin-bottom:5px; font-size:25px;">
                        <asp:Label Text="Issues" ForeColor="#166D89" runat="server" />
                        <div class="w3-right">
                            <asp:LinkButton  OnClick="goto_issues" CssClass="textdec" runat="server"><i class="fa fa-edit w3-xlarge " style="color:#166d89;"></i></asp:LinkButton>
                        </div>
                    </div>

                    <div class="w3-row" style="height:100% ;">
                        <div class="w3-row w3-center">
                            <div style="font-weight:400; font-size:15px;"><span class="red_dot" ></span>
                            <asp:Label Text="Active" ForeColor="Gray" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;
                            <span class="yellow_dot" ></span>
                            <asp:Label Text="Inactive" ForeColor="Gray" runat="server" /></div>
                        </div>

                        <div class="w3-col l12 s12 m12">
                            <asp:gridview ID="gv1"  runat="server" Width="100%" GridLines="None" AutoGenerateColumns="False"  ViewStateMode="Enabled" ShowHeaderWhenEmpty="True" AllowSorting="True">
                            <Columns>   
                            <asp:TemplateField>
                                <ItemTemplate>
                                <div class="w3-border-bottom w3-border-light-gray" style="">
                                    <div id="issue" style="color:gray;" runat="server" >
                                        <img src="<%# Eval("dot_color") %>" style="font-size:10px;"  alt="" /> <%#Eval("issue") %></div>
                                    <div runat="server" visible="false" style="font-weight:400; font-size:14px; color:#166D89; text-align:right;">Since <div id="issue_date"  ><%#Eval("since_date") %></div></div>
                                </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            </Columns>
                           </asp:gridview>
                           
                        </div>
                        <%--<div class="w3-col l1 s1 m1 w3-border-left w3-border-light-gray" style="padding:40px 0; height:auto; min-height:31.45vh;">
                            <div class="w3-right" style="writing-mode:vertical-rl;text-orientation: mixed;">
                                <div style="font-weight:400; font-size:15px;"><span class="red_dot" ></span>
                                <asp:Label Text="Active" ForeColor="Gray" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;
                                <span class="yellow_dot" ></span>
                                <asp:Label Text="Inactive" ForeColor="Gray" runat="server" /></div>
                            </div>
                        </div>--%>
                    </div>

                </div>
            </div>
            <div class="w3-col s12 w3-padding-small">
                <%--ventilation--%>
                <div class="w3-white w3-round-xlarge w3-padding-small" style="height:auto; min-height:contain;">
                    <div class="w3-center w3-border-bottom w3-border-light-gray" style="font-weight:500; margin-bottom:5px; font-size:25px;">
                        <asp:Label Text="Ventilation Mode" ForeColor="#166D89" runat="server" />
                        <div class="w3-right">
                            <asp:LinkButton  OnClick="goto_ventilation" CssClass="textdec" runat="server"><i class="fa fa-edit w3-xlarge " style="color:#166d89;"></i></asp:LinkButton>
                        </div>
                    </div>
                    <table class="w3-table w3-bordered w3-center" style="width:100%; height:80%; color:grey;">
                        <tr>
                            <td class="w3-center">
                                <b>Mode</b>
                                <br />
                                <asp:Label ID="mode" Text="" runat="server" />
                            </td>
                            <td class="w3-center">
                                <b>Tracheostomy</b>
                                <br />
                                <asp:Label ID="trach" Text="" runat="server" />
                            </td>
                            <td class="w3-center">
                                <b>Intubation</b>
                                <br />
                                <asp:Label ID="intubated" Text="" runat="server" />
                            </td>
                        </tr>
                       
                        <tr>
                            <td class="w3-center">
                                <b>Sedation</b>
                                <br />
                                <asp:Label ID="sedated" Text="" runat="server" />
                            </td>
                            <td class="w3-center">
                                <b>FIO<sub>2</sub></b> 
                                <br />
                                <asp:Label ID="fio2" Text="" runat="server" />
                            </td>
                            <td class="w3-center">
                                <b>Pressure Support</b>
                                <br />
                                <asp:Label ID="ps" Text="" runat="server" />
                            </td>
                        </tr>
                    
                    </table>
                    
                </div>
            </div>
            <div class="w3-col s12 w3-padding-small">
                <%--Vitals--%>
                <div class="w3-white w3-round-xlarge w3-padding-small" style="height:contain;">
                    <div class="w3-center w3-border-bottom w3-border-light-gray" style="font-weight:500; margin-bottom:5px; font-size:25px;">
                        <asp:Label Text="Vitals" ForeColor="#166D89" runat="server" />
                        <div class="w3-right">
                            <asp:LinkButton  OnClick="goto_vitals" CssClass="textdec" runat="server"><i class="fa fa-edit w3-xlarge " style="color:#166d89;"></i></asp:LinkButton>
                        </div>
                    </div>
                    <div class="w3-row w3-right w3-padding">
                        <div class="w3-col s12" style="color:#166D89; font-weight:400;">
                            <asp:Label ID="v_date" Text=""  runat="server" />
                            <asp:Label ID="v_time" Text=""  runat="server" />
                        </div>
                    </div>
                    <div class="w3-row w3-center">
                        <div class="w3-col l4 s6 m6 w3-padding-small">
                            <div class="w3-tag w3-center  w3-round-large" style="height:45px; font-size:16px; padding:10px 2px; width:100%; font-weight:500; background-color:#f1f1f1; color:#000;">
                                <div>RR <asp:Label ID="rr" Text="" runat="server" /><span style="color:#166D89; font-size:13px; font-weight:400;"> bpm</span></div>
                            </div>
                        </div>
                        <div class="w3-col l4 s6 m6 w3-padding-small">
                            <div class="w3-tag   w3-center w3-round-large" style="height:45px; width:100%; font-size:16px; padding:10px 2px; font-weight:500;  background-color:#f1f1f1; color:#000;">
                                <div>Pulse <asp:Label ID="pulse" Text="" runat="server" /><span style="color:#166D89; font-size:13px; font-weight:400;"> bpm</span></div>
                            </div>
                        </div>
                        <div class="w3-col l4 s6 m6 w3-padding-small">
                            <div class="w3-tag w3-center w3-round-large" style="height:45px; font-size:16px; width:100%; padding:10px 2px; font-weight:500;  background-color:#f1f1f1; color:#000;">
                                <div>Temp <asp:Label ID="temp" Text="" runat="server" /><span style="color:#166D89; font-size:13px; font-weight:400;"> <sup>o</sup>F</span></div>
                            </div>
                        </div>
                        <div class="w3-col l4 s6 m6 w3-padding-small">
                            <div class="w3-tag  w3-center  w3-round-large"  style="height:45px; font-size:16px;  width:100%; padding:10px 2px; font-weight:500;  background-color:#f1f1f1; color:#000;">
                                <div>BP <asp:Label ID="bp" Text="" runat="server" /><span style="color:#166D89; font-size:13px; font-weight:400;"> mmHg</span></div>
                            </div>
                        </div>
                        <div class="w3-col l4 s6 m6 w3-padding-small">
                            <div class="w3-tag  w3-center  w3-round-large" style="height:45px; font-size:16px; width:100%; padding:10px 2px; font-weight:500;  background-color:#f1f1f1; color:#000;">
                                <div>ICP <asp:Label ID="icp" Text="" runat="server" /><span style="color:#166D89; font-size:13px; font-weight:400;"> mmHg</span></div>
                            </div>
                        </div>
                        <div class="w3-col l4 s6 m6 w3-padding-small">
                            <div class="w3-tag  w3-center  w3-round-large" style="height:45px; font-size:16px; width:100%; padding:10px 2px; font-weight:500;  background-color:#f1f1f1; color:#000;">
                                <div>SPO<sub>2</sub> <asp:Label ID="spo2" Text="" runat="server" /><span style="color:#166D89; font-size:13px; font-weight:400;"> mmHg</span></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="w3-col s12 w3-padding-small">
                <%--last 24h i/o--%>
                <div class="w3-white w3-round-xlarge w3-padding" style="height:auto; min-height:15.7vh; ">
                    <div class="w3-center w3-border-bottom w3-border-light-gray" style="font-weight:500; margin-bottom:5px; font-size:22px; ">
                        <asp:Label Text="Last 24H I/O" ForeColor="#166D89" runat="server" />
                        <div class="w3-right">
                            <asp:LinkButton  OnClick="goto_io" CssClass="textdec" runat="server"><i class="fa fa-edit w3-xlarge " style="color:#166d89;"></i></asp:LinkButton>
                        </div>
                    </div>
                    <div class="w3-row " style="font-weight:400; font-size:18px; color:#166D89;">
                        I: <asp:Label Text="" runat="server" ID="i"  Font-Size="16px" ForeColor="Gray"/>
                    </div>
                    <div class="w3-row " style="font-weight:400; font-size:18px; color:#166D89;">
                        O: <asp:Label Text="" runat="server" ID="o" Font-Size="16px" ForeColor="Gray"/>
                    </div>
                    <div class="w3-row " style="font-weight:400; font-size:18px; color:#166D89;">
                        Drain: <asp:Label Text="" runat="server" ID="drain"  Font-Size="16px" ForeColor="Gray"/>
                    </div>
                </div>
            </div>
            <div class="w3-col s12 w3-padding-small container" >
                <%--xray and ct scans--%>
                <div class="w3-white w3-round-xlarge w3-padding-small" style="height:auto; min-height:contain">
                    <div class="w3-center w3-border-bottom w3-border-light-gray" style="font-weight:500; margin-bottom:5px; font-size:22px; ">
                        <asp:Label Text="" ForeColor="#166D89" runat="server" />
                        <div class="w3-right">
                            <asp:LinkButton  OnClick="goto_docs" CssClass="textdec" runat="server"><i class="fa fa-edit w3-xlarge " style="color:#166d89;"></i></asp:LinkButton>
                        </div>
                    </div>   

                    <div class="w3-row" id="discharge" runat="server" visible="false" style="height:50%;">                        
                        <div class=" w3-center w3-border-bottom w3-border-light-gray" style="font-weight:500; margin-bottom:5px; font-size:25px;">
                            <asp:Label Text="Discharge Summary" ForeColor="#166D89" runat="server" />
                        </div>
                        <div class="w3-col l3 m3 s4 w3-padding-small" style="height:100%;">
                            <asp:ImageButton ID="dis_img1" ImageUrl="" Visible="false" OnClick="dis_img1_click" Width="100%" Height="100%" runat="server" />
                            <div class="w3-container w3-center" style="font-size:14px;">
                                <asp:Label ID="dis_date" Text="" runat="server" /><br />
                                <asp:Label ID="dis_time" Text="" runat="server" />
                            </div>
                        </div>
                    </div>

                    <div class="w3-row" id="xray" runat="server" visible="false" style="height:50%;">                        
                        <div class=" w3-center w3-border-bottom w3-border-light-gray" style="font-weight:500; margin-bottom:5px; font-size:25px;">
                            <asp:Label Text="Chest X-Ray" ForeColor="#166D89" runat="server" />
                        </div>
                        <div class="w3-col l3 m3 s4 w3-padding-small" style="height:100%;">
                               <img class="w3-card image_css myImg" onclick="x_img1_click()" Visible="false" src="" id="x_img1"  runat="server" style="cursor:zoom-in"/>
                            <div class="w3-container w3-center" style="font-size:14px;">
                                <asp:Label ID="x_date1" Text="" runat="server" /><br />
                                <asp:Label ID="x_time1" Text="" runat="server" />
                            </div>
                        </div>
                        <div class="w3-col l3 m3 s4 w3-padding-small" style="height:100%;">
                            <img class="w3-card image_css myImg" onclick="x_img2_click()" src="" id="x_img2" Visible="false" runat="server" style="cursor:zoom-in"/>
                            <div class="w3-container w3-center" style="font-size:14px;">
                                <asp:Label ID="x_date2" Text="" runat="server" /><br />
                                <asp:Label ID="x_time2" Text="" runat="server" />
                            </div>
                        </div>
                        <div class="w3-col l3 m3 s4 w3-padding-small" style="height:100%;">
                             <img class="w3-card image_css myImg" onclick="x_img3_click()" src="" id="x_img3" Visible="false" runat="server" style="cursor:zoom-in"/>
                             <div class="w3-container w3-center" style="font-size:14px;">
                                <asp:Label ID="x_date3" Text="" runat="server" /><br />
                                <asp:Label ID="x_time3" Text="" runat="server" />
                            </div>
                        </div>
                    </div>
                       
                    <div class="w3-row" id="ct_head" runat="server" visible="false" style="height:50%;">
                        <div class=" w3-center w3-border-bottom w3-border-light-gray" style="font-weight:500; margin-bottom:5px; font-size:25px;">
                            <asp:Label Text="CT Head" ForeColor="#166D89" runat="server" />
                        </div>
                        <div class="w3-col l3 m3 s4 w3-padding-small" style="height:100%;">
                          
                            <video id="ct_h_vid1" src="" onclick="ct_h_vid1_click()" width="100%"  visible="false" runat="server" autoplay loop muted />
                          
                            <img class="w3-card image_css myImg" onclick="ct_h_img1_click()" src="" id="ct_h_img1" Visible="false" runat="server" style="cursor:zoom-in"/>
                            
                             <div class="w3-container w3-center" style="font-size:14px;">
                                <asp:Label ID="ct_h_date1" Text="" runat="server" /><br />
                                <asp:Label ID="ct_h_time1" Text="" runat="server" />
                            </div>
                        </div>
                        <div class="w3-col l3 m3 s4 w3-padding-small" style="height:100%;">
                           <video id="ct_h_vid2" src="" width="100%"  onclick="ct_h_vid2_click()" visible="false" runat="server"  autoplay loop muted/>

                            <img class="w3-card image_css myImg" onclick="ct_h_img2_click()" src="" id="ct_h_img2" Visible="false" runat="server" style="cursor:zoom-in"/>
                            <div class="w3-container w3-center" style="font-size:14px;">
                                <asp:Label ID="ct_h_date2" Text="" runat="server" /><br />
                                <asp:Label ID="ct_h_time2" Text="" runat="server" />
                            </div>
                        </div>
                        <div class="w3-col l3 m3 s4 w3-padding-small" style="height:100%;">
                           <video id="ct_h_vid3" src="" width="100%"  onclick="ct_h_vid3_click()" visible="false" runat="server"  autoplay loop muted/>
  
                            <img class="w3-card image_css myImg" onclick="ct_h_img3_click()" src="" id="ct_h_img3" Visible="false" runat="server" style="cursor:zoom-in"/>
                            <div class="w3-container w3-center" style="font-size:14px;">
                                <asp:Label ID="ct_h_date3" Text="" runat="server" /><br />
                                <asp:Label ID="ct_h_time3" Text="" runat="server" />
                            </div>
                        </div>
                    </div>
                    <div class="w3-row" id="ct_spinal" runat="server" visible="false" style="height:50%;">
                        <div class=" w3-center w3-border-bottom w3-border-light-gray" style="font-weight:500; margin-bottom:5px; font-size:25px;">
                            <asp:Label Text="CT Spinal" ForeColor="#166D89" runat="server" />
                        </div>
                        <div class="w3-col l3 m3 s4 w3-padding-small" style="height:100%;">
                            <video id="ct_s_vid1" src="" width="100%"  onclick="ct_s_vid1_click()"  visible="false" runat="server" autoplay loop muted/>
  
                            <img class="w3-card image_css myImg" onclick="ct_s_img1_click()" src="" id="ct_s_img1" Visible="false" runat="server" style="cursor:zoom-in"/>
                            <div class="w3-container w3-center" style="font-size:14px;">
                                <asp:Label ID="ct_s_date1" Text="" runat="server" /><br />
                                <asp:Label ID="ct_s_time1" Text="" runat="server" />
                            </div>
                        </div>
                        <div class="w3-col l3 m3 s4 w3-padding-small" style="height:100%;">
                            <video id="ct_s_vid2" src="" width="100%" onclick="ct_s_vid2_click()" visible="false" runat="server"  autoplay loop muted/>
  
                            <img class="w3-card image_css myImg" onclick="ct_s_img2_click()" src="" id="ct_s_img2" Visible="false" runat="server" style="cursor:zoom-in"/>
                            <div class="w3-container w3-center" style="font-size:14px;">
                                <asp:Label ID="ct_s_date2" Text="" runat="server" /><br />
                                <asp:Label ID="ct_s_time2" Text="" runat="server" />
                            </div>
                        </div>
                        <div class="w3-col l3 m3 s4 w3-padding-small" style="height:100%;">
                           <video id="ct_s_vid3" src="" width="100%" onclick="ct_s_vid3_click()" visible="false" runat="server" autoplay loop muted/>
  
                            <img class="w3-card image_css myImg" onclick="ct_s_img3_click()" src="" id="ct_s_img3" Visible="false" runat="server" style="cursor:zoom-in"/>
                            <div class="w3-container w3-center" style="font-size:14px;">
                                <asp:Label ID="ct_s_date3" Text="" runat="server" /><br />
                                <asp:Label ID="ct_s_time3" Text="" runat="server" />
                            </div>
                        </div>
                    </div>
                    <div class="w3-row" id="mri" runat="server" visible="false" style="height:50%;">
                        <div class=" w3-center w3-border-bottom w3-border-light-gray" style="font-weight:500; margin-bottom:5px; font-size:25px;">
                            <asp:Label Text="MRI" ForeColor="#166D89" runat="server" />
                        </div>
                        <div class="w3-col l3 m3 s4 w3-padding-small" style="height:100%;">
                            <video id="mri_vid1" src="" width="100%" onclick="mri_vid1_click()" visible="false" runat="server" autoplay loop muted/>
  
                            <img class="w3-card image_css myImg" onclick="mri_img1_click()" src="" id="mri_img1" Visible="false" runat="server" style="cursor:zoom-in"/>
                            <div class="w3-container w3-center" style="font-size:14px;">
                                <asp:Label ID="mri_date1" Text="" runat="server" /><br />
                                <asp:Label ID="mri_time1" Text="" runat="server" />
                            </div>
                        </div>
                        <div class="w3-col l3 m3 s4 w3-padding-small" style="height:100%;">
                            <video id="mri_vid2" src="" width="100%" onclick="mri_vid2_click()" visible="false" runat="server"  autoplay loop muted/>
  
                            <img class="w3-card image_css myImg" onclick="mri_img2_click()" src="" id="mri_img2" Visible="false" runat="server" style="cursor:zoom-in"/>
                            <div class="w3-container w3-center" style="font-size:14px;">
                                <asp:Label ID="mri_date2" Text="" runat="server" /><br />
                                <asp:Label ID="mri_time2" Text="" runat="server" />
                            </div>
                        </div>
                        <div class="w3-col l3 m3 s4 w3-padding-small" style="height:100%;">
                           <video id="mri_vid3" src="" width="100%" onclick="mri_vid3_click()"  visible="false" runat="server" autoplay loop muted/>
  
                            <img class="w3-card image_css myImg" onclick="mri_img3_click()" src="" id="mri_img3" Visible="false" runat="server" style="cursor:zoom-in"/>
                            <div class="w3-container w3-center" style="font-size:14px;">
                                <asp:Label ID="mri_date3" Text="" runat="server" /><br />
                                <asp:Label ID="mri_time3" Text="" runat="server" />
                            </div>
                        </div>
                    </div>
                    <div class="w3-row" id="nursing" runat="server" visible="false" style="height:50%;">
                        <div class=" w3-center w3-border-bottom w3-border-light-gray" style="font-weight:500; margin-bottom:5px; font-size:25px;">
                            <asp:Label Text="Nursing Front Sheet" ForeColor="#166D89" runat="server" />
                        </div>
                        <div class="w3-col l3 m3 s4 w3-padding-small" style="height:100%;">
                            <img class="w3-card image_css myImg" onclick="n_img1_click()" src="" id="n_img1" Visible="false" runat="server" style="cursor:zoom-in"/>
                            <div class="w3-container w3-center" style="font-size:14px;">
                                <asp:Label ID="n_date1" Text="" runat="server" /><br />
                                <asp:Label ID="n_time1" Text="" runat="server" />
                            </div>
                        </div>
                        <div class="w3-col l3 m3 s4 w3-padding-small" style="height:100%;">
                            <img class="w3-card image_css myImg" onclick="n_img2_click()" src="" id="n_img2" Visible="false" runat="server" style="cursor:zoom-in"/>
                            <div class="w3-container w3-center" style="font-size:14px;">
                                <asp:Label ID="n_date2" Text="" runat="server" /><br />
                                <asp:Label ID="n_time2" Text="" runat="server" />
                            </div>
                        </div>
                        <div class="w3-col l3 m3 s4 w3-padding-small" style="height:100%;">
                            <img class="w3-card image_css myImg" onclick="n_img3_click()" src="" id="n_img3" Visible="false" runat="server" style="cursor:zoom-in"/>
                            <div class="w3-container w3-center" style="font-size:14px;">
                                <asp:Label ID="n_date3" Text="" runat="server" /><br />
                                <asp:Label ID="n_time3" Text="" runat="server" />
                            </div>
                        </div>
                    </div>
                    <div class="w3-row" id="treatment" runat="server" visible="false" style="height:50%;">
                        <div class=" w3-center w3-border-bottom w3-border-light-gray" style="font-weight:500; margin-bottom:5px; font-size:25px;">
                            <asp:Label Text="Treatment Sheet" ForeColor="#166D89" runat="server" />
                        </div>
                        <div class="w3-col l3 m3 s4 w3-padding-small" style="height:100%;">
                            <img class="w3-card image_css myImg" onclick="t_img1_click()" src="" id="t_img1" Visible="false" runat="server" style="cursor:zoom-in"/>
                            <div class="w3-container w3-center" style="font-size:14px;">
                                <asp:Label ID="t_date1" Text="" runat="server" /><br />
                                <asp:Label ID="t_time1" Text="" runat="server" />
                            </div>
                        </div>
                        <div class="w3-col l3 m3 s4 w3-padding-small" style="height:100%;">
                            <img class="w3-card image_css myImg" onclick="t_img2_click()" src="" id="t_img2" Visible="false" runat="server" style="cursor:zoom-in"/>
                            <div class="w3-container w3-center" style="font-size:14px;">
                                <asp:Label ID="t_date2" Text="" runat="server" /><br />
                                <asp:Label ID="t_time2" Text="" runat="server" />
                            </div>
                        </div>
                        <div class="w3-col l3 m3 s4 w3-padding-small" style="height:100%;">
                            <img class="w3-card image_css myImg" onclick="t_img3_click()" src="" id="t_img3" Visible="false" runat="server" style="cursor:zoom-in"/>
                            <div class="w3-container w3-center" style="font-size:14px;">
                                <asp:Label ID="t_date3" Text="" runat="server" /><br />
                                <asp:Label ID="t_time3" Text="" runat="server" />
                            </div>
                        </div>
                    </div>
                    <div class="w3-row" id="monitor" runat="server" visible="false" style="height:50%;">
                        <div class=" w3-center w3-border-bottom w3-border-light-gray" style="font-weight:500; margin-bottom:5px; font-size:25px;">
                            <asp:Label Text="Monitor Screen" ForeColor="#166D89" runat="server" />
                        </div>
                        <div class="w3-col l3 m3 s4 w3-padding-small" style="height:100%;">
                            <img class="w3-card image_css myImg" onclick="m_img1_click()" src="" id="m_img1" Visible="false" runat="server" style="cursor:zoom-in"/>
                            <div class="w3-container w3-center" style="font-size:14px;">
                                <asp:Label ID="m_date1" Text="" runat="server" /><br />
                                <asp:Label ID="m_time1" Text="" runat="server" />
                            </div>
                        </div>
                        <div class="w3-col l3 m3 s4 w3-padding-small" style="height:100%;">
                            <img class="w3-card image_css myImg" onclick="m_img2_click()" src="" id="m_img2" Visible="false" runat="server" style="cursor:zoom-in"/>
                            <div class="w3-container w3-center" style="font-size:14px;">
                                <asp:Label ID="m_date2" Text="" runat="server" /><br />
                                <asp:Label ID="m_time2" Text="" runat="server" />
                            </div>
                        </div>
                        <div class="w3-col l3 m3 s4 w3-padding-small" style="height:100%;">
                            <img class="w3-card image_css myImg"  onclick="m_img3_click()" src="" id="m_img3" Visible="false" runat="server" style="cursor:zoom-in"/>
                            <div class="w3-container w3-center" style="font-size:14px;">
                                <asp:Label ID="m_date3" Text="" runat="server" /><br />
                                <asp:Label ID="m_time3" Text="" runat="server" />
                            </div>
                        </div>
                    </div>
                    <div class="w3-row" id="ventilator" runat="server" visible="false" style="height:50%;">
                        <div class=" w3-center w3-border-bottom w3-border-light-gray" style="font-weight:500; margin-bottom:5px; font-size:25px;">
                            <asp:Label Text="Ventilator Screen" ForeColor="#166D89" runat="server" />
                        </div>
                        <div class="w3-col l3 m3 s4 w3-padding-small" style="height:100%;">
                            <img class="w3-card image_css myImg"  onclick="v_img1_click()" src="" id="v_img1" Visible="false" runat="server" style="cursor:zoom-in"/>
                            <div class="w3-container w3-center" style="font-size:14px;">
                                <asp:Label ID="v_date1" Text="" runat="server" /><br />
                                <asp:Label ID="v_time1" Text="" runat="server" />
                            </div>
                        </div>
                        <div class="w3-col l3 m3 s4 w3-padding-small" style="height:100%;">
                            <img class="w3-card image_css myImg" onclick="v_img2_click()" src="" id="v_img2" Visible="false" runat="server" style="cursor:zoom-in"/>
                            <div class="w3-container w3-center" style="font-size:14px;">
                                <asp:Label ID="v_date2" Text="" runat="server" /><br />
                                <asp:Label ID="v_time2" Text="" runat="server" />
                            </div>
                        </div>
                        <div class="w3-col l3 m3 s4 w3-padding-small" style="height:100%;">
                            <img class="w3-card image_css myImg" onclick="v_img3_click()" src="" id="v_img3" Visible="false" runat="server" style="cursor:zoom-in"/>
                            <div class="w3-container w3-center" style="font-size:14px;">
                                <asp:Label ID="v_date3" Text="" runat="server" /><br />
                                <asp:Label ID="v_time3" Text="" runat="server" />
                            </div>
                        </div>
                    </div>
                    <div class="w3-row" id="abg" runat="server" visible="false" style="height:50%;">
                        <div class=" w3-center w3-border-bottom w3-border-light-gray" style="font-weight:500; margin-bottom:5px; font-size:25px;">
                            <asp:Label Text="ABG" ForeColor="#166D89" runat="server" />
                        </div>
                        <div class="w3-col l3 m3 s4 w3-padding-small" style="height:100%;">
                            <img class="w3-card image_css myImg" onclick="abg_img1_click()" src="" id="abg_img1" Visible="false" runat="server" style="cursor:zoom-in"/>
                            <div class="w3-container w3-center" style="font-size:14px;">
                                <asp:Label ID="abg_date1" Text="" runat="server" /><br />
                                <asp:Label ID="abg_time1" Text="" runat="server" />
                            </div>
                        </div>
                        <div class="w3-col l3 m3 s4 w3-padding-small" style="height:100%;">
                            <img class="w3-card image_css myImg" onclick="abg_img2_click()" src="" id="abg_img2" Visible="false" runat="server" style="cursor:zoom-in"/>
                            <div class="w3-container w3-center" style="font-size:14px;">
                                <asp:Label ID="abg_date2" Text="" runat="server" /><br />
                                <asp:Label ID="abg_time2" Text="" runat="server" />
                            </div>
                        </div>
                        <div class="w3-col l3 m3 s4 w3-padding-small" style="height:100%;">
                            <img class="w3-card image_css myImg" onclick="abg_img3_click()" src="" id="abg_img3" Visible="false" runat="server" style="cursor:zoom-in"/>
                            <div class="w3-container w3-center" style="font-size:14px;">
                                <asp:Label ID="abg_date3" Text="" runat="server" /><br />
                                <asp:Label ID="abg_time3" Text="" runat="server" />
                            </div>
                        </div>
                    </div>
                    <div class="w3-row" id="lab" runat="server" visible="false" style="height:50%;">
                        <div class=" w3-center w3-border-bottom w3-border-light-gray" style="font-weight:500; margin-bottom:5px; font-size:25px;">
                            <asp:Label Text="Lab Reports" ForeColor="#166D89" runat="server" />
                        </div>
                        <div class="w3-col l3 m3 s4 w3-padding-small" style="height:100%;">
                            <img class="w3-card image_css myImg"  onclick="lab_img1_click()" src="" id="lab_img1" Visible="false" runat="server" style="cursor:zoom-in"/>
                            <div class="w3-container w3-center" style="font-size:14px;">
                                <asp:Label ID="lab_date1" Text="" runat="server" /><br />
                                <asp:Label ID="lab_time1" Text="" runat="server" />
                            </div>
                        </div>
                        <div class="w3-col l3 m3 s4 w3-padding-small" style="height:100%;">
                            <img class="w3-card image_css myImg" onclick="lab_img2_click()" src="" id="lab_img2" Visible="false" runat="server" style="cursor:zoom-in"/>
                             <div class="w3-container w3-center" style="font-size:14px;">
                                <asp:Label ID="lab_date2" Text="" runat="server" /><br />
                                <asp:Label ID="lab_time2" Text="" runat="server" />
                            </div>
                        </div>
                        <div class="w3-col l3 m3 s4 w3-padding-small" style="height:100%;">
                            <img class="w3-card image_css myImg" onclick="lab_img3_click()" src="" id="lab_img3" Visible="false" runat="server" style="cursor:zoom-in"/>
                            <div class="w3-container w3-center" style="font-size:14px;">
                                <asp:Label ID="lab_date3" Text="" runat="server" /><br />
                                <asp:Label ID="lab_time3" Text="" runat="server" />
                            </div>
                        </div>
                    </div>
                    <div class="w3-row" id="other" runat="server" visible="false" style="height:50%;">
                        <div class=" w3-center w3-border-bottom w3-border-light-gray" style="font-weight:500; margin-bottom:5px; font-size:25px;">
                            <asp:Label Text="Other Documents" ForeColor="#166D89" runat="server" />
                        </div>
                        <div class="w3-col l3 m3 s4 w3-padding-small" style="height:100%;">
                            <img class="w3-card image_css myImg"  onclick="o_img1_click()" src="" id="o_img1" Visible="false" runat="server" style="cursor:zoom-in"/>
                            <div class="w3-container w3-center" style="font-size:14px;">
                                <asp:Label ID="o_date1" Text="" runat="server" /><br />
                                <asp:Label ID="o_time1" Text="" runat="server" />
                            </div>
                        </div>
                        <div class="w3-col l3 m3 s4 w3-padding-small" style="height:100%;">
                            <img class="w3-card image_css myImg" onclick="o_img2_click()" src="" id="o_img2" Visible="false" runat="server" style="cursor:zoom-in"/>
                            <div class="w3-container w3-center" style="font-size:14px;">
                                <asp:Label ID="o_date2" Text="" runat="server" /><br />
                                <asp:Label ID="o_time2" Text="" runat="server" />
                            </div>
                        </div>
                        <div class="w3-col l3 m3 s4 w3-padding-small" style="height:100%;">
                            <img class="w3-card image_css myImg" onclick="o_img3_click()" src="" id="o_img3" Visible="false" runat="server" style="cursor:zoom-in"/>
                            <div class="w3-container w3-center" style="font-size:14px;">
                                <asp:Label ID="o_date3" Text="" runat="server" /><br />
                                <asp:Label ID="o_time3" Text="" runat="server" />
                            </div>
                        </div>
                    </div>
                   

                    <div id="myModal" class="modal">
                        <div class="w3-top w3-bar w3-large">
                            <span id="r1" onclick="rotateImg()" class=" w3-bar-item rr">Rotate 90</span>
                            <span class="close w3-bar-item w3-right" style="margin-right:20px;">X</span>
                        </div>
                        <div class="w3-bar  w3-dark-gray">
                            <span class="w3-bar-item w3-text-white" style=" font-size:14px;" id="r3"></span>
                            <span class="w3-bar-item w3-text-white w3-right" style="margin-right:10px;" id="r4"></span>
                        </div>
                        <img src="" class="modal-content" id="img01"  runat="server"/>


                    </div>

                    <div id="myModalv" class="modalv">
                        <div class="w3-top w3-bar w3-large " >

                              <span class="w3-bar-item w3-text-white" style=" font-size:14px;" id="r2"></span>
                           
                              <span class="closev w3-bar-item w3-right w3-text-yellow " style="margin-right:20px;">X</span>
                        </div>
                        <video id="Video1" src=""  class="modal-contentv" onclick="playPause()" width="100%"   runat="server" autoplay loop muted controls  controlsList="nofullscreen"/>
                    </div>
                
                    <script>
                                             
                        var span = document.getElementsByClassName("close")[0];

                        span.onclick = function () {
                            modal.style.display = "none";
                        }

                        var spanv = document.getElementsByClassName("closev")[0];

                        spanv.onclick = function () {
                            modalv.style.display = "none";
                        }

                        var rotation = 0;
                        function rotateImg() {
                            rotation += 90;
                            if (rotation == 90) {
                                document.querySelector("#img01").style.transform = "rotate(90deg)";
                            }
                            if (rotation == 180) {
                                document.querySelector("#img01").style.transform = "rotate(180deg)";
                            }
                            if (rotation == 270) {
                                document.querySelector("#img01").style.transform = "rotate(270deg)";
                            }
                            if (rotation == 360) {
                                document.querySelector("#img01").style.transform = "rotate(0deg)";
                                rotation = 0;
                            }
                        }

                        var modal = document.getElementById("myModal");
                        var modalv = document.getElementById("myModalv");

                        var modalImg = document.getElementById("img01");
                        var modalVid = document.getElementById("Video1");

                        
                        function playPause() {
                            if (modalVid.paused)
                                modalVid.play();
                            else
                                modalVid.pause();
                        } 
                        document.getElementById('r3').innerHTML = document.getElementById("<%= p_name.ClientID %>").textContent;

                        function x_img1_click() {
                            rotation = 0;
                            document.querySelector("#img01").style.transform = "rotate(0deg)";
                            modal.style.display = "block";
                            modalImg.src = x_img1.src;

                            
                            document.getElementById('r4').innerHTML = document.getElementById("<%= x_date1.ClientID %>").textContent;

                        }

                        function x_img2_click() {
                            rotation = 0;
                            document.querySelector("#img01").style.transform = "rotate(0deg)";
                            modal.style.display = "block";
                            modalImg.src = x_img2.src;

                            document.getElementById('r4').innerHTML = document.getElementById("<%= x_date2.ClientID %>").textContent;

                        }
                        function x_img3_click() {
                            rotation = 0;
                            document.querySelector("#img01").style.transform = "rotate(0deg)";
                            modal.style.display = "block";
                            modalImg.src = x_img3.src;

                            document.getElementById('r4').innerHTML = document.getElementById("<%= x_date3.ClientID %>").textContent;

                        }
                                                
                        function ct_h_vid1_click() {                           
                            //var elem = document.getElementById('ct_h_vid1');
                            //if (elem.requestFullscreen) {
                            //    elem.requestFullscreen();
                            //} else if (elem.mozRequestFullScreen) { /* Firefox */
                            //    elem.mozRequestFullScreen();
                            //} else if (elem.webkitRequestFullscreen) { /* Chrome, Safari & Opera */
                            //    elem.webkitRequestFullscreen();
                            //} else if (elem.msRequestFullscreen) { /* IE/Edge */
                            //    elem.msRequestFullscreen();
                            //}
                                                      
                            modalv.style.display = "block";
                            modalVid.src = ct_h_vid1.src;

                            document.getElementById('r2').innerHTML = document.getElementById("<%= p_name.ClientID %>").textContent + "<br>" + document.getElementById("<%= ct_h_date1.ClientID %>").textContent;

                           // document.getElementById("r2").innerHTML = "abc";
                        }

                        function ct_h_vid2_click() {
                            //var elem = document.getElementById('ct_h_vid2');
                            //if (elem.requestFullscreen) {
                            //    elem.requestFullscreen();
                            //} else if (elem.mozRequestFullScreen) { /* Firefox */
                            //    elem.mozRequestFullScreen();
                            //} else if (elem.webkitRequestFullscreen) { /* Chrome, Safari & Opera */
                            //    elem.webkitRequestFullscreen();
                            //} else if (elem.msRequestFullscreen) { /* IE/Edge */
                            //    elem.msRequestFullscreen();
                            //}

                            modalv.style.display = "block";
                            modalVid.src = ct_h_vid2.src;

                            document.getElementById('r2').innerHTML = document.getElementById("<%= p_name.ClientID %>").textContent + "<br>" + document.getElementById("<%= ct_h_date2.ClientID %>").textContent;

                        }

                        function ct_h_vid3_click() {
                            //var elem = document.getElementById('ct_h_vid3');
                            //if (elem.requestFullscreen) {
                            //    elem.requestFullscreen();
                            //} else if (elem.mozRequestFullScreen) { /* Firefox */
                            //    elem.mozRequestFullScreen();
                            //} else if (elem.webkitRequestFullscreen) { /* Chrome, Safari & Opera */
                            //    elem.webkitRequestFullscreen();
                            //} else if (elem.msRequestFullscreen) { /* IE/Edge */
                            //    elem.msRequestFullscreen();
                            //}

                            modalv.style.display = "block";
                            modalVid.src = ct_h_vid3.src;

                            document.getElementById('r2').innerHTML = document.getElementById("<%= p_name.ClientID %>").textContent + "<br>" + document.getElementById("<%= ct_h_date3.ClientID %>").textContent;

                        }

                        function ct_s_vid1_click() {
                            //var elem = document.getElementById('ct_s_vid1');
                            //if (elem.requestFullscreen) {
                            //    elem.requestFullscreen();
                            //} else if (elem.mozRequestFullScreen) { /* Firefox */
                            //    elem.mozRequestFullScreen();
                            //} else if (elem.webkitRequestFullscreen) { /* Chrome, Safari & Opera */
                            //    elem.webkitRequestFullscreen();
                            //} else if (elem.msRequestFullscreen) { /* IE/Edge */
                            //    elem.msRequestFullscreen();
                            //}

                            modalv.style.display = "block";
                            modalVid.src = ct_s_vid1.src;

                            document.getElementById('r2').innerHTML = document.getElementById("<%= p_name.ClientID %>").textContent + "<br>" + document.getElementById("<%= ct_s_date1.ClientID %>").textContent;

                        }

                        function ct_s_vid2_click() {
                            //var elem = document.getElementById('ct_s_vid2');
                            //if (elem.requestFullscreen) {
                            //    elem.requestFullscreen();
                            //} else if (elem.mozRequestFullScreen) { /* Firefox */
                            //    elem.mozRequestFullScreen();
                            //} else if (elem.webkitRequestFullscreen) { /* Chrome, Safari & Opera */
                            //    elem.webkitRequestFullscreen();
                            //} else if (elem.msRequestFullscreen) { /* IE/Edge */
                            //    elem.msRequestFullscreen();
                            //}

                            modalv.style.display = "block";
                            modalVid.src = ct_s_vid2.src;

                            document.getElementById('r2').innerHTML = document.getElementById("<%= p_name.ClientID %>").textContent + "<br>" + document.getElementById("<%= ct_s_date2.ClientID %>").textContent;

                        }
                        function ct_s_vid3_click() {
                            //var elem = document.getElementById('ct_s_vid3');
                            //if (elem.requestFullscreen) {
                            //    elem.requestFullscreen();
                            //} else if (elem.mozRequestFullScreen) { /* Firefox */
                            //    elem.mozRequestFullScreen();
                            //} else if (elem.webkitRequestFullscreen) { /* Chrome, Safari & Opera */
                            //    elem.webkitRequestFullscreen();
                            //} else if (elem.msRequestFullscreen) { /* IE/Edge */
                            //    elem.msRequestFullscreen();
                            //}

                            modalv.style.display = "block";
                            modalVid.src = ct_s_vid3.src;

                            document.getElementById('r2').innerHTML = document.getElementById("<%= p_name.ClientID %>").textContent + "<br>" + document.getElementById("<%= ct_s_date3.ClientID %>").textContent;

                        }

                        function mri_vid1_click() {
                            //var elem = document.getElementById('mri_vid1');
                            //if (elem.requestFullscreen) {
                            //    elem.requestFullscreen();
                            //} else if (elem.mozRequestFullScreen) { /* Firefox */
                            //    elem.mozRequestFullScreen();
                            //} else if (elem.webkitRequestFullscreen) { /* Chrome, Safari & Opera */
                            //    elem.webkitRequestFullscreen();
                            //} else if (elem.msRequestFullscreen) { /* IE/Edge */
                            //    elem.msRequestFullscreen();
                            //}

                            modalv.style.display = "block";
                            modalVid.src = mri_vid1.src;

                            document.getElementById('r2').innerHTML = document.getElementById("<%= p_name.ClientID %>").textContent + "<br>" + document.getElementById("<%= mri_date1.ClientID %>").textContent;

                        }
                        function mri_vid2_click() {
                            //var elem = document.getElementById('mri_vid2');
                            //if (elem.requestFullscreen) {
                            //    elem.requestFullscreen();
                            //} else if (elem.mozRequestFullScreen) { /* Firefox */
                            //    elem.mozRequestFullScreen();
                            //} else if (elem.webkitRequestFullscreen) { /* Chrome, Safari & Opera */
                            //    elem.webkitRequestFullscreen();
                            //} else if (elem.msRequestFullscreen) { /* IE/Edge */
                            //    elem.msRequestFullscreen();
                            //}

                            modalv.style.display = "block";
                            modalVid.src = mri_vid2.src;

                            document.getElementById('r2').innerHTML = document.getElementById("<%= p_name.ClientID %>").textContent + "<br>" + document.getElementById("<%= mri_date2.ClientID %>").textContent;

                        }
                        function mri_vid3_click() {
                            //var elem = document.getElementById('mri_vid3');
                            //if (elem.requestFullscreen) {
                            //    elem.requestFullscreen();
                            //} else if (elem.mozRequestFullScreen) { /* Firefox */
                            //    elem.mozRequestFullScreen();
                            //} else if (elem.webkitRequestFullscreen) { /* Chrome, Safari & Opera */
                            //    elem.webkitRequestFullscreen();
                            //} else if (elem.msRequestFullscreen) { /* IE/Edge */
                            //    elem.msRequestFullscreen();
                            //}

                            modalv.style.display = "block";
                            modalVid.src = mri_vid3.src;

                            document.getElementById('r2').innerHTML = document.getElementById("<%= p_name.ClientID %>").textContent + "<br>" + document.getElementById("<%= mri_date3.ClientID %>").textContent;

                        }


                        function ct_h_img1_click() {
                            rotation = 0;
                            document.querySelector("#img01").style.transform = "rotate(0deg)";
                            modal.style.display = "block";
                            modalImg.src = ct_h_img1.src;

                            document.getElementById('r4').innerHTML = document.getElementById("<%= ct_h_date1.ClientID %>").textContent;

                        }

                        function ct_h_img2_click() {
                            rotation = 0;
                            document.querySelector("#img01").style.transform = "rotate(0deg)";
                            modal.style.display = "block";
                            modalImg.src = ct_h_img2.src;

                            document.getElementById('r4').innerHTML = document.getElementById("<%= ct_h_date2.ClientID %>").textContent;

                        }
                        function ct_h_img3_click() {
                            rotation = 0;
                            document.querySelector("#img01").style.transform = "rotate(0deg)";
                            modal.style.display = "block";
                            modalImg.src = ct_h_img3.src;

                            document.getElementById('r4').innerHTML = document.getElementById("<%= ct_h_date3.ClientID %>").textContent;

                        }
                        function ct_s_img1_click() {
                            rotation = 0;
                            document.querySelector("#img01").style.transform = "rotate(0deg)";
                            modal.style.display = "block";
                            modalImg.src = ct_s_img1.src;

                            document.getElementById('r4').innerHTML = document.getElementById("<%= ct_s_date1.ClientID %>").textContent;

                        }

                        function ct_s_img2_click() {
                            rotation = 0;
                            document.querySelector("#img01").style.transform = "rotate(0deg)";
                            modal.style.display = "block";
                            modalImg.src = ct_s_img2.src;

                            document.getElementById('r4').innerHTML = document.getElementById("<%= ct_s_date2.ClientID %>").textContent;

                        }
                        function ct_s_img3_click() {
                            rotation = 0;
                            document.querySelector("#img01").style.transform = "rotate(0deg)";
                            modal.style.display = "block";
                            modalImg.src = ct_s_img3.src;

                            document.getElementById('r4').innerHTML = document.getElementById("<%= ct_s_date3.ClientID %>").textContent;

                        }

                        function mri_img1_click() {
                            rotation = 0;
                            document.querySelector("#img01").style.transform = "rotate(0deg)";
                            modal.style.display = "block";
                            modalImg.src = mri_img1.src;

                            document.getElementById('r4').innerHTML = document.getElementById("<%= mri_date1.ClientID %>").textContent;

                        }

                        function mri_img2_click() {
                            rotation = 0;
                            document.querySelector("#img01").style.transform = "rotate(0deg)";
                            modal.style.display = "block";
                            modalImg.src = mri_img2.src;

                            document.getElementById('r4').innerHTML = document.getElementById("<%= mri_date2.ClientID %>").textContent;

                        }
                        function mri_img3_click() {
                            rotation = 0;
                            document.querySelector("#img01").style.transform = "rotate(0deg)";
                            modal.style.display = "block";
                            modalImg.src = mri_img3.src;

                            document.getElementById('r4').innerHTML = document.getElementById("<%= mri_date3.ClientID %>").textContent;

                        }
                        function n_img1_click() {
                            rotation = 0;
                            document.querySelector("#img01").style.transform = "rotate(0deg)";
                            modal.style.display = "block";
                            modalImg.src = n_img1.src;

                            document.getElementById('r4').innerHTML = document.getElementById("<%= n_date1.ClientID %>").textContent;

                        }

                        function n_img2_click() {
                            rotation = 0;
                            document.querySelector("#img01").style.transform = "rotate(0deg)";
                            modal.style.display = "block";
                            modalImg.src = n_img2.src;

                            document.getElementById('r4').innerHTML = document.getElementById("<%= n_date2.ClientID %>").textContent;

                        }
                        function n_img3_click() {
                            rotation = 0;
                            document.querySelector("#img01").style.transform = "rotate(0deg)";
                            modal.style.display = "block";
                            modalImg.src = n_img3.src;

                            document.getElementById('r4').innerHTML = document.getElementById("<%= n_date3.ClientID %>").textContent;

                        }
                        function t_img1_click() {
                            rotation = 0;
                            document.querySelector("#img01").style.transform = "rotate(0deg)";
                            modal.style.display = "block";
                            modalImg.src = t_img1.src;

                            document.getElementById('r4').innerHTML = document.getElementById("<%= t_date1.ClientID %>").textContent;

                        }

                        function t_img2_click() {
                            rotation = 0;
                            document.querySelector("#img01").style.transform = "rotate(0deg)";
                            modal.style.display = "block";
                            modalImg.src = t_img2.src;

                            document.getElementById('r4').innerHTML = document.getElementById("<%= t_date2.ClientID %>").textContent;

                        }
                        function t_img3_click() {
                            rotation = 0;
                            document.querySelector("#img01").style.transform = "rotate(0deg)";
                            modal.style.display = "block";
                            modalImg.src = t_img3.src;

                            document.getElementById('r4').innerHTML = document.getElementById("<%= t_date3.ClientID %>").textContent;

                        }
                        function m_img1_click() {
                            rotation = 0;
                            document.querySelector("#img01").style.transform = "rotate(0deg)";
                            modal.style.display = "block";
                            modalImg.src = m_img1.src;

                            document.getElementById('r4').innerHTML = document.getElementById("<%= m_date1.ClientID %>").textContent;

                        }

                        function m_img2_click() {
                            rotation = 0;
                            document.querySelector("#img01").style.transform = "rotate(0deg)";
                            modal.style.display = "block";
                            modalImg.src = m_img2.src;

                            document.getElementById('r4').innerHTML = document.getElementById("<%= m_date2.ClientID %>").textContent;

                        }
                        function m_img3_click() {
                            rotation = 0;
                            document.querySelector("#img01").style.transform = "rotate(0deg)";
                            modal.style.display = "block";
                            modalImg.src = m_img3.src;

                            document.getElementById('r4').innerHTML = document.getElementById("<%= m_date3.ClientID %>").textContent;

                        }
                        function v_img1_click() {
                            rotation = 0;
                            document.querySelector("#img01").style.transform = "rotate(0deg)";
                            modal.style.display = "block";
                            modalImg.src = v_img1.src;

                            document.getElementById('r4').innerHTML = document.getElementById("<%= v_date1.ClientID %>").textContent;

                        }

                        function v_img2_click() {
                            rotation = 0;
                            document.querySelector("#img01").style.transform = "rotate(0deg)";
                            modal.style.display = "block";
                            modalImg.src = v_img2.src;

                            document.getElementById('r4').innerHTML = document.getElementById("<%= v_date2.ClientID %>").textContent;

                        }
                        function v_img3_click() {
                            rotation = 0;
                            document.querySelector("#img01").style.transform = "rotate(0deg)";
                            modal.style.display = "block";
                            modalImg.src = v_img3.src;

                            document.getElementById('r4').innerHTML = document.getElementById("<%= v_date3.ClientID %>").textContent;

                        }
                        function abg_img1_click() {
                            rotation = 0;
                            document.querySelector("#img01").style.transform = "rotate(0deg)";
                            modal.style.display = "block";
                            modalImg.src = abg_img1.src;

                            document.getElementById('r4').innerHTML = document.getElementById("<%= abg_date1.ClientID %>").textContent;

                        }

                        function abg_img2_click() {
                            rotation = 0;
                            document.querySelector("#img01").style.transform = "rotate(0deg)";
                            modal.style.display = "block";
                            modalImg.src = abg_img2.src;

                            document.getElementById('r4').innerHTML = document.getElementById("<%= abg_date2.ClientID %>").textContent;

                        }
                        function abg_img3_click() {
                            rotation = 0;
                            document.querySelector("#img01").style.transform = "rotate(0deg)";
                            modal.style.display = "block";
                            modalImg.src = abg_img3.src;

                            document.getElementById('r4').innerHTML = document.getElementById("<%= abg_date3.ClientID %>").textContent;

                        }
                        function lab_img1_click() {
                            rotation = 0;
                            document.querySelector("#img01").style.transform = "rotate(0deg)";
                            modal.style.display = "block";
                            modalImg.src = lab_img1.src;

                            document.getElementById('r4').innerHTML = document.getElementById("<%= lab_date1.ClientID %>").textContent;

                        }

                        function lab_img2_click() {
                            rotation = 0;
                            document.querySelector("#img01").style.transform = "rotate(0deg)";
                            modal.style.display = "block";
                            modalImg.src = lab_img2.src;

                            document.getElementById('r4').innerHTML = document.getElementById("<%= lab_date2.ClientID %>").textContent;

                        }
                        function lab_img3_click() {
                            rotation = 0;
                            document.querySelector("#img01").style.transform = "rotate(0deg)";
                            modal.style.display = "block";
                            modalImg.src = lab_img3.src;

                            document.getElementById('r4').innerHTML = document.getElementById("<%= lab_date3.ClientID %>").textContent;

                        }
                        function o_img1_click() {
                            rotation = 0;
                            document.querySelector("#img01").style.transform = "rotate(0deg)";
                            modal.style.display = "block";
                            modalImg.src = o_img1.src;

                            document.getElementById('r4').innerHTML = document.getElementById("<%= o_date1.ClientID %>").textContent;

                        }

                        function o_img2_click() {
                            rotation = 0;
                            document.querySelector("#img01").style.transform = "rotate(0deg)";
                            modal.style.display = "block";
                            modalImg.src = o_img2.src;

                            document.getElementById('r4').innerHTML = document.getElementById("<%= o_date2.ClientID %>").textContent;

                        }
                        function o_img3_click() {
                            rotation = 0;
                            document.querySelector("#img01").style.transform = "rotate(0deg)";
                            modal.style.display = "block";
                            modalImg.src = o_img3.src;

                            document.getElementById('r4').innerHTML = document.getElementById("<%= o_date3.ClientID %>").textContent;

                        }

                    </script>

                </div>
            </div>

            <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
            <script type="text/javascript">
                $("#container img").lazyload({ container: $("#container") });
            </script>

            <div class="w3-col s12 w3-padding-small">
                <%--lab-tests--%>
                <div class="w3-white w3-round-xlarge w3-padding-small" style="height:auto; min-height:62vh; ">
                    <div class="w3-center w3-border-bottom w3-border-light-gray" style="font-weight:500; margin-bottom:5px; font-size:25px;">
                        <asp:Label Text="Lab-Tests" ForeColor="#166D89" runat="server" />
                        <div class="w3-right">
                            <asp:LinkButton  OnClick="goto_lab" CssClass="textdec" runat="server"><i class="fa fa-edit w3-xlarge " style="color:#166d89;"></i></asp:LinkButton>
                        </div>
                    </div>
                    
                    <div class="w3-row">
                        <div class="w3-col l6 s6 m6 w3-padding-small" >
                            <div class="w3-large w3-left  w3-round-large" style="height:80px; width:100%; padding:7px 10px; font-weight:500;  background-color:#f1f1f1; color:#000;">
                                <div>Hb <br />
                                    <asp:Label ID="hb" ForeColor="#166D89" Text="" runat="server" />
                                    <span style="color:#166D89; font-size:13px; font-weight:400;"> gms/dL</span>
                                </div>
                                <div class="w3-right" style="color:#414143; font-weight:400; font-size:12px;">
                                    <asp:Label ID="hb_date" Text=""  runat="server" />&nbsp;
                                    <asp:Label ID="hb_time" Text=""  runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="w3-col l6 s6 m6  w3-padding-small" >
                           <div class="w3-large w3-left  w3-round-large" style="height:80px; width:100%; padding:7px 10px; font-weight:500;  background-color:#f1f1f1; color:#000;">
                                <div>TLC <br />
                                    <asp:Label ID="tlc" Text="" ForeColor="#166D89" runat="server" />
                                    <span style="color:#166D89; font-size:13px; font-weight:400;"> gms/dL</span>
                                </div>
                               <div class="w3-right" style="color:#414143; font-weight:400; font-size:12px;">
                                    <asp:Label ID="tlc_date" Text=""  runat="server" />&nbsp;
                                    <asp:Label ID="tlc_time" Text=""  runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="w3-col l6 s6 m6  w3-padding-small" >
                            <div class="w3-large w3-left  w3-round-large" style="height:80px; width:100%; padding:7px 10px; font-weight:500;  background-color:#f1f1f1; color:#000;">
                                <div>Glu. Fasting <br />
                                    <asp:Label ID="fasting" ForeColor="#166D89" Text="" runat="server" />
                                    <span style="color:#166D89; font-size:13px; font-weight:400;"> gms/dL</span>
                                </div>
                                <div class="w3-right" style="color:#414143; font-weight:400; font-size:12px;">
                                    <asp:Label ID="fasting_date" Text=""  runat="server" />&nbsp;
                                    <asp:Label ID="fasting_time" Text=""  runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="w3-col l6 s6 m6  w3-padding-small" >
                           <div class="w3-large w3-left  w3-round-large" style="height:80px; width:100%; padding:7px 10px; font-weight:500;  background-color:#f1f1f1; color:#000;">
                                <div>Glu. PP <br />
                                    <asp:Label ForeColor="#166D89" ID="pp" Text="" runat="server" />
                                    <span style="color:#166D89; font-size:13px; font-weight:400;"> gms/dL</span>
                                </div>
                               <div class="w3-right" style="color:#414143; font-weight:400; font-size:12px;">
                                    <asp:Label ID="pp_date" Text=""  runat="server" />&nbsp;
                                    <asp:Label ID="pp_time" Text=""  runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="w3-col l6 s6 m6  w3-padding-small" >
                            <div class="w3-large w3-left  w3-round-large" style="height:80px; width:100%; padding:7px 10px; font-weight:500;  background-color:#f1f1f1; color:#000;">
                                <div>Urea <br />
                                    <asp:Label ID="urea" Text="" ForeColor="#166D89" runat="server" />
                                    <span style="color:#166D89; font-size:13px; font-weight:400;"> gms/dL</span>
                                </div>
                                <div class="w3-right" style="color:#414143; font-weight:400; font-size:12px;">
                                    <asp:Label ID="urea_date" Text=""  runat="server" />&nbsp;
                                    <asp:Label ID="urea_time" Text=""  runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="w3-col l6  s6 m6 w3-padding-small" >
                           <div class="w3-large w3-left  w3-round-large" style="height:80px; width:100%; padding:7px 10px; font-weight:500;  background-color:#f1f1f1; color:#000;">
                                <div>Creatinine <br />
                                    <asp:Label ID="creatnine" Text="" ForeColor="#166D89" runat="server" />
                                    <span style="color:#166D89; font-size:13px; font-weight:400;"> gms/dL</span>
                                </div>
                                <div class="w3-right" style="color:#414143; font-weight:400; font-size:12px;">
                                    <asp:Label ID="creat_date" Text=""  runat="server" />&nbsp;
                                    <asp:Label ID="creat_time" Text=""  runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="w3-col l6  s6 m6 w3-padding-small" >
                            <div class="w3-large w3-left  w3-round-large" style="height:80px; width:100%; padding:7px 10px; font-weight:500;  background-color:#f1f1f1; color:#000;">
                                <div>Na <br />
                                    <asp:Label Text="" ID="na" ForeColor="#166D89" runat="server" />
                                    <span style="color:#166D89; font-size:13px; font-weight:400;"> gms/dL</span>
                                </div>
                                <div class="w3-right" style="color:#414143; font-weight:400; font-size:12px;">
                                    <asp:Label ID="na_date" Text=""  runat="server" />&nbsp;
                                    <asp:Label ID="na_time" Text=""  runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="w3-col l6 s6 m6  w3-padding-small" >
                           <div class="w3-large w3-left  w3-round-large" style="height:80px; width:100%; padding:7px 10px; font-weight:500;  background-color:#f1f1f1; color:#000;">
                                <div>K <br />
                                    <asp:Label ForeColor="#166D89" ID="k" Text="" runat="server" />
                                    <span style="color:#166D89; font-size:13px; font-weight:400;"> gms/dL</span>
                                </div>
                               <div class="w3-right" style="color:#414143; font-weight:400; font-size:12px;">
                                    <asp:Label ID="k_date" Text=""  runat="server" />&nbsp;
                                    <asp:Label ID="k_time" Text=""  runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="w3-col l6 s6 m6  w3-padding-small" >
                            <div class="w3-large w3-left  w3-round-large" style="height:80px; width:100%; padding:7px 10px; font-weight:500;  background-color:#f1f1f1; color:#000;">
                                <div>CSF WBC <br />
                                    <asp:Label ForeColor="#166D89" ID="wbc" Text="" runat="server" />
                                    <span style="color:#166D89; font-size:13px; font-weight:400;"> gms/dL</span>
                                </div>
                                <div class="w3-right" style="color:#414143; font-weight:400; font-size:12px;">
                                    <asp:Label ID="wbc_date" Text=""  runat="server" />&nbsp;
                                    <asp:Label ID="wbc_time" Text=""  runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="w3-col l6 s6 m6  w3-padding-small" >
                           <div class="w3-large w3-left  w3-round-large" style="height:80px; width:100%; padding:7px 10px; font-weight:500;  background-color:#f1f1f1; color:#000;">
                                <div>CSF RBC <br />
                                    <asp:Label ForeColor="#166D89" ID="rbc" Text="" runat="server" />
                                    <span style="color:#166D89; font-size:13px; font-weight:400;"> gms/dL</span>
                                </div>
                               <div class="w3-right" style="color:#414143; font-weight:400; font-size:12px;">
                                    <asp:Label ID="rbc_date" Text=""  runat="server" />&nbsp;
                                    <asp:Label ID="rbc_time" Text=""  runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="w3-col l6 s6 m6  w3-padding-small" >
                            <div class="w3-large w3-left  w3-round-large" style="height:80px; width:100%; padding:7px 10px; font-weight:500;  background-color:#f1f1f1; color:#000;">
                                <div>CSF Bld Sugar <br />
                                    <asp:Label ID="csf_sugar" ForeColor="#166D89" Text="" runat="server" />
                                    <span style="color:#166D89; font-size:13px; font-weight:400;"> gms/dL</span>
                                </div>
                                <div class="w3-right" style="color:#414143; font-weight:400; font-size:12px;">
                                    <asp:Label ID="csf_sugar_date" Text=""  runat="server" />&nbsp;
                                    <asp:Label ID="csf_sugar_time" Text=""  runat="server" />
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>            
            <div class="w3-col s12 w3-padding-small">
                <%--fever-pack--%>
                <div class="w3-white w3-round-xlarge w3-padding-small" style="height:auto; min-height:24vh; ">
                    <div class="w3-center w3-border-bottom w3-border-light-gray" style="font-weight:500; font-size:25px; margin-bottom:5px;">
                        <asp:Label Text="Fever-Pack" ForeColor="#166D89" runat="server" />
                        <div class="w3-right">
                            <asp:LinkButton  OnClick="goto_feverpack" CssClass="textdec" runat="server"><i class="fa fa-edit w3-xlarge " style="color:#166d89;"></i></asp:LinkButton>
                        </div>
                    </div>
                    <table  style="width:100%;" class="w3-margin-top">
                        <tr style="background-color:lightgrey; font-weight:500;">
                            <td style="visibility:hidden;"></td>
                            <td class="blue" style="font-size:14px; font-weight:500; text-align:center;"><asp:Label ID="fp_date1" Text="" runat="server" /></td>
                            <td class="blue" style="font-size:14px; font-weight:500; text-align:center;"><asp:Label ID="fp_date2" Text="" runat="server" /></td>
                            <td class="blue" style="font-size:14px; font-weight:500; text-align:center;"><asp:Label ID="fp_date3" Text="" runat="server" /></td>
                        </tr>
                        <tr style="background-color:#166D89; color:white; font-weight:500;">
                            <td >Bld C+S</td>
                            <td style="font-size:14px; text-align:center;">
                                <asp:Label ID="fp_bld1" Text="" runat="server" />
                            </td>
                            <td style="font-size:14px; text-align:center;">
                                <asp:Label ID="fp_bld2" Text="" runat="server" />
                            </td>
                            <td style="font-size:14px; text-align:center;">
                                <asp:Label ID="fp_bld3" Text="" runat="server" />
                            </td>
                        </tr>
                        <tr style="background-color:#166D89; color:white; font-weight:500;">
                            <td >Trach C+S</td>
                            <td style="font-size:14px; text-align:center;">
                                <asp:Label ID="fp_trach1" Text="" runat="server" />
                            </td>
                            <td style="font-size:14px; text-align:center;">
                                <asp:Label ID="fp_trach2" Text="" runat="server" />
                            </td>
                            <td style="font-size:14px; text-align:center;">
                                <asp:Label ID="fp_trach3" Text="" runat="server" />
                            </td>
                        </tr>
                        <tr style="background-color:#166D89; color:white; font-weight:500;">
                            <td >Urine C+S</td>
                            <td style="font-size:14px; text-align:center;">
                                <asp:Label ID="fp_urine1" Text="" runat="server" />
                            </td>
                            <td style="font-size:14px; text-align:center;">
                                <asp:Label ID="fp_urine2" Text="" runat="server" />
                            </td>
                            <td style="font-size:14px; text-align:center;">
                                <asp:Label ID="fp_urine3" Text="" runat="server" />
                            </td>
                        </tr>
                                    
                        <tr style="background-color:#166D89; color:white; font-weight:500;">
                            <td >Urine R+M</td>
                            <td  style="font-size:14px; text-align:center;">P<sub>H</sub> <asp:Label ID="urine_ph1" Text="" runat="server" /><br /> WBC <asp:Label ID="urine_wbc1" Text="" runat="server" />
                            </td>
                            <td  style="font-size:14px; text-align:center;">P<sub>H</sub> <asp:Label ID="urine_ph2" Text="" runat="server" /><br /> WBC <asp:Label ID="urine_wbc2" Text="" runat="server" />
                            </td>
                            <td  style="font-size:14px; text-align:center;">P<sub>H</sub> <asp:Label ID="urine_ph3" Text="" runat="server" /><br /> WBC <asp:Label ID="urine_wbc3" Text="" runat="server" />
                            </td>
                        </tr>
                    </table>
                </div>
              
            </div>
            <div class="w3-col s12 w3-padding-small">
                <%--infusion--%>
                <div class="w3-white w3-round-xlarge w3-padding" style="height:contain;">
                    <div class="w3-center w3-border-bottom w3-border-light-gray" style="font-weight:500; font-size:25px; margin-bottom:5px;">
                        <asp:Label Text="Infusions" ForeColor="#166D89" runat="server" />
                        <div class="w3-right">
                            <asp:LinkButton  OnClick="goto_infusion" CssClass="textdec" runat="server"><i class="fa fa-edit w3-xlarge " style="color:#166d89;"></i></asp:LinkButton>
                        </div>
                    </div>
                    <div class="w3-row  " style="font-weight:400; font-size:18px; color:#166D89;">
                        Infusion1: <asp:Label Text="" ID="infusion1" runat="server" Font-Size="16px" ForeColor="Gray" />
                        <br />
                        Infusion2: <asp:Label Text="" ID="infusion2" runat="server" Font-Size="16px" ForeColor="Gray" />
                        <br />
                        Infusion3: <asp:Label Text="" ID="infusion3" runat="server" Font-Size="16px" ForeColor="Gray" />
                    </div>                    
                </div>
            </div>            
            <div class="w3-col s12 w3-padding-small">
                <%--today's plan--%>
                <div class="w3-white w3-round-xlarge w3-padding-small" style="height:auto; min-height:30.5vh; ">
                    <div class="w3-center w3-border-bottom w3-border-light-gray" style="font-weight:500; margin-bottom:5px; font-size:25px;">
                        <asp:Label Text="Plan for Today" ForeColor="#166D89" runat="server" />
                        <div class="w3-right">
                            <asp:LinkButton  OnClick="goto_todays" CssClass="textdec" runat="server"><i class="fa fa-edit w3-xlarge " style="color:#166d89;"></i></asp:LinkButton>
                        </div>
                    </div>
                    <div class="w3-row w3-padding">
                        <asp:Label ID="other_today" Text="" runat="server" />
                    </div>
                    <table class="w3-table w3-bordered ">
                        <tr>
                            <td style="width:70px; color:#166D89; font-size:17px; font-weight:400;">CT</td>
                            <td style="color:#166D89; font-size:17px; font-weight:500; width:1px;">:</td>
                            <td class="w3-left" style="font-size:17px; font-weight:400; color:gray;">
                                <asp:Label ID="ct_today" Text="" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width:70px; color:#166D89; font-size:17px; font-weight:400;">X-Ray</td>
                            <td style="color:#166D89; font-size:17px; font-weight:500;">:</td>
                            <td class="w3-left" style="font-size:17px; font-weight:400; color:gray;">
                                <asp:Label ID="x_today" Text="" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width:70px; color:#166D89; font-size:17px; font-weight:400;">MRI</td>
                            <td style="color:#166D89; font-size:17px; font-weight:500;">:</td>
                            <td class="w3-left" style="font-size:17px; font-weight:400; color:gray;">
                                <asp:Label ID="mri_today" Text="" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width:70px; color:#166D89; font-size:17px; font-weight:400;">USD</td>
                            <td style="color:#166D89; font-size:17px; font-weight:500;">:</td>
                            <td class="w3-left" style="font-size:17px; font-weight:400; color:gray;">
                                <asp:Label ID="usd_today" Text="" runat="server" />
                            </td>
                        </tr>
                      
                    </table>

                </div>
            </div>
            <div class="w3-col s12 w3-padding-small" style="height:40px;">
            </div>
        </div>
    </form>
</body>
</html>

