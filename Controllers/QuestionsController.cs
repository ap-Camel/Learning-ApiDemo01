using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using APIDEMO01.Models;
using APIDEMO01.SQL;
using APIDEMO01.SQL.Tables;
using APIDEMO01.SQL.Interfaces;

namespace APIDEMO01.Controllers{

    [ApiController]
    [Route("questions")]
    public class QuestionsCOntroller{
        private readonly IQuestionData questionData;

        public QuestionsCOntroller(IQuestionData questionData) {
            this.questionData = questionData;
        }

        [HttpGet]
        public async Task<List<Question>> getQuestions(){
            var list = await questionData.getQuestions();
            return list;
        }

        [HttpPost]
        public async Task<bool> putQuestion(InsertQuestion q){
            return await questionData.insertQuestion(new Question(q));
        }
    }
}