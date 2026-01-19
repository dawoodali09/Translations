<%@ Page Title="languages" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Languages.aspx.cs" Inherits="Translations.Languages" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="five_sixth sidebar_right" runat="server">
          <aside>
              
             <div id="divLanguages" runat="server" style="float: left; margin:1px 3px 1px 1px; width:98.5%;">
                   <div class="nav_bg" style="width:100%;">
                        <h2 class="fl_left">Languages</h2>                       
             </div>
               <div style="float: left; margin:0 20px; text-align:center; width:95%">
                  <asp:GridView ID="gvLanguages" runat="server" AutoGenerateColumns="False" CellPadding="4" AllowPaging="true" PageSize="20" 
                      OnPageIndexChanging="gvCountries_PageIndexChanging" ForeColor="Black" GridLines="Horizontal" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" 
                      BorderWidth="1px">
                     <RowStyle CssClass="DataRow" />
                        <FooterStyle BackColor="#3591cd" ForeColor="Black"></FooterStyle>

                            <HeaderStyle BackColor="#3591cd" Font-Bold="True" ForeColor="White"></HeaderStyle>

                            <PagerStyle HorizontalAlign="Right" BackColor="White" ForeColor="Black"></PagerStyle>

                            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" CssClass="yellow"></SelectedRowStyle>

                            <SortedAscendingCellStyle BackColor="#F7F7F7"></SortedAscendingCellStyle>

                            <SortedAscendingHeaderStyle BackColor="#4B4B4B"></SortedAscendingHeaderStyle>

                            <SortedDescendingCellStyle BackColor="#E5E5E5" ></SortedDescendingCellStyle>

                            <SortedDescendingHeaderStyle BackColor="#242121" CssClass="GridHeader" ></SortedDescendingHeaderStyle>
                      <PagerSettings Mode="NumericFirstLast" PageButtonCount="10"  FirstPageText="First" LastPageText="Last" />
                      <Columns>                                                  
                          <%--<asp:BoundField DataField="Id" HeaderText="Id" />--%>
                          <asp:BoundField DataField="Name" HeaderText="Name" />
                          <asp:BoundField DataField="NativeName" HeaderText="Native Name" />
                          <asp:BoundField DataField="Note" HeaderText="Note" />
                          <asp:BoundField DataField="Code" HeaderText="Code" />
                          <%--<asp:BoundField DataField="Active" HeaderText="Active" />
                          <asp:BoundField DataField="Created" HeaderText="Created" /> --%>                         
                      </Columns>


                  </asp:GridView>
                   </div>
              </div>
                 
          </aside>
      </div>
</asp:Content>
