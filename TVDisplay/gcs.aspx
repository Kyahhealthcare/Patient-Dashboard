<%@ Page Title="" Language="C#" MasterPageFile="~/display.Master" AutoEventWireup="true" CodeBehind="gcs.aspx.cs" Inherits="TVDisplay.gcs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .radio-toolbar {
          margin: 2px;
        }

        .radio-toolbar input[type="radio"] {
          opacity: 0;
          position: fixed;
          width: 0; 
        }

        .radio-toolbar label {
            display: inline-block;
            background-color: white;
            padding: 4px 11px;
            font-family: sans-serif, Arial;
            font-size: 16px;
            border: 2px solid #444;
            border-radius: 30px;
            margin-right:10px;
        }

        .radio-toolbar label:hover {
          background-color: #79B4B7;
        }

        .radio-toolbar input[type="radio"]:focus + label {
            border: 2px solid black;
        }

        .radio-toolbar input[type="radio"]:checked + label {
            background-color:#E8F0F2;
            border-color:#79B4B7;
        }
        .input-box { 
          position: relative; 
        }

        input { 
          display: block; 
          border: 1px solid #d7d6d6; 
          background: #fff; 
          padding: 10px 10px 10px 20px; 
          width: 195px; 
        }

         .BigCheckBox input 
          {
              float: right;  
             width:25px; 
             height:25px;
             border:solid;
             border-color:black;
             
             padding:5px;
              
             
          }
        .BigCheckBox label {
           width: auto;      
           display: inline;      
           float: right;
           
        }
    </style>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css" />

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script src="https://cdn.jsdelivr.net/momentjs/2.14.1/moment.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datetimepicker/4.17.37/js/bootstrap-datetimepicker.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datetimepicker/4.17.37/css/bootstrap-datetimepicker.min.css"/>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <div class="w3-row w3-margin-top w3-padding">
    <div class="w3-margin-top " style="margin-right: 10px;">
            <div class="w3-row w3-border-bottom w3-border-light-gray">
            <div class="w3-col l4 s12 m6 w3-padding-small">
                <asp:Label Text="Date" CssClass="w3-large  " ForeColor="#166D89" runat="server" />
                <div class='input-group date' id='date1'>
                    <asp:TextBox ID="tb_date" type='text' class="w3-input w3-border w3-round" runat="server" />
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>
            </div>
            <div class="w3-col l4 s12 m6 w3-padding-small">
                <asp:Label Text="Time" CssClass="w3-large  " ForeColor="#166D89" runat="server" />
                <div class='input-group date' id='time1'>
                    <asp:TextBox ID="tb_time" type='text' class="w3-input w3-border w3-round" runat="server" />
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-time"></span>
                    </span>
                </div>
            </div>
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
    <div class="w3-row w3-padding-large w3-margin-top">

               <div class="w3-col l6 m7 s12  w3-border-right">
                   <div class="w3-row  w3-margin-top ">
                       <asp:Label Text="E:" runat="server" />
                       <asp:RadioButtonList ID="rbl_e"  OnSelectedIndexChanged="cal_gcs" AutoPostBack="true" CssClass="radio-toolbar" RepeatLayout="Flow" RepeatDirection="Horizontal" runat="server">
                           <asp:ListItem Text="1" Value="1" />
                           <asp:ListItem Text="2" Value="2" />
                           <asp:ListItem Text="3" Value="3" />
                           <asp:ListItem Text="4" Value="4" />
                       </asp:RadioButtonList>
                   </div>
                   <div class="w3-row w3-center w3-margin-top">
                       <div class="w3-left" ><b style="font-size:large">ET:</b>&nbsp;<asp:CheckBox ID="cb_et" OnCheckedChanged="t_checked" AutoPostBack="true" CssClass="BigCheckBox" runat="server" /></div>
                  
                       <div class="w3-left" style="margin-left:10px;"><b style="font-size:large">T:</b>&nbsp;<asp:CheckBox ID="cb_t" OnCheckedChanged="t_checked" AutoPostBack="true" CssClass="BigCheckBox" runat="server" /></div>
                    
                       <div class="w3-left" style="margin-left:10px;"><b style="font-size:large">CRY:</b>&nbsp;<asp:CheckBox ID="cb_cry" OnCheckedChanged="cry_checked" AutoPostBack="true" CssClass="BigCheckBox" runat="server" /></div>
                   
                       <div class="w3-left" style="margin-left:10px;"><b style="font-size:large">SPONT:</b>&nbsp;<asp:CheckBox ID="cb_spont" OnCheckedChanged="spont_checked" AutoPostBack="true" CssClass="BigCheckBox" runat="server" /></div>
                   </div>
                   <div class="w3-row  w3-margin-top">
                       <asp:Label Text="V:" runat="server" />
                       <asp:RadioButtonList ID="rbl_v" OnSelectedIndexChanged="cal_gcs" AutoPostBack="true" CssClass="radio-toolbar" RepeatLayout="Flow" RepeatDirection="Horizontal" runat="server">
                           <asp:ListItem Text="1" Value="1" />
                           <asp:ListItem Text="2" Value="2" />
                           <asp:ListItem Text="3" Value="3" />
                           <asp:ListItem Text="4" Value="4" />
                           <asp:ListItem Text="5" Value="5" />
                       </asp:RadioButtonList>
                   </div>
                   
                   <div class="w3-row  w3-margin-top">
                       <asp:Label Text="M:" runat="server" />
                       <asp:RadioButtonList ID="rbl_m" OnSelectedIndexChanged="cal_gcs" AutoPostBack="true" CssClass="radio-toolbar" RepeatLayout="Flow" RepeatDirection="Horizontal" runat="server">
                           <asp:ListItem Text="1" Value="1" />
                           <asp:ListItem Text="2" Value="2" />
                           <asp:ListItem Text="3" Value="3" />
                           <asp:ListItem Text="4" Value="4" />
                           <asp:ListItem Text="5" Value="5" />
                           <asp:ListItem Text="6" Value="6" />
                       </asp:RadioButtonList>
                   </div>
               </div>
               
               <div class="w3-col l6 m5 s12 w3-padding">
                   <div class="w3-row w3-margin-top">
                       <div style=" font-size:xx-large;">Total: <asp:Label ID="lb_tot" ForeColor="#79B4B7" Text="--" runat="server" /></div>
                   </div>
               </div>
           </div>
            <div class="w3-row w3-padding-large w3-center">
                    <div>
                        <asp:Button Text="Save" OnClick="save_gcs" CssClass="w3-button w3-padding-large w3-hover-light-blue w3-large w3-round-xxlarge w3-text-white" BackColor="#166D89" runat="server" />
                    </div>
                </div>
           <br />
            <div class="w3-container w3-row w3-padding ">
                <h3 style=" color:#79B4B7;">Previous GCS: </h3>
                <div class="w3-panel w3-white  cd4_grid"   id="Div2" runat="server" >
                    <asp:gridview ID="gv2" runat="server" Width="100%" AutoGenerateColumns="False"  ViewStateMode="Enabled" ShowHeaderWhenEmpty="True" AllowSorting="True"  >
                        <Columns>   
                            <asp:BoundField HeaderText="Date" DataField="Date" SortExpression="date" DataFormatString="{0:dd-MM-yyyy}" HtmlEncode="false"/>
                            <asp:BoundField DataField="time" HeaderText="Time"  />
                            <asp:BoundField DataField="e" HeaderText="E" />
                            <asp:BoundField DataField="v" HeaderText="V"  />
                            <asp:BoundField DataField="m" HeaderText="M" />
                            <asp:BoundField DataField="et" HeaderText="ET" />
                            <asp:BoundField DataField="t" HeaderText="T" />
                            <%--<asp:BoundField DataField="cry" HeaderText="CRY" />
                            <asp:BoundField DataField="spont" HeaderText="SPONT" />--%>
                            <asp:BoundField DataField="total" HeaderText="TOTAL" />
                        </Columns>  
                        <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                    </asp:gridview>  
                </div>
            </div> 

</asp:Content>
