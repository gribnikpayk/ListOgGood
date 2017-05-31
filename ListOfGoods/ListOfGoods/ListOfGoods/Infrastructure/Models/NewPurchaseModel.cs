using Xamarin.Forms;

namespace ListOfGoods.Infrastructure.Models
{
    public class NewPurchaseModel
    {
        public ImageSource ImageSource { get; set; }
        public string PurchaseName { get; set; }
        public int PurchaseId { get; set; }
        public int PurchasesListId { get; set; }
    }
}
