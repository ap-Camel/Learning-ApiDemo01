using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using APIDEMO01.Models;
using APIDEMO01.SQL;
using APIDEMO01.SQL.Tables;
using APIDEMO01.SQL.Interfaces;
using APIDEMO01.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace APIDEMO01.Controllers{
    [ApiController]
    [Route("answers")]
    [Authorize(Roles = "student")]
    public class AnswersController : ControllerBase {

        private readonly IAnswerData answerData;

        public AnswersController(IAnswerData answerData){
            this.answerData = answerData;
        }

        [HttpGet("{id}")]
        public async Task<List<Answer>> getAnswers(int id){
            var list = await answerData.answersDefault(id);
            return list;
        }

        [HttpPost]
        public async Task<bool> postAnswer(InsertAnswer answer){

            return await answerData.insertAnswer(answer);
        }

    }
}