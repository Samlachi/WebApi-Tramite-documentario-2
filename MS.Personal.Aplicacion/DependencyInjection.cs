using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MongoDB.Driver;
using Release.MongoDB.Repository;
using MS.Personal.Aplicacion.Cliente;
using dominio = MS.Personal.Dominio.Entidades;
using MS.Personal.Infraestrucuta.Properties;

namespace MS.Personal.Aplicacion
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAplicacion(this IServiceCollection services, IConfiguration configuration)
        {
            #region Mongo

            string cs = configuration.GetSection("DBSettings:ConnectionString").Value;
            var dbUrl = new MongoUrl(cs);

            services.AddScoped<IDbContext>(x => new DbContext(dbUrl));

            //Entidades            
            services.TryAddScoped<ICollectionContext<dominio.Personal>>(x => new CollectionContext<dominio.Personal>(x.GetService<IDbContext>()));

            //Como Repo
            services.TryAddScoped<IBaseRepository<dominio.Personal>>(x => new BaseRepository<dominio.Personal>(x.GetService<IDbContext>()));

            #endregion

            #region Servicios

            services.AddScoped<IClienteService, ClienteService>();

            #endregion

            return services;
        }

    }
}
