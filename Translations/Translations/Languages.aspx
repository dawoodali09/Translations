<%@ Page Title="languages" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Languages.aspx.cs" Inherits="Translations.Languages" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Add/Edit Form -->
    <div class="wrapper row3">
        <div id="container">
            <div id="divAddEdit" runat="server" class="sidebar one_quarter first" style="width: 100%; text-align: center;" visible="false">
                <aside>
                    <div class="nav_bg">
                        <h2 class="fl_left">Language Form</h2>
                    </div>
                    <div class="form-bg">
                        <div class="form_wraper_trs">
                            <label class="first">Name</label>
                            <div class="inputprop">
                                <asp:TextBox runat="server" ID="txtName" Width="250"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                                    ErrorMessage="Name is required" ValidationGroup="validateLanguage" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="form_wraper_trs">
                            <label class="first">Native Name</label>
                            <div class="inputprop">
                                <asp:TextBox runat="server" ID="txtNativeName" Width="250"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form_wraper_trs">
                            <label class="first">Code</label>
                            <div class="inputprop">
                                <asp:TextBox runat="server" ID="txtCode" Width="250" MaxLength="10"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCode"
                                    ErrorMessage="Code is required" ValidationGroup="validateLanguage" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="form_wraper_trs">
                            <label class="first">Note</label>
                            <div class="inputprop">
                                <asp:TextBox runat="server" ID="txtNote" Width="250" TextMode="MultiLine" Rows="3"></asp:TextBox>
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
                            <asp:Button ID="btnSave" runat="server" CssClass="button_add" Text="Add" OnClick="btnSave_Click" ValidationGroup="validateLanguage" />
                            <asp:Button ID="btnCancel" runat="server" CssClass="button_add" Text="Cancel" OnClick="btnCancel_Click" CausesValidation="false" />
                            <div id="diverror" runat="server" visible="false" style="color: red; margin-top: 10px;">
                                <strong>Error!</strong> A language with this name already exists.
                            </div>
                        </div>
                    </div>
                </aside>
            </div>
        </div>
    </div>

    <!-- Languages Grid -->
    <div class="five_sixth sidebar_right" id="divLanguages" runat="server">
        <aside>
            <div style="float: left; margin: 0; width: 100%;">
                <div class="nav_bg" style="width:100%;">
                    <h2 class="fl_left">Languages</h2>
                    <asp:LinkButton ID="btnAddNew" runat="server" CssClass="button_add" Style="color:#fff; float:right;" OnClick="btnAddNew_Click">Add</asp:LinkButton>
                </div>
                <div style="float: left; margin:0; text-align:center; width:100%">
                    <asp:GridView ID="gvLanguages" runat="server" AutoGenerateColumns="False" CellPadding="4" AllowPaging="true" PageSize="20"
                        OnPageIndexChanging="gvLanguages_PageIndexChanging" OnRowCommand="gvLanguages_RowCommand"
                        ForeColor="Black" GridLines="Horizontal" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                        <RowStyle CssClass="DataRow" />
                        <FooterStyle BackColor="#3591cd" ForeColor="Black"></FooterStyle>
                        <HeaderStyle BackColor="#3591cd" Font-Bold="True" ForeColor="White" HorizontalAlign="Left"></HeaderStyle>
                        <PagerStyle HorizontalAlign="Right" BackColor="White" ForeColor="Black"></PagerStyle>
                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" CssClass="yellow"></SelectedRowStyle>
                        <SortedAscendingCellStyle BackColor="#F7F7F7"></SortedAscendingCellStyle>
                        <SortedAscendingHeaderStyle BackColor="#4B4B4B"></SortedAscendingHeaderStyle>
                        <SortedDescendingCellStyle BackColor="#E5E5E5"></SortedDescendingCellStyle>
                        <SortedDescendingHeaderStyle BackColor="#242121" CssClass="GridHeader"></SortedDescendingHeaderStyle>
                        <PagerSettings Mode="NumericFirstLast" PageButtonCount="10" FirstPageText="First" LastPageText="Last" />
                        <Columns>
                            <asp:BoundField DataField="Name" HeaderText="Name">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NativeName" HeaderText="Native Name">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Code" HeaderText="Code">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Note" HeaderText="Note">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Active">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                                <ItemTemplate>
                                    <%# (bool)Eval("Active") ? "Yes" : "No" %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Actions">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtEdit" CssClass="btn btn-primary" runat="server" CommandName="editrecord"
                                        Text="Edit" CommandArgument='<%#Eval("Id").ToString() %>'></asp:LinkButton>
                                    <asp:LinkButton ID="lbtnDelete" CssClass="btn btn-danger" runat="server" CommandName="deleterecord"
                                        OnClientClick="if (!confirm('Are you sure you want to delete this language?')) return false;"
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
