<Query Kind="Expression">
  <Connection>
    <ID>b2a0b946-0901-4e96-9132-ea0a3523cade</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

from x in Albums
select x

Albums
	.Select (x => x)
	
Albums

from x in Albums
where x.AlbumId == 5
select x

from x in Albums
where x.Title.Contains("de")
select x

from x in Tracks
where x.GenreId.HasValue
select x

from x in Employees
where !x.ReportsTo.HasValue
select x

from x in Albums
where x.Title.Contains("de")
orderby x.ReleaseYear descending, x.Title
select x

from x in Albums
select new
{
	AlbumTitle = x.Title,
	Year = x.ReleaseYear,
	ArtistName = x.Artist.Name
}