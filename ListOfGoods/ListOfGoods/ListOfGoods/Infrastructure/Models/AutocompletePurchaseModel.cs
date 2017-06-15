using ListOfGoods.Infrastructure.Enums;
using Xamarin.Forms;

namespace ListOfGoods.Infrastructure.Models
{
    public class AutocompletePurchaseModel
    {
        public string Name { get; set; }
        public ImageSource ImageSource { get; set; }

        public int PurchaseId { get; set; }
        public Categories Category { get; set; }
    }
}
