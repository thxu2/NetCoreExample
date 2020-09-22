using System.Collections.Generic;

namespace SampleApi.Domain
{
    public class TodoList: DataBaseItem
    {
        public string Name { get; set; }
        public string Owner { get; set; }
        public IEnumerable<TodoListItem> Items { get; set; }
    }
}