using ListOfGoods.DataManagers.Local.Base;

namespace ListOfGoods.DataManagers.Local.Purchase
{
    public class UsersPurchaseEntity:BaseEntity
    {
        public int PurchaseId { get; set; }
        public int PurchasesListId { get; set; }
    }
}
