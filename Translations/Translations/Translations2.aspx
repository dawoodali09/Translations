<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Translations2.aspx.cs" Inherits="Translations.Translations2" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
    
  <div class="wrapper row3">
        <div id="container">
            <div class="sidebar one_quarter first" style="width: 100%; text-align: center;">
            <aside>
                <div class="nav_bg">
                    <h2 class="fl_left">Translation Update</h2>

                </div>
<div>
                <div class="form_wraper_trs-trans2">
                   
                            <asp:Label runat="server" class="form_wraper_trs-trans2-label">Key</asp:Label>
                        <div class="inputprop">
                            <asp:DropDownList ID="ddlPendingKeys" CssClass="dropdown_pro" runat="server" OnSelectedIndexChanged="ddl_selectIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </div>
                    </div>
                    
                     <div class="form_wraper_trs-trans2">
                            <asp:Label runat="server" class="form_wraper_trs-trans2-label">Language</asp:Label>

                     
                      <div class="inputprop">
                            <asp:DropDownList ID="ddlLangauges" runat="server" CssClass="dropdown_pro" OnSelectedIndexChanged="ddlLanguages_selectIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </div>
                    </div>
                     <div class="form_wraper_trs-trans2">
                            <asp:Label runat="server" class="form_wraper_trs-trans2-label">English</asp:Label>
                          <div class="inputprop-lit">
                      <asp:Literal ID="txtEnglish" runat="server" ></asp:Literal>
                          <%--  <asp:TextBox runat="server" ID="txtEnglish"  CssClass="form_wraper_trs-trans2-dd" Enabled="false" TextMode="MultiLine"></asp:TextBox>--%>
                        </div>
                    </div>

    </div>
                <div class="clear"></div>
                <div>
                    <div class="form_wraper_trs-trans2">
                            <asp:Label runat="server" class="form_wraper_trs-trankey-label-tra">Translation</asp:Label>
                       
                       <div class="inputprop">
                            <asp:TextBox runat="server" ID="txtTranslation" CssClass="form_wraper_trs-trans2-text" TextMode="MultiLine"></asp:TextBox>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTranslation" Style="width:230px;position:absolute; text-indent:16px; margin-top:65px;" ValidationGroup="validateDetails" ErrorMessage="Translation Required" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                   <div class="form_wraper_trs-trans2">
                            <asp:Label runat="server" class="form_wraper_trs-trans2-label-com">Comments</asp:Label>
                       
                        <div class="inputprop">
                            <asp:TextBox runat="server" ID="txtComments" CssClass="form_wraper_trs-trans2-text" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>
                   <div class="form_wraper_trs-trans2">
                            <asp:Label runat="server" class="form_wraper_trs-trans2-label-act">Active</asp:Label>
                       <div class="inputprop">
                            <asp:CheckBox runat="server" CssClass="form_wraper_trs-trans2-dd" ID="cbActive" Checked="true"></asp:CheckBox>
                        </div>
                    </div>
                     <div class="clear">&nbsp;</div>
        <div class="form_wraper_trs" style="margin-bottom:20px;">
                        <asp:Button ID="btnInsert" Text="Insert" runat="server" CssClass="button_add" OnClick="btnInsert_Click"  ValidationGroup="validateDetails" />
                     <asp:Button ID="btnCancel" Text="Cancel" runat="server" CssClass="button_add" OnClick="btnCancel_Click" />
                    </div>
                    <div id="divsuccess" runat="server" visible="false" style="color: green">

                        <strong>Success!</strong> The key has been updated.
                    </div>
               </div>
            </aside>
                </div>
         </div>
      </div>
</asp:Content>
