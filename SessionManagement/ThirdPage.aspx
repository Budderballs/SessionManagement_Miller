<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ThirdPage.aspx.cs" Inherits="SessionManagement.ThirdPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblUser" runat="server" Font-Size="Large" />
            <div style="float:right;width:300px;padding:5px; text-align:right;">
                    <asp:Button ID="btnLogIn" runat="server" Text="Log In" OnClick="btnLogIn_Click" />
                </div>
        </div>
    </form>
</body>
</html>
