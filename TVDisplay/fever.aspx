<%@ Page Title="" Language="C#" MasterPageFile="~/display.Master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="fever.aspx.cs" Inherits="TVDisplay.fever" %>
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
     <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
<script src="https://cdn.jsdelivr.net/momentjs/2.14.1/moment.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datetimepicker/4.17.37/js/bootstrap-datetimepicker.min.js"></script>
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datetimepicker/4.17.37/css/bootstrap-datetimepicker.min.css">
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
        <div class="w3-row w3-margin-top w3-padding">
            <div class="w3-col l4 s12 m6 ">
                <asp:Label CssClass="w3-large" Text="Date" ForeColor="#166D89" runat="server" />
                <div class='input-group date' id='date1'>
                    <asp:TextBox ID="tb_date" type='text' class="w3-input w3-border w3-round" runat="server" />
                    <span class="input-group-addon">
                    <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>
            </div>
            
        </div>
          <table class="w3-bordered w3-margin-top w3-table w3-padding-large" style="color:#166D89;">
                <tr>
                    <th></th>
                    <th>Result</th>
                    <th>Comment</th>
                </tr>
                <tr>
                    <th style="width:30px;">Bld C+S</th>
                    <td style="width:100px;">
                        <asp:DropDownList ID="ddl_bld" CssClass="w3-select w3-border w3-round-large" runat="server">
                            <asp:ListItem Text="-VE" Value="-VE" />
                            <asp:ListItem Text="+VE" Value="+VE" />
                            <asp:ListItem Text="Awaited" Value="Awaited" />
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox ID="tb_bld" CssClass="w3-input w3-border w3-round-large" runat="server" />
                    </td>
                </tr>
                <tr>
                    <th>Trach C+S</th>
                    <td>
                        <asp:DropDownList ID="ddl_trach" CssClass="w3-select w3-border w3-round-large" runat="server">
                            <asp:ListItem Text="-VE" Value="-VE" />
                            <asp:ListItem Text="+VE" Value="+VE" />
                            <asp:ListItem Text="Awaited" Value="Awaited" />
                        </asp:DropDownList>
                    </td>
                   <td>
                        <asp:TextBox ID="tb_trach" CssClass="w3-input w3-border w3-round-large" runat="server" />
                    </td>
                </tr>
                <tr>
                    <th>Urine C+S</th>
                    <td>
                        <asp:DropDownList ID="ddl_ur_cs" CssClass="w3-select w3-border w3-round-large" runat="server">
                           <asp:ListItem Text="-VE" Value="-VE" />
                           <asp:ListItem Text="+VE" Value="+VE" />
                           <asp:ListItem Text="Awaited" Value="Awaited" />
                        </asp:DropDownList>
                    </td>
                     <td>
                        <asp:TextBox ID="tb_ur_cs" CssClass="w3-input w3-border w3-round-large" runat="server" />
                    </td>
                </tr>
                <tr>
                    <th style="padding-top:20px;">Urine R+M</th>
                    <td>
                        <asp:Label Text="WBC" runat="server" />
                        <asp:DropDownList ID="ddl_ur_wbc" CssClass="w3-select w3-border w3-round-large" runat="server">
                            <asp:ListItem Text="-VE" Value="-VE" />
                            <asp:ListItem Text="+VE" Value="+VE" />
                            <asp:ListItem Text="Awaited" Value="Awaited" />
                        </asp:DropDownList>
                        <asp:Label Text="Ph" runat="server" />
                        <asp:TextBox ID="tb_ph" CssClass="w3-input w3-border w3-round-large" runat="server" />
                    </td>
                    <td >
                        <br />
                        <asp:TextBox ID="tb_ur_rm" Height="95px" CssClass="w3-input w3-border w3-round-large" runat="server" />
                    </td>
                   
                </tr>
                
            </table>

        
        <div class="w3-row w3-padding-large w3-center">
            <div>
                <asp:Button Text="Save" OnClick="save_fever_pack" CssClass="w3-button w3-padding-large w3-hover-light-blue w3-large w3-round-xxlarge w3-text-white" BackColor="#166D89" runat="server" />
            </div>
        </div>
        <br />
            <div class="w3-container w3-row w3-padding ">
                    <h3 style=" color:#79B4B7;">Previous Fever Packs: </h3>
                   <div class="w3-panel w3-white  cd4_grid"   id="Div2" runat="server" >
                       <asp:gridview ID="gv2"  runat="server" Width="100%" AutoGenerateColumns="False"  ViewStateMode="Enabled" ShowHeaderWhenEmpty="True" AllowSorting="True"  >
                          <Columns>   
                              <asp:BoundField HeaderText="Date" DataField="date" SortExpression="date" DataFormatString="{0:dd-MM-yyyy}" HtmlEncode="false"/>
                              <asp:BoundField DataField="bld_cs" HeaderText="Bld C+S" SortExpression="asia" />
                              <asp:BoundField DataField="bld_cs_cmt" HeaderText="Bld C+S Comment" SortExpression="after" />
                              <asp:BoundField DataField="trach_cs" HeaderText="Trach C+S" SortExpression="asia" />
                              <asp:BoundField DataField="trach_cs_cmt" HeaderText="Trach C+S Comment" SortExpression="after" />
                              <asp:BoundField DataField="urine_cs" HeaderText="Urine C+S" SortExpression="asia" />
                              <asp:BoundField DataField="urine_cs_cmt" HeaderText="Urine C+S Comment" SortExpression="after" />
                              <asp:BoundField DataField="urine_wbc" HeaderText="Urine R+M WBC" SortExpression="asia" />
                              <asp:BoundField DataField="urine_ph" HeaderText="Urine R+M Ph" SortExpression="asia" />
                              <asp:BoundField DataField="urine_rm_cmt" HeaderText="Urine R+M Comment" SortExpression="after" />
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
