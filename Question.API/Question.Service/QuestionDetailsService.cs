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
            string query = "select * from questionDetails";
            using (var connection = this.context.CreateConnection())
            {
                var quelist = await connection.QueryAsync<QuestionDetails>(query);
               
                return quelist;
            }
        }

        public async Task<QuestionDetails> GetQuestionDetailsById(int id)
        {
            string query = " select * from  questionDetails where(Id=@id);";
            using (var connection = this.context.CreateConnection())
            {
                var quelist = await connection.QueryFirstOrDefaultAsync<QuestionDetails>(query, new {id});
                return quelist;
            }
        }
        public int AddQuestionDetails(QuestionDetails data)
        {
            string query = "INSERT INTO questionDetails (questionType, description) VALUES (@questionType, @description);SELECT SCOPE_IDENTITY();";

            using (var connection = this.context.CreateConnection())
            {
                return connection.ExecuteScalar<int>(query, data); //Execute return the single value 
            }
        }

        public void UpdateQuestionDetails(QuestionDetails user)
        {
            string query = "UPDATE questionDetails SET questionType = @QuestionType, description = @Description WHERE Id = @Id;";

            using (var connection = this.context.CreateConnection())
            {
                connection.Execute(query, user);
            }
        }
        public void DeleteById(int id)
        {
            string query = "Delete From questionDetails where(Id=@id)";
            using (var connection = this.context.CreateConnection())
            {
                connection.Execute(query, new { id });
            }
        }
    }
}
