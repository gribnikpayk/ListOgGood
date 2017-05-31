using ListOfGoods.DataManagers.Local.Base;

namespace ListOfGoods.DataManagers.Local.Purchase
{
    public class UsersPurchaseRepository: BaseRepository<UsersPurchaseEntity>, IUsersPurchaseRepository
    {
        public UsersPurchaseRepository() { }
    }
}
