
using ListOfGoods.CustomControls;
using ListOfGoods.DataManagers.Local.Purchase;
using ListOfGoods.Infrastructure.Models;

namespace ListOfGoods.Infrastructure.Extensions
{
    public static class CustomControlsExtensions
    {
        public static ListFrame ToListFrame(this ListModel entity)
        {
            return new ListFrame(entity);
        }
    }
}
