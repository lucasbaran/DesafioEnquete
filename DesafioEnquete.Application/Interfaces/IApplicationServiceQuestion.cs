using DesafioEnquete.Application.DTO.ViewModels;
using System.Collections.Generic;

namespace DesafioEnquete.Application.Interfaces
{
    public interface IApplicationServiceQuestion
    {
        void Add(AddQuestionViewModel obj);

        int AddWithReturn(AddQuestionViewModel obj);

        void Add(QuestionDTO obj);

        GetQuestionViewModel GetById(int id);

        IEnumerable<QuestionDTO> GetAll();

        void Update(QuestionDTO obj);

        void Remove(QuestionDTO obj);

        void SumView(int id);

        void Dispose();

    }
}
