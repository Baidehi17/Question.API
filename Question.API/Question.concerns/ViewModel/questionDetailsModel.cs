using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionPaper.Data.Entities.Model
{
    public class questionDetailsModel
    {
        [Key]
        public int Id { get; set; }
        public string questionType { get; set; }
        public string? description { get; set; }
       // public ICollection<subQuestionsModel>? subQuestions { get; set; }
    }
}
