using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using APIDEMO01.Models;
using APIDEMO01.SQL;
using APIDEMO01.SQL.Tables;
using APIDEMO01.SQL.Interfaces;
using APIDEMO01.Dtos;

namespace APIDEMO01.Controllers{

    [ApiController]
    [Route("exams")]
    public class ExamsController{
        private readonly IAnswerData answerData;
        private readonly IQuestionData questionData;

        public ExamsController(IAnswerData answerData, IQuestionData questionData) {
            this.answerData = answerData;
            this.questionData = questionData;
        }


        [HttpGet]
        public async Task<List<ExamQuestions>> getExam(){

            List<ExamQuestions> examQuestions = new List<ExamQuestions>();

            List<Question> questions = await questionData.getQuestions();

            foreach(Question q in questions) {
                examQuestions.Add(new ExamQuestions() {question = q, answers = await answerData.getAnswers(q.ID)});
            }

            return examQuestions;
        }

        [HttpPost]
        public async Task<int> evaluateExam(List<EvaluateExam> ee) {

            int mark = 0;
            Answer correctAnswer;

            foreach(EvaluateExam e in ee) {
                var listOfAnswers = await answerData.getAnswers(e.questionID);
                correctAnswer = listOfAnswers.Where(x => x.answerType == true).FirstOrDefault();
                if(e.answer == correctAnswer.description) {
                    mark += 10;
                }
            }

            return mark;
        }
    }
}