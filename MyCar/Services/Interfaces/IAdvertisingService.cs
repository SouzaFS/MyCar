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
        public Task<List<AdvertisingDTO>> GetAds();

        public Task<AdvertisingDTO> GetAdById(int id);

        public Task CreateAd(AdvertisingDTO AdvertisingDTO);

        public Task UpdateAd(int id, AdvertisingDTO AdvertisingDTO);

        public Task RemoveAdById(int id);
    }

}
