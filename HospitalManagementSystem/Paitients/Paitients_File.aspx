<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Paitients_File.aspx.cs" Inherits="HospitalManagementSystem.Paitients.Paitients_File" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #menu .current_page_item a
        {
            color: #FFFFFF;
        }

        #menu .current_page_item1 a
        {
            color: #FFFFFF;
        }

        #menu .current_page_item2 a
        {
            color: #48ACDE;
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div id="content">
        <ul>
            <li id="search">
                <h2>Search</h2>
                <form method="get" action="index.aspx">
                    <fieldset>
                        <asp:TextBox ID="txtSearch" runat="server" CssClass="s"></asp:TextBox>
                        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="x" BackColor="#48ACDE" ForeColor="White" />
                    </fieldset>
                </form>
            </li>
        </ul>
        <hr style="width: 100%; visibility: hidden;" />
        <div class="post" style="overflow: auto; height: 500px;">
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" BackColor="#333333"></rsweb:ReportViewer>
        </div>
        <hr style="width: 100%; visibility: hidden;" />
        <div class="post">
            
        </div>
        <div class="meta">
            <p class="byline">Posted on July 18, 2007</p>
            <p class="links"><a href="#" class="more">Read full article</a> <b>|</b> <a href="#" class="comments">Comments (0)</a></p>
        </div>
    </div>
</asp:Content>
