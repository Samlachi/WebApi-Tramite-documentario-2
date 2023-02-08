using MongoDB.Driver;
using Release.MongoDB.Repository;

namespace MS.Personal.Infraestrucuta.Properties
{
    public class DbContext : DataContext, IDbContext
    {
        public DbContext(MongoUrl mongoUrl) : base(mongoUrl)
        {
        }
    }
}
