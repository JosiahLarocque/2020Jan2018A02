using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region
using ChinookSystem.Data.Entities;
using ChinookSystem.DAL;
#endregion
namespace ChinookSystem.BLL
{
    public class ArtistController
    {
        //basic complete list of DBSet
        public List<Artist> Artist_List()
        {
            //set up the code block to ensure the release of the sql connection
            using (var context = new ChinookContext())
            {
                //.ToList<T> is used to convert the DbSet<T> into a List<T> collection
                return context.Artists.ToList();
            }
        }

        //basic query: return a record based on pkey
        public Artist Artist_FindByID(int artistid)
        {
            using (var context = new ChinookContext())
            {
                return context.Artists.Find(artistid);
            }
        }
    }
}
