<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RepeaterDemo.aspx.cs" Inherits="WebApp.SamplePages.RepeaterDemo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Repeater for Nested Query</h1>
    <blockquote>
        this page will demonstrate the Repeater control.
        <br /><br />
        To ease the working with the
    </blockquote>
    <div class="row">
        <div class="col-md-6 text-center">
            Enter the size of the playlist to view: &nbsp;&nbsp;
            <asp:TextBox ID="NumberOfTracks" runat="server"></asp:TextBox>
            <asp:Button ID="Submit" runat="server" Text="Submit" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-6 text-center">
            <asp:RequiredFieldValidator ID="RequiredNumberOfTracks" runat="server" 
                ErrorMessage="The playlist size is required" Display="None"
                SetFocusOnError="true" ForeColor="Firebrick"
                ControlToValidate="NumberOfTracks"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareNumberOfTracks" runat="server" 
                ErrorMessage="The playlist size must be a positve whole number"
                Display="None"
                SetFocusOnError="true" ForeColor="Firebrick"
                ControlToValidate="NumberOfTracks" Operator="GreaterThan"
                ValueToCompare="0" Type="Integer"></asp:CompareValidator>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        </div>
    </div>
    <div class="row">
        <div class="offset-3">
            <%-- The repeater at the highest level gets its data 
                using the DatasourceID attribute BECAUSE
                it is accessing an ODS control
                
                Add an itemType to have access to the data definition
                of your DTO.
                To refer to the definitions you will use the keyword 
                Item.propertyname--%>
            <asp:Repeater ID="ClientPlaylistDTO" runat="server" 
                DataSourceID="ClientPlaylistDTOODS"
                ItemType="ChinookSystem.Data.DTOs.ClientPlaylist">
                <HeaderTemplate>
                    <h2> Client Playlists for Requested Size</h2>
                </HeaderTemplate>
                <ItemTemplate>
                    <h3><%# Item.Name %> (playtime: <%# Item.PlayTime %>)</h3>
                    <%-- the POCO list of data can be handled using
                        GridView, Listvie, Repeater, ....
                        
                        The repeater at the highest level gets its data 
                        using the DatasourceID attribute BECAUSE
                        it is accessing the Item.Property of the record--%>
                    <asp:Repeater ID="SongList" runat="server"
                         DataSource='<%# Item.PlaylistSongs %>' 
                         ItemType="ChinookSystem.Data.POCOs.PlaylistSong">
                        <ItemTemplate>
                            <%# Item.SongName %> &nbsp;&nbsp; <%# Item.Genre %><br />
                        </ItemTemplate>
                    </asp:Repeater>
                    
                </ItemTemplate>
                <SeparatorTemplate>
                    <hr style="height:3px"/>
                </SeparatorTemplate>
                <FooterTemplate>
                    &copy Data is sensitive. Do not release
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>

    <asp:ObjectDataSource ID="ClientPlaylistDTOODS" runat="server"
        OldValuesParameterFormatString="original_{0}"
        SelectMethod="Playlist_GetBySize"
        TypeName="ChinookSystem.BLL.PlaylistController">

        <SelectParameters>
            <asp:ControlParameter ControlID="NumberOfTracks"
                PropertyName="Text"
                DefaultValue="1"
                Name="playlistsize" Type="Int32"></asp:ControlParameter>
        </SelectParameters>

    </asp:ObjectDataSource>
</asp:Content>
