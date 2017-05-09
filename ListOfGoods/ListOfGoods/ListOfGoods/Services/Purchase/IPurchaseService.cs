using System.Collections.Generic;
using ListOfGoods.DataManagers.Local.Purchase;

namespace ListOfGoods.Services.Purchase
{
    public interface IPurchaseService
    {
        List<PurchaseEntity> GetAllPurchases();
        List<PurchasesListEntity> GetAllPurchasesLists();
    }
}
