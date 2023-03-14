using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Todo_CRUD.DAL.DBContext;
using Todo_CRUD.DAL.Entity;
using Todo_CRUD.Models.RequestViewModel;

namespace Todo_CRUD.DAL.Repository.Implementation
{
    public class TodoItemRepository
    {
        private readonly Todo_CRUDContext _context;

        public TodoItemRepository(IServiceProvider serviceProvider)
        {
            _context = serviceProvider.GetRequiredService<Todo_CRUDContext>();
        }

        public async Task<IEnumerable<TodoItem>> GetItemsAsync()
        {
            return await _context.TodoItems.ToListAsync();
        }

        public async Task<TodoItem> GetItemByIdAsync(int id) { 
        
            var item= await _context.TodoItems.FindAsync(id);

            if (item == null)
            {
                return null;
            }

            return item;
        }

        public async Task<int> PutItemModel(int id, TodoItem item)
        {
            if (id != item.Id)
            {
                return 0;
            }

            _context.Entry(item).State = EntityState.Modified;

            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return 0;
        }
    }
}
