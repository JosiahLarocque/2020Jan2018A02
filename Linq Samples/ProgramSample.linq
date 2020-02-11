<Query Kind="Program">
  <Connection>
    <ID>b2a0b946-0901-4e96-9132-ea0a3523cade</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

void Main()
{
	var results = from x in Albums
				select new
				{
					AlbumTitle = x.Title,
					Year = x.ReleaseYear,
					ArtistName = x.Artist.Name
				};

	//.Dump() is a LinqPad method ONLY 
	results.Dump();
}

// Define other methods and classes here
public class AlbumArtists
{
	public string AlbumTitle{get;set;}
	public int Year {get;set;}
	public string ArtistName {get;set;}
}