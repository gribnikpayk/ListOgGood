using ListOfGoods.CustomControls;
using ListOfGoods.Infrastructure.Enums;

namespace ListOfGoods.Infrastructure.Models
{
    public class EditPurchasePostActionModel
    {
        public PurchaseGrid NewPurchaseGrid { get; set; }
        public PurchaseGrid InitialPurchaseGrid { get; set; }
    }
}
