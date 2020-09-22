using System;

namespace SampleUi.Models
{
    public class TodoListItem
    {
        public Guid TodoListId { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}