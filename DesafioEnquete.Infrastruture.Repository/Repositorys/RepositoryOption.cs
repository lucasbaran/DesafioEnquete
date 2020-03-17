using DesafioEnquete.Domain.Core.Interfaces.Repositorys;
using DesafioEnquete.Domain.Models;
using DesafioEnquete.Infrastructure.Data;

namespace DesafioEnquete.Infrastruture.Repository.Repositorys
{
    public class RepositoryOption : RepositoryBase<Option>, IRepositoryOption
    {
        private readonly SqlContext _context;
        public RepositoryOption(SqlContext Context)
            : base(Context)
        {
            _context = Context;
        }
    }
}
