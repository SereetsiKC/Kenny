<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Members.aspx.cs" Inherits="HospitalManagementSystem.AdminPages.Members" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div id="content">
        <div class="post">
            <h1 class="title">Member Registration</h1>
            <div class="entry">
                <p style="height:125px;">
                    <img id="Profile" src="#" alt="" width="140" height="125" class="left" /></p>
                <hr style="visibility: hidden; width: 100%;" />
                <hr style="visibility: hidden; width: 100%;" />
                <div class="col-xs-5">
                    <label for="ex1">Title :</label>
                    <asp:DropDownList ID="DDLtitle" runat="server" CssClass="form-control">
                        <asp:ListItem>Mr</asp:ListItem>
                        <asp:ListItem>Mrs</asp:ListItem>
                        <asp:ListItem>Miss</asp:ListItem>
                        <asp:ListItem>Madam</asp:ListItem>
                        <asp:ListItem>Ms</asp:ListItem>
                        <asp:ListItem>Doctor</asp:ListItem>
                        <asp:ListItem>Proffessor</asp:ListItem>
                        <asp:ListItem>Sir</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <hr style="visibility: hidden; width: 100%;" />
                <div class="col-xs-5">
                    <label for="ex1">ID Number :</label>
                    <asp:TextBox ID="txtIDNo" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <hr style="visibility: hidden; width: 100%;" />
                <div class="col-xs-5">
                    <label for="ex1">Name(s) :</label>
                    <asp:TextBox ID="txtNames" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <hr style="visibility: hidden; width: 100%;" />
                <div class="col-xs-5">
                    <label for="ex1">Surname :</label>
                    <asp:TextBox ID="txtSurname" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <hr style="visibility: hidden; width: 100%;" />
                <div class="col-xs-5">
                    <label for="ex1">E-mail Address :</label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" AutoPostBack="True"></asp:TextBox>
                </div>
                <hr style="visibility: hidden; width: 100%;" />
                <div class="col-xs-5">
                    <label for="ex1">Cell Number :</label>
                    <asp:TextBox ID="txtCell" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <hr style="visibility: hidden; width: 100%;" />
                <div class="col-xs-5">
                    <label for="ex1">Tel No :</label>
                    <asp:TextBox ID="txtTel" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <hr style="visibility: hidden; width: 100%;" />
                <div class="col-xs-5">
                    <label for="ex1">Gender :</label>
                    <asp:RadioButtonList ID="RDLGender" runat="server" AutoPostBack="True">
                        <asp:ListItem>Female</asp:ListItem>
                        <asp:ListItem>Male</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <hr style="visibility: hidden; width: 100%;" />
                <div class="col-xs-5">
                    <label for="ex1">Race :</label>
                    <asp:RadioButtonList ID="RDLRace" runat="server">
                        <asp:ListItem>White</asp:ListItem>
                        <asp:ListItem>Black</asp:ListItem>
                        <asp:ListItem>Coloured</asp:ListItem>
                        <asp:ListItem>Asian</asp:ListItem>
                        <asp:ListItem>Indian</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <hr style="visibility: hidden; width: 100%;" />
                <div class="col-xs-5">
                    <label for="ex1">Residential Address :</label>
                    <asp:TextBox ID="txtResidentialAddress" runat="server" CssClass="form-control" Height="97px" TextMode="MultiLine"></asp:TextBox>
                </div>
                <hr style="visibility: hidden; width: 100%;" />
                <div class="col-xs-5">
                    <label for="ex1">Postal Address :</label>
                    <asp:TextBox ID="txtPostalAddress" runat="server" CssClass="form-control" Height="97px" TextMode="MultiLine"></asp:TextBox>
                </div>
                <hr style="visibility: hidden; width: 100%;" />
                <div class="col-xs-5">
                    <label for="ex1">Occupation :</label>
                </div>
                <hr style="visibility: hidden; width: 100%;" />
                <div class="col-xs-5">
                    <label for="ex1">Facility Name :</label>
                </div>
                <hr style="visibility: hidden; width: 100%;" />
                <div class="col-xs-5">
                    <fieldset class="links">
                        <legend style="color: #48ACDE;">Login Information</legend>
                        <hr style="visibility: hidden; width: 100%;" />
                        <div class="col-xs-5">
                            <label for="ex1">Username :</label>
                            <asp:Label ID="lblUsername" runat="server" Text="Label">Username</asp:Label>
                        </div>
                        <hr style="visibility: hidden; width: 100%;" />
                        <div class="col-xs-5">
                            <label for="ex1">Password :</label>
                            <asp:TextBox ID="txtPassword1" runat="server" CssClass="form-control" TextMode="Password" ValidationGroup="reg"></asp:TextBox>
                        </div>
                        <hr style="visibility: hidden; width: 100%;" />
                        <div class="col-xs-5">
                            <label for="ex1">Confirm Password :</label>
                            <asp:TextBox ID="txtPassword2" runat="server" CssClass="form-control" TextMode="Password" ValidationGroup="reg"></asp:TextBox>
                        </div>
                        <div class="col-xs-5">
                            <label for="ex1">Profile Image :</label>
                            <ajaxToolkit:AjaxFileUpload ID="AjaxFileUpload1" runat="server" MaximumNumberOfFiles="1" />
                        </div>
                    </fieldset>
                </div>
                <hr style="visibility: hidden; width: 100%;" />
                <div class="meta">
                <p class="links"><asp:LinkButton ID="LBClear" runat="server" CssClass="clear" >Clear</asp:LinkButton><b>|</b><asp:LinkButton ID="LBUpdate" runat="server" CssClass="update" ValidationGroup="reg" >Update</asp:LinkButton> <b>|</b><asp:LinkButton ID="LBReg" runat="server" CssClass="reg" ValidationGroup="reg">Register</asp:LinkButton> </p>
            </div>
            </div>
        </div>
    </div>
   
</asp:Content>
