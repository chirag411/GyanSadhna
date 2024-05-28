﻿<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" EnableEventValidation="false" Inherits="SchoolDataEditing._Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <main id="main" class="main">
        <section class="section">
            <div class="row">
                <div class="col-lg-12">
                    <div class="card">
                        <div class="card-body">
                            <h5 class="card-title text-center">મુખ્યમંત્રી જ્ઞાન સાધના મેરીટ સ્કોલરશીપ યોજના (શાળા એમ્પેનલ મોડ્યુલ -૨૦૨૪)</h5>
                            <div class="row">
                                <div class="col-md-3 d-flex flex-column gap-2">
                                    <label for="ddlBoard">Select School Board</label>
                                    <asp:DropDownList ID="ddlBoard" runat="server" CssClass="form-select">
                                        <asp:ListItem Text="--All--" Value=""></asp:ListItem>
                                        <asp:ListItem Text="Guj.Board" Value="Guj.Board"></asp:ListItem>
                                        <asp:ListItem Text="Oth.Board" Value="Oth.Board"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-3 d-flex flex-column gap-2">
                                    <label for="ddlType">Select School Type</label>
                                    <asp:DropDownList ID="ddlType" runat="server" CssClass="form-select">
                                        <asp:ListItem Text="--All--" Value=""></asp:ListItem>
                                        <asp:ListItem Text="Model School (Central Govt.)" Value="Model School (Central Govt.)"></asp:ListItem>
                                        <asp:ListItem Text="MSB" Value="MSB"></asp:ListItem>
                                        <asp:ListItem Text="RMSA School" Value="RMSA School"></asp:ListItem>
                                        <asp:ListItem Text="Social welfare Department" Value="Social welfare Department"></asp:ListItem>
                                        <asp:ListItem Text="Department of Education" Value="Department of Education"></asp:ListItem>
                                        <asp:ListItem Text="Model Day School (State Govt.)" Value="Model Day School (State Govt.)"></asp:ListItem>
                                        <asp:ListItem Text="Tribal Welfare Department" Value="Tribal Welfare Department"></asp:ListItem>
                                        <asp:ListItem Text="Local Body" Value="Local Body"></asp:ListItem>
                                        <asp:ListItem Text="Government Aided" Value="Government Aided"></asp:ListItem>
                                        <asp:ListItem Text="Madarsa recognized (by Wakf board /Madarsa Board)" Value="Madarsa recognized (by Wakf board /Madarsa Board)"></asp:ListItem>
                                        <asp:ListItem Text="Private Unaided" Value="Private Unaided"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-3 d-flex flex-column gap-2">
                                    <label for="ddlDistrict">School District</label>
                                    <asp:DropDownList ID="ddlDistrict" runat="server" Width="100%" CssClass="form-select">
                                        <asp:ListItem Text="--All--" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="KACHCHH" Value="2401"></asp:ListItem>
                                        <asp:ListItem Text="BANASKANTHA" Value="2402"></asp:ListItem>
                                        <asp:ListItem Text="PATAN" Value="2403"></asp:ListItem>
                                        <asp:ListItem Text="MAHESANA" Value="2404"></asp:ListItem>
                                        <asp:ListItem Text="SABAR KANTHA" Value="2405"></asp:ListItem>
                                        <asp:ListItem Text="GANDHINAGAR" Value="2406"></asp:ListItem>
                                        <asp:ListItem Text="AHMEDABAD" Value="2407"></asp:ListItem>
                                        <asp:ListItem Text="SURENDRANAGAR" Value="2408"></asp:ListItem>
                                        <asp:ListItem Text="RAJKOT" Value="2409"></asp:ListItem>
                                        <asp:ListItem Text="JAMNAGAR" Value="2410"></asp:ListItem>
                                        <asp:ListItem Text="PORBANDAR" Value="2411"></asp:ListItem>
                                        <asp:ListItem Text="JUNAGADH" Value="2412"></asp:ListItem>
                                        <asp:ListItem Text="AMRELI" Value="2413"></asp:ListItem>
                                        <asp:ListItem Text="BHAVNAGAR" Value="2414"></asp:ListItem>
                                        <asp:ListItem Text="ANAND" Value="2415"></asp:ListItem>
                                        <asp:ListItem Text="KHEDA" Value="2416"></asp:ListItem>
                                        <asp:ListItem Text="PANCH MAHALS" Value="2417"></asp:ListItem>
                                        <asp:ListItem Text="DOHAD" Value="2418"></asp:ListItem>
                                        <asp:ListItem Text="VADODARA" Value="2419"></asp:ListItem>
                                        <asp:ListItem Text="NARMADA" Value="2420"></asp:ListItem>
                                        <asp:ListItem Text="BHARUCH" Value="2421"></asp:ListItem>
                                        <asp:ListItem Text="SURAT" Value="2422"></asp:ListItem>
                                        <asp:ListItem Text="THE DANGS" Value="2423"></asp:ListItem>
                                        <asp:ListItem Text="NAVSARI" Value="2424"></asp:ListItem>
                                        <asp:ListItem Text="VALSAD" Value="2425"></asp:ListItem>
                                        <asp:ListItem Text="TAPI" Value="2426"></asp:ListItem>
                                        <asp:ListItem Text="ARAVALLI" Value="2427"></asp:ListItem>
                                        <asp:ListItem Text="BOTAD" Value="2428"></asp:ListItem>
                                        <asp:ListItem Text="DEVBHOOMI DWARKA" Value="2429"></asp:ListItem>
                                        <asp:ListItem Text="GIR SOMNATH" Value="2430"></asp:ListItem>
                                        <asp:ListItem Text="MAHISAGAR" Value="2431"></asp:ListItem>
                                        <asp:ListItem Text="CHHOTAUDEPUR" Value="2432"></asp:ListItem>
                                        <asp:ListItem Text="MORBI" Value="2433"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-3 d-flex flex-column gap-2">
                                    <label for="ddlstatus">Verification Status</label>
                                    <asp:DropDownList ID="ddlstatus" runat="server" CssClass="form-select">
                                        <asp:ListItem Text="--All--" Value=""></asp:ListItem>
                                        <asp:ListItem Text="Completed" Value="Completed"></asp:ListItem>
                                        <asp:ListItem Text="Pending" Value="Pending"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row mt-3">
                                <div class="d-flex justify-content-end align-items-center">
                                    <asp:Button Text="View School List" ID="btnFind" runat="server" CssClass="btn btn-success btn-sm" OnClick="btnFind_OnClick" />
                                </div>

                            </div>
                            <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red" Visible="false" />
                        </div>
                    </div>
                </div>
            </div>
        </section>

        <section>
            <div class="row">
                <div class="col-md-3">
                    <div class="card text-bg-info rounded-3">
                        <div class="card-body">
                            <h6 class="card-title" style="color: black">Total School Count</h6>
                            <h1 class="card-text text-center">
                                <asp:Label ID="lblTotal" runat="server"></asp:Label></h1>
                        </div>
                    </div>
                </div>

                <div class="col-md-3">
                    <div class="card text-bg-success rounded-3">
                        <div class="card-body">
                            <h6 class="card-title" style="color: white">Competed School Count</h6>
                            <h1 class="card-text text-center">
                                <asp:Label ID="lblCompleted" runat="server"></asp:Label></h1>
                        </div>
                    </div>
                </div>

                <div class="col-md-3">
                    <div class="card text-bg-secondary rounded-3">
                        <div class="card-body">
                            <h6 class="card-title" style="color: white">Pending School Count</h6>
                            <h1 class="card-text text-center">
                                <asp:Label ID="lblPending" runat="server"></asp:Label></h1>
                        </div>
                    </div>
                </div>

                <div class="col-md-3">
                    <div class="card text-bg-danger rounded-3">
                        <div class="card-body">
                            <h6 class="card-title" style="color: white">Deleted School Count</h6>
                            <h1 class="card-text text-center">
                                <asp:Label ID="lblDeleted" runat="server"></asp:Label></h1>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <section class="section">
            <div class="row">
                <div class="col-lg-12">
                    <div class="card">
                        <div class="card-body">
                            <div class="d-flex justify-content-between align-items-center">
                                <h5 class="card-title">Matched Records</h5>
                            </div>
                            <div class="row mt-3">
                                <div class="d-flex justify-content-end align-items-center">
                                    <asp:Button ID="btnExportToExcel" runat="server" Text="Export to Excel" OnClick="btnExportToExcel_Click" CssClass="btn btn-primary" />
                                </div>
                            </div>
                            <div style="overflow: auto;" class="mt-4">
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="6" CssClass="table table-striped table-bordered"
                                    OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating"
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

                                        <asp:TemplateField HeaderText="Action" ItemStyle-Width="20%">
                                            <ItemTemplate>
                                                <div class="btn-group" role="group">
                                                    <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName="Edit" CommandArgument='<%# Eval("SchoolUDISECode") %>' CssClass="btn btn-primary btn-sm" />
                                                    <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="Delete" CommandArgument='<%# Eval("SchoolUDISECode") %>' CssClass="btn btn-danger btn-sm" OnClientClick="return confirm('Are you sure you want to delete this record?');" />
                                                </div>
                                            </ItemTemplate>
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
