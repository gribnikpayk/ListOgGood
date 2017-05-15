using ListOfGoods.DataManagers.Local.Base;

namespace ListOfGoods.DataManagers.Local.Purchase
{
    public class PurchaseEntity:BaseEntity
    {
        public string Name { get; set; }
        public bool IsCustomProduct { get; set; }
    }
}
