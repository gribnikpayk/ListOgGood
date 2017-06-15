using System.Threading.Tasks;
using ListOfGoods.Services.Purchase;

namespace ListOfGoods.ViewModels.PopUps
{
    public class PurchaseActionsPopUpViewModel:BaseViewModel
    {
        private IPurchaseService _purchaseService;
        public PurchaseActionsPopUpViewModel(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }
        public void DeletePurchase(int purchaseId, int listId)
        {
            Task.Run(() =>
            {
                _purchaseService.DeletePurchaseFromUserList(purchaseId, listId);
            });
        }

        public void MarkAsPurchased(int purchaseId, int listId)
        {
            Task.Run(() =>
            {
                _purchaseService.MarkAsPurchased(purchaseId, listId);
            });
        }
    }
}
