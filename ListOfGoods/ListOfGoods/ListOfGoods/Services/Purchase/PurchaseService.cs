using System;
using System.Collections.Generic;
using System.Linq;
using ListOfGoods.DataManagers.Local.Purchase;
using ListOfGoods.Infrastructure.Enums;
using ListOfGoods.Infrastructure.Extensions;
using ListOfGoods.Infrastructure.Models;
using Xamarin.Forms;

namespace ListOfGoods.Services.Purchase
{
    public class PurchaseService : IPurchaseService
    {
        private IPurchaseRepository _purchaseRepository;
        private IPurchasesListRepository _purchasesListRepository;
        private IUsersPurchaseRepository _usersPurchaseRepository;
        public PurchaseService(IPurchaseRepository purchaseRepository, 
            IPurchasesListRepository purchasesListRepository,
            IUsersPurchaseRepository usersPurchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
            _purchasesListRepository = purchasesListRepository;
            _usersPurchaseRepository = usersPurchaseRepository;
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

        public PurchaseEntity FindPurchaseById(int id)
        {
            if (id == 0) return null;
            return _purchaseRepository.GetById(id);
        }

        public List<AutocompletePurchaseModel> FindAutocompletePurchases(string searchKey)
        {
            var purchases = _purchaseRepository.GetQuery(x => x.Name.Contains(searchKey)).Take(5).ToList();
            return purchases.Select(x => new AutocompletePurchaseModel
            {
                ImageSource = !x.IsCustomImage
                        ? ImageSource.FromFile(x.ImagePath.ToAutocompleteImagePath())
                        : ImageSource.FromFile(x.ImagePath),
                Name = x.Name,
                PurchaseId = x.Id,
                Category = (Categories) x.CategoryType
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
        public int SavePurchase(PurchaseEntity entity)
        {
            if (entity.Id != 0)
            {
                _purchaseRepository.Update(entity);
                return entity.Id;
            }
            else
            {
                return _purchaseRepository.Create(entity);
            }
        }

        public int SaveUsersPurchase(UsersPurchaseEntity entity)
        {
            if (entity.Id != 0)
            {
                _usersPurchaseRepository.Update(entity);
                return entity.Id;
            }
            else
            {
                return _usersPurchaseRepository.Create(entity);
            }
        }

        public List<PurchasesInListModel> GetPurchasesByListId(int listId)
        {
            var purchasesInListModel = new List<PurchasesInListModel>();
            var userPurchases = _usersPurchaseRepository.GetQuery(x => x.PurchasesListId == listId).ToList(); 
            var purchasesIds = userPurchases.Select(x => x.PurchaseId);                                       
            var purchases = _purchaseRepository.GetQuery(x => purchasesIds.Contains(x.Id));                   
            foreach (var usersPurchaseEntity in userPurchases)
            {
                purchasesInListModel.Add(new PurchasesInListModel
                {
                    Purchase = purchases.FirstOrDefault(x => x.Id == usersPurchaseEntity.PurchaseId),
                    UsersPurchaseEntity = usersPurchaseEntity
                });
            }
            return purchasesInListModel;
        }

        public void DeletePurchaseFromUserList(int purchaseId, int listId)
        {
            var entity = GetUsersPurchaseByPurchaseAndListId(purchaseId, listId);
            if (entity != null)
            {
                _usersPurchaseRepository.Delete(entity.Id);
            }
        }

        public void MarkPurchasedStatus(int purchaseId, int listId, bool isAlreadyPurchased)
        {
            var entity = GetUsersPurchaseByPurchaseAndListId(purchaseId, listId);
            entity.IsAlreadyPurchased = isAlreadyPurchased;
            _usersPurchaseRepository.Update(entity);
        }
        public void AddPurchasedToListAgain(int purchaseId, int listId)
        {
            var entity = GetUsersPurchaseByPurchaseAndListId(purchaseId, listId);
            entity.IsAlreadyPurchased = false;
            _usersPurchaseRepository.Update(entity);
        }

        #region privateMethods
        private UsersPurchaseEntity GetUsersPurchaseByPurchaseAndListId(int purchaseId, int listId)
        {
            return
               _usersPurchaseRepository.GetQuery(x => x.PurchaseId == purchaseId && x.PurchasesListId == listId)
               .FirstOrDefault();
        }

        #endregion

    }
}
