using System.Collections.Generic;

namespace EFCore_WebApi.Models
{
    public class TaskPriority
    {
        public long TaskPriorityId { get; set; }
        public string Name { get; set; }
        public List<Task> Tasks { get; set; }
    }
}