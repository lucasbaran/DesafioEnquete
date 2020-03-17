using DesafioEnquete.Application.DTO.ViewModels;
using DesafioEnquete.Application.Interfaces;
using DesafioEnquete.Domain.Core.Interfaces.Services;
using DesafioEnquete.Infrastruture.CrossCutting.Adapter.Interfaces;
using System.Collections.Generic;

namespace DesafioEnquete.Application.Service
{
    public class ApplicationServiceOption : IApplicationServiceOption
    {
        private readonly IServiceOption _serviceOption;
        private readonly IMapperOption _mapperOption;
     
        public ApplicationServiceOption(IServiceOption ServiceOption, IMapperOption MapperOption)
        {
            _serviceOption = ServiceOption;
            _mapperOption = MapperOption;
        }


        public void Add(OptionDTO obj)
        {
            var objOption = _mapperOption.MapperToEntity(obj);
            _serviceOption.Add(objOption);
        }

        public void Add(IEnumerable<OptionViewModel> objList, int questionId)
        {
            foreach (var obj in objList)
                _serviceOption.Add((_mapperOption.MapperToEntity(new OptionDTO { Description = obj.option_description, QuestionId = questionId })));
        }

        public void Dispose()
        {
            _serviceOption.Dispose();
        }

        public IEnumerable<OptionDTO> GetAll()
        {
            var objOptions = _serviceOption.GetAll();
            return _mapperOption.MapperListOptions(objOptions);
        }

        public OptionDTO GetById(int id)
        {
            var objOption = _serviceOption.GetById(id);
            return _mapperOption.MapperToDTO(objOption);
        }

        public void Remove(OptionDTO obj)
        {
            var objOption = _mapperOption.MapperToEntity(obj);
            _serviceOption.Remove(objOption);
        }

        public void Update(OptionDTO obj)
        {
            var objOption = _mapperOption.MapperToEntity(obj);
            _serviceOption.Update(objOption);
        }
    }
}
