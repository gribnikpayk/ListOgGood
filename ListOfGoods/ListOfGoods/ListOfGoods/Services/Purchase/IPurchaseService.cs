using System.Collections.Generic;
using ListOfGoods.DataManagers.Local.Purchase;
using ListOfGoods.Infrastructure.Models;

namespace ListOfGoods.Services.Purchase
{
    public interface IPurchaseService
    {
        List<PurchaseEntity> GetAllPurchases();
        List<PurchasesListEntity> GetAllPurchasesLists();
        void DeleteList(int id);
        List<AutocompletePurchaseModel> FindAutocompletePurchases(string searchKey);
        PurchaseEntity FindPurchaseById(int id);
        void SavePurchasesList(PurchasesListEntity entity);
        int SavePurchase(PurchaseEntity entity);
        int SaveUsersPurchase(UsersPurchaseEntity entity);
        List<PurchasesInListModel> GetPurchasesByListId(int listId);
        void DeletePurchaseFromUserList(int purchaseId, int listId);
        void SetPurchasedStatus(int purchaseId, int listId, bool isAlreadyPurchased);
        void AddPurchasedToListAgain(int purchaseId, int listId);
    }
}
