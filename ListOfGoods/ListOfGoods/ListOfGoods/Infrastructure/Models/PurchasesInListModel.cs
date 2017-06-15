using ListOfGoods.DataManagers.Local.Purchase;

namespace ListOfGoods.Infrastructure.Models
{
    public class PurchasesInListModel
    {
        public PurchaseEntity Purchase { get; set; }
        public UsersPurchaseEntity UsersPurchaseEntity { get; set; }
    }
}
