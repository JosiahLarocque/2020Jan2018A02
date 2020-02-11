<Query Kind="Expression">
  <Connection>
    <ID>b2a0b946-0901-4e96-9132-ea0a3523cade</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

//Grouping

//basically, grouping is the technique of placing a large pile of data
// into smaller piles of data depending on a criteria

//navigational properties allow for natural grouping of parent to child (pkey/fkey)
//	collections
//ex tablerowinstance.childnavproperty.Count() counts all the child 
//		records associated with the parent instance

//problem: what if there is no navigational property for the grouping
//	of the data collection?

//Here you can use teh group clause to create a set of smaller collections
//	based on the desired criteria

//It is important to remember that once the smaller groups are created, ALL
//	reporting MUST use the smaller groups as the collection reference

//Report albums by ReleaseYear 
from x in Albums
group x by x.ReleaseYear into gYear
select gYear

//parts of a Group
//Key Component
//instance collection component

//side note hot key for commenting
// ctrl + K + C
// ctrl + K + U

//The key component is created by the "by" criteria
//the "by" criteria can be
// a) a single attribute/property
// b) a class
// c) a list of attributess/properties

//Where and Orderby clauses can be executed against the 
//	group key component or group field
//you can filter(where) or order before grouping
//however, Orderby before grouping is basically useless

//Report albums by ReleaseYear showing the year and 
// the number of Albums for that year. Order by the
// year with the most albums, then by the year within count.

from x in Albums 
group x by x.ReleaseYear into gYear
orderby gYear.Count() descending, gYear.Key
select new
{
	year = gYear.Key,
	albumcount = gYear.Count()
}


//Report albums by ReleaseYear showing the year and 
// the number of Albums for that year. Order by the
// year with the most albums, then by the year within count.
// the album title, artist name and number of album tracks.
// Report ONLY albums of the 90s. 

from x in Albums 
where x.ReleaseYear > 1989 && x.ReleaseYear < 2000
group x by x.ReleaseYear into gYear
orderby gYear.Count() descending, gYear.Key
select new
{
	year = gYear.Key,
	albumcount = gYear.Count(),
	albumandartist = from gr in gYear
					 select new
					 {
					 	title = gr.Title,
						artist = gr.Artist.Name,
						trackcount = gr.Tracks.Count(trk => trk.AlbumId == gr.AlbumId)
					 }
}

//Grouping can be done on entity attributes determined using a
//	navigational property.
//List tracks for albums produced after 2010 by Genre name. Count
//	tracks for the Name

from trk in Tracks
where trk.Album.ReleaseYear > 2010
group trk by trk.Genre.Name into gTemp
orderby gTemp.Key.Name
//select gTemp
select new 
{
	genre = gTemp.Key,
	numbreof = gTemp.Count()
}

//same report but using the entity as the group criteria
//when you have multiple attributes in a group key
//	you must reference the attribute using Key.attribute

from trk in Tracks
where trk.Album.ReleaseYear > 2010
group trk by trk.Genre into gTemp
orderby gTemp.Key.Name
//select gTemp
select new 
{
	genre = gTemp.Key.Name,
	numbreof = gTemp.Count()
}

//Using Group techniques, create a list of customers by
//	employee support individual showing the employee name
//	lastname, firstname (phone); the number of customers
//	for this employee; and a customer list for the
//	employee. In this customer list show the state, city
//	and customer name (last, first). Order the customer 
//	list by state then city

//decision one: where to start: group the customers
//						   Why: easy to reach parent info usng nProperties
//group on what?:group customers on a specific employee 
//				:report info about employee (lastname, firstname, phone)
//would grouping on the employee entity supply the employee info in the Key?
//decision two: group the customers by the employee support entity
from c in Customers
group c by c.SupportRepIdEmployee into gTemp
select new
{
	employee = gTemp.Key.LastName + ", " + gTemp.Key.FirstName + " (" + gTemp.Key.Phone + ")",
	customercount = gTemp.Count(),
	customers = from gc in gTemp
				orderby gc.State, gc.City
				select new
				{
					state = gc.State,
					city = gc.City,
					name = gc.LastName + ", " + gc.FirstName
				}
}













