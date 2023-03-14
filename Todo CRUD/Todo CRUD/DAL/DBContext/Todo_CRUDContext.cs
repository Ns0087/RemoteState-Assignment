using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Todo_CRUD.DAL.Entity;

namespace Todo_CRUD.DAL.DBContext
{
    public class Todo_CRUDContext : DbContext
    {
        public Todo_CRUDContext(DbContextOptions<Todo_CRUDContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; } = default!;
    }
}
