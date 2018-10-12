using System.Collections.Generic;

namespace DynamoDb.Libs.Models
{
    public class DynamoTableItems
    {
        public IEnumerable<Item> Items { get; set; }
    }
}