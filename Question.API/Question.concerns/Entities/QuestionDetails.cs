using System.ComponentModel.DataAnnotations;

namespace Question.Concerns.Entities
{
    public class QuestionDetails 
    {
        [Key]
        public int Id { get; set; }
        public string questionType { get; set; }
        public string? description { get; set; }
    }
}
