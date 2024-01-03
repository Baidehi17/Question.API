using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question.Concerns.Entities
{
    public class QuestionDetails 
    {
        [Key]
        public int Id { get; set; }
        public string questionType { get; set; }
        public string? description { get; set; }
       // public ICollection<SubQuestions>? subQuestions { get; set; }
    }
}
