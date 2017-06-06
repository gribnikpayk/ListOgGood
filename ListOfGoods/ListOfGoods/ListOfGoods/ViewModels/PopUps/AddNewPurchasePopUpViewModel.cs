﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using ListOfGoods.DataManagers.Local.Purchase;
using ListOfGoods.Infrastructure.Constants;
using ListOfGoods.Services.Purchase;
using ListOfGoods.Views.PopUps;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace ListOfGoods.ViewModels.PopUps
{
    public class AddNewPurchasePopUpViewModel : BaseViewModel
    {
        private string _newPurchase, _quantity, _price, _selectedCategory, _selectedMesurement;
        private ImageSource _purchaseIconSource;
        private int _selectedIndexCategory, _selectedIndexMesurement;
        private List<string> _categorySource, _mesurementSource;

        public string PurchaseIconImagePath { get; set; }
        public bool ImageIconIsCustom { get; set; }
        public int PurchasesListId { get; set; }
        public int PurchasesId { get; set; }
        public ICommand AddCommand => new Command(AddPurchase);
        public ICommand EditImageCommand => new Command(ShowEditImagePopUpAsync);

        private IPurchaseService _purchaseService;

        public AddNewPurchasePopUpViewModel(IPurchaseService purchaseService)
        {
            SelectedIndexCategory = 0;
            SelectedIndexOfMesurement = 3;
            _purchaseService = purchaseService;
        }

        public int SelectedIndexCategory
        {
            set { SetProperty(ref _selectedIndexCategory, value); }
            get { return _selectedIndexCategory; }
        }

        public int SelectedIndexOfMesurement
        {
            set { SetProperty(ref _selectedIndexMesurement, value); }
            get { return _selectedIndexMesurement; }
        }
        public string NewPurchase
        {
            set { SetProperty(ref _newPurchase, value); }
            get { return _newPurchase; }
        }

        public List<string> CategorySource
        {
            set { SetProperty(ref _categorySource, value); }
            get { return CommonNameConstants.CategoriesDictionary.Select(x => x.Value).ToList(); }
        }
        public string SelectedCategory
        {
            set { SetProperty(ref _selectedCategory, value); }
            get { return _selectedCategory; }
        }

        public string SelectedMesurement
        {
            set { SetProperty(ref _selectedMesurement, value); }
            get { return _selectedMesurement; }
        }

        public List<string> MesurementSource
        {
            set { SetProperty(ref _mesurementSource, value); }
            get { return CommonNameConstants.MeasurementsDictionary.Select(x => x.Value).ToList(); }
        }
        public ImageSource PurchaseIconSource
        {
            set { SetProperty(ref _purchaseIconSource, value); }
            get { return _purchaseIconSource; }
        }

        public string Quantity
        {
            set { SetProperty(ref _quantity, value); }
            get { return _quantity; }
        }

        public string Price
        {
            set { SetProperty(ref _price, value); }
            get { return _price; }
        }

        private async void ShowEditImagePopUpAsync()
        {
            await PopupNavigation.PushAsync(new EditImageActions(NewPurchase));
        }

        private void AddPurchase()
        {
            Task.Run(() =>
            {
                var DB_Purchase = _purchaseService.FindPurchaseById(PurchasesId);
                var newPurchase = new PurchaseEntity
                {
                    Name = NewPurchase,
                    IsCustomImage = ImageIconIsCustom //если картинка была загружена пользователем , то сохр. ImageIsCustom 
                        ? ImageIconIsCustom           //если нет - то проверить была ли картинка в базе сохранена с ImageIsCustom
                        : DB_Purchase != null
                            ? DB_Purchase.IsCustomImage
                            : ImageIconIsCustom,
                    Id = DB_Purchase?.Id ?? 0,
                    ImagePath = ImageIconIsCustom  //если картинка загружена пользователем, то сохранить как есть
                        ? PurchaseIconImagePath    //если нет - то загрузить либо иконку, либо картинку которая уже была в DB
                        : string.IsNullOrEmpty(PurchaseIconImagePath)
                                ? $"{SelectedCategory}_icon.png"
                                : DB_Purchase?.ImagePath
                };
                var purchaseId = _purchaseService.SavePurchase(newPurchase); //добавить / обновить продукт в общую базу товаров
                _purchaseService.SaveUsersPurchase(new UsersPurchaseEntity
                {
                    PurchaseId = purchaseId,
                    PurchasesListId = PurchasesListId,
                    QuantityDescription = string.IsNullOrEmpty(Quantity)
                        ? string.Empty
                        : $"{Quantity} {SelectedMesurement}",
                    PriceDescription = string.IsNullOrEmpty(Price)
                        ? string.Empty
                        : $"{Price} $",
                    CategoryType = (int)CommonNameConstants.CategoriesDictionary.FirstOrDefault(x => x.Value == SelectedCategory).Key
                });
            });
            PopupNavigation.PopAllAsync();
        }
    }
}
