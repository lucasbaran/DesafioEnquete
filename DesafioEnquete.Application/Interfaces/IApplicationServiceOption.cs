using DesafioEnquete.Application.DTO.ViewModels;
using System.Collections.Generic;

namespace DesafioEnquete.Application.Interfaces
{
    public interface IApplicationServiceOption
    {
        void Add(OptionDTO obj);

        void Add(IEnumerable<OptionViewModel> objList, int questionId);

        OptionDTO GetById(int id);

        IEnumerable<OptionDTO> GetAll();

        IEnumerable<GetOptionViewModel> GetAllOptionsQuestion(int questionId);

        void Update(OptionDTO obj);

        void Remove(OptionDTO obj);

        void Dispose();

    }
}
