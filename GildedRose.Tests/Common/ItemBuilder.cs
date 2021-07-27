using GildedRose.Models.Entities;

namespace GildedRose.Tests.Common
{
    /// <summary>
    /// Returns a builder class of Item for Testing
    /// </summary>
    public class ItemBuilder : BuilderBase<ItemBuilder, Item>
    {
        string _name = Models.Static.StandardItemNames.DexterityVest;
        int _sellin = 10;
        int _quality = 10;

        public override Item GetInstance()
        {
            return new Item
            {
                Name = _name,
                SellIn = _sellin,
                Quality = _quality
            };
        }

        public ItemBuilder HavingName(string name)
        {
            _name = name;
            return this;
        }

        public ItemBuilder HavingSellin(int sellin)
        {
            _sellin = sellin;
            return this;
        }

        public ItemBuilder HavingQuality(int quality)
        {
            _quality = quality;
            return this;
        }
    }
}
