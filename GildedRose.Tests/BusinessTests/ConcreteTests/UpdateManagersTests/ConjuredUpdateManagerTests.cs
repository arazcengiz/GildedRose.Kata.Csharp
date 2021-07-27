using GildedRose.Business.Concrete.UpdateManagers;
using GildedRose.Tests.Common;
using NUnit.Framework;

namespace GildedRose.Tests.BusinessTests.ConcreteTests.UpdateManagersTests
{
    [TestFixture]
    public class ConjuredUpdateManagerTests : UpdateManagersTestsBase
    {
        protected override void Setup()
        {
            base.Item = ItemBuilder.Build
                .HavingName(Models.Static.NonStandardItemNames.Conjured)
                .HavingSellin(CurrentSellin)
                .HavingQuality(CurrentQuality).GetInstance();
            base.UpdateService = new ConjuredUpdateManager();
        }

        /// <summary>
        /// Testing that the quality of Aged Brie item is increased as expected after each update that is each day
        /// Once the sell by date has passed, Quality degrades twice as fast 
        /// </summary>
        [TestCase(10, 10, 8)]
        [TestCase(9, 11, 9)]
        [TestCase(5, 15, 13)]
        [TestCase(0, 15, 11)]
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
            ExpectedSellin = 19;

            CurrentQuality = 15;
            
            base.Execute();

            Assert.AreEqual(Item.SellIn, base.ExpectedSellin);
        }

        /// <summary>
        /// The Quality of an item is never more than 50
        /// </summary>
        [Test]
        public void UpdateManager_MaxQualityTest()
        {
            CurrentQuality = 50;
            
            base.Execute();

            Assert.LessOrEqual(Item.Quality, 50);
        }

        /// <summary>
        /// The Quality of an item is never negative
        /// </summary>
        [Test]
        public void UpdateManager_MinQualityTest()
        {
            CurrentSellin = 0;
            CurrentQuality = 0;
            
            base.Execute();

            Assert.GreaterOrEqual(Item.Quality , 0);
        }
    }
}
