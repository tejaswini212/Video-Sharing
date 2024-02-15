<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="VideoSharingTryIT.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table class="nav-justified">
            <tr>
                <td style="height: 42px; width: 219px;"><asp:Label ID="enterVideoLabel" runat="server" Text="Enter Video to Watch"></asp:Label></td>
                <td style="height: 42px"><asp:TextBox ID="inputVideoIDText" runat="server" Width="610px"></asp:TextBox></td>            
            </tr>
            <tr>
                <td style="height: 15px"><asp:Button ID="getVideoButton" runat="server" Text="Get Video" OnClick="GetVideoButton_Click" style="margin-left: 0" Width="253px" /></td>
            </tr>
            <tr>
                <td style="height: 15px"><asp:Label ID="outputStatusLabel" runat="server" Text="Get your status here"></asp:Label></td>
            </tr>
            <tr>
                <td style="height: 15px"><asp:Button ID="LikeButton" runat="server" Text="Like Video" OnClick="LikeButton_Click" style="margin-left: 0" Width="253px" /></td>
                <td style="height: 15px"><asp:Label ID="LikeLabel" runat="server" Text="Like Status"></asp:Label></td>
            </tr>
            <tr>
                <td style="height: 15px"><asp:Button ID="DislikeButton" runat="server" Text="Dislike Video" OnClick="DislikeButton_Click" style="margin-left: 0" Width="253px" /></td>
                <td style="height: 15px"><asp:Label ID="DislikeLabel" runat="server" Text="Dislike Status"></asp:Label></td>
            </tr>
            <tr>
                <td style="height: 15px"><asp:Button ID="GetLikeDislikeButton" runat="server" Text="Get Likes and Dislikes of Video Count" OnClick="GetLikeDislikeButton_Click" style="margin-left: 0" Width="253px" /></td>
                <td style="height: 15px"><asp:Label ID="LikeLabel_All" runat="server" Text="Get Likes Status"></asp:Label></td>
                <td style="height: 15px"><asp:Label ID="DislikeLabel_All" runat="server" Text="Get Dislikes Status"></asp:Label></td>
            </tr>
        </table>
    </form>
</body>
</html>
