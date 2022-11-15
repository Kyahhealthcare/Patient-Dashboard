<%@ Page Language="C#" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="display.aspx.cs" Inherits="TVDisplay.display1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body {
            margin:0;
   /*     background-color:white;*/
        }
        * {
            font-family: 'Montserrat', sans-serif;
        }
        .arrow {
            width:auto; 
            height:auto; 
            max-width:100%; 
            max-height:100%;
        }
        .blue_heading{
            color:#166D89;
            font-size:large;
            
        }
        .blue{
            color:#166D89;
        }
        .blue_small{
            color:#166D89;
            font-size:small;
        }
        .grey_text{
            color:#575757;
            font-size:large;    
        }
        .grey{
            color:#575757;
        }
        .grey_small{
            color:#575757;
            font-size:small;
        }
        .ttd{
            border: 1px solid #c3c7c4;
        }
        .ttdl{
            border-left:solid;
            border-top:solid;
            border-width:1px;
            border-color:#c3c7c4;
        }
        .ttdr {
            border-right:solid;
            border-top:solid;
            border-width:1px;
            border-color:#c3c7c4;
        }
        .ttdm{
            border-right:solid;
            border-left:solid;
            border-top:solid;
            border-width:1px;
            border-color:#c3c7c4;
        }
        .tb{
            border-collapse: collapse;
            width:100%;
        }
        .tb td{
            width:33.33%;
            height:30px;
        }
        .tb2{
            border-collapse: collapse;
            width:100%;
        }
        .shad{
            box-shadow: 0 2px 2px 0 rgba(0, 0, 0, 0.06), 0 2px 20px 0 rgba(0, 0, 0, 0.06);
        }
        .red_dot {
          height: 20px;
          width: 20px;
          background-color: red;
          border-radius: 50%;
          display: inline-block;
        }
        .green_dot {
          height: 20px;
          width: 20px;
          background-color: forestgreen;
          border-radius: 50%;
          display: inline-block;
        }
    </style>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css"/>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>

    <link rel="stylesheet" href="https://www.w3schools.com/lib/w3-colors-2020.css"/>
  
   <link rel="preconnect" href="https://fonts.googleapis.com"/>
<link rel="preconnect" href="https://fonts.gstatic.com" crossorigin/>
<link href="https://fonts.googleapis.com/css2?family=Montserrat:wght@100;200;300;400;500;600;700&display=swap" rel="stylesheet"/>

    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet"/>
    <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons"/>
    <script src='https://kit.fontawesome.com/a076d05399.js' crossorigin='anonymous'></script>

    <script src="https://your-site-or-cdn.com/fontawesome/v6.0.0-beta3/js/all.js" data-auto-replace-svg="nest"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="w3-container w3-white" style="height:100vh;">
            <div class="w3-row w3-text-white w3-border-bottom w3-border-light-grey" style="height:15vh;">
                <div class="w3-col l4 ">
                    <div class="w3-bar w3-small" style=" background-color:#166D89;">
                        <div class="w3-bar-item">
                            <div style="font-weight:400; font-size:23px;">Patient Details</div>
                        </div>
                    </div>
                    <div class="w3-row  w3-padding-large">
                        <div class="w3-col l3 m6 s12 w3-padding-small">
                            <asp:Label Text="Name" CssClass="blue_heading" runat="server" /><br />
                            <asp:Label Text="abc" CssClass="grey_text" runat="server" />
                        </div>
                        <div class="w3-col l3 m6 s12 w3-padding-small">
                            <asp:Label Text="UHID" CssClass="blue_heading" runat="server" /><br />
                            <asp:Label Text="100002355" CssClass="grey_text" runat="server" />
                        </div> 
                        <div class="w3-col l3 m6 s12 w3-padding-small">
                            <asp:Label Text="Bld Grp" CssClass="blue_heading" runat="server" /><br />
                            <asp:Label Text="A+" CssClass="grey_text" runat="server" />
                        </div>
                        <div class="w3-col l3 m6 s12 w3-padding-small">
                            <asp:Label Text="Age/Sex" CssClass="blue_heading" runat="server" /><br />
                            <asp:Label Text="36/M" CssClass="grey_text" runat="server" />
                        </div>
                       
                    </div>
                </div>
                <div class="w3-col l8 w3-border-left w3-border-light-grey">
                    <div class="w3-bar w3-small " style=" background-color:#166D89;">
                        <div class="w3-bar-item ">
                            <div style="font-weight:400; font-size:23px;">Dr. <asp:Label Text="DA/ST" runat="server" /></div>
                        </div>
                        <div class="w3-bar-item w3-right" style="padding:12px 10px;">
                            <div style="font-weight:300; font-size:18px;">BED No.: <asp:Label Text="3" runat="server" /></div>
                        </div>
                        <div class="w3-bar-item w3-right "  style="padding:12px 10px;">
                            <div style="font-weight:300; font-size:18px;">WARD: <asp:Label Text="5" runat="server" /></div>
                        </div>
                        <div class="w3-bar-item w3-right " style="padding:12px 10px;">
                            <div style="font-weight:300; font-size:18px;">Bld Donated: <asp:Label Text="2 units" runat="server" /></div>
                        </div>
                        <div class="w3-bar-item w3-right" style="padding:12px 10px;">
                            <div style="font-weight:300; font-size:18px;">LOS: <asp:Label Text="22 Days" runat="server" /></div>
                        </div>
                        <div class="w3-bar-item w3-right " style="padding:12px 10px;">
                            <div style="font-weight:300; font-size:18px;">DOA: <asp:Label Text="22-02-2021" runat="server" /></div>
                        </div>
                    </div>
                    <div class="w3-row ">
                        <table class="w3-hide-small w3-hide-medium" style="width:100%;">
                            <tr>
                                <td class="w3-padding-small w3-border-right w3-border-light-grey">
                                    <asp:Label Text="Surgery" CssClass="w3-text-white w3-large w3-round-medium w3-padding" BackColor="#166D89" runat="server" />
                                </td>
                                <td style="width:23%;">
                                    <table class="w3-border-right w3-border-light-gray" style="width:100%;">
                                        <tr>
                                            <td colspan="2" style="text-align:center;">
                                                <asp:Label Text="head Surgery" CssClass="grey_text" runat="server" />
                                            </td>
                                        </tr>
                                        <tr style="text-align:center;">
                                            <td>
                                                <asp:Label Text="DOS1" CssClass="blue_heading" runat="server" /><br />
                                                <asp:Label Text="12-01-2021" CssClass="grey" runat="server" />
                                            </td>
                                            <td>
                                                <asp:Label Text="POD1" CssClass="blue_heading" runat="server" /><br />
                                                <asp:Label Text="20 Days" CssClass="grey" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width:23%;">
                                    <table class="w3-border-right w3-border-light-gray" style="width:100%;">
                                        <tr>
                                            <td colspan="2" style="text-align:center;">
                                                <asp:Label Text="Spinal Surgery" CssClass="grey_text" runat="server" />
                                            </td>
                                        </tr>
                                        <tr style="text-align:center;">
                                            <td>
                                                <asp:Label Text="DOS2" CssClass="blue_heading" runat="server" /><br />
                                                <asp:Label Text="12-01-2021" CssClass="grey" runat="server" />
                                            </td>
                                            <td>
                                                <asp:Label Text="POD2" CssClass="blue_heading" runat="server" /><br />
                                                <asp:Label Text="20 Days" CssClass="grey" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width:23%;">
                                    <table class="w3-border-right w3-border-light-gray" style="width:100%;">
                                        <tr>
                                            <td colspan="2" style="text-align:center;">
                                                <asp:Label Text="Spinal Surgery" CssClass="grey_text" runat="server" />
                                            </td>
                                        </tr>
                                        <tr style="text-align:center;">
                                            <td>
                                                <asp:Label Text="DOS3" CssClass="blue_heading" runat="server" /><br />
                                                <asp:Label Text="12-01-2021" CssClass="grey" runat="server" />
                                            </td>
                                            <td>
                                                <asp:Label Text="POD3" CssClass="blue_heading" runat="server" /><br />
                                                <asp:Label Text="20 Days" CssClass="grey" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width:23%;">
                                    <table class="w3-border-right w3-border-light-gray" style="width:100%;">
                                        <tr>
                                            <td colspan="2" style="text-align:center;">
                                                <asp:Label Text="Spinal Surgery" CssClass="grey_text" runat="server" />
                                            </td>
                                        </tr>
                                        <tr style="text-align:center;">
                                            <td>
                                                <asp:Label Text="DOS4" CssClass="blue_heading" runat="server" /><br />
                                                <asp:Label Text="12-01-2021" CssClass="grey" runat="server" />
                                            </td>
                                            <td>
                                                <asp:Label Text="POD4" CssClass="blue_heading" runat="server" /><br />
                                                <asp:Label Text="20 Days" CssClass="grey" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                
                               
                            </tr>
                        </table>
                    </div>
                </div>
            </div>

            <div class="w3-row ">
                <div class="w3-col l8 w3-border-right w3-border-light-gray" style="height:85vh;">
                    <div class="w3-row w3-border-bottom w3-border-light-gray" style="min-height:7vh; height:contain;">
                        <table class="w3-hide-small w3-hide-medium" style="width:100%;">
                            <tr>
                                <td class="w3-padding-small w3-border-right w3-border-light-grey" >
                                    <asp:Label Text="Diagnosis" CssClass="w3-text-white w3-large w3-round-medium w3-padding" BackColor="#166D89" runat="server" />
                                </td>
                               
                                <td class="w3-padding-small w3-border-right w3-border-light-grey" style="width:30%;">
                                    <asp:Label Text="1." CssClass="blue_heading" runat="server" /><br />
                                    <asp:Label Text="Spinal " CssClass="grey_text" runat="server" />
                                </td>
                                <td class="w3-padding-small w3-border-right w3-border-light-grey" style="width:30%;">
                                    <asp:Label Text="2." CssClass="blue_heading" runat="server" /><br />
                                   <asp:Label Text="Spinal injury" CssClass="grey_text" runat="server" />
                                </td>
                                <td class="w3-padding-small " style="width:30%;">
                                    <asp:Label Text="3." CssClass="blue_heading" runat="server" /><br />
                                   <asp:Label Text="" CssClass="grey_text" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="w3-row ">
                        <div class="w3-col l5 w3-border-right w3-border-light-grey">
                            <div class="w3-row w3-border-bottom w3-border-light-gray">
                                <div class="w3-padding w3-margin-top">
                                    <div class="w3-center">
                                      <asp:Label Text="Vitals" CssClass="w3-text-white w3-large w3-round-medium w3-padding" BackColor="#166D89" runat="server" />
                                      </div>  <br />
                                        <table class=" w3-margin-top" style="width:100%;">
                                            <tr>
                                                <td class="blue_heading">RR</td>
                                                <td class="grey">10-02-2022</td>
                                                <td class="grey">09:22</td>
                                                <td class="grey_text">36</td>
                                            </tr>
                                            <tr>
                                                <td class="blue_heading">SPO2</td>
                                                <td class="grey">10-02-2022</td>
                                                <td class="grey">09:22</td>
                                                <td class="grey_text">36</td>
                                            </tr>
                                            <tr>
                                                <td class="blue_heading">Pulse Rate</td>
                                                <td class="grey"></td>
                                                <td class="grey"></td>
                                                <td class="grey_text"></td>
                                            </tr>
                                            <tr>
                                                <td class="blue_heading">Temperature</td>
                                                <td class="grey"></td>
                                                <td class="grey"></td>
                                                <td class="grey_text"></td>
                                            </tr>
                                            <tr>
                                                <td class="blue_heading">BP</td>
                                                <td class="grey"></td>
                                                <td class="grey"></td>
                                                <td class="grey_text"></td>
                                            </tr>
                                            <tr>
                                                <td class="blue_heading">ICP</td>
                                                <td class="grey">10-02-2022</td>
                                                <td class="grey">09:22</td>
                                                <td class="grey_text">36</td>
                                            </tr>
                                        </table>
                                   
                                </div>
                                <div style="height:34vh;">
                                    
                                </div>
                            </div>

                             

                            <div class="w3-row">
                                <div class="w3-padding w3-margin-top">
                                    <div class="w3-center">
                                      <asp:Label Text="Ventilation Mode" CssClass="w3-text-white w3-large w3-round-medium w3-padding" BackColor="#166D89" runat="server" />
                                        <br />
                                        <table class=" w3-margin-top tb">
                                            <tr>
                                                <td class="grey_text ttdr"></td>
                                                <td class="grey_text ttd"></td>
                                                <td class="grey_text ttdl"></td>
                                            </tr>
                                            <tr>
                                                <td class="grey_text ttdr"></td>
                                                <td class="grey_text ttd"></td>
                                                <td class="grey_text ttdl"></td>
                                            </tr>
                                            <tr>
                                                <td class="grey_text ttdr"></td>
                                                <td class="grey_text ttd"></td>
                                                <td class="grey_text ttdl"></td>
                                            </tr>
                                          <%--  <tr>
                                                <td class="grey_text ttdr"></td>
                                                <td class="grey_text ttd"></td>
                                                <td class="grey_text ttdl"></td>
                                            </tr>--%>
                                            <tr>
                                                <td class="grey_text ttdr"></td>
                                                <td class="grey_text ttdm"></td>
                                                <td class="grey_text ttdl"></td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="w3-col l7">
                            <%--<div class="w3-row w3-border-bottom w3-border-light-gray">--%>
                               
                                    <table class="  tb2 w3-border-bottom w3-border-light-gray" style="width:100%; height:20vh; ">
                                            <tr style="height:33.33%;">
                                                <td rowspan="3" style="width:130px; text-align:center; border-right:solid; border-color:lightgray; border-width:1px;" class="">
                                                    <asp:Label Text="Issues" CssClass="w3-text-white w3-large w3-round-medium w3-padding" BackColor="#166D89" runat="server" />
                                                </td>
                                                <td class="grey_text w3-padding-small" style="width:42%; border-right:solid; border-bottom:solid; border-color:lightgray; border-width:1px;">
                                                    <span class="green_dot"></span>
                                                    <asp:Label Text="fever" CssClass="grey" runat="server" />
                                                </td>
                                                <td class="grey_text w3-padding-small" style="width:42%; border-bottom:solid; border-color:lightgray; border-width:1px;">
                                                    <span class="red_dot"></span>
                                                    <asp:Label Text="rashes" CssClass="grey" runat="server" />
                                                </td>
                                            </tr>
                                            <tr style="height:33.33%;">
                                                
                                                <td class="grey_text w3-padding-small" style="border-right:solid; border-bottom:solid; border-color:lightgray; border-width:1px;">
                                                    <asp:Label Text="" CssClass="grey" runat="server" />
                                                </td>
                                                <td class="grey_text ttdl w3-padding-small">
                                                    <asp:Label Text="" CssClass="grey" runat="server" />
                                                </td>
                                            </tr>
                                            <tr style="height:33.33%;">
                                                <td class="grey_text w3-padding-small" style="  border-color:lightgray; border-width:1px;">
                                                    <asp:Label Text="" CssClass="grey" runat="server" />
                                                </td>
                                                <td class="grey_text ttdl w3-padding-small">
                                                    <asp:Label Text="" CssClass="grey" runat="server" />
                                                </td>
                                            </tr>
                                        </table>
                               
                            <%--</div>--%>
                            <div class="w3-row ">
                                <div class="w3-padding w3-margin-top">
                                    <div class="w3-center">
                                      <asp:Label Text="LAB-Test" CssClass="w3-text-white w3-large w3-round-medium w3-padding" BackColor="#166D89" runat="server" />
                                    </div>
                                        <br />
                                        <div class=" w3-row w3-round-medium w3-margin-top  shad" >
                                            <div class=" w3-col l3 w3-left">
                                                <asp:Label CssClass="blue_heading" Text="&nbsp;&nbsp;Hb" runat="server" />
                                            </div>
                                            <div class="w3-col l2">
                                                <asp:Label Text="13-02-2022" CssClass="grey_small" runat="server" /><br />
                                                <asp:Label Text="09:02" CssClass="blue_small" runat="server" />
                                            </div>
                                            <div class="w3-col l2">
                                                <asp:Label CssClass="blue_heading" Text="84 " runat="server" /><span class="blue_small">gms/dl</span>
                                            </div>
                                            <div class="w3-col l5">

                                            </div>
                                        </div>
                                        
                                        <div class= "w3-row w3-round-medium  shad" style="margin-top:5px;" >
                                            <div class="w3-col l3 w3-left">
                                                <asp:Label CssClass="blue_heading" Text="&nbsp;&nbsp;TLC" runat="server" />
                                            </div>
                                            <div class="w3-col l2">
                                                <asp:Label Text="13-02-2022" CssClass="grey_small" runat="server" /><br />
                                                <asp:Label Text="09:02" CssClass="blue_small" runat="server" />
                                            </div>
                                            <div class="w3-col l2">
                                                <asp:Label CssClass="blue_heading" Text="84 " runat="server" /><span class="blue_small">gms/dl</span>
                                            </div>
                                            <div class="w3-col l5">

                                            </div>
                                        </div>
                                        <div class= "w3-row w3-round-medium  shad" style="margin-top:5px;">
                                            <div class="w3-col l3 w3-left">
                                                <asp:Label CssClass="blue_heading" Text="&nbsp;&nbsp;Gluc. Fasting" runat="server" />
                                            </div>
                                            <div class="w3-col l2">
                                                <asp:Label Text="13-02-2022" CssClass="grey_small" runat="server" /><br />
                                                <asp:Label Text="09:02" CssClass="blue_small" runat="server" />
                                            </div>
                                            <div class="w3-col l2">
                                                <asp:Label CssClass="blue_heading" Text="84 " runat="server" /><span class="blue_small">gms/dl</span>
                                            </div>
                                            <div class="w3-col l5">

                                            </div>
                                        </div>
                                       <div class= "w3-row w3-round-medium  shad"  style="margin-top:5px;">
                                            <div class="w3-col l3 w3-left">
                                                <asp:Label CssClass="blue_heading" Text="&nbsp;&nbsp;Gluc. PP" runat="server" />
                                            </div>
                                            <div class="w3-col l2">
                                                <asp:Label Text="13-02-2022" CssClass="grey_small" runat="server" /><br />
                                                <asp:Label Text="09:02" CssClass="blue_small" runat="server" />
                                            </div>
                                            <div class="w3-col l2">
                                                <asp:Label CssClass="blue_heading" Text="84 " runat="server" /><span class="blue_small">gms/dl</span>
                                            </div>
                                            <div class="w3-col l5">

                                            </div>
                                        </div>
                                        <div class= "w3-row w3-round-medium  shad" style="margin-top:5px;">
                                            <div class="w3-col l3 w3-left">
                                                <asp:Label CssClass="blue_heading" Text="&nbsp;&nbsp;Urea" runat="server" />
                                            </div>
                                            <div class="w3-col l2">
                                                <asp:Label Text="13-02-2022" CssClass="grey_small" runat="server" /><br />
                                                <asp:Label Text="09:02" CssClass="blue_small" runat="server" />
                                            </div>
                                            <div class="w3-col l2">
                                                <asp:Label CssClass="blue_heading" Text="84 " runat="server" /><span class="blue_small">gms/dl</span>
                                            </div>
                                            <div class="w3-col l5">

                                            </div>
                                        </div>
                                        <div class= "w3-row w3-round-medium  shad" style="margin-top:5px;">
                                            <div class="w3-col l3 w3-left">
                                                <asp:Label CssClass="blue_heading" Text="&nbsp;&nbsp;Creatinine" runat="server" />
                                            </div>
                                            <div class="w3-col l2">
                                                <asp:Label Text="13-02-2022" CssClass="grey_small" runat="server" /><br />
                                                <asp:Label Text="09:02" CssClass="blue_small" runat="server" />
                                            </div>
                                            <div class="w3-col l2">
                                                <asp:Label CssClass="blue_heading" Text="84 " runat="server" /><span class="blue_small">gms/dl</span>
                                            </div>
                                            <div class="w3-col l5">

                                            </div>
                                        </div>
                                        <div class= "w3-row w3-round-medium  shad" style="margin-top:5px;">
                                            <div class="w3-col l3 w3-left">
                                                <asp:Label CssClass="blue_heading" Text="&nbsp;&nbsp;Na" runat="server" />
                                            </div>
                                            <div class="w3-col l2">
                                                <asp:Label Text="13-02-2022" CssClass="grey_small" runat="server" /><br />
                                                <asp:Label Text="09:02" CssClass="blue_small" runat="server" />
                                            </div>
                                            <div class="w3-col l2">
                                                <asp:Label CssClass="blue_heading" Text="84 " runat="server" /><span class="blue_small">gms/dl</span>
                                            </div>
                                            <div class="w3-col l5">

                                            </div>
                                        </div>
                                        <div class= "w3-row w3-round-medium  shad"  style="margin-top:5px;">
                                            <div class="w3-col l3 w3-left">
                                                <asp:Label CssClass="blue_heading" Text="&nbsp;&nbsp;K" runat="server" />
                                            </div>
                                            <div class="w3-col l2">
                                                <asp:Label Text="13-02-2022" CssClass="grey_small" runat="server" /><br />
                                                <asp:Label Text="09:02" CssClass="blue_small" runat="server" />
                                            </div>
                                            <div class="w3-col l2">
                                                <asp:Label CssClass="blue_heading" Text="84 " runat="server" /><span class="blue_small">gms/dl</span>
                                            </div>
                                            <div class="w3-col l5">

                                            </div>
                                        </div>
                                    <div class= "w3-row w3-round-medium  shad"  style="margin-top:5px;">
                                            <div class="w3-col l3 w3-left">
                                                <asp:Label CssClass="blue_heading" Text="&nbsp;&nbsp;CSF WBC" runat="server" />
                                            </div>
                                            <div class="w3-col l2">
                                                <asp:Label Text="13-02-2022" CssClass="grey_small" runat="server" /><br />
                                                <asp:Label Text="09:02" CssClass="blue_small" runat="server" />
                                            </div>
                                            <div class="w3-col l2">
                                                <asp:Label CssClass="blue_heading" Text="84 " runat="server" /><span class="blue_small">gms/dl</span>
                                            </div>
                                            <div class="w3-col l5">

                                            </div>
                                        </div>
                                    <div class= "w3-row w3-round-medium  shad"  style="margin-top:5px;">
                                            <div class="w3-col l3 w3-left">
                                                <asp:Label CssClass="blue_heading" Text="&nbsp;&nbsp;CSF RBC" runat="server" />
                                            </div>
                                            <div class="w3-col l2">
                                                <asp:Label Text="13-02-2022" CssClass="grey_small" runat="server" /><br />
                                                <asp:Label Text="09:02" CssClass="blue_small" runat="server" />
                                            </div>
                                            <div class="w3-col l2">
                                                <asp:Label CssClass="blue_heading" Text="84 " runat="server" /><span class="blue_small">gms/dl</span>
                                            </div>
                                            <div class="w3-col l5">

                                            </div>
                                        </div>
                                    <div class= "w3-row w3-round-medium  shad"  style="margin-top:5px;">
                                            <div class="w3-col l3 w3-left">
                                                <asp:Label CssClass="blue_heading" Text="&nbsp;&nbsp;CSF Bld Sugar" runat="server" />
                                            </div>
                                            <div class="w3-col l2">
                                                <asp:Label Text="13-02-2022" CssClass="grey_small" runat="server" /><br />
                                                <asp:Label Text="09:02" CssClass="blue_small" runat="server" />
                                            </div>
                                            <div class="w3-col l2">
                                                <asp:Label CssClass="blue_heading" Text="84 " runat="server" /><span class="blue_small">gms/dl</span>
                                            </div>
                                            <div class="w3-col l5">

                                            </div>
                                        </div>
                                    
                                </div>
                            </div>
                        </div>
                   </div>
                </div>
                <div class="w3-col l4">
                    <div class="w3-row " style="border-bottom:solid; border-color:#166D89; border-width:1px;">
                        <div class="w3-padding w3-margin-top">
                            <div class="w3-center">
                                <asp:Label Text="Fever Pack" CssClass="w3-text-white w3-large w3-round-medium w3-padding" BackColor="#166D89" runat="server" />
                                </div>   <br />
                                <table class=" w3-margin-top" style="width:100%;">
                                    <tr>
                                        <td></td>
                                        <td class="blue">10-02-2022</td>
                                        <td class="blue">11-02-2022</td>
                                        <td class="blue">12-02-2022</td>
                                    </tr>
                                    <tr>
                                        <td class="blue_heading">Bld C+S</td>
                                        <td class="grey">+ve</td>
                                        <td class="grey">-ve</td>
                                        <td class="grey">+ve</td>
                                    </tr>
                                    <tr>
                                        <td class="blue_heading">Trach C+S</td>
                                        <td class="grey">+ve</td>
                                        <td class="grey">-ve</td>
                                        <td class="grey">+ve</td>
                                    </tr>
                                    <tr>
                                        <td class="blue_heading">Urine C+S</td>
                                        <td class="grey">+ve</td>
                                        <td class="grey">-ve</td>
                                        <td class="grey">+ve</td>
                                    </tr>
                                    <tr>
                                        <td class="blue_heading">Urine R+M</td>
                                        <td class="grey">+ve</td>
                                        <td class="grey">-ve</td>
                                        <td class="grey">+ve</td>
                                    </tr>
                                </table>
                                    
                        </div>
                    </div>
                    <div class="w3-row " style="border-bottom:solid; border-color:#166D89; border-width:1px;">
                        <div class="w3-padding w3-margin-top">
                            <div class="w3-center">
                                <asp:Label Text="Chest X-Ray" CssClass="w3-text-white w3-large w3-round-medium w3-padding" BackColor="#166D89" runat="server" />
                            </div>
                            <br /> 
                        </div>
                    </div>
                    <div class="w3-row " style="border-bottom:solid; border-color:#166D89; border-width:1px;">
                        <div class="w3-padding w3-margin-top">
                            <div class="w3-center">
                                <asp:Label Text="CT Scan" CssClass="w3-text-white w3-large w3-round-medium w3-padding" BackColor="#166D89" runat="server" />
                            </div>
                            <br /> 
                        </div>
                    </div>
                    <div class="w3-row ">
                        <div class="w3-padding w3-margin-top">
                            <div class="w3-center">
                                <asp:Label Text="Plan for Today" CssClass="w3-text-white w3-large w3-round-medium w3-padding" BackColor="#166D89" runat="server" />
                            </div>
                          
                            <table class="w3-table w3-bordered w3-margin-top">
                                <tr>
                                    <td style="width:100px;">CT</td>
                                    <td>:</td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>X-Ray</td>
                                    <td>:</td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>MRI</td>
                                    <td>:</td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>BT</td>
                                    <td>:</td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>Other</td>
                                    <td>:</td>
                                    <td></td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </form>
</body>
</html>
