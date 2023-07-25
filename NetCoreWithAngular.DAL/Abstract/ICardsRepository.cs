using System.Collections.Generic;
using System;
using NetCoreWithAngular.DAL.Entities;

namespace NetCoreWithAngular.DAL.Abstract
{
    public interface ICardsRepository
    {
        CardDbo Create(CardDbo card);
        CardDbo Update(CardDbo card);
        CardDbo? Get(Guid id);
        List<CardDbo> GetAll();
    }
}
