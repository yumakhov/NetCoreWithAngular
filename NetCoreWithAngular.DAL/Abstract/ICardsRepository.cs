using System.Collections.Generic;
using System;
using NetCoreWithAngular.DAL.Entities;
using System.Threading.Tasks;

namespace NetCoreWithAngular.DAL.Abstract
{
    public interface ICardsRepository
    {
        Task<CardDbo> CreateAsync(CardDbo card);
        Task<CardDbo> UpdateAsync(CardDbo card);
        Task<CardDbo?> GetAsync(Guid id);
        Task<List<CardDbo>> GetAllAsync();
    }
}
