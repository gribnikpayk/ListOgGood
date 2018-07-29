using ListOfGoods.DataManagers.Local.Settings;

namespace ListOfGoods.Services.Settings
{
    public interface ISettingsService
    {
        SettingsEntity GetSettings();
        int UpdateSettings(SettingsEntity entity);
    }
}
