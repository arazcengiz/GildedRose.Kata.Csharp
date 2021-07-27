using GildedRose.Business.Concrete.UpdateManagers;
using NUnit.Framework;

namespace GildedRose.Tests.BusinessTests.ConcreteTests.CreateManagersTests
{
    [TestFixture]
    public class StandardCreateManagerTests : CreateManagerTestsBase
    {
        [TestCase(Models.Static.StandardItemNames.DexterityVest)]
        [TestCase(Models.Static.StandardItemNames.Elixir)]
        public void CreateManager_ElixirTest(string itemName)
        {
            base.ItemName = itemName;
            base.Setup();

            base.Execute();

            Assert.IsInstanceOf<StandardUpdateManager>(base.UpdateService);
        }
    }
}
