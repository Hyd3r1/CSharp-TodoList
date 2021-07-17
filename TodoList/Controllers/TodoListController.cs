using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoListt.Database;
using TodoListt.Models;

namespace TodoListt.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("/api/v1/todo")]
    public class TodoList : Controller
    {
        private readonly TodoListContext db;

        public TodoList(TodoListContext db)
        {
            this.db = db;
        }
        
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetTask(int id)
        {
            return Json(new { task = db.Tasks.Where(t => t.taskId == id).ToList() });
        }

        [HttpGet]
        public IActionResult GetTasks()
        {
            return Json(new {tasks = db.Tasks.ToList()});
        }

        [HttpPost]
        public IActionResult CreateTask([FromBody] Task task)
        {
            db.Tasks.Add(task);
            db.SaveChanges();
            return Json(new {success = true});
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteTask(int id)
        {
            if (!db.Tasks.Any(t => t.taskId == id))
            {
                Response.StatusCode = StatusCodes.Status422UnprocessableEntity;
                return Json(new { success = false, message = $"Task {id} not found"});
            }

            var task = db.Tasks.Find(id);
            db.Tasks.Remove(task);
            db.SaveChanges();
            return Json(new {success = true});
        }
        
        
        [HttpPut]
        public IActionResult UpdateTask([FromBody] Task task)
        {
            if (!db.Tasks.Any(t => t.taskId == task.taskId))
            {
                Response.StatusCode = StatusCodes.Status422UnprocessableEntity;
                return Json(new { success = false, message = $"Task {task.taskId} not found"});
            }

            db.Entry(task).State = EntityState.Modified;
            db.SaveChanges();
            return Json(new {success = true});
        }
    }
}