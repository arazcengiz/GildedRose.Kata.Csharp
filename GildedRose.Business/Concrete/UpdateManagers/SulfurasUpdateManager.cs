using GildedRose.Business.Abstract;
using GildedRose.Models.Entities;

namespace GildedRose.Business.Concrete.UpdateManagers
{
    public class SulfurasUpdateManager : IItemUpdateService
    {
        public void UpdateItem(Item item)
        {
            //No need to update the sulfuras SellIn value (legendary items) based on the following qoute.
            //"Sulfuras", being a legendary item, never has to be sold or decreases in Quality

            //Updating its quality to 80 based on the following quote
            //however "Sulfuras" is a legendary item and as such its Quality is 80 and it never alters
            item.Quality = 80;
        }
    }
}
