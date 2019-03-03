using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestQuizz.Models
{
    public class Quiz
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int TaskNumber { get; set; }
        public DateTime Time { get; set; }
        public string Input { get; set; }
        public string Output { get; set; }
    }
}
