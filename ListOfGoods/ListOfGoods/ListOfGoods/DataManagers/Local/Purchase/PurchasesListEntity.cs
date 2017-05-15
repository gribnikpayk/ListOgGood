using System;
using ListOfGoods.DataManagers.Local.Base;

namespace ListOfGoods.DataManagers.Local.Purchase
{
    public class PurchasesListEntity:BaseEntity
    {
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
