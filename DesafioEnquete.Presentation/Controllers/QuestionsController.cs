using System;
using System.Collections.Generic;
using System.Linq;
using DesafioEnquete.Application.DTO.ViewModels;
using DesafioEnquete.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApiDDD.Presentation.Controllers
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
            if (_applicationServiceQuestion.GetAll().Where(x => x.Id.Equals(id)).Any())
                return Ok(_applicationServiceQuestion.GetById(id));
            return NotFound();
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

        [HttpPut("poll/{id}/vote")]
        public ActionResult Put([FromBody] int id)
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

        [HttpPut("poll/{id}/stats")]
        public ActionResult Stats([FromBody] int id)
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