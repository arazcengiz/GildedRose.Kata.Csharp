using GildedRose.Business.Abstract;
using System;

namespace GildedRose.Business.Concrete.CreateManagers
{
    public class CreateManager : ICreateService
    {
        public IItemUpdateService CreateUpdateService(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name), "The Name property cannot be null or empty");
            }

            switch (name)
            {
                case Models.Static.NonStandardItemNames.AgedBrie:
                    return new UpdateManagers.AgedBrieUpdateManager();
                case Models.Static.NonStandardItemNames.BackstagePasses:
                    return new UpdateManagers.BackstagePassesUpdateManager();
                case Models.Static.NonStandardItemNames.Sulfuras:
                    return new UpdateManagers.SulfurasUpdateManager();
                case Models.Static.NonStandardItemNames.Conjured:
                    return new UpdateManagers.ConjuredUpdateManager();
                default:
                    return new UpdateManagers.StandardUpdateManager();
            }
        }
    }
}
