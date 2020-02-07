using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using ChinookSystem.Data.Entities;
using ChinookSystem.DAL;
using System.ComponentModel; //ODS
using DMIT2018Common.UserControls; // used by error handling user control
using ChinookSystem.Data.DTOs;
using ChinookSystem.Data.POCOs;
#endregion

namespace ChinookSystem.BLL
{
    [DataObject]
    public class PlaylistController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<ClientPlaylist> Playlist_GetBySize(int playlistsize)
        {
            using (var context = new ChinookContext())
            {
                var exercise = from x in context.Playlists
                               where x.PlaylistTracks.Count() == playlistsize
                               select new ClientPlaylist
                               {
                                   Name = x.Name,
                                   TrackCount = x.PlaylistTracks.Count(),
                                   PlayTime = x.PlaylistTracks.Sum(pltrk => pltrk.Track.Milliseconds),
                                   PlaylistSongs = (from strk in x.PlaylistTracks
                                                    orderby strk.Track.Genre.Name
                                                    select new PlaylistSong
                                                    {
                                                        SongName = strk.Track.Name,
                                                        Genre = strk.Track.Genre.Name
                                                    })
                               };
                return exercise.ToList();
            }
        }
    }
}
