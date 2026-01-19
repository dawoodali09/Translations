<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="CountryLanguages.aspx.cs" Inherits="Translations.CountryLanguages" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
    
    <div class="wrapper row3">
        <div id="container">
            <div id="divAddEdit" runat="server" class="sidebar one_quarter first" style="width: 100%; text-align: center;">
                <aside>
                    <div class="nav_bg">
                        <h2 class="fl_left">Country Languages Form</h2>
                    </div>
                    <div class="form-bg">
                        <div class="form_wraper_trs">
                            <div class="countryLang_lable-ti">
                                <asp:Label runat="server" CssClass="first">Title</asp:Label></div>
                            <div class="inputprop">
                                <asp:TextBox runat="server" ID="txtTitle" Width="210"></asp:TextBox>
                               <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Style="width:130px;position:absolute;" runat="server" ErrorMessage="Please enter title" ValidationGroup="validateDetails" ControlToValidate="txtTitle"  ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                             <asp:RequiredFieldValidator  ID="RequiredFieldValidator1" Style="width:130px;position:absolute;" ValidationGroup="validateDetails" ControlToValidate="txtTitle" runat="server" ErrorMessage="Please enter title" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="form_wraper_trs">
                            <div class="countryLang_lable-co">
                                <asp:Label runat="server" CssClass="first">Country</asp:Label>
                            </div>
                            <div class="inputprop">
                                <asp:DropDownList ID="ddlCountries" runat="server" CssClass="dropdown_pro2" Width="210"></asp:DropDownList>
                            </div>
                        </div>

                        <div class="form_wraper_trs">
                            <div class="countryLang_lable-lan">
                                <asp:Label runat="server" CssClass="first">Language</asp:Label></div>
                            <div class="inputprop">
                                <asp:DropDownList ID="ddlLanguage" runat="server" CssClass="dropdown_pro2" Width="210"></asp:DropDownList>
                            </div>
                        </div>

                        <div class="form_wraper_trs">
                            <div class="countryLang_lable-no">
                                <asp:Label runat="server" CssClass="first">Note</asp:Label></div>
                            <div class="inputprop">
                                <asp:TextBox runat="server" ID="txtNote" Width="210"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form_wraper_trs">
                            <div class="countryLang_lable-ac">
                                <asp:Label runat="server" CssClass="first">Active</asp:Label></div>
                            <div class="inputprop">
                                <asp:CheckBox ID="chkbxActive" runat="server" Checked="true" />
                            </div>
                        </div>

                        <div class="clear"></div>
                        <div class="form_wraper_trs-btn">
                            <asp:Button ID="btnAdd" runat="server" CssClass="button_add" Text="Add" OnClick="btnAdd_Click" ValidationGroup="validateDetails"/>
                            <asp:Button ID="btnCancel" runat="server" CssClass="button_add" Text="Cancel" OnClick="btnCancel_Click" />
                            <div id="diverror" runat="server" visible="false" style="color: red">

                                <strong>Error!</strong> This country and language combination already exists.
                            </div>
                        </div>
                    </div>
                </aside>
            </div>

        </div>

    </div>
  

      <div class="five_sixth sidebar_right" id="divTranslators" runat="server">
          <aside>
              
             <div id="divCountryLanguages" runat="server" style="float: left; margin:1px 3px 1px 1px; width:98.5%;">
                   <div class="nav_bg" style="width:100%;">
                        <h2 class="fl_left">Country Languages</h2>
                       <asp:LinkButton ID="btnAddNew" runat="server" CssClass="button_add" Style=" color:#fff; float:right;"  OnClick="btnAddNew_Click">Add</asp:LinkButton>
             </div>
               <div style="float: left; margin:0 20px; text-align:center; width:95%">
                  <asp:GridView ID="gvKeys" runat="server" AutoGenerateColumns="False" OnRowCommand="gv_RowCommand" CellPadding="4" ForeColor="Black" GridLines="Horizontal" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                      <RowStyle CssClass="DataRow" /> 
                      <FooterStyle BackColor="#CCCC99" ForeColor="Black"></FooterStyle>

                            <HeaderStyle BackColor="#3591cd" Font-Bold="True" ForeColor="White"></HeaderStyle>

                            <PagerStyle HorizontalAlign="Right" BackColor="White" ForeColor="Black"></PagerStyle>

                            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" CssClass="yellow"></SelectedRowStyle>

                            <SortedAscendingCellStyle BackColor="#F7F7F7"></SortedAscendingCellStyle>

                            <SortedAscendingHeaderStyle BackColor="#4B4B4B"></SortedAscendingHeaderStyle>

                            <SortedDescendingCellStyle BackColor="#E5E5E5" ></SortedDescendingCellStyle>

                            <SortedDescendingHeaderStyle BackColor="#242121" CssClass="GridHeader" ></SortedDescendingHeaderStyle>
                      <Columns>
                          <%--<asp:BoundField DataField="Id" HeaderText="Id" />--%>
                          <asp:BoundField DataField="Title" HeaderText="Title" />
                          <asp:BoundField DataField="Country.Name" HeaderText="Country" />
                          <asp:BoundField DataField="Language.Name" HeaderText="Language" />
                         <%-- <asp:BoundField DataField="Note" HeaderText="Note" />
                          <asp:BoundField DataField="Active" HeaderText="Active" />
                          <asp:BoundField DataField="Created" HeaderText="Created" />--%>
                          <asp:TemplateField HeaderText="Edit / Delete">
                              <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" />
                              <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                              <ItemTemplate>
                                  <asp:LinkButton ID="lbtEdit"  runat="server" CommandName="editrecord" Text="Edit" CommandArgument='<%#Eval("Id").ToString() %>'></asp:LinkButton>
                                  <asp:LinkButton ID="lbtnDelete"  runat="server" CommandName="deleterecord"  OnClientClick="if (!confirm('Are you sure you want delete?')) return false;" Text="Delete" CommandArgument='<%#Eval("Id").ToString() %>'></asp:LinkButton>

                              </ItemTemplate>
                          </asp:TemplateField>
                      </Columns>


                  </asp:GridView>
                   
                   </div>
              </div>
                 
          </aside>
      </div>


</asp:Content>
