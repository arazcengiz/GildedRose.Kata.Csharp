using GildedRose.Business.Concrete.UpdateManagers;
using NUnit.Framework;

namespace GildedRose.Tests.BusinessTests.ConcreteTests.CreateManagersTests
{
    [TestFixture]
    public class NonStandardCreateManagerTests : CreateManagerTestsBase
    {
        [Test]
        public void CreateManager_AgedBrieTest()
        {
            base.ItemName = Models.Static.NonStandardItemNames.AgedBrie;
            base.Setup();

            base.Execute();

            Assert.IsInstanceOf<AgedBrieUpdateManager>(base.UpdateService);
        }

        [Test]
        public void CreateManager_BackstagePassesTest()
        {
            base.ItemName = Models.Static.NonStandardItemNames.BackstagePasses;
            base.Setup();

            base.Execute();

            Assert.IsInstanceOf<BackstagePassesUpdateManager>(base.UpdateService);
        }

        [Test]
        public void CreateManager_ConjuredTest()
        {
            base.ItemName = Models.Static.NonStandardItemNames.Conjured;
            base.Setup();

            base.Execute();

            Assert.IsInstanceOf<ConjuredUpdateManager>(base.UpdateService);
        }

        [Test]
        public void CreateManager_SulfurasTest()
        {
            base.ItemName = Models.Static.NonStandardItemNames.Sulfuras;
            base.Setup();

            base.Execute();

            Assert.IsInstanceOf<SulfurasUpdateManager>(base.UpdateService);
        }
    }
}
