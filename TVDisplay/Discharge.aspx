<%@ Page Title="" Language="C#" MasterPageFile="~/display.Master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="Discharge.aspx.cs" Inherits="TVDisplay.Discharge" %>
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
            <div class="w3-col l6 s12 m12 w3-padding-small">
               <asp:Label CssClass="w3-large " Text="Status" ForeColor="#166D89" runat="server" />
                <asp:DropDownList ID="ddl_status" CssClass="w3-input w3-border w3-round-large" runat="server">
                    <asp:ListItem Text="Discharge" Value="Discharge" />
                    <asp:ListItem Text="Transferred" Value="Transferred" />
                    <asp:ListItem Text="LAMA" Value="LAMA" />
                    <asp:ListItem Text="Death" Value="Death" />
                </asp:DropDownList>
            </div>
        </div>
        <div class="w3-row w3-padding">
            <div class="w3-col l4 s6 m6 w3-padding-small">
               <asp:Label CssClass="w3-large " Text="Date" ForeColor="#166D89" runat="server" />
               <div class='input-group date' id='date1'>
                    <asp:TextBox ID="tb_date" type='text' class="w3-input w3-border w3-round" runat="server" />
                    <span class="input-group-addon">
                    <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>
            </div>
            <div class="w3-col l4 s6 m6 w3-padding-small">
               <asp:Label CssClass="w3-large " Text="Time" ForeColor="#166D89" runat="server" />
               <div class='input-group date' id='time1'>
                    <asp:TextBox ID="tb_time" type='text' class="w3-input w3-border w3-round" runat="server" />
                    <span class="input-group-addon">
                    <span class="glyphicon glyphicon-time"></span>
                    </span>
               </div>
            </div>
        </div>
        <div class="w3-row w3-padding-large w3-center w3-margin-bottom">
            <div>
              <asp:Button Text="Save" OnClick="save_status" CssClass="w3-button w3-padding-large  w3-hover-light-blue w3-large w3-round-xxlarge w3-text-white" BackColor="#166D89" runat="server" />
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
                
            });
        </script>
        

</asp:Content>
