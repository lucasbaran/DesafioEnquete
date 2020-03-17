using DesafioEnquete.Domain.Core.Interfaces.Repositorys;
using DesafioEnquete.Domain.Models;
using DesafioEnquete.Infrastructure.Data;

namespace DesafioEnquete.Infrastruture.Repository.Repositorys
{
    public class RepositoryQuestion : RepositoryBase<Question>, IRepositoryQuestion
    {

        private readonly SqlContext _context;
        public RepositoryQuestion(SqlContext Context)
            : base(Context)
        {
            _context = Context;
        }

    }
}
