using System.Threading.Tasks;
using DynamoDb.Libs.DynamoDb;
using Microsoft.AspNetCore.Mvc;

namespace DynamoDb.Controllers
{
    [Produces("application/json")]
    [Route("api/DynamoDb")]
    public class DynamoDbController : Controller
    {
        private readonly ICreateTable _createTable;
        private readonly IPutItem _putItem;
        private readonly IGetItem _getItem;
        private readonly IUpdateItem _updateItem;
        private readonly IDeleteTable _deleteTable;

        public DynamoDbController(ICreateTable createTable, IPutItem putItem, IGetItem getItem, IUpdateItem updateItem, IDeleteTable deleteTable)
        {
            _createTable = createTable;
            _putItem = putItem;
            _getItem = getItem;
            _updateItem = updateItem;
            _deleteTable = deleteTable;
        }

        [Route("createtable")]
        public IActionResult CreateDynamoDbTable()
        {
            _createTable.CreateDynamoDbTable();

            return Ok();
        }

        [Route("putitems")]
        public IActionResult PutItem([FromQuery] int id, string replyDateTime, double price)
        {
            _putItem.AddNewEntry(id, replyDateTime, price);

            return Ok();
        }

        [Route("getitems")]
        public async Task<IActionResult> GetItems([FromQuery] int? id)
        {
            var response = await _getItem.GetItems(id);

            return Ok(response);
        }

        [HttpPut]
        [Route("updateitem")]
        public async Task<IActionResult> UpdateItem([FromQuery] int id, double price)
        {
            var response = await _updateItem.Update(id, price);

            return Ok(response);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteTable([FromQuery] string tableName)
        {
            var response = await _deleteTable.ExecuteTableDelete(tableName);

            return Ok(response);
        }

    }
}