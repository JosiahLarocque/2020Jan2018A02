<Query Kind="Statements">
  <Connection>
    <ID>b2a0b946-0901-4e96-9132-ea0a3523cade</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

var results = from x in Albums
				select new
				{
					AlbumTitle = x.Title,
					Year = x.ReleaseYear,
					ArtistName = x.Artist.Name
				};

//.Dump() is a LinqPad method ONLY 
results.Dump();