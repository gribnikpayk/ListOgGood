using System.Collections.Generic;
using System.Linq;
using ListOfGoods.Infrastructure.Constants;
using ListOfGoods.Infrastructure.DependencyService;
using ListOfGoods.Infrastructure.Enums;
using ListOfGoods.Infrastructure.Helpers;
using ListOfGoods.Infrastructure.Models;
using ListOfGoods.Services.Purchase;
using Xamarin.Forms;

namespace ListOfGoods.ViewModels.PopUps
{
    public class ListActionsPopUpViewModel : BaseViewModel
    {
        private IPurchaseService _purchaseService;
        private IShareService _shareService;

        public ListActionsPopUpViewModel(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
            _shareService = DependencyService.Get<IShareService>();
        }

        public void DeleteList(int listId)
        {
            _purchaseService.DeleteList(listId);
        }

        public void Share(ListModel listModel)
        {
            var purchases = _purchaseService.GetPurchasesByListId(listModel.Id);
            var body = ShareHelper.CreatePurchasesListBodyForShare(purchases);
            var title = $"{listModel.Name}, {listModel.CreationDate:M}";
            _shareService.Share(title, body);
        }
    }
}
