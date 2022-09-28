using EFCache;
using System.Data.Entity.Core.Common;

namespace DataAccess.Contexts
{
    public class TvProjectConfiguration : System.Data.Entity.DbConfiguration
    {
        public TvProjectConfiguration()
        {
            var t = new CacheTransactionHandler(new InMemoryCache());
            AddInterceptor(t);
            var cachingPolicy = new CachingPolicy();
            Loaded += (sender, args) =>
                args.ReplaceService<DbProviderServices>((s, _) => new CachingProviderServices(s, t, cachingPolicy));
        }
    }
}
