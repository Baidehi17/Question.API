using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Question.Concerns.Entities
{
    public class SubQuestions
    {
        [Key]
        public int id { get; set; }
        public string? subQuestionName { get; set; }
        public int? numberOfQuestion { get; set; }
        public int? timeLimit { get; set; }

        //[JsonPropertyName("questionDetailsId")]
        public int questionDetails_id { get; set; }
       // public QuestionDetails? questionDetails { get; set; }
    }
}
