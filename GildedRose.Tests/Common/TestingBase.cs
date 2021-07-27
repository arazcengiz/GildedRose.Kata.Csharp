using GildedRose.Business.Abstract;
using GildedRose.Models.Entities;

namespace GildedRose.Tests.Common
{
    public abstract class TestingBase
    {
        //Props
        protected IItemUpdateService UpdateService { get; set; }
        protected Item Item { get; set; }
        
        //Methods
        protected abstract void Setup();
        protected abstract void Execute();
    }
}
