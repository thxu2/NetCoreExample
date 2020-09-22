using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleApi.Domain;
using SampleApi.Infrastructure;

namespace SampleApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TodoListController : ControllerBase
    {
        private readonly SampleApiDbContext _dbContext;

        public TodoListController(SampleApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<IEnumerable<TodoList>>> GetTodoLists(string userName)
        {
            await using (_dbContext)
            {
                var todoLists = await _dbContext.TodoLists.Where(l => l.Owner == userName).Include(l => l.Items)
                    .ToListAsync();
                return Ok(todoLists);
            }
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<TodoList>>> CreateTodoList(TodoList todoList)
        {
            await using (_dbContext)
            {
                await _dbContext.TodoLists.AddAsync(todoList);
                await _dbContext.SaveChangesAsync();
                
                return Ok();
            }
        }
        
        [HttpPost("Item")]
        public async Task<ActionResult<IEnumerable<TodoList>>> CreateTodoListItem(TodoListItem todoListItem)
        {
            await using (_dbContext)
            {
                await _dbContext.TodoListItems.AddAsync(todoListItem);
                await _dbContext.SaveChangesAsync();
                
                return Ok();
            }
        }
    }
}