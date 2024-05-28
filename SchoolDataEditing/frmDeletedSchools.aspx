<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmDeletedSchools.aspx.cs" Inherits="SchoolDataEditing.frmDeletedSchools" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <main id="main" class="main">

        <section class="section">
            <div class="row">
                <div class="col-lg-12">
                    <div class="card">
                        <div class="card-body">
                            <div class="d-flex justify-content-between align-items-center">
                                <h5 class="card-title">Matched Records</h5>
                            </div>

                            <div style="overflow: auto;" class="mt-4">
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="6" CssClass="table table-striped table-bordered"
                                    OnPageIndexChanging="OnPageIndexChanging" AllowPaging="True" AllowSorting="True" GridLines="None" PageSize="10" ViewStateMode="Enabled"
                                    BorderColor="Black" BorderWidth="1px" OnRowCommand="GridView1_RowCommand" OnSorting="GridView1_Sorting">
                                    <PagerSettings Mode="NumericFirstLast" PageButtonCount="4" FirstPageText="First" LastPageText="Last" />
                                    <Columns>
                                        <asp:TemplateField ItemStyle-Width="200" HeaderText="School UDISE Code">
                                            <HeaderTemplate>
                                                <asp:LinkButton runat="server" CommandName="Sort" CommandArgument="SchoolUDISECode">School UDISE Code</asp:LinkButton>
                                                <asp:TextBox ID="txtSearchSchoolUDISECode" runat="server" CssClass="form-control" Placeholder="Search" />
                                                <asp:Button ID="btnSearchSchoolUDISECode" runat="server" Text="Search" CommandName="Search" CssClass="btn btn-sm btn-primary mt-2" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label runat="server" Text='<%# Eval("SchoolUDISECode") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="150" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label runat="server" Text='<%# Eval("SchoolUDISECode") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderTemplate>
                                                <asp:LinkButton runat="server" CommandName="Sort" CommandArgument="SchoolUDISECode">School UDISE Code</asp:LinkButton>
                                            </HeaderTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="District Name" SortExpression="district" ItemStyle-Width="20%">
                                            <ItemTemplate>
                                                <asp:Label ID="district" runat="server" Text='<%# Eval("district") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderTemplate>
                                                <asp:LinkButton runat="server" CommandName="Sort" CommandArgument="district">District Name</asp:LinkButton>
                                            </HeaderTemplate>
                                        </asp:TemplateField>
                                        <%--<asp:TemplateField HeaderText="DISE Code" SortExpression="SchoolUDISECode" ItemStyle-Width="20%">
                                         <ItemTemplate>
                                             <asp:Label runat="server" ID="lblDISECode" Text='<%# Eval("SchoolUDISECode") %>'></asp:Label>
                                         </ItemTemplate>
                                         <HeaderTemplate>
                                             <asp:LinkButton runat="server" CommandName="Sort" CommandArgument="SchoolUDISECode">DISE Code</asp:LinkButton>
                                         </HeaderTemplate>
                                     </asp:TemplateField>--%>

                                        <asp:TemplateField HeaderText="School Name" SortExpression="School Name" ItemStyle-Width="20%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSchoolName" runat="server" Text='<%# Eval("School Name") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderTemplate>
                                                <asp:LinkButton runat="server" CommandName="Sort" CommandArgument="School Name">School Name</asp:LinkButton>
                                            </HeaderTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="School Block" SortExpression="Block" ItemStyle-Width="20%">
                                            <ItemTemplate>
                                                <asp:Label ID="Block" runat="server" Text='<%# Eval("Block") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderTemplate>
                                                <asp:LinkButton runat="server" CommandName="Sort" CommandArgument="Block">School Block</asp:LinkButton>
                                            </HeaderTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="School Board" SortExpression="SchoolBoard" ItemStyle-Width="20%">
                                            <ItemTemplate>
                                                <asp:Label ID="SchoolBoard" runat="server" Text='<%# Eval("SchoolBoard") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderTemplate>
                                                <asp:LinkButton runat="server" CommandName="Sort" CommandArgument="SchoolBoard">School Board</asp:LinkButton>
                                            </HeaderTemplate>
                                        </asp:TemplateField>

                                        <%--  <asp:TemplateField HeaderText="School Address" SortExpression="School Address" ItemStyle-Width="20%">
                                         <ItemTemplate>
                                             <asp:Label ID="lblSchoolAddress" runat="server" Text='<%# Eval("School Address") %>'></asp:Label>
                                         </ItemTemplate>
                                         <HeaderTemplate>
                                             <asp:LinkButton runat="server" CommandName="Sort" CommandArgument="School Address">School Address</asp:LinkButton>
                                         </HeaderTemplate>
                                     </asp:TemplateField>--%>

                                        <asp:TemplateField HeaderText="School Management" SortExpression="Management" ItemStyle-Width="20%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSchoolManagement" runat="server" Text='<%# Eval("Management") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderTemplate>
                                                <asp:LinkButton runat="server" CommandName="Sort" CommandArgument="Management">School Management</asp:LinkButton>
                                            </HeaderTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Verification Status" SortExpression="School Verification Status" ItemStyle-Width="20%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblVerificationStatus" runat="server" Text='<%# Eval("School Verification Status") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderTemplate>
                                                <asp:LinkButton runat="server" CommandName="Sort" CommandArgument="School Verification Status">Verification Status</asp:LinkButton>
                                            </HeaderTemplate>
                                        </asp:TemplateField>

                                    </Columns>
                                    <HeaderStyle CssClass="bg-primary text-white" />
                                    <RowStyle CssClass="table-light" />
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </main>
</asp:Content>
