<Query Kind="Statements">
  <Connection>
    <ID>6e2f24d4-5301-4ad1-9f17-d8093a4b3246</ID>
    <Persist>true</Persist>
    <Server>aventadorsv\sqlexpress</Server>
    <Database>Schedule</Database>
  </Connection>
</Query>


//1. List all the skills for which we do not have any qualfied employees.


from s in Skills
where !(from es in EmployeeSkills
		select es.SkillID)
		.Contains(s.SkillID)
select s.Description

//2. Show all skills requiring a ticket and which employees have those skills.
	//Include all the data as seen in the following image. Order the employees by years
	//of experience (highest to lowest). Use the following text for the levels:
	//0 = Novice, 1 = Proficient, 2 = Expert. (Hint: Use nested ternary operators to handle the levels as text.)
		
from s in Skills
where s.RequiresTicket == true
select new 
{
	Description = s.Description,
	Employees = (from e in Employees
				 select new
				 {
				 	Name = e.FirstName + " " + e.LastName,
					e.EmployeeSkills.Level = e.Level ? 1 : "Novice" ? 2 : "Proficient" : "Expert",
					YearsExperience = e.YearsOfExperience
				 }
}