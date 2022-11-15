<%@ Page Title="" Language="C#" MasterPageFile="~/display.Master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="Infusions.aspx.cs" Inherits="TVDisplay.Infusions" %>
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

   
        <div class="w3-row w3-border-bottom w3-border-light-gray w3-margin-top w3-padding">
                    <div class="w3-col l3 s12 m4 w3-padding-small">
                        <div class="w3-hide-small" style="margin-top:26px;">
                        </div>
                        <asp:DropDownList ID="ddl_infusion1" CssClass="w3-input w3-border w3-round-large w3-padding" runat="server">
                            <asp:ListItem Text="SELECT" Value="" />
                            <asp:ListItem Text="NORAD" Value="NORAD" />
                            <asp:ListItem Text="DOPAMINE" Value="DOPAMINE" />
                            <asp:ListItem Text="NIMODIPINE" Value="NIMODIPINE" />
                            <asp:ListItem Text="INSULIN" Value="INSULIN" />
                            <asp:ListItem Text="MIDAZOLAM" Value="MIDAZOLAM" />
                            <asp:ListItem Text="KETAMINE" Value="KETAMINE" />
                            <asp:ListItem Text="DEXMED" Value="DEXMED" />
                            <asp:ListItem Text="FENTANYL" Value="FENTANYL" />
                            <asp:ListItem Text="VASSOPRESIN" Value="VASSOPRESIN" />
                            <asp:ListItem Text="PROPOFOL" Value="PROPOFOL" />
                            <asp:ListItem Text="3% NACL" Value="3% NACL" />
                            <asp:ListItem Text="ADRENALINE" Value="ADRENALINE" />
                            <asp:ListItem Text="KCL" Value="KCL" />
                            <asp:ListItem Text="LOBETOLOL" Value="LOBETOLOL" />
                        </asp:DropDownList>
                    </div>
                    <div class="w3-col l3 s12 m4 w3-padding-small">
                        <asp:Label Text="Quantity" CssClass="w3-large  " ForeColor="#166D89" runat="server" />
                        <div class="input-box">
                            <asp:TextBox ID="tb_quan1" CssClass="w3-input w3-border w3-round-large w3-padding" runat="server" />
                            <span class="unit">ml/hr</span>
                        </div>
                    </div>
                    <div class="w3-col l3 s6 m4 w3-padding-small">
                        <asp:Label Text="Date" CssClass="w3-large  " ForeColor="#166D89" runat="server" />
                        <div class='input-group date' id='date1'>
                            <asp:TextBox ID="tb_date1" type='text' class="w3-input w3-border w3-round" runat="server" />
                            <span class="input-group-addon">
                            <span class="glyphicon glyphicon-calendar"></span>
                            </span>
                        </div>
                    </div>
                    <div class="w3-col l3 s6 m4 w3-padding-small">
                        <asp:Label Text="Time" CssClass="w3-large  " ForeColor="#166D89" runat="server" />
                        <div class='input-group date' id='time1'>
                            <asp:TextBox ID="tb_time1" type='text' class="w3-input w3-border w3-round" runat="server" />
                            <span class="input-group-addon">
                            <span class="glyphicon glyphicon-time"></span>
                            </span>
                        </div>
                    </div>
                </div>
                <div class="w3-row w3-border-bottom w3-border-light-gray w3-margin-top w3-padding" >
                    <div class="w3-col l3 s12 m4 w3-padding-small">
                        <div class="w3-hide-small " style="margin-top:26px;">
                        </div>
                        <asp:DropDownList ID="ddl_infusion2" CssClass="w3-input w3-border w3-round-large w3-padding" runat="server">
                            <asp:ListItem Text="SELECT" Value="" />
                            <asp:ListItem Text="NORAD" Value="NORAD" />
                            <asp:ListItem Text="DOPAMINE" Value="DOPAMINE" />
                            <asp:ListItem Text="NIMODIPINE" Value="NIMODIPINE" />
                            <asp:ListItem Text="INSULIN" Value="INSULIN" />
                            <asp:ListItem Text="MIDAZOLAM" Value="MIDAZOLAM" />
                            <asp:ListItem Text="KETAMINE" Value="KETAMINE" />
                            <asp:ListItem Text="DEXMED" Value="DEXMED" />
                            <asp:ListItem Text="FENTANYL" Value="FENTANYL" />
                            <asp:ListItem Text="VASSOPRESIN" Value="VASSOPRESIN" />
                            <asp:ListItem Text="PROPOFOL" Value="PROPOFOL" />
                            <asp:ListItem Text="3% NACL" Value="3% NACL" />
                            <asp:ListItem Text="ADRENALINE" Value="ADRENALINE" />
                            <asp:ListItem Text="KCL" Value="KCL" />
                            <asp:ListItem Text="LOBETOLOL" Value="LOBETOLOL" />
                        </asp:DropDownList>
                    </div>
                    <div class="w3-col l3 s12 m4 w3-padding-small">
                        <asp:Label Text="Quantity" CssClass="w3-large  " ForeColor="#166D89" runat="server" />
                        <div class="input-box">
                            <asp:TextBox ID="tb_quan2" CssClass="w3-input w3-border w3-round-large w3-padding" runat="server" />
                            <span class="unit">ml/hr</span>
                        </div>
                    </div>
                    <div class="w3-col l3 s6 m4 w3-padding-small">
                        <asp:Label Text="Date" CssClass="w3-large  " ForeColor="#166D89" runat="server" />
                        <div class='input-group date' id='date2'>
                            <asp:TextBox ID="tb_date2" type='text' class="w3-input w3-border w3-round" runat="server" />
                            <span class="input-group-addon">
                            <span class="glyphicon glyphicon-calendar"></span>
                            </span>
                        </div>
                    </div>
                    <div class="w3-col l3 s6 m4 w3-padding-small">
                        <asp:Label Text="Time" CssClass="w3-large  " ForeColor="#166D89" runat="server" />
                        <div class='input-group date' id='time2'>
                            <asp:TextBox ID="tb_time2" type='text' class="w3-input w3-border w3-round" runat="server" />
                            <span class="input-group-addon">
                            <span class="glyphicon glyphicon-time"></span>
                            </span>
                        </div>
                    </div>
                </div>
                <div class="w3-row w3-border-bottom w3-border-light-gray w3-margin-top w3-padding">
                    <div class="w3-col l3 s12 m4 w3-padding-small">
                        <div class="w3-hide-small w3-hide-medium" style="margin-top:23px;">
                        </div>
                        <asp:DropDownList ID="ddl_infusion3" CssClass="w3-input w3-border w3-round-large w3-padding" runat="server">
                            <asp:ListItem Text="SELECT" Value="" />
                            <asp:ListItem Text="NORAD" Value="NORAD" />
                            <asp:ListItem Text="DOPAMINE" Value="DOPAMINE" />
                            <asp:ListItem Text="NIMODIPINE" Value="NIMODIPINE" />
                            <asp:ListItem Text="INSULIN" Value="INSULIN" />
                            <asp:ListItem Text="MIDAZOLAM" Value="MIDAZOLAM" />
                            <asp:ListItem Text="KETAMINE" Value="KETAMINE" />
                            <asp:ListItem Text="DEXMED" Value="DEXMED" />
                            <asp:ListItem Text="FENTANYL" Value="FENTANYL" />
                            <asp:ListItem Text="VASSOPRESIN" Value="VASSOPRESIN" />
                            <asp:ListItem Text="PROPOFOL" Value="PROPOFOL" />
                            <asp:ListItem Text="3% NACL" Value="3% NACL" />
                            <asp:ListItem Text="ADRENALINE" Value="ADRENALINE" />
                            <asp:ListItem Text="KCL" Value="KCL" />
                            <asp:ListItem Text="LOBETOLOL" Value="LOBETOLOL" />
                        </asp:DropDownList>
                    </div>
                    <div class="w3-col l3 s12 m4 w3-padding-small">
                        <asp:Label Text="Quantity" CssClass="w3-large  " ForeColor="#166D89" runat="server" />
                        <div class="input-box">
                            <asp:TextBox ID="tb_quan3" CssClass="w3-input w3-border w3-round-large w3-padding" runat="server" />
                            <span class="unit">ml/hr</span>
                        </div>
                    </div>
                    <div class="w3-col l3 s6 m4 w3-padding-small">
                        <asp:Label Text="Date" CssClass="w3-large  " ForeColor="#166D89" runat="server" />
                        <div class='input-group date' id='date3'>
                            <asp:TextBox ID="tb_date3" type='text' class="w3-input w3-border w3-round" runat="server" />
                            <span class="input-group-addon">
                            <span class="glyphicon glyphicon-calendar"></span>
                            </span>
                        </div>
                    </div>
                    <div class="w3-col l3 s6 m4 w3-padding-small">
                        <asp:Label Text="Time" CssClass="w3-large  " ForeColor="#166D89" runat="server" />
                        <div class='input-group date' id='time3'>
                            <asp:TextBox ID="tb_time3" type='text' class="w3-input w3-border w3-round" runat="server" />
                            <span class="input-group-addon">
                            <span class="glyphicon glyphicon-time"></span>
                            </span>
                        </div>
                    </div>
                </div> 
            <div class="w3-row w3-padding-large w3-center w3-margin-bottom">
                <div>
                  <asp:Button Text="Save" OnClick="save_infusion" CssClass="w3-button w3-padding-large  w3-hover-light-blue w3-large w3-round-xxlarge w3-text-white" BackColor="#166D89" runat="server" />
                </div>
            </div>
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
                $('#date2').datetimepicker({
                    format: 'DD-MM-YYYY',
                    defaultDate: moment(),
                    sideBySide: true

                });

                $('#time2').datetimepicker({
                    format: 'LT',
                    defaultDate: moment(),
                    sideBySide: true
                });
                $('#date3').datetimepicker({
                    format: 'DD-MM-YYYY',
                    defaultDate: moment(),
                    sideBySide: true

                });

                $('#time3').datetimepicker({
                    format: 'LT',
                    defaultDate: moment(),
                    sideBySide: true
                });
                
            });
        </script>
        
  

</asp:Content>
