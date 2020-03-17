using DesafioEnquete.Application.DTO.ViewModels;
using DesafioEnquete.Domain.Models;
using DesafioEnquete.Infrastruture.CrossCutting.Adapter.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DesafioEnquete.Infrastruture.CrossCutting.Adapter.Map
{
    public class MapperQuestion : IMapperQuestion
    {

        #region Properties

        List<QuestionDTO> questionDTOs = new List<QuestionDTO>();

        #endregion

        #region methods

        public Question MapperToEntity(AddQuestionViewModel questionViewModel)
        {
            var question = new Question
            {
                Description = questionViewModel.poll_description
            };

            return question;
        }

        public Question MapperToEntity(QuestionDTO questionDTO)
        {
            var question = new Question
            {

                Id = questionDTO.Id,
                Description = questionDTO.Description,
                Views = questionDTO.Views

            };

            return question;

        }

        public IEnumerable<QuestionDTO> MapperListQuestions(IEnumerable<Question> questions)
        {
            foreach (var item in questions)
            {

                var questionDTO = new QuestionDTO
                {
                    Id = item.Id
                   ,
                    Description = item.Description
                   ,
                    Views = item.Views

                };

                questionDTOs.Add(questionDTO);
            }


            return questionDTOs;

        }

        public QuestionDTO MapperToDTO(Question question)
        {
            var questionDTO = new QuestionDTO
            {
                Id = question.Id
                ,
                Description= question.Description
                ,
                Views = question.Views
            };

            return questionDTO;

        }

        public GetQuestionViewModel MapperToGetViewModel(Question question)
        {
            var getQuestionViewModel = new GetQuestionViewModel
            {
                poll_id = question.Id.GetValueOrDefault()
                ,
                poll_description = question.Description
            };

            return getQuestionViewModel;
        }

        #endregion
    }
}
