using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleApi.Domain
{
    public class TodoListItem : DataBaseItem
    {
        [ForeignKey(nameof(TodoList))]
        public Guid TodoListId { get; set; }
        public string Name { get; set; }
    }
}