using System;
namespace TestProjectAllocation
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProjectTask> Tasks { get; set; }

        public Person(int id, string name)
        {
            Id = id;
            Name = name;
            Tasks = new List<ProjectTask>();
        }

        public DateTime GetEndDateOfTasks(DateTime startDate)
        {
            DateTime endDate = startDate;
            foreach (ProjectTask task in Tasks)
            {
                if (task.AssignedTo == this && task.EndTime > endDate)
                {
                    endDate = task.EndTime;
                }
            }
            return endDate;
        }

        public DateTime NextAvailableDate(DateTime startDate)
        {
            DateTime endDate = GetEndDateOfTasks(startDate);
            if (endDate <= startDate)
            {
                return startDate;
            }
            else
            {
                return endDate.AddDays(1);
            }
        }

        public bool IsAvailable(DateTime startDate, DateTime endDate)
        {
            foreach (var task in Tasks)
            {
                if (task.StartTime <= endDate && task.EndTime >= startDate)
                {
                    // Person is not available during this date range
                    return false;
                }
            }

            // Person is available during this date range
            return true;
        }
    }
}

