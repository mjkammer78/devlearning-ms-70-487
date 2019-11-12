using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;

namespace EntitiesCore
{
    public static class ObjectContextExtensions
    {
        /// <summary>
        /// Provides a way to return an ObjectContext from Dbcontext
        /// </summary>
        public static ObjectContext ConvertContext(this DbContext dbContext)
        {
            return ((IObjectContextAdapter)dbContext).ObjectContext;
        }
    }
}
