using Autofac;
using DesafioEnquete.Application.Interfaces;
using DesafioEnquete.Application.Service;
using DesafioEnquete.Domain.Core.Interfaces.Repositorys;
using DesafioEnquete.Domain.Core.Interfaces.Services;
using DesafioEnquete.Domain.Services.Services;
using DesafioEnquete.Infrastruture.CrossCutting.Adapter.Interfaces;
using DesafioEnquete.Infrastruture.CrossCutting.Adapter.Map;
using DesafioEnquete.Infrastruture.Repository.Repositorys;

namespace DesafioEnquete.Infrastruture.CrossCutting.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region Registra IOC

            #region IOC Application
            builder.RegisterType<ApplicationServiceOption>().As<IApplicationServiceOption>();
            builder.RegisterType<ApplicationServiceQuestion>().As<IApplicationServiceQuestion>();
            #endregion

            #region IOC Services
            builder.RegisterType<ServiceOption>().As<IServiceOption>();
            builder.RegisterType<ServiceQuestion>().As<IServiceQuestion>();
            #endregion

            #region IOC Repositorys SQL
            builder.RegisterType<RepositoryOption>().As<IRepositoryOption>();
            builder.RegisterType<RepositoryQuestion>().As<IRepositoryQuestion>();
            #endregion

            #region IOC Mapper
            builder.RegisterType<MapperOption>().As<IMapperOption>();
            builder.RegisterType<MapperQuestion>().As<IMapperQuestion>();
            #endregion

            #endregion

        }
    }
}
