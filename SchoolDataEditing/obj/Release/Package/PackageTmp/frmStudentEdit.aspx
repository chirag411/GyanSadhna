<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmStudentEdit.aspx.cs" Inherits="SchoolDataEditing.frmStudentEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="scriptManager1" runat="server" />
    <main id="main" class="main">
        <asp:HiddenField ID="hfUploadedFilePathCons" runat="server" />
        <asp:HiddenField ID="hfUploadedFilePathBanks" runat="server" />


        <asp:HiddenField ID="hfDiseCode" runat="server" />
        <asp:HiddenField ID="hfSchoolName" runat="server" />
        <asp:HiddenField ID="hfSchoolDistrict" runat="server" />
        <asp:HiddenField ID="hfSchoolBlock" runat="server" />
        <asp:HiddenField ID="hfSchoolType" runat="server" />
        <%--<asp:HiddenField ID="hfIsRTE" runat="server" />--%>
        <section class="section">
            <div class="row">
                <div class="col-lg-12">
                    <div class="card">
                        <div class="card-body">
                            <h5 class="card-title text-center">Student`s Basic Detail</h5>
                            <div class="row">
                                <div class="col-lg-12">
                                    <h5 class="card-title text-center">વિગત ૧ - શાળાની વિગત</h5>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <label style="font-size: medium">શું વિદ્યાર્થી આજ શાળામાં ધોરણ ૧૦ માં અભ્યાસ કરી રહ્યો છે?</label>
                                        </div>
                                        <div class="col-md-4">
                                            <asp:DropDownList ID="drpQuestion3Part1" CssClass="form-control" runat="server" OnSelectedIndexChanged="sameSchoolSelectionChange" AutoPostBack="true">
                                                <asp:ListItem Text="Select" Value=""></asp:ListItem>
                                                <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="row mt-3" id="divQuestion3Part2Optional1" runat="server" style="display: none">
                                        <div class="col-md-6">
                                            <label style="font-size: medium">વિદ્યાર્થીએ સરકારી/ગ્રાન્ટેડ/એમ્પેનલ સેલ્ફ ફાઈનાન્સ(૨૦૨૪ માં થયેલ) શાળામાં  પ્રવેશ લીધેલ છે?</label>
                                        </div>
                                        <div class=" col-md-4">
                                            <asp:DropDownList CssClass="form-control" OnSelectedIndexChanged="regSchoolSelectionChange" ID="studyingInRegisteredSchool" runat="server" AutoPostBack="true">
                                                <asp:ListItem Text="Select" Value=""></asp:ListItem>
                                                <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="row mt-3" id="divQuestion3Part2Optional3" runat="server" style="display: none">
                                        <div class="col-md-6">
                                            <label style="font-size: medium">પ્રવેશ ન લેવાનું  નું કારણ પસંદ કરો</label>
                                        </div>
                                        <div class=" col-md-4">
                                            <asp:DropDownList CssClass="form-control" runat="server" ID="reasonForLeaving" AutoPostBack="true">
                                                <asp:ListItem Text="વિદ્યાર્થી રાજ્ય બહાર અભ્યાસ કરવા ગયેલ છે" Value="વિદ્યાર્થી રાજ્ય બહાર અભ્યાસ કરવા ગયેલ છે"></asp:ListItem>
                                                <asp:ListItem Text="વિદ્યાર્થી એમ્પેનલ સિવાયની શાળામાં અભ્યાસ કરે છે" Value="વિદ્યાર્થી એમ્પેનલ સિવાયની શાળામાં અભ્યાસ કરે છે"></asp:ListItem>
                                                <asp:ListItem Text="વિદ્યાર્થી મૃત્યુ પામેલ છે" Value="વિદ્યાર્થી મૃત્યુ પામેલ છે"></asp:ListItem>
                                                <asp:ListItem Text="વિદ્યાર્થીએ અભ્યાસ છોડી દીધેલ છે" Value="વિદ્યાર્થીએ અભ્યાસ છોડી દીધેલ છે"></asp:ListItem>
                                                <asp:ListItem Text="વિદ્યાર્થી નાપાસ થયેલ છે" Value="વિદ્યાર્થી નાપાસ થયેલ છે"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="row mt-3" id="old2NewDISE" runat="server" style="display: none">
                                        <div class="col-md-8">
                                            <label for="newDISECode" style="font-size: medium">અહીં નવો DISE કોડ દાખલ કરો</label>
                                        </div>
                                        <div class=" col-md-4">
                                            <asp:TextBox runat="server" MaxLength="11" ID="newDISECode" MinLength="11" AutoPostBack="true"></asp:TextBox>
                                            <asp:Button runat="server" ID="btnDiseSearch" class="btn-primary" OnClick="btnSearchForNewSchool" Text="શોધો" />
                                            <%--<button type="submit" class="btn-primary">શોધો</button>--%>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row mt-3">
                                <div class="col-md-3 d-flex flex-column gap-2">
                                    <label for="txtChildUid">Child UID</label>
                                    <asp:TextBox runat="server" ID="txtChildUid" placeholder="ChildUid" ReadOnly="True" />
                                </div>
                                <div class="col-md-3 d-flex flex-column gap-2">
                                    <label for="txtChildName">Student`s Name</label>

                                    <asp:TextBox runat="server" ID="txtChildName" ReadOnly="True" />
                                </div>
                                <div class="col-md-3 d-flex flex-column gap-2">
                                    <label for="txtGender">Student`s Gender</label>
                                    <asp:TextBox runat="server" ID="txtGender" ReadOnly="True" />
                                </div>
                                <div class="col-md-3 d-flex flex-column gap-2">
                                    <label for="txtMobile">Mobile Number</label>
                                    <asp:TextBox runat="server" ID="txtMobile" ReadOnly="True" />
                                </div>
                            </div>

                            <div class="row" style="margin-top: 10px">
                                <div class="col-md-3 d-flex flex-column gap-2">
                                    <label for="txtDiseCode">School Dise</label>
                                    <asp:TextBox runat="server" ID="txtDiseCode" ReadOnly="True" placeholder="Enter valid DISE Code" />
                                </div>
                                <div class="col-md-3 d-flex flex-column gap-2">
                                    <label for="txtSchoolName">School Name</label>

                                    <asp:TextBox runat="server" ID="txtSchoolName" ReadOnly="True" />
                                </div>
                                <div class="col-md-3 d-flex flex-column gap-2">
                                    <label for="txtDistrictName">School District</label>
                                    <asp:TextBox runat="server" ID="txtDistrictName" ReadOnly="True" />
                                </div>
                                <div class="col-md-3 d-flex flex-column gap-2">
                                    <label for="txtBlock">Block Name</label>
                                    <asp:TextBox runat="server" ID="txtBlock" ReadOnly="True" />
                                </div>
                            </div>

                            <div class="row" style="margin-top: 10px">
                                <div class="col-md-3 d-flex flex-column gap-2">
                                    <label for="txtSchoolType">School Type</label>
                                    <asp:TextBox runat="server" ID="txtSchoolType" ReadOnly="True" />
                                </div>


                                <div class="row" id="divConsentLetterSection" runat="server" style="display: none">
                                    <div class="col-md-6 mt-3">
                                        <label style="font-size: medium">કૃપા કરીને સંમતિ પત્ર અપલોડ કરો (.jpeg/.jpg/.png)</label>
                                    </div>
                                    <div class="col-md-2 mt-3">
                                        <asp:FileUpload ID="fuConsentLetter" runat="server" />
                                        <div class="imz" id="previewContainer" style="margin-top: 10px;">
                                            <div class="emz">
                                                <img id="imgPreview" style="display: none; max-width: 100px" runat="server" />
                                                <p id="fileInfo"></p>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <%--<div class="col-md-3 d-flex flex-column gap-2">
                                    <label for="txtIsRTE">School IS RTE</label>

                                    <asp:TextBox runat="server" ID="txtIsRTE" ReadOnly="True" />
                                </div>--%>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </section>


        <%-- Bank Section --%>

        <section class="section">
            <div class="row">
                <div class="col-lg-12">
                    <div class="card">
                        <div class="card-body">
                            <h5 class="card-title text-center">Student`s Bank Detail</h5>
                            <div class="row">
                                <div class="col-md-3 d-flex flex-column gap-2">
                                    <label for="txtStudentsAccountNumber">Student`s Account Number</label>
                                    <asp:TextBox runat="server" ID="txtStudentsAccountNumber" placeholder="ChildUid" ReadOnly="True" />
                                </div>
                                <div class="col-md-3 d-flex flex-column gap-2">
                                    <label for="txtBankName">Student`s Bank Name</label>

                                    <asp:TextBox runat="server" ID="txtBankName" ReadOnly="True" />
                                </div>
                                <div class="col-md-3 d-flex flex-column gap-2">
                                    <label for="txtIFSC">Bank IFSC</label>
                                    <asp:TextBox runat="server" ID="txtIFSC" ReadOnly="True" />
                                </div>
                                <div class="col-md-3 d-flex flex-column gap-2">
                                    <label for="txtHolderName">Benificiary Name</label>
                                    <asp:TextBox runat="server" ID="txtHolderName" ReadOnly="True" />
                                </div>
                            </div>

                            <div class="row" style="margin-top: 10px">

                                <div class="col-md-3 d-flex flex-column gap-2">
                                    <label for="txtCreditedOn">Last Installment CreditedOn</label>

                                    <asp:TextBox runat="server" ID="txtCreditedOn" ReadOnly="true" />
                                </div>
                                <div class="col-md-3 d-flex flex-column gap-2">
                                    <label for="txtLastAmount">Last Installment Amount</label>
                                    <asp:TextBox runat="server" ID="txtLastAmount" ReadOnly="true" />
                                </div>
                                <div class="col-md-3 d-flex flex-column gap-2">
                                    <label for="txtAccountType">Bank Account Relation</label>
                                    <asp:TextBox runat="server" ID="txtAccountType" ReadOnly="true" />
                                </div>
                            </div>

                            <%-- <div class="row" style="margin-top: 10px">
                                <div class="col-md-3 d-flex flex-column gap-2">
                                    <label for="txtAccountNumber">Account Number</label>
                                    <asp:TextBox runat="server" ID="TextBox6" placeholder="" Text="1234567887654321" />
                                </div>
                            </div>

                            <div class="row" style="margin-top: 10px">
                                <div class="col-md-3 d-flex flex-column gap-2">
                                    <label for="txtAccountNumber">Account Number</label>
                                    <asp:TextBox runat="server" ID="TextBox15" placeholder="" Text="1234567887654321" />
                                </div>

                            </div>--%>
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
                            <h5 class="card-title text-center">વિગત ૨ - હાજરીની વિગત</h5>
                            <div class="row">
                                <div class="col-md-6">
                                    <label style="font-size: medium">વિદ્યાર્થીની ધોરણ - ૯ ના બીજા સત્રની હાજરી ૮૦% કે તેથી વધુ છે?</label>
                                </div>
                                <div class=" col-md-2">
                                    <asp:DropDownList CssClass="form-control" runat="server" Style="float: right;" ID="eightyPercentAttend">
                                        <asp:ListItem Text="Select" Value=""></asp:ListItem>
                                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                    </asp:DropDownList>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <div class="card">
                        <div class="card-body">
                            <h5 class="card-title text-center">વિગત ૩ - સ્કોલરશીપ મળ્યાની બાહેધરી</h5>
                            <asp:UpdatePanel ID="updatePanel1" runat="server">
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="twoInstallments" EventName="SelectedIndexChanged" />
                                </Triggers>
                                <ContentTemplate>
                                    <div class="row">
                                        <div class="row">
                                            <div class="col-md-6">
                                                <label style="font-size: medium">વિદ્યાર્થીની ધોરણ - ૯ ના સ્કોલરશીપ અંતર્ગત પ્રથમ બન્ને હફ્તા મળી ગયેલ છે? </label>
                                            </div>
                                            <div class=" col-md-2">

                                                <asp:DropDownList CssClass="form-control" runat="server" AutoPostBack="true" Style="float: right;" ID="twoInstallments" OnSelectedIndexChanged="twoInstallments_SelectedIndexChanged">
                                                    <asp:ListItem Text="Select" Value=""></asp:ListItem>
                                                    <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                                </asp:DropDownList>

                                            </div>
                                        </div>
                                        <div class="row mt-3" id="divBankStatementSection" runat="server" style="display: none">
                                            <div class="col-md-6">
                                                <label style="font-size: medium">કૃપા કરીને છેલ્લા હપ્તાના મહિનાનું બેંક સ્ટેટમેન્ટ અપલોડ કરો (.jpeg/.jpg/.png)</label>
                                            </div>
                                            <div class=" col-md-2">
                                                <asp:FileUpload ID="fuBankStatement" runat="server"/>
                                                <div class="imz" id="previewContainer1" style="margin-top: 10px;">
                                                    <div class="emz">
                                                        <asp:Image ID="imgPreview1" Style="display: none; max-width: 100px;" runat="server" />
                                                        <p id="fileInfo1"></p>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
            <div class="form-group text-center">

                <asp:Button Text="Submit" runat="server" OnClick="btnOnSelectedQues" CssClass="btn-success" />
                <%--<asp:Button Text="Make It as Dispute" runat="server" CssClass="btn-danger" OnClick="btnCancel_OnClick" OnClientClick="return confirm('Are you sure you want to dispute this record?');" />--%>
            </div>
        </section>

    </main>


    <script>
        document.getElementById('<%= fuConsentLetter.ClientID %>').addEventListener('change', function (event) {
            const file = event.target.files[0];
            const previewContainer = document.getElementById('previewContainer');
            const imgPreview = document.getElementById('<%= imgPreview.ClientID %>');
            const fileInfo = document.getElementById('fileInfo');

            if (file) {
                const reader = new FileReader();

                reader.onload = function (e) {
                    if (file.type.startsWith('image/')) {
                        imgPreview.src = e.target.result;
                        imgPreview.style.display = 'block';
                        fileInfo.style.display = 'none';
                    } else {
                        imgPreview.style.display = 'none';
                        fileInfo.textContent = `File name: ${file.name}\nFile size: ${file.size} bytes`;
                        fileInfo.style.display = 'block';
                    }
                };

                reader.readAsDataURL(file);
            } else {
                imgPreview.style.display = 'none';
                fileInfo.style.display = 'none';
            }
        });
    </script>
    <%--<script>
        document.getElementById('<%= fuBankStatement.ClientID %>').addEventListener('change', function (event) {
            const file = event.target.files[0];
            const previewContainer = document.getElementById('previewContainer1');
            const imgPreview = document.getElementById('<%= imgPreview1.ClientID %>');
            const fileInfo = document.getElementById('fileInfo1');

            if (file) {
                const reader = new FileReader();

                reader.onload = function (e) {
                    if (file.type.startsWith('image/')) {
                        imgPreview.src = e.target.result;
                        imgPreview.style.display = 'block';
                        fileInfo.style.display = 'none';
                    } else {
                        imgPreview.style.display = 'none';
                        fileInfo.textContent = `File name: ${file.name}\nFile size: ${file.size} bytes`;
                        fileInfo.style.display = 'block';
                    }
                };

                reader.readAsDataURL(file);
            } else {
                imgPreview.style.display = 'none';
                fileInfo.style.display = 'none';
            }
        });
    </script>--%>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
<script type="text/javascript">
    $(document).ready(function () {
        var fuBankStatementID = '<%= fuBankStatement.ClientID %>';
       console.log("FileUpload ClientID:", fuBankStatementID);

        $('#' + fuBankStatementID).on('change', function () {
            console.log("File selection changed");
            console.log("File selection changed");
            var file = this.files[0];
            if (file) {
                console.log("File selected:", file.name);
                var reader = new FileReader();
                reader.onload = function (e) {
                    console.log("FileReader onload");
                    $('#imgPreview1').attr('src', e.target.result);
                    $('#imgPreview1').show();
                    $('#fileInfo1').text('File selected: ' + file.name);
                }
                reader.readAsDataURL(file);
            } else {
                $('#imgPreview1').hide();
                $('#fileInfo1').text('');
            }
        });
    });
</script>

</asp:Content>

