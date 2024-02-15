using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoListModelClassLibrary;
using TodoListAPI.Data;

namespace ToDoListAPI.Controllers
{
    public class ToDoController : Controller
    {
        private readonly TodoDbContext todoContext;

        public ToDoController(TodoDbContext context)
        {
            this.todoContext = context;
        }

        // 10.Get request that returns all ToDoItems with no CompletedDate set
        [HttpGet("incomplete")]
        public async Task<ActionResult<IEnumerable<ToDoItem>>> GetToDoItem()
        {
            // Retrieve ToDoItems with no CompletedDate set
            List<ToDoItem> toDoItems = await todoContext.ToDoItems
                .Where(item => item.CompletedDate == null)
                .ToListAsync();

            return Ok(toDoItems);
        }

        //12. Post request that creates a new ToDoItem
        [HttpPost("/")]
        public async Task<ActionResult<ToDoItem>> CreateTodoItem(ToDoItem todoItem)
        {
            if(todoItem == null){
                return BadRequest();
            }
            // Add the new ToDoItem to the database
            todoContext.ToDoItems.Add(todoItem);
            await todoContext.SaveChangesAsync();

            // Return the newly created ToDoItem
            return CreatedAtAction(nameof(GetTodoItemById), new { id = todoItem.Id }, todoItem);
        }

        
        [HttpGet("{id}")]
        //11. Get request that returns ToDoItem matching the provided Id
        public async Task<ActionResult<ToDoItem>> GetTodoItemById(int id)
        {
            // Retrieves ToDoItem based on provided Id
            ToDoItem toDoItem = await todoContext.ToDoItems.FindAsync(id);

            if (toDoItem == null)
            {
                return NotFound();
            }

            return Ok(toDoItem);
        }

        [HttpPost("{id}/complete")]
        //13. Post request that fills in the CompletedDate with current datetime for the provided Id
        public async Task<ActionResult<ToDoItem>> TodoItemAsCompleted(int id)
        {
            // Find the ToDoItem with the specified Id
            var toDoItem = await todoContext.ToDoItems.FindAsync(id);

            // If ToDoItem is not found, return 404 Not Found
            if (toDoItem == null)
            {
                return NotFound();
            }

            // Update the CompletedDate with the current datetime
            toDoItem.CompletedDate = DateTime.Now;

            // Update the ToDoItem in the database
            todoContext.Entry(toDoItem).State = EntityState.Modified;
            await todoContext.SaveChangesAsync();

            // Return the updated ToDoItem
            return Ok(toDoItem);
        }
    }
}