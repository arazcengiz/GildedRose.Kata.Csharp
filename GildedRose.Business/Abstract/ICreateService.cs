using GildedRose.Models.Entities;

namespace GildedRose.Business.Abstract
{
    /// <summary>
    /// The interface is a base type for handling all stock-item operations.
    /// </summary>
    public interface ICreateService
    {
        /// <summary>
        /// Creates and returns an item using the passed in information.
        /// </summary>
        IItemUpdateService CreateUpdateService(string name);
    }
}
