using ListOfGoods.DataManagers.Local.Base;

namespace ListOfGoods.DataManagers.Local.Purchase
{
    public class UsersPurchaseEntity:BaseEntity
    {
        public int PurchaseId { get; set; }
        public int PurchasesListId { get; set; }
        public string QuantityDescription { get; set; }
        public string PriceDescription { get; set; }
        public int CategoryType { get; set; }
        public bool IsAlreadyPurchased { get; set; }
    }
}
