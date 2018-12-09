using System;

namespace pomo_api.Models
{
    public enum TaskSize
    {
        Small = 0,
        Medium = 1,
        Large = 2
    }

    public class Task
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public TaskSize Size { get; set; }
    }
}