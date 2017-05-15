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
    }
}
