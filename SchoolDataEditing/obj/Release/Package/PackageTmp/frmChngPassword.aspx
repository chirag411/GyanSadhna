<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmChngPassword.aspx.cs" Inherits="SchoolDataEditing.frmChngPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>School Award Portal</title>
    <style>
        .bg-image-vertical {
            position: relative;
            overflow: hidden;
            background-repeat: no-repeat;
            background-position: right center;
            background-size: auto 100%;
        }

        @media (min-width: 1025px) {
            .h-custom-2 {
                height: 100%;
            }
        }
    </style>
    <link href="https://fonts.gstatic.com" rel="preconnect" />
    <link href="https://fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,600,600i,700,700i|Nunito:300,300i,400,400i,600,600i,700,700i|Poppins:300,300i,400,400i,500,500i,600,600i,700,700i" rel="stylesheet" />

    <!-- Vendor CSS Files -->
    <link href="assets/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="assets/vendor/bootstrap-icons/bootstrap-icons.css" rel="stylesheet" />
    <link href="assets/vendor/boxicons/css/boxicons.min.css" rel="stylesheet" />
    <link href="assets/vendor/quill/quill.snow.css" rel="stylesheet" />
    <link href="assets/vendor/quill/quill.bubble.css" rel="stylesheet" />
    <link href="assets/vendor/remixicon/remixicon.css" rel="stylesheet" />
    <link href="assets/vendor/simple-datatables/style.css" rel="stylesheet" />

    <!-- Template Main CSS File -->
    <link href="assets/css/style.css" rel="stylesheet" />
</head>
<body>

    <section class="vh-100">
        <div class="container-fluid">
            <div class="row">
                <div class="col-sm-6 px-0 d-none d-sm-block">
                    <img src="Media/LoginMain2.jpg"
                        alt="Login image" class="w-100 vh-100" style="object-fit: cover; object-position: left;">
                </div>
                <div class="col-sm-6 text-black">

                    <div class="px-5 ms-xl-4">
                        <i class="fas fa-crow fa-2x me-3 pt-5 mt-xl-4" style="color: #709085;"></i>
                        <span class="h1 fw-bold mb-0">શ્રેષ્ઠ શાળા</span>
                    </div>

                    <div class="d-flex align-items-center h-custom-2 px-5 ms-xl-4 pt-5 pt-xl-0 mt-xl-n5">

                        <form style="width: 23rem;" id="form1" runat="server">

                            <h3 class="fw-normal mb-3 pb-3" style="letter-spacing: 1px;">Change Password</h3>

                            <div class="form-outline mb-4">
                                <asp:TextBox runat="server" placeholder="Enter current password" type="password" ID="txtOldPassword" class="form-control form-control-lg"></asp:TextBox>

                            </div>

                            <div class="form-outline mb-4">
                                <asp:TextBox runat="server" placeholder="Enter new password" type="password" ID="txtNewPassword" class="form-control form-control-lg"></asp:TextBox>

                            </div>

                            <div class="form-outline mb-4">
                                <asp:TextBox runat="server" placeholder="ReEnter new password" type="password" ID="txtRePassword" class="form-control form-control-lg"></asp:TextBox>

                            </div>

                            <div class="pt-1 mb-4">
                                <asp:Button ID="submit" runat="server" class="btn btn-primary btn-lg btn-block" Text="Change Password" type="submit" OnClick="submit_Click"></asp:Button>

                            </div>


                        </form>

                    </div>

                </div>
            </div>
        </div>
        <footer id="footer" class="footer">
            <div class="copyright" style="position: absolute; z-index: 1; margin-top: -45px;margin-left:410px;font-size:smaller">
                &copy; <strong><span>2024 VSK, GCSE-Samagra Shiksha, All rights reserved. </span></strong>. | Powered By: MIS Unit, GCSE-Samagra Shiksha
            </div>

        </footer>
    </section>


</body>
</html>
