<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="TranslatorTranslations.aspx.cs" Inherits="Translations.TranslatorTranslations" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DropDownList runat="server" CssClass="dropdown_pro" ID="ddlTranslators" style="width:300px; font-family:monospace; font-size:15px; letter-spacing:1px" OnSelectedIndexChanged="ddlTranslators_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
     <div class="five_sixth sidebar_right" id="divTranslators" runat="server">
                <aside>
                    <div class="nav_bg">
                        <h2 class="fl_left">Translators</h2>
                        <%--<asp:LinkButton ID="btnAddNew" runat="server" CssClass="button_add" Style="color: #fff; float: right;" OnClick="btnAddNew_Click"> Add</asp:LinkButton>--%>

                    </div>
                    <div style="float: left; margin: 0; text-align: center; width: 100%">
                        <asp:Label runat="server" ID="lblTranslationDone" ForeColor="Red" Font-Bold="true"></asp:Label>
                        <asp:GridView ID="gvTranslatorTranslations" runat="server" AutoGenerateColumns="False" OnRowCommand="gv_RowCommand" AllowPaging="true" PageSize="20" OnPageIndexChanging="gvTranslatorTranslations_PageIndexChanging"  CellPadding="4" ForeColor="Black" GridLines="Horizontal" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                         <RowStyle CssClass="DataRow" />
                            <FooterStyle BackColor="#CCCC99" ForeColor="Black"></FooterStyle>

                        <HeaderStyle BackColor="#3591cd" Font-Bold="True" ForeColor="White" HorizontalAlign="Left"></HeaderStyle>

                        <PagerStyle HorizontalAlign="Right" BackColor="White" ForeColor="Black"></PagerStyle>

                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" CssClass="yellow"></SelectedRowStyle>

                        <SortedAscendingCellStyle BackColor="#F7F7F7"></SortedAscendingCellStyle>

                        <SortedAscendingHeaderStyle BackColor="#4B4B4B"></SortedAscendingHeaderStyle>

                        <SortedDescendingCellStyle BackColor="#E5E5E5"></SortedDescendingCellStyle>

                        <SortedDescendingHeaderStyle BackColor="#242121" CssClass="GridHeader"></SortedDescendingHeaderStyle>
                        <Columns>
                            <asp:BoundField DataField="TranslationKey.Key" HeaderText="Key">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Translated" HeaderText="Translated" DataFormatString="{0:dd/MM/yyyy}">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="English Text">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                                <ItemTemplate>
                                    <%# Eval("TranslationKey.EnglishValue") != null ? GetEngTranslation(Eval("TranslationKey.EnglishValue").ToString()) : "" %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Translation">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                                <ItemTemplate>
                                    <%# Eval("Value") != null ? GetEngTranslation(Eval("Value").ToString()) : "" %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="View">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtView" CssClass="btn btn-primary" runat="server" CommandName="viewrecord" Text="View" CommandArgument='<%#Eval("Id").ToString() %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>


                    </asp:GridView>

                    </div>

                </aside>

            </div>

     <div id="divAddEdit" runat="server" class="sidebar one_quarter first" style="width: 100%; text-align: center;">
                <aside>
                    <div class="nav_bg">
                        <h2 class="fl_left">Translation</h2>
                    </div>

                    <div class="form-bg">
                        <div class="form_wraper_trs">
                            
                                <asp:Label runat="server" class="form_wraper_trs-trans2-label">Translation Key</asp:Label>
                            
                            <div class="inputprop">
                                <asp:TextBox runat="server" ID="txtTranslationKey" Enabled="false" CssClass="form_wraper_trs-trans2-dd3"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form_wraper_trs">
                          
                                <asp:Label runat="server" class="form_wraper_trs-trans2-label">English Text</asp:Label>
                           
                            <div class="inputprop">
                                <asp:TextBox runat="server" ID="txtEnglishText" Enabled="false" TextMode="MultiLine" CssClass="form_wraper_trs-trans2-text3"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form_wraper_trs">
                            
                                <asp:Label runat="server" ID="lblTranslationLanguage" Text="Translation" class="form_wraper_trs-trans-label_trans"></asp:Label>
                           
                            <div class="inputprop">
                                <asp:TextBox runat="server" ID="txtTranslation" TextMode="MultiLine" Enabled="false" CssClass="form_wraper_trs-trans2-text3"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form_wraper_trs">
                             
                                <asp:Label runat="server" ID="lblComments" Text="Comments" class="form_wraper_trs-trans-label_com"></asp:Label>
                          
                            <div class="inputprop">
                                <asp:TextBox runat="server" ID="txtComments" TextMode="MultiLine" Enabled="false" CssClass="form_wraper_trs-trans2-dd2"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form_wraper_trs">
                            
                                <asp:Label runat="server" class="form_wraper_trs-trans-label_ac">Active</asp:Label>
                         
                            <div class="inputprop-key">
                                <asp:CheckBox ID="chkbxActive" runat="server" Enabled="false" />
                            </div>
                        </div>

                        <div class="clear"></div>
                        <div class="form_wraper_trs">
                            <%--<asp:Button ID="btnUpdate" runat="server" CssClass="button small gradient black" Text="Update" OnClick="btnUpdate_Click" />--%>
                            <asp:Button ID="btnView" runat="server" CssClass="Button_add" Text="View All" OnClick="btnView_Click" />
                        </div>
                    </div>
                </aside>
            </div>
</asp:Content>
