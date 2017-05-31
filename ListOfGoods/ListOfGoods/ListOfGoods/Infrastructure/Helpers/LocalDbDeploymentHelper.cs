using System.Collections.Generic;
using System.Linq;
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
                IsCustomImage = false,
                ImagePath = "apples.jpg"
            },
            new PurchaseEntity
            {
                Name = "bananas",
                IsCustomImage = false,
                ImagePath = "bananas.jpg"
            },
            new PurchaseEntity
            {
                Name = "beans",
                IsCustomImage = false,
                ImagePath = "beans.jpg"

            },
            new PurchaseEntity
            {
                Name = "beef",
                IsCustomImage = false,
                ImagePath = "beef.jpg"
            },
            new PurchaseEntity
            {
                Name = "bread",
                IsCustomImage = false,
                ImagePath = "bread.jpg"
            },
            new PurchaseEntity
            {
                Name = "cabbage",
                IsCustomImage = false,
                ImagePath = "cabbage.jpg"
            },
            new PurchaseEntity
            {
                Name = "candies",
                IsCustomImage = false,
                ImagePath = "candies.jpg"
            },
            new PurchaseEntity
            {
                Name = "carrot",
                IsCustomImage = false,
                ImagePath = "carrot.jpg"
            },
            new PurchaseEntity
            {
                Name = "cheese",
                IsCustomImage = false,
                ImagePath = "cheese.jpg"
            },
            new PurchaseEntity
            {
                Name = "chicken",
                IsCustomImage = false,
                ImagePath = "chicken.jpg"
            },
            new PurchaseEntity
            {
                Name = "chips",
                IsCustomImage = false,
                ImagePath = "chips.jpg"
            },
            new PurchaseEntity
            {
                Name = "chocolate",
                IsCustomImage = false,
                ImagePath = "chocolate.jpg"
            },
            new PurchaseEntity
            {
                Name = "coffee",
                IsCustomImage = false,
                ImagePath = "coffee.jpg"
            },
            new PurchaseEntity
            {
                Name = "cola",
                IsCustomImage = false,
                ImagePath = "cola.jpg"
            },
            new PurchaseEntity
            {
                Name = "cookies",
                IsCustomImage = false,
                ImagePath = "cookies.jpg"
            },
            new PurchaseEntity
            {
                Name = "corn",
                IsCustomImage = false,
                ImagePath = "corn.jpg"
            },
            new PurchaseEntity
            {
                Name = "cream",
                IsCustomImage = false,
                ImagePath = "cream.jpg"
            },
            new PurchaseEntity
            {
                Name = "cucumber",
                IsCustomImage = false,
                ImagePath = "cucumber.jpg"
            },
            new PurchaseEntity
            {
                Name = "diapers",
                IsCustomImage = false,
                ImagePath = "diapers.jpg"
            },
            new PurchaseEntity
            {
                Name = "eggs",
                IsCustomImage = false,
                ImagePath = "eggs.jpg"
            },
            new PurchaseEntity
            {
                Name = "fish",
                IsCustomImage = false,
                ImagePath = "fish.jpg"
            },
            new PurchaseEntity
            {
                Name = "fruit",
                IsCustomImage = false,
                ImagePath = "fruit.jpg"
            },
            new PurchaseEntity
            {
                Name = "grapes",
                IsCustomImage = false,
                ImagePath = "grapes.jpg"
            },
            new PurchaseEntity
            {
                Name = "ham",
                IsCustomImage = false,
                ImagePath = "ham.jpg"
            },
            new PurchaseEntity
            {
                Name = "ice cream",
                IsCustomImage = false,
                ImagePath = "ice_cream.jpg"
            },
            new PurchaseEntity
            {
                Name = "juice",
                IsCustomImage = false,
                ImagePath = "juice.jpg"
            },
            new PurchaseEntity
            {
                Name = "ketchup",
                IsCustomImage = false,
                ImagePath = "ketchup.jpg"
            },
            new PurchaseEntity
            {
                Name = "lemon",
                IsCustomImage = false,
                ImagePath = "lemon.jpg"
            },
            new PurchaseEntity
            {
                Name = "lemonade",
                IsCustomImage = false,
                ImagePath = "lemonade.jpg"
            },
            new PurchaseEntity
            {
                Name = "meat",
                IsCustomImage = false,
                ImagePath = "meat.jpg"
            },
            new PurchaseEntity
            {
                Name = "melon",
                IsCustomImage = false,
                ImagePath = "melon.jpg"
            },
            new PurchaseEntity
            {
                Name = "milk",
                IsCustomImage = false,
                ImagePath = "milk.jpg"
            },
            new PurchaseEntity
            {
                Name = "mozzarella",
                IsCustomImage = false,
                ImagePath = "mozzarella.jpg"
            },
            new PurchaseEntity
            {
                Name = "mushrooms",
                IsCustomImage = false,
                ImagePath = "mushrooms.jpg"
            },new PurchaseEntity
            {
                Name = "napkins",
                IsCustomImage = false,
                ImagePath = "napkins.jpg"
            },
            new PurchaseEntity
            {
                Name = "nuts",
                IsCustomImage = false,
                ImagePath = "nuts.jpg"
            },
            new PurchaseEntity
            {
                Name = "oil",
                IsCustomImage = false,
                ImagePath = "oil.jpg"
            },
            new PurchaseEntity
            {
                Name = "olives",
                IsCustomImage = false,
                ImagePath = "olives.jpg"
            },

            new PurchaseEntity
            {
                Name = "oranges",
                IsCustomImage = false,
                ImagePath = "oranges.jpg"
            },
            new PurchaseEntity
            {
                Name = "pasta",
                IsCustomImage = false,
                ImagePath = "pasta.jpg"
            },
            new PurchaseEntity
            {
                Name = "pastry",
                IsCustomImage = false,
                ImagePath = "pastry.jpg"
            },
            new PurchaseEntity
            {
                Name = "peaches",
                IsCustomImage = false,
                ImagePath = "peaches.jpg"
            },
            new PurchaseEntity
            {
                Name = "pears",
                IsCustomImage = false,
                ImagePath = "pears.jpg"
            },
            new PurchaseEntity
            {
                Name = "pepper",
                IsCustomImage = false,
                ImagePath = "pepper.jpg"
            },
            new PurchaseEntity
            {
                Name = "pineapple",
                IsCustomImage = false,
                ImagePath = "pineapple.jpg"
            },
            new PurchaseEntity
            {
                Name = "pork",
                IsCustomImage = false,
                ImagePath = "pork.jpg"
            },
            new PurchaseEntity
            {
                Name = "porridge",
                IsCustomImage = false,
                ImagePath = "bananas.jpg"
            },
            new PurchaseEntity
            {
                Name = "potatoes",
                IsCustomImage = false,
                ImagePath = "potatoes.jpg"
            },
            new PurchaseEntity
            {
                Name = "raisins",
                IsCustomImage = false,
                ImagePath = "raisins.jpg"
            },
            new PurchaseEntity
            {
                Name = "rice",
                IsCustomImage = false,
                ImagePath = "rice.jpg"
            },
            new PurchaseEntity
            {
                Name = "salad",
                IsCustomImage = false,
                ImagePath = "salad.jpg"
            },
            new PurchaseEntity
            {
                Name = "sausage",
                IsCustomImage = false,
                ImagePath = "sausage.jpg"
            },

            new PurchaseEntity
            {
                Name = "shrimp",
                IsCustomImage = false,
                ImagePath = "shrimp.jpg"
            },
            new PurchaseEntity
            {
                Name = "soap",
                IsCustomImage = false,
                ImagePath = "bananas.jpg"
            },
            new PurchaseEntity
            {
                Name = "spice",
                IsCustomImage = false,
                ImagePath = "spice.jpg"
            },
            new PurchaseEntity
            {
                Name = "sugar",
                IsCustomImage = false,
                ImagePath = "sugar.jpg"
            },
            new PurchaseEntity
            {
                Name = "tea",
                IsCustomImage = false,
                ImagePath = "tea.jpg"
            },
            new PurchaseEntity
            {
                Name = "tomatoes",
                IsCustomImage = false,
                ImagePath = "tomatoes.jpg"
            },
            new PurchaseEntity
            {
                Name = "toothpaste",
                IsCustomImage = false,
                ImagePath = "toothpaste.jpg"
            },
            new PurchaseEntity
            {
                Name = "water",
                IsCustomImage = false,
                ImagePath = "water.jpg"
            },
            new PurchaseEntity
            {
                Name = "watermelon",
                IsCustomImage = false,
                ImagePath = "watermelon.jpg"
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
