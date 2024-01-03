using Dapper;
using Question.Concerns.DataContext;
using Question.Concerns.Entities;
using Question.Contract;

namespace Question.Service
{
    public class QuestionDetailsService : IQuestionDetailsService
    {
        public readonly QuestionContext context;
        public QuestionDetailsService(QuestionContext _context)
        {
            this.context = _context;
        }

        public async Task<IEnumerable<QuestionDetails>> GetAll()
        {
            using (var connection = this.context.CreateConnection())
            {
                var quelist = await connection.QueryAsync<QuestionDetails>("select * from questionDetails");
               
                return quelist;
            }
        }

        public async Task<QuestionDetails> GetQuestionDetailsById(int id)
        {
            using (var connection = this.context.CreateConnection())
            {
                var quelist = await connection.QueryFirstOrDefaultAsync<QuestionDetails>("select * from  questionDetails where(Id=@id);", new {id});
                return quelist;
            }
        }
        public int AddQuestionDetails(QuestionDetails data)
        {
            using (var connection = this.context.CreateConnection())
            {
                return connection.ExecuteScalar<int>("INSERT INTO questionDetails (questionType, description) VALUES (@questionType, @description);SELECT SCOPE_IDENTITY();", data); //Execute return the single value 
            }
        }

        public void UpdateQuestionDetails(QuestionDetails user)
        {
            using (var connection = this.context.CreateConnection())
            {
                connection.Execute("UPDATE questionDetails SET questionType = @QuestionType, description = @Description WHERE Id = @Id;", user);
            }
        }
        public void DeleteById(int id)
        {
            using (var connection = this.context.CreateConnection())
            {
                connection.Execute("Delete From questionDetails where(Id=@id)", new { id });
            }
        }
    }
}
