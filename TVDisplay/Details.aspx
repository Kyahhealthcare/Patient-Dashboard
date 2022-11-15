<%@ Page Title="" Language="C#" MasterPageFile="~/display.Master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="TVDisplay.Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="UTF-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css"/>
   
    <style type="text/css">
       * {
         padding:0;
         margin:0;
        }
        body {
       /* background-color:#166D89;*/
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

        .dec {
            text-decoration:none;
        }
        .dec:hover {
        text-decoration:none;
        }
        
    </style>
    <link rel="preconnect" href="https://fonts.googleapis.com"/>
<link rel="preconnect" href="https://fonts.gstatic.com" crossorigin/>
<link href="https://fonts.googleapis.com/css2?family=Poppins:wght@200;300;400&display=swap" rel="stylesheet"/>


 <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
<script src="https://cdn.jsdelivr.net/momentjs/2.14.1/moment.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datetimepicker/4.17.37/js/bootstrap-datetimepicker.min.js"></script>
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datetimepicker/4.17.37/css/bootstrap-datetimepicker.min.css">
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <div class="w3-row w3-margin-top w3-padding">
            <div class="w3-col l4 s112 m6 w3-padding-small">
               <asp:Label CssClass="w3-large " Text="UHID" ForeColor="#166D89" runat="server" />
               
                <div class='input-group date' >
                    <asp:TextBox ID="tb_uhid"  TextMode="Number" CssClass="w3-input  w3-border w3-round" runat="server" />
                    <asp:LinkButton OnClick="search_uhid" CssClass="input-group-addon" ForeColor="#166D89" runat="server"><i class="fa fa-search" style="font-size:20px"></i></asp:LinkButton>
                    
                </div>
                <asp:CustomValidator ID="uhid_validate" runat="server" ClientValidationFunction="ValidateUHID" ErrorMessage="Enter valid UHID" ForeColor="Red" ControlToValidate="tb_uhid" EnableClientScript="true"  />   
                <script>     
                    function ValidateUHID(sender, args) {
                        var v = document.getElementById('<%=tb_uhid.ClientID%>').value;
                        if (v.length == 9 ) {
                            args.IsValid = true;
                        }
                        else if (v.length > 9) {
                            if (v.startsWith("201")) {
                                args.IsValid = true;
                            }
                            else {
                                args.IsValid = false;
                            }
                        }
                    }
                </script>
                
                <%--<asp:RangeValidator runat="server" ControlToValidate="tb_uhid" ErrorMessage="Enter valid UHID" Type="Integer" MinimumValue="100000000" MaximumValue="999999999" ForeColor="Red"></asp:RangeValidator>
           <asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" 
        ErrorMessage="RegularExpressionValidator" 
        ValidationExpression="({0,})$" 
        ControlToValidate="wtxtTPP" />--%>
         </div>
    
        </div>                            
        <div class="w3-row w3-padding">
             <div class="w3-col l5 s12 m6 w3-padding-small">
                <asp:Label CssClass="w3-large  " Text="First Name" ForeColor="#166D89" runat="server" />
                <asp:TextBox ID="tb_fname" CssClass="w3-input w3-border w3-round-large" runat="server" />
             </div>
             <div class="w3-col l5 s12 m6 w3-padding-small">
                <asp:Label CssClass="w3-large  " Text="Last Name" ForeColor="#166D89" runat="server" />
                <asp:TextBox ID="tb_lname" CssClass="w3-input w3-border w3-round-large" runat="server" />
             </div>
             <div class="w3-col l2 s12 m6 w3-padding-small">
                <asp:Label CssClass="w3-large  " Text="Sex" ForeColor="#166D89" runat="server" />
                <asp:DropDownList ID="ddl_sex"  CssClass="w3-input w3-border w3-round-large" runat="server">
                    <asp:ListItem Text="Male" Value="M" />
                    <asp:ListItem Text="Female" Value="F" />
                </asp:DropDownList>
             </div>
        </div>
        <div class="w3-row w3-padding">
             <div class="w3-col l3 s12 m6 w3-padding-small">
                <asp:Label CssClass="w3-large " Text="Age" ForeColor="#166D89" runat="server" />
                <asp:TextBox ID="tb_age"  CssClass="w3-input w3-border w3-round-large" runat="server" />
             </div>
             <div class="w3-col l3 s12 m6 w3-padding-small">
                <asp:Label CssClass="w3-large  " Text="Blood Group" ForeColor="#166D89" runat="server" />
                <asp:DropDownList ID="ddl_bld"  CssClass="w3-input w3-border w3-round-large" runat="server">
                    <asp:ListItem Text="Select" Value="" />
                    <asp:ListItem Text="A Positive" Value="A +ve" />
                    <asp:ListItem Text="B Positive" Value="B +ve" />
                    <asp:ListItem Text="AB Positive" Value="AB +ve" />
                    <asp:ListItem Text="O Positive" Value="O +ve" />
                    <asp:ListItem Text="A Negative" Value="A -ve" />
                    <asp:ListItem Text="B Negative" Value="B -ve" />
                    <asp:ListItem Text="AB Negative" Value="AB -ve" />
                    <asp:ListItem Text="O Negative" Value="O -ve" />
                </asp:DropDownList>
            </div>
            <div class="w3-col l3 s12 m6 w3-padding-small">
                <asp:Label CssClass="w3-large  " Text="Blood Donated" ForeColor="#166D89" runat="server" />
                <asp:TextBox ID="tb_bld_d" CssClass="w3-input w3-border w3-round-large" runat="server" />
            </div>
            <div class="w3-col l3 s12 m6 w3-padding-small">
                <asp:Label CssClass="w3-large  " Text="Date of Admission" ForeColor="#166D89" runat="server" />
                <div class='input-group date' id='date2'>
                    <asp:TextBox ID="tb_doa" type='text' class="w3-input w3-border w3-round" runat="server" />
                    <span class="input-group-addon">
                    <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>
            </div>
        </div>
         <div class="w3-row w3-padding">
              <div class="w3-col l6 s12 m3 w3-padding-small">
                <asp:Label CssClass="w3-large  " Text="Consultant" ForeColor="#166D89" runat="server" />
                <asp:DropDownList ID="ddl_faculty"  CssClass="w3-input w3-border w3-round-large" runat="server" >
                </asp:DropDownList>
            </div>

             <div class="w3-col l3 s6 m3 w3-padding-small">
                <asp:Label CssClass="w3-large  " Text="Ward" ForeColor="#166D89" runat="server" />
                <asp:DropDownList ID="ddl_ward"  CssClass="w3-input w3-border w3-round-large" runat="server" >
                </asp:DropDownList>
            </div>
             <div class="w3-col l3 s6 m3 w3-padding-small">
                <asp:Label CssClass="w3-large  " Text="Bed" ForeColor="#166D89" runat="server"/>
                <asp:TextBox TextMode="Number" ID="tb_bed" class="w3-input w3-border w3-round" runat="server" />
            </div>
         </div>
        <div class="w3-row w3-padding-large">
            <asp:Label CssClass="w3-large " Text="Diagnosis" ForeColor="#166D89" runat="server" />
            <div>
                <table class="w3-table" style="width:100%;">
                    <tr>
                        <td style="width:1px; color:#166D89;">1.</td>
                        <td><asp:TextBox ID="tb_diag1" CssClass="w3-input w3-border w3-round-large" TextMode="MultiLine" runat="server" /></td>
                    </tr>
                    <tr>
                        <td style="width:1px; color:#166D89;">2.</td>
                        <td><asp:TextBox ID="tb_diag2" CssClass="w3-input w3-border w3-round-large" TextMode="MultiLine" runat="server" /></td>
                    </tr>
                    <tr>
                        <td style="width:1px; color:#166D89;">3.</td>
                        <td><asp:TextBox ID="tb_diag3" CssClass="w3-input w3-border w3-round-large" TextMode="MultiLine" runat="server" /></td>
                    </tr>
                </table>
            </div>
                
          
        </div>
    <script>
        $(function () {
            $('#date1').datetimepicker({
                format: 'DD-MM-YYYY'
            });
            $('#date1').datetimepicker().on('dp.change', function (event) {
                __doPostBack('<%= Page.ClientID %>');
            });

            $('#date2').datetimepicker({
                format: 'DD-MM-YYYY',
                defaultDate: moment(),
                sideBySide: true
            });


        });
    </script>
        <div class="w3-row w3-padding-large w3-center w3-margin-bottom">
            <div>
              <asp:Button Text="Save" OnClick="save_form" CssClass="w3-button w3-padding-large w3-hover-light-blue w3-large w3-round-xxlarge w3-text-white" BackColor="#166D89" runat="server" />
            </div>
        </div>

         
   
</asp:Content>
