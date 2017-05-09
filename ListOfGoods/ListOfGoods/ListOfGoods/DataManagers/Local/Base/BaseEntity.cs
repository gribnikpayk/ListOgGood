using SQLite;

namespace ListOfGoods.DataManagers.Local.Base
{
    public class BaseEntity
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
    }
}