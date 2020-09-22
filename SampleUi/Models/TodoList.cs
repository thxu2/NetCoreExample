using System;
using System.Collections.Generic;

namespace SampleUi.Models
{
    public class TodoList
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public IEnumerable<TodoListItem> Items { get; set; }
    }
}