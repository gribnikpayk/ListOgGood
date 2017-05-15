using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListOfGoods.DataManagers.Local.Purchase;

namespace ListOfGoods.Infrastructure.Helpers
{
    public class LocalDbDeploymentHelper
    {
        #region data
        private List<PurchaseEntity> Purchases = new List<PurchaseEntity>
        {
            new PurchaseEntity
            {
                Name = "apples",
                IsCustomProduct = false
            },
            new PurchaseEntity
            {
                Name = "bananas",
                IsCustomProduct = false
            },
            new PurchaseEntity
            {
                Name = "beans",
                IsCustomProduct = false
            },
            new PurchaseEntity
            {
                Name = "beef",
                IsCustomProduct = false
            },
            new PurchaseEntity
            {
                Name = "bread",
                IsCustomProduct = false
            },
            new PurchaseEntity
            {
                Name = "cabbage",
                IsCustomProduct = false
            },
            new PurchaseEntity
            {
                Name = "candies",
                IsCustomProduct = false
            },
            new PurchaseEntity
            {
                Name = "carrot",
                IsCustomProduct = false
            },
            new PurchaseEntity
            {
                Name = "cheese",
                IsCustomProduct = false
            },
            new PurchaseEntity
            {
                Name = "chicken",
                IsCustomProduct = false
            },
            new PurchaseEntity
            {
                Name = "chips",
                IsCustomProduct = false
            },
            new PurchaseEntity
            {
                Name = "chocolate",
                IsCustomProduct = false
            },
            new PurchaseEntity
            {
                Name = "coffee",
                IsCustomProduct = false
            },
            new PurchaseEntity
            {
                Name = "cola",
                IsCustomProduct = false
            },
            new PurchaseEntity
            {
                Name = "cookies",
                IsCustomProduct = false
            },
            new PurchaseEntity
            {
                Name = "corn",
                IsCustomProduct = false
            },
            new PurchaseEntity
            {
                Name = "cream",
                IsCustomProduct = false
            },
            new PurchaseEntity
            {
                Name = "cucumber",
                IsCustomProduct = false
            },
            new PurchaseEntity
            {
                Name = "diapers",
                IsCustomProduct = false
            },
            new PurchaseEntity
            {
                Name = "eggs",
                IsCustomProduct = false
            },
            new PurchaseEntity
            {
                Name = "fish",
                IsCustomProduct = false
            },
            new PurchaseEntity
            {
                Name = "fruit",
                IsCustomProduct = false
            },
            new PurchaseEntity
            {
                Name = "grapes",
                IsCustomProduct = false
            },
            new PurchaseEntity
            {
                Name = "ham",
                IsCustomProduct = false
            },
            new PurchaseEntity
            {
                Name = "ice cream",
                IsCustomProduct = false
            },
            new PurchaseEntity
            {
                Name = "juice",
                IsCustomProduct = false
            },
            new PurchaseEntity
            {
                Name = "ketchup",
                IsCustomProduct = false
            },
            new PurchaseEntity
            {
                Name = "lemon",
                IsCustomProduct = false
            },
            new PurchaseEntity
            {
                Name = "lemonade",
                IsCustomProduct = false
            },
            new PurchaseEntity
            {
                Name = "meat",
                IsCustomProduct = false
            },
            new PurchaseEntity
            {
                Name = "melon",
                IsCustomProduct = false
            },
            new PurchaseEntity
            {
                Name = "milk",
                IsCustomProduct = false
            },
            new PurchaseEntity
            {
                Name = "mozzarella",
                IsCustomProduct = false
            },
            new PurchaseEntity
            {
                Name = "mushrooms",
                IsCustomProduct = false
            },new PurchaseEntity
            {
                Name = "napkins",
                IsCustomProduct = false
            },
            new PurchaseEntity
            {
                Name = "nuts",
                IsCustomProduct = false
            },
            new PurchaseEntity
            {
                Name = "oil",
                IsCustomProduct = false
            },
            new PurchaseEntity
            {
                Name = "olives",
                IsCustomProduct = false
            },

            new PurchaseEntity
            {
                Name = "oranges",
                IsCustomProduct = false
            },
            new PurchaseEntity
            {
                Name = "pasta",
                IsCustomProduct = false
            },
            new PurchaseEntity
            {
                Name = "pastry",
                IsCustomProduct = false
            },
            new PurchaseEntity
            {
                Name = "peaches",
                IsCustomProduct = false
            },
            new PurchaseEntity
            {
                Name = "pears",
                IsCustomProduct = false
            },
            new PurchaseEntity
            {
                Name = "pepper",
                IsCustomProduct = false
            },
            new PurchaseEntity
            {
                Name = "pineapple",
                IsCustomProduct = false
            },
            new PurchaseEntity
            {
                Name = "pork",
                IsCustomProduct = false
            },
            new PurchaseEntity
            {
                Name = "porridge",
                IsCustomProduct = false
            },
            new PurchaseEntity
            {
                Name = "potatoes",
                IsCustomProduct = false
            },
            new PurchaseEntity
            {
                Name = "raisins",
                IsCustomProduct = false
            },
            new PurchaseEntity
            {
                Name = "rice",
                IsCustomProduct = false
            },
            new PurchaseEntity
            {
                Name = "salad",
                IsCustomProduct = false
            },
            new PurchaseEntity
            {
                Name = "sausage",
                IsCustomProduct = false
            },

            new PurchaseEntity
            {
                Name = "shrimp",
                IsCustomProduct = false
            },
            new PurchaseEntity
            {
                Name = "soap",
                IsCustomProduct = false
            },
            new PurchaseEntity
            {
                Name = "spice",
                IsCustomProduct = false
            },
            new PurchaseEntity
            {
                Name = "sugar",
                IsCustomProduct = false
            },
            new PurchaseEntity
            {
                Name = "tea",
                IsCustomProduct = false
            },
            new PurchaseEntity
            {
                Name = "tomatoes",
                IsCustomProduct = false
            },
            new PurchaseEntity
            {
                Name = "toothpaste",
                IsCustomProduct = false
            },
            new PurchaseEntity
            {
                Name = "water",
                IsCustomProduct = false
            },
            new PurchaseEntity
            {
                Name = "watermelon",
                IsCustomProduct = false
            }
        };
        #endregion
        private IPurchaseRepository _purchaseRepository;
        public LocalDbDeploymentHelper(IPurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
            if (!_purchaseRepository.GetQuery().Any())
            {
                foreach (var purchaseEntity in Purchases)
                {
                    _purchaseRepository.Create(purchaseEntity);
                }
            }
        }

    }
}
