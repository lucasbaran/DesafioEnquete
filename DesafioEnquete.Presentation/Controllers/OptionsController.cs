using DesafioEnquete.Application.DTO.DTO;
using DesafioEnquete.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace WebApiDDD.Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OptionsController : ControllerBase
    {
        private readonly IApplicationServiceOption _applicationServiceOption;

        public OptionsController(IApplicationServiceOption ApplicationServiceOption)
        {
            _applicationServiceOption = ApplicationServiceOption;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_applicationServiceOption.GetAll());
        }

        // GET api/values/5\
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(_applicationServiceOption.GetById(id));
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] OptionDTO optionDTO)
        {
            try
            {
                if (optionDTO == null)
                    return NotFound();


                _applicationServiceOption.Add(optionDTO);
                return Ok("A opção foi cadastrado com sucesso");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // PUT api/values/5
        [HttpPut]
        public ActionResult Put([FromBody] OptionDTO optionDTO)
        {

            try
            {
                if (optionDTO == null)
                    return NotFound();

                _applicationServiceOption.Update(optionDTO);
                return Ok("O produto foi atualizado com sucesso!");

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // DELETE api/values/5
        [HttpDelete()]
        public ActionResult Delete([FromBody] OptionDTO optionDTO)
        {
            try
            {
                if (optionDTO == null)
                    return NotFound();

                _applicationServiceOption.Remove(optionDTO);
                return Ok("O produto foi removido com sucesso!");

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}