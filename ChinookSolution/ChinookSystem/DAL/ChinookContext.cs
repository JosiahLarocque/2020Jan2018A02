using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region
using System.Data.Entity;
using ChinookSystem.Data.Entities;
#endregion

namespace ChinookSystem.DAL
{

    internal class ChinookContext:DbContext
    {
        //constructor will pass the connection string name to the database
        //      to Entityframework via DbContext
        public ChinookContext():base("ChinookDB")
        {

        }
                
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album>  Albums { get; set; }

    }
   
}
