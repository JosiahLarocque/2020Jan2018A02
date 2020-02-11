<Query Kind="Expression">
  <Connection>
    <ID>30467387-5845-448a-90b1-61c8e3c64916</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

//select all albums
from x in Albums
select x

Albums.Select(x => x)


from x in Albums
where x.ReleaseYear >= 2007 && x.ReleaseYear <= 2010 
orderby x.ReleaseYear descending, x.Title
select x

//or this

Albums.WHERE(x => x.ReleaseYear >= 2007 && x.ReleaseYear <= 2010)
	.OrderByDescending(x => x.ReleaseYear)
	.ThenBy(x => x.Title)
	.Select(x => x)



//--------------------------


from x in Customers
where x.Country.Equals("USA") && x.Email.Contains("yahoo")
orderby x.LastName, x.FirstName
select new
{
	Name = x.LastName + ", " + x.FirstName,
	Email = x.Email,
	Phone = x.Phone
}

 //or this
 
Customers.Where(x => x.Country.Equals("USA") && x.Email.Contains("yahoo"))
	.OrderBy(x => x.LastName)
	.ThenBy(x => x.FirstName)
	.Select(x => new
				{
					Name = x.LastName + ", " + x.FirstName,
					Email = x.Email,
					Phone = x.Phone
				})
				
				
				
//-----------------------------

from x Albums
orderby x.Title
select new
		{
			Title = x.Title,
			Name = x.Artist.Name,
			Year = x.ReleaseYear
			Decade = x.ReleaseYear <
			Early = x.ReleaseYear < 1970 ? "early" :
					x.ReleaseYEar < 1980 ? "70s" :
					x.ReleaseYEar < 1990 ? "80s" :
					x.ReleaseYEar < 2000 ? "90s" : "modern"
		}