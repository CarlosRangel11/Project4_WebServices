<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Project4_Site._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <div class="row">
            <section class="col-md-4" aria-labelledby="hostingTitle">
                <p>
                    <a>Project 4 Implemented Services for Manipulating XML Documents</p>
                <p>
                    Services implemented:
                </p>
                <p>
                    Add Park</p>
                <p>
                    Name:
                    <asp:TextBox ID="txtParkName" runat="server"></asp:TextBox>
                </p>
                <p>
                    Park Type:
                    <asp:TextBox ID="txtParkType" runat="server"></asp:TextBox>
                </p>
                <p>
                    Owner:
                    <asp:TextBox ID="txtParkOwner" runat="server"></asp:TextBox>
                </p>
                <p>
                    Reservation Information:</p>
                <p>
                    &nbsp;&nbsp;&nbsp; Reservation Address:
                    <asp:TextBox ID="txtParkReservation_Address" runat="server"></asp:TextBox>
                </p>
                <p>
                    &nbsp;&nbsp;&nbsp; Reservation URL:
                    <asp:TextBox ID="txtParkReservation_URL" runat="server"></asp:TextBox>
                </p>
                <p>
                    Neighboring States:
                    <asp:TextBox ID="txtParkNeighboring_States" runat="server" Width="208px"></asp:TextBox>
                &nbsp;</p>
                <p>
                    (list separated by commas. ex: Arizona, Utah, Texas, ... )
                </p>
                <p>
                    Established In:
                    <asp:TextBox ID="txtParkEstablished_In" runat="server"></asp:TextBox>
                </p>
                <p>
                    <asp:Button ID="btnCreatePark" runat="server" OnClick="btnCreatePark_Click" Text="Add Park" />
                </p>
                <asp:Xml ID="XmlView" runat="server" TransformSource="~/App_Data/transform.xslt" Visible="False"></asp:Xml>
                <p>
                    &nbsp;</p>
                <p>
                    XML Verification</p>
                <p>
                    XML URL:
                    <asp:TextBox ID="txtXML_URL" runat="server"></asp:TextBox>
                </p>
                <p>
                    XML Schema URL:
                    <asp:TextBox ID="txtSchema_URL" runat="server"></asp:TextBox>
                </p>
                <p>
                    <asp:Button ID="btnVerifyXML" runat="server" Text="Verify XML" OnClick="btnVerifyXML_Click" />
                </p>
                <p>
                    <asp:Label ID="lblVerifyXMLResult" runat="server" Text="placeholder" Visible="False"></asp:Label>
                </p>
            </section>
        </div>
    </main>

</asp:Content>
