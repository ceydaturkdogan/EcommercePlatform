using ECommercePlatform.Data.Entities;
using ECommercePlatform.Data.Repositories;
using ECommercePlatform.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommercePlatform.Business.Operations.Setting
{
    public class SettingManager : ISettingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<SettingEntity> _settingRepo;
        public SettingManager(IUnitOfWork unitOfWork, IRepository<SettingEntity> settingRepo)
        {
            _unitOfWork = unitOfWork;
            _settingRepo = settingRepo;
        }
        public bool GetMaintenanceState()
        {
            var maintenanceState = _settingRepo.GetById(1).MaintenanceMode;
            return maintenanceState;
        }
        public async Task ToggleMaintenence()
        {
            var setting = _settingRepo.GetById(1);

            setting.MaintenanceMode = !setting.MaintenanceMode;
            _settingRepo.Update(setting);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw new Exception("Bakım durumu güncellenirken bir hata ile karşılaşıldı");
            }
        }
    }
}
