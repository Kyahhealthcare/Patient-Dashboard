<%@ Page Language="C#" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="dashboard.aspx.cs" Inherits="TVDisplay.dashboard" %>

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
         * {
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
    </style>

    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css"/>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>

    <link rel="stylesheet" href="https://www.w3schools.com/lib/w3-colors-2020.css"/>

    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet"/>
    <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons"/>
    <script src='https://kit.fontawesome.com/a076d05399.js' crossorigin='anonymous'></script>

    <script src="https://your-site-or-cdn.com/fontawesome/v6.0.0-beta3/js/all.js" data-auto-replace-svg="nest"></script>

    <link rel="preconnect" href="https://fonts.googleapis.com"/>
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin/>
    <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@100;300;400;500&display=swap" rel="stylesheet"/>

</head>
<body>
    <form id="form1" runat="server">
                
        <div class="w3-bar w3-small w3-text-white" style=" background-color:#166D89;">
            <div class="w3-bar-item">
                <div style="font-weight:400; font-size:23px;">Patient: <asp:Label ID="p_name" Text="" runat="server" /></div>
            </div>
            <div class="w3-bar-item w3-hide-small w3-hide-medium">
                <div style="font-weight:400; font-size:23px;">UHID: <asp:Label ID="uhid" Text="" runat="server" /></div>
            </div>
            <div class="w3-bar-item  w3-hide-small w3-hide-medium">
                <div style="font-weight:400; font-size:23px;">Age/Sex: <asp:Label ID="age_sex" Text="" runat="server" /></div>
            </div>
            <div class="w3-bar-item  w3-hide-small w3-hide-medium">
                <div style="font-weight:400; font-size:23px;">DOA: <asp:Label ID="doa" Text="" runat="server" /></div>
            </div>
            <div class="w3-bar-item w3-hide-small w3-hide-medium ">
                <div style="font-weight:400; font-size:23px;">LOS: <asp:Label ID="los" Text="" runat="server" /></div>
            </div>
            <div class="w3-bar-item w3-right  w3-hide-small w3-hide-medium">
                <a href="mob_dash.aspx"><i class="fa fa-mobile" style="font-size:32px;" ></i></a>
            </div>
            <div class="w3-bar-item w3-right  w3-hide-small w3-hide-medium">
                <div style="font-weight:400; font-size:23px;">Bed No.: <asp:Label ID="bed" Text="" runat="server" /></div>
            </div>
            <div class="w3-bar-item w3-right  w3-hide-small w3-hide-medium">
                <div style="font-weight:400; font-size:23px;">Ward: <asp:Label ID="ward" Text="" runat="server" /></div>
            </div>
            
        </div>
        <div class="w3-padding-small  w3-hide-large ">
            <div class="w3-row w3-padding w3-hide-large w3-round-large" style=" background-color:#166D89; color:white; ">
                <div class="w3-col m4 s6 w3-padding-small">
                    <div style="font-weight:400; font-size:16px;">UHID: <asp:Label ID="uhid2" Text="" runat="server" /></div>
                </div>
                <div class="w3-col m4 s6 w3-padding-small">
                    <div style="font-weight:400; font-size:16px;">Age/Sex: <asp:Label ID="age_sex2" Text="" runat="server" /></div>
                </div>
                <div class="w3-col m4 s6 w3-padding-small">
                    <div style="font-weight:400; font-size:16px;">DOA: <asp:Label ID="doa2" Text="" runat="server" /></div>
                </div>
                <div class="w3-col m4 s6 w3-padding-small">
                    <div style="font-weight:400; font-size:16px;">LOS: <asp:Label ID="los2" Text="" runat="server" /></div>
                </div>
                <div class="w3-col m4 s6 w3-padding-small">
                    <div style="font-weight:400; font-size:16px;">Bed No.: <asp:Label ID="bed2" Text="" runat="server" /></div>
                </div>
                <div class="w3-col m4 s6 w3-padding-small">
                    <div style="font-weight:400; font-size:16px;">Ward: <asp:Label ID="ward2" Text="" runat="server" /></div>
                </div>
            </div>
        </div>
        <div class="w3-row" >
            <div class="w3-col l2 s12 m6">
                <div class="w3-white w3-round-xlarge w3-padding" style="height:auto; min-height:13vh; margin-top:10px;  margin-left:10px; margin-bottom:10px; margin-right:5px;">
                    <div class="w3-row w3-border-bottom w3-border-light-gray w3-margin-top" style="font-weight:400; height:25%; font-size:18px; color:#166D89;">
                        Blood Group: <asp:Label Text="" ID="bld_grp" runat="server"  Font-Size="16px" ForeColor="Gray"/>
                    </div>
                    <div class="w3-row  w3-border-bottom w3-border-light-gray" style="font-weight:400; font-size:18px; height:28%; color:#166D89;">
                        Blood Donated: <asp:Label Text="" ID="bld_donated" runat="server"  Font-Size="16px" ForeColor="Gray"/>
                    </div>
                    <div class="w3-row " style="font-weight:400; font-size:18px; color:#166D89; height:25%;">
                        Infusion: <asp:Label Text="" ID="infusion1" runat="server" Font-Size="16px" ForeColor="Gray" />
                    </div>                    
                </div>
                <div class="w3-white w3-round-xlarge w3-padding" style="height:auto; min-height:15.7vh; margin-left:10px; margin-bottom:5px; margin-right:5px;">
                    <div class="w3-center w3-border-bottom w3-border-light-gray" style="font-weight:500; margin-bottom:5px; font-size:22px; "><asp:Label Text="Last 24H I/O" ForeColor="#166D89" runat="server" /></div>
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
            <div class="w3-col l3 s12 m6">
                <div class="w3-white w3-round-xlarge w3-padding-small" style="height:auto; min-height:30vh; margin-top:10px;  margin-left:5px; margin-bottom:5px; margin-right:5px;">
                    <div class="w3-center w3-border-bottom w3-border-light-gray" style="font-weight:500; margin-bottom:5px; font-size:25px; "><asp:Label Text="Diagnosis" ForeColor="#166D89" runat="server" /></div>
                    
                    <div class=" w3-border-bottom w3-border-light-gray" style="font-weight:400; min-height:8vh; height:auto; font-size:18px; color:#166D89;">1. <asp:Label ID="diag1" Text="" ForeColor="Gray"  runat="server" /></div>
                    
                    <div class=" w3-border-bottom w3-border-light-gray" style="font-weight:400; min-height:8vh; height:auto; font-size:18px; color:#166D89;">2. <asp:Label ID="diag2" Text="" ForeColor="Gray"  runat="server" /></div>
                   
                    <div class=" w3-border-bottom w3-border-light-gray" style="font-weight:400; min-height:8vh; height:auto; font-size:18px; color:#166D89;">3. <asp:Label ID="diag3" Text="" ForeColor="Gray"  runat="server" /></div>
                
                </div>
            </div>
            <div class="w3-col l2 s12 m6">
                <div class="w3-white w3-round-xlarge w3-padding-small" style="height:auto; min-height:30vh; margin-top:10px;  margin-left:5px; margin-bottom:5px; margin-right:5px;">
                    <div class="w3-center w3-border-bottom w3-border-light-gray" style="font-weight:500; margin-bottom:5px; font-size:25px;"><asp:Label Text="Ventilation Mode" ForeColor="#166D89" runat="server" /></div>
                    <table class="w3-table w3-bordered w3-center" style="width:100%; height:80%; color:grey;">
                        <tr>
                            <td class="w3-center">
                                Mode: <asp:Label ID="mode" Text="" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="w3-center">
                                Tracheostomy: <asp:Label ID="trach" Text="" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="w3-center">
                                Intubation: <asp:Label ID="intubated" Text="" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="w3-center">
                                Sedation: <asp:Label ID="sedated" Text="" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="w3-center">
                                <asp:Label ID="fio2" Text="" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="w3-center">
                                <asp:Label ID="ps" Text="" runat="server" />
                            </td>
                        </tr>
                    </table>
                    
                </div>
            </div>
            <div class="w3-col l5 s12 m12">
                <div class="w3-white w3-round-xlarge w3-padding-small" style="height:auto; min-height:30vh; margin-top:10px;  margin-left:5px; margin-bottom:5px; margin-right:10px;">
                    <div class=" w3-border-bottom w3-border-light-gray" style="font-weight:500; padding-left:10px; padding-right:10px; margin-bottom:5px; font-size:25px;">
                        <asp:Label Text="Surgery" ForeColor="#166D89" runat="server" />
                        <div class="w3-right" style="color:#166D89;">Dr. <asp:Label ID="surg" Text="" runat="server" /></div>
                    </div>
                    <div class="w3-row" style="height:100%;" >
                        <div class="w3-col l3 s12 m6 w3-padding-small " style="height:85%; ">
                            <div class="w3-round-large " style="width:100%;  height:auto; min-height:23.5vh; background-color:#f7fbfc; ">
                                <div class="w3-row w3-cell-row" style="min-height:18.33vh; height:auto;">
                                    <div class="w3-cell w3-cell-middle" style="text-align:center;">
                                        <asp:Label ID="s_name1" Text="" CssClass="grey_text" runat="server" />
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
                        <div class="w3-col l3 s12 m6 w3-padding-small " style="height:85%; ">
                            <div class="w3-round-large " style="width:100%;  height:auto; min-height:23.5vh; background-color:#f7fbfc; ">
                                <div class="w3-row w3-cell-row" style="min-height:18.33vh; height:auto;">
                                    <div class="w3-cell w3-cell-middle" style="text-align:center;">
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
                        <div class="w3-col l3 s12 m6 w3-padding-small " style="height:85%; ">
                            <div class="w3-round-large " style="width:100%;  height:auto; min-height:23.5vh; background-color:#f7fbfc; ">
                                <div class="w3-row w3-cell-row" style="min-height:18.33vh; height:auto;">
                                    <div class="w3-cell w3-cell-middle" style="text-align:center;">
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
                        <div class="w3-col l3 s12 m6 w3-padding-small " style="height:85%;">
                            <div class="w3-round-large " style="width:100%;  height:auto; min-height:23.5vh; background-color:#f7fbfc; ">
                                <div class="w3-row w3-cell-row" style="min-height:18.33vh; height:auto;">
                                    <div class="w3-cell w3-cell-middle" style="text-align:center;">
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
        </div>
        <div class="w3-row" >
            <div class="w3-col l3 s12 m12">
                <div class="w3-white w3-round-xlarge w3-padding-small" style="height:auto; min-height:62vh; margin-top:5px;  margin-left:10px; margin-bottom:5px; margin-right:5px;">
                    <div class="w3-center w3-border-bottom w3-border-light-gray" style="font-weight:500; margin-bottom:5px; font-size:25px;"><asp:Label Text="Vitals" ForeColor="#166D89" runat="server" /></div>
                    
                    <div class="w3-row w3-center">
                        <div class="w3-col l4 s6 m6 w3-padding-small">
                            <div class="w3-tag w3-center  w3-round-large" style="height:45px; font-size:16px; padding:10px 2px; width:100%; font-weight:500; background-color:#f1f1f1; color:#000;">
                                <div>RR <asp:Label ID="rr" Text="" runat="server" /><span style="color:#166D89; font-size:13px; font-weight:400;"> bpm</span></div>
                            </div>
                            <div style="color:#166D89; font-weight:400;">
                                <asp:Label ID="rr_date" Text=""  runat="server" />
                                <asp:Label ID="rr_time" Text=""  runat="server" />
                            </div>
                        </div>
                        <div class="w3-col l4 s6 m6 w3-padding-small">
                            <div class="w3-tag   w3-center w3-round-large" style="height:45px; width:100%; font-size:16px; padding:10px 2px; font-weight:500;  background-color:#f1f1f1; color:#000;">
                                <div>Pulse <asp:Label ID="pulse" Text="" runat="server" /><span style="color:#166D89; font-size:13px; font-weight:400;"> bpm</span></div>
                            </div>
                            <div style="color:#166D89; font-weight:400;">
                                <asp:Label ID="pulse_date" Text=""  runat="server" />
                                <asp:Label ID="pulse_time" Text="" runat="server" />
                            </div>
                        </div>
                        <div class="w3-col l4 s6 m6 w3-padding-small">
                            <div class="w3-tag w3-center w3-round-large" style="height:45px; font-size:16px; width:100%; padding:10px 2px; font-weight:500;  background-color:#f1f1f1; color:#000;">
                                <div>Temp <asp:Label ID="temp" Text="" runat="server" /><span style="color:#166D89; font-size:13px; font-weight:400;"> <sup>o</sup>F</span></div>
                            </div>
                            <div style="color:#166D89; font-weight:400;">
                                <asp:Label ID="temp_date" Text=""  runat="server" />
                                <asp:Label ID="temp_time" Text="" runat="server" />
                            </div>
                        </div>
                        <div class="w3-col l4 s6 m6 w3-padding-small">
                            <div class="w3-tag  w3-center  w3-round-large"  style="height:45px; font-size:16px;  width:100%; padding:10px 2px; font-weight:500;  background-color:#f1f1f1; color:#000;">
                                <div>BP <asp:Label ID="bp" Text="" ForeColor="Red" runat="server" /><span style="color:#166D89; font-size:13px; font-weight:400;"> mmHg</span></div>
                            </div>
                            <div style="color:#166D89; font-weight:400;">
                                <asp:Label ID="bp_date" Text="" runat="server" />
                                <asp:Label ID="bp_time" Text="" runat="server" />
                            </div>
                        </div>
                        <div class="w3-col l4 s6 m6 w3-padding-small">
                            <div class="w3-tag  w3-center  w3-round-large" style="height:45px; font-size:16px; width:100%; padding:10px 2px; font-weight:500;  background-color:#f1f1f1; color:#000;">
                                <div>ICP <asp:Label ID="icp" Text="" runat="server" /><span style="color:#166D89; font-size:13px; font-weight:400;"> mmHg</span></div>
                            </div>
                            <div style="color:#166D89; font-weight:400;">
                                <asp:Label ID="icp_date" Text="" runat="server" />
                                <asp:Label ID="icp_time" Text="" runat="server" />
                            </div>
                        </div>
                        <div class="w3-col l4 s6 m6 w3-padding-small">
                            <div class="w3-tag  w3-center  w3-round-large" style="height:45px; font-size:16px; width:100%; padding:10px 2px; font-weight:500;  background-color:#f1f1f1; color:#000;">
                                <div>SPO<sub>2</sub> <asp:Label ID="spo2" Text="" runat="server" /><span style="color:#166D89; font-size:13px; font-weight:400;"> mmHg</span></div>
                            </div>
                            <div style="color:#166D89; font-weight:400;">
                                <asp:Label ID="spo2_date" Text="" runat="server" />
                                <asp:Label ID="spo2_time" Text="" runat="server" />
                            </div>
                        </div>
                    </div>

                </div>
            </div>
            <div class="w3-col l3 m12 s12">
                <div class="w3-white w3-round-xlarge w3-padding-small" style="height:auto; min-height:62vh; margin-top:5px;  margin-left:5px; margin-bottom:5px; margin-right:5px;">
                    <div class="w3-center w3-border-bottom w3-border-light-gray" style="font-weight:500; margin-bottom:5px; font-size:25px;"><asp:Label Text="Lab-Tests" ForeColor="#166D89" runat="server" /></div>
                    
                    <div class="w3-row">
                        <div class="w3-col l6 s12 m6 w3-padding-small" >
                            <div class="w3-large w3-left  w3-round-large" style="height:70px; width:100%; padding:7px 10px; font-weight:500;  background-color:#f1f1f1; color:#000;">
                                <div>Hb <asp:Label ID="hb" Text="" runat="server" /><span style="color:#166D89; font-size:13px; font-weight:400;"> gms/dL</span></div>
                                <div class="w3-right" style="color:#414143; font-weight:400; font-size:12px;">
                                    <asp:Label ID="hb_date" Text=""  runat="server" /><br />
                                    <asp:Label ID="hb_time" Text=""  runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="w3-col l6 s12 m6  w3-padding-small" >
                           <div class="w3-large w3-left  w3-round-large" style="height:70px; width:100%; padding:7px 10px; font-weight:500;  background-color:#f1f1f1; color:#000;">
                                <div>TLC <asp:Label ID="tlc" Text="" runat="server" /><span style="color:#166D89; font-size:13px; font-weight:400;"> gms/dL</span></div>
                               <div class="w3-right" style="color:#414143; font-weight:400; font-size:12px;">
                                    <asp:Label ID="tlc_date" Text=""  runat="server" /><br />
                                    <asp:Label ID="tlc_time" Text=""  runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="w3-col l6 s12 m6  w3-padding-small" >
                            <div class="w3-large w3-left  w3-round-large" style="height:70px; width:100%; padding:7px 10px; font-weight:500;  background-color:#f1f1f1; color:#000;">
                                <div>Glu. Fasting <asp:Label ID="fasting" Text="" runat="server" /><span style="color:#166D89; font-size:13px; font-weight:400;"> gms/dL</span></div>
                                <div class="w3-right" style="color:#414143; font-weight:400; font-size:12px;">
                                    <asp:Label ID="fasting_date" Text=""  runat="server" /><br />
                                    <asp:Label ID="fasting_time" Text=""  runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="w3-col l6 s12 m6  w3-padding-small" >
                           <div class="w3-large w3-left  w3-round-large" style="height:70px; width:100%; padding:7px 10px; font-weight:500;  background-color:#f1f1f1; color:#000;">
                                <div>Glu. PP <asp:Label ID="pp" Text="" runat="server" /><span style="color:#166D89; font-size:13px; font-weight:400;"> gms/dL</span></div>
                               <div class="w3-right" style="color:#414143; font-weight:400; font-size:12px;">
                                    <asp:Label ID="pp_date" Text=""  runat="server" /><br />
                                    <asp:Label ID="pp_time" Text=""  runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="w3-col l6 s12 m6  w3-padding-small" >
                            <div class="w3-large w3-left  w3-round-large" style="height:70px; width:100%; padding:7px 10px; font-weight:500;  background-color:#f1f1f1; color:#000;">
                                <div>Urea <asp:Label ID="urea" Text="" runat="server" /><span style="color:#166D89; font-size:13px; font-weight:400;"> gms/dL</span></div>
                                <div class="w3-right" style="color:#414143; font-weight:400; font-size:12px;">
                                    <asp:Label ID="urea_date" Text=""  runat="server" /><br />
                                    <asp:Label ID="urea_time" Text=""  runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="w3-col l6  s12 m6 w3-padding-small" >
                           <div class="w3-large w3-left  w3-round-large" style="height:70px; width:100%; padding:7px 10px; font-weight:500;  background-color:#f1f1f1; color:#000;">
                                <div>Creatinine <asp:Label ID="creatnine" Text="" runat="server" /><span style="color:#166D89; font-size:13px; font-weight:400;"> gms/dL</span></div>
                               <div class="w3-right" style="color:#414143; font-weight:400; font-size:12px;">
                                    <asp:Label ID="creat_date" Text=""  runat="server" /><br />
                                    <asp:Label ID="creat_time" Text=""  runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="w3-col l6  s12 m6 w3-padding-small" >
                            <div class="w3-large w3-left  w3-round-large" style="height:70px; width:100%; padding:7px 10px; font-weight:500;  background-color:#f1f1f1; color:#000;">
                                <div>Na <asp:Label Text="65" ID="na" runat="server" /><span style="color:#166D89; font-size:13px; font-weight:400;"> gms/dL</span></div>
                                <div class="w3-right" style="color:#414143; font-weight:400; font-size:12px;">
                                    <asp:Label ID="na_date" Text=""  runat="server" /><br />
                                    <asp:Label ID="na_time" Text=""  runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="w3-col l6 s12 m6  w3-padding-small" >
                           <div class="w3-large w3-left  w3-round-large" style="height:70px; width:100%; padding:7px 10px; font-weight:500;  background-color:#f1f1f1; color:#000;">
                                <div>K <asp:Label ID="k" Text="" runat="server" /><span style="color:#166D89; font-size:13px; font-weight:400;"> gms/dL</span></div>
                               <div class="w3-right" style="color:#414143; font-weight:400; font-size:12px;">
                                    <asp:Label ID="k_date" Text=""  runat="server" /><br />
                                    <asp:Label ID="k_time" Text=""  runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="w3-col l6 s12 m6  w3-padding-small" >
                            <div class="w3-large w3-left  w3-round-large" style="height:70px; width:100%; padding:7px 10px; font-weight:500;  background-color:#f1f1f1; color:#000;">
                                <div>CSF WBC <asp:Label ID="wbc" Text="" runat="server" /><span style="color:#166D89; font-size:13px; font-weight:400;"> gms/dL</span></div>
                                <div class="w3-right" style="color:#414143; font-weight:400; font-size:12px;">
                                    <asp:Label ID="wbc_date" Text=""  runat="server" /><br />
                                    <asp:Label ID="wbc_time" Text=""  runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="w3-col l6 s12 m6  w3-padding-small" >
                           <div class="w3-large w3-left  w3-round-large" style="height:70px; width:100%; padding:7px 10px; font-weight:500;  background-color:#f1f1f1; color:#000;">
                                <div>CSF RBC <asp:Label ID="rbc" Text="" runat="server" /><span style="color:#166D89; font-size:13px; font-weight:400;"> gms/dL</span></div>
                               <div class="w3-right" style="color:#414143; font-weight:400; font-size:12px;">
                                    <asp:Label ID="rbc_date" Text=""  runat="server" /><br />
                                    <asp:Label ID="rbc_time" Text=""  runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="w3-col l6 s12 m6  w3-padding-small" >
                            <div class="w3-large w3-left  w3-round-large" style="height:70px; width:100%; padding:7px 10px; font-weight:500;  background-color:#f1f1f1; color:#000;">
                                <div>CSF Bld Sugar <asp:Label ID="csf_sugar" Text="" runat="server" /><span style="color:#166D89; font-size:13px; font-weight:400;"> gms/dL</span></div>
                                <div class="w3-right" style="color:#414143; font-weight:400; font-size:12px;">
                                    <asp:Label ID="csf_sugar_date" Text=""  runat="server" /><br />
                                    <asp:Label ID="csf_sugar_time" Text=""  runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="w3-col l6 s12 m6  w3-padding-small" >
                           <div class="w3-large w3-left  w3-round-large" style="height:70px; width:100%; padding:7px 10px; font-weight:500;  background-color:#f1f1f1; color:#000;">
                                <div><%-- <asp:Label Text="65" runat="server" /><span style="color:#166D89; font-size:13px; font-weight:400;"> gms/dL</span>--%></div>
                            </div>
                        </div>
                        <div class="w3-col l6 s12 m6  w3-padding-small" >
                           <div class="w3-large w3-left  w3-round-large" style="height:70px; width:100%; padding:7px 10px; font-weight:500;  background-color:#f1f1f1; color:#000;">
                                <div><%-- <asp:Label Text="65" runat="server" /><span style="color:#166D89; font-size:13px; font-weight:400;"> gms/dL</span>--%></div>
                            </div>
                        </div>
                        <div class="w3-col l6  s12 m6 w3-padding-small" >
                           <div class="w3-large w3-left  w3-round-large" style="height:70px; width:100%; padding:7px 10px; font-weight:500;  background-color:#f1f1f1; color:#000;">
                                <div><%-- <asp:Label Text="65" runat="server" /><span style="color:#166D89; font-size:13px; font-weight:400;"> gms/dL</span>--%></div>
                            </div>
                        </div>

                    </div>

                </div>
            </div>
            <div class="w3-col l2 s12 m12">
                <div class="w3-white w3-round-xlarge w3-padding-small" style="height:auto; min-height:24vh; margin-top:5px;  margin-left:5px; margin-bottom:5px; margin-right:5px;">
                    <div class="w3-center w3-border-bottom w3-border-light-gray" style="font-weight:500; font-size:25px; margin-bottom:5px;"><asp:Label Text="Fever-Pack" ForeColor="#166D89" runat="server" /></div>
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
                <div class="w3-white w3-round-xlarge w3-padding-small" style="height:auto; min-height:37vh; margin-top:10px;  margin-left:5px; margin-bottom:5px; margin-right:5px;">
                    <div class="w3-center  w3-border-bottom w3-border-light-gray " style="font-weight:500; margin-bottom:5px; font-size:25px;"><asp:Label Text="Issues" ForeColor="#166D89" runat="server" /></div>

                    <div class="w3-row" style="height:100% ;">
                        <div class="w3-col l11 s11 m11">
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
                        <div class="w3-col l1 s1 m1 w3-border-left w3-border-light-gray" style="padding:40px 0; height:auto; min-height:31.45vh;">
                            <div class="w3-right" style="writing-mode:vertical-rl;text-orientation: mixed;">
                                <div style="font-weight:400; font-size:15px;"><span class="red_dot" ></span>
                                <asp:Label Text="Active" ForeColor="Gray" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;
                                <span class="yellow_dot" ></span>
                                <asp:Label Text="Inactive" ForeColor="Gray" runat="server" /></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="w3-col l4 m12 s12">
                <div class="w3-white w3-round-xlarge w3-padding-small" style="height:auto; min-height:30.5vh; margin-top:5px;  margin-left:5px; margin-bottom:5px; margin-right:10px;">
                    <div class="w3-row" style="height:50%;">
                        <div class="w3-col l3 m3 w3-hide-small " style="padding:50px 10px;" >
                            <div  style="font-weight:500; font-size:25px;">
                                <asp:Label Text="Chest X-ray" ForeColor="#166D89" runat="server" />
                            </div>
                        </div>
                        <div class=" w3-hide-large w3-hide-medium w3-center w3-border-bottom w3-border-light-gray" style="font-weight:500; margin-bottom:5px; font-size:25px;"><asp:Label Text="Chest X-Ray" ForeColor="#166D89" runat="server" /></div>
                        <div class="w3-col l3 m3 s4 w3-padding-small" style="height:100%;">
                            <asp:Image ID="x_img1" ImageUrl="" Width="100%" Height="100%" runat="server" />
                        </div>
                        <div class="w3-col l3 m3 s4 w3-padding-small" style="height:100%;">
                            <asp:Image ID="x_img2" ImageUrl="" Width="100%" Height="100%" runat="server" />
                        </div>
                        <div class="w3-col l3 m3 s4 w3-padding-small" style="height:100%;">
                            <asp:Image ID="x_img3" ImageUrl="" Width="100%" Height="100%" runat="server" />
                        </div>
                    </div>
                    
                    <div class="w3-row" style="height:50%;">
                        <div class="w3-col l3 m3 w3-hide-small" style="padding:50px 10px;" >
                            <div style="font-weight:500; font-size:25px;">
                                <asp:Label Text="CT Scan" ForeColor="#166D89" runat="server" />
                            </div>
                        </div>
                        <div class=" w3-hide-large w3-hide-medium w3-center w3-border-bottom w3-border-light-gray" style="font-weight:500; margin-bottom:5px; font-size:25px;"><asp:Label Text="CT Scan" ForeColor="#166D89" runat="server" /></div>
                        <div class="w3-col l3 m3 s4 w3-padding-small" style="height:100%;">
                            <asp:Image ID="ct_img1" ImageUrl="" Width="100%" Height="100%" runat="server" />
                        </div>
                        <div class="w3-col l3 m3 s4 w3-padding-small" style="height:100%;">
                            <asp:Image ID="ct_img2" ImageUrl="" Width="100%" Height="100%" runat="server" />
                        </div>
                        <div class="w3-col l3 m3 s4 w3-padding-small" style="height:100%;">
                            <asp:Image ID="ct_img3" ImageUrl="" Width="100%" Height="100%" runat="server" />
                        </div>
                    </div>
                </div>
                <div class="w3-white w3-round-xlarge w3-padding-small" style="height:auto; min-height:30.5vh; margin-top:10px;  margin-left:5px; margin-bottom:5px; margin-right:10px;">
                    <div class="w3-center w3-border-bottom w3-border-light-gray" style="font-weight:500; margin-bottom:5px; font-size:25px;"><asp:Label Text="Plan for Today" ForeColor="#166D89" runat="server" /></div>
                    <div class="w3-row ">
                        <div class=" w3-container w3-round-xxlarge w3-light-gray">
                            <asp:Label ID="other_today" Text="" ForeColor="#166D89" runat="server" />
                        </div>
                    </div>
                    <table class="w3-table w3-bordered ">
                        <tr>
                            <td style="width:70px; color:#166D89; font-size:17px; font-weight:400;">CT</td>
                            <td style="color:#166D89; font-size:17px; font-weight:500; width:1px;">:</td>
                            <td class="w3-left" style="font-size:17px; font-weight:400; color:gray;">
                                <asp:Label ID="ct_today" Text="text" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width:70px; color:#166D89; font-size:17px; font-weight:400;">X-Ray</td>
                            <td style="color:#166D89; font-size:17px; font-weight:500;">:</td>
                            <td class="w3-left" style="font-size:17px; font-weight:400; color:gray;">
                                <asp:Label ID="x_today" Text="text" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width:70px; color:#166D89; font-size:17px; font-weight:400;">MRI</td>
                            <td style="color:#166D89; font-size:17px; font-weight:500;">:</td>
                            <td class="w3-left" style="font-size:17px; font-weight:400; color:gray;">
                                <asp:Label ID="mri_today" Text="text" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width:70px; color:#166D89; font-size:17px; font-weight:400;">USD</td>
                            <td style="color:#166D89; font-size:17px; font-weight:500;">:</td>
                            <td class="w3-left" style="font-size:17px; font-weight:400; color:gray;">
                                <asp:Label ID="usd_today" Text="text" runat="server" />
                            </td>
                        </tr>
                      
                    </table>

                </div>
            </div>
        </div>

          
        
    </form>
</body>
</html>
