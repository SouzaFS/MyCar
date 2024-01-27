using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCar.Context;
using MyCar.DTOs;
using MyCar.Mappers;
using MyCar.Models;
using MyCar.Repositories;
using MyCar.Repositories.Interfaces;
using MyCar.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyCar.Services
{
    public class AdvertisingService : IAdvertisingService
    {
        private IBaseRepository<AdvertisingModel> _baseRepository = null;

        public AdvertisingService(){
            _baseRepository = new BaseRepository<AdvertisingModel>();
        }

        public async Task<List<AdvertisingModel>> GetAds()
        {
            return await _baseRepository.GetAll().ToListAsync();
        }
        public async Task<AdvertisingModel> GetAdById(int id)
        {
            var advertisingModel = await _baseRepository.GetByWhere(a => a.Id == id).FirstOrDefaultAsync();
            return advertisingModel != null ? advertisingModel : null;
        }

        public async Task CreateAd(AdvertisingDTO advertisingDTO)
        {
            await _baseRepository.CreateAsync(AdvertisingMapper.FromDTOToModel(advertisingDTO));
        }

        public async Task UpdateAd(int id, AdvertisingDTO advertisingDTO)
        {
            var advertisingModel = AdvertisingMapper.FromDTOToModel(advertisingDTO);
            advertisingModel.Id = id;
            await _baseRepository.UpdateAsync(advertisingModel);
        }

        public async Task RemoveAdById(int id)
        {
            var advertisingModel = await GetAdById(id);
            if (advertisingModel != null)
            {
                await _baseRepository.DeleteAsync(advertisingModel);
            }
        }
    }
    

}
