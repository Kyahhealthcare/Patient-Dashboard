<%@ Page Title="" Language="C#" MaintainScrollPositionOnPostback="true" MasterPageFile="~/display.Master" AutoEventWireup="true" CodeBehind="plan.aspx.cs" Inherits="TVDisplay.plan" %>
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
      .l{box-shadow: inset 0 0 10px lightgray;}
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
    

       <div class="w3-container">
         <div class="w3-row w3-margin-top w3-padding">
            <div class="w3-col l12 s12 w3-margin-top m6 w3-padding-small w3-right">
                   <div class='input-group date w3-right' id='date1'>
                       <asp:Textbox ID="L_date"  CssClass="w3-large w3-round-large w3-right w3-padding-small" BorderWidth="2px" BorderStyle="Solid" BorderColor="#166D89" ForeColor="#166D89" runat="server" />
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
         </div>
        <div class="w3-row w3-padding">
            <div class="w3-col l12 s12 m12 w3-padding-small">
               <asp:Label CssClass="w3-large" Text="Instructions" ForeColor="#166D89" runat="server" />
               <asp:TextBox ID="tb_other" Height="100px" CssClass="w3-input w3-border w3-round-large" TextMode="MultiLine" runat="server" />
            </div>
        </div>
           <hr />
         <div class="w3-row w3-padding">
            <div class="w3-col l4 s12 m6 w3-padding-small">
                <asp:Label CssClass="w3-large" Text="CT" ForeColor="#166D89" runat="server" />
                <asp:DropDownList ID="ddl_ct" CssClass="w3-select w3-border w3-round-large" runat="server">
                    <asp:ListItem Text="No" />
                    <asp:ListItem Text="Yes" />
                </asp:DropDownList>
            </div>
            <div class="w3-col l8 s12 m6 w3-padding-small">
               <asp:Label CssClass="w3-large" Text="Part" ForeColor="#166D89" runat="server" />
               <asp:TextBox ID="tb_ct_part" CssClass="w3-input w3-border w3-round-large" runat="server" />
            </div>
             <div class="w3-col l12 s12 m12 w3-padding-small">
               <asp:Label CssClass="w3-large" Text="Any Important Findings?" ForeColor="#166D89" runat="server" />
               <asp:TextBox ID="tb_ct_finding" CssClass="w3-input w3-border w3-round-large" runat="server" />
            </div>
         </div>
          <hr />
         <div class="w3-row w3-padding">
            <div class="w3-col l4 s12 m6 w3-padding-small">
               <asp:Label CssClass="w3-large" Text="X-ray" ForeColor="#166D89" runat="server" />
               <asp:DropDownList ID="ddl_xray" CssClass="w3-select w3-border w3-round-large" runat="server">
                   <asp:ListItem Text="No" />
                   <asp:ListItem Text="Yes" />
               </asp:DropDownList>
            </div>
             <div class="w3-col l8 s12 m6 w3-padding-small">
               <asp:Label CssClass="w3-large" Text="Part" ForeColor="#166D89" runat="server" />
               <asp:TextBox ID="tb_xray_part" CssClass="w3-input w3-border w3-round-large" runat="server" />
            </div>
         </div>
          <div class="w3-row w3-padding">
            <div class="w3-col l4 s12 m6 w3-padding-small">
               <asp:Label CssClass="w3-large" Text="MRI" ForeColor="#166D89" runat="server" />
               <asp:DropDownList ID="ddl_mri" CssClass="w3-select w3-border w3-round-large" runat="server">
                   <asp:ListItem Text="No" />
                   <asp:ListItem Text="Yes" />
               </asp:DropDownList>
            </div>
             <div class="w3-col l8 s12 m6 w3-padding-small">
               <asp:Label CssClass="w3-large" Text="Part" ForeColor="#166D89" runat="server" />
               <asp:TextBox ID="tb_mri_part" CssClass="w3-input w3-border w3-round-large" runat="server" />
            </div>
         </div>
          <div class="w3-row w3-padding">
            <div class="w3-col l4 s12 m6 w3-padding-small">
               <asp:Label CssClass="w3-large" Text="Ultrasound" ForeColor="#166D89" runat="server" />
               <asp:DropDownList ID="ddl_usd" CssClass="w3-select w3-border w3-round-large" runat="server">
                   <asp:ListItem Text="No" />
                   <asp:ListItem Text="Yes" />
               </asp:DropDownList>
            </div>
             <div class="w3-col l8 s12 m6 w3-padding-small">
               <asp:Label CssClass="w3-large" Text="Part" ForeColor="#166D89" runat="server" />
               <asp:TextBox ID="tb_usd_part" CssClass="w3-input w3-border w3-round-large" runat="server" />
            </div>
         </div>
       
        
        <div class="w3-row w3-padding-large w3-center">
           <div>
                <asp:Button Text="Save" OnClick="save_plan" CssClass="w3-button w3-padding-large w3-hover-light-blue w3-large w3-round-xxlarge w3-text-white" BackColor="#166D89" runat="server" />
           </div>
        </div>
      </div>
     
                       
</asp:Content>
