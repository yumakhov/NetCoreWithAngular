using System.Collections.Generic;
using System;
using NetCoreWithAngular.DAL.Entities;
using System.Threading.Tasks;
using System.Threading;

namespace NetCoreWithAngular.DAL.Abstract
{
    public interface ICardsRepository
    {
        Task<CardDbo> CreateAsync(CardDbo card, CancellationToken ct = default);
        Task<CardDbo> UpdateAsync(CardDbo card, CancellationToken ct = default);
        Task DeleteAsync(Guid id, CancellationToken ct = default);
        Task<CardDbo?> GetAsync(Guid id, CancellationToken ct = default);
        Task<List<CardDbo>> GetAllAsync(CancellationToken ct = default);
    }
}
