using Statos.Model.Stores;

namespace Statos.Repository.Stores
{
    public class StoreRepository : Repository<Store>, IStoreRepository
    {
        public StoreRepository(StatosContext statosContext)
            : base(statosContext)
        {
        }
    }
}
