using ListOfGoods.DataManagers.Local.Base;

namespace ListOfGoods.DataManagers.Local.Purchase
{
    public class PurchaseEntity:BaseEntity
    {
        public string Name { get; set; }
        public bool IsCustomImage { get; set; }
        public string ImagePath { get; set; }
        public string QuantityDescription { get; set; }
        public string PriceDescription { get; set; }
        public int CategoryType { get; set; }
        public bool IsAlreadyPurchased { get; set; }
    }
}
