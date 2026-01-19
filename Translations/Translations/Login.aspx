<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Translations.Login" ValidateRequest="false"%>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login - Translation Management System</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="css/modern.css" rel="stylesheet" type="text/css" />
    <style>
        .login-container {
            min-height: 100vh;
            display: flex;
            align-items: center;
            justify-content: center;
            background: linear-gradient(135deg, #1e3a8a 0%, #3b82f6 50%, #0ea5e9 100%);
            padding: 20px;
        }
        .login-card {
            background: white;
            border-radius: 16px;
            box-shadow: 0 25px 50px -12px rgba(0, 0, 0, 0.25);
            padding: 50px 40px;
            width: 100%;
            max-width: 420px;
            text-align: center;
        }
        .login-icon {
            width: 70px;
            height: 70px;
            background: linear-gradient(135deg, #2563eb 0%, #1d4ed8 100%);
            border-radius: 16px;
            display: flex;
            align-items: center;
            justify-content: center;
            margin: 0 auto 25px;
            box-shadow: 0 10px 30px rgba(37, 99, 235, 0.3);
        }
        .login-icon svg {
            width: 35px;
            height: 35px;
            fill: white;
        }
        .login-title {
            font-size: 26px;
            font-weight: 700;
            color: #1e293b;
            margin-bottom: 8px;
        }
        .login-subtitle {
            font-size: 15px;
            color: #64748b;
            margin-bottom: 35px;
        }
        .form-group {
            margin-bottom: 22px;
            text-align: left;
        }
        .form-label {
            display: block;
            font-size: 14px;
            font-weight: 600;
            color: #374151;
            margin-bottom: 8px;
        }
        .form-input {
            width: 100%;
            padding: 14px 16px;
            font-size: 15px;
            border: 2px solid #e5e7eb;
            border-radius: 10px;
            transition: all 0.2s;
            outline: none;
            background: #f9fafb;
        }
        .form-input:focus {
            border-color: #2563eb;
            background: white;
            box-shadow: 0 0 0 4px rgba(37, 99, 235, 0.1);
        }
        .btn-login {
            width: 100%;
            padding: 14px 24px;
            font-size: 16px;
            font-weight: 600;
            color: white;
            background: linear-gradient(135deg, #2563eb 0%, #1d4ed8 100%);
            border: none;
            border-radius: 10px;
            cursor: pointer;
            transition: all 0.2s;
            margin-top: 10px;
        }
        .btn-login:hover {
            transform: translateY(-2px);
            box-shadow: 0 10px 25px rgba(37, 99, 235, 0.35);
        }
        .error-message {
            background: #fef2f2;
            color: #dc2626;
            padding: 12px 16px;
            border-radius: 8px;
            font-size: 14px;
            margin-bottom: 20px;
            border: 1px solid #fecaca;
        }
        .footer-text {
            margin-top: 30px;
            font-size: 13px;
            color: #9ca3af;
        }
        .validator {
            color: #dc2626;
            font-size: 12px;
        }
    </style>
</head>
<body>
    <div class="login-container">
        <div class="login-card">
            <div class="login-icon">
                <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24">
                    <path d="M12.87 15.07l-2.54-2.51.03-.03c1.74-1.94 2.98-4.17 3.71-6.53H17V4h-7V2H8v2H1v2.01h11.17C11.5 7.92 10.44 9.75 9 11.35 8.07 10.32 7.3 9.19 6.69 8h-2c.73 1.63 1.73 3.17 2.98 4.56l-5.09 5.02L4 19l5-5 3.11 3.11.76-2.04zM18.5 10h-2L12 22h2l1.12-3h4.75L21 22h2l-4.5-12zm-2.62 7l1.62-4.33L19.12 17h-3.24z"/>
                </svg>
            </div>
            <h1 class="login-title">Translation Management System</h1>
            <p class="login-subtitle">Sign in to manage your translations</p>

            <form id="form1" runat="server">
                <div id="diverror" runat="server" visible="false" class="error-message">
                    <strong>Invalid email or password.</strong> Please try again.
                </div>

                <div class="form-group">
                    <label class="form-label">Email Address</label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-input" ClientIDMode="Static" placeholder="Enter your email"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email is required" CssClass="validator" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <label class="form-label">Password</label>
                    <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" CssClass="form-input" ClientIDMode="Static" placeholder="Enter your password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password is required" CssClass="validator" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>

                <asp:Button ID="btnLogin" Text="Sign In" runat="server" CssClass="btn-login" OnClick="btnLogin_Click" />
            </form>

            <p class="footer-text">&copy; 2024 Translation Management System. All rights reserved.</p>
        </div>
    </div>
</body>
</html>
