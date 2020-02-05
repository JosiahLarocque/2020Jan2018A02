<Query Kind="Program">
  <Connection>
    <ID>30467387-5845-448a-90b1-61c8e3c64916</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

void Main()
{
	//Nested Queries
	
	//a query within a query
	
	//the query is returned as an IEnumerable<T> or IQueryable<T>
	//if you need to return your query as a List<T> then you must 
	//	encapsulate your query and add a .ToList() on the query
	//	(from ....).ToList()
	
	//.ToList() is also useful if you require your data in memory
	//	for some execution
	
	//Create a list of albums showing their title and artist.
	// Show only albums with 25 or more tracks.
	//Show the songs on the album (name and length)
	//Use strongly datatyped elements for all data
	
	//	Artist		Album		Track
	// 	 .Name		 .Title		 List<T> t:(name,length)
	
	var results = from x in Albums
					where x.Tracks.Count() >= 25
					select new MyPlayList
					{
						AlbumTitle = x.Title,
						ArtistName = x.Artist.Name,
						Songs = (from trk in x.Tracks
								select new Song
								{
									SongName = trk.Name,
									SongLength = trk.Milliseconds
								}).ToList()
					};
	results.Dump();
	
	
	//Create a list of Playlist with more than 15 tracks.
	//show the playlist name, count of tracks, total play time for 
	// 	the playlist and the list of tracks on the playlist
	//For each track show the song name and Genre.
	//Order the track list by Genre.
	//Use strong datatypes for all data.
	
	
	//Playlist		PlaylistTracks		Tracks
	// .Name		 .Count()			 List<T> t:(Name,milliseconds.Sum())
	
	
	var exercise = from x in Playlists
					where x.PlaylistTracks.Count() >= 15
					select new ExcercisePlaylist
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
	
	exercise.Dump();
}

// Define other methods and classes here


//POCO: flat data collection, No Structures (List, arrays, structs)
public class Song
{
	public string SongName{get;set;}
	public int SongLength{get;set;}
	
}

//DTO: everything of a POCO PLUS structure
public class MyPlayList
{
	public string AlbumTitle{get;set;}
	public string ArtistName{get;set;}
	public List<Song> Songs {get;set;}
	
}

public class ExcercisePlaylist
{
	public string Name{get;set;}
	public int TrackCount{get;set;}
	public int PlayTime {get;set;}
	public IEnumerable<PlaylistSong> PlaylistSongs {get;set;}
}

public class PlaylistSong
{
	public string SongName{get;set;}
	public string Genre{get;set;}
}
