using System;
using Dapper.Contrib.Extensions;
using TodoList.Core.Domain.Common;

namespace TodoList.Core.Domain.Entities
{
    [Table("Todo")] 
    public class Todo : BaseEntity<int>
    {
        public string Title { get; set; }
        public bool Done { get; set; }

        public Todo(int id, string title, bool done)
        {
            Id = id;
            Title = title;
            Done = done;
        }

        public Todo(string title, bool done) : this(default, title, done)
        {
        }
    }
}