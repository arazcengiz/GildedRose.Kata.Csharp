using GildedRose.Models.Entities;

namespace GildedRose.Business.Abstract
{
    /// <summary>
    /// The interface is a base type for handling all stock-item operations.
    /// </summary>
    public interface IItemUpdateService
    {
        /// <summary>
        /// Updates the information related to a specific item that is sent as parameter.
        /// </summary>
        void UpdateItem(Item item);
    }
}
