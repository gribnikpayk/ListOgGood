using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using ListOfGoods.DataManagers.Local.Purchase;
using ListOfGoods.Infrastructure.Constants;
using ListOfGoods.Services.Purchase;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace ListOfGoods.ViewModels.PopUps
{
    public class EditPurchasePopUpViewModel : AddNewPurchasePopUpViewModel
    {
        private IPurchaseService _purchaseService;
        public int Id { get; set; }
        public ICommand UpdateUsersPurchaseCommand => new Command(UpdateUsersPurchase);
        public EditPurchasePopUpViewModel(IPurchaseService purchaseService) : base(purchaseService)
        {
            _purchaseService = purchaseService;
        }

        public void UpdateUsersPurchase()
        {
            Task.Run(() =>
            {
                var newPurchase = new PurchaseEntity
                {
                    Name = NewPurchase,
                    IsCustomImage = ImageIconIsCustom,
                    Id = PurchasesId,
                    ImagePath = PurchaseIconImagePath,
                    CategoryType = (int)CommonNameConstants.CategoriesDictionary.FirstOrDefault(x => x.Value == SelectedCategory).Key
                };
                _purchaseService.SavePurchase(newPurchase); //добавить / обновить продукт в общую базу товаров
                _purchaseService.SaveUsersPurchase(new UsersPurchaseEntity
                {
                    Id = Id,
                    PurchaseId = PurchasesId,
                    PurchasesListId = PurchasesListId,
                    Quantity = Quantity,
                    MesurementType = (int)CommonNameConstants.MeasurementsDictionary.FirstOrDefault(x => x.Value == SelectedMesurement).Key,
                    Price = Price,
                    CurrencyType = (int)CommonNameConstants.CurrencyDictionary.FirstOrDefault(x => x.Value == SelectedCurrency).Key,
                    CategoryType = (int)CommonNameConstants.CategoriesDictionary.FirstOrDefault(x => x.Value == SelectedCategory).Key
                });
            });
            PopupNavigation.PopAllAsync();
        }
    }
}
