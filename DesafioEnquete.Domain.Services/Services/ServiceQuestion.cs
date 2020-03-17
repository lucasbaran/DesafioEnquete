using DesafioEnquete.Domain.Core.Interfaces.Repositorys;
using DesafioEnquete.Domain.Core.Interfaces.Services;
using DesafioEnquete.Domain.Models;

namespace DesafioEnquete.Domain.Services.Services
{
    public class ServiceQuestion : ServiceBase<Question>, IServiceQuestion
    {
        private readonly IRepositoryQuestion _repositoryQuestion;

        public ServiceQuestion(IRepositoryQuestion RepositoryQuestion)
            : base(RepositoryQuestion)
        {
            _repositoryQuestion = RepositoryQuestion;
        }
    }
}
