using GildedRose.Business.Concrete.UpdateManagers;
using GildedRose.Tests.Common;
using NUnit.Framework;

namespace GildedRose.Tests.BusinessTests.ConcreteTests.UpdateManagersTests
{
    [TestFixture]
    public class BackstagePassesUpdateManagerTests : UpdateManagersTestsBase
    {
        protected override void Setup()
        {
            base.Item = ItemBuilder.Build
                .HavingName(Models.Static.NonStandardItemNames.BackstagePasses)
                .HavingSellin(CurrentSellin)
                .HavingQuality(CurrentQuality).GetInstance();
            base.UpdateService = new BackstagePassesUpdateManager();
        }
        
        [TestCase(15, 10, 11)]
        public void UpdateManager_UpdateQualityTest(int sellIn, int quality, int expectedQuality)
        {
            CurrentQuality = quality;
            CurrentSellin = sellIn;
            
            base.Execute();

            Assert.AreEqual(Item.Quality, expectedQuality);
        }

        /// <summary>
        /// Quality increases by 2 when there are 10 days or less
        /// </summary>
        [TestCase(10, 10, 12)]
        public void UpdateManager_UpdateQualityLessThan10DaysTest(int sellIn, int quality, int expectedQuality)
        {
            CurrentQuality = quality;
            CurrentSellin = sellIn;
            
            base.Execute();

            Assert.AreEqual(Item.Quality, expectedQuality);
        }

        /// <summary>
        /// Quality increases by 3 when there are 5 days or less
        /// </summary>
        [TestCase(5, 10, 13)]
        public void UpdateManager_UpdateQualityLessThan5DaysTest(int sellIn, int quality, int expectedQuality)
        {
            CurrentQuality = quality;
            CurrentSellin = sellIn;
            
            base.Execute();

            Assert.AreEqual(Item.Quality, expectedQuality);
        }

        /// <summary>
        /// Quality drops to 0 after the concert
        /// </summary>
        [TestCase(0, 10, 0)]
        public void UpdateManager_UpdateQualityLessThan0DaysTest(int sellIn, int quality, int expectedQuality)
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
