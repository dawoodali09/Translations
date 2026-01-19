<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Translators.aspx.cs" Inherits="Translations.Translators" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- content -->

    <div class="wrapper row3">
        <div id="container">

            <div id="divAddEdit" runat="server" class="sidebar one_quarter first" style="width: 100%; text-align: center;">
                <aside>
                    <%-- <div id="diverror" visible="false" runat="server">
                        <h4>Error!</h4>
                        <p>
                            <asp:Literal ID="litError" runat="server"></asp:Literal>
                        </p>
                    </div>--%>
                    <div class="nav_bg">
                        <h2 class="fl_left">Tranlators Form </h2>
                    </div>
                    <div class="form-bg">
                        <div class="form_wraper_trs">
                            <label class=" first" for="author">Email </label>
                            <div class="inputprop">
                                <asp:TextBox runat="server" ID="txtEmail" Width="210"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Style="width: 130px; position: absolute;" ValidationGroup="validateDetails" ControlToValidate="txtEmail" runat="server" ErrorMessage="Email Required" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtEmail" Style="width: 145px; position: absolute;" runat="server" ErrorMessage="Invalid Email" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" Display="Dynamic" ForeColor="Red" ValidationGroup="validateDetails"></asp:RegularExpressionValidator>
                            </div>
                            <%--<input type="Email" class="input_inside" name="Email" placeholder="Email Address"  value="" size="22"  />--%>
                        </div>
                        <div class="form_wraper_trs" id="divPaswrd" runat="server">
                            <label class="first" for="author">Password</label>
                            <div class="inputprop">
                                <asp:TextBox runat="server" ID="txtPasswrd" Width="210" TextMode="Password"></asp:TextBox><%--<input type="password" class="input_inside" name="password" placeholder="Password"  value="" size="22"  />--%>
                                <asp:RequiredFieldValidator Style="width: 130px; position: absolute; text-indent: -21px;" ValidationGroup="validateDetails" ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPasswrd" ErrorMessage="Password Required" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>

                        </div>
                        <div class="form_wraper_trs" id="divConfrmPaswrd" runat="server">
                            <label class="first" for="author">Confirm Password</label>
                            <div class="inputprop">
                                <asp:TextBox runat="server" ID="txtCnfrmPaswrd" Width="210" TextMode="Password"></asp:TextBox><%--<input type="password" class="input_inside" name="password" placeholder="Password"  value="" size="22"  />--%>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" Style="width: 160px; position: absolute; text-indent: -105px;" ValidationGroup="validateDetails" ControlToValidate="txtCnfrmPaswrd" runat="server" ErrorMessage="Confirm Password Required" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:CompareValidator Style="width: 160px; position: absolute; text-indent: -80px;" ID="CompareValidator1" runat="server" ValidationGroup="validateDetails" ControlToCompare="txtPasswrd" ControlToValidate="txtCnfrmPaswrd" ErrorMessage="Passwords do not match" Display="Dynamic" ForeColor="Red"></asp:CompareValidator>
                            </div>

                        </div>
                        <div class="form_wraper_trs">
                            <label class="first" for="author">First Name</label>
                            <div class="inputprop">
                                <asp:TextBox runat="server" CssClass="form-control required" ID="txtFirstName" Width="210"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" Style="width: 160px; position: absolute; text-indent: -80px;" ValidationGroup="validateDetails" ID="reqName" ControlToValidate="txtFirstName" ErrorMessage="Please enter first name" ForeColor="Red" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ValidationGroup="validateDetails" Style="width: 210px; position: absolute; text-indent: -168px;" runat="server" ControlToValidate="txtFirstName" ForeColor="Red" ErrorMessage="Please enter correct first name" ValidationExpression="[a-zA-Z]*[^!@%~?:#$%^&*()'0123456789]*"></asp:RegularExpressionValidator>
                            </div>
                            <%--<input type="text" class="input_inside" name="first name" placeholder="First Name"  value="" size="22"  />--%>
                        </div>

                        <div class="form_wraper_trs">
                            <label class="first" for="author">Last Name</label>
                            <div class="inputprop">
                                <asp:TextBox runat="server" Width="210" ID="txtLastName"></asp:TextBox><%--<input type="text" class="input_inside" name="Last First Name" placeholder="Last First Name"  value="" size="22"  />--%>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ValidationGroup="validateDetails" Style="width: 210px; position: absolute; text-indent: -123px;" ControlToValidate="txtLastName" ForeColor="Red" ErrorMessage="Please enter last name" ValidationExpression="[a-zA-Z]*[^!@%~?:#$%^&*()'0123456789]*"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="form_wraper_trs">
                            <label class="first" for="author">Contact No</label>
                            <div class="inputprop">
                                <asp:TextBox runat="server" Width="210" ID="txtContact"></asp:TextBox>
                                <asp:RequiredFieldValidator Style="width: 150px; position: absolute; text-indent: -71px;" ValidationGroup="validateDetails" ID="RequiredFieldValidator3" runat="server" ForeColor="Red" ControlToValidate="txtContact" ErrorMessage="Please enter contact no"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator Style="width: 150px; position: absolute; text-indent: -71px;" ValidationGroup="validateDetails" ID="RegularExpressionValidator4" ControlToValidate="txtContact" ForeColor="Red" runat="server" ValidationExpression="^[0-9]+$" ErrorMessage="Please enter only digits"></asp:RegularExpressionValidator>
                            </div>
                        </div>

                        <div class="form_wraper_trs">
                            <label class="first" for="author">Address</label>
                            <div class="inputprop">
                                <asp:TextBox runat="server" Width="210" ID="txtAddress"></asp:TextBox>
                                <asp:RequiredFieldValidator Style="width: 160px; position: absolute; text-indent: -71px;" ValidationGroup="validateDetails" ID="RequiredFieldValidator4" ForeColor="Red" runat="server" ControlToValidate="txtAddress" ErrorMessage="Please enter Address"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="form_wraper_trs">
                            <label class="first" for="author">Active</label>
                            <div class="inputprop">
                                <asp:CheckBox ID="chkbxActive" runat="server" Checked="true" />
                            </div>
                        </div>

                        <div class="form_wraper_trs">
                            <label class="first" for="author">Mobile No</label>
                            <div class="inputprop">
                                <asp:TextBox runat="server" ID="txtMobile" Width="210"></asp:TextBox>
                                <asp:RequiredFieldValidator Style="width: 200px; position: absolute; text-indent: -111px;" ValidationGroup="validateDetails" ForeColor="Red" ID="RequiredFieldValidator5" ControlToValidate="txtMobile" runat="server" ErrorMessage="Please enter mobile no"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator Style="width: 200px; position: absolute; text-indent: -155px;" ValidationGroup="validateDetails" ForeColor="Red" ID="RegularExpressionValidator5" ValidationExpression="^[0-9]+$" ControlToValidate="txtMobile" runat="server" ErrorMessage="Please enter correct mobile no"></asp:RegularExpressionValidator>
                            </div>
                        </div>

                        <div class="form_wraper_trs">
                            <label class="first" for="author">Upload</label>
                            <div class="inputprop">
                                <asp:FileUpload ID="fuPictureUpload" runat="server" BorderColor="white" />
                            </div>
                        </div>

                        <div class="form_wraper_trs">
                            <label class="first" for="author" style="margin-top: 37px;">Role</label>
                            <div class="inputprop">
                                <asp:DropDownList ID="ddlRole" Width="210" runat="server" class="dropdown_pro">
                                    <asp:ListItem Text="Administrator" Value="Administrator"></asp:ListItem>
                                    <asp:ListItem Text="Translator" Value="Translator"></asp:ListItem>

                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="clear"></div>
                        <div class="form_wraper_trs-btn">
                            <asp:Button ID="btnAdd" runat="server" CssClass="button_add" Text="Add" OnClick="btnAdd_Click" ValidationGroup="validateDetails" />
                            <asp:Button ID="btnCancel" runat="server" CssClass="button_add" Text="Cancel" OnClick="btnCancel_Click" />
                            <div id="diverror" runat="server" visible="false" style="color: red">

                                <strong>Error!</strong> This email has been already used.
                            </div>                            
                        </div>
                    </div>
                </aside>
            </div>

            <div class="five_sixth sidebar_right" id="divTranslators" runat="server">
                <aside>
                    <div class="nav_bg">
                        <h2 class="fl_left">Translators</h2>
                        <asp:LinkButton ID="btnAddNew" runat="server" CssClass="button_add" Style="color: #fff; float: right;" OnClick="btnAddNew_Click"> Add</asp:LinkButton>

                    </div>
                    <div style="float: left; margin: 0 20px; text-align: center; width: 95%">
                        <asp:GridView ID="gvTranslators" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="Black" GridLines="Horizontal" BackColor="White" 
                            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" OnRowCommand="gv_RowCommand" OnSelectedIndexChanged="gvTranslators_SelectedIndexChanged">
                            <RowStyle CssClass="DataRow" />
                           
                            <FooterStyle BackColor="#3591cd" ForeColor="Black"></FooterStyle>

                            <HeaderStyle BackColor="#3591cd" Font-Bold="True" ForeColor="White"></HeaderStyle>

                            <PagerStyle HorizontalAlign="Right" BackColor="White" ForeColor="Black"></PagerStyle>

                            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" CssClass="yellow"></SelectedRowStyle>

                            <SortedAscendingCellStyle BackColor="#F7F7F7"></SortedAscendingCellStyle>

                            <SortedAscendingHeaderStyle BackColor="#4B4B4B"></SortedAscendingHeaderStyle>

                            <SortedDescendingCellStyle BackColor="#E5E5E5"></SortedDescendingCellStyle>

                            <SortedDescendingHeaderStyle BackColor="#242121" CssClass="GridHeader"></SortedDescendingHeaderStyle>
                            <Columns>
                                <%--<asp:Boundfield datafield="PostalCode" headertext="Postal Code"/>
          <asp:Boundfield datafield="Country" headertext="Country"/>--%>
                               <%-- <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                                <asp:BoundField DataField="LastName" HeaderText="Last Name" />--%>
                                <asp:BoundField DataField="EmailAddress" HeaderText="Email" />
                                <asp:BoundField DataField="Password" HeaderText="Password" />
                                <asp:BoundField DataField="ContactNo" HeaderText="Contact No" />
                                <%--<asp:BoundField DataField="Active" HeaderText="Active" />--%>
                                <asp:BoundField DataField="MobileNumber" HeaderText="Mobile No" />

                                <asp:BoundField DataField="Role" HeaderText="Role" />

                                <asp:TemplateField HeaderText="Edit">
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbtEdit" CssClass="btn btn-primary" runat="server" CommandName="editrecord" Text="Edit" CommandArgument='<%#Eval("Id").ToString() %>'></asp:LinkButton>

                                        <asp:LinkButton ID="lbtnDelete" CssClass="btn btn-danger confirmLink" runat="server" CommandName="deleterecord" OnClientClick="if (!confirm('Are you sure you want delete?')) return false;"
                                            Text="Delete" CommandArgument='<%#Eval("Id").ToString() %>'></asp:LinkButton>

                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>


                        </asp:GridView>

                    </div>

                </aside>

            </div>
        </div>

        <div class="clear"></div>
    </div>

</asp:Content>
