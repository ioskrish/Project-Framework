<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="ProjectFrameworkWeb.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>KTS InfoTech Private Limited</h3>
    <h4><asp:Label ID="LabelAddress" runat="server" Text="Pala | Kottayam | Kerala | India"></asp:Label></h4>
    <h5><a href="www.ktsinfotech.com"><asp:Label ID="LabelSite_URL" runat="server" Text="www.ktsinfotech.com"></asp:Label></a></h5>
    <h5><asp:Label ID="LabelContact_No" runat="server" Text=" 91-9388605612"></asp:Label></h5>

    <address>
        <strong>Support:</strong>   <a href="mailto:support@ktsinfotech.com">support@ktsinfotech.com</a><br />
        <strong>Marketing:</strong> <a href="mailto:info@ktsinfotech.com">info@ktsinfotech.com</a>
    </address>
</asp:Content>
