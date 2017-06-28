using System.Collections.Generic;
using ListOfGoods.Infrastructure.Models;

namespace ListOfGoods.Infrastructure.Constants
{
    public static class CommonConstants
    {
        public static bool IsNeedToLoadPurchasesLists;
        public static bool IsNeedToClearChildrenOnLayout;
        public static List<ListModel> AllLists;
        public static string ProductReviewAddressInStore = @"ms-windows-store://review/?ProductId=9p4chjsslxkw";
        public static string ProductDetailAddressInStore = @"ms-windows-store://pdp/?ProductId=9p4chjsslxkw";
        public static string TopFactsDetailAddressInStore = @"ms-windows-store://pdp/?ProductId=9n8b3wh3tqsg";

        public static string ApplicationName = "Shopping list";
        public static string ApplicationDescription = "Shopping list! helps people to plan and manage their grocery shopping.\n"
                                                      + "Your Shopping List stays with you everywhere you go and you'll have it on-hand once you're ready to go grocery shopping.\n"
                                                      + "\n"
                                                      + "Our Features:\n"
                                                      + "- Multiple shopping lists\n"
                                                      + "- Save time by grouping items into categories\n"
                                                      + "- Easily enter items in your shopping lists\n"
                                                      + "- Share lists by text or email\n"
                                                      + "- Shopping list! is optimized for smartphones, tablets and desktop\n"
                                                      + "- Add product photos to the items on the shopping list, so you always buy the right brand\n"
                                                      + "\n"
                                                      + "Download:\n"
                                                      + "https://www.microsoft.com/store/apps/9p4chjsslxkw";
    }
}
