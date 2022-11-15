<%@ Page Language="C#" AutoEventWireup="true"  CodeBehind="Home.aspx.cs" Async="true" MaintainScrollPositionOnPostback="true" Inherits="TVDisplay.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <style type="text/css">
        * {
            /*font-family: 'Montserrat', sans-serif;*/
            font-family: 'Roboto', sans-serif;
        }

        .lb {
            text-decoration: none;
        }

        .input-box {
            position: relative;
        }

        input {
            display: block;
            width: 195px;
        }

        .unit {
            position: absolute;
            display: block;
            right: 5px;
            top: 4px;
            z-index: 2;
            color: #166D89;
        }

        .inline {
            display: inline-block;
        }

        .switch {
            position: relative;
            /*width: 14rem;*/
            width: 300px;
            /*padding: 0 0.2rem;*/
            font-family: verdana;
            display: inline-block;
        }

        .switch:before {
            content: '  ';
            position: absolute;
            left: 0;
            z-index: -1;
            width: 100%;
            height: 3rem;
            background: white;
            border: solid;
            border-color: #166d89;
            border-width: 1px;
            border-radius: 10px;
        }

        .switch__label1 {
            display: inline-block;
            width: 40%;
            padding: 12px 15px;
            text-align: left;
            cursor: pointer;
            transition: color 200ms ease-out;
            color: #166d89;
            /*font-weight:bold;*/
        }

            .switch__label1:hover {
                color: darkgray;
            }

        .switch__label2 {
            display: inline-block;
            width: 50%;
            padding: 12px 15px;
            text-align: right;
            cursor: pointer;
            transition: color 200ms ease-out;
            /*font-weight:bold;*/
            color: #166d89;
        }

            .switch__label2:hover {
                color: darkgray;
            }

        .switch__indicator {
            width: contain;
            height: 2.5rem;
            position: absolute;
            top: 0.275rem;
            left: 0;
            background: #166d89;
            border-radius: 10px;
            transition: transform 600ms cubic-bezier(.02,.94,.09,.97), background 300ms cubic-bezier(.17,.67,.14,1.03);
            transform: translateX(1rem);
            /* transition: all .4s ease-out;*/
            padding: 7px;
        }


        #one:checked ~ .switch__indicator {
            background: #166d89;
            transform: translateX(1rem);
            /*transition: all .4s ease-out;*/ /*
            */
            /*transition: all .10s ease-out;*/
        }

        .cc:before {
            content: "Main AIIMS";
            color: white;
            /*font-weight:bold;*/
        }
       
        #three:checked ~ .switch__indicator {
            /* left:80%;*/
            background: #166d89;
            transform: translateX(285px) translateX(-100%);
        }

        #three:checked ~ .cc:before {
            content: "Trauma Center";
            color: white;
        }


        input[type="radio"] {
            display: none;
        }

        @import url('https://fonts.googleapis.com/css?family=Lato:400,500,600,700&display=swap');

        .wrapper {
            display: inline-flex;
            background: #fff;
            height: 60px;
            width: 100%;
            align-items: center;
            /*justify-content: space-evenly;*/
            border-radius: 5px;
            padding: 8px 5px;
            box-shadow: 5px 5px 30px rgba(0,0,0,0.2);
        }

            .wrapper .option {
                background: #fff;
                height: 100%;
                width: 100%;
                display: flex;
                align-items: center;
                justify-content: space-evenly;
                margin: 0 5px;
                border-radius: 5px;
                cursor: pointer;
                padding: 0 5px;
                border: 2px solid #166d89;
                /*transition: all 0.3s ease;*/
            }

            .wrapper .option .dot {
                height: 20px;
                width: 20px;
                background: #166d89;
                border-radius: 50%;
                position: relative;
            }

            .wrapper .option .dot::before {
                position: absolute;
                content: "";
                top: 4px;
                left: 4px;
                width: 12px;
                height: 12px;
                background: #166d89;
                border-radius: 50%;
                opacity: 0;
                /*transform: scale(1.5);*/
                /*transition: all 0.3s ease;*/
            }

        input[type="checkbox"] {
            display: none;
        }

        input[type="radio"] {
            display: none;
        }

        #option_1:checked ~ .option_1,
        #option_2:checked ~ .option_2 {
            border-color: #166d89;
            background: #166d89;
        }

            #option_1:checked ~ .option_1 .dot,
            #option_2:checked ~ .option_2 .dot {
                background: #fff;
            }

                #option_1:checked ~ .option_1 .dot::before,
                #option_2:checked ~ .option_2 .dot::before {
                    opacity: 1;
                    /*transform: scale(1);*/
                }

        .wrapper .option span {
            font-size: 20px;
            color: #166d89;
        }

        #option_1:checked ~ .option_1 span,
        #option_2:checked ~ .option_2 span {
            color: #fff;
        }

        .radio-toolbarr1 {
            margin-top: 0px;
            align-content: center;
            width: 100%;
            text-align: center;
        }

            .radio-toolbarr1 input[type="radio"] {
                opacity: 0;
                width: 0;
            }

            .radio-toolbarr1 label {
                display: inline-block;
                background-color: white;
                color: #166d89;
                padding: 9px 30px;
                font-family: sans-serif, Arial;
                font-size: 18px;
                /*margin-bottom:25px;*/
                border: 0px solid #444;
                border-radius: 10px;
                width: 100%;
                text-align: center;
            }

                .radio-toolbarr1 label:hover {
                    background-color: #166d89;
                    color: white;
                }

            .radio-toolbarr1 input[type="radio"]:focus + label {
                border: 0px solid black;
            }

            .radio-toolbarr1 input[type="radio"]:checked + label {
                background-color: #166d89;
                color: white;
                border-color: #79B4B7;
            }

        .progress {
            width: 100%; 
            max-width: 260px; 
            height: 10px; 
            background: #e1e4e8; 
            border-radius: 3px; 
            overflow: hidden;
        }
        .progress-bar {
            display: block; 
            height: 100%; 
            background: linear-gradient(90deg,#ffd33d,#ffd33d 17%,#ddf33d 34%,#ff9501 51%,#ffd33d 68%,#cfea4a 85%,#d5eff2);
            background-size: 300% 100%;
            animation: progress-animation 2s linear infinite;
        }

        @keyframes progress-animation {
            0% {
                background-position: 100% 100%; 
                background-position: 0;
            }
        }
        .btn_icon {
            position:absolute;
            bottom: -5px;
            right: -2px;
          /*  background-color:lightgray;*/
            border-radius:3px;
            height:30px;
            width:30px;
            color:white;
            font-size:16px;
        }

        .bb{
          position:relative;
        }

        .show {
   display: block;
}

    </style>
   
     <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <%--<link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css"/>--%>
    <link href="css/w3_css.css" rel="stylesheet" />


    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
    <link href="css/font_awesome.css" rel="stylesheet" />
  
    <link rel="preconnect" href="https://fonts.googleapis.com"/>
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin/>
    <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@100;300;400;500&display=swap" rel="stylesheet"/>
    <link href="css/roboto_font.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">     
        <div class="w3-top">
            <div class="w3-bar w3-text-white w3-large" style="width:100%; background-color:#166D89;">
                <%--<asp:LinkButton ID="link" class=" w3-bar-item w3-button w3-xlarge w3-hide-large"  runat="server" ><i class="fa fa-bars"></i></asp:LinkButton>--%>
                <div class="w3-bar-item  w3-xlarge "  style="text-shadow:1px 1px 0"; ></div>
                <%--<div class="w3-bar-item w3-xlarge" style="float:right;"><a style="text-decoration:none;" title="Logout" href="Login.aspx"><i class="fa fa-power-off"></i> </a></div>--%>
                <div style="float:right;"  class="w3-dropdown-hover ">
                    <a href="#" onclick="if(document.getElementById('rightMenu').style.display=='none')
                        {
                        document.getElementById('rightMenu').style.display='block';
                        document.getElementById('overlay').style.display='block';
                        document.getElementById('search_btn').style.display='none';
                        }else if(document.getElementById('rightMenu').style.display=='block')
                        {
                        document.getElementById('rightMenu').style.display='none';
                        document.getElementById('overlay').style.display='none';
                        document.getElementById('search_btn').style.display='block';
                        }" class="w3-button  w3-hover-text-black w3-hover-white" style="height:51px; padding-top:12px;"><i  class="fa fa-cog w3-xlarge"></i> <i class="fa fa-caret-down"></i></a>
                      
                    <div id="rightMenu" class="w3-dropdown-content w3-bar-block w3-card-4" style="right:0; display:none; z-index:5;">
                      <a href="MyPatients.aspx" style="text-decoration:none;" class="w3-bar-item w3-button w3-medium">My Patients</a>
                       <a href="ResetPass.aspx" style="text-decoration:none;" class="w3-bar-item w3-button w3-medium">Change Password</a>
                       <a href="Details.aspx" style="text-decoration:none;" class="w3-bar-item w3-button w3-medium">Register New Patient</a>
                       <a href="upload_id.aspx" id="upload_mail" visible="false" runat="server" style="text-decoration:none;" class="w3-bar-item w3-button w3-medium">Upload Email Ids</a>
                       <a href="add_surgeon.aspx" id="surg"  runat="server" style="text-decoration:none;" class="w3-bar-item w3-button w3-medium">Add Surgeon</a>
                       <a href="Login.aspx" style="text-decoration:none;" class="w3-bar-item w3-button w3-medium">Logout</a>
                    </div>
                </div>
                    
                <div class="w3-bar-item  w3-large " style="float:right; padding-top:12px;"><i class="fa fa-user-circle w3-xlarge"></i> <asp:Label ID="l_user" Text="Admin" runat="server" /></div>
            </div>
            <div id="overlay" class="w3-overlay" onclick="document.getElementById('rightMenu').style.display='none';
                document.getElementById('overlay').style.display='none';
                document.getElementById('search_btn').style.display='block';" style="cursor:pointer">
            </div>
        </div>
        <div class="progress">
          <div class="progress-bar" style="width: 75%;"></div>
        </div>

        <div class="w3-container w3-padding-small" style="margin-top:40px;"> 
            <div class="w3-row" >
                
                <div class="w3-col l8 s12 m12 w3-padding-small w3-right">
                    <%--<div class=" w3-round-large w3-padding-large " style="height:contain; min-height:102px; background-color:#d8e3ef;">--%>
                        <div class="w3-row">
                            <div class="w3-col l12 s12  w3-right">
                                <div class="input-box">
                                    <asp:TextBox ID="tb_uhid" placeholder="Search UHID..." AutoPostBack="true" OnTextChanged="search_uhid" AutoCompleteType="Disabled"    CssClass="w3-input w3-round-large w3-padding-large" runat="server" BorderWidth="1px" BorderStyle="Solid" BorderColor="#c5c4c4"  />
                                    <span id="search_btn" class="unit">
                                        <asp:ImageButton OnClick="search_button" CssClass=" w3-hover-grayscale" ImageUrl="Images\home\search1.png" Width="40px" Height="40px" runat="server"></asp:ImageButton>
                                    </span>
                                </div>
                            </div>
                            <br />
                            <div class="w3-col l12 m12 s12 w3-padding-small"><asp:Label ID="alert_label" CssClass="w3-large" Visible="false" Text="Patient is not yet registered" ForeColor="IndianRed" runat="server" /></div>
                            <br />
                            <div class="w3-col l12 m12 s12 w3-padding" id="p_row" runat="server" visible="false" style="height:contain; background-color:#d8e3ef;">
                                <div class=" w3-padding-small">
                                    <div class="w3-row w3-white w3-text-blue-gray " style="width:100%; color:#166D89; padding:10px 10px 10px 10px;">
                                        <div class="w3-col l6 s12">
                                            Patient Name: <asp:Label ID="p_name" runat="server" />
                                        </div>
                                        <div class="w3-col l6 s12">
                                            UHID: <asp:Label ID="p_uhid" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="w3-row">
                                    <div class="w3-col l4 s6 ">
                                        <asp:LinkButton OnClick="edit_click" CssClass="w3-btn  w3-white w3-text-blue-gray w3-round-xxlarge w3-padding" runat="server" >
                                            <i class="fa fa-pencil" style="font-size:18px"></i>&nbsp;Edit Details
                                        </asp:LinkButton>
                                    </div>
                                    <div class="w3-col l4 s6  ">
                                        <asp:LinkButton OnClick="view_click" CssClass="w3-btn w3-right w3-white w3-text-blue-gray w3-padding w3-round-xxlarge" runat="server" >
                                            <i class="fa fa-television" style="font-size:18px"></i>&nbsp;View Dashboard
                                        </asp:LinkButton>
                                    </div>
                                    
                                    <div class="w3-col l4 s12 ">
                                        <br />
                                        <asp:LinkButton OnClick="cancel_click" CssClass="w3-right w3-block w3-btn w3-white w3-text-blue-gray w3-padding w3-round-xxlarge" runat="server" >
                                            Cancel
                                        </asp:LinkButton>
                                    </div>                                                                        
                                </div>
                            </div>
                        </div>
                </div>
                <div class="w3-col l4 s12 m12  ">
                    <div class="w3-row w3-padding-small">
                        <asp:Button ID="btn_details" OnClick="register" ForeColor="#166D89" BackColor="#d8e3ef" Text="Register New Patient" CssClass="w3-btn  w3-round-large w3-padding-large" Width="100%" runat="server" />
                    </div>
                </div>
            </div>
      
        
            <div class="w3-row">
                <div class="w3-col l4 w3-padding-small"></div>
                <div class="w3-col l4 s12 w3-padding-small w3-container w3-center" >

                    <div class="switch">
                      <input name="switch" id="one" type="radio" runat="server" onclick="aiims()" />
                      <label for="one" class="switch__label1 w3-left">Main AIIMS</label>
                    
                      <input name="switch" id="three" runat="server" type="radio" onclick="trauma()" />
                      <label for="three" class="switch__label2 w3-right" >Trauma Center</label>
                      <span class="switch__indicator cc" ></span>

                    </div>
                    <div style="display: none;">
                       <asp:Button runat="server" ID="ww" OnClick="ww_click" />
                    </div>
                  
                    <script type="text/javascript">
                        function trauma() {
                            document.getElementById('<%= ww.ClientID %>').click();
                        }
                        function aiims() {
                            document.getElementById('<%= ww.ClientID %>').click();
                        }
                    </script>
                </div>
                <div class="w3-col l4 w3-padding-small"></div>
            </div>
            <div class="row">
                <div class="w3-right w3-col s12 l4 m12 w3-padding" style="background-color:#F0F0F0;" >
                    <div class="w3-row ">
                        <div class="w3-text-green w3-col l4 s3 m3" id="syncing" runat="server" style="display:none;"><i class="fa fa-refresh fa-spin "></i> Syncing</div>
                        <div class="w3-text-blue-gray w3-col l4 s3 m3" id="sync_now"  runat="server" > 
                            <asp:LinkButton CssClass="lb" OnClientClick="back_click()" OnClick="sync_to_cache" runat="server" > <i class="fa fa-refresh"></i> Sync Now</asp:LinkButton>
                            
                        </div>
                       
                        <div class="w3-text-red w3-col l8 s9 m9" id="last_sync" runat="server" visible="false" style="text-align:right;">Last Synced <asp:Label Text="" ID="sync_date" runat="server" />
                        </div>
                    </div>
                </div>
            </div>

            <div class="w3-row">
                <div class="w3-panel w3-round-large w3-animate-opacity " id="bed_panel" runat="server" visible="true" style="background-color:#eaeaea; width:100%; height:auto; min-height:450px;">
                    <div class="w3-row w3-padding">
                        <div class="w3-col l3 w3-padding-small"></div>
                        
                        <div class="w3-col l4 s12">
                            <asp:RadioButtonList ID="rbl_pt" AutoPostBack="true" OnSelectedIndexChanged="unit_select" CssClass="radio-toolbarr1 w3-padding-small" RepeatLayout="Table" RepeatDirection="Horizontal" runat="server">
                                <asp:ListItem  Text="UNIT 1" Value="unit1" />
                                <asp:ListItem Text="UNIT 2" Value="unit2" />
                            </asp:RadioButtonList>
                        </div>
                        <div class="w3-col l2 s12 w3-padding">
                            <asp:DropDownList ID="ddl_ward" OnSelectedIndexChanged="select_ward" AutoPostBack="true" ForeColor="White" BackColor="#166D89" CssClass="w3-select w3-round-large w3-padding-large" runat="server">
                            </asp:DropDownList>
                        </div>
                        <div class="w3-col l3 w3-padding-small"></div>
                    </div>
                  
                        <div class="w3-row w3-center w3-animate-opacity w3-margin-bottom " style="width:82%; margin:auto;" id="unit1" runat="server" visible="true">
                            <div id="u1b1" visible="false" runat="server" class="w3-padding-small inline" >
                                <asp:LinkButton ID="b1" OnClick="unit1_bed1" ForeColor="White" BackColor="#A9A9A9"  Height="60px" Width="60px" CssClass="bb w3-button w3-xlarge w3-round-xlarge" runat="server" >
                                    <div id="sync1" runat="server" >
                                        1<div class="btn_icon"><i  class="fa fa-refresh"></i></div>
                                    </div>
                                    <div id="syncing1" runat="server" style="display:none;">
                                        1<div class="btn_icon"><i  class="fa fa-refresh fa-spin"></i></div>
                                    </div>
                                    <div id="tick1" runat="server"  visible="false">
                                        1<div class="btn_icon"><i  class="fa fa-check w3-text-lime"></i></div>
                                    </div>
                                 </asp:LinkButton>
                            </div>
                            <div id="u1b2"  visible="false" runat="server" class="w3-padding-small inline">
                                <asp:LinkButton ID="b2" OnClick="unit1_bed2" ForeColor="White" BackColor="#A9A9A9"  Height="60px" Width="60px" CssClass="bb w3-button w3-xlarge w3-round-xlarge" runat="server" >
                                    <div id="sync2" runat="server" >
                                        2<div class="btn_icon"><i  class="fa fa-refresh"></i></div>
                                    </div>
                                    <div id="syncing2" runat="server" style="display:none;">
                                        2<div class="btn_icon"><i  class="fa fa-refresh fa-spin"></i></div>
                                    </div>
                                    <div id="tick2" runat="server" visible="false">
                                        2<div class="btn_icon"><i  class="fa fa-check w3-text-lime"></i></div>
                                    </div>
                                </asp:LinkButton>
                            </div>
                            <div id="u1b3"  visible="false" runat="server" class="w3-padding-small inline" >
                                <asp:LinkButton ID="b3" OnClick="unit1_bed3" ForeColor="White" BackColor="#A9A9A9" Height="60px" Width="60px" CssClass="bb w3-button w3-xlarge w3-round-xlarge" runat="server" >
                                    <div id="sync3" runat="server" visible="true">
                                        3<div class="btn_icon"><i  class="fa fa-refresh"></i></div>
                                    </div>
                                    <div id="syncing3" runat="server" style="display:none;">
                                        3<div class="btn_icon"><i  class="fa fa-refresh fa-spin"></i></div>
                                    </div>
                                    <div id="tick3" runat="server" visible="false">
                                        3<div class="btn_icon"><i  class="fa fa-check w3-text-lime"></i></div>
                                    </div>
                                </asp:LinkButton>
                            </div>
                            <div id="u1b4"  visible="false" runat="server" class="w3-padding-small inline" >
                                 <asp:LinkButton ID="b4" OnClick="unit1_bed4" ForeColor="White" BackColor="#A9A9A9" Height="60px" Width="60px" CssClass="bb w3-button w3-xlarge w3-round-xlarge" runat="server" >
                                     <div id="sync4" runat="server" >
                                        4<div class="btn_icon"><i  class="fa fa-refresh"></i></div>
                                    </div>
                                    <div id="syncing4" runat="server" style="display:none;">
                                        4<div class="btn_icon"><i  class="fa fa-refresh fa-spin"></i></div>
                                    </div>
                                    <div id="tick4" runat="server" visible="false">
                                        4<div class="btn_icon"><i  class="fa fa-check w3-text-lime"></i></div>
                                    </div>
                                </asp:LinkButton>
                            </div>
                            <div id="u1b5"  visible="false" runat="server" class="w3-padding-small inline">
                                <asp:LinkButton ID="b5" OnClick="unit1_bed5" ForeColor="White" BackColor="#A9A9A9" Height="60px" Width="60px" CssClass="bb w3-button w3-xlarge w3-round-xlarge" runat="server" >
                                     <div id="sync5" runat="server">
                                        5<div class="btn_icon"><i  class="fa fa-refresh"></i></div>
                                    </div>
                                    <div id="syncing5" runat="server" style="display:none;">
                                        5<div class="btn_icon"><i  class="fa fa-refresh fa-spin"></i></div>
                                    </div>
                                    <div id="tick5" runat="server" visible="false">
                                        5<div class="btn_icon"><i  class="fa fa-check w3-text-lime"></i></div>
                                    </div>
                                </asp:LinkButton>
                            </div>
                            <div id="u1b6" visible="false" runat="server" class="w3-padding-small inline">
                                <asp:LinkButton ID="b6" OnClick="unit1_bed6" ForeColor="White" BackColor="#A9A9A9" Height="60px" Width="60px" CssClass="bb w3-button w3-xlarge w3-round-xlarge" runat="server" >
                                     <div id="sync6" runat="server" visible="true">
                                        6<div class="btn_icon"><i  class="fa fa-refresh"></i></div>
                                    </div>
                                    <div id="syncing6" runat="server" style="display:none;">
                                        6<div class="btn_icon"><i  class="fa fa-refresh fa-spin"></i></div>
                                    </div>
                                    <div id="tick6" runat="server" visible="false">
                                        6<div class="btn_icon"><i  class="fa fa-check w3-text-lime"></i></div>
                                    </div>
                                </asp:LinkButton>
                            </div>
                            <div id="u1b7" visible="false" runat="server" class="w3-padding-small inline" >
                                <asp:LinkButton ID="b7" OnClick="unit1_bed7" ForeColor="White" BackColor="#A9A9A9" Height="60px" Width="60px" CssClass="bb w3-button w3-xlarge w3-round-xlarge" runat="server" >
                                     <div id="sync7" runat="server" >
                                        7<div class="btn_icon"><i  class="fa fa-refresh"></i></div>
                                    </div>
                                    <div id="syncing7" runat="server" style="display:none;">
                                        7<div class="btn_icon"><i  class="fa fa-refresh fa-spin"></i></div>
                                    </div>
                                    <div id="tick7" runat="server" visible="false">
                                        7<div class="btn_icon"><i  class="fa fa-check w3-text-lime"></i></div>
                                    </div>
                                </asp:LinkButton>
                            </div>
                            <div id="u1b8" visible="false" runat="server" class="w3-padding-small inline">
                                <asp:LinkButton ID="b8" OnClick="unit1_bed8" ForeColor="White" BackColor="#A9A9A9" Height="60px" Width="60px" CssClass="bb w3-button w3-xlarge w3-round-xlarge" runat="server" >
                                     <div id="sync8" runat="server" visible="true">
                                        8<div class="btn_icon"><i  class="fa fa-refresh"></i></div>
                                    </div>
                                    <div id="syncing8" runat="server" style="display:none;">
                                        8<div class="btn_icon"><i  class="fa fa-refresh fa-spin"></i></div>
                                    </div>
                                    <div id="tick8" runat="server" visible="false">
                                        8<div class="btn_icon"><i  class="fa fa-check w3-text-lime"></i></div>
                                    </div>
                                </asp:LinkButton>
                            </div>
                            <div id="u1b9" visible="false" runat="server" class="w3-padding-small inline" >
                                <asp:LinkButton ID="b9" OnClick="unit1_bed9" ForeColor="White" BackColor="#A9A9A9" Height="60px" Width="60px" CssClass="bb w3-button w3-xlarge w3-round-xlarge" runat="server" >
                                     <div id="sync9" runat="server" >
                                        9<div class="btn_icon"><i  class="fa fa-refresh"></i></div>
                                    </div>
                                    <div id="syncing9" runat="server" style="display:none;">
                                        9<div class="btn_icon"><i  class="fa fa-refresh fa-spin"></i></div>
                                    </div>
                                    <div id="tick9" runat="server" visible="false">
                                        9<div class="btn_icon"><i  class="fa fa-check w3-text-lime"></i></div>
                                    </div>
                                </asp:LinkButton>
                            </div> 
                            <div id="u1b10" visible="false" runat="server" class="w3-padding-small inline" >
                                <asp:LinkButton ID="b10" OnClick="unit1_bed10" ForeColor="White" BackColor="#A9A9A9" Height="60px" Width="60px" CssClass="bb w3-button w3-xlarge w3-round-xlarge" runat="server" >
                                     <div id="sync10" runat="server" >
                                        10<div class="btn_icon"><i  class="fa fa-refresh"></i></div>
                                    </div>
                                    <div id="syncing10" runat="server" style="display:none;">
                                        10<div class="btn_icon"><i  class="fa fa-refresh fa-spin"></i></div>
                                    </div>
                                    <div id="tick10" runat="server" visible="false">
                                        10<div class="btn_icon"><i  class="fa fa-check w3-text-lime"></i></div>
                                    </div>
                                </asp:LinkButton>
                            </div>
                            <div id="u1b11" visible="false" runat="server" class="w3-padding-small inline">
                               <asp:LinkButton ID="b11" OnClick="unit1_bed11" ForeColor="White" BackColor="#A9A9A9" Height="60px" Width="60px" CssClass="bb w3-button w3-xlarge w3-round-xlarge" runat="server" >
                                    <div id="sync11" runat="server">
                                        11<div class="btn_icon"><i  class="fa fa-refresh"></i></div>
                                    </div>
                                    <div id="syncing11" runat="server" style="display:none;">
                                        11<div class="btn_icon"><i  class="fa fa-refresh fa-spin"></i></div>
                                    </div>
                                    <div id="tick11" runat="server" visible="false">
                                        11<div class="btn_icon"><i  class="fa fa-check w3-text-lime"></i></div>
                                    </div>
                               </asp:LinkButton>
                            </div>
                            <div id="u1b12" visible="false" runat="server" class="w3-padding-small inline">
                               <asp:LinkButton ID="b12" OnClick="unit1_bed12" ForeColor="White" BackColor="#A9A9A9" Height="60px" Width="60px" CssClass="bb w3-button w3-xlarge w3-round-xlarge" runat="server" >
                                    <div id="sync12" runat="server">
                                        12<div class="btn_icon"><i  class="fa fa-refresh"></i></div>
                                    </div>
                                    <div id="syncing12" runat="server" style="display:none;">
                                        12<div class="btn_icon"><i  class="fa fa-refresh fa-spin"></i></div>
                                    </div>
                                    <div id="tick12" runat="server" visible="false">
                                        12<div class="btn_icon"><i  class="fa fa-check w3-text-lime"></i></div>
                                    </div>
                               </asp:LinkButton>
                            </div>
                            <div id="u1b13" visible="false" runat="server" class="w3-padding-small inline" >
                               <asp:LinkButton ID="b13" OnClick="unit1_bed13" ForeColor="White" BackColor="#A9A9A9" Height="60px" Width="60px" CssClass="bb w3-button w3-xlarge w3-round-xlarge" runat="server" >
                                    <div id="sync13" runat="server">
                                        13<div class="btn_icon"><i  class="fa fa-refresh"></i></div>
                                    </div>
                                    <div id="syncing13" runat="server" style="display:none;">
                                        13<div class="btn_icon"><i  class="fa fa-refresh fa-spin"></i></div>
                                    </div>
                                    <div id="tick13" runat="server" visible="false">
                                        13<div class="btn_icon"><i  class="fa fa-check w3-text-lime"></i></div>
                                    </div>
                               </asp:LinkButton>
                            </div>
                            <div id="u1b14" visible="false" runat="server" class="w3-padding-small inline">
                               <asp:LinkButton ID="b14" OnClick="unit1_bed14" ForeColor="White" BackColor="#A9A9A9" Height="60px" Width="60px" CssClass="bb w3-button w3-xlarge w3-round-xlarge" runat="server" >
                                    <div id="sync14" runat="server">
                                        14<div class="btn_icon"><i  class="fa fa-refresh"></i></div>
                                    </div>
                                    <div id="syncing14" runat="server" style="display:none;">
                                        14<div class="btn_icon"><i  class="fa fa-refresh fa-spin"></i></div>
                                    </div>
                                    <div id="tick14" runat="server" visible="false">
                                        14<div class="btn_icon"><i  class="fa fa-check w3-text-lime"></i></div>
                                    </div>
                               </asp:LinkButton>
                            </div>
                            <div id="u1b15" visible="false" runat="server" class="w3-padding-small inline" >
                               <asp:LinkButton ID="b15" OnClick="unit1_bed15" ForeColor="White" BackColor="#A9A9A9" Height="60px" Width="60px" CssClass="bb w3-button w3-xlarge w3-round-xlarge" runat="server" >
                                    <div id="sync15" runat="server">
                                        15<div class="btn_icon"><i  class="fa fa-refresh"></i></div>
                                    </div>
                                    <div id="syncing15" runat="server" style="display:none;">
                                        15<div class="btn_icon"><i  class="fa fa-refresh fa-spin"></i></div>
                                    </div>
                                    <div id="tick15" runat="server" visible="false">
                                        15<div class="btn_icon"><i  class="fa fa-check w3-text-lime"></i></div>
                                    </div>
                               </asp:LinkButton>
                            </div>
                            <div id="u1b16" visible="false" runat="server" class="w3-padding-small inline" >
                               <asp:LinkButton ID="b16" OnClick="unit1_bed16" ForeColor="White" BackColor="#A9A9A9" Height="60px" Width="60px" CssClass="bb w3-button w3-xlarge w3-round-xlarge" runat="server" >
                                    <div id="sync16" runat="server" >
                                        16<div class="btn_icon"><i  class="fa fa-refresh"></i></div>
                                    </div>
                                    <div id="syncing16" runat="server" style="display:none;">
                                        16<div class="btn_icon"><i  class="fa fa-refresh fa-spin"></i></div>
                                    </div>
                                    <div id="tick16" runat="server" visible="false">
                                        16<div class="btn_icon"><i  class="fa fa-check w3-text-lime"></i></div>
                                    </div>
                               </asp:LinkButton>
                            </div>
                            <div id="u1b17" visible="false" runat="server" class="w3-padding-small inline">
                               <asp:LinkButton ID="b17" OnClick="unit1_bed17" ForeColor="White" BackColor="#A9A9A9" Height="60px" Width="60px" CssClass="bb w3-button w3-xlarge w3-round-xlarge" runat="server" >
                                    <div id="sync17" runat="server" >
                                        17<div class="btn_icon"><i  class="fa fa-refresh"></i></div>
                                    </div>
                                    <div id="syncing17" runat="server" style="display:none;">
                                        17<div class="btn_icon"><i  class="fa fa-refresh fa-spin"></i></div>
                                    </div>
                                    <div id="tick17" runat="server" visible="false">
                                        17<div class="btn_icon"><i  class="fa fa-check w3-text-lime"></i></div>
                                    </div>
                               </asp:LinkButton>
                            </div>
                            <div id="u1b18" visible="false" runat="server" class="w3-padding-small inline">
                              <asp:LinkButton ID="b18" OnClick="unit1_bed18" ForeColor="White" BackColor="#A9A9A9" Height="60px" Width="60px" CssClass="bb w3-button w3-xlarge w3-round-xlarge" runat="server" >
                                    <div id="sync18" runat="server">
                                        18<div class="btn_icon"><i  class="fa fa-refresh"></i></div>
                                    </div>
                                    <div id="syncing18" runat="server" style="display:none;">
                                        18<div class="btn_icon"><i  class="fa fa-refresh fa-spin"></i></div>
                                    </div>
                                    <div id="tick18" runat="server" visible="false">
                                        18<div class="btn_icon"><i  class="fa fa-check w3-text-lime"></i></div>
                                    </div>
                              </asp:LinkButton>
                            </div>
                            <div id="u1b19" visible="false" runat="server" class="w3-padding-small inline" >
                                <asp:LinkButton ID="b19" OnClick="unit1_bed19" ForeColor="White" BackColor="#A9A9A9" Height="60px" Width="60px" CssClass="bb w3-button w3-xlarge w3-round-xlarge" runat="server" >
                                    <div id="sync19" runat="server" >
                                        19<div class="btn_icon"><i  class="fa fa-refresh"></i></div>
                                    </div>
                                    <div id="syncing19" runat="server" style="display:none;">
                                        19<div class="btn_icon"><i  class="fa fa-refresh fa-spin"></i></div>
                                    </div>
                                    <div id="tick19" runat="server" visible="false">
                                        19<div class="btn_icon"><i  class="fa fa-check w3-text-lime"></i></div>
                                    </div>
                                </asp:LinkButton>
                            </div>
                            <div id="u1b20" visible="false" runat="server" class="w3-padding-small inline">
                                 <asp:LinkButton ID="b20" OnClick="unit1_bed20" ForeColor="White" BackColor="#A9A9A9" Height="60px" Width="60px" CssClass="bb w3-button w3-xlarge w3-round-xlarge" runat="server" >
                                      <div id="sync20" runat="server" >
                                        20<div class="btn_icon"><i  class="fa fa-refresh"></i></div>
                                    </div>
                                    <div id="syncing20" runat="server" style="display:none;">
                                        20<div class="btn_icon"><i  class="fa fa-refresh fa-spin"></i></div>
                                    </div>
                                    <div id="tick20" runat="server" visible="false">
                                        20<div class="btn_icon"><i  class="fa fa-check w3-text-lime"></i></div>
                                    </div>
                                 </asp:LinkButton>
                            </div>
                            <div id="u1b21" visible="false" runat="server" class="w3-padding-small inline" >
                                <asp:LinkButton ID="b21" OnClick="unit1_bed21" ForeColor="White" BackColor="#A9A9A9" Height="60px" Width="60px" CssClass="bb w3-button w3-xlarge w3-round-xlarge" runat="server" >
                                     <div id="sync21" runat="server" >
                                        21<div class="btn_icon"><i  class="fa fa-refresh"></i></div>
                                    </div>
                                    <div id="syncing21" runat="server" style="display:none;">
                                        21<div class="btn_icon"><i  class="fa fa-refresh fa-spin"></i></div>
                                    </div>
                                    <div id="tick21" runat="server" visible="false">
                                        21<div class="btn_icon"><i  class="fa fa-check w3-text-lime"></i></div>
                                    </div>
                                </asp:LinkButton>
                            </div>
                            <div id="u1b22" visible="false" runat="server" class="w3-padding-small inline" >
                                 <asp:LinkButton ID="b22" OnClick="unit1_bed22" ForeColor="White" BackColor="#A9A9A9" Height="60px" Width="60px" CssClass="bb w3-button w3-xlarge w3-round-xlarge" runat="server" >
                                     <div id="sync22" runat="server">
                                        22<div class="btn_icon"><i  class="fa fa-refresh"></i></div>
                                    </div>
                                    <div id="syncing22" runat="server" style="display:none;">
                                        22<div class="btn_icon"><i  class="fa fa-refresh fa-spin"></i></div>
                                    </div>
                                    <div id="tick22" runat="server" visible="false">
                                        22<div class="btn_icon"><i  class="fa fa-check w3-text-lime"></i></div>
                                    </div>
                                 </asp:LinkButton>
                            </div>
                            <div id="u1b23" visible="false" runat="server" class="w3-padding-small inline">
                                 <asp:LinkButton ID="b23" OnClick="unit1_bed23" ForeColor="White" BackColor="#A9A9A9" Height="60px" Width="60px" CssClass="bb w3-button w3-xlarge w3-round-xlarge" runat="server" >
                                      <div id="sync23" runat="server" >
                                        23<div class="btn_icon"><i  class="fa fa-refresh"></i></div>
                                    </div>
                                    <div id="syncing23" runat="server" style="display:none;">
                                        23<div class="btn_icon"><i  class="fa fa-refresh fa-spin"></i></div>
                                    </div>
                                    <div id="tick23" runat="server" visible="false">
                                        23<div class="btn_icon"><i  class="fa fa-check w3-text-lime"></i></div>
                                    </div>
                                 </asp:LinkButton>
                            </div>
                            <div id="u1b24" visible="false" runat="server" class="w3-padding-small inline">
                                 <asp:LinkButton ID="b24" OnClick="unit1_bed24" ForeColor="White" BackColor="#A9A9A9" Height="60px" Width="60px" CssClass="bb w3-button w3-xlarge w3-round-xlarge" runat="server" >
                                     <div id="sync24" runat="server" >
                                        24<div class="btn_icon"><i  class="fa fa-refresh"></i></div>
                                    </div>
                                    <div id="syncing24" runat="server" style="display:none;">
                                        24<div class="btn_icon"><i  class="fa fa-refresh fa-spin"></i></div>
                                    </div>
                                    <div id="tick24" runat="server" visible="false">
                                        24<div class="btn_icon"><i  class="fa fa-check w3-text-lime"></i></div>
                                    </div>
                                 </asp:LinkButton>
                            </div>
                            <div id="u1b25" visible="false" runat="server" class="w3-padding-small inline" >
                                 <asp:LinkButton ID="b25" OnClick="unit1_bed25" ForeColor="White" BackColor="#A9A9A9" Height="60px" Width="60px" CssClass="bb w3-button w3-xlarge w3-round-xlarge" runat="server" >
                                      <div id="sync25" runat="server" >
                                        25<div class="btn_icon"><i  class="fa fa-refresh"></i></div>
                                    </div>
                                    <div id="syncing25" runat="server" style="display:none;">
                                        25<div class="btn_icon"><i  class="fa fa-refresh fa-spin"></i></div>
                                    </div>
                                    <div id="tick25" runat="server" visible="false">
                                        25<div class="btn_icon"><i  class="fa fa-check w3-text-lime"></i></div>
                                    </div>
                                 </asp:LinkButton>
                            </div>
                            <div id="u1b26" visible="false" runat="server" class="w3-padding-small inline">
                                 <asp:LinkButton ID="b26" OnClick="unit1_bed26" ForeColor="White" BackColor="#A9A9A9" Height="60px" Width="60px" CssClass="bb w3-button w3-xlarge w3-round-xlarge" runat="server" >
                                      <div id="sync26" runat="server" >
                                        26<div class="btn_icon"><i  class="fa fa-refresh"></i></div>
                                    </div>
                                    <div id="syncing26" runat="server" style="display:none;">
                                        26<div class="btn_icon"><i  class="fa fa-refresh fa-spin"></i></div>
                                    </div>
                                    <div id="tick26" runat="server" visible="false">
                                        26<div class="btn_icon"><i  class="fa fa-check w3-text-lime"></i></div>
                                    </div>
                                 </asp:LinkButton>
                            </div>
                            <div id="u1b27" visible="false" runat="server" class="w3-padding-small inline" >
                               <asp:LinkButton ID="b27" OnClick="unit1_bed27" ForeColor="White" BackColor="#A9A9A9" Height="60px" Width="60px" CssClass="bb w3-button w3-xlarge w3-round-xlarge" runat="server" >
                                    <div id="sync27" runat="server" >
                                        27<div class="btn_icon"><i  class="fa fa-refresh"></i></div>
                                    </div>
                                    <div id="syncing27" runat="server" style="display:none;">
                                        27<div class="btn_icon"><i  class="fa fa-refresh fa-spin"></i></div>
                                    </div>
                                    <div id="tick27" runat="server" visible="false">
                                        27<div class="btn_icon"><i  class="fa fa-check w3-text-lime"></i></div>
                                    </div>
                               </asp:LinkButton>
                            </div>
                            <div id="u1b28" visible="false" runat="server" class="w3-padding-small inline" >
                                <asp:LinkButton ID="b28" OnClick="unit1_bed28" ForeColor="White" BackColor="#A9A9A9" Height="60px" Width="60px" CssClass="bb w3-button w3-xlarge w3-round-xlarge" runat="server" >
                                     <div id="sync28" runat="server" >
                                        28<div class="btn_icon"><i  class="fa fa-refresh"></i></div>
                                    </div>
                                    <div id="syncing28" runat="server" style="display:none;">
                                        28<div class="btn_icon"><i  class="fa fa-refresh fa-spin"></i></div>
                                    </div>
                                    <div id="tick28" runat="server" visible="false">
                                        28<div class="btn_icon"><i  class="fa fa-check w3-text-lime"></i></div>
                                    </div>
                                </asp:LinkButton>
                            </div>
                            <div id="u1b29" visible="false" runat="server" class="w3-padding-small inline">
                                 <asp:LinkButton ID="b29" OnClick="unit1_bed29" ForeColor="White" BackColor="#A9A9A9" Height="60px" Width="60px" CssClass="bb w3-button w3-xlarge w3-round-xlarge" runat="server" >
                                      <div id="sync29" runat="server" >
                                        29<div class="btn_icon"><i  class="fa fa-refresh"></i></div>
                                    </div>
                                    <div id="syncing29" runat="server" style="display:none;">
                                        29<div class="btn_icon"><i  class="fa fa-refresh fa-spin"></i></div>
                                    </div>
                                    <div id="tick29" runat="server" visible="false">
                                        29<div class="btn_icon"><i  class="fa fa-check w3-text-lime"></i></div>
                                    </div>
                                 </asp:LinkButton>
                            </div>
                            <div id="u1b30" visible="false" runat="server" class="w3-padding-small inline">
                                <asp:LinkButton ID="b30" OnClick="unit1_bed30" ForeColor="White" BackColor="#A9A9A9" Height="60px" Width="60px" CssClass="bb w3-button w3-xlarge w3-round-xlarge" runat="server" >
                                     <div id="sync30" runat="server">
                                        30<div class="btn_icon"><i  class="fa fa-refresh"></i></div>
                                    </div>
                                    <div id="syncing30" runat="server" style="display:none;">
                                        30<div class="btn_icon"><i  class="fa fa-refresh fa-spin"></i></div>
                                    </div>
                                    <div id="tick30" runat="server" visible="false">
                                        30<div class="btn_icon"><i  class="fa fa-check w3-text-lime"></i></div>
                                    </div>
                                </asp:LinkButton>
                            </div>
                            <div id="u1b31" visible="false" runat="server" class="w3-padding-small inline">
                                <asp:LinkButton ID="b31" OnClick="unit1_bed31" ForeColor="White" BackColor="#A9A9A9" Height="60px" Width="60px" CssClass="bb w3-button w3-xlarge w3-round-xlarge" runat="server" >
                                     <div id="sync31" runat="server">
                                        31<div class="btn_icon"><i  class="fa fa-refresh"></i></div>
                                    </div>
                                    <div id="syncing31" runat="server" style="display:none;">
                                        31<div class="btn_icon"><i  class="fa fa-refresh fa-spin"></i></div>
                                    </div>
                                    <div id="tick31" runat="server" visible="false">
                                        31<div class="btn_icon"><i  class="fa fa-check w3-text-lime"></i></div>
                                    </div>
                                </asp:LinkButton>
                            </div>
                        </div>
                </div>
            </div>
        
        </div>


         <script>
             var chh;
             function sync1() {
                 var sy1 = document.getElementById("syncing1");
                 sy1.style.display = "block";
                 sy1.style.visibility = "block";
                 var s1 = document.getElementById("sync1");
                 s1.style.visibility = "hidden";
                 s1.style.display = "none";
                 //var t1 = document.getElementById("tick1");
                
                 //t1.style.display = "none";
                 //t1.style.visibility = "hidden";
                 //t1.hidden = true; 
             }
             function sync2() {
                 var sy2 = document.getElementById("syncing2");
                 sy2.style.display = "block";
                 sy2.style.visibility = "block";
                 var s2 = document.getElementById("sync2");
                 s2.style.visibility = "hidden";
                 s2.style.display = "none";
                 //var t2 = document.getElementById("tick2");
                 //t2.style.visibility = "hidden";
                 //t2.style.display = "none";
             }
             function sync3() {
                 var sy3 = document.getElementById("syncing3");
                 sy3.style.display = "block";
                 sy3.style.visibility = "block";
                 var s3 = document.getElementById("sync3");
                 s3.style.visibility = "hidden";
                 s3.style.display = "none";
                 //var t3 = document.getElementById("tick3");
                 //t3.style.visibility = "hidden";
                 //t3.style.display = "none";
             }
             function sync4() {
                 var sy4 = document.getElementById("syncing4");
                 sy4.style.display = "block";
                 sy4.style.visibility = "block";
                 var s4 = document.getElementById("sync4");
                 s4.style.visibility = "hidden";
                 s4.style.display = "none";
                 //var t4 = document.getElementById("tick4");
                 //t4.style.visibility = "hidden";
                 //t4.style.display = "none";
             }
             function sync5() {
                 var sy5 = document.getElementById("syncing5");
                 sy5.style.display = "block";
                 sy5.style.visibility = "block";
                 var s5 = document.getElementById("sync5");
                 s5.style.visibility = "hidden";
                 s5.style.display = "none";
                 //var t5 = document.getElementById("tick5");
                 //t5.style.visibility = "hidden";
                 //t5.style.display = "none";
             }
             function sync6() {
                 var sy6 = document.getElementById("syncing6");
                 sy6.style.display = "block";
                 sy6.style.visibility = "block";
                 var s6 = document.getElementById("sync6");
                 s6.style.visibility = "hidden";
                 s6.style.display = "none";
                 //var t6 = document.getElementById("tick6");
                 //t6.style.visibility = "hidden";
                 //t6.style.display = "none";
             }
             function sync7() {
                 var sy7 = document.getElementById("syncing7");
                 sy7.style.display = "block";
                 sy7.style.visibility = "block";
                 var s7 = document.getElementById("sync7");
                 s7.style.visibility = "hidden";
                 s7.style.display = "none";
                 //var t7 = document.getElementById("tick7");
                 //t7.style.visibility = "hidden";
                 //t7.style.display = "none";
             }
             function sync8() {
                 var sy8 = document.getElementById("syncing8");
                 sy8.style.display = "block";
                 sy8.style.visibility = "block";
                 var s8 = document.getElementById("sync8");
                 s8.style.visibility = "hidden";
                 s8.style.display = "none";
                 //var t8 = document.getElementById("tick8");
                 //t8.style.visibility = "hidden";
                 //t8.style.display = "none";
             }
             function sync9() {
                 var sy9 = document.getElementById("syncing9");
                 sy9.style.display = "block";
                 sy9.style.visibility = "block";
                 var s9 = document.getElementById("sync9");
                 s9.style.visibility = "hidden";
                 s9.style.display = "none";
             }
             function sync10() {
                 var sy10 = document.getElementById("syncing10");
                 sy10.style.display = "block";
                 sy10.style.visibility = "block";
                 var s10 = document.getElementById("sync10");
                 s10.style.visibility = "hidden";
                 s10.style.display = "none";
             }
             function sync11() {
                 var sy11 = document.getElementById("syncing11");
                 sy11.style.display = "block";
                 sy11.style.visibility = "block";
                 var s11 = document.getElementById("sync11");
                 s11.style.visibility = "hidden";
                 s11.style.display = "none";
             }
             function sync12() {
                 var sy12 = document.getElementById("syncing12");
                 sy12.style.display = "block";
                 sy12.style.visibility = "block";
                 var s12 = document.getElementById("sync12");
                 s12.style.visibility = "hidden";
                 s12.style.display = "none";
             }
             function sync13() {
                 var sy13 = document.getElementById("syncing13");
                 sy13.style.display = "block";
                 sy13.style.visibility = "block";
                 var s13 = document.getElementById("sync13");
                 s13.style.visibility = "hidden";
                 s13.style.display = "none";
             }
             function sync14() {
                 var sy14 = document.getElementById("syncing14");
                 sy14.style.display = "block";
                 sy14.style.visibility = "block";
                 var s14 = document.getElementById("sync14");
                 s14.style.visibility = "hidden";
                 s14.style.display = "none";
             }
             function sync15() {
                 var sy15 = document.getElementById("syncing15");
                 sy15.style.display = "block";
                 sy15.style.visibility = "block";
                 var s15 = document.getElementById("sync15");
                 s15.style.visibility = "hidden";
                 s15.style.display = "none";
             }
             function sync16() {
                 var sy16 = document.getElementById("syncing16");
                 sy16.style.display = "block";
                 sy16.style.visibility = "block";
                 var s16 = document.getElementById("sync16");
                 s16.style.visibility = "hidden";
                 s16.style.display = "none";
             }
             function sync17() {
                 var sy17 = document.getElementById("syncing17");
                 sy17.style.display = "block";
                 sy17.style.visibility = "block";
                 var s17 = document.getElementById("sync17");
                 s17.style.visibility = "hidden";
                 s17.style.display = "none";
             }
             function sync18() {
                 var sy18 = document.getElementById("syncing18");
                 sy18.style.display = "block";
                 sy18.style.visibility = "block";
                 var s18 = document.getElementById("sync18");
                 s18.style.visibility = "hidden";
                 s18.style.display = "none";
             }
             function sync19() {
                 var sy19 = document.getElementById("syncing19");
                 sy19.style.display = "block";
                 sy19.style.visibility = "block";
                 var s19 = document.getElementById("sync19");
                 s19.style.visibility = "hidden";
                 s19.style.display = "none";
             }
             function sync20() {
                 var sy20 = document.getElementById("syncing20");
                 sy20.style.display = "block";
                 sy20.style.visibility = "block";
                 var s20 = document.getElementById("sync20");
                 s20.style.visibility = "hidden";
                 s20.style.display = "none";
             }
             function sync21() {
                 var sy21 = document.getElementById("syncing21");
                 sy21.style.display = "block";
                 sy21.style.visibility = "block";
                 var s21 = document.getElementById("sync21");
                 s21.style.visibility = "hidden";
                 s21.style.display = "none";
             }
             function sync22() {
                 var sy22 = document.getElementById("syncing22");
                 sy22.style.display = "block";
                 sy22.style.visibility = "block";
                 var s22 = document.getElementById("sync22");
                 s22.style.visibility = "hidden";
                 s22.style.display = "none";
             }
             function sync23() {
                 var sy23 = document.getElementById("syncing23");
                 sy23.style.display = "block";
                 sy23.style.visibility = "block";
                 var s23 = document.getElementById("sync23");
                 s23.style.visibility = "hidden";
                 s23.style.display = "none";
             }
             function sync24() {
                 var sy24 = document.getElementById("syncing24");
                 sy24.style.display = "block";
                 sy24.style.visibility = "block";
                 var s24 = document.getElementById("sync24");
                 s24.style.visibility = "hidden";
                 s24.style.display = "none";
             }
             function sync25() {
                 var sy25 = document.getElementById("syncing25");
                 sy25.style.display = "block";
                 sy25.style.visibility = "block";
                 var s25 = document.getElementById("sync25");
                 s25.style.visibility = "hidden";
                 s25.style.display = "none";
             }
             function sync26() {
                 var sy26 = document.getElementById("syncing26");
                 sy26.style.display = "block";
                 sy26.style.visibility = "block";
                 var s26 = document.getElementById("sync26");
                 s26.style.visibility = "hidden";
                 s26.style.display = "none";
             }
             function sync27() {
                 var sy27 = document.getElementById("syncing27");
                 sy27.style.display = "block";
                 sy27.style.visibility = "block";
                 var s27 = document.getElementById("sync27");
                 s27.style.visibility = "hidden";
                 s27.style.display = "none";
             }
             function sync28() {
                 var sy28 = document.getElementById("syncing28");
                 sy28.style.display = "block";
                 var s28 = document.getElementById("sync28");
                 s28.style.visibility = "hidden";
                 sy28.style.visibility = "block";
                 s28.style.display = "none";
             }
             function sync29() {
                 var sy29 = document.getElementById("syncing29");
                 sy29.style.display = "block";
                 sy29.style.visibility = "block";
                 var s29 = document.getElementById("sync29");
                 s29.style.visibility = "hidden";
                 s29.style.display = "none";
             }
             function sync30() {
                 var sy30 = document.getElementById("syncing30");
                 sy30.style.display = "block";
                 sy30.style.visibility = "block";
                 var s30 = document.getElementById("sync30");
                 s30.style.visibility = "hidden";
                 s30.style.display = "none";
             }

             function back_click() {
                 var element1 = document.getElementById("sync_now");
                 element1.style.visibility = "hidden";
                 var x = document.getElementById('syncing');
                 x.style.visibility = "block";
                 x.style.display = "block";

                 var bb1 = document.getElementById("u1b1");
                 var bb2 = document.getElementById("u1b2");
                 var bb3 = document.getElementById("u1b3");
                 var bb4 = document.getElementById("u1b4");
                 var bb5 = document.getElementById("u1b5");
                 var bb6 = document.getElementById("u1b6");
                 var bb7 = document.getElementById("u1b7");
                 var bb8 = document.getElementById("u1b8");
                 var bb9 = document.getElementById("u1b9");
                 var bb10 = document.getElementById("u1b10");
                 var bb11 = document.getElementById("u1b11");
                 var bb12 = document.getElementById("u1b12");
                 var bb13 = document.getElementById("u1b13");
                 var bb14 = document.getElementById("u1b14");
                 var bb15 = document.getElementById("u1b15");
                 var bb16 = document.getElementById("u1b16");
                 var bb17 = document.getElementById("u1b17");
                 var bb18 = document.getElementById("u1b18");
                 var bb19 = document.getElementById("u1b19");
                 var bb20 = document.getElementById("u1b20");
                 var bb21 = document.getElementById("u1b21");
                 var bb22 = document.getElementById("u1b22");
                 var bb23 = document.getElementById("u1b23");
                 var bb24 = document.getElementById("u1b24");
                 var bb25 = document.getElementById("u1b25");
                 var bb26 = document.getElementById("u1b26");
                 var bb27 = document.getElementById("u1b27");
                 var bb28 = document.getElementById("u1b28");
                 var bb29 = document.getElementById("u1b29");
                 var bb30 = document.getElementById("u1b30");

                 var ddl = document.getElementById("ddl_ward");
                 var selectedValue = ddl.options[ddl.selectedIndex].value;

                 var radio = document.getElementsByName("rbl_pt");
                  //   var chh;
                     for (var j = 0; j < radio.length; j++) {
                         if (radio[j].checked) {
                              chh = radio[j].value;
                            // alert("'" + chh + "'");
                        }
                     }
                

                 if (selectedValue == "TC3") {

                     //bannerImage = document.getElementById('bannerImg');
                     //imgData = getBase64Image(bannerImage);
                     //localStorage.setItem("imgData", imgData);
 

                        if (chh == "unit1") {
                            sync1();
                            sync2();
                            sync3();
                            sync4();
                            sync5();
                            sync6();

                            sync13();
                            sync14();
                            sync15();
                            sync16();
                        }
                        else if (chh == "unit2") {
                            sync7();
                            sync8();
                            sync9();
                            sync10();
                            sync11();
                            sync12();

                            sync17();
                            sync18();
                            sync19();
                            sync20();
                           
                            }
                        else {
                            sync1();
                            sync2();
                            sync3();
                            sync4();
                            sync5();
                            sync6();

                            sync13();
                            sync14();
                            sync15();
                            sync16();

                            sync7();
                            sync8();
                            sync9();
                            sync10();
                            sync11();
                            sync12();

                            sync17();
                            sync18();
                            sync19();
                            sync20();
                        }
                 }
                 else if (selectedValue == "TC5") {
                     if (chh == "unit1") {
                         sync1();
                         sync2();
                         sync3();
                         sync4();
                         sync5();
                         sync6();
                         sync7();
                         sync8();
                         sync9();

                         sync19();
                         sync20();
                         sync21();

                         sync25();
                         sync26();
                     }
                     else if (chh == "unit2") {
                         sync10();
                         sync11();
                         sync12();
                         sync13();
                         sync14();
                         sync15();
                         sync16();
                         sync17();
                         sync18();

                         sync22();
                         sync23();
                         sync24();

                         sync27();
                         sync28();
                     }
                     else {
                         sync1();
                         sync2();
                         sync3();
                         sync4();
                         sync5();
                         sync6();
                         sync7();
                         sync8();
                         sync9();

                         sync19();
                         sync20();
                         sync21();

                         sync25();
                         sync26();

                         sync10();
                         sync11();
                         sync12();
                         sync13();
                         sync14();
                         sync15();
                         sync16();
                         sync17();
                         sync18();

                         sync22();
                         sync23();
                         sync24();

                         sync27();
                         sync28();
                     }
                 }
                 else if (selectedValue == "ICUB") {
                     if (chh == "unit1") {
                         sync1();
                         sync2();
                         sync3();
                         sync4();
                         sync5();
                         sync6();
                     }
                     else if (chh == "unit2") {
                         sync7();
                         sync8();
                         sync9();
                         sync10();
                         sync11();
                         sync12();
                     }
                     else {
                         sync1();
                         sync2();
                         sync3();
                         sync4();
                         sync5();
                         sync6();

                         sync7();
                         sync8();
                         sync9();
                         sync10();
                         sync11();
                         sync12();
                     }
                 }
                 else if (selectedValue == "ICUC") {
                     if (chh == "unit1") {
                         sync11();
                         sync12();
                         sync13();
                         sync14();
                         sync15();
                         sync16();
                         sync17();
                     }
                     else if (chh == "unit2") {
                         sync7();
                         sync8();
                         sync9();
                         sync10();
                         sync18();
                         sync19();
                     }
                     else {
                         sync11();
                         sync12();
                         sync13();
                         sync14();
                         sync15();
                         sync16();
                         sync17();

                         sync7();
                         sync8();
                         sync9();
                         sync10();
                         sync18();
                         sync19();
                     }
                 }


                 //var t1 = document.getElementById("tick1");
                 //t1.style.visibility = "hidden";
                 //var t2 = document.getElementById("tick2");
                 //t2.style.visibility = "hidden";
                 //var t3 = document.getElementById("tick3");
                 //t3.style.visibility = "hidden";
                 //var t4 = document.getElementById("tick4");
                 //t4.style.visibility = "hidden";
                 //var t5 = document.getElementById("tick5");
                 //t5.style.visibility = "hidden";
                 //var t6 = document.getElementById("tick6");
                 //t6.style.visibility = "hidden";
                 //var t7 = document.getElementById("tick7");
                 //t7.style.visibility = "hidden";
                 //var t8 = document.getElementById("tick8");
                 //t8.style.visibility = "hidden";
                 //var t9 = document.getElementById("tick9");
                 //t9.style.visibility = "hidden";
                 //var t10 = document.getElementById("tick10");
                 //t10.style.visibility = "hidden";
                 //var t11 = document.getElementById("tick11");
                 //t11.style.visibility = "hidden";
                 //var t12 = document.getElementById("tick12");
                 //t12.style.visibility = "hidden";
                 //var t13 = document.getElementById("tick13");
                 //t13.style.visibility = "hidden";
                 //var t14 = document.getElementById("tick14");
                 //t14.style.visibility = "hidden";
                 //var t15 = document.getElementById("tick15");
                 //t15.style.visibility = "hidden";
                 //var t16 = document.getElementById("tick16");
                 //t16.style.visibility = "hidden";
                 //var t17 = document.getElementById("tick17");
                 //t17.style.visibility = "hidden";
                 //var t18 = document.getElementById("tick18");
                 //t18.style.visibility = "hidden";
                 //var t19 = document.getElementById("tick19");
                 //t19.style.visibility = "hidden";
                 //var t20 = document.getElementById("tick20");
                 //t20.style.visibility = "hidden";
                 //var t21 = document.getElementById("tick21");
                 //t21.style.visibility = "hidden";
                 //var t22 = document.getElementById("tick22");
                 //t22.style.visibility = "hidden";
                 //var t23 = document.getElementById("tick23");
                 //t23.style.visibility = "hidden";
                 //var t24 = document.getElementById("tick24");
                 //t24.style.visibility = "hidden";
                 //var t25 = document.getElementById("tick25");
                 //t25.style.visibility = "hidden";
                 //var t26 = document.getElementById("tick26");
                 //t26.style.visibility = "hidden";
                 //var t27 = document.getElementById("tick27");
                 //t27.style.visibility = "hidden";
                 //var t28 = document.getElementById("tick28");
                 //t28.style.visibility = "hidden";
                 //var t29 = document.getElementById("tick29");
                 //t29.style.visibility = "hidden";
                 //var t30 = document.getElementById("tick30");
                 //t30.style.visibility = "hidden";

             }
         </script>

    </form>
</body>
</html>
