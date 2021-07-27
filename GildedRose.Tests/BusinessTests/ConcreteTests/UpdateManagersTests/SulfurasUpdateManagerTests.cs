using GildedRose.Business.Concrete.UpdateManagers;
using GildedRose.Tests.Common;
using NUnit.Framework;

namespace GildedRose.Tests.BusinessTests.ConcreteTests.UpdateManagersTests
{
    [TestFixture]
    public class SulfurasUpdateManagerTests : UpdateManagersTestsBase
    {
        protected override void Setup()
        {
            base.Item = ItemBuilder.Build
                .HavingName(Models.Static.NonStandardItemNames.Sulfuras)
                .HavingSellin(CurrentSellin)
                .HavingQuality(CurrentQuality).GetInstance();
            base.UpdateService = new SulfurasUpdateManager();
        }

        /// <summary>
        /// Testing that the quality of Aged Brie item is increased as expected after each update that is each day
        /// Once the sell by date has passed, Quality degrades twice as fast 
        /// </summary>
        [TestCase(10, 10, 80)]
        [TestCase(9, 11, 80)]
        [TestCase(5, 15, 80)]
        [TestCase(0, 15, 80)]
        public void UpdateManager_UpdateQualityTest(int sellIn, int quality, int expectedQuality)
        {
            CurrentQuality = quality;
            CurrentSellin = sellIn;
            
            base.Execute();

            Assert.AreEqual(Item.Quality, expectedQuality);
        }

        [Test]
        public void UpdateManager_UpdateSellInTest()
        {
            CurrentSellin = 20;
            ExpectedSellin = 20;
            
            base.Execute();

            Assert.AreEqual(Item.SellIn, base.ExpectedSellin);
        }

        /// <summary>
        /// The Quality of an item is never more than 50
        /// </summary>
        [Test]
        public void UpdateManager_MaxQualityTest()
        {
            CurrentQuality = 10;
            
            base.Execute();

            Assert.AreEqual(80, Item.Quality);
        }
    }
}
