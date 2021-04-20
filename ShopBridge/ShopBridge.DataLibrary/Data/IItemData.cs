using System.Collections.Generic;
using System.Threading.Tasks;
using ShopBridge.Models;

namespace ShopBridge.DataLibrary.Data
{
    public interface IItemData
    {
        Task<int> CreateItem(ItemModel itemModel);
        Task<int> DeleteItem(int ItemId);
        Task<List<ItemModel>> GetItem();
        Task<ItemModel> GetItemById(int ItemId);
        Task<int> UpdateItem(ItemModel itemModel);
    }
}