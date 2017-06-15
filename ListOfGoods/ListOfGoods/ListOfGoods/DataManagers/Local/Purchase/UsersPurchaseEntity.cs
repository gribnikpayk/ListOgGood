using ListOfGoods.DataManagers.Local.Base;

namespace ListOfGoods.DataManagers.Local.Purchase
{
    public class UsersPurchaseEntity:BaseEntity
    {
        public int PurchaseId { get; set; }
        public int PurchasesListId { get; set; }
        public string Quantity { get; set; }
        public int MesurementType { get; set; }
        public string Price { get; set; }
        public int CurrencyType { get; set; }
        public int CategoryType { get; set; }
        public bool IsAlreadyPurchased { get; set; }
    }
}
