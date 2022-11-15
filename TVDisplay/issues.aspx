<%@ Page Title="" Language="C#" MasterPageFile="~/display.Master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="issues.aspx.cs" Inherits="TVDisplay.issues" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .cd4_grid {
            width: 100%;
            height: 150px;
            background-color: white;
            border: solid;
            border-color: darkgray;
            border-width: 1px;
            text-align: center;
            overflow-x: scroll;
            overflow-y: scroll;
        }

        .mydatagrid {
            width: 100%;
            /* border: solid 1px grey;*/
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
            /* border: solid 1px #CDCDCD;*/
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
    </style>
     <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script src="https://cdn.jsdelivr.net/momentjs/2.14.1/moment.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datetimepicker/4.17.37/js/bootstrap-datetimepicker.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datetimepicker/4.17.37/css/bootstrap-datetimepicker.min.css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   
            <div class="w3-row w3-padding-large w3-margin-top">
                <div class="w3-col l4 s12 w3-padding-small">
                    <asp:Label Text="Issue" CssClass="w3-large  " ForeColor="#166D89" runat="server" />
                   
                    <%--<link href="css/icd_style.css" rel="stylesheet" />
                    <script src='https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js'></script>--%>
                    
                    <%--<script src="script/icd_script.js"></script>--%>
                    <asp:TextBox runat="server"  type="text" ID="icd10"  class="w3-input w3-border w3-round-large" />
                    <%--<script type="text/javascript">   
                        new Def.Autocompleter.Search('icd10', 'https://clinicaltables.nlm.nih.gov/api/icd10cm/v3/search?sf=code,name',
                            { tableFormat: true, valueCols: [0] + [1], colHeaders: ['Code', 'Name'] });
                    </script>--%>
                   
                </div>
                <div class="w3-col l4 s12 w3-padding-small">
                    <asp:Label Text="Since Date" CssClass="w3-large  " ForeColor="#166D89" runat="server" />
                    <div class='input-group date' id='date1'>
                        <asp:TextBox ID="tb_sd1" type='text' class="w3-input w3-border w3-round" runat="server" />
                        <span class="input-group-addon">
                            <span class="glyphicon glyphicon-calendar"></span>
                        </span>
                    </div>
                </div>
                <div class="w3-col l4 s12 w3-padding-small">
                    <asp:Label Text="Till Date" CssClass="w3-large  " ForeColor="#166D89" runat="server" />
                    <div class='input-group date' id='date2'>
                        <asp:TextBox ID="tb_td1" type='text' class="w3-input w3-border w3-round" runat="server" />
                        <span class="input-group-addon">
                            <span class="glyphicon glyphicon-calendar"></span>
                        </span>
                    </div>
                    <script>
                        $(function () {
                            $('#date1').datetimepicker({
                                format: 'DD-MM-YYYY',
                                defaultDate: moment(),
                                sideBySide: true
                            });

                            $('#date2').datetimepicker({
                                format: 'DD-MM-YYYY'
                            });

                        });
                    </script>
                </div>
            </div>



            <div class="w3-row w3-padding-large w3-center">
                <div>
                    <asp:Button ID="btn_save" Text="Save" OnClick="save_issue" CssClass="w3-button w3-padding-large w3-hover-light-blue w3-large w3-round-xxlarge w3-text-white" BackColor="#166D89" runat="server" />
                </div>
            </div>
            <br />
            <br />
            <div class="w3-container w3-row w3-padding ">
                <h3 style="color: #79B4B7;">Previous Issues: </h3>
                <div class="w3-panel w3-white  cd4_grid" id="Div2" runat="server">
                    <asp:GridView ID="gv1" Width="100%" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gv_index_change"  AutoGenerateColumns="False" runat="server">
                        <Columns>
                            <asp:BoundField DataField="issue" HeaderText="ISSUE" SortExpression="name" />
                            <asp:BoundField DataField="status" HeaderText="STATUS" SortExpression="status" />
                            <asp:BoundField DataField="since_date" HeaderText="SINCE DATE"  SortExpression="date" DataFormatString="{0:dd-MM-yyyy}" HtmlEncode="false" />
                            <asp:BoundField DataField="till_date" HeaderText="TILL DATE" SortExpression="date" DataFormatString="{0:dd-MM-yyyy}" HtmlEncode="false" />
                         </Columns>
                        <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                    </asp:GridView>
                </div>
            </div>

      
</asp:Content>
