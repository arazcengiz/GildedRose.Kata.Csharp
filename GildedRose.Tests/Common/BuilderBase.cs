using System;

namespace GildedRose.Tests.Common
{
    public abstract class BuilderBase<TBuilderType, TBuildType>
    {
        public abstract TBuildType GetInstance();

        public static TBuilderType Build
        {
            get
            {
                return Activator.CreateInstance<TBuilderType>();
            }
        }
    }
}