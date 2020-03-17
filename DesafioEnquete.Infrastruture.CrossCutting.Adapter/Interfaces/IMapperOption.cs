using DesafioEnquete.Application.DTO.ViewModels;
using DesafioEnquete.Domain.Models;
using System.Collections.Generic;

namespace DesafioEnquete.Infrastruture.CrossCutting.Adapter.Interfaces
{
    public interface IMapperOption
    {
        #region Mappers

        Option MapperToEntity(OptionDTO optionDTO);

        IEnumerable<OptionDTO> MapperListOptions(IEnumerable<Option> options);

        OptionDTO MapperToDTO(Option Op);

        #endregion

    }
}
