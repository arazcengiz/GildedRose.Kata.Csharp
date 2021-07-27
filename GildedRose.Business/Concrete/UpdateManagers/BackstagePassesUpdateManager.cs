using GildedRose.Business.Abstract;
using GildedRose.Models.Entities;
using System;

namespace GildedRose.Business.Concrete.UpdateManagers
{
    public class BackstagePassesUpdateManager : IItemUpdateService
    {
        private readonly int QualityDegradation = +1;

        public void UpdateItem(Item item)
        {
            item.SellIn--;

            //The Quality of an item is never negative
            if (item.Quality < 0) item.Quality = 0;

            if (item.SellIn < 0)
            {
                item.Quality = 0;
            }
            else if (item.SellIn < 5)
            {
                item.Quality = Math.Min(item.Quality + 3 * QualityDegradation, 50);
            }
            else if (item.SellIn < 10)
            {
                item.Quality = Math.Min(item.Quality + 2 * QualityDegradation, 50);
            }
            else
            {
                item.Quality = Math.Min(item.Quality + QualityDegradation, 50);
            }
        }
    }
}
