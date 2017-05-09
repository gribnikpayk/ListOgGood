using System;
using System.Collections.Generic;
using System.Linq;
using ListOfGoods.DataManagers.Local.Purchase;

namespace ListOfGoods.Services.Purchase
{
    public class PurchaseService:IPurchaseService
    {
        private IPurchaseRepository _purchaseRepository;
        private IPurchasesListRepository _purchasesListRepository;
        public PurchaseService(IPurchaseRepository purchaseRepository,IPurchasesListRepository purchasesListRepository)
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
    }
}
