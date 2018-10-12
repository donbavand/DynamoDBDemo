using System.Threading.Tasks;
using DynamoDb.Libs.Models;

namespace DynamoDb.Libs.DynamoDb
{
    public interface IUpdateItem
    {
        Task<Item> Update(int id, double price);
    }
}