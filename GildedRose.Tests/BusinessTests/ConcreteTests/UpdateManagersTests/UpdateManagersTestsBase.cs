using GildedRose.Tests.Common;

namespace GildedRose.Tests.BusinessTests.ConcreteTests.UpdateManagersTests
{
    public abstract class UpdateManagersTestsBase : TestingBase
    {
        //Props
        protected int CurrentSellin { get; set; }
        protected int ExpectedSellin { get; set; }
        protected int CurrentQuality { get; set; }
        protected int ExpectedQuality { get; set; }

        //Methods
        protected override void Setup()
        {
            base.Item = ItemBuilder.Build.GetInstance();
        }

        protected override void Execute()
        {
            Setup();

            base.UpdateService.UpdateItem(base.Item);
        }
    }
}
