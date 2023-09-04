using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionPaper.Data.Entities.Model
{
    public class subQuestionsModel
    {
        [Key]
        public int  id{ get; set; }
        public string? subQuestionName { get; set; }
        public int? numberOfQuestion { get; set; }
        public int? timeLimit { get; set; }
        public int questionDetails_id { get; set; }
      //  public questionDetailsModel questionDetails { get; set; }
    }
}
