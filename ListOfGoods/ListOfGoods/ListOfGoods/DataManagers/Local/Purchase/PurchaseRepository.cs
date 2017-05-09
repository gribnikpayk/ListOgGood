using ListOfGoods.DataManagers.Local.Base;

namespace ListOfGoods.DataManagers.Local.Purchase
{
    public class PurchaseRepository:BaseRepository<PurchaseEntity>, IPurchaseRepository
    {
        public PurchaseRepository() { }
    }
}
