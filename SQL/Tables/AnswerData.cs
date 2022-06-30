using APIDEMO01.Dtos;
using APIDEMO01.Models;
using APIDEMO01.SQL.Interfaces;

namespace APIDEMO01.SQL.Tables{
    

    public class AnswerData : IAnswerData
    {
        private readonly ISqlDataAccess _db;

        public AnswerData(ISqlDataAccess db)
        {
            _db = db;
        }


        public async Task<List<Answer>> getAnswers(int id)
        {
            string sql = $"select * from answer where questionid = {id}";

            return await _db.LoadMany<Answer>(sql);
        }

        public async Task<List<Answer>> answersDefault(int id) {

            List<Answer> allAnswers = await getAnswers(id);
            
            Answer correctAnswer = allAnswers.Where(x => Convert.ToInt32(x.answerType) == 1).FirstOrDefault();
            List<Answer> falseAnswers = allAnswers.Where(x => Convert.ToInt32(x.answerType) == 0).ToList<Answer>();

            // this part is if there were less than 4 answers
            int count = falseAnswers.Count() + 1;
            if(count >= 4){
                count = 4;
            }

            Answer[] arr = new Answer[count];
            Random rand = new Random();
            int num = rand.Next(count);
            arr[num] = correctAnswer;

            

            for(int i = 0; i < count;) {

                if(arr[i] == correctAnswer) {
                    i++;
                    continue;
                }

                num = rand.Next(falseAnswers.Count());
                if(arr[i] is null) {
                    arr[i] = falseAnswers[num];
                    falseAnswers.RemoveAt(num);
                    i++;

                }
            }

            return arr.ToList();
        }

        public async Task<bool> insertAnswer(InsertAnswer answer){
            string sql = $"insert into answer values ({Convert.ToInt16(answer.answerType)}, '{answer.description}', GETDATE(), {answer.answerPriority}, {answer.questionID})";

            return await _db.insertData(sql);
        }
    }
}