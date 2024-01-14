using NetCoreWithAngular.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCoreWithAngular.Logic.Abstract
{
    public interface ICardsService
    {
        Task<Card> CreateAsync(Card cardData);
        Task<Card> UpdateAsync(Card cardData);
        Task<Card?> GetAsync(Guid id);
        Task<List<Card?>> GetAllAsync();
    }
}
