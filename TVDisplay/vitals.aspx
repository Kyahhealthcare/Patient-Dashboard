<%@ Page Title="" Language="C#" MasterPageFile="~/display.Master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="vitals.aspx.cs" Inherits="TVDisplay.vitals" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <style type="text/css">
        * {
            padding: 0;
            margin: 0;
        }

        body {
            /* background-color:#166D89;*/
            margin: 0;
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
            color: #166D89;
        }

        .modalBackground {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }

        .modalPopup {
            background-color: #fff;
            border-left: 3px solid #ccc;
            border-right: 3px solid #ccc;
            border-bottom: 3px solid #ccc;
            width: 70%;
            height: 70vh;
            /*overflow-y:scroll;*/
        }

        .cd4_grid {
            width: 100%;
            height: 150px;
            background-color: white;
            border: solid;
            border-color: black;
            border-width: 2px;
            text-align: center;
            overflow-x: scroll;
            overflow-y: scroll;
        }

        .mydatagrid {
            width: 100%;
            border: solid 1px grey;
            min-width: 100%;
        }

        .header {
            background-color: #79B4B7;
            font-family: Arial;
            color: white;
            /*border: none 0px transparent;*/
            border: solid 1px #CDCDCD;
            height: 25px;
            text-align: center;
            font-size: 16px;
        }

        .rows {
            background-color: #fff;
            font-family: Arial;
            font-size: 14px;
            color: #000;
            min-height: 25px;
            text-align: left;
            /* border: none 0px transparent;*/
            border: solid 1px #CDCDCD;
            text-align: center;
        }

        .rows:hover {
            background-color: #ff8000;
            font-family: Arial;
            color: #fff;
            text-align: left;
            font-weight: bold;
            text-align: center;
        }

        .selectedrow {
            background-color: #ff8000;
            font-family: Arial;
            color: #fff;
            font-weight: bold;
            text-align: left;
        }

        .mydatagrid a /** FOR THE PAGING ICONS **/ {
            background-color: Transparent;
            padding: 5px 5px 5px 5px;
            color: #fff;
            text-decoration: none;
            font-weight: bold;
        }

        .mydatagrid a:hover /** FOR THE PAGING ICONS HOVER STYLES**/ {
            background-color: #000;
            color: #fff;
        }

        .mydatagrid span /** FOR THE PAGING ICONS CURRENT PAGE INDICATOR **/ {
            background-color: #c9c9c9;
            color: #000;
            padding: 5px 5px 5px 5px;
        }

        .pager {
            background-color: #646464;
            font-family: Arial;
            color: White;
            height: 30px;
            text-align: left;
        }

        .mydatagrid td {
            padding: 5px;
        }

        .mydatagrid th {
            padding: 5px;
        }

        .cbl {            
            overflow-y: scroll;
            height: 110px;
            font-weight:400;
        }
        .cbl input
        {
             float: left;  
             width:20px; 
             height:20px;
             border:solid;
             border-color:black;
             padding:5px;
             border-bottom:solid;
             border-width:2px;
             font-weight:400;
        }
        .cbl label {
           width: auto;      
           display: inline;      
           float: left;
           font-weight:400;           
           padding:5px;           
        }

    </style>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css" />

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script src="https://cdn.jsdelivr.net/momentjs/2.14.1/moment.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datetimepicker/4.17.37/js/bootstrap-datetimepicker.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datetimepicker/4.17.37/css/bootstrap-datetimepicker.min.css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

       <div class="w3-row w3-margin-top w3-padding">

              <div class="w3-margin-top w3-padding" style="margin-right: 10px;">
                     <div class="w3-row w3-border-bottom w3-border-light-gray">
                        <div class="w3-col l4 s6 m4 w3-padding-small">
                            <asp:Label Text="Date" CssClass="w3-large  " ForeColor="#166D89" runat="server" />
                            <div class='input-group date' id='date1'>
                                <asp:TextBox ID="tb_date" type='text' class="w3-input w3-border w3-round" runat="server" />
                                <span class="input-group-addon">
                                    <span class="glyphicon glyphicon-calendar"></span>
                                </span>
                            </div>
                        </div>
                        <div class="w3-col l4 s6 m4 w3-padding-small">
                            <asp:Label Text="Time" CssClass="w3-large  " ForeColor="#166D89" runat="server" />
                            <div class='input-group date' id='time1'>
                                <asp:TextBox ID="tb_time" type='text' class="w3-input w3-border w3-round" runat="server" />
                                <span class="input-group-addon">
                                    <span class="glyphicon glyphicon-time"></span>
                                </span>
                            </div>
                        </div>
                    </div>
                    <div class="w3-row">
                        <div class="w3-col l6 s12 m4 w3-padding-small">
                            <asp:Label Text="RR" CssClass="w3-large  " ForeColor="#166D89" runat="server" />
                            <div class="input-box">
                                <asp:TextBox ID="tb_rr" CssClass="w3-input w3-border w3-round-large w3-padding" runat="server" />
                                <span class="unit">bpm</span>
                            </div>
                        </div>
                        <div class="w3-col l6 s12 m4 w3-padding-small">
                            <asp:Label Text="SPO2" CssClass="w3-large  " ForeColor="#166D89" runat="server" />
                            <div class="input-box">
                                <asp:TextBox ID="tb_spo2" CssClass="w3-input w3-border w3-round-large w3-padding" runat="server" />
                                <span class="unit">mmHg</span>
                            </div>
                        </div>
                        <div class="w3-col l6 s12 m4 w3-padding-small">
                            <asp:Label Text="Pulse Rate" CssClass="w3-large  " ForeColor="#166D89" runat="server" />
                            <div class="input-box">
                                <asp:TextBox ID="tb_pulse" CssClass="w3-input w3-border w3-round-large w3-padding" runat="server" />
                                <span class="unit">bpm</span>
                            </div>
                        </div>
                        <div class="w3-col l6 s12 m4 w3-padding-small">
                            <asp:Label Text="Temperature" CssClass="w3-large  " ForeColor="#166D89" runat="server" />
                            <div class="input-box">
                                <asp:TextBox ID="tb_temp" CssClass="w3-input w3-border w3-round-large w3-padding" runat="server" />
                                <span class="unit"><sup>o</sup>F</span>
                            </div>
                        </div>
                        <div class="w3-col l6 s12 m4 w3-padding-small">
                            <asp:Label Text="Blood Pressure" CssClass="w3-large " ForeColor="#166D89" runat="server" />
                            <div class="input-box">
                                <asp:TextBox ID="tb_bp" CssClass="w3-input w3-border w3-round-large w3-padding" runat="server" />
                                <span class="unit">mmHg</span>
                            </div>
                        </div>
                        <div class="w3-col l6 s12 m4 w3-padding-small">
                            <asp:Label Text="ICP" CssClass="w3-large " ForeColor="#166D89" runat="server" />
                            <div class="input-box">
                                <asp:TextBox ID="tb_icp" CssClass="w3-input w3-border w3-round-large w3-padding" runat="server" />
                                <span class="unit">mmHg</span>
                            </div>
                        </div>
                       
                    </div>

                    <hr />
                   <h4 class="w3-padding-small">Pupils</h4> 
                   <div class="w3-row">
                       <div class="w3-col l4 m6 s12 w3-padding-small">
                           <asp:Label CssClass="w3-large " Text="Right" ForeColor="#166D89" runat="server" />
                           <asp:RadioButtonList ID="rbl_p_right" CssClass="cbl w3-input w3-border w3-round-large" runat="server">
                               <asp:ListItem Text="NSRL" Value="NSRL" />
                               <asp:ListItem Text="NSNR" Value="NSNR" />
                               <asp:ListItem Text="NSSRL" Value="NSSRL" />
                               <asp:ListItem Text="MDRL" Value="MDRL" />
                               <asp:ListItem Text="MDNRL" Value="MDNRL" />
                               <asp:ListItem Text="NSNRL" Value="NSNRL" />
                               <asp:ListItem Text="DILATED SR" Value="DILATED SR" />
                               <asp:ListItem Text="DILATED NR" Value="DILATED NR" />
                               <asp:ListItem Text="DILATED FIXED" Value="DILATED FIXED" /> 
                               <asp:ListItem Text="CONSTRICTED" Value="CONSTRICTED" />
                               <asp:ListItem Text="NOT ACCESSIBLE" Value="NOT ACCESSIBLE" />
                           </asp:RadioButtonList>
                       </div>
                       <div class="w3-col l4 m6 s12 w3-padding-small">
                           <asp:Label CssClass="w3-large " Text="Left" ForeColor="#166D89" runat="server" />
                           <asp:RadioButtonList ID="rbl_p_left"  CssClass="cbl w3-input w3-border w3-round-large" runat="server">
                               <asp:ListItem Text="NSRL" Value="NSRL" />
                               <asp:ListItem Text="NSNR" Value="NSNR" />
                               <asp:ListItem Text="NSSRL" Value="NSSRL" />
                               <asp:ListItem Text="MDRL" Value="MDRL" />
                               <asp:ListItem Text="MDNRL" Value="MDNRL" />
                               <asp:ListItem Text="NSNRL" Value="NSNRL" />
                               <asp:ListItem Text="DILATED SR" Value="DILATED SR" />
                               <asp:ListItem Text="DILATED NR" Value="DILATED NR" />
                               <asp:ListItem Text="DILATED FIXED" Value="DILATED FIXED" /> 
                               <asp:ListItem Text="CONSTRICTED" Value="CONSTRICTED" />
                               <asp:ListItem Text="NOT ACCESSIBLE" Value="NOT ACCESSIBLE" />
                           </asp:RadioButtonList>
                       </div>
                   </div>

                </div>
               <div class="w3-row w3-padding-large w3-center">
                    <div>
                        <asp:Button Text="Save" OnClick="save_vitals" CssClass="w3-button w3-padding-large w3-hover-light-blue w3-large w3-round-xxlarge w3-text-white" BackColor="#166D89" runat="server" />
                    </div>
                </div>
           <br />
            <div class="w3-container w3-row w3-padding ">
                <h3 style=" color:#79B4B7;">Previous Vitals: </h3>
                <div class="w3-panel w3-white  cd4_grid"   id="Div2" runat="server" >
                    <asp:gridview ID="gv2" runat="server" Width="100%" AutoGenerateColumns="False"  ViewStateMode="Enabled" ShowHeaderWhenEmpty="True" AllowSorting="True"  >
                        <Columns>   
                            <asp:BoundField HeaderText="Date" DataField="date" SortExpression="date" DataFormatString="{0:dd-MM-yyyy}" HtmlEncode="false"/>
                            <asp:BoundField DataField="time" HeaderText="Time"  />
                            <asp:BoundField DataField="rr" HeaderText="RR" />
                            <asp:BoundField DataField="spo2" HeaderText="SPO2"  />
                            <asp:BoundField DataField="pulse" HeaderText="Pulse" />
                            <asp:BoundField DataField="temp" HeaderText="Temp" />
                            <asp:BoundField DataField="bp" HeaderText="BP" />
                            <asp:BoundField DataField="icp" HeaderText="ICP" />
                            <asp:BoundField DataField="rpupil" HeaderText="Right Pupil" />
                            <asp:BoundField DataField="lpupil" HeaderText="Left Pupil" />
                        </Columns>  
                        <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                    </asp:gridview>  
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

           

</asp:Content>
