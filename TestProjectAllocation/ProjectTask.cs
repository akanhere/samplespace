using System;
namespace TestProjectAllocation
{
    public enum TaskStatus
    {
        NotStarted,
        Unassigned,
        Assigned,
        Completed,
        Overdue
    }

    public class ProjectTask
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TaskStatus Status { get; set; }
        public Person AssignedTo { get; set; }
        public DateTime Deadline { get; set; }

        public ProjectTask(int id, string description, DateTime startTime, DateTime endTime, TaskStatus status, DateTime deadline)
        {
            Id = id;
            Description = description;
            StartTime = startTime;
            EndTime = endTime;
            Status = status;
            Deadline = deadline;
        }
    }
}

