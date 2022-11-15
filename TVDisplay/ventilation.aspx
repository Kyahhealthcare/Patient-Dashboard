<%@ Page Title="" Language="C#" MasterPageFile="~/display.Master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="ventilation.aspx.cs" Inherits="TVDisplay.ventilation" %>
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
        .ab:in-range {
            
        }
        
    </style>
    <meta charset="UTF-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

        <div class="w3-container">
        <div class="w3-row w3-margin-top w3-padding">
            <div class="w3-col l3 m6 s12 w3-padding-small">
                <asp:Label CssClass="w3-large" Text="Mode" ForeColor="#166D89" runat="server" />
                <asp:DropDownList ID="ddl_vent_mode" CssClass="w3-select w3-border w3-round-large" runat="server">
                    <asp:ListItem Text="Room Air" Value="Room Air" />
                    <asp:ListItem Text="Mask" Value="Mask" />
                    <asp:ListItem Text="SIMV" Value="SIMV" />
                    <asp:ListItem Text="PSV" Value="PSV" />
                    <asp:ListItem Text="T Piece" Value="T Piece" />
                    <asp:ListItem Text="CPAP" Value="CPAP" />
                    <asp:ListItem Text="ACBC" Value="ACBC" />
                    <asp:ListItem Text="SPONT" Value="SPONT" />
                </asp:DropDownList>
            </div>
            <div class="w3-col l3 m6 s12 w3-padding-small">
                <asp:Label CssClass="w3-large" Text="Tracheostomy" ForeColor="#166D89" runat="server" />
                <asp:DropDownList ID="ddl_trach" AutoPostBack="true" OnSelectedIndexChanged="venti_trach" CssClass="w3-select w3-border w3-round-large" runat="server">
                    <asp:ListItem Text="No" Value="No" />
                    <asp:ListItem Text="Yes" Value="Yes" />
                </asp:DropDownList>
            </div>
            <div class="w3-col l3 m6 s12 w3-padding-small">
                <asp:Label CssClass="w3-large" Text="Intubated" ForeColor="#166D89" runat="server" />
                <asp:DropDownList ID="ddl_intubated" AutoPostBack="true" OnSelectedIndexChanged="venti_intu" CssClass="w3-select w3-border w3-round-large" runat="server">
                    <asp:ListItem Text="No" Value="No" />
                    <asp:ListItem Text="Yes" Value="Yes" />
                </asp:DropDownList>
            </div>
            <div class="w3-col l3 m6 s12 w3-padding-small">
                <asp:Label CssClass="w3-large" Text="Sedation" ForeColor="#166D89" runat="server" />
                <asp:DropDownList ID="ddl_sedation" CssClass="w3-select w3-border w3-round-large" runat="server">
                    <asp:ListItem Text="No" Value="No" />
                    <asp:ListItem Text="Yes" Value="Yes" />
                </asp:DropDownList>
            </div>
        </div>
        <div class="w3-row w3-padding">
            <div class="w3-col l3 m6 s12 w3-padding-small">
                <asp:Label CssClass="w3-large" Text="FIO<sub>2</sub>" ForeColor="#166D89" runat="server" />
                <asp:TextBox ID="tb_fio" TextMode="Number" runat="server" Text="21" CssClass="ab w3-select w3-border w3-round-large" min="21" max="100"></asp:TextBox>
                <asp:RangeValidator runat="server" ControlToValidate="tb_fio" ErrorMessage="FIO<sub>2</sub> can be between 21% to 100%"
                Type="Integer" MinimumValue="21" MaximumValue="100" ForeColor="Red"></asp:RangeValidator>
            </div>
            <div class="w3-col l4 m6 s12 w3-padding-small">
                <asp:Label CssClass="w3-large" Text="Pressure Support" ForeColor="#166D89" runat="server" />
                <asp:TextBox ID="tb_pres" TextMode="Number" runat="server" Text="6" CssClass="ab w3-select w3-border w3-round-large" min="6" max="20"></asp:TextBox>
                <asp:RangeValidator runat="server" ControlToValidate="tb_pres" ErrorMessage="PS can be between 6 to 20"
                Type="Integer" MinimumValue="6" MaximumValue="20" ForeColor="Red"></asp:RangeValidator>
            </div>
        </div>
        <div class="w3-row w3-padding-large w3-center">
            <div>
                <asp:Button Text="Save" OnClick="Save_venti" CssClass="w3-button w3-padding-large w3-hover-light-blue w3-large w3-round-xxlarge w3-text-white" BackColor="#166D89" runat="server" />
            </div>
        </div>
        </div>
   
   <%-- </div>
</div>--%>
                       
</asp:Content>
