using DesafioEnquete.Application.DTO.ViewModels;
using DesafioEnquete.Domain.Models;
using System.Collections.Generic;

namespace DesafioEnquete.Infrastruture.CrossCutting.Adapter.Interfaces
{
    public interface IMapperQuestion
    {
        #region Interfaces Mappers
        Question MapperToEntity(QuestionDTO questionDTO);

        Question MapperToEntity(PostQuestionViewModel questionViewModel);

        IEnumerable<QuestionDTO> MapperListQuestions(IEnumerable<Question> questions);

        QuestionDTO MapperToDTO(Question question);

        GetQuestionViewModel MapperToGetViewModel(Question question);

        StatsQuestionViewModel MapperToStatsViewModel(Question question);

        #endregion

    }
}
