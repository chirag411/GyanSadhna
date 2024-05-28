<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="frmSchoolEditAdd.aspx.cs" Inherits="SchoolDataEditing.frmSchoolEditAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.12.9/dist/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7HuiB39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>

    <main id="main" class="main">
        <section class="section p-3" style="background-color: #f8f9fa">
            <form id="form">
                <div class="mt-5">
                    <h3 class="mb-3">Add / Edit School List</h3>
                    <asp:HiddenField ID="hfTableData" runat="server" />
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label for="udiseCode">School UDISE Code*</label>
                                <asp:TextBox ID="udiseCode" runat="server" CssClass="form-control" OnTextChanged="udiseCode_TextChanged" type="number" min="24010000000" max="24340000000" AutoPostBack="True"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label for="schoolType">School Type*</label>
                                <asp:DropDownList ID="schoolType" runat="server" CssClass="form-control">
                                    <asp:ListItem Text="Guj.Board" Value="Guj.Board"></asp:ListItem>
                                    <asp:ListItem Text="Oth.Board" Value="Oth.Board"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label for="district">District*</label>
                                <asp:TextBox ID="district" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label for="taluka">Taluka*</label>
                                <asp:TextBox ID="taluka" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label for="schoolName">School Name*</label>
                                <asp:TextBox ID="schoolName" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label for="schoolManagement">School Management (as per UDISE)*</label>
                                <asp:DropDownList ID="schoolManagement" runat="server" CssClass="form-control" OnSelectedIndexChanged="schoolManagement_SelectedIndexChanged" Enabled="False">
                                    <asp:ListItem Text="Please Select" Value="Select"></asp:ListItem>
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
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="schoolAddress">School Address*</label>
                        <asp:TextBox ID="schoolAddress" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3"></asp:TextBox>
                    </div>

                    <hr />

                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>ધોરણ ૯ થી ૧૨ એક જ કેમ્પસ માં ચાલે છે ?</label>
                                <asp:DropDownList ID="SQue1" runat="server" CssClass="form-control" Enabled="False">
                                    <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                    <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>ધોરણ ૯ થી ૧૨ એક જ ટ્રસ્ટ/સંસ્થા દ્વારા ચાલે છે ?</label>
                                <asp:DropDownList ID="SQue2" runat="server" CssClass="form-control" Enabled="False">
                                    <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                    <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <label>શાળા નું છેલ્લા ૫ વર્ષ પૈકી છેલ્લા ૩ વર્ષ ધોરણ ૧૦ નુ પરિણામ ૮૦% કે તેથી વધુ આવેલ છે ?</label>
                                <asp:DropDownList ID="SQue3" runat="server" CssClass="form-control" Enabled="False">
                                    <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                    <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>



                    <div>
                        <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red" />
                        <%--  <asp:GridView ID="gvSchoolDetails" runat="server" AutoGenerateColumns="False" OnRowDeleting="gvSchoolDetails_RowDeleting">
                            <Columns>
                                <asp:BoundField DataField="SchoolCategory" HeaderText="School Category" />
                                <asp:BoundField DataField="IndexNo" HeaderText="Index No" />
                                <asp:BoundField DataField="SchoolManagement" HeaderText="School Management" />
                                <asp:BoundField DataField="Std9FrcFee" HeaderText="Std 9 FRC Fee" />
                                <asp:BoundField DataField="Std10FrcFee" HeaderText="Std 10 FRC Fee" />
                                <asp:BoundField DataField="SchoolMedium" HeaderText="School Medium" />
                                <asp:CommandField ShowDeleteButton="True" HeaderText="Action" />
                            </Columns>
                        </asp:GridView>

                        <asp:Label ID="lblAddNewData" runat="server" Text="Add New Data" />--%>

                        <table class="mb-3 mt-2 table table-bordered">
                            <thead>
                                <tr>
                                    <td>School Category
                                    </td>
                                    <td>School Index
                                    </td>
                                    <td>School Management
                                    </td>
                                    <td>Std 9 FRC FEE
                                    </td>
                                    <td>Std 10 FRC FEE
                                    </td>
                                    <td>School Medium
                                    </td>
                                </tr>
                            </thead>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlSchoolCategory" runat="server" CssClass="form-control">
                                        <asp:ListItem Text="Please Select" Value="Select"></asp:ListItem>
                                        <asp:ListItem Text="માધ્યમિક" Value="માધ્યમિક"></asp:ListItem>
                                        <asp:ListItem Text="ઉ.માધ્યમિક" Value="ઉ.માધ્યમિક"></asp:ListItem>
                                        <asp:ListItem Text="૯-૧૨ સળંગ એકમ" Value="૯-૧૨ સળંગ એકમ"></asp:ListItem>
                                    </asp:DropDownList></td>
                                <td>
                                    <asp:TextBox ID="txtIndexNo" runat="server" CssClass="form-control" type="number" min="0" step="any"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlSchoolManagement" runat="server" CssClass="form-control">
                                        <asp:ListItem Text="Please Select" Value="Select"></asp:ListItem>
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
                                    </asp:DropDownList></td>
                                <td>
                                    <asp:TextBox ID="txtStd9FrcFee" runat="server" CssClass="form-control" type="number" min="0" max="999999"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtStd10FrcFee" runat="server" CssClass="form-control" type="number" min="0" max="999999"></asp:TextBox></td>
                                <td>
                                    <asp:DropDownList ID="ddlSchoolMedium" runat="server" CssClass="form-control">
                                        <asp:ListItem Text="Please Select" Value="Select"></asp:ListItem>
                                        <asp:ListItem Text="Gujarati" Value="Gujarati"></asp:ListItem>
                                        <asp:ListItem Text="English" Value="English"></asp:ListItem>
                                        <asp:ListItem Text="Hindi" Value="Hindi"></asp:ListItem>
                                        <asp:ListItem Text="Urdu" Value="Urdu"></asp:ListItem>
                                        <asp:ListItem Text="Tamil" Value="Tamil"></asp:ListItem>
                                        <asp:ListItem Text="Udiya" Value="Udiya"></asp:ListItem>
                                        <asp:ListItem Text="Marathi" Value="Marathi"></asp:ListItem>
                                        <asp:ListItem Text="Telugu" Value="Telugu"></asp:ListItem>
                                    </asp:DropDownList></td>
                                <td>
                                    <asp:Button Text="Add" runat="server" CssClass="btn btn-success" OnClick="btnAdd_Click" />
                                </td>

                            </tr>
                        </table>

                        <%-- <asp:GridView ID="gvSchoolDetails" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered" OnRowDeleting="gvSchoolDetails_RowDeleting" ViewStateMode="Enabled">
                            <%--<Columns>
                                <asp:TemplateField HeaderText="School Category">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlSchoolCategory" runat="server" CssClass="form-control">
                                            <asp:ListItem Text="Please Select" Value="Select"></asp:ListItem>
                                            <asp:ListItem Text="માધ્યમિક" Value="માધ્યમિક"></asp:ListItem>
                                            <asp:ListItem Text="ઉ.માધ્યમિક" Value="ઉ.માધ્યમિક"></asp:ListItem>
                                            <asp:ListItem Text="૯-૧૨ સળંગ એકમ" Value=""></asp:ListItem>
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Index No">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtIndexNo" runat="server" CssClass="form-control"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="School Management">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlSchoolManagement" runat="server" CssClass="form-control">
                                            <asp:ListItem Text="Please Select" Value="Select"></asp:ListItem>
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
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Std 9 FRC Fee">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtStd9FrcFee" runat="server" CssClass="form-control"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Std 10 FRC Fee">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtStd10FrcFee" runat="server" CssClass="form-control"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="School Medium">
                                    <ItemTemplate>
                                        <asp:Label ID="Lable1" runat="server" CssClass="form-control"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                             
                            </Columns>
                        </asp:GridView>
                        --%>
                        <asp:GridView ID="gvSchoolDetails" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered" ViewStateMode="Enabled">
                            <Columns>
                                <asp:TemplateField HeaderText="School Category">
                                    <ItemTemplate>
                                        <asp:Label ID="SchoolCategory" runat="server" Text='<%# Eval("SchoolCategory") %>' CssClass="form-control"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Index No">
                                    <ItemTemplate>
                                        <asp:Label ID="SchoolIndex" runat="server" Text='<%# Eval("SchoolIndex") %>' CssClass="form-control"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="School Management">
                                    <ItemTemplate>
                                        <asp:Label ID="SchoolMgmt" runat="server" Text='<%# Eval("SchoolMgmt") %>' CssClass="form-control"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Std 9 FRC Fee">
                                    <ItemTemplate>
                                        <asp:Label ID="Std9FRC" runat="server" Text='<%# Eval("Std9FRC") %>' CssClass="form-control"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Std 10 FRC Fee">
                                    <ItemTemplate>
                                        <asp:Label ID="Std10FRC" runat="server" Text='<%# Eval("Std10FRC") %>' CssClass="form-control"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="School Medium">
                                    <ItemTemplate>
                                        <asp:Label ID="SchoolMedium" runat="server" Text='<%# Eval("SchoolMedium") %>' CssClass="form-control"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>

                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <asp:CheckBox Text="આ શાળા માટે દાખલ કરેલ તમામ વિગત ની  મે ચકાસણી કરેલ છે અને તમામ વિગત સાચી છે જેની હું બાહેધરી આપું છું. " ID="chkAcceptTerms" runat="server" />
                            </div>
                        </div>
                    </div>

                    <div class="form-group text-center">
                        <asp:Button ID="submitBtn" runat="server" CssClass="btn btn-primary" Text="Submit" OnClick="btnSubmit_Click" />
                    </div>
                </div>
            </form>
        </section>
    </main>
    <script>
      <%--  function addRow() {
            // Get input values
            const schoolCategory = document.getElementById('<%=ddlSchoolCategory.ClientID%>').value;
            const indexNo = document.getElementById('<%=txtIndexNo.ClientID%>').value;
            const schoolMgmt = document.getElementById('<%=ddlSchoolManagement.ClientID%>').value;
            const std9FRCFee = document.getElementById('<%=txtStd9FrcFee.ClientID%>').value;
            const std10FRCFee = document.getElementById('<%=txtStd10FrcFee.ClientID%>').value;
            const schoolMedium = document.getElementById('<%=ddlSchoolMedium.ClientID%>').value;

            // Get the table
            const table = document.getElementById('existingGrid').getElementsByTagName('tbody')[0];

            // Create a new row
            const newRow = table.insertRow();

            // Insert new cells
            const cell1 = newRow.insertCell(0);
            const cell2 = newRow.insertCell(1);
            const cell3 = newRow.insertCell(2);
            const cell4 = newRow.insertCell(3);
            const cell5 = newRow.insertCell(4);
            const cell6 = newRow.insertCell(5);
            const cell7 = newRow.insertCell(6);

            // Add values to the new cells
            cell1.innerHTML = schoolCategory;
            cell2.innerHTML = indexNo;
            cell3.innerHTML = schoolMgmt;
            cell4.innerHTML = std9FRCFee;
            cell5.innerHTML = std10FRCFee;
            cell6.innerHTML = schoolMedium;
            cell7.innerHTML = '<span class="delete-button" onclick="deleteRow(this)">Delete</span>';

            // Update the hidden field with the new table data
            updateHiddenField();

            // Clear input fields
            document.getElementById('<%=ddlSchoolCategory.ClientID%>').value = '';
            document.getElementById('<%=txtIndexNo.ClientID%>').value = '';
            document.getElementById('<%=ddlSchoolManagement.ClientID%>').value = '';
            document.getElementById('<%=txtStd9FrcFee.ClientID%>').value = '';
            document.getElementById('<%=txtStd10FrcFee.ClientID%>').value = '';
            document.getElementById('<%=ddlSchoolMedium.ClientID%>').value = '';
        }--%>

        function deleteRow(button) {
            // Find the row to delete
            const row = button.parentNode.parentNode;
            row.parentNode.removeChild(row);
            // Update the hidden field with the new table data
            updateHiddenField();
        }

        function updateHiddenField() {
            const table = document.getElementById('existingGrid').getElementsByTagName('tbody')[0];
            const rows = table.rows;
            const tableData = [];

            for (let i = 0; i < rows.length; i++) {
                const cells = rows[i].cells;
                tableData.push({
                    schoolCategory: cells[0].innerText,
                    indexNo: cells[1].innerText,
                    schoolMgmt: cells[2].innerText,
                    std9FRCFee: cells[3].innerText,
                    std10FRCFee: cells[4].innerText,
                    schoolMedium: cells[5].innerText
                });
            }

            document.getElementById('<%= hfTableData.ClientID %>').value = JSON.stringify(tableData);
        }
    </script>
</asp:Content>
