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

        public async Task<List<AdvertisingDTO>> GetAds()
        {
            return AdvertisingMapper.FromModelToDTOList(await _baseRepository.GetAll().ToListAsync());
        }

        //Estudos para próxima etapa:
        //Linq, Lambda, Ternário
        //Modelagem de Banco de Dados
            //5 formas normais, normalização de banco de dados
        //Diagrama Entidade Relacionamento
            //Gerar diagrama de Entidade Relacionamento com base no Só Carrão
        //Diagrama de Classe UML

        public async Task<AdvertisingDTO> GetAdById(int id)
        {
            var AdvertisingDTO = await _baseRepository.GetByWhere(a => a.Id == id).FirstOrDefaultAsync();
            return AdvertisingDTO != null ? AdvertisingMapper.FromModelToDTO(AdvertisingDTO) : null;
        }

        public async Task CreateAd(AdvertisingDTO AdvertisingDTO)
        {
            await _baseRepository.CreateAsync(AdvertisingMapper.FromDTOToModel(AdvertisingDTO));
        }

        public async Task UpdateAd(int id, AdvertisingDTO AdvertisingDTO)
        {
            var AdvertisingModel = AdvertisingMapper.FromDTOToModel(AdvertisingDTO);
            AdvertisingModel.Id = id;
            await _baseRepository.UpdateAsync(AdvertisingModel);
        }

        public async Task RemoveAdById(int id)
        {
            var AdvertisingDTO = await GetAdById(id);
            var AdvertisingModel = AdvertisingMapper.FromDTOToModel(AdvertisingDTO);
            AdvertisingModel.Id = id;
            await _baseRepository.DeleteAsync(AdvertisingModel);
        }
    }
    

}
