using GildedRose.Business.Abstract;
using GildedRose.Models.Entities;
using System;

namespace GildedRose.Business.Concrete.UpdateManagers
{
    public class ConjuredUpdateManager : IItemUpdateService
    {
        //"Conjured" items degrade in Quality twice as fast as normal items
        private readonly int QualityDegradation = -2;

        public void UpdateItem(Item item)
        {
            item.SellIn--;

            if(item.SellIn < 0)
            {
                //The Quality of an item is never negative
                //Once the sell by date has passed, Quality degrades twice as fast
                item.Quality = Math.Max(item.Quality + 2 * QualityDegradation, 0);
            }
            else
            {
                //The Quality of an item is never negative
                item.Quality = Math.Max(item.Quality + QualityDegradation, 0);
            }
        }
    }
}
