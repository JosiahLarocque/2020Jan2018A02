using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using ChinookSystem.Data.Entities;
using ChinookSystem.Data.DTOs;
using ChinookSystem.Data.POCOs;
using ChinookSystem.DAL;
using System.ComponentModel;
using DMIT2018Common.UserControls;
#endregion

namespace ChinookSystem.BLL
{
    public class PlaylistTracksController
    {
        public List<UserPlaylistTrack> List_TracksForPlaylist(
            string playlistname, string username)
        {
            using (var context = new ChinookContext())
            {

                List<UserPlaylistTrack> results = (from x in context.PlaylistTracks
                                                  where x.Playlist.Name.Equals(playlistname)
                                                    && x.Playlist.UserName.Equals(username)
                                                  orderby x.TrackNumber
                                                  select new UserPlaylistTrack
                                                  {
                                                      TrackID = x.TrackId,
                                                      TrackNumber = x.TrackNumber,
                                                      TrackName = x.Track.Name,
                                                      Milliseconds = x.Track.Milliseconds,
                                                      UnitPrice = x.Track.UnitPrice
                                                  }).ToList();

                return null;
            }
        }//eom
        public void Add_TrackToPLaylist(string playlistname, string username, int trackid)
        {
            using (var context = new ChinookContext())
            {
                //trx
                //query the Playlist Table to see if the playlistname exists
                //if not 
                //  create an instance of Playlist
                //  load
                //  add
                //  set tracknumber to 1
                //if yes
                //  query Playlist for max tracknumber, increment++
                //  query PlaylistTrack for track id
                //  if found 
                //      yes:throw an error
                //      no:query Playlist to max tracknumber, increment++
                //create an instance of PlaylistTrack
                //load 
                //add
                //save changes
                List<string> errors = new List<string>();
                int tracknumber = 0;
                PlaylistTrack newtrack = null;
                Playlist exists = (from x in context.Playlists
                                        where x.Name.Equals(playlistname)
                                            && x.UserName.Equals(username)
                                        select x).FirstOrDefault();
                if (exists == null)
                {
                    //new playlist
                    exists = new Playlist();
                    exists.Name = playlistname;
                    exists.UserName = username;
                    context.Playlists.Add(exists); //"add"stages ONLY
                    tracknumber = 1;
                }
                else
                {
                    //playlist that exists
                    newtrack = (from x in context.PlaylistTracks
                                where x.Playlist.Name.Equals(playlistname)
                                    && x.Playlist.Name.Equals(username)
                                    && x.TrackId == trackid
                                select x).FirstOrDefault(); 
                    if (newtrack == null)
                    {
                        //can add to playlist
                        tracknumber = (from x in context.PlaylistTracks
                                       where x.Playlist.Name.Equals(playlistname)
                                           && x.Playlist.Name.Equals(username)
                                       select x.TrackNumber).Max();
                        tracknumber++;
                    }
                    else
                    {
                        //track already on playlist
                        //business rule states duplicate track not allowed
                        //violates the business rule 

                        //throw an exception
                        //throw new Exception("Track already on the playlist. Duplicates not allowed.");

                        //throw a business rule exception
                        //collect the errors into a List<string> 
                        //after all validation is done test the collection (List<T> for
                        //  having any messages, if so, throw new BusinessRuleException()
                        errors.Add("Track already on the playlist. Duplicates not allowed.");
                        
                    }
                    //all validation of Playlist and PlaylistTrack is complete
                    if (errors.Count > 0)
                    {
                        throw new BusinessRuleException("Adding a track", errors);
                    }
                    else
                    {
                        //create/load/add a PlaylistTrack
                        newtrack = new PlaylistTrack();
                        newtrack.PlaylistId = exists.PlaylistId;
                        newtrack.TrackId = trackid;
                        newtrack.TrackNumber = tracknumber;
                        context.PlaylistTracks.Add(newtrack); //stage ONLY, USE THE PARENT

                        context.SaveChanges();
                    }
                }

                
             
            }
        }//eom
        public void MoveTrack(string username, string playlistname, int trackid, int tracknumber, string direction)
        {
            using (var context = new ChinookContext())
            {
                //code to go here 

            }
        }//eom


        public void DeleteTracks(string username, string playlistname, List<int> trackstodelete)
        {
            using (var context = new ChinookContext())
            {
               //code to go here


            }
        }//eom
    }
}
