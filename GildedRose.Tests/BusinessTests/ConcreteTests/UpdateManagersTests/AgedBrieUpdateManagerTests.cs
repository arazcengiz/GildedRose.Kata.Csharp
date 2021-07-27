using GildedRose.Business.Concrete.UpdateManagers;
using GildedRose.Tests.Common;
using NUnit.Framework;

namespace GildedRose.Tests.BusinessTests.ConcreteTests.UpdateManagersTests
{
    [TestFixture]
    public class AgedBrieUpdateManagerTests : UpdateManagersTestsBase
    {
        protected override void Setup()
        {
            base.Item = ItemBuilder.Build
                .HavingName(Models.Static.NonStandardItemNames.AgedBrie)
                .HavingSellin(CurrentSellin)
                .HavingQuality(CurrentQuality).GetInstance();
            base.UpdateService = new AgedBrieUpdateManager();
        }

        /// <summary>
        /// Testing that the quality of Aged Brie item is increased as expected after each update that is each day
        /// </summary>
        [TestCase(10, 10, 11)]
        [TestCase(9, 11, 12)]
        [TestCase(5, 15, 16)]
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

            Assert.GreaterOrEqual(Item.Quality, 0);
        }
    }
}
