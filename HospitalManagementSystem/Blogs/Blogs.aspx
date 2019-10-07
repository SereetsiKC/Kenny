<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Blogs.aspx.cs" Inherits="HospitalManagementSystem.Blogs.Blogs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="refresh" content="10"/> 
    <style type="text/css">
        #menu .current_page_item a
        {
            color: #FFFFFF;
        }
        #menu .current_page_item1 a
        {
            color: #48ACDE;
        }
        #menu .current_page_item2 a {
	        color: #FFFFFF;
        }
        #menu .current_page_item3 a
        {
            color: #FFFFFF;
        }
        #menu .current_page_item4 a
        {
            color: #FFFFFF;
        }
        /*ScrollBar Design*/
        #scrollBar
        {
            width:100%;
        }
        
       #content > ::-webkit-scrollbar {
            height: 12px;
            width: 5px;
            background: #000;
        }

        #content > ::-webkit-scrollbar-thumb {
            background: #48ACDE;
            -webkit-border-radius: 1ex;
            -webkit-box-shadow: 0px 1px 2px rgba(0, 0, 0, 0.75);
        }

#scrollBar > ::-webkit-scrollbar-corner {
    background: #000;
} 
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content" >
        <p>
            <strong><a href="Blogs.aspx">
                <img style="float: left;" title="BlogFrog_Logo" src="../images/BlogFrog_Logo.jpg" alt="" width="300" height="101" /></a></strong>
            <em style="font-size:larger;">A conversation with Holly Humann</em>
        </p>
        <div id="scrollBar" style="height: 800px; overflow: auto; overflow-x: hidden; overflow-style: move;">
            <asp:Literal runat="server" ID="myLiteral" />
        </div>
    </div>    
</asp:Content>
