using System;
namespace TestProjectAllocation
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProjectTask> Tasks { get; set; }

        public List<Person> AssignedPersons
        {
            get
            {
                return Tasks
                    .Where(t => t.AssignedTo != null)
                    .Select(t => t.AssignedTo)
                    .Distinct()
                    .ToList();
            }
        }

        public Project(int id, string name)
        {
            Id = id;
            Name = name;
            Tasks = new List<ProjectTask>();
        }

        public void AssignPerson(Person person, ProjectTask task)
        {
            if (person.Tasks == null)
            {
                person.Tasks = new List<ProjectTask>();
            }

            person.Tasks.Add(task);
            
            task.AssignedTo = person;

            this.Tasks.Add(task);
        }

        public List<Person> AvailablePersons(DateTime startDate, DateTime endDate)
        {
            var availablePersons = new List<Person>();

            foreach (var person in AssignedPersons)
            {
                if (person.IsAvailable(startDate, endDate))
                {
                    availablePersons.Add(person);
                }
                else
                {
                    var nextAvailableDate = person.NextAvailableDate(endDate);
                    Console.WriteLine($"Person {person.Name} is not available during this date range. Next available date is {nextAvailableDate.ToShortDateString()}");
                }
            }

            return availablePersons.OrderBy(p => p.NextAvailableDate(endDate)).ToList();
        }

    }

}

