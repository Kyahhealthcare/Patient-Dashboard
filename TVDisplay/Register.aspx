<%@ Page Language="C#" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="TVDisplay.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="UTF-8"/>

    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <%--<link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css"/>--%>
    <link href="css/w3_css.css" rel="stylesheet" />


    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
    <link href="css/font_awesome.css" rel="stylesheet" />
   
    <style type="text/css">
       * {
         padding:0;
         margin:0;
        }
        body {
         padding:20px;
        }

        @media (min-width: 1200px) {

            .bgimg {
                background: url(Images/jhol.jpg);
                background-size: cover;
                background-repeat:no-repeat;
            }
            .ct{
                box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
            }
            .pp{
                padding:80px 0px;
            }
        }
/*Hide in Other Small Devices */


        /* Landscape tablets and medium desktops */
        @media (min-width: 992px) and (max-width: 1199px) {

            .bgimg {
                background-image: url(Images/jhol.jpg);
                background-size: cover;
                background-repeat:no-repeat;
            }
             .ct{
                box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
            }
             .pp{
                 padding:80px 0px;
             }

        }

        /* Portrait tablets and small desktops */
        @media (min-width: 768px) and (max-width: 991px) {

            .bgimg {
                /*background-image: none;
                background-color:#cdebf6;*/
                background-image: url(Images/jhol.jpg);
                background-size: cover;
                background-repeat:no-repeat;
            }
            .ct{
                box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
            }
            .pp{
                padding:70px 0px;
            }


        }

        /* Landscape phones and portrait tablets */
        @media (max-width: 767px) {

            .bgimg {
                /*background-image: none;

                background-color:#cdebf6;*/
                background-image: url(Images/jhol.jpg);
                background-size: cover;
                background-repeat:no-repeat;
            }
            .ct{
               box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
            }
            .pp{
                padding:10px 0px;
            }

        }

        /* Portrait phones and smaller */
        @media (max-width: 480px) {

            .bgimg {
                /*background-image: none;
                background-color:#cdebf6;*/
                background-image: url(Images/jhol.jpg);
                background-size: cover;
                background-repeat:no-repeat;
            }
            .ct{
                box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
            }
            .pp{
                padding:10px 0px;
            }
        }

        .loader {
          display: none;
          top: 50%;
          left: 50%;
          position: absolute;
          transform: translate(-50%, -50%);
        }

        .loading {
          border: 5px solid #ccc;
          width: 40px;
          height: 40px;
          border-radius: 50%;
          border-top-color: green;
          border-left-color: green;
          animation: spin 1s infinite ease-in;
        }

        @keyframes spin {
            0% {
                transform: rotate(0deg);
            }

            100% {
                transform: rotate(360deg);
            }
        }

    </style>
 
</head>
<body class="bgimg">
    <form id="form1"  runat="server">
         
        <div class="w3-container " style="height:100vh;">

         
            <div class="w3-row pp" style="">
                <div class="w3-col l4 m2 w3-small-hide">
                    <div class="w3-panel"></div>
                </div>
                <div class="w3-col l4 m8  s12 w3-margin-top">
                     <div class="w3-container w3-cell-row w3-padding  w3-round-large w3-margin-top ct" style="height:75vh; background-color:#fff;">
                        <div class="w3-cell w3-cell-middle w3-margin-bottom">
                            <div class="w3-row w3-padding w3-margin-top w3-center">
                                <div class="w3-text" style="color:#166D89; font-size:30px;">Patient Dashboard</div>
                            </div>
                          

                            <div class="w3-row w3-padding-small">
                                <div class="w3-col l4 s4 m8 w3-padding-small">
                                    <asp:DropDownList ID="ddl_sal" ValidationGroup="login_submit" Height="48px" ForeColor="Black" CssClass="w3-input w3-round-large w3-padding" runat="server" BorderWidth="1px" BorderStyle="Solid" BorderColor="#166D89" >
                                         <asp:ListItem Text="Dr." Value="dr" />
                                         <asp:ListItem Text="Mr." Value="mr" />
                                         <asp:ListItem Text="Miss." Value="ms" />
                                         <asp:ListItem Text="Mrs." Value="mrs" />
                                    </asp:DropDownList>
                                </div>
                                <div class="w3-col l8 s8 m8 w3-padding-small">
                                    <asp:TextBox ID="tb_fname" ValidationGroup="login_submit" AutoCompleteType="Disabled" placeholder="First Name" CssClass="w3-input w3-round-large  w3-padding-large" runat="server" BorderStyle="Solid" BorderWidth="1px" BorderColor="#166D89" />
                                </div>
                               
                            </div>
                            <div class="w3-row w3-padding">
                                <asp:TextBox ID="tb_lname" AutoCompleteType="Disabled" placeholder="Last Name" CssClass="w3-input w3-round-large  w3-padding-large" runat="server" BorderStyle="Solid" BorderWidth="1px" BorderColor="#166D89" />
                            </div>
                            <div class="w3-row w3-padding">
                               <asp:TextBox ID="tb_username" ValidationGroup="login_submit" AutoCompleteType="Disabled"  placeholder="Username" CssClass="w3-input w3-round-large  w3-padding-large" runat="server" BorderStyle="Solid" BorderWidth="1px" BorderColor="#166D89" />
                            </div>
                            <div class="w3-row w3-padding">
                                <asp:DropDownList ID="ddl_designation" ValidationGroup="login_submit" CssClass="w3-input w3-round-large  w3-padding-large" runat="server" BorderStyle="Solid" BorderWidth="1px" BorderColor="#166D89">
                                    <asp:ListItem Text="Choose Desgination" Value="" />
                                    <asp:ListItem Text="Faculty" Value="faculty" />
                                    <asp:ListItem Text="Doctor" Value="doc" />
                                    <asp:ListItem Text="Residents" Value="resident" />
                                    <asp:ListItem Text="Nursing Officer" Value="nurse" />
                                </asp:DropDownList>
                            </div>
                            
                            <div class="w3-row w3-padding">
                               <asp:TextBox ID="tb_mail" ValidationGroup="login_submit" AutoCompleteType="Disabled" placeholder="Email ID" CssClass="w3-input w3-round-large  w3-padding-large" runat="server" BorderStyle="Solid" BorderWidth="1px" BorderColor="#166D89" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tb_mail"
    ForeColor="Red" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
    Display = "Dynamic" ErrorMessage = "Invalid email address"/>
                            </div>
                            <div class="w3-row w3-padding">
                               <asp:TextBox ID="tb_mob" AutoCompleteType="Disabled" placeholder="Mobile No." CssClass="w3-input w3-round-large  w3-padding-large" runat="server" BorderStyle="Solid" BorderWidth="1px" BorderColor="#166D89" />
                            </div>                            
                            
                            <div class="w3-row w3-padding w3-margin-bottom">
                                <asp:Button Text="Register" OnClientClick="spinner()" OnClick="submit_click" ValidationGroup="login_submit" CssClass="w3-btn w3-text-white w3-large w3-padding w3-round-large" BackColor="#166D89" Width="100%" runat="server" />
                                <div class="loader">
                                  <div class="loading">
                                  </div>
                                </div>


                                <script type="text/javascript">
                                    window.onload = function () { document.getElementById("loading").style.display = "none" }
                                    function spinner() {
                                        document.getElementsByClassName("loader")[0].style.display = "block";
                                    }
                                </script>    
                            </div>
                            <br />
                            
                            <div class="w3-center">
                                <asp:Label ID="lblMsg" Visible="false" Text="" CssClass=" w3-text-white w3-padding-small  w3-large" runat="server"></asp:Label>

                            </div> 
                            <div class="w3-center">
                               <asp:RequiredFieldValidator ValidationGroup="login_submit"   ControlToValidate="tb_username" ID="RequiredFieldValidator87" runat="server" ErrorMessage="Username can't ne empty" Display="Dynamic" SetFocusOnError="True"  ForeColor="white" BackColor="Red"></asp:RequiredFieldValidator>
                                
                                <asp:RequiredFieldValidator  ValidationGroup="login_submit"  ControlToValidate="ddl_sal" ID="RequiredFieldValidator1" runat="server" ErrorMessage="" Display="Dynamic" SetFocusOnError="True"  ForeColor="white" BackColor="Red"></asp:RequiredFieldValidator>
                                
                                <asp:RequiredFieldValidator  ValidationGroup="login_submit"  ControlToValidate="tb_fname" ID="RequiredFieldValidator2" runat="server" ErrorMessage="<br />First Name can't be empty" Display="Dynamic" SetFocusOnError="True" ForeColor="white" BackColor="Red"></asp:RequiredFieldValidator>
                               <asp:RequiredFieldValidator  ValidationGroup="login_submit"  ControlToValidate="ddl_designation" ID="RequiredFieldValidator3" runat="server" ErrorMessage="<br />Select Designation" Display="Dynamic" SetFocusOnError="True" ForeColor="white" BackColor="Red"></asp:RequiredFieldValidator>
                               <asp:RequiredFieldValidator  ValidationGroup="login_submit"  ControlToValidate="tb_mail" ID="RequiredFieldValidator4" runat="server" ErrorMessage="<br />Email id can't be empty" Display="Dynamic" SetFocusOnError="True" ForeColor="white" BackColor="Red"></asp:RequiredFieldValidator>
                           
                            </div>
                            <div class=" w3-container w3-margin-bottom">
                                <div class="w3-row w3-padding w3-center">
                                    <asp:Label Text="Already Registered? " ForeColor="#166D89" runat="server" /> <asp:Button OnClick="goto_login" CssClass="w3-btn w3-round-xlarge w3-border w3-border-blue-grey w3-text-blue-gray" Text="Login" runat="server"></asp:Button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="w3-col l4 m2"></div>
               
            </div>
        </div>
        <%--<div class="w3-display-bottomleft w3-padding-large">
            Powered by <a href="https://www.w3schools.com/w3css/default.asp" target="_blank">w3.css</a>
          </div>
        --%>
    </form>
</body>
</html>
