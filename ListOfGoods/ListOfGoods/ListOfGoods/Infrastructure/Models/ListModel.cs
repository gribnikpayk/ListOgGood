using System;

namespace ListOfGoods.Infrastructure.Models
{
    public class ListModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public int CountOfPurchases { get; set; }
        public int CountOfAlreadyPurchased { get; set; }
    }
}
