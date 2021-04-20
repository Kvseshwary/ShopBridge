using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopBridge.Attributes;
using ShopBridge.DataLibrary.Data;
using ShopBridge.Models;

namespace ShopBridge.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemData _itemData;

        public ItemController(IItemData itemData)
        {
            _itemData = itemData;
        }

        [HttpPost]
        [ValidateModel]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(ItemModel itemModel)
        {
            int id = await _itemData.CreateItem(itemModel);
            return Ok(new { Id =id});
        }

        [HttpGet]
        //[HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
       
        public async Task<IActionResult> Get(int Id)
        {
            if(Id==0)
            {
                throw new ArgumentException(
                    $"ID can't be zero{ Id}", nameof(Id));
            }
            
            var Item = await _itemData.GetItemById(Id);
            if (Item != null)
            {
                return Ok(Item);
            }

            else
            {
                return NotFound();
            }
        }
        [HttpGet]
        public async Task <List<ItemModel>> GetAll()
        {
            
             return  await _itemData.GetItem();
        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put([FromBody] ItemModel itemModel)
        {
            int id = await _itemData.UpdateItem(itemModel);
            return Ok(new { itemId = id });
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            await _itemData.DeleteItem(id);
            return Ok();
        }

    }
}
