// See https://aka.ms/new-console-template for more information
using TestProjectAllocation;
using TaskStatus = TestProjectAllocation.TaskStatus;

Console.WriteLine("Hello, World!");
Console.WriteLine("Wow");


// Instantiate Person objects
var person1 = new Person(1, "John Smith");
var person2 = new Person(2, "Jane Doe");
var person3 = new Person(3, "Bob Johnson");
var person4 = new Person(4, "Emily Lee");
var person5 = new Person(5, "New Person");

var allPeople = new List<Person> { person1, person2, person3, person4, person5 };

// Instantiate Task objects
var task1 = new ProjectTask(1, "Design UI", new DateTime(2023, 5, 15, 9, 0, 0), new DateTime(2023, 5, 15, 12, 0, 0), TaskStatus.NotStarted, new DateTime(2023, 5, 17));
var task2 = new ProjectTask(2, "Implement database", new DateTime(2023, 5, 16, 13, 0, 0), new DateTime(2023, 5, 16, 18, 0, 0), TaskStatus.NotStarted, new DateTime(2023, 5, 19));
var task3 = new ProjectTask(3, "Write unit tests", new DateTime(2023, 5, 17, 9, 0, 0), new DateTime(2023, 5, 17, 12, 0, 0), TaskStatus.NotStarted, new DateTime(2023, 5, 20));
var task4 = new ProjectTask(4, "Implement authentication", new DateTime(2023, 5, 18, 13, 0, 0), new DateTime(2023, 5, 18, 18, 0, 0), TaskStatus.NotStarted, new DateTime(2023, 5, 22));
var task5 = new ProjectTask(5, "Code review", new DateTime(2023, 5, 19, 9, 0, 0), new DateTime(2023, 5, 19, 12, 0, 0), TaskStatus.NotStarted, new DateTime(2023, 5, 23));
var task6 = new ProjectTask(6, "Prepare deployment", new DateTime(2023, 5, 22, 9, 0, 0), new DateTime(2023, 5, 22, 18, 0, 0), TaskStatus.NotStarted, new DateTime(2023, 5, 24));
// Instantiate Project object
var project1 = new Project(1, "My Project");

project1.AssignPerson(person1, task1);
project1.AssignPerson(person1, task2);
project1.AssignPerson(person2, task3);

var project2 = new Project(2, "My OtherProject");

project2.AssignPerson(person4, task4);
project2.AssignPerson(person3, task5);
project2.AssignPerson(person2, task6);

Project project3 = new Project(3, "Project 3");
DateTime startDate = DateTime.Parse("2023-06-12");
List<Person> availablePeople = new List<Person>();
//foreach (Person person in project1.AssignedPersons.Concat(project2.AssignedPersons))
foreach (Person person in allPeople)
{
    DateTime nextAvailableDate = person.NextAvailableDate(startDate);
    if (nextAvailableDate <= startDate)
    {
        availablePeople.Add(person);
        Console.WriteLine($"Availble, will be available by- {person.Name}: {person.NextAvailableDate(startDate)}");

    }
    else
    {
        Console.WriteLine($"Not Availble, will be available by- {person.Name}: {person.NextAvailableDate(startDate)}");
    }
}


