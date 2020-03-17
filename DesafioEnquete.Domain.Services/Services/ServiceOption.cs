using DesafioEnquete.Domain.Core.Interfaces.Repositorys;
using DesafioEnquete.Domain.Core.Interfaces.Services;
using DesafioEnquete.Domain.Models;

namespace DesafioEnquete.Domain.Services.Services
{
    public class ServiceOption : ServiceBase<Option>, IServiceOption
    {
        public readonly IRepositoryOption _repositoryOption;

        public ServiceOption(IRepositoryOption RepositoryOption)
            : base(RepositoryOption)
        {
            _repositoryOption = RepositoryOption;
        }

    }
}
