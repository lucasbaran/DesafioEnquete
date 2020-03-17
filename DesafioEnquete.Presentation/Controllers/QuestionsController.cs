﻿using System;
using System.Collections.Generic;
using System.Linq;
using DesafioEnquete.Application.DTO.ViewModels;
using DesafioEnquete.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DesafioEnquete.Presentation.Controllers
{
    [Route("poll")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IApplicationServiceQuestion _applicationServiceQuestion;
        private readonly IApplicationServiceOption _applicationServiceOption;


        public QuestionsController(IApplicationServiceQuestion ApplicationServiceQuestion, IApplicationServiceOption ApplicationServiceOption)
        {
            _applicationServiceQuestion = ApplicationServiceQuestion;
            _applicationServiceOption = ApplicationServiceOption;
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            var dto =_applicationServiceQuestion.GetById(id);

            if (dto is null)
                return NotFound("Questão não encontrada");

            _applicationServiceQuestion.SumView(id);

            var questionViewModel = _applicationServiceQuestion.GetById(id);
            questionViewModel.options = _applicationServiceOption.GetAllOptionsQuestion(id);

            return Ok(questionViewModel);
            
        }

        [HttpPost("poll")]
        public ActionResult Post([FromBody] AddQuestionViewModel questionViewModel)
        {
            try
            {
                questionViewModel.Validate();
                if (questionViewModel.Invalid)
                    return NotFound(new ResultViewModel
                    {
                        Success = false,
                        Message = "Não foi possível cadastrar a questão",
                        Data = questionViewModel.Notifications
                    });

                return Ok(new { poll_id = _applicationServiceQuestion.AddWithReturn(questionViewModel) });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("poll/{id}/vote")]
        public ActionResult Put(int id)
        {
            try
            {
                var dto = _applicationServiceOption.GetById(id);

                if (dto is null)
                    return NotFound("Opção não cadastrada.");

                dto.Quantity = dto.Quantity++;
                _applicationServiceOption.Update(dto);
                return Ok("Opção contabilizada com sucesso!");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("{id}/stats")]
        public ActionResult Stats(int id)
        {
            try
            {
                var question = _applicationServiceQuestion.GetById(id);

                if (question is null)
                    return NotFound("Questão não cadastrada.");

                return Ok(question);
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}