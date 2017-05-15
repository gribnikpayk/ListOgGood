using ListOfGoods.Services.Purchase;

namespace ListOfGoods.ViewModels.PopUps
{
    public class ListActionsPopUpViewModel:BaseViewModel
    {
        private IPurchaseService _purchaseService;

        public ListActionsPopUpViewModel(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        public void DeleteList(int listId)
        {
            _purchaseService.DeleteList(listId);
        }
    }
}
