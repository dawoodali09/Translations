<%@ Page Title="countries" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Countries.aspx.cs" Inherits="Translations.Countries"  ValidateRequest="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
     <div class="five_sixth sidebar_right" runat="server">
          <aside>
              
             <div id="divCountries" runat="server" style="float: left; margin:1px 3px 1px 1px; width:98.5%;">
                   <div class="nav_bg" style="width:100%;">
                        <h2 class="fl_left">Countries</h2>                       
             </div>
               <div style="float: left; margin:0 20px; text-align:center; width:95%">
                  <asp:GridView ID="gvCountries" runat="server" AutoGenerateColumns="False" AllowPaging="true" PageSize="20"  CellPadding="4" ForeColor="Black" GridLines="Horizontal" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" OnPageIndexChanging="gvCountries_PageIndexChanging">
                       <RowStyle CssClass="DataRow" />
                       <FooterStyle BackColor="#CCCC99" ForeColor="Black"></FooterStyle>

                            <HeaderStyle BackColor="#3591cd" Font-Bold="True" ForeColor="White"></HeaderStyle>

                            <PagerStyle HorizontalAlign="Right" BackColor="White" ForeColor="Black"></PagerStyle>

                            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" CssClass="yellow"></SelectedRowStyle>

                            <SortedAscendingCellStyle BackColor="#F7F7F7"></SortedAscendingCellStyle>

                            <SortedAscendingHeaderStyle BackColor="#4B4B4B"></SortedAscendingHeaderStyle>

                            <SortedDescendingCellStyle BackColor="#E5E5E5" ></SortedDescendingCellStyle>

                            <SortedDescendingHeaderStyle BackColor="#242121" CssClass="GridHeader" ></SortedDescendingHeaderStyle>
            <PagerSettings Mode="NumericFirstLast" PageButtonCount="10"  FirstPageText="First" LastPageText="Last" />
                       <%--<PagerSettings Mode="NumericFirstLast" PageButtonCount="10"  FirstPageText="First" LastPageText="Last" />--%>
                      <Columns>                           
                          <%--<asp:BoundField DataField="Id" HeaderText="Id" />--%>
                          <asp:BoundField DataField="Name" HeaderText="Name" />
                          <asp:BoundField DataField="ISONumber" HeaderText="ISO Number" />
                          <asp:BoundField DataField="ISOCode" HeaderText="ISO Code" />
                          <asp:BoundField DataField="ShortCode" HeaderText="Short Code" />
                         <%-- <asp:BoundField DataField="Active" HeaderText="Active" />
                          <asp:BoundField DataField="Created" HeaderText="Created" />--%>                          
                      </Columns>


                  </asp:GridView>
                  
                  
                   </div>
              </div>
                 
          </aside>
      </div>
</asp:Content>
