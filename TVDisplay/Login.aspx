<%@ Page Language="C#" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="Login.aspx.cs" Inherits="TVDisplay.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="UTF-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css"/>
     <link href="css/w3_css.css" rel="stylesheet" />
   
    <style type="text/css">
        @media (prefers-color-scheme: dark) {
        }

            * {
                padding: 0;
                margin: 0;
            }

            body {
                padding: 20px;
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
    </style>
  <%--  <script>
        /* Storing user's device details in a variable*/
        let details = navigator.userAgent;
  
        /* Creating a regular expression 
        containing some mobile devices keywords 
        to search it in details string*/
        let regexp = /android|iphone|kindle|ipad/i;
  
        /* Using test() method to search regexp in details
        it returns boolean value*/
        let isMobileDevice = regexp.test(details);
  
        if (isMobileDevice) {
            document.write("You are using a Mobile Device");
        } else {
            document.write("You are using Desktop");
        }
        
    </script>--%>

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
                            <div class="w3-margin-bottom w3-margin-top w3-center" >
                                <img src="Images/logimg.png" width="100%"/>
                            </div>
                            <div class="w3-row w3-padding w3-margin-top w3-center">
                                <div class="w3-text" style="color:#166D89; font-size:30px;">Patient Dashboard</div>
                            </div>
                            <div class="w3-row w3-padding">
                               <asp:TextBox ID="tb_username"  AutoCompleteType="Disabled" placeholder="Username" CssClass="w3-input w3-round-large  w3-padding-large" runat="server" BorderStyle="Solid" BorderWidth="1px" BorderColor="#166D89" />
                            </div>
                            <div class="w3-row w3-padding">
                               <asp:TextBox ID="tb_password" placeholder="Password" TextMode="Password" CssClass="w3-input w3-round-large w3-padding-large" runat="server" BorderWidth="1px" BorderStyle="Solid" BorderColor="#166D89"  />
                            </div>
                            <div class="w3-row w3-padding w3-margin-bottom">
                                <asp:Button Text="Log In" OnClick="submit_click" CssClass="w3-btn w3-text-white w3-large w3-padding w3-round-large" BackColor="#166D89" Width="100%" runat="server" />
                            </div>
                            <br />
                            <br />
                            <div class="w3-center">
                                <asp:Label ID="lblMsg" Visible="false" Text="Wrong id or password entered!!" CssClass=" w3-text-white w3-padding-small w3-red w3-large" runat="server"></asp:Label>
                            </div>
                            <div>
                               <asp:RequiredFieldValidator  ValidationGroup="login_submit" CssClass="w3-xlarge"  ControlToValidate="tb_username" ID="RequiredFieldValidator87" runat="server" ErrorMessage="Enter Username!!" Display="Dynamic" SetFocusOnError="True" Font-Names="Aparajita" ForeColor="Red"></asp:RequiredFieldValidator>
                               <asp:RequiredFieldValidator  ValidationGroup="login_submit"  CssClass="w3-xlarge"  ControlToValidate="tb_password" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Password!!" Display="Dynamic" SetFocusOnError="True" Font-Names="Aparajita" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                            <div class=" w3-container w3-margin-bottom">
                                <div class="w3-row w3-padding w3-center">
                                    <asp:Label Text="Not Registered yet? " ForeColor="#166D89" runat="server" /> <asp:Button OnClick="goto_register" CssClass="w3-btn w3-round-xlarge w3-border w3-border-blue-grey w3-text-blue-gray" Text="Register Here..." runat="server"></asp:Button>
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
