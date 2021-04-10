using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using ShopBridge.DataLibrary.Db;
using ShopBridge.Models;

namespace ShopBridge.DataLibrary.Data
{

    public class ItemData : IItemData
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionStringData;

        public ItemData(IDataAccess dataAccess, ConnectionStringData connectionStringData)
        {
            _dataAccess = dataAccess;
            _connectionStringData = connectionStringData;
        }

        public Task<List<ItemModel>> GetItem()
        {
            return _dataAccess.LoadData<ItemModel, dynamic>("dbo.sp_GetItems", new { },
                                                            _connectionStringData.SqlConnectionName);
        }

        public async Task<int> CreateItem(ItemModel itemModel)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("Name", itemModel.Name);
            p.Add("Description", itemModel.Description);
            p.Add("Price", itemModel.Price);
            p.Add("Quantity", itemModel.Quantity);
            p.Add("ItemId", DbType.Int32, direction: ParameterDirection.Output);
            await _dataAccess.SaveData("dbo.sp_ItemInsert", p, _connectionStringData.SqlConnectionName);

            return p.Get<int>("ItemId");
        }

        public async Task<int> UpdateItem(ItemModel itemModel)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("Name", itemModel.Name);
            p.Add("Description", itemModel.Description);
            p.Add("Price", itemModel.Price);
            p.Add("Quantity", itemModel.Quantity);
            p.Add("ItemId", DbType.Int32, direction: ParameterDirection.Output);
            await _dataAccess.SaveData("dbo.sp_ItemUpdate", p, _connectionStringData.SqlConnectionName);
            return p.Get<int>("ItemId");
        }


        public Task<int> DeleteItem(int ItemId)
        {


            return _dataAccess.SaveData("dbo.sp_ItemDelete",
                                        new
                                        {
                                            ItemId = ItemId

                                        }, _connectionStringData.SqlConnectionName);



        }

        public async Task<ItemModel> GetItemById(int ItemId)
        {
            var recs = await _dataAccess.LoadData<ItemModel, dynamic>("dbo.sp_ItemGetById",
                new
                {
                    ItemId = ItemId
                }, _connectionStringData.SqlConnectionName);

            return recs.FirstOrDefault();
        }
    }
}

