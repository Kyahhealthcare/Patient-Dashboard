<%@ Page Language="C#" ViewStateMode="Enabled" AutoEventWireup="true" CodeBehind="MyPatients.aspx.cs" Inherits="TVDisplay.MyPatients"  %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <style type="text/css">
        * {
            /*font-family: 'Montserrat', sans-serif;*/
            font-family: 'Roboto', sans-serif;
        }
        body{
            background-color:#f2f2f2;
        }

        .lb {
            text-decoration: none;           
            font-weight:500;           
        }

        .cd4_grid {
            width: 100%;
            height: 150px;
            background-color: white;
            border: solid;
            border-color: darkgray;
            border-width: 1px;
            text-align: center;
            overflow-y: scroll;
        }
        .search_box{
            margin-top:7px;
        }
        input[type=checkbox] {width:25px; height:25px;}
        
    </style>
   
     <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <%--<link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css"/>--%>
    <link href="css/w3_css.css" rel="stylesheet" />


    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
    <link href="css/font_awesome.css" rel="stylesheet" />
  
    <link rel="preconnect" href="https://fonts.googleapis.com"/>
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin/>
    <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@100;300;400;500&display=swap" rel="stylesheet"/>
    <link href="css/roboto_font.css" rel="stylesheet" />

     <script type="text/javascript">
         // Select/Deselect checkboxes based on header checkbox
         function SelectheaderCheckboxes(headerchk) {
             debugger
             var gvcheck = document.getElementById('gv2');
             var i;
             //Condition to check header checkbox selected or not if that is true checked all checkboxes
             if (headerchk.checked) {
                 document.getElementById("second_bar").style.display = "block";
                 document.getElementById("first_bar").style.display = "none";
                 for (i = 0; i < gvcheck.rows.length; i++) {
                     var inputs = gvcheck.rows[i].getElementsByTagName('input');
                     inputs[0].checked = true;
                 }
             }
             //if condition fails uncheck all checkboxes in gridview
             else {
                 document.getElementById("second_bar").style.display = "none";
                 document.getElementById("first_bar").style.display = "block";
                 for (i = 0; i < gvcheck.rows.length; i++) {
                     var inputs = gvcheck.rows[i].getElementsByTagName('input');
                     inputs[0].checked = false;
                 }
             }
         }
         //function to check header checkbox based on child checkboxes condition
         function Selectchildcheckboxes(header) {
             var ck = header;
             var count = 0;
             var gvcheck = document.getElementById('gv2');
             var headerchk = document.getElementById(header);
             var rowcount = gvcheck.rows.length;
             //By using this for loop we will count how many checkboxes has checked
             for (i = 1; i < gvcheck.rows.length; i++) {
                 var inputs = gvcheck.rows[i].getElementsByTagName('input');
                 if (inputs[0].checked) {
                     count++;
                 }
             }
             //Condition to check all the checkboxes selected or not
             if (count == rowcount - 1) {
                 headerchk.checked = true;                 
             }
             else {
                 headerchk.checked = false;
             }

             if (count == 0) {
                 //alert('nothing')
                 document.getElementById("second_bar").style.display = "none";
                 document.getElementById("first_bar").style.display = "block";
             }
             else {
                // alert('something checked')
                 document.getElementById("second_bar").style.display = "block";
                 document.getElementById("first_bar").style.display = "none";
             }
         }
     </script>

</head>
<body>
    <form id="form1" runat="server">   
        <asp:ScriptManager runat="server" />
        <div class="w3-top">
            <div class="w3-bar w3-text-white w3-large" style="width:100%; background-color:#166D89;">
                <%--<asp:LinkButton ID="link" class=" w3-bar-item w3-button w3-xlarge w3-hide-large"  runat="server" ><i class="fa fa-bars"></i></asp:LinkButton>--%>
                <div class="w3-bar-item  w3-xlarge "  style="text-shadow:1px 1px 0"; ></div>
                <%--<div class="w3-bar-item w3-xlarge" style="float:right;"><a style="text-decoration:none;" title="Logout" href="Login.aspx"><i class="fa fa-power-off"></i> </a></div>--%>
                <div style="float:right;"  class="w3-dropdown-hover ">
                    <a href="#" onclick="if(document.getElementById('rightMenu').style.display=='none')
                        {
                        document.getElementById('rightMenu').style.display='block';
                        document.getElementById('overlay').style.display='block';
                        document.getElementById('search_btn').style.display='none';
                        }else if(document.getElementById('rightMenu').style.display=='block')
                        {
                        document.getElementById('rightMenu').style.display='none';
                        document.getElementById('overlay').style.display='none';
                        document.getElementById('search_btn').style.display='block';
                        }" class="w3-button  w3-hover-text-black w3-hover-white" style="height:51px; padding-top:12px;"><i  class="fa fa-cog w3-xlarge"></i> <i class="fa fa-caret-down"></i></a>
                      
                    <div id="rightMenu" class="w3-dropdown-content w3-bar-block w3-card-4" style="right:0; display:none; z-index:5;">
                      <%--<a href="dashboard.aspx" style="text-decoration:none;" class="w3-bar-item w3-button w3-medium">View Dashboard</a>--%>
                       <a href="ResetPass.aspx" style="text-decoration:none;" class="w3-bar-item w3-button w3-medium">Change Password</a>
                       <a href="Details.aspx" style="text-decoration:none;" class="w3-bar-item w3-button w3-medium">Register New Patient</a>
                       <a href="upload_id.aspx" id="upload_mail" visible="false" runat="server" style="text-decoration:none;" class="w3-bar-item w3-button w3-medium">Upload Email Ids</a>
                       <a href="add_surgeon.aspx" id="surg"  runat="server" style="text-decoration:none;" class="w3-bar-item w3-button w3-medium">Add Surgeon</a>
                       <a href="Login.aspx" style="text-decoration:none;" class="w3-bar-item w3-button w3-medium">Logout</a>
                    </div>
                </div>
                    
                <div class="w3-bar-item  w3-large " style="float:right; padding-top:12px;"><i class="fa fa-user-circle w3-xlarge"></i> <asp:Label ID="l_user" Text="" runat="server" /></div>
            </div>
            <div id="overlay" class="w3-overlay" onclick="document.getElementById('rightMenu').style.display='none';
                document.getElementById('overlay').style.display='none';
                document.getElementById('search_btn').style.display='block';" style="cursor:pointer">
            </div>
        </div>        

        <div class="w3-container w3-padding-small " style="margin-top:60px;"> 
                <div class=" w3-border  w3-round-large cd4_grid" style="height:97vh; background-color:#506D84;" >
             
                    <div id="first_bar" runat="server" class="w3-bar w3-white " style="width:100%;">
                    <a href="#" class="w3-bar-item w3-button w3-xlarge w3-hide-large" onclick="if(document.getElementById('leftMenu').style.display=='none'){document.getElementById('leftMenu').style.display='block';document.getElementById('overlay2').style.display='block';}else if(document.getElementById('leftMenu').style.display=='block'){document.getElementById('leftMenu').style.display='none';document.getElementById('overlay2').style.display='none';}"><i class="fa fa-bars"></i></a>
                    
                    <asp:LinkButton ID="all" Text="All" ForeColor="#9EB23B"  OnClick="all_click" CssClass="w3-bar-item lb w3-hide-small   w3-padding-large"  runat="server" />
                    <asp:LinkButton ID="acad" Text="Academic" ForeColor="#166D89"  OnClick="acad_click" CssClass="w3-bar-item lb w3-hide-small  w3-padding-large " runat="server" />
                    <asp:LinkButton ID="op" Text="Operative" ForeColor="#166D89"  OnClick="op_click" CssClass="w3-bar-item lb w3-hide-small  w3-padding-large " runat="server" />
                    <asp:LinkButton ID="Exam" Text="Exam Cases" ForeColor="#166D89" OnClick="exam_click" CssClass="w3-bar-item lb w3-hide-small   w3-padding-large " runat="server" />
                    <asp:LinkButton ID="conf" Text="Conference Cases" ForeColor="#166D89"  OnClick="conf_click" CssClass="w3-bar-item lb w3-hide-small   w3-padding-large " runat="server" />
                   
                    <asp:DropDownList ID="other_label" ForeColor="#166D89"  AutoPostBack="true" OnSelectedIndexChanged="label_selected" Width="15%" CssClass="w3-bar-item lb w3-hide-small w3-input w3-round-xxlarge w3-border  search_box" runat="server">
                     
                    </asp:DropDownList>
                   
                    <div style="float:right;"  class="w3-dropdown-hover w3-right ">
                        <a href="#" onclick="if(document.getElementById('rightMenu2').style.display=='none')
                            {
                            document.getElementById('rightMenu2').style.display='block';
                            document.getElementById('overlay3').style.display='block';
                            }else if(document.getElementById('rightMenu2').style.display=='block')
                            {
                            document.getElementById('rightMenu2').style.display='none';
                            document.getElementById('overlay3').style.display='none';
                            }" class="w3-button  w3-hover-text-black w3-hover-white" style="height:51px; padding-top:12px;"><i  class="fa fa-ellipsis-v"></i></a>
                      
                        <div id="rightMenu2" class="w3-dropdown-content w3-bar-block w3-card-4" style="right:0; display:none; z-index:5;">
                           <span style="text-decoration:none;" onclick="document.getElementById('id01').style.display='block';document.getElementById('rightMenu2').style.display='none';" class="w3-bar-item w3-button w3-medium">Create Label</span>
                           <span style="text-decoration:none;"  onclick="document.getElementById('id02').style.display='block';document.getElementById('rightMenu2').style.display='none';" class="w3-bar-item w3-button w3-medium">Rename Label</span>
                           <span style="text-decoration:none;" onclick="document.getElementById('id02').style.display='block';document.getElementById('rightMenu2').style.display='none';" class="w3-bar-item w3-button w3-medium">Delete Label</span>
                        </div>
                    </div>

                    <div id="id01" class="w3-modal" >
                        <div class="w3-modal-content w3-card-2">
                          <header class="w3-container "> 
                            <span onclick="document.getElementById('id01').style.display='none'; document.getElementById('overlay3').style.display='none';" 
                            class="w3-button w3-display-topright">&times;</span>
                            <h2>Create Label</h2>
                          </header>
                          <%--  <asp:UpdatePanel runat="server">
                                <ContentTemplate>--%>
                                     <div class="w3-container w3-light-grey">
                                          <div class="w3-row w3-margin-top w3-margin-bottom">
                                              <div class="w3-col s9 w3-padding-small">
                                                  <asp:TextBox ID="tb_l_name" CssClass="w3-input w3-round-large w3-border" runat="server" />
                                              </div>
                                              <div class="w3-col s3 w3-padding-small">
                                                  <asp:Button ID="Button1" OnClick="create_label" CssClass="w3-white w3-btn w3-round-large" Width="100%" runat="server" Text="Add" />
                                              </div>
                                          </div>
                                          <div class="w3-row w3-margin-top w3-center">
                                              <asp:Label ForeColor="Green" Text="" ID="label_msg" runat="server" />
                                          </div>
                                      </div>
                              <%--</ContentTemplate>
                            </asp:UpdatePanel> --%>
                        </div>
                      </div>

                    <div id="id02" class="w3-modal" >
                        <div class="w3-modal-content w3-card-2">
                          <header class="w3-container "> 
                            <span onclick="document.getElementById('id02').style.display='none'; document.getElementById('overlay3').style.display='none';" 
                            class="w3-button w3-display-topright">&times;</span>
                          </header>
                           <%-- <asp:UpdatePanel runat="server">
                                <ContentTemplate>--%>
                                <asp:GridView ID="modal_gv" OnRowCommand="gv1_rowCommand" OnRowDataBound="gv1_rowdatabound" runat="server" Width="100%"  GridLines="None" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:TemplateField>
                                        <ItemTemplate>
                                        <div class="w3-row w3-border-bottom w3-border-dark-gray " style="font-size:18px;">
                                            <div class="w3-col s9 ">
                                                <asp:Label ID="issue" style="color:gray;" runat="server" ><%#Eval("l_name") %></asp:Label>
                                                <asp:TextBox ID="rename_box" Visible="false" CssClass="w3-input w3-border w3-round-large" runat="server" />
                                            </div>
                                                <div class="w3-col s1 w3-right">
                                                <asp:LinkButton CommandName="delete_label"  runat="server" ><i class="fa fa-trash" style="font-size:24px"></i></asp:LinkButton>
                                                </div>
                                            <div class="w3-col s1 w3-right">
                                                <asp:LinkButton CommandName="edit"  runat="server" ><i class="fa fa-edit" style="font-size:24px"></i></asp:LinkButton>
                                                        
                                            </div>
                                        </div>
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <%--</ContentTemplate>
                            </asp:UpdatePanel> --%>
                        </div>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             
                      </div>

                    <asp:TextBox placeholder="Search UHID..." CssClass="w3-right w3-hide-large  lb w3-input w3-round-xxlarge w3-border  search_box" Height="35px" Width="75%" runat="server" />
                    <asp:TextBox Width="20%" placeholder="Search UHID..." CssClass="w3-right w3-bar-item lb w3-hide-small w3-input w3-round-xxlarge w3-border  search_box" Height="35px" runat="server" />
                    
                    <div id="overlay2" class="w3-overlay" onclick="document.getElementById('leftMenu').style.display='none';document.getElementById('overlay2').style.display='none'" style="cursor:pointer">

                    </div>
                     <d id="overlay3" class="w3-overlay" onclick="document.getElementById('rightMenu2').style.display='none';
                        document.getElementById('overlay3').style.display='none';
                      " style="cursor:pointer">
                    </div>

                      <div id="second_bar" runat="server"  class="w3-bar w3-white " style="display:none; padding:10px;">
                        <div class="w3-bar-item">Label as </div>
                        <asp:DropDownList ID="ddl_label" CssClass=" w3-bar-item w3-white w3-text-blue-gray w3-input w3-round-xxlarge w3-border " runat="server">
                                <asp:ListItem Text="All" Value="" />
                                <asp:ListItem Text="Academic" Value="Academic" />
                                <asp:ListItem Text="Operative" Value="Operative" />
                                <asp:ListItem Text="Exam Cases" Value="Exam Cases" />
                                <asp:ListItem Text="Conference Cases" Value="Conference Cases" />
                        </asp:DropDownList>
                        <asp:Button Text="Save" OnClick="tag_as" CssClass="w3-bar-item w3-button w3-blue-gray w3-text-white w3-round-xlarge" runat="server" />
                  
                    </div>

                <div style="padding:10px;">
                    <asp:gridview ID="gv2" CssClass="w3-white" runat="server" Width="100%" AutoGenerateColumns="False" OnRowDeleting="OnRowDeleting" OnRowDataBound = "OnRowDataBound" ViewStateMode="Enabled" ShowHeaderWhenEmpty="True" AllowSorting="True"  >
                        <Columns>
                            <asp:TemplateField>
                                 <ItemTemplate>
                                <asp:CheckBox ID="chkchild" runat="server"/>
                                </ItemTemplate>
                                <HeaderTemplate>
                                <asp:CheckBox ID="chkheader" runat="server" onclick="javascript:SelectheaderCheckboxes(this)" />
                                </HeaderTemplate>
                               
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Name" DataField="name" />
                            <asp:BoundField DataField="uhid" HeaderText="UHID"  />
                            <asp:BoundField DataField="age_sex" HeaderText="Age/Sex" />
                            <asp:BoundField DataField="diagnosis" HeaderText="Diagnosis"  />
                           <%-- <asp:BoundField DataField="surg_date" HeaderText="Surgery Date" />
                            <asp:BoundField DataField="surg_name" HeaderText="Surgery Name"  />
                            <asp:BoundField DataField="discharge_status" HeaderText="Discharge Status"  />--%>
                            <asp:CommandField Visible="false" ShowDeleteButton="True" ControlStyle-CssClass="w3-btn w3-round-xxlarge w3-red bttn" ButtonType="Button" />
                        </Columns>
                        <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                    </asp:gridview> 
                </div>
             
              
                </div>
                

            </div>
        
        
    </form>
</body>
</html>
