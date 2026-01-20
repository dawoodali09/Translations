<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="TranslationKeys.aspx.cs" Inherits="Translations.TranslationKeys" ValidateRequest="false" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="wrapper row3">
        <div id="container">
   
    <div id="divAddEdit" runat="server"  class="sidebar one_quarter first" style="width: 100%; text-align: center;">      
        <aside>
                    <div class="nav_bg">
                        <h2 class="fl_left">Translation Key</h2>
                    </div>
        <div class="form_wraper_trs">
            
            <asp:Label runat="server" class="form_wraper_trs-trans2-label">Key</asp:Label>
               
            <div class="inputprop">
                <asp:TextBox runat="server" ID="txtKey" CssClass="form_wraper_trs-trans2-dd"></asp:TextBox>
                <asp:RequiredFieldValidator Style="width:130px;position:absolute; text-indent:-16px;" ValidationGroup="validateDetails" ControlToValidate="txtKey" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter key"  Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="form_wraper_trs">
           
            <asp:Label runat="server" class="form_wraper_trs-trankey-la_eng">English Text</asp:Label>
                
            <div class="inputprop">
                <asp:TextBox runat="server" ID="txtEnglishText" CssClass="form_wraper_trs-trans2-text" TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Style="width:160px;position:absolute; text-indent:-96px;" ValidationGroup="validateDetails" ControlToValidate="txtEnglishText" runat="server" ErrorMessage="Please enter English text"  Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
        </div>

         <div class="form_wraper_trs">
               
            <asp:Label runat="server" class="form_wraper_trs-trankey-la_com">Comments</asp:Label>
                   
            <div class="inputprop">
                <asp:TextBox runat="server" ID="txtComments" CssClass="form_wraper_trs-trans2-text" TextMode="MultiLine"></asp:TextBox>
            </div>
        </div>    
        
        <div class="form_wraper_trs">
            
                        <asp:Label runat="server" class="form_wraper_trs-trankey-la_ac">Active</asp:Label>
               
                        <div class="inputprop-key">
                            <asp:CheckBox ID="chkbxActive" runat="server" Checked="true" />
                        </div>
                    </div>   
      
         <div class="clear"></div>
        <div class="form_wraper_trs">
            <asp:Button ID="btnAdd" CssClass="button_add" runat="server" Text="Add" OnClick="btnAdd_Click" ValidationGroup="validateDetails"/>
            <asp:Button ID="btnCancel" CssClass="button_add" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
             <div id="diverror" runat="server" visible="false" style="color:red">

                <strong>Error!</strong> This key has already been used.
            </div>
              <div style="padding-bottom:20px;"></div>
        </div>

</aside>
    </div>
</div>
 </div>

    <div class="five_sixth sidebar_right" id="divTranslators" runat="server">
          <aside>
              <div id="divSearch" runat="server">
                  <table>
                      <tr>
                          <td>
                              <label class="first" for="author" style="margin-top:8px; font-size:14px; ">Search by:</label>   <asp:DropDownList ID="ddlSearchBy" runat="server" class="dropdown_pro" style="width:46%; margin-top:0px;">
                      <asp:ListItem Value="1">Key</asp:ListItem>
                      <asp:ListItem Value="2">English Text</asp:ListItem>
                  </asp:DropDownList>
                          </td>
                          <td>
                               <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
                          </td>
                          <td>
                              <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="button_add" />
                          </td>
                           <td>
                              <asp:Button ID="btnViewAll" runat="server" Text="View All" CssClass="button_add" OnClick="btnViewAll_Click"/>
                          </td>
                      </tr>
                  </table>
                

              </div>
             <div id="divKeys" runat="server" style="float: left; margin: 0; width: 100%;">
                   <div class="nav_bg" style="width:100%;">
                        <h2 class="fl_left">Translation Key</h2>
                        <asp:LinkButton ID="btnAddNew" CssClass="button_add" Style=" color:#fff; float:right;" runat="server" OnClick="btnAddNew_Click"> Add</asp:LinkButton>
                       </div>
     <div style="float: left; margin:0; text-align:center; width:100%">
        <asp:GridView ID="gvKeys" runat="server" AutoGenerateColumns="False" AllowPaging="true" PageSize="20" OnPageIndexChanging="gvKeys_PageIndexChanging" 
            OnRowCommand="gv_RowCommand" CellPadding="4" ForeColor="Black" GridLines="Horizontal" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
            <FooterStyle BackColor="#CCCC99" ForeColor="Black"></FooterStyle>
                             <RowStyle CssClass="DataRow" />
                            <HeaderStyle BackColor="#3591cd" Font-Bold="True" ForeColor="White" HorizontalAlign="Left"></HeaderStyle>

                            <PagerStyle HorizontalAlign="Right" BackColor="White" ForeColor="Black"></PagerStyle>

                            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" CssClass="yellow"></SelectedRowStyle>

                            <SortedAscendingCellStyle BackColor="#F7F7F7"></SortedAscendingCellStyle>

                            <SortedAscendingHeaderStyle BackColor="#4B4B4B"></SortedAscendingHeaderStyle>

                            <SortedDescendingCellStyle BackColor="#E5E5E5" ></SortedDescendingCellStyle>

                            <SortedDescendingHeaderStyle BackColor="#242121" CssClass="GridHeader" ></SortedDescendingHeaderStyle>
            <PagerSettings Mode="NumericFirstLast" PageButtonCount="10"  FirstPageText="First" LastPageText="Last" />
            <Columns>
                <asp:BoundField DataField="Key" HeaderText="Key">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>

                <asp:TemplateField HeaderText="English Text">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                    <ItemTemplate>
                        <%# Eval("EnglishValue") != null ? GetEngTranslation(Eval("EnglishValue").ToString()) : "" %>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="Translator.FirstName" HeaderText="Added By">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>

                <asp:TemplateField HeaderText="Edit">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                    <ItemTemplate>
                        <asp:LinkButton ID="lbtEdit" CssClass="btn btn-primary" runat="server" CommandName="editrecord" Text="Edit" CommandArgument='<%#Eval("Id").ToString() %>'></asp:LinkButton>
                        <asp:LinkButton ID="lbtnDelete" CssClass="btn btn-danger" runat="server" CommandName="deleterecord" OnClientClick="if (!confirm('Are you sure you want delete?')) return false;" Text="Delete" CommandArgument='<%#Eval("Id").ToString() %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>


        </asp:GridView>
    </div>
                 </div>
              </aside>
        </div>
</asp:Content>

