using DesafioEnquete.Application.DTO.ViewModels;
using System.Collections.Generic;

namespace DesafioEnquete.Application.Interfaces
{
    public interface IApplicationServiceQuestion
    {
        void Add(PostQuestionViewModel obj);

        int AddWithReturn(PostQuestionViewModel obj);

        void Add(QuestionDTO obj);

        GetQuestionViewModel GetById(int id);

        StatsQuestionViewModel StatsQuestion(int id);

        IEnumerable<QuestionDTO> GetAll();

        void Update(QuestionDTO obj);

        void Remove(QuestionDTO obj);

        void SumView(int id);

        void Dispose();

    }
}
