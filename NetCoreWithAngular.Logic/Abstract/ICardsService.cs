using NetCoreWithAngular.BusinessLogic.Models;
using System;
using System.Collections.Generic;

namespace NetCoreWithAngular.Logic.Abstract
{
    public interface ICardsService
    {
        Card Create(Card cardData);
        Card Update(Card cardData);
        Card? Get(Guid id);
        List<Card> GetAll();
    }
}
