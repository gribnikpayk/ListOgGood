
using ListOfGoods.CustomControls;
using ListOfGoods.DataManagers.Local.Purchase;

namespace ListOfGoods.Infrastructure.Extensions
{
    public static class CustomControlsExtensions
    {
        public static ListFrame ToListFrame(this PurchasesListEntity entity)
        {
            return new ListFrame(entity);
        }
    }
}
