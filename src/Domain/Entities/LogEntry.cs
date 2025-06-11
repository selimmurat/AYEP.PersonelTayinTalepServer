using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class LogEntry
    {
        public int Id { get; set; }
        public DateTime LogDate { get; set; } = DateTime.Now;
        public string Level { get; set; } = "Info";
        public string Message { get; set; } = string.Empty;
        public string? Exception { get; set; }
        public string? UserName { get; set; }
        public string? Path { get; set; }
    }
}
