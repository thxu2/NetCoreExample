using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleApi.Domain;
using SampleApi.Infrastructure;

namespace SampleApi.Controlßlers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TodoListController: ControllerBase
    {
        private readonly SampleApiDbContext _dbContext;
        
        public TodoListController(SampleApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ActionResult<IEnumerable<TodoList>>> GetTodoLists(string userName)
        {
            await using (_dbContext)
            {
               var todoLists = await _dbContext.TodoLists.Where(l => l.Owner == userName).ToListAsync();
               return Ok(todoLists);
            }
        }
    }
}