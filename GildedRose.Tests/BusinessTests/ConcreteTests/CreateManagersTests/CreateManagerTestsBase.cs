using GildedRose.Business.Abstract;
using GildedRose.Business.Concrete.CreateManagers;
using GildedRose.Models.Entities;
using GildedRose.Tests.Common;
using NUnit.Framework;
using Rhino.Mocks;

namespace GildedRose.Tests.BusinessTests.ConcreteTests.CreateManagersTests
{
    [TestFixture]
    public abstract class CreateManagerTestsBase : TestingBase
    {
        //Services
        protected ICreateService MockCreateService { get; set; }
        protected ICreateService CreateService { get; set; }

        //Item related properties
        protected string ItemName;

        protected override void Setup()
        {
            Item = ItemBuilder.Build.HavingName(ItemName).GetInstance();

            MockCreateService = MockRepository.GenerateStub<ICreateService>();

            CreateService = new CreateManager();
        }

        protected override void Execute()
        {
            Setup();

            UpdateService = CreateService.CreateUpdateService(Item.Name);
        }
    }
}
