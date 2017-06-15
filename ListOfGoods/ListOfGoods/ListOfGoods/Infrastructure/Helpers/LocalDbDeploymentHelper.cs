using System.Collections.Generic;
using System.Linq;
using ListOfGoods.DataManagers.Local.Purchase;
using ListOfGoods.Infrastructure.Enums;

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
                ImagePath = "apples.jpg",
                CategoryType = (int) Categories.Fruit
            },
            new PurchaseEntity
            {
                Name = "bananas",
                IsCustomImage = false,
                ImagePath = "bananas.jpg",
                CategoryType = (int) Categories.Fruit
            },
            new PurchaseEntity
            {
                Name = "beans",
                IsCustomImage = false,
                ImagePath = "beans.jpg",
                CategoryType = (int) Categories.Vegetables

            },
            new PurchaseEntity
            {
                Name = "beef",
                IsCustomImage = false,
                ImagePath = "beef.jpg",
                CategoryType = (int) Categories.Meat
            },
            new PurchaseEntity
            {
                Name = "bread",
                IsCustomImage = false,
                ImagePath = "bread.jpg",
                CategoryType = (int) Categories.Bakery
            },
            new PurchaseEntity
            {
                Name = "cabbage",
                IsCustomImage = false,
                ImagePath = "cabbage.jpg",
                CategoryType = (int) Categories.Vegetables
            },
            new PurchaseEntity
            {
                Name = "candies",
                IsCustomImage = false,
                ImagePath = "candies.jpg",
                CategoryType = (int) Categories.WithoutÑategory
            },
            new PurchaseEntity
            {
                Name = "carrot",
                IsCustomImage = false,
                ImagePath = "carrot.jpg",
                CategoryType = (int) Categories.Vegetables
            },
            new PurchaseEntity
            {
                Name = "cheese",
                IsCustomImage = false,
                ImagePath = "cheese.jpg",
                CategoryType = (int) Categories.Dairy
            },
            new PurchaseEntity
            {
                Name = "chicken",
                IsCustomImage = false,
                ImagePath = "chicken.jpg",
                CategoryType = (int) Categories.Chicken
            },
            new PurchaseEntity
            {
                Name = "chips",
                IsCustomImage = false,
                ImagePath = "chips.jpg",
                CategoryType = (int) Categories.Other
            },
            new PurchaseEntity
            {
                Name = "chocolate",
                IsCustomImage = false,
                ImagePath = "chocolate.jpg",
                CategoryType = (int) Categories.WithoutÑategory
            },
            new PurchaseEntity
            {
                Name = "coffee",
                IsCustomImage = false,
                ImagePath = "coffee.jpg",
                CategoryType = (int) Categories.Drinks
            },
            new PurchaseEntity
            {
                Name = "cola",
                IsCustomImage = false,
                ImagePath = "cola.jpg",
                CategoryType = (int) Categories.Drinks
            },
            new PurchaseEntity
            {
                Name = "cookies",
                IsCustomImage = false,
                ImagePath = "cookies.jpg",
                CategoryType = (int) Categories.Bakery
            },
            new PurchaseEntity
            {
                Name = "corn",
                IsCustomImage = false,
                ImagePath = "corn.jpg",
                CategoryType = (int) Categories.WithoutÑategory
            },
            new PurchaseEntity
            {
                Name = "cream",
                IsCustomImage = false,
                ImagePath = "cream.jpg",
                CategoryType = (int) Categories.WithoutÑategory
            },
            new PurchaseEntity
            {
                Name = "cucumber",
                IsCustomImage = false,
                ImagePath = "cucumber.jpg",
                CategoryType = (int) Categories.Vegetables
            },
            new PurchaseEntity
            {
                Name = "diapers",
                IsCustomImage = false,
                ImagePath = "diapers.jpg",
                CategoryType = (int) Categories.Other
            },
            new PurchaseEntity
            {
                Name = "eggs",
                IsCustomImage = false,
                ImagePath = "eggs.jpg",
                CategoryType = (int) Categories.WithoutÑategory
            },
            new PurchaseEntity
            {
                Name = "fish",
                IsCustomImage = false,
                ImagePath = "fish.jpg",
                CategoryType = (int) Categories.Fish
            },
            new PurchaseEntity
            {
                Name = "fruit",
                IsCustomImage = false,
                ImagePath = "fruit.jpg",
                CategoryType = (int) Categories.Fruit
            },
            new PurchaseEntity
            {
                Name = "grapes",
                IsCustomImage = false,
                ImagePath = "grapes.jpg",
                CategoryType = (int) Categories.Fruit
            },
            new PurchaseEntity
            {
                Name = "ham",
                IsCustomImage = false,
                ImagePath = "ham.jpg",
                CategoryType = (int) Categories.Meat
            },
            new PurchaseEntity
            {
                Name = "ice cream",
                IsCustomImage = false,
                ImagePath = "ice_cream.jpg",
                CategoryType = (int) Categories.WithoutÑategory
            },
            new PurchaseEntity
            {
                Name = "juice",
                IsCustomImage = false,
                ImagePath = "juice.jpg",
                CategoryType = (int) Categories.Drinks
            },
            new PurchaseEntity
            {
                Name = "ketchup",
                IsCustomImage = false,
                ImagePath = "ketchup.jpg",
                CategoryType = (int) Categories.WithoutÑategory
            },
            new PurchaseEntity
            {
                Name = "lemon",
                IsCustomImage = false,
                ImagePath = "lemon.jpg",
                CategoryType = (int) Categories.Fruit
            },
            new PurchaseEntity
            {
                Name = "lemonade",
                IsCustomImage = false,
                ImagePath = "lemonade.jpg",
                CategoryType = (int) Categories.Drinks
            },
            new PurchaseEntity
            {
                Name = "meat",
                IsCustomImage = false,
                ImagePath = "meat.jpg",
                CategoryType = (int) Categories.Meat
            },
            new PurchaseEntity
            {
                Name = "melon",
                IsCustomImage = false,
                ImagePath = "melon.jpg",
                CategoryType = (int) Categories.Fruit
            },
            new PurchaseEntity
            {
                Name = "milk",
                IsCustomImage = false,
                ImagePath = "milk.jpg",
                CategoryType = (int) Categories.Dairy
            },
            new PurchaseEntity
            {
                Name = "mozzarella",
                IsCustomImage = false,
                ImagePath = "mozzarella.jpg",
                CategoryType = (int) Categories.Dairy
            },
            new PurchaseEntity
            {
                Name = "mushrooms",
                IsCustomImage = false,
                ImagePath = "mushrooms.jpg",
                CategoryType = (int) Categories.Vegetables
            },new PurchaseEntity
            {
                Name = "napkins",
                IsCustomImage = false,
                ImagePath = "napkins.jpg",
                CategoryType = (int) Categories.Other
            },
            new PurchaseEntity
            {
                Name = "nuts",
                IsCustomImage = false,
                ImagePath = "nuts.jpg",
                CategoryType = (int) Categories.WithoutÑategory
            },
            new PurchaseEntity
            {
                Name = "oil",
                IsCustomImage = false,
                ImagePath = "oil.jpg",
                CategoryType = (int) Categories.WithoutÑategory
            },
            new PurchaseEntity
            {
                Name = "olives",
                IsCustomImage = false,
                ImagePath = "olives.jpg",
                CategoryType = (int) Categories.WithoutÑategory
            },

            new PurchaseEntity
            {
                Name = "oranges",
                IsCustomImage = false,
                ImagePath = "oranges.jpg",
                CategoryType = (int) Categories.Fruit
            },
            new PurchaseEntity
            {
                Name = "pasta",
                IsCustomImage = false,
                ImagePath = "pasta.jpg",
                CategoryType = (int) Categories.WithoutÑategory
            },
            new PurchaseEntity
            {
                Name = "pastry",
                IsCustomImage = false,
                ImagePath = "pastry.jpg",
                CategoryType = (int) Categories.WithoutÑategory
            },
            new PurchaseEntity
            {
                Name = "peaches",
                IsCustomImage = false,
                ImagePath = "peaches.jpg",
                CategoryType = (int) Categories.Fruit
            },
            new PurchaseEntity
            {
                Name = "pears",
                IsCustomImage = false,
                ImagePath = "pears.jpg",
                CategoryType = (int) Categories.Fruit
            },
            new PurchaseEntity
            {
                Name = "pepper",
                IsCustomImage = false,
                ImagePath = "pepper.jpg",
                CategoryType = (int) Categories.Vegetables
            },
            new PurchaseEntity
            {
                Name = "pineapple",
                IsCustomImage = false,
                ImagePath = "pineapple.jpg",
                CategoryType = (int) Categories.Fruit
            },
            new PurchaseEntity
            {
                Name = "pork",
                IsCustomImage = false,
                ImagePath = "pork.jpg",
                CategoryType = (int) Categories.Meat
            },
            new PurchaseEntity
            {
                Name = "porridge",
                IsCustomImage = false,
                ImagePath = "porridge.jpg",
                CategoryType = (int) Categories.WithoutÑategory
            },
            new PurchaseEntity
            {
                Name = "potatoes",
                IsCustomImage = false,
                ImagePath = "potatoes.jpg",
                CategoryType = (int) Categories.Vegetables
            },
            new PurchaseEntity
            {
                Name = "raisins",
                IsCustomImage = false,
                ImagePath = "raisins.jpg",
                CategoryType = (int) Categories.Fruit
            },
            new PurchaseEntity
            {
                Name = "rice",
                IsCustomImage = false,
                ImagePath = "rice.jpg",
                CategoryType = (int) Categories.WithoutÑategory
            },
            new PurchaseEntity
            {
                Name = "salad",
                IsCustomImage = false,
                ImagePath = "salad.jpg",
                CategoryType = (int) Categories.Vegetables
            },
            new PurchaseEntity
            {
                Name = "sausage",
                IsCustomImage = false,
                ImagePath = "sausage.jpg",
                CategoryType = (int) Categories.WithoutÑategory
            },

            new PurchaseEntity
            {
                Name = "shrimp",
                IsCustomImage = false,
                ImagePath = "shrimp.jpg",
                CategoryType = (int) Categories.Fish
            },
            new PurchaseEntity
            {
                Name = "soap",
                IsCustomImage = false,
                ImagePath = "soap.jpg",
                CategoryType = (int) Categories.WithoutÑategory
            },
            new PurchaseEntity
            {
                Name = "spice",
                IsCustomImage = false,
                ImagePath = "spice.jpg",
                CategoryType = (int) Categories.Other
            },
            new PurchaseEntity
            {
                Name = "sugar",
                IsCustomImage = false,
                ImagePath = "sugar.jpg",
                CategoryType = (int) Categories.Other
            },
            new PurchaseEntity
            {
                Name = "tea",
                IsCustomImage = false,
                ImagePath = "tea.jpg",
                CategoryType = (int) Categories.Drinks
            },
            new PurchaseEntity
            {
                Name = "tomatoes",
                IsCustomImage = false,
                ImagePath = "tomatoes.jpg",
                CategoryType = (int) Categories.Vegetables
            },
            new PurchaseEntity
            {
                Name = "toothpaste",
                IsCustomImage = false,
                ImagePath = "toothpaste.jpg",
                CategoryType = (int) Categories.Other
            },
            new PurchaseEntity
            {
                Name = "water",
                IsCustomImage = false,
                ImagePath = "water.jpg",
                CategoryType = (int) Categories.Drinks
            },
            new PurchaseEntity
            {
                Name = "watermelon",
                IsCustomImage = false,
                ImagePath = "watermelon.jpg",
                CategoryType = (int) Categories.Fruit
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
