using System.Threading.Tasks;
using Amazon.DynamoDBv2.Model;

namespace DynamoDb.Libs.DynamoDb
{
    public interface IDeleteTable
    {
        Task<DeleteTableResponse> ExecuteTableDelete(string tableName);
    }
}