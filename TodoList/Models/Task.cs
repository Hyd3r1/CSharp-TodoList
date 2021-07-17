using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace TodoListt.Models
{
    public class Task
    {
        public int taskId { get; set; }
        
        [Required]
        public string name { get; set; }
        
        [Required]
        public bool completed { get; set; }
        
        [Required]
        public string description { get; set; }
    }
}