<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="RegisterPaitient.aspx.cs" Inherits="HospitalManagementSystem.Paitients.RegisterPaitient" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

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
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div id="content">
        <div class="post">
            <h1 class="title">Registration</h1>
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
                    </asp:DropDownList>
                </div>
                <hr style="visibility: hidden; width: 100%;" />
                <div class="col-xs-5">
                    <label for="ex1">ID Number :</label><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtIDNo" ForeColor="Red" ValidationGroup="reg"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtIDNo" runat="server" CssClass="form-control"></asp:TextBox>
                    <ajaxToolkit:MaskedEditExtender ID="txtIDNo_MaskedEditExtender" runat="server" TargetControlID="txtIDNo" Mask="(999999)-9999-9-99" MaskType="Number" />
                </div>
                <hr style="visibility: hidden; width: 100%;" />
                <div class="col-xs-5">
                    <label for="ex1">Name(s) :</label><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtNames" ForeColor="Red" ValidationGroup="reg"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtNames" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <hr style="visibility: hidden; width: 100%;" />
                <div class="col-xs-5">
                    <label for="ex1">Surname :</label><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="txtSurname" ForeColor="Red" ValidationGroup="reg"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtSurname" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <hr style="visibility: hidden; width: 100%;" />
                <div class="col-xs-5">
                    <label for="ex1">E-mail Address :</label><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ControlToValidate="txtEmail" ForeColor="Red" ValidationGroup="reg"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="INVALID" ControlToValidate="txtEmail" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="reg"></asp:RegularExpressionValidator>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" AutoPostBack="True" OnTextChanged="txtEmail_TextChanged"></asp:TextBox>
                </div>
                <hr style="visibility: hidden; width: 100%;" />
                <div class="col-xs-5">
                    <label for="ex1">Cell Number :</label><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ControlToValidate="txtCell" ForeColor="Red" ValidationGroup="reg"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtCell" runat="server" CssClass="form-control"></asp:TextBox>
                    <ajaxToolkit:MaskedEditExtender ID="txtCell_MaskedEditExtender" runat="server" Mask="(999)-999-9999" MaskType="Number" TargetControlID="txtCell" />
                </div>
                <hr style="visibility: hidden; width: 100%;" />
                <div class="col-xs-5">
                    <label for="ex1">Tel No :</label><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ControlToValidate="txtTel" ForeColor="Red" ValidationGroup="reg"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtTel" runat="server" CssClass="form-control"></asp:TextBox>
                    <ajaxToolkit:MaskedEditExtender ID="txtTel_MaskedEditExtender" runat="server" Mask="(999)-999-9999" MaskType="Number" TargetControlID="txtTel" />
                </div>
                <hr style="visibility: hidden; width: 100%;" />
                <div class="col-xs-5">
                    <label for="ex1">Gender :</label><asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ControlToValidate="RDLGender" ForeColor="Red" ValidationGroup="reg"></asp:RequiredFieldValidator>
                    <asp:RadioButtonList ID="RDLGender" runat="server" OnSelectedIndexChanged="RDLGender_SelectedIndexChanged" AutoPostBack="True">
                        <asp:ListItem>Female</asp:ListItem>
                        <asp:ListItem>Male</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <hr style="visibility: hidden; width: 100%;" />
                <div class="col-xs-5">
                    <label for="ex1">Race :</label><asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" ControlToValidate="RDLRace" ForeColor="Red" ValidationGroup="reg"></asp:RequiredFieldValidator>
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
                    <label for="ex1">Residential Address :</label><asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*" ControlToValidate="txtResidentialAddress" ForeColor="Red" ValidationGroup="reg"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtResidentialAddress" runat="server" CssClass="form-control" Height="97px" TextMode="MultiLine"></asp:TextBox>
                </div>
                <hr style="visibility: hidden; width: 100%;" />
                <div class="col-xs-5">
                    <label for="ex1">Postal Address :</label><asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*" ControlToValidate="txtPostalAddress" ForeColor="Red" ValidationGroup="reg"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtPostalAddress" runat="server" CssClass="form-control" Height="97px" TextMode="MultiLine"></asp:TextBox>
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
                            <label for="ex1">Password :</label><asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*" ControlToValidate="txtPassword1" ForeColor="Red" ValidationGroup="reg"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txtPassword1" runat="server" CssClass="form-control" TextMode="Password" ValidationGroup="reg"></asp:TextBox>
                        </div>
                        <hr style="visibility: hidden; width: 100%;" />
                        <div class="col-xs-5">
                            <label for="ex1">Confirm Password :</label><asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="NOT A MATCH" ControlToCompare="txtPassword1" ControlToValidate="txtPassword2" ForeColor="Red" ValidationGroup="reg"></asp:CompareValidator>
                            <asp:TextBox ID="txtPassword2" runat="server" CssClass="form-control" TextMode="Password" ValidationGroup="reg"></asp:TextBox>
                        </div>
                        <div class="col-xs-5">
                            <label for="ex1">Profile Image :</label>
                            <ajaxToolkit:AjaxFileUpload ID="AjaxFileUpload1" runat="server" AllowedFileTypes="jpg,png,jpeg" MaximumNumberOfFiles="1" OnUploadComplete="AjaxFileUpload1_UploadComplete" />
                        </div>
                    </fieldset>
                </div>
                <hr style="visibility: hidden; width: 100%;" />
                <div class="meta">
                <p class="links"><asp:LinkButton ID="LBClear" runat="server" CssClass="clear" OnClick="LBClear_Click">Clear</asp:LinkButton> <b>|</b><asp:LinkButton ID="LBReg" runat="server" CssClass="reg" ValidationGroup="reg" OnClick="LBReg_Click">Register</asp:LinkButton> </p>
            </div>
            </div>
        </div>
    </div>
    
</asp:Content>
