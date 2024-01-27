using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCar.Context;
using MyCar.DTOs;
using MyCar.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyCar.Services.Interfaces
{
    public interface IAdvertisingService
    {
        public Task<List<AdvertisingModel>> GetAds();

        public Task<AdvertisingModel> GetAdById(int id);

        public Task CreateAd(AdvertisingDTO advertisingDTO);

        public Task UpdateAd(int id, AdvertisingDTO advertisingDTO);

        public Task RemoveAdById(int id);
    }

}
