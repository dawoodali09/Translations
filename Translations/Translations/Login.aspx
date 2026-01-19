<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Translations.Login"  ValidateRequest="false"%>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CIB Translation System.</title>
    <link href="css/main.css" rel="stylesheet" type="text/css" media="all" />
     <link rel="stylesheet" href="css/newstyle.css" type="text/css">
<link href="css/mediaqueries.css" rel="stylesheet" type="text/css" media="all" />
</head>
<body>
    <div class="wrapper6 row3" >
        <div id="container">
            <!-- ################################################################################################ -->
            <div class="responsive-container">
                <div class="dummy"></div>

                <div class="img-container" style="background-color:#eee;">
                    <div class="login_box">
                        <%--<img src="images/logos.png" alt="Logo" />--%>
                        <img src="images/OnlyLogo.png" style="margin-top:5px;" /> 
                        <br /><b>CIB Group Translation System</b>
                       
                        <hr color="#999999" />
                        <center>
                        <form id="form1" class="rnd5" runat="server">

                            <div class="form_wraper" >                             
                                <br />
                                   <div id="diverror" runat="server" visible="false" style="color: red">
                                    <strong> Invalid Username Or Password.</strong>
                                </div>


                                <div style="margin-left:20px;">
                                <label class="first" for="author" >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="*">*</asp:RequiredFieldValidator>&nbsp;&nbsp;&nbsp;&nbsp;Email&nbsp;&nbsp;&nbsp;</label>
                                <div style="float:left;"><asp:TextBox ID="txtEmail" runat="server"  ClientIDMode="Static" Width="250px"  ></asp:TextBox>                                                                </div>
                               </div>                               
                                                   
                              <div style="margin-left:20px;">
                                  <label class="first" for="author" >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword" ErrorMessage="*">*</asp:RequiredFieldValidator>Password</label>
                                <div style="float:left;">
                                    <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" ClientIDMode="Static" Width="250px" ></asp:TextBox>
                                </div>
                                  </div>



                            </div>
                                 <div class="clear"></div>    
                            <div class="form_btn">
                                <asp:Button ID="btnLogin" Text="Login" runat="server" Style="width:100px;" class="Button_add" OnClick="btnLogin_Click" />                                
                            </div>
                         
                        </form>
                            </center>
                        <div class="clear"></div>
                         <div id="footer" style="height: 2em; position: relative; z-index: 1; vertical-align:bottom; ">
                            <b>© All Rights Reserved CIB Finance </b>
                        </div>

                    </div>
                </div>
            </div>
        </div>
        
    </div>
   

    <!-- Scripts -->
    <script src="http://code.jquery.com/jquery-latest.min.js"></script>
    <script src="http://code.jquery.com/ui/1.10.1/jquery-ui.min.js"></script>
    <script>window.jQuery || document.write('<script src="js/jquery-latest.min.js"><\/script>\
<script src="js/jquery-ui.min.js"><\/script>')</script>
    <script>jQuery(document).ready(function ($) { $('img').removeAttr('width height'); });</script>
    <script src="js/jquery-mobilemenu.min.js"></script>
    <script src="js/custom.js"></script>
</body>
</html>
