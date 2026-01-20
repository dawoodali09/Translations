<%@ Page Title="TranslatorCountryLanguages" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="TranslatorCountyLanguage.aspx.cs" Inherits="Translations.TranslatorCountyLanguage" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="wrapper row3">
        <div id="container">
   
    <div id="divAddEdit" runat="server"  class="sidebar one_quarter first" style="width: 100%; text-align: center;">      
        <aside>
                    <div class="nav_bg">
                        <h2 class="fl_left">Translator Languages</h2>
                    </div>
       <div class="form_wraper_trs">
                        <label class="first" for="author" style="margin-top:37px;">Translator</label>
                        <div class="inputprop">
                            <asp:DropDownList ID="ddlTranslator" Width="210" runat="server" class="dropdown_pro">
                            </asp:DropDownList>
                        </div>
                    </div>

            <div class="form_wraper_trs">
                        <label class="first" for="author" style="margin-top:37px;">Country Language</label>
                        <div class="inputprop">
                            <asp:DropDownList ID="ddlCountryLanguage" Width="210" runat="server" class="dropdown_pro">
                            </asp:DropDownList>
                        </div>
                    </div>


         <div class="form_wraper_trs">
              
            <asp:Label runat="server" CssClass="form_wraper_trs-tcl-la_note">Note</asp:Label>
                   
            <div class="inputprop">
                <asp:TextBox runat="server" ID="txtNote" Width="210"></asp:TextBox>
            </div>
        </div>    
        
        <div class="form_wraper_trs">
             
                        <asp:Label runat="server" CssClass="form_wraper_trs-tcl-la_ac">Active</asp:Label>
                  
                        <div class="inputprop">
                            <asp:CheckBox ID="chkbxActive" runat="server" />
                        </div>
                    </div>   
      
         <div class="clear"></div>
        <div class="form_wraper_trs">
            <asp:Button ID="btnAdd" CssClass="button_add" runat="server" Text="Add" OnClick="btnAdd_Click" ValidationGroup="validateDetails"/>
            <asp:Button ID="btnCancel" CssClass="button_add" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
             <div id="diverror" runat="server" visible="false" style="color:red">

                <strong>Error!</strong> This language has already been assigned to this translator.
            </div>
              <div style="padding-bottom:20px;"></div>
        </div>

</aside>
    </div>
</div>
 </div>

     <div class="five_sixth sidebar_right" id="divTranslators" runat="server">
          <aside>
              
              <div id="divTranslatorCountryLanguages" runat="server" style="float: left; margin: 0; width: 100%;">
                  <div class="nav_bg" style="width: 100%;">
                      <h2 class="fl_left">Translator Country Languages</h2>
                      <asp:LinkButton ID="btnAddNew" runat="server" CssClass="button_add" Style="color: #fff; float: right;" OnClick="btnAddNew_Click">Add</asp:LinkButton>
                  </div>
                   <div style="float: left; margin:0; text-align:center; width:100%">
                  <asp:GridView ID="gvTranslatorCountryLanguages" runat="server" AutoGenerateColumns="False" OnRowCommand="gv_RowCommand" CellPadding="4" ForeColor="Black" GridLines="Horizontal" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                      
                       <RowStyle CssClass="DataRow" />
                       <FooterStyle BackColor="#CCCC99" ForeColor="Black"></FooterStyle>

                            <HeaderStyle BackColor="#3591cd" Font-Bold="True" ForeColor="White" HorizontalAlign="Left"></HeaderStyle>

                            <PagerStyle HorizontalAlign="Right" BackColor="White" ForeColor="Black"></PagerStyle>

                            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" CssClass="yellow"></SelectedRowStyle>

                            <SortedAscendingCellStyle BackColor="#F7F7F7"></SortedAscendingCellStyle>

                            <SortedAscendingHeaderStyle BackColor="#4B4B4B"></SortedAscendingHeaderStyle>

                            <SortedDescendingCellStyle BackColor="#E5E5E5" ></SortedDescendingCellStyle>

                            <SortedDescendingHeaderStyle BackColor="#242121" CssClass="GridHeader" ></SortedDescendingHeaderStyle>
                      <Columns>
                          <asp:BoundField DataField="Translator.FirstName" HeaderText="Translator">
                              <HeaderStyle HorizontalAlign="Left" />
                              <ItemStyle HorizontalAlign="Left" />
                          </asp:BoundField>
                          <asp:BoundField DataField="CountryLanguage.Title" HeaderText="Country Language">
                              <HeaderStyle HorizontalAlign="Left" />
                              <ItemStyle HorizontalAlign="Left" />
                          </asp:BoundField>
                          <asp:BoundField DataField="Active" HeaderText="Active">
                              <HeaderStyle HorizontalAlign="Left" />
                              <ItemStyle HorizontalAlign="Left" />
                          </asp:BoundField>
                          <asp:TemplateField HeaderText="Edit">
                              <HeaderStyle HorizontalAlign="Left" />
                              <ItemStyle HorizontalAlign="Left" />
                              <ItemTemplate>
                                  <asp:LinkButton ID="lbtEdit" CssClass="btn btn-primary" runat="server" CommandName="editrecord" Text="Edit" CommandArgument='<%#Eval("Id").ToString() %>'></asp:LinkButton>
                              </ItemTemplate>
                          </asp:TemplateField>
                      </Columns>


                  </asp:GridView>
                       </div>
              </div>
              </aside>
         </div>
</asp:Content>
