using System.Collections.Generic;
using System.Linq;
using ListOfGoods.Infrastructure.Constants;
using ListOfGoods.Infrastructure.Enums;
using ListOfGoods.Infrastructure.Models;

namespace ListOfGoods.Infrastructure.Helpers
{
    public class ShareHelper
    {
        public static string CreatePurchasesListBodyForShare(List<PurchasesInListModel> purchases)
        {

            var purchasesInCard = purchases.Where(x => x.UsersPurchaseEntity.IsAlreadyPurchased);
            var newPurchases = purchases.Where(x => !x.UsersPurchaseEntity.IsAlreadyPurchased);
            var body = string.Empty;

            body += newPurchases.Any() ? "My Purchases\n" : string.Empty;
            foreach (var purchase in newPurchases)
            {
                body += $"- {purchase.Purchase.Name}";
                if (!string.IsNullOrEmpty(purchase.UsersPurchaseEntity.Quantity))
                {
                    body += $", {purchase.UsersPurchaseEntity.Quantity} {CommonNameConstants.MeasurementsDictionary.FirstOrDefault(x => x.Key == (Measurements)purchase.UsersPurchaseEntity.MesurementType).Value}";
                }

                if (!string.IsNullOrEmpty(purchase.UsersPurchaseEntity.Price))
                {
                    body += $" ({purchase.UsersPurchaseEntity.Price} {CommonNameConstants.CurrencyDictionary.FirstOrDefault(x => x.Key == (Currency)purchase.UsersPurchaseEntity.CurrencyType).Value})";
                }
                body += "\n";
            }

            body += purchasesInCard.Any() ? "\nCart\n" : string.Empty;
            foreach (var purchase in purchasesInCard)
            {
                body += $"- {purchase.Purchase.Name}";
                if (!string.IsNullOrEmpty(purchase.UsersPurchaseEntity.Quantity))
                {
                    body += $", {purchase.UsersPurchaseEntity.Quantity} {CommonNameConstants.MeasurementsDictionary.FirstOrDefault(x => x.Key == (Measurements)purchase.UsersPurchaseEntity.MesurementType).Value}";
                }

                if (!string.IsNullOrEmpty(purchase.UsersPurchaseEntity.Price))
                {
                    body += $" ({purchase.UsersPurchaseEntity.Price} {CommonNameConstants.CurrencyDictionary.FirstOrDefault(x => x.Key == (Currency)purchase.UsersPurchaseEntity.CurrencyType).Value})";
                }
                body += "\n";
            }
            return body;
        }
    }
}
