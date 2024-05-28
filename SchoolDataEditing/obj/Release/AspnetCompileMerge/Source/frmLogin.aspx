<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmLogin.aspx.cs" Inherits="SchoolDataEditing.frmLogin" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Gyan Shadhna Portal</title>
    <style>
        body, html {
            height: 100%;
            margin: 0;
            font-family: 'Open Sans', sans-serif;
            background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
            /*display: flex;
            align-items: center;
            justify-content: center;*/
        }

        .container-fluid {
            max-width: 1200px;
            margin: auto;
        }

        .row {
           height: 100vh;
        }

        .login-image {
            width: 65%;
            height:stretch;
            object-fit: cover;

        }

        .login-form {
            background: white;
            padding: 40px;
            border-radius: 10px;
            box-shadow: 0 8px 16px rgba(0, 0, 0, 0.2);
        }

        .form-outline {
            margin-bottom: 20px;
        }

        .form-control {
            height: calc(2.875rem + 2px);
            padding: 0.75rem 1.25rem;
            font-size: 1rem;
            line-height: 1.5;
            border: 1px solid #ced4da;
            border-radius: 0.375rem;
            transition: border-color 0.3s ease-in-out;
        }

        .form-control:focus {
            border-color: #667eea;
            box-shadow: 0 0 0 0.2rem rgba(102, 126, 234, 0.25);
        }

        .btn-primary {
            background-color: #667eea;
            border-color: #667eea;
            transition: background-color 0.3s ease-in-out, border-color 0.3s ease-in-out;
        }

        .btn-primary:hover {
            background-color: #556cd6;
            border-color: #556cd6;
        }

        .footer {
            width: 100%;
            text-align: center;
            font-size: smaller;
            background: rgba(255, 255, 255, 0.8);
            padding: 10px 0;
            position: absolute;
            bottom: 0;
        }
        
        .footer span {
            font-weight: bold;
        }

        h3 {
            color: #333;
            font-weight: 600;
        }
    </style>
    <link href="https://fonts.googleapis.com/css?family=Open+Sans:300,400,600,700" rel="stylesheet" />
    <link href="assets/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="assets/vendor/bootstrap-icons/bootstrap-icons.css" rel="stylesheet" />
</head>
<body>
    <section>
        <div">
            <div class="row">
                <div class="col-md-6">
                    <img src="Media/LoginMain2.jpg" alt="Login image" class="login-image">
                </div>
                <div class="col-md-6 d-flex align-items-center justify-content-center">
                    <div class="login-form">
                        <form id="form1" runat="server">
                            <h3 class="text-center mb-4">જ્ઞાન સાધના</h3>
                            <h3 class="text-center mb-4">DEO Log in</h3>
                            <div class="form-outline">
                                <asp:TextBox runat="server" placeholder="User ID" type="text" ID="txtUserName" class="form-control form-control-lg"></asp:TextBox>
                            </div>
                            <div class="form-outline">
                                <asp:TextBox runat="server" placeholder="Password" type="password" ID="txtPassword" class="form-control form-control-lg"></asp:TextBox>
                            </div>
                            <div class="text-center">
                                <asp:Button ID="submit" runat="server" class="btn btn-primary btn-lg btn-block" Text="Login" OnClick="submit_Click"></asp:Button>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <footer class="footer">
        <div>
            &copy; <strong><span>2024 VSK, GCSE-Samagra Shiksha, All rights reserved.</span></strong> | Powered By: MIS Unit, GCSE-Samagra Shiksha
        </div>
    </footer>
    <script src="assets/vendor/bootstrap/js/bootstrap.bundle.min.js"></script>
</body>
</html>
