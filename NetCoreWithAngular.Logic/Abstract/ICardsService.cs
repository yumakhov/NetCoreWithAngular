using NetCoreWithAngular.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NetCoreWithAngular.Logic.Abstract
{
    public interface ICardsService
    {
        Task<Card> CreateAsync(Card cardData, CancellationToken ct = default);
        Task<Card> UpdateAsync(Card cardData, CancellationToken ct = default);
        Task<Card?> GetAsync(Guid id, CancellationToken ct = default);
        Task<List<Card?>> GetAllAsync(CancellationToken ct = default);
    }
}
