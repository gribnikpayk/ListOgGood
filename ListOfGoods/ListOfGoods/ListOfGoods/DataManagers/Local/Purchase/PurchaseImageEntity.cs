using ListOfGoods.DataManagers.Local.Base;

namespace ListOfGoods.DataManagers.Local.Purchase
{
    public class PurchaseImageEntity:BaseEntity
    {
        public int PurchaseId { get; set; }
        public string ImageBase64 { get; set; }
    }
}
