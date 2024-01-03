using Dapper;
using Question.Concerns.DataContext;
using Question.Concerns.Entities;
using Question.Contract;

namespace Question.Service
{
    public class SubQuestionService : ISubQuestionService
    {
        public readonly QuestionContext context;
        public SubQuestionService(QuestionContext _context)
        {
            this.context = _context;
        }
        public async Task<IEnumerable<SubQuestions>> GetAll()
        {
            using (var connection = this.context.CreateConnection())
            {
                var quelist = await connection.QueryAsync<SubQuestions>("select * from subQuestions");
                return quelist;
            }
        }

        public async Task<IEnumerable<SubQuestions>> GetSubQuesById(int id)
        {
            using (var connection = this.context.CreateConnection())
            {
                IEnumerable<SubQuestions> subQuestionsList = await connection.QueryAsync<SubQuestions>("SELECT * FROM subQuestions WHERE questionDetails_id = @id;", new { id });
                return subQuestionsList;
            }
        }

        public void updateSubQues(SubQuestions subQuest)
        {
            using (var connection = this.context.CreateConnection())
            {
                connection.Execute("UPDATE subQuestions SET subQuestionName = @subQuestionName,numberOfQuestion = @numberOfQuestion, timeLimit = @timeLimit,questionDetails_id = @questionDetails_id WHERE id = @Id;", subQuest);
            }
        }

        public void AddSubquestions(SubQuestions data)
        {
            using (var connection = this.context.CreateConnection())
            {
                 connection.Execute("INSERT INTO subQuestions (subQuestionName, numberOfQuestion, timeLimit, questionDetails_id) VALUES (@subQuestionName, @numberOfQuestion, @timeLimit, @questionDetails_id);", data);
            }
        }

        public void DeleteById(int id)
        {
            using (var connectin = this.context.CreateConnection())
            {
                connectin.Execute("Delete From subQuestions where(id=@id)", new { id });
            }
        }

        public async Task DeleteQuestionDetailsById(int id)
        {
            using (var connectin = this.context.CreateConnection())
            {
               await connectin.ExecuteAsync("Delete From subQuestions where(questionDetails_id=@id)", new { id });
            }
        }
    }
}
