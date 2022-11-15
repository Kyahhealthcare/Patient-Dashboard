<%@ Page Title="" Language="C#" MasterPageFile="~/display.Master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="IO.aspx.cs" Inherits="TVDisplay.IO" %>

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
        <div class="w3-col l4 s12 w3-padding-small">
            <asp:Label Text="Date" CssClass="w3-large  " ForeColor="#166D89" runat="server" />
            <div class='input-group date' id='date1'>
                <asp:TextBox ID="tb_date" type='text' class="w3-input w3-border w3-round" runat="server" />
                <span class="input-group-addon">
                    <span class="glyphicon glyphicon-calendar"></span>
                </span>
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
    </div>
   
    <div class="w3-row w3-padding">
        <div class="w3-col l4 s12 w3-padding-small">
            <asp:Label Text="I" CssClass="w3-large  " ForeColor="#166D89" runat="server" />
            <div class="input-box">
                <asp:TextBox ID="tb_i" CssClass="w3-input w3-border w3-round-large w3-padding" runat="server" />
                <span class="unit">ml</span>
            </div>
        </div>
        <div class="w3-col l4 s12 w3-padding-small">
            <asp:Label Text="O" CssClass="w3-large  " ForeColor="#166D89" runat="server" />
            <div class="input-box">
                <asp:TextBox ID="tb_o" CssClass="w3-input w3-border w3-round-large w3-padding" runat="server" />
                <span class="unit">ml</span>
            </div>
        </div>
        <div class="w3-col l4 s12 w3-padding-small">
            <asp:Label Text="Drain" CssClass="w3-large  " ForeColor="#166D89" runat="server" />
            <div class="input-box">
                <asp:TextBox ID="tb_drain" CssClass="w3-input w3-border w3-round-large w3-padding" runat="server" />
                <span class="unit">ml</span>
            </div>
        </div>
        <div class="w3-col l4 s12 w3-padding-small">
            <asp:Label Text="Comment for Other Drain" CssClass="w3-large  " ForeColor="#166D89" runat="server" />
            <asp:TextBox ID="tb_drain_comment" TextMode="MultiLine" CssClass="w3-input w3-border w3-round-large w3-padding" runat="server" />
        </div>
    </div>
    <div class="w3-row w3-padding-large w3-center w3-margin-bottom">
        <div>
            <asp:Button ID="btn_save" Text="Save" OnClick="save_io" CssClass="w3-button w3-padding-large  w3-hover-light-blue w3-large w3-round-xxlarge w3-text-white" BackColor="#166D89" runat="server" />
        </div>
    </div>
    <br />
    <br />
    <div class="w3-container w3-row w3-padding ">
        <h3 style="color: #79B4B7;">Previous Issues: </h3>
        <div class="w3-panel w3-white  cd4_grid" id="Div2" runat="server">
            <asp:GridView ID="gv1" Width="100%" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gv_index_change"  AutoGenerateColumns="False" runat="server">
                <Columns>
                    <asp:BoundField DataField="date" HeaderText="Date"  SortExpression="date" DataFormatString="{0:dd-MM-yyyy}" HtmlEncode="false" />
                    <asp:BoundField DataField="i" HeaderText="I(ml)" SortExpression="i" />
                    <asp:BoundField DataField="o" HeaderText="O (ml)" SortExpression="o" />
                    <asp:BoundField DataField="drain" HeaderText="Drain (ml)" SortExpression="drain"/>
                    <asp:BoundField DataField="drain_comment" HeaderText="Cmment for Drain" SortExpression="drain_comment"/>
             
                </Columns>
                <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
            </asp:GridView>
        </div>
    </div>

  </asp:Content>
