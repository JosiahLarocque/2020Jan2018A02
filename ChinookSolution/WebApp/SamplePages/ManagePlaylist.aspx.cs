using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additonal Namespaces
using ChinookSystem.BLL;
using ChinookSystem.Data.POCOs;
#endregion

namespace WebApp.SamplePages
{
    public partial class ManagePlaylist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TracksSelectionList.DataSource = null;
        }

        protected void CheckForException(object sender, ObjectDataSourceStatusEventArgs e)
        {
            MessageUserControl.HandleDataBoundException(e);
        }


        protected void ArtistFetch_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(ArtistName.Text))
            {
                //message to the user
                MessageUserControl.ShowInfo("Selection Error", "Select an Artist Name ");
            }
            else
            {
                TracksBy.Text = "Artist";
                SearchArg.Text = ArtistName.Text;
                //bind web form control
                TracksSelectionList.DataBind();
            }

        }

        protected void MediaTypeDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MediaTypeDDL.SelectedIndex == 0)
            {
                //message to the user
                MessageUserControl.ShowInfo("Selection Error", "Select a media type");
            }
            else
            {
                TracksBy.Text = "MediaType";
                SearchArg.Text = MediaTypeDDL.SelectedValue;
                //bind web form control
                TracksSelectionList.DataBind();
            }
        }
        protected void GenreFetch_Click(object sender, EventArgs e)
        {
            if (GenreDDL.SelectedIndex == 0)
            {
                //message to the user
                MessageUserControl.ShowInfo("Selection Error", "Select a genre type");
            }
            else
            {
                TracksBy.Text = "Genre";
                SearchArg.Text = GenreDDL.SelectedValue;
                //bind web form control
                TracksSelectionList.DataBind();
            }

        }

        protected void AlbumFetch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(AlbumTitle.Text))
            {
                //message to the user
                MessageUserControl.ShowInfo("Selection Error", "Enter an Album Title");
            }
            else
            {
                TracksBy.Text = "Album";
                SearchArg.Text = AlbumTitle.Text;
                //bind web form control
                TracksSelectionList.DataBind();
            }

        }

        protected void PlayListFetch_Click(object sender, EventArgs e)
        {
            //code to go here
 
        }

        protected void MoveDown_Click(object sender, EventArgs e)
        {
            //code to go here
 
        }

        protected void MoveUp_Click(object sender, EventArgs e)
        {
            //code to go here
 
        }

        protected void MoveTrack(int trackid, int tracknumber, string direction)
        {
            //call BLL to move track
 
        }


        protected void DeleteTrack_Click(object sender, EventArgs e)
        {
            //code to go here
 
        }

        protected void TracksSelectionList_ItemCommand(object sender, 
            ListViewCommandEventArgs e)
        {
            //code to go here
            
        }

        
    }
}