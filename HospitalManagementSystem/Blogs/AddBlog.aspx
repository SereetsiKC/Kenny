﻿<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="AddBlog.aspx.cs" Inherits="HospitalManagementSystem.Blogs.AddBlog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <div class="post">
            <div class="col-xs-3">
                <label for="ex1">Title :</label>
                <hr style="visibility: hidden; width:100%;" />
                <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <hr style="visibility: hidden; width:100%;" />
            <hr style="visibility: hidden; width:100%;" />
            <div class="entry">
                <div class="col-xs-5">
                <label for="ex1">Title :</label>
                    <hr style="visibility: hidden; width:100%;" />
                <asp:TextBox ID="txtMsg" runat="server" TextMode="MultiLine" Height="271px" Width="562px" CssClass="form-control"></asp:TextBox>
            </div>
                <hr style="visibility: hidden; width:100%;" />
                <hr style="visibility: hidden; width:100%;" />  
            </div>
            <div class="meta">
                <p class="byline" id="Author">...</p>
                <p class="links"><asp:LinkButton ID="LBPost" runat="server" CssClass="more">Post Article</asp:LinkButton><b>|</b><%--</b> <a href="#" class="comments">Comments (0)</a>--%></p>
            </div>
        </div>
    </div>
 
</asp:Content>
