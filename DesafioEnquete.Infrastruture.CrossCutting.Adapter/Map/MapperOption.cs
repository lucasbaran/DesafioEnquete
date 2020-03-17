using DesafioEnquete.Application.DTO.ViewModels;
using DesafioEnquete.Domain.Models;
using DesafioEnquete.Infrastruture.CrossCutting.Adapter.Interfaces;
using System.Collections.Generic;

namespace DesafioEnquete.Infrastruture.CrossCutting.Adapter.Map
{
    public class MapperOption : IMapperOption
    {

        #region properties

        List<OptionDTO> optionDTOs = new List<OptionDTO>();
        List<GetOptionViewModel> optionViewModels = new List<GetOptionViewModel>();

        #endregion


        #region methods

        public Option MapperToEntity(OptionDTO optionDTO)
        {
            var option = new Option
            {
                Id = optionDTO.Id
                ,
                Description = optionDTO.Description
                ,
                Quantity = optionDTO.Quantity
                ,
                QuestionId = optionDTO.QuestionId
            };

            return option;

        }


        public IEnumerable<OptionDTO> MapperListOptions(IEnumerable<Option> options)
        {
            foreach (var item in options)
            {


                var optionDTO = new OptionDTO
                {
                    Id = item.Id
                    ,
                    Description = item.Description
                    ,
                    Quantity = item.Quantity
                    ,
                    QuestionId = item.QuestionId
                };

                optionDTOs.Add(optionDTO);

            }

            return optionDTOs;
        }

        public OptionDTO MapperToDTO(Option Option)
        {

            var optionDTO = new OptionDTO
            {
                Id = Option.Id
                ,
                Description = Option.Description
                ,
                Quantity = Option.Quantity
            };

            return optionDTO;

        }

        public IEnumerable<GetOptionViewModel> MapperListGetOptionsViewModel(IEnumerable<Option> options)
        {
            foreach (var item in options)
            {
                var optionDTO = new GetOptionViewModel
                {
                    option_id = item.Id.GetValueOrDefault()
                    ,
                    option_description = item.Description
                };

                optionViewModels.Add(optionDTO);

            }

            return optionViewModels;
        }

        #endregion

    }
}
