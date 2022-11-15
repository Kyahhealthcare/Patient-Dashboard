<%@ Page Title="" Language="C#" MasterPageFile="~/display.Master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="BldTrans.aspx.cs" Inherits="TVDisplay.BldTrans" %>
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
    .mydatagrid
        {
        width: 100%;
        border: solid 1px grey;
        min-width: 100%;
        }
        .header
        {
        background-color: #79B4B7;
        font-family: Arial;
        color:white;
        /*border: none 0px transparent;*/
        border: solid 1px #CDCDCD;
        height: 25px;
        text-align: center;
        font-size: 16px;
       
        }

        .rows
        {
        background-color: #fff;
        font-family: Arial;
        font-size: 14px;
        color: #000;
        min-height: 25px;
        text-align: left;
       /* border: none 0px transparent;*/
           border: solid 1px #CDCDCD;
           text-align:center;
        }
        .rows:hover
        {
        background-color: #ff8000;
        font-family: Arial;
        color: #fff;
        text-align: left;
        font-weight:bold;
        text-align:center;
        }
        .selectedrow
        {
        background-color: #ff8000;
        font-family: Arial;
        color: #fff;
        font-weight: bold;
        text-align: left;
        }
        .mydatagrid a /** FOR THE PAGING ICONS **/
        {
        background-color: Transparent;
        padding: 5px 5px 5px 5px;
        color: #fff;
        text-decoration: none;
        font-weight: bold;
        }

        .mydatagrid a:hover /** FOR THE PAGING ICONS HOVER STYLES**/
        {
        background-color: #000;
        color: #fff;
        }
        .mydatagrid span /** FOR THE PAGING ICONS CURRENT PAGE INDICATOR **/
        {
        background-color: #c9c9c9;
        color: #000;
        padding: 5px 5px 5px 5px;
        }
        .pager
        {
        background-color: #646464;
        font-family: Arial;
        color: White;
        height: 30px;
        text-align: left;
        }

        .mydatagrid td
        {
        padding: 5px;
        }
        .mydatagrid th
        {
        padding: 5px;
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
            <div class="w3-col l4 s12 m6 w3-padding-small">
                <asp:Label CssClass="w3-large" Text="Blood" ForeColor="#166D89" runat="server" />
                <asp:DropDownList ID="ddl_bld_trans" CssClass="w3-select w3-border w3-round-large" runat="server">
                    <asp:ListItem Value=""></asp:ListItem>
                    <asp:ListItem Value="RBC">RED  BLOOD CELLS</asp:ListItem>
                    <asp:ListItem Value="WB">WHOLE BLOOD </asp:ListItem>
                    <asp:ListItem Value="FFP">FRESH FROZEN PLAZMA</asp:ListItem>
                    <asp:ListItem Value="HWB">HEPRARIN WHOLE BLOOD</asp:ListItem>
                    <asp:ListItem Value="LP">LIQUID PLAZMA</asp:ListItem>
                    <asp:ListItem Value="PLTS">PLATELETS</asp:ListItem>
                    <asp:ListItem Value="POOLED PLT">POOLED PLATELETS</asp:ListItem>
                    <asp:ListItem Value="RH IgG">RH IMMUNE GLOBULIN</asp:ListItem>
                    <asp:ListItem Value="ALBUMIN 5%"></asp:ListItem>
                    <asp:ListItem Value="CRYOPRECIPITATE"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="w3-col l4 s12 m6 w3-padding-small">
                <asp:Label CssClass="w3-large" Text="Quantity" ForeColor="#166D89" runat="server" />
                <asp:TextBox ID="tb_quan"  CssClass="w3-input w3-border w3-round-large" runat="server" />
            </div>
            <div class="w3-col l4 s12 m6 w3-padding-small">
                <asp:Label CssClass="w3-large" Text="Blood Bag No." ForeColor="#166D89" runat="server" />
                <asp:TextBox ID="tb_bld_bag"  CssClass="w3-input w3-border w3-round-large" runat="server" />
            </div>
        </div>
        <div class="w3-row w3-padding">
            <div class="w3-col l4 s12 m6 w3-padding-small">
                <asp:Label CssClass="w3-large" Text="Date of Start" ForeColor="#166D89" runat="server" />
                 <div class='input-group date' id='date1'>
                    <asp:TextBox ID="tb_dos" type='text' class="w3-input w3-border w3-round" runat="server" />
                    <span class="input-group-addon">
                    <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>
            </div>
            <div class="w3-col l4 s12 m6 w3-padding-small">
                <asp:Label CssClass="w3-large" Text="Any Reaction?" ForeColor="#166D89" runat="server" />
                <asp:DropDownList ID="ddl_react" CssClass="w3-select w3-border w3-round-large" runat="server">
                    <asp:ListItem Text="No" />
                    <asp:ListItem Text="Yes" />
                </asp:DropDownList>
            </div>
            <div class="w3-col l4 s12 m6 w3-padding-small">
                <asp:Label CssClass="w3-large" Text="Completed?" ForeColor="#166D89" runat="server" />
                <asp:DropDownList ID="ddl_comp" CssClass="w3-select w3-border w3-round-large" runat="server">
                    <asp:ListItem Text="No" />
                    <asp:ListItem Text="Yes" />
                </asp:DropDownList>
            </div>
        </div>
        
        
        <div class="w3-row w3-padding-large w3-center">
        <div>
            <asp:Button Text="Save" OnClick="save_bld_trans" CssClass="w3-button w3-padding-large w3-hover-light-blue w3-large w3-round-xxlarge w3-text-white" BackColor="#166D89" runat="server" />
        </div>
        </div>
        <br />
            <div class="w3-container w3-row w3-padding ">
                <h3 style=" color:#79B4B7;">Previous Blood Transfusions: </h3>
                <div class="w3-panel w3-white  cd4_grid"   id="Div2" runat="server" >
                    <asp:gridview ID="gv2"  runat="server" Width="100%" AutoGenerateColumns="False"  ViewStateMode="Enabled" ShowHeaderWhenEmpty="True" AllowSorting="True"  >
                        <Columns>   
                            <asp:BoundField  DataField="type" HeaderText="Type" />
                            <asp:BoundField DataField="quantity" HeaderText="Quantity"  />
                            <asp:BoundField DataField="blood_bag_no" HeaderText="Bld Bag no."  />
                            <asp:BoundField DataField="date_of_start" HeaderText="Date of Start"  DataFormatString="{0:dd-MM-yyyy}" HtmlEncode="false" />
                            <asp:BoundField DataField="reaction" HeaderText="Any Reaction?"  />
                            <asp:BoundField DataField="completed" HeaderText="Completed?"  />
                        </Columns>  
                        <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                    </asp:gridview>  
                </div>
            </div> 
         <script>
            $(function () {
                $('#date1').datetimepicker({
                    format: 'DD-MM-YYYY',
                    defaultDate: moment(),
                    sideBySide: true
                });
            });
         </script>
    

</asp:Content>
