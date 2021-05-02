using DinExApi.Business.Interfaces;
using DinExApi.Domain.Models;
using DinExApi.Infrastructure.Enums;
using DinExApi.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DinExApi.Business.Services
{
    public class LaunchService : BaseServices<Launch>, ILaunchService
    {
        private ILaunchRepository _launchRepository;

        public LaunchService(ILaunchRepository launchRepository)
        {
            _launchRepository = launchRepository;
        }

        public async Task<ErrorCode> AddAsync(Launch launch)
        {
            var isRegistered = await _launchRepository.AddAsync(launch);

            if (isRegistered.Equals(0)) return ErrorCode.ErrorToSave;

            return ErrorCode.Empty;
        }

        public async Task<ErrorCode> DeleteAsync(int launchID)
        {
            var launch = await FindByIdAsync(launchID);

            if (launch is null) return ErrorCode.NotFound;

            try
            {
                await _launchRepository.DeleteAsync(launch);
                return ErrorCode.Empty;
            }
            catch (Exception)
            {
                return ErrorCode.ErrorToDel;
            }
        }

        public override bool Exists(Launch entity)
        {
            var hasAlreadyExists = FindByIdAsync(entity.Id).GetAwaiter().GetResult();

            if (hasAlreadyExists is null) return false;

            return true;
        }

        public async Task<IEnumerable<Launch>> FindAllAsync()
        {
            return await _launchRepository.FindAllAsync();
        }

        public async Task<Launch> FindByIdAsync(int launchID)
        {
            return await _launchRepository.FindByIdAsync(launchID);
        }

        public async Task UpdateAsync(Launch launch)
        {
            var launchDB = await FindByIdAsync(launch.Id);

            launchDB.Status = launch.Status;
            launchDB.Description = launch.Description;
            launchDB.Amount = launch.Amount;

            launchDB.UpdatedAt = DateTime.Now;
            await _launchRepository.UpdateAsync(launchDB);
        }
    }
}
