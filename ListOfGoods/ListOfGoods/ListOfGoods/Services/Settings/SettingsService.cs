using ListOfGoods.DataManagers.Local.Settings;

namespace ListOfGoods.Services.Settings
{
    public class SettingsService : ISettingsService
    {
        private ISettingsRepository _settingsRepository;

        public SettingsService(ISettingsRepository settingsRepository)
        {
            _settingsRepository = settingsRepository;
        }

        public SettingsEntity GetSettings()
        {
            return _settingsRepository.GetQuery().FirstOrDefault();
        }

        public int UpdateSettings(SettingsEntity entity)
        {
            if (entity.Id != 0)
            {
                _settingsRepository.Update(entity);
                return entity.Id;
            }
            else
            {
                return _settingsRepository.Create(entity);
            }
        }
    }
}
