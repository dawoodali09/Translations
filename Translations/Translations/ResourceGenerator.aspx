<%@ Page Title="Resource Generator" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ResourceGenerator.aspx.cs" Inherits="Translations.ResourceGenerator" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="wrapper row3">
        <div id="container">

            <!-- Resource Generator Panel -->
            <div class="sidebar one_quarter first" style="width: 100%;">
                <aside>
                    <div class="nav_bg">
                        <h2 class="fl_left">Resource File Generator</h2>
                    </div>
                    <div class="form-bg">

                        <!-- Info Section -->
                        <div style="background: #e0f2fe; border: 1px solid #0ea5e9; border-radius: 8px; padding: 16px; margin-bottom: 24px;">
                            <strong style="color: #0369a1;">About Resource Files</strong>
                            <p style="margin: 8px 0 0 0; color: #0c4a6e; font-size: 13px;">
                                Resource files (.resx) are XML-based files used in .NET applications for localization.
                                Download resource files for specific country-languages or get a global file with all English translations.
                            </p>
                        </div>

                        <!-- Country Language Selection -->
                        <div class="form_wraper_trs">
                            <label class="first">Country Language</label>
                            <div class="inputprop">
                                <asp:DropDownList ID="ddlCountryLanguage" runat="server" CssClass="dropdown_pro" Width="300">
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="form_wraper_trs">
                            <label class="first">File Name Prefix</label>
                            <div class="inputprop">
                                <asp:TextBox ID="txtFilePrefix" runat="server" Width="300" Text="Resources"></asp:TextBox>
                                <div style="font-size: 12px; color: #64748b; margin-top: 4px;">
                                    Output: [Prefix].[LanguageCode].resx (e.g., Resources.fr-FR.resx)
                                </div>
                            </div>
                        </div>

                        <div class="form_wraper_trs">
                            <label class="first">Include Empty</label>
                            <div class="inputprop">
                                <asp:CheckBox ID="chkIncludeEmpty" runat="server" />
                                <span style="font-size: 12px; color: #64748b; margin-left: 8px;">
                                    Include keys with empty translations (uses English value as fallback)
                                </span>
                            </div>
                        </div>

                        <div class="clear"></div>
                        <div class="form_wraper_trs-btn">
                            <asp:Button ID="btnDownloadLanguage" runat="server" CssClass="button_add" Text="Download Language Resource" OnClick="btnDownloadLanguage_Click" />
                        </div>

                        <hr style="border: none; border-top: 1px solid #e2e8f0; margin: 30px 0;" />

                        <!-- Global Resource Section -->
                        <h3 style="color: #1e293b; margin-bottom: 16px;">Global Resource File</h3>

                        <div style="background: #fef3c7; border: 1px solid #f59e0b; border-radius: 8px; padding: 16px; margin-bottom: 24px;">
                            <strong style="color: #92400e;">Global Resource</strong>
                            <p style="margin: 8px 0 0 0; color: #78350f; font-size: 13px;">
                                The global resource file contains all translation keys with their English values.
                                This serves as the default/fallback resource file in your application.
                            </p>
                        </div>

                        <div class="form_wraper_trs">
                            <label class="first">Global File Name</label>
                            <div class="inputprop">
                                <asp:TextBox ID="txtGlobalFileName" runat="server" Width="300" Text="Resources"></asp:TextBox>
                                <div style="font-size: 12px; color: #64748b; margin-top: 4px;">
                                    Output: [Name].resx (e.g., Resources.resx)
                                </div>
                            </div>
                        </div>

                        <div class="clear"></div>
                        <div class="form_wraper_trs-btn">
                            <asp:Button ID="btnDownloadGlobal" runat="server" CssClass="button_add" Text="Download Global Resource" OnClick="btnDownloadGlobal_Click" />
                        </div>

                        <hr style="border: none; border-top: 1px solid #e2e8f0; margin: 30px 0;" />

                        <!-- Bulk Download Section -->
                        <h3 style="color: #1e293b; margin-bottom: 16px;">Bulk Download (All Languages)</h3>

                        <div style="background: #f0fdf4; border: 1px solid #10b981; border-radius: 8px; padding: 16px; margin-bottom: 24px;">
                            <strong style="color: #166534;">Bulk Export</strong>
                            <p style="margin: 8px 0 0 0; color: #14532d; font-size: 13px;">
                                Download a ZIP file containing resource files for all country-languages plus the global resource file.
                            </p>
                        </div>

                        <div class="clear"></div>
                        <div class="form_wraper_trs-btn">
                            <asp:Button ID="btnDownloadAll" runat="server" CssClass="button_add" Text="Download All Resources (ZIP)" OnClick="btnDownloadAll_Click" />
                        </div>

                    </div>
                </aside>
            </div>

            <!-- Statistics Panel -->
            <div class="five_sixth sidebar_right" style="margin-top: 20px;">
                <aside>
                    <div class="nav_bg">
                        <h2 class="fl_left">Translation Statistics</h2>
                    </div>
                    <div style="padding: 20px;">
                        <asp:GridView ID="gvStats" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            ForeColor="Black" GridLines="Horizontal" BackColor="White" BorderColor="#CCCCCC"
                            BorderStyle="None" BorderWidth="1px" Width="100%">
                            <RowStyle CssClass="DataRow" />
                            <HeaderStyle BackColor="#3591cd" Font-Bold="True" ForeColor="White"></HeaderStyle>
                            <Columns>
                                <asp:BoundField DataField="CountryLanguage" HeaderText="Country Language" />
                                <asp:BoundField DataField="TotalKeys" HeaderText="Total Keys" />
                                <asp:BoundField DataField="TranslatedKeys" HeaderText="Translated" />
                                <asp:BoundField DataField="PendingKeys" HeaderText="Pending" />
                                <asp:BoundField DataField="CompletionPercent" HeaderText="Completion %" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </aside>
            </div>

        </div>
    </div>

</asp:Content>
