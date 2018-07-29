using ListOfGoods.DataManagers.Local.Base;

namespace ListOfGoods.DataManagers.Local.Settings
{
    public class SettingsEntity : BaseEntity
    {
        public bool? IsTableView { get; set; }
    }
}
