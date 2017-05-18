using System.Collections.Generic;
using ListOfGoods.Infrastructure.Enums;

namespace ListOfGoods.Infrastructure.Constants
{
    public class CommonNameConstants
    {
        public const string DeleteActionName = "Delete";
        public const string ShareActionName = "Share";
        public const string EditActionName = "Edit";

        public static Dictionary<Categories, string> CategoriesDictionary = new Dictionary<Categories, string>
        {
            [Categories.WithoutСategory] = "Without category",
            [Categories.Bakery] = "Bakery",
            [Categories.Chicken] = "Chicken",
            [Categories.Сosmetics] = "Сosmetics",
            [Categories.Dairy] = "Dairy",
            [Categories.Drinks] = "Drinks",
            [Categories.Fish] = "Fish",
            [Categories.Fruit] = "Fruit",
            [Categories.Meat] = "Meat",
            [Categories.Vegetables] = "Vegetables",
            [Categories.Other] = "Other"
        };
        public static Dictionary<Measurements, string> MeasurementsDictionary = new Dictionary<Measurements, string>
        {
            [Measurements.Bottle] = "Bottle",
            [Measurements.Couple] = "Couple",
            [Measurements.Gr] = "Gr.",
            [Measurements.Kg] = "Kg.",
            [Measurements.Liter] = "Liter",
            [Measurements.Pt] = "Pt.",
            [Measurements.Pkg] = "Pkg.",
            [Measurements.Piece] = "Piece"
        };
    }
}
