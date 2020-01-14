using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region
using ChinookSystem.Data.Entities;
using ChinookSystem.DAL;
using System.ComponentModel; //ODS
#endregion
namespace ChinookSystem.BLL
{
    [DataObject]
    public class AlbumController
    {
        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public List<Album> Album_List()
        {
            //set up the code block to ensure the release of the sql connection
            using (var context = new ChinookContext())
            {
                //.ToList<T> is used to convert the DbSet<T> into a List<T> collection
                return context.Albums.ToList();
            }
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public Album Album_FindByID(int albumid)
        {
            using (var context = new ChinookContext())
            {
                return context.Albums.Find(albumid);
            }
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Album> Album_FindByArtist(int artistid)
        {
            using (var context = new ChinookContext())
            {
                var results = from albumrow in context.Albums
                              where albumrow.ArtistId == artistid
                              select albumrow;
                return results.ToList();
            }
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Album> Album_FindByTitle (string title)
        {
            using (var context = new ChinookContext())
            {
                var results = from albumrow in context.Albums
                              where albumrow.Title.Contains(title)
                              select albumrow;
                return results.ToList();
            }
        }
    }
}
