using DesafioEnquete.Application.DTO.ViewModels;
using DesafioEnquete.Application.Interfaces;
using DesafioEnquete.Domain.Core.Interfaces.Services;
using DesafioEnquete.Infrastruture.CrossCutting.Adapter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioEnquete.Application.Service
{
    public class ApplicationServiceQuestion : IDisposable, IApplicationServiceQuestion
    {
        private readonly IServiceQuestion _serviceQuestion;
        private readonly IApplicationServiceOption _applicationServiceOption;
        private readonly IMapperQuestion _mapperQuestion;

        public ApplicationServiceQuestion(IServiceQuestion ServiceQuestion
                                         , IApplicationServiceOption ApplicationServiceOption
                                         , IMapperQuestion MapperQuestion)
        {
            _serviceQuestion = ServiceQuestion;
            _applicationServiceOption = ApplicationServiceOption;
            _mapperQuestion = MapperQuestion;
        }

        public void Add(AddQuestionViewModel obj)
        {
            var objQuestion = _mapperQuestion.MapperToEntity(obj);
            _serviceQuestion.Add(objQuestion);
        }

        public void Add(QuestionDTO obj)
        {
            var objQuestion = _mapperQuestion.MapperToEntity(obj);
            _serviceQuestion.Add(objQuestion);
        }

        public int AddWithReturn(AddQuestionViewModel obj)
        {
            var objQuestion = _mapperQuestion.MapperToEntity(obj);
            _serviceQuestion.Add(objQuestion);

            _applicationServiceOption.Add(obj.options, objQuestion.Id.GetValueOrDefault());

            return objQuestion.Id.GetValueOrDefault();
        }

        public void Dispose()
        {
            _serviceQuestion.Dispose();
        }

        public IEnumerable<QuestionDTO> GetAll()
        {
            var objQuestions = _serviceQuestion.GetAll();
            return _mapperQuestion.MapperListQuestions(objQuestions);
        }

        public GetQuestionViewModel GetById(int id)
        {
            var objQuestion = _serviceQuestion.GetById(id);
            if (objQuestion is null)
                return null;

            var questionViewModel = _mapperQuestion.MapperToGetViewModel(objQuestion);

            var options = _applicationServiceOption.GetAll().Where(x => x.QuestionId == id).ToList();

            //questionViewModel.options = _applicationServiceOption
            //    .GetAll()
            //    .Where(x => x.QuestionId.Equals(id))
            //    .Select(x => new GetOptionViewModel { option_id = x.Id.GetValueOrDefault(), option_description = x.Description });

            return questionViewModel;
        }

        public void Remove(QuestionDTO obj)
        {
            var objQuestion = _mapperQuestion.MapperToEntity(obj);
            _serviceQuestion.Remove(objQuestion);
        }

        public void SumView(int id)
        {
            var objQuestion = _serviceQuestion.GetById(id);
            objQuestion.Views = objQuestion.Views + 1;
            _serviceQuestion.Update(objQuestion);
        }

        public void Update(QuestionDTO obj)
        {
            var objQuestion = _mapperQuestion.MapperToEntity(obj);
            _serviceQuestion.Update(objQuestion);
        }

    }
}
