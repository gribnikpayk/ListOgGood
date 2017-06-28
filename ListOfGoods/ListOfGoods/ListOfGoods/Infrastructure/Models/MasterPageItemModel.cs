using System;

namespace ListOfGoods.Infrastructure.Models
{

    public class MasterPageItemModel
    {

        public string Title { get; set; }
        public string Icon { get; set; }
        public int ListId { get; set; }
        public Type TargetType { get; set; }
    }
}