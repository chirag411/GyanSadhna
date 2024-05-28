<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmAddSchool.aspx.cs" Inherits="SchoolDataEditing.frmAddSchool" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
          <meta charset="UTF-8">
      <meta name="viewport" content="width=device-width, initial-scale=1.0">
      <title>Dynamic Form Grid</title>
      <style>
          table {
              width: 100%;
              border-collapse: collapse;
          }

          table, th, td {
              border: 1px solid black;
          }

          th, td {
              padding: 10px;
              text-align: left;
          }

          .delete-button {
              color: red;
              cursor: pointer;
          }
      </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <main id="main" class="main">

        <section class="section">
            <div class="row">
                <div class="col-md-12">
                    <div class="card-header p-2">
                    </div>
                  
                    <head>
                        <form name="untitled1">
                            <h2>Existing Data</h2>
                            <table id="existingGrid">
                                <thead>
                                    <tr>
                                        <th>School Category</th>
                                        <th>Index No</th>
                                        <th>School Management</th>
                                        <th>Std 9 FRC Fee</th>
                                        <th>Std 10 FRC Fee</th>
                                        <th>School Medium</th>
                                        <th>Action</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>માધ્યમિક</td>
                                        <td>10.101</td>
                                        <td>MSB</td>
                                        <td>300</td>
                                        <td>300</td>
                                        <td>Gujarati</td>
                                        <td><span class="delete-button" onclick="deleteRow(this)">Delete</span></td>
                                    </tr>
                                </tbody>
                            </table>
                            <h2>Add New Data</h2>
                            <table>
                                <tr>
                                    <td>
                                        <input type="text" id="newSchoolCategory" placeholder="School Category"></td>
                                    <td>
                                        <input type="text" id="newIndexNo" placeholder="Index No"></td>
                                    <td>
                                        <input type="text" id="newSchoolMgmt" placeholder="School Management"></td>
                                    <td>
                                        <input type="text" id="newStd9FRCFee" placeholder="Std 9 FRC Fee"></td>
                                    <td>
                                        <input type="text" id="newStd10FRCFee" placeholder="Std 10 FRC Fee"></td>
                                    <td>
                                        <input type="text" id="newSchoolMedium" placeholder="School Medium"></td>
                                    <td>
                                        <button type="button" onclick="addRow()">Add</button></td>
                                </tr>
                            </table>
                        </form>
                        <script>
                            function addRow() {
                                // Get input values
                                const schoolCategory = document.getElementById('newSchoolCategory').value;
                                const indexNo = document.getElementById('newIndexNo').value;
                                const schoolMgmt = document.getElementById('newSchoolMgmt').value;
                                const std9FRCFee = document.getElementById('newStd9FRCFee').value;
                                const std10FRCFee = document.getElementById('newStd10FRCFee').value;
                                const schoolMedium = document.getElementById('newSchoolMedium').value;

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

                                // Clear input fields
                                document.getElementById('newSchoolCategory').value = '';
                                document.getElementById('newIndexNo').value = '';
                                document.getElementById('newSchoolMgmt').value = '';
                                document.getElementById('newStd9FRCFee').value = '';
                                document.getElementById('newStd10FRCFee').value = '';
                                document.getElementById('newSchoolMedium').value = '';
                            }

                            function deleteRow(button) {
                                // Find the row to delete
                                const row = button.parentNode.parentNode;
                                row.parentNode.removeChild(row);
                            }
                        </script>
                   

                </div>
            </div>
        </section>
    </main>
</asp:Content>
