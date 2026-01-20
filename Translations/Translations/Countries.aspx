<%@ Page Title="countries" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Countries.aspx.cs" Inherits="Translations.Countries" ValidateRequest="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Add/Edit Form -->
    <div class="wrapper row3">
        <div id="container">
            <div id="divAddEdit" runat="server" class="sidebar one_quarter first" style="width: 100%; text-align: center;" visible="false">
                <aside>
                    <div class="nav_bg">
                        <h2 class="fl_left">Country Form</h2>
                    </div>
                    <div class="form-bg">
                        <div class="form_wraper_trs">
                            <label class="first">Name</label>
                            <div class="inputprop">
                                <asp:TextBox runat="server" ID="txtName" Width="250"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                                    ErrorMessage="Name is required" ValidationGroup="validateCountry" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="form_wraper_trs">
                            <label class="first">ISO Number</label>
                            <div class="inputprop">
                                <asp:TextBox runat="server" ID="txtISONumber" Width="250"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form_wraper_trs">
                            <label class="first">ISO Code</label>
                            <div class="inputprop">
                                <asp:TextBox runat="server" ID="txtISOCode" Width="250" MaxLength="3"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtISOCode"
                                    ErrorMessage="ISO Code is required" ValidationGroup="validateCountry" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="form_wraper_trs">
                            <label class="first">Short Code</label>
                            <div class="inputprop">
                                <asp:TextBox runat="server" ID="txtShortCode" Width="250" MaxLength="3"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form_wraper_trs">
                            <label class="first">Active</label>
                            <div class="inputprop">
                                <asp:CheckBox ID="chkActive" runat="server" Checked="true" />
                            </div>
                        </div>

                        <div class="clear"></div>
                        <div class="form_wraper_trs-btn">
                            <asp:Button ID="btnSave" runat="server" CssClass="button_add" Text="Add" OnClick="btnSave_Click" ValidationGroup="validateCountry" />
                            <asp:Button ID="btnCancel" runat="server" CssClass="button_add" Text="Cancel" OnClick="btnCancel_Click" CausesValidation="false" />
                            <div id="diverror" runat="server" visible="false" style="color: red; margin-top: 10px;">
                                <strong>Error!</strong> A country with this name already exists.
                            </div>
                        </div>
                    </div>
                </aside>
            </div>
        </div>
    </div>

    <!-- Countries Grid -->
    <div class="five_sixth sidebar_right" id="divCountries" runat="server">
        <aside>
            <div style="float: left; margin:1px 3px 1px 1px; width:98.5%;">
                <div class="nav_bg" style="width:100%;">
                    <h2 class="fl_left">Countries</h2>
                    <asp:LinkButton ID="btnAddNew" runat="server" CssClass="button_add" Style="color:#fff; float:right;" OnClick="btnAddNew_Click">Add</asp:LinkButton>
                </div>
                <div style="float: left; margin:0 20px; text-align:center; width:95%">
                    <asp:GridView ID="gvCountries" runat="server" AutoGenerateColumns="False" AllowPaging="true" PageSize="20"
                        CellPadding="4" ForeColor="Black" GridLines="Horizontal" BackColor="White" BorderColor="#CCCCCC"
                        BorderStyle="None" BorderWidth="1px" OnPageIndexChanging="gvCountries_PageIndexChanging" OnRowCommand="gvCountries_RowCommand">
                        <RowStyle CssClass="DataRow" />
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black"></FooterStyle>
                        <HeaderStyle BackColor="#3591cd" Font-Bold="True" ForeColor="White"></HeaderStyle>
                        <PagerStyle HorizontalAlign="Right" BackColor="White" ForeColor="Black"></PagerStyle>
                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" CssClass="yellow"></SelectedRowStyle>
                        <SortedAscendingCellStyle BackColor="#F7F7F7"></SortedAscendingCellStyle>
                        <SortedAscendingHeaderStyle BackColor="#4B4B4B"></SortedAscendingHeaderStyle>
                        <SortedDescendingCellStyle BackColor="#E5E5E5"></SortedDescendingCellStyle>
                        <SortedDescendingHeaderStyle BackColor="#242121" CssClass="GridHeader"></SortedDescendingHeaderStyle>
                        <PagerSettings Mode="NumericFirstLast" PageButtonCount="10" FirstPageText="First" LastPageText="Last" />
                        <Columns>
                            <asp:BoundField DataField="Name" HeaderText="Name" />
                            <asp:BoundField DataField="ISONumber" HeaderText="ISO Number" />
                            <asp:BoundField DataField="ISOCode" HeaderText="ISO Code" />
                            <asp:BoundField DataField="ShortCode" HeaderText="Short Code" />
                            <asp:TemplateField HeaderText="Active">
                                <ItemTemplate>
                                    <%# (bool)Eval("Active") ? "Yes" : "No" %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Actions">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtEdit" CssClass="btn btn-primary" runat="server" CommandName="editrecord"
                                        Text="Edit" CommandArgument='<%#Eval("Id").ToString() %>'></asp:LinkButton>
                                    <asp:LinkButton ID="lbtnDelete" CssClass="btn btn-danger" runat="server" CommandName="deleterecord"
                                        OnClientClick="if (!confirm('Are you sure you want to delete this country?')) return false;"
                                        Text="Delete" CommandArgument='<%#Eval("Id").ToString() %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </aside>
    </div>
</asp:Content>
