using System;
using System.Collections.Generic;
using System.Linq;
using ListOfGoods.DataManagers.Local.Purchase;
using ListOfGoods.Infrastructure.Extensions;
using ListOfGoods.Infrastructure.Models;
using Xamarin.Forms;

namespace ListOfGoods.Services.Purchase
{
    public class PurchaseService : IPurchaseService
    {
        private IPurchaseRepository _purchaseRepository;
        private IPurchasesListRepository _purchasesListRepository;
        public PurchaseService(IPurchaseRepository purchaseRepository, IPurchasesListRepository purchasesListRepository)
        {
            _purchaseRepository = purchaseRepository;
            _purchasesListRepository = purchasesListRepository;
        }

        public List<PurchaseEntity> GetAllPurchases()
        {
            return _purchaseRepository.GetQuery().ToList();
        }

        public List<PurchasesListEntity> GetAllPurchasesLists()
        {
            return _purchasesListRepository.GetQuery().ToList();
        }

        public void DeleteList(int id)
        {
            _purchasesListRepository.Delete(id);
        }

        public PurchaseEntity FindPurchaseByName(string name)
        {
            return string.IsNullOrEmpty(name)
                ? null
                : _purchaseRepository.GetQuery(x => x.Name.ToLower() == name.ToLower()).FirstOrDefault();
        }

        public List<AutocompletePurchaseModel> FindAutocompletePurchases(string searchKey)
        {
            var purchases = _purchaseRepository.GetQuery(x => x.Name.Contains(searchKey)).Take(5).ToList();
            return purchases.Select(x => new AutocompletePurchaseModel
            {
                ImageSource = !x.IsCustomProduct
                        ? ImageSource.FromFile(x.Name.ToAutocompleteImagePath())
                        : ImageSource.FromFile(""),
                Name = x.Name
            }).ToList();
        }

        public void SavePurchasesList(PurchasesListEntity entity)
        {
            if (entity.Id != 0)
            {
                _purchasesListRepository.Update(entity);
            }
            else
            {
                _purchasesListRepository.Create(entity);
            }
        }
        public void SavePurchase(PurchaseEntity entity)
        {
            if (entity.Id != 0)
            {
                _purchaseRepository.Update(entity);
            }
            else
            {
                _purchaseRepository.Create(entity);
            }
        }
    }
}
