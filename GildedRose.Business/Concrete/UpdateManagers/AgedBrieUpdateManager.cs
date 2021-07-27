using GildedRose.Business.Abstract;
using GildedRose.Models.Entities;
using System;

namespace GildedRose.Business.Concrete.UpdateManagers
{
    public class AgedBrieUpdateManager : IItemUpdateService
    {
        private readonly int QualityDegradation = +1;

        public void UpdateItem(Item item)
        {
            item.SellIn--;

            //The Quality of an item is never negative
            if (item.Quality < 0) item.Quality = 0;

            item.Quality = Math.Min(item.Quality + QualityDegradation, 50);
        }
    }
}
