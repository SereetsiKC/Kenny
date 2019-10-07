<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Appointments.aspx.cs" Inherits="HospitalManagementSystem.Paitients.Appointments" %>
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
        #menu .current_page_item2 a {
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
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <ul>
			<li id="search" >
				<h2>Search</h2>
				<form method="get" action="index.aspx">
					<fieldset>
					<input type="text" id="s" name="s" value="" />
					<input type="submit" id="x" value="Search" />
					</fieldset>
				</form>
			</li>
        </ul>
        <hr style="width:100%; visibility:hidden;"/>
        <div class="post">
            <h1 class="title">List Of appointments After Search(Download links)</h1>
            <div class="entry">
                <p>

                </p>
            </div>
            <div class="meta">
                <p class="byline">Posted on january 05, 2016 Boipelo Medical file System</p>
                <p class="links"><a href="#" class="more">Read full article</a> <b>|</b><%--</b> <a href="#" class="comments">Comments (0)</a>--%></p>
            </div>
        </div>
        <div class="post">
            <h2 class="title">Title</h2>
            <div class="entry">
                <p>1st paragraph</p>
                <p>2nd paragraph</p>
            </div>
            <div class="meta">
                <p class="byline">Posted on July 18, 2007</p>
                <p class="links"><a href="#" class="more">Read full article</a> <b>|</b> <a href="#" class="comments">Comments (0)</a></p>
            </div>
        </div>
    </div>
</asp:Content>
